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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        ClsGeneric objClsGeneric = new ClsGeneric();
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
                        bindLogtimeGrd();
                        bindCreateCircleGrd();
                        bindPostCommentGrd();
                        bindMissionGrd();
                        bindInspiratorGrd();

                    }
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void bindLogtimeGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "D";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindCreateCircleGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "D2";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GrdCreateCircle.DataSource = dt;
                GrdCreateCircle.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindPostCommentGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "D1";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GrdPostComment.DataSource = dt;
                GrdPostComment.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindMissionGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "D3";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GrdAddMission.DataSource = dt;
                GrdAddMission.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void bindInspiratorGrd()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ProcedureType = "D4";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GrdAddInspirator.DataSource = dt;
                GrdAddInspirator.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (RadioButtonList1.SelectedValue == "" || RadioButtonList1.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Please select atleast one option either Web or Mobile');", true);
                }
                else
                {
                    int retval = 0;
                    objAdminBAO.GM_ID = 0;
                    objAdminBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.GM_MESSAGE = txtMessage.Text;
                    objAdminBAO.GM_DATE = DateTime.Now.ToString();
                    if (RadioButtonList1.SelectedValue == "0")
                    {
                        objAdminBAO.GM_WM = "Web";
                    }
                    else
                    {
                        objAdminBAO.GM_WM = "Mobile";
                    }
                    objAdminBAO.ProcedureType = "I";
                    retval = AdminDAO.InserttblGlobalMessage(objAdminBAO);
                    txtMessage.Text = "";
                    RadioButtonList1.SelectedValue = "";
                    lbMsg.Visible = true;

                }
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
                bindLogtimeGrd();
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
                    Label lblogout = (Label)e.Row.FindControl("lblogout");
                    Image Image1 = (Image)e.Row.FindControl("Image1");
                    Label lbimage = (Label)e.Row.FindControl("lbimage");
                    if (lblogout.Text == "1900-01-01 00:00:00")
                    {
                        lblogout.Text = "NA";
                    }

                    if (lbimage.Text == "True")
                    {
                        Image1.ImageUrl = "../images/online-icon.png";
                    }
                    else
                    {
                        Image1.ImageUrl = "../images/Actions-im-user-offline-icon.png";
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
       
    }
}
