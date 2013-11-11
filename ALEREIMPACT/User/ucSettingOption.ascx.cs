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
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAO.User;


namespace ALEREIMPACT.User
{
    public partial class ucSettingOption : System.Web.UI.UserControl
    {
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        PrivacySettingBAO objUserPrivacySettings = new PrivacySettingBAO();
        UserFoodLogBAO objUserFoodLogBAo = new UserFoodLogBAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                //if (!Page.IsPostBack)
                //{
                if (Convert.ToString(Request.QueryString["val"]) == "1")
                {
                    Label1.Visible = true;
                    Label4.Visible = false;
                }
                else if (Convert.ToString(Request.QueryString["val"]) == "2")
                {
                    Label1.Visible = false;
                    Label4.Visible = true;
                }
                else if (Convert.ToString(Request.QueryString["val"]) == "3")
                {
                    Label1.Visible = false;
                    Label4.Visible = true;
                    Label4.Text = "Password Change Sucessfully.";
                }
                else if (Convert.ToString(Request.QueryString["val"]) == "4")
                {
                    Label1.Visible = false;
                    Label4.Visible = true;
                    Label4.Text = "Privacy Settings has been updated.";
                }
                else if (Convert.ToString(Request.QueryString["val"]) == "5")
                {
                    Label1.Visible = false;
                    Label4.Visible = true;
                    Label4.Text = "Notifications has been updated.";
                }
                else
                {
                    Label1.Visible = false;
                    Label4.Visible = false;
                }
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkFeedBAck_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["FeedBack"] = "True";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void LnkProblem_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["ReportProblem"] = "True";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkTicket_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["Tickets"] = "True";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["ChangePassword"] = "True";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkPrivacy_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["Privacy"] = "True";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkNotification_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["Notification"] = "True";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}