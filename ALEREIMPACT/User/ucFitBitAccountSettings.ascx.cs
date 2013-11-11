using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.DAL.User;
using OAuth.Net.Common;
using OAuth.Net.Consumer;
using OAuth.Net.Components;
using System.Xml;
using System.Reflection;

namespace ALEREIMPACT.User
{
    public partial class ucFitBitAccountSettings : System.Web.UI.UserControl
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        protected XmlDocument stepsDoc { get; private set; }
        protected XmlDocument caloriesDoc { get; private set; }
        OAuthService service = null;
        OAuthRequest request = null;
        OAuthResponse response = null;
        string NewID = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Convert.ToString(Request.QueryString["Msg"]) != "Disconnected" && Convert.ToString(Request.QueryString["Msg"]) != "Connect")
                Fetch_CaloriesBurnFrom_FitBitApi(Convert.ToInt32(MySession.Current.LoginId));

            if (Convert.ToString(Request.QueryString["Msg"]) == "Connect")
            {
                System.Web.SessionState.SessionIDManager Manager = new System.Web.SessionState.SessionIDManager();
                if (String.IsNullOrEmpty(Convert.ToString(Session["keep_session"])))
                {
                    NewID = Manager.CreateSessionID(Context);
                    lnkSinkDataFromFitBit.Text = "Connect Account";
                }
                else
                {
                    NewID = Session["keep_session"].ToString();
                    lnkSinkDataFromFitBit.Text = "Disconnect Account";
                    dvMessage.Visible = true;
                    dvDevices.Visible = false;
                }

                Fetch_CaloriesBurnFrom_FitBitApi(Convert.ToInt32(MySession.Current.LoginId));


                Session["keep_session"] = NewID;
                //PropertyInfo isreadonly =
                //                          typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                //                          "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

                //isreadonly.SetValue(this.Request.QueryString, false, null);
                //string newUrl = Request.Url.AbsoluteUri.Replace(Request.Url.Query, "?Msg=Disconnected");
                //Response.Redirect(newUrl);
            }
            if (Convert.ToString(Request.QueryString["Msg"]) == "Disconnected")
            {
                System.Web.SessionState.SessionIDManager Manager = new System.Web.SessionState.SessionIDManager();
                NewID = Manager.CreateSessionID(Context);
                Fetch_CaloriesBurnFrom_FitBitApi(Convert.ToInt32(MySession.Current.LoginId));

                //PropertyInfo isreadonly =
                //                          typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                //                          "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

                //isreadonly.SetValue(this.Request.QueryString, false, null);
                string newUrl = Request.Url.AbsoluteUri.Replace(Request.Url.Query, "?Msg=Connect");
                Response.Redirect(newUrl);
            }
        }
        protected void lnkSinkDataFromFitBit_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            RegisterUserBAO objRegisterUserBAO = null;
            DataTable dtgetFitBitDetails = null;
            try
            {
                if (lnkSinkDataFromFitBit.Text == "Disconnect Account")
                {
                    objRegisterUserBAO = new RegisterUserBAO();
                    objRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    dtgetFitBitDetails = RegisterUserDAO.DeleteFitBitKeys(objRegisterUserBAO);
                    objRegisterUserBAO = null;
                    Session["keep_session"] = null;
                    Response.Redirect("~/User/FitBitAccountSettings.aspx?Msg=Disconnected", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        /// <summary>
        /// Calling FitBit Api.
        /// </summary>
        /// <param name="CaloriesConsumed"></param>
        /// <param name="CaloriesBurnt"></param>
        /// <param name="pk_user_log_id"></param>
        /// <param name="request_type"></param>

        private void Fetch_CaloriesBurnFrom_FitBitApi(int login_user_id)
        {
            const string ConsumerKey = "68308bc1af7d419c8f5489f25e7555ad";
            const string ConsumerSecret = "78ffc3a4a18249ff94c3d84a34cbb217";
            const string RequestTokenUrl = "http://www.fitbit.com/oauth/request_token";

            string AuthorizationUrl = "http://www.fitbit.com/oauth/authorize";
            const string AccessTokenUrl = "http://api.fitbit.com/oauth/access_token";

            DateTime dt_todaydate = Convert.ToDateTime(System.DateTime.Now.ToString());
            string myDate = dt_todaydate.ToString("yyyy-MM-dd"); // As String;

            string ApiCallUrl = "http://api.fitbit.com/1/user/-/activities/date/" + myDate.ToString() + ".xml";

            DataTable dtgetFitBitDetails = new DataTable();
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            objRegisterUserBAO.fk_user_registration_id = login_user_id;
            objRegisterUserBAO.AccessToken = "0";
            objRegisterUserBAO.AccessTokenSecret = "0";
            objRegisterUserBAO.procedureType = "1";

            dtgetFitBitDetails = RegisterUserDAO.AddFitBitKeys(objRegisterUserBAO);

            service = OAuthService.Create(
                             new EndPoint(RequestTokenUrl, "POST"),         // requestTokenEndPoint
                             new Uri(AuthorizationUrl),                     // authorizationUri
                             new EndPoint(AccessTokenUrl, "POST"),          // accessTokenEndPoint
                             true,                                          // useAuthorizationHeader
                             "http://api.fitbit.com",                       // realm
                             "HMAC-SHA1",                                   // signatureMethod
                             "1.0",                                         // oauthVersion
                             new OAuthConsumer(ConsumerKey, ConsumerSecret) // consumer
                             );


            request = OAuthRequest.Create(
                                  new OAuth.Net.Consumer.EndPoint(ApiCallUrl, "GET"),
                                  service,
                                  this.Context.Request.Url,
                                  NewID);


            request.VerificationHandler = AspNetOAuthRequest.HandleVerification;
            response = request.GetResource();

            if (dtgetFitBitDetails != null)
            {
                if (dtgetFitBitDetails.Rows.Count > 0)
                {
                    lnkSinkDataFromFitBit.Text = "Disconnect Account";
                    lnkSinkDataFromFitBit.Attributes.Add("onclick", "javascript:return confirmAction();");

                    lnkSinkDataFromFitBit2.Text = "Disconnect Account";
                    lnkSinkDataFromFitBit2.Attributes.Add("onclick", "javascript:return confirmAction();");
                }
                else
                {
                    lnkSinkDataFromFitBit.Text = "Connect Accounts";
                    lnkSinkDataFromFitBit.Attributes.Add("OnClientClick", "javascript:return HideProgresBarForSettings();");

                    lnkSinkDataFromFitBit2.Text = "Connect Accounts";
                    lnkSinkDataFromFitBit2.Attributes.Add("OnClientClick", "javascript:return HideProgresBarForSettings();");
                }
            }
            try
            {
                if (dtgetFitBitDetails.Rows.Count == 0)
                {
                    if (!response.HasProtectedResource)
                    {
                        string authorizationUrl = service.BuildAuthorizationUrl(response.Token).AbsoluteUri;
                        lnkSinkDataFromFitBit.Attributes.Add("onclick", "javascript:return PostToNewWindow('" + authorizationUrl + "');");
                        lnkSinkDataFromFitBit.Attributes.Add("OnClientClick", "javascript:return HideProgresBarForSettings();");

                        lnkSinkDataFromFitBit2.Attributes.Add("onclick", "javascript:return PostToNewWindow('" + authorizationUrl + "');");
                        lnkSinkDataFromFitBit2.Attributes.Add("OnClientClick", "javascript:return HideProgresBarForSettings();");

                    }
                    else
                    {
                        if (lnkSinkDataFromFitBit.Text != "Disconnect Account")
                        {
                            DataTable dtInsertFitBitDetails = new DataTable();
                            RegisterUserBAO objInsertRegisterUserBAO = new RegisterUserBAO();

                            objInsertRegisterUserBAO.fk_user_registration_id = login_user_id;
                            objInsertRegisterUserBAO.AccessToken = response.Token.Token;
                            objInsertRegisterUserBAO.AccessTokenSecret = response.Token.Secret;
                            objInsertRegisterUserBAO.procedureType = "1";

                            dtInsertFitBitDetails = RegisterUserDAO.AddFitBitKeys(objInsertRegisterUserBAO);

                            string close = @"<script type='text/javascript'>
                                                window.opener.location.reload(true);
                                                window.returnValue = true;
                                                window.close();
                                              </script>";
                            base.Response.Write(close);
                        }
                    }
                }

            }
            catch (System.Net.WebException ex)
            {
                Response.Write(ex.Message);
                Response.Close();
            }
            catch (OAuthRequestException ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
        }

        protected void lnkRedirectToActivityLog_Click(object sender, EventArgs e)
        {
            Session["FoodLog"] = "True";
            Response.Redirect("~/User/Log.aspx", false);
        }
    }
}
