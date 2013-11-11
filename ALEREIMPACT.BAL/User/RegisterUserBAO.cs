using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ALEREIMPACT.BAL.User
{
    public class RegisterUserBAO
    {

        #region variables declaration
        private Int32 login_Id = 0;
        private string login_email = string.Empty;
        private string login_password = string.Empty;
        private string user_role_id = string.Empty;
        private string password_salt = string.Empty;
        private bool is_password_changed;
        private int login_status = 0;
   
        private object _user_code = string.Empty;
        private string first_name = string.Empty;
        private string last_name = string.Empty;
        private string user_address = string.Empty;
        private int yearOfbirth;
        private int monthOfBirth;
        private int dateOfBirth;
        private string user_image = string.Empty;
        private int location_id = 0;

        private int height_units = 0;
        private int weight_units = 0;
        private int height_inches = 0;

        private int zip = 0;

        private string gender = string.Empty;

        private string home_contact_1 = string.Empty;
        private string home_contact_2 = string.Empty;
        private string office_contact = string.Empty;
        private string mobile_number = string.Empty;
        private decimal height = 0;
        private int weight = 0;
        private int registration_type_id = 0;
        private bool has_profile_added;
        private Int32 pk_user_registration_Id = 0;
        private string ProcedureType = string.Empty;
        private Int32 preference_options = 0;
        private Int32 days_suggested_by_user = 0;

        private object _AT_ID = string.Empty;
        private object _fk_user_registration_Id = string.Empty;
        private object _AT_LOGINTIME = string.Empty;
        private object _AT_LOGOUTTIME = string.Empty;
        private object _AT_DATE = string.Empty;
        private object _AT_LOGIN_STATUS = string.Empty;
        private object _AT_FAILUREREASON = string.Empty;
         private object _AT_ONLINE = string.Empty;
         private object _ID = string.Empty;
         private object _UI_ID = string.Empty;
         private object _fk_user_registration_id = string.Empty;
         private object _UI_USER_MAIL_ID = string.Empty;
         private object _UI_STATUS = string.Empty;
         private object _UI_CODE = string.Empty;
         private object _UI_DATE = string.Empty;
         private object _UI_MAIL_STATUS = string.Empty;

         private object _ER_ID = string.Empty;
         private object _PAGE_ID_FK = string.Empty;
         private object _ER_MESSAGE = string.Empty;
         private object _ER_IMAGE = string.Empty;
         private object _ER_POST_DATE = string.Empty;
         private object _ER_STATUS = string.Empty;

          private object _FB_ID = string.Empty;
         private object _FB_MESSAGE = string.Empty;
         private object _FB_DATE = string.Empty;
         private object _FB_RATING = string.Empty;
         private object _FB_STATUS = string.Empty;

         private object _T_ID = string.Empty;
         private object _T_MESSAGE = string.Empty;
         private object _T_REPLYSTATUS = string.Empty;
         private object _T_DATE = string.Empty;
         private object _T_STATUS = string.Empty;

         private decimal _body_weight = 0;
         private decimal _body_mass = 0;
         private decimal _body_fat = 0;
         private string _log_date = string.Empty;

         private object _SUPPORT_ID = string.Empty;
         private object _SUPPORT_NAME = string.Empty;
         private object _SUPPORT_EMAIL = string.Empty;
         private object _SUPPORT_MESSAGE = string.Empty;
         private object _SUPPORT_DATE = string.Empty;

         private object _RS_ID_FK = string.Empty;
         private object _EDU_ID_FK = string.Empty;
         private object _WP_ID_FK = string.Empty;
         private object _INTEREST_ID_FK = string.Empty;
         private object _RELIGION_ID_FK = string.Empty;

         private string _accessToken = string.Empty;
         private string _accessTokenSecret = string.Empty;

         private XmlDocument _xmlToSave;

         private object _JOURNAL_ID = string.Empty;
         private object _MOOD_ID_FK = string.Empty;
         private object _JOURNAL_TITLE = string.Empty;
         private object _JOURNAL_CONTENT = string.Empty;
         private object _JOURNAL_DATE = string.Empty;

        #endregion

        #region Properties


        public Int32 LoginId
        {
            get { return login_Id; }
            set { login_Id = value; }
        }
        public string LoginEmail
        {
            get { return login_email; }
            set { login_email = value; }
        }
        public string LoginPassword
        {
            get { return login_password; }
            set { login_password = value; }
        }
        public string UserRoleId
        {
            get { return user_role_id; }
            set { user_role_id = value; }
        }
        public string PasswordSalt
        {
            get { return password_salt; }
            set { password_salt = value; }
        }

        public bool IsPasswordChanged
        {
            get { return is_password_changed; }
            set { is_password_changed = value; }
        }

        public int LoginStatus
        {
            get { return login_status; }
            set { login_status = value; }
        }



        public object user_code
        {
            get { return _user_code; }
            set { _user_code = value; }
        }
        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }
        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }
        public string UserAddress
        {
            get { return user_address; }
            set { user_address = value; }
        }
        public int YearOfBirth
        {
            get { return yearOfbirth; }
            set { yearOfbirth = value; }
        }
        public int MonthOfBirth
        {
            get { return monthOfBirth; }
            set { monthOfBirth = value; }
        }
        public int DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public string UserImage
        {
            get { return user_image; }
            set { user_image = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int LocationId
        {
            get { return location_id; }
            set { location_id = value; }
        }

        public int Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public string HomeContact1
        {
            get { return home_contact_1; }
            set { home_contact_1 = value; }
        }

        public string HomeContact2
        {
            get { return home_contact_2; }
            set { home_contact_2 = value; }
        }
        public string OfficeContact
        {
            get { return office_contact; }
            set { office_contact = value; }
        }
        public string MobileNumber
        {
            get { return mobile_number; }
            set { mobile_number = value; }
        }


        public decimal Height
        {
            get { return height; }
            set { height = value; }
        }
        public int HeightInches
        {
            get { return height_inches; }
            set { height_inches = value; }
        }


        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int RegistrationTypeId
        {
            get { return registration_type_id; }
            set { registration_type_id = value; }
        }

        public bool HasProfileAdded
        {
            get { return has_profile_added; }
            set { has_profile_added = value; }
        }
        public Int32 user_registration_Id
        {
            get { return pk_user_registration_Id; }
            set { pk_user_registration_Id = value; }
        }

        public string procedureType
        {
            get { return ProcedureType; }
            set { ProcedureType = value; }
        }


        public Int32 Days_Suggested_By_User
        {
            get { return days_suggested_by_user; }
            set { days_suggested_by_user = value; }
        }
        public Int32 PreferenceOptions
        {
            get { return preference_options; }
            set { preference_options = value; }
        }

        public Int32 HeightUnits
        {
            get { return height_units; }
            set { height_units = value; }
        }
        public Int32 WeightUnits
        {
            get { return weight_units; }
            set { weight_units = value; }
        }


        public object AT_ID
        {
            get { return _AT_ID; }
            set { _AT_ID = value; }
        }
        public object fk_user_registration_Id
        {
            get { return _fk_user_registration_Id; }
            set { _fk_user_registration_Id = value; }
        }
        public object AT_LOGINTIME
        {
            get { return _AT_LOGINTIME; }
            set { _AT_LOGINTIME = value; }
        }
        public object AT_LOGOUTTIME
        {
            get { return _AT_LOGOUTTIME; }
            set { _AT_LOGOUTTIME = value; }
        }
        public object AT_DATE
        {
            get { return _AT_DATE; }
            set { _AT_DATE = value; }
        }
        public object AT_LOGIN_STATUS
        {
            get { return _AT_LOGIN_STATUS; }
            set { _AT_LOGIN_STATUS = value; }
        }
        public object AT_FAILUREREASON
        {
            get { return _AT_FAILUREREASON; }
            set { _AT_FAILUREREASON = value; }
        }
        public object AT_ONLINE
        {
            get { return _AT_ONLINE; }
            set { _AT_ONLINE = value; }
        }
        public object ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public object UI_ID
        {
            get { return _UI_ID; }
            set { _UI_ID = value; }
        }
        public object fk_user_registration_id
        {
            get { return _fk_user_registration_id; }
            set { _fk_user_registration_id = value; }
        }
        public object UI_USER_MAIL_ID
        {
            get { return _UI_USER_MAIL_ID; }
            set { _UI_USER_MAIL_ID = value; }
        }
        public object UI_STATUS
        {
            get { return _UI_STATUS; }
            set { _UI_STATUS = value; }
        }
        public object UI_CODE
        {
            get { return _UI_CODE; }
            set { _UI_CODE = value; }
        }
        public object UI_DATE
        {
            get { return _UI_DATE; }
            set { _UI_DATE = value; }
        }
        public object UI_MAIL_STATUS
        {
            get { return _UI_MAIL_STATUS; }
            set { _UI_MAIL_STATUS = value; }
        }

        public object ER_ID
        {
            get { return _ER_ID; }
            set { _ER_ID = value; }
        }
        public object PAGE_ID_FK
        {
            get { return _PAGE_ID_FK; }
            set { _PAGE_ID_FK = value; }
        }
        public object ER_MESSAGE
        {
            get { return _ER_MESSAGE; }
            set { _ER_MESSAGE = value; }
        }
        public object ER_IMAGE
        {
            get { return _ER_IMAGE; }
            set { _ER_IMAGE = value; }
        }
        public object ER_POST_DATE
        {
            get { return _ER_POST_DATE; }
            set { _ER_POST_DATE = value; }
        }
        public object ER_STATUS
        {
            get { return _ER_STATUS; }
            set { _ER_STATUS = value; }
        }



        public object FB_ID
        {
            get { return _FB_ID; }
            set { _FB_ID = value; }
        }
        public object FB_MESSAGE
        {
            get { return _FB_MESSAGE; }
            set { _FB_MESSAGE = value; }
        }
        public object FB_DATE
        {
            get { return _FB_DATE; }
            set { _FB_DATE = value; }
        }
        public object FB_RATING
        {
            get { return _FB_RATING; }
            set { _FB_RATING = value; }
        }
        public object FB_STATUS
        {
            get { return _FB_STATUS; }
            set { _FB_STATUS = value; }
        }
        public object T_ID
        {
            get { return _T_ID; }
            set { _T_ID = value; }

        }
        public object T_MESSAGE
        {
            get { return _T_MESSAGE; }
            set { _T_MESSAGE = value; }
        }
        public object T_REPLYSTATUS
        {
            get { return _T_REPLYSTATUS; }
            set { _T_REPLYSTATUS = value; }
        }
        public object T_DATE
        {
            get { return _T_DATE; }
            set { _T_DATE = value; }
        }
        public object T_STATUS
        {
            get { return _T_STATUS; }
            set { _T_STATUS = value; }
        }




        public object SUPPORT_ID
        {
            get { return _SUPPORT_ID; }
            set { _SUPPORT_ID = value; }
        }
        public object SUPPORT_NAME
        {
            get { return _SUPPORT_NAME; }
            set { _SUPPORT_NAME = value; }
        }
        public object SUPPORT_EMAIL
        {
            get { return _SUPPORT_EMAIL; }
            set { _SUPPORT_EMAIL = value; }
        }
        public object SUPPORT_MESSAGE
        {
            get { return _SUPPORT_MESSAGE; }
            set { _SUPPORT_MESSAGE = value; }
        }
        public object SUPPORT_DATE
        {
            get { return _SUPPORT_DATE; }
            set { _SUPPORT_DATE = value; }
        }




        public object RS_ID_FK
        {
            get { return _RS_ID_FK; }
            set { _RS_ID_FK = value; }
        }


        public object EDU_ID_FK
        {
            get { return _EDU_ID_FK; }
            set { _EDU_ID_FK = value; }
        }


        public object WP_ID_FK
        {
            get { return _WP_ID_FK; }
            set { _WP_ID_FK = value; }
        }
        public object INTEREST_ID_FK
        {
            get { return _INTEREST_ID_FK; }
            set { _INTEREST_ID_FK = value; }
        }
        public object RELIGION_ID_FK
        {
            get { return _RELIGION_ID_FK; }
            set { _RELIGION_ID_FK = value; }
        }
        



        public string AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }
        public string AccessTokenSecret
        {
            get { return _accessTokenSecret; }
            set { _accessTokenSecret = value; }
        }




        public decimal FitBitBodyWeight
        {
            get { return _body_weight; }
            set { _body_weight = value; }
        }

        public decimal FitBitBodyMass
        {
            get { return _body_mass; }
            set { _body_mass = value; }
        }
        public decimal FitBitBodyFat
        {
            get { return _body_fat; }
            set { _body_fat = value; }
        }
        public string FitBitBodyInfoLogDate
        {
            get { return _log_date; }
            set { _log_date = value; }
        }

        public object JOURNAL_ID
        {
            get { return _JOURNAL_ID; }
            set { _JOURNAL_ID = value; }
        }
        public object MOOD_ID_FK
        {
            get { return _MOOD_ID_FK; }
            set { _MOOD_ID_FK = value; }
        }
        public object JOURNAL_TITLE
        {
            get { return _JOURNAL_TITLE; }
            set { _JOURNAL_TITLE = value; }
        }
        public object JOURNAL_CONTENT
        {
            get { return _JOURNAL_CONTENT; }
            set { _JOURNAL_CONTENT = value; }
        }
        public object JOURNAL_DATE
        {
            get { return _JOURNAL_DATE; }
            set { _JOURNAL_DATE = value; }
        }
        #endregion
    }
}

