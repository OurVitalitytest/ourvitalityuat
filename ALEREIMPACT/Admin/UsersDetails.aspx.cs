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
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;

namespace ALEREIMPACT.Admin
{
    public partial class UsersDetails : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();

        SQLHelper objSQLHelper = new SQLHelper();
        public static string userid = "";
        ClsGeneric objGeneric = new ClsGeneric();
        string Todate = "";
        string FromDate = "";
        string Procedure = "";

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
                    if (!IsPostBack)
                    {
                        BindGridView();
                        dvmain.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkNewUser_Click(object sender, EventArgs e)
        {

            BindGridView();
        }

        private DataTable BindGridView()
        {
            DataTable dtNewUserDetails = new DataTable();
            dvgrdNewUserdetails.Visible = true;
            divLoggedInMore.Visible = false ;
            div2.Visible = false;
            div1.Visible = false ;

            try
            {
                objAdminBAO.ProcedureType = Procedure;
                objAdminBAO.FromDate = FromDate .ToString();
                objAdminBAO.ToDate = Todate.ToString ();
                dtNewUserDetails = AdminDAO.GetNewUserDetails(objAdminBAO);
                if (dtNewUserDetails.Rows.Count != 0)
                {
                    GridView1.DataSource = dtNewUserDetails;
                    GridView1.DataBind();
                    lblmsg.Visible = false;
                    GridView1.Visible = true;
                }
                else
                {
                    lblmsg.Visible = true;
                    GridView1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {

                dtNewUserDetails.Dispose();
            }
            return dtNewUserDetails;
        }

        private DataTable BindGridView1()
        {
            DataTable dtLoggedMore = new DataTable();
            divLoggedInMore.Visible = true;
            dvgrdNewUserdetails.Visible = false;
            div2.Visible = false;
            div1.Visible = false ;
            try
            {
                objAdminBAO.ProcedureType = Procedure;
                objAdminBAO.FromDate = FromDate.ToString();
                objAdminBAO.ToDate = Todate.ToString();
                dtLoggedMore = AdminDAO.GetNewUserDetails(objAdminBAO);
                if (dtLoggedMore.Rows.Count != 0)
                {
                    gdLoggedInMore.DataSource = dtLoggedMore;
                    gdLoggedInMore.DataBind();
                    lblmsg.Visible = false ;
                    gdLoggedInMore.Visible = true;
                }
                else
                {
                    lblmsg.Visible = true;
                    gdLoggedInMore.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {

                dtLoggedMore.Dispose();
            }
            return dtLoggedMore;
        }
        private DataTable BindGridView2()
        {
            DataTable dtinvited = new DataTable();
            divLoggedInMore.Visible = false ;
            dvgrdNewUserdetails.Visible = false;
            div2.Visible = false ;
            div1.Visible = true;
            try
            {
                objAdminBAO.ProcedureType = Procedure;
                objAdminBAO.FromDate = FromDate.ToString();
                objAdminBAO.ToDate = Todate.ToString();
                dtinvited = AdminDAO.GetNewUserDetails(objAdminBAO);
                if (dtinvited.Rows.Count != 0)
                {
                    GridView2.DataSource = dtinvited;
                    GridView2.DataBind();
                    lblmsg.Visible = false;
                    GridView2.Visible = true;
                }
                else
                {
                    lblmsg.Visible = true;
                    GridView2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {

                dtinvited.Dispose();
            }
            return dtinvited;
        }
        private DataTable BindGridView3()
        {
            DataTable dtMSaccomp = new DataTable();
            divLoggedInMore.Visible = false;
            dvgrdNewUserdetails.Visible = false;
            div1.Visible = false ;
            div2.Visible = true;
            try
            {
                objAdminBAO.ProcedureType = Procedure;
                objAdminBAO.FromDate = FromDate.ToString();
                objAdminBAO.ToDate = Todate.ToString();
                dtMSaccomp = AdminDAO.GetNewUserDetails(objAdminBAO);
                if (dtMSaccomp.Rows.Count != 0)
                {
                    GridView3.DataSource = dtMSaccomp;
                    GridView3.DataBind();
                    lblmsg.Visible = false;
                    GridView3.Visible = true;
                }
                else
                {
                    lblmsg.Visible = true;
                    GridView3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {

                dtMSaccomp.Dispose();
            }
            return dtMSaccomp;
        }


        protected void ddlUserstats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserstats.SelectedValue == "1")
            {
                ddlduration.Visible = true;
                lblmsg.Visible = false;
            }
            else if (ddlUserstats.SelectedValue == "2")
            {
                //ddlduration.Visible = false ;
               // ddlduration.SelectedValue = "1";
                lblmsg.Visible = false;
            }
        }
        protected void Imgbtnresult_Click(object sender, EventArgs e)
        {
            if (ddlduration.SelectedValue == "1" && ddlUserstats.SelectedValue =="1")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                Procedure="NewUserDetails";
                BindGridView();
            }
            else if (ddlduration.SelectedValue == "2" && ddlUserstats.SelectedValue == "1")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                Procedure="NewUserDetails";
                BindGridView();
            }
            else if (ddlUserstats.SelectedValue == "2" && ddlduration.SelectedValue == "1")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                Procedure = "loginMore";
                BindGridView1();
            }
            else if (ddlUserstats.SelectedValue == "2" && ddlduration.SelectedValue == "2")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                Procedure = "loginMore";
                BindGridView1();
            }
            else if (ddlUserstats.SelectedValue == "3" && ddlduration.SelectedValue == "1")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                Procedure = "FrdRqT";
                BindGridView2();
            }
            else if (ddlUserstats.SelectedValue == "3" && ddlduration.SelectedValue == "2")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                Procedure = "FrdRqT";
                BindGridView2();
            }
            
                  else if (ddlUserstats.SelectedValue == "4" && ddlduration.SelectedValue == "1")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                Procedure = "MissionLogActivity";
                BindGridView3();
            }
            else if (ddlUserstats.SelectedValue == "4" && ddlduration.SelectedValue == "2")
            {
                Todate = DateTime.Now.ToString("yyyy-MM-dd");
                FromDate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                Procedure = "MissionLogActivity";
                BindGridView3();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnMonth = (HiddenField)e.Row.FindControl("hdnMonth");
                HiddenField hdnDate = (HiddenField)e.Row.FindControl("hdnDate");
                HiddenField HdnName = (HiddenField)e.Row.FindControl("HdnName");
                Label lbMonth = (Label)e.Row.FindControl("LbMonth");
                Label lbl1 = (Label)e.Row.FindControl("lbl1");
                if (hdnMonth.Value == "0")
                {
                    lbMonth.Text = "NA";
                }
                else
                {
                    lbMonth.Text = hdnMonth.Value + ", " + hdnDate.Value;
                }

                if ((HdnName.Value).Contains("No Information") || HdnName.Value == "" || HdnName.Value == null)
                {
                    lbl1.Text = "NA (Facebook Login)";
                }
                else
                {
                    lbl1.Text = HdnName.Value;
                }

                 
            } 
        }

        protected void gdLoggedInMore_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField HdnName = (HiddenField)e.Row.FindControl("HdnName");
                Label lbl8 = (Label)e.Row.FindControl("lbl8");
                if ((HdnName.Value).Contains("No Information") || HdnName.Value == "" || HdnName.Value == " " || HdnName.Value == null)
                {
                    lbl8.Text = "NA (Facebook Login)";
                }
                else
                {
                    lbl8.Text = HdnName.Value;
                }
            }
        }

    }
}
