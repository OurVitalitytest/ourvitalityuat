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
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.DAO.User;
using System.Web.Services;

namespace ALEREIMPACT.User
{
    public partial class FeedBackAndProblem : System.Web.UI.Page
    {
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
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
                    MySession.Current.MemberUserId = null;
                    MySession.Current.PublicCircleUserId = null;
                    MySession.Current.PublicCircleId = null;
                    MySession.Current.MemberCircleId = null;
                    MySession.Current.searchfriendId = null;
                    if (!IsPostBack)
                    {
                        if (Convert.ToString(Session["FeedBack"]) == "True")
                        {
                            dvChangePassword.Visible = false;
                            dvFeedBack.Visible = true;
                            dvSetting.Visible = false;
                            dvTickets.Visible = false;
                            dvREportProblem.Visible = false;
                            dvNotification.Visible = false;
                            dvPrivacy.Visible = false;
                            Session["FeedBack"] = null;
                        }
                        else if (Convert.ToString(Session["ReportProblem"]) == "True")
                        {
                            dvChangePassword.Visible = false;
                            dvFeedBack.Visible = false;
                            dvSetting.Visible = false;
                            dvTickets.Visible = false;
                            dvNotification.Visible = false;
                            dvPrivacy.Visible = false;
                            dvREportProblem.Visible = true;
                            Session["ReportProblem"] = null;
                        }
                        else if (Convert.ToString(Session["Tickets"]) == "True")
                        {
                            dvChangePassword.Visible = false;
                            dvFeedBack.Visible = false;
                            dvSetting.Visible = false;
                            dvTickets.Visible = true;
                            dvNotification.Visible = false;
                            dvPrivacy.Visible = false;
                            dvREportProblem.Visible = false;
                            Session["Tickets"] = null;
                        }
                        else if (Convert.ToString(Session["ChangePassword"]) == "True")
                        {
                            dvChangePassword.Visible = true;
                            dvFeedBack.Visible = false;
                            dvSetting.Visible = false;
                            dvTickets.Visible = false;
                            dvNotification.Visible = false;
                            dvPrivacy.Visible = false;
                            dvREportProblem.Visible = false;
                            Session["ChangePassword"] = null;
                        }
                        else if (Convert.ToString(Session["Privacy"]) == "True")
                        {
                            dvChangePassword.Visible = false;
                            dvFeedBack.Visible = false;
                            dvSetting.Visible = false;
                            dvTickets.Visible = false;
                            dvNotification.Visible = false;
                            dvPrivacy.Visible = true;
                            dvREportProblem.Visible = false;
                            Session["Privacy"] = null;
                        }
                        else if (Convert.ToString(Session["Notification"]) == "True")
                        {
                            dvChangePassword.Visible = false;
                            dvFeedBack.Visible = false;
                            dvSetting.Visible = false;
                            dvTickets.Visible = false;
                            dvNotification.Visible = true;
                            dvPrivacy.Visible = false;
                            dvREportProblem.Visible = false;
                            Session["Notification"] = null;
                        }
                        else
                        {
                            dvChangePassword.Visible = false;
                            dvFeedBack.Visible = false;
                            dvSetting.Visible = true;
                            dvNotification.Visible = false;
                            dvPrivacy.Visible = false;
                            dvTickets.Visible = false;
                            dvREportProblem.Visible = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        [WebMethod]
        public static string ProcessIT()
        {
            RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
            int retval = 0;
            objRegisterUserBAO.AT_ID = Convert.ToInt32(MySession.Current.ATId);
            objRegisterUserBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            objRegisterUserBAO.AT_LOGOUTTIME = Convert.ToString(DateTime.Now);
            objRegisterUserBAO.procedureType = "U";
            retval = RegisterUserDAO.UpdatetblAuditTrail(objRegisterUserBAO);
            return "";

        }

    }
}
