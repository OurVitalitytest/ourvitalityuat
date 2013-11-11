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
    public partial class InspiratorLike : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        public static Int32 Inspid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        userid = Convert.ToInt32(Request.QueryString["userid"]);
                        Inspid = Convert.ToInt32(Request.QueryString["val"]);
                        bindGrd();
                        getname();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void getname()   //get name of user//
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ProcedureType = "N";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    lbname.Text = dt.Rows[0]["usercode"].ToString();
                  //  lbname2.Text = dt.Rows[0]["last_name"].ToString();
                }
                else
                {
                    lbname.Text = "Admin";
                    lbname2.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindGrd()         //bind gridview//
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.fk_Inspirator_id = Inspid;
                objAdminBAO.ProcedureType = "L1";
                dt = AdminDAO.GetInspiratorCount(objAdminBAO);
                GridView1.DataSource = dt;
                GridView1.DataBind();
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
        protected void lnkInsp_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            Response.Redirect("InspiratorManagement.aspx", false);
            Session["Inspirator"] = true;
        }
    }
}
