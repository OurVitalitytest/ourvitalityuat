using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using System.Web.Services;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAO.User;

namespace ALEREIMPACT.User
{
    public partial class PendingFriendRequests : System.Web.UI.Page
    {
       

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
