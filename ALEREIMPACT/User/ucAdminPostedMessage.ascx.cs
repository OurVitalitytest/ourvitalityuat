using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.DAL.User;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.BAL.User;

namespace ALEREIMPACT.User
{
    public partial class ucAdminPostedMessage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //if (Session["show_admin_posed_messages"] != null)
                    //{
                    //    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    //    {
                    //        Bind_AdminPosts(Convert.ToInt32(MySession.Current.SelectedCircleUserId), "", 0, 1);
                    //    }
                    //    else
                    //    {
                    //        Bind_AdminPosts(Convert.ToInt32(MySession.Current.SelectedCircleUserId), "", 0, 1);
                    //    }
                    //    Session["show_admin_posed_messages"] = null;
                    //}
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void Bind_AdminPosts(int LoginId, string replymessage, Int32 reply_to_admin_message_id, Int32 request_type_id)
        {
            DataTable dtComments = new DataTable();
            UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
            UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

            ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
            ObjUserCommentsBAL.PostedComments = string.Empty;
            ObjUserCommentsBAL.ReplyToAdminMessageId = 0;
            ObjUserCommentsBAL.RequestTypeId = 1;
            dtComments = UserCommentsDAL.GetAndReply_AdminPostedComments(ObjUserCommentsBAL);

            if (dtComments.Rows.Count > 0)
            {
                grdPostedMessages.DataSource = dtComments;
                grdPostedMessages.DataBind();

                dvEmptyMessage.Visible = false;
            }
            else
            {
                dvEmptyMessage.Visible = true;
            }


            //if (dtComments != null)
            //{
            //    if (dtComments.Rows.Count > 0)
            //    {
            //        MySession.Current.RowsGenerated = Convert.ToInt32(dtComments.Rows[0]["RowsGenerated"]);
            //        if (MySession.Current.RowsGenerated == dtComments.Rows.Count)
            //        {
            //            lnkViewMore.Visible = false;
            //        }
            //        else
            //        {
            //            lnkViewMore.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        lnkViewMore.Visible = false;
            //    }
            //}
        }
        protected void grdPostedMessages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string MajorCommentId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PostedMessageIDByAdmin"));

                GridView grdSubComments = (GridView)e.Row.FindControl("grdSubComments");
                GridViewRow ParentRow = (GridViewRow)grdSubComments.NamingContainer;
                DataTable dtSubComments = new DataTable();

                UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                ObjUserCommentsBAL.PostedComments = string.Empty;
                ObjUserCommentsBAL.ReplyToAdminMessageId = Convert.ToInt32(MajorCommentId);
                ObjUserCommentsBAL.RequestTypeId = 3;
                dtSubComments = UserCommentsDAL.GetAndReply_AdminPostedComments(ObjUserCommentsBAL);

                HtmlGenericControl dvSubComment = (HtmlGenericControl)e.Row.FindControl("dvSubComment");
                Label lblCountSubComments = (Label)e.Row.FindControl("lblCountSubComments");

                if (dtSubComments.Rows.Count > 0)
                {
                    grdSubComments.DataSource = dtSubComments;
                    grdSubComments.DataBind();
                    dvSubComment.Visible = true;
                }
                else
                {
                    dvSubComment.Visible = false;
                }

            }
        }
        protected void grdPostedMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            if (e.CommandName == "ReplyComment")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                TextBox txtReply = (TextBox)row.Cells[0].FindControl("txtReply");

                string commArg = Convert.ToString(e.CommandArgument);
                UserCommentsBAL ObjUserCommentsBAL = new UserCommentsBAL();
                UserCommentsDAL ObjUserCommentsDAL = new UserCommentsDAL();

                ObjUserCommentsBAL.LoginId = Convert.ToInt32(MySession.Current.LoginId);
                ObjUserCommentsBAL.ReplyMessage = txtReply.Text.Trim();
                ObjUserCommentsBAL.ReplyToAdminMessageId = Convert.ToInt32(commArg);
                ObjUserCommentsBAL.RequestTypeId = 2;
                UserCommentsDAL.GetAndReply_AdminPostedComments(ObjUserCommentsBAL);
                Bind_AdminPosts(Convert.ToInt32(MySession.Current.SelectedCircleUserId), "", 0, 1);
            }
            else if (e.CommandName == "ClikedToPostReply")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lnkPostReply = (LinkButton)row.FindControl("lnkPostReply");
                Panel dvPostSubComment = (Panel)row.Cells[0].FindControl("dvPostSubComment");
                HtmlGenericControl dvPostSubCommentOnMajor = (HtmlGenericControl)row.FindControl("dvPostSubCommentOnMajor");

                if (lnkPostReply.Text == "Reply")
                {
                    dvPostSubComment.Visible = true;
                    dvPostSubCommentOnMajor.Visible = false;
                }
                else
                {
                    dvPostSubComment.Visible = false;
                    dvPostSubCommentOnMajor.Visible = true;
                }
            }
        }
    }
}