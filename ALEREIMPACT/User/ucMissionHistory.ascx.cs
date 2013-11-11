using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using System.Text;

namespace ALEREIMPACT.User
{
    public partial class ucMissionHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {
                    if (MySession.Current.LoginId != null)
                    {
                        Bind_History();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void Bind_History()
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
                }
                else
                {
                    ObjUserMissionsBAL.AllFriends_Id = MySession.Current.MemberCircleId;
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.MemberCircleId);
                }
                ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                ObjUserMissionsBAL.DateId = 0;
                DataSet ds = UserMissionsDAL.BindMissionHistory(ObjUserMissionsBAL);

                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[2].Rows[0]["MissionStatus"].ToString() == "0")
                            lnkSubmitAgain.Visible = false;
                        else
                            lnkSubmitAgain.Visible = true;

                        grdDates.DataSource = ds.Tables[0];
                        grdDates.DataBind();

                        
                    }
                    else
                    {
                        grdDates.DataSource = null;
                        grdDates.DataBind();

                        //   tdMissionInfo.Visible = false;
                    }
                }
                if (ds.Tables[1] != null)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[1].Rows[0]["MissionOverallStatus"]) == "2")
                            lnkSubmitAgain.Visible = false;


                        if (Convert.ToString(ds.Tables[1].Rows[0]["Options"]) == "0")
                            lnkSubmitAgain.Visible = false;

                    }
                }
                if (ObjUserMissionsBAL.MissionId != 0)
                {
                    ViewState["selected_mission_theme_id"] = ds.Tables[2].Rows[0]["Mission_theme_id"].ToString();
                    lblMissionName.Text = ds.Tables[2].Rows[0]["MissionName"].ToString();

                    //if (ds.Tables[2].Rows[0]["Mission_theme_id"].ToString() == "2")
                    //    lblMissionTarget.Text = ds.Tables[2].Rows[0]["TotalCaloriesOrWeightTarget"].ToString().Replace(".00", "") + " steps";
                    //else
                    //    lblMissionTarget.Text = ds.Tables[2].Rows[0]["TotalCaloriesOrWeightTarget"].ToString() + " calories";

                    lblDeadline.Text = ds.Tables[2].Rows[0]["DeadlineSet"].ToString();
                    lblMIssionDescription.Text = ds.Tables[2].Rows[0]["TaskTarget"].ToString();
                    dvLeftDescription.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdCaloriesBurnt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                int a = 0;
                int tot = 0;
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Convert.ToString(ViewState["selected_mission_theme_id"]) == "1" || String.IsNullOrEmpty(Convert.ToString(ViewState["selected_mission_theme_id"])))
                    {
                        e.Row.Cells[2].Visible = true;
                        e.Row.Cells[1].Text = "Calories Burnt";
                        e.Row.Cells[2].Text = "Calories Eaten";
                        e.Row.Cells[3].Text = "Calories Left To Burn Today";
                        e.Row.Cells[4].Text = "Target Left";

                    }
                    else
                    {
                        if (Convert.ToString(ViewState["selected_mission_theme_id"]) == "2")
                        {
                            e.Row.Cells[1].Text = "Steps travelled";
                            e.Row.Cells[2].Visible = false;
                            e.Row.Cells[3].Text = "Daily steps targeted left";

                            e.Row.Cells[4].Text = "Mission Target Left";
                        }
                    }
                }
                if (Convert.ToString(ViewState["selected_mission_theme_id"]) == "1")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[2].Visible = true;
                        a = Convert.ToInt32(e.Row.Cells[1].Text);

                        if (String.IsNullOrEmpty(Convert.ToString(ViewState["_last_total"])))
                        {
                            tot = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CaloriesLeftFromTotal"));
                        }
                        else
                        {
                            tot = Convert.ToInt32(ViewState["_last_total"]);
                        }
                        e.Row.Cells[4].Text = Convert.ToString(tot - a);
                        ViewState["_last_total"] = e.Row.Cells[4].Text;
                    }
                }
                else
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        a = Convert.ToInt32(e.Row.Cells[1].Text);

                        if (String.IsNullOrEmpty(Convert.ToString(ViewState["_last_total"])))
                        {
                            tot = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CaloriesLeftFromTotal"));
                        }
                        else
                        {
                            tot = Convert.ToInt32(ViewState["_last_total"]);
                        }
                        e.Row.Cells[4].Text = Convert.ToString(tot - a);
                        ViewState["_last_total"] = e.Row.Cells[4].Text;
                        e.Row.Cells[2].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdDates_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int Date_rank_Id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DenseRankNumber"));
                    GridView grdCaloriesInput = (GridView)e.Row.FindControl("grdCaloriesBurnt");


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
                    }
                    else
                    {
                        ObjUserMissionsBAL.AllFriends_Id = MySession.Current.MemberCircleId;
                        ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.MemberCircleId);
                    }
                    ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                    ObjUserMissionsBAL.DateId = Date_rank_Id;

                    DataSet ds = UserMissionsDAL.BindMissionHistory(ObjUserMissionsBAL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdCaloriesInput.DataSource = ds.Tables[0];
                        grdCaloriesInput.DataBind();
                    }
                    else
                    {
                        grdCaloriesInput.DataSource = null;
                        grdCaloriesInput.DataBind();
                    }
                }
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

        protected void lnkSubmitAgain_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("~/User/Log.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnDailyProgress_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["track_mission_graphs"] = "True";
                Response.Redirect("~/User/Missions.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}