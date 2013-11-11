using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.alereimpactservice;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.Admin;
using System.Configuration;
using System.Text;
using System.IO;
using System.Web.Services;
using System.Data.SqlClient;
using System.Globalization;
namespace ALEREIMPACT.User
{
    public partial class LoginUserMaster : System.Web.UI.MasterPage
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        UserCommentsBAL objUserCommentsBal = new UserCommentsBAL();
        UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
        SQLHelper objhelper = new SQLHelper();
        AdminBAO objAdminBAO = new AdminBAO();
        ClsGeneric objClsGeneric = new ClsGeneric();

        protected static string _mission_id_selected = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                //Response.Write(Server.MapPath(".") + "CircleImages/");

                Page.Header.DataBind();
                if (String.IsNullOrEmpty(Convert.ToString(MySession.Current.LoginId)))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                }

                else
                {
                    if (!Page.IsPostBack)
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(MySession.Current.LoginId)))
                        {
                            FoodLog();
                            txtcirclecolor.Attributes.Add("readonly", "readonly");
                            LoginUserDetails();
                            GetPendingInvitations();
                            GetProfileImage();
                            CountMessage();
                            BindCircles(); //Bind Circles 
                            filldropdowns(); // Bind Circle Permissions

                            //  Session["bubbleId"] = lblMessage.Value;
                        }

                    }

                    Show_PersonalizationBox();
                    AskWeight_Weekely();


                    if (Convert.ToString(Session["bubbleId"]) == "" || Convert.ToString(Session["bubbleId"]) == null)
                    {
                        lblMessage.Value = "1";
                    }
                    else
                    {
                        lblMessage.Value = Convert.ToString(Session["bubbleId"]);
                    }
                    if (Convert.ToString(Session["terms"]) == "True")
                    {
                        this.iframeProfile.Attributes["src"] = "TermsAndConditions.aspx";
                    }
                    else if (Convert.ToString(Session["privacy"]) == "True")
                    {
                        this.iframeProfile.Attributes["src"] = "PrivacyAndPolicy.aspx";
                    }
                    else if (Convert.ToString(Session["support"]) == "True")
                    {
                        this.iframeProfile.Attributes["src"] = "Support.aspx";
                    }
                }

              //  Page.GetPostBackEventReference(ImgBtnPrevious);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //  SerachMembers1();
        }
        public HtmlControl iframe
        {
            get
            {
                return this.iframeProfile;
            }
        }
        private Boolean Ifweight_AlreadyEneterd()
        {
            bool Exists;
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            DataSet ds = new DataSet();
            objRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
            ds = RegisterUserDAO.Get_WeightAlreadyExists(objRegisterUserBAO);


            if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
                Exists = true;
            else
                Exists = false;

            return Exists;
        }
        private void AskWeight_Weekely()
        {
            string nameOfTheDay = DateTime.Now.ToString("dddd", new CultureInfo("en-US")).ToLower();
            if (nameOfTheDay == "sunday")
            {
                var eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                var local = TimeZoneInfo.Local;
                DateTime k = DateTime.Now.Add(eastern.BaseUtcOffset - local.BaseUtcOffset);
                String s = k.ToString("HH");

                //var dateTime = System.DateTime.ParseExact("03/14/2012 01:00:00 PM", "MM/dd/yyyy hh:mm:ss tt",
                //                   System.Globalization.CultureInfo.InvariantCulture);
                //var dateTimeString = dateTime.ToString("MM/dd/yyyy HH:mm:ss");

                if (Convert.ToInt32(s) >= 12 && Convert.ToInt32(s) < 14)
                {
                    popUpWeightAsk.Style.Add("position", "fixed");
                    popUpWeightAsk.Style.Add("top", "0");
                    popUpWeightAsk.Style.Add("left", "0");
                    popUpWeightAsk.Style.Add("width", "100%");
                    popUpWeightAsk.Style.Add("height", "100%");
                    popUpWeightAsk.Style.Add("filter", "alpha(opacity=70)");
                    popUpWeightAsk.Style.Add("z-index", "100");

                    if (!Ifweight_AlreadyEneterd())
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:openWeight();", true);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:closeAskWeightpopUp();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:closeAskWeightpopUp();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:closeAskWeightpopUp();", true);
            }


            
        }
        private void Show_PersonalizationBox()
        {
            try
            {
                DataSet ds = new DataSet();
                objRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                objRegisterUserBAO.UI_STATUS = 0;
                objRegisterUserBAO.procedureType = "1";

                ds = RegisterUserDAO.GetPersonalizationStatus(objRegisterUserBAO);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["PerStatus"].ToString() == "2")
                        {
                            popPersonalization.Style.Add("position", "fixed");
                            popPersonalization.Style.Add("top", "0");
                            popPersonalization.Style.Add("left", "0");
                            popPersonalization.Style.Add("width", "100%");
                            popPersonalization.Style.Add("height", "100%");
                            popPersonalization.Style.Add("filter", "alpha(opacity=70)");
                            popPersonalization.Style.Add("z-index", "100");
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:openPerosalization();", true);

                            dtPersonlizationImages.DataSource = ds.Tables[1];
                            dtPersonlizationImages.DataBind();
                            Session["from_login"] = string.Empty;
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["PerStatus"].ToString() == "1" && !String.IsNullOrEmpty(Convert.ToString(Session["from_login"])))
                            {
                                Session["from_login"] = string.Empty;
                                dtPersonlizationImages.DataSource = ds.Tables[1];
                                dtPersonlizationImages.DataBind();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:openPerosalization();", true);
                            }
                            else if (ds.Tables[0].Rows[0]["PerStatus"].ToString() == "3" && !String.IsNullOrEmpty(Convert.ToString(Session["from_login"])))
                            {
                                Session["from_login"] = string.Empty;
                                dtPersonlizationImages.DataSource = ds.Tables[1];
                                dtPersonlizationImages.DataBind();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:openPerosalization();", true);
                            }
                            else
                            {
                                dtPersonlizationImages.DataSource = ds.Tables[1];
                                dtPersonlizationImages.DataBind();

                                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:closePerosalization();", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnAddWeight_Click(object source, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            RegisterUserBAO objNewUserBao = new RegisterUserBAO();
            objNewUserBao.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
            objNewUserBao.Weight = Convert.ToInt32(txtWeight.Text.Trim());
            objNewUserBao.WeightUnits = Convert.ToInt32(DrpWeightUnit.SelectedValue);
            RegisterUserDAO.AddAskWeight_Weekely(objNewUserBao);

            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "javascript:closeAskWeightpopUp();", true);
        }
        protected void DLQuickVideos_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                txtcirclecolor.Attributes.Add("readonly", "readonly");
                LoginUserDetails();
                GetPendingInvitations();
                GetProfileImage();
                CountMessage();
                BindCircles(); //Bind Circles 
                filldropdowns(); // Bind Circle Permissions
                Show_PersonalizationBox();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
       

        private void GetProfileImage()
        {
            try
            {
                DataTable dt = new DataTable();
                objRegisterUserBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objRegisterUserBAO.procedureType = "GI";
                dt = RegisterUserDAO.GetInvitationDetail(objRegisterUserBAO);
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
        private void CountMessage()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.ProcedureType = "G3";
                dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NOOFUNREAD"].ToString() == "0")
                    {
                        divnoti.Style.Add("display", "none");
                    }
                    else
                    {
                        divnoti.Style.Add("display", "");
                        lbnotification.Text = dt.Rows[0]["NOOFUNREAD"].ToString();
                    }
                }


                else
                {
                    divnoti.Style.Add("display", "none");
                }

                DataTable dtN = new DataTable();
                objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.ProcedureType = "G5";
                dtN = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                if (dtN.Rows.Count > 0)
                {
                    if (dtN.Rows[0]["noofUnread"].ToString() == "0")
                    {
                        DivNitification.Style.Add("display", "none");
                    }
                    else
                    {
                        DivNitification.Style.Add("display", "");
                        lbNMINotification.Text = dtN.Rows[0]["noofUnread"].ToString();
                    }
                }
                else
                {
                    DivNitification.Style.Add("display", "none");
                }
                DataTable dtMessage = new DataTable();
                objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.ProcedureType = "UN9";
                dtMessage = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                if (dtMessage.Rows.Count > 0)
                {
                    DVAdminMessage.Style.Add("display", "block");
                   // lnkClick.Text = dtMessage.Rows[0]["GM_MESSAGE"].ToString();
                    //LinkButton2.Text = dtMessage.Rows[1]["GM_MESSAGE"].ToString();
                    //LinkButton3.Text = dtMessage.Rows[2]["GM_MESSAGE"].ToString();
                    //LinkButton4.Text = dtMessage.Rows[3]["GM_MESSAGE"].ToString();
                    //LinkButton5.Text = dtMessage.Rows[4]["GM_MESSAGE"].ToString();
                }
                else
                {
                    DVAdminMessage.Style.Add("display", "none");
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
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

        //Logout 
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objRegisterUserBAO.AT_ID = Convert.ToInt32(MySession.Current.ATId);
                objRegisterUserBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objRegisterUserBAO.AT_LOGOUTTIME = Convert.ToString(DateTime.Now);
                objRegisterUserBAO.procedureType = "U";
                retval = RegisterUserDAO.UpdatetblAuditTrail(objRegisterUserBAO);

                /*CAUTION***********************************/

                /* we are commenting this sessin.abondon() so that FitBit account of a user whoes token and 
                /* secret are added in our database need not to establish new Authentication.*/

                /*********************************************************/
                if (Request.Cookies["myCookie"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("myCookie");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
                Session.Abandon();
                //MySession.Current.LoginId = null;
                //MySession.Current.PublicCircleUserId = null;
                //MySession.Current.PublicCircleId = null;
                //MySession.Current.PublicPermissions = null;
                //MySession.Current.StatusID = null;
                //MySession.Current.LinkID = null;
                //MySession.Current.ETID = null;
                //MySession.Current.LabelId = null;

                //MySession.Current.UserFirstName = null;
                //MySession.Current.searchfriendId = null;
                //MySession.Current.CircleId = null;
                //MySession.Current.MemberCircleId = null;
                //MySession.Current.SelectedCircleUserId = null;
                //MySession.Current.SelectedCircleName = null;
                //MySession.Current.MemberUserId = null;
                //MySession.Current.Id = null;
                //Session["from_logActivities"] = null;
                //int limit = Request.Cookies.Count; //Get the number of cookies and use that as the limit
                //HttpCookie aCookie;   //Instantiate a cookie placeholder
                //string cookieName;

                ////Loop through the cookies

                //for (int i = 0; i < limit; i++)
                //{
                //    cookieName = Request.Cookies[i].Name;    //get the name of the current cookie

                //    aCookie = new HttpCookie(cookieName);    //create a new cookie with the same name as the one you're deleting
                //    aCookie.Value = "";    //set a blank value to the cookie
                //    aCookie.Expires = DateTime.Now.AddDays(-1);    //Setting the expiration date in the past deletes the cookie

                //    Response.Cookies.Add(aCookie);    //Set the cookie
                //}
                Response.Redirect("~/Login.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //Pending Invitation Notification
        protected void GetPendingInvitations()
        {

            try
            {
                int invitationcount = 0;
                objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
                //objusercircles.fk_circle_id = MySession.Current.CircleId;
                objusercircles.proceduretype = "C";
                invitationcount = UserCirclesDAO.GetPendingInvitations(objusercircles);
                if (invitationcount != 0)
                {
                    dvpendinginvitaionmsg.Style.Add("display", "block");
                    lbpendinginvitations.Text = Convert.ToString(invitationcount);
                    lbpendinginvmsg.Text = " New Circle Invitation(s)";
                }
                else
                {
                    dvpendinginvitaionmsg.Style.Add("display", "none");
                }

                //if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                //{
                //    if (MySession.Current.PublicCircleId == null || MySession.Current.PublicCircleId == "")
                //    {
                //    }
                //    else
                //    {
                //        dvpendinginvitaionmsg.Style.Add("display", "none");
                //        dvacceptInvitation.Visible = true;
                //    }
                //    //dvpendinginvitaionmsg.Visible = true;
                //}
                //else
                //{
                //    dvpendinginvitaionmsg.Style.Add("display", "none");
                //    dvacceptInvitation.Visible = true;
                //}


            }
            catch (Exception ex)
            {

            }

        }

        //Logo Click
        protected void lkhomelogo_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                MySession.Current.PublicCircleId = "";
                MySession.Current.PublicCircleUserId = "";
                MySession.Current.MemberUserId = "";
                MySession.Current.MemberCircleId = "";
                Session["bubbleId"] = "1";
                string cid = MySession.Current.LoginId + "-" + 1;
                MySession.Current.SelectedCircleUserId = MySession.Current.LoginId;
                (Session["selectedcircleid"]) = cid;
                MySession.Current.CircleId = "1";
                MySession.Current.SelectedCircleName = "Inner Circle";
                Response.Redirect("Wall.aspx", false);
                //GetCircleName();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //protected void lkMessages_Click(object sender, EventArgs e)
        //{
        //    Session["show_admin_posed_messages"] = "True";
        //   // Response.Redirect("Wall.aspx", false);
        //    this.iframeProfile.Attributes["src"] = "Wall.aspx";




        //}

        //Bind Circles and Circle Selections
        protected void repCircles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                LinkButton lb = e.Item.FindControl("lnkChangeCircle") as LinkButton;
                ToolkitScriptManager1.RegisterAsyncPostBackControl(e.Item.FindControl("lnkChangeCircle"));

                int membercount = 0;
                int missioncount = 0;
                //Find Controls from Repeater Control
                HtmlGenericControl dynamic1 = (HtmlGenericControl)e.Item.FindControl("dvimagecircle");
                HiddenField hndcolor = (HiddenField)e.Item.FindControl("hndcolor");
                HiddenField hnducId = (HiddenField)e.Item.FindControl("hnducId");
                HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
                HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
                HiddenField hndCName = (HiddenField)e.Item.FindControl("hndCName");
                HiddenField hdnIID = (HiddenField)e.Item.FindControl("hdnIID");
                HiddenField hdnPermission = (HiddenField)e.Item.FindControl("hdnPermission");
              

                Label lbmembercount = (Label)e.Item.FindControl("lbmembercount");
                Label lbmissioncount = (Label)e.Item.FindControl("lbmissioncount");

                HtmlAnchor lkfriendscount = (HtmlAnchor)e.Item.FindControl("lkfriendscount");
                HtmlAnchor lkmissioncount = (HtmlAnchor)e.Item.FindControl("lkmissioncount");

                var myHidden = (HiddenField)e.Item.FindControl("repid");
                if (Convert.ToString(Session["NewcircleId"]) != "" && Convert.ToString(Session["NewcircleId"]) != null)
                {
                    if (hndCircleId.Value == Convert.ToString(Session["NewcircleId"]))
                    {
                        myHidden.Value = e.Item.ItemIndex.ToString();
                        Session["bubbleId"] = Convert.ToInt32(myHidden.Value) + 1;
                        Session["NewcircleId"] = null;
                    }
                }
                else
                {
                    if (hndCircleId.Value == Convert.ToString(MySession.Current.PublicCircleId))
                    {
                        myHidden.Value = e.Item.ItemIndex.ToString();
                        Session["bubbleId"] = Convert.ToInt32(myHidden.Value) + 1;
                    }
                }


                //Find color Div - Change circle color dynamically
                HtmlGenericControl dvcirclecolor = (HtmlGenericControl)e.Item.FindControl("dvcirclecolor");
                dvcirclecolor.Style.Add("background-color", "#" + hndcolor.Value);
                //dynamic1.Style.Add("border", "9px solid");


                HtmlGenericControl dv1img = (HtmlGenericControl)e.Item.FindControl("dv1img");
                HtmlGenericControl dv2img = (HtmlGenericControl)e.Item.FindControl("dv2img");
                HtmlGenericControl dv3img = (HtmlGenericControl)e.Item.FindControl("dv3img");
                HtmlGenericControl dv4img = (HtmlGenericControl)e.Item.FindControl("dv4img");
                HtmlGenericControl dv5img = (HtmlGenericControl)e.Item.FindControl("dv5img");


                //Get member Images (5)
                DataTable dtMemberimg = new DataTable();
                objusercircles.UserId = hndUserId.Value;
                objusercircles.fk_circle_id = hndCircleId.Value;
                objusercircles.proceduretype = "S";
                dtMemberimg = UserCirclesDAO.GetMemberImagesForCircle(objusercircles);
                if (dtMemberimg.Rows.Count == 1)
                {
                    if (Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == null)
                    {
                        dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[0]["userid"].ToString())
                        {
                            dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[0]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                            }
                        }
                    }
                    dv1img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv1img.Style.Add("cursor", "pointer");
                    dv1img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[0][0] + "');");
                }

                if (dtMemberimg.Rows.Count == 2)
                {
                    DataRow[] dr = dtMemberimg.Select("userid ='" + MySession.Current.LoginId + "'");
                    DataRow newRow = dtMemberimg.NewRow();
                    // We "clone" the row
                    newRow.ItemArray = dr[0].ItemArray;
                    // We remove the old and insert the new
                    dtMemberimg.Rows.Remove(dr[0]);
                    dtMemberimg.Rows.InsertAt(newRow, 0);

                    if (Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == null)
                    {
                        dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[0]["userid"].ToString())
                        {
                            dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[0]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                            }
                        }
                    }
                    if (Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == null)
                    {
                        dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[1]["userid"].ToString())
                        {
                            dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[1]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                            }
                        }

                    }
                    dv1img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv2img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv1img.Style.Add("cursor", "pointer");
                    dv2img.Style.Add("cursor", "pointer");

                    dv1img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[0][0] + "');");
                    dv2img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[1][0] + "');");
                }
                if (dtMemberimg.Rows.Count == 3)
                {

                    DataRow[] dr = dtMemberimg.Select("userid ='" + MySession.Current.LoginId + "'");
                    DataRow newRow = dtMemberimg.NewRow();
                    // We "clone" the row
                    newRow.ItemArray = dr[0].ItemArray;
                    // We remove the old and insert the new
                    dtMemberimg.Rows.Remove(dr[0]);
                    dtMemberimg.Rows.InsertAt(newRow, 0);

                    if (Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == null)
                    {
                        dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[0]["userid"].ToString())
                        {
                            dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[0]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                            }
                        }
                    }
                    if (Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == null)
                    {
                        dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[1]["userid"].ToString())
                        {
                            dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[1]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                            }
                        }
                    }
                    if (Convert.ToString(dtMemberimg.Rows[2]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[2]["frdimage"]) == null)
                    {
                        dv3img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[2]["userid"].ToString())
                        {
                            dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[2]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                            }
                        }
                    }
                    dv1img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv2img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv3img.Style.Add("border", "2px solid #EEEEEE !important");

                    dv1img.Style.Add("cursor", "pointer");
                    dv2img.Style.Add("cursor", "pointer");
                    dv3img.Style.Add("cursor", "pointer");

                    dv1img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[0][0] + "');");
                    dv2img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[1][0] + "');");
                    dv3img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[2][0] + "');");

                }
                if (dtMemberimg.Rows.Count == 4)
                {
                    DataRow[] dr = dtMemberimg.Select("userid ='" + MySession.Current.LoginId + "'");
                    DataRow newRow = dtMemberimg.NewRow();
                    // We "clone" the row
                    newRow.ItemArray = dr[0].ItemArray;
                    // We remove the old and insert the new
                    dtMemberimg.Rows.Remove(dr[0]);
                    dtMemberimg.Rows.InsertAt(newRow, 0);

                    if (Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == null)
                    {
                        dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[0]["userid"].ToString())
                        {
                            dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[0]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                            }
                        }
                    }
                    if (Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == null)
                    {
                        dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[1]["userid"].ToString())
                        {
                            dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[1]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                            }
                        }
                    }
                    if (Convert.ToString(dtMemberimg.Rows[2]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[2]["frdimage"]) == null)
                    {
                        dv3img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[2]["userid"].ToString())
                        {
                            dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[2]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                            }
                        }

                    }
                    if (Convert.ToString(dtMemberimg.Rows[3]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[3]["frdimage"]) == null)
                    {
                        dv4img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[3]["userid"].ToString())
                        {
                            dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[2]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv4img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                            }
                        }

                    }

                    dv1img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv2img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv3img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv4img.Style.Add("border", "2px solid #EEEEEE !important");

                    dv1img.Style.Add("cursor", "pointer");
                    dv2img.Style.Add("cursor", "pointer");
                    dv3img.Style.Add("cursor", "pointer");
                    dv4img.Style.Add("cursor", "pointer");

                    dv1img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[0][0] + "');");
                    dv2img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[1][0] + "');");
                    dv3img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[2][0] + "');");
                    dv4img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[3][0] + "');");
                }
                if (dtMemberimg.Rows.Count == 5)
                {
                    DataRow[] dr = dtMemberimg.Select("userid ='" + MySession.Current.LoginId + "'");
                    DataRow newRow = dtMemberimg.NewRow();
                    if (dr.Length > 0)
                    {
                        // We "clone" the row
                        newRow.ItemArray = dr[0].ItemArray;
                        // We remove the old and insert the new
                        dtMemberimg.Rows.Remove(dr[0]);
                        dtMemberimg.Rows.InsertAt(newRow, 0);
                    }
                    if (Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[0]["frdimage"]) == null)
                    {
                        dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[0]["userid"].ToString())
                        {
                            dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[0]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv1img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                            }
                        }
                    }
                    if (Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[1]["frdimage"]) == null)
                    {
                        dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[1]["userid"].ToString())
                        {
                            dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[1]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv2img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                            }
                        }
                    }
                    if (Convert.ToString(dtMemberimg.Rows[2]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[2]["frdimage"]) == null)
                    {
                        dv3img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[2]["userid"].ToString())
                        {
                            dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[2]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv3img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                            }
                        }

                    }
                    if (Convert.ToString(dtMemberimg.Rows[3]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[3]["frdimage"]) == null)
                    {
                        dv4img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[3]["userid"].ToString())
                        {
                            dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[3]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv4img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                            }
                        }

                    }
                    if (Convert.ToString(dtMemberimg.Rows[4]["frdimage"]) == "" || Convert.ToString(dtMemberimg.Rows[4]["frdimage"]) == null)
                    {
                        dv5img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                    }
                    else
                    {
                        if (MySession.Current.LoginId == dtMemberimg.Rows[4]["userid"].ToString())
                        {
                            dv5img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[4]["frdimage"]));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(dtMemberimg.Rows[3]["userid"]);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dv5img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[4]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    dv5img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[4]["frdimage"]));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dv5img.Style.Add("background-image", "profile_image/profileBlankPhoto.jpg");
                                }
                            }
                            else
                            {
                                dv5img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[4]["frdimage"]));
                            }
                        }

                    }

                    dv1img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv2img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv3img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv4img.Style.Add("border", "2px solid #EEEEEE !important");
                    dv5img.Style.Add("border", "2px solid #EEEEEE !important");

                    dv1img.Style.Add("cursor", "pointer");
                    dv2img.Style.Add("cursor", "pointer");
                    dv3img.Style.Add("cursor", "pointer");
                    dv4img.Style.Add("cursor", "pointer");
                    dv5img.Style.Add("cursor", "pointer");

                    dv1img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[0][0] + "');");
                    dv2img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[1][0] + "');");
                    dv3img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[2][0] + "');");
                    dv4img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[3][0] + "');");
                    dv5img.Attributes.Add("onclick", "ToUserProfile('" + dtMemberimg.Rows[4][0] + "');");
                }



                //Get Total Member Count for the circle
                objusercircles.UserId = hndUserId.Value;
                objusercircles.fk_circle_id = hndCircleId.Value;
                objusercircles.proceduretype = "M";
                membercount = UserCirclesDAO.GetCircleMemberCount(objusercircles);
                //lkfriendscount.Text = Convert.ToString(membercount);
                lbmembercount.Text = Convert.ToString(membercount);

                lkfriendscount.Attributes.Add("onclick", "GetMemberList('" + DataBinder.Eval(e.Item.DataItem, "fk_circle_id") + "','" + DataBinder.Eval(e.Item.DataItem, "fk_user_registration_Id") + "');");

                ////Get Total Mission Count for the circle
                //objusercircles.UserId = hndUserId.Value;
                //objusercircles.fk_circle_id = hndCircleId.Value;
                ////if (MySession.Current.LoginId == hndUserId.Value)
                ////    {
                //objusercircles.proceduretype = "MI";
                ////}
                ////else
                ////{
                ////    objusercircles.proceduretype = "MC";
                ////}
                DataTable dt = new DataTable();
                objusercircles.fk_user_registration_Id = hndUserId.Value;
                objusercircles.fk_circle_id = MySession.Current.CircleId;
                objusercircles.proceduretype = "S";
                DataTable dtFriends = new DataTable();
                dtFriends = UserCirclesDAO.GetFriendList(objusercircles);

                StringBuilder fr = new StringBuilder();
                foreach (DataRow dr in dtFriends.Rows)
                {
                    fr.Append(dr["userid"].ToString() + ",");
                }
                ObjUserMissionsBAL.AllFriends_Id = fr.ToString().TrimEnd(',');
                ObjUserMissionsBAL.CircleId = Convert.ToInt32(hndCircleId.Value);
                ObjUserMissionsBAL.LoginId = Convert.ToInt32(hndUserId.Value);
                ObjUserMissionsBAL.fk_User_Circle_id = Convert.ToInt32(hnducId.Value);

                dt = RegisterUserDAO.ListAllMissionsByLoginId(ObjUserMissionsBAL);
                DataTable table= new DataTable();
                table.Columns.Add("Name", typeof(string));
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       string  name = dt.Rows[i]["mission_name"].ToString();
                       if (hndUserId.Value == dt.Rows[i]["Pk_created_by_user_Id"].ToString())
                       {
                           table.Rows.Add(name);
                       }
                       else
                       {
                           if (dt.Rows[i]["missionInfo"].ToString() == "IndividualPrivate")
                           {
                           }
                           else if (dt.Rows[i]["missionInfo"].ToString() == "0")
                           {
                           }
                           else if (dt.Rows[i]["missionInfo"].ToString() == "Show")
                           {
                               table.Rows.Add(name);
                           }
                       }
                    }
                }



                missioncount = Convert.ToInt32(table.Rows.Count);
                lbmissioncount.Text = Convert.ToString(missioncount);

                if (Convert.ToString(Session["selectedcircleid"]) == null || Convert.ToString(Session["selectedcircleid"]) == "")
                {
                    if (MySession.Current.SelectedCircleName == null || MySession.Current.SelectedCircleName == "")
                    {
                        MySession.Current.SelectedCircleName = "Inner Circle";
                    }
                    // MySession.Current.SelectedCircleName = hndCName.Value;

                }

                //Selected Circle Indication

                string cid = hndUserId.Value + "-" + hndCircleId.Value;

                (Session["selectedcircleid"]) = cid;
                MySession.Current.SelectedCircleUserId = MySession.Current.LoginId;



                if (Convert.ToString(Session["selectedcircleid"]) == cid)
                {
                    HtmlGenericControl dvcirclecolor1 = (HtmlGenericControl)e.Item.FindControl("dvcirclecolor");
                    //  dvcirclecolor1.Style.Add("border", "9px solid");
                    //   dvcirclecolor1.Style.Add("height", "190px !important");
                    // dvcirclecolor1.Style.Add("width", "190px !important");
                    //dvcirclecolor1.Style.Add("left", "40px !important");
                    //dvcirclecolor1.Style.Add("top", "200px !important");
                    //dvcirclecolor1.Style.Add("data-href", hndCircleId.Value);
                    //MySession.Current.SelectedCircleName = hndCName.Value;

                }

                // dynamic1.Style.Add("border-color", "#" + hndcolor.Value);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void repCircles_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                //LinkButton lb1 = e.Item.FindControl("lnkChangeCircle") as LinkButton;
                //ToolkitScriptManager1.RegisterAsyncPostBackControl(lb1);

                //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                //{
                //    HiddenField getselectedbubbleId = (HiddenField)e.Item.FindControl("repid");

                //    Session["bubbleId"] = getselectedbubbleId.Value;
                //    HtmlGenericControl dvcirclecolor = (HtmlGenericControl)e.Item.FindControl("dvcirclecolor");

                //    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                //    if (e.CommandName == "ShowForSelectedCircle") //Circle Selection
                //    {
                //        HiddenField hnducId = (HiddenField)e.Item.FindControl("hnducId");
                //        Int32 CircleId = Convert.ToInt32(commandArgs[0]);
                //        HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
                //        HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
                //        HiddenField hndCName = (HiddenField)e.Item.FindControl("hndCName");

                //        string cid = hndUserId.Value + "-" + hndCircleId.Value;
                //        Session["selectedcircleid"] = cid;

                //        Int32 SelectedCircleUId = Convert.ToInt32(commandArgs[1]);
                //        MySession.Current.SelectedCircleUserId = Convert.ToInt32(SelectedCircleUId).ToString();
                //        MySession.Current.CircleId = Convert.ToInt32(CircleId).ToString();
                //        MySession.Current.SelectedCircleName = hndCName.Value;




                //      //  Response.Redirect("~/User/Wall.aspx", false);

                //     }
                //    if (e.CommandName == "ShowSelectedCircleMembers") //Member List on click on Circle Member count
                //    {
                //        HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
                //        HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
                //        string cid = hndUserId.Value + "-" + hndCircleId.Value;
                //        Session["selectedcircleid"] = cid;

                //        Int32 CircleId = Convert.ToInt32(commandArgs[0]);
                //        Int32 SelectedCircleUId = Convert.ToInt32(commandArgs[1]);
                //        MySession.Current.SelectedCircleUserId = Convert.ToInt32(SelectedCircleUId).ToString();
                //        MySession.Current.CircleId = Convert.ToInt32(CircleId).ToString();
                //        Response.Redirect("~/User/MemberList.aspx", false);
                //    }
                //    if (e.CommandName == "ShowSelectedCircleMissions") //Mission List on click on Circle Mission count
                //    {
                //        HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
                //        HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
                //        string cid = hndUserId.Value + "-" + hndCircleId.Value;
                //        Session["selectedcircleid"] = cid;

                //        Int32 CircleId = Convert.ToInt32(commandArgs[0]);
                //        Int32 SelectedCircleUId = Convert.ToInt32(commandArgs[1]);
                //        MySession.Current.SelectedCircleUserId = Convert.ToInt32(SelectedCircleUId).ToString();
                //        MySession.Current.CircleId = Convert.ToInt32(CircleId).ToString();
                //        Session["show_list_mission"] = "True";
                //        Response.Redirect("~/User/Missions.aspx", false);

                //    }
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void BindCircles()
        {
            try
            {
                DataTable dtcircles = new DataTable();
                DataSet ds = new DataSet();


                //if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                //{
                //    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                //    {
                objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.fk_circle_id = 0;

                objusercircles.proceduretype = "G";
                dtcircles = UserCirclesDAO.GetUserCircles(objusercircles);
                ds.Tables.Add(dtcircles);
                //imgaddcircle.Visible = true;
                //Label1.Visible = true;
                //}

                //else
                //{
                //    //if (MySession.Current.PublicCircleUserId == "2")
                //    //{


                //    objusercircles.userRegistration_ID = Convert.ToInt32(MySession.Current.LoginId);
                //    objusercircles.fk_circle_ID = Convert.ToInt32(MySession.Current.CircleId);
                //    objusercircles.userfriend_ID = Convert.ToInt32(MySession.Current.PublicCircleUserId);
                //    objusercircles.fk_circlePermission_ID = "2";
                //    if (Convert.ToString(Session["Search"]) == "True")
                //    {
                //        objusercircles.proceduretype = "V";
                //    }
                //    else if (Convert.ToString(Session["Circle"]) == "True")
                //    {
                //        objusercircles.proceduretype = "G";
                //    }
                //    else
                //    {
                //        objusercircles.proceduretype = "S";
                //    }
                //      //  dtcircles = UserCirclesDAO.GetUserFriendPublicCircles(objusercircles);
                //        if (Convert.ToString(Session["Circle"]) == "True")
                //        {
                //            if (dtcircles.Rows.Count > 0)
                //            {
                //                if (dtcircles.Rows[0]["fk_circle_id"].ToString() == MySession.Current.PublicCircleId)
                //                {
                //                    Int32 count = dtcircles.Rows.Count;
                //                    Session["bubbleId"] = Convert.ToString(count);
                //                }
                //            }
                //        }
                //        ds.Tables.Add(dtcircles);
                //        MySession.Current.SelectedCircleUserId = Convert.ToString(MySession.Current.PublicCircleUserId);
                //        MySession.Current.CircleId = Convert.ToString(MySession.Current.PublicCircleId);
                //        Session["Search"] = false;
                //        Session["Circle"] = false;
                //        //}
                //        //else
                //        //{ 
                //        //}
                //    }



                //}


                //else
                //{
                //    objusercircles.UserId = Convert.ToInt32(MySession.Current.MemberUserId);
                //    objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.MemberCircleId);
                //    objusercircles.proceduretype = "M";
                //    dtcircles = UserCirclesDAO.GetUserCircles(objusercircles);
                //    ds.Tables.Add(dtcircles);
                //    // imgaddcircle.Visible = false;
                //    //  Label1.Visible = false;
                //}



                if (dtcircles.Rows.Count > 0)
                {
                    //repCircles.DataSource = dtcircles;
                    repCircles.DataSource = ds.Tables[0];
                    repCircles.DataBind();

                }
                //if (dtcircles.Rows.Count == 10)
                //{
                //    lkAllCircles.Visible = true;
                //}
                //else
                //{
                //    lkAllCircles.Visible = false;
                //}


                if (MySession.Current.CircleId == "" || MySession.Current.CircleId == null)
                {
                    MySession.Current.CircleId = Convert.ToInt32(dtcircles.Rows[0]["pk_circle_id"]).ToString();

                }

                //Hide Search when view profile on invitation
                if (dtcircles.Rows.Count == 1)
                {
                    dvsearchmembers.Style.Add("display", "none");
                }

                if (Convert.ToString(MySession.Current.MemberUserId) != "" || Convert.ToString(MySession.Current.PublicCircleId) != null)
                {
                    DataTable dtMemberimg = new DataTable();
                    objusercircles.UserId = MySession.Current.LoginId;
                    if (Convert.ToString(MySession.Current.PublicCircleId) != "")
                    {
                        objusercircles.fk_circle_id = MySession.Current.PublicCircleId;
                    }
                    else
                    {
                        objusercircles.fk_circle_id = MySession.Current.MemberCircleId;
                    }
                    objusercircles.proceduretype = "G";
                    dtMemberimg = UserCirclesDAO.GetMemberImagesForCircle(objusercircles);
                    if (dtMemberimg.Rows.Count > 0)
                    {
                        if (dtMemberimg.Rows[0]["fk_request_status_id"].ToString() == "1" || dtMemberimg.Rows[0]["fk_request_status_id"].ToString() == "5")
                        {
                            aLog.Disabled = true;
                        }
                        else
                        {
                            aLog.Disabled = false;
                        }
                    }
                    else
                    {

                        aLog.Disabled = true;
                        aLog.Style.Add("cursor", "none");
                    }
                }
            }
            catch (Exception ex)
            { }


        }
        protected void btnJoinPublicGroup_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                objusercircles.proceduretype = "S";
                dt = UserCirclesDAO.GetUserCircles(objusercircles);
                if (dt.Rows.Count == 0)
                {
                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {
                            objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        }
                        else
                        {
                            objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.PublicCircleUserId);
                        }
                    }
                    else
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.MemberUserId);
                    }

                    objusercircles.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                    DataTable dt1 = new DataTable();
                    objRegisterUserBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
                    objRegisterUserBAO.procedureType = "GC";
                    dt = RegisterUserDAO.GetInvitationDetail(objRegisterUserBAO);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["fk_circle_permission_id"].ToString() == "3")
                        {
                            objusercircles.request_status = 5;
                        }
                        else
                        {
                            objusercircles.request_status = 2;
                        }
                    }
                    //Accept Request
                    objusercircles.updated_on = System.DateTime.Now;
                    objusercircles.proceduretype = "I";
                    UserCirclesDAO.AcceptFriendRequest(objusercircles);

                    MySession.Current.SelectedCircleUserId = MySession.Current.PublicCircleUserId;
                    MySession.Current.CircleId = MySession.Current.CircleId;
                    Session["NewcircleId"] = MySession.Current.CircleId; // Select Circle ID
                    Session["Topselcircle"] = MySession.Current.CircleId;//to display circle name at top
                    MySession.Current.PublicCircleUserId = "";
                    MySession.Current.PublicCircleId = "";
                    MySession.Current.MemberUserId = "";
                    MySession.Current.MemberCircleId = "";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "parentwindow2", "parentwindow2()", true);
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('This Inspirator is already exists in your Library');", true);
                //}

            }

            catch (Exception ex)
            {

            }
        }
        //public void MessagesShow()
        //{
        //    this.iframeProfile.Attributes["src"] = "AdminMessagesFront.aspx";
        //}
        public void SearchMembers()
        {
            try
            {
                if (MySession.Current.searchfriendId == MySession.Current.LoginId)
                {
                }
                else if (MySession.Current.SearchNAme == "" || MySession.Current.SearchNAme == null)
                {
                    Session["USerProfile"] = true;
                    if (MySession.Current.Id == "0")
                    {
                        this.iframeProfile.Attributes["src"] = "MyProfile.aspx";
                    }
                    else
                    {
                        MySession.Current.PublicCircleId = MySession.Current.Id;
                        this.iframeProfile.Attributes["src"] = "MyProfile.aspx";
                    }
                }
                else
                {

                    this.iframeProfile.Attributes["src"] = "InviteMembers.aspx?val=" + MySession.Current.SearchNAme;

                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //search circle from search box
        public void Search_Circle_List()
        {
            try
            {


                this.iframeProfile.Attributes["src"] = "PublicCircles.aspx";

                }

            
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //Add New Circle

        protected void btncreatecircle_Click(object sender, EventArgs e)
        {

            ClsGeneric.ReplaceCookie();

            // PnlCircle.Visible = true;
            string circleimagefile = "";
            try
            {
                if (txtcirclename.Text != "")
                {

                    if (fucircleimage.HasFile)
                    {
                        Int32 filesize = fucircleimage.PostedFile.ContentLength;
                        //if (filesize < 102400)
                        //{
                        string extension = System.IO.Path.GetExtension(fucircleimage.PostedFile.FileName);
                        circleimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + txtcirclename.Text + extension;

                        string filepath = Server.MapPath("~/User/CircleImages");
                        fucircleimage.PostedFile.SaveAs(filepath + "\\" + circleimagefile);

                        // }
                        //else
                        //{ 
                        //    lbuploadimger.Text="Image Size is ";
                        //}

                    }
                    MySession.Current.PublicCircleUserId = "";
                    MySession.Current.PublicCircleUserId = "";

                    objusercircles.circle_name = txtcirclename.Text;
                    objusercircles.circle_color = txtcirclecolor.Text;
                    objusercircles.circle_create_date = Convert.ToString(DateTime.Now);
                    objusercircles.circle_image = circleimagefile;
                    objusercircles.fk_circle_id = 0;
                    objusercircles.fk_circle_permission_id = ddlcirclespec.SelectedValue.ToString();
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.proceduretype = "S";
                    Int32 newcircleId = 0;
                    newcircleId = UserCirclesDAO.AddNewCircle(objusercircles);
                    MySession.Current.SelectedCircleUserId = Convert.ToInt32(MySession.Current.LoginId).ToString();
                    MySession.Current.CircleId = Convert.ToInt32(newcircleId).ToString();
                    Session["NewcircleId"] = MySession.Current.CircleId;
                    string cid = MySession.Current.SelectedCircleUserId + "-" + MySession.Current.CircleId;
                    (Session["selectedcircleid"]) = cid;
                    BindCircles();
                    MySession.Current.SelectedCircleName = "";
                    MySession.Current.SelectedCircleName = txtcirclename.Text;
                    Response.Redirect("~/User/Wall.aspx", false);

                    txtcirclename.Text = "";
                    txtcirclecolor.Text = "";
                    ddlcirclespec.SelectedValue = "0";

                    BindCircles();
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
        }
        private void filldropdowns()
        {
            objhelper.fillDrpControl(ddlcirclespec, "spFillDrpDown", "CirclePermissions", "CirclePermissionId", "CS");
        }



        protected void txtcirclename_TextChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objusercircles.circle_name = txtcirclename.Text;
                objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.proceduretype = "S";
                dt = UserCirclesDAO.GetUserCircleName(objusercircles);
                if (dt.Rows.Count > 0)
                {
                    lbCName.Visible = true;
                }
                else
                {
                    lbCName.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //protected void imgaddcircle_Click(object sender, ImageClickEventArgs e)
        //{
        //    txtcirclecolor.Text = "";
        //    txtcirclename.Text = "";
        //    fucircleimage.Dispose();
        //    ddlcirclespec.SelectedIndex = 0;
        //    this.ModalPopupExtender2.Show();
        //}
        //protected void btnSend_Click(object sender, EventArgs e)
        //{
        //    string subject;
        //    try
        //    {
        //        if (txtEmail.Text != "")
        //        {
        //            DataTable dt = new DataTable();
        //            objAdminBAO.name = txtEmail.Text;
        //            objAdminBAO.name1 = "";
        //            objAdminBAO.ProcedureType = "V";
        //            dt = AdminDAO.GetUserDetailSearch(objAdminBAO);
        //            if (dt.Rows.Count > 0)
        //            {
        //                //for (int i = 0; i < dt.Rows.Count; i++)
        //                //{
        //                //    if (txtEmail.Text == dt.Rows[i]["login_email"].ToString())
        //                //    {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('User already exists');", true);
        //                txtEmail.Text = "";
        //                txtmessage.Text = "";
        //                return;
        //                //    }
        //                //}
        //            }
        //            else
        //            {

        //                // get();
        //                email = txtEmail.Text;
        //                int retval = 0;
        //                objAdminBAO.UI_ID = 0;
        //                objAdminBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
        //                objAdminBAO.UI_USER_MAIL_ID = txtEmail.Text;
        //                objAdminBAO.UI_DATE = DateTime.Now.ToString();
        //                objAdminBAO.UI_STATUS = "False";
        //                objAdminBAO.UI_CODE = 1;
        //                objAdminBAO.UI_MAIL_STATUS = "Successfull";
        //                objAdminBAO.ProcedureType = "I";
        //                retval = AdminDAO.InserttblUserInvitation(objAdminBAO);
        //                subject = "Alere Vitality Invitation";
        //                if (txtmessage.Text == "")
        //                {
        //                    body = PopulateBody("Alere Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + retval,
        //        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
        //        " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, "
        //        + "when an unknown printer took a galley of type and scrambled it to make a type specimen book.");
        //                }
        //                else
        //                {
        //                    body = PopulateBody("Alere Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + retval, txtmessage.Text);
        //                }
        //                objClsGeneric.SendMail(email, body, subject);
        //                txtEmail.Text = "";
        //                txtmessage.Text = "";

        //                lbMsgSend.Visible = true;
        //                lbMsgSend.Text = "Invitation has been sent.";
        //                DivEmail.Style.Add("display", "block");

        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }

        //}


        protected void imgCloseBtn_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DivEmail.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void FoodLog()
        {
            try
            {
                if (MySession.Current.LinkID == "1" || MySession.Current.LinkID == "2")
                {

                    this.iframeProfile.Attributes["src"] = "Log.aspx";
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkClick_Click(object sender, EventArgs e)
        {
            DVAdminMessage.Style.Add("display", "none");
            this.iframeProfile.Attributes["src"] = "AdminMessagesFront.aspx";

        }

        protected void ImgBtnClose_Click(object sender, ImageClickEventArgs e)
        {
            DVAdminMessage.Style.Add("display", "none");
        }
        //protected void ImgBtnPrevious_Click(object sender, ImageClickEventArgs e)
        //{
        //    ImgBtnNext.Enabled = true;
        //    ImgBtnNext.Style.Add("cursor", "pointer");
        //    int count = Convert.ToInt32(Session["countmsg"]);
        //    count = count - 1;
        //    DataTable dtMessage = new DataTable();
        //    objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
        //    objUserCommentsBal.ProcedureType = "UN9";
        //    dtMessage = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
        //    if (dtMessage.Rows.Count > 0)
        //    {
        //        lnkClick.Text = dtMessage.Rows[count]["GM_MESSAGE"].ToString();
        //    }
        //    Session["countmsg"] = Convert.ToString(count);
        //    if (count == 0)
        //    {
        //        ImgBtnPrevious.Enabled = false;
        //        ImgBtnPrevious.Style.Add("cursor", "not-allowed");
        //        ImgBtnNext.Enabled = true;
        //        ImgBtnNext.Style.Add("cursor", "pointer");
        //    }
        //}
        //protected void ImgBtnNext_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (Convert.ToString(Session["countmsg"]) == "" || Convert.ToString(Session["countmsg"]) == "0" || Convert.ToString(Session["countmsg"]) == null)
        //    {
        //        DataTable dtMessage = new DataTable();
        //        objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
        //        objUserCommentsBal.ProcedureType = "UN9";
        //        dtMessage = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
        //        if (dtMessage.Rows.Count > 0)
        //        {
        //            lnkClick.Text = dtMessage.Rows[1]["GM_MESSAGE"].ToString();
        //        }
        //        Session["countmsg"] = "1";
        //        ImgBtnPrevious.Enabled = true;
        //        ImgBtnPrevious.Style.Add("cursor", "pointer");
        //    }
        //    else
        //    {

        //        int count = Convert.ToInt32(Session["countmsg"]);
        //        count = count + 1;
               
        //            DataTable dtMessage = new DataTable();
        //            objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
        //            objUserCommentsBal.ProcedureType = "UN9";
        //            dtMessage = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
        //            if (dtMessage.Rows.Count > 0)
        //            {
        //                if (dtMessage.Rows.Count == count)
        //                {
        //                    ImgBtnNext.Enabled = false;
        //                    ImgBtnNext.Style.Add("cursor", "not-allowed");
        //                }
        //                else
        //                {
        //                    lnkClick.Text = dtMessage.Rows[count]["GM_MESSAGE"].ToString();
        //                }
        //            }
        //            Session["countmsg"] = Convert.ToString(count);
        //            if (count == dtMessage.Rows.Count)
        //            {
        //                ImgBtnNext.Enabled = false;
        //                ImgBtnNext.Style.Add("cursor", "not-allowed");
        //            }
        //            ImgBtnPrevious.Enabled = true;
        //            ImgBtnPrevious.Style.Add("cursor", "pointer");
        //        }
            
        //}
    }
}
