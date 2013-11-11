using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAL.User
{
  public   class UserInspiratorsBAL
  {
      #region "Data Members"

      private object _pk_Inspirator_id = string.Empty;
        private object _Inspirator_image = string.Empty;
        private object _Inspirator_desc = string.Empty;
        private object _fk_user_registration_Id = string.Empty;
        private object _Inspirator_createdon = string.Empty;
        private object _Fk_Inspirator_status_id = string.Empty;
        private object _fk_circle_id = string.Empty;
        private object _fk_user_circle_id = string.Empty;

        private object _fk_Inspirator_id = string.Empty;
        private object _pk_InspiratorLiked_id = string.Empty;
        private object _InspiratorLiked_on = string.Empty;
        private object _pk_InspiratorComments_id = string.Empty;
        private object _InspiratorComment_text = string.Empty;
        private object _InspiratorComment_on = string.Empty;
        private object _userid = string.Empty;
        private object _pk_InspiratorInappro_id = string.Empty;
        private object _InspiratorInappro_on = string.Empty;
        private object _page_index = string.Empty;
        private object _page_size = string.Empty;
        private object _pk_inspiratorLib_id = string.Empty;
        private object _inspiratorLib_createdon = string.Empty;
        private object _Friend_id = string.Empty;
        private object _ID = string.Empty;
        private object _ProcedureType = string.Empty;

        private object _IN_ID = string.Empty;
        private object _IN_DATE = string.Empty;
        private object _IN_NOTIFICATION_STATUS = string.Empty;
        private object _fk_user_registration_id = string.Empty;
        private object _IN_EMAIL_STATUS = string.Empty;
        private object _LIKE_STATUS = string.Empty;

      #endregion


      #region "Data Members Properties"
        public object pk_Inspirator_id
        {
            get { return _pk_Inspirator_id; }
            set { _pk_Inspirator_id = value; }
        }
        public object Inspirator_image
        {
            get { return _Inspirator_image; }
            set { _Inspirator_image = value; }
        }
        public object Inspirator_desc 
        {
            get { return _Inspirator_desc; }
            set { _Inspirator_desc = value; }
        }
        public object fk_user_registration_Id
        {
            get { return _fk_user_registration_Id; }
            set { _fk_user_registration_Id = value; }
        }
        public object Inspirator_createdon
        {
            get { return _Inspirator_createdon; }
            set { _Inspirator_createdon = value; }
        }
        public object Fk_Inspirator_status_id
        {
            get { return _Fk_Inspirator_status_id; }
            set { _Fk_Inspirator_status_id = value; }
        }

        public object fk_circle_id
        {
            get { return _fk_circle_id; }
            set { _fk_circle_id = value; }
        }


        public object fk_user_circle_id
        {
            get { return _fk_user_circle_id; }
            set { _fk_user_circle_id = value; }
        }
        public object fk_Inspirator_id
        {
            get { return _fk_Inspirator_id; }
            set { _fk_Inspirator_id = value; }
        }
        public object pk_InspiratorLiked_id
        {
            get { return _pk_InspiratorLiked_id; }
            set { _pk_InspiratorLiked_id = value; }
        }
        public object InspiratorLiked_on
        {
            get { return _InspiratorLiked_on; }
            set { _InspiratorLiked_on = value; }
        }
        public object pk_InspiratorComments_id
        {
            get { return _pk_InspiratorComments_id; }
            set { _pk_InspiratorComments_id = value; }
        }
        public object InspiratorComment_text
        {
            get { return _InspiratorComment_text; }
            set { _InspiratorComment_text = value; }
        }
        public object InspiratorComment_on
        {
            get { return _InspiratorComment_on; }
            set { _InspiratorComment_on = value; }
        }
        public object userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public object pk_InspiratorInappro_id
        {
            get { return _pk_InspiratorInappro_id; }
            set { _pk_InspiratorInappro_id = value; }
        }
        public object InspiratorInappro_on
        {
            get { return _InspiratorInappro_on; }
            set { _InspiratorInappro_on = value; }
        }
        public object page_index
        {
            get { return _page_index; }
            set { _page_index = value; }
        }
        public object page_size
        {
            get { return _page_size; }
            set { _page_size = value; }
        }
        public object pk_inspiratorLib_id
        {
            get { return _pk_inspiratorLib_id; }
            set { _pk_inspiratorLib_id = value; }
        }
        public object inspiratorLib_createdon
        {
            get { return _inspiratorLib_createdon; }
            set { _inspiratorLib_createdon = value; }
        }

        public object Friend_id
        {
            get { return _Friend_id; }
            set { _Friend_id = value; }
        }
        public object ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public object ProcedureType
        {
            get { return _ProcedureType; }
            set { _ProcedureType = value; }
        }


        public object IN_ID
        {
            get { return _IN_ID; }
            set { _IN_ID = value; }
        }
        public object IN_DATE
        {
            get { return _IN_DATE; }
            set { _IN_DATE = value; }
        }
        public object IN_NOTIFICATION_STATUS
        {
            get { return _IN_NOTIFICATION_STATUS; }
            set { _IN_NOTIFICATION_STATUS = value; }
        }
        public object fk_user_registration_id
        {
            get { return _fk_user_registration_id; }
            set { _fk_user_registration_id = value; }
        }
        public object IN_EMAIL_STATUS
        {
            get { return _IN_EMAIL_STATUS; }
            set { _IN_EMAIL_STATUS = value; }
        }

        public object LIKE_STATUS
        {
            get { return _LIKE_STATUS; }
            set { _LIKE_STATUS = value; }
        }
      #endregion

  }
}
