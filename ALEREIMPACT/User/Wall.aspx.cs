using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using ALEREIMPACT.BAO.Facebook;
using System.Data;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Configuration;


namespace ALEREIMPACT.User
{
    public partial class Wall : System.Web.UI.Page
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        RegisterUserDAO ObjRegisterUserDAO = new RegisterUserDAO();
        PrivacySettingBAO objUserPrivacySettings = new PrivacySettingBAO();
        UserFoodLogBAO objUserFoodLogBAo = new UserFoodLogBAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Master.iframe.Attributes.Add("src", "Notes.aspx");

                this.Master.iframe.Attributes.Add("onload", "closeProgressIndicator(this)");

                if (!Page.IsPostBack)
                {
                    if (MySession.Current.SelectedCircleUserId == null)
                    {
                        if (Session["googleemail"] != null)
                        {
                            RegisterExternal_LoginUser(Convert.ToString(Session["googleemail"]), Convert.ToString(Session["googlefirstname"]), 3);
                            MySession.Current.CircleId = "1";

                        }
                        else if (Session["facebook_login"] != null)
                        {
                            MySession.Current.CircleId = "1";
                            RegisterFaceBookUser();
                            if (Convert.ToString(Session["MyPrfile"]) == "True")
                            {
                                this.Master.iframe.Attributes.Add("src", "MyProfile.aspx");
                                Session["MyPrfile"] = false;
                            }
                            else
                            {
                                this.Master.iframe.Attributes.Add("src", "Notes.aspx");
                            }
                        }
                        else if (Session["show_admin_posed_messages"] != null)
                        {
                            divAdminMessageNew.Visible = true;

                            //dvAdminPostedMessages.Visible = true;
                            // MssionsTab.Visible = false;
                        }
                        else if (Convert.ToString(Session["MyPrfile"]) == "True")
                        {
                            this.Master.iframe.Attributes.Add("src", "MyProfile.aspx");
                            Session["MyPrfile"] = false;
                        }

                        else
                        {
                            this.Master.iframe.Attributes.Add("src", "Notes.aspx");

                        }
                    }
                }
                if (Convert.ToString(Session["Notes"]) == "True")
                {
                    this.Master.iframe.Attributes.Add("src", "Notes.aspx");
                    Session["Notes"] = false;
                }
                Session["Member_Profile"] = null;
                Session["show_admin_posed_messages"] = null;
                //HtmlGenericControl divCtrl = (HtmlGenericControl)FindControl("dvpostcomments");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void RegisterExternal_LoginUser(string externalLoginEmail, string userName, int typeOfLogin)
        {
            try
            {

                ObjRegisterUserBAO.LoginEmail = externalLoginEmail;
                DataTable dtCheck = RegisterUserDAO.CheckExternalUserLoginId(ObjRegisterUserBAO);
                if (Convert.ToString(dtCheck.Rows[0][0]) == "0")
                {
                    ObjRegisterUserBAO.LoginPassword = "No Information";
                    ObjRegisterUserBAO.UserRoleId = "2";
                    ObjRegisterUserBAO.PasswordSalt = string.Empty;
                    ObjRegisterUserBAO.IsPasswordChanged = false;
                    ObjRegisterUserBAO.LoginStatus = 0;
                    ObjRegisterUserBAO.FirstName = userName;
                    MySession.Current.UserFirstName = userName;
                    ObjRegisterUserBAO.LastName = "";
                    ObjRegisterUserBAO.UserAddress = "No Information";
                    ObjRegisterUserBAO.YearOfBirth = 0;
                    ObjRegisterUserBAO.MonthOfBirth = 0;
                    ObjRegisterUserBAO.DateOfBirth = 0;
                    // ObjRegisterUserBAO.UserImage = "No Information";

                    ObjRegisterUserBAO.LocationId = 0;

                    ObjRegisterUserBAO.MobileNumber = "No Information";

                    ObjRegisterUserBAO.Zip = 0;
                    ObjRegisterUserBAO.HomeContact1 = "No Information";
                    ObjRegisterUserBAO.HomeContact2 = "No Information";
                    ObjRegisterUserBAO.OfficeContact = "No Information";

                    ObjRegisterUserBAO.Height = 0;

                    ObjRegisterUserBAO.Weight = 0;
                    ObjRegisterUserBAO.HeightInches = 0;
                    ObjRegisterUserBAO.Gender = "No Information";
                    ObjRegisterUserBAO.RegistrationTypeId = typeOfLogin;
                    ObjRegisterUserBAO.HasProfileAdded = true;
                    ObjRegisterUserBAO.RS_ID_FK = 9;
                    ObjRegisterUserBAO.EDU_ID_FK = 10;
                    ObjRegisterUserBAO.WP_ID_FK = 15;
                    ObjRegisterUserBAO.INTEREST_ID_FK = 10;
                    ObjRegisterUserBAO.RELIGION_ID_FK = 10;
                    DataTable dt = new DataTable();
                    dt = RegisterUserDAO.SubmitNewUser(ObjRegisterUserBAO);
                    MySession.Current.LoginId = dt.Rows[0]["LoginId"].ToString();
                    DataTable dtPrivacy = new DataTable();
                    objUserFoodLogBAo.ProcedureType = "PS";
                    dtPrivacy = UserFoodLogDAO.GetFoodCategories(objUserFoodLogBAo);
                    if (dtPrivacy.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtPrivacy.Rows.Count; i++)
                        {
                            int retval1 = 0;
                            objUserPrivacySettings.UPS_ID = 0;
                            objUserPrivacySettings.PS_ID_FK = Convert.ToInt32(dtPrivacy.Rows[i]["PS_ID"]);
                            objUserPrivacySettings.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                            if (i == 0)
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                            else if (i == 1)
                            {
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;

                            }
                            else if (i == 2)
                            {


                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                            else if (i == 3)
                            {

                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = true;

                            }
                            else if (i == 4)
                            {

                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = true;


                            }
                            else if (i == 5)
                            {

                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = true;


                            }
                            else if (i == 6)
                            {

                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;

                            }
                            objUserPrivacySettings.ProcedureType = "I";
                            retval1 = privacySettingDAO.InserttblUserPrivacySetting(objUserPrivacySettings);
                        }
                    }



                    MySession.Current.LoginId = dt.Rows[0]["LoginId"].ToString();
                    int retval = 0;
                    ObjRegisterUserBAO.AT_ID = 0;
                    ObjRegisterUserBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    ObjRegisterUserBAO.AT_LOGINTIME = Convert.ToString(DateTime.Now);
                    ObjRegisterUserBAO.AT_LOGOUTTIME = "";
                    ObjRegisterUserBAO.AT_DATE = Convert.ToString(DateTime.Now);
                    ObjRegisterUserBAO.AT_LOGIN_STATUS = "Successfull";
                    ObjRegisterUserBAO.AT_FAILUREREASON = "";
                    ObjRegisterUserBAO.AT_ONLINE = "True";
                    ObjRegisterUserBAO.procedureType = "I";
                    retval = RegisterUserDAO.InserttblAuditTrail(ObjRegisterUserBAO);
                    MySession.Current.ATId = Convert.ToString(retval);
                    RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
                    DataTable dt1 = new DataTable();

                    objRegisterUserBAO.LoginEmail = externalLoginEmail;
                    objRegisterUserBAO.procedureType = "C";
                    dt1 = RegisterUserDAO.GetEmailDetail(objRegisterUserBAO);
                    MySession.Current.SelectedCircleName = "Inner Circle";
                    if (Convert.ToString(Session["MyPrfile"]) == "True")
                    {
                        this.Master.iframe.Attributes.Add("src", "MyProfile.aspx");
                        Session["MyPrfile"] = false;
                    }
                    else
                    {
                        if (Convert.ToString(dt1.Rows[0]["is_change_circle"]) == "True")
                        {
                            Session["from_login"] = "True";
                            //Response.Redirect("~/User/CirclesNew.aspx", false);
                            this.Master.iframe.Attributes.Add("src", "Notes.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/User/ChangeCircles.aspx");
                        }
                    }
                }
                else
                {
                    MySession.Current.LoginId = dtCheck.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void RegisterFaceBookUser()
        {
            try
            {
                MySession.Current.SelectedCircleName = "Inner Circle";


                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FB_Api_Key"].ToString();
                FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FB_Api_Secret"].ToString();

                if (!IsPostBack)
                {
                    if (Request.QueryString["error"] == "access_denied")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                        return;
                    }

                    string code = Request.QueryString["code"];

                    if (!string.IsNullOrEmpty(code))
                    {
                        string data = FaceBookConnect.Fetch(code, "me");
                        //Response.Write(data);
                        FacebookUser faceBookUser = new JavaScriptSerializer().Deserialize<FacebookUser>(data);
                        //faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                        DataTable dtCheck = RegisterUserDAO.CheckExternalUserLoginId(ObjRegisterUserBAO);
                        if (Convert.ToString(dtCheck.Rows[0][0]) == "0")
                        {
                            RegisterExternal_LoginUser(faceBookUser.Email, faceBookUser.UserName, 2);

                            Session["facebook_login"] = faceBookUser.Email;

                            //pnlFaceBookUser.Visible = true;
                            //lblId.Text = faceBookUser.Id;
                            //lblUserName.Text = faceBookUser.UserName;
                            //lblName.Text = faceBookUser.Name;
                            //ViewState["name"] = faceBookUser.Name;
                            //ViewState["Username"] = faceBookUser.Email;
                            // Session["Code"] = code;
                            //lblEmail.Text = faceBookUser.Email;
                            //ProfileImage.ImageUrl = faceBookUser.PictureUrl;
                            int retval = 0;
                            ObjRegisterUserBAO.AT_ID = 0;
                            ObjRegisterUserBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                            ObjRegisterUserBAO.AT_LOGINTIME = Convert.ToString(DateTime.Now);
                            ObjRegisterUserBAO.AT_LOGOUTTIME = "";
                            ObjRegisterUserBAO.AT_DATE = Convert.ToString(DateTime.Now);
                            ObjRegisterUserBAO.AT_LOGIN_STATUS = "Successfull";
                            ObjRegisterUserBAO.AT_FAILUREREASON = "";
                            ObjRegisterUserBAO.AT_ONLINE = "True";
                            ObjRegisterUserBAO.procedureType = "I";
                            retval = RegisterUserDAO.InserttblAuditTrail(ObjRegisterUserBAO);


                            DataTable dtPrivacy = new DataTable();
                            objUserFoodLogBAo.ProcedureType = "PS";
                            dtPrivacy = UserFoodLogDAO.GetFoodCategories(objUserFoodLogBAo);
                            if (dtPrivacy.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtPrivacy.Rows.Count; i++)
                                {
                                    int retval1 = 0;
                                    objUserPrivacySettings.UPS_ID = 0;
                                    objUserPrivacySettings.PS_ID_FK = Convert.ToInt32(dtPrivacy.Rows[i]["PS_ID"]);
                                    objUserPrivacySettings.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                                    if (i == 0)
                                    {
                                        objUserPrivacySettings.UPS_ANYONE = true;
                                        objUserPrivacySettings.UPS_YOU = false;
                                        objUserPrivacySettings.UPS_FRIENDS = false;
                                    }
                                    else if (i == 1)
                                    {
                                        objUserPrivacySettings.UPS_ANYONE = false;
                                        objUserPrivacySettings.UPS_YOU = true;
                                        objUserPrivacySettings.UPS_FRIENDS = false;

                                    }
                                    else if (i == 2)
                                    {


                                        objUserPrivacySettings.UPS_ANYONE = false;
                                        objUserPrivacySettings.UPS_YOU = true;
                                        objUserPrivacySettings.UPS_FRIENDS = false;
                                    }
                                    else if (i == 3)
                                    {

                                        objUserPrivacySettings.UPS_ANYONE = false;
                                        objUserPrivacySettings.UPS_YOU = false;
                                        objUserPrivacySettings.UPS_FRIENDS = true;

                                    }
                                    else if (i == 4)
                                    {

                                        objUserPrivacySettings.UPS_ANYONE = false;
                                        objUserPrivacySettings.UPS_YOU = false;
                                        objUserPrivacySettings.UPS_FRIENDS = true;


                                    }
                                    else if (i == 5)
                                    {

                                        objUserPrivacySettings.UPS_ANYONE = false;
                                        objUserPrivacySettings.UPS_YOU = false;
                                        objUserPrivacySettings.UPS_FRIENDS = true;


                                    }
                                    else if (i == 6)
                                    {

                                        objUserPrivacySettings.UPS_YOU = true;
                                        objUserPrivacySettings.UPS_FRIENDS = false;
                                        objUserPrivacySettings.UPS_ANYONE = false;

                                    }
                                    objUserPrivacySettings.ProcedureType = "I";
                                    retval1 = privacySettingDAO.InserttblUserPrivacySetting(objUserPrivacySettings);
                                }

                            }
                        }
                        else
                        {
                            MySession.Current.LoginId = dtCheck.Rows[0][0].ToString();
                        }
                    }
                }

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

    }
}
