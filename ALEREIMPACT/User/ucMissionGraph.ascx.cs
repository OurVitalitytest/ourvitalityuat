using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using System.Text;

namespace ALEREIMPACT.User
{
    public partial class ucMissionGraph : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["track_mission_graphs"]) == "True")
                    {

                        UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                        UserCirclesBAO objusercircles = new UserCirclesBAO();

                        //if (MySession.Current.MemberUserId != null && MySession.Current.MemberUserId != "")
                        //{
                        //    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.MemberUserId);
                        //}
                        //else
                        //{
                        //    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        //}
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
                        ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                        ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                        DataSet ds = UserMissionsDAL.BindMissionGraph(ObjUserMissionsBAL);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string[] x = new string[ds.Tables[0].Rows.Count];
                            decimal[] y = new decimal[ds.Tables[0].Rows.Count];
                            decimal[] z = new decimal[ds.Tables[0].Rows.Count];

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                x[i] = ds.Tables[0].Rows[i]["DateOfInputSubmitted"].ToString();
                                y[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                                z[i] = Convert.ToInt32(ds.Tables[0].Rows[i][10]);
                            }
                            //x = x.Where(i => !String.IsNullOrEmpty(i)).ToArray();
                            y = y.Where(j => !String.IsNullOrEmpty(Convert.ToString(j))).ToArray();
                            z = z.Where(j => !String.IsNullOrEmpty(Convert.ToString(j))).ToArray();

                            LineChart2.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y, Name = "Calorie Burnt", LineColor = "Orange" });
                            LineChart2.CategoriesAxis = string.Join(",", x);


                            bool isAllZero = z.All(c => c == 0);

                            if (!isAllZero)
                            {
                                lncSteps.CategoriesAxis = string.Join(",", x);
                                lncSteps.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = z, Name = "Steps Covered", LineColor = "#990033" });
                                imgEmptyChartImageSteps.Visible = false;
                                lncSteps.Visible = true;
                            }
                            else
                            {
                                imgEmptyChartImageSteps.Visible = true;
                                lncSteps.Visible = false;
                            }

                            /* Consumed Line*/



                            decimal[] x_consume = new decimal[ds.Tables[0].Rows.Count];

                            for (int i_consume = 0; i_consume < ds.Tables[0].Rows.Count; i_consume++)
                            {
                                if (!String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i_consume][2])))
                                {
                                    x_consume[i_consume] = Convert.ToDecimal(ds.Tables[0].Rows[i_consume][2]);
                                }
                                //LineChart2.AreaDataLabel = x[i_consume] + " <br/> Calories Consumed " + x_consume[i_consume];
                            }
                            x_consume = x_consume.Where(j => !String.IsNullOrEmpty(Convert.ToString(j))).ToArray();


                            LineChart2.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = x_consume, Name = "Calorie Consume", LineColor = "Green" });

                            if (ds.Tables[0].Rows.Count > 3)
                            {
                                lncSteps.ChartWidth = Convert.ToString(ds.Tables[0].Rows.Count * 85);
                                LineChart2.ChartWidth = Convert.ToString(ds.Tables[0].Rows.Count * 85);
                                //  
                            }

                            lblMissionName.Text = ds.Tables[0].Rows[0]["MissionName"].ToString();

                            if (ds.Tables[0].Rows[0]["Mission_theme_id"].ToString() == "2")
                            {
                                lblMissionTarget.Text = ds.Tables[0].Rows[0]["TotalCaloriesOrWeightTarget"].ToString().Replace(".00", "") + " steps";

                            }
                            else
                            {
                                lblMissionTarget.Text = ds.Tables[0].Rows[0]["TotalCaloriesOrWeightTarget"].ToString() + " calories";
                            }

                            lblDeadline.Text = ds.Tables[0].Rows[0]["DeadlineSet"].ToString();

                            dvChart.Visible = true;
                            dvLineChart.Visible = true;
                            imgEmptyChartImage.Visible = false;

                        }
                        else
                        {
                            dvChart.Visible = false;
                            dvLineChart.Visible = false;

                            lnkSubmitAgain.Style.Value = "margin-top:0px;";
                            btnActivityLog.Style.Value = "margin-top:16px;";
                            LineChart2.Visible = false;
                            imgEmptyChartImage.Visible = true;
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            if (Convert.ToString(ds.Tables[1].Rows[0]["MissionOverallStatus"]) == "2")
                            {
                                lnkSubmitAgain.Visible = false;
                            }
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                if (Convert.ToString(ds.Tables[1].Rows[0]["Options"]) == "0")
                                    lnkSubmitAgain.Visible = false;
                            }
                        }
                        if (ObjUserMissionsBAL.MissionId != 0)
                        {

                            lblMissionName.Text = ds.Tables[2].Rows[0]["MissionName"].ToString();

                            lblMissionDescription.Text = ds.Tables[2].Rows[0]["TaskTarget"].ToString();

                            //if (ds.Tables[2].Rows[0]["Mission_theme_id"].ToString() == "2")
                            //    lblMissionTarget.Text = ds.Tables[2].Rows[0]["TotalCaloriesOrWeightTarget"].ToString().Replace(".00", "") + " steps";
                            //else
                            //    lblMissionTarget.Text = ds.Tables[2].Rows[0]["TotalCaloriesOrWeightTarget"].ToString() + " calories";

                            lblDeadline.Text = ds.Tables[2].Rows[0]["DeadlineSet"].ToString();
                        }
                    }
                    if (MySession.Current.MemberUserId != null && MySession.Current.MemberUserId != "")
                    {
                        btnActivityLog.Visible = false;
                        lnkSubmitAgain.Visible = false;
                    }
                    Session["track_mission_graphs"] = null;
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