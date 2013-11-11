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
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.DAL.User;
using System.Net;
using Newtonsoft.Json;
using System.Xml;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Collections.Generic;
using ALEREIMPACT.DAO.User;

namespace ALEREIMPACT.User
{
    public partial class ucFoodLog : System.Web.UI.UserControl
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
        public static Int32 cal, fat, chol, fiber, sugar = 0;
        public static int count = 0;
        public static Int32 number = 20;
        public static Int32 setofno = 0;
        public static string lengend = "";
        public static string Pro_size = "";
        protected static int chartPoints = 0;
        public static Int32 s = 0;
        public static Int32 n = 10;
        public static Int32 n1 = 0;
        public static Int32 PageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");
                this.txtSearch.Attributes.Add("onkeypress", "ShowImage()");
                this.txtSearch.Attributes.Add("onblur", "HideImage()");
                txtSearch.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                if (!IsPostBack)
                {

                    //if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                    //{

                    //    dvRegionOfCalsBurn.Visible = true;
                    //}
                    //else
                    //{
                    //    dvRegionOfCalsBurn.Visible = false;
                    //}
                    InsertFoodLogAutoLogin();
                    txtCalendarNavigation.Text = System.DateTime.Today.ToString("dd MMM yyyy");
                    dvSerach.Style.Add("display", "none");
                    BindFoodLog();
                    bindGrdFAv();
                    BindCAt();
                    BindQuickLog_ActivitiesAndCalories();
                }
                Bind_History();
                BindTotal();
                piechartbind();
                if (!String.IsNullOrEmpty(Convert.ToString(Session["selected_mission_id"])))
                {

                    dvSerach.Style.Add("display", "none");
                   
                    //dvChart.Style.Add("display", "");
                    Chart2.Series[0].PostBackValue = "#INDEX";
                    BindTotal();
                    // piechartbind();
                    chartPoints = Chart2.Series["Series1"].Points.Count;
                    txtCalendarNavigation.Text = System.DateTime.Today.ToString("dd MMM yyyy");
                }
                else
                {
                    //  dvactivity_right_section.Style.Value = "float: right; margin-top: 15px;";
                }
                if (!String.IsNullOrEmpty(Convert.ToString(hdnSelectedDateForMissionHistory.Value)))
                {
                    //BindHistoryLogBasedOnDates(Convert.ToString(hdnSelectedDateForMissionHistory.Value));
                    txtCalendarNavigation.Text = Convert.ToString(String.Format(hdnSelectedDateForMissionHistory.Value, "dd MMM yyyy"));
                    Bind_History();
                    BindTotal();

                }

                txtCalendarNavigation.Attributes.Add("readonly", "readonly");
                //  Session["FoodLog"] = null;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        } /// <summary>
        ///  Purpose: Show QuickLog activities along with cals burn specified w.r.t each activity
        /// </summary>
        private void BindQuickLog_ActivitiesAndCalories()
        {
            UserFoodLogBAO ObjUserFoodLogBAO = null;
            try
            {
                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.RequestType = 1;
                ObjUserFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);

                System.Data.DataSet retval = UserFoodLogDAO.ShowQuickLogActivities(ObjUserFoodLogBAO);

                if (retval.Tables[0].Rows.Count > 0)
                {
                    dtFoodLogActivityImages.DataSource = retval.Tables[0];
                    dtFoodLogActivityImages.DataBind();
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
            ClsGeneric.ReplaceCookie();
            BindCAt();

            string activitySelected = string.Empty;
            string caloriesBurn = string.Empty;
            DataTable dtLog = new DataTable();
            int retval = 0;

            DataSet dsResults = null;
            UserFoodLogBAO ObjUserFoodLogBAO = null;
            try
            {
                dsResults = new DataSet();

                ObjUserFoodLogBAO = new UserFoodLogBAO();
                ObjUserFoodLogBAO.RequestType = 1;
                ObjUserFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);

                dsResults = UserFoodLogDAO.ShowQuickLogActivities(ObjUserFoodLogBAO);

                if (dsResults.Tables[1].Rows.Count > 0)
                {
                    string yesterDayCalories = Convert.ToString(dsResults.Tables[1].Rows[0]["CALORIES"]);
                    if (!String.IsNullOrEmpty(Convert.ToString(yesterDayCalories)))
                    {
                        double CalculatedYesterDayCalories = 0;
                        if (radLessthanYesterday.Checked)
                            CalculatedYesterDayCalories = Convert.ToDouble(yesterDayCalories) - 75.00;
                        else if (radMorethanYesterday.Checked)
                            CalculatedYesterDayCalories = Convert.ToDouble(yesterDayCalories) + 75.00;

                        objUserFoodLog.UFL_ID = 0;
                        objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                        objUserFoodLog.Search_Name = dsResults.Tables[1].Rows[0]["Search_Name"];
                        objUserFoodLog.Product_Size = 0;
                        objUserFoodLog.QUANTITY = 0;
                        objUserFoodLog.CALORIES = CalculatedYesterDayCalories.ToString();
                        objUserFoodLog.FAT = "0.0";
                        objUserFoodLog.CHOLESTROL = "0.0";
                        objUserFoodLog.SODIUM = "0.0";
                        objUserFoodLog.CARBOHYDRATES = "0.0";
                        objUserFoodLog.FIBER = "0.0";
                        objUserFoodLog.PROTIENS = "0.0";
                        objUserFoodLog.SUGAR = "0.0";

                        if (hdnSelectedDateForMissionHistory.Value == "")
                        {
                            objUserFoodLog.UFL_DATE = txtCalendarNavigation.Text;
                        }
                        else
                        {
                            objUserFoodLog.UFL_DATE = Convert.ToString(hdnSelectedDateForMissionHistory.Value);
                        }
                        objUserFoodLog.ProcedureType = "I";
                        objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                        retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);


                        int retval1 = 0;
                        objUserFoodLog.ETL_ID = 0;
                        objUserFoodLog.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserFoodLog.UFL_ID_FK = retval;
                        DataTable dt = new DataTable();
                        objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                        objUserFoodLog.ProcedureType = "S";
                        dt = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                        if (dt.Rows.Count > 0)
                        {
                            objUserFoodLog.ET_ID_FK = Convert.ToInt32(dt.Rows[0]["ET_ID"]);
                        }
                        objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                        objUserFoodLog.ProcedureType = "I";
                        retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                        DataTable dtEathabbit = new DataTable();
                        objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.procedureType = "EH";
                        dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                        if (dtEathabbit.Rows.Count > 0)
                        {
                            int retupdate = 0;
                            objUserFoodLog.EH_ID = 0;
                            objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                            DataTable dt1 = new DataTable();
                            objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                            objUserFoodLog.ProcedureType = "S";
                            dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                            if (dt1.Rows.Count > 0)
                            {
                                if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                                    objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                                }
                                else
                                {
                                    if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                                    {
                                        objUserFoodLog.EH_BREAKFAST = "Y";
                                        objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                                    objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                                }
                                else
                                {
                                    if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                                    {
                                        objUserFoodLog.EH_LUNCH = "Y";
                                        objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                                    objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                                }
                                else
                                {
                                    if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                                    {
                                        objUserFoodLog.EH_DINNER = "Y";
                                        objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }

                                if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                                    objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                                }
                                else
                                {
                                    if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                                    {
                                        objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                        objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                                    objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                                }
                                else
                                {
                                    if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                                    {
                                        objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                        objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                                    objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                                }
                                else
                                {
                                    if (dt1.Rows[0]["ET_ID"].ToString() == "4")
                                    {
                                        objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                        objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                            }
                            objUserFoodLog.ProcedureType = "U";
                            retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                        }
                        else
                        {
                            int retvalHabbit = 0;
                            objUserFoodLog.EH_ID = 0;
                            objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                            DataTable dt1 = new DataTable();
                            objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                            objUserFoodLog.ProcedureType = "S";
                            dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                            if (dt1.Rows.Count > 0)
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                                {
                                    objUserFoodLog.EH_BREAKFAST = "Y";
                                    objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                                else if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                                {
                                    objUserFoodLog.EH_LUNCH = "Y";
                                    objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                                else if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                                {
                                    objUserFoodLog.EH_DINNER = "Y";
                                    objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                                else if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                                {
                                    objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                    objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                                else if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                                {
                                    objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                    objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                                else
                                {
                                    objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                    objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            objUserFoodLog.ProcedureType = "I";
                            retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                        }

                        objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                        if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                        {
                            objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                        }
                        else
                        {
                            objUserMissionBAL.MissionId = 0;
                        }
                        objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                        objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(CalculatedYesterDayCalories);
                        objUserMissionBAL.Pk_user_Log_Id = 0;
                        objUserMissionBAL.Request_Type = 1;
                        objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(txtCalendarNavigation.Text);

                        objUserMissionBAL.Activity_Performed = string.Empty;
                        objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                        objUserMissionBAL.Activity_Hours = 0;
                        objUserMissionBAL.Activity_minutes = 0;
                        objUserMissionBAL.Activity_Seconds = 0;
                        objUserMissionBAL.Distance_Units = "0";
                        objUserMissionBAL.Distance_Covered = 0;

                        objUserMissionBAL.Activity_Id = 0;
                        objUserMissionBAL.StepsCovered = 0;

                        dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                        ModifyWeight_BasedOnLogInput(0, Convert.ToDecimal(CalculatedYesterDayCalories), objUserMissionBAL.DateOfCompletion.ToString(), Convert.ToInt32(dtLog.Rows[0]["fk_mission_log_id"]));

                    }
                    else
                    {
                        dvErrorMsgForYesterDayCalories.Style.Value = "display:block";
                        radMorethanYesterday.Checked = false;
                        radLessthanYesterday.Checked = false;
                        MdlQuickLog_FoodLog.Show();
                    }
                }
                else
                {
                    dvErrorMsgForYesterDayCalories.Style.Value = "display:block";
                    radMorethanYesterday.Checked = false;
                    radLessthanYesterday.Checked = false;
                    MdlQuickLog_FoodLog.Show();
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

            Bind_History();
            BindFoodLog();


        }
        /// <summary>
        /// Purpose :  To modify the weight of the user because of new log input through search, quick log.
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
        /// <summary>
        /// Purpose: To submit custom food information to the database .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnSaveCustomFood_Click(object sender, EventArgs e)
        {
            BindCAt();

            string activitySelected = string.Empty;
            string caloriesBurn = string.Empty;
            DataTable dtLog = new DataTable();
            int retval = 0;

            DataSet dsResults = null;
            try
            {
                dsResults = new DataSet();

                objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                objUserFoodLog.FOOD_NAME = txtAddNewFood.Text.Trim();

                objUserFoodLog.Brand_name = txtBrandName.Text.Trim();
                objUserFoodLog.Serving_size = txtServingSize.Text.Trim();
                objUserFoodLog.CALORIES = txtCalories.Text.Trim();
                objUserFoodLog.CaloriesFromFat = txtCaloriesFat.Text.Trim() != "" ? txtCaloriesFat.Text.Trim() : "0.00";
                objUserFoodLog.TotalFat = txtTotalFat.Text.Trim() != "" ? txtTotalFat.Text.Trim() : "0.00";
                objUserFoodLog.SaturatedFat = txtSaturatedFat.Text.Trim();
                objUserFoodLog.TransFat = txtTransFat.Text.Trim();
                objUserFoodLog.Cholestrol = txtCholesterol.Text.Trim();


                objUserFoodLog.Sodium = txtSodium.Text.Trim();
                objUserFoodLog.Potassium = txtPotassium.Text.Trim();
                objUserFoodLog.TotalCarbohydrates = txtTotalCarbohydrate.Text.Trim();
                objUserFoodLog.DietaryFiber = txtDietaryFiber.Text.Trim();
                objUserFoodLog.Sugars = txtSugars.Text.Trim();
                objUserFoodLog.Protein = txtProtein.Text.Trim();
                objUserFoodLog.Vitamin_A = txtVitaminA.Text.Trim();
                objUserFoodLog.Vitamin_C = txtVitaminC.Text.Trim();
                objUserFoodLog.Calcium = txtCalcium.Text.Trim();


                objUserFoodLog.Iron = txtIron.Text.Trim();
                objUserFoodLog.Thiamin = txtThiamin.Text.Trim();
                objUserFoodLog.Riboflavin = txtRiboflavin.Text.Trim();
                objUserFoodLog.VitaminB6 = txtVitaminB6.Text.Trim();
                objUserFoodLog.VitaminB12 = txtVitaminB12.Text.Trim();
                objUserFoodLog.VitaminE = txtVitaminE.Text.Trim();
                objUserFoodLog.FolicAcid = txtFolicAcid.Text.Trim();
                objUserFoodLog.Niacin = txtNiacin.Text.Trim();


                objUserFoodLog.Magnesium = txtMagnesium.Text.Trim();
                objUserFoodLog.Phosphorus = txtPhosphorus.Text.Trim();
                objUserFoodLog.Iodine = txtIodine.Text.Trim();
                objUserFoodLog.Zinc = txtZinc.Text.Trim();
                objUserFoodLog.Copper = txtCopper.Text.Trim();
                objUserFoodLog.Biotin = txtBiotin.Text.Trim();
                objUserFoodLog.Pantothenic = txtPantothenicAcid.Text.Trim();
                objUserFoodLog.VitaminD = txtVitaminD.Text.Trim();

                objUserFoodLog.CARBOHYDRATES = txtcarbohydrates.Text.Trim();
                objUserFoodLog.FIBER = txtfiber.Text.Trim();

                objUserFoodLog.UFL_DATE = DateTime.Now.ToString();

                retval = UserFoodLogDAO.InserttblCustomFood(objUserFoodLog);

                objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);

                objUserFoodLog.UFL_ID = 0;
                objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                objUserFoodLog.Search_Name = txtAddNewFood.Text.Trim();
                objUserFoodLog.Product_Size = txtServingSize.Text.Trim();
                objUserFoodLog.QUANTITY = 0;
                objUserFoodLog.CALORIES = txtCalories.Text.Trim();
                objUserFoodLog.FAT = txtTotalFat.Text.Trim();
                objUserFoodLog.CHOLESTROL = txtCholesterol.Text.Trim();
                objUserFoodLog.SODIUM = txtSodium.Text.Trim();
                objUserFoodLog.CARBOHYDRATES = txtcarbohydrates.Text.Trim();
                objUserFoodLog.FIBER = txtfiber.Text.Trim();
                objUserFoodLog.PROTIENS = txtProtein.Text.Trim();
                objUserFoodLog.SUGAR = txtSugars.Text.Trim();

                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserFoodLog.UFL_DATE = txtCalendarNavigation.Text;
                }

                else
                {
                    objUserFoodLog.UFL_DATE = Convert.ToString(hdnSelectedDateForMissionHistory.Value);
                }


                objUserFoodLog.ProcedureType = "I";
                retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);


                int retval1 = 0;
                objUserFoodLog.ETL_ID = 0;
                objUserFoodLog.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserFoodLog.UFL_ID_FK = retval;
                DataTable dt = new DataTable();
                objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                objUserFoodLog.ProcedureType = "S";
                dt = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                if (dt.Rows.Count > 0)
                {
                    objUserFoodLog.ET_ID_FK = Convert.ToInt32(dt.Rows[0]["ET_ID"]);
                }
                objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                objUserFoodLog.ProcedureType = "I";
                retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                DataTable dtEathabbit = new DataTable();
                objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserRegisterBAO.procedureType = "EH";
                dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dtEathabbit.Rows.Count > 0)
                {
                    int retupdate = 0;
                    objUserFoodLog.EH_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    DataTable dt1 = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                            objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                            {
                                objUserFoodLog.EH_BREAKFAST = "Y";
                                objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                            objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                            {
                                objUserFoodLog.EH_LUNCH = "Y";
                                objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                            objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                            {
                                objUserFoodLog.EH_DINNER = "Y";
                                objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }

                        if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                            objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                            objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "4")
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                    }
                    objUserFoodLog.ProcedureType = "U";
                    retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                }
                else
                {
                    int retvalHabbit = 0;
                    objUserFoodLog.EH_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    DataTable dt1 = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                        {
                            objUserFoodLog.EH_BREAKFAST = "Y";
                            objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                        {
                            objUserFoodLog.EH_LUNCH = "Y";
                            objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                        {
                            objUserFoodLog.EH_DINNER = "Y";
                            objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = "Y";
                            objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = "Y";
                            objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = "Y";
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                    }
                    objUserFoodLog.ProcedureType = "I";
                    retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                }

                objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                {
                    objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                }
                else
                {
                    objUserMissionBAL.MissionId = 0;
                }
                objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(txtCalories.Text.Trim());
                objUserMissionBAL.Pk_user_Log_Id = 0;
                objUserMissionBAL.Request_Type = 1;
                objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(txtCalendarNavigation.Text);

                objUserMissionBAL.Activity_Performed = string.Empty;
                objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                objUserMissionBAL.Activity_Hours = 0;
                objUserMissionBAL.Activity_minutes = 0;
                objUserMissionBAL.Activity_Seconds = 0;
                objUserMissionBAL.Distance_Units = "0";
                objUserMissionBAL.Distance_Covered = 0;

                objUserMissionBAL.Activity_Id = 0;
                objUserMissionBAL.StepsCovered = 0;

                dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                ModifyWeight_BasedOnLogInput(0, Convert.ToDecimal(txtCalories.Text.Trim()), objUserMissionBAL.DateOfCompletion.ToString(), Convert.ToInt32(dtLog.Rows[0]["fk_mission_log_id"]));
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }


            Bind_History();
            BindFoodLog();
        }
        /// <summary>
        ///  Purpose: To show all p[revious food log activities logged by the login user.
        /// </summary>
        private void Bind_History()
        {
            try
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

                    if (Convert.ToString(dtInput.Rows[0]["MissionTypeId"]) == "1" || String.IsNullOrEmpty(Convert.ToString(dtInput.Rows[0]["MissionTypeId"])))
                    {
                        /*progress bar */

                        if (!String.IsNullOrEmpty(Convert.ToString(dtInput.Rows[0]["MissionTypeId"])))
                        {
                            spConsumedCaloriesToday.InnerText = dtInput.Rows[0]["TotalCalorieEatenToday"].ToString() + " | " + System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageCaloriesConsumeToday"].ToString()), 0) + "%";
                            spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString() + " | " + System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageOfCaloriesBurnToday"].ToString()), 0) + "%";


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

                            string CalLeftToday = dtInput.Rows[0]["CalorieLeftToBurnToday"].ToString();
                            if (CalLeftToday.Contains("-"))
                            {
                                CalLeftToday = "0";
                            }

                            spCalToBurnToday.InnerText = CalLeftToday;
                            spCalToBurnTodayMsg.InnerText = "Calories Left To Burn Today";

                            string perCentage = dtInput.Rows[0]["PercentageGrossCaloriesRemaining"].ToString();

                            Session["ProgressBarPercentage"] = System.Math.Round(Convert.ToDouble(perCentage), 0);
                            //  ProgressbarCaloriesConsume1.Visible = true;


                        }
                        else
                        {
                            spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString();
                            spConsumedCaloriesToday.InnerText = dtInput.Rows[0]["TotalCalorieEatenToday"].ToString();

                            //ProgressbarCaloriesConsume1.Visible = false;
                            Session["ProgressBarPercentage"] = null;
                        }

                        if (!String.IsNullOrEmpty(Convert.ToString(Session["Group_Mission"])))
                        {
                            spTodayMsg.InnerText = "Group Cals Consumption";
                            spBurnMsg.InnerText = "Group Cals Burnt";
                        }
                        else
                        {
                            // spRemainingMsg.InnerText = "Calories Remaining";
                            spTodayMsg.InnerText = "Cals Consumed Today";
                            spBurnMsg.InnerText = "Cals Burnt Today";
                        }

                    }
                    else
                    {
                        /*progress bar */
                        //spRemainingFromTotal.InnerText = dtInput.Rows[0]["GrossTotalStepsRemainingToCover"].ToString() + " | " + System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageGrossStepsRemaining"].ToString()), 0) + "%";
                        //spRemainingMsg.InnerText = "Steps Remaining";

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

                        /* calories burns today */
                        spCaloriesBurnedToday.InnerText = dtInput.Rows[0]["TotalCalorieBurntToday"].ToString() + " | " + System.Math.Round(Convert.ToDouble(dtInput.Rows[0]["PercentageOfCaloriesBurnToday"].ToString()), 0) + "%";
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

                        string perCentage = dtInput.Rows[0]["PercentageGrossStepsRemaining"].ToString();
                        Session["ProgressBarPercentage"] = System.Math.Round(Convert.ToDouble(perCentage), 0);

                    }

                    //spCaloriesBudget.InnerText = dtInput.Rows[0]["CaloriesToBurnToday"].ToString();
                    ViewState["mission_type"] = Convert.ToString(dtInput.Rows[0]["MissionTypeId"]);
                    if (Convert.ToString(dtInput.Rows[0]["MissionTypeId"]) == "1")
                    {
                        dvBreadCrumInput.Style.Add("display", "");

                        BindCAt();
                        //BindFoodLog();
                        dvSerach.Style.Add("display", "none");
                    }
                    else if (Convert.ToString(dtInput.Rows[0]["MissionTypeId"]) == "2")
                    {
                        dvBreadCrumInput.Style.Add("display", "none");

                    }
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkActivities_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["FoodLog"] = true;
                if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                {
                    Response.Redirect("Log.aspx?MissionSelected=True", false);
                }
                else
                {
                    Response.Redirect("Log.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
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
                    if (json_data.Contains("error in your call"))
                    {
                        json_data = "";
                        return string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
                    }

                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
                }
                else
                {
                    return string.IsNullOrEmpty(a) ? JsonConvert.DeserializeObject<T>(a) : new T();
                }
            }
        }
        /// <summary>
        /// Purpose: to change Looged Activities Grid w.r.t Food Log .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFood_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["FoodLog"] = null;

                if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                {
                    Response.Redirect("Log.aspx?MissionSelected=True", false);
                }
                else
                {
                    Response.Redirect("Log.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindGrd()
        {
            try
            {
                dvSerach.Style.Add("display", "block");
                //Pnl_ModalPopupExtender11.Hide();
                dvNextBtn.Visible = true;


                string url = "http://api.foodessentials.com/searchprods?q=" + Searchname + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&n=" + n + "&s=" + s + "&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";

                var currencyRates = _download_serialized_json_data<CurrencyRates>(url);

                string data = null;
                string data1 = null;

                DataTable table = new DataTable("ApiData");

                table.Columns.Add("upc", typeof(string));
                table.Columns.Add("product_name", typeof(string));
                //table.Columns.Add("brand", typeof(string));
                table.Columns.Add("product_size", typeof(string));
                table.Columns.Add("cal", typeof(string));
                // table.Columns.Add("Cal_Unit", typeof(string));
                table.Columns.Add("Cholesterol", typeof(string));
                table.Columns.Add("Fiber", typeof(string));
                table.Columns.Add("Protein", typeof(string));
                table.Columns.Add("Sodium", typeof(string));
                table.Columns.Add("Sugars", typeof(string));
                table.Columns.Add("Carbohydrate", typeof(string));
                table.Columns.Add("Fat", typeof(string));
                if (currencyRates != null)
                {
                    if (currencyRates.productsArray != null)
                    {
                        for (var x = 0; x < currencyRates.productsArray.Count; x++)
                        {
                            data = currencyRates.productsArray[x].ToString();

                            int p_size = data.IndexOf("product_size");
                            // int b_brand = data.IndexOf("brand");
                            int p_name = data.IndexOf("product_name");
                            int p_desc = data.IndexOf("product_description");
                            int manu = data.IndexOf("manufacturer");

                            string upc = data.Substring(13, 12).Replace(",", "").Replace("''", "").Replace("\"", "").Replace("\r\n", "").Replace("\"", "").Replace("''", "").Replace("\"", "").Replace("''", "").Replace(",", "");
                            string url1 = "http://api.foodessentials.com/productscore?u=" + upc + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";
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
                                                    // lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";
                                                    // lbCalsTotal.Text = Convert.ToString(nutr_vale);

                                                }
                                                else
                                                {
                                                    nutr_vale = 0;
                                                    // lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";
                                                    // lbCalsTotal.Text = Convert.ToString(nutr_vale);

                                                }
                                                //if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(unit + 16, nu_feLevel - unit - 18))))
                                                //{
                                                //    nutr_unit = Convert.ToString(data1.Substring(unit + 16, nu_feLevel - unit - 18));
                                                //}

                                                //else
                                                //{
                                                //    nutr_unit = "";
                                                //}
                                            }
                                            else if (text == "Choles")
                                            {
                                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                                {

                                                    nutr_vale1 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                                    // lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
                                                }
                                                else
                                                {
                                                    nutr_vale1 = 0;
                                                    //lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
                                                }

                                            }
                                            else if (text == "Dietar")
                                            {
                                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                                {

                                                    nutr_vale2 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                                    // lbTotalFiber.Text= Convert.ToString(nutr_vale2) + "g";
                                                }
                                                else
                                                {
                                                    nutr_vale2 = 0;
                                                    // lbTotalFiber.Text = Convert.ToString(nutr_vale2) + "g";
                                                }

                                            }

                                            else if (text == "Protei")
                                            {
                                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                                {

                                                    nutr_vale3 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                                    //  lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
                                                }
                                                else
                                                {
                                                    nutr_vale3 = 0;
                                                    //  lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
                                                }

                                            }

                                            else if (text == "Sodium")
                                            {
                                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                                {

                                                    nutr_vale4 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                                    // lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
                                                }
                                                else
                                                {
                                                    nutr_vale4 = 0;
                                                    //  lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
                                                }

                                            }

                                            else if (text == "Sugars")
                                            {
                                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                                {

                                                    nutr_vale5 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                                    // lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
                                                }
                                                else
                                                {
                                                    nutr_vale5 = 0;
                                                    //  lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
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
                                                        // lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
                                                    }
                                                    else
                                                    {
                                                        nutr_vale6 = 0;
                                                        // lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
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
                                                        // lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
                                                    }
                                                    else
                                                    {
                                                        nutr_vale7 = 0;
                                                        //  lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
                                                    }

                                                }
                                            }

                                        }

                                        // table.Rows.Add(nutr_vale, nutr_unit);
                                        string size = data.Substring(p_size + 16, 3).Replace("''", "").Replace("}", "").Replace("\"\r\n", "").Replace("\"", "");
                                        table.Rows.Add(data.Substring(13, 12), data.Substring(p_name + 16, p_desc - p_name - 23),
                                   size, nutr_vale, nutr_vale1, nutr_vale2, nutr_vale3, nutr_vale4, nutr_vale5, nutr_vale6, nutr_vale7);
                                    }
                                }
                            }

                        }
                    }
                    else
                    {


                    }
                    if (number < count)
                    {
                       grData.AllowPaging = true;
                    }
                    objUserFoodLog.ProcedureType = Searchname;
                    DataSet ds = UserFoodLogDAO.GetCustomFoodList(objUserFoodLog);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int iCount = 0; iCount <= ds.Tables[0].Rows.Count - 1; iCount++)
                            {
                                table.Rows.Add(ds.Tables[0].Rows[iCount]["food_name"].ToString(),
                                                ds.Tables[0].Rows[iCount]["brand_name"].ToString(),
                                                ds.Tables[0].Rows[iCount]["serving_size"].ToString(),
                                                ds.Tables[0].Rows[iCount]["Calories"].ToString(),
                                                ds.Tables[0].Rows[iCount]["cholestrol"].ToString(),
                                                ds.Tables[0].Rows[iCount]["fiber"].ToString(),
                                                ds.Tables[0].Rows[iCount]["protein"].ToString(),
                                                ds.Tables[0].Rows[iCount]["sodium"].ToString(),
                                                ds.Tables[0].Rows[iCount]["sugars"].ToString(),
                                                ds.Tables[0].Rows[iCount]["carbohydrates"].ToString(),
                                                ds.Tables[0].Rows[iCount]["total_fat"].ToString());

                            }
                        }
                    }
                    grData.DataSource = table;
                    grData.DataBind();
                    table = null;
                    if (s == 0)
                    {
                        ImgBtnPrev.Enabled = false;
                        ImgBtnPrev.Style.Add("cursor", "not-allowed");
                        ImgBtnNext.Enabled = true;
                        ImgBtnNext.Style.Add("cursor", "pointer");
                    }
                    else if (n1 == s)
                    {
                        ImgBtnNext.Enabled = false;
                        ImgBtnNext.Style.Add("cursor", "not-allowed");
                        ImgBtnPrev.Enabled = true;
                        ImgBtnPrev.Style.Add("cursor", "pointer");
                    }
                    else
                    {
                        ImgBtnNext.Enabled = true;
                        ImgBtnPrev.Enabled = true;
                        ImgBtnNext.Style.Add("cursor", "pointer");
                        ImgBtnPrev.Style.Add("cursor", "pointer");
                    }

                }
                else
                {
                    Label1.Text = "No Record Searched." + "<br/>" + "Reason: Developer Over Rate" + "<br/>" + "Description: You are using development version of API, and your limit of testing/searching per day is over. Better try it tommorrow.";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //protected void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    ClsGeneric.ReplaceCookie();
        //    try
        //    {
        //        n = 10;
        //        s = 0;
        //        BindCAt();
        //        Searchname = txtSearch.Text.Trim();
        //        string url = "http://api.foodessentials.com/searchprods?q=" + Searchname + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&n=10&s=0&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";
        //        var currencyRates = _download_serialized_json_data<CurrencyRates>(url);
        //        if (currencyRates != null)
        //        {
        //            n1 = Convert.ToInt32(currencyRates.numFound);
        //        }
        //        Searchname = txtSearch.Text.Trim();
        //        ImgBtnPrev.Enabled = false;
        //        ImgBtnPrev.Style.Add("cursor", "not-allowed");
        //        if (n1 > s)
        //        {
        //            ImgBtnNext.Enabled = true;
        //            ImgBtnNext.Style.Add("cursor", "pointer");
        //        }
        //        else
        //        {
        //            ImgBtnNext.Enabled = false;
        //            ImgBtnNext.Style.Add("cursor", "not-allowed");
        //        }
        //        bindGrd();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //}

        //protected void grData_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            Label lblUpc = (Label)e.Row.FindControl("lblUpc");
        //            Label lbCal = (Label)e.Row.FindControl("lbcal");
        //            Label lbfat = (Label)e.Row.FindControl("lbfat");
        //            Label lbchol = (Label)e.Row.FindControl("lbChol");
        //            Label lbfiber = (Label)e.Row.FindControl("lbFiber");
        //            Label lbsugar = (Label)e.Row.FindControl("lbSugar");
        //            if (lbCal.Text == "")
        //            {
        //                lbCal.Text = "0.0";
        //            }
        //            if (lbfat.Text == "")
        //            {
        //                lbfat.Text = "0.0";
        //            }
        //            if (lbchol.Text == "")
        //            {
        //                lbchol.Text = "0.0";
        //            }

        //            if (lbfiber.Text == "")
        //            {
        //                lbfiber.Text = "0.0";
        //            }

        //            if (lbsugar.Text == "")
        //            {
        //                lbsugar.Text = "0.0";
        //            }

        //            ImageButton imgAdd = (ImageButton)e.Row.FindControl("imgAdd");
        //            imgAdd.Visible = true;

        //            if (Convert.ToString(ViewState["mission_overall_status"]) == "1")
        //            {
        //                imgAdd.Visible = false;
        //            }

        //            /*
        //             * binding link button results through api
        //             * */

        //            Label lbTotalcal = (Label)e.Row.FindControl("lbTotalcal");
        //            Label lbtotalfat = (Label)e.Row.FindControl("lbtotalfat");
        //            Label lbtotalchol = (Label)e.Row.FindControl("lbtotalchol");
        //            Label lbTotalSodium = (Label)e.Row.FindControl("lbTotalSodium");
        //            Label lbtotalCarbs = (Label)e.Row.FindControl("lbtotalCarbs");
        //            Label lbTotalFiber = (Label)e.Row.FindControl("lbTotalFiber");
        //            Label lbTotalProteins = (Label)e.Row.FindControl("lbTotalProteins");
        //            Label lbTotalSugar = (Label)e.Row.FindControl("lbTotalSugar");
        //            Label lbCalsTotal = (Label)e.Row.FindControl("lbCalsTotal");
        //            ImageButton ImgAddLog = (ImageButton)e.Row.FindControl("ImgAddLog");

        //            //string[] arg = new string[3];

        //            //Searchname = arg[2];
        //            string data1 = null;
        //            //string id = arg[0];
        //            DataTable table = new DataTable("ApiData");

        //            table.Columns.Add("cal", typeof(string));
        //            table.Columns.Add("Cholesterol", typeof(string));
        //            table.Columns.Add("Fiber", typeof(string));
        //            table.Columns.Add("Protein", typeof(string));
        //            table.Columns.Add("Sodium", typeof(string));
        //            table.Columns.Add("Sugars", typeof(string));
        //            table.Columns.Add("Carbohydrate", typeof(string));
        //            table.Columns.Add("Fat", typeof(string));
        //            string url1 = "http://api.foodessentials.com/productscore?u=" + lblUpc.Text.Trim() + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";
        //            int cal = 0;
        //            int unit = 0;
        //            var currencyRates1 = _download_serialized_json_data_2<CurrencyRates1>(url1);
        //            if (currencyRates1 != null)
        //            {
        //                if (currencyRates1.nutrients != null)
        //                {
        //                    if (currencyRates1.nutrients.Count > 0)
        //                    {
        //                        for (var x1 = 0; x1 < currencyRates1.nutrients.Count; x1++)
        //                        {
        //                            data1 = currencyRates1.nutrients[x1].ToString();
        //                            cal = data1.IndexOf("nutrient_value");
        //                            unit = data1.IndexOf("nutrient_uom");
        //                            int nu_feLevel = data1.IndexOf("nutrient_fe_level");



        //                            string text = Convert.ToString(data1.Substring(23, 6));

        //                            if (text == "Calori")
        //                            {
        //                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                {

        //                                    nutr_vale = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                    lbCalsTotal.Text = Convert.ToString(nutr_vale);
        //                                    lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";
        //                                }
        //                                else
        //                                {
        //                                    nutr_vale = 0;
        //                                    lbCalsTotal.Text = Convert.ToString(nutr_vale) + "cal";
        //                                    lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";

        //                                }

        //                            }
        //                            else if (text == "Choles")
        //                            {
        //                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                {

        //                                    nutr_vale1 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                    lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
        //                                }
        //                                else
        //                                {
        //                                    nutr_vale1 = 0;
        //                                    lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
        //                                }

        //                            }
        //                            else if (text == "Dietar")
        //                            {
        //                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                {

        //                                    nutr_vale2 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                    lbTotalFiber.Text = Convert.ToString(nutr_vale2) + "g";
        //                                }
        //                                else
        //                                {
        //                                    nutr_vale2 = 0;
        //                                    lbTotalFiber.Text = Convert.ToString(nutr_vale2) + "g";
        //                                }

        //                            }

        //                            else if (text == "Protei")
        //                            {
        //                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                {

        //                                    nutr_vale3 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                    lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
        //                                }
        //                                else
        //                                {
        //                                    nutr_vale3 = 0;
        //                                    lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
        //                                }

        //                            }

        //                            else if (text == "Sodium")
        //                            {
        //                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                {

        //                                    nutr_vale4 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                    lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
        //                                }
        //                                else
        //                                {
        //                                    nutr_vale4 = 0;
        //                                    lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
        //                                }

        //                            }

        //                            else if (text == "Sugars")
        //                            {
        //                                if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                {

        //                                    nutr_vale5 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                    lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
        //                                }
        //                                else
        //                                {
        //                                    nutr_vale5 = 0;
        //                                    lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
        //                                }

        //                            }
        //                            if (total == null)
        //                            {
        //                                if (text == "Total ")
        //                                {
        //                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                    {

        //                                        nutr_vale6 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                        total = text;
        //                                        lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
        //                                    }
        //                                    else
        //                                    {
        //                                        nutr_vale6 = 0;
        //                                        lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
        //                                    }

        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (text == "Total ")
        //                                {
        //                                    if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
        //                                    {

        //                                        nutr_vale7 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
        //                                        lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
        //                                    }
        //                                    else
        //                                    {
        //                                        nutr_vale7 = 0;
        //                                        lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
        //                                    }

        //                                }
        //                            }

        //                        }
        //                        //lbtotalfat.Text = "rishi";
        //                        // table.Rows.Add(nutr_vale, nutr_unit);
        //                        //Pro_size = arg[1];
        //                        table.Rows.Add(nutr_vale, nutr_vale1, nutr_vale2, nutr_vale3, nutr_vale4, nutr_vale5, nutr_vale6, nutr_vale7);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //}
        protected void GrdFoodLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowIndex != -1)
                    {
                        e.Row.Attributes["onmouseover"] = "showContents('" + (e.Row.RowIndex + 1) + "')";
                        e.Row.Attributes["onmouseout"] = "HideElemments('" + (e.Row.RowIndex + 1) + "')";
                        
                    }
                    Label lbID = (Label)e.Row.FindControl("lbID");                


                    Label lbEatingTime = (Label)e.Row.FindControl("lbEatingTime");
                    DropDownList drpEating = (DropDownList)e.Row.FindControl("drpEating");
                    DataTable dt = new DataTable();
                    objUserRegisterBAO.ID = lbID.Text;
                    objUserRegisterBAO.procedureType = "ET";
                    dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dt.Rows.Count > 0)
                    {
                        if (lbEatingTime != null)
                        {
                            lbEatingTime.Text = dt.Rows[0]["ET_NAME"].ToString();
                        }
                        if (drpEating != null)
                        {
                            drpEating.SelectedValue = dt.Rows[0]["ET_ID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFAvFoodLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ex.ToString();
            }
 
        }
        protected void grData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                BindCAt();
                if (e.CommandName == "ImgAddFood")
                {

                    //dvFoodLogOfMissionId.Style.Add("display", "block");
                    string[] arg = new string[7];
                    arg = e.CommandArgument.ToString().Split(';');
                    string name = arg[0];
                    string size = arg[1];
                    string cal = arg[2];
                    string fat = arg[3];
                    string chol = arg[4];
                    string fiber = arg[5];
                    string sugar = arg[6];

                    int retval = 0;
                    objUserFoodLog.UFL_ID = 0;
                    objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                    objUserFoodLog.Search_Name = name;
                    objUserFoodLog.Product_Size = "1";
                    objUserFoodLog.QUANTITY = 0;
                    if (cal != "")
                    {
                        objUserFoodLog.CALORIES = cal;
                    }
                    else
                    {
                        objUserFoodLog.CALORIES = "0.0";
                    }
                    if (fat != "")
                    {
                        objUserFoodLog.FAT = fat;
                    }
                    else
                    {
                        objUserFoodLog.FAT = "0.0";
                    }
                    if (chol != "")
                    {
                        objUserFoodLog.CHOLESTROL = chol;
                    }
                    else
                    {
                        objUserFoodLog.CHOLESTROL = "0.0";
                    }

                    objUserFoodLog.SODIUM = "0.0";

                    objUserFoodLog.CARBOHYDRATES = "0.0";

                    if (fiber != "")
                    {
                        objUserFoodLog.FIBER = fiber;
                    }
                    else
                    {
                        objUserFoodLog.FIBER = "0.0";
                    }

                    objUserFoodLog.PROTIENS = "0.0";

                    if (sugar != "")
                    {
                        objUserFoodLog.SUGAR = sugar;
                    }
                    else
                    {
                        objUserFoodLog.SUGAR = "0.0";
                    }
                    objUserFoodLog.UFL_DATE = DateTime.Now.ToString();
                    objUserFoodLog.ProcedureType = "I";
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                    retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);

                    int retval1 = 0;
                    objUserFoodLog.ETL_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserFoodLog.UFL_ID_FK = retval;
                    DataTable dt = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt.Rows.Count > 0)
                    {
                        objUserFoodLog.ET_ID_FK = Convert.ToInt32(dt.Rows[0]["ET_ID"]);
                    }
                    objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                    objUserFoodLog.ProcedureType = "I";
                    retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                    DataTable dtEathabbit = new DataTable();
                    objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objUserRegisterBAO.procedureType = "EH";
                    dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dtEathabbit.Rows.Count > 0)
                    {
                        int retupdate = 0;
                        objUserFoodLog.EH_ID = 0;
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        DataTable dt1 = new DataTable();
                        objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                        objUserFoodLog.ProcedureType = "S";
                        dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                                objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                                {
                                    objUserFoodLog.EH_BREAKFAST = "Y";
                                    objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                                objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                                {
                                    objUserFoodLog.EH_LUNCH = "Y";
                                    objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                                objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                                {
                                    objUserFoodLog.EH_DINNER = "Y";
                                    objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }

                            if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                                objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                                {
                                    objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                    objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                                objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                                {
                                    objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                    objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "4")
                                {
                                    objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                    objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                        }
                        objUserFoodLog.ProcedureType = "U";
                        retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                    }
                    else
                    {
                        int retvalHabbit = 0;
                        objUserFoodLog.EH_ID = 0;
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        DataTable dt1 = new DataTable();
                        objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                        objUserFoodLog.ProcedureType = "S";
                        dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                            {
                                objUserFoodLog.EH_BREAKFAST = "Y";
                                objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                            {
                                objUserFoodLog.EH_LUNCH = "Y";
                                objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                            {
                                objUserFoodLog.EH_DINNER = "Y";
                                objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        objUserFoodLog.ProcedureType = "I";
                        retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                    }
                    //
                    objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                    {
                        objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                    }
                    else
                    {
                        objUserMissionBAL.MissionId = 0;
                    }
                    objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                    objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(cal);
                    objUserMissionBAL.Pk_user_Log_Id = retval;
                    objUserMissionBAL.Request_Type = 1;
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim()) + DateTime.Now.ToString(" HH:mm:ss tt")); //Convert.ToDateTime(txtCalendarNavigation.Text);

                    objUserMissionBAL.Activity_Performed = string.Empty;
                    objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    objUserMissionBAL.Activity_Hours = 0;
                    objUserMissionBAL.Activity_minutes = 0;
                    objUserMissionBAL.Activity_Seconds = 0;
                    objUserMissionBAL.Distance_Units = "0";
                    objUserMissionBAL.Distance_Covered = 0;

                    objUserMissionBAL.Activity_Id = 0;
                    objUserMissionBAL.StepsCovered = 0;

                    DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);

                    ModifyWeight_BasedOnLogInput(0, Convert.ToDecimal(cal), objUserMissionBAL.DateOfCompletion.ToString(), Convert.ToInt32(dtLog.Rows[0]["fk_mission_log_id"]));



                    Bind_History();

                    /*
                     * The calories that were consumed either by search or input ar e inserted here to show charts.
                     * 
                     * */

                    string strCal = cal;
                    int index = strCal.IndexOf(' ');
                    //if (index > 0)
                    //    AddDailyCaloriesInput(Convert.ToDecimal(strCal.Substring(0, index)), 0, retval, 1, "", 0);
                    //else
                    //    AddDailyCaloriesInput(Convert.ToDecimal(strCal), 0, retval, 1, "", 0);

                    BindFoodLog();
                    //


                    // dvSearch.Style.Add("display", "");
                    //BindTotal();
                }
                else if (e.CommandName == "lnkADDFL")
                {

                    dvSerach.Style.Add("display", "");
                    string[] arg = new string[7];
                    arg = e.CommandArgument.ToString().Split(';');
                    string name = arg[0];
                    string size = arg[1];
                    string cal = arg[2];
                    string fat = arg[3];
                    string chol = arg[4];
                    string fiber = arg[5];
                    string sugar = arg[6];

                    int retval = 0;
                    objUserFoodLog.UFL_ID = 0;
                    objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                    objUserFoodLog.Search_Name = name;
                    objUserFoodLog.Product_Size = "1";
                    objUserFoodLog.QUANTITY = 0;
                    if (cal != "")
                    {
                        objUserFoodLog.CALORIES = cal;
                    }
                    else
                    {
                        objUserFoodLog.CALORIES = "0.0";
                    }
                    if (fat != "")
                    {
                        objUserFoodLog.FAT = fat;
                    }
                    else
                    {
                        objUserFoodLog.FAT = "0.0";
                    }
                    if (chol != "")
                    {
                        objUserFoodLog.CHOLESTROL = chol;
                    }
                    else
                    {
                        objUserFoodLog.CHOLESTROL = "0.0";
                    }

                    objUserFoodLog.SODIUM = "0.0";

                    objUserFoodLog.CARBOHYDRATES = "0.0";

                    if (fiber != "")
                    {
                        objUserFoodLog.FIBER = fiber;
                    }
                    else
                    {
                        objUserFoodLog.FIBER = "0.0";
                    }

                    objUserFoodLog.PROTIENS = "0.0";

                    if (sugar != "")
                    {
                        objUserFoodLog.SUGAR = sugar;
                    }
                    else
                    {
                        objUserFoodLog.SUGAR = "0.0";
                    }
                    objUserFoodLog.UFL_DATE = DateTime.Now.ToString();
                    objUserFoodLog.ProcedureType = "I";
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                    retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);

                    int retval1 = 0;
                    objUserFoodLog.ETL_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserFoodLog.UFL_ID_FK = retval;
                    DataTable dt = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt.Rows.Count > 0)
                    {
                        objUserFoodLog.ET_ID_FK = Convert.ToInt32(dt.Rows[0]["ET_ID"]);
                    }
                    objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                    objUserFoodLog.ProcedureType = "I";
                    retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                    DataTable dtEathabbit = new DataTable();
                    objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objUserRegisterBAO.procedureType = "EH";
                    dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dtEathabbit.Rows.Count > 0)
                    {
                        int retupdate = 0;
                        objUserFoodLog.EH_ID = 0;
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        DataTable dt1 = new DataTable();
                        objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                        objUserFoodLog.ProcedureType = "S";
                        dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                                objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                                {
                                    objUserFoodLog.EH_BREAKFAST = "Y";
                                    objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                                objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                                {
                                    objUserFoodLog.EH_LUNCH = "Y";
                                    objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                                objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                                {
                                    objUserFoodLog.EH_DINNER = "Y";
                                    objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }

                            if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                                objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                                {
                                    objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                    objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                                objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                                {
                                    objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                    objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "4")
                                {
                                    objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                    objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                        }
                        objUserFoodLog.ProcedureType = "U";
                        retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                    }
                    else
                    {
                        int retvalHabbit = 0;
                        objUserFoodLog.EH_ID = 0;
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        DataTable dt1 = new DataTable();
                        objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                        objUserFoodLog.ProcedureType = "S";
                        dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                            {
                                objUserFoodLog.EH_BREAKFAST = "Y";
                                objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                            {
                                objUserFoodLog.EH_LUNCH = "Y";
                                objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                            {
                                objUserFoodLog.EH_DINNER = "Y";
                                objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        objUserFoodLog.ProcedureType = "I";
                        retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                    }

                    objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                    {
                        objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                    }
                    else
                    {
                        objUserMissionBAL.MissionId = 0;
                    }
                    objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                    objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(cal);
                    objUserMissionBAL.Pk_user_Log_Id = retval;
                    objUserMissionBAL.Request_Type = 1;
                    if (hdnSelectedDateForMissionHistory.Value == "")
                    {
                        objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                    }

                    else
                    {
                        objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(hdnSelectedDateForMissionHistory.Value.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                    }

                    objUserMissionBAL.Activity_Performed = string.Empty;
                    objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    objUserMissionBAL.Activity_Hours = 0;
                    objUserMissionBAL.Activity_minutes = 0;
                    objUserMissionBAL.Activity_Seconds = 0;
                    objUserMissionBAL.Distance_Units = "0";
                    objUserMissionBAL.Distance_Covered = 0;

                    objUserMissionBAL.Activity_Id = 0;
                    objUserMissionBAL.StepsCovered = 0;

                    DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                    ModifyWeight_BasedOnLogInput(0, Convert.ToDecimal(cal), objUserMissionBAL.DateOfCompletion.ToString(), Convert.ToInt32(dtLog.Rows[0]["fk_mission_log_id"]));
                    Bind_History();
                    /*
                     * The calories that were consumed either by search or input ar e inserted here to show charts.
                     * 
                     * */

                    //AddDailyCaloriesInput(Convert.ToDecimal(cal), 0, retval, 1, "", 0);
                    BindFoodLog();

                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }
        private void BindFoodLog()
        {
            try
            {
                //if (!String.IsNullOrEmpty(Convert.ToString(Session["selected_mission_id"])))
                //{
                DataTable dt = new DataTable();
                objUserFoodLog = new UserFoodLogBAO();
                objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserFoodLog.UFL_DATE = txtCalendarNavigation.Text;
                }

                else
                {
                    objUserFoodLog.UFL_DATE = Convert.ToString(hdnSelectedDateForMissionHistory.Value);
                }
                if (Convert.ToString(Session["selected_mission_id"]) == "" || Convert.ToString(Session["selected_mission_id"]) == null)
                {
                    objUserFoodLog.Fk_MissionId = 0;
                }
                else
                {
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                }
                objUserFoodLog.ProcedureType = "V";
                objUserFoodLog.ID = 1;
                dt = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);

                GrdFoodLog.Visible = true;
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("FavImage",typeof(string));
                        dt.AcceptChanges();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["favID"])))
                            {
                                dt.Rows[i]["FavImage"] = "~/images/star_sel.png"; 
                                dt.AcceptChanges();

                            }
                            else
                            {
                                dt.Rows[i]["FavImage"] = "~/images/star_not_sel.png";
                                dt.AcceptChanges();

                            }
                        }
                        GrdFoodLog.DataSource = dt;
                        GrdFoodLog.DataBind();
                    }
                    else
                    {
                        GrdFoodLog.DataSource = null;
                        GrdFoodLog.DataBind();
                    }
                }
                else
                {
                    GrdFoodLog.DataSource = null;
                    GrdFoodLog.DataBind();
                }
                //  dvFoodLogOfMissionId.Style.Add("display", "block");
                BindTotal();
                // Bind_History();
                //piechartbind();
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void dtFoodLogActivityImages_RowCommand(object sender, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "AddFoodLogSelected")
                {
                    BindCAt();

                    string caloriesBurn = e.CommandArgument.ToString();
                    Label lblActivity = (Label)e.Item.FindControl("lblActivity");
                    objUserFoodLog.UFL_ID = 0;
                    objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                    objUserFoodLog.Search_Name = lblActivity.Text;
                    objUserFoodLog.Product_Size = 1;
                    objUserFoodLog.QUANTITY = 0;
                    objUserFoodLog.CALORIES = caloriesBurn;
                    objUserFoodLog.FAT = "0.0";
                    objUserFoodLog.CHOLESTROL = "0.0";
                    objUserFoodLog.SODIUM = "0.0";
                    objUserFoodLog.CARBOHYDRATES = "0.0";
                    objUserFoodLog.FIBER = "0.0";
                    objUserFoodLog.PROTIENS = "0.0";
                    objUserFoodLog.SUGAR = "0.0";

                    // objUserFoodLog.UFL_DATE = DateTime.Now.ToString();
                    objUserFoodLog.UFL_DATE = txtCalendarNavigation.Text + DateTime.Now.ToString(" HH:mm:ss tt");
                    objUserFoodLog.ProcedureType = "I";
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);

                    int retval = 0;
                    retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);
                    int retval1 = 0;
                    objUserFoodLog.ETL_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserFoodLog.UFL_ID_FK = retval;
                    DataTable dt = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt.Rows.Count > 0)
                    {
                        objUserFoodLog.ET_ID_FK = Convert.ToInt32(dt.Rows[0]["ET_ID"]);
                    }
                    objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                    objUserFoodLog.ProcedureType = "I";
                    retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                    DataTable dtEathabbit = new DataTable();
                    objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objUserRegisterBAO.procedureType = "EH";
                    dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dtEathabbit.Rows.Count > 0)
                    {
                        int retupdate = 0;
                        objUserFoodLog.EH_ID = 0;
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        DataTable dt1 = new DataTable();
                        objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                        objUserFoodLog.ProcedureType = "S";
                        dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                                objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                                {
                                    objUserFoodLog.EH_BREAKFAST = "Y";
                                    objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                                objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                                {
                                    objUserFoodLog.EH_LUNCH = "Y";
                                    objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                                objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                                {
                                    objUserFoodLog.EH_DINNER = "Y";
                                    objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }

                            if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                                objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                                {
                                    objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                    objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                                objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                                {
                                    objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                    objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                            if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                            }
                            else
                            {
                                if (dt1.Rows[0]["ET_ID"].ToString() == "4")
                                {
                                    objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                    objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                        }
                        objUserFoodLog.ProcedureType = "U";
                        retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                    }
                    else
                    {
                        int retvalHabbit = 0;
                        objUserFoodLog.EH_ID = 0;
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        DataTable dt1 = new DataTable();
                        objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                        objUserFoodLog.ProcedureType = "S";
                        dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                            {
                                objUserFoodLog.EH_BREAKFAST = "Y";
                                objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }

                            else if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                            {
                                objUserFoodLog.EH_LUNCH = "Y";
                                objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                            {
                                objUserFoodLog.EH_DINNER = "Y";
                                objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        objUserFoodLog.ProcedureType = "I";
                        retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                    }
                    objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                    {
                        objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                    }
                    else
                    {
                        objUserMissionBAL.MissionId = 0;
                    }
                    objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                    objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(caloriesBurn);
                    objUserMissionBAL.Pk_user_Log_Id = retval;
                    objUserMissionBAL.Request_Type = 1;
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim()) + DateTime.Now.ToString(" HH:mm:ss tt")); //Convert.ToDateTime(txtCalendarNavigation.Text);

                    objUserMissionBAL.Activity_Performed = lblActivity.Text;
                    objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    objUserMissionBAL.Activity_Hours = 0;
                    objUserMissionBAL.Activity_minutes = 0;
                    objUserMissionBAL.Activity_Seconds = 0;
                    objUserMissionBAL.Distance_Units = "0";
                    objUserMissionBAL.Distance_Covered = 0;

                    objUserMissionBAL.Activity_Id = 0;
                    objUserMissionBAL.StepsCovered = 0;

                    DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                    ModifyWeight_BasedOnLogInput(0, Convert.ToDecimal(cal), objUserMissionBAL.DateOfCompletion.ToString(), Convert.ToInt32(dtLog.Rows[0]["fk_mission_log_id"]));
                    Bind_History();
                    BindFoodLog();
                    radOptionOne.Checked = false;
                    radOptionTwo.Checked = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFoodLog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                BindCAt();
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
                        bindGrdFAv();
                        BindFoodLog();
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
                    //Bind_History();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void GrdFoodLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                BindCAt();
                string lbid;
                lbid = ((Label)GrdFoodLog.Rows[e.RowIndex].FindControl("lbID")).Text;
                if (lbid != "")
                {
                    int retvaleat = 0;
                    objUserFoodLog.UFL_ID = lbid;
                    objUserFoodLog.ProcedureType = "DEL";
                    retvaleat = UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLog);

                    int retval = 0;
                    objUserFoodLog.UFL_ID = lbid;
                    objUserFoodLog.ProcedureType = "DF";
                    retval = UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLog);
                    GrdFoodLog.EditIndex = -1;
                    BindFoodLog();
                    Bind_History();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void piechartbind()
        {
            try
            {
                Chart2.Legends.Clear();
                Series series1 = Chart2.Series[0];
                string[] xValues = { "Cals" + "(" + cal + " cal)", "Fat" + " (" + fat + " g)", "Chol" + "(" + chol + " mg)", "Fiber" + " (" + fiber + " g)", "Sugars" + "(" + sugar + " g)" };
                int[] yValues = { cal, fat, chol, fiber, sugar };
                Chart2.Series["Series1"].Points.DataBindXY(xValues, yValues);
                Chart2.Series["Series1"].Points[0].Color = Color.Red;
                Chart2.Series["Series1"].Points[1].Color = Color.Blue;
                Chart2.Series["Series1"].Points[2].Color = Color.Yellow;
                Chart2.Series["Series1"].Points[3].Color = Color.Green;
                Chart2.Series["Series1"].Points[4].Color = Color.Indigo;
                Chart2.Series["Series1"].ChartType = SeriesChartType.Pie;
                Chart2.Series["Series1"]["PieLabelStyle"] = "Enable";
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;


                Chart2.Legends.Add("Legend1");



                Chart2.Legends["Legend1"].Enabled = true;
                Chart2.Legends["Legend1"].Docking = Docking.Bottom;
                Chart2.Series["Series1"].IsVisibleInLegend = true;

                Chart2.Series[0].Points[0].CustomProperties += "Exploded=true";
                Chart2.Series[0].Points[1].CustomProperties += "Exploded=true";
                Chart2.Series[0].Points[2].CustomProperties += "Exploded=true";
                Chart2.Series[0].Points[3].CustomProperties += "Exploded=true";
                Chart2.Series[0].Points[4].CustomProperties += "Exploded=true";
                lengend = "1";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void BindTotal()
        {
            try
            {
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
                objUserFoodLog.ProcedureType = "T";
                objUserFoodLog.ID = "1";
                dt = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
                if (dt.Rows.Count > 0)
                {

                    if (dt.Rows[0]["totalcal"].ToString() != "")
                    {
                        cal = Convert.ToInt32(dt.Rows[0]["totalcal"]);

                    }
                    else
                    {
                        cal = 0;

                    }

                    if (dt.Rows[0]["totalfat"].ToString() != "")
                    {


                        fat = Convert.ToInt32(dt.Rows[0]["totalfat"]);
                    }
                    else
                    {
                        fat = 0;

                    }

                    if (dt.Rows[0]["totalchol"].ToString() != "")
                    {

                        chol = Convert.ToInt32(dt.Rows[0]["totalchol"]);
                    }
                    else
                    {
                        chol = 0;

                    }




                    if (dt.Rows[0]["totalfiber"].ToString() != "")
                    {

                        fiber = Convert.ToInt32(dt.Rows[0]["totalfiber"]);
                    }
                    else
                    {
                        fiber = 0;

                    }


                    if (dt.Rows[0]["totalsugar"].ToString() != "")
                    {

                        sugar = Convert.ToInt32(dt.Rows[0]["totalsugar"]);
                    }
                    else
                    {
                        sugar = 0;

                    }
                    //  dvChart.Style.Add("display", "");
                    piechartbind();
                    if (cal == 0 && sugar == 0 && fiber == 0 && chol == 0 && fat == 0)
                    {
                        lbChart.Visible = true;
                        lbChart.Text = "Daily food log chart ";
                        Chart2.Style.Add("display", "none");
                    }
                    else
                    {
                        lbChart.Visible = false;

                        Chart2.Style.Add("display", "");
                    }
                }
                else
                {
                    Chart2.Style.Add("display", "none");
                    lbChart.Visible = true;
                    lbChart.Text = "Daily food log chart";
                    Chart2.Legends.Clear();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void Chart2_Click(object sender, ImageMapEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int _clickedPoint = int.Parse(e.PostBackValue);
                Series series1 = Chart2.Series[0];
                string[] xValues = { "Cals", "Fat", "Chol", "Fiber", "Sugars" };
                int[] yValues = { cal, fat, chol, fiber, sugar };
                Chart2.Series["Series1"].Points.DataBindXY(xValues, yValues);
                Chart2.Series["Series1"].Points[0].Color = Color.Red;
                Chart2.Series["Series1"].Points[1].Color = Color.BlueViolet;
                Chart2.Series["Series1"].Points[2].Color = Color.Blue;
                Chart2.Series["Series1"].Points[3].Color = Color.Indigo;
                Chart2.Series["Series1"].Points[4].Color = Color.DarkBlue;

                Series defaultSeries = Chart2.Series["Series1"];
                if (_clickedPoint >= 0 && _clickedPoint < chartPoints)
                {
                    Chart2.Series["Series1"].Points[_clickedPoint].CustomProperties += "Exploded=true";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void bindGrdFAv()
        {
            try
            {
                DataTable dt = new DataTable();
                if (Convert.ToString(MySession.Current.SelectedCircleUserId) == Convert.ToString(MySession.Current.LoginId))
                {
                    objUserFoodLog.ID = Convert.ToInt32(MySession.Current.LoginId);
                }
                else
                {
                    objUserFoodLog.ID = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                }
                objUserFoodLog.ProcedureType = "FFL";
                dt = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);
                GrdFAvFoodLog.DataSource = dt;
                GrdFAvFoodLog.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void txtCalendarNavigation_TextChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                BindCAt();

                BindFoodLog();
                bindGrdFAv();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void BindCAt()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserFoodLog.ProcedureType = "FC";
                dt = UserFoodLogDAO.GetFoodCategories(objUserFoodLog);
                grdCategoriesfood.DataSource = dt;
                grdCategoriesfood.DataBind();
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grdCategoriesfood_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView grdSubCategories = (GridView)e.Row.FindControl("grdSubCategoriesfood");
                    string CommentId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CAT_ID"));
                    LinkButton lnkCategory = (LinkButton)e.Row.FindControl("lnkCategory");
                    DataTable dtPsubcat = new DataTable();
                    objUserFoodLog.ID = Convert.ToInt32(CommentId);
                    objUserFoodLog.ProcedureType = "FS";
                    dtPsubcat = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);
                    if (dtPsubcat.Rows.Count > 0)
                    {
                        grdSubCategories.DataSource = dtPsubcat;
                        grdSubCategories.DataBind();
                    }
                    else
                    {
                        grdSubCategories.DataSource = null;
                        grdSubCategories.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdSubCategoriesfood_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string CommentId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CAT_ID_FK"));
                    LinkButton lnkBtnMAjorSubcat = (LinkButton)e.Row.FindControl("lnkBtnMAjorSubcat");
                    DataTable dtsubcat = new DataTable();
                    objUserFoodLog.ID = Convert.ToInt32(CommentId);
                    objUserFoodLog.ProcedureType = "FC";
                    dtsubcat = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);

                    if (dtsubcat.Rows.Count > 0)
                    {
                        grdActivitiesfood.DataSource = dtsubcat;
                        grdActivitiesfood.DataBind();
                    }
                    else
                    {
                        grdActivitiesfood.DataSource = null;
                        grdActivitiesfood.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdSubCategoriesfood_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "SelectSubCategory")
                {
                    BindCAt();
                    grdActivitiesfood.DataSource = null;
                    grdActivitiesfood.DataBind();


                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    Searchname = arg[1];
                    string CommentId = arg[0];
                    int index = Convert.ToInt32(CommentId);
                    objUserFoodLog.ID = Convert.ToInt32(CommentId);
                    objUserFoodLog.ProcedureType = "FC";
                    System.Data.DataTable retval = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);

                    if (retval.Rows.Count > 0)
                    {

                        grdActivitiesfood.DataSource = retval;
                        grdActivitiesfood.DataBind();


                    }
                    else
                    {
                        grdActivitiesfood.DataSource = null;
                        grdActivitiesfood.DataBind();
                        txtSearch.Text = Searchname;
                        bindGrd();

                    }

                    modalPopActivities.Show();
                    pnlActivities.Style.Add("display", "");

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdCategoriesfood_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "SelectCategory")
                {
                    BindCAt();
                    grdActivitiesfood.DataSource = null;
                    grdActivitiesfood.DataBind();
                    //BindCAt();
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    Searchname = arg[1];
                    string CommentId = arg[0];

                    objUserFoodLog.ID = Convert.ToInt32(CommentId);
                    objUserFoodLog.ProcedureType = "CMS";
                    System.Data.DataTable retval = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);

                    if (retval.Rows.Count > 0)
                    {

                        grdActivitiesfood.DataSource = retval;
                        grdActivitiesfood.DataBind();
                        modalPopActivities.Show();
                        pnlActivities.Style.Add("display", "");
                    }
                    else
                    {

                        grdActivitiesfood.DataSource = null;
                        grdActivitiesfood.DataBind();
                        txtSearch.Text = Searchname;
                        bindGrd();
                    }


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdActivitiesfood_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkActivity")
                {

                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    Searchname = arg[1];
                    txtSearch.Text = Convert.ToString(arg[1]);
                    Searchname = txtSearch.Text.Replace(",", " ");
                    bindGrd();
                    BindCAt();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GrdFAvFoodLog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkADDFL")
            {
               // dvSerach.Style.Add("display", "");
                string[] arg = new string[7];
                arg = e.CommandArgument.ToString().Split(';');
                string name = arg[0];
                string size = arg[1];
                string cal = arg[2];
                string fat = arg[3];
                string chol = arg[4];
                string fiber = arg[5];
                string sugar = arg[6];

                int retval = 0;
                objUserFoodLog.UFL_ID = 0;
                objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                objUserFoodLog.Search_Name = name;
                objUserFoodLog.Product_Size = "1";
                objUserFoodLog.QUANTITY = 0;
                if (cal != "")
                {
                    objUserFoodLog.CALORIES = cal;
                }
                else
                {
                    objUserFoodLog.CALORIES = "0.0";
                }
                if (fat != "")
                {
                    objUserFoodLog.FAT = fat;
                }
                else
                {
                    objUserFoodLog.FAT = "0.0";
                }
                if (chol != "")
                {
                    objUserFoodLog.CHOLESTROL = chol;
                }
                else
                {
                    objUserFoodLog.CHOLESTROL = "0.0";
                }

                objUserFoodLog.SODIUM = "0.0";

                objUserFoodLog.CARBOHYDRATES = "0.0";

                if (fiber != "")
                {
                    objUserFoodLog.FIBER = fiber;
                }
                else
                {
                    objUserFoodLog.FIBER = "0.0";
                }

                objUserFoodLog.PROTIENS = "0.0";

                if (sugar != "")
                {
                    objUserFoodLog.SUGAR = sugar;
                }
                else
                {
                    objUserFoodLog.SUGAR = "0.0";
                }
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserFoodLog.UFL_DATE = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }

                else
                {
                    objUserFoodLog.UFL_DATE = Convert.ToDateTime(String.Format(hdnSelectedDateForMissionHistory.Value.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }

                objUserFoodLog.ProcedureType = "I";
                objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);

                int retval1 = 0;
                objUserFoodLog.ETL_ID = 0;
                objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                objUserFoodLog.UFL_ID_FK = retval;
                DataTable dt = new DataTable();
                objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                objUserFoodLog.ProcedureType = "S";
                dt = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                if (dt.Rows.Count > 0)
                {
                    objUserFoodLog.ET_ID_FK = Convert.ToInt32(dt.Rows[0]["ET_ID"]);
                }
                objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                objUserFoodLog.ProcedureType = "I";
                retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                DataTable dtEathabbit = new DataTable();
                objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserRegisterBAO.procedureType = "EH";
                dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dtEathabbit.Rows.Count > 0)
                {
                    int retupdate = 0;
                    objUserFoodLog.EH_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    DataTable dt1 = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                            objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                            {
                                objUserFoodLog.EH_BREAKFAST = "Y";
                                objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                            objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                            {
                                objUserFoodLog.EH_LUNCH = "Y";
                                objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                            objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                            {
                                objUserFoodLog.EH_DINNER = "Y";
                                objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }

                        if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                            objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                            objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "4")
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                    }
                    objUserFoodLog.ProcedureType = "U";
                    retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                }
                else
                {
                    int retvalHabbit = 0;
                    objUserFoodLog.EH_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    DataTable dt1 = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                        {
                            objUserFoodLog.EH_BREAKFAST = "Y";
                            objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                        {
                            objUserFoodLog.EH_LUNCH = "Y";
                            objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                        {
                            objUserFoodLog.EH_DINNER = "Y";
                            objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = "Y";
                            objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = "Y";
                            objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = "Y";
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                    }
                    objUserFoodLog.ProcedureType = "I";
                    retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                }

                objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                {
                    objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                }
                else
                {
                    objUserMissionBAL.MissionId = 0;
                }
                objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(cal);
                objUserMissionBAL.Pk_user_Log_Id = retval;
                objUserMissionBAL.Request_Type = 1;
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }

                else
                {
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(hdnSelectedDateForMissionHistory.Value.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }

                objUserMissionBAL.Activity_Performed = string.Empty;
                objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                objUserMissionBAL.Activity_Hours = 0;
                objUserMissionBAL.Activity_minutes = 0;
                objUserMissionBAL.Activity_Seconds = 0;
                objUserMissionBAL.Distance_Units = "0";
                objUserMissionBAL.Distance_Covered = 0;

                objUserMissionBAL.Activity_Id = 0;
                objUserMissionBAL.StepsCovered = 0;

                DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                Bind_History();
                /*
                 * The calories that were consumed either by search or input ar e inserted here to show charts.
                 * 
                 * */

                //AddDailyCaloriesInput(Convert.ToDecimal(cal), 0, retval, 1, "", 0);
                BindFoodLog();
                BindCAt();

            }

        }
        protected void GrdFAvFoodLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClsGeneric.ReplaceCookie();

            try
            {
                BindCAt();
                string lbid;
                lbid = ((Label)GrdFAvFoodLog.Rows[e.RowIndex].FindControl("lbUpc")).Text;
                if (lbid != "")
                {
                    int retval = 0;
                    objUserFoodLog.UFL_ID = lbid;
                    objUserFoodLog.ProcedureType = "DF1";
                    retval = UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLog);
                    GrdFAvFoodLog.EditIndex = -1;
                    bindGrdFAv();
                    BindFoodLog();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void GrdFoodLog_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                BindCAt();
                string lbid, drpserving, drpEating;
                string lbcal = "";
                string lbfat = "";
                string lbchol = "";
                string lbfiber = "";
                string lbSugars = "";

                string serving = "";
                lbid = ((Label)GrdFoodLog.Rows[e.RowIndex].FindControl("lbID")).Text;
                drpserving = ((DropDownList)GrdFoodLog.Rows[e.RowIndex].FindControl("drpServing")).SelectedValue;
                drpEating = ((DropDownList)GrdFoodLog.Rows[e.RowIndex].FindControl("drpEating")).SelectedValue;
                DataTable dt1 = new DataTable();
                objUserFoodLog.fk_user_registration_Id = lbid;
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserFoodLog.UFL_DATE = txtCalendarNavigation.Text;
                }

                else
                {
                    objUserFoodLog.UFL_DATE = Convert.ToString(hdnSelectedDateForMissionHistory.Value);
                }
                if (Convert.ToString(Session["selected_mission_id"]) == "" || Convert.ToString(Session["selected_mission_id"]) == null)
                {
                    objUserFoodLog.Fk_MissionId = 0;
                }
                else
                {
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                }
                objUserFoodLog.ProcedureType = "G";
                objUserFoodLog.ID = 1;
                dt1 = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
                if (dt1.Rows.Count > 0)
                {
                    serving = dt1.Rows[0]["Product_Size"].ToString();
                    lbcal = dt1.Rows[0]["Cals"].ToString();
                    lbfat = dt1.Rows[0]["fat"].ToString();
                    lbchol = dt1.Rows[0]["Chol"].ToString();
                    lbfiber = dt1.Rows[0]["Fiber"].ToString();
                    lbSugars = dt1.Rows[0]["Sugars"].ToString();
                }
                decimal cals;
                decimal fats;
                decimal choles;
                decimal fibers;
                decimal sugars;

                //if (Convert.ToDecimal(serving) < Convert.ToDecimal(drpserving))
                //{
                //     cals = (Convert.ToDecimal(drpserving) * Convert.ToDecimal(lbcal));
                //}
                //else
                //{
                cals = ((Convert.ToDecimal(lbcal) / Convert.ToDecimal(serving)) * Convert.ToDecimal(drpserving));
                //}
                string formatedCals = String.Format("{0:0.0}", cals);

                fats = ((Convert.ToDecimal(lbfat) / Convert.ToDecimal(serving)) * Convert.ToDecimal(drpserving));
                string formatedfats = String.Format("{0:0.0}", fats);

                choles = ((Convert.ToDecimal(lbchol) / Convert.ToDecimal(serving)) * Convert.ToDecimal(drpserving));
                string formatedcholes = String.Format("{0:0.0}", choles);

                fibers = ((Convert.ToDecimal(lbfiber) / Convert.ToDecimal(serving)) * Convert.ToDecimal(drpserving));
                string formatedfibers = String.Format("{0:0.0}", fibers);

                sugars = ((Convert.ToDecimal(lbSugars) / Convert.ToDecimal(serving)) * Convert.ToDecimal(drpserving));
                string formatedsugars = String.Format("{0:0.0}", sugars);

                DataTable dt = new DataTable();
                objUserRegisterBAO.ID = Convert.ToInt32(lbid);
                objUserRegisterBAO.procedureType = "FL";
                dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dt.Rows.Count > 0)
                {
                    int retval = 0;
                    objUserFoodLog.UFL_ID = lbid;
                    objUserFoodLog.fk_user_registration_Id = dt.Rows[0]["fk_user_registration_Id"].ToString();
                    objUserFoodLog.Search_Name = dt.Rows[0]["Search_Name"].ToString();
                    objUserFoodLog.Product_Size = drpserving;
                    objUserFoodLog.QUANTITY = "";
                    objUserFoodLog.CALORIES = formatedCals;
                    objUserFoodLog.FAT = formatedfats;
                    objUserFoodLog.CHOLESTROL = formatedcholes;
                    objUserFoodLog.SODIUM = dt.Rows[0]["SODIUM"].ToString();
                    objUserFoodLog.CARBOHYDRATES = dt.Rows[0]["CARBOHYDRATES"].ToString();
                    objUserFoodLog.FIBER = formatedfibers;
                    objUserFoodLog.PROTIENS = dt.Rows[0]["PROTIENS"].ToString();
                    objUserFoodLog.SUGAR = formatedsugars;
                    objUserFoodLog.UFL_DATE = dt.Rows[0]["UFL_DATE"].ToString();
                    objUserFoodLog.ProcedureType = "U";
                    retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);


                    DataTable dtEating = new DataTable();
                    objUserRegisterBAO.ID = lbid;
                    objUserRegisterBAO.procedureType = "ETL";
                    dtEating = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dtEating.Rows.Count > 0)
                    {
                        int retvaleat = 0;
                        objUserFoodLog.ETL_ID = Convert.ToInt32(dtEating.Rows[0]["ETL_ID"]);
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserFoodLog.UFL_ID_FK = lbid;
                        objUserFoodLog.ET_ID_FK = Convert.ToInt32(drpEating);
                        objUserFoodLog.ETL_DATE = dtEating.Rows[0]["ETL_DATE"].ToString();
                        objUserFoodLog.ProcedureType = "U";
                        retvaleat = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);
                    }

                    DataTable dtEatingHabbit = new DataTable();
                    objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objUserRegisterBAO.procedureType = "EH";
                    dtEatingHabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dtEatingHabbit.Rows.Count > 0)
                    {
                        int retvalEatHabit = 0;
                        objUserFoodLog.EH_ID = Convert.ToInt32(dtEatingHabbit.Rows[0]["EH_ID"].ToString());
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        if (drpEating == "1")
                        {
                            objUserFoodLog.EH_BREAKFAST = "Y";
                            objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_BREAKFAST = dtEatingHabbit.Rows[0]["EH_BREAKFAST"].ToString();
                            objUserFoodLog.EH_BREAKFAST_TIME = dtEatingHabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                        }
                        if (drpEating == "2")
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = "Y";
                            objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = dtEatingHabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                            objUserFoodLog.EH_MORNSNACKS_TIME = dtEatingHabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                        }
                        if (drpEating == "3")
                        {
                            objUserFoodLog.EH_LUNCH = "Y";
                            objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_LUNCH = dtEatingHabbit.Rows[0]["EH_LUNCH"].ToString();
                            objUserFoodLog.EH_LUNCH_TIME = dtEatingHabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                        }
                        if (drpEating == "4")
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = "Y";
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = dtEatingHabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEatingHabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                        }
                        if (drpEating == "5")
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = "Y";
                            objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = dtEatingHabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                            objUserFoodLog.EH_EVENSNACKS_TIME = dtEatingHabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                        }
                        if (drpEating == "6")
                        {
                            objUserFoodLog.EH_DINNER = "Y";
                            objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_DINNER = dtEatingHabbit.Rows[0]["EH_DINNER"].ToString();
                            objUserFoodLog.EH_DINNER_TIME = dtEatingHabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                        }
                        objUserFoodLog.ProcedureType = "U";
                        retvalEatHabit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                    }

                    objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                    {
                        objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                    }
                    else
                    {
                        objUserMissionBAL.MissionId = 0;
                    }
                    objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                    objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(formatedCals);
                    objUserMissionBAL.Pk_user_Log_Id = Convert.ToInt32(lbid);
                    objUserMissionBAL.Request_Type = 3;
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim()) + DateTime.Now.ToString(" HH:mm:ss tt")); //Convert.ToDateTime(txtCalendarNavigation.Text);

                    objUserMissionBAL.Activity_Performed = string.Empty;
                    objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                    objUserMissionBAL.Activity_Hours = 0;
                    objUserMissionBAL.Activity_minutes = 0;
                    objUserMissionBAL.Activity_Seconds = 0;
                    objUserMissionBAL.Distance_Units = "0";
                    objUserMissionBAL.Distance_Covered = 0;

                    objUserMissionBAL.Activity_Id = 0;
                    objUserMissionBAL.StepsCovered = 0;

                    DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                    //  ModifyWeight_BasedOnLogInput(0, Convert.ToDecimal(formatedCals), objUserMissionBAL.DateOfCompletion.ToString(), Convert.ToInt32(dtLog.Rows[0]["fk_mission_log_id"])); 


                }
                GrdFoodLog.EditIndex = -1;
                Bind_History();
                BindFoodLog();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFoodLog_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {

                GrdFoodLog.EditIndex = e.NewEditIndex;
                BindFoodLog();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFoodLog_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                BindCAt();
                GrdFoodLog.EditIndex = -1;
                BindFoodLog();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void drpServing_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string lbcal1 = "";
                string lbfat1 = "";
                string lbsugar1 = "";
                string lbchol1 = "";
                string serving = "";
                string lbfibers1 = "";

                BindCAt();

                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;
                Label lbID = (Label)row.Cells[0].FindControl("lbID");
                DataTable dt1 = new DataTable();
                objUserFoodLog.fk_user_registration_Id = lbID.Text;
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserFoodLog.UFL_DATE = txtCalendarNavigation.Text;
                }

                else
                {
                    objUserFoodLog.UFL_DATE = Convert.ToString(hdnSelectedDateForMissionHistory.Value);
                }
                if (Convert.ToString(Session["selected_mission_id"]) == "" || Convert.ToString(Session["selected_mission_id"]) == null)
                {
                    objUserFoodLog.Fk_MissionId = 0;
                }
                else
                {
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                }
                objUserFoodLog.ProcedureType = "G";
                objUserFoodLog.ID = 1;
                dt1 = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
                if (dt1.Rows.Count > 0)
                {
                    serving = dt1.Rows[0]["Product_Size"].ToString();
                    lbcal1 = dt1.Rows[0]["Cals"].ToString();
                    lbfat1 = dt1.Rows[0]["fat"].ToString();
                    lbsugar1 = dt1.Rows[0]["Sugars"].ToString();
                    lbchol1 = dt1.Rows[0]["Chol"].ToString();
                    lbfibers1 = dt1.Rows[0]["Fiber"].ToString();
                }
                Label lbCals = (Label)row.Cells[0].FindControl("lbcal");
                Label lbfat = (Label)row.Cells[0].FindControl("lbfat");
                Label lbchol = (Label)row.Cells[0].FindControl("lbchol");
                Label lbFiber = (Label)row.Cells[0].FindControl("lbFiber");
                Label lbSugars = (Label)row.Cells[0].FindControl("lbSugars");
                decimal cals;
                decimal fats;
                decimal chol;
                decimal fibers;
                decimal sugar;   
            
                cals = ((Convert.ToDecimal(lbcal1) / Convert.ToDecimal(serving)) * Convert.ToDecimal(ddl.SelectedValue));            
                string formatedCals = String.Format("{0:0.0}", cals);
                lbCals.Text = formatedCals;

                fats = ((Convert.ToDecimal(lbfat1) / Convert.ToDecimal(serving)) * Convert.ToDecimal(ddl.SelectedValue));
                string formatedfats = String.Format("{0:0.0}", fats);
                lbfat.Text = formatedfats;

                chol = ((Convert.ToDecimal(lbchol1) / Convert.ToDecimal(serving)) * Convert.ToDecimal(ddl.SelectedValue));
                string formatedchol = String.Format("{0:0.0}", chol);
                lbchol.Text = formatedchol;

                fibers = ((Convert.ToDecimal(lbfibers1) / Convert.ToDecimal(serving)) * Convert.ToDecimal(ddl.SelectedValue));
                string formatedfibers = String.Format("{0:0.0}", fibers);
                lbFiber.Text = formatedfibers;

                sugar = ((Convert.ToDecimal(lbsugar1) / Convert.ToDecimal(serving)) * Convert.ToDecimal(ddl.SelectedValue));
                string formatedsugar = String.Format("{0:0.0}", sugar);
                lbSugars.Text = formatedsugar;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void InsertFoodLogAutoLogin()
        {
            try
            {
                if (MySession.Current.LinkID == "1")
                {
                    DataTable dt = new DataTable();
                    objUserFoodLog.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserFoodLog.UFL_DATE = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                    objUserFoodLog.Fk_MissionId = Convert.ToInt32(MySession.Current.ETID);
                    objUserFoodLog.ProcedureType = "VF";
                    objUserFoodLog.ID = "1";
                    dt = UserFoodLogDAO.GetUserFoodLog(objUserFoodLog);
                    if (dt.Rows.Count > 0)
                    {
                        int retval = 0;
                        objUserFoodLog.UFL_ID = 0;
                        objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
                        objUserFoodLog.Search_Name = dt.Rows[0]["Search_Name"].ToString();
                        objUserFoodLog.Product_Size = "1";
                        objUserFoodLog.QUANTITY = dt.Rows[0]["QUANTITY"].ToString();
                        objUserFoodLog.CALORIES = dt.Rows[0]["CALORIES"].ToString();
                        string cals = Convert.ToString(objUserFoodLog.CALORIES);
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

                        int retval1 = 0;
                        objUserFoodLog.ETL_ID = 0;
                        objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserFoodLog.UFL_ID_FK = retval;
                        objUserFoodLog.ET_ID_FK = Convert.ToInt32(MySession.Current.ETID);
                        objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                        objUserFoodLog.ProcedureType = "I";
                        retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                        DataTable dtEathabbit = new DataTable();
                        objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.procedureType = "EH";
                        dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                        if (dtEathabbit.Rows.Count > 0)
                        {
                            int retupdate = 0;
                            objUserFoodLog.EH_ID = 0;
                            objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                            DataTable dt1 = new DataTable();
                            objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                            objUserFoodLog.ProcedureType = "S";
                            dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                            if (dt1.Rows.Count > 0)
                            {
                                if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                                    objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                                }
                                else
                                {
                                    if (Convert.ToString(MySession.Current.ETID) == "1")
                                    {
                                        objUserFoodLog.EH_BREAKFAST = "Y";
                                        objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                                    objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                                }
                                else
                                {
                                    if (Convert.ToString(MySession.Current.ETID) == "3")
                                    {
                                        objUserFoodLog.EH_LUNCH = "Y";
                                        objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                                    objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                                }
                                else
                                {
                                    if (Convert.ToString(MySession.Current.ETID) == "6")
                                    {
                                        objUserFoodLog.EH_DINNER = "Y";
                                        objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }

                                if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                                    objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                                }
                                else
                                {
                                    if (Convert.ToString(MySession.Current.ETID) == "2")
                                    {
                                        objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                        objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                                    objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                                }
                                else
                                {
                                    if (Convert.ToString(MySession.Current.ETID) == "5")
                                    {
                                        objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                        objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                                {
                                    objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                                    objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                                }
                                else
                                {
                                    if (Convert.ToString(MySession.Current.ETID) == "4")
                                    {
                                        objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                        objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                            }
                            objUserFoodLog.ProcedureType = "U";
                            retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                        }
                        else
                        {
                            int retvalHabbit = 0;
                            objUserFoodLog.EH_ID = 0;
                            objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);

                            if (Convert.ToString(MySession.Current.ETID) == "1")
                            {
                                objUserFoodLog.EH_BREAKFAST = "Y";
                                objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (Convert.ToString(MySession.Current.ETID) == "3")
                            {
                                objUserFoodLog.EH_LUNCH = "Y";
                                objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (Convert.ToString(MySession.Current.ETID) == "6")
                            {
                                objUserFoodLog.EH_DINNER = "Y";
                                objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (Convert.ToString(MySession.Current.ETID) == "2")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (Convert.ToString(MySession.Current.ETID) == "5")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }

                            objUserFoodLog.ProcedureType = "I";
                            retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                        }
                        //
                        objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                        if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                        {
                            objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                        }
                        else
                        {
                            objUserMissionBAL.MissionId = 0;
                        }
                        objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                        objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(cals);
                        objUserMissionBAL.Pk_user_Log_Id = retval;
                        objUserMissionBAL.Request_Type = 1;
                        objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(hdnSelectedDateForMissionHistory.Value.Trim(), "dd MMM yyyy hh:mm:ss tt")); //Convert.ToDateTime(System.DateTime.Today.ToString("dd MMM yyyy"));

                        objUserMissionBAL.Activity_Performed = string.Empty;
                        objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                        objUserMissionBAL.Activity_Hours = 0;
                        objUserMissionBAL.Activity_minutes = 0;
                        objUserMissionBAL.Activity_Seconds = 0;
                        objUserMissionBAL.Distance_Units = "0";
                        objUserMissionBAL.Distance_Covered = 0;

                        objUserMissionBAL.Activity_Id = 0;
                        objUserMissionBAL.StepsCovered = 0;

                        DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);


                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void ImgBtnPrev_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                PageIndex = PageIndex - 1;

                s = s - 10;
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnNext_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                PageIndex = PageIndex + 1;

                s = s + 10;
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void imgBtnPrevious_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string date1 = txtCalendarNavigation.Text;
                string date = Convert.ToDateTime(date1).AddDays(-1).ToString("dd MMM yyyy");
                txtCalendarNavigation.Text = date;
                hdnSelectedDateForMissionHistory.Value = txtCalendarNavigation.Text;
                BindCAt();
                BindFoodLog();

                bindGrdFAv();
                Bind_History();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnNextDate_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string date1 = txtCalendarNavigation.Text;
                string date = Convert.ToDateTime(date1).AddDays(+1).ToString("dd MMM yyyy");
                txtCalendarNavigation.Text = date;
                hdnSelectedDateForMissionHistory.Value = txtCalendarNavigation.Text;
                BindCAt();
                BindFoodLog();

                bindGrdFAv();
                Bind_History();
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnseachfoodlog_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                n = 10;
                s = 0;
                BindCAt();
                Searchname = hdsearhresult.Value;
                string url = "http://api.foodessentials.com/searchprods?q=" + Searchname + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&n=10&s=0&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";
                var currencyRates = _download_serialized_json_data<CurrencyRates>(url);
                if (currencyRates != null)
                {
                    n1 = Convert.ToInt32(currencyRates.numFound);
                }
                Searchname = hdsearhresult.Value;
                ImgBtnPrev.Enabled = false;
                ImgBtnPrev.Style.Add("cursor", "not-allowed");
                if (n1 > s)
                {
                    ImgBtnNext.Enabled = true;
                    ImgBtnNext.Style.Add("cursor", "pointer");
                }
                else
                {
                    ImgBtnNext.Enabled = false;
                    ImgBtnNext.Style.Add("cursor", "not-allowed");
                }
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                    string url1 = "http://api.foodessentials.com/productscore?u=" + lblUpc.Text.Trim() + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";
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
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e) 
        {
 
            
                //dvSerach.Style.Add("display", "");
              
                string name = hdproducname.Value;
                string size = hdproductsize.Value;
                string cal = hdcal.Value;
                string fat = hdfat.Value;
                string chol = hdchol.Value;
                string fiber = hdfiber.Value;
                string sugar = hdsugars.Value;

                 double serving_size;
                 double cal_new;
                 double fat_new;
                 double chol_new;
                 double fiber_new ;
                 double sugar_new;

                if (name == "" || name == ",")
                {
 //btnseachfoodlog_Click
                    hdsearhresult.Value = txtSearch.Text.Trim();
                    btnseachfoodlog_Click("", e);
                    return;
                }
            serving_size= Convert.ToDouble( ddlservingsize.SelectedItem.Text);
            if (name.Contains(","))
            {
                string name_after = name.Replace(",", "");
                objUserFoodLog.Search_Name = name_after;

            }
            else
            {
                objUserFoodLog.Search_Name = name;
            }
                if (cal.Contains(","))
                {
                string cal_after=    cal.Replace(",", "");
                    cal_new = (Convert.ToDouble(cal_after) * serving_size);
                }
            else
                {
                     cal_new = (Convert.ToDouble(cal) * serving_size);
                }
            if(fat.Contains(","))
            {
                string fat_after=fat.Replace(",","");
                fat_new = (Convert.ToDouble(fat_after) * serving_size);
            }
            else
            {
                fat_new = (Convert.ToDouble(fat) * serving_size);
            }

            if(chol.Contains(","))
            {
                string chol_after=chol.Replace(",","");
                chol_new = (Convert.ToDouble(chol_after) * serving_size);

            }
            else
            {
                chol_new = (Convert.ToDouble(chol) * serving_size);
            }
            if(fiber.Contains(","))
            {
                string fiber_after=fiber.Replace(",","");
                 fiber_new = (Convert.ToDouble(fiber_after) * serving_size);
            }
            else
            {
                fiber_new = (Convert.ToDouble(fiber) * serving_size);
            }
            if(sugar.Contains(","))
            {
                string sugar_after=sugar.Replace(",","");
                sugar_new = (Convert.ToDouble(sugar_after) * serving_size);
            
            }
            else
            {
                sugar_new = (Convert.ToDouble(sugar) * serving_size);
            }


          
              
              //fat_new = (Convert.ToDouble(fat) * serving_size);
              //chol_new = (Convert.ToDouble(chol) * serving_size);
              //fiber_new = (Convert.ToDouble(fiber) * serving_size);
              //sugar_new = (Convert.ToDouble(sugar) * serving_size);


                int retval = 0;
                objUserFoodLog.UFL_ID = 0;
                objUserFoodLog.fk_user_registration_Id = MySession.Current.LoginId;
              
                //objUserFoodLog.Product_Size = "1";
                objUserFoodLog.Product_Size = ddlservingsize.SelectedItem.Text;
                objUserFoodLog.QUANTITY = 0;
            
                if (cal != "")
                {
                    objUserFoodLog.CALORIES = cal_new;
                }
                else
                {
                    objUserFoodLog.CALORIES = "0.0";
                }
                if (fat != "")
                {
                    objUserFoodLog.FAT = fat_new;
                }
                else
                {
                    objUserFoodLog.FAT = "0.0";
                }
                if (chol != "")
                {
                    objUserFoodLog.CHOLESTROL = chol_new;
                }
                else
                {
                    objUserFoodLog.CHOLESTROL = "0.0";
                }

                objUserFoodLog.SODIUM = "0.0";

                objUserFoodLog.CARBOHYDRATES = "0.0";

                if (fiber != "")
                {
                    objUserFoodLog.FIBER = fiber_new;
                }
                else
                {
                    objUserFoodLog.FIBER = "0.0";
                }

                objUserFoodLog.PROTIENS = "0.0";

                if (sugar != "")
                {
                    objUserFoodLog.SUGAR = sugar_new;
                }
                else
                {
                    objUserFoodLog.SUGAR = "0.0";
                }
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserFoodLog.UFL_DATE = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }

                else
                {
                    objUserFoodLog.UFL_DATE = Convert.ToDateTime(String.Format(hdnSelectedDateForMissionHistory.Value.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }
          

                objUserFoodLog.ProcedureType = "I";
                objUserFoodLog.Fk_MissionId = Convert.ToInt32(Session["selected_mission_id"]);
                retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLog);

                int retval1 = 0;
                objUserFoodLog.ETL_ID = 0;
                objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                objUserFoodLog.UFL_ID_FK = retval;
                DataTable dt = new DataTable();
                objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                objUserFoodLog.ProcedureType = "S";
                dt = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                if (dt.Rows.Count > 0)
                {
                    objUserFoodLog.ET_ID_FK = Convert.ToInt32(dt.Rows[0]["ET_ID"]);
                }
                objUserFoodLog.ETL_DATE = DateTime.Now.ToString();
                objUserFoodLog.ProcedureType = "I";
                retval1 = UserFoodLogDAO.InsertEatingTimeLog(objUserFoodLog);

                DataTable dtEathabbit = new DataTable();
                objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserRegisterBAO.procedureType = "EH";
                dtEathabbit = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dtEathabbit.Rows.Count > 0)
                {
                    int retupdate = 0;
                    objUserFoodLog.EH_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    DataTable dt1 = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_BREAKFAST = dtEathabbit.Rows[0]["EH_BREAKFAST"].ToString();
                            objUserFoodLog.EH_BREAKFAST_TIME = dtEathabbit.Rows[0]["EH_BREAKFAST_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                            {
                                objUserFoodLog.EH_BREAKFAST = "Y";
                                objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_LUNCH"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_LUNCH = dtEathabbit.Rows[0]["EH_LUNCH"].ToString();
                            objUserFoodLog.EH_LUNCH_TIME = dtEathabbit.Rows[0]["EH_LUNCH_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                            {
                                objUserFoodLog.EH_LUNCH = "Y";
                                objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_DINNER"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_DINNER = dtEathabbit.Rows[0]["EH_DINNER"].ToString();
                            objUserFoodLog.EH_DINNER_TIME = dtEathabbit.Rows[0]["EH_DINNER_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                            {
                                objUserFoodLog.EH_DINNER = "Y";
                                objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }

                        if (dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = dtEathabbit.Rows[0]["EH_MORNINGSNACKS"].ToString();
                            objUserFoodLog.EH_MORNSNACKS_TIME = dtEathabbit.Rows[0]["EH_MORNSNACKS_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                            {
                                objUserFoodLog.EH_MORNINGSNACKS = "Y";
                                objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = dtEathabbit.Rows[0]["EH_EVENINGSNACKS"].ToString();
                            objUserFoodLog.EH_EVENSNACKS_TIME = dtEathabbit.Rows[0]["EH_EVENSNACKS_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                            {
                                objUserFoodLog.EH_EVENINGSNACKS = "Y";
                                objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                        if (dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString() == "Y")
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = dtEathabbit.Rows[0]["EH_UNCLASSIFIED"].ToString();
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = dtEathabbit.Rows[0]["EH_UNCLASSIFIED_TIME"].ToString();
                        }
                        else
                        {
                            if (dt1.Rows[0]["ET_ID"].ToString() == "4")
                            {
                                objUserFoodLog.EH_UNCLASSIFIED = "Y";
                                objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                    }
                    objUserFoodLog.ProcedureType = "U";
                    retupdate = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                }
                else
                {
                    int retvalHabbit = 0;
                    objUserFoodLog.EH_ID = 0;
                    objUserFoodLog.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    DataTable dt1 = new DataTable();
                    objUserFoodLog.presenttime = DateTime.Now.ToString("HH:mm:ss");
                    objUserFoodLog.ProcedureType = "S";
                    dt1 = UserFoodLogDAO.GetEatingTimeID(objUserFoodLog);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0]["ET_ID"].ToString() == "1")
                        {
                            objUserFoodLog.EH_BREAKFAST = "Y";
                            objUserFoodLog.EH_BREAKFAST_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "3")
                        {
                            objUserFoodLog.EH_LUNCH = "Y";
                            objUserFoodLog.EH_LUNCH_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "6")
                        {
                            objUserFoodLog.EH_DINNER = "Y";
                            objUserFoodLog.EH_DINNER_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "2")
                        {
                            objUserFoodLog.EH_MORNINGSNACKS = "Y";
                            objUserFoodLog.EH_MORNSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else if (dt1.Rows[0]["ET_ID"].ToString() == "5")
                        {
                            objUserFoodLog.EH_EVENINGSNACKS = "Y";
                            objUserFoodLog.EH_EVENSNACKS_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                        {
                            objUserFoodLog.EH_UNCLASSIFIED = "Y";
                            objUserFoodLog.EH_UNCLASSIFIED_TIME = DateTime.Now.ToString("HH:mm:ss");
                        }
                    }
                    objUserFoodLog.ProcedureType = "I";
                    retvalHabbit = UserFoodLogDAO.InserttblUserEatingHabbit(objUserFoodLog);
                }

                objUserMissionBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                if (!String.IsNullOrEmpty(Convert.ToString(Session["mission_has_been_selected"])))
                {
                    objUserMissionBAL.MissionId = Convert.ToInt32(Session["selected_mission_id"].ToString());
                }
                else
                {
                    objUserMissionBAL.MissionId = 0;
                }
                objUserMissionBAL.CaloriesBurnt = Convert.ToInt32(0);
                if (cal.Contains(","))
                {
                    string calconsumed = cal.Replace(",", "");

                    objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(cal_new);
                }
                else
                {
                    objUserMissionBAL.CaloriesEaten = Convert.ToDecimal(cal_new);
                }
             
                objUserMissionBAL.Pk_user_Log_Id = retval;
                objUserMissionBAL.Request_Type = 1;
                if (hdnSelectedDateForMissionHistory.Value == "")
                {
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(txtCalendarNavigation.Text.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }

                else
                {
                    objUserMissionBAL.DateOfCompletion = Convert.ToDateTime(String.Format(hdnSelectedDateForMissionHistory.Value.Trim(), "dd MMM yyyy hh:mm:ss tt"));
                }

                objUserMissionBAL.Activity_Performed = string.Empty;
                objUserMissionBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);
                objUserMissionBAL.Activity_Hours = 0;
                objUserMissionBAL.Activity_minutes = 0;
                objUserMissionBAL.Activity_Seconds = 0;
                objUserMissionBAL.Distance_Units = "0";
                objUserMissionBAL.Distance_Covered = 0;

                objUserMissionBAL.Activity_Id = 0;
                objUserMissionBAL.StepsCovered = 0;

                DataTable dtLog = UserMissionsDAL.SubmitMissionInput(objUserMissionBAL);
                Bind_History();
                /*
                 * The calories that were consumed either by search or input ar e inserted here to show charts.
                 * 
                 * */

                //AddDailyCaloriesInput(Convert.ToDecimal(cal), 0, retval, 1, "", 0);
                BindFoodLog();
                txtSearch.Text = "";
                ddlservingsize.SelectedIndex = 1;

            
        }

        protected void imgclosesearch_Click(object sender, ImageClickEventArgs e)
        {
            dvSerach.Style.Add("display", "none");
            BindFoodLog();
            bindGrdFAv();
            BindCAt();
            BindQuickLog_ActivitiesAndCalories();
            txtSearch.Text = "";
        }
    }
}
