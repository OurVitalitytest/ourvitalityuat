using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.Admin;

namespace ALEREIMPACT.User
{
    public partial class ucPendingFriendRequests : System.Web.UI.UserControl
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();
        public  int count = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    GetPendingRequests();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void GetPendingRequests()
        {
            try
            {
                DataTable dtpendingreq = new DataTable();
                dlPendingRequests.DataSource = dtpendingreq;
                dlPendingRequests.DataBind();

                objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.proceduretype = "D";
                dtpendingreq = UserCirclesDAO.GetPendingFriendRequests(objusercircles);
                if (dtpendingreq.Rows.Count > 0)
                {
                    dlPendingRequests.DataSource = dtpendingreq;
                    dlPendingRequests.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void dlPendingRequests_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdnColor = (HiddenField)e.Item.FindControl("hdnColor");
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    HiddenField hdnUserId = (HiddenField)e.Item.FindControl("hdnUserId");
                    HiddenField hdnMEmbername = (HiddenField)e.Item.FindControl("hdnMEmbername");
                    HiddenField hdnCircleName = (HiddenField)e.Item.FindControl("hdnCircleName");
                    HiddenField hdnPermissionId = (HiddenField)e.Item.FindControl("hdnPermissionId");
                    Label lbJoinCircle = (Label)e.Item.FindControl("lbJoinCircle");

                    HtmlGenericControl divCircle = (HtmlGenericControl)e.Item.FindControl("divCircle");
                    HtmlGenericControl divHoverColor = (HtmlGenericControl)e.Item.FindControl("divHoverColor");
                    divCircle.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                    divHoverColor.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                    HiddenField hdnIMIMage = (HiddenField)e.Item.FindControl("hdnIMIMage");
                    Image frdimage = (Image)e.Item.FindControl("frdimage");
                    if (hdnIMIMage.Value == "" || hdnIMIMage.Value == null)
                    {
                        frdimage.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                    }
                    else
                    {
                        DataTable dtPhoto = new DataTable();
                        objusercircles.ID = Convert.ToInt32(hdnUserId.Value);
                        objusercircles.proceduretype = "GP";
                        dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                        if (dtPhoto.Rows.Count > 0)
                        {
                            if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                            {
                                frdimage.ImageUrl = "profile_image/" + hdnIMIMage.Value;
                            }
                            else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                            {
                                DataTable dtFreinds = new DataTable();
                                AdminBAO objAdminBAO = new AdminBAO();
                                objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                objAdminBAO.ID1 = Convert.ToInt32(hdnUserId.Value);
                                objAdminBAO.ProcedureType = "GF";
                                dtFreinds = AdminDAO.GetSearchDetail(objAdminBAO);
                                if (dtFreinds.Rows.Count > 0)
                                {
                                    frdimage.ImageUrl = "profile_image/" + hdnIMIMage.Value;
                                }
                                else
                                {
                                    frdimage.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                                }
                            }
                            else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                            {
                                frdimage.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                            }
                        }
                        else
                        {
                            frdimage.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                        }
                    }

                    if (hdnPermissionId.Value == "5")
                    {
                        lbJoinCircle.Text ="''"+ hdnMEmbername.Value+"''" + "  want to join your " + "''"+hdnCircleName.Value+"''";
                    }
                  
                    else
                    {
                        lbJoinCircle.Text = "''" + hdnMEmbername.Value + "''" + "  has invited you to Join their  " + "''" + hdnCircleName.Value + "''";
                    }


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void dlPendingRequests_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkView")
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string userID = arg[0];
                    string CircleiD = arg[1];
                    Session["bubbleId"] = "1";
                    string cid = userID + "-" + CircleiD;
                    (Session["selectedcircleid"]) = cid;
                    MySession.Current.MemberUserId = userID;
                    MySession.Current.MemberCircleId = CircleiD;
                    Session["USerProfile"] = true;
                    Response.Redirect("MyProfile.aspx", false);
                    //Session["selectedcircleid"] = MySession.Current.PublicCircleUserId + "-" + MySession.Current.PublicCircleId;
                    //Session["Topselcircle"] = MySession.Current.PublicCircleId;
                    //Session["Circle"] = true;
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void grdPendingRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            //if (e.CommandName == "ClikedToAcceptRequest")
            //{

            //    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            //    Label lbfrdid = (Label)row.FindControl("frdregid");
            //    DropDownList ddlcircleid = (DropDownList)row.FindControl("ddlcircleopt");    

            //    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);

            //    objusercircles.friend_registration_id = lbfrdid.Text;
            //    objusercircles.fk_circle_id = Convert.ToInt32(ddlcircleid.SelectedValue).ToString();
            //   // objusercircles.fk_circle_id = 0;
            //    objusercircles.request_status = 2; //Accept Request
            //    objusercircles.updated_on = System.DateTime.Now;
            //    objusercircles.proceduretype = "A";
            //    UserCirclesDAO.AcceptFriendRequest(objusercircles);
            //    GetPendingRequests();

            //    // ucCircles ctrlCircles = (ucCircles)Page.FindControl("ctl00_circle");
            //    //ctrlCircles.BindCircles();

            //
            //}
        }

        protected void btnviewprofile_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
                Label memberid = (Label)row.FindControl("memberid");
                Label membercircleid = (Label)row.FindControl("lbmembercircleid");
                Label ucid = (Label)row.FindControl("lbucid");
                Session["bubbleId"] = "1";
                string cid = memberid.Text + "-" + membercircleid.Text;
                (Session["selectedcircleid"]) = cid;
                MySession.Current.MemberUserId = memberid.Text;
                MySession.Current.MemberCircleId = membercircleid.Text;
                Session["USerProfile"] = true;
                Response.Redirect("MyProfile.aspx", false);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow", "parentwindow();", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grdPendingRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl dynamic1 = (HtmlGenericControl)e.Row.FindControl("dvMemberCircles");
                    // dynamic1.Attributes.Add("class", "thumb");

                    HiddenField hndcolor = (HiddenField)e.Row.FindControl("hndcolor");
                    dynamic1.Style.Add("border-color", "#" + hndcolor.Value);


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }           

        }




    }
}