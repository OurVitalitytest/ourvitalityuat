using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using System.Data;

namespace ALEREIMPACT.DAL.User
{
   public  class UserInspiratorsDAL
    {
       //  add Inspirator//
       public static Int32 InsertInspirator(UserInspiratorsBAL objUserInspiratorBAL)
       {
           int returnValue = 0;
           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@pk_Inspirator_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.pk_Inspirator_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@Inspirator_image",
                   TextValue = objUserInspiratorBAL.Inspirator_image.ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@Inspirator_desc",
                   TextValue = objUserInspiratorBAL.Inspirator_desc.ToString()
               });

               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_user_registration_Id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_Id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@Inspirator_createdon",
                   TextValue = objUserInspiratorBAL.Inspirator_createdon.ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@Fk_Inspirator_status_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.Fk_Inspirator_status_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_circle_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_circle_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_user_circle_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_circle_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = objUserInspiratorBAL.ProcedureType.ToString()
               });
               returnValue = sQLHelper.ExecuteNonQuery("spInsertInspirator", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return returnValue;
       }

       // get User Inspirator//

       public static DataTable GetUserInspirator(UserInspiratorsBAL objUserInspiratorBAL)
       {
           IList<Parameters> parametersList = new List<Parameters>();
           SQLHelper sQLHelper = new SQLHelper();
           parametersList.Add(new Parameters()
           {
               TextName = "@fk_user_registration_Id",
               TextValue = Convert.ToInt32( objUserInspiratorBAL.fk_user_registration_Id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@Friend_id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.Friend_id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@fk_circle_id",
               TextValue =Convert.ToInt32(  objUserInspiratorBAL.fk_circle_id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@fk_user_circle_id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_circle_id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@page_index",
               TextValue = objUserInspiratorBAL.page_index.ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@page_size",
               TextValue = objUserInspiratorBAL.page_size.ToString()
           });

           parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objUserInspiratorBAL.ProcedureType.ToString()
           });
           return sQLHelper.getRecords("spGetUsersInspirators", parametersList);
       }
       // count like and cooments of Inspirator//
       public static DataTable GetCountLCInspirator(UserInspiratorsBAL objUserInspiratorBAL)
       {
           IList<Parameters> parametersList = new List<Parameters>();
           SQLHelper sQLHelper = new SQLHelper();
         
           parametersList.Add(new Parameters()
           {
               TextName = "@fk_Inspirator_id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_Inspirator_id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objUserInspiratorBAL.ProcedureType.ToString()
           });
           return sQLHelper.getRecords("spInspiratorManagement", parametersList);
       }

       // Insert Inspirator Like//

       public static Int32 InsertInspiratorLike(UserInspiratorsBAL objUserInspiratorBAL)
       {
           int returnValue = 0;
           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@pk_InspiratorLiked_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.pk_InspiratorLiked_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_Inspirator_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_Inspirator_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_user_registration_Id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_Id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@InspiratorLiked_on",
                   TextValue = objUserInspiratorBAL.InspiratorLiked_on.ToString()
               });
              
               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = objUserInspiratorBAL.ProcedureType.ToString()
               });
               returnValue = sQLHelper.ExecuteNonQuery("spInserttblInspiratorLike", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return returnValue;
       }
       //insert inspirator comment//
       public static Int32 InsertInspiratorComment(UserInspiratorsBAL objUserInspiratorBAL)
       {
           int returnValue = 0;
           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@pk_InspiratorComments_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.pk_InspiratorComments_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@InspiratorComment_text",
                   TextValue = objUserInspiratorBAL.InspiratorComment_text.ToString()
               });

               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_Inspirator_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_Inspirator_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_user_registration_Id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_Id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@InspiratorComment_on",
                   TextValue = objUserInspiratorBAL.InspiratorComment_on.ToString()
               });

               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = objUserInspiratorBAL.ProcedureType.ToString()
               });
               returnValue = sQLHelper.ExecuteNonQuery("spInsertInspiratorComment", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return returnValue;
       }

       public static DataTable GetUserInspiratorLike(UserInspiratorsBAL objUserInspiratorBAL)
       {
           IList<Parameters> parametersList = new List<Parameters>();
           SQLHelper sQLHelper = new SQLHelper();

           parametersList.Add(new Parameters()
           {
               TextName = "@fk_Inspirator_id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_Inspirator_id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@fk_user_registration_Id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_Id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objUserInspiratorBAL.ProcedureType.ToString()
           });
           return sQLHelper.getRecords("spGetUserInspiratorLike", parametersList);
       }

       // get User Inspirator//

       public static DataTable GetFriendInspirator(UserInspiratorsBAL objUserInspiratorBAL)
       {
           IList<Parameters> parametersList = new List<Parameters>();
           SQLHelper sQLHelper = new SQLHelper();
           parametersList.Add(new Parameters()
           {
               TextName = "@userid",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.userid).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@fk_circle_id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_circle_id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@fk_user_circle_id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_circle_id).ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@page_index",
               TextValue = objUserInspiratorBAL.page_index.ToString()
           });
           parametersList.Add(new Parameters()
           {
               TextName = "@page_size",
               TextValue = objUserInspiratorBAL.page_size.ToString()
           });

           parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objUserInspiratorBAL.ProcedureType.ToString()
           });
           return sQLHelper.getRecords("spGetFriendsInspirtors", parametersList);
       }

       // Insert Inspirator Inappropriate//

       public static Int32 InsertInspiratorInappropriate(UserInspiratorsBAL objUserInspiratorBAL)
       {
           int returnValue = 0;
           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@pk_InspiratorInappro_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.pk_InspiratorInappro_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_Inspirator_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_Inspirator_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_user_registration_Id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_Id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@InspiratorInappro_on",
                   TextValue = objUserInspiratorBAL.InspiratorInappro_on.ToString()
               });

               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = objUserInspiratorBAL.ProcedureType.ToString()
               });
               returnValue = sQLHelper.ExecuteNonQuery("spInserttblInappropriate", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return returnValue;
       }

       public static DataTable GetViewInspirator(UserInspiratorsBAL objUserInspiratorBAL)
       {
           IList<Parameters> parametersList = new List<Parameters>();
           SQLHelper sQLHelper = new SQLHelper();

           parametersList.Add(new Parameters()
           {
               TextName = "@pk_Inspirator_id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.pk_Inspirator_id).ToString()
           });
        
           parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objUserInspiratorBAL.ProcedureType.ToString()
           });
           return sQLHelper.getRecords("spViewInspirator", parametersList);
       }

       public static Int32 InsertInspiratorLibrary(UserInspiratorsBAL objUserInspiratorBAL)
       {
           int returnValue = 0;
           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@pk_inspiratorLib_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.pk_inspiratorLib_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_Inspirator_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_Inspirator_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_user_registration_Id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_Id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@inspiratorLib_createdon",
                   TextValue = objUserInspiratorBAL.inspiratorLib_createdon.ToString()
               });

               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = objUserInspiratorBAL.ProcedureType.ToString()
               });
               returnValue = sQLHelper.ExecuteNonQuery("spInserttblInspiratorLibarary", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return returnValue;
       }

       public static DataTable GetLibraryInspirator(UserInspiratorsBAL objUserInspiratorBAL)
       {
           IList<Parameters> parametersList = new List<Parameters>();
           SQLHelper sQLHelper = new SQLHelper();

           parametersList.Add(new Parameters()
           {
               TextName = "@ID",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.ID).ToString()
           });

           parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objUserInspiratorBAL.ProcedureType.ToString()
           });
           return sQLHelper.getRecords("spFilterSearch", parametersList);
       }

       public static DataTable GetViewInappropriateInspirator(UserInspiratorsBAL objUserInspiratorBAL)
       {
           IList<Parameters> parametersList = new List<Parameters>();
           SQLHelper sQLHelper = new SQLHelper();

           parametersList.Add(new Parameters()
           {
               TextName = "@fk_user_registration_Id",
               TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_Id).ToString()
           });

           parametersList.Add(new Parameters()
           {
               TextName = "@ProcedureType",
               TextValue = objUserInspiratorBAL.ProcedureType.ToString()
           });
           return sQLHelper.getRecords("spViewtblInappropriate", parametersList);
       }


       public static Int32 InsertInspiratorNotifications(UserInspiratorsBAL objUserInspiratorBAL)
       {
           int returnValue = 0;
           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@IN_ID",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.IN_ID).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_Inspirator_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_Inspirator_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@fk_user_registration_id",
                   TextValue = Convert.ToInt32(objUserInspiratorBAL.fk_user_registration_id).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@IN_DATE",
                   TextValue = objUserInspiratorBAL.IN_DATE.ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@IN_NOTIFICATION_STATUS",
                   TextValue = objUserInspiratorBAL.IN_NOTIFICATION_STATUS.ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@IN_EMAIL_STATUS",
                   TextValue = objUserInspiratorBAL.IN_EMAIL_STATUS.ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@LIKE_STATUS",
                   TextValue = objUserInspiratorBAL.LIKE_STATUS.ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = objUserInspiratorBAL.ProcedureType.ToString()
               });
               returnValue = sQLHelper.ExecuteNonQuery("spInserttblInspiratorNotification", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return returnValue;
       }
    }
}
