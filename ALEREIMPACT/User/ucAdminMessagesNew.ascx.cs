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
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;

namespace ALEREIMPACT.User
{
    public partial class ucAdminMessagesNew : System.Web.UI.UserControl
    {

        UserCommentsBAL objUserCommentsBal = new UserCommentsBAL();
        UserMissionsBAL objUserMissionBAL = new UserMissionsBAL();
        UserCirclesBAO objUserCircleBAO = new UserCirclesBAO();
        public static Int32 id = 0;
        public static Int32 msgid = 0;
        public static Int32 requestid = 0;
        public static string sender_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                Page.MaintainScrollPositionOnPostBack = true;

                Session["show_admin_posed_messages"] = "True";
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                    //Response.Redirect("~/Login.aspx", false);

                }
                else
                {
                    if (!IsPostBack)
                    {
                        if (Session["show_admin_posed_messages"] != null)
                        {
                            if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                            {
                                if (Session["msgid"] == null || Session["msgid"].ToString() == "")
                                {

                                    bindAllAdminMessage();
                                    Panel1.Visible = false;
                                    PanelMissionInvitation.Visible = false;
                                    PanelReply.Visible = true;
                                    PanelRequested.Visible = false;
                                }
                                else
                                {
                                    msgid = Convert.ToInt32(Session["msgid"]);
                                    bindAllAdminMessage();
                                    if (Convert.ToString(Session["User_name"]) == "Alere Vitality")
                                    {
                                        panelRequestedUnresc.Visible = false;
                                        bindAdminMessage();
                                        binReplyMessages();
                                        Panel1.Visible = true;
                                        PanelRequested.Visible = false;
                                        PanelMissionInvitation.Visible = false;
                                    }
                                    else if (Convert.ToString(Session["request_id"]) == "1")
                                    {
                                        panelRequestedUnresc.Visible = false;
                                        Panel1.Visible = false;
                                        PanelRequested.Visible = false;
                                        PanelMissionInvitation.Visible = true;
                                        bindMissionInvitation();
                                    }
                                    else if (Convert.ToString(Session["request_id"]) == "3")
                                    {
                                        panelRequestedUnresc.Visible = true;
                                        Panel1.Visible = false;
                                        PanelMissionInvitation.Visible = false;
                                        PanelRequested.Visible = false;
                                        bindUnresc();
                                    }
                                    else
                                    {
                                        panelRequestedUnresc.Visible = false;
                                        Panel1.Visible = false;
                                        PanelMissionInvitation.Visible = false;
                                        PanelRequested.Visible = true;
                                        bindCirclerequested();
                                    }
                                    PanelReply.Visible = false;
                                    divreply.Style.Add("display", "");
                                }
                            }

                            else
                            {
                                bindAllAdminMessage();
                                Panel1.Visible = false;
                                PanelMissionInvitation.Visible = false;
                                PanelReply.Visible = true;

                            }
                            Session["show_admin_posed_messages"] = null;
                            Session["msgid"] = null;
                            Session["User_name"] = null;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void RegisterClientScriptFile(ucAdminMessagesNew ucAdminMessagesNew, string p, string p_3, bool p_4)
        {
            throw new NotImplementedException();
        }
        private void bindAllAdminMessage()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.PostedComments = "";
                objUserCommentsBal.ReplyToAdminMessageId = 0;
                objUserCommentsBal.RequestTypeId = 1;
                dt = UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                if (dt.Rows.Count > 0)
                {
                    lbNoMsg.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    lbNoMsg.Visible = true;
                    Label21.Visible = true;
                    Label8.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindMissionInvitation()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.PostedComments = "";
                objUserCommentsBal.ReplyToAdminMessageId = msgid;
                objUserCommentsBal.RequestTypeId = 5;
                dt = UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                GridView4.DataSource = dt;
                GridView4.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void bindUnresc()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.PostedComments = "";
                objUserCommentsBal.ReplyToAdminMessageId = msgid;
                objUserCommentsBal.RequestTypeId = 7;
                dt = UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                GridView6.DataSource = dt;
                GridView6.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {
                string[] strArg = e.CommandArgument.ToString().Split(new char[] { ';' });
                int senderId = Convert.ToInt32(strArg[0]);
                int circleId = Convert.ToInt32(strArg[1]);

                objUserCircleBAO.fk_user_registration_Id = senderId;
                objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.fk_circle_id = circleId;
                objUserCircleBAO.request_status = 2; //Accept Request
                objUserCircleBAO.updated_on = System.DateTime.Now;
                objUserCircleBAO.proceduretype = "I";
                UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);

                MySession.Current.SelectedCircleUserId = Convert.ToString(senderId);
                MySession.Current.CircleId = Convert.ToString(circleId);
                Session["NewcircleId"] = MySession.Current.CircleId; // Select Circle ID
                Session["Topselcircle"] = MySession.Current.CircleId;//to display circle name at top
                MySession.Current.PublicCircleUserId = "";
                MySession.Current.PublicCircleId = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow3", "parentwindow3();", true);
            }
            else if (e.CommandName == "RedirectToCircle")
            {
                MySession.Current.PublicCircleUserId = "";
                MySession.Current.PublicCircleId = "";
                string[] strArg = e.CommandArgument.ToString().Split(new char[] { ';' });
                int senderId = Convert.ToInt32(strArg[0]);
                int circleId = Convert.ToInt32(strArg[1]);

                Session["USerProfile"] = true;
                MySession.Current.PublicCircleUserId = senderId.ToString();
                MySession.Current.PublicCircleId = circleId.ToString();

                Response.Redirect("~/User/MyProfile.aspx",false);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkMessage")
                {
                    Panel1.Visible = true;
                    PanelReply.Visible = false;
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(',');
                    Session["msg_id"] = arg[0];
                    Session["User_name"] = arg[1];
                    Session["request_id"] = arg[2];
                    msgid = Convert.ToInt32(Session["msg_id"]);
                    sender_name = Convert.ToString(Session["User_name"]);
                    requestid = Convert.ToInt32(Session["request_id"]);
                    if (sender_name == "Alere Vitality")
                    {
                        bindAdminMessage();
                        binReplyMessages();
                        if (MySession.Current.SelectedCircleUserId == MySession.Current.LoginId)
                        {
                            divreply.Style.Add("display", "");
                        }
                        else
                        {
                            divreply.Style.Add("display", "none");
                        }
                        int retval = 0;
                        objUserCommentsBal.GMU_ID = 0;
                        objUserCommentsBal.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserCommentsBal.GM_ID_FK = msgid;
                        objUserCommentsBal.ProcedureType = "I";
                        retval = UserCommentsDAL.InserttblGlobalMessageRead(objUserCommentsBal);
                        // scrollArea.Attributes.Add("onclick", "SaveScrollPos()");
                    }
                    else if (requestid == 1)
                    {
                        DataTable dt = new DataTable();
                        objUserCommentsBal.ID = msgid;
                        objUserCommentsBal.ProcedureType = "MI";
                        dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                        if (dt.Rows.Count > 0)
                        {
                            objUserMissionBAL.Pk_mission_Invitation = msgid;
                            objUserMissionBAL.LoginId = Convert.ToInt32(dt.Rows[0]["fk_invited_by"]);
                            objUserMissionBAL.AllFriends_Id = (MySession.Current.LoginId);
                            objUserMissionBAL.MissionId = Convert.ToInt32(dt.Rows[0]["fk_mission_id"]);
                            objUserMissionBAL.CircleId = Convert.ToInt32(dt.Rows[0]["fk_circle_id"]);
                            objUserMissionBAL.InvitationMessage = dt.Rows[0]["inivitation_message"].ToString();
                            objUserMissionBAL.TypeOfRequest = 3;
                            objUserMissionBAL.Mission_Invitation_Status = false;
                            objUserMissionBAL.InvitationRead_Status = true;
                            UserMissionsDAL.SendMissionInvitation(objUserMissionBAL);

                        }



                    }
                    else if (requestid == 3)
                    {
                        DataTable dt = new DataTable();
                        objUserCommentsBal.ID = msgid;
                        objUserCommentsBal.ProcedureType = "CIM";
                        dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                        if (dt.Rows.Count > 0)
                        {
                            int retval = 0;
                            objUserCircleBAO.CI_ID = 0;
                            objUserCircleBAO.fk_login_id = Convert.ToInt32(dt.Rows[0]["fk_login_id"]);
                            objUserCircleBAO.freind_user_id = Convert.ToInt32(MySession.Current.LoginId);
                            objUserCircleBAO.CI_MESSAGE = dt.Rows[0]["CI_MESSAGE"].ToString();
                            objUserCircleBAO.fk_circle_id = Convert.ToInt32(dt.Rows[0]["fk_circle_id"]);
                            objUserCircleBAO.CI_DATE = dt.Rows[0]["CI_DATE"].ToString();
                            objUserCircleBAO.CI_STATUS = "True";
                            objUserCircleBAO.proceduretype = "U";
                            retval = UserCirclesDAO.InsertCircleInvitation(objUserCircleBAO);
                        }
                    }
                    else
                    {

                    }
                    Session["msgid"] = msgid;
                    Session["show_admin_posed_messages"] = "True";
                    Response.Redirect("AdminMessagesFront.aspx", false);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void bindAdminMessage()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.PostedComments = "";
                objUserCommentsBal.ReplyToAdminMessageId = msgid;
                objUserCommentsBal.RequestTypeId = 4;
                dt = UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void binReplyMessages()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.PostedComments = "";
                objUserCommentsBal.ReplyToAdminMessageId = msgid;
                objUserCommentsBal.RequestTypeId = 3;
                dt = UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void bindCirclerequested()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.PostedComments = "";
                objUserCommentsBal.ReplyToAdminMessageId = msgid;
                objUserCommentsBal.RequestTypeId = 6;
                dt = UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                GridView5.DataSource = dt;
                GridView5.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void btnReply_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCommentsBal.ReplyMessage = txtReply.Text.Trim();
                objUserCommentsBal.ReplyToAdminMessageId = msgid;
                objUserCommentsBal.RequestTypeId = 2;
                UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                binReplyMessages();
                txtReply.Text = "";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label LBID = (Label)e.Row.FindControl("LBID");
                    Label lbHiddenId = (Label)e.Row.FindControl("lbHiddenId");
                    Label lbname = (Label)e.Row.FindControl("Label4");
                    if (LBID != null)
                    {
                        HtmlGenericControl divMsg = (HtmlGenericControl)e.Row.FindControl("divMsg");
                        if (lbname.Text == "Alere Vitaltiy")
                        {
                            DataTable dt = new DataTable();
                            objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objUserCommentsBal.ProcedureType = "G4";
                            dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (LBID.Text == Convert.ToString(dt.Rows[i]["GM_ID"]))
                                    {
                                        divMsg.Style.Add("background-color", "#EFEFEF");
                                    }

                                }
                            }
                            else
                            {
                                // divMsg.Style.Add("background-color", "#F9F9F9");
                            }
                        }
                        else if (lbHiddenId.Text == "1")
                        {
                            DataTable dt = new DataTable();
                            objUserCommentsBal.ID = Convert.ToInt32(LBID.Text);
                            objUserCommentsBal.ProcedureType = "MI";
                            dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dt.Rows[i]["invitation_read"]) == "False")
                                    {
                                        divMsg.Style.Add("background-color", "#EFEFEF");
                                    }

                                }
                            }
                            else
                            {
                                // divMsg.Style.Add("background-color", "#F9F9F9");
                            }
                        }

                        else
                        {
                            DataTable dt = new DataTable();
                            objUserCommentsBal.ID = Convert.ToInt32(LBID.Text);
                            objUserCommentsBal.ProcedureType = "CI";
                            dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dt.Rows[i]["fk_request_status_id"]) == "5")
                                    {
                                        divMsg.Style.Add("background-color", "#EFEFEF");
                                    }
                                    else
                                    {
                                        //   divMsg.Style.Add("background-color", "#F9F9F9");
                                    }
                                }
                            }
                            else
                            {
                                //  divMsg.Style.Add("background-color", "#F9F9F9");
                            }
                        }
                        //else
                        //{
                        //    DataTable dt = new DataTable();
                        //    objUserCommentsBal.ID = msgid;
                        //    objUserCommentsBal.ProcedureType = "CI";
                        //    dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                        //    if (dt.Rows.Count > 0)
                        //    {
                        //        // int i = 0;
                        //        // for (int i = 0; i < dt.Rows.Count; i++)
                        //        {
                        //            if (Convert.ToString(dt.Rows[0]["fk_request_status_id"]) == "5")
                        //            {
                        //                divMsg.Style.Add("background-color", "#CFCFCF");

                        //            }
                        //            else
                        //            {
                        //                divMsg.Style.Add("background-color", "#F9F9F9"); ;
                        //            }

                        //        }
                        //    }
                        //    else
                        //    {
                        //        divMsg.Style.Add("background-color", "#F9F9F9"); ;
                        //    }

                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "AcceptInvitation")
                {
                    DataTable dt = new DataTable();
                    objUserCommentsBal.ID = msgid;
                    objUserCommentsBal.ProcedureType = "MI";
                    dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                    if (dt.Rows.Count > 0)
                    {
                        objUserMissionBAL.Pk_mission_Invitation = msgid;
                        objUserMissionBAL.LoginId = Convert.ToInt32(dt.Rows[0]["fk_invited_by"]);
                        objUserMissionBAL.AllFriends_Id = (MySession.Current.LoginId);
                        objUserMissionBAL.MissionId = Convert.ToInt32(dt.Rows[0]["fk_mission_id"]);
                        objUserMissionBAL.CircleId = Convert.ToInt32(dt.Rows[0]["fk_circle_id"]);
                        objUserMissionBAL.InvitationMessage = dt.Rows[0]["inivitation_message"].ToString();
                        objUserMissionBAL.TypeOfRequest = 2;
                        objUserMissionBAL.Mission_Invitation_Status = true;
                        objUserMissionBAL.InvitationRead_Status = true;
                        UserMissionsDAL.SendMissionInvitation(objUserMissionBAL);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('Thanks ! Now this mission will be visible in your mission list.');", true);
                        Session["msg_id"] = true;
                        bindMissionInvitation();

                    }
                }
                else if (e.CommandName == "RejectInvitation")
                {
                    DataTable dt = new DataTable();
                    objUserCommentsBal.ID = msgid;
                    objUserCommentsBal.ProcedureType = "MI";
                    dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                    if (dt.Rows.Count > 0)
                    {
                        objUserMissionBAL.Pk_mission_Invitation = msgid;
                        objUserMissionBAL.LoginId = Convert.ToInt32(dt.Rows[0]["fk_invited_by"]);
                        objUserMissionBAL.AllFriends_Id = (MySession.Current.LoginId);
                        objUserMissionBAL.MissionId = Convert.ToInt32(dt.Rows[0]["fk_mission_id"]);
                        objUserMissionBAL.CircleId = Convert.ToInt32(dt.Rows[0]["fk_circle_id"]);
                        objUserMissionBAL.InvitationMessage = dt.Rows[0]["inivitation_message"].ToString();
                        objUserMissionBAL.TypeOfRequest = 2;
                        objUserMissionBAL.Mission_Invitation_Status = false;
                        objUserMissionBAL.InvitationRead_Status = true;
                        UserMissionsDAL.SendMissionInvitation(objUserMissionBAL);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('You have Rejected the invitation to join this mission !');", true);
                        Session["msg_id"] = true;
                        bindMissionInvitation();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbmsg = (Label)e.Row.FindControl("lbmsg");
                    LinkButton lnkaccept = (LinkButton)e.Row.FindControl("lnkAcceptInvitation");
                    LinkButton lnkreject = (LinkButton)e.Row.FindControl("lnkRejectInvitation");
                    Image Image1 = (Image)e.Row.FindControl("Image1");
                    DataTable dt = new DataTable();
                    objUserCommentsBal.ID = msgid;
                    objUserCommentsBal.ProcedureType = "MI";
                    dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["invitation_status"].ToString() == "")
                        {
                            lnkaccept.Visible = true;
                            lnkreject.Visible = true;
                            lbmsg.Visible = false;
                            Image1.Visible = false;
                        }
                        else
                        {
                            lnkaccept.Visible = false;
                            lnkreject.Visible = false;
                            if (Convert.ToString(Session["msg_id"]) != "True")
                            {
                                lbmsg.Visible = true;
                                Image1.Visible = true;

                                if (dt.Rows[0]["invitation_status"].ToString() == "True")
                                {

                                    lbmsg.Text = "You have already Accepted this Invitation.";
                                }
                                else
                                {
                                    lbmsg.Text = "You have already Rejected this Invitation.";
                                }
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



        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "AcceptInvitation")
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        objUserCommentsBal.ID = Convert.ToInt32(e.CommandArgument);
                        objUserCommentsBal.ProcedureType = "CI";
                        dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                        if (dt.Rows.Count > 0)
                        {
                            int retval = 0;
                            objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                            objUserCircleBAO.friend_registration_id = Convert.ToInt32(dt.Rows[0]["friend_registration_Id"]);
                            objUserCircleBAO.fk_circle_id = Convert.ToInt32(dt.Rows[0]["fk_circle_id"]);
                            objUserCircleBAO.request_status = 2;
                            objUserCircleBAO.updated_on = DateTime.Now;
                            objUserCircleBAO.proceduretype = "U";
                            retval = UserCirclesDAO.SendFriendRequest(objUserCircleBAO);

                            Session["msg_id"] = true;
                            Session["msgHide"] = true;
                            bindCirclerequested();
                            bindAllAdminMessage();
                            //Session["NewcircleId"] = Convert.ToString(dt.Rows[0]["fk_circle_id"]);
                            //Session["Topselcircle"] = Convert.ToString(dt.Rows[0]["fk_circle_id"]); 
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "parentwindow", "parentwindow()", true);

                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    objUserCommentsBal.ID = Convert.ToInt32(e.CommandArgument);
                    objUserCommentsBal.ProcedureType = "CI";
                    dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                    if (dt.Rows.Count > 0)
                    {
                        int retval = 0;
                        objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserCircleBAO.friend_registration_id = Convert.ToInt32(dt.Rows[0]["friend_registration_Id"]);
                        objUserCircleBAO.fk_circle_id = Convert.ToInt32(dt.Rows[0]["fk_circle_id"]);
                        objUserCircleBAO.request_status = 3;
                        objUserCircleBAO.updated_on = dt.Rows[0]["updated_on"].ToString();
                        objUserCircleBAO.proceduretype = "U";
                        retval = UserCirclesDAO.SendFriendRequest(objUserCircleBAO);
                        Session["msg_id"] = true;
                        Session["msgHide"] = true;
                        bindCirclerequested();
                        bindAllAdminMessage();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbmsg = (Label)e.Row.FindControl("lbmsg");
                    Label Label1 = (Label)e.Row.FindControl("Label1");
                    LinkButton lnkaccept = (LinkButton)e.Row.FindControl("lnkAcceptInvitation");
                    LinkButton lnkreject = (LinkButton)e.Row.FindControl("lnkRejectInvitation");
                    Image Image1 = (Image)e.Row.FindControl("Image1");
                    DataTable dt = new DataTable();
                    objUserCommentsBal.ID = msgid;
                    objUserCommentsBal.ProcedureType = "CI";
                    dt = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["fk_request_status_id"].ToString() == "5")
                        {
                            lnkaccept.Visible = true;
                            lnkreject.Visible = true;
                            lbmsg.Visible = false;
                            Image1.Visible = false;
                        }
                        else
                        {
                            lnkaccept.Visible = false;
                            lnkreject.Visible = false;
                            if (Convert.ToString(Session["msgHide"]) == "True")
                            {
                                lbmsg.Visible = true;
                                Image1.Visible = true;

                                if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                                {

                                    lbmsg.Text = "You have  Accepted this Request.";
                                }
                                else
                                {
                                    lbmsg.Text = "You have  Rejected this Request.";
                                }
                                Session["msgHide"] = false;
                            }
                            else
                            {
                                lbmsg.Visible = true;
                                Image1.Visible = true;

                                if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                                {

                                    lbmsg.Text = "You have already Accepted this Request.";
                                }
                                else
                                {
                                    lbmsg.Text = "You have already Rejected this Request.";
                                }
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

        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCircleId = (Label)e.Row.FindControl("lblCircleId");
                     Label lblMsg = (Label)e.Row.FindControl("lblMsg");
                    Button btnJoin = (Button)e.Row.FindControl("btnJoin");

                    DataTable dt = new DataTable();
                    objUserCommentsBal.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    objUserCommentsBal.PostedComments = "";
                    objUserCommentsBal.ReplyToAdminMessageId = Convert.ToInt32(lblCircleId.Text);
                    objUserCommentsBal.RequestTypeId = 8;
                    dt = UserCommentsDAL.GetAndReply_AdminPostedComments(objUserCommentsBal);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                        {
                            btnJoin.Visible = false;
                            lblMsg.Visible = true;
                        }
                        else
                        {
                            lblMsg.Visible = false;
                            btnJoin.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
