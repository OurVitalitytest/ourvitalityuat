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
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
namespace ALEREIMPACT.Admin
{
    public partial class AdminChangePassword : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        // change password button//
        protected void btnchgpwd_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.pk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objAdminBAO.login_password = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtPassword.Text);
                objAdminBAO.ProcedureType = "S";
                dt = AdminDAO.GetPassword(objAdminBAO);
                if (dt.Rows.Count == 0)
                {
                    lberrormsg.Visible = true;
                    lberrormsg.Text = "Password not found!";
                }
                else
                {
                    int param = 0;
                    objAdminBAO.pk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.login_password = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(txtNewPassword.Text);
                    objAdminBAO.ProcedureType = "U";
                    param = AdminDAO.UpdatePassword(objAdminBAO);
                    Response.Write("<script>alert('Password has been changed successfully') ; location.href='AdminLogin.aspx'</script>");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
          
        }
// logout button//
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
               // MySession.Current.LoginId = null;
                Response.Redirect("AdminDashboard.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



    }
}
