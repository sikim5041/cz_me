using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_GR_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        #region -> 조회
        public DataSet Search_M(object[] obj) // 헤더부분
        {
            //string sp_name = "UP_CZ_MEZZO_SALESGR_H_S";
            //DataTable dt = DBHelper.GetDataTable(sp_name, obj);
            //return dt;

            return DBHelper.GetDataSet("UP_CZ_MEZZO_SALESGR_H_S", obj);
        }

        #endregion

        internal DataSet Search_D(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_MEZZO_SALESGR_D_S", obj);
        }

        internal bool Delete(string 지출결의번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_MEZZO_SALESGR_H_D", new object[] { 지출결의번호, 회사코드 });
        }

        internal bool DeleteD(string 지출결의번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_MEZZO_SALESGR_D_D", new object[] { 지출결의번호, 회사코드 });
        }

        public object Save_M(DataTable dtM)
        {

            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            if (dtM != null)
            {
                si = new SpInfo();
                //if (!타메뉴호출)
                //    si.DataState = DataValueState.Added;
                //else
                //    si.DataState = DataValueState.Modified;

                si.DataValue = dtM;
                si.CompanyID = 회사코드;
                si.UserID = 사용자ID;

                si.SpNameInsert = "UP_CZ_MEZZO_SALESGR_H_I";
                si.SpNameUpdate = "UP_CZ_MEZZO_SALESGR_H_U";
                si.SpNameDelete = "UP_CZ_MEZZO_SALESGR_H_D";
                si.SpParamsInsert = new string[] { "CD_COMPANY", "CD_MEDIAGR", "NM_MEDIAGR", "ID_INSERT" };
                si.SpParamsUpdate = new string[] { "CD_COMPANY", "CD_MEDIAGR", "NM_MEDIAGR", "ID_INSERT" };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "CD_MEDIAGR" };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }

        public object Save_D(DataTable dtD)
        {

            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            if (dtD != null)
            {
                SpInfo si1 = new SpInfo();
                si = new Duzon.Common.Util.SpInfo();

                //if (!타메뉴호출)
                //    si1.DataState = DataValueState.Added;

                si.DataValue = dtD;
                si.CompanyID = 회사코드;
                si.UserID = 사용자ID;
                si.SpNameInsert = "UP_CZ_MEZZO_SALESGR_D_I";
                si.SpNameDelete = "UP_CZ_MEZZO_SALESGR_D_D";
                si.SpParamsInsert = new string[] { "CD_COMPANY", "CD_MEDIAGR", "CD_PARTNER", "ID_INSERT" };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "CD_MEDIAGR", "CD_PARTNER" };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }
    }
}
