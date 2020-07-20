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
    public partial class H_CZ_PARTNER_SUB : HelpBase, IHelp
    {
        public H_CZ_PARTNER_SUB(HelpParam helpParam) : base(helpParam)
        {
            InitializeComponent();
            base.SetIHelp = this as IHelp;

            InitGrid();

            DataSet ds = Global.MainFrame.GetComboData("N;YESNO", "S;YESNO");

            SetControl st = new SetControl();
            st.SetCombobox(cbo미수금액반영여부, ds.Tables[0]);
            st.SetCombobox(cbo사용여부, ds.Tables[1]);

            cbo미수금액반영여부.SelectedValue = "N";
            cbo사용여부.SelectedValue = "Y";

            SetDefault(base.Get타이틀명, flex, btn확인, btn검색, btn취소, txt검색);
            helpParam.QueryAction = QueryAction.RealTime;

            txt검색.Text = helpParam.P92_DETAIL_SEARCH_CODE;
        }

        private void InitGrid()
        {
            ArrayList list = new ArrayList();

            list.Add(new object[] { "CD_PARTNER", "거래처코드", 90 });
            list.Add(new object[] { "LN_PARTNER", "거래처명", 140 });
            list.Add(new object[] { "SN_PARTNER", "거래처명(약칭)", 130 });
            list.Add(new object[] { "AM_GIMALMISU", "미수금액", 110 });
            list.Add(new object[] { "NO_COMPANY", "사업자등록번호", 100 });
            list.Add(new object[] { "NM_BANK", "은행명", 75 });
            list.Add(new object[] { "NO_DEPOSIT", "계좌번호", 120 });
            list.Add(new object[] { "NM_DEPOSIT", "예금주", 65 });
            list.Add(new object[] { "NM_CEO", "대표자명", 70 });

            base.InitGrid(flex, list);

            flex.Cols["AM_GIMALMISU"].DataType = typeof(decimal);
            flex.Cols["AM_GIMALMISU"].Format = "#,###";
            flex.Cols["AM_GIMALMISU"].TextAlign = TextAlignEnum.RightCenter;
            flex.SetStringFormatCol("AM_GIMALMISU");

            flex.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            flex.Cols["NO_COMPANY"].Format = "###-##-#####";
            flex.SetStringFormatCol("NO_COMPANY");

            flex.SettingVersion = "1.0";
        }

        #region IHelp 멤버

        public DataTable SetDetail(string 검색)
        {
            string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
            object 미수금액반영여부 = cbo미수금액반영여부.SelectedValue;
            object 사용여부 = cbo사용여부.SelectedValue;

            List<object> parma = new List<object>();
            parma.Add(회사코드);
            parma.Add(base.GetHelpID);
            parma.Add(검색);

            MsgControl.ShowMsg("매출거래처를 조회중 입니다.");

            DataTable dt = DBHelper.GetDataTable("UP_H_CZ_PARTNER_SUB_S", new object[] { 회사코드, 미수금액반영여부, 사용여부, 검색 });

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
