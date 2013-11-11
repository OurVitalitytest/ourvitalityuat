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
    public partial class CircleMissionDetail : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        public static Int32 circleid = 0;
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
                        userid = Convert.ToInt32(Request.QueryString["val"]);
                        circleid = Convert.ToInt32(Request.QueryString["circleid"]);
                        getname();
                        BindGridView();



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
                objAdminBAO.ID = circleid;
                objAdminBAO.ProcedureType = "N2";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    lbname2.Text = dt.Rows[0]["circle_name"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void BindGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.fk_user_registration_Id = userid;
                objAdminBAO.fk_circle_id = Convert.ToInt32(circleid);
                objAdminBAO.ProcedureType = "M";
                dt = AdminDAO.GetUserFriendsCount(objAdminBAO);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("USerCircleDetail.aspx?val=" + userid, false);
                Session["Circle"] = true;
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
                BindGridView();
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
