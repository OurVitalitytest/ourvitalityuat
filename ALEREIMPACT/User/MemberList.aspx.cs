using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.DAO.User;

namespace ALEREIMPACT.User
{
    public partial class MemberList : System.Web.UI.Page
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
                    if (Convert.ToString(Request.QueryString["circles"]) == "all")
                    {
                        dvmemberlist.Visible = false;
                        dvcircles.Visible = true;
                    }

                    else if (Session["Member_Profile"] != null)
                    {
                        divMemberProfile.Visible = true;
                        dvmemberlist.Visible = false;
                        dvcircles.Visible = false;
                    }
                    else
                    {
                        dvmemberlist.Visible = true;
                        dvcircles.Visible = false;
                        divMemberProfile.Visible = false;
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
