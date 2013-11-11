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
    public partial class MissionManagement : System.Web.UI.Page
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
                objAdminBAO.ProcedureType = "M";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkMission")
                {
                    string val = e.CommandArgument.ToString();
                    Response.Redirect("MissionDetail.aspx?val=" + val, false);
                    Session["Mission"] = true;
                }
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
                    LinkButton lnkMission = (LinkButton)e.Row.FindControl("lnkMission");
                    if (lnkMission.Text == "0")
                    {
                        lnkMission.Enabled = false;
                        lnkMission.Style.Add("color", "#555");
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
