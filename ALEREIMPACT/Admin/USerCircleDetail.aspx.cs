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
    public partial class USerCircleDetail : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
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
                        if (Convert.ToString(Request.QueryString["val1"]) == "" || Convert.ToString(Request.QueryString["val1"]) == null)
                        {
                            lbname.Text = "Self Created Circle Detail";
                            getname();
                            PanelUSerCircle.Visible = true;
                            PanelFreindCircle.Visible = false;
                            BindGridView();
                        }
                        else
                        {
                            lbname.Text = "Friend's Circle Detail";
                            getname();
                            PanelUSerCircle.Visible = false;
                            PanelFreindCircle.Visible = true;
                            BindGridView();
                        }


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
                objAdminBAO.ID = userid;
                if (Convert.ToString(Request.QueryString["val1"]) == "" || Convert.ToString(Request.QueryString["val1"]) == null)
                {
               
                    objAdminBAO.ProcedureType = "C4";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    grdCirclesDetail.DataSource = dt;
                    grdCirclesDetail.DataBind();
                }
                else
                {
                    objAdminBAO.ProcedureType = "C5";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    GrdFriendCircleDetail.DataSource = dt;
                    GrdFriendCircleDetail.DataBind();
                }
                
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
        protected void grdCirclesDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divimage = (HtmlGenericControl)e.Row.FindControl("dvimagecircle");
                    HiddenField hdncolor = (HiddenField)e.Row.FindControl("hndcolor");
                    LinkButton lnkMember = (LinkButton)e.Row.FindControl("lnkMember");
                    LinkButton lnkInspirator = (LinkButton)e.Row.FindControl("lnkInspirator");
                    LinkButton lnkMission = (LinkButton)e.Row.FindControl("lnkMission");
                    if (lnkInspirator.Text == "0")
                    {
                        lnkInspirator.Enabled = false;
                        lnkInspirator.Style.Add("color", "#555");
                    }
                    if (lnkMember.Text == "0")
                    {
                        lnkMember.Text = "1";
                        //lnkMember.Enabled = false;
                        //lnkMember.Style.Add("color", "#555");
                    }
                    if (lnkMission.Text == "0")
                    {
                        lnkMission.Enabled = false;
                        lnkMission.Style.Add("color", "#555");
                    }
                    divimage.Style.Add("border-color", "#" + hdncolor.Value);

                }
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
        protected void grdCirclesDetail_Sorting(object sender, GridViewSortEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridViewSortExpression = e.SortExpression;
                int pageIndex = grdCirclesDetail.PageIndex;
                grdCirclesDetail.DataSource = SortDataTable(BindGridView(), false);
                grdCirclesDetail.DataBind();
                grdCirclesDetail.PageIndex = pageIndex;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grdCirclesDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                if (e.CommandName == "lnkMember")
                {
                    Int32 userid = Convert.ToInt32(commandArgs[1]);
                    Int32 circleid = Convert.ToInt32(commandArgs[0]);
                    string val1 = "1";
                    Response.Redirect("userfriendList.aspx?val=" + userid + "&circleid=" + circleid + "&val1=" + val1, false);
                    Session["Circle"] = true;
                }
                else if (e.CommandName == "lnkInspirator")
                {
                    Int32 userid = Convert.ToInt32(commandArgs[1]);
                    Int32 circleid = Convert.ToInt32(commandArgs[0]);
                    string val1 = "1";
                    Response.Redirect("InspiratorCircleDetail.aspx?val=" + userid + "&circleid=" + circleid + "&val1=" + val1, false);
                    Session["Circle"] = true;
                }
                else if (e.CommandName == "lnkMission")
                {
                    Int32 userid = Convert.ToInt32(commandArgs[1]);
                    Int32 circleid = Convert.ToInt32(commandArgs[0]);
                    string val1 = "1";
                    Response.Redirect("CircleMissionDetail.aspx?val=" + userid + "&circleid=" + circleid + "&val1=" + val1, false);
                    Session["Circle"] = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grdCirclesDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                grdCirclesDetail.DataSource = SortDataTable(BindGridView(), true);
                grdCirclesDetail.PageIndex = e.NewPageIndex;
                grdCirclesDetail.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFriendCircleDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divimage = (HtmlGenericControl)e.Row.FindControl("dvimagecircle");
                    HiddenField hdncolor = (HiddenField)e.Row.FindControl("hndcolor");
                    divimage.Style.Add("border-color", "#" + hdncolor.Value);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFriendCircleDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GrdFriendCircleDetail.DataSource = SortDataTable(BindGridView(), true);
                GrdFriendCircleDetail.PageIndex = e.NewPageIndex;
                GrdFriendCircleDetail.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFriendCircleDetail_Sorting(object sender, GridViewSortEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridViewSortExpression = e.SortExpression;
                int pageIndex = grdCirclesDetail.PageIndex;
                GrdFriendCircleDetail.DataSource = SortDataTable(BindGridView(), false);
                GrdFriendCircleDetail.DataBind();
                GrdFriendCircleDetail.PageIndex = pageIndex;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkCirle_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("CircleManagement.aspx", false);
                Session["Circle"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
