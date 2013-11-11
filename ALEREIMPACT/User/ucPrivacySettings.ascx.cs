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
    public partial class ucPrivacySettings : System.Web.UI.UserControl
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
                        getPrivacy();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



        private void getPrivacy()     //Get User Privacy Settings//
        {
            try
            {
                DataTable dt = new DataTable();
                objUserRegisterBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserRegisterBAO.procedureType = "PS";
                dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToString(dt.Rows[i]["PS_ID_FK"]) == "1")
                            {
                                if (Convert.ToString(dt.Rows[i]["UPS_YOU"]) == "True")
                                {
                                    rdbtnProfilepic.SelectedValue = "1";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_FRIENDS"]) == "True")
                                {
                                    rdbtnProfilepic.SelectedValue = "2";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_ANYONE"]) == "True")
                                {
                                    rdbtnProfilepic.SelectedValue = "3";
                                }
                            }
                            if (Convert.ToString(dt.Rows[i]["PS_ID_FK"]) == "2")
                            {
                                if (Convert.ToString(dt.Rows[i]["UPS_YOU"]) == "True")
                                {
                                    rdbtnHeight.SelectedValue = "1";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_FRIENDS"]) == "True")
                                {
                                    rdbtnHeight.SelectedValue = "2";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_ANYONE"]) == "True")
                                {
                                    rdbtnHeight.SelectedValue = "3";
                                }
                            }
                            if (Convert.ToString(dt.Rows[i]["PS_ID_FK"]) == "3")
                            {
                                if (Convert.ToString(dt.Rows[i]["UPS_YOU"]) == "True")
                                {
                                    rdbtnWeight.SelectedValue = "1";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_FRIENDS"]) == "True")
                                {
                                    rdbtnWeight.SelectedValue = "2";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_ANYONE"]) == "True")
                                {
                                    rdbtnWeight.SelectedValue = "3";
                                }
                            }
                            if (Convert.ToString(dt.Rows[i]["PS_ID_FK"]) == "4")
                            {
                                if (Convert.ToString(dt.Rows[i]["UPS_YOU"]) == "True")
                                {
                                    rdbtnDOB.SelectedValue = "1";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_FRIENDS"]) == "True")
                                {
                                    rdbtnDOB.SelectedValue = "2";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_ANYONE"]) == "True")
                                {
                                    rdbtnDOB.SelectedValue = "3";
                                }
                            }
                            if (Convert.ToString(dt.Rows[i]["PS_ID_FK"]) == "5")
                            {
                                if (Convert.ToString(dt.Rows[i]["UPS_YOU"]) == "True")
                                {
                                    rdbtnLocation.SelectedValue = "1";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_FRIENDS"]) == "True")
                                {
                                    rdbtnLocation.SelectedValue = "2";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_ANYONE"]) == "True")
                                {
                                    rdbtnLocation.SelectedValue = "3";
                                }
                            }
                            if (Convert.ToString(dt.Rows[i]["PS_ID_FK"]) == "6")
                            {
                                if (Convert.ToString(dt.Rows[i]["UPS_YOU"]) == "True")
                                {
                                    rdbtnFreinds.SelectedValue = "1";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_FRIENDS"]) == "True")
                                {
                                    rdbtnFreinds.SelectedValue = "2";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_ANYONE"]) == "True")
                                {
                                    rdbtnFreinds.SelectedValue = "3";
                                }
                            }
                            if (Convert.ToString(dt.Rows[i]["PS_ID_FK"]) == "9")
                            {
                                if (Convert.ToString(dt.Rows[i]["UPS_YOU"]) == "True")
                                {
                                    rdbtnEmail.SelectedValue = "1";
                                }
                                else if (Convert.ToString(dt.Rows[i]["UPS_FRIENDS"]) == "True")
                                {
                                    rdbtnEmail.SelectedValue = "2";
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
            objUserRegisterBAO.procedureType = "PS";
            dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int retval = 0;
                    objUserPrivacySettings.UPS_ID = dt.Rows[j]["UPS_ID"].ToString();
                    objUserPrivacySettings.PS_ID_FK = dt.Rows[j]["PS_ID_FK"].ToString();
                    objUserPrivacySettings.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    if (dt.Rows[j]["PS_ID_FK"].ToString() == "1")
                    {
                        if (rdbtnProfilepic.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                        else if (rdbtnProfilepic.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UPS_FRIENDS = true;
                            objUserPrivacySettings.UPS_ANYONE = false;
                            objUserPrivacySettings.UPS_YOU = false;
                        }
                        else if (rdbtnProfilepic.SelectedValue == "3")
                        {
                            objUserPrivacySettings.UPS_ANYONE = true;
                            objUserPrivacySettings.UPS_YOU = false;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                        }
                    }

                    if (dt.Rows[j]["PS_ID_FK"].ToString() == "2")
                    {
                        if (rdbtnHeight.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                        else if (rdbtnHeight.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UPS_FRIENDS = true;
                            objUserPrivacySettings.UPS_ANYONE = false;
                            objUserPrivacySettings.UPS_YOU = false;
                        }
                        else if (rdbtnHeight.SelectedValue == "3")
                        {
                            objUserPrivacySettings.UPS_ANYONE = true;
                            objUserPrivacySettings.UPS_YOU = false;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                        }
                    }
                    if (dt.Rows[j]["PS_ID_FK"].ToString() == "3")
                    {
                        if (rdbtnWeight.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                        else if (rdbtnWeight.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UPS_FRIENDS = true;
                            objUserPrivacySettings.UPS_ANYONE = false;
                            objUserPrivacySettings.UPS_YOU = false;
                        }
                        else
                        {
                            objUserPrivacySettings.UPS_ANYONE = true;
                            objUserPrivacySettings.UPS_YOU = false;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                        }
                    }
                    if (dt.Rows[j]["PS_ID_FK"].ToString() == "4")
                    {
                        if (rdbtnDOB.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                        else if (rdbtnDOB.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UPS_FRIENDS = true;
                            objUserPrivacySettings.UPS_ANYONE = false;
                            objUserPrivacySettings.UPS_YOU = false;
                        }
                        else
                        {
                            objUserPrivacySettings.UPS_ANYONE = true;
                            objUserPrivacySettings.UPS_YOU = false;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                        }
                    }
                    if (dt.Rows[j]["PS_ID_FK"].ToString() == "5")
                    {
                        if (rdbtnLocation.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                        else if (rdbtnLocation.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UPS_FRIENDS = true;
                            objUserPrivacySettings.UPS_ANYONE = false;
                            objUserPrivacySettings.UPS_YOU = false;
                        }
                        else
                        {
                            objUserPrivacySettings.UPS_ANYONE = true;
                            objUserPrivacySettings.UPS_YOU = false;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                        }
                    }
                    if (dt.Rows[j]["PS_ID_FK"].ToString() == "6")
                    {
                        if (rdbtnFreinds.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                        else if (rdbtnFreinds.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UPS_FRIENDS = true;
                            objUserPrivacySettings.UPS_ANYONE = false;
                            objUserPrivacySettings.UPS_YOU = false;
                        }
                        else
                        {
                            objUserPrivacySettings.UPS_ANYONE = true;
                            objUserPrivacySettings.UPS_YOU = false;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                        }
                    }
                    if (dt.Rows[j]["PS_ID_FK"].ToString() == "9")
                    {
                        if (rdbtnEmail.SelectedValue == "1")
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                        else if (rdbtnEmail.SelectedValue == "2")
                        {
                            objUserPrivacySettings.UPS_FRIENDS = true;
                            objUserPrivacySettings.UPS_ANYONE = false;
                            objUserPrivacySettings.UPS_YOU = false;
                        }
                        else
                        {
                            objUserPrivacySettings.UPS_YOU = true;
                            objUserPrivacySettings.UPS_FRIENDS = false;
                            objUserPrivacySettings.UPS_ANYONE = false;
                        }
                    }
                    objUserPrivacySettings.ProcedureType = "U";
                    retval = privacySettingDAO.InserttblUserPrivacySetting(objUserPrivacySettings);

                }
            }
            else
            {
                DataTable dtPrivacy = new DataTable();
                objUserFoodLogBAo.ProcedureType = "PS";
                dtPrivacy = UserFoodLogDAO.GetFoodCategories(objUserFoodLogBAo);
                if (dtPrivacy.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPrivacy.Rows.Count; i++)
                    {
                        int retval = 0;
                        objUserPrivacySettings.UPS_ID = 0;
                        objUserPrivacySettings.PS_ID_FK = Convert.ToInt32(dtPrivacy.Rows[i]["PS_ID"]);
                        objUserPrivacySettings.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        if (i == 0)
                        {
                            if (rdbtnProfilepic.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                            else if (rdbtnProfilepic.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UPS_FRIENDS = true;
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                            }
                            else
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                        }
                        else if (i == 1)
                        {
                            if (rdbtnHeight.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                            else if (rdbtnHeight.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UPS_FRIENDS = true;
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                            }
                            else
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                        }
                        else if (i == 2)
                        {
                            if (rdbtnWeight.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                            else if (rdbtnWeight.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UPS_FRIENDS = true;
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                            }
                            else
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                        }
                        else if (i == 3)
                        {
                            if (rdbtnDOB.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                            else if (rdbtnDOB.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UPS_FRIENDS = true;
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                            }
                            else
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                        }
                        else if (i == 4)
                        {
                            if (rdbtnLocation.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                            else if (rdbtnLocation.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UPS_FRIENDS = true;
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                            }
                            else
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                        }
                        else if (i == 5)
                        {
                            if (rdbtnFreinds.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                            else if (rdbtnFreinds.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UPS_FRIENDS = true;
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                            }
                            else
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                        }
                        else if (i == 6)
                        {
                            if (rdbtnEmail.SelectedValue == "1")
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                            else if (rdbtnEmail.SelectedValue == "2")
                            {
                                objUserPrivacySettings.UPS_FRIENDS = true;
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                            }
                            else
                            {
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;
                            }
                        }
                        objUserPrivacySettings.ProcedureType = "I";
                        retval = privacySettingDAO.InserttblUserPrivacySetting(objUserPrivacySettings);
                    }
                }
            }

            Response.Redirect("FeedBackAndProblem.aspx?val=" + 4, false);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeedBackAndProblem.aspx", false);
        }
    }
}