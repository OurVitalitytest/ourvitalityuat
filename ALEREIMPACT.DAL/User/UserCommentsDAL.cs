using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALEREIMPACT.BAL.User;
using System.Data;
using ALEREIMPACT.FRAMEWORK;

namespace ALEREIMPACT.DAL.User
{
    public class UserCommentsDAL
    {
        public static DataTable PostComments(UserCommentsBAL objUserCommentsBAL)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserCommentsBAL.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@comment",
                TextValue = objUserCommentsBAL.PostedComments.ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@pk_major_CommentId",
                TextValue = objUserCommentsBAL.MajorCommentId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_circle_id",
                TextValue = objUserCommentsBAL.CircleId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_cicle_id",
                TextValue = objUserCommentsBAL.UserCircleId.ToString()
            });
            return sqlhelper.getRecords("spPostWallComments", parameterslist);
        }

        public static DataTable GetWallComments(Int32 LoginUserId, Int32 CircleId, Int32 PageIndex, Int32 PageSize,Int32 UserCircleId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = LoginUserId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_id",
                TextValue = CircleId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@page_index",
                TextValue = PageIndex.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@page_size",
                TextValue = PageSize.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@pk_user_circle_id",
                TextValue = UserCircleId.ToString()
            });
            return sqlhelper.getRecords("[Get_WallCommentsBy_LoginId]", parameterslist);
        }
        public static DataTable LikeComments(Int32 CommentId, Int32 LoginUserId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = LoginUserId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_comment_id",
                TextValue = CommentId.ToString()
            });
            return sqlhelper.getRecords("spLikeComments", parameterslist);
        }

        public static DataTable SuperLikeComments(Int32 CommentId, Int32 LoginUserId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = LoginUserId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_comment_id",
                TextValue = CommentId.ToString()
            });
            return sqlhelper.getRecords("spSuperLikeComments", parameterslist);
        }


        public static DataTable GetSubComments(Int32 CommentId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@majorCommentId",
                TextValue = CommentId.ToString()
            });

            return sqlhelper.getRecords("Get_WallSubCommentsBy_CommentId", parameterslist);
        }
        public static DataTable GetLikeStatus(Int32 CommentId, Int32 LoginUserId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = LoginUserId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_comment_id",
                TextValue = CommentId.ToString()
            });
            return sqlhelper.getRecords("spCheck_LikeStatus", parameterslist);
        }

        public static DataTable GetSuperLikeStatus(Int32 CommentId, Int32 LoginUserId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = LoginUserId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_comment_id",
                TextValue = CommentId.ToString()
            });
            return sqlhelper.getRecords("spCheckSuperLikeStatus", parameterslist);
        }

        public static DataTable GetLikeCount(Int32 CommentId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_comment_id",
                TextValue = CommentId.ToString()
            });
            return sqlhelper.getRecords("[spCountLikes]", parameterslist);
        }

        public static DataTable GetSuperLikeCount(Int32 CommentId)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_comment_id",
                TextValue = CommentId.ToString()
            });
            return sqlhelper.getRecords("[spCountSuperLike]", parameterslist);
        }
        public static DataTable GetAndReply_AdminPostedComments(UserCommentsBAL objUserCommentsBal)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objUserCommentsBal.LoginId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@reply_message",
               TextValue = objUserCommentsBal.ReplyMessage.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@reply_to_admin_message_id",
                TextValue = objUserCommentsBal.ReplyToAdminMessageId.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@request_type_id",
                TextValue = objUserCommentsBal.RequestTypeId.ToString()
            });
            return sqlhelper.getRecords("spGetAndReply_GlobalMessages", parameterslist);
        }

        public static Int32 InserttblGlobalMessageRead(UserCommentsBAL objUserCommentsBal)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@GMU_ID",
                    TextValue = Convert.ToInt32(objUserCommentsBal.GMU_ID).ToString()
                });
              
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objUserCommentsBal.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GM_ID_FK",
                    TextValue = Convert.ToInt32(objUserCommentsBal.GM_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objUserCommentsBal.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInsertbtlGlobalMessageRead", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataTable GetGlobalUnreadMessageCount(UserCommentsBAL objUserCommentsBal)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@ID",
                TextValue = Convert.ToInt32(objUserCommentsBal.ID).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objUserCommentsBal.ProcedureType.ToString()
            });
            return sqlhelper.getRecords("spFilterSearch", parameterslist);
        }


        public static Int32 InserttblNotesNotification(UserCommentsBAL objUserCommentsBal)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@NOTESN_ID",
                    TextValue = Convert.ToInt32(objUserCommentsBal.NOTESN_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_comment_id",
                    TextValue = Convert.ToInt32(objUserCommentsBal.fk_comment_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objUserCommentsBal.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@NOTESN_DATE",
                    TextValue = (objUserCommentsBal.NOTESN_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@NOTESN_NOTIFICATION_STATUS",
                    TextValue = (objUserCommentsBal.NOTESN_NOTIFICATION_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@NOTES_EMAIL_STATUS",
                    TextValue = (objUserCommentsBal.NOTES_EMAIL_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@LIKE_STATUS",
                    TextValue = (objUserCommentsBal.LIKE_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objUserCommentsBal.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInsertNotesNotification", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

    }
}
