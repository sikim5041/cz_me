using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Duzon.Common.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.Common.Controls;
using Duzon.ERPU;
using Duzon.Common.Util;
using Duzon.Common.BpControls;
using Duzon.Common.Forms.Help;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace cz
{
          // ================================================
          // AUTHOR      : 오기동
          // CREATE DATE : 2014.12.18
          //               
          // MODULE      : 일정관리
          // SYSTEM      : 스케줄관리
          // SUBSYSTEM   : 
          // PAGE        : 스케줄등록
          // PROJECT     : P_CZ_SCHEDULE
          // DESCRIPTION : 
          // ================================================ 
          // CHANGE HISTORY
          // ================================================

          public partial class P_CZ_ME_CALENDAR : PageBase
          {
                    P_CZ_ME_CALENDAR_BIZ _biz = new P_CZ_ME_CALENDAR_BIZ();

                    DataTable _calendar;
                    DataTable dtChk;
                    public DataTable _dtArtist;

                    string SelectedDate;
                    string today2;
                    string today;
                    string longtoday = "";

                    [DllImport("user32.dll", EntryPoint = "HideCaret")]

                    public static extern long HideCaret(IntPtr hwnd);

                    public P_CZ_ME_CALENDAR()
                    {
                              InitializeComponent();

                              MainGrids = new FlexGrid[] { _flex };
                              DataChanged += new EventHandler(Page_DataChanged);
                    }

                    #region → 초기 설정
                    protected override void InitLoad()
                    {
                              base.InitLoad();
                              InitGrid();
                              InitEvent();
                              InitControl();
                              InitControlEvent(panel1);

                              //SetToolBarButtonState(true, true, false, false, false);

                              isChecked(chk휴일.Checked);
                    }
                    
                    protected override void InitPaint()
                    {
                              base.InitPaint();

                              DateTime time = this.MainFrameInterface.GetDateTimeToday(); // 오늘 날짜

                              longtoday = time.ToString("yyyMMddHHmmss");
                              today = longtoday.Substring(0, 8);
                              //dp년월.Text = longtoday.Substring(0, 6);

                              dp년월.ShowUpDown = false;
                              dp년월.Format = DateTimePickerFormat.Custom;
                              dp년월.CustomFormat = "yyyy/MM";

                              dp년월.Text = longtoday.Substring(0, 4) + '/' + longtoday.Substring(4, 2);

                              try
                              {
                                        if (!BeforeSearch()) return;

                                        today2 = today;
                                        if (SelectedDate == null)
                                                  SelectedDate = today2;

                                        //dp년월.Text = SelectedDate;
                                        dp년월.Text = SelectedDate.Substring(0, 4) + '/' + SelectedDate.Substring(4, 2);

                                        selectday.Text = today.Substring(0, 4) + "년" + " " + today.Substring(4, 2) + "월";
                                        selectday.Tag = today.Substring(0, 4) + today.Substring(4, 2) + "01"; //20020501

                                        string[] data = VarCalendar(D.GetString(selectday.Tag));
                                        Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));

                                        // 금일 날짜의 계획을 뿌려 준다.
                                        t_dc_text.Tag = today;
                                        t_dc_text.Text = today.Substring(0, 4) + "년" + " " + today.Substring(4, 2) + "월" + " " + "내용";

                                        GridLoad(today);

                                        if (_calendar != null)
                                                  _calendar.AcceptChanges();

                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }

                              // MA_B000023 : 캘린더타입, HR_G000007 : 근태구분
                              //DataSet ds = GetComboData("N;MA_B000023", "N;HR_G000007");
                    }

                    private void InitGrid()
                    {
                              _flex.BeginSetting(1, 1, false);
                              _flex.SetCol("DT_CALENDAR", "일자", 80, false);
                              _flex.SetCol("NM_TITLE", "제목", 240, false);
                              _flex.SetCol("DT_ROW", "순번", 0, false);
                              _flex.SetCol("NM_NOTE", "내용", 0, false);
                              _flex.SetCol("NO_EMP", "사번", 0, false);
                              _flex.SetCol("NM_EMP", "사명", 0, false);
                              _flex.SetCol("TP_CALENDAR", "중요", 0, false);
                              _flex.SetCol("DT_INSERT", "작성일자", 0, false);
                              _flex.SetCol("TM_INSERT", "작성시간", 0, false);
                              _flex.SetCol("DT_UPDATE", "수정일자", 0, false);
                              _flex.SetCol("TM_UPDATE", "수정시간", 0, false);
                              _flex.SetCol("TM_START", "시간", 0, false);

                              _flex.Cols["DT_CALENDAR"].Format = _flex.Cols["DT_CALENDAR"].EditMask = "####/##/##";
                              _flex.Cols["DT_CALENDAR"].TextAlign = TextAlignEnum.CenterCenter;
                              _flex.SetStringFormatCol("DT_CALENDAR");
                              _flex.SetNoMaskSaveCol("DT_CALENDAR");

                              _flex.Cols["DT_INSERT"].Format = _flex.Cols["DT_INSERT"].EditMask = "####/##/##";
                              _flex.Cols["DT_INSERT"].TextAlign = TextAlignEnum.CenterCenter;
                              _flex.SetStringFormatCol("DT_INSERT");
                              _flex.SetNoMaskSaveCol("DT_INSERT");

                              _flex.Cols["TM_INSERT"].Format = _flex.Cols["TM_INSERT"].EditMask = "##:##";
                              _flex.Cols["TM_INSERT"].TextAlign = TextAlignEnum.CenterCenter;
                              _flex.SetStringFormatCol("TM_INSERT");
                              _flex.SetNoMaskSaveCol("TM_INSERT");

                              _flex.Cols["DT_UPDATE"].Format = _flex.Cols["DT_UPDATE"].EditMask = "####/##/##";
                              _flex.Cols["DT_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
                              _flex.SetStringFormatCol("DT_UPDATE");
                              _flex.SetNoMaskSaveCol("DT_UPDATE");

                              _flex.Cols["TM_UPDATE"].Format = _flex.Cols["TM_UPDATE"].EditMask = "##:##";
                              _flex.Cols["TM_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
                              _flex.SetStringFormatCol("TM_UPDATE");
                              _flex.SetNoMaskSaveCol("TM_UPDATE");

                              _flex.VerifyDuplicate = new string[] { "DT_ROW" };
                              _flex.VerifyNotNull = new string[] { "DT_ROW" };
                              // 이후 Save할때 _flex.Verify() 로 체크하면 해당 컬럼에 대해서 유효성 검사를 하게 된다.
                              _flex.ExtendLastCol = true;
                              _flex.SettingVersion = "1.0.0.8";
                              _flex.EndSetting(GridStyleEnum.Green, AllowSortingEnum.None, SumPositionEnum.None);

                              _flex.SetBinding(pnlInfoSchedule, null);

                              _flex.SetBindningRadioButton(new RadioButtonExt[] { rdo일반, rdo청색, rdo적색 }, new string[] { "N", "Y", "R" });

                              _flex.AfterRowChange += new RangeEventHandler(_flex_AfterRowChange);
                    }

                    private void InitEvent()
                    {
                        //dp년월.UpDownClick += new UpDownClickEventHandler(dp년월_UpDownClick);
                        //dp년월.KeyDown += new KeyEventHandler(dp년월_KeyDown);
                        ibtnPreCalendar.Click += new EventHandler(IbtnPreCalendar_Click);
                        ibtnNextCalendar.Click += new EventHandler(IbtnNextCalendar_Click);
                        chk휴일.CheckedChanged += new EventHandler(chk휴일_CheckedChanged);
                        btnToday.Click += new EventHandler(btnToday_Click);
                        btn휴일.Click += new EventHandler(btn휴일_Click);
                        //btn휴일지정.Click += new EventHandler(btn휴일지정_Click);
                        //btn휴일해제.Click += new EventHandler(btn휴일해제_Click);
                        btn전체일정.Click += new EventHandler(btn전체일정_Click);
                        dp년월.CloseUp += new EventHandler(dp년월_CloseUp); 
                        dp년월.KeyDown += new KeyEventHandler(dp년월_KeyDown);
                    }

                    private void InitControl()
                    {
                        bpManager.CodeValue = Global.MainFrame.LoginInfo.UserID;
                    }
                    #endregion

                    #region → 버튼 및 그리드 이벤트

                    //오늘 버튼 클릭 시 이벤트
                    void btnToday_Click(object sender, EventArgs e)
                    {
                              try
                              {
                                        if (!BeforeSearch()) return;

                                        today2 = today;
                                        //if (SelectedDate == null)
                                                  SelectedDate = today2;

                                        //dp년월.Text = today.Substring(0, 4) + today.Substring(4, 2);
                                        dp년월.Text = SelectedDate.Substring(0, 4) + '/' + SelectedDate.Substring(4, 2);

                                        selectday.Text = today.Substring(0, 4) + "년" + " " + today.Substring(4, 2) + "월";
                                        selectday.Tag = today.Substring(0, 4) + today.Substring(4, 2) + "01"; //20020501

                                        string[] data = VarCalendar(D.GetString(selectday.Tag));

                                        Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));

                                        // 금일 날짜의 계획을 뿌려 준다.
                                        t_dc_text.Tag = today;
                                        t_dc_text.Text = today.Substring(0, 4) + "년" + " " + today.Substring(4, 2) + "월" + " " + "내용";

                                        GridLoad(today);

                                        Click_Bgcolor(SelectedDate);

                                        if (_calendar != null)
                                                  _calendar.AcceptChanges();

                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    #endregion

                    /// <summary>
                    ///  Grid의 Combo column 또는 control Binding 처리
                    /// </summary>

                    protected override bool BeforeSearch()
                    {
                              if (!base.BeforeSearch() || !캘린더체크 || !CheckManagerID) return false;
                              return true;
                    }

                    private bool Save()
                    {
                              bool Success = false;
                              if (!_flex.Verify())
                                        return false;

                              DataTable dt = _flex.DataTable.GetChanges();

                              if (dt == null) return false;

                              Success = _biz.Save2(dt);
                                
                              if (!Success) return false;
                              {
                                        _flex.AcceptChanges();
                              }

                              return true;

                    }

                    private bool MsgAndSave(bool displayDialog, bool isExit)
                    {
 
                              if (!displayDialog) // 저장 버튼을 클릭한 경우이므로 다이알 로그는 필요없음
                                        return Save();

                              DialogResult result;

                              if (CanSave)
                              {
                                        if (isExit)
                                        {
                                                  result = ShowMessage(공통메세지.변경된사항이있습니다저장하시겠습니까);
                                                  if (result == DialogResult.No)
                                                            return true;
                                                  if (result == DialogResult.Cancel)
                                                            return false;
                                        }
                                        else
                                        {
                                                  result = ShowMessage(공통메세지.변경된사항이있습니다저장하시겠습니까);
                                                  if (result == DialogResult.No)
                                                            return true;
                                        }
                              }
                              else
                                        return true;

                              Application.DoEvents();		// 대화상자 즉시 사라지게

                              // "예"를 선택한 경우
                              return Save();
                    }

                    public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
                    {
                              try
                              {
                                        if (!BeforeDelete())
                                                  return;

                                        string Filter = "DT_ROW  = '" + D.GetString(_flex["DT_ROW"]) + "'";

                                        _flex.Rows.Remove(_flex.Row);

                                        //Page_DataChanged(null, null);
                              }
                              catch (Exception ex)
                              {
                                        this.MsgEnd(ex);
                              }

                    }

                    public override void OnToolBarSaveButtonClicked(object sender, EventArgs e)
                    {
                              try
                              {
                                    if (!BeforeSave()) return;

                                    if (MsgAndSave(false, false))

                                        if (!BeforeSearch()) return;
                                        string[] data = VarCalendar(D.GetString(selectday.Tag));
                                        Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));

                                        GridLoad(SelectedDate);

                                        ShowMessage(공통메세지.자료가정상적으로저장되었습니다);

                                    //Page_DataChanged(null, null);
                              }
                              catch (Exception ex)
                              {
                                    MsgEnd(ex);
                              }
                    }

                    public override void OnToolBarAddButtonClicked(object sender, EventArgs e)
                    {
                              try
                              {
                                    _flex.Rows.Add();
                                    _flex.Row = _flex.Rows.Count - 1;

                                    _flex[_flex.Row, "DT_ROW"] = _biz.GetNo_Schedule(SelectedDate);
                                    _flex[_flex.Row, "NO_EMP"] = bpManager.CodeValue;
                                    _flex[_flex.Row, "NM_EMP"] = bpManager.CodeName;
                                    _flex[_flex.Row, "TP_CALENDAR"] = "N";

                                    _flex.AddFinished();

                                    _flex.Col = _flex.Cols.Fixed;

                                    dp작성일자.Text = SelectedDate;
                                    dp수정일자.Text = SelectedDate;
                                    dp월일.Text = SelectedDate;
                                    mak작성일자.Text = longtoday.Substring(8, 6);
                                    mak수정일자.Text = longtoday.Substring(8, 6);
                                    mak시간.Text = longtoday.Substring(8, 6);

                                    SetToolBarButtonState(true, false, true, true, false);

                                    //FilterArtist();

                                    //bp계약명.Focus();
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
                    {
                              try
                              {
                                        // 변경되어진 것이 있음 저장한다.
                                        if (YnChange() == true)
                                                  OnToolBarSaveButtonClicked(sender, e);

                                        string[] data = VarCalendar(D.GetString(selectday.Tag));
                                        Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));

                                        GridLoad(SelectedDate);

                                        if (_calendar != null)
                                                _calendar.AcceptChanges();

                                        Click_Bgcolor(SelectedDate);

                                        t_dc_text.Tag = SelectedDate;

                                        if (D.GetString(SelectedDate.Substring(4, 2)) == "00")
                                        {
                                                int yy = Convert.ToInt32(D.GetString(SelectedDate.Substring(0, 4))) - 1;
                                                t_dc_text.Text = D.GetString(yy) + "년" + " " + "12" + "월" + " " + "내용";
                                        }
                                        else if (D.GetString(SelectedDate.Substring(4, 2)) == "13")
                                        {
                                                int yy = Convert.ToInt32(D.GetString(SelectedDate.Substring(0, 4))) + 1;
                                                t_dc_text.Text = D.GetString(yy) + "년" + " " + "01" + "월" + " " + "내용";
                                        }
                                        else
                                                t_dc_text.Text = SelectedDate.Substring(0, 4) + "년" + " " + SelectedDate.Substring(4, 2) + "월" + " " + "내용";

                                        //if (ToolBarSaveButtonEnabled)
                                        //          ToolBarSaveButtonEnabled = false;
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    #region ♪ 화면 내 버튼  ♬

                    void IbtnPreCalendar_Click(object sender, EventArgs e)
                    {
                              try
                              {
                                        if (YnChange())
                                                  OnToolBarSaveButtonClicked(sender, e);

                                        string selmonth = D.GetString(selectday.Tag);

                                        int preyear = Int32.Parse(selmonth.Substring(0, 4));
                                        int premonth = Int32.Parse(selmonth.Substring(4, 2)) - 1;

                                        if (premonth < 1)
                                        {
                                                preyear = System.Int32.Parse(selmonth.Substring(0, 4)) - 1;
                                                premonth = 12;
                                        }

                                        object[] calCheck = null;
                                        _biz.캘린더존재여부(D.GetString("001"), D.GetString(preyear), out calCheck);

                                        if (D.GetString(calCheck[0]) == "N")
                                        {
                                                if (Global.MainFrame.LoginInfo.Language == "KR")
                                                            ShowMessage("PR_M100003");
                                                else
                                                            ShowMessage("Please Creating Calendar.");

                                                return;
                                        }

                                        string preAll = "";

                                        if (premonth < 10)
                                                preAll = D.GetString(preyear) + "0" + D.GetString(premonth) + "01"; // 지난년도월일 20010301
                                        else
                                                preAll = D.GetString(preyear) + D.GetString(premonth) + "01";       // 지난년도월일 20010301

                                        selectday.Text = preAll.Substring(0, 4) + "년" + " " + preAll.Substring(4, 2) + "월";
                                        selectday.Tag = preAll;
                                        //dp년월.Text = preAll;
                                        dp년월.Text = preAll.Substring(0, 4) + '/' + preAll.Substring(4, 2);

                                        string[] data = VarCalendar(preAll);

                                        Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    void IbtnNextCalendar_Click(object sender, EventArgs e)
                    {
                              try
                              {
                                        if (YnChange())
                                                  OnToolBarSaveButtonClicked(sender, e);

                                        string selmonth = D.GetString(selectday.Tag);

                                        int nextyear = Int32.Parse(selmonth.Substring(0, 4));
                                        int nextmonth = Int32.Parse(selmonth.Substring(4, 2)) + 1;

                                        if (nextmonth > 12)
                                        {
                                                nextyear = Int32.Parse(selmonth.Substring(0, 4)) + 1;
                                                nextmonth = 1;
                                        }

                                        object[] calCheck = null;
                                        _biz.캘린더존재여부(D.GetString("001"), D.GetString(nextyear), out calCheck);

                                        if (D.GetString(calCheck[0]) == "N")
                                        {
                                                if (Global.MainFrame.LoginInfo.Language == "KR")
                                                            ShowMessage("PR_M100003");
                                                else
                                                            ShowMessage("Please Creating Calendar.");

                                                return;
                                        }

                                        string nextAll = "";

                                        if (nextmonth < 10)
                                                nextAll = D.GetString(nextyear) + "0" + D.GetString(nextmonth) + "01";  // 다음년도월일 20030301
                                        else
                                                nextAll = D.GetString(nextyear) + D.GetString(nextmonth) + "01";        // 다음년도월일 20030301

                                        this.selectday.Text = nextAll.Substring(0, 4) + "년" + " " + nextAll.Substring(4, 2) + "월";
                                        this.selectday.Tag = nextAll;

                                        //dp년월.Text = nextAll;
                                        dp년월.Text = nextAll.Substring(0, 4) + '/' + nextAll.Substring(4, 2);

                                        string[] data = VarCalendar(nextAll);

                                        Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    #endregion

                    #region ♪ 기타 이벤트   ♬

                    #region → 날짜에 마우스를 올렸을 경우 배경색 변경
                    /// <summary>
                    /// 날짜에 마우스를 올렸을 경우 배경색 변경
                    /// </summary>
                    private void Label_MouseMove(object sender, MouseEventArgs e)
                    {
                              try
                              {
                                        ((LabelExt)sender).BackColor = System.Drawing.Color.FromArgb(((System.Byte)(242)), ((System.Byte)(203)), ((System.Byte)(97)));
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    #endregion

                    #region → 날짜에 마우스 떠났을 경우 배경색 변경
                    /// <summary>
                    /// 날짜에 마우스떠났을 경우 배경색 변경
                    /// </summary>
                    private void Label_MouseLeave(object sender, System.EventArgs e)
                    {
                              try
                              {
                                        if (today2 == D.GetString(((LabelExt)sender).Tag))
                                                ((LabelExt)sender).BackColor = Color.FromArgb(((Byte)(178)), ((Byte)(235)), ((Byte)(244)));
                                        else
                                                ((LabelExt)sender).BackColor = Color.Transparent;

                                        Click_Bgcolor(SelectedDate);
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    #endregion

                    #region → 날짜 클릭시 이벤트
                    /// <summary>
                    /// 날짜 클릭시 이벤트
                    /// </summary>
                    void Label_Click(object sender, EventArgs e)
                    {
                              try
                              {
                                        // 변경되어진 것이 있음 저장한다.
                                        if (YnChange() == true)
                                                  OnToolBarSaveButtonClicked(sender, e);

                                        ((LabelExt)sender).BackColor = Color.FromArgb(((Byte)(181)), ((Byte)(178)), ((Byte)(255)));
                                        SelectedDate = D.GetString(((LabelExt)sender).Tag); // 선택되어진 날짜를 변수에 넣는다.

                                        GridLoad(SelectedDate);
                                        if (_calendar != null)
                                                _calendar.AcceptChanges();

                                        Click_Bgcolor(SelectedDate);

                                        t_dc_text.Tag = SelectedDate;

                                        if (D.GetString(t_dc_text.Tag) == D.GetString(((LabelExt)sender).Tag))
                                            ((LabelExt)sender).BackColor = Color.FromArgb(((Byte)(242)), ((Byte)(203)), ((Byte)(97)));

                                        if (D.GetString(SelectedDate.Substring(4, 2)) == "00")
                                        {
                                                int yy = Convert.ToInt32(D.GetString(SelectedDate.Substring(0, 4))) - 1;
                                                t_dc_text.Text = D.GetString(yy) + "년" + " " + "12" + "월" + " " + "내용";
                                        }
                                        else if (D.GetString(SelectedDate.Substring(4, 2)) == "13")
                                        {
                                                int yy = Convert.ToInt32(D.GetString(SelectedDate.Substring(0, 4))) + 1;
                                                t_dc_text.Text = D.GetString(yy) + "년" + " " + "01" + "월" + " " + "내용";
                                        }
                                        else
                                                t_dc_text.Text = SelectedDate.Substring(0, 4) + "년" + " " + SelectedDate.Substring(4, 2) + "월" + " " + "내용";

                                        //dp년월.Text = SelectedDate.Substring(0, 4) + SelectedDate.Substring(4, 2);
                                        dp년월.Text = SelectedDate.Substring(0, 4) + '/' + SelectedDate.Substring(4, 2);

                                        //if (ToolBarSaveButtonEnabled)
                                        //          ToolBarSaveButtonEnabled = true;
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }
                    #endregion

                    #region → 날짜에서 엔터 입력 시

                    void dp년월_KeyDown(object sender, KeyEventArgs e)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            try
                            {
                                if (dp년월.Text.ToString() != "" && dp년월.Text.ToString().Length == 7)
                                {
                                    SpInfo si = new SpInfo();
                                    si.SpNameSelect = "SP_MA_CALENDAR_SELECT_CNT";
                                    si.SpParamsSelect = new object[] { this.MainFrameInterface.LoginInfo.CompanyCode, "001", dp년월.Text.ToString(), "" };

                                    ResultData result = (ResultData)this.FillDataTable(si);

                                    if (result.OutParamsSelect[0, 0].ToString() == "N")
                                    {
                                        if (Global.MainFrame.LoginInfo.Language == "KR")
                                            this.ShowMessage("PR_M100003");
                                        else
                                            ShowMessage("Please Creating Calendar.");

                                        return;
                                    }

                                    string years = dp년월.Text.Substring(0, 4).ToString() + dp년월.Text.Substring(5, 2).ToString() + "01";
                                    this.selectday.Tag = dp년월.Text.Substring(0, 4).ToString() + dp년월.Text.Substring(5, 2).ToString() + "01"; //20020501

                                    SelectedDate = years;

                                    string[] data = VarCalendar(years);
                                    Calendar(System.Int32.Parse(data[0].ToString()), System.Int32.Parse(data[1].ToString()), System.Int32.Parse(data[2].ToString()));

                                    selectday.Text = dp년월.Text.Substring(0, 4).ToString() + "년" + " " + dp년월.Text.Substring(5, 2).ToString() + "월";

                                    // 해당 월의 1일 날짜의 계획을 뿌려 준다.
                                    t_dc_text.Tag = SelectedDate;
                                    t_dc_text.Text = SelectedDate.Substring(0, 4) + "년" + " " + SelectedDate.Substring(4, 2) + "월" + " " + "내용";
                                    GridLoad(SelectedDate);

                                    Click_Bgcolor(SelectedDate);

                                    if (_calendar != null)
                                        _calendar.AcceptChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                MsgEnd(ex);
                            }
                        }
                    }

                    #endregion

                    #endregion

                    #region ♪ 기타 메소드   ♬

                    #region → 날짜 이벤트 일괄로..

                    private void InitControlEvent(Control ctrs)
                    {
                              foreach (Control ctr in ctrs.Controls)
                              {
                                        if (ctr is PanelExt) InitControlEvent(ctr as PanelExt);

                                        switch (ctr.Name)
                                        {
                                            case "lblSun":
                                            case "lblMon":
                                            case "lblTue":
                                            case "lblWed":
                                            case "lblThu":
                                            case "lblFri":
                                            case "lblSat":
                                            case "lblToDays":
                                            case "lbl년월":
                                                            continue;
                                        }

                                        switch (ctr.GetType().Name)
                                        {
                                                  case "LabelExt":
                                                        if (((LabelExt)ctr).Name != selectday.Name.ToString())
                                                        {
                                                            ((LabelExt)ctr).MouseMove += new MouseEventHandler(Label_MouseMove);
                                                            ((LabelExt)ctr).MouseLeave += new EventHandler(Label_MouseLeave);
                                                            ((LabelExt)ctr).Click += new EventHandler(Label_Click);
                                                        }
                                                            break;
                                                  case "RichTextBox":
                                                            ((RichTextBox)ctr).ReadOnly = true;
                                                            ((RichTextBox)ctr).Click += new EventHandler(Richtextbox_Click);
                                                            ((RichTextBox)ctr).Enter += new EventHandler(Richtextbox_Enter);
                                                            break;
                                        }
                              }
                    }

                    private void Richtextbox_Enter(object sender, EventArgs e)
                    {
                        //selectday.Focus();
                    }

                    private void Richtextbox_Click(object sender, EventArgs e)
                    {
                        HideCaret(((RichTextBox)sender).Handle);
                    }
                    #endregion

                    #region → 달력을 그린다.
                    /// <summary>
                    /// 칼렌더 생성 메서드
                    /// </summary>
                    /// <param name="premonth">전달의 마지막 일(ex: 30일)</param>
                    /// <param name="month">이달의 마지막 일(ex: 31일)</param>
                    /// <param name="day">이달의 첫 시작일의 요일(4이면 수요일; 일요일부터 시작)</param>
                    public void Calendar(int premonth, int month, int day)
                    {
                              try
                              {
                                        int preday = day - 1;
                                        int nextday = day + 1;
                                        int preyear = System.Int32.Parse(D.GetString(selectday.Tag).Substring(0, 4)) - 1;
                                        int nextyear = System.Int32.Parse(D.GetString(selectday.Tag).Substring(0, 4)) + 1;
                                        string preYY = string.Empty;
                                        string nextYY = string.Empty;
                                        string currYY = D.GetString(selectday.Tag).Substring(0, 4);

                                        int[] months = new int[43];
                                        int daycount = 0;
                                        int daycount2 = 0;

                                        //Label 이름을 Object 배열로 선언
                                        object[] labelName ={
										 label101,label102,label103,label104,label105,label106,
										 label107,label108,label109,label110,label111,label112,
										 label113,label114,label115,label116,label117,label118,
										 label119,label120,label121,label122,label123,label124,
										 label125,label126,label127,label128,label129,label130,
										 label131,label132,label133,label134,label135,label136,
										 label137,label138,label139,label140,label141,label142
									 };
                                        object[] labelName_box ={
                                        label101_box,label102_box,label103_box,label104_box,label105_box,
                                        label106_box,label107_box,label108_box,label109_box,label110_box,
                                        label111_box,label112_box,label113_box,label114_box,label115_box,
                                        label116_box,label117_box,label118_box,label119_box,label120_box,
                                        label121_box,label122_box,label123_box,label124_box,label125_box,
                                        label126_box,label127_box,label128_box,label129_box,label130_box,
                                        label131_box,label132_box,label133_box,label134_box,label135_box,
                                        label136_box,label137_box,label138_box,label139_box,label140_box,
                                        label141_box,label142_box
									 };
                                        //string today = longtoday;

                                        //전달
                                        int premon = System.Int32.Parse(D.GetString(selectday.Tag).Substring(4, 2)) - 1;
                                        string prem;
                                        if (premon <= 0)
                                        {
                                                  prem = "12";
                                                  preYY = D.GetString(preyear);
                                        }
                                        else if (premon < 10)
                                        {
                                                  prem = D.GetString("0" + premon);
                                                  preYY = currYY;
                                        }
                                        else
                                        {
                                                  prem = D.GetString(premon);
                                                  preYY = currYY;
                                        }

                                        // 이번달
                                        string tom = D.GetString(selectday.Tag).Substring(4, 2);

                                        // 다음달
                                        int nextmon = Int32.Parse(D.GetString(selectday.Tag).Substring(4, 2)) + 1;
                                        string nextm;
                                        if (nextmon < 10)
                                        {
                                                  nextm = D.GetString("0" + nextmon);
                                                  nextYY = currYY;
                                        }
                                        else if (nextmon > 12)
                                        {
                                                  nextm = "01";
                                                  nextYY = D.GetString(nextyear);
                                        }
                                        else
                                        {
                                                  nextm = D.GetString(nextmon);
                                                  nextYY = currYY;
                                        }

                                        // 전달의 날짜를 음영으로 처리, 삽입
                                        for (int b = preday; b > 0; b--)
                                        {
                                                  months[b] = premonth;
                                                  premonth--;

                                                  ((LabelExt)labelName[b - 1]).ForeColor = Color.Black;

                                                  if (b == 1)
                                                            ((LabelExt)labelName[b - 1]).ForeColor = Color.FromArgb(((Byte)(240)), ((Byte)(170)), ((Byte)(170)));
                                                  else
                                                            ((LabelExt)labelName[b - 1]).ForeColor = Color.Gray;

                                                  //((LabelExt)labelName[b - 1]).Tag = D.GetString(selectday.Tag).Substring(0, 4) + prem;
                                                  ((LabelExt)labelName[b - 1]).Tag = preYY + prem;
                                        }

                                        // 다음달 날짜를 음영으로 처리 하면서 이번달과 다음달 날짜를 삽입
                                        for (int a = day; a < 43; a++)
                                        {

                                                  if (a < (month + day))
                                                  {
                                                            daycount++;
                                                            months[a] = daycount;
                                                            if (a != 1 && a != 8 && a != 15 && a != 22 && a != 29 && a != 36)
                                                                      ((LabelExt)labelName[a - 1]).ForeColor = Color.Black;

                                                            ((LabelExt)labelName[a - 1]).Tag = D.GetString(selectday.Tag).Substring(0, 4) + tom;
                                                  }
                                                  else
                                                  {
                                                            daycount2++;
                                                            months[a] = daycount2;
                                                            if (a == 29 || a == 36)
                                                                      ((LabelExt)labelName[a - 1]).ForeColor = Color.FromArgb(((Byte)(240)), ((Byte)(170)), ((Byte)(170)));
                                                            else
                                                                      ((LabelExt)labelName[a - 1]).ForeColor = Color.Gray;

                                                            //((LabelExt)labelName[a - 1]).Tag = D.GetString(selectday.Tag).Substring(0, 4) + nextm;
                                                            ((LabelExt)labelName[a - 1]).Tag = nextYY + nextm;
                                                  }
                                        }

                                        DataSet ds = _biz.Search_Schedule_List(bpManager.CodeValue, currYY + tom); //일정을 조회Search_Schedule_List

                                        _flex.Binding = ds.Tables[0];

                                        // 라벨에 전체 달력의 날짜를 넣는다.
                                        for (int s1 = 1; s1 < 43; s1++)
                                        {
                                                  ((LabelExt)labelName[s1 - 1]).Text = D.GetString(months[s1]);

                                                  string setdate;

                                                  if (months[s1] < 10)
                                                  {
                                                      setdate = D.GetString(((LabelExt)labelName[s1 - 1]).Tag) + "0" + D.GetString(months[s1]);
                                                      ((LabelExt)labelName[s1 - 1]).Tag = setdate;
                                                  }
                                                  else
                                                  {
                                                      setdate = D.GetString(((LabelExt)labelName[s1 - 1]).Tag) + D.GetString(months[s1]);
                                                      ((LabelExt)labelName[s1 - 1]).Tag = setdate;
                                                  }


                                                    int ccount = 0;
                                                    string text = "";
                                                    string text2 = "";
                                                    string tm_시작 = "";

                                                    string Filter = "DT_CALENDAR  = '" + setdate + "'";

                                                    DataRow[] drs = _flex.DataTable.Select(Filter);

                                                    if (drs.Length > 0)
                                                    {
                                                        foreach (DataRow row in drs)
                                                        {
                                                            tm_시작 = row["TM_START"].ToString();
                                                            tm_시작 = tm_시작.Length == 4 ? "(" + row["TM_START"].ToString().Substring(0, 2) + ":" + row["TM_START"].ToString().Substring(2, 2) + ") " : "";

                                                            if (row["NM_TITLE"].ToString().Length > 9)
                                                            {
                                                                text2 = text2 + tm_시작 + Left(row["NM_TITLE"].ToString(), 8) + "…" + "\n";
                                                            }
                                                            else
                                                            {
                                                                text2 = text2 + tm_시작 + row["NM_TITLE"].ToString() + "\n";
                                                            }

                                                            //text2 = text2 + r["NM_TITLE"].ToString() + "\n";
                                                        }
                                                    }

                                                    ((RichTextBox)labelName_box[s1 - 1]).Text = text2;
                                                        
                                                    foreach (DataRow r in ds.Tables[0].Rows)
                                                    {
                                                        tm_시작 = r["TM_START"].ToString();
                                                        tm_시작 = tm_시작.Length == 4 ? "(" + r["TM_START"].ToString().Substring(0, 2) + ":" + r["TM_START"].ToString().Substring(2, 2) + ") " : "";

                                                        if (r["NM_TITLE"].ToString().Length > 9)
                                                        {
                                                            text = tm_시작 + Left(r["NM_TITLE"].ToString(), 8) + "…" + "\n";
                                                        }
                                                        else
                                                        {
                                                            text = tm_시작 + r["NM_TITLE"].ToString() + "\n";
                                                        }

                                                        int idx = ((RichTextBox)labelName_box[s1 - 1]).Text.IndexOf(text.Trim());

                                                        int length = text.Length;

                                                        string important = r["TP_CALENDAR"].ToString();

                                                        if (idx > -1)
                                                        {
                                                            ((RichTextBox)labelName_box[s1 - 1]).Select(idx, length);

                                                            if (important == "Y")
                                                            {
                                                                ((RichTextBox)labelName_box[s1 - 1]).SelectionColor = Color.Blue;
                                                            }
                                                            else if (important == "R")
                                                            {
                                                                ((RichTextBox)labelName_box[s1 - 1]).SelectionColor = Color.Red;
                                                            }
                                                            else
                                                            {
                                                                ((RichTextBox)labelName_box[s1 - 1]).SelectionColor = Color.Black;
                                                            }

                                                            ((RichTextBox)labelName_box[s1 - 1]).HideSelection = true;
                                                        }
                                                        ccount = ccount + 1;
                                                    }

                                                  if (today2 == D.GetString(((LabelExt)labelName[s1 - 1]).Tag))
                                                            ((LabelExt)labelName[s1 - 1]).BackColor = Color.FromArgb(((Byte)(227)), ((Byte)(241)), ((Byte)(248)));
                                                  else
                                                            ((LabelExt)labelName[s1 - 1]).BackColor = Color.White;

                                                  // 유휴일에 대한 날짜 색깔을 지정한다.
                                                  DataRow[] dtRow = dtChk.Select("SEQ = '2' AND CNT = '" + D.GetString(((LabelExt)labelName[s1 - 1]).Tag) + "'", "", DataViewRowState.CurrentRows);
                                                  if (dtRow.Length > 0)
                                                  {
                                                            if (D.GetString(((LabelExt)labelName[s1 - 1]).ForeColor.Name) == "Gray")
                                                                      ((LabelExt)labelName[s1 - 1]).ForeColor = Color.FromArgb(((Byte)(240)), ((Byte)(170)), ((Byte)(170)));
                                                            else
                                                                      ((LabelExt)labelName[s1 - 1]).ForeColor = Color.FromArgb(((Byte)(200)), ((Byte)(15)), ((Byte)(30)));
                                                  }

                                                  isChecked(chk휴일.Checked);
                                        }
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    #endregion
                    /// <summary>
                    /// 레프트 함수 추가/
                    /// </summary>
                    /// <param name="str"></param>
                    /// <param name="int_Length"></param>
                    /// <returns></returns>
                    public string Left(string str, int int_Length)
                    {
                        if (str.Length < int_Length) int_Length = str.Length;

                        return str.Substring(0, int_Length);
                    }

                    #region → 이전달의 마지막일, 이번달의 날짜 갯수, 이번달 1일의 요일 값
                    /// <summary>
                    /// 이전달의 마지막일, 이번달의 날짜 갯수, 이번달 1일의 요일을 dataRow로 리턴한다.
                    /// </summary>
                    /// <param name="selmonth">20020501</param>
                    /// <returns>30, 31, 4</returns>	
                    public string[] VarCalendar(string selmonth)
                    {
                              try
                              {
                                        int nextyear = System.Int32.Parse(selmonth.Substring(0, 4));
                                        int nextmonth = System.Int32.Parse(selmonth.Substring(4, 2)) + 1;

                                        // 13월 방지
                                        if (nextmonth > 12)
                                        {
                                                  nextyear = System.Int32.Parse(selmonth.Substring(0, 4)) + 1;
                                                  nextmonth = 1;
                                        }

                                        string nextAll = "";

                                        // 08월이 8월로 변경되는 현상 방지
                                        if (nextmonth < 10)
                                                  nextAll = nextyear.ToString() + "0" + nextmonth.ToString() + "01"; //다음년도월일 20030301
                                        else
                                                  nextAll = nextyear.ToString() + nextmonth.ToString() + "01"; //다음년도월일 20030301

                                        int preyear = System.Int32.Parse(selmonth.Substring(0, 4));
                                        int premonth = System.Int32.Parse(selmonth.Substring(4, 2)) - 1;

                                        // -1월 방지
                                        if (premonth < 1)
                                        {
                                                  preyear = System.Int32.Parse(selmonth.Substring(0, 4)) - 1;
                                                  premonth = 12;
                                        }


                                        string preAll = "";

                                        // 08월이 8월로 변경되는 현상 방지
                                        if (premonth < 10)
                                                  preAll = preyear.ToString() + "0" + premonth.ToString() + "01";		//지난년도월일 20010301
                                        else
                                                  preAll = preyear.ToString() + premonth.ToString() + "01";			//지난년도월일 20010301

                                        SpInfo si = new SpInfo();
                                        si.SpNameSelect = "SP_MA_CALENDAR_SELECT_DATE";
                                        si.SpParamsSelect = new object[] { preAll, selmonth, nextAll };

                                        ResultData result = (ResultData)this.FillDataTable(si);
                                        DataTable dt = (DataTable)result.DataValue;

                                        string[] data = new string[4];
                                        data[0] = dt.Rows[0]["last_month"].ToString();
                                        data[1] = dt.Rows[0]["to_month"].ToString();
                                        data[2] = dt.Rows[0]["next_month"].ToString();

                                        return data;
                              }
                              catch (Exception ex)
                              {
                                        this.MsgEnd(ex);
                              }

                              return null;
                    }

                    #endregion


                    void Page_DataChanged(object sender, EventArgs e)
                    {
                              try
                              {
                                        //SetToolBarButtonState(true, true, true, true, false);
                              }
                              catch (Exception ex)
                              {
                                        MsgControl.CloseMsg();
                                        MsgEnd(ex);
                              }
                    }
                    /*
                    private void FilterArtist()
                    {
                              try
                              {
                                        string Filter = "NO_SCHEDULE  = '" + D.GetString(_flex["NO_SCHEDULE"]) + "'";

                                        //_flexArtist.RowFilter = Filter;
                              }
                              catch (Exception ex)
                              {
                                        throw ex;
                              }
                    }
                    */
                    #region → 그리드 및 panel 값 로드
                    /// <summary>
                    /// 텍스트 박스에 값 로드
                    /// </summary>
                    /// <param name="seldate">선택 날짜</param>
                    public void GridLoad(string seldate)
                    {
                              _calendar = _biz.Search(D.GetString("001"), seldate);       // 정규 근무 형태

                              if (_calendar.Rows.Count > 0)
                              {
                                        //if (!MsgAndSave(true, false)) return;


                                        if (_flex.DataTable != null)
                                        {
                                                  _flex.DataTable.Rows.Clear();

                                                  SetControlBinding(null, this.pnlInfoSchedule);

                                                  Application.DoEvents();
                                        }

                                        DataSet ds = _biz.Search_Schedule(bpManager.CodeValue, SelectedDate);

                                        _flex.Binding = ds.Tables[0];

                                        string holiday = "";

                                        holiday = _calendar.Rows[0]["FG1_HOLIDAY"].ToString();

                                        if (holiday == "H")
                                        {
                                            chk휴일.Checked = true;
                                        }
                                        else
                                        {
                                            chk휴일.Checked = false;
                                        }

                                        if (!_flex.HasNormalRow)
                                        {
                                                  //ShowMessage(공통메세지.조건에해당하는내용이없습니다);
                                                  return;
                                        }

                                        isChecked(chk휴일.Checked);

                                        if (D.GetString(_flex["NO_EMP"]) == bpManager.CodeValue)
                                        {
                                            pnlInfoSchedule.Enabled = true;
                                            SetToolBarButtonState(true, true, true, true, false);
                                        }
                                        else
                                        {
                                            pnlInfoSchedule.Enabled = false;
                                            SetToolBarButtonState(true, true, false, false, false);
                                        }
                              }
                              else
                              {
                                        DataRow rows = _calendar.NewRow();
                                        _calendar.Rows.Add(rows);
                                        //tClear = true;
                                        //txtSeqCal.Text = txtFdateSeq.Text = txtCalendarDes.Text = string.Empty;
                              }
                    }

                    public void isChecked(bool Checked)
                    {
                        if (Checked)
                        {
                            pnlInfoSchedule.Enabled = false;
                            SetToolBarButtonState(true, false, false, false, false);
                            btn휴일.Text = "평일지정";
                        }
                        else
                        {
                            pnlInfoSchedule.Enabled = true;
                            //SetToolBarButtonState(true, true, true, true, false);
                            btn휴일.Text = "휴일지정";
                        }
                    }

                    private void btn휴일_Click(object sender, EventArgs e)
                    {
                        string chk = chk휴일.Checked == true ? "H" : "W";
                        string seldate = SelectedDate;

                        if (chk == "H")
                        {
                            DialogResult result = ShowMessage("평일로 지정하시겠습니까?", "QY2");

                            if (result == DialogResult.Yes)
                            {
                                _biz.휴일저장("W", seldate);

                                if (!BeforeSearch()) return;

                                string[] data = VarCalendar(D.GetString(selectday.Tag));
                                Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));
                                GridLoad(seldate);
                            }
                        }
                        else if (chk == "W")
                        {
                            DialogResult result = ShowMessage("휴일을 지정하시겠습니까?", "QY2");

                            if (result == DialogResult.Yes)
                            {
                                _biz.휴일저장("H", seldate);

                                if (!BeforeSearch()) return;

                                string[] data = VarCalendar(D.GetString(selectday.Tag));
                                Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));
                                GridLoad(seldate);
                            }
                        }
                    }

              /*

                    private void btn휴일지정_Click(object sender, EventArgs e)
                    {
                        string chk = chk휴일.Checked == true ? "H" : "W";
                        string seldate = SelectedDate;

                        if (chk == "H")
                        {
                            ShowMessage("이미 휴일로 지정된 일자입니다.");
                        }
                        else if (chk == "W")
                        {
                            DialogResult result = ShowMessage("휴일을 지정하시겠습니까?", "QY2");

                            if (result == DialogResult.Yes)
                            {
                                _biz.휴일저장("H", seldate);

                                if (!BeforeSearch()) return;

                                string[] data = VarCalendar(D.GetString(selectday.Tag));
                                Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));
                                GridLoad(seldate);
                            }
                        }
                    }

                    private void btn휴일해제_Click(object sender, EventArgs e)
                    {
                        string chk = chk휴일.Checked == true ? "H" : "W";
                        string seldate = SelectedDate;

                        if (chk == "W")
                        {
                            ShowMessage("이미 평일로 지정된 일자입니다.");
                        }
                        else if (chk == "H")
                        {
                            DialogResult result = ShowMessage("평일로 지정하시겠습니까?", "QY2");

                            if (result == DialogResult.Yes)
                            {
                                _biz.휴일저장("W", seldate);

                                if (!BeforeSearch()) return;

                                string[] data = VarCalendar(D.GetString(selectday.Tag));
                                Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));
                                GridLoad(seldate);
                            }
                        }
                    }
              */

                    private void btn전체일정_Click(object sender, EventArgs e)
                    {
                        string[] data = VarCalendar(D.GetString(selectday.Tag));
                        Calendar(Int32.Parse(D.GetString(data[0])), Int32.Parse(D.GetString(data[1])), Int32.Parse(D.GetString(data[2])));
                    }

                    private void chk휴일_CheckedChanged(object sender, EventArgs e)
                    {
                        isChecked(chk휴일.Checked);
                    }

                    private void SetControlBinding(DataRow row, Control pnl)
                    {
                              if (row == null)
                              {
                                        foreach (Control ctr in pnl.Controls)
                                        {
                                                  if (ctr is TextBoxExt)
                                                  {
                                                            ((TextBoxExt)ctr).Text = string.Empty;
                                                  }
                                                  else if (ctr is DropDownComboBox)
                                                  {
                                                            ((DropDownComboBox)ctr).SelectedIndex = -1;
                                                            ((DropDownComboBox)ctr).SelectedValue = string.Empty;
                                                  }
                                                  else if (ctr is MaskedEditBox)
                                                  {
                                                            ((MaskedEditBox)ctr).Clear();
                                                            ((MaskedEditBox)ctr).Text = longtoday.Substring(8, 6);
                                                  }
                                                  else if (ctr is BpCodeTextBox)
                                                  {
                                                            ((BpCodeTextBox)ctr).Clear();
                                                  }
                                                  else if (ctr is RichTextBox)
                                                  {
                                                      ((RichTextBox)ctr).Clear();
                                                  }
                                                  else if (ctr is DatePicker)
                                                  { 
                                                            ((DatePicker)ctr).Text = SelectedDate;
                                                  }
                                        }

                              }
                              else
                              {
                                        foreach (Control ctr in pnl.Controls)
                                        {
                                                  if (ctr is TextBoxExt)
                                                  {
                                                            ((TextBoxExt)ctr).Text = row[((TextBoxExt)ctr).Tag.ToString()].ToString();
                                                  }
                                                  else if (ctr is DropDownComboBox)
                                                  {
                                                            ((DropDownComboBox)ctr).SelectedValue = row[((DropDownComboBox)ctr).Tag.ToString()].ToString();
                                                  }
                                                  else if (ctr is CheckBoxExt)
                                                  {
                                                      ((CheckBoxExt)ctr).Checked = row[((CheckBoxExt)ctr).Tag.ToString()].ToString() == "Y" ? true : false;
                                                  }
                                                  
                                        }

                              }

                    }

                    void _flex_AfterRowChange(object sender, RangeEventArgs e)
                    {
                        string right = "";

                        try
                        {
                            right = D.GetString(_flex["NO_EMP"]);

                            if (right == bpManager.CodeValue)
                            {
                                isChecked(false);
                                SetToolBarButtonState(true, true, true, true, false);
                            }
                            else
                            {
                                isChecked(true);
                                SetToolBarButtonState(true, true, false, false, false);
                            }
                        }
                        catch (Exception ex)
                        {
                            Global.MainFrame.MsgEnd(ex);
                        }
                    }

                    #endregion

                    #region → 변경유무 체크
                    /// <summary>
                    /// 변경유무 체크
                    /// </summary>
                    /// <returns></returns>
                    private bool YnChange()
                    {
                              if (_calendar != null)
                              {
                                        if (_calendar.GetChanges() != null)
                                        {
                                                  DialogResult result = ShowMessage(공통메세지.변경된사항이있습니다저장하시겠습니까, "QY2");

                                                  if (result == DialogResult.Yes)
                                                            return true;
                                                  else if (result == DialogResult.Cancel)
                                                            return false;
                                        }
                              }

                              return false;
                    }

                    #endregion

                    #region → 클릭시 라벨의 배경색을 변경한다.
                    /// <summary>
                    /// 클릭시 라벨의 배경색을 변경한다.
                    /// </summary>
                    /// <param name="SelectedDate">선택되어진 날짜</param>
                    private void Click_Bgcolor(string SelectedDate)
                    {
                              try
                              {
                                        //Label 이름을 Object 배열로 선언
                                        object[] labelName ={
										 label101,label102,label103,label104,label105,label106,
										 label107,label108,label109,label110,label111,label112,
										 label113,label114,label115,label116,label117,label118,
										 label119,label120,label121,label122,label123,label124,
										 label125,label126,label127,label128,label129,label130,
										 label131,label132,label133,label134,label135,label136,
										 label137,label138,label139,label140,label141,label142
									 };

                                        for (int s = 1; s < 43; s++)
                                        {
                                                  if (SelectedDate == D.GetString(((LabelExt)labelName[s - 1]).Tag))
                                                            ((LabelExt)labelName[s - 1]).BackColor = Color.FromArgb(((Byte)(255)), ((Byte)(250)), ((Byte)(190)));
                                                  else
                                                  {
                                                            if (today2 == D.GetString(((LabelExt)labelName[s - 1]).Tag))
                                                                      ((LabelExt)labelName[s - 1]).BackColor = Color.FromArgb(((Byte)(227)), ((Byte)(241)), ((Byte)(248)));
                                                            else
                                                                      ((LabelExt)labelName[s - 1]).BackColor = Color.Transparent;
                                                  }
                                        }
                              }
                              catch (Exception ex)
                              {
                                        MsgEnd(ex);
                              }
                    }

                    #endregion
                    #endregion

                    #region ♪ 속성          ♬

                    bool CheckManagerID { get { return !Checker.IsEmpty(bpManager, DD(lblID_USER.Text)); } }

                    bool 캘린더체크
                    {
                        get
                        {
                            dtChk = _biz.CalendarCheck(D.GetString("001"), dp년월.Text.Substring(0, 4).ToString());      // 등록된 calenda type 001로 고정

                            if (dtChk.Rows[0]["CNT"].ToString() == "0")
                            {
                                // CALENDAR가 없으면 생성
                                if (!_biz.달력생성(dp년월.Text.Substring(0, 4).ToString()))
                                {
                                    MessageBoxEx.Show(this.GetMessageDictionaryItem("PR_M100004"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                            return true;
                        }
                    }
                    #endregion

                    private void dp년월_CloseUp(object sender, EventArgs e)
                    {
                        string dtvalue2 = dp년월.Value.ToString("yyyyMMdd");

                        try
                        {
                            SpInfo si = new SpInfo();
                            si.SpNameSelect = "SP_MA_CALENDAR_SELECT_CNT";
                            si.SpParamsSelect = new object[] { this.MainFrameInterface.LoginInfo.CompanyCode, "001", dp년월.Text.ToString(), "" };

                            ResultData result = (ResultData)this.FillDataTable(si);

                            if (result.OutParamsSelect[0, 0].ToString() == "N")
                            {
                                if (Global.MainFrame.LoginInfo.Language == "KR")
                                    this.ShowMessage("PR_M100003");
                                else
                                    ShowMessage("Please Creating Calendar.");

                                return;
                            }
                               
                            string years = dtvalue2.Substring(0, 4).ToString() + dtvalue2.Substring(4, 2).ToString() + "01";
                            this.selectday.Tag = dp년월.Text.Substring(0, 4).ToString() + dp년월.Text.Substring(5, 2).ToString() + "01";

                            SelectedDate = dtvalue2;

                            string[] data = VarCalendar(years);
                            Calendar(System.Int32.Parse(data[0].ToString()), System.Int32.Parse(data[1].ToString()), System.Int32.Parse(data[2].ToString()));

                            selectday.Text = dp년월.Text.Substring(0, 4).ToString() + "년" + " " + dp년월.Text.Substring(5, 2).ToString() + "월";

                            // 해당 월의 1일 날짜의 계획을 뿌려 준다.
                            t_dc_text.Tag = SelectedDate;
                            t_dc_text.Text = SelectedDate.Substring(0, 4) + "년" + " " + SelectedDate.Substring(4, 2) + "월" + " " + "내용";

                            GridLoad(SelectedDate);

                            Click_Bgcolor(SelectedDate);

                            if (_calendar != null)
                                _calendar.AcceptChanges();
                        }
                        catch (Exception ex)
                        {
                            MsgEnd(ex);
                        }
                    }
          }
}
