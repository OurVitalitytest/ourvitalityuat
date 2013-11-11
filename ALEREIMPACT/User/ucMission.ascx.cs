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
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
namespace ALEREIMPACT.User
{
    public partial class ucMission : System.Web.UI.UserControl
    {
        protected static string _check_for_stepTwo = null;
        UserCirclesBAO objusercircles = new UserCirclesBAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                }
                if (!Page.IsPostBack)
                {
                    pnlFeatures.Style.Value = "display:none;";
                    txtMissionName.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    txtWeightToLose.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

                    if (MySession.Current.LoginId != null)
                    {
                        BindYearDay();
                        BindMissionTypesAndThemeswithFeatures();
                        if (pnlFeatures.Visible == true)
                        {
                            btnCalculate.Style.Value = "display:none;";
                        }
                        txtWeightToLose.Enabled = true;
                        drpWeightToLooseOptions.Enabled = true;
                        drpSelectMissionTheme.Enabled = true;
                        drpPeriodicTime.Enabled = true;

                        btnAcceptedByUser.Enabled = false;
                        btnRejectedByUser.Enabled = false;
                        pnlMissionCompletionMessage.Style.Value = "display:none;";
                        pnlCaloriesNotFeasible.Style.Value = "display:none;";

                        if (drpSelectMissionType.SelectedIndex == 0)
                            txtWeightToLose.MaxLength = 2;
                        else if (drpSelectMissionType.SelectedIndex == 1)
                            txtWeightToLose.MaxLength = 6;

                    }
                }

                calMissionCompletion.StartDate = DateTime.Today.AddDays(1);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BindYearDay()
        {
            try
            {
                int currentyear = DateTime.Now.Year;
                drpYear.Items.Insert(0, new ListItem("- Select -"));

                for (int year = currentyear; year >= 1900; year--)
                {
                    drpYear.Items.Add(year.ToString());
                }

                //drpUserHeightOptions.Items.Insert(0, new ListItem("- Select -", "0"));
                //drpUserHeightOptions.Items.Insert(1, new ListItem("- feet -", "1"));
                //drpUserHeightOptions.Items.Insert(2, new ListItem("- cms -", "2"));

                drpUserWeightOptions.Items.Insert(0, new ListItem("- Select -"));
                drpUserWeightOptions.Items.Insert(1, new ListItem("- Kilograms (kgs) -", "1"));
                drpUserWeightOptions.Items.Insert(2, new ListItem("- Pounds (lbs) -", "2"));


                drpGender.Items.Insert(0, new ListItem("- Select -", "0"));
                drpGender.Items.Insert(1, new ListItem("- Male -", "1"));
                drpGender.Items.Insert(2, new ListItem("- Female -", "2"));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BindMissionTypesAndThemeswithFeatures()
        {
            try
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
                        Session["name_of_login_user"] = dsThemes.Tables[2].Rows[0]["NameOfLoginUser"];
                    }
                    else
                    {
                        hdnProfileValue.Value = "features";
                    }
                }
                drpSelectMissionType.DataSource = dsThemes.Tables[0];
                drpSelectMissionType.DataTextField = "MissionTheme";
                drpSelectMissionType.DataValueField = "MissionThemeId";
                drpSelectMissionType.DataBind();

                drpSelectMissionTheme.DataSource = dsThemes.Tables[1];
                drpSelectMissionTheme.DataTextField = "MissionType";
                drpSelectMissionTheme.DataValueField = "MissionTypeId";
                drpSelectMissionTheme.DataBind();

                if (dsThemes.Tables[2] != null)
                {
                    if (dsThemes.Tables[2].Rows.Count > 0)
                    {
                        if (Convert.ToDouble(dsThemes.Tables[2].Rows[0]["HeightEntered"]) != 0.00
                            && Convert.ToInt32(dsThemes.Tables[2].Rows[0]["WeightEntered"]) != 0
                            && Convert.ToInt32(dsThemes.Tables[2].Rows[0]["YearEntered"]) != 0
                            && Convert.ToInt32(dsThemes.Tables[2].Rows[0]["HeightEnteredUnits"]) != 0
                            && Convert.ToInt32(dsThemes.Tables[2].Rows[0]["WeightEnteredUnits"]) != 0
                            && Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"]) == "1" || Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"]) == "2"
                            )
                        {
                            hdnProfileValue.Value = "theme";
                            btnShowStepThree.Style.Value = "display:none;";
                            pnlFeatures.Style.Value = "display:none;";
                        }
                        else
                        {
                            hdnProfileValue.Value = "features";

                            if (Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEntered"]) != "0.00")
                            {
                                txtHeight.Text = Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEntered"]);
                                txtHeight.Enabled = false;
                            }
                            else
                            {
                                txtHeight.Enabled = true;
                            }
                            if (Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEntered"]) != "0")
                            {
                                txtWeight.Text = Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEntered"]);
                                txtWeight.Enabled = false;
                            }
                            else
                            {
                                txtWeight.Enabled = true;
                            }

                            drpYear.Enabled = true;
                            if (Convert.ToString(dsThemes.Tables[2].Rows[0]["YearEntered"]) != "0")
                            {
                                drpYear.SelectedIndex = drpYear.Items.IndexOf(drpYear.Items.FindByText(Convert.ToString(dsThemes.Tables[2].Rows[0]["YearEntered"])));
                                drpYear.Enabled = false;
                            }
                            else
                            {
                                drpYear.SelectedIndex = 0;
                            }

                            if (Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEnteredUnits"]) != "0")
                            {
                                drpUserHeightOptions.SelectedIndex = drpUserHeightOptions.Items.IndexOf(drpUserHeightOptions.Items.FindByValue(Convert.ToString(dsThemes.Tables[2].Rows[0]["HeightEnteredUnits"])));
                                drpUserHeightOptions.Enabled = false;
                            }
                            else
                            {
                                drpUserHeightOptions.Enabled = true;
                            }


                            if (Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEnteredUnits"]) != "0")
                            {
                                drpUserWeightOptions.SelectedIndex = drpUserWeightOptions.Items.IndexOf(drpUserWeightOptions.Items.FindByValue(Convert.ToString(dsThemes.Tables[2].Rows[0]["WeightEnteredUnits"])));
                                drpUserWeightOptions.Enabled = false;

                            }
                            else
                            {
                                drpUserWeightOptions.Enabled = true;
                            }
                            if (Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"]) != "1" && Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"]) != "2")
                            {
                                drpGender.Enabled = true;

                            }
                            else
                            {
                                drpGender.SelectedIndex = drpGender.Items.IndexOf(drpGender.Items.FindByValue(Convert.ToString(dsThemes.Tables[2].Rows[0]["Gender"])));
                                drpGender.Enabled = false;
                            }
                        }
                    }
                }
                tr_steptwo.Style.Value = "display:none;";
                tblStepTwo.Style.Value = "display:none;";
                pnlErrorMsg.Style.Value = "display:none;";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        /// <summary>
        /// Purpse: the following event is fired when user selects any othe proposed dates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFin2_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            RegisterUserBAO ObjRegisterUserBAO = null;
            UserMissionsBAL ObjUserMissionsBAL = null;

            try
            {
                ObjRegisterUserBAO = new RegisterUserBAO();
                ObjUserMissionsBAL = new UserMissionsBAL();

                //if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                //{
                    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.LoginId);

                //}
                //else
                //{
                //    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                //}

                ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeightToLose.Text.Trim());
                ObjRegisterUserBAO.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                ObjRegisterUserBAO.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);

                if (!String.IsNullOrEmpty(Convert.ToString(hdnProposedDate.Value)))
                {
                    TimeSpan daysLeft = Convert.ToDateTime(System.DateTime.Now.ToString("d")) - Convert.ToDateTime(hdnProposedDate.Value);
                    ObjRegisterUserBAO.Days_Suggested_By_User = Convert.ToInt32(daysLeft.Days.ToString().Replace("-", ""));
                }
                else
                {
                    ObjRegisterUserBAO.Days_Suggested_By_User = 0;
                }

                //////// For Weight Lose ... the calories are required
                if (drpSelectMissionType.SelectedIndex == 0)
                {
                    DataSet ds = RegisterUserDAO.CalculateBMR(ObjRegisterUserBAO);

                    pnlCaloriesNotFeasible.Style.Value = "display:none;";
                    pnlMissionCompletionMessage.Style.Value = "display:block;";

                    decimal CaloriesEaten = 0;
                    decimal CaloriesBurnt = 0;
                    int daysLeft = 0;

                    if (radLessAggresive.Checked)
                    {
                        ObjUserMissionsBAL.CaloriesEaten = Convert.ToDecimal(lblLessAggressiveCalConsume.Text);

                        TimeSpan timeDiffFordaysLeft = Convert.ToDateTime(System.DateTime.Now.ToString("d")) - Convert.ToDateTime(lblLessAggressiveDateRecommended.Text);
                        daysLeft = Convert.ToInt32(timeDiffFordaysLeft.Days.ToString().Replace("-", ""));
                    }
                    else if (radAverage.Checked)
                    {
                        ObjUserMissionsBAL.CaloriesEaten = Convert.ToDecimal(lblAverageCalConsume.Text);

                        TimeSpan timeDiffFordaysLeft = Convert.ToDateTime(System.DateTime.Now.ToString("d")) - Convert.ToDateTime(lblAverageDateRecommended.Text);
                        daysLeft = Convert.ToInt32(timeDiffFordaysLeft.Days.ToString().Replace("-", ""));

                    }
                    else if (radMoreAggressive.Checked)
                    {
                        ObjUserMissionsBAL.CaloriesEaten = Convert.ToDecimal(lblMoreAggressiveCalCosnume.Text);

                        TimeSpan timeDiffFordaysLeft = Convert.ToDateTime(System.DateTime.Now.ToString("d")) - Convert.ToDateTime(lblMoreAggressiveDateRecommended.Text);
                        daysLeft = Convert.ToInt32(timeDiffFordaysLeft.Days.ToString().Replace("-", ""));
                    }

                    string newDeadline = System.DateTime.Now.AddDays(daysLeft).ToString("d");

                    CaloriesEaten = ObjUserMissionsBAL.CaloriesEaten;
                    CaloriesBurnt = ObjUserMissionsBAL.CaloriesBurnt;

                    ObjUserMissionsBAL.LoginId = ObjRegisterUserBAO.LoginId;
                    ObjUserMissionsBAL.WeightEntered = Convert.ToInt32(txtWeightToLose.Text.Trim());
                    ObjUserMissionsBAL.MissionName = txtMissionName.Text.Trim();
                    ObjUserMissionsBAL.MissionTypeId = Convert.ToInt32(drpSelectMissionType.SelectedValue);
                    ObjUserMissionsBAL.MissionThemeId = Convert.ToInt32(drpSelectMissionTheme.SelectedValue);
                    ObjUserMissionsBAL.CreatedByName = Session["name_of_login_user"].ToString();

                    ObjUserMissionsBAL.DateOfCompletion = Convert.ToDateTime(newDeadline);
                    ObjUserMissionsBAL.TotalCaloriesToBurn = Convert.ToDecimal(ds.Tables[0].Rows[0]["CaloriesToLoose"]);
                    ObjUserMissionsBAL.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);
                    ObjUserMissionsBAL.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);


                    if (radPeriodicOptions.SelectedItem.Value == "1")
                    {
                        ObjUserMissionsBAL.Periodic_Selection = 1;
                    }
                    else
                    {
                        ObjUserMissionsBAL.Periodic_Selection = 2;
                    }

                    ObjUserMissionsBAL.Public_Private = Convert.ToInt32(drpPublicPrivate.SelectedItem.Value);
                    ObjUserMissionsBAL.Group_Individual = Convert.ToInt32(drpGroupIndividual.SelectedItem.Value);
                    ObjUserMissionsBAL.fk_User_Circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                    RegisterUserDAO.CreateMission(ObjUserMissionsBAL);

                    string activitySelectedByUser = string.Empty;
                    if (drpPreferenceOptions.SelectedValue == "1")
                        activitySelectedByUser = " with a preference to Diet";
                    else if (drpPreferenceOptions.SelectedValue == "2")
                        activitySelectedByUser = " with an increase in your activity level";
                    else if (drpPreferenceOptions.SelectedValue == "3")
                        activitySelectedByUser = " with a preference to Diet and increase in your activity level";

                    if (!String.IsNullOrEmpty(Convert.ToString(hdnProposedDate.Value)))
                    {
                        spFinalMessage.InnerText = "In order to Lose " + ObjRegisterUserBAO.Weight + (ObjUserMissionsBAL.WeightUnits == 1 ? " kilogram(s) by " : " pound(s) by ") + Convert.ToDateTime(newDeadline).ToString("MMMM dd, yyyy") + activitySelectedByUser + ".\r\n\tDaily you need to consume " + CaloriesEaten + " calories. ";
                    }
                    else
                    {
                        spFinalMessage.InnerText = "In order to Lose " + ObjRegisterUserBAO.Weight + (ObjUserMissionsBAL.WeightUnits == 1 ? " kilogram(s) by " : " pound(s) by ") + Convert.ToDateTime(newDeadline).ToString("MMMM dd, yyyy") + activitySelectedByUser + " .\r\n\tDaily you need to consume " + CaloriesEaten + " calories. ";
                    }
                    int Missionid = 0;
                    AdminBAO objAdminBAO = new AdminBAO();
                    DataTable dt = new DataTable();
                    ObjRegisterUserBAO.ID = MySession.Current.LoginId;
                    ObjRegisterUserBAO.procedureType = "GM";
                    dt = RegisterUserDAO.GetInvitationDetail(ObjRegisterUserBAO);
                    if (dt.Rows.Count > 0)
                    {
                        Missionid = Convert.ToInt32(dt.Rows[0]["Pk_mission_id"]);
                    }
                    if (MySession.Current.SelectedCircleUserId == MySession.Current.LoginId)
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
                                int retval = 0;
                                ObjUserMissionsBAL.MN_ID = 0;
                                ObjUserMissionsBAL.fk_mission_id = Missionid;
                                ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                ObjUserMissionsBAL.ProcedureType = "I";
                                retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                if (retval != 0)
                                {
                                    string name = "";
                                    string email = "";
                                    string name1 = "";
                                    string Circlename = "";
                                    DataTable dtUser = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                    objAdminBAO.ProcedureType = "CU";
                                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                    if (dtUser.Rows.Count > 0)
                                    {
                                        Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                    }
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
                                    string Subject = name1 + "Create a Mission  in " + Circlename;
                                    string body = "Hi " + name + ",<br /><br />" + name1 + " has been create a new mission in  Circle : '" + Circlename + "'" + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                    ClsGeneric objClsGeneric = new ClsGeneric();
                                    objClsGeneric.SendMail(email, body, Subject);
                                }
                            }
                        }
                    }
                    else
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                        objusercircles.fk_circle_id = MySession.Current.CircleId;
                        objusercircles.proceduretype = "S";
                        DataTable dtFriends = new DataTable();
                        dtFriends = UserCirclesDAO.GetFriendList(objusercircles);
                        if (dtFriends.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtFriends.Rows.Count; i++)
                            {
                                int retval = 0;
                                ObjUserMissionsBAL.MN_ID = 0;
                                ObjUserMissionsBAL.fk_mission_id = Missionid;
                                ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                ObjUserMissionsBAL.ProcedureType = "I";
                                retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                if (retval != 0)
                                {
                                    string name = "";
                                    string email = "";
                                    string name1 = "";
                                    string Circlename = "";
                                    DataTable dtUser = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                    objAdminBAO.ProcedureType = "CU";
                                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                    if (dtUser.Rows.Count > 0)
                                    {
                                        Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                    }
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
                                    string Subject = name1 + "Create a Mission  in " + Circlename;
                                    string body = "Hi " + name + ",<br /><br />" + name1 + " has been create a new mission in  Circle : '" + Circlename + "'" + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                    ClsGeneric objClsGeneric = new ClsGeneric();
                                    objClsGeneric.SendMail(email, body, Subject);
                                }
                            }
                        }
                    }
                    txtMissionName.Text = "";
                    txtWeightToLose.Text = "";
                    txtMissionName.Enabled = false;
                    txtWeightToLose.Enabled = false;
                    btnAcceptedByUser.Enabled = false;
                    btnRejectedByUser.Enabled = false;
                    drpPreferenceOptions.SelectedValue = "0";
                    btnCalculate.Enabled = false;
                    pnlCaloriesNotFeasible.Style.Value = "display:none;";
                    pnlMissionCompletionMessage.Style.Value = "display:block;";
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
            finally
            {
                ObjRegisterUserBAO = null;
                ObjUserMissionsBAL = null;
            }
        }
        /// <summary>
        /// Purpose: the following event is fired when user is confident with the system generated date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAcceptedByUser_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                System.Threading.Thread.Sleep(1000);
                UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();
                //if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                //{
                    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                //}
                //else
                //{
                //    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                //}
                ObjUserMissionsBAL.WeightEntered = Convert.ToInt32(txtWeightToLose.Text.Trim());
                ObjUserMissionsBAL.MissionName = txtMissionName.Text.Trim();
                ObjUserMissionsBAL.MissionTypeId = Convert.ToInt32(drpSelectMissionType.SelectedValue);
                ObjUserMissionsBAL.MissionThemeId = Convert.ToInt32(drpSelectMissionTheme.SelectedValue);
                ObjUserMissionsBAL.CreatedByName = Session["name_of_login_user"].ToString();

                if (!String.IsNullOrEmpty(Convert.ToString(hdnProposedDate.Value)))
                {
                    ObjUserMissionsBAL.DateOfCompletion = Convert.ToDateTime(hdnProposedDate.Value);
                }
                else
                {
                    ObjUserMissionsBAL.DateOfCompletion = Convert.ToDateTime(spEstimatedDate.InnerText);
                }

                RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();

                //if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                //{
                    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                //}
                //else
                //{
                //    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                //}

                ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeightToLose.Text.Trim());
                ObjRegisterUserBAO.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                ObjRegisterUserBAO.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);

                if (!String.IsNullOrEmpty(Convert.ToString(hdnProposedDate.Value)))
                {
                    TimeSpan daysLeft = Convert.ToDateTime(System.DateTime.Now.ToString("d")) - Convert.ToDateTime(hdnProposedDate.Value);
                    ObjRegisterUserBAO.Days_Suggested_By_User = Convert.ToInt32(daysLeft.Days.ToString().Replace("-", ""));
                }
                else
                {
                    ObjRegisterUserBAO.Days_Suggested_By_User = 0;
                }

                //////// For Weight Lose ... the calories are required
                if (drpSelectMissionType.SelectedIndex == 0)
                {
                    DataSet ds = RegisterUserDAO.CalculateBMR(ObjRegisterUserBAO);

                    ////////////// If user has selected any of the proposed date and details

                    if (Convert.ToDecimal(ds.Tables[0].Rows[0]["DaysTargetedForNormalCase"]) == 0)
                    {
                        pnlCaloriesNotFeasible.Style.Value = "display:block;";
                        pnlMissionCompletionMessage.Style.Value = "display:none;";


                        lblLessAggressiveCalConsume.Text = ds.Tables[0].Rows[0]["CaloriesToConsumeForLightActive"].ToString();
                        lblLessAggressiveDateRecommended.Text = System.DateTime.Now.AddDays(Convert.ToDouble(ds.Tables[0].Rows[0]["DaysTargetedForLightActive"].ToString())).ToString("MMMM dd, yyyy");


                        lblAverageCalConsume.Text = ds.Tables[0].Rows[0]["CaloriesToConsumeForModerately"].ToString();
                        lblAverageDateRecommended.Text = System.DateTime.Now.AddDays(Convert.ToDouble(ds.Tables[0].Rows[0]["DaysTargetedForModerately"].ToString())).ToString("MMMM dd, yyyy");


                        lblMoreAggressiveCalCosnume.Text = ds.Tables[0].Rows[0]["CaloriesToConsumeForVeryActive"].ToString();
                        lblMoreAggressiveDateRecommended.Text = System.DateTime.Now.AddDays(Convert.ToDouble(ds.Tables[0].Rows[0]["DaysTargetedForVeryActive"].ToString())).ToString("MMMM dd, yyyy");

                        btnFin2.Style.Value = "display:block;";
                    }
                    else
                    {
                        pnlCaloriesNotFeasible.Style.Value = "display:none;";
                        pnlMissionCompletionMessage.Style.Value = "display:block;";

                        ObjUserMissionsBAL.CaloriesEaten = Convert.ToDecimal(ds.Tables[0].Rows[0]["CaloriesToConsumeNormalCase"]);


                        int daysLeft = Convert.ToInt32(ds.Tables[0].Rows[0]["DaysTargetedForNormalCase"]);

                        ObjUserMissionsBAL.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);
                        ObjUserMissionsBAL.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                        ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);


                        if (radPeriodicOptions.SelectedItem.Value == "1")
                        {
                            ObjUserMissionsBAL.Periodic_Selection = 1;
                        }
                        else
                        {
                            ObjUserMissionsBAL.Periodic_Selection = 2;
                        }

                        ObjUserMissionsBAL.Public_Private = Convert.ToInt32(drpPublicPrivate.SelectedItem.Value);
                        ObjUserMissionsBAL.Group_Individual = Convert.ToInt32(drpGroupIndividual.SelectedItem.Value);
                        ObjUserMissionsBAL.fk_User_Circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                        RegisterUserDAO.CreateMission(ObjUserMissionsBAL);

                        string activitySelectedByUser = string.Empty;
                        if (drpPreferenceOptions.SelectedValue == "1")
                            activitySelectedByUser = " with a preference to Diet";
                        else if (drpPreferenceOptions.SelectedValue == "2")
                            activitySelectedByUser = " with an increase in your activity level";
                        else if (drpPreferenceOptions.SelectedValue == "3")
                            activitySelectedByUser = " with a preference to Diet and increase in your activity level";

                        if (!String.IsNullOrEmpty(Convert.ToString(hdnProposedDate.Value)))
                        {
                            spFinalMessage.InnerText = "In order to Lose " + ObjUserMissionsBAL.WeightEntered + (ObjUserMissionsBAL.WeightUnits == 1 ? " kilogram(s) by " : " pound(s) by ") + "\r\n\t" + Convert.ToDateTime(hdnProposedDate.Value).ToString("MMMM dd, yyyy") + activitySelectedByUser + " .\r\n\tDaily you need to consume " + ds.Tables[0].Rows[0]["CaloriesToConsumeNormalCase"] + " calories. ";
                        }
                        else
                        {
                            spFinalMessage.InnerText = "In order to Lose " + ObjUserMissionsBAL.WeightEntered + (ObjUserMissionsBAL.WeightUnits == 1 ? " kilogram(s) by " : " pound(s) by ") + "\r\n\t" + Convert.ToDateTime(spEstimatedDate.InnerText).ToString("MMMM dd, yyyy") + activitySelectedByUser + " .\r\n\tDaily you need to consume " + ds.Tables[0].Rows[0]["CaloriesToConsumeNormalCase"] + " calories. ";
                        }
                        int Missionid = 0;
                        int Groupindividual = 0;
                        int privatepublic = 0;
                        AdminBAO objAdminBAO = new AdminBAO();
                        DataTable dt = new DataTable();
                        ObjRegisterUserBAO.ID = MySession.Current.LoginId;
                        ObjRegisterUserBAO.procedureType = "GM";
                        dt = RegisterUserDAO.GetInvitationDetail(ObjRegisterUserBAO);
                        if (dt.Rows.Count > 0)
                        {
                            Missionid = Convert.ToInt32(dt.Rows[0]["Pk_mission_id"]);
                            Groupindividual = Convert.ToInt32(dt.Rows[0]["group_individual"]);
                            privatepublic = Convert.ToInt32(dt.Rows[0]["public_private"]);

                        }
                        if (Groupindividual == 2 && privatepublic == 2 || Groupindividual == 1 && privatepublic == 2)
                        {
                        }
                        else
                        {
                            if (MySession.Current.SelectedCircleUserId == MySession.Current.LoginId)
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
                                            int retval = 0;
                                            ObjUserMissionsBAL.MN_ID = 0;
                                            ObjUserMissionsBAL.fk_mission_id = Missionid;
                                            ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                            ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                            ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                            ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                            ObjUserMissionsBAL.ProcedureType = "I";
                                            retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                            if (retval != 0)
                                            {
                                                string name = "";
                                                string email = "";
                                                string name1 = "";
                                                string Circlename = "";
                                                DataTable dtUser = new DataTable();
                                                objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                                objAdminBAO.ProcedureType = "CU";
                                                dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                                if (dtUser.Rows.Count > 0)
                                                {
                                                    Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                                }
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
                                                string Subject = name1 + " Create a Mission  in " + Circlename;
                                                string body = "Hi " + name + ",<br /><br />" + name1 + " has created a new mission in  Circle : " + " ' " + Circlename + " ' " + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                                ClsGeneric objClsGeneric = new ClsGeneric();
                                                objClsGeneric.SendMail(email, body, Subject);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                                objusercircles.fk_circle_id = MySession.Current.CircleId;
                                objusercircles.proceduretype = "S";
                                DataTable dtFriends = new DataTable();
                                dtFriends = UserCirclesDAO.GetFriendList(objusercircles);
                                if (dtFriends.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtFriends.Rows.Count; i++)
                                    {
                                        int retval = 0;
                                        ObjUserMissionsBAL.MN_ID = 0;
                                        ObjUserMissionsBAL.fk_mission_id = Missionid;
                                        ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                        ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                        ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                        ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                        ObjUserMissionsBAL.ProcedureType = "I";
                                        retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                        if (retval != 0)
                                        {
                                            string name = "";
                                            string email = "";
                                            string name1 = "";
                                            string Circlename = "";
                                            DataTable dtUser = new DataTable();
                                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                            objAdminBAO.ProcedureType = "CU";
                                            dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                            if (dtUser.Rows.Count > 0)
                                            {
                                                Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                            }
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
                                            string Subject = name1 + " Create a Mission  in " + Circlename;
                                            string body = "Hi " + name + ",<br /><br />" + name1 + " has created a new mission in  Circle : "+" '" + Circlename +"' "+ "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                            ClsGeneric objClsGeneric = new ClsGeneric();
                                            objClsGeneric.SendMail(email, body, Subject);
                                        }
                                    }
                                }
                            }
                        }

                        txtMissionName.Text = "";
                        txtWeightToLose.Text = "";
                        txtMissionName.Enabled = false;
                        txtWeightToLose.Enabled = false;
                        btnAcceptedByUser.Enabled = false;
                        btnRejectedByUser.Enabled = false;
                        drpPreferenceOptions.SelectedValue = "0";
                        btnCalculate.Enabled = false;
                        pnlCaloriesNotFeasible.Style.Value = "display:none;";
                        pnlMissionCompletionMessage.Style.Value = "display:block;";
                    }
                }
                else
                {
                    ///////////// for steps needed to cover 

                    ObjUserMissionsBAL.CaloriesEaten = 0;
                    int daysLeft = 0;

                    if (String.IsNullOrEmpty(Convert.ToString(hdnProposedDate.Value)))
                    {
                        if (Convert.ToInt32(txtWeightToLose.Text) >= 10000)
                        {
                            if (drpSelectMissionTheme.SelectedValue == "2")
                            {
                                if (radPeriodicOptions.SelectedItem.Value == "1")
                                {
                                    daysLeft = Convert.ToInt32(7 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim()));
                                }
                                else if (radPeriodicOptions.SelectedItem.Value == "2")
                                {
                                    daysLeft = Convert.ToInt32(30 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim()));
                                }
                            }
                            else
                            {
                                daysLeft = Convert.ToInt32(Convert.ToDecimal(txtWeightToLose.Text) / 10000);
                            }

                            spEstimatedDate.InnerText = System.DateTime.Now.AddDays(daysLeft).ToString("d");
                        }
                        else
                        {
                            spEstimatedDate.InnerText = System.DateTime.Now.AddDays(1).ToString("d");
                            daysLeft = 1;
                        }
                        ObjRegisterUserBAO.Days_Suggested_By_User = daysLeft;
                    }
                    else
                    {
                        TimeSpan dfayeLeft = Convert.ToDateTime(System.DateTime.Now.ToString("d")) - Convert.ToDateTime(hdnProposedDate.Value);
                        ObjRegisterUserBAO.Days_Suggested_By_User = Convert.ToInt32(dfayeLeft.Days.ToString().Replace("-", ""));
                    }

                    ObjUserMissionsBAL.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);
                    ObjUserMissionsBAL.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);

                    Int32 stpesToCoverDaily = Convert.ToInt32(txtWeightToLose.Text) / Convert.ToInt32(ObjRegisterUserBAO.Days_Suggested_By_User);
                    ObjUserMissionsBAL.CaloriesBurnt = stpesToCoverDaily;
                    ObjUserMissionsBAL.TotalCaloriesToBurn = Convert.ToInt32(txtWeightToLose.Text);

                    ObjUserMissionsBAL.Public_Private = Convert.ToInt32(drpPublicPrivate.SelectedItem.Value);
                    ObjUserMissionsBAL.Group_Individual = Convert.ToInt32(drpGroupIndividual.SelectedItem.Value);
                    ObjUserMissionsBAL.fk_User_Circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                    RegisterUserDAO.CreateMission(ObjUserMissionsBAL);

                    if (String.IsNullOrEmpty(Convert.ToString(hdnProposedDate.Value)))
                    {
                        spFinalMessage.InnerText = "In order to Walk " + ObjUserMissionsBAL.WeightEntered + " steps by " + System.DateTime.Now.AddDays(daysLeft).ToString("MMMM dd, yyyy") + ".Daily you will need to walk " + stpesToCoverDaily + " steps.";
                    }
                    else
                    {
                        spFinalMessage.InnerText = "In order to Walk " + ObjUserMissionsBAL.WeightEntered + " steps by " + Convert.ToDateTime(hdnProposedDate.Value).ToString("MMMM dd, yyyy") + ".Daily you will need to walk " + stpesToCoverDaily + " steps.";
                    }
                    int Missionid = 0;
                    AdminBAO objAdminBAO = new AdminBAO();
                    DataTable dt = new DataTable();
                    ObjRegisterUserBAO.ID = MySession.Current.LoginId;
                    ObjRegisterUserBAO.procedureType = "GM";
                    dt = RegisterUserDAO.GetInvitationDetail(ObjRegisterUserBAO);
                    if (dt.Rows.Count > 0)
                    {
                        Missionid = Convert.ToInt32(dt.Rows[0]["Pk_mission_id"]);
                    }
                    if (MySession.Current.SelectedCircleUserId == MySession.Current.LoginId)
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
                                    int retval = 0;
                                    ObjUserMissionsBAL.MN_ID = 0;
                                    ObjUserMissionsBAL.fk_mission_id = Missionid;
                                    ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                    ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                    ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                    ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                    ObjUserMissionsBAL.ProcedureType = "I";
                                    retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                    if (retval != 0)
                                    {
                                        string name = "";
                                        string email = "";
                                        string name1 = "";
                                        string Circlename = "";
                                        DataTable dtUser = new DataTable();
                                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                        objAdminBAO.ProcedureType = "CU";
                                        dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                        if (dtUser.Rows.Count > 0)
                                        {
                                            Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                        }
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
                                        string Subject = name1 + " Create a Mission  in " + Circlename;
                                        string body = "Hi " + name + ",<br /><br />" + name1 + " has created a new mission in  Circle : " + " '" + Circlename + "' " + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                        ClsGeneric objClsGeneric = new ClsGeneric();
                                        objClsGeneric.SendMail(email, body, Subject);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                        objusercircles.fk_circle_id = MySession.Current.CircleId;
                        objusercircles.proceduretype = "S";
                        DataTable dtFriends = new DataTable();
                        dtFriends = UserCirclesDAO.GetFriendList(objusercircles);
                        if (dtFriends.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtFriends.Rows.Count; i++)
                            {
                                int retval = 0;
                                ObjUserMissionsBAL.MN_ID = 0;
                                ObjUserMissionsBAL.fk_mission_id = Missionid;
                                ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                ObjUserMissionsBAL.ProcedureType = "I";
                                retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                if (retval != 0)
                                {
                                    string name = "";
                                    string email = "";
                                    string name1 = "";
                                    string Circlename = "";
                                    DataTable dtUser = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                    objAdminBAO.ProcedureType = "CU";
                                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                    if (dtUser.Rows.Count > 0)
                                    {
                                        Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                    }
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
                                    string Subject = name1 + " Create a Mission  in " + Circlename;
                                    string body = "Hi " + name + ",<br /><br />" + name1 + " has created a new mission in  Circle :"+" '" + Circlename+"' " + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                    ClsGeneric objClsGeneric = new ClsGeneric();
                                    objClsGeneric.SendMail(email, body, Subject);
                                }
                            }
                        }
                    }

                    txtMissionName.Text = "";
                    txtWeightToLose.Text = "";
                    txtMissionName.Enabled = false;
                    txtWeightToLose.Enabled = false;
                    btnAcceptedByUser.Enabled = false;
                    btnRejectedByUser.Enabled = false;
                    drpPreferenceOptions.SelectedValue = "0";
                    btnCalculate.Enabled = false;
                    pnlCaloriesNotFeasible.Style.Value = "display:none;";
                    pnlMissionCompletionMessage.Style.Value = "display:block;";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnSubmitDetails_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                System.Threading.Thread.Sleep(1000);
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
                    if (txtheightInches.Text != "0" || txtheightInches.Text != null)
                    {
                        ObjRegisterUserBAO.HeightInches = Convert.ToInt32(txtheightInches.Text);
                    }
                    else
                    {
                        ObjRegisterUserBAO.HeightInches = 0;
                    }
                }
                ObjRegisterUserBAO.YearOfBirth = Convert.ToInt32(drpYear.SelectedValue);
                ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeight.Text.Trim());
                ObjRegisterUserBAO.WeightUnits = Convert.ToInt32(drpUserWeightOptions.SelectedValue);
                ObjRegisterUserBAO.HeightUnits = Convert.ToInt32(drpUserHeightOptions.SelectedValue);

                ObjRegisterUserBAO.Gender = Convert.ToString(drpGender.SelectedValue);

                RegisterUserDAO.UpdateFeatures(ObjRegisterUserBAO);
                BindMissionTypesAndThemeswithFeatures();

                tblInitialMessage.Style.Value = "display:none;";
                tr_steptwo.Style.Value = "display:block;";
                tblStepTwo.Style.Value = "display:block";
                btnShowStepThree.Style.Value = "display:block";
                pnlFeatures.Style.Value = "display:none;";

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                System.Threading.Thread.Sleep(1000);
                if (btnCalculate.Text == "Calculate")
                {
                    RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();

                    //if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                    //{
                        ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    //}
                    //else
                    //{
                    //    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    //}
                    ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeightToLose.Text.Trim());
                    if (drpSelectMissionTheme.SelectedValue == "1")
                    {

                        ObjRegisterUserBAO.Days_Suggested_By_User = 0;
                    }
                    else
                    {
                        if (radPeriodicOptions.SelectedItem.Value == "1")
                        {
                            ObjRegisterUserBAO.Days_Suggested_By_User = Convert.ToInt32(7 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim()));
                        }
                        else if (radPeriodicOptions.SelectedItem.Value == "2")
                        {
                            ObjRegisterUserBAO.Days_Suggested_By_User = Convert.ToInt32(30 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim()));
                        }
                        else
                        {
                            ObjRegisterUserBAO.Days_Suggested_By_User = 0;
                        }
                    }
                    DataSet ds = null;
                    //////// For Weight Lose ... the calories are required
                    if (drpSelectMissionType.SelectedIndex == 0)
                    {


                        ObjRegisterUserBAO.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                        ObjRegisterUserBAO.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);
                        ds = new DataSet();
                        ds = RegisterUserDAO.CalculateBMR(ObjRegisterUserBAO);

                        int daysLeft = Convert.ToInt32(ds.Tables[0].Rows[0]["DaysTargetedForNormalCase"]);
                        spEstimatedDate.InnerText = Convert.ToDateTime(System.DateTime.Now.AddDays(daysLeft).ToString("d")).ToString("MMMM dd, yyyy");
                        spConsumeAmount.InnerText = " by consuming " + Convert.ToString(ds.Tables[0].Rows[0]["CaloriesToConsumeNormalCase"]);

                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["DaysTargetedForNormalCase"]) == 0)
                        {
                            decimal minimValue = 1200;
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["CaloriesToConsumeForLightActive"]) >= minimValue)
                            {

                                pnlCaloriesNotFeasible.Style.Value = "display:block;";
                                pnlMissionCompletionMessage.Style.Value = "display:none;";


                                lblLessAggressiveCalConsume.Text = ds.Tables[0].Rows[0]["CaloriesToConsumeForLightActive"].ToString();
                                lblLessAggressiveDateRecommended.Text = System.DateTime.Now.AddDays(Convert.ToDouble(ds.Tables[0].Rows[0]["DaysTargetedForLightActive"].ToString())).ToString("MMMM dd, yyyy");


                                lblAverageCalConsume.Text = ds.Tables[0].Rows[0]["CaloriesToConsumeForModerately"].ToString();
                                lblAverageDateRecommended.Text = System.DateTime.Now.AddDays(Convert.ToDouble(ds.Tables[0].Rows[0]["DaysTargetedForModerately"].ToString())).ToString("MMMM dd, yyyy");


                                lblMoreAggressiveCalCosnume.Text = ds.Tables[0].Rows[0]["CaloriesToConsumeForVeryActive"].ToString();
                                lblMoreAggressiveDateRecommended.Text = System.DateTime.Now.AddDays(Convert.ToDouble(ds.Tables[0].Rows[0]["DaysTargetedForVeryActive"].ToString())).ToString("MMMM dd, yyyy");

                                btnFin2.Style.Value = "display:block;";
                            }
                            else
                            {
                                pnlErrorMsg.Style.Value = "display:block;";
                            }
                        }
                    }
                    else
                    {
                        int daysLeft = 0;
                        if (Convert.ToInt32(txtWeightToLose.Text) >= 10000)
                        {
                            if (drpSelectMissionTheme.SelectedValue == "2")
                            {
                                if (radPeriodicOptions.SelectedItem.Value == "1")
                                {
                                    daysLeft = Convert.ToInt32(7 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim()));
                                }
                                else if (radPeriodicOptions.SelectedItem.Value == "2")
                                {
                                    daysLeft = Convert.ToInt32(30 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim()));
                                }
                            }
                            else
                            {
                                daysLeft = Convert.ToInt32(Convert.ToDecimal(txtWeightToLose.Text) / 10000);
                            }
                            spEstimatedDate.InnerText = System.DateTime.Now.AddDays(daysLeft).ToString("MMMM dd, yyyy"); ;
                        }
                        else
                        {
                            spEstimatedDate.InnerText = System.DateTime.Now.AddDays(1).ToString("MMMM dd, yyyy"); ;
                            daysLeft = 1;
                        }
                    }


                    tr_steptwo.Style.Value = "display:block;";
                    if (pnlFeatures.Style.Value == "display:block;")
                    {
                        tblStepTwo.Style.Value = "display:none;";
                        pnlFeatures.Style.Value = "display:block;";
                    }
                    else
                    {
                        pnlFeatures.Style.Value = "display:none;";
                        tblStepTwo.Style.Value = "display:block;";
                    }

                    btnShowStepThree.Style.Value = "display:block;";
                    tblStepThree.Style.Value = "display:block;";
                    btnShowStepFour.Style.Value = "display:block;";
                    if (dvPeriodic.Style.Value == "display:block;")
                    {
                        dvPeriodic.Style.Value = "display:block;";
                    }
                    else
                    {
                        dvPeriodic.Style.Value = "display:none;";
                    }

                    tblStepFour.Style.Value = "display:block;";

                    if (drpSelectMissionType.SelectedIndex == 1)
                    {
                        tblStepFive.Style.Value = "display:none;";
                        spWeightSteps.InnerText = "Steps needed to take";
                        drpWeightToLooseOptions.Style.Value = "display:none;";
                        spStepSixFive.InnerText = "Step -5";
                    }
                    else
                    {
                        tblStepFive.Style.Value = "display:block;";
                        spWeightSteps.InnerText = "Weight(lbs or kgs) \nneeded to lose";
                        drpWeightToLooseOptions.Style.Value = "display:block;";
                        spStepSixFive.InnerText = "Step -6";
                    }

                    btnShowStepFour.Style.Value = "display:block;";
                    btnShowStepFive.Style.Value = "display:block;";
                    btnCalculate.Style.Value = "display:block;";
                    btnAcceptedByUser.Enabled = true;
                    btnRejectedByUser.Enabled = true;

                    if (ds != null)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["DaysTargetedForNormalCase"]) != 0)
                        {
                            tblInitialMessage.Style.Value = "display:block;";
                            pnlMissionCompletionMessage.Style.Value = "display:none;";
                            pnlCaloriesNotFeasible.Style.Value = "display:none;";
                        }
                    }
                    else
                    {
                        tblInitialMessage.Style.Value = "display:block;";
                        pnlMissionCompletionMessage.Style.Value = "display:none;";
                        pnlCaloriesNotFeasible.Style.Value = "display:none;";
                    }

                    txtWeightToLose.Enabled = false;
                    drpWeightToLooseOptions.Enabled = false;
                    drpSelectMissionTheme.Enabled = false;
                    drpPeriodicTime.Enabled = false;
                }
                else
                {
                    UserMissionsBAL ObjUserMissionsBAL = new UserMissionsBAL();

                    //if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                    //{
                        ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    //}
                    //else
                    //{
                    //    ObjUserMissionsBAL.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    //}
                    ObjUserMissionsBAL.WeightEntered = Convert.ToInt32(txtWeightToLose.Text.Trim());
                    ObjUserMissionsBAL.MissionName = txtMissionName.Text.Trim();
                    ObjUserMissionsBAL.MissionTypeId = Convert.ToInt32(drpSelectMissionType.SelectedValue);
                    ObjUserMissionsBAL.MissionThemeId = Convert.ToInt32(drpSelectMissionTheme.SelectedValue);
                    ObjUserMissionsBAL.CreatedByName = Session["name_of_login_user"].ToString();
                    int daysCalculated = 0;
                    int daysCalculated_when_month = 0;

                    if (drpSelectMissionTheme.SelectedValue == "1")
                    {
                        if (radPeriodicOptions.SelectedItem.Value == "1")
                        {
                            daysCalculated = 7 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim());
                            ObjUserMissionsBAL.DateOfCompletion = Convert.ToDateTime(System.DateTime.Now.AddDays(daysCalculated).ToString());
                        }
                        else if (radPeriodicOptions.SelectedItem.Value == "2")
                        {
                            daysCalculated_when_month = 30 * Convert.ToInt32(drpPeriodicTime.SelectedValue.Trim());
                            ObjUserMissionsBAL.DateOfCompletion = Convert.ToDateTime(System.DateTime.Now.AddDays(daysCalculated_when_month).ToString());
                        }
                    }
                    else
                    {
                        ObjUserMissionsBAL.DateOfCompletion = Convert.ToDateTime(spEstimatedDate.InnerText);
                    }
                    RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
                    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    //if (MySession.Current.SelectedCircleUserId == MySession.Current.LoginId)
                    //{
                    //    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                    //}
                    //else
                    //{
                    //    ObjRegisterUserBAO.LoginId = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    //}
                    ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeightToLose.Text.Trim());
                    ObjRegisterUserBAO.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                    ObjRegisterUserBAO.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);

                    if (radPeriodicOptions.SelectedItem.Value == "1")
                    {
                        ObjRegisterUserBAO.Days_Suggested_By_User = daysCalculated;
                    }
                    else if (radPeriodicOptions.SelectedItem.Value == "2")
                    {
                        ObjRegisterUserBAO.Days_Suggested_By_User = daysCalculated_when_month;
                    }

                    int daysLeft = 0;

                    ObjUserMissionsBAL.PreferenceOptions = Convert.ToInt32(drpPreferenceOptions.SelectedValue);
                    ObjUserMissionsBAL.WeightUnits = Convert.ToInt32(drpWeightToLooseOptions.SelectedValue);
                    ObjUserMissionsBAL.CircleId = Convert.ToInt32(MySession.Current.CircleId);

                    //////// For Weight Lose ... the calories are required
                    if (drpSelectMissionType.SelectedIndex == 0)
                    {
                        DataSet ds = RegisterUserDAO.CalculateBMR(ObjRegisterUserBAO);
                        ObjUserMissionsBAL.CaloriesEaten = Convert.ToDecimal(ds.Tables[0].Rows[0]["CaloriesToConsumeNormalCase"]);

                        ObjUserMissionsBAL.TotalCaloriesToBurn = Convert.ToDecimal(ds.Tables[0].Rows[0]["CaloriesToLoose"]);
                        daysLeft = Convert.ToInt32(ds.Tables[0].Rows[0]["DaysTargetedForNormalCase"]);
                        ObjUserMissionsBAL.CreatedByName = Session["name_of_login_user"].ToString();
                        if (radPeriodicOptions.SelectedItem.Value == "1")
                        {
                            ObjUserMissionsBAL.Periodic_Selection = 1;
                        }
                        else
                        {
                            ObjUserMissionsBAL.Periodic_Selection = 2;
                        }
                        ObjUserMissionsBAL.Public_Private = Convert.ToInt32(drpPublicPrivate.SelectedItem.Value);
                        ObjUserMissionsBAL.Group_Individual = Convert.ToInt32(drpGroupIndividual.SelectedItem.Value);
                        ObjUserMissionsBAL.fk_User_Circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                        RegisterUserDAO.CreateMission(ObjUserMissionsBAL);

                        string activitySelectedByUser = string.Empty;
                        if (drpPreferenceOptions.SelectedValue == "1")
                            activitySelectedByUser = " with a preference to Diet";
                        else if (drpPreferenceOptions.SelectedValue == "2")
                            activitySelectedByUser = " with an increase in your activity level";
                        else if (drpPreferenceOptions.SelectedValue == "3")
                            activitySelectedByUser = " with a preference to Diet and increase in your activity level";

                        spFinalMessage.InnerText = "In order to Lose " + ObjUserMissionsBAL.WeightEntered + (ObjUserMissionsBAL.WeightUnits == 1 ? " kilogram(s) by " : " pound(s) ") + " by " + System.DateTime.Now.AddDays(daysLeft).ToString("MMMM dd, yyyy") + activitySelectedByUser + ".\r\n\tDaily you need to consume " + ds.Tables[0].Rows[0]["CaloriesToConsumeNormalCase"] + " calories. ";
                    }
                    else
                    {
                        ///////// For steps needed to cover ... the calories are not required and are passed as 0.
                        ObjUserMissionsBAL.CaloriesEaten = 0;
                        daysLeft = Convert.ToInt32(txtWeightToLose.Text) / Convert.ToInt32(ObjRegisterUserBAO.Days_Suggested_By_User);
                        ObjUserMissionsBAL.CaloriesBurnt = daysLeft;
                        ObjUserMissionsBAL.TotalCaloriesToBurn = Convert.ToInt32(txtWeightToLose.Text);

                        if (radPeriodicOptions.SelectedItem.Value == "1")
                        {
                            ObjUserMissionsBAL.Periodic_Selection = 1;
                        }
                        else
                        {
                            ObjUserMissionsBAL.Periodic_Selection = 2;
                        }
                        ObjUserMissionsBAL.CreatedByName = Session["name_of_login_user"].ToString();
                        ObjUserMissionsBAL.Public_Private = Convert.ToInt32(drpPublicPrivate.SelectedItem.Value);
                        ObjUserMissionsBAL.Group_Individual = Convert.ToInt32(drpGroupIndividual.SelectedItem.Value);
                        ObjUserMissionsBAL.fk_User_Circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                        RegisterUserDAO.CreateMission(ObjUserMissionsBAL);
                        spFinalMessage.InnerText = "In order to Walk " + ObjUserMissionsBAL.WeightEntered + " steps by " + System.DateTime.Now.AddDays(ObjRegisterUserBAO.Days_Suggested_By_User).ToString("MMMM dd, yyyy") + ".Daily you will need to walk " + daysLeft + " steps.";
                    }
                    int Missionid = 0;
                    AdminBAO objAdminBAO = new AdminBAO();
                    DataTable dt = new DataTable();
                    ObjRegisterUserBAO.ID = MySession.Current.LoginId;
                    ObjRegisterUserBAO.procedureType = "GM";
                    dt = RegisterUserDAO.GetInvitationDetail(ObjRegisterUserBAO);
                    if (dt.Rows.Count > 0)
                    {
                        Missionid = Convert.ToInt32(dt.Rows[0]["Pk_mission_id"]);
                    }
                    if (MySession.Current.SelectedCircleUserId == MySession.Current.LoginId)
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
                                    int retval = 0;
                                    ObjUserMissionsBAL.MN_ID = 0;
                                    ObjUserMissionsBAL.fk_mission_id = Missionid;
                                    ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                    ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                    ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                    ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                    ObjUserMissionsBAL.ProcedureType = "I";
                                    retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                    if (retval != 0)
                                    {
                                        string name = "";
                                        string email = "";
                                        string name1 = "";
                                        string Circlename = "";
                                        DataTable dtUser = new DataTable();
                                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                        objAdminBAO.ProcedureType = "CU";
                                        dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                        if (dtUser.Rows.Count > 0)
                                        {
                                            Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                        }
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
                                        string Subject = name1 + " Create a Mission  in " + Circlename;
                                        string body = "Hi " + name + ",<br /><br />" + name1 + " has created a new mission in  Circle : " + " '" + Circlename + "' " + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                        ClsGeneric objClsGeneric = new ClsGeneric();
                                        objClsGeneric.SendMail(email, body, Subject);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                        objusercircles.fk_circle_id = MySession.Current.CircleId;
                        objusercircles.proceduretype = "S";
                        DataTable dtFriends = new DataTable();
                        dtFriends = UserCirclesDAO.GetFriendList(objusercircles);
                        if (dtFriends.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtFriends.Rows.Count; i++)
                            {
                                int retval = 0;
                                ObjUserMissionsBAL.MN_ID = 0;
                                ObjUserMissionsBAL.fk_mission_id = Missionid;
                                ObjUserMissionsBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                ObjUserMissionsBAL.MN_DATE = DateTime.Now.ToString();
                                ObjUserMissionsBAL.MN_NOTIFICATION_STATUS = "False";
                                ObjUserMissionsBAL.MN_EMAIL_STATUS = "True";
                                ObjUserMissionsBAL.ProcedureType = "I";
                                retval = UserMissionsDAL.InsertMissionNotification(ObjUserMissionsBAL);
                                if (retval != 0)
                                {
                                    string name = "";
                                    string email = "";
                                    string name1 = "";
                                    string Circlename = "";
                                    DataTable dtUser = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                    objAdminBAO.ProcedureType = "CU";
                                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                    if (dtUser.Rows.Count > 0)
                                    {
                                        Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                    }
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
                                    string Subject = name1 + " Create a Mission  in " + Circlename;
                                    string body = "Hi " + name + ",<br /><br />" + name1 + " has created a new mission in  Circle :"+" '" + Circlename+"' " + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                    ClsGeneric objClsGeneric = new ClsGeneric();
                                    objClsGeneric.SendMail(email, body, Subject);
                                }
                            }
                        }
                    }
                    txtMissionName.Text = "";
                    txtWeightToLose.Text = "";
                    txtMissionName.Enabled = false;
                    txtWeightToLose.Enabled = false;
                    pnlMissionCompletionMessage.Style.Value = "display:block;";
                    btnCalculate.Text = "Calculate";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //protected void drpSelectMissionTheme_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (drpSelectMissionTheme.SelectedValue == "2")
        //    {
        //        dvPeriodic.Style.Value = "display:none;";
        //        btnCalculate.Text = "Calculate";
        //    }
        //    else
        //    {
        //        dvPeriodic.Style.Value = "display:none;";
        //        btnCalculate.Text = "Calculate";
        //    }
        //    if (tblStepFour.Visible == true && drpSelectMissionType.SelectedIndex != 1)
        //    {
        //        btnShowStepFive.Style.Value = "display:block;";
        //    }
        //    else
        //    {
        //        btnShowStepFive.Style.Value = "display:none;";
        //    }
        //}

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

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                txtMissionName.Text = "";
                txtWeightToLose.Text = "";
                txtMissionName.Enabled = true;
                txtWeightToLose.Enabled = true;
                pnlMissionCompletionMessage.Style.Value = "display:none;";
                pnlCaloriesNotFeasible.Style.Value = "display:none;";
                tblInitialMessage.Style.Value = "display:none;";
                dvPeriodic.Style.Value = "display:none;";
                drpSelectMissionTheme.SelectedValue = "1";
                tblStepTwo.Style.Value = "display:none;";
                btnShowStepTwo.Style.Value = "display:block;";
                tblStepThree.Style.Value = "display:none;";
                btnShowStepThree.Style.Value = "display:none;";
                tblStepFour.Style.Value = "display:none;";
                btnShowStepFour.Style.Value = "display:none;";
                tblStepFive.Style.Value = "display:none;";
                btnShowStepFive.Style.Value = "display:none;";
                btnCalculate.Style.Value = "display:none;";
                tr_steptwo.Style.Value = "display:none;";
                btnCalculate.Enabled = true;

                radAverage.Checked = false;
                radMoreAggressive.Checked = false;
                radLessAggresive.Checked = false;
                pnlFeatures.Style.Value = "display:none;";

                txtWeightToLose.Enabled = true;
                drpWeightToLooseOptions.Enabled = true;
                drpSelectMissionTheme.Enabled = true;
                drpPeriodicTime.Enabled = true;
                pnlErrorMsg.Style.Value = "display:none;";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnListAllMissions_Click(object sender, EventArgs e)
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



    }
}
