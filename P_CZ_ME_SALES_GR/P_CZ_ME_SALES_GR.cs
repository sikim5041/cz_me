using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.Common.BpControls;
using Duzon.Common.Forms;
using Duzon.ERPU;
using Duzon.ERPU.MF;
using Duzon.ERPU.MF.Common;
using Duzon.Windows.Print;
using Duzon.Common.Forms.Help;

namespace cz
{
    // **************************************
    // 작   성   자 : 이표
    // 재 작  성 일 : 2020-06-01
    // 모   듈   명 : 매체구분등록
    // 시 스  템 명 : 매체구분등록
    // 서브시스템명 : 매체구분등록
    // 페 이 지  명 : 매체구분등록
    // 프로젝트  명 : P_CZ_ME_MEDIA_GR
    // **************************************
    public partial class P_CZ_ME_SALES_GR : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_GR_BIZ _biz = new P_CZ_ME_SALES_GR_BIZ();

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_GR()
        {
            InitializeComponent();
            MainGrids = new FlexGrid[] { _flexM, _flexD };          
            _flexM.DetailGrids = new FlexGrid[] { _flexD }; 
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();

            InitGrid();
            //Page_DataChanged(null, null);
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
            //HEADER
            _flexM.BeginSetting(1, 1, true);

            _flexM.SetCol("CD_MEDIAGR", "구분코드", 80, false);
            _flexM.SetCol("NM_MEDIAGR", "매체구분명", 150, true);

            _flexM.Cols["CD_MEDIAGR"].TextAlign = TextAlignEnum.CenterCenter;  //구분코드
            _flexM.Cols["NM_MEDIAGR"].TextAlign = TextAlignEnum.LeftCenter;  //매체구분명

            _flexM.SettingVersion = "0.0.1.4";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            _flexM.SetDummyColumn( "CD_MEDIAGR");

            _flexM.AfterRowChange += new RangeEventHandler(_flexM_AfterRowChange);

            //DETAIL
            _flexD.BeginSetting(1, 1, false);

            _flexD.SetCol("CD_MEDIAGR", "구분코드", 0, false);
            _flexD.SetCol("CD_PARTNER", "매체ID", 90, true);
            _flexD.SetCol("biz_name", "매체명", 180, false);
            _flexD.SetCol("biz_name2", "사업자명", 180, false);
            _flexD.SetCol("biz_no", "사업자등록번호", 130, false);

            _flexD.Cols["CD_MEDIAGR"].TextAlign = TextAlignEnum.CenterCenter;  //매체구분코드
            _flexD.Cols["CD_PARTNER"].TextAlign = TextAlignEnum.CenterCenter;  //매체
            _flexD.Cols["biz_name"].TextAlign = TextAlignEnum.LeftCenter;  //매체명
            _flexD.Cols["biz_name2"].TextAlign = TextAlignEnum.LeftCenter;  //사업자명
            _flexD.Cols["biz_no"].TextAlign = TextAlignEnum.CenterCenter;  //사업자등록번호

            _flexD.SettingVersion = "0.0.1.5";// new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            _flexD.SetDummyColumn("CD_MEDIAGR");

            //_flexD.AllowEditing = true;

            _flexD.SetCodeHelpCol("CD_PARTNER", "H_CZ_HELP02", ShowHelpEnum.Always, new string[] { "CD_PARTNER", "biz_name", "biz_name2", "biz_no" }, new string[] { "CD_PARTNER", "biz_name", "biz_name2", "biz_no" });
            //_flexD.SetCodeHelpCol("CD_PARTNER_4", HelpID.P_MA_PARTNER_SUB1, ShowHelpEnum.Always, new string[] { "CD_PARTNER_4", "biz_name" }, new string[] { "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);
            //_flexD.StartEdit += new RowColEventHandler(_flexD_StartEdit);
            _flexD.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexD_BeforeCodeHelp);
            //_flexD.AfterRowChange += new RangeEventHandler(_flexD_AfterRowChange);
            
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                object[] Params = new object[1];
                object[] ParamsD = new object[2];
                Params[0] = LoginInfo.CompanyCode;
                //Params[1] = cboMEDIAGR_GUBUN.SelectedValue;       //결의유형 : CZ_SME_021 : 004 선급금결의

                DataSet ds = _biz.Search_M(Params);
                DataSet dsd;

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    _flexM.Binding = ds.Tables[0];

                    ParamsD[0] = LoginInfo.CompanyCode;
                    ParamsD[1] = D.GetString(_flexM["CD_MEDIAGR"]);

                    dsd = _biz.Search_D(ParamsD);

                    _flexD.Binding = dsd.Tables[0];
                }
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        #endregion


        #region -> 저장버튼클릭

        public override void OnToolBarSaveButtonClicked(object sender, EventArgs e)
        {

            try
            {
                if (!BeforeSaveChk())
                    return;

                if (SaveData())
                {
                    ShowMessage(PageResultMode.SaveGood);
                    {
                        //_flexM.AllowEditing = true;
                        //OnToolBarSearchButtonClicked(sender, e);
                        object[] Params = new object[1];
                        object[] ParamsD = new object[2];

                        Params[0] = LoginInfo.CompanyCode;

                        ParamsD[0] = LoginInfo.CompanyCode;
                        ParamsD[1] = D.GetString(_flexM["CD_MEDIAGR"]);

                        DataSet ds = _biz.Search_M(Params);

                        _flexM.Binding = ds.Tables[0];

                        DataSet dsd = _biz.Search_D(ParamsD);

                        _flexD.Binding = dsd.Tables[0];
                    }
                }
            }

            catch (Exception ex)
            {
                //ShowMessage("코드,ID를 입력해주세요");
                MsgEnd(ex);
            }
        }
        #endregion


        protected override bool SaveData()
        {

            object obj = null;

            if (_flexM.GetChanges() != null)
            {
                obj = _biz.Save_M(_flexM.GetChanges());
            }

            if (_flexD.GetChanges() != null)
            {
                obj = _biz.Save_D(_flexD.GetChanges());
            }

            return true;
        }

        protected bool BeforeSaveChk()
        {
          
            if (!_flexM.HasNormalRow)
            {
                ShowMessage("저장할 내용이 없습니다.");
                return false;
            }

            if (!_flexM.Verify())
                return false;

            if (!_flexD.Verify())
                return false;
         
            return true;
        }

        #region -> 삭제버튼클릭

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                if (!BeforeDelete())
                    return;

                //string Filter = "GUBUN_CODE  = '" + D.GetString(_flexM["GUBUN_CODE"]) + "'";
                //DataRow[] drArt = _flexArtist.DataTable.Select(Filter);

                _flexM.Rows.Remove(_flexM.Row);
                
                //if (!BeforeDelete())
                //    return;

                ////if (string.IsNullOrEmpty(D.GetString(txt결의번호.Text)))
                ////{
                ////    ShowMessage("결의번호를 먼저 선택하세요.");
                ////    return;
                ////}

                //DialogResult Result = ShowMessage(공통메세지.자료를삭제하시겠습니까, PageName);

                //if (Result != DialogResult.Yes)
                //    return;

                //if (_biz.Delete(D.GetString(cboMEDIAGR_GUBUN.SelectedValue)))
                //{
                    
                //    ShowMessage(공통메세지.자료가정상적으로삭제되었습니다);
                //}
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
        #endregion


        #region -> 추가버튼클릭

        public override void OnToolBarAddButtonClicked(object sender, EventArgs e)
        {
            try
            {
                _flexM.Rows.Add();
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }

        #endregion

        #endregion

        #region ♥ 기타 이벤트

        #region -> Control_QueryBefore

        private void Control_QueryBefore(object sender, Duzon.Common.BpControls.BpQueryArgs e)
        {
            BpCodeTextBox bp_Control = sender as BpCodeTextBox;
            try
            {
                switch (e.ControlName)
                {
                    case "ctxMEDIAGR":  //매체
                        e.HelpParam.IsRequireSearchKey = true;
                        break;

                    case "ctxPARTNER":   //사업자
                        e.HelpParam.IsRequireSearchKey = true;
                        break;

                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        #endregion

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion

        private void btn삭제_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BeforeDelete())
                    return;

                DialogResult Result = ShowMessage(공통메세지.자료를삭제하시겠습니까, PageName);

                if (Result != DialogResult.Yes)
                    return;

                if (_biz.DeleteD(D.GetString(cboMEDIAGR_GUBUN.SelectedValue)))
                {

                    ShowMessage(공통메세지.자료가정상적으로삭제되었습니다);
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void Page_DataChanged(object sender, EventArgs e)
        {
            try
            {
                SetToolBarButtonState(true, true, true, true, false);
            }
            catch (Exception ex)
            {
                MsgControl.CloseMsg();
                MsgEnd(ex);
            }
        }

        private void btn추가_Click_1(object sender, EventArgs e)
        {
            try
            {
                _flexD.Rows.Add();
                _flexD.Row = _flexD.Rows.Count - 1;
                _flexD["CD_MEDIAGR"] = _flexM["CD_MEDIAGR"];


                //HelpParam param = new HelpParam(HelpID.P_USER);//사용자정의도움창을 포함하는 HelpParam 클래스 생성
                //param.UserCodeName = "biz_name";
                //param.UserCodeValue = "CD_PARTNER_4";
                //param.UserHelpID = "H_CZ_HELP02";
                //string 첫번째param = string.Empty;
                //string 두번째param = string.Empty;
                //param.UserParams = "매체 도움창;H_CZ_ME_GR;" + 첫번째param + ";" + 두번째param;
                //HelpReturn helpreturn = (HelpReturn)ShowHelp(param);//도움창 호출(OPEN)
                //DataTable dt = helpreturn.DataTable;//도움창에서 선택된 값들을 DataTable로 리턴

                //DataRow[] drChk;

                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    _flexD.Redraw = false;
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        drChk = _flexD.DataTable.Select("CD_PARTNER_4 = '"+dr["CD_PARTNER_4"]+"' ");
                //        if (drChk.Length == 0)
                //        {
                //            _flexD.Rows.Add();
                //            _flexD.Row = _flexD.Rows.Count - 1;

                //            _flexD[_flexD.Row, "CD_MEDIAGR"] = _flexM["CD_MEDIAGR"];
                //            _flexD[_flexD.Row, "CD_PARTNER_4"] = dr["CD_PARTNER_4"];
                //            _flexD[_flexD.Row, "biz_name"] = dr["biz_name"];
                //            _flexD[_flexD.Row, "biz_name2"] = dr["biz_name2"];
                //            _flexD[_flexD.Row, "biz_no"] = dr["biz_no"];

                //            _flexD.AddFinished();
                //        }
                        
                //    }
                //    _flexD.Redraw = true;
                //}
                
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn삭제_Click_1(object sender, EventArgs e)
        {
            if (!_flexD.HasNormalRow)
                return;

            if (!BeforeDelete())
                return;

            //string Filter = "MEDIAGR_ID  = '" + D.GetString(_flexD["MEDIAGR_ID"]) + "'";
            ////DataRow[] drArt = _flexArtist.DataTable.Select(Filter);

            _flexD.Rows.Remove(_flexD.Row);
        }

        #region -> _flexM_AfterRowChange

        void _flexM_AfterRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                //if (!_flexM.IsBindingEnd || !_flexM.HasNormalRow)
                //    return;
                //_flexD.RowFilter = "ISNULL(CD_MEDIAGR,'') = '" + D.GetString(_flexM["CD_MEDIAGR"]) + "'";

                if (D.GetString(_flexM["CD_MEDIAGR"]) != "")
                {
                    object[] ParamsD = new object[2];

                    ParamsD[0] = LoginInfo.CompanyCode;
                    ParamsD[1] = D.GetString(_flexM["CD_MEDIAGR"]);

                    DataSet dsd = _biz.Search_D(ParamsD);

                    _flexD.Binding = dsd.Tables[0];
                }
            }
            catch (Exception ex)
            {
                Global.MainFrame.MsgEnd(ex);
            }
        }
        #endregion

        #region -> _flexD_BeforeCodeHelp

        void _flexD_BeforeCodeHelp(object sender, BeforeCodeHelpEventArgs e)
        {
            try
            {
                switch (_flexD.Cols[e.Col].Name)
                {
                    case "CD_PARTNER":

                        e.Parameter.UserParams = "매체 도움창;H_CZ_ME_GR;";
                        break;
                }

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
        #endregion

        private void _flexM_BeforeRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                DialogResult result;

                DataTable dtD = _flexD.GetChanges();
                if (dtD != null)
                {
                    result = ShowMessage("변경된 사항을 저장하시겠습니까?", "QY2");
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (SaveData() == true)
                        {
                            ShowMessage(PageResultMode.SaveGood);
                            {
                                OnToolBarSearchButtonClicked(sender, e);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //ShowMessage("코드,ID를 입력해주세요");
                MsgEnd(ex);
            }
        }

        string strCheck = "";

        private void _flexD_AfterCodeHelp(object sender, AfterCodeHelpEventArgs e)
        {
            //중복 매체ID 체크
            DataTable dt = e.Result.DataTable;
            int i = 0;
            DataSet dsd;
            DataRow[] ldr = null;
            object[] ParamsD = new object[2];
            if (dt != null)
            {
                ParamsD[0] = LoginInfo.CompanyCode;
                ParamsD[1] = "";

                dsd = _biz.Search_D(ParamsD);

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    ldr = dsd.Tables[0].Select("CD_PARTNER = '" + dt.Rows[i]["CD_PARTNER"] + "'");

                    if (ldr.Length != 0)
                    {
                        ShowMessage("이미 등록된 매체 ID 입니다.(" + dt.Rows[i][2] + ")", "QY1");

                        strCheck = "yes";
                        //_flexD.Row = _flexD.Rows.Count - 1;
                        //_flexD.Rows.Remove(_flexD.Row);

                        //_flexD.Row = _flexD.Rows.Count - 1;
                        //_flexD[_flexD.Row, "CD_MEDIAGR"] = _flexM["CD_MEDIAGR"];
                        //_flexD[_flexD.Row, "CD_PARTNER_4"] = "";
                        //_flexD[_flexD.Row, "biz_name"] = "";
                        //_flexD[_flexD.Row, "biz_name2"] = "";
                        //_flexD[_flexD.Row, "biz_no"] = "";

                        return;
                    }
                }
            }

            i = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                _flexD.Redraw = false;
                foreach (DataRow dr in dt.Rows)
                {
                        if(i != 0)
                        {
                            _flexD.Rows.Add();
                        }
                        _flexD.Row = _flexD.Rows.Count - 1;

                        _flexD[_flexD.Row, "CD_MEDIAGR"] = _flexM["CD_MEDIAGR"];
                        _flexD[_flexD.Row, "CD_PARTNER"] = dr["CD_PARTNER"];
                        _flexD[_flexD.Row, "biz_name"] = dr["biz_name"];
                        _flexD[_flexD.Row, "biz_name2"] = dr["biz_name2"];
                        _flexD[_flexD.Row, "biz_no"] = dr["biz_no"];

                        _flexD.AddFinished();

                        i++;
                }
                _flexD.Redraw = true;
            }

        }

        private void _flexD_DoubleClick(object sender, EventArgs e)
        {
            if (strCheck == "yes")
            {
                _flexD.Row = _flexD.Rows.Count - 1;
                _flexD[_flexD.Row, "CD_MEDIAGR"] = _flexM["CD_MEDIAGR"];
                _flexD[_flexD.Row, "CD_PARTNER"] = "";
                _flexD[_flexD.Row, "biz_name"] = "";
                _flexD[_flexD.Row, "biz_name2"] = "";
                _flexD[_flexD.Row, "biz_no"] = "";

                strCheck = "";
            }
        }


        //#region -> _flexD_AfterRowChange

        //void _flexD_AfterRowChange(object sender, RangeEventArgs e)
        //{
        //    try
        //    {
        //        if (!_flexD.IsBindingEnd || !_flexD.HasNormalRow)
        //            return;

        //        _flexD.RowFilter = "ISNULL(CD_MEDIAGR,'') = '" + D.GetString(_flexD["CD_MEDIAGR"]) + "'";
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.MainFrame.MsgEnd(ex);
        //    }
        //}
        //#endregion



    }
}