using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using System.Diagnostics;
using Microsoft.Office.Interop;
using System.IO;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ALEREIMPACT.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");

                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }

                else
                {
                    userid = Convert.ToString(MySession.Current.LoginId);
                    countErrorMessage();
                    if (Convert.ToString(Session["User"]) == "True")
                    {
                        lnkUser.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Group"]) == "True")
                    {
                        lnkGroup.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Invite"]) == "True")
                    {
                        lnkInvite.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Circle"]) == "True")
                    {
                        lnkCircle.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Inspirator"]) == "True")
                    {
                        lnkInsp.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Mission"]) == "True")
                    {
                        lnkMission.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Analytics"]) == "True")
                    {
                        lnkAnalytics.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Error"]) == "True")
                    {
                        lnkError.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Flags"]) == "True")
                    {
                        lnkFlag.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["MessageD"]) == "True")
                    {
                        lnkMessageD.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["FeedBack"]) == "True")
                    {
                        lnkFeedBAck.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["category"]) == "True")
                    {
                        lnkAddCategory.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Personalization"]) == "True")
                    {
                        lnkAddCategory.Style.Add("color", "#31A5A0");
                    }
                    else if (Convert.ToString(Session["Healthstats"]) == "True")
                    {
                        lnkHeathstats.Style.Add("color", "#31A5A0");
                    }
                    Session["User"] = false;
                    Session["Group"] = false;
                    Session["Invite"] = false;
                    Session["Circle"] = false;
                    Session["Inspirator"] = false;
                    Session["Mission"] = false;
                    Session["Analytics"] = false;
                    Session["Error"] = false;
                    Session["Flags"] = false;
                    Session["MessageD"] = false;
                    Session["FeedBack"] = false;
                    Session["category"] = false;
                    Session["Personalization"] = false;
                    Session["Healthstats"] = false;
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void countErrorMessage()
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                objAdminBAO.ProcedureType = "CE";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToString(dt.Rows[0]["noofunread"]) == "0")
                    {
                        divCount.Style.Add("display", "none");
                    }
                    else
                    {
                        divCount.Style.Add("display", "");
                        lbCountER.Text = dt.Rows[0]["noofunread"].ToString();
                    }
                }

                System.Data.DataTable dt1 = new System.Data.DataTable();
                objAdminBAO.ProcedureType = "CT";
                dt1 = AdminDAO.GettbUserDetail(objAdminBAO);
                if (dt1.Rows.Count > 0)
                {
                    if (Convert.ToString(dt1.Rows[0]["noofunread"]) == "0")
                    {
                        divFeed.Style.Add("display", "none");
                    }
                    else
                    {
                        divFeed.Style.Add("display", "");

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("AdminChangePassword.aspx?val=" + userid, false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void lnkUser_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("AdminPanel.aspx", false);
                Session["User"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkGroup_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("GroupDetail.aspx", false);
                Session["Group"] = true;
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void lnkInvite_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("UserInvitation.aspx", false);
                Session["Invite"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkCircle_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("CircleManagement.aspx", false);
                Session["Circle"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkInsp_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("InspiratorManagement.aspx", false);
                Session["Inspirator"] = true;
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkMission_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("MissionManagement.aspx", false);
                Session["Mission"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkAnalytics_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {

                Response.Redirect("UserAnalytics.aspx", false);
                Session["Analytics"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkError_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("ErrorTypeLog.aspx", false);
                Session["Error"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkFlag_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("Flags.aspx", false);
                Session["Flags"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkMoodAnalytics_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("Personalization.aspx", false);
                Session["Personalization"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkMessageD_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("GlobalMessageDetail.aspx", false);
                Session["MessageD"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkFeedBAck_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("MessagesandTickets.aspx", false);
                Session["FeedBack"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkAddCategory_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("AddFoodCategory.aspx", false);
                Session["category"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkHeathstats_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("HealthStats.aspx", false);
                Session["Healthstats"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



        protected void lnkExportUserDetails_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            objAdminBAO.ProcedureType = "Profile";
            dt = AdminDAO.GetUserDetails(objAdminBAO);
            if (dt.Rows.Count > 0)
            {
                string filename = "UserPersonalDetails.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");

                Response.Write(tw.ToString());
                Response.End();
            }

        }

        protected void lnkBtnLog_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            objAdminBAO.ProcedureType = "Log";
            dt = AdminDAO.GetUserDetails(objAdminBAO);
            if (dt.Rows.Count > 0)
            {
                string filename = "UserLog.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");

                Response.Write(tw.ToString());
                Response.End();
            }

        }

        protected void lnkFoodLog_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            objAdminBAO.ProcedureType = "FoodLog";
            dt = AdminDAO.GetUserDetails(objAdminBAO);
            if (dt.Rows.Count > 0)
            {
                string filename = "UserFoodLog.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");

                Response.Write(tw.ToString());
                Response.End();
            }

        }

        protected void lnkBtnMissions_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            objAdminBAO.ProcedureType = "Missions";
            dt = AdminDAO.GetUserDetails(objAdminBAO);
            if (dt.Rows.Count > 0)
            {
                string filename = "Missions.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");

                Response.Write(tw.ToString());
                Response.End();
            }

        }


        protected void LnkUsersStats_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("UsersDetails.aspx", false);
                //Session["Group"] = true;
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void lnkExportAll_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            objAdminBAO.ProcedureType = "All";
            ds=AdminDAO.ExportAllExcel(objAdminBAO);
            if (ds != null)
            {
                ConvertToExcel(ds);
            }
                
        }


        public void ConvertToExcel(DataSet ds)
        {

            try
            {
                string FilePath;
                Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                //ExcelApp.Application.SheetsInNewWorkbook = 4;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;
                oSheet = (Worksheet)ExcelApp.Sheets.Add(Missing.Value, Missing.Value, 6,Missing.Value);
                System.Data.DataTable dt = ds.Tables[0];
                System.Data.DataTable dt1 = ds.Tables[1];
                System.Data.DataTable dt2 = ds.Tables[2];
                System.Data.DataTable dt3 = ds.Tables[3];
                int idnx = 1;
                Microsoft.Office.Interop.Excel.Worksheet Sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.Sheets[idnx];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Sheet1.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Sheet1.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }
                idnx = idnx + 1;
                Microsoft.Office.Interop.Excel.Worksheet Sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.Sheets[idnx];
                for (int i = 0; i < dt1.Columns.Count; i++)
                {
                    Sheet2.Cells[1, i + 1] = dt1.Columns[i].ColumnName;
                }
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    for (int j = 0; j < dt1.Columns.Count; j++)
                    {
                        Sheet2.Cells[i + 2, j + 1] = dt1.Rows[i][j].ToString();
                    }
                }
                idnx = idnx + 1;
                Microsoft.Office.Interop.Excel.Worksheet Sheet3 = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.Sheets[idnx];
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    Sheet3.Cells[1, i + 1] = dt2.Columns[i].ColumnName;
                }
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        Sheet3.Cells[i + 2, j + 1] = dt2.Rows[i][j].ToString();
                    }
                }
                idnx = idnx + 1;
                Microsoft.Office.Interop.Excel.Worksheet Sheet4 = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.Sheets[idnx];
                for (int i = 0; i < dt3.Columns.Count; i++)
                {
                    Sheet4.Cells[1, i + 1] = dt3.Columns[i].ColumnName;
                }
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    for (int j = 0; j < dt3.Columns.Count; j++)
                    {
                        Sheet4.Cells[i + 2, j + 1] = dt3.Rows[i][j].ToString();
                    }
                }
                string name = "AllExport";
                FilePath = @"D:\" + name + ".xlsx";
                if (FilePath != string.Empty)
                {
                    ExcelApp.ActiveWorkbook.SaveAs(FilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel7, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                    System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
                    //Response.AppendHeader("content-disposition", "attachment;filename=" + name);
                    //Response.Clear();

                    Response.AddHeader("Content-Disposition", "attachement; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(file.FullName);
                    Response.End();
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
