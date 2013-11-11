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
    public partial class ChangePassword : System.Web.UI.Page
    {
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        ClsGeneric objGeneric = new ClsGeneric();
        public static string val = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        val = Convert.ToString(Request.QueryString["val"]);
                        if (val == "1")
                        {
                            btnBack.Visible = false;
                        }
                        else
                        {
                            btnBack.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnchangePwd_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objRegisterUserBAO.user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objRegisterUserBAO.LoginPassword = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtCurrentPassword.Text);
                objRegisterUserBAO.procedureType="S";
                dt = RegisterUserDAO.ChangePassword(objRegisterUserBAO);
                if (dt.Rows.Count == 0)
                {
                    lberror.Visible = true;
                    lberror.Text = "Password Not Found";
                }
                else
                {
                    string name = Convert.ToString(MySession.Current.UserFirstName);

                    lberror.Visible = false;
                    int retval = 0;
                    objRegisterUserBAO.user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objRegisterUserBAO.LoginPassword = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtNewPassword.Text);
                    objRegisterUserBAO.PasswordSalt = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtNewPassword.Text);
                    objRegisterUserBAO.IsPasswordChanged = true;
                    objRegisterUserBAO.procedureType = "U";
                    retval = RegisterUserDAO.UpdatePassword(objRegisterUserBAO);
                    string email = dt.Rows[0]["login_email"].ToString();
                    string subject = "Vitality : Change Password Detail";
                    string body = "Hi " + "&nbsp;" + name + "," + "<br /><br />" + "Thanks for joining Vitality.We’re excited to have you try out our Beta version." +
                        "<br /><br />" + "Your new password  :" + "&nbsp;" + txtNewPassword.Text  + "<br /><br />" + "Improving your health and the health of your community of loved ones is very" + " <br />" +
                        "important to us. We’ve tried to develop an easy-to-use and smart tool, but that’s" + " <br />" +
                        "really for you to judge. Your input is critical to how we continue to build and adjust" + " <br />" +
                        "Vitality. Please never hesitate to be open and honest, and in return we will" + " <br />" +
                        "make sure to incorporate feedback and fixes as quickly as possible." + " <br /><br/>" +
                        "We’re excited to be a part of your journey for better health! " + " <br /><br />" +
                        "Let’s get started: Click Here to visit" + "&nbsp;" + "http://alerevitality.com/" + "&nbsp;" + " now!"
                        + " <br /><br />" + "With Support and Respect," + "<br />" +

                        "The Vitality Team";


                    //string body = "Your Password is  " + txtNewPassword.Text +".";
                    objGeneric.SendMail(email, body, subject);
                    //Response.Write("<script> location.href='RegistrationThanks.aspx'</script>");
                    Response.Redirect("~/User/ChangeCircles.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("Wall.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        [WebMethod]
        public static string ProcessIT()
        {
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            int retval = 0;
            objRegisterUserBAO.AT_ID = Convert.ToInt32(MySession.Current.ATId);
            objRegisterUserBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            objRegisterUserBAO.AT_LOGOUTTIME = Convert.ToString(DateTime.Now);
            objRegisterUserBAO.procedureType = "U";
            retval = RegisterUserDAO.UpdatetblAuditTrail(objRegisterUserBAO);
            return "";

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
