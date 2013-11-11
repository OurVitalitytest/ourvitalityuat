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
    public partial class TicketMesssages : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 msg_id = 0;
        public static Int32 User_id = 0;
        ClsGeneric objClsGeneric = new ClsGeneric();
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
                objAdminBAO.ProcedureType = "TM";
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
                if (e.CommandName == "lnkReply")
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(',');
                    Session["msg_id"] = arg[0];
                    Session["User_id"] = arg[1];
                    msg_id = Convert.ToInt32(Session["msg_id"]);
                    User_id = Convert.ToInt32(Session["User_id"]);
                    this.ModalPopupExtender1.Show();
                    divadd.Style.Add("display", "");
                    panel2.Visible = true;
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = User_id;
                    objAdminBAO.ProcedureType = "E";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        lbEmail.Text = dt.Rows[0]["login_email"].ToString();
                    }
                    lbTicketN.Text = Convert.ToString(msg_id);
                    DataTable dt1 = new DataTable();
                    objAdminBAO.ID = msg_id;
                    objAdminBAO.ProcedureType = "TM";
                    dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt1.Rows.Count > 0)
                    {
                        int retval1 = 0;
                        objAdminBAO.T_ID = msg_id;
                        objAdminBAO.fk_user_registration_id = User_id;
                        objAdminBAO.T_MESSAGE = dt1.Rows[0]["T_MESSAGE"].ToString();
                        objAdminBAO.T_REPLYSTATUS = dt1.Rows[0]["T_REPLYSTATUS"].ToString();
                        objAdminBAO.T_DATE = dt1.Rows[0]["T_DATE"].ToString();
                        objAdminBAO.T_STATUS = "True";
                        objAdminBAO.ProcedureType = "U";
                        retval1 = AdminDAO.UpdatetblTicket(objAdminBAO);
                    }

                }
                else if (e.CommandName == "lnkView")
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(',');
                    Session["msg_id"] = arg[0];
                    Session["User_id"] = arg[1];
                    msg_id = Convert.ToInt32(Session["msg_id"]);
                    User_id = Convert.ToInt32(Session["User_id"]);
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = msg_id;
                    objAdminBAO.ProcedureType = "TM";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        int retval1 = 0;
                        objAdminBAO.T_ID = msg_id;
                        objAdminBAO.fk_user_registration_id = User_id;
                        objAdminBAO.T_MESSAGE = dt.Rows[0]["T_MESSAGE"].ToString();
                        objAdminBAO.T_REPLYSTATUS = dt.Rows[0]["T_REPLYSTATUS"].ToString();
                        objAdminBAO.T_DATE = dt.Rows[0]["T_DATE"].ToString();
                        objAdminBAO.T_STATUS = "True";
                        objAdminBAO.ProcedureType = "U";
                        retval1 = AdminDAO.UpdatetblTicket(objAdminBAO);
                    }
                    Response.Redirect("ViewTicketsReply.aspx?val=" + User_id + "&msg_id=" + msg_id, false);
                    Session["FeedBack"] = true;


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
                bindGrd();
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
                    Label lbID = (Label)e.Row.FindControl("lbID");
                    Label Label1 = (Label)e.Row.FindControl("Label1");
                    Label lbStatus = (Label)e.Row.FindControl("lbStatus");
                    if (Label1.Text == "False")
                    {
                        lbStatus.Text = "Waiting";
                    }
                    else
                    {
                        lbStatus.Text = "Replied";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void btn_Reply_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                string email = lbEmail.Text;
                string Subject = "Alere Vitality Ticket Reply";
                string body = txtREply.Text;
                int retval = 0;
                objAdminBAO.TR_ID = 0;
                objAdminBAO.fk_user_registration_id = User_id;
                objAdminBAO.T_ID_FK = msg_id;
                objAdminBAO.TR_REPLY = txtREply.Text;
                objAdminBAO.TR_DATE = DateTime.Now.ToString();
                objAdminBAO.ProcedureType = "I";
                retval = AdminDAO.InserttblTicketREply(objAdminBAO);
                DataTable dt = new DataTable();
                objAdminBAO.ID = msg_id;
                objAdminBAO.ProcedureType = "TM";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    int retval1 = 0;
                    objAdminBAO.T_ID = msg_id;
                    objAdminBAO.fk_user_registration_id = User_id;
                    objAdminBAO.T_MESSAGE = dt.Rows[0]["T_MESSAGE"].ToString();
                    objAdminBAO.T_REPLYSTATUS = "True";
                    objAdminBAO.T_DATE = dt.Rows[0]["T_DATE"].ToString();
                    objAdminBAO.T_STATUS = "True";
                    objAdminBAO.ProcedureType = "U";
                    retval1 = AdminDAO.UpdatetblTicket(objAdminBAO);
                }
                objClsGeneric.SendMail(email, body, Subject);

                bindGrd();
                txtREply.Text = "";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkMsg_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("MessagesandTickets.aspx", false);
                Session["FeedBack"] = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
