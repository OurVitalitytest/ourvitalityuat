using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using System.Data;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.alereimpactservice;
using ALEREIMPACT.Service;
using System.Web.Services;
using ALEREIMPACT.BAL.User;
using ASPSnippets.FaceBookAPI;
using ALEREIMPACT.BAO.Facebook;
using System.Web.Script.Serialization;
using System.Configuration;
using System.IO;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO;
using ALEREIMPACT.BAO;


namespace ALEREIMPACT.User
{
    public partial class ChangeCircles_old : System.Web.UI.Page
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();

        AdminBAO objAdminBAO = new AdminBAO();
        ClsGeneric objClsGeneric = new ClsGeneric();
        public static string email = "";
        public static string body = "";
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        RegisterUserDAO ObjRegisterUserDAO = new RegisterUserDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                }
                if (!IsPostBack)
                {
                    LoginUserDetails();
                    GetCircleImage();
                    getProfileImage();
                    ////// to populate login id session from the database w.r.t the facebook email /////
                    if (Convert.ToString(Session["facebook_login"]) == "True")
                    {
                        RegisterFaceBookUser();
                    }
                }
                txtcirclecolor.Attributes.Add("readonly", "readonly");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void getProfileImage()         
        {
            try
            {
                DataTable dt = new DataTable();
                ObjRegisterUserBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                ObjRegisterUserBAO.procedureType = "GI";
                dt = RegisterUserDAO.GetInvitationDetail(ObjRegisterUserBAO);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["user_image"].ToString() == "" || dt.Rows[0]["user_image"].ToString() == null)
                    {
                        imgprofile.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";

                    }
                    else
                    {
                        imgprofile.ImageUrl = "~/User/profile_image/" + dt.Rows[0]["user_image"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        [WebMethod]
        public void hi()
        {
        }
        protected void GetCircleImage()
        {
            try
            {
                DataTable dtcircles = new DataTable();
                objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.fk_circle_id = 1;
                objusercircles.proceduretype = "CN";
                dtcircles = UserCirclesDAO.GetUserCircles(objusercircles);
                if (dtcircles.Rows.Count > 0)
                {
                    if (dtcircles.Rows[0]["circleimage"].ToString() == "" || dtcircles.Rows[0]["circleimage"].ToString() == null)
                    {
                        imgInnercircle.ImageUrl = "~/User/CircleImages/DefaultInnerCircle.jpg";
                    }
                    else
                    {
                        imgInnercircle.ImageUrl = "~/User/CircleImages/" + dtcircles.Rows[0]["circleimage"].ToString();
                    }
                    dvcircleimg.Style.Add("border-color", "#" + dtcircles.Rows[0]["circlecolor"].ToString());
                    Session["circlecolor"] = dtcircles.Rows[0]["circlecolor"].ToString();
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
                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FB_Api_Key"].ToString();
                FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FB_Api_Secret"].ToString();


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

                    string fbEmail = string.Empty;
                    string fbUserName = string.Empty;
                    fbEmail = faceBookUser.Email;
                    fbUserName = faceBookUser.UserName;

                    if (fbEmail == null)
                    {
                        fbEmail = faceBookUser.UserName;
                    }
                    if (fbUserName == null)
                    {
                        fbUserName = fbEmail;
                    }

                    RegisterExternal_LoginUser(fbEmail, fbUserName, 2);


                    RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
                    DataTable dt = new DataTable();

                    objRegisterUserBAO.LoginEmail = fbEmail;
                    objRegisterUserBAO.procedureType = "C";
                    dt = RegisterUserDAO.GetEmailDetail(objRegisterUserBAO);

                    MySession.Current.LoginId = dt.Rows[0]["pk_user_registration_Id"].ToString();
                    MySession.Current.UserFirstName = Convert.ToString(dt.Rows[0]["FirstName"]);

                    Session["facebook_login"] = fbEmail;
                    Session["AccessToken"] = Request.QueryString["code"];

                    if (Convert.ToString(dt.Rows[0]["is_change_circle"]) == "True")
                    {
                        //Response.Redirect("~/User/CirclesNew.aspx", false);
                        Response.Redirect("~/User/Wall.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/User/ChangeCircles.aspx");
                    }
                }
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

                ObjRegisterUserBAO.LoginPassword = "No Information";
                ObjRegisterUserBAO.UserRoleId = "2";
                ObjRegisterUserBAO.PasswordSalt = string.Empty;
                ObjRegisterUserBAO.IsPasswordChanged = false;
                ObjRegisterUserBAO.LoginStatus = 0;
                ObjRegisterUserBAO.FirstName = userName;
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
                ObjRegisterUserBAO.Gender = "0";
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
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void lkmovetocircle_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                MySession.Current.MemberUserId = "";
                MySession.Current.MemberCircleId = "";
                string cid = MySession.Current.LoginId + "-" + 1;
                MySession.Current.SelectedCircleUserId = MySession.Current.LoginId;
                (Session["selectedcircleid"]) = cid;
                MySession.Current.CircleId = "1";
                Session["from_login"] = "True";
                Response.Redirect("Wall.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnupdatecircle_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            // PnlCircle.Visible = true;
            string circleimagefile = "";
            string profileimagefile = "";
            try
            {
                if (fucircleimage.HasFile)
                {
                    if (objClsGeneric.checkRealFile(((FileUpload)fucircleimage)) == true)
                    {
                        Int32 filesize = fucircleimage.PostedFile.ContentLength;
                        if (filesize < 1048576)
                        {
                            string extension = System.IO.Path.GetExtension(fucircleimage.PostedFile.FileName);
                            circleimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "InnerCircle" + extension;
                            profileimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "ProfilePhoto" + extension;
                            fucircleimage.PostedFile.SaveAs(MapPath("~") + "/User/CircleImages/" + circleimagefile);
                            fucircleimage.PostedFile.SaveAs(MapPath("~") + "/User/profile_image/" + profileimagefile);

                            if (txtcirclecolor.Text == "")
                            {
                                objusercircles.circle_color = Convert.ToString(Session["circlecolor"]);
                            }
                            else
                            {
                                objusercircles.circle_color = txtcirclecolor.Text;
                            }
                            objusercircles.circle_name = profileimagefile;
                            objusercircles.circle_image = circleimagefile;
                            objusercircles.fk_circle_permission_id = 1;
                            objusercircles.fk_circle_id = 1;
                            objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                            objusercircles.proceduretype = "U";
                            Int32 newcircleId = 0;
                            newcircleId = UserCirclesDAO.AddNewCircle(objusercircles);


                            string extension1 = System.IO.Path.GetExtension(fucircleimage.PostedFile.FileName);
                            circleimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "InnerCircle" + extension1;
                            profileimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "ProfilePhoto" + extension1;
                            fucircleimage.PostedFile.SaveAs(MapPath("~") + "/User/CircleImages/" + circleimagefile);
                            fucircleimage.PostedFile.SaveAs(MapPath("~") + "/User/profile_image/" + profileimagefile);

                            if (txtcirclecolor.Text == "")
                            {
                                objusercircles.circle_color = Convert.ToString(Session["circlecolor"]);
                            }
                            else
                            {
                                objusercircles.circle_color = txtcirclecolor.Text;
                            }
                            objusercircles.circle_name = profileimagefile;
                            objusercircles.circle_image = circleimagefile;
                            objusercircles.fk_circle_permission_id = 1;
                            objusercircles.fk_circle_id = 1;
                            objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                            objusercircles.proceduretype = "U1";
                            Int32 newcircleId1 = 0;
                            newcircleId1 = UserCirclesDAO.AddNewCircle(objusercircles);
                            GetCircleImage();
                            getProfileImage();
                        }
                        else
                        {
                            lbuploadimger.Text = "Image Size should be less than 100Kb";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Upload image in (jpg or jpeg or png or gif ) format');", true); 
                    }

                }


            }
            catch (Exception ex)
            { }

        }

        private void LoginUserDetails()
        {
            if (Session["googleemail"] != null)
                lblWelcomeUser.Text = Session["googleemail"].ToString();
            else if (Session["facebook_login"] != null)
                lblWelcomeUser.Text = Session["facebook_login"].ToString();
            else if (Session["Email"] != null)
            {
                lblWelcomeUser.Text = Session["Email"].ToString();
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

        protected void btnInvite_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            string subject;
            try
            {
                if (txtEmail.Text != "")
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.name = txtEmail.Text;
                    objAdminBAO.name1 = "";
                    objAdminBAO.ProcedureType = "V";
                    dt = AdminDAO.GetUserDetailSearch(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    if (txtEmail.Text == dt.Rows[i]["login_email"].ToString())
                        //    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('User already exists');", true);
                        txtEmail.Text = "";
                        txtmessage.Text = "";
                        return;
                        //    }
                        //}
                    }
                    else
                    {
                        // get();
                        email = txtEmail.Text;
                        string name = Convert.ToString(MySession.Current.UserFirstName);
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
                        subject = "Vitality Invitation";
                        //if (txtmessage.Text == "")
                        //{
                        body = "Hi, " + "<br /><br />" + name + " would like to invite you to participate in their health journey and " +
                                "<br />" + "help test out a new site and app called Vitality." + "<br /><br />" +
                                " Vitality lets you connect with other people looking to get healthier and" + "<br />" +
                                "support each other as we all accomplish our health goals." + "<br /><br />" +
                               "http://alerevitality.com/Register.aspx?val=" + retval + "&nbsp;" + " to finish signing up." + name + "&nbsp;" + " is waiting for you!"
                               + "<br /><br />" + "Can’t wait to meet you," + "<br />" + "The Vitality Team";




                        //   body = this.PopulateBody( "<br /><br />"+"Alere Vitality Invitation",ConfigurationManager.AppSettings["AlereVitality_Path"]  + "/Register.aspx?val=" + retval, "<br />"+
                        // name +" would like to invite you to participate in their health journey and "+"<br />"
                        //+ "help test out a new site and app called Alere Vitality." + "<br /><br />"+
                        //"Alere Vitality lets you connect with other people looking to get healthier and"+"<br />"
                        //+ "support each other as we all accomplish our health goals."+"<br /><br />"+
                        //"Click Here to finish signing up. "+ name +" is waiting for you!"+"<br /><br />"+
                        //"Can’t wait to meet you," + "<br />" + "The Alere Vitality Team");
                        //}
                        //else
                        //{
                        //    body = this.PopulateBody("Alere Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + retval, txtmessage.Text);
                        //}
                        objClsGeneric.SendMail(email, body, subject);
                        txtEmail.Text = "";
                        txtmessage.Text = "";
                        lbMsg.Visible = true;
                        lbMsg.Text = "Invitation has been sent.";
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private string PopulateBody(string title, string url, string description)
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

        protected void imgprofile_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["MyPrfile"] = true;
                Session["from_login"] = "True";
                Response.Redirect("Wall.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lklogout_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (Request.Cookies["myCookie"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("myCookie");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
                Session.Abandon(); 

                Response.Redirect("../Login.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgRedirectTo_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                MySession.Current.MemberUserId = "";
                MySession.Current.MemberCircleId = "";
                string cid = MySession.Current.LoginId + "-" + 1;
                MySession.Current.SelectedCircleUserId = MySession.Current.LoginId;
                (Session["selectedcircleid"]) = cid;
                MySession.Current.CircleId = "1";
                Session["from_login"] = "True";
                Response.Redirect("Wall.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }


}
