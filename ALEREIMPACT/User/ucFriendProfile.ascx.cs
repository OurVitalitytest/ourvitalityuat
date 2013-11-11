using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ALEREIMPACT.User
{
    public partial class ucFriendProfile : System.Web.UI.UserControl
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();
        public static Int32 id = 0;
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        protected void Page_Load(object sender, EventArgs e)
        {        
            GetFriendProfile();

            BindRestrictedCircle();

            bindCircles();
            BtnHideShow();
        }
        private void BtnHideShow()
        {
            DataTable dt = new DataTable();
            objRegisterUserBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
            objRegisterUserBAO.procedureType = "GC";
            dt = RegisterUserDAO.GetInvitationDetail(objRegisterUserBAO);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["fk_circle_permission_id"].ToString() == "2")
                {
                    MySession.Current.PublicPermissions =" 2";
                    CircleInvitation();

                }
                else
                {
                    txtMessage.Visible = false;
                    btnsendfrdrequest.Visible = true;
                    btnSendMessage.Visible = false;
                }
            }
        }
        protected void GetFriendProfile()
        {

            try
            {
                DataTable dtcircles = new DataTable();
                objusercircles.UserId = Convert.ToInt32(MySession.Current.searchfriendId);
                objusercircles.proceduretype = "V";
                dtcircles = UserCirclesDAO.GetFriendProfile(objusercircles);

                if (dtcircles.Rows.Count > 0)
                {
                    imgFriendphoto.Src = "~/User/profile_image/" + dtcircles.Rows[0]["frdimage"];
                    lbName.Text = dtcircles.Rows[0]["FullName"].ToString();
                    lbAddress.Text = dtcircles.Rows[0]["ContactDetails"].ToString();
                    lbemail.Text = dtcircles.Rows[0]["email"].ToString();
                }

                int mutualfrd = 0;
                objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                objusercircles.friend_registration_id = Convert.ToInt32(MySession.Current.searchfriendId);
                mutualfrd = UserCirclesDAO.GetMutualFriends(objusercircles);

                if (MySession.Current.searchfriendId == MySession.Current.LoginId)
                {
                    btnsendfrdrequest.Visible = false;
                }
                else
                {
                    if (mutualfrd == 1) // already Member of this current circle
                    {
                        lbmemberinvitation.Visible = true;
                        lbmemberinvitation.Text = "This member is already in your " + MySession.Current.SelectedCircleName;
                        btnsendfrdrequest.Visible = false;
                    }
                    else if (mutualfrd == 2) // already Member but not this current circle
                    {
                        lbmemberinvitation.Visible = true;
                        lbmemberinvitation.Text = "This member is already in your other circle";
                        if (MySession.Current.PublicPermissions != "2")
                        {
                            btnsendfrdrequest.Visible = true;
                        }
                    }
                    else if (mutualfrd == 3) // Invitation already sent to this Member for this current circle but not approved yet
                    {
                        lbmemberinvitation.Visible = true;
                        lbmemberinvitation.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                        btnsendfrdrequest.Visible = false;
                    }
                    //if (mutualfrd == 4) // Invitation already sent to this Member for other circle but not approved yet
                    //{
                    //    lbmemberinvitation.Visible = true;
                    //    lbmemberinvitation.Text = "Invitation already sent to join other circle";
                    //    btnsendfrdrequest.Visible = true;                   
                    //}
                    if (mutualfrd == 5) // Not A member of any circle
                    {
                        if (MySession.Current.PublicPermissions != "2")
                        {
                            btnsendfrdrequest.Visible = true;
                        }
                       
                    }
                }

            }
            catch (Exception ex)
            { }

        }

        protected void btnsendfrdrequest_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.friend_registration_id = Convert.ToInt32(MySession.Current.searchfriendId);
                objusercircles.fk_circle_id = MySession.Current.CircleId;
                objusercircles.request_status = 1;
                objusercircles.updated_on = System.DateTime.Now;
                objusercircles.proceduretype = "I";
                Int32 frdreq = 0;
                frdreq = UserCirclesDAO.SendFriendRequest(objusercircles);

                if (frdreq > 0)
                {
                    lbmemberinvitation.Visible = true;
                    lbmemberinvitation.Text = "Invitation has been successfully sent to join your " + MySession.Current.SelectedCircleName;
                    btnsendfrdrequest.Visible = false;
                }

            }
            catch (Exception ex)
            {

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
        }

        private void bindCircles()
        {
            DataTable dt = new DataTable();
            if (MySession.Current.searchfriendId != null)
            {
                objusercircles.ID = Convert.ToInt32(MySession.Current.searchfriendId);
            }
            objusercircles.proceduretype = "PC1";
            dt = UserCirclesDAO.GetUserNameEmail(objusercircles);
            if (dt.Rows.Count > 0)
            {
                // dvPublic.Style.Add("display", "");
                DataList1.DataSource = dt;
                DataList1.DataBind();
                if (dt.Rows.Count <= 4)
                {
                    divUnres.Style.Add("height", "190px");
                }
            }
            else
            {
                divUnres.Style.Add("height", "30px");
                lbl_public_circle_msg.Visible = true;
            }


        }

        private void BindRestrictedCircle()
        {

            DataTable dt = new DataTable();
            if (MySession.Current.searchfriendId != null)
            {
                objusercircles.ID = Convert.ToInt32(MySession.Current.searchfriendId);
            }
            objusercircles.proceduretype = "PR1";
            dt = UserCirclesDAO.GetUserNameEmail(objusercircles);
            if (dt.Rows.Count > 0)
            {
                // dicPublicRestricted.Style.Add("display", "");
                DataList2.DataSource = dt;
                DataList2.DataBind();
                if (dt.Rows.Count <= 4)
                {
                    divPublicRestricted.Style.Add("height", "190px");
                }
            }
            else
            {
                divPublicRestricted.Style.Add("height", "30px");
                lblRestrictedMsg.Visible = true;
            }
        }

        protected void lnkBtnView_Click(object sender,  EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int count = 1;
                DataListItem dlist = ((LinkButton)sender).NamingContainer as DataListItem;

                HiddenField memberid = (HiddenField)dlist.FindControl("HiddenUserID");
                HiddenField membercircleid = (HiddenField)dlist.FindControl("hiddenCircleID");
                MySession.Current.PublicCircleUserId = memberid.Value;
                MySession.Current.PublicCircleId = membercircleid.Value;
                var myHidden = (HiddenField)dlist.FindControl("hdnId");
                myHidden.Value = dlist.ItemIndex.ToString();
                if (Session["bubbleId"] == null && myHidden.Value == "1")
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
                int count = 1;
                HiddenField memberid = (HiddenField)e.Item.FindControl("HiddenUserID");
                HiddenField membercircleid = (HiddenField)e.Item.FindControl("hiddenCircleID");
                MySession.Current.PublicCircleUserId = memberid.Value;
                MySession.Current.PublicCircleId = membercircleid.Value;
                var myHidden = (HiddenField)e.Item.FindControl("hdnId");
                myHidden.Value = e.Item.ItemIndex.ToString();
                if (Session["bubbleId"] == null && myHidden.Value == "1")
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
        }

        protected void lnkBtnView1_Click(object sender,  EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            int count = 0;
            try
            {
                DataTable dt = new DataTable();
                objusercircles.ID = id;
                objusercircles.proceduretype = "PC";
                dt = UserCirclesDAO.GetUserNameEmail(objusercircles);
                if (dt.Rows.Count > 0)
                {
                    count = dt.Rows.Count + 2;

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

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            if (e.CommandName == "lnkView")
            {
                int count = 0;
                DataTable dt = new DataTable();
                objusercircles.ID = id;
                objusercircles.proceduretype = "PC";
                dt = UserCirclesDAO.GetUserNameEmail(objusercircles);
                if (dt.Rows.Count > 0)
                {
                    count = dt.Rows.Count + 2;

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

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            int retval = 0;
            objusercircles.CI_ID = 0;
            objusercircles.fk_login_id = Convert.ToInt32(MySession.Current.LoginId);
            objusercircles.freind_user_id = Convert.ToInt32(MySession.Current.searchfriendId);
            if (txtMessage.Text != "")
            {
                objusercircles.CI_MESSAGE = txtMessage.Text;
            }
            else
            {
                objusercircles.CI_MESSAGE = "This is my public circle , request you to join this circle.";
            }
            objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
            objusercircles.CI_DATE = DateTime.Now.ToString();
            objusercircles.CI_STATUS = "False";
            objusercircles.proceduretype = "I";
            retval = UserCirclesDAO.InsertCircleInvitation(objusercircles);
            if (retval > 0)
            {
                lbmemberinvitation.Visible = true;
                lbmemberinvitation.Text = "Message has been successfully sent to join your " + MySession.Current.SelectedCircleName;
            }
        }

        private void CircleInvitation()
        {
            DataTable dt = new DataTable();
            objusercircles.UserId = Convert.ToInt32(MySession.Current.searchfriendId);
            objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
            objusercircles.proceduretype = "CI";
            dt = UserCirclesDAO.GetUserCircles(objusercircles);
            if (dt.Rows.Count > 0)
            {
                lbmemberinvitation.Visible = true;
                lbmemberinvitation.Text = "Message already sent to join your " + MySession.Current.SelectedCircleName;
                txtMessage.Visible = false;
                btnsendfrdrequest.Visible = false;
                btnSendMessage.Visible = false;
            }
            else
            {
                lbmemberinvitation.Visible = false;
                txtMessage.Visible = true;
                btnsendfrdrequest.Visible = false;
                btnSendMessage.Visible = true;
            }
        }
    }
}