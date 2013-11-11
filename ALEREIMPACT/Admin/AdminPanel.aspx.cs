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
    public partial class AdminPanel : System.Web.UI.Page
    {   
        AdminBAO objAdminBAO = new AdminBAO();
     
        SQLHelper objSQLHelper = new SQLHelper();
        public static string userid = "";
        ClsGeneric objGeneric = new ClsGeneric();
        public static string subject="";
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
                        BindGridView();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        
        // bind user List gridview//
        private DataTable BindGridView()
        {
            DataTable dt = new DataTable();
           
            try
            {
                if (txtname.Text != "" || txtemail.Text != "" || txtUserCode.Text != "")
                {
                    if (txtname.Text != "")
                    {
                        DataTable dt1 = new DataTable();
                        objAdminBAO.ProcedureType = "N";
                        dt1 = AdminDAO.GettbUserDetail(objAdminBAO);
                        objAdminBAO.name = txtname.Text;
                        objAdminBAO.name1 = "";
                        objAdminBAO.ProcedureType = "S";
                        dt = AdminDAO.GetUserDetailSearch(objAdminBAO);

                    }


                    else if (txtemail.Text != "")
                    {

                        objAdminBAO.name = txtemail.Text;
                        objAdminBAO.name1 = "";
                        objAdminBAO.ProcedureType = "E";
                        dt = AdminDAO.GetUserDetailSearch(objAdminBAO);


                    }
                    else if (txtUserCode.Text != "")
                    {
                        objAdminBAO.name = txtUserCode.Text;
                        objAdminBAO.name1 = "";
                        objAdminBAO.ProcedureType = "U";
                        dt = AdminDAO.GetUserDetailSearch(objAdminBAO);

                    }
                }
                else
                {


                    if (DropDownList1.SelectedIndex == 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ProcedureType = "S";
                        dt = AdminDAO.GettbUserDetail(objAdminBAO);

                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID = Convert.ToInt32(DrpLocation.SelectedValue);
                        objAdminBAO.ProcedureType = "S";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex != 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID = Convert.ToInt32(DrpStatus.SelectedValue);
                        objAdminBAO.ProcedureType = "V";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ProcedureType = "S";
                        dt = AdminDAO.GettbUserDetail(objAdminBAO);

                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex != 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID = Convert.ToInt32(DrpUserType.SelectedValue);
                        objAdminBAO.ProcedureType = "U";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex != 0)
                    {
                        objAdminBAO.ID = Convert.ToInt32(DrpRegisType.SelectedValue);
                        objAdminBAO.ProcedureType = "R";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }

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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
            if (DropDownList1.SelectedValue == "1")
            {
                divButton.Style.Add("display", "none");
                divname.Style.Add("display", "none");
                divEmail.Style.Add("display", "none");
                divStatus.Style.Add("display", "");
                divLocation.Style.Add("display", "none");
                divUserType.Style.Add("display", "none");
                divRegsType.Style.Add("display", "none");
                divUsercode.Style.Add("display", "none");
                objSQLHelper.fillDrpControl(DrpStatus, "spFillDrpDown", "user_status", "pk_user_status_id", "S");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
          
            else if (DropDownList1.SelectedValue == "2")
            {
                divButton.Style.Add("display", "none");
                divname.Style.Add("display", "none");
                divEmail.Style.Add("display", "none");
                divStatus.Style.Add("display", "none");
                divLocation.Style.Add("display", "");
                divUserType.Style.Add("display", "none");
                divRegsType.Style.Add("display", "none");
                divUsercode.Style.Add("display", "none");
                objSQLHelper.fillDrpControl(DrpLocation, "spFillDrpDown", "location_name", "pk_location_id", "L");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                divButton.Style.Add("display", "none");
                divname.Style.Add("display", "none");
                divEmail.Style.Add("display", "none");
                divStatus.Style.Add("display", "none");
                divLocation.Style.Add("display", "none");
                divUserType.Style.Add("display", "");
                divRegsType.Style.Add("display", "none");
                divUsercode.Style.Add("display", "none");
                objSQLHelper.fillDrpControl(DrpUserType, "spFillDrpDown", "user_type_role", "pk_user_role_Id", "U");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedValue == "4")
            {
                divButton.Style.Add("display", "none");
                divname.Style.Add("display", "none");
                divEmail.Style.Add("display", "none");
                divStatus.Style.Add("display", "none");
                divLocation.Style.Add("display", "none");
                divUserType.Style.Add("display", "none");
                divRegsType.Style.Add("display", "");
                divUsercode.Style.Add("display", "none");
                objSQLHelper.fillDrpControl(DrpRegisType, "spFillDrpDown", "type_of_login", "pk_types_of_login_Id", "R");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedValue == "5")
            {
                divButton.Style.Add("display", "");
                divname.Style.Add("display", "");
                divEmail.Style.Add("display", "none");
                divStatus.Style.Add("display", "none");
                divLocation.Style.Add("display", "none");
                divUserType.Style.Add("display", "none");
                divRegsType.Style.Add("display", "none");
                divUsercode.Style.Add("display", "none");
                txtemail.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedValue == "6")
            {
                divButton.Style.Add("display", "");
                divname.Style.Add("display", "none");
                divEmail.Style.Add("display", "");
                divStatus.Style.Add("display", "none");
                divLocation.Style.Add("display", "none");
                divUserType.Style.Add("display", "none");
                divRegsType.Style.Add("display", "none");
                divUsercode.Style.Add("display", "none");
                txtname.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedValue == "7")
            {
                divButton.Style.Add("display", "");
                divname.Style.Add("display", "none");
                divEmail.Style.Add("display", "none");
                divStatus.Style.Add("display", "none");
                divLocation.Style.Add("display", "none");
                divUserType.Style.Add("display", "none");
                divRegsType.Style.Add("display", "none");
                divUsercode.Style.Add("display", "");
                txtname.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            else
            {
                divButton.Style.Add("display", "none");
                divname.Style.Add("display", "none");
                divEmail.Style.Add("display", "none");
                divStatus.Style.Add("display", "none");
                divLocation.Style.Add("display", "none");
                divUserType.Style.Add("display", "none");
                divRegsType.Style.Add("display", "none");
                divUsercode.Style.Add("display", "none");
                DropDownList1.SelectedIndex = 0;
                DrpStatus.SelectedIndex = 0;
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                txtemail.Text = "";
                txtname.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
        }

        protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpStatus.SelectedIndex = 0;
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                 DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                txtemail.Text = "";
                txtname.Text = "";
                txtUserCode.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
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
                    Label lbid = (Label)e.Row.FindControl("lbId");
                    
                    LinkButton lbcircles = (LinkButton)e.Row.FindControl("lnkCircle");
                    DropDownList drpstatuschange = (DropDownList)e.Row.FindControl("drpstatuschange");
                    LinkButton lnkInspirator = (LinkButton)e.Row.FindControl("lnkInspirator");
                    DataTable dtcircle = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid.Text);
                    objAdminBAO.ProcedureType = "C1";
                    dtcircle = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtcircle.Rows.Count > 0)
                    {
                        lbcircles.Text = dtcircle.Rows[0]["noofcircles"].ToString();
                    }
                    else
                    {
                        lbcircles.Text = "0";
                    }
                   
                    DataTable dtInsp = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid.Text);
                    objAdminBAO.ProcedureType = "I";
                    dtInsp = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtInsp.Rows.Count > 0)
                    {
                        lnkInspirator.Text = dtInsp.Rows[0]["noofInspirator"].ToString();
                    }
                    else
                    {
                        lnkInspirator.Text = "0";
                       
                    }
                    if (lnkInspirator.Text == "0")
                    {
                        lnkInspirator.Enabled = false;
                        lnkInspirator.Style.Add("color", "#555");
                       
                    }
                    if (drpstatuschange != null)
                    {
                        objSQLHelper.fillDrpControl(drpstatuschange, "spFillDrpDown", "user_status", "pk_user_status_id", "S");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string drpstatus, lbid;
                lbid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lbId")).Text;
                drpstatus = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("drpstatuschange")).SelectedValue;
                int retval = 0;
                objAdminBAO.fk_user_status_id = Convert.ToInt32(drpstatus);
                objAdminBAO.pk_user_registration_Id = Convert.ToInt32(lbid);
                objAdminBAO.ProcedureType = "U";
                retval = AdminDAO.UpdateStatus(objAdminBAO);
                GridView1.EditIndex = -1;
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView1.EditIndex = -1;
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DrpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                txtemail.Text = "";
                txtname.Text = "";
                txtUserCode.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
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
                if (e.CommandName == "circle")
                {
                    string id = e.CommandArgument.ToString();
                    Response.Redirect("Circles.aspx?val=" + id, false);
                    Session["User"] = true;
                }
                else if (e.CommandName == "Inspirator")
                {
                    string id = e.CommandArgument.ToString();
                    Response.Redirect("InspiratorManagement.aspx?val=" + id, false);
                    Session["Inspirator"] = true;
                }
                else if (e.CommandName == "Contact")
                {
                    userid = e.CommandArgument.ToString();
                    this.ModalPopupExtender1.Show();
                    divGrdEsc.Style.Add("display", "");
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(userid);
                    objAdminBAO.ProcedureType = "E";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    lbemail.Text = dt.Rows[0]["login_email"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
//Gridview Sorting//
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            GridViewSortExpression = e.SortExpression;
            int pageIndex = GridView1.PageIndex;
            GridView1.DataSource = SortDataTable(BindGridView(), false);
            GridView1.DataBind();
            GridView1.PageIndex = pageIndex;
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

        protected void DrpUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                txtemail.Text = "";
                txtUserCode.Text = "";
                txtname.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DrpRegisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                txtemail.Text = "";
                txtname.Text = "";
                txtUserCode.Text = "";
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindGrdWtihtextbox()
        {
            try
            {
                DataTable dt = new DataTable();
                if (txtname.Text != "")
                {
                    objAdminBAO.ProcedureType = "N";
                    dt = AdminDAO.GettbUserDetail(objAdminBAO);
                    DataTable dtsearch = new DataTable();
                    objAdminBAO.name = txtname.Text;
                    objAdminBAO.name1 = "";
                    objAdminBAO.ProcedureType = "S";
                    dtsearch = AdminDAO.GetUserDetailSearch(objAdminBAO);
                    GridView1.DataSource = dtsearch;
                    GridView1.DataBind();
                }
                else if (txtemail.Text != "")
                {
                    string txt = txtemail.Text;
                    txt = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txt.ToUpper());
                    DataTable dtsearch = new DataTable();

                    objAdminBAO.name = txtemail.Text;
                    objAdminBAO.name1 = "";
                    objAdminBAO.ProcedureType = "E";
                    dtsearch = AdminDAO.GetUserDetailSearch(objAdminBAO);
                    if (dtsearch.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtsearch;
                        GridView1.DataBind();

                    }
                    else
                    {
                        objAdminBAO.name = txt;
                        objAdminBAO.name1 = "";
                        objAdminBAO.ProcedureType = "E";
                        dtsearch = AdminDAO.GetUserDetailSearch(objAdminBAO);
                        GridView1.DataSource = dtsearch;
                        GridView1.DataBind();

                    }
                }
                else if (txtUserCode.Text != "")
                {
                    objAdminBAO.name = txtUserCode.Text;
                    objAdminBAO.name1 = "";
                    objAdminBAO.ProcedureType = "U";
                    dt = AdminDAO.GetUserDetailSearch(objAdminBAO);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    BindGridView();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                bindGrdWtihtextbox();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                this.ModalPopupExtender1.Hide();
                divGrdEsc.Style.Add("display", "none");
                string email = lbemail.Text;
                string body = CKEditor1.Text;
                subject = "Alere Impact";
                objGeneric.SendMail(email, body, subject);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "alert('Message Sent Successfully.');", true);
                return;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

       
        
    }
}
