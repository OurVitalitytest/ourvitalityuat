using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ALEREIMPACT.BAO;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.BAL.User;

namespace ALEREIMPACT.DAO.User
{
    public class RegisterUserDAO
    {
        public static DataTable SubmitNewUser(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_email",
                TextValue = objNewUserBao.LoginEmail.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@login_password",
                TextValue = objNewUserBao.LoginPassword.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@user_role_id",
                TextValue = objNewUserBao.UserRoleId.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@password_salt",
                TextValue = objNewUserBao.PasswordSalt.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@is_password_changed",
                TextValue = objNewUserBao.IsPasswordChanged.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@login_status",
                TextValue = objNewUserBao.LoginStatus.ToString()
            });
          
            parameterslist.Add(new Parameters()
            {
                TextName = "@first_name",
                TextValue = objNewUserBao.FirstName.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@last_name",
                TextValue = objNewUserBao.LastName.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@user_address",
                TextValue = objNewUserBao.UserAddress.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@yearOfbirth",
                TextValue = Convert.ToInt32(objNewUserBao.YearOfBirth).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@monthOfBirth",
                TextValue = Convert.ToInt32(objNewUserBao.MonthOfBirth).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@dateOfBirth",
                TextValue = Convert.ToInt32(objNewUserBao.DateOfBirth).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@user_image",
                TextValue = objNewUserBao.UserImage.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@location_id",
                TextValue = Convert.ToInt32(objNewUserBao.LocationId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@zip",
                TextValue = objNewUserBao.Zip.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@home_contact_1",
                TextValue = objNewUserBao.HomeContact1.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@home_contact_2",
                TextValue = objNewUserBao.HomeContact2.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@office_contact",
                TextValue = objNewUserBao.OfficeContact.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@mobile_number",
                TextValue = objNewUserBao.MobileNumber.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@gender",
                TextValue = objNewUserBao.Gender.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@height",
                TextValue = Convert.ToDecimal(objNewUserBao.Height).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@height_units",
                TextValue = Convert.ToInt32(objNewUserBao.HeightUnits).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@heightInches",
                TextValue = Convert.ToInt32(objNewUserBao.HeightInches).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@weight",
                TextValue = Convert.ToInt32(objNewUserBao.Weight).ToString()
            });


            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_units",
                TextValue = Convert.ToInt32(objNewUserBao.WeightUnits).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@registration_type_id",
                TextValue = objNewUserBao.RegistrationTypeId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@has_profile_added",
                TextValue = objNewUserBao.HasProfileAdded.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@RS_ID_FK",
                TextValue = objNewUserBao.RS_ID_FK.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@EDU_ID_FK",
                TextValue = objNewUserBao.EDU_ID_FK.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@WP_ID_FK",
                TextValue = objNewUserBao.WP_ID_FK.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@INTEREST_ID_FK",
                TextValue = objNewUserBao.INTEREST_ID_FK.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@RELIGION_ID_FK",
                TextValue = objNewUserBao.RELIGION_ID_FK.ToString()
            });
            return sqlhelper.getRecords("spRegister_Newuser", parameterslist);
        }
        public static DataTable GetAllLocations()
        {
            SQLHelper sqlhelper = new SQLHelper();
            return sqlhelper.getRecords("spGetAllLocations");
        }
        public static DataTable ChangePassword(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@pk_user_registration_Id",
                TextValue = Convert.ToInt32(objNewUserBao.user_registration_Id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@login_password",
                TextValue = objNewUserBao.LoginPassword.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objNewUserBao.procedureType.ToString()
            });
            return sqlhelper.getRecords("spGetPassword", parameterslist);
        }
        public static Int32 UpdatePassword(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@pk_user_registration_Id",
                    TextValue = Convert.ToInt32(objNewUserBao.user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@login_password",
                    TextValue = objNewUserBao.LoginPassword.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@password_salt",
                    TextValue = objNewUserBao.PasswordSalt.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Is_pwd_Changed",
                    TextValue = objNewUserBao.IsPasswordChanged.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objNewUserBao.procedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spUpdatePassword", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }
        public static DataTable GetEmailDetail(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_email",
                TextValue = objNewUserBao.LoginEmail.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objNewUserBao.procedureType.ToString()
            });
            return sqlhelper.getRecords("spGetEmailDetail", parameterslist);
        }

        public static DataTable GetEmailDetail_ForRememberMe(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_Id",
                TextValue = objNewUserBao.fk_user_registration_id.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objNewUserBao.procedureType.ToString()
            });
            return sqlhelper.getRecords("spGetEmailDetail_ForRememberMe", parameterslist);
        }

        public static DataTable UpdateFeatures(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_id",
                TextValue = objNewUserBao.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@height",
                TextValue = objNewUserBao.Height.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@yearOfBirth",
                TextValue = objNewUserBao.YearOfBirth.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@height_units",
                TextValue = objNewUserBao.HeightUnits.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_units",
                TextValue = objNewUserBao.WeightUnits.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@weight",
                TextValue = objNewUserBao.Weight.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@gender",
                TextValue = objNewUserBao.Gender.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@height_inches",
                TextValue = objNewUserBao.HeightInches.ToString()
            });
            return sqlhelper.getRecords("update_Features", parameterslist);
        }
        public static DataSet CalculateBMR(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_id",
                TextValue = objNewUserBao.LoginId.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_to_loose",
                TextValue = objNewUserBao.Weight.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_to_lose_units",
                TextValue = objNewUserBao.WeightUnits.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@days_depicted",
                TextValue = objNewUserBao.Days_Suggested_By_User.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@preference_option",
                TextValue = objNewUserBao.PreferenceOptions.ToString()
            });

            return sqlhelper.getRecordsDS("Calculate_Metablosim", parameterslist);
        }
        public static DataSet CreateMission(UserMissionsBAL objUserMissionsBAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@mission_name",
                TextValue = objUserMissionsBAL.MissionName.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_to_loose",
                TextValue = objUserMissionsBAL.WeightEntered.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_to_loose_unit",
                TextValue = objUserMissionsBAL.WeightUnits.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_type",
                TextValue = objUserMissionsBAL.MissionTypeId.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_theme",
                TextValue = objUserMissionsBAL.MissionThemeId.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_created_by_user_Id",
                TextValue = objUserMissionsBAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@deadline_date_set",
                TextValue = objUserMissionsBAL.DateOfCompletion.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@calories_to_burn_daily",
                TextValue = objUserMissionsBAL.CaloriesBurnt.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@calories_to_consume_daily",
                TextValue = objUserMissionsBAL.CaloriesEaten.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@total_calories_to_burn",
                TextValue = objUserMissionsBAL.TotalCaloriesToBurn.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@preference_option_selected",
                TextValue = objUserMissionsBAL.PreferenceOptions.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_id",
                TextValue = objUserMissionsBAL.CircleId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@periodic_type",
                TextValue = objUserMissionsBAL.Periodic_Selection.ToString()
            });


            parameterslist.Add(new Parameters()
            {
                TextName = "@group_individual",
                TextValue = objUserMissionsBAL.Group_Individual.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@public_private",
                TextValue = objUserMissionsBAL.Public_Private.ToString()
            });


            parameterslist.Add(new Parameters()
            {
                TextName = "@created_by_name",
                TextValue = objUserMissionsBAL.CreatedByName.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_User_Circle_id",
                TextValue = objUserMissionsBAL.fk_User_Circle_id.ToString()
            });
            return sqlhelper.getRecordsDS("spCreateMission", parameterslist);
        }
        public static DataTable ListAllMissionsByLoginId(UserMissionsBAL objUserMissionsBAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_friends_id",
                TextValue = objUserMissionsBAL.AllFriends_Id.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@selected_circle_id",
                TextValue = objUserMissionsBAL.CircleId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_id",
                TextValue = objUserMissionsBAL.LoginId.ToString()  
            });
             parameterslist.Add(new Parameters()
            {
                TextName = "@pk_user_circle_ID",
                TextValue = objUserMissionsBAL.fk_User_Circle_id.ToString()
            });
            return sqlhelper.getRecords("spGet_AllMissions_ByLoginId", parameterslist);
        }


        public static Int32 InserttblAuditTrail(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_ID",
                    TextValue = Convert.ToInt32(objNewUserBao.AT_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id ",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_LOGINTIME",
                    TextValue = (objNewUserBao.AT_LOGINTIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_LOGOUTTIME",
                    TextValue = (objNewUserBao.AT_LOGOUTTIME).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_DATE",
                    TextValue = (objNewUserBao.AT_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_LOGIN_STATUS",
                    TextValue = (objNewUserBao.AT_LOGIN_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_FAILUREREASON",
                    TextValue = (objNewUserBao.AT_FAILUREREASON).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_ONLINE",
                    TextValue = (objNewUserBao.AT_ONLINE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttbAuditTrail", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static Int32 UpdatetblAuditTrail(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_ID",
                    TextValue = Convert.ToInt32(objNewUserBao.AT_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id ",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_LOGOUTTIME",
                    TextValue = (objNewUserBao.AT_LOGOUTTIME).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spUpdatetbAuditTrail", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static Int32 UpdatetblUserInvitation(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_ID",
                    TextValue = Convert.ToInt32(objNewUserBao.UI_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id ",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_USER_MAIL_ID",
                    TextValue = (objNewUserBao.UI_USER_MAIL_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_STATUS",
                    TextValue = (objNewUserBao.UI_STATUS).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_CODE",
                    TextValue = Convert.ToInt32(objNewUserBao.UI_CODE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_DATE",
                    TextValue = (objNewUserBao.UI_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_MAIL_STATUS",
                    TextValue = (objNewUserBao.UI_MAIL_STATUS).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserInvitation", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataTable GetInvitationDetail(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@ID",
                TextValue = objNewUserBao.ID.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objNewUserBao.procedureType.ToString()
            });
            return sqlhelper.getRecords("spFilterSearch", parameterslist);
        }


        public static Int32 InserttblErrorDetail(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_ID",
                    TextValue = Convert.ToInt32(objNewUserBao.ER_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@PAGE_ID_FK ",
                    TextValue = Convert.ToInt32(objNewUserBao.PAGE_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id ",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_MESSAGE",
                    TextValue = (objNewUserBao.ER_MESSAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_IMAGE",
                    TextValue = (objNewUserBao.ER_IMAGE).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_POST_DATE",
                    TextValue = (objNewUserBao.ER_POST_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_STATUS",
                    TextValue = (objNewUserBao.ER_STATUS).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblErrorDetails", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static Int32 InserttblFeedBAck(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_ID",
                    TextValue = Convert.ToInt32(objNewUserBao.FB_ID).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id ",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@PAGE_ID_FK ",
                    TextValue = Convert.ToInt32(objNewUserBao.PAGE_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_MESSAGE",
                    TextValue = (objNewUserBao.FB_MESSAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_DATE",
                    TextValue = (objNewUserBao.FB_DATE).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_RATING",
                    TextValue = (objNewUserBao.FB_RATING).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_STATUS",
                    TextValue = (objNewUserBao.FB_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserFeedBack", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataTable GetFeedBAck(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_id ",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@PAGE_ID_FK ",
                TextValue = Convert.ToInt32(objNewUserBao.PAGE_ID_FK).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objNewUserBao.procedureType.ToString()
            });
            return sqlhelper.getRecords("spViewFeedBackMeesages", parameterslist);
        }

        public static Int32 InserttblTickets(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@T_ID",
                    TextValue = Convert.ToInt32(objNewUserBao.T_ID).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id ",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@T_MESSAGE ",
                    TextValue = (objNewUserBao.T_MESSAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@T_REPLYSTATUS",
                    TextValue = (objNewUserBao.T_REPLYSTATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@T_DATE",
                    TextValue = (objNewUserBao.T_DATE).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@T_STATUS",
                    TextValue = (objNewUserBao.T_STATUS).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblTickets", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }


        public static DataTable AddFitBitKeys(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id ",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@secret ",
                TextValue = Convert.ToString(objNewUserBao.AccessTokenSecret)
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@token",
                TextValue = Convert.ToString(objNewUserBao.AccessToken)
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@request_type",
                TextValue = objNewUserBao.procedureType.ToString()
            });
            return sqlhelper.getRecords("spAddFitBitKeys", parameterslist);
        }



        public static DataTable Get_MissionLogDatesOfuser(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_id",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@tracker_date",
                TextValue = Convert.ToString(objNewUserBao.T_DATE)
            });

            return sqlhelper.getRecords("spGet_MissionLogDatesOfuser", parameterslist);
        }

        public static Int32 UpdatetblUSerProfile(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@dateOfBirth ",
                    TextValue = Convert.ToInt32(objNewUserBao.DateOfBirth).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@monthOfBirth",
                    TextValue = Convert.ToInt32(objNewUserBao.MonthOfBirth).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@yearOfBirth",
                    TextValue = (objNewUserBao.YearOfBirth).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@weight",
                    TextValue = Convert.ToInt32(objNewUserBao.Weight).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@gender",
                    TextValue = (objNewUserBao.Gender).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });

                returnValue = sQLHelper.ExecuteNonQuery("spUpdateProfile", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static Int32 UpdateMyProfile(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id",
                    TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@dateOfBirth ",
                    TextValue = Convert.ToInt32(objNewUserBao.DateOfBirth).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@monthOfBirth",
                    TextValue = Convert.ToInt32(objNewUserBao.MonthOfBirth).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@yearOfBirth",
                    TextValue = (objNewUserBao.YearOfBirth).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@weight",
                    TextValue = Convert.ToInt32(objNewUserBao.Weight).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_location_id",
                    TextValue = Convert.ToInt32(objNewUserBao.LocationId).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@height",
                    TextValue = Convert.ToDecimal(objNewUserBao.Height).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@heightInches",
                    TextValue = Convert.ToDecimal(objNewUserBao.HeightInches).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@height_units",
                    TextValue = Convert.ToInt32(objNewUserBao.HeightUnits).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@weight_units",
                    TextValue = Convert.ToInt32(objNewUserBao.WeightUnits).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@gender",
                    TextValue = (objNewUserBao.Gender).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@RS_ID_FK",
                    TextValue = objNewUserBao.RS_ID_FK.ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@EDU_ID_FK",
                    TextValue = objNewUserBao.EDU_ID_FK.ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@WP_ID_FK",
                    TextValue = objNewUserBao.WP_ID_FK.ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@INTEREST_ID_FK",
                    TextValue = objNewUserBao.INTEREST_ID_FK.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@RELIGION_ID_FK",
                    TextValue = objNewUserBao.RELIGION_ID_FK.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });

                returnValue = sQLHelper.ExecuteNonQuery("spUpdateMyProfile", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataSet GetPersonalizationStatus(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_id ",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@personalization_selected ",
                TextValue = Convert.ToInt32(objNewUserBao.UI_STATUS).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@request_type ",
                TextValue = Convert.ToInt32(objNewUserBao.procedureType).ToString()
            });

            return sqlhelper.getRecordsDS("spGetUser_Personalization_Info", parameterslist);
        }


        public static DataTable CheckFitBitAuthorization(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@login_Id ",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@request_type ",
                TextValue = Convert.ToInt32(objNewUserBao.procedureType).ToString()
            });
            parameterslist.Add(new Parameters()
             {
                 TextName = "@login_status ",
                 TextValue = Convert.ToInt32(objNewUserBao.LoginStatus).ToString()
             });


            return sqlhelper.getRecords("spFitBit_LoginStatus", parameterslist);
        }

        public static DataTable DeleteFitBitKeys(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_id ",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });



            return sqlhelper.getRecords("spDeleteFitBitKeys", parameterslist);
        }
        public static DataTable CheckExternalUserLoginId(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@emailid ",
                TextValue = objNewUserBao.LoginEmail
            });



            return sqlhelper.getRecords("spCheckExternalLogin_EmailId", parameterslist);
        }

        public static DataTable LogBodyMeasurement(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id ",
                TextValue = Convert.ToInt32(objNewUserBao.LoginId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@body_weight",
                TextValue = Convert.ToDecimal(objNewUserBao.FitBitBodyWeight).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@body_mass",
                TextValue = Convert.ToDecimal(objNewUserBao.FitBitBodyMass).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@body_fat",
                TextValue = Convert.ToDecimal(objNewUserBao.FitBitBodyFat).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@log_date",
                TextValue = objNewUserBao.FitBitBodyInfoLogDate.ToString()
            });
            return sqlhelper.getRecords("spLogBodyMeasurement", parameterslist);
        }
        public static DataTable AddAskWeight_Weekely(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_added",
                TextValue = objNewUserBao.Weight.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@weight_units",
                TextValue = objNewUserBao.WeightUnits.ToString()
            });
            

            return sqlhelper.getRecords("spAddAskWeight_Weekely", parameterslist);
        }





        public static DataSet Get_WeightAlreadyExists(RegisterUserBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = Convert.ToInt32(objNewUserBao.fk_user_registration_id).ToString()
            });


            return sqlhelper.getRecordsDS("spGet_WeightAlreadyExists", parameterslist);
        }



        public static Int32 InsertTblSupport(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();


                parametersList.Add(new Parameters()
                {
                    TextName = "@SUPPORT_ID",
                    TextValue = (objNewUserBao.SUPPORT_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUPPORT_NAME",
                    TextValue = (objNewUserBao.SUPPORT_NAME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUPPORT_EMAIL",
                    TextValue = (objNewUserBao.SUPPORT_EMAIL).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUPPORT_MESSAGE",
                    TextValue = (objNewUserBao.SUPPORT_MESSAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUPPORT_DATE",
                    TextValue = (objNewUserBao.SUPPORT_DATE).ToString()
                });
               
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objNewUserBao.procedureType).ToString()
                });

                returnValue = sQLHelper.ExecuteNonQuery("spInsertTblSupport", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }


        public static Int32 InsertTblJournal(RegisterUserBAO objNewUserBao)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@JOURNAL_ID",
                    TextValue = Convert.ToInt32(objNewUserBao.JOURNAL_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = objNewUserBao.fk_user_registration_id.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@MOOD_ID_FK",
                    TextValue = objNewUserBao.MOOD_ID_FK.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@JOURNAL_TITLE",
                    TextValue = objNewUserBao.JOURNAL_TITLE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@JOURNAL_CONTENT",
                    TextValue = objNewUserBao.JOURNAL_CONTENT.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@JOURNAL_DATE",
                    TextValue = objNewUserBao.JOURNAL_DATE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objNewUserBao.procedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblJournal", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }
    }
}
