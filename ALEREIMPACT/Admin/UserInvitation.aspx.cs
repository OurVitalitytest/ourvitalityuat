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
using System.Text;
using System.IO;

namespace ALEREIMPACT.Admin
{
    public partial class UserInvitation : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        ClsGeneric objClsGeneric = new ClsGeneric();
        public static string email = "";
        public static string body="";
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
                        bindGrd();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "UI";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btn_send_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            string subject;
            try
            {
                if (txtEmail.Text != "")
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.ProcedureType = "E";
                    dt = AdminDAO.GettbUserDetail(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (txtEmail.Text == dt.Rows[i]["login_email"].ToString())
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('User already exists');", true);
                                txtEmail.Text = "";
                                return;
                            }
                        }
                    }
                    
                        // get();
                        email = txtEmail.Text;
                        int retval = 0;
                        objAdminBAO.UI_ID = 0;
                        objAdminBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objAdminBAO.UI_USER_MAIL_ID = txtEmail.Text;
                        objAdminBAO.UI_DATE = DateTime.Now.ToString();
                        objAdminBAO.UI_STATUS = "False";
                        objAdminBAO.UI_CODE = 1;
                        objAdminBAO.UI_MAIL_STATUS = "Successfull";
                        objAdminBAO.ProcedureType = "I";
                        retval = AdminDAO.InserttblUserInvitation(objAdminBAO);
                        subject = " Vitality Invitation";

                   



                        body = this.PopulateBody("Hi" + "," + "<br /><br />"+" Vitality Invitation",ConfigurationManager.AppSettings["AlereVitality_Path"]  + "/Register.aspx?val=" + retval, "<br />"+
                         "Admin would like to invite you to participate in their health journey and "+"<br />"
                         + "help test out a new site and app called Vitality." + "<br /><br />"+
                         "Vitality lets you connect with other people looking to get healthier and"+"<br />"
                         + "support each other as we all accomplish our health goals."+"<br /><br />"+
                         "Click Here to finish signing up. Admin is waiting for you!"+"<br /><br />"+
                         "Can’t wait to meet you," + "<br />" + "The Vitality Team");
                        // body = "Please join This Link ,<br/>" + "<br/>" + "http://trigmasolutions.com/alereimpactnew/Register.aspx";
                        // body += GetGridviewData(GridView2);
                        objClsGeneric.SendMail(email, body, subject);
                     

                        bindGrd();
                        txtEmail.Text = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Invitation has been sent.');", true);
                        // Response.Write("<script>alert('Invitation Sent Successfully.') ; location.href='UserInvitation.aspx'</script>");
                    }
                
               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private string PopulateBody( string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/InvitationEmail.htm")))
            {
                body = reader.ReadToEnd();
            }
           //body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }
       

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                RequiredFieldValidator1.Enabled = false;
                if (e.CommandName == "lnkResend")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = id;
                    objAdminBAO.ProcedureType = "SG";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        email = dt.Rows[0]["UI_USER_MAIL_ID"].ToString();
                    }

                    string subject = " Vitality : Invitation";
                    body = this.PopulateBody("Hi" + "," + "<br /><br />" + "Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + id, "<br />" +
                               "Admin would like to invite you to participate in their health journey and " + "<br />"
                               + "help test out a new site and app called Vitality." + "<br /><br />" +
                               "Vitality lets you connect with other people looking to get healthier and" + "<br />"
                               + "support each other as we all accomplish our health goals." + "<br /><br />" +
                               "Click Here to finish signing up. Admin is waiting for you!" + "<br /><br />" +
                               "Can’t wait to meet you," + "<br />" + "The Vitality Team");
                    // body = "Please join This Link ,<br/>" + "<br/>" + "http://trigmasolutions.com/alereimpactnew/Register.aspx";
                    // body += GetGridviewData(GridView2);
                    objClsGeneric.SendMail(email, body, subject);
                    int retval = 0;
                    objAdminBAO.UI_ID = id;
                    objAdminBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.UI_USER_MAIL_ID = email;
                    objAdminBAO.UI_DATE = DateTime.Now.ToString();
                    objAdminBAO.UI_STATUS = "False";
                    objAdminBAO.UI_CODE = 1;
                    objAdminBAO.UI_MAIL_STATUS = "Successfull";
                    objAdminBAO.ProcedureType = "U";
                    retval = AdminDAO.InserttblUserInvitation(objAdminBAO);
                    //txtEmail.Text = "";
                    bindGrd();
                    //  Response.Write("<script>alert('Invitation Resent Successfully.') ; location.href='UserInvitation.aspx'</script>");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbId = (Label)e.Row.FindControl("lbId");
                    Label lbStatus = (Label)e.Row.FindControl("lbStatus");
                    LinkButton lnkResend = (LinkButton)e.Row.FindControl("lnkResend");
                    DataTable dt = new DataTable();
                    objAdminBAO.ID =  Convert.ToInt32(lbId.Text);
                    objAdminBAO.ProcedureType = "SG";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows[0]["UI_STATUS"].ToString() == "False")
                    {
                        lbStatus.Text = "Waiting";
                        lnkResend.Enabled = true;
                    }
                    else
                    {
                        lbStatus.Text = "Joined";
                        lnkResend.Enabled = false;
                        lnkResend.Style.Add("color", "#999999");
                        lnkResend.Style.Add("text-decoration", "none");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
