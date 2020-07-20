using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Duzon.ERPU;
using Duzon.Common.Forms;
using Duzon.Common.Forms.Help;
using Duzon.Common.Forms.Help.Forms;
using Duzon.ERPU.MF;

namespace cz
{
    [UserHelpDescription("기본도움창", "기본도움창을 가져옵니다.", "CODE", "NAME")]

    public partial class H_CZ_SM_PITEM_SUB : HelpBase, IHelp
    {
        private string 아이템타입 = string.Empty;
        private string 아이템군 = string.Empty;

        public H_CZ_SM_PITEM_SUB()
        {
            InitializeComponent();
        }

        public H_CZ_SM_PITEM_SUB(HelpParam helpParam)
            : base(helpParam)
        {
            helpParam.IsRequireSearchKey = true;

            InitializeComponent();
            base.SetIHelp = this as IHelp;

            InitGrid();

            SetDefault(base.Get타이틀명, flex, _bnOk, _bnSearch, _bnCancel, _txt검색);
            helpParam.QueryAction = QueryAction.RealTime;

            _txt검색.Text = helpParam.P92_DETAIL_SEARCH_CODE;
        }

        #region ♪ override 메서드 ♪

        protected override void InitPaint()
        {
            _txt검색.Focus();
        }
        //그리드 초기화
        private void InitGrid()
        {
            ArrayList list = new ArrayList();

            switch (base.GetHelpID)
            {
                case "H_CZ_SM_PITEM_SUB1":         //수주에서 사용 : 계약번호 연결된 아이템만 보여줌
                    list.Add(new object[] { "CD_ITEM", "아이템코드", 80 });
                    list.Add(new object[] { "NM_ITEM", "아이템명", 100 });
                    list.Add(new object[] { "STND_ITEM", "규격", 100 });
                    list.Add(new object[] { "UNIT_SO", "수주단위", 80 });
                    list.Add(new object[] { "UNIT_IM", "재고단위", 80 });
                    list.Add(new object[] { "TP_ITEM", "품목타입", 80 });
                    list.Add(new object[] { "CD_SL", "창고코드", 80 });
                    list.Add(new object[] { "NM_SL", "창고명", 100 });
                    list.Add(new object[] { "UNIT_SO_FACT", "수주단위수량", 80 });
                    list.Add(new object[] { "LT_GI", "출하LT", 80 });
                    list.Add(new object[] { "WEIGHT", "중량", 80 });
                    list.Add(new object[] { "UNIT_WEIGHT", "중량단위", 80 });
                    //list.Add(new object[] { "YN_ATP", "ATP적용여부", 210 });
                    //list.Add(new object[] { "CUR_ATP_DAY", "ATP적용기한", 210 });
                    list.Add(new object[] { "GRP_MFG", "제품군", 80 });
                    list.Add(new object[] { "NM_GRP_MFG", "제품군명", 100 });
                    list.Add(new object[] { "CD_CONTRACT", "계약코드", 80 });
                    list.Add(new object[] { "SEQ", "계약품목항번", 80 });
                    list.Add(new object[] { "QT_SO", "수량", 80 });
                    list.Add(new object[] { "UM_SO", "단가", 80 });
                    list.Add(new object[] { "RATE", "요율", 80 });
                    //list.Add(new object[] { "AM_SO", "수주금액", 210 });
                    //list.Add(new object[] { "AM_WONAMT", "수주금액(원화)", 210 });
                    //list.Add(new object[] { "AM_VAT", "부가세", 210 });
                    //list.Add(new object[] { "AMVAT_SO", "합계금액", 210 });
                    list.Add(new object[] { "PARTNER", "주거래처", 80 });
                    list.Add(new object[] { "LN_PARTNER", "주거래처명", 100 });
                    list.Add(new object[] { "REMARK", "비고", 120 });
                    break;

                case "H_CZ_SM_PITEM_SUB":           //아이템 도움창
                case "H_CZ_SM_PITEM_PUIV_SUB":      //지출결의등록(일반경비)에서 사용 : 회계계정매핑등록에 연결된 아이템만 보여줌
                    list.Add(new object[] { "CD_ITEM", "아이템코드", 100 });
                    list.Add(new object[] { "NM_ITEM", "아이템명", 150 });
                    list.Add(new object[] { "EN_ITEM", "아이템명(영) ", 100 });
                    list.Add(new object[] { "DTS_INSERT", "입력일자", 150 });
                    list.Add(new object[] { "STND_ITEM", "규격", 100 });
                    list.Add(new object[] { "STND_DETAIL_ITEM", "세부규격", 100 });
                    list.Add(new object[] { "UNIT_IMNM", "재고단위", 70 });
                    list.Add(new object[] { "CLS_ITEMNM", "아이템계정명", 100 });
                    list.Add(new object[] { "NM_GRP_MFG", "제품군명", 100 });
                    list.Add(new object[] { "NM_MAKER", "모델명", 100 });
                    list.Add(new object[] { "TP_ITEM", "아이템타입", 80 });
                    list.Add(new object[] { "NM_TPITEM", "아이템타입명", 100 });
                    list.Add(new object[] { "GRP_MFG", "아이템군", 80 });
                    list.Add(new object[] { "NM_GRP_MFG", "아이템군명", 100 });
                    list.Add(new object[] { "MAT_ITEM", "재질", 100 });
                    list.Add(new object[] { "GRP_ITEM", "예산계정", 100 });
                    list.Add(new object[] { "NM_GRP_ITEM", "예산계정명", 100 });                    
                    break;

                case "H_CZ_SM_PITEM_SUB4":
                    list.Add(new object[] { "CD_PITEM", "아이템코드", 100 });
                    list.Add(new object[] { "NM_PITEM", "아이템명", 150 });
                    list.Add(new object[] { "EN_ITEM", "아이템명(영) ", 100 });
                    list.Add(new object[] { "STND_ITEM", "규격", 100 });
                    list.Add(new object[] { "STND_DETAIL_ITEM", "세부규격", 100 });
                    list.Add(new object[] { "UNIT_IMNM", "재고단위", 70 });
                    list.Add(new object[] { "CLS_ITEMNM", "아이템계정명", 100 });
                    list.Add(new object[] { "NM_GRP_MFG", "제품군명", 100 });
                    list.Add(new object[] { "NM_MAKER", "모델명", 100 });
                    list.Add(new object[] { "TP_ITEM", "아이템타입", 80 });
                    list.Add(new object[] { "NM_TPITEM", "아이템타입명", 100 });
                    list.Add(new object[] { "GRP_MFG", "아이템군", 80 });
                    list.Add(new object[] { "NM_GRP_MFG", "아이템군명", 100 });
                    list.Add(new object[] { "MAT_ITEM", "재질", 100 });
                    //list.Add(new object[] { "GRP_ITEM", "예산계정", 100 });
                    //list.Add(new object[] { "NM_GRP_ITEM", "예산계정명", 100 });
                    break;
            }

            if (base.GetHelpID == "H_CZ_SM_PITEM_SUB")
            {
                if (GetListParam.Count > 0)
                {
                    if (GetListParam[0] != string.Empty)
                        아이템타입 = GetListParam[0];
                }
                if (GetListParam.Count > 1)
                {
                    if (GetListParam[1] != string.Empty)
                        아이템군 = GetListParam[1];
                }
            }

            // 상단 조회조건
            string strQuery = string.Format(@" SELECT '' AS CD_SYSDEF, '' AS NM_SYSDEF  FROM MA_CODEDTL
                                                                                          UNION
                                                                                          SELECT CD_SYSDEF, NM_SYSDEF  FROM MA_CODEDTL
                                                                                          WHERE CD_FIELD = 'MA_B000011' AND CD_COMPANY = '{0}' AND USE_YN = 'Y' ", Global.MainFrame.LoginInfo.CompanyCode);
            DataTable dt품목타입 = DBHelper.GetDataTable(strQuery);
            cbo품목타입S.DataSource = dt품목타입.Copy();
            cbo품목타입S.DisplayMember = "NM_SYSDEF";
            cbo품목타입S.ValueMember = "CD_SYSDEF";

            if (아이템타입 != string.Empty)
                cbo품목타입S.SelectedValue = 아이템타입;
            else
                cbo품목타입S.SelectedIndex = 0;

            strQuery = string.Format(@"SELECT CD_SYSDEF, NM_SYSDEF, CD_FLAG1 FROM MA_CODEDTL
                                                                                WHERE CD_FIELD = 'MA_B000066' AND CD_COMPANY = '{0}' AND USE_YN = 'Y'  ", Global.MainFrame.LoginInfo.CompanyCode);
            DataTable dt아이템군 = DBHelper.GetDataTable(strQuery);
            cbo아이템군.DataSource = dt아이템군.Copy();
            cbo아이템군.DisplayMember = "NM_SYSDEF";
            cbo아이템군.ValueMember = "CD_SYSDEF";

            if (아이템군 != string.Empty)
            {
                cbo아이템군.SelectedValue = 아이템군;
                cbo품목타입S.Enabled = false;
            }
            else
                cbo아이템군.SelectedIndex = -1;

            cbo아이템군.Enabled = false;

            string strFilter = string.Format(@" CD_FLAG1 = '{0}' ", cbo품목타입S.SelectedValue);
            dt아이템군.DefaultView.RowFilter = strFilter;

            SetControl setctr = new SetControl();

            setctr.SetCombobox(cbo공장코드S, MF.GetCode(MF.코드.MASTER.공장));
            setctr.SetCombobox(cbo계정구분S, MF.GetCode(MF.코드.MASTER.품목.품목계정, true));

            base.InitGrid(flex, list);

            if (base.GetHelpID == "H_CZ_SM_PITEM_SUB")
            {
                flex.Cols["DTS_INSERT"].DataType = typeof(string);
                flex.Cols["DTS_INSERT"].Format = "####/##/##/##:##:##";
                flex.Cols["DTS_INSERT"].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
                flex.SetStringFormatCol("DTS_INSERT");
            }

            flex.SettingVersion = "1.3.4";

            cbo품목타입S.SelectionChangeCommitted += new EventHandler(cbo품목타입S_SelectionChangeCommitted);
        }

        void cbo품목타입S_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string strFilter = string.Format(@" CD_FLAG1 = '{0}' ", cbo품목타입S.SelectedValue);
            DataTable dt아이템군 = (DataTable)cbo아이템군.DataSource;
            dt아이템군.DefaultView.RowFilter = strFilter;

            if (cbo품목타입S.SelectedIndex == 0) cbo아이템군.Enabled = false;
            else cbo아이템군.Enabled = true;

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

        #endregion

        #region add 메서드

        #region 조건 입력 체크
        private bool FieldCheck(string flag)
        {
            if ((cbo품목타입S.SelectedValue == null || D.GetString(cbo품목타입S.SelectedValue) == string.Empty) &&
                      (cbo계정구분S.SelectedValue == null || D.GetString(cbo계정구분S.SelectedValue) == string.Empty) &&
                      (cbo아이템군.SelectedValue == null || D.GetString(cbo아이템군.SelectedValue) == string.Empty) &&
                      (bp예산계정s.CodeValue == null || bp예산계정s.CodeValue == string.Empty) &&
                      (_txt검색.Text == null || _txt검색.Text == string.Empty)
                      ) return false;
            else return true;
        }
        #endregion

        #endregion

        #region ♪ IHelp 멤버      ♪

        public DataTable SetDetail(string 검색)
        {
            DataTable dt = null;

            DialogResult result;

            if (!FieldCheck(""))
            {
                if (base.GetHelpID != "H_CZ_SM_PITEM_PUIV_SUB" && base.GetHelpID != "H_CZ_SM_PITEM_SUB4")
                {
                    result = Global.MainFrame.ShowMessage("설정된 조건이 없어 조회시간이 길어집니다. 조회하시겠습니까?", "QY2");
                    if (result == DialogResult.No)
                        return dt;
                }
            }

            string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
            string 아이템타입 = "";

            if (cbo품목타입S.SelectedValue != null)
                아이템타입 = cbo품목타입S.SelectedValue.ToString();

            string 아이템군 = "";
            if (cbo아이템군.SelectedValue != null)
                아이템군 = cbo아이템군.SelectedValue.ToString();

            string 아이템계정 = cbo계정구분S.SelectedValue.ToString();
            string 예산계정 = bp예산계정s.CodeValue;

            List<object> parma = new List<object>();
            parma.Add(회사코드);
            parma.Add(base.GetHelpID);
            parma.Add(검색);

            switch (base.GetHelpID)
            {
                case "H_CZ_SM_PITEM_SUB1":        // GetListParam[0] : 계약번호
                    dt = DBHelper.GetDataTable("UP_CZ_SO_CONTRACT_SUB_S2", new object[] { 회사코드, "1000", 아이템타입, 아이템군, 아이템계정, 예산계정, 검색, GetListParam[0] });
                    break;
                case "H_CZ_SM_PITEM_SUB":           // UP_H_CZ_SM_PITEM_SUB_S --> UP_H_CZ_SM_PITEM_SUB_S5
                    dt = DBHelper.GetDataTable("UP_H_CZ_SM_PITEM_SUB_S5", new object[] { 회사코드, "1000", 아이템타입, 아이템군, 아이템계정, 예산계정, 검색 });
                    break;
                case "H_CZ_SM_PITEM_PUIV_SUB":    // GetListParam[0] : 사업장, GetListParam[1] : 매입형태
                    dt = DBHelper.GetDataTable("UP_H_CZ_SM_PITEM_SUB_S3", new object[] { 회사코드, "1000", 아이템타입, 아이템군, 아이템계정, 예산계정, 검색, GetListParam[0], GetListParam[1] });
                    break;
                case "H_CZ_SM_PITEM_SUB4":    // GetListParam[0] : 사업장, GetListParam[1] : 매입형태
                    dt = DBHelper.GetDataTable("UP_H_CZ_SM_PITEM_SUB_S4", new object[] { 회사코드, "1000", 아이템타입, 아이템군, 아이템계정, 예산계정, 검색, GetListParam[0], GetListParam[1] });
                    break;
            }

            return dt;
        }

        public string Get검색
        {
            get { return _txt검색.Text; }
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