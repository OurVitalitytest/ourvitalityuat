using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.BAL.User;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.Admin;
namespace ALEREIMPACT.User
{
    public partial class ucWall : System.Web.UI.UserControl
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        AdminBAO objAdminBAO = new AdminBAO();
        public static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (Request.QueryString["uid"] == null)
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = MySession.Current.CircleId;
                    objAdminBAO.ID1 = MySession.Current.LoginId;
                    objAdminBAO.ProcedureType = "GC";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        MySession.Current.UserCircleID = Convert.ToString(dt.Rows[0]["pk_user_circle_id"]);
                    }
                }
                else
                {
                    int userid = Convert.ToInt32(Request.QueryString["uid"].ToString());
                    int circleid = Convert.ToInt32(Request.QueryString["cid"].ToString());
                    string circlename = Convert.ToString(Request.QueryString["cnam"]);
                    string usercircleid = Convert.ToString(Request.QueryString["pk_usercircle_id"]);
                    MySession.Current.SelectedCircleUserId = Convert.ToInt32(userid).ToString();
                    MySession.Current.CircleId = Convert.ToInt32(circleid).ToString();
                    MySession.Current.SelectedCircleName = circlename;
                    MySession.Current.UserCircleID = Convert.ToInt32(usercircleid).ToString();
                    Session["bubbleId"] = Convert.ToString(Request.QueryString["selcir"]);
                }


                if (!Page.IsPostBack)
                {
                    MySession.Current.PageIndex = 1;
                    MySession.Current.PageSize = 0;

                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.SelectedCircleUserId), Convert.ToInt32(MySession.Current.CircleId), MySession.Current.PageIndex, MySession.Current.PageSize, Convert.ToInt32(MySession.Current.UserCircleID));

                    }
                    else
                    {

                        Bind_WallComments(Convert.ToInt32(MySession.Current.MemberUserId), Convert.ToInt32(MySession.Current.CircleId), MySession.Current.PageIndex, MySession.Current.PageSize, Convert.ToInt32(MySession.Current.UserCircleID));
                        DataTable dt = new DataTable();
                        objusercircles.UserId = MySession.Current.LoginId;
                        if (count == 0)
                        {
                            objusercircles.fk_circle_id = MySession.Current.MemberCircleId;
                            count = 1;
                        }
                        else
                        {
                            objusercircles.fk_circle_id = MySession.Current.CircleId;
                        }
                        objusercircles.proceduretype = "V";
                        dt = UserCirclesDAO.GetUserCircles(objusercircles);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                            {

                                dvpostcomments.Visible = true;
                                btnPostComments.Visible = true;
                            }
                            else
                            {

                                dvpostcomments.Visible = false;
                                btnPostComments.Visible = false;
                            }
                        }
                        else
                        {

                            dvpostcomments.Visible = false;
                            btnPostComments.Visible = false;
                        }
                    }

                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {

                    }
                    else
                    {

                        DataTable dt = new DataTable();
                        objusercircles.UserId = MySession.Current.LoginId;
                        if (count == 0)
                        {
                            objusercircles.fk_circle_id = MySession.Current.PublicCircleId;
                            count = 1;
                        }
                        else
                        {
                            objusercircles.fk_circle_id = MySession.Current.CircleId;
                        }
                        objusercircles.proceduretype = "V";
                        dt = UserCirclesDAO.GetUserCircles(objusercircles);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                            {
                                welcomemsg.Visible = true;
                                DivOtherCircle.Visible = false;
                                txtPostComments.ReadOnly = false;
                                btnPostComments.Enabled = true;
                                //btnPostComments.Style.Add("cursor", "not-allowed");
                            }
                            else
                            {
                                welcomemsg.Visible = false;
                                DivOtherCircle.Visible = true;
                                txtPostComments.ReadOnly = true;
                                btnPostComments.Enabled = false;
                                btnPostComments.Style.Add("cursor", "not-allowed");
                            }
                        }
                        else
                        {
                            welcomemsg.Visible = false;
                            DivOtherCircle.Visible = true;
                            txtPostComments.ReadOnly = true;
                            btnPostComments.Enabled = false;
                            btnPostComments.Style.Add("cursor", "not-allowed");
                        }
                        Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId), MySession.Current.PageIndex, MySession.Current.PageSize, Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Bind_WallComments(int LoginId, Int32 CircleId, Int32 PageIndex, Int32 PageSize, Int32 UserCircleId)
        {
            try
            {
                grdComments.DataSource = null;
                grdComments.DataBind();

                DataTable dtComments = new DataTable();
                dtComments = UserCommentsDAL.GetWallComments(LoginId, CircleId, PageIndex, PageSize, UserCircleId);


                if (dtComments.Rows.Count == 0)
                {
                    grdComments.DataSource = null;
                    grdComments.DataBind();


                    lbUsrFirstName.Text = Convert.ToString(MySession.Current.UserFirstName);
                    if (MySession.Current.SelectedCircleName == null || MySession.Current.SelectedCircleName == "")
                    {
                        lbwelcomecircle.Text = "Inner Circle";
                    }
                    else
                    {
                        lbwelcomecircle.Text = Convert.ToString(MySession.Current.SelectedCircleName);
                    }


                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {
                            DataTable dt = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ID1 = Convert.ToInt32(MySession.Current.CircleId);
                            objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.UserCircleID);
                            objAdminBAO.ProcedureType = "V";
                            dt = AdminDAO.GetUserMemberStatus(objAdminBAO);
                            if (dt.Rows.Count > 0)
                            {
                                lbwelcomecircle.Text = dt.Rows[0]["circle_name"].ToString();
                                welcomemsg.Visible = true;
                                lnkInvite.Visible = true;
                            }
                            else
                            {
                                welcomemsg.Visible = true;
                                lnkInvite.Visible = false;
                            }
                        }
                    }
                    else
                    {

                        grdComments.DataSource = null;
                        grdComments.DataBind();
                        welcomemsg.Visible = false;
                        lbwelcomemembercircle.Text = Convert.ToString(MySession.Current.SelectedCircleName);
                        lbUserMemberName.Text = Convert.ToString(MySession.Current.UserFirstName);
                        dvmember.Visible = true;

                    }

                }
                else
                {
                    welcomemsg.Visible = false;

                    grdComments.DataSource = dtComments;
                    grdComments.DataBind();
                }

                if (dtComments != null)
                {
                    if (dtComments.Rows.Count > 0)
                    {
                        MySession.Current.RowsGenerated = Convert.ToInt32(dtComments.Rows[0]["RowsGenerated"]);
                        if (MySession.Current.RowsGenerated == dtComments.Rows.Count)
                        {
                            lnkViewMore.Visible = false;
                        }
                        else
                        {
                            //HtmlGenericControl dvFooter = Page.Master.FindControl("ContentPlaceHolder1").FindControl("dvFooter") as HtmlGenericControl;
                            //string topMargin = PageSize.ToString();
                            //dvFooter.Style.Add("margin-top", topMargin);

                            lnkViewMore.Visible = true;
                        }
                    }
                    else
                    {
                        lnkViewMore.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnPostComments_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                ObjUserCommentsBAL.PostedComments = txtPostComments.Text.Trim();
                ObjUserCommentsBAL.MajorCommentId = 0;

                ObjUserCommentsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId); // to be changed at the circle click

                ObjUserCommentsBAL.UserCircleId = Convert.ToInt32(MySession.Current.UserCircleID);
                DataTable dt = UserCommentsDAL.PostComments(ObjUserCommentsBAL);

                ////*** insert notes notification****////
                DataTable dtUser = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                objAdminBAO.ProcedureType = "CU";
                dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dtUser.Rows.Count > 0)
                {
                    if (dtUser.Rows[0]["fk_user_registration_Id"].ToString() == MySession.Current.LoginId)
                    {

                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objusercircles.fk_circle_id = MySession.Current.CircleId;
                        objusercircles.proceduretype = "S";
                        DataTable dtFriends = new DataTable();
                        dtFriends = UserCirclesDAO.GetFriendList(objusercircles);
                        if (dtFriends.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtFriends.Rows.Count; i++)
                            {
                                if (dtFriends.Rows[i]["userid"].ToString() != Convert.ToString(MySession.Current.LoginId))
                                {
                                    int retvalInsp = 0;
                                    ObjUserCommentsBAL.NOTESN_ID = 0;
                                    ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(dt.Rows[0]["pk_comment_id"]);
                                    ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(dtFriends.Rows[i]["userid"].ToString());
                                    ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                                    ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "False";
                                    ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "True";
                                    ObjUserCommentsBAL.LIKE_STATUS = "";
                                    ObjUserCommentsBAL.ProcedureType = "I";
                                    retvalInsp = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                                    if (retvalInsp != 0)
                                    {
                                        string name = "";
                                        string email = "";
                                        string name1 = "";
                                        string Circlename = "";
                                        //DataTable dtUser = new DataTable();
                                        //objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                        //objAdminBAO.ProcedureType = "CU";
                                        //dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                        //if (dtUser.Rows.Count > 0)
                                        //{
                                        Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                        //}
                                        DataTable dtName = new DataTable();
                                        objAdminBAO.ID = Convert.ToInt32(dtFriends.Rows[i]["userid"].ToString());
                                        objAdminBAO.ProcedureType = "NE";
                                        dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                        if (dtName.Rows.Count > 0)
                                        {
                                            name = dtName.Rows[0]["name"].ToString();
                                            email = dtName.Rows[0]["login_email"].ToString();
                                        }
                                        DataTable dtName1 = new DataTable();
                                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                        objAdminBAO.ProcedureType = "NE";
                                        dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                        if (dtName1.Rows.Count > 0)
                                        {
                                            name1 = dtName1.Rows[0]["name"].ToString();
                                        }
                                        string Subject = name1 + " posted a note in Circle : " + Circlename;
                                        string body = "Hi " + name + ",<br /><br />" + name1 + " posted a note in  Circle :" + " '" + Circlename + "' " + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                        ClsGeneric objClsGeneric = new ClsGeneric();
                                        objClsGeneric.SendMail(email, body, Subject);
                                    }
                                }
                            }

                        }
                    }



                    else
                    {
                        int retval = 0;
                        ObjUserCommentsBAL.NOTESN_ID = 0;
                        ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(dt.Rows[0]["pk_comment_id"]);
                        ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                        ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                        ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "False";
                        ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "True";
                        ObjUserCommentsBAL.LIKE_STATUS = "";
                        ObjUserCommentsBAL.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                        if (retval != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " posted a Note in your circle";
                            string body = "Hi " + name + ",<br /><br />" + name1 + " has posted note in your" + " ' " + Circlename + " ' " + "space" + "<br /><br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                            ClsGeneric objClsGeneric = new ClsGeneric();
                            objClsGeneric.SendMail(email, body, Subject);

                        }

                    }
                }
                Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId),
                    Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));



                txtPostComments.Text = "Whats on your mind?";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void grdSubComments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbIDIUser = (Label)e.Row.FindControl("lbIDIUser");
                    LinkButton lnkLikeSubComment = (LinkButton)e.Row.FindControl("lnkLikeSubComment");
                    ImageButton lnkSuperLikeSubComment = (ImageButton)e.Row.FindControl("lnkSuperLikeSubComment");
                    ScriptManager current = ScriptManager.GetCurrent(Page);
                    if (current != null)
                        current.RegisterPostBackControl(lnkLikeSubComment);


                    string SubCommentId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SubCommentID"));
                    LinkButton lnkLike = (LinkButton)e.Row.FindControl("lnkLikeSubComment");
                    ImageButton lnkSuperLike = (ImageButton)e.Row.FindControl("lnkSuperLikeSubComment");

                    Image imgSubCommentSenderImage = (Image)e.Row.FindControl("imgSubCommentSenderImage");
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage")) == "" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage")) == null)
                    {
                        imgSubCommentSenderImage.ImageUrl = "../User/profile_image/profileBlankPhoto.jpg";
                    }
                    else
                    {
                        if (MySession.Current.LoginId == Convert.ToString(lbIDIUser.Text))
                        {
                            imgSubCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(lbIDIUser.Text);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    imgSubCommentSenderImage.ImageUrl = "../User/profile_image/profileBlankPhoto.jpg";
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    imgSubCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                                }
                                else if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    imgSubCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                                }
                            }
                            else
                            {
                                imgSubCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                            }
                        }
                    }
                    DataTable dt = UserCommentsDAL.GetLikeStatus(Convert.ToInt32(SubCommentId), Convert.ToInt32(MySession.Current.LoginId));
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["LikeStatus"].ToString() == "2")
                        {
                            lnkLike.Visible = true;
                        }
                        else
                        {
                            lnkLike.Enabled = false;
                            lnkLike.Text = "Liked";
                        }
                    }

                    DataTable dtSuperLike = UserCommentsDAL.GetSuperLikeStatus(Convert.ToInt32(SubCommentId), Convert.ToInt32(MySession.Current.LoginId));
                    if (dtSuperLike.Rows.Count > 0)
                    {
                        if (dtSuperLike.Rows[0]["LikeStatus"].ToString() == "2")
                        {
                            lnkSuperLike.Visible = true;
                        }
                        else
                        {
                            lnkSuperLike.Enabled = false;

                        }
                    }
                    DataTable dtLikeCount = UserCommentsDAL.GetLikeCount(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SubCommentID")));
                    if (dtLikeCount != null)
                    {
                        if (dtLikeCount.Rows.Count > 0)
                        {
                            Image imgThumbsUp = (Image)e.Row.FindControl("imgThumbsUpSubComments");
                            Label lblCountSubCommentsLikes = (Label)e.Row.FindControl("lblCountSubCommentsLikes");

                            if (Convert.ToString(dtLikeCount.Rows[0]["LikeCount"]) != "0")
                                lblCountSubCommentsLikes.Text = dtLikeCount.Rows[0]["LikeCount"].ToString();
                            else
                                lblCountSubCommentsLikes.Text = "0";
                        }
                    }
                    DataTable dtSuperLikeCount = UserCommentsDAL.GetSuperLikeCount(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SubCommentID")));
                    if (dtSuperLikeCount != null)
                    {
                        if (dtSuperLikeCount.Rows.Count > 0)
                        {
                            Label lblCountSubCommentsSuperLikes = (Label)e.Row.FindControl("lblCountSubCommentsSuperLikes");

                            if (Convert.ToString(dtSuperLikeCount.Rows[0]["LikeCount"]) != "0")
                                lblCountSubCommentsSuperLikes.Text = dtSuperLikeCount.Rows[0]["LikeCount"].ToString();
                            else
                                lblCountSubCommentsSuperLikes.Text = "0";
                        }
                    }
                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {

                        }
                        else
                        {
                            lnkLike.Text = "Like";
                            lnkLike.Enabled = false;
                            lnkSuperLike.Enabled = false;
                        }
                    }
                    else
                    {
                        lnkLike.Text = "Like";
                        lnkLike.Enabled = false;
                        lnkSuperLike.Enabled = false;
                    }


                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void rptComments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Find Controls in gridview
                    LinkButton lnkLike = (LinkButton)e.Row.FindControl("lnkLike");
                    LinkButton lnkPostSubComment = (LinkButton)e.Row.FindControl("lnkPostSubComment");
                    ImageButton lnkSupeLike = (ImageButton)e.Row.FindControl("lnkSupeLike");
                    ImageButton imgCloseSubCommentBox = (ImageButton)e.Row.FindControl("imgCloseSubCommentBox");
                    Label lbUserid = (Label)e.Row.FindControl("lbUserid");
                    //Without Page refresh
                    ScriptManager current = ScriptManager.GetCurrent(Page);
                    if (current != null)
                        current.RegisterPostBackControl(lnkLike);
                    current.RegisterPostBackControl(lnkPostSubComment);
                    current.RegisterPostBackControl(imgCloseSubCommentBox);


                    string MajorCommentId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PrimaryKeyOfComment"));

                    GridView grdSubComments = (GridView)e.Row.FindControl("grdSubComments");


                    GridViewRow ParentRow = (GridViewRow)grdSubComments.NamingContainer;
                    DataTable dtSubComments = new DataTable();
                    dtSubComments = UserCommentsDAL.GetSubComments(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PrimaryKeyOfComment")));

                    Image imgCommentSenderImage = (Image)e.Row.FindControl("imgCommentSenderImage");
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage")) == "" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage")) == null)
                    {
                        imgCommentSenderImage.ImageUrl = "../User/profile_image/profileBlankPhoto.jpg";
                    }
                    else
                    {
                        if (MySession.Current.LoginId == Convert.ToString(lbUserid.Text))
                        {
                            imgCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(lbUserid.Text);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    imgCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    imgCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    if (MySession.Current.LoginId == Convert.ToString(lbUserid.Text))
                                    {
                                        imgCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                                    }
                                    else
                                    {
                                        imgCommentSenderImage.ImageUrl = "../User/profile_image/profileBlankPhoto.jpg";
                                    }
                                }
                            }
                            else
                            {
                                imgCommentSenderImage.ImageUrl = "../User/profile_image/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserProfileImage"));
                            }
                        }
                    }
                    HtmlGenericControl dvSubComment = (HtmlGenericControl)e.Row.FindControl("dvSubComment");
                    Label lblCountSubComments = (Label)e.Row.FindControl("lblCountSubComments");

                    if (dtSubComments.Rows.Count > 0)
                    {
                        lblCountSubComments.Text = dtSubComments.Rows.Count.ToString();
                        grdSubComments.DataSource = dtSubComments;
                        grdSubComments.DataBind();
                        dvSubComment.Visible = true;
                    }
                    else
                    {
                        lblCountSubComments.Text = "0";
                        dvSubComment.Visible = false;
                    }


                    UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                    UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                    ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserCommentsBAL.PostedComments = txtPostComments.Text.Trim();
                    ObjUserCommentsBAL.MajorCommentId = 0;

                    ObjUserCommentsBAL.CircleId = 1; // to be changed at the circle click

                    DataTable dt = UserCommentsDAL.GetLikeStatus(Convert.ToInt32(MajorCommentId), Convert.ToInt32(MySession.Current.LoginId));
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["LikeStatus"].ToString() == "2")
                        {
                            lnkLike.Visible = true;
                        }
                        else
                        {
                            lnkLike.Enabled = false;
                            lnkLike.Text = "Liked";
                        }
                    }

                    DataTable dtLikeCount = UserCommentsDAL.GetLikeCount(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PrimaryKeyOfComment")));
                    if (dtLikeCount != null)
                    {
                        if (dtLikeCount.Rows.Count > 0)
                        {
                            Image imgThumbsUp = (Image)e.Row.FindControl("imgThumbsUp");

                            if (Convert.ToString(dtLikeCount.Rows[0]["LikeCount"]) != "0")
                            {
                                Label lblCountLikes = (Label)e.Row.FindControl("lblCountLikes");
                                lblCountLikes.Text = dtLikeCount.Rows[0]["LikeCount"].ToString();

                                imgThumbsUp.Visible = true;
                            }
                            else
                            {
                                imgThumbsUp.Visible = false;
                            }
                        }
                    }


                    DataTable dtsuperlike = UserCommentsDAL.GetSuperLikeStatus(Convert.ToInt32(MajorCommentId), Convert.ToInt32(MySession.Current.LoginId));
                    if (dtsuperlike.Rows.Count > 0)
                    {
                        if (dtsuperlike.Rows[0]["LikeStatus"].ToString() == "2")
                        {
                            lnkSupeLike.Visible = true;
                        }
                        else
                        {
                            lnkSupeLike.Enabled = false;
                            // lnkSupeLike.Text = "Liked";
                        }
                    }
                    DataTable dtSuperLikeCount = UserCommentsDAL.GetSuperLikeCount(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PrimaryKeyOfComment")));
                    if (dtSuperLikeCount != null)
                    {
                        if (dtSuperLikeCount.Rows.Count > 0)
                        {
                            Image imgThumbSuper = (Image)e.Row.FindControl("imgThumbSuper");

                            if (Convert.ToString(dtSuperLikeCount.Rows[0]["LikeCount"]) != "0")
                            {
                                Label lbSuperLike = (Label)e.Row.FindControl("lbSuperLike");
                                lbSuperLike.Text = dtSuperLikeCount.Rows[0]["LikeCount"].ToString();

                                imgThumbSuper.Visible = true;
                            }
                            else
                            {
                                imgThumbSuper.Visible = false;
                            }
                        }
                    }
                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {

                        }
                        else
                        {
                            lnkLike.Text = "Like";
                            lnkLike.Enabled = false;
                            lnkSupeLike.Enabled = false;
                            lnkPostSubComment.Enabled = false;
                        }
                    }
                    else
                    {
                        lnkLike.Text = "Like";
                        lnkLike.Enabled = false;
                        lnkPostSubComment.Enabled = false;
                        lnkSupeLike.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdComments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
                if (e.CommandName == "PostComment")
                {
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    TextBox txtSubComments = (TextBox)row.Cells[0].FindControl("txtSubComments");
                    DataTable dt = new DataTable();
                    string commArg = Convert.ToString(e.CommandArgument);
                    UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                    UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                    ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserCommentsBAL.PostedComments = txtSubComments.Text.Trim();
                    ObjUserCommentsBAL.MajorCommentId = Convert.ToInt32(commArg);
                    ObjUserCommentsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    dt = UserCommentsDAL.PostComments(ObjUserCommentsBAL);
                    ////*** insert notes notification****////
                    DataTable dtUser = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        int retval = 0;
                        ObjUserCommentsBAL.NOTESN_ID = 0;
                        ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                        ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(ObjUserCommentsBAL.LoginId);
                        ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                        ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "False";
                        ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "Subcomment";
                        ObjUserCommentsBAL.LIKE_STATUS = "";
                        ObjUserCommentsBAL.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                        if (retval != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + "comments on your note";
                            string body = "Hi " + name + ",<br /><br />" + name1 + " comments on your note in Circle :" + " ' " + Circlename + " ' " + "space" + "<br /><br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                            ClsGeneric objClsGeneric = new ClsGeneric();
                            objClsGeneric.SendMail(email, body, Subject);

                        }
                    }
                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                    else
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId),
                           Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                }
                if (e.CommandName == "LikeComment")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    string commArg = Convert.ToString(e.CommandArgument);

                    UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                    UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                    ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserCommentsBAL.MajorCommentId = Convert.ToInt32(commArg);

                    UserCommentsDAL.LikeComments(Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId), Convert.ToInt32(ObjUserCommentsBAL.LoginId));
                    DataTable dtUser = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        int retval = 0;
                        ObjUserCommentsBAL.NOTESN_ID = 0;
                        ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                        ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(ObjUserCommentsBAL.LoginId);
                        ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                        ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "True";
                        ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "True";
                        ObjUserCommentsBAL.LIKE_STATUS = "False";
                        ObjUserCommentsBAL.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                        if (retval != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " liked Note ";
                            string body = "Hi " + name + ",<br /><br />" + name1 + " likes your note posted in Circle " + " ' " + Circlename + " ' " + "space" + "<br /><br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                            ClsGeneric objClsGeneric = new ClsGeneric();
                            objClsGeneric.SendMail(email, body, Subject);

                        }

                    }
                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                    else
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId),
                          Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                }
                if (e.CommandName == "lnkSuperlike")
                {
                    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                    string commArg = Convert.ToString(e.CommandArgument);

                    UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                    UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                    ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserCommentsBAL.MajorCommentId = Convert.ToInt32(commArg);

                    UserCommentsDAL.SuperLikeComments(Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId), Convert.ToInt32(ObjUserCommentsBAL.LoginId));
                    DataTable dtUser = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        int retval = 0;
                        ObjUserCommentsBAL.NOTESN_ID = 0;
                        ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                        ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(ObjUserCommentsBAL.LoginId);
                        ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                        ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "True";
                        ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "Supported";
                        ObjUserCommentsBAL.LIKE_STATUS = "";
                        ObjUserCommentsBAL.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                        if (retval != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " Supported Note ";
                            string body = "Hi " + name + ",<br /><br />" + name1 + " Supports your note posted in Circle " + " ' " + Circlename + " ' " + "space" + "<br /><br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                            ClsGeneric objClsGeneric = new ClsGeneric();
                            objClsGeneric.SendMail(email, body, Subject);

                        }

                    }
                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                    else
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId),
                          Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                }
                if (e.CommandName == "ClikedToPostSubComment")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    LinkButton lnkPostSubComment = (LinkButton)row.FindControl("lnkPostSubComment");
                    Panel dvPostSubComment = (Panel)row.Cells[0].FindControl("dvPostSubComment");
                    HtmlGenericControl dvPostSubCommentOnMajor = (HtmlGenericControl)row.FindControl("dvPostSubCommentOnMajor");

                    if (lnkPostSubComment.Text == "Comment")
                    {
                        dvPostSubComment.Visible = true;
                        dvPostSubCommentOnMajor.Visible = false;
                    }
                    else
                    {
                        dvPostSubComment.Visible = false;
                        dvPostSubCommentOnMajor.Visible = true;
                    }
                }
                if (e.CommandName == "CloseSubCommentBox")
                {
                    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                    HtmlGenericControl dvPostSubCommentOnMajor = (HtmlGenericControl)row.FindControl("dvPostSubCommentOnMajor");
                    Panel dvPostSubComment = (Panel)row.Cells[0].FindControl("dvPostSubComment");
                    TextBox txtSubComments = (TextBox)row.Cells[0].FindControl("txtSubComments");
                    dvPostSubComment.Visible = false;
                    dvPostSubCommentOnMajor.Visible = true;
                }
                if (e.CommandName == "MemberProfile")
                {
                    Session["USerProfile"] = true;

                    Response.Redirect("~/User/MyProfile.aspx?val=" + e.CommandArgument.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grdSubComments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
                if (e.CommandName == "PostSubComment")
                {
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    TextBox txtSubComments = (TextBox)row.Cells[0].FindControl("txtSubComments");

                    Button btnPostSubComment = (Button)row.FindControl("btnPostSubComment");
                    // ImageButton imgCloseSubCommentBox = (ImageButton)row.FindControl("imgCloseSubCommentBox");
                    //Without Page refresh
                    ScriptManager current = ScriptManager.GetCurrent(Page);
                    if (current != null)
                        current.RegisterAsyncPostBackControl(btnPostSubComment);
                    DataTable dt = new DataTable();
                    string commArg = Convert.ToString(e.CommandArgument);
                    UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                    UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                    ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserCommentsBAL.PostedComments = txtSubComments.Text.Trim();
                    ObjUserCommentsBAL.MajorCommentId = Convert.ToInt32(commArg);
                    ObjUserCommentsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);

                    dt = UserCommentsDAL.PostComments(ObjUserCommentsBAL);
                    ////*** insert notes notification****////
                    DataTable dtUser = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        int retval = 0;
                        ObjUserCommentsBAL.NOTESN_ID = 0;
                        ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                        ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(ObjUserCommentsBAL.LoginId);
                        ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                        ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "False";
                        ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "Subcomment";
                        ObjUserCommentsBAL.LIKE_STATUS = "";
                        ObjUserCommentsBAL.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                        if (retval != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " comments on your note";
                            string body = "Hi " + name + ",<br /><br />" + name1 + " comments on your note in Circle :" + " ' " + Circlename + " ' " + "space" + "<br /><br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                            ClsGeneric objClsGeneric = new ClsGeneric();
                            objClsGeneric.SendMail(email, body, Subject);

                        }


                    }
                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                    else
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId),
                       Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                }

                if (e.CommandName == "LikeSubComment")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    string commArg = Convert.ToString(e.CommandArgument);

                    UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                    UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                    ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserCommentsBAL.MajorCommentId = Convert.ToInt32(commArg);

                    UserCommentsDAL.LikeComments(Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId), Convert.ToInt32(ObjUserCommentsBAL.LoginId));
                    DataTable dtUser = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        int retval = 0;
                        ObjUserCommentsBAL.NOTESN_ID = 0;
                        ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                        ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(ObjUserCommentsBAL.LoginId);
                        ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                        ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "True";
                        ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "True";
                        ObjUserCommentsBAL.LIKE_STATUS = "False";
                        ObjUserCommentsBAL.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                        if (retval != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " liked Note ";
                            string body = "Hi " + name + ",<br /><br />" + name1 + " likes your note posted in Circle" + " ' " + Circlename + " ' " + "space" + "<br /><br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                            ClsGeneric objClsGeneric = new ClsGeneric();
                            objClsGeneric.SendMail(email, body, Subject);

                        }

                    }
                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                    else
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                }

                if (e.CommandName == "SuperLikeSubComment")
                {
                    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                    string commArg = Convert.ToString(e.CommandArgument);

                    UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                    UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                    ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserCommentsBAL.MajorCommentId = Convert.ToInt32(commArg);

                    UserCommentsDAL.SuperLikeComments(Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId), Convert.ToInt32(ObjUserCommentsBAL.LoginId));
                    DataTable dtUser = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        int retval = 0;
                        ObjUserCommentsBAL.NOTESN_ID = 0;
                        ObjUserCommentsBAL.fk_comment_id = Convert.ToInt32(ObjUserCommentsBAL.MajorCommentId);
                        ObjUserCommentsBAL.fk_user_registration_id = Convert.ToInt32(ObjUserCommentsBAL.LoginId);
                        ObjUserCommentsBAL.NOTESN_DATE = DateTime.Now.ToString();
                        ObjUserCommentsBAL.NOTESN_NOTIFICATION_STATUS = "True";
                        ObjUserCommentsBAL.NOTES_EMAIL_STATUS = "Supported";
                        ObjUserCommentsBAL.LIKE_STATUS = "";
                        ObjUserCommentsBAL.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblNotesNotification(ObjUserCommentsBAL);
                        if (retval != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"]);
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " Supported Note ";
                            string body = "Hi " + name + ",<br /><br />" + name1 + " Supports your note posted in Circle" + " ' " + Circlename + " ' " + "space" + "<br /><br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                            ClsGeneric objClsGeneric = new ClsGeneric();
                            objClsGeneric.SendMail(email, body, Subject);

                        }

                    }
                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                    else
                    {
                        Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId),
                        Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkViewMore_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                MySession.Current.PageSize += 5;

                //HtmlGenericControl dvIframe = (HtmlGenericControl)cachedHeader.FindControl("iframeProfile");

                //dvIframe.Style.Add(HtmlTextWriterStyle.MarginTop, "400px");


                //dvFooter.Height = new Unit(1000);
                //Unit sjj = dvFooter.Height;
                if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                {
                    Bind_WallComments(Convert.ToInt32(MySession.Current.LoginId), Convert.ToInt32(MySession.Current.CircleId), Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
                }
                else
                {
                    Bind_WallComments(Convert.ToInt32(MySession.Current.PublicCircleUserId), Convert.ToInt32(MySession.Current.CircleId), Convert.ToInt32(MySession.Current.PageIndex), Convert.ToInt32(MySession.Current.PageSize), Convert.ToInt32(MySession.Current.UserCircleID));
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkInvite_Click(object sender, EventArgs e)
        {
            Response.Redirect("InviteMembers.aspx", false);
        }


    }
}