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
using System.Web.Services;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAO.User;

namespace ALEREIMPACT.User
{
    public partial class Notifications : System.Web.UI.Page
    {
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
