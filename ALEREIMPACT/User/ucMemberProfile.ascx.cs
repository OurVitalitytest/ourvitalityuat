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
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;

namespace ALEREIMPACT.User
{
    public partial class ucMemberProfile : System.Web.UI.UserControl
    {
        UserCirclesBAO objUserCircleBAO = new UserCirclesBAO();
        public static Int32 id = 0;
        public static Int32 count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(MySession.Current.LoginId))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
                //Response.Redirect("~/Login.aspx", false);

            }
            if (Convert.ToString(Session["Member_Profile"]) == "True")
            {
                if (Convert.ToString(Request.QueryString["val"]) != "0")
                {
                    if (!IsPostBack)
                    {
                        id = Convert.ToInt32(Request.QueryString["val"]);
                        BindData();
                        bindCircles();
                        BindRestrictedCircle();
                    }
                }
                Session["Member_Profile"] = null;
               
            }

           

        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            objUserCircleBAO.ID = id;
            objUserCircleBAO.proceduretype = "NE";
            dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
            if (dt.Rows.Count > 0)
            {
             
                Image1.ImageUrl = "profile_image/" + dt.Rows[0]["user_image"].ToString();
                lbEmail.Text = dt.Rows[0]["login_email"].ToString();
                lbName.Text = dt.Rows[0]["name"].ToString();
            }
          
          
        }

        protected void lnkMessage_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            Session["show_admin_posed_messages"] = true;
            Response.Redirect("AdminMessagesFront.aspx", false);
        }

        protected void lnkMembers_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            Session["Member_Profile"] = null;
            Response.Redirect("MemberList.aspx", false);
        }


        private void bindCircles()
        {
            DataTable dt = new DataTable();
            objUserCircleBAO.ID = id;
            objUserCircleBAO.proceduretype = "PC1";
            dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
            if (dt.Rows.Count > 0)
            {
                dvPublic.Style.Add("display", "");
                DataList1.DataSource = dt;
                DataList1.DataBind();
                if (dt.Rows.Count <= 4)
                {
                    dvPublic.Style.Add("height", "190px");
                }
            }
            else
            {
                lbPublicUnres.Visible = true;
                dvPublic.Style.Add("height", "30px");
                dvPublic.Style.Add("display", "none");
            }
        }

        private void BindRestrictedCircle()
        {

            DataTable dt = new DataTable();
            objUserCircleBAO.ID = id;
            objUserCircleBAO.proceduretype = "PR1";
            dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
            if (dt.Rows.Count > 0)
            {
                DataList2.DataSource = dt;
                DataList2.DataBind();
                dicPublicRestricted.Style.Add("display", "");
                if (dt.Rows.Count <= 4)
                {
                    dicPublicRestricted.Style.Add("height", "190px");
                }
            }
            else
            {
                lbREs.Visible = true;
                dicPublicRestricted.Style.Add("display", "none");
                dicPublicRestricted.Style.Add("height", "30px");
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnColor = (HiddenField)e.Item.FindControl("hndcolor");
                HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                HtmlGenericControl divCircle = (HtmlGenericControl)e.Item.FindControl("divCircle");
                HtmlGenericControl divHoverColor = (HtmlGenericControl)e.Item.FindControl("divHoverColor");
                divCircle.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                divHoverColor.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
            }
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    HtmlGenericControl dvimagecircle = (HtmlGenericControl)e.Item.FindControl("dvimagecircle");
               
            //    HiddenField hndcolor = (HiddenField)e.Item.FindControl("hndcolor");
            //    HiddenField hiddenCircle = (HiddenField)e.Item.FindControl("hiddenCircleID");
            //    HiddenField hiddenUser = (HiddenField)e.Item.FindControl("HiddenUserID");
            //    dvimagecircle.Style.Add("border-color", "#" + hndcolor.Value);
              
             
            //}
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnColor = (HiddenField)e.Item.FindControl("hndcolorRestricted");
                HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                HtmlGenericControl divCircle = (HtmlGenericControl)e.Item.FindControl("divCircle");
                HtmlGenericControl divHoverColor = (HtmlGenericControl)e.Item.FindControl("divHoverColor");
                divCircle.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                divHoverColor.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            if (e.CommandName == "lnkView")
            {
                int count = 2;
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                MySession.Current.PublicCircleUserId = arg[0];
                MySession.Current.PublicCircleId = arg[1];

                var myHidden = (HiddenField)e.Item.FindControl("hdnId");
                myHidden.Value = e.Item.ItemIndex.ToString();
                if (Session["bubbleId"] == null && myHidden.Value == "0")
                {
                    Session["bubbleId"] = count;

                }
                else
                {
                    Session["bubbleId"] = Convert.ToInt32(myHidden.Value) + count;
                }

                string cid = MySession.Current.PublicCircleUserId + "-" + MySession.Current.PublicCircleId;
                (Session["selectedcircleid"]) = cid;
                Session["Search"] = true;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);
            }
        }

       protected void lnkBtnView_Click(object sender,  EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int count = 2;
                DataListItem dlist = ((LinkButton)sender).NamingContainer as DataListItem;

                HiddenField memberid = (HiddenField)dlist.FindControl("HiddenUserID");
                HiddenField membercircleid = (HiddenField)dlist.FindControl("hiddenCircleID");
                MySession.Current.PublicCircleUserId = memberid.Value;
                MySession.Current.PublicCircleId = membercircleid.Value;
                var myHidden = (HiddenField)dlist.FindControl("hdnId");
                myHidden.Value = dlist.ItemIndex.ToString();
                if (Session["bubbleId"] == null && myHidden.Value == "0")
                {
                    Session["bubbleId"] = count;

                }
                else
                {
                    Session["bubbleId"] = Convert.ToInt32(myHidden.Value) + count;
                }

                string cid = memberid.Value + "-" + membercircleid.Value;
                (Session["selectedcircleid"]) = cid;
                Session["Search"] = true;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);
            }
            catch (Exception ex)
            { }
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
       {
           ClsGeneric.ReplaceCookie();
            if (e.CommandName == "lnkView")
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = id;
                objUserCircleBAO.proceduretype = "PC";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt.Rows.Count > 0)
                {
                    count = dt.Rows.Count + 1;

                }
                else
                {
                    count = 2;
                }
                HiddenField myHiddenRestricted = (HiddenField)e.Item.FindControl("hdnIdRestricted");
                HiddenField HdnPermissionID = (HiddenField)e.Item.FindControl("hdnPermissionID");
                MySession.Current.PublicPermissions = Convert.ToString(HdnPermissionID.Value);

                HiddenField memberidRestricted = (HiddenField)e.Item.FindControl("HiddenUserIDRestricted");
                HiddenField membercircleidRestricted = (HiddenField)e.Item.FindControl("hiddenCircleIDRestricted");
                MySession.Current.PublicCircleUserId = memberidRestricted.Value;
                MySession.Current.PublicCircleId = membercircleidRestricted.Value;


                myHiddenRestricted.Value = e.Item.ItemIndex.ToString();
                if (myHiddenRestricted.Value == "0")
                {
                    Session["bubbleId"] = count;

                }
                else
                {
                    Session["bubbleId"] = Convert.ToInt32(myHiddenRestricted.Value) + count;
                }

                string cid = memberidRestricted.Value + "-" + membercircleidRestricted.Value;
                (Session["selectedcircleid"]) = cid;
                Session["Search"] = true;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);
            }
        }

        protected void lnkBtnView1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();

            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = id;
                objUserCircleBAO.proceduretype = "PC";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt.Rows.Count > 0)
                {
                    count = dt.Rows.Count + 1;

                }
                else
                {
                    count = 2;
                }

                DataListItem dlistRestricted = ((LinkButton)sender).NamingContainer as DataListItem;
                HiddenField myHiddenRestricted = (HiddenField)dlistRestricted.FindControl("hdnIdRestricted");
                HiddenField HdnPermissionID = (HiddenField)dlistRestricted.FindControl("hdnPermissionID");
                MySession.Current.PublicPermissions = Convert.ToString(HdnPermissionID.Value);

                HiddenField memberidRestricted = (HiddenField)dlistRestricted.FindControl("HiddenUserIDRestricted");
                HiddenField membercircleidRestricted = (HiddenField)dlistRestricted.FindControl("hiddenCircleIDRestricted");
                MySession.Current.PublicCircleUserId = memberidRestricted.Value;
                MySession.Current.PublicCircleId = membercircleidRestricted.Value;



                // Session["PermissionID"] = HdnPermissionID;
                //  MySession.Current.PermissionId

                //var prmssionID = (MySession)Session.Add[]
                // MySession.Curren

                // Session["SessionVariableNameHere"] = someNewValue; //Setter

                myHiddenRestricted.Value = dlistRestricted.ItemIndex.ToString();
                if (myHiddenRestricted.Value == "0")
                {
                    Session["bubbleId"] = count;

                }
                else
                {
                    Session["bubbleId"] = Convert.ToInt32(myHiddenRestricted.Value) + count;
                }

                string cid = memberidRestricted.Value + "-" + membercircleidRestricted.Value;
                (Session["selectedcircleid"]) = cid;
                Session["Search"] = true;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);
            }
            catch (Exception ex)
            { }
        }

    }
}