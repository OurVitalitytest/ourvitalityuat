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
    public partial class UserReportedErrorLog : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
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
                        PanelReply.Visible = true;
                        Panel1.Visible = false;
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
                objAdminBAO.ProcedureType = "ED";
                dt = AdminDAO.GettbUserDetail(objAdminBAO);
                GridView1.DataSource = dt;
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
                if (e.CommandName == "lnkMessage")
                {
                    Panel1.Visible = true;
                    PanelReply.Visible = false;
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(e.CommandArgument);
                    objAdminBAO.ProcedureType = "EL";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    int retval = 0;
                    objAdminBAO.ER_ID = Convert.ToInt32(e.CommandArgument);
                    objAdminBAO.PAGE_ID_FK = dt.Rows[0]["PAGE_ID_FK"].ToString();
                    objAdminBAO.fk_user_registration_id = dt.Rows[0]["fk_user_registration_id"].ToString();
                    objAdminBAO.ER_MESSAGE = dt.Rows[0]["ER_MESSAGE"].ToString();
                    objAdminBAO.ER_IMAGE = dt.Rows[0]["ER_IMAGE"].ToString();
                    objAdminBAO.ER_POST_DATE = dt.Rows[0]["postDAte"].ToString();
                    objAdminBAO.ER_STATUS = "True";
                    objAdminBAO.ProcedureType = "U";
                    retval = AdminDAO.UpdatetblErrorDetail(objAdminBAO);
                    bindGrd();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
       
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkImage")
                {

                    this.ModalPopupExtender1.Show();
                    divadd.Style.Add("display", "");
                    panel2.Visible = true;
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(e.CommandArgument);
                    objAdminBAO.ProcedureType = "EL";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        Image2.ImageUrl = "/AlereImpactNew/User/ReportErrorImages/" + dt.Rows[0]["ER_IMAGE"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl DivImage = (HtmlGenericControl)e.Row.FindControl("DivImage");
                    Image Image1 = (Image)e.Row.FindControl("Image1");
                    HiddenField HiddenField1 = (HiddenField)e.Row.FindControl("HiddenField1");
                    if (HiddenField1.Value == "")
                    {
                        DivImage.Style.Add("display", "none");
                    }
                    else
                    {
                        DivImage.Style.Add("display", "");
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
                    Label Label1 = (Label)e.Row.FindControl("Label1");
                    LinkButton lnk = (LinkButton)e.Row.FindControl("LinkButton1");
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(Label1.Text);
                    objAdminBAO.ProcedureType = "EL";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["ER_STATUS"].ToString() == "False")
                        {
                            lnk.Style.Add("background-color", "#999999");
                        }
                        else
                        {
                            lnk.Style.Add("background-color", "#EEEEEE");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkError_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("ErrorTypeLog.aspx", false);
                Session["Error"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
