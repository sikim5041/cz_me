using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_MAP_EMP_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        #region -> 조회
        public DataTable Search_T(object[] obj) // 헤더부분
        {
            string sp_name = "UP_CZ_MEZZO_MEDIAGR_H_S";
            DataTable dt = DBHelper.GetDataTable(sp_name, obj);
            return dt;
        }

        #endregion

        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_MEZZO_SALESGR_D_S", obj);
        }

        internal DataSet Search_D(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_MEZZO_SALESGR_D_S", obj);
        }

        internal DataTable Get지출구분()
        {
            string sql = "SELECT '' CODE, '' NAME " +
                         "UNION " +
                         "SELECT CD_COMPANY, CD_MEDIAGR FROM CZ_MEZZO_MEDIAGR_D WHERE CD_COMPANY = '10' AND CD_COMPANY = '" + 회사코드 + "' AND YN_USE = 'Y'";

            return DBHelper.GetDataTable(sql);
        }

        internal bool Delete(string 지출결의번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_MEZZO_SALESGR_H_D", new object[] { 지출결의번호, 회사코드 });
        }

        internal bool DeleteD(string 지출결의번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_MEZZO_SALESGR_D_D", new object[] { 지출결의번호, 회사코드 });
        }

        public object Save(DataTable dtM, DataTable dtD, bool 타메뉴호출)
        {

            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            if (dtM != null)
            {
                si = new SpInfo();
                if (!타메뉴호출)
                    si.DataState = DataValueState.Added;
                else
                    si.DataState = DataValueState.Modified;

                si.DataValue = dtM;
                si.CompanyID = 회사코드;
                si.UserID = 사용자ID;

                si.SpNameInsert = "UP_CZ_MEZZO_SALESGR_H_I";
                si.SpNameUpdate = "UP_CZ_MEZZO_SALESGR_H_U";
                si.SpParamsInsert = new string[] { "NO_IV", "CD_COMPANY", "CD_BIZAREA", "NO_BIZAREA", "FG_TPPURCHASE", "CD_PARTNER", "FG_TRANS", "AM_K", "VAT_TAX", "RT_EXCH", "CD_EXCH", "AM_EX","DT_PROCESS", 
                                               "FG_TAX", "CD_DEPT", "NO_EMP", "YN_PURSUB", "YN_EXPIV", "ID_INSERT", "DC_RMK", "FG_PAYBILL","DT_PAY_PREARRANGED",
                                               "CD_BIZAREA_TAX", "YN_JEONJA", "CD_PC_USER", "NO_DEPOSIT", "TXT_USERDEF1", "TP_SUMTAX", "TP_EVIDENCE" };
                si.SpParamsUpdate = new string[] { "NO_IV", "CD_COMPANY", "CD_BIZAREA", "NO_BIZAREA", "FG_TPPURCHASE", "CD_PARTNER", "FG_TRANS", "AM_K", "VAT_TAX", "RT_EXCH", "CD_EXCH", "AM_EX","DT_PROCESS", 
                                               "FG_TAX", "CD_DEPT", "NO_EMP", "YN_PURSUB", "YN_EXPIV", "ID_UPDATE", "DC_RMK", "FG_PAYBILL","DT_PAY_PREARRANGED",
                                               "CD_BIZAREA_TAX", "YN_JEONJA", "CD_PC_USER", "NO_DEPOSIT", "TXT_USERDEF1", "TP_SUMTAX", "TP_EVIDENCE" };
                sic.Add(si);
            }

            if (dtD != null)
            {
                SpInfo si1 = new SpInfo();
                si1 = new Duzon.Common.Util.SpInfo();

                //if (!타메뉴호출)
                //    si1.DataState = DataValueState.Added;

                si1.DataValue = dtD;
                si1.CompanyID = 회사코드;
                si1.UserID = 사용자ID;
                si1.SpNameInsert = "UP_CZ_MEZZO_SALESGR_D_I";
                si1.SpParamsInsert = new string[] { "NO_IV", "NO_IVLINE", "CD_COMPANY", "CD_PLANT", "NO_IO", "CD_ITEM",
                                                "CD_PURGRP", "DT_TAX", "UM", "AM_IV", "VAT_IV", "NO_EMP", "CD_PJT",  
                                                "FG_TPPURCHASE", "NO_PO", "CD_EXCH", "RT_EXCH", "UM_EX", "AM_EX", 
                                                "QT_CLS", "NO_WBS", "NO_CBS","TP_UM_TAX","MEMO_CD","CHECK_PEN","REMARK",
                                                "ACCT_NO", "BANK_CODE", "TRADE_DATE", "TRADE_TIME", "SEQ", "YN_CAL",
                                                "CD_ITEM_PARENTS", "CD_BUDGET", "TP_CAL", "CD_NATION", "FG_TAX", "TRADE_PLACE", "ID_INSERT" };
                sic.Add(si1);
            }
            
            return Global.MainFrame.Save(sic);
        }

    }
}
