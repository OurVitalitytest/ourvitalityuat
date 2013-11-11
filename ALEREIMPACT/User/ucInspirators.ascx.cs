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
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;

namespace ALEREIMPACT.User
{
    public partial class ucInspirators : System.Web.UI.UserControl
    {
        UserInspiratorsBAL objUserInspiratorBAL = new UserInspiratorsBAL();
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        public static Int32 userid = 0;
        public static Int32 circleid = 0;
        PagedDataSource adsource;
        public static int count = 0;
        public static int id = 0;
        public static Int32 inspiratorid = 0;
        public static string filename = "";
        int pos;
        ClsGeneric objClsGeneric = new ClsGeneric();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                //if (string.IsNullOrEmpty(MySession.Current.LoginId))
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);

                // //   Page.ClientScript.RegisterClientScriptBlock(typeof(string), "Redirect", "window.parent.location='Default.aspx';", true);
                //  //  Response.Redirect("~/Login.aspx", false);
                //    // ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript>parent.location.href = parent.location.href;</script>", false);

                //    //Page.ClientScript.RegisterStartupScript(GetType(), "Load", "<script>parent.location='http://google.com';</script>");

                //   // string url = "~/Login.aspx";
                //   // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='" + url + "';", true);
                //    //Page.ClientScript.RegisterClientScriptBlock("redirect", "<Script language = 'Javascript'> window.parent.location='~/Login.aspx' ; </Script>");
                // //   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RedirectScript", "window.parent.location.href = 'Default.aspx'", true);

                //}
                //else
                //{
                if (!IsPostBack)
                {
                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {
                            if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) == Convert.ToInt32(MySession.Current.LoginId))
                            {
                                userid = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                                circleid = Convert.ToInt32(MySession.Current.CircleId);
                                PanelUser.Visible = true;
                                PanelMy.Visible = true;
                                DivDrp.Style.Add("display", "");
                                MySession.Current.PageIndex = 1;
                                MySession.Current.PageSize = 8;
                                bindDLInspirator();
                            }


                            else if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) != Convert.ToInt32(MySession.Current.LoginId))
                            {
                                userid = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                                circleid = Convert.ToInt32(MySession.Current.CircleId);
                                MySession.Current.PageIndex = 1;
                                MySession.Current.PageSize = 8;
                                PanelUser.Visible = true;
                                PanelMy.Visible = true;
                                DivDrp.Style.Add("display", "");
                                bindDLInspirator();
                            }
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            objusercircles.UserId = MySession.Current.LoginId;
                            if (count == 0)
                            {
                                objusercircles.fk_circle_id = MySession.Current.PublicCircleUserId;
                                count = 1;
                            }
                            else
                            {
                                objusercircles.fk_circle_id = MySession.Current.CircleId;
                            }
                            objusercircles.proceduretype = "V";
                            dt = UserCirclesDAO.GetUserCircles(objusercircles);
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                                {
                                    userid = Convert.ToInt32(MySession.Current.PublicCircleUserId);
                                    circleid = Convert.ToInt32(MySession.Current.CircleId);
                                    MySession.Current.PageIndex = 1;
                                    MySession.Current.PageSize = 8;
                                    PanelUser.Visible = true;
                                    PanelMy.Visible = true;
                                    DivDrp.Style.Add("display", "");
                                    bindDLInspirator();

                                }
                                else
                                {
                                    userid = Convert.ToInt32(MySession.Current.PublicCircleUserId);
                                    circleid = Convert.ToInt32(MySession.Current.CircleId);
                                    MySession.Current.PageIndex = 1;
                                    MySession.Current.PageSize = 8;
                                    PanelUser.Visible = true;
                                    PanelMy.Visible = false;
                                    DivDrp.Style.Add("display", "none");
                                    bindDLInspirator();
                                }
                            }

                        }
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        objusercircles.UserId = MySession.Current.LoginId;
                        if (count == 0)
                        {
                            objusercircles.fk_circle_id = MySession.Current.MemberCircleId;
                            count = 1;
                        }
                        else
                        {
                            objusercircles.fk_circle_id = MySession.Current.CircleId;
                        }
                        objusercircles.proceduretype = "V";
                        dt = UserCirclesDAO.GetUserCircles(objusercircles);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                            {
                                if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) != Convert.ToInt32(MySession.Current.LoginId))
                                {

                                    userid = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                                    circleid = Convert.ToInt32(MySession.Current.CircleId);
                                    PanelUser.Visible = true;
                                    PanelMy.Visible = true;
                                    DivDrp.Style.Add("display", "");
                                    MySession.Current.PageIndex = 1;
                                    MySession.Current.PageSize = 8;
                                    bindDLInspirator();
                                }
                            }

                            else
                            {
                                userid = Convert.ToInt32(MySession.Current.MemberUserId);
                                circleid = Convert.ToInt32(MySession.Current.MemberCircleId);
                                MySession.Current.PageIndex = 1;
                                MySession.Current.PageSize = 8;
                                PanelUser.Visible = true;
                                PanelMy.Visible = false;
                                DivDrp.Style.Add("display", "none");
                                bindDLInspirator();
                            }
                        }
                        else
                        {
                            userid = Convert.ToInt32(MySession.Current.MemberUserId);
                            circleid = Convert.ToInt32(MySession.Current.MemberCircleId);
                            MySession.Current.PageIndex = 1;
                            MySession.Current.PageSize = 8;
                            PanelUser.Visible = true;
                            PanelMy.Visible = false;
                            DivDrp.Style.Add("display", "none");
                            bindDLInspirator();
                        }

                    }

                    //To view My Inspirator
                    txtdesc.Text = "";
                    filename = "";
                    Session["_Inspirator"] = null;
                    MySession.Current.Image = null;

                }
                // }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void bindDLInspirator()  //first time
        {
            try
            {
                DataTable dt = new DataTable();

                objUserInspiratorBAL.fk_circle_id = Convert.ToInt32(circleid);
                objUserInspiratorBAL.page_index = Convert.ToInt32(MySession.Current.PageIndex);
                objUserInspiratorBAL.page_size = Convert.ToInt32(MySession.Current.PageSize);
                if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                {
                    if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) == Convert.ToInt32(MySession.Current.LoginId))
                    {
                        objUserInspiratorBAL.userid = Convert.ToInt32(userid);
                        objUserInspiratorBAL.fk_user_circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                        objUserInspiratorBAL.ProcedureType = "V";
                        dt = UserInspiratorsDAL.GetFriendInspirator(objUserInspiratorBAL);
                    }
                    else if (Convert.ToInt32(MySession.Current.SelectedCircleUserId) != Convert.ToInt32(MySession.Current.LoginId))
                    {
                        objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(userid);
                        objUserInspiratorBAL.Friend_id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserInspiratorBAL.fk_user_circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                        objUserInspiratorBAL.ProcedureType = "U";
                        dt = UserInspiratorsDAL.GetUserInspirator(objUserInspiratorBAL);
                    }

                }
                else
                {

                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(userid);
                    objUserInspiratorBAL.Friend_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.fk_user_circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                    objUserInspiratorBAL.ProcedureType = "U";
                    dt = UserInspiratorsDAL.GetUserInspirator(objUserInspiratorBAL);

                }
                adsource = new PagedDataSource();
                adsource.DataSource = dt.DefaultView;
                adsource.PageSize = MySession.Current.PageSize;
                adsource.AllowPaging = true;
                adsource.CurrentPageIndex = pos;
                lnkViewMore.Enabled = !adsource.IsLastPage;
                DataList1.DataSource = adsource;
                DataList1.DataBind();

                //DataList1.DataSource = dt;
                //DataList1.DataBind();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (MySession.Current.PageSize == dt.Rows.Count || MySession.Current.PageSize < 8 || MySession.Current.PageSize > dt.Rows.Count)
                        {
                            lnkViewMore.Visible = false;
                        }
                        else
                        {

                            lnkViewMore.Visible = true;
                            ViewState["page_size"] = MySession.Current.PageSize;
                        }
                    }
                    else
                    {
                        //tdUser.Style.Add("display", "");
                        lbNorecord.Visible = true;
                        lbNorecord.Text = "No Inspirators Found<br/> Share Inspiring images and image description.";
                        lnkViewMore.Visible = false;
                    }

                }
                else
                {
                    //tdUser.Style.Add("display", "");
                    lbNorecord.Visible = true;
                    lbNorecord.Text = "No Inspirators Found<br/> Share Inspiring images and image description.";
                    lnkViewMore.Visible = false;
                }
                txtdesc.Text = "";
                filename = "";
                MySession.Current.Image = null;
                // btnadd.Enabled = false;
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
                AdminBAO objAdminBAO = new AdminBAO();
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
                    DataTable dtUser = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(inspiratorid);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        objUserInspiratorBAL.IN_ID = 0;
                        objUserInspiratorBAL.fk_Inspirator_id = retval;
                        objUserInspiratorBAL.fk_user_registration_id = MySession.Current.LoginId;
                        objUserInspiratorBAL.IN_DATE = DateTime.Now.ToString();
                        objUserInspiratorBAL.IN_NOTIFICATION_STATUS = "False";
                        objUserInspiratorBAL.IN_EMAIL_STATUS = "True";
                        objUserInspiratorBAL.LIKE_STATUS = "";
                        objUserInspiratorBAL.ProcedureType = "I";
                        int retvalInsp = UserInspiratorsDAL.InsertInspiratorNotifications(objUserInspiratorBAL);
                        if (retvalInsp != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = "";
                            DataTable dtUser1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                            objAdminBAO.ProcedureType = "CU";
                            dtUser1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtUser.Rows.Count > 0)
                            {
                                Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            }
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"].ToString());
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " liked Inspirator  in " + Circlename;
                            string body = "Hi " + name + ",<br /><br />" + name1 + " liked  inspirator that in  Circle : " + Circlename;
                            objClsGeneric.SendMail(email, body, Subject);
                        }
                    }
                    
                    bindDLInspirator();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
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
                    bindDLInspirator();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);

                }
                else if (e.CommandName == "Add")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
                    inspiratorid = Convert.ToInt32(e.CommandArgument);
                    int retval = 0;
                    objUserInspiratorBAL.pk_inspiratorLib_id = 0;
                    objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.inspiratorLib_createdon = DateTime.Now.ToString();
                    objUserInspiratorBAL.ProcedureType = "I";
                    retval = UserInspiratorsDAL.InsertInspiratorLibrary(objUserInspiratorBAL);
                    if (retval != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Inspirator successfully added to Library');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('This Inspirator is already exists in your Library');", true);
                    }
                    bindDLInspirator();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
                }
                else if (e.CommandName == "PopUp")
                {
                    inspiratorid = Convert.ToInt32(e.CommandArgument);
                    this.ModalPopupExtender1.Show();
                    panel4.Visible = true;
                    bindDLmyInspirator();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindDLmyInspirator()  // Pop up
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
                    if (dt.Rows[0]["first_name"].ToString() == "" || dt.Rows[0]["first_name"].ToString() == null)
                    {
                        lbName.Text = "Admin";
                    }
                    else
                    {
                        lbName.Text = dt.Rows[0]["first_name"].ToString();
                    }
                    lbDesc.Text = dt.Rows[0]["Inspirator_desc"].ToString();
                    MySession.Current.LabelId = dt.Rows[0]["pk_Inspirator_id"].ToString();

                    DataTable dt1 = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
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
                    objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
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
                    objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
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

                if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                {
                    if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                    {


                        ImageButton4.Enabled = true;
                        ImageButton1.Enabled = true;
                        lnkInspLike.Enabled = true;
                        txtComments.Enabled = true;
                        btnComment.Enabled = true;

                    }
                    else
                    {
                        ImageButton4.Enabled = false;
                        ImageButton1.Enabled = false;
                        lnkInspLike.Enabled = false;
                        txtComments.Enabled = false;
                        btnComment.Enabled = false;
                        lnkInspLike.Style.Add("cursor", "not-allowed");
                        btnComment.Style.Add("cursor", "not-allowed");
                        ImageButton4.Style.Add("cursor", "not-allowed");
                        ImageButton1.Style.Add("cursor", "not-allowed");
                    }
                }
                else
                {
                    ImageButton4.Enabled = false;
                    ImageButton1.Enabled = false;
                    lnkInspLike.Enabled = false;
                    txtComments.Enabled = false;
                    btnComment.Enabled = false;
                    ImageButton4.Style.Add("cursor", "not-allowed");
                    ImageButton1.Style.Add("cursor", "not-allowed");
                    btnComment.Style.Add("cursor", "not-allowed");
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
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
                    Label lbDesc = (Label)e.Item.FindControl("lbDesc");
                    LinkButton lnkComment = (LinkButton)e.Item.FindControl("lnkComment");
                    Label lbCommentCount = (Label)e.Item.FindControl("lbCommentCount");
                    LinkButton lnkLike = (LinkButton)e.Item.FindControl("lnkLike");
                    ImageButton ImageButton1 = (ImageButton)e.Item.FindControl("ImageButton1");
                    ImageButton ImageButton2 = (ImageButton)e.Item.FindControl("ImageButton2");
                    HtmlAnchor aimage = (HtmlAnchor)e.Item.FindControl("aimage");
                    ImageButton img = (ImageButton)e.Item.FindControl("ImageButton3");
                    Image img1 = (Image)e.Item.FindControl("Image2");
                    HtmlTableRow trDesc = (HtmlTableRow)e.Item.FindControl("trDesc");
                    HtmlGenericControl divInsp = (HtmlGenericControl)e.Item.FindControl("divInsp");

                    if (lbDesc.Text.Length < 150)
                    {
                        //  divInsp.Style.Add("height", "444px");


                    }
                    else if (lbDesc.Text.Length > 150)
                    {
                        // divInsp.Style.Add("height", "444px");

                    }
                    string val = hdnImage.Value;
                    img.ImageUrl = "../User/InspiratorImages/" + val;
                    // string pageid = "4";
                    // aimage.HRef = "~/User/Inspirators.aspx?val=" + hdnInspiratorid.Value + "&pageid=" + pageid;
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

                        if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                        {
                            if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                            {

                                lnkLike.Text = "Liked";
                                lnkLike.Enabled = false;

                            }
                            else
                            {
                                lnkLike.Text = "Liked";
                                lnkLike.Enabled = false;

                            }
                        }
                        else
                        {
                            lnkLike.Text = "Like";
                            lnkLike.Enabled = false;

                        }

                    }
                    else
                    {

                        if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                        {
                            if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                            {
                                lnkLike.Text = "Like";
                                lnkLike.Enabled = true;
                            }
                            else
                            {
                                lnkLike.Text = "Like";
                                lnkLike.Enabled = false;
                                ImageButton2.Enabled = false;
                                ImageButton2.Style.Add("cursor", "not-allowed");
                            }
                        }
                        else
                        {

                            lnkLike.Text = "Like";
                            lnkLike.Enabled = false;
                            ImageButton2.Enabled = false;
                            ImageButton2.Style.Add("cursor", "not-allowed");
                        }
                    }
                    DataTable dtInappro = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = hdnInspiratorid.Value;
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.ProcedureType = "I";
                    dtInappro = UserInspiratorsDAL.GetUserInspiratorLike(objUserInspiratorBAL);
                    if (dtInappro.Rows.Count > 0)
                    {

                        if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                        {
                            if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                            {

                                ImageButton1.Enabled = false;
                                ImageButton1.Style.Add(" pointer-events", " none");
                            }
                            else
                            {
                                ImageButton2.Enabled = false;
                                ImageButton2.Style.Add("cursor", "not-allowed");
                                ImageButton1.Enabled = false;
                                ImageButton1.Style.Add("cursor", "not-allowed");
                            }
                        }

                        else
                        {
                            ImageButton1.Enabled = false;
                            ImageButton1.Style.Add("cursor", "not-allowed");
                        }

                    }


                    else
                    {

                        if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                        {
                            if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                            {
                                ImageButton1.Enabled = true;
                            }
                            else
                            {
                                ImageButton1.Enabled = false;
                                ImageButton1.Style.Add("cursor", "not-allowed");
                            }
                        }
                        else
                        {
                            ImageButton1.Enabled = false;
                            ImageButton1.Style.Add(" pointer-events", " none");
                        }

                    }


                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {

                            ImageButton2.Enabled = true;

                        }
                        else
                        {
                            ImageButton2.Enabled = false;
                            ImageButton2.Style.Add("cursor", "not-allowed");
                        }
                    }
                    else
                    {
                        ImageButton2.Enabled = false;
                        ImageButton2.Style.Add("cursor", "not-allowed");

                    }

                    if (hdnuserid.Value == MySession.Current.LoginId)
                    {
                        img1.ImageUrl = "../images/green-user-icon.png";
                        img1.ToolTip = "My Inspirators";
                    }
                    else
                    {
                        img1.ImageUrl = "../images/Friends-icon.png";
                        img1.ToolTip = "Member's Inspirators";
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);

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
                int pagesize = Convert.ToInt32(ViewState["page_size"]);
                MySession.Current.PageSize = pagesize + 8;
                bindDLInspirator();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }


        protected void btnadd_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            panel1.Visible = true;
            AdminBAO objAdminBAO = new AdminBAO();
            try
            {
                if (txtdesc.Text != "")
                {
                    if (fuInspiratorImage.HasFile)
                    {
                        if (objClsGeneric.checkRealFile(((FileUpload)fuInspiratorImage)) == true)
                        {
                            Int32 filesize = fuInspiratorImage.PostedFile.ContentLength;
                            if (filesize < 1048576)
                            {
                                string PhotoFileName = fuInspiratorImage.FileName;
                                if (PhotoFileName.Contains("#"))
                                {
                                    PhotoFileName = PhotoFileName.Replace("#", "-");
                                }
                                string fileext = System.IO.Path.GetExtension(PhotoFileName.ToString());
                                Session["_Inspirator"] = PhotoFileName;
                                MySession.Current.Image = PhotoFileName;
                                filename = userid + "_" + PhotoFileName;
                                fuInspiratorImage.PostedFile.SaveAs(MapPath("~") + "/User/InspiratorImages/" + filename);

                                int retval = 0;
                                objUserInspiratorBAL.pk_Inspirator_id = 0;
                                objUserInspiratorBAL.Inspirator_image = filename;
                                objUserInspiratorBAL.Inspirator_desc = txtdesc.Text;
                                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                                objUserInspiratorBAL.Inspirator_createdon = DateTime.Now.ToString();
                                objUserInspiratorBAL.Fk_Inspirator_status_id = 1;
                                objUserInspiratorBAL.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                                objUserInspiratorBAL.fk_user_circle_id = Convert.ToInt32(MySession.Current.UserCircleID);
                                objUserInspiratorBAL.ProcedureType = "I";
                                retval = UserInspiratorsDAL.InsertInspirator(objUserInspiratorBAL);
                                if (MySession.Current.LoginId == MySession.Current.SelectedCircleUserId)
                                {
                                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                                    objusercircles.fk_circle_id = MySession.Current.CircleId;
                                    objusercircles.proceduretype = "S";
                                    DataTable dtFriends = new DataTable();
                                    dtFriends = UserCirclesDAO.GetFriendList(objusercircles);
                                    if (dtFriends.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtFriends.Rows.Count; i++)
                                        {
                                            if (dtFriends.Rows[i]["userid"].ToString() != Convert.ToString(MySession.Current.LoginId))
                                            {
                                                int retvalInsp = 0;
                                                objUserInspiratorBAL.IN_ID = 0;
                                                objUserInspiratorBAL.fk_Inspirator_id = retval;
                                                objUserInspiratorBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                                objUserInspiratorBAL.IN_DATE = DateTime.Now.ToString();
                                                objUserInspiratorBAL.IN_NOTIFICATION_STATUS = "False";
                                                objUserInspiratorBAL.IN_EMAIL_STATUS = "True";
                                                objUserInspiratorBAL.LIKE_STATUS = "";
                                                objUserInspiratorBAL.ProcedureType = "I";
                                                retvalInsp = UserInspiratorsDAL.InsertInspiratorNotifications(objUserInspiratorBAL);
                                                if (retvalInsp != 0)
                                                {
                                                    string name = "";
                                                    string email = "";
                                                    string name1 = "";
                                                    string Circlename = "";
                                                    DataTable dtUser = new DataTable();
                                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                                    objAdminBAO.ProcedureType = "CU";
                                                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                                    if (dtUser.Rows.Count > 0)
                                                    {
                                                        Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                                    }
                                                    DataTable dtName = new DataTable();
                                                    objAdminBAO.ID = Convert.ToInt32(dtFriends.Rows[i]["userid"].ToString());
                                                    objAdminBAO.ProcedureType = "NE";
                                                    dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                                    if (dtName.Rows.Count > 0)
                                                    {
                                                        name = dtName.Rows[0]["name"].ToString();
                                                        email = dtName.Rows[0]["login_email"].ToString();
                                                    }
                                                    DataTable dtName1 = new DataTable();
                                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                                    objAdminBAO.ProcedureType = "NE";
                                                    dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                                    if (dtName1.Rows.Count > 0)
                                                    {
                                                        name1 = dtName1.Rows[0]["name"].ToString();
                                                    }
                                                    string Subject = name1 + " added a Inspirator  in " + Circlename;
                                                    string body = "Hi " + name + ",<br /><br />" + name1 + " has added a new inspirator in  Circle :" + " '" + Circlename + "' " + "<br /><br />" + "With Support and Respect," + "<br />" + "The Vitality Team";
                                                    objClsGeneric.SendMail(email, body, Subject);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                                    objusercircles.fk_circle_id = MySession.Current.CircleId;
                                    objusercircles.proceduretype = "S";
                                    DataTable dtFriends = new DataTable();
                                    dtFriends = UserCirclesDAO.GetFriendList(objusercircles);
                                    if (dtFriends.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtFriends.Rows.Count; i++)
                                        {
                                            int retvalInsp = 0;
                                            objUserInspiratorBAL.IN_ID = 0;
                                            objUserInspiratorBAL.fk_Inspirator_id = retval;
                                            objUserInspiratorBAL.fk_user_registration_id = dtFriends.Rows[i]["userid"].ToString();
                                            objUserInspiratorBAL.IN_DATE = DateTime.Now.ToString();
                                            objUserInspiratorBAL.IN_NOTIFICATION_STATUS = "False";
                                            objUserInspiratorBAL.IN_EMAIL_STATUS = "True";
                                            objUserInspiratorBAL.LIKE_STATUS = "";
                                            objUserInspiratorBAL.ProcedureType = "I";
                                            retvalInsp = UserInspiratorsDAL.InsertInspiratorNotifications(objUserInspiratorBAL);
                                            if (retvalInsp != 0)
                                            {
                                                string name = "";
                                                string email = "";
                                                string name1 = "";
                                                string Circlename = "";
                                                DataTable dtUser = new DataTable();
                                                objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                                                objAdminBAO.ProcedureType = "CU";
                                                dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                                if (dtUser.Rows.Count > 0)
                                                {
                                                    Circlename = dtUser.Rows[0]["circle_name"].ToString();
                                                }
                                                DataTable dtName = new DataTable();
                                                objAdminBAO.ID = Convert.ToInt32(dtFriends.Rows[i]["userid"].ToString());
                                                objAdminBAO.ProcedureType = "NE";
                                                dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                                if (dtName.Rows.Count > 0)
                                                {
                                                    name = dtName.Rows[0]["name"].ToString();
                                                    email = dtName.Rows[0]["login_email"].ToString();
                                                }
                                                DataTable dtName1 = new DataTable();
                                                objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                                objAdminBAO.ProcedureType = "NE";
                                                dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                                if (dtName1.Rows.Count > 0)
                                                {
                                                    name1 = dtName1.Rows[0]["name"].ToString();
                                                }
                                                string Subject = name1 + "added a Inspirator  in " + Circlename;
                                                string body = "Hi " + name + ",<br /><br />" + name1 + " has added a new inspirator in  Circle : " + Circlename;
                                                objClsGeneric.SendMail(email, body, Subject);
                                            }
                                        }



                                    }
                                }

                                bindDLInspirator();


                                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Inspirator Added Successfully into  Inspirators');", true);
                                txtdesc.Text = "";
                                filename = "";
                                Session["_Inspirator"] = null;
                                MySession.Current.Image = null;
                                btnadd.Enabled = false;
                                fuInspiratorImage.Dispose();
                                Response.Redirect("Inspirators.aspx", false);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Image Size should less than 100Kb');", true);
                                return;

                            }

                        }
                        else
                        {
                            this.PnlInspirator_ModalPopupExtender.Show();
                            panel1.Visible = true;
                            btnadd.Enabled = true;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Upload image in (jpg or jpeg or png or gif ) format');", true); ;
                        }
                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);

            }
            catch (Exception ex)
            {
                ex.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Inspirator no added ');", true);
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
                    DropDownList1.SelectedValue = "1";

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
                AdminBAO objAdminBAO = new AdminBAO();
                int retval = 0;
                objUserInspiratorBAL.pk_InspiratorLiked_id = 0;
                objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.InspiratorLiked_on = DateTime.Now.ToString();
                objUserInspiratorBAL.ProcedureType = "I";
                retval = UserInspiratorsDAL.InsertInspiratorLike(objUserInspiratorBAL);
                 DataTable dtUser = new DataTable();
                 objAdminBAO.ID = Convert.ToInt32(inspiratorid);
                    objAdminBAO.ProcedureType = "CU1";
                    dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dtUser.Rows.Count > 0)
                    {
                        objUserInspiratorBAL.IN_ID = 0;
                        objUserInspiratorBAL.fk_Inspirator_id = retval;
                        objUserInspiratorBAL.fk_user_registration_id = MySession.Current.LoginId;
                        objUserInspiratorBAL.IN_DATE = DateTime.Now.ToString();
                        objUserInspiratorBAL.IN_NOTIFICATION_STATUS = "False";
                        objUserInspiratorBAL.IN_EMAIL_STATUS = "True";
                        objUserInspiratorBAL.LIKE_STATUS = "";
                        objUserInspiratorBAL.ProcedureType = "I";
                      int  retvalInsp = UserInspiratorsDAL.InsertInspiratorNotifications(objUserInspiratorBAL);
                        if (retvalInsp != 0)
                        {
                            string name = "";
                            string email = "";
                            string name1 = "";
                            string Circlename = "";
                            DataTable dtUser1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                            objAdminBAO.ProcedureType = "CU";
                            dtUser1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtUser.Rows.Count > 0)
                            {
                                Circlename = dtUser.Rows[0]["circle_name"].ToString();
                            }
                            DataTable dtName = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"].ToString());
                            objAdminBAO.ProcedureType = "NE";
                            dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName.Rows.Count > 0)
                            {
                                name = dtName.Rows[0]["name"].ToString();
                                email = dtName.Rows[0]["login_email"].ToString();
                            }
                            DataTable dtName1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ProcedureType = "NE";
                            dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                            if (dtName1.Rows.Count > 0)
                            {
                                name1 = dtName1.Rows[0]["name"].ToString();
                            }
                            string Subject = name1 + " liked Inspirator  in " + Circlename;
                            string body = "Hi " + name + ",<br /><br />" + name1 + " liked  inspirator that in  Circle : " + Circlename;
                            objClsGeneric.SendMail(email, body, Subject);
                        }
                    }
                    


                bindDLmyInspirator();
                bindDLInspirator();
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
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
                bindDLInspirator();
                if (retval != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Inspirator successfully added to Library');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Inspirator already exists in your Library');", true);

                }
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
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
                bindDLInspirator();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
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
                AdminBAO objAdminBAO = new AdminBAO();
                DataTable dtUser = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(inspiratorid);
                objAdminBAO.ProcedureType = "CU1";
                dtUser = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dtUser.Rows.Count > 0)
                {
                    objUserInspiratorBAL.IN_ID = 0;
                    objUserInspiratorBAL.fk_Inspirator_id = retval;
                    objUserInspiratorBAL.fk_user_registration_id = MySession.Current.LoginId;
                    objUserInspiratorBAL.IN_DATE = DateTime.Now.ToString();
                    objUserInspiratorBAL.IN_NOTIFICATION_STATUS = "False";
                    objUserInspiratorBAL.IN_EMAIL_STATUS = "Comment";
                    objUserInspiratorBAL.LIKE_STATUS = "";
                    objUserInspiratorBAL.ProcedureType = "I";
                    int retvalInsp = UserInspiratorsDAL.InsertInspiratorNotifications(objUserInspiratorBAL);
                    if (retvalInsp != 0)
                    {
                        string name = "";
                        string email = "";
                        string name1 = "";
                        string Circlename = "";
                        DataTable dtUser1 = new DataTable();
                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.UserCircleID);
                        objAdminBAO.ProcedureType = "CU";
                        dtUser1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                        if (dtUser.Rows.Count > 0)
                        {
                            Circlename = dtUser.Rows[0]["circle_name"].ToString();
                        }
                        DataTable dtName = new DataTable();
                        objAdminBAO.ID = Convert.ToInt32(dtUser.Rows[0]["fk_user_registration_Id"].ToString());
                        objAdminBAO.ProcedureType = "NE";
                        dtName = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                        if (dtName.Rows.Count > 0)
                        {
                            name = dtName.Rows[0]["name"].ToString();
                            email = dtName.Rows[0]["login_email"].ToString();
                        }
                        DataTable dtName1 = new DataTable();
                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                        objAdminBAO.ProcedureType = "NE";
                        dtName1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                        if (dtName1.Rows.Count > 0)
                        {
                            name1 = dtName1.Rows[0]["name"].ToString();
                        }
                        string Subject = name1 + " comments on your Inspirator  in " + Circlename;
                        string body = "Hi " + name + ",<br /><br />" + name1 + " comments on your  inspirator that in  Circle : " + Circlename;
                        objClsGeneric.SendMail(email, body, Subject);
                    }
                }
                    
                txtComments.Text = "";
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
                bindDLmyInspirator();
                bindDLInspirator();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();

        }

        protected void lnkAddInspirator_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                this.PnlInspirator_ModalPopupExtender.Show();
                panel1.Visible = true;
                btnadd.Enabled = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>bind();</script>", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}