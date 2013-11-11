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
    public partial class MissionDetail : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        SQLHelper objSQLHelper = new SQLHelper();
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
                        getanme();
                        BindGridView();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void getanme()
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
                if (DropDownList1.SelectedIndex == 0 && DrpCircleType.SelectedIndex == 0 && DrpMType.SelectedIndex == 0 && DrpMTheme.SelectedIndex == 0)
                {
                    objAdminBAO.ProcedureType = "M1";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpCircleType.SelectedIndex != 0 && DrpMType.SelectedIndex == 0 && DrpMTheme.SelectedIndex == 0)
                {
                    objAdminBAO.ID1 = DrpCircleType.SelectedValue;
                    objAdminBAO.ProcedureType = "M2";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpCircleType.SelectedIndex == 0 && DrpMType.SelectedIndex != 0 && DrpMTheme.SelectedIndex == 0)
                {
                    objAdminBAO.ID1 = DrpMType.SelectedValue;
                    objAdminBAO.ProcedureType = "M1";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpCircleType.SelectedIndex == 0 && DrpMType.SelectedIndex == 0 && DrpMTheme.SelectedIndex != 0)
                {
                    objAdminBAO.ID1 = DrpMTheme.SelectedValue;
                    objAdminBAO.ProcedureType = "M";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else
                {
                    objAdminBAO.ProcedureType = "M1";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                }
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpMTheme.Items.Clear();
                DrpMTheme.Items.Add("--Please Select--");
                DrpMType.Items.Clear();
                DrpMType.Items.Add("--Please Select--");
                DrpCircleType.Items.Clear();
                DrpCircleType.Items.Add("--Please Select--");
                if (DropDownList1.SelectedValue == "1")
                {
                    divCircle.Style.Add("display", "none");
                    divTheme.Style.Add("display", "");
                    divType.Style.Add("display", "none");
                    objSQLHelper.fillDrpControl(DrpMTheme, "spFillDrpDown", "mission_theme", "pk_mission_theme_Id", "M");
                    GridView1.DataSource = SortDataTable(BindGridView(), true);
                    GridView1.DataBind();
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    divCircle.Style.Add("display", "none");
                    divTheme.Style.Add("display", "none");
                    divType.Style.Add("display", "");
                    objSQLHelper.fillDrpControl(DrpMType, "spFillDrpDown", "mission_type", "pk_mission_type_Id", "M1");
                    GridView1.DataSource = SortDataTable(BindGridView(), true);
                    GridView1.DataBind();
                }
                else if (DropDownList1.SelectedValue == "3")
                {
                    divCircle.Style.Add("display", "");
                    divTheme.Style.Add("display", "none");
                    divType.Style.Add("display", "none");
                    objSQLHelper.fillDrpControl(DrpCircleType, "spFillDrpDown", "circle_name", "pk_circle_id", "C");
                    GridView1.DataSource = SortDataTable(BindGridView(), true);
                    GridView1.DataBind();
                }
                else
                {
                    divCircle.Style.Add("display", "none");
                    divTheme.Style.Add("display", "none");
                    divType.Style.Add("display", "none");
                    DrpMTheme.Items.Clear();
                    DrpMTheme.Items.Add("--Please Select--");
                    DrpMType.Items.Clear();
                    DrpMType.Items.Add("--Please Select--");
                    DrpCircleType.Items.Clear();
                    DrpCircleType.Items.Add("--Please Select--");
                    GridView1.DataSource = SortDataTable(BindGridView(), true);
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DrpMTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpMType.Items.Clear();
                DrpMType.Items.Add("--Please Select--");
                DrpCircleType.Items.Clear();
                DrpCircleType.Items.Add("--Please Select--");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DrpMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpMTheme.Items.Clear();
                DrpMTheme.Items.Add("--Please Select--");
                DrpCircleType.Items.Clear();
                DrpCircleType.Items.Add("--Please Select--");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DrpCircleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpMTheme.Items.Clear();
                DrpMTheme.Items.Add("--Please Select--");
                DrpMType.Items.Clear();
                DrpMType.Items.Add("--Please Select--");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkMission_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("MissionManagement.aspx", false);
                Session["Mission"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

      
    }
}
