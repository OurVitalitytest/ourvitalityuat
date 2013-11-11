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
using System.Configuration;
using System.IO;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.Admin;

namespace ALEREIMPACT.User
{
    public partial class Notes : System.Web.UI.Page
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        RegisterUserDAO ObjRegisterUserDAO = new RegisterUserDAO();
        PrivacySettingBAO objUserPrivacySettings = new PrivacySettingBAO();
        UserFoodLogBAO objUserFoodLogBAo = new UserFoodLogBAO();
        public static string email = "";
        public static string body = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                }
                else
                {
                    MySession.Current.MemberUserId = null;
                    MySession.Current.PublicCircleUserId = null;
                    MySession.Current.PublicCircleId = null;
                    MySession.Current.MemberCircleId = null;
                    MySession.Current.searchfriendId = null;
                    if (!Page.IsPostBack)
                    {
                        if (Session["googleemail"] != null)
                        {
                            RegisterExternal_LoginUser(Convert.ToString(Session["googleemail"]), 3);
                            //MssionsTab.Visible = true;

                        }
                        else if (Session["facebook_login"] != null)
                        {
                            RegisterFaceBookUser();
                            //  MssionsTab.Visible = true;
                        }
                        else if (Convert.ToString(Request.QueryString["msgs"]) == "true")
                        {
                            divAdminMessageNew.Visible = true;
                            // divInviteMEmbers.Visible = false;
                            //dvAdminPostedMessages.Visible = true;
                            // MssionsTab.Visible = false;
                        }
                        //else if (Convert.ToString(Request.QueryString["Invite"]) == "true")
                        //{
                        //    divAdminMessageNew.Visible = false;
                        //    divInviteMEmbers.Visible = true;
                        //}
                    }


                    var cachedHeader = (MasterPage)Page.LoadControl(@"LoginUserMaster.Master");

                    Image dvFooter = (Image)cachedHeader.FindControl("imgFooterSpacer");
                    //if (Session["dvfooter"] == "true")
                    //    dvFooter.Height = new Unit(1000);

                    //Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void RegisterExternal_LoginUser(string externalLoginEmail, int typeOfLogin)
        {
            MySession.Current.SelectedCircleName = "Inner Circle";
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
                    ObjRegisterUserBAO.FirstName = "No Information";
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
                            RegisterExternal_LoginUser(faceBookUser.Email, 2);
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
                            MySession.Current.ATId = Convert.ToString(retval);

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
        [WebMethod]
        public static string SendMail(string email, string msg)
        {
            string subject;
            ClsGeneric objClsGeneric = new ClsGeneric();
            try
            {

                if (email != "")
                {
                    AdminBAO objAdminBAO = new AdminBAO();
                    DataTable dt = new DataTable();
                    objAdminBAO.name = email;
                    objAdminBAO.name1 = "";
                    objAdminBAO.ProcedureType = "V";
                    dt = AdminDAO.GetUserDetailSearch(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    if (txtEmail.Text == dt.Rows[i]["login_email"].ToString())
                        //    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('User already exists');", true);
                        email = "";
                        msg = "";
                        Label lblheading = new Label();
                        lblheading.Text = "User already Exists";
                        // return;
                        //    }
                        //}
                    }
                    else
                    {

                        // get();
                        //email = txtEmail.Text;
                        string name = Convert.ToString(MySession.Current.UserFirstName);
                        int retval = 0;
                        objAdminBAO.UI_ID = 0;
                        objAdminBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objAdminBAO.UI_USER_MAIL_ID = email;
                        objAdminBAO.UI_DATE = DateTime.Now.ToString();
                        objAdminBAO.UI_STATUS = "False";
                        objAdminBAO.UI_CODE = 1;
                        objAdminBAO.UI_MAIL_STATUS = "Successfull";
                        objAdminBAO.ProcedureType = "I";
                        retval = AdminDAO.InserttblUserInvitation(objAdminBAO);
                        subject = " Vitality : Invitation";
                        body = "Hi, " + "<br /><br />" + name + " would like to invite you to participate in their health journey and " +
                               "<br />" + "help test out a new site and app called Vitality." + "<br /><br />" +
                               "Vitality lets you connect with other people looking to get healthier and" + "<br />" +
                               "support each other as we all accomplish our health goals." + "<br /><br />" +
                              "http://alerevitality.com/Register.aspx?val=" + retval + "&nbsp;" + " to finish signing up." + name + "&nbsp;" + " is waiting for you!"
                              + "<br /><br />" + "Can’t wait to meet you," + "<br />" + "The Vitality Team";
                        //       if (msg == "")
                        //       {


                        //           body = PopulateBody("Alere Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + retval,
                        //"Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                        //" Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, "
                        //+ "when an unknown printer took a galley of type and scrambled it to make a type specimen book.");
                        //       }
                        //       else
                        //       {
                        //           body = PopulateBody("Alere Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + retval, msg);
                        //       }
                        objClsGeneric.SendMail(email, body, subject);
                        //txtEmail.Text = "";
                        //txtmessage.Text = "";

                        //lbMsgSend.Visible = true;
                        //lbMsgSend.Text = "Invitation has been sent.";
                        //DivEmail.Style.Add("display", "block");

                    }


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return body;
        }

        public static string PopulateBody(string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("ALEREIMPACT/InvitationEmail.htm"))
            {
                body = reader.ReadToEnd();
            }
            //body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }
        [WebMethod]
        public static void SubmitPersonalizationSelection(string selectionId)
        {
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            DataSet ds = new DataSet();
            objRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
            objRegisterUserBAO.UI_STATUS = selectionId;
            objRegisterUserBAO.procedureType = "2";

            ds = RegisterUserDAO.GetPersonalizationStatus(objRegisterUserBAO);
        }
        [WebMethod]
        public static void CloseForLoginUser()
        {
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            DataSet ds = new DataSet();
            objRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
            objRegisterUserBAO.UI_STATUS = 0;
            objRegisterUserBAO.procedureType = "3";

            ds = RegisterUserDAO.GetPersonalizationStatus(objRegisterUserBAO);
        }
    }
}
