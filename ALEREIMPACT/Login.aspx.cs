using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ASPSnippets.FaceBookAPI;
using System.Web.UI.WebControls;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Provider;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO;
using ALEREIMPACT.BAO;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.BAO.Facebook;
using System.Web.Script.Serialization;
using ALEREIMPACT.BAL.User;
using System.Configuration;

namespace ALEREIMPACT
{
    public partial class Login : System.Web.UI.Page
    {
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        OpenIdRelyingParty OIDRP;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(Session["register_success"])))
                {
                    lblRegisterNewUserMsg.Text = Convert.ToString(Session["register_success"]);
                }
                this.btnLogin.Focus();
                txtPassword.Attributes.Add("onkeypress", "return clickEnterButton(event,'" + btnLogin.ClientID + "')");
                Session["register_success"] = null;
                Session["googleemail"] = null;
                Session["facebook_login"] = null;
                Session["Email"] = null;
                LoginWithFacebook();
                LoginWithGoogle();
            }
        }
        /// <summary>
        /// Purpose: loads Facebook login api key.
        /// Created on: 25-03-2013
        /// </summary>
        private void LoginWithFacebook()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FB_Api_Key"].ToString();
            FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FB_Api_Secret"].ToString(); 
        
        }

        #region Code for login with google
        /// <summary>
        /// Purpose: calls google API to check and provide login user details.
        /// Created on: 25-03-2013
        /// </summary>
        private void LoginWithGoogle()
        {
            OIDRP = new OpenIdRelyingParty();

            DataTable dt = new DataTable();

            UserOperationDAO objUserOperationDAO = new UserOperationDAO();
            UserOperationsBAO objUserOperationsBAO = new UserOperationsBAO();
            try
            {
                var str = OIDRP.GetResponse();
                if (str != null)
                {
                    switch (str.Status)
                    {
                        case AuthenticationStatus.Authenticated:
                            Session["GoogleIdentifier"] = str.ClaimedIdentifier.ToString();
                            var fetch = str.GetExtension<FetchResponse>();
                            if (fetch != null)
                            {
                                Session["googlefirstname"] = fetch.GetAttributeValue(WellKnownAttributes.Name.First);
                                Session["googleemail"] = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);

                            }
                            Response.Redirect("~/User/Wall.aspx"); //redirect to main page of your website  
                            break;
                        case AuthenticationStatus.Canceled:
                            Response.Write("Cancelled");
                            break;
                        case AuthenticationStatus.Failed:
                            Response.Write("Login Failed");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                OIDRP = null;
            }
        }
        #endregion
        /// <summary>
        /// Purpose: loads LoginWithGoogle() function with requesting few mandatory required fields.
        /// Created on: 25-03-2013
        /// </summary>
        protected void imgGoogleLogin_Click(object sender, CommandEventArgs e)
        {
            OIDRP = new OpenIdRelyingParty();
            try
            {
                string str = e.CommandArgument.ToString();
                var b = new UriBuilder(Request.Url) { Query = "" };
                var req = OIDRP.CreateRequest(str, b.Uri, b.Uri);
                var fetch = new FetchRequest();
                fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetch.Attributes.AddRequired(WellKnownAttributes.Name.First);
                req.AddExtension(fetch);
                req.RedirectToProvider();
                LoginWithGoogle();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                OIDRP = null;
            }
        }
        /// <summary>
        /// Purpose: redirects user using facebook login to the wall page.
        /// Created on: 25-03-2013
        /// </summary>
        protected void imgFacebookLogin_Click(object sender, ImageClickEventArgs e)
        {
            Session["facebook_login"] = "True";
            string url = HttpContext.Current.Request.Url.ToString();

            if (url.Contains("dev.alerevitality.com"))
            {
                FaceBookConnect.Authorize("user_photos,email", System.Configuration.ConfigurationManager.AppSettings["facebook_login_path_dev"].ToString());
            }
            else if (url.Contains("uat.alerevitality.com"))
            {
                FaceBookConnect.Authorize("user_photos,email", System.Configuration.ConfigurationManager.AppSettings["facebook_login_path_uat"].ToString());
            }
            else if (url.Contains("alerevitality.com"))
            {
                FaceBookConnect.Authorize("user_photos,email", System.Configuration.ConfigurationManager.AppSettings["facebook_login_path_live"].ToString());
            }
            else if (url.Contains("localhost:"))
            {
                FaceBookConnect.Authorize("user_photos,email", System.Configuration.ConfigurationManager.AppSettings["facebook_login_path"].ToString());
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            UserOperationDAO objUserOperationDAO = new UserOperationDAO();
            UserOperationsBAO objUserOperationsBAO = new UserOperationsBAO();

            objUserOperationsBAO.LoginWithEmail = txtUserName.Text.Trim();
            objUserOperationsBAO.LoginWithPassword = ClsGeneric.md5(txtPassword.Text.Trim());

            DataSet dsLogin = UserOperationDAO.Login(objUserOperationsBAO);

            HttpCookie myCookie = new HttpCookie("myCookie");
            if (chkRememberMe.Checked == true)
            {

                if (Convert.ToString(dsLogin.Tables[0].Rows[0]["LoginStatus"]) != "2")
                {
                    myCookie.Values.Add("userid", dsLogin.Tables[1].Rows[0]["LoginId"].ToString());
                    myCookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(myCookie);
                }
                else
                {
                    Response.Cookies["myCookie"].Value = null;
                    myCookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(myCookie);
                }
            }
            else
            {
                Response.Cookies["myCookie"].Value = null;
                myCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(myCookie);
            }
            if (dsLogin != null || !String.IsNullOrEmpty(Convert.ToString(Request.Cookies["myCookie"].Value)))
            {
                MySession.Current.CircleId = "1";

                if (Convert.ToString(dsLogin.Tables[0].Rows[0]["LoginStatus"]) == "1" || !String.IsNullOrEmpty(Convert.ToString(Request.Cookies["myCookie"].Value)))
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(Request.Cookies["myCookie"].Value)))
                    {
                        HttpCookie getmyCookie = Request.Cookies["myCookie"];
                        objRegisterUserBAO.fk_user_registration_id = getmyCookie.Values["userid"].ToString();
                        objRegisterUserBAO.procedureType = "C";
                        dt = RegisterUserDAO.GetEmailDetail_ForRememberMe(objRegisterUserBAO);
                        MySession.Current.LoginId = dt.Rows[0]["pk_user_registration_Id"].ToString();
                        Session["Email"] = dt.Rows[0]["login_email"].ToString();
                    }
                    else
                    {
                        MySession.Current.LoginId = dsLogin.Tables[1].Rows[0]["LoginId"].ToString();
                        Session["Email"] = txtUserName.Text;

                        // To check, user change inner circle image or not
                        objRegisterUserBAO.LoginEmail = txtUserName.Text;
                        objRegisterUserBAO.procedureType = "C";
                        dt = RegisterUserDAO.GetEmailDetail(objRegisterUserBAO);
                    }
                    MySession.Current.UserFirstName = Convert.ToString(dt.Rows[0]["FirstName"]);

                    int retval = 0;
                    objRegisterUserBAO.AT_ID = 0;
                    objRegisterUserBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objRegisterUserBAO.AT_LOGINTIME = Convert.ToString(DateTime.Now);
                    objRegisterUserBAO.AT_LOGOUTTIME = "";
                    objRegisterUserBAO.AT_DATE = Convert.ToString(DateTime.Now);
                    objRegisterUserBAO.AT_LOGIN_STATUS = "Successfull";
                    objRegisterUserBAO.AT_FAILUREREASON = "";
                    objRegisterUserBAO.AT_ONLINE = "True";
                    objRegisterUserBAO.procedureType = "I";
                    retval = RegisterUserDAO.InserttblAuditTrail(objRegisterUserBAO);
                    MySession.Current.ATId = Convert.ToString(retval);
                    if (Convert.ToString(dt.Rows[0]["is_change_circle"]) == "True")
                    {
                        Session["from_login"] = "True";
                        Response.Redirect("~/User/Wall.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("~/User/ChangeCircles.aspx", false);
                    }

                }
                else if (Convert.ToString(dsLogin.Tables[0].Rows[0]["LoginStatus"]) == "2")
                {
                    lblWrongCredentials.Text = "Invalid Credentials / Locked Account";

                }
                else if (Convert.ToString(dsLogin.Tables[0].Rows[0]["LoginStatus"]).ToString() == "3")
                {
                    objRegisterUserBAO.LoginEmail = txtUserName.Text;
                    objRegisterUserBAO.procedureType = "C";
                    dt = RegisterUserDAO.GetEmailDetail(objRegisterUserBAO);
                    if (dt.Rows.Count > 0)
                    {
                        MySession.Current.UserFirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    }
                    Session["Email"] = txtUserName.Text;
                    MySession.Current.LoginId = dsLogin.Tables[1].Rows[0]["LoginId"].ToString();
                    int retval = 0;
                    objRegisterUserBAO.AT_ID = 0;
                    objRegisterUserBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objRegisterUserBAO.AT_LOGINTIME = Convert.ToString(DateTime.Now);
                    objRegisterUserBAO.AT_LOGOUTTIME = "";
                    objRegisterUserBAO.AT_DATE = Convert.ToString(DateTime.Now);
                    objRegisterUserBAO.AT_LOGIN_STATUS = "Successfull";
                    objRegisterUserBAO.AT_FAILUREREASON = "";
                    objRegisterUserBAO.procedureType = "I";
                    retval = RegisterUserDAO.InserttblAuditTrail(objRegisterUserBAO);
                    MySession.Current.ATId = Convert.ToString(retval);
                    string val = "1";
                    Response.Redirect("ChangePassword.aspx?val=" + val, false);
                }

            }
        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx", false);

        }

        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/Register.aspx", false);
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
