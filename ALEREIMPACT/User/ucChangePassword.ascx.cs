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
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO.User;
namespace ALEREIMPACT.User
{
    public partial class ucChangePassword : System.Web.UI.UserControl
    {
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        ClsGeneric objGeneric = new ClsGeneric();
        protected  static string _pwd_Message;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {
                    if (string.IsNullOrEmpty(MySession.Current.LoginId))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void BtnChangePwd_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objRegisterUserBAO.user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objRegisterUserBAO.LoginPassword = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtPassword.Text);
                objRegisterUserBAO.procedureType = "S";
                dt = RegisterUserDAO.ChangePassword(objRegisterUserBAO);

                

                if (dt.Rows.Count == 0)
                {
                    _pwd_Message = "Failed";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>showMessage();</script>", false);
                }
                else
                {
                    string name = Convert.ToString(MySession.Current.UserFirstName);
                    _pwd_Message = "Success";
                    int retval = 0;
                    objRegisterUserBAO.user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objRegisterUserBAO.LoginPassword = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtNewPassword.Text);
                    objRegisterUserBAO.PasswordSalt = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtNewPassword.Text);
                    objRegisterUserBAO.IsPasswordChanged = true;
                    objRegisterUserBAO.procedureType = "U";
                    retval = RegisterUserDAO.UpdatePassword(objRegisterUserBAO);
                    string email = dt.Rows[0]["login_email"].ToString();
                    string subject = " Vitality : Change Password Detail";
                    string body = "Hi " + "&nbsp;" + name + "," + "<br /><br />" + "Thanks for joining Vitality.We’re excited to have you try out our Beta version." +
                        "<br /><br />" + "Your new password  :" + "&nbsp;" + txtNewPassword.Text + "<br /><br />" + "Improving your health and the health of your community of loved ones is very" + " <br />" +
                        "important to us. We’ve tried to develop an easy-to-use and smart tool, but that’s" + " <br />" +
                        "really for you to judge. Your input is critical to how we continue to build and adjust" + " <br />" +
                        "Vitality. Please never hesitate to be open and honest, and in return we will" + " <br />" +
                        "make sure to incorporate feedback and fixes as quickly as possible." + " <br /><br/>" +
                        "We’re excited to be a part of your journey for better health! " + 
                       
                        " <br /><br />" + "With Support and Respect," + "<br />" +

                        "The Vitality Team";

                    objGeneric.SendMail(email, body, subject);
                    Response.Redirect("FeedBackAndProblem.aspx?val=" + 3, false);
                    //Response.Write("<script> location.href='RegistrationThanks.aspx'</script>");
                  //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>showMessage();</script>", false);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "<script type='text/javascript'>showMessage();</script>", true);

                    //txtPassword.Text = "";
                    //txtNewPassword.Text = "";
                    //txtConfirmPwd.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
           // _pwd_Message = "";

        }
    }
}