using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ALEREIMPACT.BAO;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Circles;

namespace ALEREIMPACT.DAO.Circles
{
    public class UserCirclesDAO
    {
        public static DataTable GetUserCircles(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.UserId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circleid",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });
            
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });
           

            return sqlhelper.getRecords("spGetUserCircles", parameterslist);


        }
        public static int GetPendingInvitations(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.UserId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.ExecuteNonQuery("spGetPendingInvitations", parameterslist);


        }
        //To get Membercount for each circle
        public static int GetCircleMemberCount(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userid",
                TextValue = Convert.ToInt32(objucircles.UserId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circleid",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.ExecuteNonQuery("spGetCircleMemberCount", parameterslist);


        }
        //Get member Images (5)
        public static DataTable GetMemberImagesForCircle(UserCirclesBAO objucircles)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userid",
                TextValue = Convert.ToInt32(objucircles.UserId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circleid",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("GetMemberCircleImages", parameterslist);

        }

        public static int AddNewCircle(UserCirclesBAO objucircles)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_name",
                TextValue = (objucircles.circle_name).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_id",
                TextValue = (objucircles.fk_circle_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = (objucircles.fk_user_registration_Id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_circle_permission_id",
                TextValue = (objucircles.fk_circle_permission_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_image",
                TextValue = (objucircles.circle_image).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_color",
                TextValue = (objucircles.circle_color).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_create_date",
                TextValue = (objucircles.circle_create_date).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.ExecuteNonQuery("spAddNewCircle", parameterslist);

        }

        public static DataTable GetFriendProfile(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.UserId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("spGetFriendProfile", parameterslist);


        }

        public static Int32 SendFriendRequest(UserCirclesBAO objucircles)
        {
           
                IList<Parameters> parameterslist = new List<Parameters>();
                SQLHelper sqlhelper = new SQLHelper();

                parameterslist.Add(new Parameters()
                {
                    TextName = "@userId",
                    TextValue = Convert.ToInt32(objucircles.fk_user_registration_Id).ToString()
                });
                parameterslist.Add(new Parameters()
                {
                    TextName = "@frienduserId",
                    TextValue = Convert.ToInt32(objucircles.friend_registration_id).ToString()
                });
                parameterslist.Add(new Parameters()
                {
                    TextName = "@circleid",
                    TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
                });
                parameterslist.Add(new Parameters()
                {
                    TextName = "@requeststatus",
                    TextValue = Convert.ToInt32(objucircles.request_status).ToString()
                });
                parameterslist.Add(new Parameters()
                {
                    TextName = "@updatedon",
                    TextValue = Convert.ToDateTime(objucircles.updated_on).ToString()
                });
                parameterslist.Add(new Parameters()
                {
                    TextName = "@proceduretype",
                    TextValue = objucircles.proceduretype.ToString()
                });

                return sqlhelper.ExecuteNonQuery("spSendFriendRequest", parameterslist);

           
        }
        public static DataTable GetPendingFriendRequests(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.UserId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("spGetPendingInvitations", parameterslist);

        }

        public static int AcceptFriendRequest(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.fk_user_registration_Id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@frienduserId",
                TextValue = Convert.ToInt32(objucircles.friend_registration_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circleid",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@requeststatus",
                TextValue = Convert.ToInt32(objucircles.request_status).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@updatedon",
                TextValue = Convert.ToDateTime(objucircles.updated_on).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.ExecuteNonQuery("spSendFriendRequest", parameterslist);


        }

        public static int GetMutualFriends(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.fk_user_registration_Id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circleid",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@frienduserId",
                TextValue = Convert.ToInt32(objucircles.friend_registration_id).ToString()
            });

            return sqlhelper.ExecuteNonQuery("spGetMutualFriends", parameterslist);


        }

        public static DataTable BindCircles(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.UserId).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("spBindCircles", parameterslist);


        }

        public static DataTable GetFriendList(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.fk_user_registration_Id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circleid",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("GetFriendList", parameterslist);

        }

        public static DataTable GetCircleList(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("GetCircleList", parameterslist);

        }

        public static DataTable GetCircleName(UserCirclesBAO objucircles)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userId",
                TextValue = Convert.ToInt32(objucircles.fk_user_registration_Id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@circleid",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("spGetUserCircles", parameterslist);
        }

        public static DataTable GetUserCircleName(UserCirclesBAO objucircles)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@circle_name",
                TextValue = (objucircles.circle_name).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = Convert.ToInt32(objucircles.fk_user_registration_Id).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("spGetCircleName", parameterslist);
        }

        public static DataTable GetUserNameEmail(UserCirclesBAO objucircles)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

           
            parameterslist.Add(new Parameters()
            {
                TextName = "@ID",
                TextValue = Convert.ToInt32(objucircles.ID).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("spFilterSearch", parameterslist);
        }


        public static DataTable GetUserFriendPublicCircles(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@userRegistration_ID",
                TextValue = Convert.ToInt32(objucircles.userRegistration_ID).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@userfriend_ID",
                TextValue = Convert.ToInt32(objucircles.userfriend_ID).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_circle_ID",
                TextValue = Convert.ToInt32(objucircles.fk_circle_ID).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_circlePermission_ID",
                TextValue = Convert.ToInt32(objucircles.fk_circlePermission_ID).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@Proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("spuserfrndPublicCircles", parameterslist);


        }

        public static Int32 InsertCircleInvitation(UserCirclesBAO objucircles)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@CI_ID",
                    TextValue = Convert.ToInt32(objucircles.CI_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_login_id",
                    TextValue = Convert.ToInt32(objucircles.fk_login_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@freind_user_id",
                    TextValue = Convert.ToInt32(objucircles.freind_user_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CI_MESSAGE",
                    TextValue = (objucircles.CI_MESSAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_circle_id",
                    TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CI_DATE",
                    TextValue =(objucircles.CI_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CI_STATUS",
                    TextValue = (objucircles.CI_STATUS).ToString()

                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objucircles.proceduretype).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInsertCircleInvitation", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }


        public static DataTable GetUserCircleSearchREsult(UserCirclesBAO objucircles)
        {

            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = Convert.ToInt32(objucircles.fk_user_registration_Id).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@fk_circle_id",
                TextValue = Convert.ToInt32(objucircles.fk_circle_id).ToString()
            });

            parameterslist.Add(new Parameters()
            {
                TextName = "@Prefixtext",
                TextValue =(objucircles.Prefixtext).ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@Proceduretype",
                TextValue = objucircles.proceduretype.ToString()
            });

            return sqlhelper.getRecords("GEtSearchResults", parameterslist);


        }

    }   


}
