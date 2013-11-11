using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.DAO.User;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using System.Xml;
using OAuth.Net.Common;
using OAuth.Net.Components;
using OAuth.Net.Consumer;
using EndPoint = OAuth.Net.Consumer.EndPoint;
using System.Reflection;
using System.Collections;
using System.Security.Cryptography;


namespace ALEREIMPACT.User
{
    public partial class ucTrackMission : System.Web.UI.UserControl
    {
        protected XmlDocument stepsDoc { get; private set; }
        protected XmlDocument caloriesDoc { get; private set; }

        protected static string checkForMissionType = string.Empty;
        UserMissionsBAL objUserMissionBAL = new UserMissionsBAL();
        UserFoodLogBAO objUserFoodLog = new UserFoodLogBAO();
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        public static string total;
        decimal nutr_vale = 0;
        decimal nutr_vale1 = 0;
        decimal nutr_vale2 = 0;
        decimal nutr_vale3 = 0;
        decimal nutr_vale4 = 0;
        decimal nutr_vale5 = 0;
        decimal nutr_vale6 = 0;
        decimal nutr_vale7 = 0;
        public Int32 minutes = 0;
        public Int32 heartrate = 0;
        public static string Searchname = "";
        public decimal calBurns = 0;
        public Int32 steps = 0;
        public static Int32 cal, fat, chol, fiber, sugar, calconsumed = 0;
        public static int count = 0;
        public static Int32 number = 20;
        public static Int32 setofno = 0;
        public static string lengend = "";
        public static string Pro_size = "";
        protected static int chartPoints = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MySession.Current.LoginId))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
            }

            if (!Page.IsPostBack)
            {
                //if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                //{
                //    dvRegionOfCalsBurn.Visible = true;
                //}
                //else
                //{
                //    dvRegionOfCalsBurn.Visible = false;
                //}
                if (!String.IsNullOrEmpty(Convert.ToString(Session["navigated_date_selected"])))
                {
                    hdnSelectedDateForMissionHistory.Value = Session["navigated_date_selected"].ToString();
                    txtCalendarNavigation.Text = hdnSelectedDateForMissionHistory.Value;
                    //                    Session["navigated_date_selected"] = string.Empty;
                }
                if (String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                {
                    txtCalendarNavigation.Text = System.DateTime.Now.ToString("dd MMM yyyy");
                    hdnSelectedDateForMissionHistory.Value = txtCalendarNavigation.Text + DateTime.Now.ToString(" HH:mm:ss tt");
                }

                Fetch_CaloriesBurnFrom_FitBitApi(Convert.ToInt32(MySession.Current.LoginId));
                //CheckIf_FitBitDetailsPresent(Convert.ToInt32(MySession.Current.LoginId));

                // BindFoodLog();
                //panel_FAv_pop.Style.Value = "display:none;";
                //Pnl_ModalPopupExtenderFav.Hide();
                bindGrdFAv();
                BindCategories();
                BindFavActivityLog();

                if (String.IsNullOrEmpty(Convert.ToString(hdnCheckPostback.Value)))
                    bindLogActivities();


                bindDistanceCAl();
                BindQuickLog_ActivitiesAndCalories();
                bindYearDay();
                heightAndWeight_Units();
                //BindFeatures();
                Bind_History();
            }
            bindTotal();

            if (!String.IsNullOrEmpty(Convert.ToString(Session["selected_mission_id"])))
            {

                //dvSerach.Style.Add("display", "none");
                //// dvChart.Style.Add("display", "");
                //Chart2.Series[0].PostBackValue = "#INDEX";
                //chartPoints = Chart2.Series["Series1"].Points.Count;
                if (String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                    txtCalendarNavigation.Text = System.DateTime.Now.ToString("dd MMM yyyy");
            }
            else
            {
                // dvactivity_right_section.Style.Value = "float: right; margin-top: 15px;";
            }
            if (!String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
            {
                BindHistoryLogBasedOnDates(Convert.ToString(hdnSelectedDateForMissionHistory.Value));

                string presentdate = hdnSelectedDateForMissionHistory.Value;
                if (presentdate.Length > 11)
                {
                    presentdate = presentdate.Substring(0, presentdate.IndexOf(' ', presentdate.IndexOf(' ') + 5));
                    txtCalendarNavigation.Text = presentdate;
                }
                else
                {
                    txtCalendarNavigation.Text = Convert.ToString(String.Format(hdnSelectedDateForMissionHistory.Value, "dd MMM yyyy"));
                }


                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);
                Bind_History();

            }

            this.txtSearchActivities.Attributes.Add("onkeypress", "ShowImage(event)");
            txtSearchActivities.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            ViewState["Mission_selection"] = null;
            txtCalendarNavigation.Attributes.Add("readonly", "readonly");

            if (String.IsNullOrEmpty(Convert.ToString(hdnCheckPostback.Value)))
                bindLogActivities();

        }
        /// <summary>
        ///  Purpose: Show QuickLog activities along with cals burn specified w.r.t each activity
        ///  ref : http://www.fitday.com/fitness-articles/fitness/cardio/calories-burned-for-yoga-is-it-enough-for-weight-loss.html
        ///  ref :http://calorielab.com/burned/?mo=se&gr=15&ti=Sports&wt=150&un=lb&kg=68
        ///  ref : http://calorielab.com/burned/?mo=se&gr=05&ti=Home+activities&wt=150&un=lb&kg=68
        /// </summary>
        private void BindQuickLog_ActivitiesAndCalories()
        {
            UserFoodLogBAO ObjUserFoodLogBAO = null;
            try
            {
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.RequestType = 2;
                ObjUserFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                System.Data.DataSet retval = UserFoodLogDAO.ShowQuickLogActivities(ObjUserFoodLogBAO);

                if (retval.Tables[0].Rows.Count > 0)
                {
                    grdQuickLog.DataSource = retval.Tables[0];
                    grdQuickLog.DataBind();
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
            finally
            {
                ObjUserFoodLogBAO = null;
            }
        }
        /// <summary>
        /// Purpose: To submit calorie burn amd steps covered if quick log is choosed.
        /// Reference :  http://www.ask.com/answers/16547281/i-have-pedometer-example-for-17146-steps-taken-how-can-your-find-out-how-many-calories-you-burned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_QuickLog_Click(object sender, EventArgs e)
        {
            string activitySelected = string.Empty;
            string caloriesSelected = string.Empty;
            double stepsCovered = 0;

            foreach (GridViewRow dr in grdQuickLog.Rows)
            {
                RadioButton radActivitySelected = (RadioButton)dr.FindControl("radQuickLog");
                Label lblQuickLogCalories = (Label)dr.FindControl("lblQuickLogCalories");

                if (radActivitySelected.Checked)
                {
                    string[] arg = new string[2];
                    arg = lblQuickLogCalories.Text.ToString().Split('@');
                    activitySelected = arg[0];
                    caloriesSelected = arg[1];
                }
            }
            stepsCovered = Convert.ToDouble(caloriesSelected) / 0.05;

            ViewState["QuickLog"] = "true";
            AddDailyCaloriesInput(0, Convert.ToInt32(stepsCovered), Convert.ToDecimal(caloriesSelected), Convert.ToInt32(MySession.Current.LoginId), 1, activitySelected, 0, hdnSelectedDateForMissionHistory.Value, 0, 0, 0);
            foreach (GridViewRow dr in grdQuickLog.Rows)
            {
                RadioButton radActivitySelected = (RadioButton)dr.FindControl("radQuickLog");
                radActivitySelected.Checked = false;
            }
            Bind_History();

            string presentdate = hdnSelectedDateForMissionHistory.Value;


            if (presentdate.Length > 11)
            {
                presentdate = presentdate.Substring(0, presentdate.IndexOf(' ', presentdate.IndexOf(' ') + 5));
                txtCalendarNavigation.Text = presentdate;
            }
            else
            {
                txtCalendarNavigation.Text = presentdate;
            }

            //panel_FAv_pop.Style.Value = "display:none;";
            //Pnl_ModalPopupExtenderFav.Hide();
            bindGrdFAv();
            BindCategories();
            BindFavActivityLog();
            bindLogActivities();
            bindDistanceCAl();

        }
        private void heightAndWeight_Units()
        {
            //drpUserHeightOptions.Items.Clear();
            //drpUserHeightOptions.Items.Insert(0, new ListItem("- Select -", "0"));
            //drpUserHeightOptions.Items.Insert(1, new ListItem("inches", "1"));
            //drpUserHeightOptions.Items.Insert(2, new ListItem("cms", "2"));

            drpUserWeightOptions.Items.Clear();
            drpUserWeightOptions.Items.Insert(0, new ListItem("- Select -", "0"));
            drpUserWeightOptions.Items.Insert(1, new ListItem("Kilograms (kgs)", "1"));
            drpUserWeightOptions.Items.Insert(2, new ListItem("Pounds (lbs)", "2"));


            drpGender.Items.Clear();
            drpGender.Items.Insert(0, new ListItem("- Select -", "0"));
            drpGender.Items.Insert(1, new ListItem("Male", "1"));
            drpGender.Items.Insert(2, new ListItem("Female", "2"));

        }
        private void BindFeatures()
        {
            UserMissionsBAL objUserMissionsDAL = new UserMissionsBAL();
            if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
            {
                objUserMissionsDAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
            }
            else
            {
                objUserMissionsDAL.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
            }
            objUserMissionsDAL.User_id_For_Name = Convert.ToInt32(MySession.Current.LoginId);
            DataSet dsThemes = UserMissionsDAL.BindMissionTypesAndThemes(objUserMissionsDAL);

            if (dsThemes.Tables[2] != null)
            {
                if (dsThemes.Tables[2].Rows.Count > 0)
                {
                    if (Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEntered"]) == "0.00")
                    {
                        dvHeight.Style.Value = "display:block;";
                    }
                    else
                    {
                        txtHeight.Text = Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEntered"]).Substring(0, Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEntered"]).IndexOf('.', 0)); ;
                        dvHeight.Style.Value = "display:none;";
                    }

                    if (Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEnteredUnits"]) == "0")
                    {
                        dvHeight.Style.Value = "display:block;";
                    }
                    else
                    {
                        drpUserHeightOptions.SelectedIndex = drpUserHeightOptions.Items.IndexOf(drpUserHeightOptions.Items.FindByValue(Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEnteredUnits"])));
                    }
                    if (Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEntered"]) == "0")
                    {
                        divWeight.Style.Value = "display:block;";
                    }
                    else
                    {
                        txtWeight.Text = Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEntered"]);
                        divWeight.Style.Value = "display:none;";
                    }

                    if (Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEnteredUnits"]) == "0")
                    {
                        divWeight.Style.Value = "display:block;";

                    }
                    else
                    {
                        drpUserWeightOptions.SelectedIndex = drpUserWeightOptions.Items.IndexOf(drpUserWeightOptions.Items.FindByValue(Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEnteredUnits"])));
                    }

                    if (Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"]) != "1" && Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"]) != "2")
                    {
                        divGender.Style.Value = "display:block;";
                    }
                    else
                    {
                        divGender.Style.Value = "display:none;";
                        drpGender.SelectedIndex = drpGender.Items.IndexOf(drpGender.Items.FindByValue(Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"])));
                    }

                    if (Convert.ToString(dsThemes.Tables[2].Rows[0]["YearEntered"]) == "0")
                    {
                        divDOB.Style.Value = "display:block;";

                    }
                    else
                    {
                        drpYear.SelectedIndex = drpYear.Items.IndexOf(drpYear.Items.FindByText(Convert.ToString(dsThemes.Tables[2].Rows[0]["YearEntered"])));
                        drpMonth.SelectedIndex = drpMonth.Items.IndexOf(drpMonth.Items.FindByText(Convert.ToString(dsThemes.Tables[2].Rows[0]["MonthEntered"])));
                        DrpDAy.SelectedIndex = DrpDAy.Items.IndexOf(DrpDAy.Items.FindByText(Convert.ToString(dsThemes.Tables[2].Rows[0]["DateEntered"])));
                        divDOB.Style.Value = "display:none;";

                        int ageCalculated = Convert.ToInt32(System.DateTime.Now.Year - Convert.ToInt32(dsThemes.Tables[2].Rows[0]["YearEntered"]));

                        if (txtHeartRateAvg.Text == "0")
                        {
                            CalculateCAlories(220);
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(Convert.ToString(txtHeartRateAvg.Text.Trim())))
                                CalculateCAlories(Convert.ToInt32(220));
                            else
                            {
                                //if (!String.IsNullOrEmpty(Convert.ToString(Session["heartrate"])))
                                //{
                                //    CalculateCAlories(Convert.ToInt32(Session["heartrate"]));
                                //}
                                //else
                                //{
                                CalculateCAlories(Convert.ToInt32(txtHeartRateAvg.Text.Trim()));
                                //}
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Purpose: to change Looged Activities Grid w.r.t Log linkbuttons click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkActivities_Click(object sender, EventArgs e)
        {
            Session["FoodLog"] = true;
            Session["track_mission"] = true;
            if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
            {
                Response.Redirect("Log.aspx?MissionSelected=True", false);
            }
            else
            {
                Response.Redirect("Log.aspx", false);
            }
        }
        /// <summary>
        /// Purpose: to change Looged Activities Grid w.r.t Food Log .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFood_Click(object sender, EventArgs e)
        {
            Session["FoodLog"] = null;
            Session["track_mission"] = null;
            if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
            {
                Response.Redirect("Log.aspx?MissionSelected=True", false);
            }
            else
            {
                Response.Redirect("Log.aspx", false);
            }
        }
        /// <summary>
        /// Pupose: To bind categories to the gridview and 
        ///         then bind subcategories w.r.t categort
        /// </summary>
        private void BindCategories()
        {
            UserFoodLogBAO ObjUserFoodLogBAO = null;
            try
            {
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.Search_Name = string.Empty;
                ObjUserFoodLogBAO.ID = "2";
                System.Data.DataTable retval = UserFoodLogDAO.ShowActivitiesBasedonSearchText(ObjUserFoodLogBAO);

                if (retval.Rows.Count > 0)
                {
                    grdCategories.DataSource = retval;
                    grdCategories.DataBind();
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
            finally
            {
                ObjUserFoodLogBAO = null;
            }
        }
        protected void grdCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectCategory")
            {
                string CommentId = e.CommandArgument.ToString();

                UserFoodLogBAO ObjUserFoodLogBAO = null;
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.Search_Name = CommentId;
                ObjUserFoodLogBAO.ID = "4";
                System.Data.DataTable retval = UserFoodLogDAO.ShowActivitiesBasedonSearchText(ObjUserFoodLogBAO);

                if (retval.Rows.Count > 0)
                {

                    grdActivities.DataSource = retval;
                    grdActivities.DataBind();
                }
                else
                {
                    grdActivities.DataSource = null;
                    grdActivities.DataBind();

                }
                modalPopActivities.Show();
                pnlActivities.Style.Add("display", "");
            }
        }

        /// <summary>
        /// Purpose: To bind all subCategories w.r.t the category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdCategories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserFoodLogBAO ObjUserFoodLogBAO = null;

                string CommentId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "pk_category_master_id"));

                GridView grdSubCategories = (GridView)e.Row.FindControl("grdSubCategories");


                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.Search_Name = CommentId;
                ObjUserFoodLogBAO.ID = "3";
                System.Data.DataTable retval = UserFoodLogDAO.ShowActivitiesBasedonSearchText(ObjUserFoodLogBAO);

                if (retval.Rows.Count > 0)
                {

                    grdSubCategories.DataSource = retval;
                    grdSubCategories.DataBind();
                }
                else
                {
                    grdSubCategories.DataSource = null;
                    grdSubCategories.DataBind();

                }

            }
        }
        /// <summary>
        /// Purpose: To bind all activities w.r.t the sub-category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdSubCategories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserFoodLogBAO ObjUserFoodLogBAO = null;

                string CommentId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fk_category_master_id"));
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.Search_Name = CommentId;
                ObjUserFoodLogBAO.ID = "4";
                System.Data.DataTable retval = UserFoodLogDAO.ShowActivitiesBasedonSearchText(ObjUserFoodLogBAO);

                if (retval.Rows.Count > 0)
                {
                    grdActivities.DataSource = retval;
                    grdActivities.DataBind();
                }
                else
                {
                    grdActivities.DataSource = null;
                    grdActivities.DataBind();

                }

            }
        }
        protected void grdSubCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectSubCategory")
            {
                string CommentId = e.CommandArgument.ToString();
                int index = Convert.ToInt32(e.CommandArgument);

                UserFoodLogBAO ObjUserFoodLogBAO = null;
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.Search_Name = CommentId;
                ObjUserFoodLogBAO.ID = "4";
                System.Data.DataTable retval = UserFoodLogDAO.ShowActivitiesBasedonSearchText(ObjUserFoodLogBAO);

                if (retval.Rows.Count > 0)
                {

                    grdActivities.DataSource = retval;
                    grdActivities.DataBind();
                }
                else
                {
                    grdActivities.DataSource = null;
                    grdActivities.DataBind();

                }
                modalPopActivities.Show();
                pnlActivities.Style.Add("display", "");
            }
        }

        protected void grdActivities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkActivity")
            {
                System.Threading.Thread.Sleep(1000);
                txtSearchActivities.Text = Convert.ToString(e.CommandArgument);
                UserFoodLogBAO ObjUserFoodLogBAO = null;
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.Search_Name = txtSearchActivities.Text;
                ObjUserFoodLogBAO.ID = "5";
                System.Data.DataTable retval = UserFoodLogDAO.ShowActivitiesBasedonSearchText(ObjUserFoodLogBAO);
                if (retval.Rows.Count > 0)
                {
                    BindFeatures();
                    if (retval.Rows[0]["Activity_step_status"].ToString() == "True")
                    {
                        divDistance.Style.Add("display", "");

                    }
                    else
                    {
                        divDistance.Style.Add("display", "none");
                    }
                }

                divDuration.Style.Add("display", "block");
                dvHeartRate.Style.Add("display", "block");
                txtDistance.Text = "";
                txtHeight.Text = "";
                txtHours.Text = "";
                txtminutes.Text = "";
                txtSec.Text = "";
                txtWeight.Text = "";

            }
        }

        private void Bind_History()
        {
            UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();

            ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
            if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
            {
                ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
            }
            else
            {
                ObjUserMissionsBAL.MissionId = 0;
            }
            ObjUserMissionsBAL.CaloriesBurnt = 0;
            objUserFoodLog.UFL_ID_FK = 0;
            ObjUserMissionsBAL.CaloriesEaten = 0;
            ObjUserMissionsBAL.DateId = 0;
            ObjUserMissionsBAL.Request_Type = 2;

            string toDayDate = System.DateTime.Now.ToString("MM/dd/yyyy");
            DateTime dtToDayDate = DateTime.Parse(toDayDate);


            if (!String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
            {
                string selectedDate = null;

                if (!String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                    selectedDate = hdnSelectedDateForMissionHistory.Value;



                var culture = System.Globalization.CultureInfo.CurrentCulture;


                dtToDayDate = Convert.ToDateTime(String.Format(selectedDate, "dd MMM yyyy"));
            }
            ObjUserMissionsBAL.DateOfCompletion = dtToDayDate;
            ObjUserMissionsBAL.Activity_Id = 0;
            ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
            ObjUserMissionsBAL.StepsCovered = 0;

            DataTable dtInput = UserMissionsDAL.SubmitMissionInput(ObjUserMissionsBAL);

            if (dtInput.Rows.Count > 0)
            {
                //dvFoodLogOfMissionId.Style.Add("display", "block");

                if (Convert.ToString(dtInput.Rows[0]["MissionTypeId"]) == "1" || String.IsNullOrEmpty(Convert.ToString(dtInput.Rows[0]["MissionTypeId"])))
                {
                    /*progress bar */

                    if (!String.IsNullOrEmpty(Convert.ToString(dtInput.Rows[0]["MissionTypeId"])))
                    {

                        double calConsumePercentage = System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageCaloriesConsumeToday"].ToString()), 0);

                        if (calConsumePercentage <= 100.00)
                            spConsumedCaloriesToday.InnerText = dtInput.Rows[0]["TotalCalorieEatenToday"].ToString() + " | " + calConsumePercentage + "%";
                        else
                            spConsumedCaloriesToday.InnerText = dtInput.Rows[0]["TotalCalorieEatenToday"].ToString() + " | 100 %";


                        double calBurnPercentage = System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageOfCaloriesBurnToday"].ToString()), 0);

                        if (calBurnPercentage <= 100.00)
                            spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString() + " | " + calBurnPercentage + "%";
                        else
                            spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString() + " | 100 %";



                        ////  spRemainingFromTotal.InnerText = dtInput.Rows[0]["GrossTotalCaloriesToBurn"].ToString() + " | " + System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageGrossCaloriesRemaining"].ToString()), 0) + "%";

                        string CalLeftToday = dtInput.Rows[0]["CalorieLeftToBurnToday"].ToString();
                        if (CalLeftToday.Contains("-"))
                        {
                            CalLeftToday = "0";
                        }

                        spCalToBurnToday.InnerText = CalLeftToday;
                        spCalToBurnTodayMsg.InnerText = "Calories Left To Burn Today";

                        Session["ProgressBarPercentage"] = System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageGrossCaloriesRemaining"].ToString()), 0);
                        //dvRegionOfCalsBurn.Visible = true;
                    }
                    else
                    {
                        spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString();
                        spConsumedCaloriesToday.InnerText = dtInput.Rows[0]["TotalCalorieEatenToday"].ToString();
                        //dvRegionOfCalsBurn.Visible = false;
                        Session["ProgressBarPercentage"] = null;
                    }

                    //spRemainingMsg.InnerText = "Target Cals Remaining";
                    if (!String.IsNullOrEmpty(Convert.ToString(Session["Group_Mission"])))
                    {
                        spTodayMsg.InnerText = "Group Cals Consumption";
                        spBurnMsg.InnerText = "Group Cals Burnt";
                    }
                    else
                    {
                        spTodayMsg.InnerText = "Cals Consumed Today";
                        spBurnMsg.InnerText = "Cals Burnt Today";
                    }

                }
                else
                {
                    /*progress bar */
                    //  spRemainingFromTotal.InnerText = dtInput.Rows[0]["GrossTotalStepsRemainingToCover"].ToString() + " | " + System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageGrossStepsRemaining"].ToString()), 0) + "%";
                    //  spRemainingMsg.InnerText = "Steps Remaining";

                    /* calories burns today */
                    double calPercentage = System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageOfCaloriesBurnToday"].ToString()), 0);

                    if (calPercentage <= 100.00)
                        spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString() + " | " + calPercentage + "%";
                    else
                        spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString() + " | 100 %";


                    string CalLeftToday = dtInput.Rows[0]["TotalStepsLeftToday"].ToString();
                    if (CalLeftToday.Contains("-"))
                    {
                        CalLeftToday = "0";
                    }

                    spCalToBurnToday.InnerText = CalLeftToday;
                    spCalToBurnTodayMsg.InnerText = "Steps Left Today";

                    spBurnMsg.InnerText = "Cals Burnt Today";

                    /* calories consumed today */
                    spConsumedCaloriesToday.InnerText = dtInput.Rows[0]["TotalStepsCoveredToday"].ToString();// +" | " + System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageCaloriesConsumeToday"].ToString()), 0) + "%";

                    if (!String.IsNullOrEmpty(Convert.ToString(Session["Group_Mission"])))
                    {
                        spTodayMsg.InnerText = "Group Steps Covered";
                    }
                    else
                    {
                        spTodayMsg.InnerText = "Steps Taken Today";
                    }

                    Session["ProgressBarPercentage"] = System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageGrossStepsRemaining"].ToString()), 0);

                }

                //spCaloriesBudget.InnerText = dtInput.Rows[0]["CaloriesToBurnToday"].ToString();
                ViewState["mission_type"] = Convert.ToString(dtInput.Rows[0]["MissionTypeId"]);
                if (Convert.ToString(dtInput.Rows[0]["MissionTypeId"]) == "1")
                {
                    dvBreadCrumInput.Style.Add("display", "");
                    dvFav.Style.Add("display", "");
                    breadcrumb_mission.Style.Add("display", "none");
                    dvWeightLooseMission.Visible = true;
                    dvStepsCoveredMission.Visible = false;
                    BindCAt();
                    //BindFoodLog();
                    //dvSerach.Style.Add("display", "none");
                }
                else if (Convert.ToString(dtInput.Rows[0]["MissionTypeId"]) == "2")
                {
                    dvBreadCrumInput.Style.Add("display", "none");
                    breadcrumb_mission.Style.Add("display", "");
                    dvFav.Style.Add("display", "none");
                    dvStepsCoveredMission.Visible = true;
                    dvWeightLooseMission.Visible = false;
                }
            }
            /*
             * Checks if the mission is Public and Individual
             * */


            if (Convert.ToInt32(dtInput.Rows[0]["CreatedByUserId"]) != Convert.ToInt32(MySession.Current.LoginId))
            {
                if (Convert.ToInt32(dtInput.Rows[0]["GroupIndividual"]) == 2 && Convert.ToInt32(dtInput.Rows[0]["PublicPrivate"]) == 1)
                {
                    tblMissionInput.Visible = false;
                    tblWarning.Visible = true;
                    spCreatedByUserName.InnerText = Convert.ToString(dtInput.Rows[0]["CreatedByUserName"]);

                }
                else
                {
                    tblMissionInput.Visible = true;
                    tblWarning.Visible = false;
                }
            }
            else
            {
                tblMissionInput.Visible = true;
                tblWarning.Visible = false;
            }
            //lblFitBitCalData.Text = Convert.ToString(Session["cal_burn_from_tracker"]);
           // lblFitBitStepsData.Text = Convert.ToString(Session["steps_from_tracker"]);
        }
        protected void btnSubmitStepsCovered_Click(object sender, EventArgs e)
        {
            //AddDailyCaloriesInput(0, Convert.ToDecimal(txtStepsCovered.Text.Trim()), 0, 1, "", 0);
            //Bind_History();
        }

        private void BindCAt()
        {
            DataTable dt = new DataTable();
            objUserFoodLog.ProcedureType = "FC";
            dt = UserFoodLogDAO.GetFoodCategories(objUserFoodLog);
            dMajor.DataSource = dt;
            dMajor.DataBind();
        }

        protected void dMajor_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater dMajorSubcat = (Repeater)e.Item.FindControl("dMajorSubcat");
                LinkButton lnkCat = (LinkButton)e.Item.FindControl("lnkCat");
                Label lbid = (Label)e.Item.FindControl("lbid");
                HtmlAnchor ancMajorCategories = (HtmlAnchor)e.Item.FindControl("ancMajorCategories");
                DataTable dtPsubcat = new DataTable();
                objUserFoodLog.ID = Convert.ToInt32(lbid.Text);
                objUserFoodLog.ProcedureType = "FS";
                dtPsubcat = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);
                if (dtPsubcat.Rows.Count > 0)
                {
                    ancMajorCategories.Visible = true;
                    lnkCat.Visible = false;
                    dMajorSubcat.DataSource = dtPsubcat;
                    dMajorSubcat.DataBind();
                }
                else
                {
                    ancMajorCategories.Visible = false;
                    lnkCat.Visible = true;
                }

            }
        }
        protected void dMajorSubcat_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbPsubcatid = (Label)e.Item.FindControl("lbPsubcatid");
                LinkButton lnkBtnMAjorSubcat = (LinkButton)e.Item.FindControl("lnkBtnMAjorSubcat");
                HtmlAnchor a1 = (HtmlAnchor)e.Item.FindControl("a1");
                Repeater dSubcat = (Repeater)e.Item.FindControl("dSubcat");
                DataTable dtsubcat = new DataTable();
                objUserFoodLog.ID = Convert.ToInt32(lbPsubcatid.Text);
                objUserFoodLog.ProcedureType = "FC";
                dtsubcat = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);

                if (dtsubcat.Rows.Count > 0)
                {
                    a1.Visible = true;
                    lnkBtnMAjorSubcat.Visible = false;
                    dSubcat.DataSource = dtsubcat;
                    dSubcat.DataBind();
                }
                else
                {
                    a1.Visible = false;
                    lnkBtnMAjorSubcat.Visible = true;
                }
            }
        }

        protected void dSubcat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "lnkBtnSubcat")
            {
                Searchname = e.CommandArgument.ToString().Replace(",", " ");
          
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

            }
        }

        protected void dMajorSubcat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "lnkBtnMAjorSubcat")
            {
                Searchname = e.CommandArgument.ToString().Replace(",", " ");
          
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

            }
        }
        protected void dMajor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "lnkCat")
            {
                Searchname = e.CommandArgument.ToString().Replace(",", " ");
      
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);
            }
        }
        public class CurrencyRates
        {
            public string numFound { get; set; }
            public string resultSize { get; set; }
            public string session_id { get; set; }
            public string Base { get; set; }
            public List<object> productsArray { get; set; }
        }

        public class CurrencyRates1
        {
            public string product { get; set; }
            public string product_name { get; set; }
            public string brand { get; set; }
            public string manufacturer { get; set; }
            public List<object> nutrients { get; set; }
        }


        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                string a = "";
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                    // if string with JSON data is not empty, deserialize it to class and return its instance
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                if (json_data != "")
                {
                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
                }
                else
                {
                    return string.IsNullOrEmpty(a) ? JsonConvert.DeserializeObject<T>(a) : new T();
                }
            }

        }

        private static T _download_serialized_json_data_2<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                string a = "";
                var json_data = string.Empty;

                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url.Replace(",", "").Replace("''", "").Replace("\"", "").Replace("\r\n", "").Replace("\"", "").Replace("''", "").Replace("\"", "").Replace("''", "").Replace(",", ""));
                    json_data = json_data.Substring(11, json_data.Length - 12);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                if (json_data != "")
                {
                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
                }
                else
                {
                    return string.IsNullOrEmpty(a) ? JsonConvert.DeserializeObject<T>(a) : new T();
                }
            }
        }

   

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtDistance.Text = "";
            txtHeight.Text = "";
            txtHours.Text = "";
            txtminutes.Text = "";
            txtSec.Text = "";
            txtWeight.Text = "";

            Searchname = txtSearch.Text.Trim();
            Bind_History();

            //bindGrd();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);
        }

        protected void grData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblUpc = (Label)e.Row.FindControl("lblUpc");
                Label lbCal = (Label)e.Row.FindControl("lbcal");
                Label lbfat = (Label)e.Row.FindControl("lbfat");
                Label lbchol = (Label)e.Row.FindControl("lbChol");
                Label lbfiber = (Label)e.Row.FindControl("lbFiber");
                Label lbsugar = (Label)e.Row.FindControl("lbSugar");
                if (lbCal.Text == "")
                {
                    lbCal.Text = "0.0";
                }
                if (lbfat.Text == "")
                {
                    lbfat.Text = "0.0";
                }
                if (lbchol.Text == "")
                {
                    lbchol.Text = "0.0";
                }

                if (lbfiber.Text == "")
                {
                    lbfiber.Text = "0.0";
                }

                if (lbsugar.Text == "")
                {
                    lbsugar.Text = "0.0";
                }

                ImageButton imgAdd = (ImageButton)e.Row.FindControl("imgAdd");
                imgAdd.Visible = true;

                if (Convert.ToString(ViewState["mission_overall_status"]) == "1")
                {
                    imgAdd.Visible = false;
                }

                /*
                 * binding link button results through api
                 * */

                Label lbTotalcal = (Label)e.Row.FindControl("lbTotalcal");
                Label lbtotalfat = (Label)e.Row.FindControl("lbtotalfat");
                Label lbtotalchol = (Label)e.Row.FindControl("lbtotalchol");
                Label lbTotalSodium = (Label)e.Row.FindControl("lbTotalSodium");
                Label lbtotalCarbs = (Label)e.Row.FindControl("lbtotalCarbs");
                Label lbTotalFiber = (Label)e.Row.FindControl("lbTotalFiber");
                Label lbTotalProteins = (Label)e.Row.FindControl("lbTotalProteins");
                Label lbTotalSugar = (Label)e.Row.FindControl("lbTotalSugar");
                Label lbCalsTotal = (Label)e.Row.FindControl("lbCalsTotal");
                ImageButton ImgAddLog = (ImageButton)e.Row.FindControl("ImgAddLog");

                //string[] arg = new string[3];

                //Searchname = arg[2];
                string data1 = null;
                //string id = arg[0];
                DataTable table = new DataTable("ApiData");

                table.Columns.Add("cal", typeof(string));
                table.Columns.Add("Cholesterol", typeof(string));
                table.Columns.Add("Fiber", typeof(string));
                table.Columns.Add("Protein", typeof(string));
                table.Columns.Add("Sodium", typeof(string));
                table.Columns.Add("Sugars", typeof(string));
                table.Columns.Add("Carbohydrate", typeof(string));
                table.Columns.Add("Fat", typeof(string));
                string url1 = "http://api.foodessentials.com/productscore?u=" + lblUpc.Text.Trim() + "&sid=825655af-789e-482f-9ae1-2ce4f867a466&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";
                int cal = 0;
                int unit = 0;
                var currencyRates1 = _download_serialized_json_data_2<CurrencyRates1>(url1);
                if (currencyRates1 != null)
                {
                    if (currencyRates1.nutrients != null)
                    {
                        if (currencyRates1.nutrients.Count > 0)
                        {
                            for (var x1 = 0; x1 < currencyRates1.nutrients.Count; x1++)
                            {
                                data1 = currencyRates1.nutrients[x1].ToString();
                                cal = data1.IndexOf("nutrient_value");
                                unit = data1.IndexOf("nutrient_uom");
                                int nu_feLevel = data1.IndexOf("nutrient_fe_level");



                                string text = Convert.ToString(data1.Substring(23, 6));

                                if (text == "Calori")
                                {
                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                    {

                                        nutr_vale = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                        lbCalsTotal.Text = Convert.ToString(nutr_vale);
                                        lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";
                                    }
                                    else
                                    {
                                        nutr_vale = 0;
                                        lbCalsTotal.Text = Convert.ToString(nutr_vale) + "cal";
                                        lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";

                                    }

                                }
                                else if (text == "Choles")
                                {
                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                    {

                                        nutr_vale1 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                        lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
                                    }
                                    else
                                    {
                                        nutr_vale1 = 0;
                                        lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
                                    }

                                }
                                else if (text == "Dietar")
                                {
                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                    {

                                        nutr_vale2 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                        lbTotalFiber.Text = Convert.ToString(nutr_vale2) + "g";
                                    }
                                    else
                                    {
                                        nutr_vale2 = 0;
                                        lbTotalFiber.Text = Convert.ToString(nutr_vale2) + "g";
                                    }

                                }

                                else if (text == "Protei")
                                {
                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                    {

                                        nutr_vale3 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                        lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
                                    }
                                    else
                                    {
                                        nutr_vale3 = 0;
                                        lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
                                    }

                                }

                                else if (text == "Sodium")
                                {
                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                    {

                                        nutr_vale4 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                        lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
                                    }
                                    else
                                    {
                                        nutr_vale4 = 0;
                                        lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
                                    }

                                }

                                else if (text == "Sugars")
                                {
                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                    {

                                        nutr_vale5 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                        lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
                                    }
                                    else
                                    {
                                        nutr_vale5 = 0;
                                        lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
                                    }

                                }
                                if (total == null)
                                {
                                    if (text == "Total ")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale6 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            total = text;
                                            lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
                                        }
                                        else
                                        {
                                            nutr_vale6 = 0;
                                            lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
                                        }

                                    }
                                }
                                else
                                {
                                    if (text == "Total ")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale7 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
                                        }
                                        else
                                        {
                                            nutr_vale7 = 0;
                                            lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
                                        }
                                    }
                                }
                            }
                            //lbtotalfat.Text = "rishi";
                            // table.Rows.Add(nutr_vale, nutr_unit);
                            //Pro_size = arg[1];
                            table.Rows.Add(nutr_vale, nutr_vale1, nutr_vale2, nutr_vale3, nutr_vale4, nutr_vale5, nutr_vale6, nutr_vale7);
                        }
                    }
                }
            }
        }
        protected void GrdFoodLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[7].Visible = true;

                if (Convert.ToString(ViewState["mission_overall_status"]) == "1")
                {
                    e.Row.Cells[7].Visible = false;
                }

                string toDayDate = System.DateTime.Now.ToString("MM/dd/yyyy");
                DateTime dtToDayDate = DateTime.Parse(toDayDate);

                if (!String.IsNullOrEmpty(Convert.ToString(txtCalendarNavigation.Text.Trim())) || !String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                {
                    string selectedDate = null;

                    if (!String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                        selectedDate = hdnSelectedDateForMissionHistory.Value;
                    else if (!String.IsNullOrEmpty(Convert.ToString(txtCalendarNavigation.Text.Trim())))
                        selectedDate = txtCalendarNavigation.Text.Trim();


                    DateTime dtSelectedDate = DateTime.Parse(selectedDate);

                    if (dtToDayDate > dtSelectedDate)
                    {
                        e.Row.Cells[7].Visible = false;
                    }
                }

                if (Session["link_selection"].ToString() == "1")
                {
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                else
                {
                    e.Row.Cells[0].Visible = false;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;

                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (Convert.ToString(ViewState["mission_overall_status"]) == "1")
                {
                    e.Row.Cells[7].Visible = false;
                }

                string toDayDate = System.DateTime.Now.ToString("MM/dd/yyyy");
                DateTime dtToDayDate = DateTime.Parse(toDayDate);

                if (!String.IsNullOrEmpty(Convert.ToString(txtCalendarNavigation.Text.Trim())) || !String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                {
                    string selectedDate = null;

                    if (!String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                        selectedDate = hdnSelectedDateForMissionHistory.Value;
                    else if (!String.IsNullOrEmpty(Convert.ToString(txtCalendarNavigation.Text.Trim())))
                        selectedDate = txtCalendarNavigation.Text.Trim();


                    DateTime dtSelectedDate = DateTime.Parse(selectedDate);

                    if (dtToDayDate > dtSelectedDate)
                    {
                        e.Row.Cells[7].Visible = false;
                    }
                }
                if (Session["link_selection"].ToString() == "1")
                {
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                }
                else
                {
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                }

            }
        }
  

        protected void lnkSinkDataFromFitBit_Click(object sender, EventArgs e)
        {
            Fetch_CaloriesBurnFrom_FitBitApi(Convert.ToInt32(MySession.Current.LoginId));
            Session["FoodLog"] = true;
            Session["track_mission"] = true;
            Session["navigated_date_selected"] = hdnSelectedDateForMissionHistory.Value;
            if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
            {
                Response.Redirect("Log.aspx?MissionSelected=True", false);
            }
            else
            {
                Response.Redirect("Log.aspx", false);
            }
        }
        protected void CheckIf_FitBitDetailsPresent(int login_user_id)
        {
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            objRegisterUserBAO.fk_user_registration_id = login_user_id;
            objRegisterUserBAO.AccessToken = "0";
            objRegisterUserBAO.AccessTokenSecret = "0";
            objRegisterUserBAO.procedureType = "1";
            DataTable dtgetFitBitDetails = new DataTable();

            dtgetFitBitDetails = RegisterUserDAO.AddFitBitKeys(objRegisterUserBAO);
            if (dtgetFitBitDetails.Rows.Count == 0)
            {

                OAuthRequest request = null;
                OAuthResponse response = null;


                const string ConsumerKey = "68308bc1af7d419c8f5489f25e7555ad";
                const string ConsumerSecret = "78ffc3a4a18249ff94c3d84a34cbb217";
                const string RequestTokenUrl = "http://www.fitbit.com/oauth/request_token";

                string AuthorizationUrl = "http://www.fitbit.com/oauth/authorize";
                const string AccessTokenUrl = "http://api.fitbit.com/oauth/access_token";

                OAuthService service = OAuthService.Create(
                                new EndPoint(RequestTokenUrl, "POST"),         // requestTokenEndPoint
                                new Uri(AuthorizationUrl),                     // authorizationUri
                                new EndPoint(AccessTokenUrl, "POST"),          // accessTokenEndPoint
                                true,                                          // useAuthorizationHeader
                                "http://api.fitbit.com",                       // realm
                                "HMAC-SHA1",                                   // signatureMethod
                                "1.0",                                         // oauthVersion
                                new OAuthConsumer(ConsumerKey, ConsumerSecret) // consumer
                                );


                request = OAuthRequest.Create(
                                               new OAuth.Net.Consumer.EndPoint("http://api.fitbit.com", "GET"),
                                               service,
                                               this.Context.Request.Url,
                                             this.Context.Session.SessionID);

                request.VerificationHandler = AspNetOAuthRequest.HandleVerification;

                response = request.GetResource();

                string authorizationUrl = service.BuildAuthorizationUrl(response.Token).AbsoluteUri;
                lnkSinkDataFromFitBit.Attributes.Add("onclick", "javascript:return PostToNewWindow('" + authorizationUrl + "');");
            }

        }
        /// <summary>
        /// Calling FitBit Api.
        /// </summary>
        /// <param name="CaloriesConsumed"></param>
        /// <param name="CaloriesBurnt"></param>
        /// <param name="pk_user_log_id"></param>
        /// <param name="request_type"></param>

        private void Fetch_CaloriesBurnFrom_FitBitApi(int login_user_id)
        {
            OAuthRequest request = null;
            OAuthResponse response = null;
            OAuthService service = null;
            DataTable dtgetFitBitDetails = null;
            RegisterUserBAO objRegisterUserBAO = null;
            DataTable dtInsertFitBitDetails = null;
            RegisterUserBAO objInsertRegisterUserBAO = null;
            ArrayList arrDates = new ArrayList(7);
            int time_Calculated = 0;

            try
            {
                #region to decalre FitBit essentials

                const string ConsumerKey = "68308bc1af7d419c8f5489f25e7555ad";
                const string ConsumerSecret = "78ffc3a4a18249ff94c3d84a34cbb217";
                const string RequestTokenUrl = "http://www.fitbit.com/oauth/request_token";
                string AuthorizationUrl = "http://www.fitbit.com/oauth/authorize";
                const string AccessTokenUrl = "http://api.fitbit.com/oauth/access_token";

                #endregion

                #region to change format of the date selected

                DateTime dt_todaydate = Convert.ToDateTime(System.DateTime.Now.ToString());
                string str_getTodayDate = dt_todaydate.ToString("yyyy-MM-dd");

                DateTime today = Convert.ToDateTime(txtCalendarNavigation.Text); // As DateTime
                string myDate = null;

                if (String.IsNullOrEmpty(Convert.ToString(Session["navigated_date_selected"])))
                {
                    myDate = today.ToString("yyyy-MM-dd"); // As String
                }
                else
                {
                    myDate = Convert.ToDateTime(Session["navigated_date_selected"]).ToString("yyyy-MM-dd");
                }
                DateTime dtToDayDate = DateTime.Parse(myDate);

                #endregion

                string ApiCallUrl = "http://api.fitbit.com/1/user/-/activities/date/" + myDate.ToString() + ".xml";


                /* Step - 1 : The user Access tokens are checked if they are present or not in database */

                dtgetFitBitDetails = new DataTable();
                objRegisterUserBAO = new RegisterUserBAO();

                objRegisterUserBAO.fk_user_registration_id = login_user_id;
                objRegisterUserBAO.AccessToken = "0";
                objRegisterUserBAO.AccessTokenSecret = "0";
                objRegisterUserBAO.procedureType = "1";
                dtgetFitBitDetails = RegisterUserDAO.AddFitBitKeys(objRegisterUserBAO);

                if (dtgetFitBitDetails.Rows.Count == 0)
                {
                    /* Step - 2 : The user is first time synching data from the tracker so the pop will be shown */

                    service = OAuthService.Create(
                       new EndPoint(RequestTokenUrl, "POST"),         // requestTokenEndPoint
                       new Uri(AuthorizationUrl),                     // authorizationUri
                       new EndPoint(AccessTokenUrl, "POST"),          // accessTokenEndPoint
                       true,                                          // useAuthorizationHeader
                       "http://api.fitbit.com",                       // realm
                       "HMAC-SHA1",                                   // signatureMethod
                       "1.0",                                         // oauthVersion
                       new OAuthConsumer(ConsumerKey, ConsumerSecret) // consumer
                       );


                    request = OAuthRequest.Create(
                       new OAuth.Net.Consumer.EndPoint(ApiCallUrl, "GET"),
                       service,
                       this.Context.Request.Url,
                     this.Context.Session.SessionID);


                    request.VerificationHandler = AspNetOAuthRequest.HandleVerification;
                    response = request.GetResource();

                    if (!response.HasProtectedResource)
                    {
                        string authorizationUrl = service.BuildAuthorizationUrl(response.Token).AbsoluteUri;
                        lnkSinkDataFromFitBit.Attributes.Add("onclick", "javascript:return PostToNewWindow('" + authorizationUrl + "');");
                    }
                    else
                    {
                        /* After the authentication the access token details are saved in the database  */

                        objInsertRegisterUserBAO = new RegisterUserBAO();
                        objInsertRegisterUserBAO.fk_user_registration_id = login_user_id;
                        objInsertRegisterUserBAO.AccessToken = response.Token.Token;
                        objInsertRegisterUserBAO.AccessTokenSecret = response.Token.Secret;
                        objInsertRegisterUserBAO.procedureType = "1";
                        dtInsertFitBitDetails = new DataTable();

                        dtInsertFitBitDetails = RegisterUserDAO.AddFitBitKeys(objInsertRegisterUserBAO);

                        if (response.ProtectedResource != null)
                        {
                            caloriesDoc = new XmlDocument();
                            caloriesDoc.Load(response.ProtectedResource.GetResponseStream());

                            if (str_getTodayDate == myDate)
                            {
                                SubmitInput_FromTracker(true, response, caloriesDoc, login_user_id, ApiCallUrl, time_Calculated, myDate);
                                Submitting_lastWeekInput_fromTracker(arrDates, response, objInsertRegisterUserBAO, login_user_id, str_getTodayDate, ApiCallUrl, time_Calculated, this.caloriesDoc);
                                //Retrieve_WeightFrom_Tracker(myDate, login_user_id);
                            }
                            else
                            {
                                SubmitInput_FromTracker(true, response, this.caloriesDoc, login_user_id, ApiCallUrl, time_Calculated, myDate);
                                //                                Retrieve_WeightFrom_Tracker(myDate, login_user_id);
                            }
                        }
                    }
                }
                else
                {
                    /* If the user's access tokens are available in the database , then WebResponse is used to load  */

                    this.caloriesDoc = new XmlDocument();

                    if (String.IsNullOrEmpty(Convert.ToString(Session["navigated_date_selected"])) || str_getTodayDate == myDate)
                    {
                        Submitting_lastWeekInput_fromTracker(arrDates, response, objInsertRegisterUserBAO, login_user_id, str_getTodayDate, ApiCallUrl, time_Calculated, this.caloriesDoc);
                        //                        Retrieve_WeightFrom_Tracker(myDate, login_user_id);
                    }
                    else
                    {
                        myDate = Convert.ToDateTime(Session["navigated_date_selected"]).ToString("yyyy-MM-dd");
                        ApiCallUrl = "http://api.fitbit.com/1/user/-/activities/date/" + myDate.ToString() + ".xml";

                        SubmitInput_FromTracker(false, response, this.caloriesDoc, login_user_id, ApiCallUrl, time_Calculated, myDate);
                        //                        Retrieve_WeightFrom_Tracker(myDate, login_user_id);
                    }
                }
            }
            catch (WebException ex)
            {
                Response.Write(ex.Message);
                Response.Close();
            }
            catch (OAuthRequestException ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
            FitBit_AuthenticationCode();
        }

        protected void Retrieve_WeightFrom_Tracker(string dateSelected, Int32 login_user_id)
        {
            RegisterUserBAO objInsertRegisterUserBAO = null;
            DataTable dtInsertFitBitDetails = null;
            try
            {

                string apiCall_Weight = String.Format("http://api.fitbit.com/1/user/-/body/log/weight/date/{0}.xml", dateSelected);
                XmlDocument weightDoc = Retrieve_FitBitTokenDetails(Convert.ToInt32(MySession.Current.LoginId), apiCall_Weight);

                var getWeight = weightDoc["result"]["weight"]["weightLog"]["weight"].InnerText.ToString();
                var getMass = weightDoc["result"]["weight"]["weightLog"]["bmi"].InnerText.ToString();

                string apiCall_fat = String.Format("http://api.fitbit.com/1/user/-/body/log/fat/date/{0}.xml", dateSelected);
                XmlDocument fatDoc = Retrieve_FitBitTokenDetails(Convert.ToInt32(MySession.Current.LoginId), apiCall_fat);
                var getFat = weightDoc["result"]["fat"]["fatLog"]["fat"].InnerText.ToString();

                var getLogDate = weightDoc["result"]["weight"]["weightLog"]["date"].InnerText.ToString();

                objInsertRegisterUserBAO = new RegisterUserBAO();

                objInsertRegisterUserBAO.LoginId = login_user_id;
                objInsertRegisterUserBAO.FitBitBodyWeight = Convert.ToDecimal(getWeight);

                objInsertRegisterUserBAO.FitBitBodyMass = Convert.ToDecimal(getMass);
                objInsertRegisterUserBAO.FitBitBodyFat = Convert.ToDecimal(getFat);
                objInsertRegisterUserBAO.FitBitBodyInfoLogDate = dateSelected;
                dtInsertFitBitDetails = new DataTable();

                dtInsertFitBitDetails = RegisterUserDAO.LogBodyMeasurement(objInsertRegisterUserBAO);
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
            objInsertRegisterUserBAO = null;
        }
        /// <summary>
        /// Purpose : To submit user's previous 6 days input from fitbit
        ///             a loop will run iff the selected date was today's date
        ///             else only todays date input will be calculated.
        ///             
        /// </summary>
        /// <param name="arrDates"></param>
        /// <param name="response"></param>
        /// <param name="objInsertRegisterUserBAO"></param>
        /// <param name="login_user_id"></param>
        /// <param name="str_getTodayDate"></param>
        /// <param name="ApiCallUrl"></param>
        /// <param name="time_Calculated"></param>
        /// <param name="caloriesDoc"></param>
        private void Submitting_lastWeekInput_fromTracker(ArrayList arrDates, OAuthResponse response, RegisterUserBAO objInsertRegisterUserBAO, Int32 login_user_id, string str_getTodayDate, string ApiCallUrl, Int32 time_Calculated, XmlDocument caloriesDoc)
        {
            DataTable dtInsertFitBitDetails = null;
            try
            {
                DateTime today = Convert.ToDateTime(txtCalendarNavigation.Text); // As DateTime
                string myDate = null;

                if (String.IsNullOrEmpty(Convert.ToString(Session["navigated_date_selected"])))
                {
                    myDate = today.ToString("yyyy-MM-dd"); // As String
                }
                else
                {
                    myDate = Convert.ToDateTime(Session["navigated_date_selected"]).ToString("yyyy-MM-dd");
                }
                DateTime dtToDayDate = DateTime.Parse(myDate);

                if (str_getTodayDate == myDate)
                {
                    for (int iPreviousDates = 0; iPreviousDates <= 6; iPreviousDates++)
                    {
                        Int32 getpreviousDate = Convert.ToInt32(iPreviousDates.ToString());
                        arrDates.Add(today.AddDays(-getpreviousDate));
                    }
                }
                else
                {
                    arrDates.Add(myDate);
                }
                foreach (DateTime arrItem in arrDates)
                {
                    string formatedDate = arrItem.ToString("yyyy-MM-dd").Replace("12:00:00 AM", "");
                    objInsertRegisterUserBAO = new RegisterUserBAO();

                    objInsertRegisterUserBAO.fk_user_registration_id = login_user_id;
                    objInsertRegisterUserBAO.T_DATE = formatedDate;
                    dtInsertFitBitDetails = new DataTable();

                    dtInsertFitBitDetails = RegisterUserDAO.Get_MissionLogDatesOfuser(objInsertRegisterUserBAO);

                    if (Convert.ToString(dtInsertFitBitDetails.Rows[0]["DateStatus"]) == "0" || str_getTodayDate == myDate)
                    {
                        ApiCallUrl = "http://api.fitbit.com/1/user/-/activities/date/" + formatedDate.ToString() + ".xml";
                        SubmitInput_FromTracker(false, response, caloriesDoc, login_user_id, ApiCallUrl, time_Calculated, formatedDate);
                        //                        Retrieve_WeightFrom_Tracker(formatedDate, login_user_id);
                    }
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
        }
        /// <summary>
        /// Purpose : To add input from fitbit account iff the user has come from first time authentication
        ///           else if the user has selected different date from today and has come for the first time from fitbit window
        ///           the data has been retrieved from the WebResponse object.
        /// </summary>
        /// <param name="firstTime"></param>
        /// <param name="response"></param>
        /// <param name="caloriesDoc"></param>
        /// <param name="login_user_id"></param>
        /// <param name="ApiCallUrl"></param>
        /// <param name="time_Calculated"></param>
        /// <param name="myDate"></param>
        private void SubmitInput_FromTracker(bool firstTime, OAuthResponse response, XmlDocument caloriesDoc, Int32 login_user_id, string ApiCallUrl, Int32 time_Calculated, string myDate)
        {
            if (!firstTime)
                caloriesDoc = Retrieve_FitBitTokenDetails(Convert.ToInt32(login_user_id), ApiCallUrl);

            var caloriesBurnt = caloriesDoc["result"]["summary"]["caloriesOut"].InnerText.ToString();
            var caloriesDistance = caloriesDoc["result"]["summary"]["distances"].SelectNodes("activityDistance")[1]["activity"].NextSibling.InnerText.ToString();

            if (Convert.ToString(caloriesDistance) != "0")
            {
                int iCountCaloriesNode = 1;
                var caloriesFloors = caloriesDoc["result"]["summary"]["floors"].InnerText.ToString();
                var caloriesSteps = caloriesDoc["result"]["summary"]["steps"].InnerText.ToString();
                time_Calculated = Convert.ToInt32(caloriesDoc["result"]["summary"]["fairlyActiveMinutes"].InnerText.ToString())
                                     + Convert.ToInt32(caloriesDoc["result"]["summary"]["lightlyActiveMinutes"].InnerText.ToString())
                                      + Convert.ToInt32(caloriesDoc["result"]["summary"]["veryActiveMinutes"].InnerText.ToString());

                AddDailyCaloriesInput(0, Convert.ToInt32(caloriesSteps), Convert.ToDecimal(caloriesBurnt), 0, 1, "Tracker", iCountCaloriesNode, myDate.ToString() + DateTime.Now.ToString(" HH:mm:ss tt"), Convert.ToDecimal(caloriesFloors), time_Calculated, Convert.ToDecimal(caloriesDistance));
            }
        }
        /// <summary>
        /// Purpose : To clear all the sessions after the fitbit account has been authenticated/denied and close the pop-up window.
        /// </summary>
        private void FitBit_AuthenticationCode()
        {
            Session["track_mission"] = "True";
            Session["access_token"] = null;
            Session["track_mission"] = null;

            string close = @"<script type='text/javascript'>
                                                window.opener.location.reload(true);
                                                window.returnValue = true;
                                                window.close();
                                              </script>";
            base.Response.Write(close);
            bindLogActivities();
            hdnCheckPostback.Value = "";
            Session["from_logActivities"] = "true";
        }
        /// <summary>
        /// Purpose :  To retrieve the FitBit credentials from the database and pass them to the WebResponse object .
        /// </summary>
        /// <param name="user_Id"></param>
        /// <param name="requested_url"></param>
        /// <returns></returns>
        protected XmlDocument Retrieve_FitBitTokenDetails(Int32 user_Id, string requested_url)
        {
            var oauth_token = "";
            var oauth_token_secret = "";

            DataTable dtgetFitBitDetails = new DataTable();
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            objRegisterUserBAO.fk_user_registration_id = user_Id;
            objRegisterUserBAO.AccessToken = "0";
            objRegisterUserBAO.AccessTokenSecret = "0";
            objRegisterUserBAO.procedureType = "1";

            dtgetFitBitDetails = RegisterUserDAO.AddFitBitKeys(objRegisterUserBAO);

            if (dtgetFitBitDetails.Rows[0]["AccessTokenSecret"].ToString() != "0")
            {
                oauth_token = dtgetFitBitDetails.Rows[0]["AccessTokenKey"].ToString();
                oauth_token_secret = dtgetFitBitDetails.Rows[0]["AccessTokenSecret"].ToString();
            }

            var oauth_consumer_key = "68308bc1af7d419c8f5489f25e7555ad";
            var oauth_consumer_secret = "78ffc3a4a18249ff94c3d84a34cbb217";

            // oauth implementation details
            var oauth_version = "1.0";
            var oauth_signature_method = "HMAC-SHA1";

            // unique request details
            var oauth_nonce = Convert.ToBase64String(
                new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            var timeSpan = DateTime.UtcNow
                - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

            // message api details
            var status = "Updating status via REST API if this works";
            var resource_url = requested_url;

            // create oauth signature
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                            "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}";

            var baseString = string.Format(baseFormat,
                                        oauth_consumer_key,
                                        oauth_nonce,
                                        oauth_signature_method,
                                        oauth_timestamp,
                                        oauth_token,
                                        oauth_version,
                                        Uri.EscapeDataString(status)
                                        );

            baseString = string.Concat("POST&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));

            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                                    "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            // create the request header
            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                               "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                               "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                               "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
                                    Uri.EscapeDataString(oauth_nonce),
                                    Uri.EscapeDataString(oauth_signature_method),
                                    Uri.EscapeDataString(oauth_timestamp),
                                    Uri.EscapeDataString(oauth_consumer_key),
                                    Uri.EscapeDataString(oauth_token),
                                    Uri.EscapeDataString(oauth_signature),
                                    Uri.EscapeDataString(oauth_version)
                            );


            // make the request
            var postBody = "status=" + Uri.EscapeDataString(status);

            ServicePointManager.Expect100Continue = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }
            WebResponse response = request.GetResponse();

            XmlDocument doc = new XmlDocument();
            doc = new XmlDocument();
            doc.Load(response.GetResponseStream());
            return doc;
        }

        /// <summary>
        /// Purpose :  To modify the weight of the user because of new log input through tracker, search, quick log.
        /// </summary>
        private void ModifyWeight_BasedOnLogInput(decimal calBurn, decimal calConsume, string modifiedOn, int fk_mission_log_id)
        {
            UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
            DataTable dtWeight = new DataTable();
            try
            {
                ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                ObjUserMissionsBAL.DateOfCompletion = DateTime.Parse(modifiedOn);
                ObjUserMissionsBAL.Activity_Id = Convert.ToInt32(fk_mission_log_id);
                ObjUserMissionsBAL.CaloriesBurnt = calBurn;
                ObjUserMissionsBAL.CaloriesEaten = calConsume;

                dtWeight = UserMissionsDAL.Weight_Adjustments(ObjUserMissionsBAL);
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
        }
        private void AddDailyCaloriesInput(decimal CaloriesConsumed, Int32 StepsCovered, decimal CaloriesBurnt, int pk_user_log_id, int request_type, string activity, int activity_id, string dateOfInput, decimal floors_Covered, Int32 time_minutes, decimal distanceCovered)
        {

            btnSubmitStepsCovered.Visible = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp12", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);
            UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
            ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);

            if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
            {
                ObjUserMissionsBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
            }
            else
            {
                ObjUserMissionsBAL.MissionId = 0;
            }
            ObjUserMissionsBAL.CaloriesBurnt = CaloriesBurnt; //Convert.ToDecimal(txtTodayInput.Text.Trim());
            ObjUserMissionsBAL.CaloriesEaten = CaloriesConsumed;

            ObjUserMissionsBAL.Pk_user_Log_Id = pk_user_log_id;
            ObjUserMissionsBAL.Request_Type = request_type;

            if (!String.IsNullOrEmpty(Convert.ToString(ViewState["QuickLog"])))
                ObjUserMissionsBAL.Activity_minutes = 20;
            else
                ObjUserMissionsBAL.Activity_minutes = time_minutes;

            ObjUserMissionsBAL.DateOfCompletion = DateTime.Parse(dateOfInput);
            ObjUserMissionsBAL.Activity_Performed = activity;
            ObjUserMissionsBAL.Activity_Id = Convert.ToInt32(activity_id);
            ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
            ObjUserMissionsBAL.StepsCovered = StepsCovered;
            ObjUserMissionsBAL.Floors_Covered = floors_Covered;
            ObjUserMissionsBAL.Distance_Covered = distanceCovered;

            DataTable dtInput = UserMissionsDAL.SubmitMissionInput(ObjUserMissionsBAL);
            ModifyWeight_BasedOnLogInput(Convert.ToDecimal(CaloriesBurnt), 0, DateTime.Parse(dateOfInput).ToString(), Convert.ToInt32(dtInput.Rows[0]["fk_mission_log_id"]));

            //if (dtInput != null)
            //{
            //    if (dtInput.Rows.Count > 0)
            //    {
            //        if (Convert.ToString(dtInput.Rows[0]["mission_overall_status"]) == "0")
            //        {
            //            btnSubmitStepsCovered.Visible = false;
            //            ViewState["mission_overall_status"] = 1;
            //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('This mission is accomplished now !');", true);
            //        }
            //    }
            //}
            ViewState["QuickLog"] = "";
        }

        //protected void imgManuallyConsumed_Click(object sender, ImageClickEventArgs e)
        //{
        //    AddDailyCaloriesInput(Convert.ToDecimal(txtManuallyConsumed.Text.Trim()), 0, Convert.ToInt32(MySession.Current.LoginId), 1);
        //    Bind_History();
        //}
        //protected void imgManuallyBurnt_Click(object sender, ImageClickEventArgs e)
        //{
        //    AddDailyCaloriesInput(0, Convert.ToDecimal(txtBurnedManually.Text.Trim()), Convert.ToInt32(MySession.Current.LoginId), 1);
        //    Bind_History();
        //}
        protected void imgPrevious_Click(object sender, ImageClickEventArgs e)
        {
            int alreadySelectedDate = Convert.ToInt32(hdnSelectedDateForMissionHistory.Value) - 1;
            hdnSelectedDateForMissionHistory.Value = Convert.ToString(alreadySelectedDate);

        }
        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            int alreadySelectedDate = Convert.ToInt32(hdnSelectedDateForMissionHistory.Value) + 1;
            hdnSelectedDateForMissionHistory.Value = Convert.ToString(alreadySelectedDate);
        }
        private void BindHistoryLogBasedOnDates(string selectedDate)
        {
            UserFoodLogBAO objUserFoodLogBAO = new UserFoodLogBAO();
            objUserFoodLogBAO.UFL_DATE = selectedDate;
            objUserFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            objUserFoodLogBAO.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
            DataTable dt = UserFoodLogDAO.ShowHistoryRecordsOnBasisOfDate(objUserFoodLogBAO);

            //if (dt.Rows.Count > 0)
            //{
            //    GrdFoodLog.Visible = true;
            //    GrdFoodLog.DataSource = dt;
            //    GrdFoodLog.DataBind();

            //}
            //else
            //{
            //    GrdFoodLog.Visible = false;
            //    GrdFoodLog.DataSource = null;
            //    GrdFoodLog.DataBind();

            //}

        }
        private void BindFoodLog()
        {

            if (!String.IsNullOrEmpty(Convert.ToString(Session["selected_mission_id"])))
            {
                DataTable dt = new DataTable();
                objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserFoodLog.UFL_DATE = DateTime.Now.ToString("MM/dd/yyyy");
                }

                else
                {
                    objUserFoodLog.UFL_DATE = Convert.ToString(String.Format(hdnSelectedDateForMissionHistory.Value, "dd MMM yyyy"));
                }
                objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                objUserFoodLog.ProcedureType = "V";
                objUserFoodLog.ID = 2;
                dt = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
                if (dt.Rows.Count > 0)
                {
                    //GrdFoodLog.Visible = true;
                    //GrdFoodLog.DataSource = dt;
                    //GrdFoodLog.DataBind();
                   // dvFoodLogOfMissionId.Style.Add("display", "block");
                    //piechartbind();
                }
                else
                {
                   // GrdFoodLog.Visible = false;
                    //dvChart.Style.Add("display", "none");
                //    dvFoodLogOfMissionId.Style.Add("display", "none");
                }
            }
        }
        protected void GrdFoodLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string lbid;
            //lbid = ((Label)GrdFoodLog.Rows[e.RowIndex].FindControl("lbID")).Text;
            //if (lbid != "")
            //{
            //    int retval = 0;
            //    objUserFoodLog.UFL_ID = lbid;
            //    objUserFoodLog.ProcedureType = "DF";
            //    retval = UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLog);
            //   // GrdFoodLog.EditIndex = -1;
            //    BindFoodLog();
            //    Bind_History();
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

            //}

        }

        protected void GrdFoodLog_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbid, txtcal;
            //lbid = ((Label)GrdFoodLog.Rows[e.RowIndex].FindControl("lbID")).Text;
            //txtcal = ((TextBox)GrdFoodLog.Rows[e.RowIndex].FindControl("txtcal")).Text;
           // Label lbREquired = (Label)GrdFoodLog.Rows[e.RowIndex].FindControl("lbRequired");
           //if ((txtcal) != "")
           // {
           //     DataTable dt = new DataTable();
           //     objUserRegisterBAO.ID = Convert.ToInt32(lbid);
           //     objUserRegisterBAO.procedureType = "FL";
           //     dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
           //     if (dt.Rows.Count > 0)
           //     {
           //         int retval = 0;
           //         objUserFoodLog.UFL_ID = lbid;
           //         objUserFoodLog.fk_user_registration_Id = dt.Rows[0]["fk_user_registration_Id"].ToString();
           //         objUserFoodLog.Search_Name = dt.Rows[0]["Search_Name"].ToString();
           //         objUserFoodLog.Product_Size = dt.Rows[0]["Product_Size"].ToString();
           //         objUserFoodLog.QUANTITY = "";
           //         objUserFoodLog.CALORIES = txtcal;
           //         objUserFoodLog.FAT = dt.Rows[0]["FAT"].ToString();
           //         objUserFoodLog.CHOLESTROL = dt.Rows[0]["CHOLESTROL"].ToString();
           //         objUserFoodLog.SODIUM = dt.Rows[0]["SODIUM"].ToString();
           //         objUserFoodLog.CARBOHYDRATES = dt.Rows[0]["CARBOHYDRATES"].ToString();
           //         objUserFoodLog.FIBER = dt.Rows[0]["FIBER"].ToString();
           //         objUserFoodLog.PROTIENS = dt.Rows[0]["PROTIENS"].ToString();
           //         objUserFoodLog.SUGAR = dt.Rows[0]["SUGAR"].ToString();
           //         objUserFoodLog.UFL_DATE = dt.Rows[0]["UFL_DATE"].ToString();
           //         objUserFoodLog.ProcedureType = "U";
           //         retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);

           //         AddDailyCaloriesInput(Convert.ToDecimal(txtcal), 0, 0, Convert.ToInt32(lbid), 2, "", 0, hdnSelectedDateForMissionHistory.Value + DateTime.Now.ToString(" HH:mm:ss tt"), 0, 0, 0);
           //     }
           //     //GrdFoodLog.EditIndex = -1;
           //     Bind_History();
           //     BindFoodLog();
           //     ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);
           // }
           // else
           // {
           //    // lbREquired.Visible = true;
           //     ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

           // }
        }

        protected void GrdFoodLog_RowEditing(object sender, GridViewEditEventArgs e)
        {
           // GrdFoodLog.EditIndex = e.NewEditIndex;

            BindFoodLog();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

        }

        protected void GrdFoodLog_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //GrdFoodLog.EditIndex = -1;
            BindFoodLog();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

        }

        protected void GrdFoodLog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkAddFAv")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                objUserRegisterBAO.ID = id;
                objUserRegisterBAO.procedureType = "FL";
                dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dt.Rows.Count > 0)
                {
                    int retval = 0;
                    objUserFoodLog.UAF_ID = 0;
                    objUserFoodLog.UFL_ID_FK = id;
                    objUserFoodLog.fk_user_registration_Id = dt.Rows[0]["fk_user_registration_Id"].ToString();
                    objUserFoodLog.FOOD_NAME = dt.Rows[0]["Search_Name"].ToString();
                    objUserFoodLog.Product_Size = dt.Rows[0]["Product_Size"].ToString();
                    objUserFoodLog.QUANTITY = dt.Rows[0]["QUANTITY"].ToString();
                    objUserFoodLog.CALORIES = dt.Rows[0]["CALORIES"].ToString();
                    objUserFoodLog.FAT = dt.Rows[0]["FAT"].ToString();
                    objUserFoodLog.CHOLESTROL = dt.Rows[0]["CHOLESTROL"].ToString();
                    objUserFoodLog.SODIUM = dt.Rows[0]["SODIUM"].ToString();
                    objUserFoodLog.CARBOHYDRATES = dt.Rows[0]["CARBOHYDRATES"].ToString();
                    objUserFoodLog.FIBER = dt.Rows[0]["FIBER"].ToString();
                    objUserFoodLog.PROTIENS = dt.Rows[0]["PROTIENS"].ToString();
                    objUserFoodLog.SUGAR = dt.Rows[0]["SUGAR"].ToString();
                    objUserFoodLog.UFA_DATE = DateTime.Now.ToString();
                    objUserFoodLog.UFL_DATE = dt.Rows[0]["UFL_DATE"].ToString();
                    objUserFoodLog.ProcedureType = "I";
                    retval = UserFoodLogDAO.InserttblAddFavouriteFoodLog(objUserFoodLog);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

                }
            }
            else if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                UserFoodLogBAO objUserFoodLogBAO = new UserFoodLogBAO();
                objUserFoodLogBAO.ID = id;
                objUserFoodLogBAO.ProcedureType = "FL";
                UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLogBAO);
                BindFoodLog();
                Bind_History();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

            }

        }

        private void piechartbind()
        {
            Chart1.Legends.Clear();
            Series series1 = Chart1.Series[0];
            string[] xValues = { "Calories Burn", "calories Consumed" };
            int[] yValues = { cal, calconsumed };
            Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Series1"].Points[0].Color = Color.Red;
            Chart1.Series["Series1"].Points[1].Color = Color.Green;
            Chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            Chart1.Series["Series1"]["PieLabelStyle"] = "Enable";
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;


            Chart1.Legends.Add("Legend1");



            Chart1.Legends["Legend1"].Enabled = true;
            Chart1.Legends["Legend1"].Docking = Docking.Bottom;
            Chart1.Series["Series1"].IsVisibleInLegend = true;

            //Chart2.Series[0].Points[0].CustomProperties += "Exploded=true";
            lengend = "1";
        }
        protected void imghistory_Click(object sender, EventArgs e)
        {
            Session["track_mission"] = null;
            Session["track_mission_history"] = "True";
            Response.Redirect("~/User/Missions.aspx", false);
        }
        protected void lnkGraphs_Click(object sender, EventArgs e)
        {
            Session["track_mission"] = null;
            Session["track_mission_graphs"] = "True";
            Response.Redirect("~/User/Missions.aspx", false);
        }
  


        protected void imgFAV_Click(object sender, ImageClickEventArgs e)
        {
            bindGrdFAv();
          

        }

        protected void lnkListMission_Click(object sender, EventArgs e)
        {
            Session["show_list_mission"] = "True";
            Response.Redirect("~/User/Missions.aspx", false);
        }
        private void bindGrdFAv()
        {
            DataTable dt = new DataTable();
            objUserFoodLog.ID = Convert.ToInt32(MySession.Current.LoginId);
            objUserFoodLog.ProcedureType = "FFL";
            dt = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);
        
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

        }
        protected void GrdFAvFoodLog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ImgLnkFav")
            {
                string id = e.CommandArgument.ToString();
                DataTable dt = new DataTable();
                objUserFoodLog.ID = Convert.ToInt32(id);
                objUserFoodLog.ProcedureType = "FLF";
                dt = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);
                if (dt.Rows.Count > 0)
                {
                    int retval = 0;
                    objUserFoodLog.UFL_ID = 0;
                    objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                    objUserFoodLog.Search_Name = dt.Rows[0]["FOOD_NAME"].ToString();
                    objUserFoodLog.Product_Size = dt.Rows[0]["Product_Size"].ToString();
                    objUserFoodLog.QUANTITY = dt.Rows[0]["QUANTITY"].ToString();
                    objUserFoodLog.CALORIES = dt.Rows[0]["CALORIES"].ToString();
                    objUserFoodLog.FAT = dt.Rows[0]["FAT"].ToString();
                    objUserFoodLog.CHOLESTROL = dt.Rows[0]["CHOLESTROL"].ToString();
                    objUserFoodLog.SODIUM = dt.Rows[0]["SODIUM"].ToString();
                    objUserFoodLog.CARBOHYDRATES = dt.Rows[0]["CARBOHYDRATES"].ToString();
                    objUserFoodLog.FIBER = dt.Rows[0]["FIBER"].ToString();
                    objUserFoodLog.PROTIENS = dt.Rows[0]["PROTIENS"].ToString();
                    objUserFoodLog.SUGAR = dt.Rows[0]["SUGAR"].ToString();
                    objUserFoodLog.UFL_DATE = DateTime.Now.ToString();
                    objUserFoodLog.ProcedureType = "I";
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                    retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);


                    /*
                     * The calories that were consumed either by search or input ar e inserted here to show charts.
                     * 
                     * */

                    AddDailyCaloriesInput(Convert.ToDecimal(cal), 0, 0, retval, 1, "", 0, hdnSelectedDateForMissionHistory.Value, 0, 0, 0);
                    BindFoodLog();
                    Bind_History();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp11", "<script type='text/javascript'>LoadCssOnLinkBtnClick();</script>", false);

                }
            }
        }

        private void bindYearDay()
        {
            drpYear.Items.Clear();
            DrpDAy.Items.Clear();
            int currentyear = DateTime.Now.Year;
            for (int year = currentyear; year >= 1900; year--)
            {
                drpYear.Items.Add(year.ToString());
            }

            for (int i = 1; i <= 31; i++)
            {
                DrpDAy.Items.Add(i.ToString());
            }

        }

        protected void txtSearchActivities_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchActivities.Text != "")
            {
                bindYearDay();
                BindFeatures();
                UserFoodLogBAO ObjUserFoodLogBAO = null;
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.Search_Name = txtSearchActivities.Text;
                ObjUserFoodLogBAO.ID = "5";
                System.Data.DataTable retval = UserFoodLogDAO.ShowActivitiesBasedonSearchText(ObjUserFoodLogBAO);
                if (retval != null)
                {
                    if (retval.Rows.Count > 0)
                    {
                        if (retval.Rows[0]["Activity_step_status"].ToString() == "True")
                        {
                            divDOB.Style.Add("display", "none");
                            divDistance.Style.Add("display", "block");
                            divDuration.Style.Add("display", "block");
                            dvHeartRate.Style.Add("display", "block");
                        }
                        else
                        {
                            divDOB.Style.Add("display", "none");
                            divDistance.Style.Add("display", "none");
                            divDuration.Style.Add("display", "block");
                            dvHeartRate.Style.Add("display", "block");
                            //ScriptManager.RegisterStartupScript(this.Page, GetType(), "displayalertmessage", "Showalert();", true);
                        }


                    }
                    else
                    {
                        divDOB.Style.Add("display", "none");
                        divGender.Style.Add("display", "none");
                        divWeight.Style.Add("display", "none");
                        dvHeight.Style.Add("display", "none");

                        divDistance.Style.Add("display", "none");
                        divDuration.Style.Add("display", "none");
                        dvHeartRate.Style.Add("display", "none");

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "displayalertmessage", "Showalert();", true);
                }


            }
            else
            {
                dvHeartRate.Style.Add("display", "none");
                divDuration.Style.Add("display", "none");
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "displayalertmessage", "Showalert();", true);
            }
        }

        private void CalculateCAlories(Int32 heartRateCalculated)
        {
            DataTable dt = new DataTable();
            objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            objUserRegisterBAO.procedureType = "GA";
            dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
            if (dt.Rows.Count > 0)
            {
                int age = Convert.ToInt32(dt.Rows[0]["age"]);
                int weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                //if (heartRateCalculated == 220)
                //    heartrate = heartRateCalculated - age;  // 220 - age;
                //else
                //    heartrate = heartRateCalculated;

                //Session["heartrate"] = Convert.ToString(heartrate);
                //txtHeartRateAvg.Text = Convert.ToString(heartrate);


                if (dt.Rows[0]["gender"].ToString() == "1" || dt.Rows[0]["gender"].ToString() == "NA" || dt.Rows[0]["gender"].ToString() == "No Informa" || (dt.Rows[0]["gender"].ToString() != "1" && dt.Rows[0]["gender"].ToString() != "2"))
                {
                    calculateTime();
                    int heartrate1 = 220 - age;
                    heartrate = Convert.ToInt32(heartrate1 * (0.7));
                    Session["heartrate"] = Convert.ToString(heartrate);
                    txtHeartRateAvg.Text = Convert.ToString(heartrate);
                    decimal agecal = Convert.ToDecimal((age) * (0.2017));
                    decimal weightcal = Convert.ToDecimal((weight) * (0.2017));
                    decimal heartcal = Convert.ToDecimal(heartrate * 0.6309);
                    decimal timecal = Convert.ToDecimal(minutes / 4.184);
                    decimal calBurn1 = agecal - weightcal;
                    decimal calBurn2 = calBurn1 + heartcal;
                    decimal calBurn3 = Convert.ToDecimal(Convert.ToInt32(calBurn2) - (55.0969));
                    calBurns = calBurn3 * timecal;
                }
                else if (dt.Rows[0]["gender"].ToString() == "2")
                {
                    calculateTime();
                    decimal heartret = Convert.ToDecimal((age) * (0.88));
                    int heartrate1 = Convert.ToInt32(206 - heartret);
                    heartrate = Convert.ToInt32(heartrate1 * (0.7));
                    Session["heartrate"] = Convert.ToString(heartrate);
                    txtHeartRateAvg.Text = Convert.ToString(heartrate);
                    decimal agecal = Convert.ToDecimal((age) * (0.074));
                    decimal weightcal = Convert.ToDecimal((weight) * (0.05741));
                    decimal heartcal = Convert.ToDecimal(heartrate * 0.4472);
                    decimal timecal = Convert.ToDecimal(minutes / 4.184);
                    decimal calBurn1 = agecal - weightcal;
                    decimal calBurn2 = calBurn1 + heartcal;
                    decimal calBurn3 = Convert.ToDecimal(Convert.ToInt32(calBurn2) - (20.4022));
                    calBurns = calBurn3 * timecal;
                }
            }
        }

        private void calculateTime()
        {
            int hrmin = 0;
            int min = 0;
            decimal minsec = 0;
            if (txtHours.Text != "")
            {
                int hours = Convert.ToInt32(txtHours.Text);
                hrmin = (hours) * 60;
            }
            else
            {
                hrmin = 0;
            }
            if (txtminutes.Text != "")
            {
                min = Convert.ToInt32(txtminutes.Text);
            }
            else
            {
                min = 0;
            }
            if (txtSec.Text != "")
            {
                int sec = Convert.ToInt32(txtSec.Text);
                minsec = Convert.ToDecimal(sec / 60);
            }
            else
            {
                minsec = 0;
            }
            minutes = hrmin + min + Convert.ToInt32(minsec);
        }

        protected void btn_Log_Click(object sender, EventArgs e)
        {
            if (txtSearchActivities.Text != string.Empty)
            {
                if (txtHours.Text != "" || txtminutes.Text != "" || txtSec.Text != "")
                {
                    if (divDistance.Style.Value == "display:block;float:left;" && txtDistance.Text.Trim() == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "displayalertmessage", "ShowalertForDistance();", true);
                    }
                    else
                    {
                        BindFeatures();

                        if (dvHeight.Style.Value == "display:block;" || divGender.Style.Value == "display:block;" || divDOB.Style.Value == "display:block;" || divWeight.Style.Value == "display:block;")
                        {
                            updateProfile();
                        }

                        BindFeatures();
                        calBurns = 0;
                        CalculateCAlories(Convert.ToInt32(txtHeartRateAvg.Text.Trim()));
                        txtHeartRateAvg.Text = Session["heartrate"].ToString();
                        Calculatesteps();

                        if (!calBurns.ToString().Contains("-"))
                        {
                            objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                            if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                            {
                                objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                            }
                            else
                            {
                                objUserMissionBAL.MissionId = 0;
                            }
                            objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(calBurns);
                            objUserMissionBAL.CaloriesEaten = 0;
                            objUserMissionBAL.Pk_user_Log_Id = 0;
                            objUserMissionBAL.Request_Type = 1;
                            objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(hdnSelectedDateForMissionHistory.Value.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                            if (txtSearchActivities.Text != "")
                            {
                                objUserMissionBAL.Activity_Performed = txtSearchActivities.Text;
                            }
                            else
                            {
                                objUserMissionBAL.Activity_Performed = "Tracker";
                            }
                            objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                            if (txtHours.Text != "")
                            {
                                objUserMissionBAL.Activity_Hours = Convert.ToInt32(txtHours.Text);
                            }
                            else
                            {
                                objUserMissionBAL.Activity_Hours = 0;
                            }
                            if (txtminutes.Text != "")
                            {
                                objUserMissionBAL.Activity_minutes = Convert.ToInt32(txtminutes.Text);
                            }
                            else
                            {
                                objUserMissionBAL.Activity_minutes = 0;
                            }
                            if (txtSec.Text != "")
                            {
                                objUserMissionBAL.Activity_Seconds = Convert.ToInt32(txtSec.Text);
                            }
                            else
                            {
                                objUserMissionBAL.Activity_Seconds = 0;
                            }

                            objUserMissionBAL.Distance_Units = DrpDIstance.SelectedValue;
                            if (txtDistance.Text != "")
                            {
                                objUserMissionBAL.Distance_Covered = Convert.ToInt32(txtDistance.Text);
                            }
                            else
                            {
                                objUserMissionBAL.Distance_Covered = 0;
                            }
                            objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                            objUserMissionBAL.Activity_Id = 0;

                            int calculateSteps = 0;
                            if (txtDistance.Text != "")
                            {
                                if (DrpDIstance.SelectedValue == "Km")
                                {

                                    int distance = Convert.ToInt32(txtDistance.Text);
                                    calculateSteps = distance * 1312;

                                }
                                else
                                {
                                    int distance = Convert.ToInt32(txtDistance.Text);
                                    calculateSteps = distance * 2111;
                                }
                            }
                            else
                            {
                                calculateSteps = 0;
                            }


                            objUserMissionBAL.StepsCovered = calculateSteps;

                            DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                            ModifyWeight_BasedOnLogInput(Convert.ToDecimal(calBurns), 0, objUserMissionBAL.DateOfCompletion.ToString(), Convert.ToInt32(dtLog.Rows[0]["fk_mission_log_id"]));

                            divDistance.Style.Add("display", "none");
                            divDuration.Style.Add("display", "none");
                            dvHeartRate.Style.Add("display", "none");

                            bindLogActivities();
                            bindDistanceCAl();
                            txtSearchActivities.Text = "";
                            txtDistance.Text = "";
                            txtHours.Text = "";
                            txtminutes.Text = "";
                            txtSec.Text = "";
                            drpGender.SelectedIndex = 0;
                            drpMonth.SelectedIndex = 0;
                            DrpDAy.SelectedIndex = 0;
                            drpYear.SelectedIndex = 0;
                            txtWeight.Text = "";

                            Bind_History();

                            string presentdate = hdnSelectedDateForMissionHistory.Value;


                            if (presentdate.Length > 11)
                            {
                                presentdate = presentdate.Substring(0, presentdate.IndexOf(' ', presentdate.IndexOf(' ') + 5));
                                txtCalendarNavigation.Text = presentdate;
                            }
                            else
                            {
                                txtCalendarNavigation.Text = presentdate;
                            }
                            bindGrdFAv();
                            BindCategories();
                            BindFavActivityLog();
                            bindLogActivities();
                            bindDistanceCAl();
                        }
                        else
                        {                            
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Distance/HeartRate/Duration do not produce an appropriate calorie burnt for the given activity.');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "displayalertmessage", "ShowalertForDuration();", true);

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "displayalertmessage", "ShowalertForNoActivity();", true);

            }
        }
        private void updateProfile()
        {
            RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();

            if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
            {
                ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.LoginId);
            }
            else
            {
                ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
            }
            if (drpUserHeightOptions.SelectedValue == "2")
            {
                ObjRegisterUserBAO.Height = Convert.ToDecimal(txtHeight.Text.Trim());
                ObjRegisterUserBAO.HeightInches = 0;

            }
            else
            {
                ObjRegisterUserBAO.Height = Convert.ToDecimal(txtHeight.Text.Trim());
                if (txtheightInches.Text == "0" || txtheightInches.Text == null || txtheightInches.Text == "")
                {
                    ObjRegisterUserBAO.HeightInches = 0;
                   
                }
                else
                {
                    ObjRegisterUserBAO.HeightInches = Convert.ToInt32(txtheightInches.Text);
                  
                }
            }
            ObjRegisterUserBAO.YearOfBirth = Convert.ToInt32(drpYear.SelectedValue);
            ObjRegisterUserBAO.MonthOfBirth = Convert.ToInt32(drpMonth.SelectedValue);
            ObjRegisterUserBAO.DateOfBirth = Convert.ToInt32(DrpDAy.SelectedValue);
            ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeight.Text.Trim());
            ObjRegisterUserBAO.WeightUnits = Convert.ToInt32(drpUserWeightOptions.SelectedValue);
            ObjRegisterUserBAO.HeightUnits = Convert.ToInt32(drpUserHeightOptions.SelectedValue);
            ObjRegisterUserBAO.Gender = Convert.ToString(drpGender.SelectedValue);


            RegisterUserDAO.UpdateFeatures(ObjRegisterUserBAO);
        }

        private void bindLogActivities()
        {
            DataTable dtActivityLog = new DataTable();
            objUserFoodLog.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            objUserFoodLog.UFL_DATE = (txtCalendarNavigation.Text);
            objUserFoodLog.Fk_MissionId = 0;
            objUserFoodLog.ProcedureType = "AL";
            objUserFoodLog.ID = 1;
            dtActivityLog = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
            if (dtActivityLog.Rows.Count > 0)
            {
                dtActivityLog.Columns.Add("FavImage", typeof(string));
                dtActivityLog.AcceptChanges();
                for (int i = 0; i < dtActivityLog.Rows.Count; i++)
                {

                    if (!string.IsNullOrEmpty(Convert.ToString(dtActivityLog.Rows[i]["FAv_Id"])))
                    {
                        dtActivityLog.Rows[i]["FavImage"] = "~/images/star_sel.png";
                        dtActivityLog.AcceptChanges();

                    }
                    else
                    {
                        dtActivityLog.Rows[i]["FavImage"] = "~/images/star_not_sel.png";
                        dtActivityLog.AcceptChanges();

                    }
                }
            }
            GrdActivitiesLog.DataSource = dtActivityLog;
            GrdActivitiesLog.DataBind();

        }
        protected void GrdActivitiesLog_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex != -1)
                {
                    e.Row.Attributes["onmouseover"] = "showContents('" + (e.Row.RowIndex + 1) + "')";
                    e.Row.Attributes["onmouseout"] = "HideElemments('" + (e.Row.RowIndex + 1) + "')";

                }
                Label lbHour = (Label)e.Row.FindControl("lbHour");
                Label lbmin = (Label)e.Row.FindControl("lbmin");
               int hours = Convert.ToInt32(lbHour.Text);
                //int hours = 0;
                int minutes = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "minutes_of_activity").ToString());

                if (minutes >= 60 && minutes < 120)
                {
                    hours = hours + 1;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 60);
                }
                else if (minutes >= 120 && minutes < 180)
                {
                    hours = hours + 2;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 120);
                }
                else if (minutes >= 180 && minutes < 240)
                {
                    hours = hours + 3;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 180);
                }
                else if (minutes >= 240 && minutes < 300)
                {
                    hours = hours + 4;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 240);
                }

                else if (minutes >= 300 && minutes < 360)
                {
                    hours = hours + 5;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 300);
                }
                else if (minutes >= 360 && minutes < 420)
                {
                    hours = hours + 6;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 360);
                }
                else if (minutes >= 420 && minutes < 480)
                {
                    hours = hours + 7;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 420);
                }
                else if (minutes >= 480 && minutes < 540)
                {
                    hours = hours + 8;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 480);
                }
                else if (minutes >= 540 && minutes < 600)
                {
                    hours = hours + 9;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 540);
                }
                else if (minutes >= 600 && minutes < 660)
                {
                    hours = hours + 10;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 600);
                }

                else if (minutes >= 660 && minutes < 720)
                {
                    hours = hours + 11;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 660);
                }
                else if (minutes >= 720 && minutes < 780)
                {
                    hours = hours + 12;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 720);
                }
                else if (minutes >= 780 && minutes < 840)
                {
                    hours = hours + 13;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 780);
                }
                else if (minutes >= 840 && minutes < 900)
                {
                    hours = hours + 14;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 840);
                }
                else if (minutes >= 900 && minutes < 960)
                {
                    hours = hours + 15;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 900);
                }
                else if (minutes >= 960 && minutes < 1020)
                {
                    hours = hours + 16;
                    lbHour.Text = Convert.ToString(hours);
                    lbmin.Text = Convert.ToString(Convert.ToInt32(lbmin.Text) - 960);
                }


                DateTime dt_todaydate = Convert.ToDateTime(System.DateTime.Now.ToString());
                string str_getTodayDate = dt_todaydate.ToString("yyyy-MM-dd");

                DateTime today = Convert.ToDateTime(txtCalendarNavigation.Text); // As DateTime
                string myDate = null;
                if (String.IsNullOrEmpty(Convert.ToString(Session["navigated_date_selected"])))
                {
                    myDate = today.ToString("yyyy-MM-dd"); // As String
                }
                else
                {
                    myDate = Convert.ToDateTime(Session["navigated_date_selected"]).ToString("yyyy-MM-dd");
                }
                ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("ImageButton1");

                if (str_getTodayDate != myDate)
                {
                    ImageButton1.Visible = false;
                }
                else
                {
                    ImageButton1.Visible = true;
                }
            }
        }

        protected void GrdFavActivityLog_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex != -1)
                {
                    e.Row.Attributes["onmouseover"] = "ShowFavContent('" + (e.Row.RowIndex + 1) + "')";
                    e.Row.Attributes["onmouseout"] = "HideFavContent('" + (e.Row.RowIndex + 1) + "')";

                }
            }
        }
        private void Calculatesteps()
        {
            if (txtDistance.Text != "")
            {
                if (DrpDIstance.SelectedValue == "Km")
                {

                    int distance = Convert.ToInt32(txtDistance.Text);
                    steps = distance * 1312;

                }
                else
                {
                    int distance = Convert.ToInt32(txtDistance.Text);
                    steps = distance * 2111;
                }
            }
            else
            {
                steps = 0;
            }
        }

        private void bindDistanceCAl()
        {
            DataTable dtDistanceLog = new DataTable();
            objUserFoodLog.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            objUserFoodLog.UFL_DATE = (txtCalendarNavigation.Text);
            objUserFoodLog.Fk_MissionId = 0;
            objUserFoodLog.ProcedureType = "DL";
            objUserFoodLog.ID = 1;
            dtDistanceLog = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
            if (dtDistanceLog.Rows.Count > 0)
            {
                lbDistanceMiles.Text = dtDistanceLog.Rows[0]["distnce"].ToString();
                lbDistanceUnit.Text = dtDistanceLog.Rows[0]["distance_units"].ToString();
                lbNoofCal.Text = dtDistanceLog.Rows[0]["calories"].ToString();
                lbNoofSteps.Text = dtDistanceLog.Rows[0]["steps"].ToString();
                //lbNoofCal.InnerText = dtDistanceLog.Rows[0]["calories"].ToString();
            }
            else
            {
                lbDistanceMiles.Text = "0";
                lbDistanceUnit.Text = "miles";
                lbNoofCal.Text = "0";
                lbNoofSteps.Text = "0";

            }
        }

        protected void GrdActivitiesLog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IMGBtn_Log")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                objUserRegisterBAO.ID = id;
                objUserRegisterBAO.procedureType = "AL";
                dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dt.Rows.Count > 0)
                {
                    int retval = 0;
                    objUserMissionBAL.fav_ID = 0;
                    objUserMissionBAL.Fk_mission_log_id = id;
                    objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    objUserMissionBAL.fa_CAL_BURNS = Convert.ToInt32(dt.Rows[0]["calories_burnt"]);
                    objUserMissionBAL.Activity_Performed = dt.Rows[0]["activity_selected"].ToString();
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(dt.Rows[0]["date_of_calories_burnt"]);
                    objUserMissionBAL.fa_date = DateTime.Now;
                    objUserMissionBAL.ProcedureType = "I";
                    retval = UserMissionsDAL.InsertAddFavActivityLog(objUserMissionBAL);
                    BindFavActivityLog();
                    bindLogActivities();
                }
                //ImageButton lbtnAction;
                //GridViewRow row;
                //row = (GridViewRow)((ImageButton)e.CommandSource).Parent.Parent;

                //lbtnAction = (ImageButton)GrdActivitiesLog.Rows[row.RowIndex].FindControl("imgBtn_Log");
                //lbtnAction.Attributes.Add("onclick", "javascript:return RemoveHidden();");
            }
        }
        private void BindFavActivityLog()
        {
            DataTable dt = new DataTable();
            objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            objUserRegisterBAO.procedureType = "FA";
            dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);

            GrdFavActivityLog.DataSource = dt;
            GrdFavActivityLog.DataBind();

        }
        protected void GrdFavActivityLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string lbid;
            lbid = ((Label)GrdFavActivityLog.Rows[e.RowIndex].FindControl("lbFavId")).Text;
            if (lbid != "")
            {
                int retval = 0;
                objUserFoodLog.UFL_ID = lbid;
                objUserFoodLog.ProcedureType = "DA";
                retval = UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLog);
                GrdFavActivityLog.EditIndex = -1;
                BindFavActivityLog();
                bindLogActivities();
            }

        }
        protected void txtCalendarNavigation_TextChanged(object sender, EventArgs e)
        {
            bindLogActivities();
            //            Bind_History();
            BindFavActivityLog();
            bindDistanceCAl();
            hdnSelectedDateForMissionHistory.Value = txtCalendarNavigation.Text + DateTime.Now.ToString(" HH:mm:ss tt");
            Session["navigated_date_selected"] = hdnSelectedDateForMissionHistory.Value;
        }

        private void bindTotal()
        {
            //dvChart.Style.Add("display", "");
            DataTable dt = new DataTable();
            objUserFoodLog.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            if (hdnSelectedDateForMissionHistory.Value == "")
            {
                objUserFoodLog.UFL_DATE = txtCalendarNavigation.Text;
            }
            else
            {
                objUserFoodLog.UFL_DATE = Convert.ToString(hdnSelectedDateForMissionHistory.Value);
            }
            if (Convert.ToString(Session["selected_mission_id"]) != "" || Convert.ToString(Session["selected_mission_id"]) == null)
            {
                objUserFoodLog.Fk_MissionId = 0;
            }
            else
            {
                objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
            }
            objUserFoodLog.ProcedureType = "T2";
            objUserFoodLog.ID = "1";
            dt = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["calburn"].ToString() != "")
                {
                    cal = Convert.ToInt32(dt.Rows[0]["calburn"]);
                }
                else
                {
                    cal = 0;
                }
                if (dt.Rows[0]["calconsumed"].ToString() != "")
                {
                    calconsumed = Convert.ToInt32(dt.Rows[0]["calconsumed"]);
                }
                else
                {
                    calconsumed = 0;
                }
            }
            piechartbind();
            if (cal == 0 && calconsumed == 0)
            {
                Chart1.Style.Add("display", "none");
                lbChart1.Visible = true;
                lbChart1.Text = "Daily Activity log chart";
            }
        }
        protected void ImgGetStartedNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/FitBitAccountSettings.aspx", false);
        }

        protected void imgBtnPrevious_Click(object sender, ImageClickEventArgs e)
        {
            string date1 = txtCalendarNavigation.Text;
            string date = Convert.ToDateTime(date1).AddDays(-1).ToString("dd MMM yyyy");
            txtCalendarNavigation.Text = date;
            hdnSelectedDateForMissionHistory.Value = txtCalendarNavigation.Text + DateTime.Now.ToString(" HH:mm:ss tt");
            Session["navigated_date_selected"] = hdnSelectedDateForMissionHistory.Value;

            bindLogActivities();
            Bind_History();
            BindFavActivityLog();
            bindDistanceCAl();
        }

        protected void ImgBtnNextDate_Click(object sender, ImageClickEventArgs e)
        {
            string date1 = txtCalendarNavigation.Text;
            string date = Convert.ToDateTime(date1).AddDays(+1).ToString("dd MMM yyyy");
            txtCalendarNavigation.Text = date;
            hdnSelectedDateForMissionHistory.Value = txtCalendarNavigation.Text + DateTime.Now.ToString(" HH:mm:ss tt");
            Session["navigated_date_selected"] = hdnSelectedDateForMissionHistory.Value;

            bindLogActivities();
            Bind_History();
            BindFavActivityLog();
            bindDistanceCAl();
        }

        protected void GrdActivitiesLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {

                string lbid;
                lbid = ((Label)GrdActivitiesLog.Rows[e.RowIndex].FindControl("lbID")).Text;
                if (lbid != "")
                {
                    int retval = 0;
                    objUserFoodLog.UFL_ID = lbid;
                    objUserFoodLog.ProcedureType = "DA";
                    retval = UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLog);
                    GrdActivitiesLog.EditIndex = -1;
                    bindLogActivities();
                    Bind_History();
                    BindFavActivityLog();
                    bindDistanceCAl();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
    }
}
