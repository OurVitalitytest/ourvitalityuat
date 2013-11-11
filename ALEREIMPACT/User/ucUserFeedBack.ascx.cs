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

namespace ALEREIMPACT.User
{
    public partial class ucUserFeedBack : System.Web.UI.UserControl
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        SQLHelper objSqlHelper = new SQLHelper();
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
                        fillDrpDown();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void fillDrpDown()
        {
            objSqlHelper.fillDrpControl(DrpPage, "spFillDrpDown", "PAGE_NAME", "PAGE_ID", "P");

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                ObjRegisterUserBAO.FB_ID = 0;
                ObjRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                ObjRegisterUserBAO.PAGE_ID_FK = DrpPage.SelectedValue;
                ObjRegisterUserBAO.FB_MESSAGE = txtFeedback.Text;
                ObjRegisterUserBAO.FB_DATE = DateTime.Now.ToString();
                ObjRegisterUserBAO.FB_RATING = ratingControl.CurrentRating;
                ObjRegisterUserBAO.FB_STATUS = "False";
                ObjRegisterUserBAO.procedureType = "I";
                retval = RegisterUserDAO.InserttblFeedBAck(ObjRegisterUserBAO);
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Thanks for contacting ALERE VITALITY. You should receive an email response shortly.');", true);
                txtFeedback.Text = "";
                DrpPage.SelectedIndex = 0;
                Response.Redirect("FeedBackAndProblem.aspx?val=" + 1, false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}