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
    public partial class UserAnalytics : System.Web.UI.Page
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
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private DataTable BindGridView()
        {

            DataTable dt = new DataTable();
            try
            {
                objAdminBAO.ProcedureType = "UA";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {

                dt.Dispose();
            }
            return dt;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.PageIndex = e.NewPageIndex;
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
                if (e.CommandName == "LnkNotes")
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(',');
                    string userid = (arg[0]);
                    Session["date1"] = arg[1];
                    Session["date2"] = arg[2];
                    Response.Redirect("Notes.aspx?val=" + userid + "&date1=" + Session["date1"] + "&date2=" + Session["date2"] + "&val1=" + 1, false);
                }
                else if (e.CommandName == "LnkCircles")
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(',');
                    string userid = (arg[0]);
                    Session["date1"] = arg[1];
                    Session["date2"] = arg[2];
                    Response.Redirect("Notes.aspx?val=" + userid + "&date1=" + Session["date1"] + "&date2=" + Session["date2"] + "&val1=" + 2, false);
                }
                else if (e.CommandName == "LnkInspirators")
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(',');
                    string userid = (arg[0]);
                    Session["date1"] = arg[1];
                    Session["date2"] = arg[2];
                    Response.Redirect("Notes.aspx?val=" + userid + "&date1=" + Session["date1"] + "&date2=" + Session["date2"] + "&val1=" + 3, false);
                }
                else if (e.CommandName == "LnkMission")
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(',');
                    string userid = (arg[0]);
                    Session["date1"] = arg[1];
                    Session["date2"] = arg[2];
                    Response.Redirect("Notes.aspx?val=" + userid + "&date1=" + Session["date1"] + "&date2=" + Session["date2"] + "&val1=" + 4, false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridViewSortExpression = e.SortExpression;
                int pageIndex = GridView1.PageIndex;
                GridView1.DataSource = SortDataTable(BindGridView(), false);
                GridView1.DataBind();
                GridView1.PageIndex = pageIndex;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected DataView SortDataTable(DataTable ptblDataTable, Boolean pblnIsPageIndexChanging)
        {
            if (ptblDataTable != null)
            {
                DataView dataView = new DataView(ptblDataTable);
                if (GridViewSortExpression != string.Empty)
                    if (pblnIsPageIndexChanging)
                        dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection);
                    else
                        dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GetSortDirection());
                return dataView;
            }
            else
                return new DataView();
        }

        #region " GridViewSortDirection Property "
        /// <summary>
        /// 
        /// </summary>
        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        #endregion

        #region " GridViewSortExpression Property "
        /// <summary>
        /// 
        /// </summary>
        private string GridViewSortExpression
        {
            get { return ViewState["SortExpression"] as string ?? string.Empty; }
            set { ViewState["SortExpression"] = value; }
        }
        #endregion

        #region " GetSortDirection Function "
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetSortDirection()
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    break;
            }
            return GridViewSortDirection;
        }
        #endregion

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkNotes = (LinkButton)e.Row.FindControl("lnkNotes");
                    LinkButton lnkCircles = (LinkButton)e.Row.FindControl("lnkCircles");
                    LinkButton lnkInspirators = (LinkButton)e.Row.FindControl("lnkInspirators");
                    LinkButton lnkMission = (LinkButton)e.Row.FindControl("lnkMission");
                    if (lnkNotes.Text == "0")
                    {
                        lnkNotes.Enabled = false;
                    }
                    else
                    {
                        lnkNotes.Enabled = true;
                        lnkNotes.Style.Add("color", "#31A5A0");
                        lnkNotes.Style.Add("text-decoration", "underline");
                    }
                    if (lnkCircles.Text == "0")
                    {
                        lnkCircles.Enabled = false;
                    }
                    else
                    {
                        lnkCircles.Enabled = true;
                        lnkCircles.Style.Add("color", "#31A5A0");
                        lnkCircles.Style.Add("text-decoration", "underline");
                    }
                    if (lnkInspirators.Text == "0")
                    {
                        lnkInspirators.Enabled = false;
                    }
                    else
                    {
                        lnkInspirators.Enabled = true;
                        lnkInspirators.Style.Add("color", "#31A5A0");
                        lnkInspirators.Style.Add("text-decoration", "underline");
                    }
                    if (lnkMission.Text == "0")
                    {
                        lnkMission.Enabled = false;
                    }
                    else
                    {
                        lnkMission.Enabled = true;
                        lnkMission.Style.Add("color", "#31A5A0");
                        lnkMission.Style.Add("text-decoration", "underline");
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
