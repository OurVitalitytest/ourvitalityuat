using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using System.Data;

namespace ALEREIMPACT
{
    public class Global : System.Web.HttpApplication
    {
        AdminBAO objAdminBAO = new AdminBAO();
        UserFoodLogBAO objUSerFoodLogBAO = new UserFoodLogBAO();
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        public static string timeStart = "";
        public static string timeEnd = "";
        public static string Username = "";
        public static string name = "";
        public static string Userid = "";
        public static string Body = "";
        clsScheduleMail objScheduleMail = new clsScheduleMail();
        public override void Init()
        {
            IServiceLocator injector =
                new WindsorServiceLocator(
                    new WindsorContainer(
                        new XmlInterpreter(
                            new ConfigResource("oauth.net.components"))));

            ServiceLocator.SetLocatorProvider(() => injector);
        }
        protected void Application_Start(object sender, EventArgs e)
        {
          // EmailScheduling();

        }

        public void EmailScheduling()
        {
            try
            {
                DataTable dtDelete = new DataTable();
                objUSerFoodLogBAO.fk_user_registration_Id = 0;
                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                objUSerFoodLogBAO.Fk_MissionId = 0;
                objUSerFoodLogBAO.ProcedureType = "D";
                objUSerFoodLogBAO.ID = "1";
                dtDelete = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "UF";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string time = DateTime.Now.ToString("HH:mm:ss");
                        DataTable dtUser = new DataTable();
                        objUSerFoodLogBAO.presenttime = time;
                        objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                        objUSerFoodLogBAO.ProcedureType = "S";
                        dtUser = UserFoodLogDAO.GetEatingID(objUSerFoodLogBAO);
                        if (dtUser.Rows.Count > 0)
                        {
                            if (dtUser.Rows[0]["ET_ID"].ToString() == "1")
                            {
                            }
                            else if (dtUser.Rows[0]["ET_ID"].ToString() == "2")
                            {
                                DataTable dtEtBreak = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 1;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEtBreak = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEtBreak.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 1;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                            }
                            else if (dtUser.Rows[0]["ET_ID"].ToString() == "3")
                            {
                                DataTable dtEtBreak = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 1;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEtBreak = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEtBreak.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 1;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt1 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 2;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt1 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt1.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 2;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                            }
                            else if (dtUser.Rows[0]["ET_ID"].ToString() == "5")
                            {
                                DataTable dtEtBreak = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 1;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEtBreak = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEtBreak.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 1;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt1 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 2;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt1 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt1.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 2;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt2 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 3;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt2 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt2.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 3;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                            }
                            else if (dtUser.Rows[0]["ET_ID"].ToString() == "6")
                            {
                                DataTable dtEtBreak = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 1;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEtBreak = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEtBreak.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 1;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt1 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 2;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt1 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt1.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 2;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt2 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 3;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt2 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt2.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 3;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt3 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 5;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt3 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt3.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 5;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                            }
                            else
                            {
                                DataTable dtEtBreak = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 1;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEtBreak = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEtBreak.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 1;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt1 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 2;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt1 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt1.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 2;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt2 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 3;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt2 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt2.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 3;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt3 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 5;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt3 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt3.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 5;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                                DataTable dtEt4 = new DataTable();
                                objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                                objUSerFoodLogBAO.Fk_MissionId = 6;
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                objUSerFoodLogBAO.ID = "1";
                                dtEt4 = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                                if (dtEt4.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    int retval = 0;
                                    objUSerFoodLogBAO.ES_ID = 0;
                                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUSerFoodLogBAO.ET_ID_FK = 6;
                                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                    objUSerFoodLogBAO.ES_STATUS = "Pending";
                                    objUSerFoodLogBAO.ProcedureType = "I";
                                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);

                                }
                            }
                        }
                        else
                        {
                            time = DateTime.Now.ToString("HH:mm:ss");
                            DataTable dtTime = new DataTable();
                            objUSerFoodLogBAO.ProcedureType = "ET";
                            dtTime = UserFoodLogDAO.GetFoodCategories(objUSerFoodLogBAO);
                            if (dtTime.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtTime.Rows.Count; j++)
                                {
                                    timeStart = dtTime.Rows[j]["ET_START_TIME"].ToString();
                                    timeEnd = dtTime.Rows[j]["ET_END_TIME"].ToString();
                                    if (Convert.ToDateTime(time) > Convert.ToDateTime(timeStart) && Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                    {
                                        if (j == 0)
                                        {
                                            Body = "No entry exist for Breakfast today.";
                                        }
                                        else if (j == 1)
                                        {
                                            int retval = 0;
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 1;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                        }
                                        else if (j == 2)
                                        {
                                            int retval = 0;
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 1;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 2;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                        }
                                        else if (j == 3)
                                        {
                                            int retval = 0;
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 1;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 2;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 3;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 5;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 6;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                        }

                                        else if (j == 4)
                                        {
                                            int retval = 0;
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 1;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 2;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 3;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                        }
                                        else if (j == 5)
                                        {
                                            int retval = 0;
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 1;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 2;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 3;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                            objUSerFoodLogBAO.ES_ID = 0;
                                            objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                            objUSerFoodLogBAO.ET_ID_FK = 5;
                                            objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                                            objUSerFoodLogBAO.ES_STATUS = "Pending";
                                            objUSerFoodLogBAO.ProcedureType = "I";
                                            retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                DataTable dtEmail = new DataTable();
                objAdminBAO.ProcedureType = "ES";
                dtEmail = AdminDAO.GettbUserDetail(objAdminBAO);
                if (dtEmail.Rows.Count > 0)
                {
                    Userid = Convert.ToString(dtEmail.Rows[0]["fk_user_registration_id"]);
                    DataTable dtname = new DataTable();
                    objUserRegisterBAO.ID = Convert.ToInt32(dtEmail.Rows[0]["fk_user_registration_id"]);
                    objUserRegisterBAO.procedureType = "E1";
                    dtname = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dtname.Rows.Count > 0)
                    {
                        Username = Convert.ToString(dtname.Rows[0]["login_email"]);
                        name = Convert.ToString(dtname.Rows[0]["name"]);
                    }
                    string subject = "Food Log Detail";
                    if (dtEmail.Rows[0]["ET_ID_FK"].ToString() == "1")
                    {
                        Body = "Hi " + name + "<br /><br />" + " No entry exist for Breakfast today." + "<br /><br />" +
                            "If you had your breakfast same as of yesterday then Click this link :" + "<br />" +
                          "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=1&etid=1 >Today's Input Same as Yesterday</a>" + "<br /><br />" + "Otherwise click this link :" + "<br />"
                            + "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=2&etid=1 >Today's Input</a>";


                    }
                    else if (dtEmail.Rows[0]["ET_ID_FK"].ToString() == "2")
                    {
                        Body = "Hi " + name + "<br /><br />" + " No entry exist for Morning Snacks today." + "<br /><br />" +
                           "If you had your Morning Snacks same as of yesterday then Click this link :" + "<br />" +
                          "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=1&etid=2>Today's Input Same as Yesterday</a>" + "<br /><br />" + "Otherwise click this link :" + "<br />"
                            + "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=2&etid=2 >Today's Input</a>";

                    }
                    else if (dtEmail.Rows[0]["ET_ID_FK"].ToString() == "3")
                    {
                        Body = "Hi " + name + "<br /><br />" + " No entry exist for Lunch today." + "<br /><br />" +
                           "If you had your Lunch same as of yesterday then Click this link :" + "<br />" +
                         "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=1&etid=3 >Today's Input Same as Yesterday</a>" + "<br /><br />" + "Otherwise click this link :" + "<br />"
                            + "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=2&etid=3 >Today's Input</a>";

                    }
                    else if (dtEmail.Rows[0]["ET_ID_FK"].ToString() == "5")
                    {
                        Body = "Hi " + name + "<br /><br />" + " No entry exist for Evening Snacks today." + "<br /><br />" +
                            "If you had your Evening Snacks same as of yesterday then Click this link :" + "<br />" +
                         "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=1&etid=5 >Today's Input Same as Yesterday</a>" + "<br /><br />" + "Otherwise click this link :" + "<br />"
                            + "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=2&etid=5 >Today's Input</a>";

                    }
                    else if (dtEmail.Rows[0]["ET_ID_FK"].ToString() == "6")
                    {
                        Body = "Hi " + name + "<br /><br />" + " No entry exist for Dinner today." + "<br /><br />" +
                            "If you had your Dinner same as of yesterday then Click this link :" + "<br />" +
                          "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=1&etid=6 >Today's Input Same as Yesterday</a>" + "<br /><br />" + "Otherwise click this link :" + "<br />"
                            + "<a href=http://dev.alerevitality.com?val=" + Userid + "&val1=2&etid=6 >Today's Input</a>";

                    }
                    objScheduleMail.SendScheduleMail(subject, Username, Body);
                    int retval = 0;
                    objUSerFoodLogBAO.ES_ID = Convert.ToInt32(dtEmail.Rows[0]["ES_ID"]);
                    objUSerFoodLogBAO.fk_user_registration_id = Convert.ToInt32(Userid);
                    objUSerFoodLogBAO.ET_ID_FK = Convert.ToInt32(dtEmail.Rows[0]["ET_ID_FK"]);
                    objUSerFoodLogBAO.ES_DATE = DateTime.Now.ToString();
                    objUSerFoodLogBAO.ES_STATUS = "Send";
                    objUSerFoodLogBAO.ProcedureType = "U";
                    retval = UserFoodLogDAO.InsertblEmailScheduling(objUSerFoodLogBAO);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public void EmailFoodLog()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "UF";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataTable dtUser = new DataTable();
                        objUSerFoodLogBAO.fk_user_registration_Id = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                        objUSerFoodLogBAO.UFL_DATE = DateTime.Now.ToString("dd/MM/yyyy");
                        objUSerFoodLogBAO.Fk_MissionId = 0;
                        objUSerFoodLogBAO.ProcedureType = "UF";
                        objUSerFoodLogBAO.ID = "1";
                        dtUser = UserFoodLogDAO.GetUserFoodLog(objUSerFoodLogBAO);
                        if (dtUser.Rows.Count > 0)
                        {
                            if (dtUser.Rows[0]["ET_ID_FK"].ToString() == "1")
                            {

                            }
                            else
                            {
                                string time = DateTime.Now.ToString("HH:mm:ss");
                                DataTable dtTime = new DataTable();
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                dtTime = UserFoodLogDAO.GetFoodCategories(objUSerFoodLogBAO);
                                if (dtTime.Rows.Count > 0)
                                {
                                    timeStart = dtTime.Rows[0]["ET_START_TIME"].ToString();
                                    timeEnd = dtTime.Rows[0]["ET_END_TIME"].ToString();
                                }
                                if (Convert.ToDateTime(time) > Convert.ToDateTime(timeStart) && Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {
                                }
                                else if (Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {

                                }
                                else
                                {
                                    DataTable dtname = new DataTable();
                                    objUserRegisterBAO.ID = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUserRegisterBAO.procedureType = "E";
                                    dtname = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                                    if (dtname.Rows.Count > 0)
                                    {
                                        Username = Convert.ToString(dtname.Rows[0]["login_email"]);
                                    }
                                    string subject = "Food Log Detail";
                                    String Body = "No entry exist for Breakfast today.";

                                    objScheduleMail.SendScheduleMail(subject, Username, Body);
                                }

                            }
                            if (dtUser.Rows[0]["ET_ID_FK"].ToString() == "2")
                            {
                            }
                            else
                            {
                                string time = DateTime.Now.ToString("HH:mm:ss");
                                DataTable dtTime = new DataTable();
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                dtTime = UserFoodLogDAO.GetFoodCategories(objUSerFoodLogBAO);
                                if (dtTime.Rows.Count > 0)
                                {
                                    timeStart = dtTime.Rows[1]["ET_START_TIME"].ToString();
                                    timeEnd = dtTime.Rows[1]["ET_END_TIME"].ToString();
                                }
                                if (Convert.ToDateTime(time) > Convert.ToDateTime(timeStart) && Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {
                                }
                                else if (Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {

                                }
                                else
                                {
                                    DataTable dtname = new DataTable();
                                    objUserRegisterBAO.ID = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUserRegisterBAO.procedureType = "E";
                                    dtname = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                                    if (dtname.Rows.Count > 0)
                                    {
                                        Username = Convert.ToString(dtname.Rows[0]["login_email"]);
                                    }
                                    string subject = "Food Log Detail";
                                    String Body = "No entry exist for Morning Snacks today.";

                                    objScheduleMail.SendScheduleMail(subject, Username, Body);
                                }
                            }
                            if (dtUser.Rows[0]["ET_ID_FK"].ToString() == "3")
                            {
                            }
                            else
                            {
                                string time = DateTime.Now.ToString("HH:mm:ss");
                                DataTable dtTime = new DataTable();
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                dtTime = UserFoodLogDAO.GetFoodCategories(objUSerFoodLogBAO);
                                if (dtTime.Rows.Count > 0)
                                {
                                    timeStart = dtTime.Rows[2]["ET_START_TIME"].ToString();
                                    timeEnd = dtTime.Rows[2]["ET_END_TIME"].ToString();
                                }
                                if (Convert.ToDateTime(time) > Convert.ToDateTime(timeStart) && Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {
                                }
                                else if (Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {

                                }
                                else
                                {
                                    DataTable dtname = new DataTable();
                                    objUserRegisterBAO.ID = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUserRegisterBAO.procedureType = "E";
                                    dtname = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                                    if (dtname.Rows.Count > 0)
                                    {
                                        Username = Convert.ToString(dtname.Rows[0]["login_email"]);
                                    }
                                    string subject = "Food Log Detail";
                                    String Body = "No entry exist for Lunch today.";

                                    objScheduleMail.SendScheduleMail(subject, Username, Body);
                                }
                            }
                            if (dtUser.Rows[0]["ET_ID_FK"].ToString() == "5")
                            {
                            }
                            else
                            {
                                string time = DateTime.Now.ToString("HH:mm:ss");
                                DataTable dtTime = new DataTable();
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                dtTime = UserFoodLogDAO.GetFoodCategories(objUSerFoodLogBAO);
                                if (dtTime.Rows.Count > 0)
                                {
                                    timeStart = dtTime.Rows[4]["ET_START_TIME"].ToString();
                                    timeEnd = dtTime.Rows[4]["ET_END_TIME"].ToString();
                                }
                                if (Convert.ToDateTime(time) > Convert.ToDateTime(timeStart) && Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {
                                }
                                else if (Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {

                                }
                                else
                                {
                                    DataTable dtname = new DataTable();
                                    objUserRegisterBAO.ID = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUserRegisterBAO.procedureType = "E";
                                    dtname = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                                    if (dtname.Rows.Count > 0)
                                    {
                                        Username = Convert.ToString(dtname.Rows[0]["login_email"]);
                                    }
                                    string subject = "Food Log Detail";
                                    String Body = "No entry exist for Evening Snacks today.";

                                    objScheduleMail.SendScheduleMail(subject, Username, Body);
                                }
                            }
                            if (dtUser.Rows[0]["ET_ID_FK"].ToString() == "6")
                            {
                            }
                            else
                            {
                                string time = DateTime.Now.ToString("HH:mm:ss");
                                DataTable dtTime = new DataTable();
                                objUSerFoodLogBAO.ProcedureType = "ET";
                                dtTime = UserFoodLogDAO.GetFoodCategories(objUSerFoodLogBAO);
                                if (dtTime.Rows.Count > 0)
                                {
                                    timeStart = dtTime.Rows[5]["ET_START_TIME"].ToString();
                                    timeEnd = dtTime.Rows[5]["ET_END_TIME"].ToString();
                                }
                                if (Convert.ToDateTime(time) > Convert.ToDateTime(timeStart) && Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {
                                }
                                else if (Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                {

                                }
                                else
                                {
                                    DataTable dtname = new DataTable();
                                    objUserRegisterBAO.ID = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                    objUserRegisterBAO.procedureType = "E";
                                    dtname = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                                    if (dtname.Rows.Count > 0)
                                    {
                                        Username = Convert.ToString(dtname.Rows[0]["login_email"]);
                                    }
                                    string subject = "Food Log Detail";
                                    String Body = "No entry exist for Dinner today.";

                                    objScheduleMail.SendScheduleMail(subject, Username, Body);
                                }
                            }
                        }
                        else
                        {
                            string time = DateTime.Now.ToString("HH:mm:ss");
                            DataTable dtTime = new DataTable();
                            objUSerFoodLogBAO.ProcedureType = "ET";
                            dtTime = UserFoodLogDAO.GetFoodCategories(objUSerFoodLogBAO);
                            if (dtTime.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtTime.Rows.Count; j++)
                                {
                                    timeStart = dtTime.Rows[j]["ET_START_TIME"].ToString();
                                    timeEnd = dtTime.Rows[j]["ET_END_TIME"].ToString();
                                    if (Convert.ToDateTime(time) > Convert.ToDateTime(timeStart) || Convert.ToDateTime(time) < Convert.ToDateTime(timeEnd))
                                    {
                                        DataTable dtname = new DataTable();
                                        objUserRegisterBAO.ID = Convert.ToInt32(dt.Rows[i]["fk_user_registration_id"]);
                                        objUserRegisterBAO.procedureType = "E";
                                        dtname = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                                        if (dtname.Rows.Count > 0)
                                        {
                                            Username = Convert.ToString(dtname.Rows[0]["login_email"]);
                                        }
                                        string subject = "Food Log Detail";
                                        if (j == 0)
                                        {
                                            Body = "No entry exist for Breakfast today.";
                                        }
                                        else if (j == 1)
                                        {
                                            Body = "No entry exist for Morning Snacks today.";
                                        }
                                        else if (j == 2)
                                        {
                                            Body = "No entry exist for Lunch today.";
                                        }
                                        else if (j == 4)
                                        {
                                            Body = "No entry exist for Evening Snacks today.";
                                        }
                                        else if (j == 5)
                                        {
                                            Body = "No entry exist for Dinner today.";
                                        }

                                        objScheduleMail.SendScheduleMail(subject, Username, Body);
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
            }

        }                                 
        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 30;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}