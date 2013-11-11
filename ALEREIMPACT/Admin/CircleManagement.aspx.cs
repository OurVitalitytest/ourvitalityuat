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
    public partial class CircleManagement : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

              
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

        // bind gridview//
        private DataTable BindGridView()
        {

            DataTable dt = new DataTable();
            try
            {
                objAdminBAO.ProcedureType = "C";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                grdCircles.DataSource = dt;
                grdCircles.DataBind();
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

        protected void grdCircles_Sorting(object sender, GridViewSortEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            GridViewSortExpression = e.SortExpression;
            int pageIndex = grdCircles.PageIndex;
            grdCircles.DataSource = SortDataTable(BindGridView(), false);
            grdCircles.DataBind();
            grdCircles.PageIndex = pageIndex;
        }

        protected void grdCircles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkCircle")
                {
                    string val = e.CommandArgument.ToString();
                    Response.Redirect("USerCircleDetail.aspx?val=" + val, false);
                    Session["Circle"] = true;
                }
                else if (e.CommandName == "lnkFreindCircle")
                {
                    string val = e.CommandArgument.ToString();
                    string val1 = "1";
                    Response.Redirect("USerCircleDetail.aspx?val=" + val + "&val1=" + val1, false);
                    Session["Circle"] = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grdCircles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            grdCircles.DataSource = SortDataTable(BindGridView(), true);
            grdCircles.PageIndex = e.NewPageIndex;
            grdCircles.DataBind();
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

        protected void grdCircles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkCircle = (LinkButton)e.Row.FindControl("lnkCircle");
                    LinkButton lnkFreindCircle = (LinkButton)e.Row.FindControl("lnkFreindCircle");
                    if (lnkCircle.Text == "0")
                    {
                        lnkCircle.Enabled = false;
                        lnkCircle.Style.Add("color", "#555");
                    }

                    if (lnkFreindCircle.Text == "0")
                    {
                        lnkFreindCircle.Enabled = false;
                        lnkFreindCircle.Style.Add("color", "#555");
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
