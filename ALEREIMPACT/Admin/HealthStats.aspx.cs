using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.FRAMEWORK;
using System.IO;
namespace ALEREIMPACT.Admin
{
    public partial class HealthStats : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                //Response.Cache.SetNoStore();
                //Response.AppendHeader("Pragma", "no-cache");
            
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        BindMissionProgress();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BindMissionProgress()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "AU";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                if (dt.Rows.Count > 0)
                {

                    GrdMissionProgess.DataSource = dt;
                    GrdMissionProgess.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdMissionProgess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbID = (Label)e.Row.FindControl("lbId");
                    Label lbCalconsumed = (Label)e.Row.FindControl("lbCalconsumed");
                    Label lbCalBurned = (Label)e.Row.FindControl("lbCalBurned");
                    Label lbSteps = (Label)e.Row.FindControl("lbSteps");
                    Label lbCWeight = (Label)e.Row.FindControl("lbCWeight");
                    DataTable dt= new DataTable();
                    objAdminBAO.fk_login_id = Convert.ToInt32(lbID.Text);
                    objAdminBAO.login_user_Id = Convert.ToInt32(lbID.Text);
                    objAdminBAO.ProcedureType = "S";
                    dt=AdminDAO.GetUserMissionProgressGraph(objAdminBAO);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            int sumOfCalBurn = 0;
                            int stepsTaken = 0;
                            int calConsumed = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                sumOfCalBurn += Convert.ToInt32(dt.Rows[i]["InputSubmitted"].ToString().Trim());
                                stepsTaken += Convert.ToInt32(dt.Rows[i]["CalorieConsumed"].ToString().Trim());
                                calConsumed += Convert.ToInt32(dt.Rows[i]["StepsCovered"].ToString().Trim());
                            }
                            lbCalBurned.Text = Convert.ToString(sumOfCalBurn);
                            lbCalconsumed.Text = Convert.ToString(calConsumed);
                            lbSteps.Text = Convert.ToString(stepsTaken);
                            lbCWeight.Text = Convert.ToString(dt.Rows[0]["weight_left"].ToString());
                        }
                        else
                        {
                            lbCalBurned.Text = "0";
                            lbCalconsumed.Text ="0";
                            lbSteps.Text = "0";
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdMissionProgess_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GrdMissionProgess.PageIndex = e.NewPageIndex;
                BindMissionProgress();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //return;
        }
        protected void ImgBtnExportExcel_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "AU";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=Healthstats.xls");
                    Response.Charset = "utf-8";
                    Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter ht = new HtmlTextWriter(sw);
                    GrdMissionProgess.AllowPaging = false;
                    GrdMissionProgess.Columns[5].Visible = false;
                    BindMissionProgress();
                    GrdMissionProgess.RenderControl(ht);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdMissionProgess_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkViewChart")
                {
                    string id = e.CommandArgument.ToString();
                    Session["Healthstats"] = true;
                    Response.Redirect("HealthstatChart.aspx?val=" + id, false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
