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
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using System.Text;
using AjaxControlToolkit;


namespace ALEREIMPACT.User
{
    public partial class ucListMissions : System.Web.UI.UserControl
    {
        // Delegate declaration
        public delegate void OnButtonClick(string strValue);

        // Event declaration
        public event OnButtonClick btnHandler;


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
                    if (!Page.IsPostBack)
                    {
                        Session["Group_Mission"] = "";
                        BindMissions_ByLoginId();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private DataTable BindMissions_ByLoginId()
        {
            DataTable dt = new DataTable();
            try
            {
                UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                UserCirclesBAO objusercircles = new UserCirclesBAO();

                if (MySession.Current.MemberUserId != null && MySession.Current.MemberUserId != "")
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.MemberUserId);
                }
                else
                {
                    if (MySession.Current.SelectedCircleUserId == MySession.Current.LoginId)
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    }
                    else
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    }
                }

                objusercircles.fk_circle_id = MySession.Current.CircleId;
                objusercircles.proceduretype = "S";
                DataTable dtFriends = new DataTable();
                dtFriends = UserCirclesDAO.GetFriendList(objusercircles);

                StringBuilder fr = new StringBuilder();
                foreach (DataRow dr in dtFriends.Rows)
                {
                    fr.Append(dr["userid"].ToString() + ",");
                }

                // CASE 1: Only FOR FIRSY TIME default person and related friends missios.

                //CASE 1 :
                if (MySession.Current.MemberUserId == null && MySession.Current.MemberUserId == ""
                    && MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                {
                    ObjUserMissionsBAL.AllFriends_Id = fr.ToString().TrimEnd(',');
                    //  ObjUserMissionsBAL.AllFriends_Id = MySession.Current.LoginId;
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                }

                // CASE 2: When a friemd request has came and this person is viewing the missions of invitation sender.

                //CASE 2 :
                else if (MySession.Current.MemberUserId != null && MySession.Current.MemberUserId != "")
                {
                    //ObjUserMissionsBAL.AllFriends_Id = MySession.Current.MemberUserId;
                    ObjUserMissionsBAL.AllFriends_Id = fr.ToString().TrimEnd(',');
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.MemberCircleId);
                    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.MemberUserId);

                    lnkCreateMission.Visible = false;
                }

                // CASE 3: When this user has clicked a circle of his or any member.

                //CASE 3 :
                else if (MySession.Current.SelectedCircleUserId != null && MySession.Current.SelectedCircleUserId != ""
                    && (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    )
                {
                    //if (MySession.Current.LoginId == MySession.Current.SelectedCircleUserId)
                    //{
                    //    ObjUserMissionsBAL.AllFriends_Id = MySession.Current.LoginId;
                    //}
                    //else
                    //{
                    //    ObjUserMissionsBAL.AllFriends_Id = MySession.Current.SelectedCircleUserId;
                    //}
                    ObjUserMissionsBAL.AllFriends_Id = fr.ToString().TrimEnd(',');
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    //                    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    if (MySession.Current.LoginId == MySession.Current.SelectedCircleUserId)
                    {
                        ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    }
                    else
                    {
                        ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    }

                }
                ObjUserMissionsBAL.fk_User_Circle_id = Convert.ToInt32(MySession.Current.UserCircleID);

                dt = RegisterUserDAO.ListAllMissionsByLoginId(ObjUserMissionsBAL);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        grdMissionList.DataSource = dt;
                        grdMissionList.DataBind();
                    }
                    else
                    {
                        grdMissionList.DataSource = null;
                        grdMissionList.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

                dt.Dispose();
            }
            return dt;
        }

        protected void lnkCreateMission_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                System.Threading.Thread.Sleep(1000);
                Session["show_create_mission"] = "True";
                Response.Redirect("~/User/Missions.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grdMissionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["selected_mission_id"] = null;
                if (e.CommandName == "TrackMission")
                {
                    System.Threading.Thread.Sleep(1000);
                    //// Check if event is null
                    //if (btnHandler != null)
                    //    btnHandler(string.Empty);


                    string[] strArray = e.CommandArgument.ToString().Split(';');
                    if (strArray[1] == "1" && strArray[2] == "1")
                    {
                        Session["Group_Mission"] = "True";
                    }
                    Session["track_mission"] = "True";
                    Session["selected_mission_id"] = Convert.ToInt32(strArray[0]);
                    Response.Redirect("~/User/Log.aspx", false);
                }
                else if (e.CommandName == "TrackMissionHistory")
                {
                    System.Threading.Thread.Sleep(1000);
                    Session["track_mission_history"] = "True";
                    Session["selected_mission_id"] = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/User/Missions.aspx", false);
                }
                else if (e.CommandName == "CheckProgress")
                {
                    System.Threading.Thread.Sleep(1000);
                    Session["track_mission_graphs"] = "True";
                    Session["selected_mission_id"] = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/User/Missions.aspx", false);
                }
                else if (e.CommandName == "AskOptions")
                {
                    System.Threading.Thread.Sleep(1000);
                    Session["AskOptions_mission"] = "True";
                    Session["selected_mission_id"] = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/User/Missions.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdMissionList_Sorting(object sender, GridViewSortEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridViewSortExpression = e.SortExpression;
                int pageIndex = grdMissionList.PageIndex;
                grdMissionList.DataSource = SortDataTable(BindMissions_ByLoginId(), false);
                grdMissionList.DataBind();
                grdMissionList.PageIndex = pageIndex;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp1", "<script type='text/javascript'>bind();</script>", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected DataView SortDataTable(DataTable ptblDataTable, Boolean pblnIsPageIndexChanging)
        {
            if (ptblDataTable != null)
            {
                DataView dataView = new DataView(ptblDataTable);
                if (GridViewSortExpression != string.Empty)
                    if (pblnIsPageIndexChanging)
                        dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection);
                    else
                        dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GetSortDirection());
                return dataView;
            }
            else
                return new DataView();
        }

        #region " GridViewSortDirection Property "
        /// <summary>
        /// 
        /// </summary>
        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        #endregion

        #region " GridViewSortExpression Property "
        /// <summary>
        /// 
        /// </summary>
        private string GridViewSortExpression
        {
            get { return ViewState["SortExpression"] as string ?? string.Empty; }
            set { ViewState["SortExpression"] = value; }
        }
        #endregion

        #region " GetSortDirection Function "
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetSortDirection()
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    break;
            }
            return GridViewSortDirection;
        }
        #endregion

        protected void grdMissionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HdnCrestedid = (HiddenField)e.Row.FindControl("HdnCrestedid");
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "missionInfo")) == "IndividualPrivate")
                    {
                        if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                        {
                            e.Row.Visible = true;
                        }
                        else
                        {
                            if (MySession.Current.LoginId == HdnCrestedid.Value)
                            {
                                e.Row.Visible = true;

                            }
                            else
                            {
                                e.Row.Visible = false;

                            }
                        }

                    }
                    else
                    {
                        if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                        {
                            e.Row.Visible = true;
                        }
                        else
                        {
                            if (MySession.Current.LoginId == HdnCrestedid.Value)
                            {
                                e.Row.Visible = true;

                            }
                            else
                            {
                                e.Row.Visible = false;

                            }
                        }
                    }
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "missionInfo")) == "0")
                    {
                        if (MySession.Current.LoginId == HdnCrestedid.Value)
                        {
                            e.Row.Visible = true;

                        }
                        else
                        {
                            e.Row.Visible = false;
                        }
                    }
                    else
                    {
                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "missionInfo")) != "IndividualPrivate")
                            e.Row.Visible = true;
                        else
                            if (MySession.Current.LoginId == HdnCrestedid.Value)
                            {
                                e.Row.Visible = true;

                            }
                            else
                            {
                                e.Row.Visible = false;

                            }

                    }

                    CheckBox chkSelectedMissionid = (CheckBox)e.Row.FindControl("chkSelectedMissionid");
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "group_individual")) == "1" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "public_private")) == "2")
                    {
                        chkSelectedMissionid.Enabled = true;

                    }
                    else
                    {
                        chkSelectedMissionid.Enabled = false;
                        chkSelectedMissionid.Attributes.Add("style", "background-color:#DBD3D6;");
                    }

                    chkSelectedMissionid.Attributes.Add("style", "width:68px");

                    Image imgPublicPrivate = (Image)e.Row.FindControl("imgPublicPrivate");
                    Image imgGroupIndividual = (Image)e.Row.FindControl("imgGroupIndividual");

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "public_private")) == "1")
                    {
                        imgPublicPrivate.ImageUrl = "../images/public.png";
                        imgPublicPrivate.ToolTip = "Public";
                    }
                    else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "public_private")) == "2")
                    {
                        imgPublicPrivate.ImageUrl = "../images/private.gif";
                        imgPublicPrivate.ToolTip = "Private";
                    }


                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "group_individual")) == "1")
                    {
                        imgGroupIndividual.ImageUrl = "../images/group.png";
                        imgGroupIndividual.ToolTip = "Group";
                    }
                    else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "group_individual")) == "2")
                    {
                        imgGroupIndividual.ImageUrl = "../images/individual.png";
                        imgGroupIndividual.ToolTip = "Individual";
                    }


                    if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pk_created_by_user_Id")))
                    {
                        //e.Row.CssClass = "createdByOther";
                        e.Row.Attributes.Add("onmouseover", "mouseIn(this);");
                        e.Row.Attributes.Add("onmouseout", "createdByOtherUser(this);");

                        string tooltipMsg = "This Mission has been created by one of the members: " + DataBinder.Eval(e.Row.DataItem, "created_by");
                        e.Row.ToolTip = tooltipMsg;
                    }
                    else
                    {
                        e.Row.Attributes.Add("onmouseover", "mouseIn(this);");
                        e.Row.Attributes.Add("onmouseout", "mouseOut(this);");
                    }
                    if (String.IsNullOrEmpty(MySession.Current.MemberUserId))
                    {
                        ImageButton lnkTrackMission = (ImageButton)e.Row.FindControl("lnkTrackMission");
                        int missionStatus = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Mission_Status"));
                        if (missionStatus == 1)
                        {
                            lnkTrackMission.Enabled = true;

                            ImageButton imgAskOptions = (ImageButton)e.Row.FindControl("imgAskOptions");
                            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Options")) == "1")
                            {
                                imgAskOptions.Visible = false;
                                lnkTrackMission.Visible = true;
                            }
                            else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Options")) == "0")
                            {
                                imgAskOptions.Visible = true;
                                lnkTrackMission.Visible = false;

                                chkSelectedMissionid.Enabled = false;
                            }
                        }
                        else
                        {
                            lnkTrackMission.Visible = false;
                            Image mission_accomplished = (Image)e.Row.FindControl("mission_accomplished");

                            lnkTrackMission.Enabled = false;
                            ImageButton imgAskOptions = (ImageButton)e.Row.FindControl("imgAskOptions");
                            mission_accomplished.Style.Value = "display:block;";
                            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Options")) == "1")
                            {
                                imgAskOptions.Visible = false;
                                //lnkTrackMission.Enabled = true;
                                //lnkTrackMission.Visible = true;
                                ///
                                
                                lnkTrackMission.ForeColor = System.Drawing.Color.Red;
                                chkSelectedMissionid.Enabled = false;

                            }
                            else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Options")) == "0")
                            {
                                imgAskOptions.Visible = true;
                                mission_accomplished.Style.Value = "display:none;";

                            }
                        }
                        e.Row.Cells[5].Visible = true;
                        e.Row.Cells[6].Visible = true;
                        e.Row.Cells[7].Visible = true;

                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "mission_overall_status")) == "2")
                        {
                            ImageButton imgAskOptions = (ImageButton)e.Row.FindControl("imgAskOptions");
                            lnkTrackMission.Style.Value = "display:none;";
                            //e.Row.Cells[6].Text = "This mission is closed";
                            //e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue;

                            imgAskOptions.Style.Value = "display:none;";
                            Image imgMissionClosed = (Image)e.Row.FindControl("imgMissionClosed");
                            imgMissionClosed.Style.Value = "display:block;";
                            chkSelectedMissionid.Enabled = false;

                        }
                    }
                    else
                    {
                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "group_individual")) == "2"
                            && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "public_private")) == "2")
                        {
                            e.Row.Visible = false;
                        }

                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "group_individual")) == "1"
                           && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "public_private")) == "2")
                        {
                            e.Row.Visible = false;
                        }

                        e.Row.Cells[0].Visible = false;
                        e.Row.Cells[5].Visible = false;
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                    }

                    UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                    Label lblMissionId = (Label)e.Row.FindControl("lblMissionId");

                    GridView gvR = (GridView)e.Row.FindControl("grdOtherCircleMembers");

                    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserMissionsBAL.AllFriends_Id = "";
                    ObjUserMissionsBAL.MissionId = Convert.ToInt32(lblMissionId.Text);
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    ObjUserMissionsBAL.InvitationMessage = "";
                    ObjUserMissionsBAL.TypeOfRequest = 1;

                    DataSet ds = ALEREIMPACT.DAL.User.UserMissionsDAL.SendMissionInvitation(ObjUserMissionsBAL);
                    if (ds.Tables[0] != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            gvR.DataSource = ds.Tables[0];
                            gvR.DataBind();
                        }
                    }
                }
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (String.IsNullOrEmpty(MySession.Current.MemberUserId))
                    {
                        e.Row.Cells[0].Visible = true;
                        e.Row.Cells[5].Visible = true;
                        e.Row.Cells[6].Visible = true;
                        e.Row.Cells[7].Visible = true;
                    }
                    else
                    {
                        e.Row.Cells[0].Visible = false;
                        e.Row.Cells[5].Visible = false;
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdMissionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                grdMissionList.DataSource = SortDataTable(BindMissions_ByLoginId(), true);
                grdMissionList.PageIndex = e.NewPageIndex;
                grdMissionList.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void grdOtherCircleMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Int32 pk_mission_invi_id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "mission_invi_id"));
                    Int32 pk_invited_to = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "userid"));
                    CheckBox chkOtherMembers = (CheckBox)e.Row.FindControl("chkOtherMembers");
                    Label lblMemberName = (Label)e.Row.FindControl("lblMemberName");

                    if (pk_mission_invi_id != 0)
                    {
                        chkOtherMembers.Enabled = false;
                        chkOtherMembers.Checked = true;
                    }
                    else
                    {
                        chkOtherMembers.Enabled = true;
                        chkOtherMembers.Checked = false;
                    }
                    if (pk_invited_to == Convert.ToInt32(MySession.Current.LoginId))
                    {

                        lblMemberName.Visible = false;
                        chkOtherMembers.Visible = false;
                    }
                    else
                    {
                        lblMemberName.Visible = true;
                        chkOtherMembers.Visible = true;

                    }
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
            try
            {
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                }
                else
                {
                    UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                    string strAllselected_members = null;

                    Button lnk = (Button)sender;

                    GridViewRow gvr = (GridViewRow)lnk.NamingContainer;
                    int selectedRow = gvr.RowIndex;
                    GridView gvR = (GridView)grdMissionList.Rows[selectedRow].FindControl("grdOtherCircleMembers");
                    Label lblMissionId = (Label)gvr.FindControl("lblMissionId");
                    TextBox txtInvitationMessage = (TextBox)gvr.FindControl("txtInvitationMessage");

                    foreach (GridViewRow row in gvR.Rows)
                    {
                        CheckBox cb = (CheckBox)row.FindControl("chkOtherMembers");
                        Label lb_memberId = row.FindControl("lblMemberId") as Label;

                        if (cb.Checked == true && cb.Enabled == true)
                        {
                            strAllselected_members += lb_memberId.Text + ",";
                        }
                    }
                    if (String.IsNullOrEmpty(Convert.ToString(strAllselected_members)) || String.IsNullOrEmpty(Convert.ToString(txtInvitationMessage.Text.Trim())))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('You must enter some invitation message and select member(s) from the list !');", true);
                    }
                    else
                    {
                        ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                        ObjUserMissionsBAL.AllFriends_Id = strAllselected_members.TrimEnd(',');
                        ObjUserMissionsBAL.MissionId = Convert.ToInt32(lblMissionId.Text);
                        ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);


                        ObjUserMissionsBAL.InvitationMessage = txtInvitationMessage.Text.Trim();
                        ObjUserMissionsBAL.TypeOfRequest = 0;

                        ObjUserMissionsBAL.Pk_mission_Invitation = 0;
                        ObjUserMissionsBAL.Mission_Invitation_Status = false;
                        ObjUserMissionsBAL.InvitationRead_Status = false;

                        DataSet ds = ALEREIMPACT.DAL.User.UserMissionsDAL.SendMissionInvitation(ObjUserMissionsBAL);

                        int checkStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["ReturnedMessage"].ToString());
                        if (checkStatus == 1)
                        {
                            BindMissions_ByLoginId();
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('Your invitation has been posted successfully to the selected member(s) !');", true);

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