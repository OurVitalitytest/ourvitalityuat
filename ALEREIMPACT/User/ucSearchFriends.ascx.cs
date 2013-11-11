using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.FRAMEWORK;

namespace ALEREIMPACT.User
{
    public partial class ucSearchFriends : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");
                //if (string.IsNullOrEmpty(Request.Cookies["AuthToken"].Value))
                //{
                //    ClsGeneric.Clear_Session1();
                //}
                if (MySession.Current.SelectedCircleUserId != MySession.Current.LoginId)
                {
                    dvsearch.Visible = false;

                }
                else
                {
                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {
                            dvsearch.Visible = true;
                        }
                        else
                        {
                            dvsearch.Visible = true;
                        }
                    }
                    else
                    {
                        dvsearch.Visible = false;
                    }
                }
                this.txtfindfriend.Attributes.Add("onkeypress", "ShowImage()");
                this.txtfindfriend.Attributes.Add("onblur", "HideImage()");
                txtfindfriend.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnfindfriend_Click(object sender, EventArgs e)
        {
           ClsGeneric.ReplaceCookie();
           try
           {
               MySession.Current.PublicCircleId = "";
               MySession.Current.PublicCircleUserId = "";
               MasterPage mstr = this.Parent.Page.Master as MasterPage;

               MySession.Current.searchfriendId = ace1Value.Value;
               // this.Master.iframe.Attributes.Add("src", "Frien   dProfile.aspx");
               // Response.Redirect("~/User/FriendProfile.aspx", false);
               ((LoginUserMaster)this.Page.Master).SearchMembers();
               txtfindfriend.Text = "";
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
        }

        protected void btnInviteMember_Click(object sender, EventArgs e)
        {
            
            ClsGeneric.ReplaceCookie();
            try
            {
                MySession.Current.PublicCircleId = "";
                MySession.Current.PublicCircleUserId = "";
                MasterPage mstr = this.Parent.Page.Master as MasterPage;

                MySession.Current.searchfriendId = ace1Value.Value;
                MySession.Current.SearchNAme = txtfindfriend.Text.Trim();
                if (txtfindfriend.Text == "" && MySession.Current.searchfriendId != null)
                {
                    MySession.Current.SearchNAme = "Find all circles named::" + MySession.Current.searchfriendId;
                }
                if (MySession.Current.SearchNAme.Contains("See More Results for"))
                {
                  string filter_search=  MySession.Current.SearchNAme.Split(':').Last();
                  MySession.Current.SearchNAme = filter_search.Trim();
                  ((LoginUserMaster)this.Page.Master).SearchMembers();
                  txtfindfriend.Text = "";
                }
                else if (MySession.Current.SearchNAme.Contains("Find all circles named:"))
                {
                    string filter_search = MySession.Current.SearchNAme.Split(':').Last();
                    MySession.Current.SearchNAme = filter_search.Trim();
                    Session["seachByCircel"] = "search_cicle";
                    ((LoginUserMaster)this.Page.Master).Search_Circle_List();
                    MySession.Current.searchfriendId = "";
                    txtfindfriend.Text = "";

                }
                //BindCircles
                // this.Master.iframe.Attributes.Add("src", "FriendProfile.aspx");
                // Response.Redirect("~/User/FriendProfile.aspx", false);
                else
                {
                    ((LoginUserMaster)this.Page.Master).SearchMembers();
                    txtfindfriend.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}