using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAO.Circles
{
   public class UserCirclesBAO
    {
        #region variables declaration


        private object _UserId = string.Empty;
        private object _pk_circle_id = string.Empty;
        private object _circle_name = string.Empty;
        private object _pk_user_circle_id = string.Empty;
        private object _fk_circle_id = string.Empty;

        private object _fk_user_registration_Id = string.Empty;
        private object _fk_circle_permission_id = string.Empty;
        private object _circle_image = string.Empty;
        private object _circle_color = string.Empty;
        private object _circle_create_date = string.Empty;
        private object _friend_registration_id = string.Empty; // add new friend
        private object _request_status = string.Empty;          // add new friend
        private object _updated_on = string.Empty;              // add new friend
        private object _ID = string.Empty;
        private object _proceduretype = string.Empty;

        private object _userRegistration_ID = string.Empty;
        private object _userfriend_ID = string.Empty;
        private object _fk_circle_ID = string.Empty;
        private object _fk_circlePermission_ID = string.Empty;


        private object _CI_ID = string.Empty;
        private object _fk_login_id = string.Empty;
        private object _freind_user_id = string.Empty;
        private object _CI_MESSAGE = string.Empty;
        private object _CI_DATE = string.Empty;
        private object _CI_STATUS = string.Empty;


        private object _Prefixtext = string.Empty;


        #endregion

        #region Properties

        public object UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public object pk_circle_id
        {
            get { return _pk_circle_id; }
            set { _pk_circle_id = value; }
        }
        public object circle_name
        {
            get { return _circle_name; }
            set { _circle_name = value; }
        }
        public object pk_user_circle_id
        {
            get { return _pk_user_circle_id; }
            set { _pk_user_circle_id = value; }
        }
        public object fk_circle_id
        {
            get { return _fk_circle_id; }
            set { _fk_circle_id = value; }
        }
        public object fk_user_registration_Id
        {
            get { return _fk_user_registration_Id; }
            set { _fk_user_registration_Id = value; }
        }
        public object fk_circle_permission_id
        {
            get { return _fk_circle_permission_id; }
            set { _fk_circle_permission_id = value; }
        }
        public object circle_image
        {
            get { return _circle_image; }
            set { _circle_image = value; }
        }
        public object circle_color
        {
            get { return _circle_color; }
            set { _circle_color = value; }
        }
        public object circle_create_date
        {
            get { return _circle_create_date; }
            set { _circle_create_date = value; }
        }
        public object friend_registration_id
        {
            get { return _friend_registration_id; }
            set { _friend_registration_id = value; }
        }
        public object request_status
        {
            get { return _request_status; }
            set { _request_status = value; }
        }
        public object updated_on
        {
            get { return _updated_on; }
            set { _updated_on = value; }
        }

        public object ID
        {
            get { return _ID; }
            set { _ID = value; }
        } 
        public object proceduretype
        {
            get { return _proceduretype; }
            set { _proceduretype = value; }
        }

        public object userRegistration_ID
        {
            get { return _userRegistration_ID; }
            set { _userRegistration_ID = value; }
        }

        public object userfriend_ID
        {
            get { return _userfriend_ID; }
            set { _userfriend_ID = value; }
        }

        public object fk_circle_ID
        {
            get { return _fk_circle_ID; }
            set { _fk_circle_ID = value; }
        }

        public object fk_circlePermission_ID
        {
            get { return _fk_circlePermission_ID; }
            set { _fk_circlePermission_ID = value; }
        }




        public object CI_ID
        {
            get { return _CI_ID; }
            set { _CI_ID = value; }
        }

        public object fk_login_id
        {
            get { return _fk_login_id; }
            set { _fk_login_id = value; }
        }

        public object freind_user_id
        {
            get { return _freind_user_id; }
            set { _freind_user_id = value; }
        }

        public object CI_MESSAGE
        {
            get { return _CI_MESSAGE; }
            set { _CI_MESSAGE = value; }
        }
        public object CI_DATE
        {
            get { return _CI_DATE; }
            set { _CI_DATE = value; }
        }
        public object CI_STATUS
        {
            get { return _CI_STATUS; }
            set { _CI_STATUS = value; }
        }
        public object Prefixtext
        {
            get { return _Prefixtext; }
            set { _Prefixtext = value; }
        }

        #endregion
    }
}
