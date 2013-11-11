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
    public partial class ucMyInspirator : System.Web.UI.UserControl
    {
        UserInspiratorsBAL objUserInspiratorBAL = new UserInspiratorsBAL();
        public static Int32 userid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {        
            if (string.IsNullOrEmpty(MySession.Current.LoginId))
            {
               // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='Default.aspx';", true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "Load", "<script>parent.location='http://google.com';</script>");

              //  Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RedirectScript", "window.parent.location.href = 'Default.aspx'", true);
               // Response.Redirect("~/Login.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    userid = Convert.ToInt32(MySession.Current.LoginId);
                    MySession.Current.PageIndex = 1;
                    MySession.Current.PageSize = 0;
                    bindDLmyInspirator();
                    DropDownList1.SelectedValue = "1";
                }
            }

        }

        private void bindDLmyInspirator()
        {
            DataTable dt = new DataTable();
            if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
            {
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
            }
            else
            {
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
            }
            objUserInspiratorBAL.Friend_id = Convert.ToInt32(MySession.Current.LoginId);
            objUserInspiratorBAL.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
            objUserInspiratorBAL.page_index = Convert.ToInt32(MySession.Current.PageIndex);
            objUserInspiratorBAL.page_size = Convert.ToInt32(MySession.Current.PageSize);
            objUserInspiratorBAL.ProcedureType = "V";
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
                    lbNorecord.Visible = true;
                    lbNorecord.Text = "No Inspirator Found";
                    lnkViewMore.Visible = false;
                }
              
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
                    LinkButton lnkComment = (LinkButton)e.Item.FindControl("lnkComment");
                    ImageButton ImageButton1 = (ImageButton)e.Item.FindControl("ImageButton1");

                    HtmlAnchor aimage = (HtmlAnchor)e.Item.FindControl("aimage");
                    Image img = (Image)e.Item.FindControl("Image1");
                    string val = hdnImage.Value;
                    img.ImageUrl = "../User/InspiratorImages/" + val;
                   
                    string pageid = "1";
                    aimage.HRef = "~/User/Inspirators.aspx?val=" + hdnInspiratorid.Value+"&pageid="+pageid;
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
                    DataTable dtInappro = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = hdnInspiratorid.Value;
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.ProcedureType = "I";
                    dt = UserInspiratorsDAL.GetUserInspiratorLike(objUserInspiratorBAL);
                    if (dtInappro.Rows.Count > 0)
                    {
                        ImageButton1.Enabled = false;
                        ImageButton1.Style.Add(" pointer-events", " none");
                    }
                    else
                    {
                        ImageButton1.Enabled = true;
                    }
                   
                  
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

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
                else if (e.CommandName == "Inappropriate")
                {
                    string inspiratorid = e.CommandArgument.ToString();
                    int retval = 0;
                    objUserInspiratorBAL.pk_InspiratorInappro_id = 0;
                    objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.InspiratorInappro_on = DateTime.Now.ToString();
                    objUserInspiratorBAL.ProcedureType = "I";
                    retval = UserInspiratorsDAL.InsertInspiratorInappropriate(objUserInspiratorBAL);
                    bindDLmyInspirator();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkViewMore_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            MySession.Current.PageSize += 8;
            bindDLmyInspirator();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();

            if (DropDownList1.SelectedValue == "1")
            {
                Session["MyInspirator"] = true;
                Response.Redirect("~/User/Inspirators.aspx", false);

            }
            else if (DropDownList1.SelectedValue == "2")
            {
                Session["FriendInspirator"] = true;
                Response.Redirect("~/User/Inspirators.aspx", false);

            }
            else if (DropDownList1.SelectedValue == "3")
            {
                Session["LibraryInspirator"] = true;
                Response.Redirect("~/User/Inspirators.aspx", false);

            }
            else
            {
                Response.Redirect("~/User/Inspirators.aspx", false);
            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            panel32.Visible = true;
            string filename = "";
            try
            {
                if (fuInspiratorImage.HasFile)
                {
                    Int32 filesize = fuInspiratorImage.PostedFile.ContentLength;
                    if (filesize < 1048576)
                    {
                        string PhotoFileName = fuInspiratorImage.FileName;
                        string fileext = System.IO.Path.GetExtension(PhotoFileName.ToString());
                        Session["_Inspirator"] = PhotoFileName;
                        MySession.Current.Image = PhotoFileName;
                        filename = userid + "_" + PhotoFileName;
                        fuInspiratorImage.PostedFile.SaveAs(MapPath("~") + "/User/InspiratorImages/" + filename);

                        int retval = 0;
                        objUserInspiratorBAL.pk_Inspirator_id = 0;
                        objUserInspiratorBAL.Inspirator_image = filename;
                        objUserInspiratorBAL.Inspirator_desc = txtdesc.Text;
                        objUserInspiratorBAL.fk_user_registration_Id = userid;
                        objUserInspiratorBAL.Inspirator_createdon = DateTime.Now.ToString();
                        objUserInspiratorBAL.Fk_Inspirator_status_id = 1;
                        objUserInspiratorBAL.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                        objUserInspiratorBAL.ProcedureType = "I";
                        retval = UserInspiratorsDAL.InsertInspirator(objUserInspiratorBAL);
                        if (retval != 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Inspirator Added Successfully into My Inspirators');", true);
                            txtdesc.Text = "";
                            Session["MyInspirator"] = true;
                            Response.Redirect("~/User/Inspirators.aspx", false);

                        }

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Image Size should less than 100Kb');", true);
                        return;

                    }
                }




            }
            catch (Exception ex)
            {
                ex.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Inspirator no added ');", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            panel32.Visible = true;
            this.ModalPopupExtender1.Show();
           
        }

      
    }
}