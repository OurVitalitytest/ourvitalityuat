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
using System.Reflection;

namespace ALEREIMPACT.Admin
{
    public partial class AddFoodCategory : System.Web.UI.Page
    {
        AdminFoodCategoryBAO objAdminFoodCategoryBAO = new AdminFoodCategoryBAO();
        SQLHelper objSqlHelper = new SQLHelper();
        public static string filename = "";
        AdminBAO objAdminBAO = new AdminBAO();
        public static string Catid = "";
        public static string Subcatid = "";
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
                        FillDrpDown();
                        bindcatgoryList();


                    }
                    if (Convert.ToString(Session["2"]) == "True")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Parent Category Added Successfully');", true);
                        Session["2"] = false;
                    }
                    else if (Convert.ToString(Session["3"]) == "True")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Parent Subcategory Added Successfully');", true);
                        Session["3"] = false;
                    }
                    else if (Convert.ToString(Session["4"]) == "True")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert(' Subcategory Added Successfully');", true);
                        Session["4"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void FillDrpDown()
        {
            objSqlHelper.fillDrpControl(drpCategory, "spFillDrpDown", "CAT_NAME", "CAT_ID", "FC");
            objSqlHelper.fillDrpControl(drpSubcat, "spFillDrpDown", "SUBCAT1_NAME", "SUBCAT1_ID", "FS");
        }
        protected void btn_catCreate_Click(object sender, EventArgs e)
        {
            try
            {

                ClsGeneric.ReplaceCookie();
                btn_catCreate.Text = "Processing";
                if (fuCategory.HasFile)
                {
                    string PhotoFileName = fuCategory.FileName;
                    string fileext = System.IO.Path.GetExtension(PhotoFileName.ToString());
                    Session["_category"] = PhotoFileName;
                    MySession.Current.Image = PhotoFileName;

                    filename = MySession.Current.LoginId + "_" + PhotoFileName.Replace("!", "").Replace("@", "").Replace("#", "").Replace("%", "").Replace("^", "").Replace("&", "").Replace("*", "").Replace("(", "").Trim();
                    // string filepath = Server.MapPath("~/User");
                    /*
                     * For server
                     * */
                    fuCategory.PostedFile.SaveAs(MapPath("~") + "/User/FoodCategoryImages/" + filename);
                    //fuCategory.SaveAs(filepath+"/FoodCategoryImages/" + filename);

                    // * For local
                    // * */
                    //fuCategory.SaveAs("D:\\Harjeet Working Directory\\Vitalityweb\\ALEREIMPACT\\User" + "/FoodCategoryImages/" + filename);
                }
                int retval = 0;
                objAdminFoodCategoryBAO.CAT_ID = 0;
                objAdminFoodCategoryBAO.CAT_NAME = txtCatName.Text;
                objAdminFoodCategoryBAO.CAT_IMAGE = filename;
                objAdminFoodCategoryBAO.CAT_DATE = DateTime.Now.ToString();
                objAdminFoodCategoryBAO.CAT_DESCRIPTION = txtCatDesc.Text;
                objAdminFoodCategoryBAO.ProcedureType = "I";
                retval = AdminFoodCategoryDAO.InserttblCategory(objAdminFoodCategoryBAO);
                txtCatDesc.Text = "";
                txtCatName.Text = "";
                fuCategory.Dispose();
                Session["category"] = true;
                Session["2"] = true;
                Response.Redirect("AddFoodCategory.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btn_Subcat1Create_Click(object sender, EventArgs e)
        {
            try{
            ClsGeneric.ReplaceCookie();
            if (fuSubcat1.HasFile)
            {
                string PhotoFileName = fuSubcat1.FileName;
                string fileext = System.IO.Path.GetExtension(PhotoFileName.ToString());
                Session["_category"] = PhotoFileName;
                MySession.Current.Image = PhotoFileName;
                filename = MySession.Current.LoginId + "_" + PhotoFileName;
                fuSubcat1.PostedFile.SaveAs(MapPath("~") + "/User/FoodCategoryImages/" + filename);
               // fuCategory.SaveAs("D:\\Harjeet Working Directory\\Vitalityweb\\ALEREIMPACT\\User" + "/FoodCategoryImages/" + filename);
            }

            int retval = 0;
            objAdminFoodCategoryBAO.SUBCAT1_ID = 0;
            objAdminFoodCategoryBAO.CAT_ID_FK = drpCategory.SelectedValue;
            objAdminFoodCategoryBAO.SUBCAT1_NAME = txtSubcat1Name.Text;
            objAdminFoodCategoryBAO.SUBCAT1_IMAGE = filename;
            objAdminFoodCategoryBAO.SUBCAT1_DATE = DateTime.Now.ToString();
            objAdminFoodCategoryBAO.SUBCAT1_DESCRIPTION = txtSubcat1Desc.Text;
            objAdminFoodCategoryBAO.ProcedureType = "I";
            retval = AdminFoodCategoryDAO.InserttblSubCategory1(objAdminFoodCategoryBAO);
            txtSubcat1Desc.Text = "";
            txtSubcat1Name.Text = "";
            fuSubcat1.Dispose();
            Session["category"] = true;
            Session["3"] = true;
            Response.Redirect("AddFoodCategory.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btn_Subcat2Create_Click(object sender, EventArgs e)
        {try{
            ClsGeneric.ReplaceCookie();
            if (fuSubcat2.HasFile)
            {
                string PhotoFileName = fuSubcat2.FileName;
                string fileext = System.IO.Path.GetExtension(PhotoFileName.ToString());
                Session["_category"] = PhotoFileName;
                MySession.Current.Image = PhotoFileName;
                filename = MySession.Current.LoginId + "_" + PhotoFileName.Replace("!", "").Replace("@", "").Replace("#", "").Replace("%", "").Replace("^", "").Replace("&", "").Replace("*", "").Replace("(", "").Trim();
                fuSubcat2.PostedFile.SaveAs(MapPath("~") + "/User/FoodCategoryImages/" + filename);
                //fuCategory.SaveAs("D:\\Harjeet Working Directory\\Vitalityweb\\ALEREIMPACT\\User" + "/FoodCategoryImages/" + filename);
            }
            int retval = 0;
            objAdminFoodCategoryBAO.SUBCAT2_ID = 0;
            objAdminFoodCategoryBAO.SUBCAT1_ID_FK = drpSubcat.SelectedValue;
            objAdminFoodCategoryBAO.SUBCAT2_NAME = txtSubcat2Name.Text;
            objAdminFoodCategoryBAO.SUBCAT2_IMAGE = filename;
            objAdminFoodCategoryBAO.SUBCAT2_DATE = DateTime.Now.ToString();
            objAdminFoodCategoryBAO.SUBCAT2_DESCRIPTION = txtSubcat2Desc.Text;
            objAdminFoodCategoryBAO.ProcedureType = "I";
            retval = AdminFoodCategoryDAO.InserttblSubCategory2(objAdminFoodCategoryBAO);
            txtSubcat2Desc.Text = "";
            txtSubcat2Name.Text = "";
            fuSubcat2.Dispose();
            Session["category"] = true;
            Session["4"] = true;
            Response.Redirect("AddFoodCategory.aspx", false);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        }

        private void bindcatgoryList()
        {try{
            lbSubcat.Visible = false;
            lbPSubcat.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            DataTable dt = new DataTable();
            objAdminBAO.ProcedureType = "FC";
            dt = AdminDAO.GettbUserDetail(objAdminBAO);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
                Label1.Visible = false;
                Label4.Visible = true;
                Label5.Visible = true;



            }
            else
            {
                GridView1.Visible = false;
                Label1.Visible = true;
                Label1.Text = "No Food Category Found.";
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    HiddenField HiddenField1 = (HiddenField)e.Row.FindControl("HiddenField1");
                    Image Image1 = (Image)e.Row.FindControl("Image1");
                    string val = HiddenField1.Value;
                  // string filePath = Server.MapPath(ConfigurationManager.AppSettings["ImagePath"].ToString());
                    Image1.ImageUrl = "../User/FoodCategoryImages/" + val;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ClsGeneric.ReplaceCookie();
                Label4.Visible = false;
                Label5.Visible = true;
                GridView3.Visible = false;
                lbSubcat.Visible = false;
                if (e.CommandName == "Lnk")
                {
                    string id = e.CommandArgument.ToString();
                    Catid = e.CommandArgument.ToString();
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(id);
                    objAdminBAO.ProcedureType = "FS";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        GridView2.Visible = true;
                        lbPSubcat.Visible = false;
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.Visible = false;
                        lbPSubcat.Visible = true;
                        lbPSubcat.Text = "This Parent Category has no Parent Subcategory List.";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }  
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {try{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField HiddenField1 = (HiddenField)e.Row.FindControl("HiddenField1");
                Image Image1 = (Image)e.Row.FindControl("Image1");
                if (HiddenField1 != null)
                {
                    string val = HiddenField1.Value;
                    //string filePath = Server.MapPath(ConfigurationManager.AppSettings["ImagePath"].ToString());
                    Image1.ImageUrl = "../User/FoodCategoryImages/" + val;
                    //Image1.ImageUrl = "/AlereImpactNew/User/FoodCategoryImages/" + val;
                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {try{
            ClsGeneric.ReplaceCookie();
            Label5.Visible = false;

            if (e.CommandName == "Lnk")
            {
                string id = e.CommandArgument.ToString();
                Subcatid = e.CommandArgument.ToString();
                DataTable dt = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(id);
                objAdminBAO.ProcedureType = "FC";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    GridView3.Visible = true;
                    lbSubcat.Visible = false;
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.Visible = false;
                    lbSubcat.Visible = true;
                    lbSubcat.Text = "This Parent Subcategory has no  Subcategory List.";
                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {try{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField HiddenField1 = (HiddenField)e.Row.FindControl("HiddenField1");
                Image Image1 = (Image)e.Row.FindControl("Image1");
                if (HiddenField1 != null)
                {
                    string val = HiddenField1.Value;
                   // string filePath = Server.MapPath(ConfigurationManager.AppSettings["ImagePath"].ToString());
                    Image1.ImageUrl = "../User/FoodCategoryImages/" + val;
                   // Image1.ImageUrl = "/AlereImpactNew/User/FoodCategoryImages/" + val;
                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ClsGeneric.ReplaceCookie();
                string lbid;
                lbid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lbID")).Text;
                if (lbid != "")
                {
                    int retval = 0;
                    objAdminFoodCategoryBAO.ID = Convert.ToInt32(lbid);
                    objAdminFoodCategoryBAO.ProcedureType = "CD";
                    retval = AdminFoodCategoryDAO.DeleteFoodCategory(objAdminFoodCategoryBAO);
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid);
                    objAdminBAO.ProcedureType = "FS";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        int retval1 = 0;
                        objAdminFoodCategoryBAO.ID = Convert.ToInt32(dt.Rows[0]["SUBCAT1_ID"]);
                        objAdminFoodCategoryBAO.ProcedureType = "SD";
                        retval1 = AdminFoodCategoryDAO.DeleteFoodCategory(objAdminFoodCategoryBAO);

                        DataTable dt1 = new DataTable();
                        objAdminBAO.ID = Convert.ToInt32(dt.Rows[0]["SUBCAT1_ID"]);
                        objAdminBAO.ProcedureType = "FC";
                        dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                        if (dt1.Rows.Count > 0)
                        {
                            int retval2 = 0;
                            objAdminFoodCategoryBAO.ID = Convert.ToInt32(dt1.Rows[0]["SUBCAT2_ID"]);
                            objAdminFoodCategoryBAO.ProcedureType = "DS";
                            retval2 = AdminFoodCategoryDAO.DeleteFoodCategory(objAdminFoodCategoryBAO);
                        }
                    }
                }
                GridView1.EditIndex = -1;
                bindcatgoryList();
                Session["category"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            } Response.Redirect("AddFoodCategory.aspx", false);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ClsGeneric.ReplaceCookie();
                string lbid, txtname;
                lbid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lbID1")).Text;
                txtname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("textname")).Text;
                if (txtname != "")
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid);
                    objAdminBAO.ProcedureType = "CS";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        int retval = 0;
                        objAdminFoodCategoryBAO.CAT_ID = Convert.ToInt32(lbid);
                        objAdminFoodCategoryBAO.CAT_NAME = txtname;
                        objAdminFoodCategoryBAO.CAT_IMAGE = dt.Rows[0]["CAT_IMAGE"].ToString();
                        objAdminFoodCategoryBAO.CAT_DATE = dt.Rows[0]["CAT_DATE"].ToString();
                        objAdminFoodCategoryBAO.CAT_DESCRIPTION = dt.Rows[0]["CAT_DESCRIPTION"].ToString();
                        objAdminFoodCategoryBAO.ProcedureType = "U";
                        retval = AdminFoodCategoryDAO.InserttblCategory(objAdminFoodCategoryBAO);
                        GridView1.EditIndex = -1;
                        bindcatgoryList();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Add Parent Category Name.');", true);
                }
            }
            
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ClsGeneric.ReplaceCookie();
                GridView1.EditIndex = -1;
                bindcatgoryList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ClsGeneric.ReplaceCookie();
                GridView1.EditIndex = e.NewEditIndex;
                bindcatgoryList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindParentSubcat()
        {
            try
            {
                lbSubcat.Visible = false;
                DataTable dt = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(Catid);
                objAdminBAO.ProcedureType = "FS";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    Label4.Visible = false;
                    Label5.Visible = true;
                    lbPSubcat.Visible = false;
                    GridView2.Visible = true;
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.Visible = false;
                    lbPSubcat.Visible = true;
                    lbPSubcat.Text = "This Parent Category has no Parent Subcategory List.";
                    Label4.Visible = false;
                    Label5.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ClsGeneric.ReplaceCookie();
                GridView2.EditIndex = -1;
                bindParentSubcat();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ClsGeneric.ReplaceCookie();
                string lbid;
                lbid = ((Label)GridView2.Rows[e.RowIndex].FindControl("lbID")).Text;
                if (lbid != "")
                {
                    int retval1 = 0;
                    objAdminFoodCategoryBAO.ID = Convert.ToInt32(lbid);
                    objAdminFoodCategoryBAO.ProcedureType = "SD";
                    retval1 = AdminFoodCategoryDAO.DeleteFoodCategory(objAdminFoodCategoryBAO);
                    DataTable dt1 = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid);
                    objAdminBAO.ProcedureType = "FC";
                    dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt1.Rows.Count > 0)
                    {
                        int retval2 = 0;
                        objAdminFoodCategoryBAO.ID = Convert.ToInt32(dt1.Rows[0]["SUBCAT2_ID"]);
                        objAdminFoodCategoryBAO.ProcedureType = "DS";
                        retval2 = AdminFoodCategoryDAO.DeleteFoodCategory(objAdminFoodCategoryBAO);
                    }
                }
                GridView2.EditIndex = -1;
                bindParentSubcat();
                Session["category"] = true;
                Response.Redirect("AddFoodCategory.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
                ClsGeneric.ReplaceCookie();
            try
            {
                GridView2.EditIndex = e.NewEditIndex;
                bindParentSubcat();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string lbid, txtname;
                lbid = ((Label)GridView2.Rows[e.RowIndex].FindControl("lbID1")).Text;
                txtname = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("textname")).Text;
                if (txtname != "")
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid);
                    objAdminBAO.ProcedureType = "SC";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        int retval = 0;
                        objAdminFoodCategoryBAO.SUBCAT1_ID = Convert.ToInt32(lbid);
                        objAdminFoodCategoryBAO.CAT_ID_FK = Convert.ToInt32(dt.Rows[0]["CAT_ID_FK"]);
                        objAdminFoodCategoryBAO.SUBCAT1_NAME = txtname;
                        objAdminFoodCategoryBAO.SUBCAT1_IMAGE = dt.Rows[0]["SUBCAT1_IMAGE"].ToString();
                        objAdminFoodCategoryBAO.SUBCAT1_DATE = dt.Rows[0]["SUBCAT1_DATE"].ToString();
                        objAdminFoodCategoryBAO.SUBCAT1_DESCRIPTION = dt.Rows[0]["SUBCAT1_DESCRIPTION"].ToString();
                        objAdminFoodCategoryBAO.ProcedureType = "U";
                        retval = AdminFoodCategoryDAO.InserttblSubCategory1(objAdminFoodCategoryBAO);
                    }
                    GridView2.EditIndex = -1;
                    bindParentSubcat();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Add Parent Subcategory Name.');", true);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void bindSubcat()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(Subcatid);
                objAdminBAO.ProcedureType = "FC";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    Label4.Visible = false;
                    Label5.Visible = false;
                    lbSubcat.Visible = false;
                    GridView3.Visible = true;
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = false;
                    lbSubcat.Visible = true;
                    lbSubcat.Text = "This Parent Subcategory has no  Subcategory List.";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string lbid;
                lbid = ((Label)GridView3.Rows[e.RowIndex].FindControl("lbID")).Text;
                if (lbid != "")
                {

                    int retval2 = 0;
                    objAdminFoodCategoryBAO.ID = Convert.ToInt32(lbid);
                    objAdminFoodCategoryBAO.ProcedureType = "DS";
                    retval2 = AdminFoodCategoryDAO.DeleteFoodCategory(objAdminFoodCategoryBAO);
                }
                GridView3.EditIndex = -1;
                bindSubcat();
                Session["category"] = true;
                Response.Redirect("AddFoodCategory.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView3.EditIndex = e.NewEditIndex;
                bindSubcat();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string lbid, txtname;
                lbid = ((Label)GridView3.Rows[e.RowIndex].FindControl("lbID1")).Text;
                txtname = ((TextBox)GridView3.Rows[e.RowIndex].FindControl("textname")).Text;
                if (txtname != "")
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid);
                    objAdminBAO.ProcedureType = "SS";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        int retval = 0;
                        objAdminFoodCategoryBAO.SUBCAT2_ID = Convert.ToInt32(lbid);
                        objAdminFoodCategoryBAO.SUBCAT1_ID_FK = Convert.ToInt32(dt.Rows[0]["SUBCAT1_ID_FK"]);
                        objAdminFoodCategoryBAO.SUBCAT2_NAME = txtname;
                        objAdminFoodCategoryBAO.SUBCAT2_IMAGE = dt.Rows[0]["SUBCAT2_IMAGE"].ToString();
                        objAdminFoodCategoryBAO.SUBCAT2_DATE = dt.Rows[0]["SUBCAT2_DATE"].ToString();
                        objAdminFoodCategoryBAO.SUBCAT2_DESCRIPTION = dt.Rows[0]["SUBCAT2_DESCRIPTION"].ToString();
                        objAdminFoodCategoryBAO.ProcedureType = "U";
                        retval = AdminFoodCategoryDAO.InserttblSubCategory2(objAdminFoodCategoryBAO);
                    }
                    GridView3.EditIndex = -1;
                    bindSubcat();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Add  Subcategory Name.');", true);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridView3.EditIndex = -1;
                bindSubcat();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }


    }
}
