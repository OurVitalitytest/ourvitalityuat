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


namespace ALEREIMPACT.User
{
    public partial class ucMemberList : System.Web.UI.UserControl
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    GetMemberList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GetMemberList()
        {
            try
            {
                DataTable dtpendingreq = new DataTable();
                // grdPendingRequests.DataSource = dtpendingreq;
                // grdPendingRequests.DataBind();
                if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                {
                    if (Request.QueryString["uid"] != null)
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(Request.QueryString["uid"]);
                    }
                    else
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    }
                }
                else
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.MemberUserId);
                }
                if (Request.QueryString["cid"] != null)
                {
                    objusercircles.fk_circle_id = Convert.ToInt32(Request.QueryString["cid"]);
                }
                else
                {
                    objusercircles.fk_circle_id = MySession.Current.CircleId;
                }
                objusercircles.proceduretype = "S";
                dtpendingreq = UserCirclesDAO.GetFriendList(objusercircles);
                if (MySession.Current.LoginId == MySession.Current.SelectedCircleUserId)
                {
                    if (dtpendingreq.Rows.Count > 0)
                    {
                        //if (dtpendingreq.Rows.Count >= 4)
                        //{
                        //    dlmemberlist.RepeatColumns = 4;
                        //}
                        //else
                        //{
                        //    dlmemberlist.RepeatColumns = dtpendingreq.Rows.Count;
                        //}

                        dlmemberlist.DataSource = dtpendingreq;
                        dlmemberlist.DataBind();
                        //grdPendingRequests.DataSource = dtpendingreq;
                        //grdPendingRequests.DataBind();
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    if (Request.QueryString["cid"] != null)
                    {
                        objusercircles.ID = Convert.ToInt32(Request.QueryString["cid"]);
                    }
                    else
                    {
                        objusercircles.ID = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    }

                    objusercircles.proceduretype = "GF";
                    dt = UserCirclesDAO.GetUserNameEmail(objusercircles);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UPS_ANYONE"].ToString() == "True")
                        {
                            dlmemberlist.DataSource = dtpendingreq;
                            dlmemberlist.DataBind();
                        }
                        else if (dt.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                        {
                            dlmemberlist.DataSource = dtpendingreq;
                            dlmemberlist.DataBind();
                        }
                        else if (dt.Rows[0]["UPS_YOU"].ToString() == "True")
                        {
                            lbmsg.Visible = true;
                            dtpendingreq = null;
                            dlmemberlist.DataSource = dtpendingreq;
                            dlmemberlist.DataBind();
                        }
                    }
                    else
                    {
                        dlmemberlist.DataSource = dtpendingreq;
                        dlmemberlist.DataBind();
                        dtpendingreq = null;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            if (Request.QueryString["cid"] != null && Request.QueryString["uid"] != null)
            {
                //ALEREIMPACT.User.TopselectedCircle pa = new TopselectedCircle();
                //pa.GetCircleName();
            }
        }

        protected void dlmemberlist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkImage")
                {
                    string id = e.CommandArgument.ToString();
                    if (MySession.Current.LoginId == Convert.ToString(id))
                    {
                    }
                    else
                    {
                        Session["USerProfile"] = true;
                    }
                    Response.Redirect("MyProfile.aspx?val=" + id, false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }



        protected void dlmemberlist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    ImageButton frdimage = (ImageButton)e.Item.FindControl("frdimage");
                    Label lbfrdaddress = (Label)e.Item.FindControl("lbfrdaddress");
                    Label frdregid = (Label)e.Item.FindControl("frdregid");
                    if (hdnImage.Value == "" || hdnImage.Value == null)
                    {
                        frdimage.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                    }
                    else
                    {
                        if (MySession.Current.LoginId == Convert.ToString(frdregid.Text))
                        {
                            frdimage.ImageUrl = "profile_image/" + hdnImage.Value;
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objusercircles.ID = Convert.ToInt32(frdregid.Text);
                            objusercircles.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objusercircles);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    frdimage.ImageUrl = "profile_image/" + hdnImage.Value;
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    frdimage.ImageUrl = "profile_image/" + hdnImage.Value;
                                }
                                else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    frdimage.ImageUrl = "profile_image/profileBlankPhoto.jpg";
                                }
                            }
                            else
                            {
                                frdimage.ImageUrl = "profile_image/" + hdnImage.Value;
                            }

                        }
                    }
                    DataTable dtEmail = new DataTable();
                    objusercircles.ID = Convert.ToInt32(frdregid.Text);
                    objusercircles.proceduretype = "GE1";
                    dtEmail = UserCirclesDAO.GetUserNameEmail(objusercircles);
                    if (dtEmail.Rows.Count > 0)
                    {
                        if (dtEmail.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                        {
                            lbfrdaddress.Visible = true;
                        }
                        else if (dtEmail.Rows[0]["UPS_YOU"].ToString() == "True")
                        {
                            if (MySession.Current.LoginId == Convert.ToString(frdregid.Text))
                            {
                                lbfrdaddress.Visible = true;
                            }
                            else
                            {
                                lbfrdaddress.Visible = false;
                            }
                        }
                        else
                        {
                            lbfrdaddress.Visible = false;
                        }


                    }
                    else
                    {
                        lbfrdaddress.Visible = false;
                    }



                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkInvite_Click(object sender, EventArgs e)
        {
            Response.Redirect("InviteMembers.aspx", false);
        }

    }
}