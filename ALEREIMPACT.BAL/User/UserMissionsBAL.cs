using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAL.User
{
    public class UserMissionsBAL
    {
        #region variables declaration

        private string created_by_name = string.Empty;
        private Int32 get_invited_to_id = 0;
        private Int32 type_of_request = 0;
        private Int32 periodic_type = 0;
        private Int32 group_individual = 0;
        private Int32 public_private = 0;
        private Int32 date_Id = 0;
        private int weight_units = 0;
        private Int32 circle_Id = 0;
        private Int32 login_Id = 0;
        private Int32 user_id_for_name = 0;
        private string all_friends_id = string.Empty;
        private object _fk_User_Circle_id = string.Empty;

        private Int32 steps_covered = 0;
        private string activity_performed = string.Empty;
        private Int32 activity_id = 0;
        private Int32 duration_in_hours = 0;
        private Int32 duration_in_minutes = 0;
        private Int32 duration_in_seconds = 0;
        private string distance_units = string.Empty;
        private decimal distance_covered = 0;

        private string mission_name = string.Empty;
        private Int32 mission_Id = 0;
        private Int32 pk_mission_type_Id = 0;
        private Int32 pk_mission_theme_Id = 0;
        private DateTime age_entered;
        private decimal height_entered = 0;
        private decimal weight_entered = 0;
        private DateTime dateOfCompletion;
        private decimal calories_Burnt = 0;
        private decimal calories_Eaten = 0;
        private decimal total_calories_to_burn = 0;
        private Int32 preference_options = 0;
        private string invitation_message = string.Empty;

        private int pk_mission_invitation_id = 0;
        private bool invitation_status;
        private bool invitation_read;


        private Int32 pk_user_log_id = 0;
        private Int32 request_type = 0;
        private Int32 FA_ID = 0;
        private Int32 fk_mission_log_id = 0;
        private Int32 FA_CAL_BURNS = 0;
        private Int32 Mission_Graphs_Interval = 0;
        private DateTime FA_DATE;
        private object _ProcedureType = string.Empty;

        private string graphDateFrom = string.Empty;
        private string graphDateTo = string.Empty;
        private decimal _floors_covered = 0;



        private object _MN_ID = string.Empty;
        private object _fk_mission_id = string.Empty;
        private object _fk_user_registration_id = string.Empty;
        private object _MN_DATE = string.Empty;
        private object _MN_NOTIFICATION_STATUS = string.Empty;
        private object _MN_EMAIL_STATUS = string.Empty;
        private object _date = string.Empty;

        #endregion

        #region Properties
        public Int32 LoginId
        {
            get { return login_Id; }
            set { login_Id = value; }
        }
        public string MissionName
        {
            get { return mission_name; }
            set { mission_name = value; }
        }
        public Int32 MissionTypeId
        {
            get { return pk_mission_type_Id; }
            set { pk_mission_type_Id = value; }
        }
        public Int32 MissionThemeId
        {
            get { return pk_mission_theme_Id; }
            set { pk_mission_theme_Id = value; }
        }
        public DateTime DateOfCompletion
        {
            get { return dateOfCompletion; }
            set { dateOfCompletion = value; }
        }

        public DateTime AgeEntered
        {
            get { return age_entered; }
            set { age_entered = value; }
        }
        public decimal WeightEntered
        {
            get { return weight_entered; }
            set { weight_entered = value; }
        }
        public decimal HeightEntered
        {
            get { return height_entered; }
            set { height_entered = value; }
        }
        public decimal CaloriesBurnt
        {
            get { return calories_Burnt; }
            set { calories_Burnt = value; }
        }
        public decimal CaloriesEaten
        {
            get { return calories_Eaten; }
            set { calories_Eaten = value; }
        }
        public decimal TotalCaloriesToBurn
        {
            get { return total_calories_to_burn; }
            set { total_calories_to_burn = value; }
        }

        public Int32 MissionId
        {
            get { return mission_Id; }
            set { mission_Id = value; }
        }
        public Int32 PreferenceOptions
        {
            get { return preference_options; }
            set { preference_options = value; }
        }

        public Int32 WeightUnits
        {
            get { return weight_units; }
            set { weight_units = value; }
        }
        public Int32 CircleId
        {
            get { return circle_Id; }
            set { circle_Id = value; }
        }
        public Int32 DateId
        {
            get { return date_Id; }
            set { date_Id = value; }
        }
        public Int32 Periodic_Selection
        {
            get { return periodic_type; }
            set { periodic_type = value; }
        }
        public Int32 User_id_For_Name
        {
            get { return user_id_for_name; }
            set { user_id_for_name = value; }
        }

        public Int32 Group_Individual
        {
            get { return group_individual; }
            set { group_individual = value; }
        }

        public Int32 Public_Private
        {
            get { return public_private; }
            set { public_private = value; }
        }
        public string AllFriends_Id
        {
            get { return all_friends_id; }
            set { all_friends_id = value; }
        }
        public string CreatedByName
        {
            get { return created_by_name; }
            set { created_by_name = value; }
        }
        public string InvitationMessage
        {
            get { return invitation_message; }
            set { invitation_message = value; }
        }
        public int TypeOfRequest
        {
            get { return type_of_request; }
            set { type_of_request = value; }
        }

        public int GetInvitedToId
        {
            get { return get_invited_to_id; }
            set { get_invited_to_id = value; }
        }

        public int Pk_mission_Invitation
        {
            get { return pk_mission_invitation_id; }
            set { pk_mission_invitation_id = value; }
        }



        public bool Mission_Invitation_Status
        {
            get { return invitation_status; }
            set { invitation_status = value; }
        }

        public bool InvitationRead_Status
        {
            get { return invitation_read; }
            set { invitation_read = value; }
        }



        public int Request_Type
        {
            get { return request_type; }
            set { request_type = value; }
        }

        public int Pk_user_Log_Id
        {
            get { return pk_user_log_id; }
            set { pk_user_log_id = value; }
        }

        public string Activity_Performed
        {
            get { return activity_performed; }
            set { activity_performed = value; }
            
        }


        public Int32 Activity_Id
        {
            get { return activity_id; }
            set { activity_id = value; }

        }
        public Int32 Activity_Hours
        {
            get { return duration_in_hours; }
            set { duration_in_hours = value; }

        }
        public Int32 Activity_minutes
        {
            get { return duration_in_minutes; }
            set { duration_in_minutes = value; }

        }
        public Int32 Activity_Seconds
        {
            get { return duration_in_seconds; }
            set { duration_in_seconds = value; }

        }

        public string Distance_Units
        {
            get { return distance_units; }
            set { distance_units = value; }
        }

        public decimal Distance_Covered
        {
            get { return distance_covered; }
            set { distance_covered = value; }

        }



        public Int32 fav_ID
        {
            get { return FA_ID; }
            set { FA_ID = value; }

        }
        public Int32 Fk_mission_log_id
        {
            get { return fk_mission_log_id; }
            set { fk_mission_log_id = value; }

        }
        public Int32 fa_CAL_BURNS
        {
            get { return FA_CAL_BURNS; }
            set { FA_CAL_BURNS = value; }

        }

        public DateTime fa_date
        {
            get { return FA_DATE; }
            set { FA_DATE = value; }
        }

        public object ProcedureType
        {
            get { return _ProcedureType; }
            set { _ProcedureType = value; }
        }
        public object fk_User_Circle_id
        {
            get { return _fk_User_Circle_id; }
            set { _fk_User_Circle_id = value; }
        }
        public Int32 StepsCovered
        {
            get { return steps_covered; }
            set { steps_covered = value; }

        }

        public string Graph_DateFrom
        {
            get { return graphDateFrom; }
            set { graphDateFrom = value; }
        }
        public string Graph_DateTo
        {
            get { return graphDateTo; }
            set { graphDateTo = value; }
        }


        public decimal Floors_Covered
        {
            get { return _floors_covered; }
            set { _floors_covered = value; }
        }



        public object MN_ID
        {
            get { return _MN_ID; }
            set { _MN_ID = value; }
        }
        public object fk_mission_id
        {
            get { return _fk_mission_id; }
            set { _fk_mission_id = value; }
        }
        public object fk_user_registration_id
        {
            get { return _fk_user_registration_id; }
            set { _fk_user_registration_id = value; }
        }
        public object MN_DATE
        {
            get { return _MN_DATE; }
            set { _MN_DATE = value; }
        }
        public object MN_NOTIFICATION_STATUS
        {
            get { return _MN_NOTIFICATION_STATUS; }
            set { _MN_NOTIFICATION_STATUS = value; }
        }
        public object MN_EMAIL_STATUS
        {
            get { return _MN_EMAIL_STATUS; }
            set { _MN_EMAIL_STATUS = value; }
        }
        public object date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion

    }
}
