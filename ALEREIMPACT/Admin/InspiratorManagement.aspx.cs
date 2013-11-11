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
    public partial class InspiratorManagement : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        public static Int32 userid1 = 0;
        public static Int32 Inspid = 0;
        public static string filename = "";
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
                        if (!string.IsNullOrEmpty(Request.QueryString["val"]))
                        {
                            userid1 = Convert.ToInt32(Request.QueryString["val"]);
                            BindGridView();
                        }

                        else
                        {
                            userid1 = 0;
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

        // bind gridview//
        private DataTable BindGridView()
        {

            DataTable dt = new DataTable();
            try
            {
                if (userid1 != 0 )
                {
                  
                    if (DropDownList1.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex==0)
                    {
                        objAdminBAO.ID = userid1;
                        objAdminBAO.ProcedureType = "I1";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex != 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex == 0)
                    {
                        objAdminBAO.fk_user_registration_Id = userid1;
                        objAdminBAO.fk_circle_id = Convert.ToInt32( DrpStatus.SelectedValue);
                        objAdminBAO.ProcedureType = "I4";
                        dt = AdminDAO.GetUserFriendsCount(objAdminBAO);

                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex != 0 && DrpCircleType.SelectedIndex == 0)
                    {
                        objAdminBAO.fk_user_registration_Id = userid1;
                        objAdminBAO.fk_circle_id = Convert.ToInt32(DrpUserType.SelectedValue);
                        objAdminBAO.ProcedureType = "I5";
                        dt = AdminDAO.GetUserFriendsCount(objAdminBAO);

                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex != 0)
                    {
                        objAdminBAO.fk_user_registration_Id = userid1;
                        objAdminBAO.fk_circle_id = Convert.ToInt32(DrpCircleType.SelectedValue);
                        objAdminBAO.ProcedureType = "I6";
                        dt = AdminDAO.GetUserFriendsCount(objAdminBAO);

                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID = userid1;
                        objAdminBAO.ProcedureType = "I1";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                }
                else
                {
                    if (DropDownList1.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex == 0)
                    {
                        objAdminBAO.ProcedureType = "V";
                        dt = AdminDAO.GettbUserDetail(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex != 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID =Convert.ToInt32( DrpStatus.SelectedValue);
                        objAdminBAO.ProcedureType = "I2";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex != 0 && DrpCircleType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID =Convert.ToInt32( DrpUserType.SelectedValue);
                        objAdminBAO.ProcedureType = "I3";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex != 0)
                    {
                        objAdminBAO.ID = Convert.ToInt32(DrpCircleType.SelectedValue);
                        objAdminBAO.ProcedureType = "I4";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpCircleType.SelectedIndex == 0)
                    {
                        objAdminBAO.ProcedureType = "V";
                        dt = AdminDAO.GettbUserDetail(objAdminBAO);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                Session["inspid"] = arg[0];
                Session["userid"] = arg[1];
                if (e.CommandName == "like")
                {
                  
                   // Inspid = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("InspiratorLike.aspx?val=" + Session["inspid"] + "&userid=" + Session["userid"], false);
                    Session["Inspirator"] = true;
                }
                else if (e.CommandName == "comments")
                {
                   // Inspid = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("Inspiratorcomment.aspx?val=" + Session["inspid"] + "&userid=" + Session["userid"], false);
                    Session["Inspirator"] = true;
                }
                else if (e.CommandName == "Inappropriate")
                {
                   // Inspid = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("InspiratorInappro.aspx?val=" + Session["inspid"] + "&userid=" + Session["userid"], false);
                    Session["Inspirator"] = true;
                }
                else if (e.CommandName == "Library")
                {
                  //  Inspid = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("InspiratorLibrary.aspx?val=" + Session["inspid"] + "&userid=" + Session["userid"], false);
                    Session["Inspirator"] = true;
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
                    Label lbuserId = (Label)e.Row.FindControl("lbId");
                    Label lbInspId = (Label)e.Row.FindControl("lbIId");
                    Label lbname = (Label)e.Row.FindControl("lbname");
                    Label lbname1 = (Label)e.Row.FindControl("Label2");
                    if (lbname.Text == "" && lbname1.Text=="")
                    {
                        lbname.Text = "Admin";
                    }
                    HiddenField hf = (HiddenField)e.Row.FindControl("HiddenField1");
                    Image img = (Image)e.Row.FindControl("Image1");
                    DropDownList drpstatuschange = (DropDownList)e.Row.FindControl("drpstatuschange");
                    LinkButton lnkLike = (LinkButton)e.Row.FindControl("lnklike");
                    LinkButton lnkcomment = (LinkButton)e.Row.FindControl("lnkComments");
                    LinkButton lnkinappro = (LinkButton)e.Row.FindControl("lnkInappropriate");
                    LinkButton lnklibrary = (LinkButton)e.Row.FindControl("lnklibrary");
                    userid = Convert.ToInt32(lbuserId.Text);
                    Inspid = Convert.ToInt32(lbInspId.Text);
                    string val = hf.Value;
                    string filePath = Server.MapPath(ConfigurationManager.AppSettings["ImagePath"].ToString());
                    img.ImageUrl = filePath + "/InspiratorImages/" + val;
                   // img.ImageUrl = "/AlereImpactNew/User/InspiratorImages/" + val;
                   
                    if (lnkLike.Text == "0")
                    {
                        lnkLike.Enabled = false;
                        lnkLike.Style.Add("color", "#555");
                    }

                    if (lnkcomment.Text == "0")
                    {
                        lnkcomment.Enabled = false;
                        lnkcomment.Style.Add("color", "#555");
                    }

                    if (lnkinappro.Text == "0")
                    {
                        lnkinappro.Enabled = false;
                        lnkinappro.Style.Add("color", "#555");
                    }

                    
                    if (lnklibrary.Text == "0")
                    {
                        lnklibrary.Enabled = false;
                        lnklibrary.Style.Add("color", "#555");
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string lbid = (((Label)GridView1.Rows[e.RowIndex].FindControl("lbIId")).Text);
                objAdminBAO.ID = lbid;
                objAdminBAO.ProcedureType = "D1";
                AdminDAO.deleteComment(objAdminBAO);
                objAdminBAO.ID = lbid;
                objAdminBAO.ProcedureType = "D2";
                AdminDAO.deleteComment(objAdminBAO);
                objAdminBAO.ID = lbid;
                objAdminBAO.ProcedureType = "D3";
                AdminDAO.deleteComment(objAdminBAO);
                objAdminBAO.ID = lbid;
                objAdminBAO.ProcedureType = "D4";
                AdminDAO.deleteComment(objAdminBAO);
                objAdminBAO.ID = lbid;
                objAdminBAO.ProcedureType = "D5";
                AdminDAO.deleteComment(objAdminBAO);
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
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
                GridView1.DataSource = SortDataTable(BindGridView(), false);
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
                lbid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lbIId")).Text;
                drpstatus = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("drpstatuschange")).SelectedValue;
                int retval = 0;
                objAdminBAO.fk_user_status_id = Convert.ToInt32(drpstatus);
                objAdminBAO.pk_user_registration_Id = Convert.ToInt32(lbid);
                objAdminBAO.ProcedureType = "S";
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
                GridView1.DataSource = SortDataTable(BindGridView(), false);
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
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpCircleType.Items.Clear();
                DrpCircleType.Items.Add("--Please Select--");
                if (DropDownList1.SelectedValue == "1")
                {
                    divStatus.Style.Add("display", "");
                    divUserType.Style.Add("display", "none");
                    divCircle.Style.Add("display", "none");
                    objSQLHelper.fillDrpControl(DrpStatus, "spFillDrpDown", "user_status", "pk_user_status_id", "S");
                    GridView1.DataSource = SortDataTable(BindGridView(), true);
                    GridView1.DataBind();
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    divStatus.Style.Add("display", "none");
                    divUserType.Style.Add("display", "");
                    divCircle.Style.Add("display", "none");
                    objSQLHelper.fillDrpControl(DrpUserType, "spFillDrpDown", "user_type_role", "pk_user_role_Id", "U1");
                    GridView1.DataSource = SortDataTable(BindGridView(), true);
                    GridView1.DataBind();
                }
                else if (DropDownList1.SelectedValue == "3")
                {
                    divStatus.Style.Add("display", "none");
                    divUserType.Style.Add("display", "none");
                    divCircle.Style.Add("display", "");
                    objSQLHelper.fillDrpControl(DrpCircleType, "spFillDrpDown", "circle_name", "pk_circle_id", "C");
                    GridView1.DataSource = SortDataTable(BindGridView(), true);
                    GridView1.DataBind();
                }
                else
                {
                    divStatus.Style.Add("display", "none");
                    divUserType.Style.Add("display", "none");
                    divCircle.Style.Add("display", "none");
                    DrpStatus.Items.Clear();
                    DrpStatus.Items.Add("--Please Select--");
                    DrpUserType.Items.Clear();
                    DrpUserType.Items.Add("--Please Select--");
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

        protected void DrpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
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

        protected void DrpUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpCircleType.Items.Clear();
                DrpCircleType.Items.Add("--Please Select--");
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                this.ModalPopupExtender1.Show();
                divadd.Style.Add("display", "");
                btnadd.Enabled = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (txtdesc.Text != "")
                {
                    if (FileUpload1.HasFile)
                    {
                        string PhotoFileName = FileUpload1.FileName;
                        string fileext = System.IO.Path.GetExtension(PhotoFileName.ToString());
                        Session["_Inspirator"] = PhotoFileName;
                        MySession.Current.Image = PhotoFileName;
                        filename = MySession.Current.LoginId + "_" + PhotoFileName.Replace("!", "").Replace("@", "").Replace("#", "").Replace("%", "").Replace("^", "").Replace("&", "").Replace("*", "").Replace("(", "").Trim();
                        // string filepath = Server.MapPath("~/User");
                        /*
                         * For server
                         * */
                        FileUpload1.PostedFile.SaveAs(MapPath("~") + "/User/InspiratorImages/" + filename);
                       // string filePath = Server.MapPath( ConfigurationManager.AppSettings["ImagePath"].ToString());
                       // FileUpload1.PostedFile.SaveAs(filePath+"/InspiratorImages/" + filename);
                    }

                    int retval = 0;
                    objAdminBAO.pk_Inspirator_id = 0;
                    objAdminBAO.Inspirator_image = filename;
                    objAdminBAO.Inspirator_desc = txtdesc.Text;
                    objAdminBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.Inspirator_createdon = DateTime.Now.ToString();
                    objAdminBAO.Fk_Inspirator_status_id = 1;
                    objAdminBAO.fk_circle_id = 1;
                    objAdminBAO.fk_user_circle_id = 0;
                    objAdminBAO.ProcedureType = "I";
                    retval = AdminDAO.InsertInspirator(objAdminBAO);
                    if (retval != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Inspirator Added Successfully');", true);
                        txtdesc.Text = "";
                        filename = "";
                        FileUpload1.Dispose();
                    }
                }
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
                txtdesc.Text = "";
                filename = "";
                Session["_Inspirator"] = null;
                btnadd.Enabled = false;
                MySession.Current.Image = null;

                Response.Redirect("InspiratorManagement.aspx", false);
                Session["Inspirator"] = true;
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

                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                GridView1.DataSource = SortDataTable(BindGridView(), true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

    
     
    
    }
}
