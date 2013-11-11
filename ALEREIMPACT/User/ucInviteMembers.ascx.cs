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
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
namespace ALEREIMPACT.User
{
    public partial class ucInviteMembers : System.Web.UI.UserControl
    {
        AdminBAO objAdminBAO = new AdminBAO();
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        public static string Search = "";
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
                    if (!IsPostBack)
                    {
                        
                        if (Convert.ToString(Request.QueryString["val"]) == "" || Convert.ToString(Request.QueryString["val"]) == null)
                        {
                            GetMembersList();
                        }
                        else
                        {
                            Search = Convert.ToString(Request.QueryString["val"]);
                            GetMembersList();
                            GetMemebers();
                            getREsultstatus();
                            MySession.Current.SearchNAme = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void getREsultstatus()
        {
            DataTable dt = new DataTable();
            objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
            objusercircles.Prefixtext = Search;
            objusercircles.proceduretype = "V";
            dt = UserCirclesDAO.GetUserCircleSearchREsult(objusercircles);

            if (dt.Rows.Count > 0)
            {
                Label1.Visible = true;
                Label1.Text = "Showing results for" + " " + "'" + MySession.Current.SearchNAme + "'";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "No results found for" + " " + "'" + MySession.Current.SearchNAme + "'";
                sptips.Visible = true;
                showtips.Style.Add("display", "block");
            }
        }

        private void GetMembersList()
        {
            try
            {
                DataTable dt = new DataTable();
                if (Convert.ToString(Request.QueryString["val"]) == "" || Convert.ToString(Request.QueryString["val"]) == null)
                {

                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.ID1 = MySession.Current.CircleId;
                    objAdminBAO.ProcedureType = "IM";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                    objusercircles.Prefixtext = Search;
                    objusercircles.proceduretype = "S";
                    dt = UserCirclesDAO.GetUserCircleSearchREsult(objusercircles);
                }

                if (dt.Rows.Count > 0)
                {
                    rptrFreindList.DataSource = dt;
                    rptrFreindList.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void GetMemebers()
        {
            try
            {
                DataTable dt = new DataTable();
                objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                objusercircles.Prefixtext = Search;
                objusercircles.proceduretype = "G";
                dt = UserCirclesDAO.GetUserCircleSearchREsult(objusercircles);
                if (dt.Rows.Count > 0)
                {
                    RpterCircle.DataSource = dt;
                    RpterCircle.DataBind();
                }
            }
            catch (Exception ex)
            { ex.ToString(); }

        }

        protected void rptrFreindList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    HiddenField hdnUserID = (HiddenField)e.Item.FindControl("hdnUserID");
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    ImageButton ImgFreind = (ImageButton)e.Item.FindControl("ImgFreind");
                    Label lbEMail = (Label)e.Item.FindControl("lbEMail");
                    Label lbPending = (Label)e.Item.FindControl("lbPending");
                    Button BtnInvite = (Button)e.Item.FindControl("BtnInvite");
                    DataTable dtStatus = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.ID1 = Convert.ToInt32(hdnUserID.Value);
                    objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.CircleId);
                    objAdminBAO.ProcedureType = "S";
                    dtStatus = AdminDAO.GetUserMemberStatus(objAdminBAO);
                    if (dtStatus.Rows.Count > 0)
                    {
                        if (Convert.ToString(dtStatus.Rows[0]["fk_request_status_id"]) == "3" || Convert.ToString(dtStatus.Rows[0]["fk_request_status_id"]) == "6")
                        {
                            BtnInvite.Visible = true;
                            lbPending.Visible = false;
                            BtnInvite.Text = "Invite";
                        }
                        else
                        {
                            BtnInvite.Visible = false;
                            lbPending.Visible = true;
                        }


                    }
                    else
                    {
                        BtnInvite.Visible = true;
                        lbPending.Visible = false;
                        BtnInvite.Text = "Invite";
                    }
                    if (hdnImage.Value == null || hdnImage.Value == "")
                    {
                        ImgFreind.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                    }
                    else
                    {
                        DataTable dtPhoto = new DataTable();
                        objusercircles.ID = Convert.ToInt32(hdnUserID.Value);
                        objusercircles.proceduretype = "GP";
                        dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                        if (dtPhoto.Rows.Count > 0)
                        {
                            if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                            {
                                ImgFreind.ImageUrl = "profile_image/" + hdnImage.Value;
                            }
                            else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                            {
                                ImgFreind.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                            }
                            else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                            {
                                ImgFreind.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                            }
                        }
                        else
                        {
                            ImgFreind.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                        }
                    }
                    DataTable dtEmail = new DataTable();
                    objusercircles.ID = Convert.ToInt32(hdnUserID.Value);
                    objusercircles.proceduretype = "GE1";
                    dtEmail = UserCirclesDAO.GetUserNameEmail(objusercircles);
                    if (dtEmail.Rows.Count > 0)
                    {
                        if (dtEmail.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                        {
                            lbEMail.Visible = false;
                        }
                        else if (dtEmail.Rows[0]["UPS_YOU"].ToString() == "True")
                        {
                            lbEMail.Visible = false;
                        }
                        else
                        {
                            lbEMail.Visible = true;
                        }

                    }
                    else
                    {
                        lbEMail.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

            }
        }


        protected void rptrFreindList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ImgFrendClick")
                {
                    string id1 = e.CommandArgument.ToString();

                    Session["USerProfile"] = true;
                    Response.Redirect("MyProfile.aspx?val=" + id1 + "&val2=1", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void btnInvite_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();

            Button lnk = (Button)sender;
            lnk.Text = "Sending..";
            RepeaterItem gvr = (RepeaterItem)lnk.NamingContainer;
            HiddenField hdnUserID = (HiddenField)gvr.FindControl("hdnUserID");
            Label lbPending = (Label)gvr.FindControl("lbPending");
            string id = hdnUserID.Value;
            DataTable dt = new DataTable();
            objAdminBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
            objAdminBAO.ProcedureType = "GC";
            dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["fk_circle_permission_id"].ToString() == "1")
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.friend_registration_id = Convert.ToInt32(id);
                    objusercircles.fk_circle_id = MySession.Current.CircleId;
                    objusercircles.request_status = 1;
                    objusercircles.updated_on = System.DateTime.Now;
                    objusercircles.proceduretype = "I";
                    UserCirclesDAO.SendFriendRequest(objusercircles);
                }
                else if (dt.Rows[0]["fk_circle_permission_id"].ToString() == "2")
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.friend_registration_id = Convert.ToInt32(id);
                    objusercircles.fk_circle_id = MySession.Current.CircleId;
                    objusercircles.request_status = 1;
                    objusercircles.updated_on = System.DateTime.Now;
                    objusercircles.proceduretype = "I";
                    UserCirclesDAO.SendFriendRequest(objusercircles);
                    //int retval = 0;
                    //objusercircles.CI_ID = 0;
                    //objusercircles.fk_login_id = Convert.ToInt32(MySession.Current.LoginId);
                    //objusercircles.freind_user_id = Convert.ToInt32(id);
                    //objusercircles.CI_MESSAGE = "This is my public circle , request you to join this circle.";
                    //objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                    //objusercircles.CI_DATE = DateTime.Now.ToString();
                    //objusercircles.CI_STATUS = "False";
                    //objusercircles.proceduretype = "I";
                    //retval = UserCirclesDAO.InsertCircleInvitation(objusercircles);
                }
                else if (dt.Rows[0]["fk_circle_permission_id"].ToString() == "3")
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.friend_registration_id = Convert.ToInt32(id);
                    objusercircles.fk_circle_id = MySession.Current.CircleId;
                    objusercircles.request_status = 7;
                    objusercircles.updated_on = System.DateTime.Now;
                    objusercircles.proceduretype = "I";
                    UserCirclesDAO.SendFriendRequest(objusercircles);
                }
            }
            lnk.Visible = false;
            lbPending.Visible = true;
            lbPending.Text = "Request Sent";

        }


        protected void RpterCircle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    HiddenField hdnColor = (HiddenField)e.Item.FindControl("hdnColor");
                    ImageButton imgtopcircle = (ImageButton)e.Item.FindControl("imgtopcircle");
                    HtmlGenericControl dvtopimagecircle = (HtmlGenericControl)e.Item.FindControl("dvtopimagecircle");
                    dvtopimagecircle.Style.Add("border", "3px solid #"+hdnColor.Value+" !important");
                    if (hdnImage.Value == "" || hdnImage.Value == null)
                    {
                        imgtopcircle.ImageUrl = "CircleImages/DefaultInnerCircle.jpg";
                    }
                    else
                    {
                        imgtopcircle.ImageUrl = "CircleImages/" + hdnImage.Value;
                    }

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }


        protected void RpterCircle_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "imgtopcircleClick")
                {
                    MySession.Current.searchfriendId = "";
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string id1 = arg[0];
                    string id2 = arg[1];
                    Session["USerProfile"] = true;
                    MySession.Current.PublicCircleUserId = id1;
                    MySession.Current.PublicCircleId = id2;
                    Response.Redirect("MyProfile.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}