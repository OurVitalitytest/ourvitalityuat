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
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;

namespace ALEREIMPACT.User
{
    public partial class LibraryInspirators : System.Web.UI.UserControl
    {
        UserInspiratorsBAL objUserInspiratorBAL = new UserInspiratorsBAL();
        public static Int32 userid = 0;
        public static Int32 inspiratorid = 0;
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
                        userid = Convert.ToInt32(MySession.Current.LoginId);
                        //if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) == Convert.ToInt32(MySession.Current.LoginId))
                        //{
                        //    userid = Convert.ToInt32(MySession.Current.LoginId);
                        //}
                        //else if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) != Convert.ToInt32(MySession.Current.LoginId))
                        //{
                        //    userid = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                        //}
                        MySession.Current.PageIndex = 1;
                        MySession.Current.PageSize = 0;
                        bindDLmyInspirator();
                        DropDownList1.SelectedValue = "2";
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void bindDLmyInspirator()
        {
            try
            {
                DataTable dt = new DataTable();

                //if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) == Convert.ToInt32(MySession.Current.LoginId))
                //{
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.Friend_id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                objUserInspiratorBAL.fk_user_circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                //}
                //else 
                //{
                //    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                //    objUserInspiratorBAL.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                //}


                objUserInspiratorBAL.page_index = Convert.ToInt32(MySession.Current.PageIndex);
                objUserInspiratorBAL.page_size = Convert.ToInt32(MySession.Current.PageSize);
                objUserInspiratorBAL.ProcedureType = "L";
                dt = UserInspiratorsDAL.GetUserInspirator(objUserInspiratorBAL);
                DataList1.DataSource = dt;
                DataList1.DataBind();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MySession.Current.RowsGenerated = Convert.ToInt32(dt.Rows[0]["ROW_GENERATED"]);
                        if (MySession.Current.RowsGenerated == dt.Rows.Count)
                        {
                            lnkViewMore.Visible = false;
                        }
                        else
                        {
                            lnkViewMore.Visible = true;
                        }
                    }
                    else
                    {
                        tdREc.Style.Add("display", "");
                        lbNorecord.Visible = true;
                        lbNorecord.Text = "Currently no Inspirator found in your library";
                        lnkViewMore.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "Like")
                {
                    string inspiratorid = e.CommandArgument.ToString();
                    int retval = 0;
                    objUserInspiratorBAL.pk_InspiratorLiked_id = 0;
                    objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.InspiratorLiked_on = DateTime.Now.ToString();
                    objUserInspiratorBAL.ProcedureType = "I";
                    retval = UserInspiratorsDAL.InsertInspiratorLike(objUserInspiratorBAL);
                    bindDLmyInspirator();
                }
                else if (e.CommandName == "PopUp")
                {
                    inspiratorid = Convert.ToInt32(e.CommandArgument);
                    this.ModalPopupExtender1.Show();
                    panel4.Visible = true;
                    bindDLInspirator();
                }
               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void bindDLInspirator()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserInspiratorBAL.pk_Inspirator_id = inspiratorid;
                objUserInspiratorBAL.ProcedureType = "S";
                dt = UserInspiratorsDAL.GetViewInspirator(objUserInspiratorBAL);
                if (dt.Rows.Count > 0)
                {
                    Image1.ImageUrl = "../User/InspiratorImages/" + dt.Rows[0]["Inspirator_image"].ToString();
                    lbName.Text = dt.Rows[0]["first_name"].ToString();
                    lbDesc.Text = dt.Rows[0]["Inspirator_desc"].ToString();
                    MySession.Current.LabelId = dt.Rows[0]["pk_Inspirator_id"].ToString();

                    DataTable dt1 = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = inspiratorid;

                    //if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) == Convert.ToInt32(MySession.Current.LoginId))
                    //{
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    lnkInspLike.Enabled = true;
                    txtComments.Enabled = true;
                    btnComment.Enabled = true;

                    //}
                    //else 
                    //{
                    //    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    //    lnkInspLike.Enabled = true;
                    //    txtComments.Enabled = true;
                    //    btnComment.Enabled = true;

                    //}

                    objUserInspiratorBAL.ProcedureType = "S";
                    dt1 = UserInspiratorsDAL.GetUserInspiratorLike(objUserInspiratorBAL);
                    if (dt1.Rows.Count > 0)
                    {
                        lnkInspLike.Text = "Liked";
                        lnkInspLike.Enabled = false;
                    }
                    else
                    {

                        lnkInspLike.Text = "Like";
                        lnkInspLike.Enabled = true;

                    }
                    DataTable dtlike = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = inspiratorid;
                    objUserInspiratorBAL.ProcedureType = "L";
                    dtlike = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
                    if (dtlike.Rows.Count > 0)
                    {
                        lbLikeCount.Text = dtlike.Rows[0]["nooflike"].ToString();
                    }
                    else
                    {
                        lbLikeCount.Text = "0";
                    }

                    DataTable dtcomment = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = inspiratorid;
                    objUserInspiratorBAL.ProcedureType = "C";
                    dtcomment = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
                    if (dtcomment.Rows.Count > 0)
                    {
                        lbCommentCount.Text = dtcomment.Rows[0]["noofcomments"].ToString();
                    }
                    else
                    {
                        lbCommentCount.Text = "0";
                    }



                    DataTable dtCommentDesc = new DataTable();
                    objUserInspiratorBAL.pk_Inspirator_id = inspiratorid;
                    objUserInspiratorBAL.ProcedureType = "C";
                    dtCommentDesc = UserInspiratorsDAL.GetViewInspirator(objUserInspiratorBAL);
                    if (dtCommentDesc.Rows.Count > 0)
                    {
                        divComments.Style.Add("display", "");
                        Repeater1.DataSource = dtCommentDesc;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        divComments.Style.Add("display", "none");
                    }



                }
                Session["InspDescription"] = null;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                try
                {
                    HiddenField hdnuserid = (HiddenField)e.Item.FindControl("hdnUserid");
                    HiddenField hdnInspiratorid = (HiddenField)e.Item.FindControl("hdnInspiratorid");
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    Label lbLikeCount = (Label)e.Item.FindControl("lbLikeCount");
                    Label lbCommentCount = (Label)e.Item.FindControl("lbCommentCount");
                    LinkButton lnkLike = (LinkButton)e.Item.FindControl("lnkLike");
                   
                    HtmlAnchor aimage = (HtmlAnchor)e.Item.FindControl("aimage");
                    ImageButton img = (ImageButton)e.Item.FindControl("ImageButton2");
                    string val = hdnImage.Value;
                    img.ImageUrl = "../User/InspiratorImages/" + val;
                 //string pageid="3";
                 //   aimage.HRef = "~/User/Inspirators.aspx?val=" + hdnInspiratorid.Value+"&pageid="+pageid;
                    DataTable dtlike = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = hdnInspiratorid.Value;
                    objUserInspiratorBAL.ProcedureType = "L";
                    dtlike = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
                    if (dtlike.Rows.Count > 0)
                    {
                        lbLikeCount.Text = dtlike.Rows[0]["nooflike"].ToString();
                    }
                    else
                    {
                        lbLikeCount.Text = "0";
                    }
                    DataTable dtcomment = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = hdnInspiratorid.Value;
                    objUserInspiratorBAL.ProcedureType = "C";
                    dtcomment = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
                    if (dtcomment.Rows.Count > 0)
                    {
                        lbCommentCount.Text = dtcomment.Rows[0]["noofcomments"].ToString();
                    }
                    else
                    {
                        lbCommentCount.Text = "0";
                    }

                    DataTable dt = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = hdnInspiratorid.Value;
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.ProcedureType = "S";
                    dt = UserInspiratorsDAL.GetUserInspiratorLike(objUserInspiratorBAL);
                    if (dt.Rows.Count > 0)
                    {
                        lnkLike.Text = "Liked";
                        lnkLike.Enabled = false;
                    }
                    else
                    {

                        lnkLike.Text = "Like";
                        lnkLike.Enabled = true;
                    }
                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        lnkLike.Enabled = true;

                    }
                    else
                    {
                        lnkLike.Enabled = false;
                    }
                   

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

            }
        }

        protected void lnkViewMore_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                MySession.Current.PageSize += 8;
                bindDLmyInspirator();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (DropDownList1.SelectedValue == "1")
                {
                    Response.Redirect("~/User/Inspirators.aspx", false);

                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    Session["LibraryInspirator"] = true;
                    Response.Redirect("~/User/Inspirators.aspx", false);
                }

                else
                {
                    Response.Redirect("~/User/Inspirators.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkInspLike_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objUserInspiratorBAL.pk_InspiratorLiked_id = 0;
                objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.InspiratorLiked_on = DateTime.Now.ToString();
                objUserInspiratorBAL.ProcedureType = "I";
                retval = UserInspiratorsDAL.InsertInspiratorLike(objUserInspiratorBAL);
                bindDLmyInspirator();
                bindDLInspirator();
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkComments_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
        }


        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objUserInspiratorBAL.pk_inspiratorLib_id = 0;
                objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.inspiratorLib_createdon = DateTime.Now.ToString();
                objUserInspiratorBAL.ProcedureType = "I";
                retval = UserInspiratorsDAL.InsertInspiratorLibrary(objUserInspiratorBAL);
                bindDLmyInspirator();

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Inspirator successfully added to Library');", true);
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objUserInspiratorBAL.pk_InspiratorInappro_id = 0;
                objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.InspiratorInappro_on = DateTime.Now.ToString();
                objUserInspiratorBAL.ProcedureType = "I";
                retval = UserInspiratorsDAL.InsertInspiratorInappropriate(objUserInspiratorBAL);
                bindDLmyInspirator();
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objUserInspiratorBAL.pk_InspiratorComments_id = 0;
                objUserInspiratorBAL.InspiratorComment_text = txtComments.Text;
                objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.InspiratorComment_on = DateTime.Now.ToString();
                objUserInspiratorBAL.ProcedureType = "I";
                retval = UserInspiratorsDAL.InsertInspiratorComment(objUserInspiratorBAL);

                txtComments.Text = "";
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
                bindDLInspirator();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}