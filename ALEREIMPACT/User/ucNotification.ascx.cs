using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;

namespace ALEREIMPACT.User
{
    public partial class ucNotification : System.Web.UI.UserControl
    {
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        PrivacySettingBAO objUserPrivacySettings = new PrivacySettingBAO();
        UserFoodLogBAO objUserFoodLogBAo = new UserFoodLogBAO();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);

                }
                else
                {
                    if (!IsPostBack)
                    {
                        getNotification();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void getNotification()     //Get User Notification//
        {
            try
            {
                DataTable dt = new DataTable();
                objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserRegisterBAO.procedureType = "UN";
                dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["UNM_ID_FK"].ToString() == "1")
                            {
                                if (dt.Rows[i]["UN_NOTIFICATION_DAILY"].ToString() == "True")
                                {
                                    rdbtnList.SelectedValue = "1";
                                }
                                else if (dt.Rows[i]["UN_NOTIFICATION_WEEKLY"].ToString() == "True")
                                {
                                    rdbtnList.SelectedValue = "2";
                                }
                                else if (dt.Rows[i]["UN_NOTIFICATION_MONTHLY"].ToString() == "True")
                                {
                                    rdbtnList.SelectedValue = "3";
                                }
                                else if (dt.Rows[i]["UN_NOTIFICATION_OFF"].ToString() == "True")
                                {
                                    rdbtnList.SelectedValue = "4";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            objUserRegisterBAO.procedureType = "UN";
            dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int retval = 0;
                    objUserPrivacySettings.UN_ID = dt.Rows[i]["UN_ID"].ToString();
                    objUserPrivacySettings.UNM_ID_FK = dt.Rows[i]["UNM_ID_FK"].ToString();
                    objUserPrivacySettings.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    if (dt.Rows[i]["UNM_ID_FK"].ToString() == "1")
                    {
                        if (rdbtnList.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UN_NOTIFICATION_DAILY = true;
                            objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_OFF = false;
                        }
                        else if (rdbtnList.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UN_NOTIFICATION_DAILY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = true;
                            objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_OFF = false;
                            
                        }
                        else if (rdbtnList.SelectedValue == "3")
                        {
                            objUserPrivacySettings.UN_NOTIFICATION_DAILY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = true;
                            objUserPrivacySettings.UN_NOTIFICATION_OFF = false;
                          
                        }
                        else if (rdbtnList.SelectedValue == "4")
                        {
                            objUserPrivacySettings.UN_NOTIFICATION_DAILY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = false;
                            objUserPrivacySettings.UN_NOTIFICATION_OFF = true;
                        }
                    }
                    objUserPrivacySettings.ProcedureType = "U";
                    retval = privacySettingDAO.InserttblUserNotification(objUserPrivacySettings);
                }

            }
            else
            {
                DataTable dtnotification = new DataTable();
                objUserFoodLogBAo.ProcedureType = "UN";
                dtnotification = UserFoodLogDAO.GetFoodCategories(objUserFoodLogBAo);
                if (dtnotification.Rows.Count > 0)
                {
                    for (int j = 0; j < dtnotification.Rows.Count; j++)
                    {
                        int retval = 0;
                        objUserPrivacySettings.UN_ID = 0;
                        objUserPrivacySettings.UNM_ID_FK = Convert.ToInt32(dtnotification.Rows[j]["UNM_ID"]);
                        objUserPrivacySettings.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        if (j == 0)
                        {
                            if (rdbtnList.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UN_NOTIFICATION_DAILY = true;
                                objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_OFF = false;
                            }
                            else if (rdbtnList.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UN_NOTIFICATION_DAILY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = true;
                                objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_OFF = false;

                            }
                            else if (rdbtnList.SelectedValue == "3")
                            {
                                objUserPrivacySettings.UN_NOTIFICATION_DAILY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = true;
                                objUserPrivacySettings.UN_NOTIFICATION_OFF = false;

                            }
                            else if (rdbtnList.SelectedValue == "4")
                            {
                                objUserPrivacySettings.UN_NOTIFICATION_DAILY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_WEEKLY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_MONTHLY = false;
                                objUserPrivacySettings.UN_NOTIFICATION_OFF = true;
                            }
                        }
                        objUserPrivacySettings.ProcedureType = "I";
                        retval = privacySettingDAO.InserttblUserNotification(objUserPrivacySettings);
                    }
                }
            }

            Response.Redirect("FeedBackAndProblem.aspx?val=" + 5, false);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeedBackAndProblem.aspx", false);
        }
    }
}