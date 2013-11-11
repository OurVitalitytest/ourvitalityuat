using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAL.User
{
    public class UserCommentsBAL
    {
        #region variables declaration

        private Int32 login_Id = 0;
        private string posted_comments = string.Empty;
        private Int32 pk_major_CommentId = 0;
        private Int32 pk_circle_Id = 0;
        private Int32 fk_user_cicle_id = 0;

        private string reply_message = string.Empty;
        private int reply_to_admin_message_id = 0;
        private int request_type_id = 0;


        private object _GMU_ID = string.Empty;
        private object _GM_ID_FK = string.Empty;
        private object _fk_user_registration_id = string.Empty;
        private object _ProcedureType = string.Empty;
        private object _ID = string.Empty;

        private object _NOTESN_ID = string.Empty;
        private object _fk_comment_id = string.Empty;
        private object _NOTESN_DATE = string.Empty;
        private object _NOTESN_NOTIFICATION_STATUS = string.Empty;
        private object _NOTES_EMAIL_STATUS = string.Empty;
        private object _LIKE_STATUS = string.Empty;
        #endregion

        #region Properties
        public Int32 LoginId
        {
            get { return login_Id; }
            set { login_Id = value; }
        }
        public string PostedComments
        {
            get { return posted_comments; }
            set { posted_comments = value; }
        }
        public Int32 MajorCommentId
        {
            get { return pk_major_CommentId; }
            set { pk_major_CommentId = value; }
        }
        public Int32 CircleId
        {
            get { return pk_circle_Id; }
            set { pk_circle_Id = value; }
        }
        public Int32 UserCircleId
        {
            get { return fk_user_cicle_id; }
            set { fk_user_cicle_id = value; }
        }



        public string ReplyMessage
        {
            get { return reply_message; }
            set { reply_message = value; }
        }
        public Int32 ReplyToAdminMessageId
        {
            get { return reply_to_admin_message_id; }
            set { reply_to_admin_message_id = value; }
        }
        public Int32 RequestTypeId
        {
            get { return request_type_id; }
            set { request_type_id = value; }
        }
        public object GMU_ID
        {
            get { return _GMU_ID; }
            set { _GMU_ID = value; }
        }
       
        public object fk_user_registration_id
        {
            get { return _fk_user_registration_id; }
            set { _fk_user_registration_id = value; }
        }
        public object GM_ID_FK
        {
            get { return _GM_ID_FK; }
            set { _GM_ID_FK = value; }
        }
        public object ProcedureType
        {
            get { return _ProcedureType; }
            set { _ProcedureType = value; }
        }

        public object ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        public object NOTESN_ID
        {
            get { return _NOTESN_ID; }
            set { _NOTESN_ID = value; }
        }

        public object fk_comment_id
        {
            get { return _fk_comment_id; }
            set { _fk_comment_id = value; }
        }

        public object NOTESN_DATE
        {
            get { return _NOTESN_DATE; }
            set { _NOTESN_DATE = value; }
        }

        public object NOTESN_NOTIFICATION_STATUS
        {
            get { return _NOTESN_NOTIFICATION_STATUS; }
            set { _NOTESN_NOTIFICATION_STATUS = value; }
        }

        public object NOTES_EMAIL_STATUS
        {
            get { return _NOTES_EMAIL_STATUS; }
            set { _NOTES_EMAIL_STATUS = value; }
        }
        public object LIKE_STATUS
        {
            get { return _LIKE_STATUS; }
            set { _LIKE_STATUS = value; }
        }

        #endregion

    }
}
