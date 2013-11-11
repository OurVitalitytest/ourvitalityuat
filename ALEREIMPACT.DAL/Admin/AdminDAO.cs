using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.FRAMEWORK;
using System.Data;

namespace ALEREIMPACT.DAO.Admin
{
    public class AdminDAO
    {
        //GET ADMIN USER DETAIL//

        public static DataTable GettbAdminUser(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@login_email",
                TextValue = objAdminBAO.login_email.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@login_password",
                TextValue = objAdminBAO.login_password.ToString()
            });
            parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objAdminBAO.ProcedureType.ToString()
           });
            return sQLHelper.getRecords("spGetAdminUser", parametersList);
        }

        //Get  other User Details and Inspirator Detail//
        public static DataTable GettbUserDetail(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spUsermanagement", parametersList);
        }
        // get password//
        public static DataTable GetPassword(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@pk_user_registration_Id",
                TextValue = Convert.ToInt32(objAdminBAO.pk_user_registration_Id).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@login_password",
                TextValue = objAdminBAO.login_password.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spGetPassword", parametersList);
        }

        // update Password//
        public static Int32 UpdatePassword(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@pk_user_registration_Id",
                    TextValue = Convert.ToInt32(objAdminBAO.pk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@login_password",
                    TextValue = objAdminBAO.login_password.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spGetPassword", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        // get Count of Freinds and comments, userdetail acc to filter//
        public static DataTable GetUserDeatilsCount(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@ID",
                TextValue = Convert.ToInt32(objAdminBAO.ID).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spFilterSearch", parametersList);
        }

        // update User Status//
        public static Int32 UpdateStatus(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_status_id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_status_id).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@pk_user_registration_Id",
                    TextValue = Convert.ToInt32(objAdminBAO.pk_user_registration_Id).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spUpdateStatus", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        // count friends of user in circles//
        public static DataTable GetUserFriendsCount(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_Id).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@fk_circle_id",
                TextValue = Convert.ToInt32(objAdminBAO.fk_circle_id).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spCountFreinds", parametersList);
        }
        // Count number of Likes,comments,inappropriate, library on Inspirator//

        public static DataTable GetInspiratorCount(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();

            parametersList.Add(new Parameters()
            {
                TextName = "@fk_Inspirator_id",
                TextValue = Convert.ToInt32(objAdminBAO.fk_Inspirator_id).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spInspiratorManagement", parametersList);
        }

        //get userdetail acc to name,email//
        public static DataTable GetUserDetailSearch(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@name",
                TextValue = objAdminBAO.name.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@name1",
                TextValue = objAdminBAO.name1.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spSerachUserByNameEmail", parametersList);
        }
        //for delete//
        public static Int32 deleteComment(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@ID",
                    TextValue = Convert.ToInt32(objAdminBAO.ID).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spFilterSearch", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }
        //for add inspirator//
        public static Int32 InsertInspirator(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@pk_Inspirator_id",
                    TextValue = Convert.ToInt32(objAdminBAO.pk_Inspirator_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Inspirator_image",
                    TextValue = objAdminBAO.Inspirator_image.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Inspirator_desc",
                    TextValue = objAdminBAO.Inspirator_desc.ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Inspirator_createdon",
                    TextValue = objAdminBAO.Inspirator_createdon.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Fk_Inspirator_status_id",
                    TextValue = Convert.ToInt32(objAdminBAO.Fk_Inspirator_status_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_circle_id ",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_circle_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_circle_id ",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_circle_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInsertInspirator", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //for add Group//
        public static Int32 InserttblGroupMaster(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@GROUP_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.GROUP_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GROUP_NAME",
                    TextValue = objAdminBAO.GROUP_NAME.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInsertGroupMaster", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //GET Group//

        public static DataTable GettblGroupMaster(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spViewtblGroupMaster", parametersList);
        }

        //get group user detail//

        public static DataTable GetSearchDetail(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@ID",
                TextValue = Convert.ToInt32(objAdminBAO.ID).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ID1",
                TextValue = Convert.ToInt32(objAdminBAO.ID1).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spSearchdetail", parametersList);
        }

        //insert GroupUser Detail;//

        public static Int32 InserttblGroupUserDetail(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@GUD_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.GUD_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GROUP_ID_FK",
                    TextValue = Convert.ToInt32(objAdminBAO.GROUP_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblGroupUserDetail", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //update tblGroupUserDetail//
        public static Int32 UpdatetblGroupUserDetail(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@user_id",
                    TextValue = (objAdminBAO.user_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GROUP_ID_FK",
                    TextValue = (objAdminBAO.GROUP_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("SpupdateUserGroupDetail", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }


        //for add Global Message//
        public static Int32 InserttblGlobalMessage(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@GM_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.GM_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GM_MESSAGE",
                    TextValue = (objAdminBAO.GM_MESSAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GM_DATE",
                    TextValue = objAdminBAO.GM_DATE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GM_WM",
                    TextValue = objAdminBAO.GM_WM.ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblGlobalMessage", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //for add Comment//
        public static Int32 InserttblAdminCommemts(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@AC_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.AC_ID).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@AC_COMMENT",
                    TextValue = (objAdminBAO.AC_COMMENT).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AC_COMMENT_ON",
                    TextValue = (objAdminBAO.AC_COMMENT_ON).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_Admin_user_registration_Id ",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_Admin_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_circle_id ",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_circle_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@GROUP_ID_FK ",
                    TextValue = Convert.ToInt32(objAdminBAO.GROUP_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objAdminBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttbAdminComments", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //for add TbAuditTrail//
        public static Int32 InserttblAuditTrail(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.AT_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id ",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_LOGINTIME",
                    TextValue = (objAdminBAO.AT_LOGINTIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_LOGOUTTIME",
                    TextValue = (objAdminBAO.AT_LOGOUTTIME).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_DATE",
                    TextValue = (objAdminBAO.AT_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_LOGIN_STATUS",
                    TextValue = (objAdminBAO.AT_LOGIN_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@AT_FAILUREREASON",
                    TextValue = (objAdminBAO.AT_FAILUREREASON).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objAdminBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttbAuditTrail", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //for add TBLUSERINVITATION//
        public static Int32 InserttblUserInvitation(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.UI_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id ",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_USER_MAIL_ID",
                    TextValue = (objAdminBAO.UI_USER_MAIL_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_STATUS",
                    TextValue = (objAdminBAO.UI_STATUS).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_CODE",
                    TextValue = Convert.ToInt32(objAdminBAO.UI_CODE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_DATE",
                    TextValue = (objAdminBAO.UI_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UI_MAIL_STATUS",
                    TextValue = (objAdminBAO.UI_MAIL_STATUS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objAdminBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserInvitation", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //for add Ticket Reply//
        public static Int32 InserttblTicketREply(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@TR_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.TR_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@T_ID_FK",
                    TextValue = Convert.ToInt32(objAdminBAO.T_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@TR_REPLY",
                    TextValue = objAdminBAO.TR_REPLY.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@TR_DATE",
                    TextValue = objAdminBAO.TR_DATE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblTicketReply", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //for add Ticket Reply//
        public static Int32 UpdatetblTicket(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@T_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.T_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_id).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@T_MESSAGE",
                    TextValue = objAdminBAO.T_MESSAGE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@T_REPLYSTATUS",
                    TextValue = objAdminBAO.T_REPLYSTATUS.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@T_DATE",
                    TextValue = objAdminBAO.T_DATE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@T_STATUS",
                    TextValue = objAdminBAO.T_STATUS.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblTickets", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //get group user Analytics Detail//

        public static DataTable GetUserAnalyticsDetail(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_Id).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@date1 ",
                TextValue = (objAdminBAO.date1).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@date2",
                TextValue = (objAdminBAO.date2).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spGetUSerAnalyticDetail", parametersList);
        }

        //for uPDATE ERROE LOG//
        public static Int32 UpdatetblErrorDetail(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.ER_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@PAGE_ID_FK",
                    TextValue = Convert.ToInt32(objAdminBAO.PAGE_ID_FK).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_id).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_MESSAGE",
                    TextValue = objAdminBAO.ER_MESSAGE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_IMAGE",
                    TextValue = objAdminBAO.ER_IMAGE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_POST_DATE",
                    TextValue = objAdminBAO.ER_POST_DATE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ER_STATUS",
                    TextValue = objAdminBAO.ER_STATUS.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblErrorDetails", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        //for uPDATE ERROE LOG//
        public static Int32 UpdatetblFeedBack(AdminBAO objAdminBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_ID",
                    TextValue = Convert.ToInt32(objAdminBAO.FB_ID).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objAdminBAO.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@PAGE_ID_FK",
                    TextValue = Convert.ToInt32(objAdminBAO.PAGE_ID_FK).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_MESSAGE",
                    TextValue = objAdminBAO.FB_MESSAGE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_DATE",
                    TextValue = objAdminBAO.FB_DATE.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_RATING",
                    TextValue = objAdminBAO.FB_RATING.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FB_STATUS",
                    TextValue = objAdminBAO.FB_STATUS.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserFeedBack", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }
        public static DataTable GetPersonalization_Images(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();

            parametersList.Add(new Parameters()
            {
                TextName = "@fk_tblPersonalization_types_Images_Id",
                TextValue = objAdminBAO.PersonalizationTypesImagesId.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@request_Type",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@personalization_types_Image",
                TextValue = objAdminBAO.PersonalizationTypesImage.ToString()
            });
            return sQLHelper.getRecords("spGetPersonalization_Images", parametersList);
        }

        public static DataTable GetUserMissionProgressGraph(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@fk_login_id",
                TextValue = objAdminBAO.fk_login_id.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@login_user_Id",
                TextValue = objAdminBAO.login_user_Id.ToString()
            });

            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spGetUserMissionProgressGraph", parametersList);
        }


        public static DataTable GetUserMemberStatus(AdminBAO objAdminBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@ID",
                TextValue = objAdminBAO.ID.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ID1",
                TextValue = objAdminBAO.ID1.ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ID2",
                TextValue = objAdminBAO.ID2.ToString()
            });

            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spGetMemberStatus", parametersList);
        }

        public static DataTable GetUserDetails(AdminBAO objAdminBAO)
        {
            DataTable dt = new DataTable();

            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = objAdminBAO.ProcedureType.ToString()
                });
                return sQLHelper.getRecords("spAdmin_ExcelData", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;

        }


        public static DataTable GetNewUserDetails(AdminBAO objAdminBAO)
       {
           DataTable dt = new DataTable();

           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = objAdminBAO.ProcedureType.ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@Fromdate",
                   TextValue = objAdminBAO.FromDate.ToString ()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@ToDate",
                   TextValue = objAdminBAO.ToDate.ToString()
               });
              
               return sQLHelper.getRecords("spAdminUsersDetails", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return dt;

       }

        public static DataSet ExportAllExcel(AdminBAO objAdminBAO)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();


            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objAdminBAO.ProcedureType.ToString()
            });


            return sqlhelper.getRecordsDS("spAdmin_ExcelData", parameterslist);
        }

    }
}
