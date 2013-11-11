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
    public partial class Circles : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
   
                if (string.IsNullOrEmpty(Request.QueryString["val"]))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        userid = Convert.ToInt32(Request.QueryString["val"]);
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

        // for getting user name//
        private void getname()
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
                    //lbname2.Text = dt.Rows[0]["last_name"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        // bind circle name and number of friends in gridview//
        private void bindGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ProcedureType = "C2";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
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



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "friend")
                {
                    string circleid = e.CommandArgument.ToString();
                    Response.Redirect("userfriendList.aspx?val=" + userid + "&circleid=" + circleid, false);
                    Session["User"] = true;
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
                    Label lbId = (Label)e.Row.FindControl("lbId");
                    LinkButton lnkFrnd = (LinkButton)e.Row.FindControl("lnkFrnd");
                    DataTable dtcount = new DataTable();
                    objAdminBAO.fk_user_registration_Id = userid;
                    objAdminBAO.fk_circle_id = Convert.ToInt32(lbId.Text);
                    objAdminBAO.ProcedureType = "C";
                    dtcount = AdminDAO.GetUserFriendsCount(objAdminBAO);
                    if (dtcount.Rows.Count > 0)
                    {
                        if (dtcount.Rows[0]["nooffrinds"].ToString() == "0")
                        {
                            lnkFrnd.Text = " 1";
                        }
                        else
                        {
                            lnkFrnd.Text = dtcount.Rows[0]["nooffrinds"].ToString();
                        }
                        if (lnkFrnd.Text == "0")
                        {
                            lnkFrnd.Enabled = false;
                            lnkFrnd.Style.Add("color", "#555");
                        }
                    }
                    else
                    {
                        lnkFrnd.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkUser_Click(object sender, EventArgs e)
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
    }
}
