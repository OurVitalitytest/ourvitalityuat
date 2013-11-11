using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using System.Text;
using System.Web.Services;

namespace ALEREIMPACT.User
{
    public partial class Missions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string showMissionList = Request.QueryString["s"];

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

                    //Response.Write("rishi : " + System.DateTime.Now.ToShortDateString()); // only date is coming here


                    //string date = "15/06/2013";
                    //DateTime myDate = DateTime.ParseExact(date, "dd/MM/yyyy",
                    //                           System.Globalization.CultureInfo.InvariantCulture);

                    //Response.Write("  My Date " + myDate);
                    //Response.Write(" todaye : " + DateTime.Today);
                    //if (myDate > DateTime.Today)
                    //{
                    //    Response.Write(" rishi 2 :");
                    //}
                    //else
                    //{
                    //    Response.Write(" rishi 3 :");
                    //}
                    //
                    if (!Page.IsPostBack)
                    {
                        BindMissions_ByLoginId_IfAny();
                        if (Convert.ToString(Session["show_create_mission"]) == "True")
                        {
                            divMissionOptions.Visible = false;
                            dvCreateMission.Visible = true;
                            // dvTrackMission.Visible = false;
                            dvListMissions.Visible = false;
                            dvMissionHistory.Visible = false;
                            dvMissionGraphs.Visible = false;
                            divMissionFoodEssentials.Visible = false;
                            Session["show_create_mission"] = null;

                        }
                        else if (Convert.ToString(Session["show_list_mission"]) == "True" || showMissionList == "true")
                        {
                            divMissionOptions.Visible = false;
                            dvCreateMission.Visible = false;
                            dvListMissions.Visible = true;
                            // dvTrackMission.Visible = false;
                            dvMissionHistory.Visible = false;
                            divMissionFoodEssentials.Visible = false;
                            dvMissionGraphs.Visible = false;
                            Session["show_list_mission"] = null;
                        }

                        else if (Convert.ToString(Session["track_mission_history"]) == "True")
                        {
                            divMissionOptions.Visible = false;
                            dvMissionHistory.Visible = true;
                            // dvTrackMission.Visible = false;
                            dvCreateMission.Visible = false;
                            dvListMissions.Visible = false;
                            divMissionFoodEssentials.Visible = false;
                            dvMissionGraphs.Visible = false;
                            Session["track_mission_history"] = null;
                        }
                        else if (Convert.ToString(Session["track_mission_graphs"]) == "True")
                        {
                            divMissionOptions.Visible = false;
                            dvMissionGraphs.Visible = true;
                            dvMissionHistory.Visible = false;
                            // dvTrackMission.Visible = false;
                            divMissionFoodEssentials.Visible = false;
                            dvCreateMission.Visible = false;
                            dvListMissions.Visible = false;

                        }
                        else if (Convert.ToString(Session["FoodEssentials"]) == "True")
                        {
                            divMissionOptions.Visible = false;
                            dvMissionGraphs.Visible = false;
                            dvMissionHistory.Visible = false;
                            //dvTrackMission.Visible = false;
                            divMissionFoodEssentials.Visible = true;
                            dvCreateMission.Visible = false;
                            dvListMissions.Visible = false;
                            Session["FoodEssentials"] = null;
                        }
                        else if (Convert.ToString(Session["AskOptions_mission"]) == "True")
                        {
                            divMissionOptions.Visible = true;
                            dvMissionGraphs.Visible = false;
                            dvMissionHistory.Visible = false;
                            //dvTrackMission.Visible = false;
                            divMissionFoodEssentials.Visible = false;
                            dvCreateMission.Visible = false;
                            dvListMissions.Visible = false;
                            Session["AskOptions_mission"] = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void misList_btnHandler(string strValue)
        {
            Session["mission_has_been_selected"] = "clicked";
        }
        private void BindMissions_ByLoginId_IfAny()
        {
            try
            {
                UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();

                if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                {
                    UserCirclesBAO objusercircles = new UserCirclesBAO();
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
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
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);

                    DataTable dt = RegisterUserDAO.ListAllMissionsByLoginId(ObjUserMissionsBAL);
                    if (dt.Rows.Count > 0)
                    {
                        dvListMissions.Visible = true;
                    }
                    else
                    {
                        dvCreateMission.Visible = true;
                    }
                }
                else
                {
                    ObjUserMissionsBAL.AllFriends_Id = MySession.Current.MemberUserId;
                    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.MemberCircleId);

                    DataTable dt = RegisterUserDAO.ListAllMissionsByLoginId(ObjUserMissionsBAL);
                    dvListMissions.Visible = true;
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
