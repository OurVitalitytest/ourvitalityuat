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
    public partial class userfriendList : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        public static Int32 circleid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                //Response.Cache.SetNoStore();
                //Response.AppendHeader("Pragma", "no-cache");
            
                if (string.IsNullOrEmpty(Request.QueryString["val"]))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        userid = Convert.ToInt32(Request.QueryString["val"]);
                        circleid = Convert.ToInt32(Request.QueryString["circleid"]);
                        if (Convert.ToString(Request.QueryString["val1"]) == "" || Convert.ToString(Request.QueryString["val1"]) == null)
                        {
                            // a2.Style.Add("color", "#31A5A0 !important");
                            PanelUser.Visible = true;
                            PanelCircle.Visible = false;
                        }
                        else
                        {
                            PanelUser.Visible = false;
                            PanelCircle.Visible = true;
                            //a1.Style.Add("color", "#31A5A0 !important");
                        }
                        getname();
                        bindGrd();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        // for getting name of circle ,user's name//
        private void getname()
        {
            try
            {
                DataTable dtCN = new DataTable();
                objAdminBAO.ID = circleid;
                objAdminBAO.ProcedureType = "C3";
                dtCN = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                DataTable dt = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ProcedureType = "N";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    lbcirename.Text = dtCN.Rows[0]["circle_name"].ToString() + " (" + dt.Rows[0]["usercode"].ToString() + ")";

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        // for bind gridview//
        private void bindGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.fk_user_registration_Id = userid;
                objAdminBAO.fk_circle_id = circleid;
                objAdminBAO.ProcedureType = "V";
                dt = AdminDAO.GetUserFriendsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    objAdminBAO.fk_user_registration_Id = userid;
                    objAdminBAO.ProcedureType = "V1";
                    dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        // for Link back to circles// 
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("Circles.aspx?val=" + userid, false);
                Session["User"] = true;
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

        protected void LinkButton2_Click(object sender, EventArgs e)
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("AdminPanel.aspx", false);
                Session["User"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
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
