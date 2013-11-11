using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
namespace ALEREIMPACT.User
{
    public partial class UCNIMNotification : System.Web.UI.UserControl
    {
        AdminBAO ObjAdminBAO = new AdminBAO();
        UserMissionsBAL objUserMissionBAl = new UserMissionsBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        UpdateStatus();
                        BindDate();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void UpdateStatus()
        {

            int retavl = 0;
            ObjAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            ObjAdminBAO.ProcedureType = "UN1";
            retavl = AdminDAO.deleteComment(ObjAdminBAO);

            int retavl1 = 0;
            ObjAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            ObjAdminBAO.ProcedureType = "UN2";
            retavl1 = AdminDAO.deleteComment(ObjAdminBAO);


            int retavl2 = 0;
            ObjAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            ObjAdminBAO.ProcedureType = "UN3";
            retavl2 = AdminDAO.deleteComment(ObjAdminBAO);

            DataTable dt = new DataTable();
            ObjAdminBAO.ID = MySession.Current.LoginId;
            ObjAdminBAO.ProcedureType = "UN5";
            dt = AdminDAO.GetUserDeatilsCount(ObjAdminBAO);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int retavl3 = 0;
                    ObjAdminBAO.ID = Convert.ToInt32(dt.Rows[i]["NOTESN_ID"]);
                    ObjAdminBAO.ProcedureType = "UN4";
                    retavl3 = AdminDAO.deleteComment(ObjAdminBAO);
                }
            }

            DataTable dt1 = new DataTable();
            ObjAdminBAO.ID = MySession.Current.LoginId;
            ObjAdminBAO.ProcedureType = "UN6";
            dt1 = AdminDAO.GetUserDeatilsCount(ObjAdminBAO);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    int retavl3 = 0;
                    ObjAdminBAO.ID = Convert.ToInt32(dt1.Rows[i]["IN_ID"]);
                    ObjAdminBAO.ProcedureType = "UN7";
                    retavl3 = AdminDAO.deleteComment(ObjAdminBAO);
                }
            }
        }


        private void BindDate()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Date", typeof(string));
            for (int i = 0; i < 7; i++)
            {
                DateTime date = DateTime.Now.AddDays(-i);
                string date1 = date.ToString();
                table.Rows.Add(date1);
            }
            GrdDAte.DataSource = table;
            GrdDAte.DataBind();
        }


        protected void GrdDAte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    HiddenField hdnDate = (HiddenField)e.Row.FindControl("hdnDate");
                    Label lbDate = (Label)e.Row.FindControl("lbDate");
                    Image ImgLogo = (Image)e.Row.FindControl("ImgLogo");
                    Label lbComment = (Label)e.Row.FindControl("lbComment");
                    Label lbCircleName = (Label)e.Row.FindControl("lbCircleName");
                   
                    GridView GrdNotification = (GridView)e.Row.FindControl("GrdNotification");
                    DateTime date = Convert.ToDateTime(hdnDate.Value);
                    DateTime date1 = Convert.ToDateTime(hdnDate.Value);
                    lbDate.Text = date1.ToString("MMMM dd, yyyy");
                    DataTable dt = new DataTable();
                    objUserMissionBAl.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserMissionBAl.date = lbDate.Text;
                    objUserMissionBAl.ProcedureType = "S";
                    dt = UserMissionsDAL.BindNotifications(objUserMissionBAl);
                    if (dt.Rows.Count > 0)
                    {
                        GrdNotification.DataSource = dt;
                        GrdNotification.DataBind();
                     
                    }
                    

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        protected void GrdNotification_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnDAte1 = (HiddenField)e.Row.FindControl("hdnDAte1");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                HiddenField hdnName = (HiddenField)e.Row.FindControl("hdnName");
                 HiddenField hdnCirclename = (HiddenField)e.Row.FindControl("hdnCirclename");
                 HiddenField hdnCircleowner = (HiddenField)e.Row.FindControl("hdnCircleowner");
                Image ImgLogo = (Image)e.Row.FindControl("ImgLogo");
                Label lbComment = (Label)e.Row.FindControl("lbComment");
                 Label LBnAME = (Label)e.Row.FindControl("LBnAME");
                 Label lbCircleName = (Label)e.Row.FindControl("lbCircleName");
                if (hdnStatus.Value == "Notes")
                {
                    ImgLogo.ImageUrl = "~/images/blog.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text = " has  posted a note in  ";
                    lbCircleName.Text =  hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
                else if (hdnStatus.Value == "Inspirator")
                {
                    ImgLogo.ImageUrl = "~/images/mission.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text =  " has  added a new Inspirator in  ";
                    lbCircleName.Text = hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
                else if (hdnStatus.Value == "Mission")
                {
                    ImgLogo.ImageUrl = "~/images/flag.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text = " has  added a new Mission in  ";
                    lbCircleName.Text = hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
                else if (hdnStatus.Value == "NotesLike")
                {
                    ImgLogo.ImageUrl = "~/images/thumbs_up.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text = " likes your note posted in  ";
                    lbCircleName.Text = hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
                else if (hdnStatus.Value == "InspiratorLike")
                {
                    ImgLogo.ImageUrl = "~/images/thumbs_up.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text = " likes your Inspirator  in  ";
                    lbCircleName.Text = hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
                else if (hdnStatus.Value == "Subcomment")
                {
                    ImgLogo.ImageUrl = "~/images/blog.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text = " comments on your note in  ";
                    lbCircleName.Text = hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
                else if (hdnStatus.Value == "Comment")
                {
                    ImgLogo.ImageUrl = "~/images/blog.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text = " comments on your Inspirator in  ";
                    lbCircleName.Text = hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
                else if (hdnStatus.Value == "Supported")
                {
                    ImgLogo.ImageUrl = "~/images/heart.png";
                    LBnAME.Text = hdnName.Value;
                    lbComment.Text = " Supports your note posted in  ";
                    lbCircleName.Text = hdnCircleowner.Value + "'s  " + hdnCirclename.Value;
                }
            }
        }
    }
}