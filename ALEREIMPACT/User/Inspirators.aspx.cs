using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using System.Web.Services;
namespace ALEREIMPACT.User
{
    public partial class Inspirators : System.Web.UI.Page
    {
        public static Int32 pageid = 0;
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
                        if (Convert.ToString(Session["MyInspirator"]) == "True")
                        {
                            dvInspLibrary.Visible = false;
                            dvInspirator.Visible = false;
                            //dvInspDescription.Visible = false;
                            //dvMyInspirator.Visible = true;
                            //dvFriendInspirator.Visible = false;
                            Session["MyInspirator"] = null;

                        }
                        else if (Convert.ToString(Session["FriendInspirator"]) == "True")
                        {
                            dvInspLibrary.Visible = false;
                            dvInspirator.Visible = false;
                            //dvMyInspirator.Visible = false;
                            //dvFriendInspirator.Visible = true;
                            //dvInspDescription.Visible = false;
                            Session["FriendInspirator"] = null;

                        }
                        else if (Convert.ToString(Request.QueryString["val"]) != null)
                        {
                            dvInspLibrary.Visible = false;
                            dvInspirator.Visible = false;
                            //dvMyInspirator.Visible = false;
                            //dvFriendInspirator.Visible =false;
                            //dvInspDescription.Visible = true;
                            Session["InspDescription"] = null;

                        }
                        else if (Convert.ToString(Session["LibraryInspirator"]) == "True")
                        {
                            dvInspLibrary.Visible = true;
                            dvInspirator.Visible = false;
                            //dvMyInspirator.Visible = false;
                            //dvFriendInspirator.Visible = false;
                            //dvInspDescription.Visible = false;
                            Session["LibraryInspirator"] = null;

                        }
                        else
                        {
                            dvInspLibrary.Visible = false;
                            dvInspirator.Visible = true;
                            //dvMyInspirator.Visible = false;
                            //dvFriendInspirator.Visible = false;
                            //dvInspDescription.Visible = false;
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
