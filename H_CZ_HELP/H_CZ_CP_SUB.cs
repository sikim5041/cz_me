using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Duzon.Common.Forms.Help;
using Duzon.Common.Forms;
using System.Collections;
using Duzon.ERPU;
using C1.Win.C1FlexGrid;

namespace cz
{
    public partial class H_CZ_CP_SUB : HelpBase, IHelp
    {
        public H_CZ_CP_SUB(HelpParam helpParam) : base(helpParam)
        {
            InitializeComponent();
            base.SetIHelp = this as IHelp;

            InitGrid();

            DateTime time = Global.MainFrame.GetDateTimeToday();
            string year = "";

            year = time.ToString("yyyy") + "0101";

            dt일자.StartDate = DateTime.ParseExact(year, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt일자.EndDate = Global.MainFrame.GetDateTimeToday();

            SetDefault(base.Get타이틀명, flex, btn확인, btn검색, btn취소, txt검색);
            helpParam.QueryAction = QueryAction.RealTime;

            txt검색.Text = helpParam.P92_DETAIL_SEARCH_CODE;
        }

        private void InitGrid()
        {
            ArrayList list = new ArrayList();

            list.Add(new object[] { "cpid", "캠페인코드", 80 });
            list.Add(new object[] { "cpname", "캠페인명", 140 });
            list.Add(new object[] { "startdate", "시작일자", 80 });
            list.Add(new object[] { "enddate", "종료일자", 80 });
            list.Add(new object[] { "closed", "마감여부", 50 });

            base.InitGrid(flex, list);

            /*
            flex.Cols["AM_GIMALMISU"].DataType = typeof(decimal);
            flex.Cols["AM_GIMALMISU"].Format = "#,###";
            flex.Cols["AM_GIMALMISU"].TextAlign = TextAlignEnum.RightCenter;
            flex.SetStringFormatCol("AM_GIMALMISU");

            flex.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            flex.Cols["NO_COMPANY"].Format = "###-##-#####";
            flex.SetStringFormatCol("NO_COMPANY");
            */

            flex.SettingVersion = "1.1";
        }

        #region IHelp 멤버

        public DataTable SetDetail(string 검색)
        {
            string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
            string rdo_index = "";

            if (rdo마감.Checked == true)
            {
                rdo_index = "1";
            }
            else if (rdo미마감.Checked == true)
            {
                rdo_index = "0";
            }
            else
            {
                rdo_index = "";
            }

            object 마감여부 = rdo_index;
            object 시작일자 = dt일자.StartDateToString;
            object 종료일자 = dt일자.EndDateToString;

            List<object> parma = new List<object>();
            parma.Add(회사코드);
            parma.Add(base.GetHelpID);
            parma.Add(검색);

            MsgControl.ShowMsg("MTS 캠페인 목록을 조회중 입니다.");

            DataTable dt = DBHelper.GetDataTable("UP_H_CZ_CP_SUB_S", new object[] { 회사코드, 시작일자, 종료일자, 마감여부, 검색 });

            MsgControl.CloseMsg();

            flex.Focus();

            return dt;
        }

        public string Get검색
        {
            get { return txt검색.Text; }
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SetAfterSearch(RefreshSearch());
                    flex.Focus();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        //파라미터 1개
        private void H_CZ_PARAM1(ref List<object> parma)
        {
            parma.Add(GetListParam[0]);
        }

        //파라미터 2개
        private void H_CZ_PARAM2(ref List<object> parma)
        {
            parma.Add(GetListParam[0]);
            parma.Add(GetListParam[1]);
        }

        //파라미터 3개
        private void H_CZ_PARAM3(ref List<object> parma)
        {
            parma.Add(GetListParam[0]);
            parma.Add(GetListParam[1]);
            parma.Add(GetListParam[3]);
        }
        #endregion

    }
}
