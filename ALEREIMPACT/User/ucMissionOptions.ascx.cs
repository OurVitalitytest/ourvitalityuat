using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAL.User;

namespace ALEREIMPACT.User
{
    public partial class ucMissionOptions : System.Web.UI.UserControl
    {
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
                        if (!String.IsNullOrEmpty(Convert.ToString(Session["selected_mission_id"])))
                            MissionDetails_ByMissionId();
                    }
                }
                putOnHoldCalendar.StartDate = DateTime.Today.AddDays(1);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void MissionDetails_ByMissionId()
        {

            DataTable dt = new DataTable();
            try
            {
                UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                dt = UserMissionsDAL.BindMissionDetails(ObjUserMissionsBAL);
                lblMissionName.Text = dt.Rows[0]["MissionName"].ToString();
                lblDateCreated.Text = dt.Rows[0]["DateCreatedOn"].ToString();
                lblDeadline.Text = dt.Rows[0]["DeadlineSet"].ToString();

                if (Convert.ToString(dt.Rows[0]["PublicPrivate"]) == "1")
                {
                    imgMission_PublicPrivate.ImageUrl = "../images/public.png";
                    imgMission_PublicPrivate.ToolTip = "Public";
                }
                else if (Convert.ToString(dt.Rows[0]["PublicPrivate"]) == "2")
                {
                    imgMission_PublicPrivate.ImageUrl = "../images/private.gif";
                    imgMission_PublicPrivate.ToolTip = "Private";
                }


                if (Convert.ToString(dt.Rows[0]["GroupIndividual"]) == "1")
                {
                    imgMission_GroupIndividual.ImageUrl = "../images/group.png";
                    imgMission_GroupIndividual.ToolTip = "Group";
                }
                else if (Convert.ToString(dt.Rows[0]["GroupIndividual"]) == "2")
                {
                    imgMission_GroupIndividual.ImageUrl = "../images/individual.png";
                    imgMission_GroupIndividual.ToolTip = "Individual";
                }
            }
            finally
            {
                dt.Dispose();
            }
        }
        protected void imgSubmitNewDeadline_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                ObjUserMissionsBAL.TypeOfRequest = 1;

                DateTime DateOfCompletion = DateTime.ParseExact(hdnProposedEndDate.Value, "dd/MM/yyyy", null);
                ObjUserMissionsBAL.DateOfCompletion = DateOfCompletion;


                UserMissionsDAL.ChangeMissionStatus(ObjUserMissionsBAL);
                hdnProposedEndDate.Value = "";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('The new target date has been set successfully for this mission !');", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkEndMission_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                ObjUserMissionsBAL.TypeOfRequest = 2;
                ObjUserMissionsBAL.DateOfCompletion = System.DateTime.Now;

                UserMissionsDAL.ChangeMissionStatus(ObjUserMissionsBAL);
                hdnProposedEndDate.Value = "";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('The mission is closed successfully !');", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkListMission_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["show_list_mission"] = "True";
                Response.Redirect("~/User/Missions.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnActivityLog_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["track_mission_history"] = "True";
                Response.Redirect("~/User/Missions.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}