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

namespace cz
{
    // **************************************
    // 작   성   자 : 이표
    // 재 작  성 일 : 2020-06-05
    // 모   듈   명 : MTS 연동-사원등록
    // 시 스  템 명 : MTS 연동-사원등록
    // 서브시스템명 : MTS 연동-사원등록
    // 페 이 지  명 : MTS 연동-사원등록
    // 프로젝트  명 : CZ_ME_MAP_EMP
    // **************************************
    public partial class P_CZ_ME_MAP_EMP : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_MAP_EMP_BIZ _biz = new P_CZ_ME_MAP_EMP_BIZ();
        bool _타메뉴호출 = false;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_MAP_EMP()
        {
            InitializeComponent();
            MainGrids = new FlexGrid[] { _flexM };          
            _flexM.DetailGrids = new FlexGrid[] { _flexD }; 
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();
            InitGrid();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
            //HEADER
            _flexM.BeginSetting(1, 1, false);

            _flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);
            //MTS
            _flexM.SetCol("MTS_NO_EMP", "사번", 80, false);
            _flexM.SetCol("MTS_NM_KOR", "사원명", 100, false);
            _flexM.SetCol("MTS_CD_DEPT", "부서", 90, false);
            _flexM.SetCol("MTS_DTS_UPDATE", "변경일자", 100, false);
            _flexM.SetCol("MTS_GUBUN", "구분", 80, false);
            //DOUZON
            _flexM.SetCol("DZ_NO_EMP", "사번", 80, false);
            _flexM.SetCol("DZ_NM_KOR", "사원명", 100, false);
            _flexM.SetCol("DZ_CD_DEPT", "부서", 90, false);
            _flexM.SetCol("DZ_DT_ENTRY", "입사일자", 100, false);
            _flexM.SetCol("DZ_DTS_UPDATE", "변경일자", 100, false);
            _flexM.SetCol("DZ_GUBUN", "구분", 80, false);
            _flexM.SetCol("DZ_NM_USER2", "작업자", 80, false);

            _flexM.Cols["MTS_NO_EMP"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["MTS_NM_KOR"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["MTS_CD_DEPT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["MTS_DTS_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["MTS_DTS_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DZ_NO_EMP"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DZ_NM_KOR"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DZ_CD_DEPT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DZ_DT_ENTRY"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DZ_DTS_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DZ_GUBUN"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DZ_NM_USER2"].TextAlign = TextAlignEnum.CenterCenter;  
            
            _flexM.SettingVersion = "0.0.1.1";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);
            _flexM.SetDummyColumn("S");

            //MERGE 처리 MTS
            _flexM[0, "MTS_NO_EMP"] = _flexM[0, "MTS"] = "MTS";
            _flexM[0, "MTS_NM_KOR"] = _flexM[0, "MTS"] = "MTS";
            _flexM[0, "MTS_CD_DEPT"] = _flexM[0, "MTS"] = "MTS";
            _flexM[0, "MTS_DTS_UPDATE"] = _flexM[0, "MTS"] = "MTS";
            _flexM[0, "MTS_GUBUN"] = _flexM[0, "MTS"] = "MTS";

            //MERGE 처리 더존
            _flexM[0, "DZ_NO_EMP"] = _flexM[0, "DZ"] = "더존";
            _flexM[0, "DZ_NM_KOR"] = _flexM[0, "DZ"] = "더존";
            _flexM[0, "DZ_CD_DEPT"] = _flexM[0, "DZ"] = "더존";
            _flexM[0, "DZ_DT_ENTRY"] = _flexM[0, "DZ"] = "더존";
            _flexM[0, "DZ_DTS_UPDATE"] = _flexM[0, "DZ"] = "더존";
            _flexM[0, "DZ_GUBUN"] = _flexM[0, "DZ"] = "더존";
            _flexM[0, "DZ_NM_USER2"] = _flexM[0, "DZ"] = "더존";

            _flexM.Cols.Frozen = 1;

            //DETAIL
            _flexD.BeginSetting(1, 1, false);

            _flexD.SetCol("NO_EMP", "사번", 90, false);
            _flexD.SetCol("NM_SYSDEF", "발령구분", 130, false);
            _flexD.SetCol("NM_DEPT", "부서", 130, false);
            _flexD.SetCol("DTS_UPDATE", "변경일자", 110, false);
            _flexD.SetCol("GUBUN", "구분", 110, false);

            _flexD.Cols["NO_EMP"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["NM_SYSDEF"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["NM_DEPT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["DTS_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["GUBUN"].TextAlign = TextAlignEnum.CenterCenter;

            _flexD.SettingVersion = "0.0.1.1";// new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);
            _flexD.SetDummyColumn("NO_EMP");   
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanDelete = false;
            Grant.CanAdd = false;
            //Grant.CanPrint = false;

            string strQuery = string.Format(@"   SELECT '' CD_TPDOCU, '' NM_TPDOCU UNION ALL 
                                                                              SELECT CD_TPDOCU, NM_TPDOCU FROM CZ_AISPOSTH A WHERE CD_COMPANY  = '{0}' AND FG_TPDOCU = '002' ", LoginInfo.CompanyCode);

            //DataTable dt발주유형 = DBHelper.GetDataTable(strQuery);
            //cboMEDIAGR_GUBUN.DataSource = dt발주유형.Copy();
            //cboMEDIAGR_GUBUN.DisplayMember = "NM_TPDOCU";
            //cboMEDIAGR_GUBUN.ValueMember = "CD_TPDOCU";     //매체구분

            //ctxMEDIAGR.QueryBefore += new BpQueryHandler(Control_QueryBefore);  //매체
            //ctxPARTNER.QueryBefore += new BpQueryHandler(Control_QueryBefore);  //사업자

            //DataSet g_dsCombo = GetComboData("S;CZ_SME_021", "S;FI_J000031", "S;YESNO", "S;MA_CODEDTL2;CZ_SME_040", "S;MA_B000020");
            //_flexM.SetDataMap("GUBUN_CODE", g_dsCombo.Tables[1].Copy(), "CODE", "NAME");
            //_flexM.SetDataMap("MEDIAGR_GUBUN_NM", g_dsCombo.Tables[1].Copy(), "CODE", "NAME");
            

            //DataTable dt지출구분 = _biz.Get지출구분();
            //_flexD.SetDataMap("MEDIAGR_ID", dt지출구분, "CODE", "NAME");
            //_flexD.SetDataMap("MEDIAGR_NM", dt지출구분, "CODE", "NAME");
            //_flexD.SetDataMap("PARTNER_NM", dt지출구분, "CODE", "NAME");
            //_flexD.SetDataMap("PARTNER_NUM", dt지출구분, "CODE", "NAME");

        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                object[] Params = new object[2];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = rdoMts1.Text;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                _flexD.Binding = ds.Tables[1];
                _flexD.RowFilter = "ISNULL(NO_IV,'') = '" + D.GetString(_flexM["NO_IV"]) + "' AND NO_IVLINE = " + D.GetInt(_flexM["NO_IVLINE"]);

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
                        _flexM.AllowEditing = false;
                        _flexD.AllowEditing = false;   
                    }
                }
            }
            catch (Exception ex)
            {
                
                MsgEnd(ex);
            }
            
        }
        #endregion


        protected override bool SaveData()
        {

            object obj = null;

            if (_flexM.HasNormalRow)
            {
                obj = _biz.Save(_flexM.GetChanges(), _flexD.GetChanges(), _타메뉴호출);
            }

            return false;
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

            if (!_flexD.HasNormalRow)
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
                if (!BeforeDelete())
                    return;

                //if (string.IsNullOrEmpty(D.GetString(txt결의번호.Text)))
                //{
                //    ShowMessage("결의번호를 먼저 선택하세요.");
                //    return;
                //}

                DialogResult Result = ShowMessage(공통메세지.자료를삭제하시겠습니까, PageName);

                if (Result != DialogResult.Yes)
                    return;

                if (_biz.Delete(D.GetString(cboMEDIAGR_GUBUN.SelectedValue)))
                {
                    
                    ShowMessage(공통메세지.자료가정상적으로삭제되었습니다);
                }
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


        private void btn추가_Click(object sender, EventArgs e)
        {
            try
            {
                _flexD.Rows.Add();

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

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




    }
}