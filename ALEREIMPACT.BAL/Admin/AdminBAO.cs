using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAO.Admin
{
   public  class AdminBAO
   {
       #region "Data Members"
       private object _login_email = string.Empty;
       private object _login_password = string.Empty;
       private object _pk_user_registration_Id = string.Empty;
       private object _ID = string.Empty;
       private object _ID1 = string.Empty;
       private object _ID2 = string.Empty;
       private object _fk_user_status_id = string.Empty;
       private object _fk_user_registration_Id = string.Empty;
       private object _fk_circle_id = string.Empty;
       private object _pk_circle_id = string.Empty;
       private object _fk_Inspirator_id = string.Empty;
       private object _name= string.Empty;
       private object _name1 = string.Empty;
       private object _pk_Inspirator_id = string.Empty;
       private object _Inspirator_image = string.Empty;
       private object _Inspirator_desc = string.Empty;
       private object _Inspirator_createdon = string.Empty;
       private object _Fk_Inspirator_status_id = string.Empty;
       private object _GROUP_ID = string.Empty;
       private object _GROUP_NAME = string.Empty;
       private object _GUD_ID = string.Empty;
       private object _GROUP_ID_FK = string.Empty;
       private object _user_id = string.Empty;
       private object _GM_ID = string.Empty;
       private object _fk_user_registration_id = string.Empty;
       private object _GM_MESSAGE = string.Empty;
       private object _GM_DATE = string.Empty;
       private object _GM_READ_ID = string.Empty;
       private object _AC_ID = string.Empty;
       private object _AC_COMMENT = string.Empty;
       private object _AC_COMMENT_ON = string.Empty;
       private object _fk_Admin_user_registration_Id = string.Empty;
       private object _AT_ID = string.Empty;
       private object _AT_LOGINTIME = string.Empty;
       private object _AT_LOGOUTTIME = string.Empty;
       private object _AT_DATE = string.Empty;
       private object _AT_LOGIN_STATUS = string.Empty;
       private object _AT_FAILUREREASON = string.Empty;


       private object _UI_ID = string.Empty;
       private object _UI_USER_MAIL_ID = string.Empty;
       private object _UI_STATUS = string.Empty;
       private object _UI_CODE = string.Empty;
       private object _UI_DATE = string.Empty;
       private object _UI_MAIL_STATUS = string.Empty;

       private object _TR_ID = string.Empty;
       private object _T_ID_FK = string.Empty;
       private object _TR_REPLY = string.Empty;
       private object _TR_DATE = string.Empty;

       private object _T_ID = string.Empty;
       private object _T_MESSAGE = string.Empty;
       private object _T_REPLYSTATUS = string.Empty;
       private object _T_DATE = string.Empty;
       private object _T_STATUS = string.Empty;
       private object _date1 = string.Empty;
       private object _date2 = string.Empty;

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


       private object _ProcedureType = string.Empty;

       private object _Personalization_types_Images_Id = string.Empty;
       private object _Personalization_types_Image = string.Empty;


       private object _fk_login_id = string.Empty;
       private object _login_user_Id = string.Empty;
       private object _fk_mission_id = string.Empty;
       private object _fk_user_circle_id = string.Empty;
       private object _FromDate = string.Empty;
       private object _ToDate = string.Empty;
       private object _GM_WM = string.Empty;


       #endregion

       #region "Data Members Properties"
       public object login_email
       {
           get { return _login_email; }
           set { _login_email = value; }
       }
       public object login_password
       {
           get { return _login_password; }
           set { _login_password = value; }
       }
       public object pk_user_registration_Id
       {
           get { return _pk_user_registration_Id; }
           set { _pk_user_registration_Id = value; }
       }
       public object ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
       public object ID1
       {
           get { return _ID1; }
           set { _ID1 = value; }
       }
       public object ID2
       {
           get { return _ID2; }
           set { _ID2 = value; }
       }
       public object fk_user_status_id
       {
           get { return _fk_user_status_id; }
           set { _fk_user_status_id = value; }
       }
       public object fk_user_registration_Id
       {
           get { return _fk_user_registration_Id; }
           set { _fk_user_registration_Id = value; }
       }
       public object fk_circle_id
       {
           get { return _fk_circle_id; }
           set { _fk_circle_id = value; }
       }
       public object pk_circle_id
       {
           get { return _pk_circle_id; }
           set { _pk_circle_id = value; }
       }
       public object fk_Inspirator_id
       {
           get { return _fk_Inspirator_id; }
           set { _fk_Inspirator_id = value; }
       }
       public object name
       {
           get { return _name; }
           set { _name = value; }
       }
       public object name1
       {
           get { return _name1; }
           set { _name1 = value; }
       }
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
       public object GROUP_ID
       {
           get { return _GROUP_ID; }
           set { _GROUP_ID = value; }
       }
       public object GROUP_NAME
       {
           get { return _GROUP_NAME; }
           set { _GROUP_NAME = value; }
       }
       public object GUD_ID
       {
           get { return _GUD_ID; }
           set { _GUD_ID = value; }
       }
       public object GROUP_ID_FK
       {
           get { return _GROUP_ID_FK; }
           set { _GROUP_ID_FK = value; }
       }
       public object user_id
       {
           get { return _user_id; }
           set { _user_id = value; }
       }
       public object GM_ID
       {
           get { return _GM_ID; }
           set { _GM_ID = value; }
       }
       public object fk_user_registration_id
       {
           get { return _fk_user_registration_id; }
           set { _fk_user_registration_id = value; }
       }
       public object GM_MESSAGE
       {
           get { return _GM_MESSAGE; }
           set { _GM_MESSAGE = value; }
       }
       public object GM_DATE
       {
           get { return _GM_DATE; }
           set { _GM_DATE = value; }
       }
    
       public object AC_ID
       {
           get { return _AC_ID; }
           set { _AC_ID = value; }
       }
       public object AC_COMMENT
       {
           get { return _AC_COMMENT; }
           set { _AC_COMMENT = value; }
       }
       public object AC_COMMENT_ON
       {
           get { return _AC_COMMENT_ON; }
           set { _AC_COMMENT_ON = value; }
       }
       public object fk_Admin_user_registration_Id
       {
           get { return _fk_Admin_user_registration_Id; }
           set { _fk_Admin_user_registration_Id = value; }
       }
       public object AT_ID
       {
           get { return _AT_ID; }
           set { _AT_ID = value; }
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



       public object UI_ID
       {
           get { return _UI_ID; }
           set { _UI_ID = value; }
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


       public object TR_ID
       {
           get { return _TR_ID; }
           set { _TR_ID = value; }
       }
       public object T_ID_FK
       {
           get { return _T_ID_FK; }
           set { _T_ID_FK = value; }
       }
       public object TR_REPLY
       {
           get { return _TR_REPLY; }
           set { _TR_REPLY = value; }
       }
       public object TR_DATE
       {
           get { return _TR_DATE; }
           set { _TR_DATE = value; }
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
       public object date1
       {
           get { return _date1; }
           set { _date1 = value; }
       }
       public object date2 
       {
           get { return _date2; }
           set { _date2 = value; }
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

       public object ProcedureType
       {
           get { return _ProcedureType; }
           set { _ProcedureType = value; }
       }

       public object PersonalizationTypesImagesId
       {
           get { return _Personalization_types_Images_Id; }
           set { _Personalization_types_Images_Id = value; }
       }

       public object PersonalizationTypesImage
       {
           get { return _Personalization_types_Image; }
           set { _Personalization_types_Image = value; }
       }


       public object fk_login_id
       {
           get { return _fk_login_id; }
           set { _fk_login_id = value; }
       }
       public object login_user_Id
       {
           get { return _login_user_Id; }
           set { _login_user_Id = value; }
       }
       public object fk_mission_id
       {
           get { return _fk_mission_id; }
           set { _fk_mission_id = value; }
       }


       public object fk_user_circle_id
       {
           get { return _fk_user_circle_id; }
           set { _fk_user_circle_id = value; }
       }

       public object FromDate
       {
           get { return _FromDate; }
           set { _FromDate = value; }
       }
       public object ToDate
       {
           get { return _ToDate; }
           set { _ToDate = value; }
       }

       public object GM_WM
       {
           get { return _GM_WM; }
           set { _GM_WM = value; }
       }
       #endregion
   }
}
