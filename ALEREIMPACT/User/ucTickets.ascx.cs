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
    public partial class ucTickets : System.Web.UI.UserControl
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                ObjRegisterUserBAO.T_ID = 0;
                ObjRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                ObjRegisterUserBAO.T_MESSAGE = txtTickets.Text;
                ObjRegisterUserBAO.T_REPLYSTATUS = "False";
                ObjRegisterUserBAO.T_DATE = DateTime.Now.ToString();
                ObjRegisterUserBAO.T_STATUS = "False";
                ObjRegisterUserBAO.procedureType = "I";
                retval = RegisterUserDAO.InserttblTickets(ObjRegisterUserBAO);
                txtTickets.Text = "";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


    }
}