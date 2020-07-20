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

namespace cz
{
    public partial class H_CZ_CARD_SUB : HelpBase, IHelp
    {
        public H_CZ_CARD_SUB(HelpParam helpParam) : base(helpParam)
        {
            InitializeComponent();
            base.SetIHelp = this as IHelp;

            InitGrid();

            DataSet ds = Global.MainFrame.GetComboData("S;FI_B000016", "S;MA_B000057");

            SetControl st = new SetControl();
            st.SetCombobox(cbo신용카드구분, ds.Tables[0]);
            st.SetCombobox(cbo사용여부, ds.Tables[1]);

            cbo사용여부.SelectedValue = "Y";

            SetDefault(base.Get타이틀명, flex, btn확인, btn검색, btn취소, txt검색);
            helpParam.QueryAction = QueryAction.RealTime;

            txt검색.Text = helpParam.P92_DETAIL_SEARCH_CODE;
        }

        private void InitGrid()
        {
            ArrayList list = new ArrayList();

            list.Add(new object[] { "NM_ST_CARD", "신용카드구분", 100 });
            list.Add(new object[] { "NO_CARD", "신용카드번호", 130 });
            list.Add(new object[] { "NM_CARD", "카드명", 120 });
            list.Add(new object[] { "NM_OWNER", "소유자", 80 });
            list.Add(new object[] { "NM_MDEPT", "관리부서", 120 });
            list.Add(new object[] { "NM_EMP", "관리사원", 80 });

            base.InitGrid(flex, list);

            flex.SettingVersion = "1.0";
        }

        #region IHelp 멤버

        public DataTable SetDetail(string 검색)
        {
            string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
            object 신용카드구분 = cbo신용카드구분.SelectedValue;
            object 사용여부 = cbo사용여부.SelectedValue;

            List<object> parma = new List<object>();
            parma.Add(회사코드);
            parma.Add(base.GetHelpID);
            parma.Add(검색);

            return DBHelper.GetDataTable("UP_H_CZ_CARD_SUB_S", new object[] { 회사코드, 신용카드구분, 사용여부, 검색, GetListParam[0] });
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
