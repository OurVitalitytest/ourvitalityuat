using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.BAL.User;

namespace ALEREIMPACT.DAL.User
{
    public class UserMissionsDAL
    {
        public static DataTable RegisterMission(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserMissionsDAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@comment",
                TextValue = objUserMissionsDAL.MissionName.ToString()
            });

            //parameterslist.Add(new Parameters()
            //{
            //    TextName = "@pk_major_CommentId",
            //    TextValue = objUserMissionsDAL.MajorCommentId.ToString()
            //});
            //parameterslist.Add(new Parameters()
            //{
            //    TextName = "@fk_circle_id",
            //    TextValue = objUserMissionsDAL.CircleId.ToString()
            //});
            return sqlhelper.getRecords("spPostWallComments", parameterslist);
        }
        public static DataSet BindMissionTypesAndThemes(UserMissionsBAL objUserMissionsBAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserMissionsBAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@user_id_for_name",
                TextValue = objUserMissionsBAL.User_id_For_Name.ToString()
            });
            return sqlhelper.getRecordsDS("spGetMissionThemesAndTypes", parameterslist);
        }
        public static DataTable SubmitMissionInput(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserMissionsDAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_id",
                TextValue = objUserMissionsDAL.MissionId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@calories_burnt",
                TextValue = objUserMissionsDAL.CaloriesBurnt.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@calories_eaten_today",
                TextValue = objUserMissionsDAL.CaloriesEaten.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@pk_user_log_id",
                TextValue = objUserMissionsDAL.Pk_user_Log_Id.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@request_type",
                TextValue = objUserMissionsDAL.Request_Type.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@selected_date",
                TextValue = objUserMissionsDAL.DateOfCompletion.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@activity_performed",
                TextValue = objUserMissionsDAL.Activity_Performed.ToString()
            });
       
            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_id",
                TextValue = objUserMissionsDAL.CircleId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@duration_in_hours",
                TextValue = objUserMissionsDAL.Activity_Hours.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@duration_in_minutes",
                TextValue = objUserMissionsDAL.Activity_minutes.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@duration_in_seconds",
                TextValue = objUserMissionsDAL.Activity_Seconds.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@distance_units",
                TextValue = objUserMissionsDAL.Distance_Units.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@distance_covered",
                TextValue = objUserMissionsDAL.Distance_Covered.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@activity_id",
                TextValue = objUserMissionsDAL.Activity_Id.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@steps_covered",
                TextValue = objUserMissionsDAL.StepsCovered.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@mission_selected",
                TextValue = objUserMissionsDAL.MissionId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@floors_covered",
                TextValue = objUserMissionsDAL.Floors_Covered.ToString()
            });

            return sqlhelper.getRecords("spLogMissionInputs", parameterslist);
        }
        public static DataTable BindMissionDetails(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_id",
                TextValue = objUserMissionsDAL.MissionId.ToString()
            });
            return sqlhelper.getRecords("spGet_MissionDetails", parameterslist);
        }
        public static DataSet BindMissionHistory(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserMissionsDAL.AllFriends_Id.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_id",
                TextValue = objUserMissionsDAL.MissionId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@dense_rank_id",
                TextValue = objUserMissionsDAL.DateId.ToString()
            });
            return sqlhelper.getRecordsDS("[dbo].[spGet_HistoryOfMission_byLoginId]", parameterslist);
        }
        public static DataSet BindMissionGraph(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_login_id",
                TextValue = objUserMissionsDAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserMissionsDAL.AllFriends_Id.ToString()
            });
            parameterslist.Add(new Parameters()
            { 
                TextName = "@fk_mission_id",
                TextValue = objUserMissionsDAL.MissionId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@date_From",
                TextValue = objUserMissionsDAL.Graph_DateFrom.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@date_To",
                TextValue = objUserMissionsDAL.Graph_DateTo.ToString()
            });
            return sqlhelper.getRecordsDS("[dbo].[spGet_GraphsOfMissionProgress_byLoginId]", parameterslist);
        }
        public static DataSet SendMissionInvitation(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_invited_by",
                TextValue = objUserMissionsDAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_invited_to",
                TextValue = objUserMissionsDAL.AllFriends_Id.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_id",
                TextValue = objUserMissionsDAL.MissionId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_circle_id",
                TextValue = objUserMissionsDAL.CircleId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@inivitation_message",
                TextValue = objUserMissionsDAL.InvitationMessage.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@type_of_request",
                TextValue = objUserMissionsDAL.TypeOfRequest.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@pk_mission_invitation_id",
                TextValue = objUserMissionsDAL.Pk_mission_Invitation.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@invitation_status",
                TextValue = objUserMissionsDAL.Mission_Invitation_Status.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@invitation_read",
                TextValue = objUserMissionsDAL.InvitationRead_Status.ToString()
            });
            return sqlhelper.getRecordsDS("spSubmitMission_Invitations", parameterslist);
        }

        public static DataTable ChangeMissionStatus(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_id",
                TextValue = objUserMissionsDAL.MissionId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@new_deadline",
                TextValue = objUserMissionsDAL.DateOfCompletion.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@request_type",
                TextValue = objUserMissionsDAL.TypeOfRequest.ToString()
            });
            return sqlhelper.getRecords("dbo.spUdateMission_Status", parameterslist);
        }

        public static Int32 InsertAddFavActivityLog(UserMissionsBAL objUserMissionsBAL)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@FA_ID",
                    TextValue = Convert.ToInt32(objUserMissionsBAL.fav_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_mission_log_id",
                    TextValue = Convert.ToInt32(objUserMissionsBAL.Fk_mission_log_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_login_id",
                    TextValue = Convert.ToInt32(objUserMissionsBAL.LoginId).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FA_CAL_BURNS",
                    TextValue = Convert.ToInt32(objUserMissionsBAL.fa_CAL_BURNS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FA_NAME",
                    TextValue =(objUserMissionsBAL.Activity_Performed).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FA_DATE_ADD",
                    TextValue = (objUserMissionsBAL.DateOfCompletion).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FA_DATE",
                    TextValue = (objUserMissionsBAL.fa_date).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objUserMissionsBAL.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblAddFavActivityLog", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataSet Get_CheckDates_Of_MissionInputs_byLoginId(UserMissionsBAL objUserMissionsDAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_login_id",
                TextValue = objUserMissionsDAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserMissionsDAL.AllFriends_Id.ToString()
            });

            return sqlhelper.getRecordsDS("[dbo].[spGet_CheckDates_Of_MissionInputs_byLoginId]", parameterslist);
        }


        public static DataTable Weight_Adjustments(UserMissionsBAL objUserMissionsBAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id ",
                TextValue = Convert.ToInt32(objUserMissionsBAL.LoginId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@caloriesBurnt",
                TextValue = Convert.ToDecimal(objUserMissionsBAL.CaloriesBurnt).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@caloriesConsume",
                TextValue = Convert.ToDecimal(objUserMissionsBAL.CaloriesEaten).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_mission_log_id",
                TextValue = objUserMissionsBAL.Activity_Id.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@updatedOn",
                TextValue = objUserMissionsBAL.DateOfCompletion.ToString()
            });
            return sqlhelper.getRecords("spWeight_Adjustments", parameterslist);
        }

        public static Int32 InsertMissionNotification(UserMissionsBAL objUserMissionsBAL)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@MN_ID",
                    TextValue = Convert.ToInt32(objUserMissionsBAL.MN_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_mission_id",
                    TextValue = Convert.ToInt32(objUserMissionsBAL.fk_mission_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objUserMissionsBAL.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@MN_DATE",
                    TextValue = (objUserMissionsBAL.MN_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@MN_NOTIFICATION_STATUS",
                    TextValue = (objUserMissionsBAL.MN_NOTIFICATION_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@MN_EMAIL_STATUS",
                    TextValue = (objUserMissionsBAL.MN_EMAIL_STATUS).ToString()
                });
              
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objUserMissionsBAL.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInsertMissionNotification", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }


        public static DataTable BindNotifications(UserMissionsBAL objUserMissionsBAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_id",
                TextValue = objUserMissionsBAL.fk_user_registration_id.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@date",
                TextValue = objUserMissionsBAL.date.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objUserMissionsBAL.ProcedureType.ToString()
            });

       
            return sqlhelper.getRecords("SpViewNotifications", parameterslist);
        }

     
    }
}
