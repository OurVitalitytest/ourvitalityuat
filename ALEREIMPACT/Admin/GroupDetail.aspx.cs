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
    public partial class GroupDetail : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 groupid = 0;

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
                        bindGrd();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
           
        }
        private void bindGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "S";
                dt = AdminDAO.GettblGroupMaster(objAdminBAO);
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
                if (e.CommandName == "lnkedit")
                {
                    string val = e.CommandArgument.ToString();
                    Response.Redirect("Group.aspx?val=" + val, false);
                    Session["Group"] = true;
                }
                else if (e.CommandName == "lnkemail")
                {
                    string val = e.CommandArgument.ToString();
                    Response.Redirect("GroupEmail.aspx?val=" + val, false);
                    Session["Group"] = true;
                }
                else if (e.CommandName == "lnkcomment")
                {
                    string val = e.CommandArgument.ToString();
                    groupid = Convert.ToInt32(e.CommandArgument);
                    this.ModalPopupExtender1.Show();
                    panel1.Visible = true;
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ProcedureType = "GN";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        lbGroup.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                    }

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
                    Label lbid = (Label)e.Row.FindControl("lbid");
                    Label lbMembers = (Label)e.Row.FindControl("lbMembers");
                    LinkButton lnkEmail = (LinkButton)e.Row.FindControl("lnkEmail");
                    LinkButton lnkComment = (LinkButton)e.Row.FindControl("lnkComment");
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(lbid.Text);
                    objAdminBAO.ProcedureType = "M";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        lbMembers.Text = dt.Rows[0]["noofusers"].ToString();
                    }
                    if (lbMembers.Text == "0")
                    {
                        lnkEmail.Enabled = false;
                        lnkComment.Enabled = false;
                        lnkEmail.Style.Add("color", "#555");
                        lnkComment.Style.Add("color", "#555");
                    }
                }
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
                Response.Redirect("Group.aspx", false);
                Session["Group"] = true;
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
                int retval = 0;
                objAdminBAO.AC_ID = 0;
                objAdminBAO.AC_COMMENT = txtComment.Text;
                objAdminBAO.AC_COMMENT_ON = DateTime.Now.ToString();
                objAdminBAO.fk_Admin_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objAdminBAO.fk_circle_id = 1;
                objAdminBAO.GROUP_ID_FK = groupid;
                objAdminBAO.ProcedureType = "I";
                retval = AdminDAO.InserttblAdminCommemts(objAdminBAO);
                if (retval != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Your Comment has been posted.');", true);
                    txtComment.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
