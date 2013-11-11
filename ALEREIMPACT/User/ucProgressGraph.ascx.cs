using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using System.Text;
using System.Globalization;

namespace ALEREIMPACT.User
{
    public partial class ucProgressGraph : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!Page.IsPostBack)
                {
                    if (string.IsNullOrEmpty(MySession.Current.LoginId))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                    }
                    else
                    {
                        txtDefaultWeekelyCalendar.Style.Value = "display:none";
                        dvShowMultipleCalendars.Style.Value = "display:none";
                        BindFirstDate_LatestDate();
                        spHeadingMsg.InnerText = "OverAll";
                        btnAll.Style.Value = "background: none repeat scroll 0 0 #4CBFBF;cursor:pointer;";
                        // BindProgressGraph_BasedOnSelection(Convert.ToInt32(ddlSortProgressGarph.SelectedValue));
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnGo_click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                BindProgressGraph_BasedOnSelection(hdnDateFrom.Value.ToString(), hdnDateTo.Value.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnSelection_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Button btnSenderId = (Button)sender;
                if (btnSenderId.ID == "btnAll")
                {
                    BindFirstDate_LatestDate();
                    spHeadingMsg.InnerText = "OverAll";

                    btnMonth.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                    btnAll.Style.Value = "background: none repeat scroll 0 0 #4CBFBF;cursor:pointer;";
                    btnToday.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                    btnYear.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                    btnWeek.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                }
                else
                {
                    BindProgressGraph_BasedOnSelection(hdnDateFrom.Value.ToString(), hdnDateTo.Value.ToString());
                    if (btnSenderId.ID == "btnToday")
                    {
                        spHeadingMsg.InnerText = "Today";
                        btnMonth.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnAll.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnToday.Style.Value = "background: none repeat scroll 0 0 #4CBFBF;cursor:pointer;";
                        btnYear.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnWeek.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                    }
                    else if (btnSenderId.ID == "btnWeek")
                    {
                        spHeadingMsg.InnerText = "Weekly";
                        btnMonth.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnAll.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnToday.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnYear.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnWeek.Style.Value = "background: none repeat scroll 0 0 #4CBFBF;cursor:pointer;";
                    }
                    else if (btnSenderId.ID == "btnMonth")
                    {
                        spHeadingMsg.InnerText = "Monthly";

                        btnMonth.Style.Value = "background: none repeat scroll 0 0 #4CBFBF;cursor:pointer;";
                        btnAll.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnToday.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnYear.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnWeek.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                    }
                    else if (btnSenderId.ID == "btnYear")
                    {
                        spHeadingMsg.InnerText = "Yearly";

                        btnMonth.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnAll.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnToday.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                        btnYear.Style.Value = "background: none repeat scroll 0 0 #4CBFBF;cursor:pointer;";
                        btnWeek.Style.Value = "background: none repeat scroll 0 0 #0E7C77;cursor:pointer;";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BindFirstDate_LatestDate()
        {
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
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
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


                ObjUserMissionsBAL.AllFriends_Id = fr.ToString().TrimEnd(',');
                ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);

                DataSet ds = UserMissionsDAL.Get_CheckDates_Of_MissionInputs_byLoginId(ObjUserMissionsBAL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["StartDate"].ToString())) && !String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["StartDate"].ToString())))
                    {
                        txtGraphCalendarNavigation.Text = ds.Tables[0].Rows[0]["StartDate"].ToString() + " - " + ds.Tables[0].Rows[0]["EndDate"].ToString();
                        hdnDateFrom.Value = ds.Tables[0].Rows[0]["StartDate"].ToString();
                        hdnDateTo.Value = ds.Tables[0].Rows[0]["EndDate"].ToString();
                        BindProgressGraph_BasedOnSelection(hdnDateFrom.Value.ToString(), hdnDateTo.Value.ToString());
                    }
                    else
                    {
                        hdnDateFrom.Value = ds.Tables[0].Rows[0]["StartDate"].ToString();
                        hdnDateTo.Value = ds.Tables[0].Rows[0]["EndDate"].ToString();
                        BindProgressGraph_BasedOnSelection(hdnDateFrom.Value.ToString(), hdnDateTo.Value.ToString());
                        txtGraphCalendarNavigation.Text = System.DateTime.Now.ToString("dd MMM yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
        }
        private void BindProgressGraph_BasedOnSelection(string Fromdate, string ToDate)
        {
            try
            {
                txtGraphCalendarNavigation.Text = Fromdate + "-" + ToDate;

                UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                UserCirclesBAO objusercircles = new UserCirclesBAO();

                if (MySession.Current.MemberUserId != null && MySession.Current.MemberUserId != "")
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.MemberUserId);
                }
                else
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
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


                ObjUserMissionsBAL.AllFriends_Id = fr.ToString().TrimEnd(',');
                ObjUserMissionsBAL.MissionId = 0;
                ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);

                if (Fromdate.IndexOf(' ') == 1)
                {
                    Fromdate = "0" + Fromdate;
                }
                if (ToDate.IndexOf(' ') == 1)
                {
                    ToDate = "0" + ToDate;
                }
                ObjUserMissionsBAL.Graph_DateFrom = Fromdate;
                ObjUserMissionsBAL.Graph_DateTo = ToDate;

                DataSet ds = UserMissionsDAL.BindMissionGraph(ObjUserMissionsBAL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    tblChartInfo.Visible = true;

                    string[] x = new string[ds.Tables[0].Rows.Count];
                    decimal[] y = new decimal[ds.Tables[0].Rows.Count];
                    decimal[] z = new decimal[ds.Tables[0].Rows.Count];

                    int sumOfCalBurn = 0;
                    int stepsTaken = 0;


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //if (Convert.ToString(ds.Tables[0].Rows[i][0]) != "0")
                        //{
                        x[i] = ds.Tables[0].Rows[i][1].ToString();
                        y[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                        z[i] = Convert.ToInt32(ds.Tables[0].Rows[i]["StepsCovered"]);

                        sumOfCalBurn += Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString().Trim());
                        stepsTaken += Convert.ToInt32(ds.Tables[0].Rows[i][10].ToString().Trim());
                        //}
                    }

                    spCalBurned.InnerText = sumOfCalBurn.ToString() + " calories";
                    spStepsTaken.InnerText = stepsTaken.ToString() + " steps";

                    // x = x.Where(i => !String.IsNullOrEmpty(i)).ToArray();
                    y = y.Where(j => !String.IsNullOrEmpty(Convert.ToString(j))).ToArray();
                    z = z.Where(j => !String.IsNullOrEmpty(Convert.ToString(j))).ToArray();

                    LineChart2.CategoriesAxis = string.Join(",", x);
                    LineChart2.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y, Name = "Calorie Burnt", LineColor = "Orange" });

                    bool isAllZero = z.All(c => c == 0);

                    if (!isAllZero)
                    {
                        lncSteps.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = z, Name = "Steps Covered", LineColor = "#990033" });
                        lncSteps.CategoriesAxis = string.Join(",", x);

                        imgEmptyChartForSteps.Visible = false;
                        lncSteps.Visible = true;
                    }
                    else
                    {
                        imgEmptyChartForSteps.Visible = true;
                        lncSteps.Visible = false;
                    }

                    /* Consumed Line*/

                    decimal[] x_consume = new decimal[ds.Tables[0].Rows.Count];
                    int sumOfCalConsume = 0;
                    for (int i_consume = 0; i_consume < ds.Tables[0].Rows.Count; i_consume++)
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i_consume][2])))
                        {
                            x_consume[i_consume] = Convert.ToInt32(ds.Tables[0].Rows[i_consume][2]);
                            sumOfCalConsume += Convert.ToInt32(ds.Tables[0].Rows[i_consume][2].ToString().Trim());
                        }
                    }

                    spCalConsume.InnerText = sumOfCalConsume.ToString() + " calories";


                    string[] strArray = new string[ds.Tables[0].Rows.Count];
                    for (int iCount = 0; iCount < x_consume.Count(); iCount++)
                    {
                        strArray[iCount] = x_consume[iCount].ToString();
                    }

                    strArray = strArray.Where(i => !String.IsNullOrEmpty(i)).ToArray();
                    y = new decimal[strArray.Count()];

                    for (int iCountDec = 0; iCountDec < strArray.Count(); iCountDec++)
                    {
                        y[iCountDec] = Convert.ToDecimal(strArray[iCountDec].ToString());
                    }


                    spWeight.InnerText = ds.Tables[0].Rows[0][3].ToString() + " " + ds.Tables[0].Rows[0][12].ToString();

                    if (sumOfCalConsume != 0)
                    {
                        LineChart2.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y, Name = "Calorie Consume", LineColor = "Green" });
                    }


                    if (ds.Tables[0].Rows.Count > 3)
                    {
                        LineChart2.ChartWidth = Convert.ToString(ds.Tables[0].Rows.Count * 50);
                    }


                    /* BEGIN *******************************************  Steps Chart width ********************/


                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        lncSteps.ChartWidth = "150";
                    }
                    else if (ds.Tables[0].Rows.Count == 2)
                    {
                        lncSteps.ChartWidth = "190";
                    }
                    else if (ds.Tables[0].Rows.Count > 3)
                    {
                        lncSteps.ChartWidth = Convert.ToString(ds.Tables[0].Rows.Count * 50);
                    }

                    /* END *******************************************  Steps Chart width ********************/

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        LineChart2.ChartWidth = "150";
                    }
                    else if (ds.Tables[0].Rows.Count == 2)
                    {
                        LineChart2.ChartWidth = "200";
                    }
                    else if (ds.Tables[0].Rows.Count > 3)
                    {
                        LineChart2.ChartWidth = Convert.ToString(ds.Tables[0].Rows.Count * 50);
                    }

                    /******************** weight *********************/



                    LineChart2.Visible = true;
                    imgEmptyChartImage.Visible = false;

                    if (ds.Tables[3] != null)
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                        {

                            if (!String.IsNullOrEmpty(Convert.ToString(ds.Tables[3].Rows[0]["weight_left"])) && Convert.ToString(ds.Tables[3].Rows[0]["weight_left"]) != "0" && Convert.ToString(ds.Tables[3].Rows[0]["weight_left"]) != "0.00")
                            {
                                DataRow dr = (DataRow)ds.Tables[3].Rows[ds.Tables[3].Rows.Count - 1];
                                spWeight.InnerText = dr[0].ToString() + " lbs";

                                string category = "";
                                decimal[] y_weight = new decimal[ds.Tables[3].Rows.Count];
                                string[] x_weight = new string[ds.Tables[3].Rows.Count];

                                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                                {
                                    category = category + "," + ds.Tables[3].Rows[i]["DateOfInputSubmitted"].ToString();
                                    y_weight[i] = Decimal.Parse(ds.Tables[3].Rows[i]["weight_left"].ToString());
                                    x_weight[i] = ds.Tables[3].Rows[i]["DateOfInputSubmitted"].ToString();
                                }
                                //lnchweigth.CategoriesAxis = category.Remove(0, 1);


                                lnchweigth.CategoriesAxis = string.Join(",", x_weight);
                                lnchweigth.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y_weight, Name = "Weight", LineColor = "Blue" });


                                imgEmptyChartForWeights.Visible = false;
                                lnchweigth.Visible = true;

                                if (ds.Tables[3].Rows.Count == 1)
                                {
                                    lnchweigth.ChartWidth = "150";
                                }
                                else if (ds.Tables[3].Rows.Count == 2)
                                {
                                    lnchweigth.ChartWidth = "200";
                                }
                                else if (ds.Tables[3].Rows.Count > 3)
                                {
                                    lnchweigth.ChartWidth = Convert.ToString(ds.Tables[3].Rows.Count * 50);
                                }
                            }
                        }
                        else
                        {
                            imgEmptyChartForWeights.Visible = true;
                            lnchweigth.Visible = false;
                        }
                    }
                    else
                    {
                        imgEmptyChartForWeights.Visible = true;
                        lnchweigth.Visible = false;
                    }
                }
                else
                {
                    string[] x = new string[1];
                    decimal[] y = new decimal[1];


                    x[0] = "No data available";
                    y[0] = 0;

                    LineChart2.Visible = false;
                    lncSteps.Visible = false;
                    imgEmptyChartImage.Visible = true;
                    imgEmptyChartForSteps.Visible = true;
                    spHeadingMsg.InnerText = "Today";
                    spCalConsume.InnerText = "0";
                    spCalBurned.InnerText = "0";
                    spStepsTaken.InnerText = "0";



                    if (ds.Tables[3] != null)
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            decimal[] y_weight = new decimal[ds.Tables[3].Rows.Count];
                            y_weight[0] = Convert.ToDecimal(ds.Tables[3].Rows[0]["weight_left"]);


                            lnchweigth.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y_weight, Name = "Weight", LineColor = "Blue" });


                            if (ds.Tables[3].Rows.Count > 3)
                            {
                                lnchweigth.ChartWidth = Convert.ToString(ds.Tables[0].Rows.Count * 50);
                            }
                            DataRow dr = (DataRow)ds.Tables[3].Rows[ds.Tables[3].Rows.Count - 1];
                            spWeight.InnerText = dr[0].ToString() + " lbs";

                            if (!String.IsNullOrEmpty(Convert.ToString(ds.Tables[3].Rows[0]["weight_left"])) && Convert.ToString(ds.Tables[3].Rows[0]["weight_left"]) != "0" && Convert.ToString(ds.Tables[3].Rows[0]["weight_left"]) != "0.00")
                            {
                                if (ds.Tables[3].Rows.Count == 1)
                                {
                                    lnchweigth.ChartWidth = "150";
                                }
                                else if (ds.Tables[3].Rows.Count == 2)
                                {
                                    lnchweigth.ChartWidth = "200";
                                }
                                else if (ds.Tables[3].Rows.Count > 3)
                                {
                                    lnchweigth.ChartWidth = Convert.ToString(ds.Tables[0].Rows.Count * 50);
                                }
                                imgEmptyChartForWeights.Visible = false;
                                lnchweigth.Visible = true;
                            }
                            else
                            {
                                imgEmptyChartForWeights.Visible = true;
                                lnchweigth.Visible = false;
                            }
                        }
                        else
                        {
                            imgEmptyChartForWeights.Visible = true;
                            lnchweigth.Visible = false;
                        }
                    }
                    else
                    {
                        imgEmptyChartForWeights.Visible = true;
                        lnchweigth.Visible = false;
                    }
                }
                Session["track_mission_graphs"] = null;
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
        }
    }

}


