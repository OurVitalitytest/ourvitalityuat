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
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;

namespace ALEREIMPACT.Admin
{
    public partial class ViewTicketsReply : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 User_id = 0;
        public static Int32 msg_id = 0;
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
                else
                {
                    if (!IsPostBack)
                    {
                        User_id = Convert.ToInt32(Request.QueryString["User_id"]);
                        msg_id = Convert.ToInt32(Request.QueryString["msg_id"]);
                        lbTicketNumber.Text = Convert.ToString(Request.QueryString["msg_id"]);
                        bindGrd();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

       

        private void bindGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = msg_id;
                objAdminBAO.ProcedureType = "TR";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkMsg_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("MessagesandTickets.aspx", false);
                Session["FeedBack"] = true;
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
                Response.Redirect("TicketMesssages.aspx", false);
                Session["FeedBack"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
