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
    public partial class FeedBackMessage : System.Web.UI.Page
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
                        bindGrd();
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
        private void bindGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "FM";
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
                    Panel1.Visible = true;
                    PanelReply.Visible = false;

                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(e.CommandArgument);
                    objAdminBAO.ProcedureType = "FM";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    int retval = 0;
                    objAdminBAO.FB_ID = Convert.ToInt32(e.CommandArgument);
                    objAdminBAO.fk_user_registration_id = dt.Rows[0]["fk_user_registration_id"].ToString();
                    objAdminBAO.PAGE_ID_FK = dt.Rows[0]["PAGE_ID_FK"].ToString();
                    objAdminBAO.FB_MESSAGE = dt.Rows[0]["FB_MESSAGE"].ToString();
                    objAdminBAO.FB_DATE = dt.Rows[0]["date1"].ToString();
                    objAdminBAO.FB_RATING = dt.Rows[0]["FB_RATING"].ToString();
                    objAdminBAO.FB_STATUS = "True";
                    objAdminBAO.ProcedureType = "U";
                    retval = AdminDAO.UpdatetblFeedBack(objAdminBAO);
                    bindGrd();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label Label1 = (Label)e.Row.FindControl("Label1");
                    AjaxControlToolkit.Rating Rating1 = (AjaxControlToolkit.Rating)e.Row.FindControl("Rating1");

                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(Label1.Text);
                    objAdminBAO.ProcedureType = "FM";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["FB_RATING"].ToString() == "0")
                        {
                            Rating1.CurrentRating = 0;
                            Rating1.Style.Add(" cursor", "none");
                            Rating1.Enabled = false;
                        }
                        else
                        {
                            Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["FB_RATING"]);
                            Rating1.Style.Add(" cursor", "none");
                            Rating1.Enabled = false;
                        }
                    }

                }
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                    Label Label1 = (Label)e.Row.FindControl("Label1");
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(Label1.Text);
                    objAdminBAO.ProcedureType = "FM";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["FB_STATUS"].ToString() == "False")
                        {
                            LinkButton1.Style.Add("background-color", "#999999");
                        }
                        else
                        {
                            LinkButton1.Style.Add("background-color", "#EEEEEE");
                        }
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
