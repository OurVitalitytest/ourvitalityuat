using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using System.Data;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.alereimpactservice;
using ALEREIMPACT.Service;
using System.Web.Services;
using ALEREIMPACT.BAL.User;

namespace ALEREIMPACT.User
{
    public partial class CirclesNew : System.Web.UI.Page
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  txtcirclecolor.Attributes.Add("readonly", "readonly");
                filldropdowns();
                BindCircles();

            }
            if (Convert.ToString(Session["bubbleId"]) == "" || Convert.ToString(Session["bubbleId"]) == null)
            {
                lblMessage.Value = "1";
            }
            else
            {
                lblMessage.Value = Convert.ToString(Session["bubbleId"]);
            }
           
        }

        private void filldropdowns()
        {
          //  objhelper.fillDrpControl(ddlcirclespec, "spFillDrpDown", "CirclePermissions", "CirclePermissionId", "CS");
        }

        protected void repCircles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            int membercount = 0;
            int missioncount = 0;
            //Find Controls from Repeater Control
            HtmlGenericControl dynamic1 = (HtmlGenericControl)e.Item.FindControl("dvimagecircle");
            HiddenField hndcolor = (HiddenField)e.Item.FindControl("hndcolor");
            HiddenField hnducId = (HiddenField)e.Item.FindControl("hnducId");
            HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
            HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
            HiddenField hndCName = (HiddenField)e.Item.FindControl("hndCName");
            LinkButton lkfriendscount = (LinkButton)e.Item.FindControl("lkfriendscount");
            LinkButton lkmissioncount = (LinkButton)e.Item.FindControl("lkmissioncount");

            //Find color Div - Change circle color dynamically
            HtmlGenericControl dvcirclecolor = (HtmlGenericControl)e.Item.FindControl("dvcirclecolor");
            dvcirclecolor.Style.Add("background-color", "#" + hndcolor.Value);
            //dynamic1.Style.Add("border", "9px solid");


            HtmlGenericControl dv1img = (HtmlGenericControl)e.Item.FindControl("dv1img");
            HtmlGenericControl dv2img = (HtmlGenericControl)e.Item.FindControl("dv2img");
            HtmlGenericControl dv3img = (HtmlGenericControl)e.Item.FindControl("dv3img");
            HtmlGenericControl dv4img = (HtmlGenericControl)e.Item.FindControl("dv4img");
            HtmlGenericControl dv5img = (HtmlGenericControl)e.Item.FindControl("dv5img");


            //Get member Images (5)
            DataTable dtMemberimg = new DataTable();
            objusercircles.UserId = hndUserId.Value;
            objusercircles.fk_circle_id = hndCircleId.Value;
            objusercircles.proceduretype = "S";
            dtMemberimg = UserCirclesDAO.GetMemberImagesForCircle(objusercircles);
            if (dtMemberimg.Rows.Count == 1)
            {
                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
            }

            if (dtMemberimg.Rows.Count == 2)
            {
                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
            }
            if (dtMemberimg.Rows.Count == 3)
            {
                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
            }
            if (dtMemberimg.Rows.Count == 4)
            {
                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
            }
            if (dtMemberimg.Rows.Count == 5)
            {

                dv1img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[0]["frdimage"]));
                dv2img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[1]["frdimage"]));
                dv3img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[2]["frdimage"]));
                dv4img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[3]["frdimage"]));
                dv5img.Style.Add("background-image", "profile_image/" + Convert.ToString(dtMemberimg.Rows[4]["frdimage"]));
            }



            //Get Total Member Count for the circle
            objusercircles.UserId = hndUserId.Value;
            objusercircles.fk_circle_id = hndCircleId.Value;
            objusercircles.proceduretype = "M";
            membercount = UserCirclesDAO.GetCircleMemberCount(objusercircles);
            lkfriendscount.Text = Convert.ToString(membercount);

            //Get Total Mission Count for the circle
            objusercircles.UserId = hndUserId.Value;
            objusercircles.fk_circle_id = hndCircleId.Value;
            objusercircles.proceduretype = "MI";
            missioncount = UserCirclesDAO.GetCircleMemberCount(objusercircles);
            lkmissioncount.Text = Convert.ToString(missioncount);


            //Selected Circle Indication

            string cid = hndUserId.Value + "-" + hndCircleId.Value;
            if (Convert.ToString(Session["selectedcircleid"]) == null || Convert.ToString(Session["selectedcircleid"]) == "")
            {
                (Session["selectedcircleid"]) = cid;
                MySession.Current.SelectedCircleUserId = MySession.Current.LoginId;
                MySession.Current.SelectedCircleName = "Inner Circle";
            }

            if (Convert.ToString(Session["selectedcircleid"]) == cid)
            {
                HtmlGenericControl dvcirclecolor1 = (HtmlGenericControl)e.Item.FindControl("dvcirclecolor");
                //  dvcirclecolor1.Style.Add("border", "9px solid");
                dvcirclecolor1.Style.Add("height", "200px !important");
                dvcirclecolor1.Style.Add("width", "200px !important");
                dvcirclecolor1.Style.Add("left", "40px !important");
                dvcirclecolor1.Style.Add("top", "200px !important");
                dvcirclecolor1.Style.Add("data-href", hndCircleId.Value);
                

                MySession.Current.SelectedCircleName = hndCName.Value;

            }

            //dynamic1.Style.Add("border-color", "#" + hndcolor.Value);

        }
        protected void repCircles_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField getselectedbubbleId = (HiddenField)e.Item.FindControl("repid");

                Session["bubbleId"] = getselectedbubbleId.Value;
                HtmlGenericControl dvcirclecolor = (HtmlGenericControl)e.Item.FindControl("dvcirclecolor");

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                if (e.CommandName == "ShowForSelectedCircle") //Circle Selection
                {
                    HiddenField hnducId = (HiddenField)e.Item.FindControl("hnducId");
                    Int32 CircleId = Convert.ToInt32(commandArgs[0]);
                    HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
                    HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
                    HiddenField hndCName = (HiddenField)e.Item.FindControl("hndCName");

                    string cid = hndUserId.Value + "-" + hndCircleId.Value;
                    Session["selectedcircleid"] = cid;

                    Int32 SelectedCircleUId = Convert.ToInt32(commandArgs[1]);
                    MySession.Current.SelectedCircleUserId = Convert.ToInt32(SelectedCircleUId).ToString();
                    MySession.Current.CircleId = Convert.ToInt32(CircleId).ToString();
                    MySession.Current.SelectedCircleName = hndCName.Value;
                    //  Response.Redirect("~/User/Wall.aspx", false);
                    //Response.Redirect(Request.Url.AbsoluteUri);
                  //  Control ctl = LoadControl("~/User/ucWall.ascx");

                   // ucWall ser = (ucWall)Page.LoadControl("~/User/ucWall.ascx"); //Find User Control
                   // upNotesPanel.ContentTemplateContainer.Controls.Add(ser);
                   // u.ButtonClickDemo += new EventHandler(Demo1_ButtonClickDemo);

                   
                    // Control control = Page.FindControl("UserControl1ID");
                    //  LinkButton lbUserControl1 = ser.FindControl("LinkButton1") as LinkButton;
                    // lbUserControl1.Text = "link";
                  //  ser.ClickButton();

                    //upNotesPanel.Update();
                    //ser.ButtonClickDemo += new EventHandler(lbUserControl1..);
                    //IPostBackEventHandler c = (IPostBackEventHandler)this.lbUserControl1;
                    //c.RaisePostBackEvent(string.Empty);




                    //ucWall UC_text = (ucWall)this.NamingContainer.FindControl("LinkButton1");

                    // LinkButton lkwall = (LinkButton)ser.FindControl("LinkButton1");
                    //lkwall = (LinkButton)(ser.FindControl("LinkButton1"));
                    // lkwall.Text = "link";

                    //  (LinkButton)ser.findcontrol("LinkButton1")).text = "test";



                    //ContentPlaceHolder MySecondContent = (ContentPlaceHolder)this.Parent.Parent.FindControl("ContentPlaceHolder1");

                    //  LinkButton UC_text = (LinkButton)MySecondContent.FindControl("LinkButton1");
                    //   UC_text.Text = "link";


                    //  IPostBackEventHandler c = (IPostBackEventHandler)this.lkwall;
                    //c.RaisePostBackEvent(string.Empty);


                    //Call Bind Commnets Method from User Control(ucWall)
                    // ser.Bind_WallComments(Convert.ToInt32(MySession.Current.SelectedCircleUserId), Convert.ToInt32(MySession.Current.CircleId), 1, 0);

                    //Find Update Panel From User Control (ucWall)
                    //UpdatePanel mUpdatePanel = new UpdatePanel();
                    //mUpdatePanel = (UpdatePanel)(ser.FindControl("updatePanelWall_1"));

                    // mUpdatePanel.Update(); //Update User Control's Update Panel


                    //UpdatePanel updatePanel = (UpdatePanel)this.Page.FindControl("updatePanelWall_1");                    
                    // BindCircles();
                }
                if (e.CommandName == "ShowSelectedCircleMembers") //Member List on click on Circle Member count
                {
                    HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
                    HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
                    string cid = hndUserId.Value + "-" + hndCircleId.Value;
                    Session["selectedcircleid"] = cid;

                    Int32 CircleId = Convert.ToInt32(commandArgs[0]);
                    Int32 SelectedCircleUId = Convert.ToInt32(commandArgs[1]);
                    MySession.Current.SelectedCircleUserId = Convert.ToInt32(SelectedCircleUId).ToString();
                    MySession.Current.CircleId = Convert.ToInt32(CircleId).ToString();
                    Response.Redirect("~/User/MemberList.aspx", false);
                }
                if (e.CommandName == "ShowSelectedCircleMissions") //Mission List on click on Circle Mission count
                {
                    HiddenField hndUserId = (HiddenField)e.Item.FindControl("hndUserId");
                    HiddenField hndCircleId = (HiddenField)e.Item.FindControl("hndCircleId");
                    string cid = hndUserId.Value + "-" + hndCircleId.Value;
                    Session["selectedcircleid"] = cid;

                    Int32 CircleId = Convert.ToInt32(commandArgs[0]);
                    Int32 SelectedCircleUId = Convert.ToInt32(commandArgs[1]);
                    MySession.Current.SelectedCircleUserId = Convert.ToInt32(SelectedCircleUId).ToString();
                    MySession.Current.CircleId = Convert.ToInt32(CircleId).ToString();
                    Session["show_list_mission"] = "True";
                    Response.Redirect("~/User/Missions.aspx", false);

                }
            }
        }
        public void BindCircles()
        {
            try
            {
                DataTable dtcircles = new DataTable();
                DataSet ds = new DataSet();
                if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                {
                    objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.fk_circle_id = 0;

                    objusercircles.proceduretype = "G";
                    //imgaddcircle.Visible = true;
                    //Label1.Visible = true;



                }
                else
                {
                    objusercircles.UserId = Convert.ToInt32(MySession.Current.MemberUserId);
                    objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.MemberCircleId);
                    objusercircles.proceduretype = "M";
                    // imgaddcircle.Visible = false;
                    //  Label1.Visible = false;
                }


                dtcircles = UserCirclesDAO.GetUserCircles(objusercircles);
                ds.Tables.Add(dtcircles);
                if (dtcircles.Rows.Count > 0)
                {
                    //repCircles.DataSource = dtcircles;
                    repCircles.DataSource = ds.Tables[0];
                    repCircles.DataBind();

                }
                if (MySession.Current.CircleId == "" || MySession.Current.CircleId == null)
                {
                    MySession.Current.CircleId = Convert.ToInt32(dtcircles.Rows[0]["pk_circle_id"]).ToString();
                }
            }
            catch (Exception ex)
            { }


        }

        protected void btncreatecircle_Click(object sender, EventArgs e)
        {

            // PnlCircle.Visible = true;
           
        }
      
        //protected void lkfriends_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/User/FriendList.aspx", false);
    }
}
