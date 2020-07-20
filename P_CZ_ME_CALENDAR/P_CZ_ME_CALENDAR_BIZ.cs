using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Duzon.ERPU;
using Duzon.Common.Util;
using Duzon.Common.Forms;

namespace cz
{
          public class P_CZ_ME_CALENDAR_BIZ
          {
                    string _CompanyCode = Global.MainFrame.LoginInfo.CompanyCode;
                    string _UserID = Global.MainFrame.LoginInfo.UserID;

                    internal DataTable CalendarCheck(string CalType, string YM)
                    {
                            return DBHelper.GetDataTable("SP_MA_CALENDAR_SELECT", new object[] { _CompanyCode, CalType, YM });
                    }

                    internal bool 달력생성(string Year)
                    {
                              // EXEC UP_CZ_CALENDAR_SACE '3000', '001', '20140101', '001', ' '
                              return DBHelper.ExecuteNonQuery("MA_CALENDAR_SACE", new object[] { _CompanyCode, "001", Year+"01"+"01","001"," " });
                    }

                    internal void 주차구하기(string SelectedDate, out object[] Day)
                    {
                            DBHelper.ExecuteNonQuery("SP_MA_CALENDAR_SAVE_BEFORE", new object[] { SelectedDate }, out Day);
                    }

                    internal void 캘린더존재여부(string CalType, string YM, out object[] CalCheck)
                    {
                            DBHelper.ExecuteNonQuery("SP_MA_CALENDAR_SELECT_CNT", new object[] { _CompanyCode, CalType, YM }, out CalCheck);
                    }

                    internal DataTable Search(string CalType, string SelDate)
                    {
                            return DBHelper.GetDataTable("SP_MA_CALENDAR_SELECT_SUB", new object[] { _CompanyCode, CalType, SelDate });
                    }

                    internal void 휴일저장(string HW, string SelDate)
                    {
                        DBHelper.ExecuteNonQuery("UP_CZ_ME_CALENDAR_H_U", new object[] { _CompanyCode, HW, SelDate });
                    }

                    internal void Save(DataTable dt)
                    {
                            if (dt == null || dt.Rows.Count == 0) return;

                            SpInfo si = new SpInfo();
                            si.DataValue = dt;
                            si.CompanyID = _CompanyCode;
                            si.UserID = Global.MainFrame.LoginInfo.UserID;

                            si.SpNameInsert = "SP_MA_CALENDAR_INSERT";
                            si.SpParamsInsert = new string[] { "TP_CAL", "CD_COMPANY", "DT_CAL", "TP_WEEK", "SEQ_CAL", "TP_JOB", "FG1_HOLIDAY", "FDATESEQ", "FDATENO", "NO_PERIOD", "DC_TEXT", "ID_INSERT" };

                            si.SpNameUpdate = "SP_MA_CALENDAR_UPDATE";
                            si.SpParamsUpdate = new string[] { "TP_CAL", "CD_COMPANY", "DT_CAL", "TP_WEEK", "SEQ_CAL", "TP_JOB", "FG1_HOLIDAY", "FDATESEQ", "FDATENO", "NO_PERIOD", "DC_TEXT", "ID_UPDATE" };

                            si.SpNameDelete = "SP_MA_CALENDAR_DELETE";
                            si.SpParamsDelete = new string[] { "TP_CAL", "CD_COMPANY", "DT_CAL" };

                            DBHelper.Save(si);
                    }

                    // 매지저별 일정관리 조회
                    internal DataSet Search_Schedule(string SelectedEMP, string SelectedDate)
                    {
                        DataSet ds = DBHelper.GetDataSet("UP_CZ_ME_CALENDAR_S", new object[] { _CompanyCode, SelectedEMP, SelectedDate });

                              return ds;
                    }

                    // 매지저별 일정관리 조회
                    internal DataSet Search_Schedule_List(string SelectedEMP, string SelectedDate)
                    {
                        DataSet ds = DBHelper.GetDataSet("UP_CZ_ME_CALENDAR_LIST", new object[] { _CompanyCode, SelectedEMP, SelectedDate });

                        return ds;
                    }

                    internal string GetNo_Schedule(string SelDate)
                    {
                              string strNO_SCHEDULE = string.Empty;
                              string sQuery = string.Format("SELECT NEOE.FN_CZ_GET_NO_SCHEDULE('{0}','{1}')", _CompanyCode, SelDate);
                              object o = DBHelper.ExecuteScalar(sQuery);
                              return o.ToString();
                    }

                    internal bool Save2(DataTable dt)
                    {
                              SpInfoCollection sc = new SpInfoCollection();
                              SpInfo si = null;

                              if (dt != null && dt.Rows.Count != 0)
                              {
                                        si = new SpInfo();
                                        si.DataValue = dt;
                                        si.CompanyID = Global.MainFrame.LoginInfo.CompanyCode;
                                        si.UserID = Global.MainFrame.LoginInfo.EmployeeNo;
                                        si.SpNameInsert = "UP_CZ_ME_CALENDAR_I";
                                        si.SpNameUpdate = "UP_CZ_ME_CALENDAR_U";
                                        si.SpNameDelete = "UP_CZ_ME_CALENDAR_D";
                                        si.SpParamsInsert = new string[] { "CD_COMPANY", "DT_CALENDAR", "TP_CALENDAR", "DT_ROW", "NO_EMP", "NM_TITLE", "NM_NOTE", "DT_INSERT", "DT_UPDATE", "HOLIDAY", "TM_START" };
                                        si.SpParamsUpdate = new string[] { "CD_COMPANY", "DT_CALENDAR", "TP_CALENDAR", "DT_ROW", "NO_EMP", "NM_TITLE", "NM_NOTE", "DT_INSERT", "DT_UPDATE", "TM_START" };
                                        si.SpParamsDelete = new string[] { "CD_COMPANY", "DT_ROW" };

                                        sc.Add(si);
                              }


                              return DBHelper.Save(sc);
                    }
            
          }
}