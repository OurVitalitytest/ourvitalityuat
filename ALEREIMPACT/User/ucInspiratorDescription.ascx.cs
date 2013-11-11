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
    public partial class ucInspiratorDescription : System.Web.UI.UserControl
    {
        UserInspiratorsBAL objUserInspiratorBAL = new UserInspiratorsBAL();
        public static Int32 userid = 0;
        public static Int32 inspiratorid = 0;
        public static Int32 pageid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //if (string.IsNullOrEmpty(MySession.Current.LoginId))
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);

            //    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
            //}
            //else
            //{
          //      if (!IsPostBack)
          //      {
          //          userid = Convert.ToInt32(MySession.Current.LoginId);
          //          inspiratorid = Convert.ToInt32(Request.QueryString["val"]);
          //          pageid = Convert.ToInt32(Request.QueryString["pageid"]);
                  
          //          if (pageid == 1)
          //          {
          //              panellink.Visible = true;
          //              lnkInspirator.Text = "My Inspirator";
          //              PanelHS.Visible = true;
          //              DropDownList1.SelectedValue = "1";
          //              divdrp.Style.Add("display", "");
          //          }
          //          else if (pageid == 2)
          //          {
          //              panellink.Visible = true;
          //              lnkInspirator.Text = "Member's Inspirator";
          //              PanelHS.Visible = true;
          //              DropDownList1.SelectedValue = "2";
          //              divdrp.Style.Add("display", "");
          //          }
          //          else if (pageid == 3)
          //          {
          //              panellink.Visible = true;
          //              lnkInspirator.Text = "My Library";
          //              PanelHS.Visible = false ;
          //              DropDownList1.SelectedValue = "3";
          //              divdrp.Style.Add("display", "");
          //          }
          //          else if (pageid == 4)
          //          {
          //              lnkInspirator.Text = "";
          //              if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
          //              {
          //                  lnkInspLike.Enabled = true;
          //                  lnkcollect.Enabled=true;
          //                  ImageButton1.Enabled = true;
          //              }
          //              else
          //              {
          //                  lnkInspLike.Enabled = false;
          //                  lnkcollect.Enabled = false;
          //                  ImageButton1.Enabled = false;
          //                  ImageButton1.Style.Add(" pointer-events", " none");
          //              }
          //              panellink.Visible = false;
          //              divdrp.Style.Add("display", "none");
          //          }
          //          bindDLmyInspirator();
                   
          //      }
          ////  }
         

        }

        //private void bindDLmyInspirator()
        //{
        //    DataTable dt = new DataTable();
        //    objUserInspiratorBAL.pk_Inspirator_id = inspiratorid;
        //    objUserInspiratorBAL.ProcedureType = "S";
        //    dt = UserInspiratorsDAL.GetViewInspirator(objUserInspiratorBAL);
        //    if (dt.Rows.Count > 0)
        //    {
        //        Image1.ImageUrl = "../User/InspiratorImages/" + dt.Rows[0]["Inspirator_image"].ToString();
        //        lbName.Text ="Posted By:  "+ dt.Rows[0]["first_name"].ToString();
        //        lbDesc.Text = dt.Rows[0]["Inspirator_desc"].ToString();
        //        MySession.Current.LabelId = dt.Rows[0]["pk_Inspirator_id"].ToString();

        //        DataTable dt1 = new DataTable();
        //        objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
        //        objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
        //        objUserInspiratorBAL.ProcedureType = "S";
        //        dt1 = UserInspiratorsDAL.GetUserInspiratorLike(objUserInspiratorBAL);
        //        if (dt1.Rows.Count > 0)
        //        {
        //            lnkInspLike.Text = "Liked";
        //            lnkInspLike.Enabled = false;
        //        }
        //        else
        //        {

        //            lnkInspLike.Text = "Like";
        //            lnkInspLike.Enabled = true;

        //        }
        //        DataTable dtlike = new DataTable();
        //        objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
        //        objUserInspiratorBAL.ProcedureType = "L";
        //        dtlike = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
        //        if (dtlike.Rows.Count > 0)
        //        {
        //            lbLikeCount.Text = dtlike.Rows[0]["nooflike"].ToString();
        //        }
        //        else
        //        {
        //            lbLikeCount.Text = "0";
        //        }

        //        DataTable dtcomment = new DataTable();
        //        objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
        //        objUserInspiratorBAL.ProcedureType = "C";
        //        dtcomment = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
        //        if (dtcomment.Rows.Count > 0)
        //        {
        //            lbCommentCount.Text = dtcomment.Rows[0]["noofcomments"].ToString();
        //        }
        //        else
        //        {
        //            lbCommentCount.Text = "0";
        //        }

        //        if (pageid == 3)
        //        {
        //            lnkcollect.Enabled = false;
        //            ImageButton1.Enabled = false;
        //            ImageButton1.Style.Add(" pointer-events", " none");
        //        }
        //        else if (pageid == 4)
        //        {
        //            if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
        //            {
                        
        //                lnkcollect.Enabled = true;
        //                ImageButton1.Enabled = true;
                   
        //            }
        //            else
        //            {
        //                lnkInspLike.Enabled = false;
        //                lnkcollect.Enabled = false;
        //                ImageButton1.Enabled = false;
        //                ImageButton1.Style.Add(" pointer-events", " none");
        //            }
        //        }
        //        else
        //        {
        //            lnkcollect.Enabled = true;
        //            ImageButton1.Enabled = true;
        //        }

        //        DataTable dtCommentDesc = new DataTable();
        //        objUserInspiratorBAL.pk_Inspirator_id = inspiratorid;
        //        objUserInspiratorBAL.ProcedureType = "C";
        //        dtCommentDesc = UserInspiratorsDAL.GetViewInspirator(objUserInspiratorBAL);
        //        if (dtCommentDesc.Rows.Count > 0)
        //        {
        //            Repeater1.DataSource = dtCommentDesc;
        //            Repeater1.DataBind();
        //        }
               
            
        //    }
        //       Session["InspDescription"] = null;
            
        //}

        protected void lnkInspLike_Click(object sender, EventArgs e)
        {
        //    int retval = 0;
        //    objUserInspiratorBAL.pk_InspiratorLiked_id = 0;
        //    objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
        //    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
        //    objUserInspiratorBAL.InspiratorLiked_on = DateTime.Now.ToString();
        //    objUserInspiratorBAL.ProcedureType = "I";
        //    retval = UserInspiratorsDAL.InsertInspiratorLike(objUserInspiratorBAL);
        //    bindDLmyInspirator();
            
        }

        protected void lnkComments_Click(object sender, EventArgs e)
        {
          
        }

        protected void lnkcollect_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        int retval = 0;
        //        objUserInspiratorBAL.pk_inspiratorLib_id = 0;
        //        objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
        //        objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
        //        objUserInspiratorBAL.inspiratorLib_createdon = DateTime.Now.ToString();
        //        objUserInspiratorBAL.ProcedureType = "I";
        //        retval = UserInspiratorsDAL.InsertInspiratorLibrary(objUserInspiratorBAL);
        //        bindDLmyInspirator();
           
        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Inspirator successfully added to Library');", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        
           
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
        //    int retval = 0;
        //    objUserInspiratorBAL.pk_InspiratorInappro_id = 0;
        //    objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
        //    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
        //    objUserInspiratorBAL.InspiratorInappro_on = DateTime.Now.ToString();
        //    objUserInspiratorBAL.ProcedureType = "I";
        //    retval = UserInspiratorsDAL.InsertInspiratorInappropriate(objUserInspiratorBAL);
        //    if (pageid == 1)
        //    {
        //        Session["MyInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);
        //    }
        //    else if (pageid == 2)
        //    {
        //        Session["FriendInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);
        //    }
        //    else if (pageid == 3)
        //    {
        //        Session["LibraryInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);
        //    }
        //  //  bindDLmyInspirator();
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
        //    int retval = 0;
        //    objUserInspiratorBAL.pk_InspiratorComments_id = 0;
        //    objUserInspiratorBAL.InspiratorComment_text = txtComments.Text;
        //    objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
        //    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
        //    objUserInspiratorBAL.InspiratorComment_on = DateTime.Now.ToString();
        //    objUserInspiratorBAL.ProcedureType = "I";
        //    retval = UserInspiratorsDAL.InsertInspiratorComment(objUserInspiratorBAL);
        //    bindDLmyInspirator();
        //    txtComments.Text = "";

        }

        protected void lnkInspirator_Click(object sender, EventArgs e)
        {
        //    if (pageid == 1)
        //    {
        //        Session["MyInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);
        //    }
        //    else if (pageid == 2)
        //    {
        //        Session["FriendInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);
        //    }
        //    else if (pageid == 3)
        //    {
        //        Session["LibraryInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);
        //    }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        //    if (DropDownList1.SelectedValue == "1")
        //    {
        //        Session["MyInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);

        //    }
        //    else if (DropDownList1.SelectedValue == "2")
        //    {
        //        Session["FriendInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);

        //    }
        //    else if (DropDownList1.SelectedValue == "3")
        //    {
        //        Session["LibraryInspirator"] = true;
        //        Response.Redirect("~/User/Inspirators.aspx", false);

        //    }
        //    else
        //    {
        //        Response.Redirect("~/User/Inspirators.aspx", false);
        //    }

        }


   
    }
}