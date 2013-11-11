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
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO.User;
using System.Web.Services;

namespace ALEREIMPACT
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        ClsGeneric objGeneric = new ClsGeneric();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnsend_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objRegisterUserBAO.LoginEmail = txtemail.Text;
                objRegisterUserBAO.procedureType = "S";
                dt = RegisterUserDAO.GetEmailDetail(objRegisterUserBAO);
                if (dt.Rows.Count == 0)
                {
                    lberror.Visible = true;
                    lberror.Text = "Email Not Found";
                }
                else
                {
                    lberror.Visible = false;
                    string randomPassword = System.Guid.NewGuid().ToString().Substring(0, 8);
                    int retval = 0;                   
                    objRegisterUserBAO.user_registration_Id = Convert.ToInt32(dt.Rows[0]["pk_user_registration_Id"]);
                    objRegisterUserBAO.LoginPassword = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(randomPassword);
                    objRegisterUserBAO.PasswordSalt = "";
                    objRegisterUserBAO.IsPasswordChanged = false;
                    objRegisterUserBAO.procedureType = "U1";
                    retval = RegisterUserDAO.UpdatePassword(objRegisterUserBAO);
                    string email = txtemail.Text;
                    string subject = "Alere Vitality : Forgot Password Detail";
                    string body = "Hi " + "&nbsp;"  + "," + "<br /><br />" + "Your email :"+"&nbsp;"+ email +
                        "<br /><br />" + "Your new password  :" + "&nbsp;" + randomPassword + "<br /><br />" + "Improving your health and the health of your community of loved ones is very" + " <br />" +
                        "important to us. We’ve tried to develop an easy-to-use and smart tool, but that’s" + " <br />" +
                        "really for you to judge. Your input is critical to how we continue to build and adjust" + " <br />" +
                        "Alere Vitality. Please never hesitate to be open and honest, and in return we will" + " <br />" +
                        "make sure to incorporate feedback and fixes as quickly as possible." + " <br /><br/>" +
                        "We’re excited to be a part of your journey for better health! " + " <br /><br />" +
                        "Let’s get started: Click Here to visit" + "&nbsp;" + "http://alerevitality.com/" + "&nbsp;" + " now!"
                        + " <br /><br />" + "With Support and Respect," + "<br />" +

                        "The Alere Vitality Team";


                    //string body = "Your New  Password is  " + randomPassword + ".";
                    objGeneric.SendMail(email, body, subject);
                    Response.Write("<script> location.href='ForgotPasswordThank.aspx'</script>");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkTermsnConditions_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/termsandconditions.aspx", false);
        }

        protected void lnkprivacynPolicy_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/privacyandpolicy.aspx", false);
        }

        protected void lnkSupport_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/support.aspx", false);
        }
    }
}
