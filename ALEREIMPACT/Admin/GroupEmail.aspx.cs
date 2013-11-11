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
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.FRAMEWORK;

namespace ALEREIMPACT.Admin
{
    public partial class GroupEmail : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 groupid = 0;
        ClsGeneric objClsGeneric = new ClsGeneric();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                //Response.Cache.SetNoStore();
                //Response.AppendHeader("Pragma", "no-cache");
             
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        groupid = Convert.ToInt32(Request.QueryString["val"]);
                        groupname();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void groupname()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = groupid;
                objAdminBAO.ProcedureType = "GN";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    lbname.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                    lbTo.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

 
        protected void btnSend_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = groupid;
                objAdminBAO.ProcedureType = "GE";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string email = dt.Rows[i]["login_email"].ToString();
                        string subject = txtSubject.Text;
                        string body = txtmessage.Text;
                        objClsGeneric.SendMail(email, body, subject);
                        Response.Redirect("GroupDetail.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkGroup_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                Response.Redirect("GroupDetail.aspx", false);
                Session["Group"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
