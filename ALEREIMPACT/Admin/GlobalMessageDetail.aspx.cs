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
    public partial class GlobalMessageDetail : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
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

                        BindGridView();

                        PanelReply.Visible = true;
                        Panel1.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BindGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "M1";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }




        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkMessage")
                {
                    PanelReply.Visible = false;
                    Panel1.Visible = true;
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = e.CommandArgument.ToString();
                    objAdminBAO.ProcedureType = "M3";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        lbmsg.Text = dt.Rows[0]["GM_MESSAGE"].ToString();
                    }

                    DataTable dt1 = new DataTable();
                    objAdminBAO.ID = e.CommandArgument.ToString();
                    objAdminBAO.ProcedureType = "M2";
                    dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt1.Rows.Count > 0)
                    {
                        lbreply.Visible = false;
                        Repeater1.Visible = true;
                        Repeater1.DataSource = dt1;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        lbreply.Visible = true;
                        lbreply.Text = "No Reply";
                        Repeater1.Visible = false;

                    }
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
