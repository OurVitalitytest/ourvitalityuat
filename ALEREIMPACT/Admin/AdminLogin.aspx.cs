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
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.FRAMEWORK;

namespace ALEREIMPACT.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        AdminBAO objAdminUserBAO = new AdminBAO();
        public static string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
        }
        // login Button//
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objAdminUserBAO.login_email = txtusername.Text.Trim() ;
                objAdminUserBAO.login_password = (txtPassword.Text);
                objAdminUserBAO.ProcedureType = "S";
                dt = AdminDAO.GettbAdminUser(objAdminUserBAO);
                if (dt.Rows.Count > 0)
                {
                    MySession.Current.LoginId = dt.Rows[0]["pk_user_registration_Id"].ToString();
                    userid = MySession.Current.LoginId;
                    Response.Redirect("AdminDashboard.aspx?val=" + userid, false);
                }
                else
                {
                    Response.Write("<script>alert('Username/Password is Incorrect') ; location.href='AdminLogin.aspx'</script>");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
