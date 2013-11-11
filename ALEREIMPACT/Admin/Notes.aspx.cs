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
    public partial class Notes : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        public static DateTime date1;
        public static DateTime date2;
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
                        userid = Convert.ToInt32(Request.QueryString["val"]);
                        date1 = Convert.ToDateTime(Request.QueryString["date1"]);
                        date2 = Convert.ToDateTime(Request.QueryString["date2"]);
                        if (Convert.ToString(Request.QueryString["val1"]) == "1")
                        {
                            PanleNotes.Visible = true;
                            PanelCircle.Visible = false;
                            PanelInspirator.Visible = false;
                            PanelMission.Visible = false;
                            PanleGrdNote.Visible = true;
                        }
                        else if (Convert.ToString(Request.QueryString["val1"]) == "2")
                        {
                            PanleNotes.Visible = false;
                            PanelCircle.Visible = true;
                            PanelInspirator.Visible = false;
                            PanelMission.Visible = false;
                            PanelGRdCircle.Visible = true;
                        }
                        else if (Convert.ToString(Request.QueryString["val1"]) == "3")
                        {
                            PanleNotes.Visible = false;
                            PanelCircle.Visible = false;
                            PanelInspirator.Visible = true;
                            PanelMission.Visible = false;
                            PanelGrdInsprator.Visible = true;
                        }
                        else if (Convert.ToString(Request.QueryString["val1"]) == "4")
                        {
                            PanleNotes.Visible = false;
                            PanelCircle.Visible = false;
                            PanelInspirator.Visible = false;
                            PanelMission.Visible = true;
                            PanelGrdMission.Visible = true;
                        }
                        getname();
                        bindGrd();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void getname()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ProcedureType = "N1";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    lbname2.Text = dt.Rows[0]["usercode"].ToString();
                    lbname.Text = dt.Rows[0]["usercode"].ToString();
                    lbname1.Text = dt.Rows[0]["usercode"].ToString();
                    lbname3.Text = dt.Rows[0]["usercode"].ToString();
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
                objAdminBAO.fk_user_registration_Id = userid;
                objAdminBAO.date1 = date1;
                objAdminBAO.date2 = date2;
                if (Convert.ToString(Request.QueryString["val1"]) == "1")
                {
                    objAdminBAO.ProcedureType = "N";
                    dt = AdminDAO.GetUserAnalyticsDetail(objAdminBAO);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (Convert.ToString(Request.QueryString["val1"]) == "2")
                {
                    objAdminBAO.ProcedureType = "C";
                    dt = AdminDAO.GetUserAnalyticsDetail(objAdminBAO);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else if (Convert.ToString(Request.QueryString["val1"]) == "3")
                {
                    objAdminBAO.ProcedureType = "I";
                    dt = AdminDAO.GetUserAnalyticsDetail(objAdminBAO);
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                else if (Convert.ToString(Request.QueryString["val1"]) == "4")
                {
                    objAdminBAO.ProcedureType = "M";
                    dt = AdminDAO.GetUserAnalyticsDetail(objAdminBAO);
                    GridView4.DataSource = dt;
                    GridView4.DataBind();
                }
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

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView2.PageIndex = e.NewPageIndex;
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView3.PageIndex = e.NewPageIndex;
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView4.PageIndex = e.NewPageIndex;
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
