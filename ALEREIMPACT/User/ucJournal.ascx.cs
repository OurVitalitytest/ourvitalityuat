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
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;

namespace ALEREIMPACT.User
{
    public partial class ucJournal : System.Web.UI.UserControl
    {
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        AdminBAO objAdminBAO = new AdminBAO();
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
                        bindMood();
                        BindJournalDetail(); 
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void bindMood()
        {
            DataTable dt = new DataTable();
            objRegisterUserBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            objRegisterUserBAO.procedureType = "JD";
            dt = RegisterUserDAO.GetInvitationDetail(objRegisterUserBAO);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["MOOD_ID_FK"].ToString() == "1")
                {
                    dvExcellent.Attributes.Add("class", "vary_happy sel_Journal");
                    dvHappy.Attributes.Add("class", "happy");
                    dvOK.Attributes.Add("class", "ok ");
                    dvSad.Attributes.Add("class", "sad ");
                    dvAngry.Attributes.Add("class", "angry ");
                }
                else if (dt.Rows[0]["MOOD_ID_FK"].ToString() == "2")
                {
                    dvHappy.Attributes.Add("class", "happy sel_Journal");
                    dvExcellent.Attributes.Add("class", "vary_happy");
                    dvOK.Attributes.Add("class", "ok ");
                    dvSad.Attributes.Add("class", "sad ");
                    dvAngry.Attributes.Add("class", "angry ");
                }
                else if (dt.Rows[0]["MOOD_ID_FK"].ToString() == "3")
                {
                    dvOK.Attributes.Add("class", "ok sel_Journal");
                    dvExcellent.Attributes.Add("class", "vary_happy");
                    dvHappy.Attributes.Add("class", "happy ");
                    dvSad.Attributes.Add("class", "sad ");
                    dvAngry.Attributes.Add("class", "angry ");
                }
                else if (dt.Rows[0]["MOOD_ID_FK"].ToString() == "4")
                {
                    dvSad.Attributes.Add("class", "sad sel_Journal");
                    dvExcellent.Attributes.Add("class", "vary_happy");
                    dvHappy.Attributes.Add("class", "happy ");
                    dvOK.Attributes.Add("class", "ok ");
                    dvAngry.Attributes.Add("class", "angry ");
                }
                else if (dt.Rows[0]["MOOD_ID_FK"].ToString() == "5")
                {
                    dvAngry.Attributes.Add("class", "angry sel_Journal");
                    dvExcellent.Attributes.Add("class", "vary_happy");
                    dvHappy.Attributes.Add("class", "happy ");
                    dvSad.Attributes.Add("class", "sad ");
                    dvOK.Attributes.Add("class", "ok ");
                }
            }
        }


        private void BindJournalDetail()
        {
            DataTable dt = new DataTable();
            objRegisterUserBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            objRegisterUserBAO.procedureType = "JD";
            dt = RegisterUserDAO.GetInvitationDetail(objRegisterUserBAO);
            if (dt.Rows.Count > 0)
            {

                RpMoodDeatil.DataSource = dt;
                RpMoodDeatil.DataBind();
            }
            else
            {
                RpMoodDeatil.DataSource = null;
                RpMoodDeatil.DataBind();
            }
        }

        protected void RpMoodDeatil_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hdnMood = (HiddenField)e.Item.FindControl("hdnMood");
                Image ImgMood = (Image)e.Item.FindControl("ImgMood");
                if (hdnMood.Value == "1")
                {
                    ImgMood.ImageUrl = "~/images/veryhappy.png";
                    ImgMood.ToolTip = "Excellent";
                }
                else if (hdnMood.Value == "2")
                {
                    ImgMood.ImageUrl = "~/images/happy.png";
                    ImgMood.ToolTip = "Happy";
                }
                else if (hdnMood.Value == "3")
                {
                    ImgMood.ImageUrl = "~/images/ok.png";
                    ImgMood.ToolTip = "Ok";
                }
                else if (hdnMood.Value == "4")
                {
                    ImgMood.ImageUrl = "~/images/sad.png";
                    ImgMood.ToolTip = "Sad";
                }
                else if (hdnMood.Value == "5")
                {
                    ImgMood.ImageUrl = "~/images/angry.png";
                    ImgMood.ToolTip = "Angry";
                }
                
            }
        }

        protected void btnJournalSubmit_Click(object sender, EventArgs e)
        {
            if (hdnMoodId.Value == "" || hdnMoodId.Value == null || hdnMoodId.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Select atleast one Mood');", true);
            }
            else
            {
                int retval = 0;
                objRegisterUserBAO.JOURNAL_ID = 0;
                objRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                objRegisterUserBAO.MOOD_ID_FK = hdnMoodId.Value;
                objRegisterUserBAO.JOURNAL_TITLE = txtTitle.Text;
                objRegisterUserBAO.JOURNAL_CONTENT = txtContent.Text;
                objRegisterUserBAO.JOURNAL_DATE = DateTime.Now.ToString();
                objRegisterUserBAO.procedureType = "I";
                retval = RegisterUserDAO.InsertTblJournal(objRegisterUserBAO);
                txtContent.Text = "";
                txtTitle.Text = "";
            }
            BindJournalDetail();
        }


        protected void RpMoodDeatil_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ImgBtnDelete")
            {
                string id = e.CommandArgument.ToString();
                objAdminBAO.ID = Convert.ToInt32(id);
                objAdminBAO.ProcedureType = "JDD";
                AdminDAO.deleteComment(objAdminBAO);
                BindJournalDetail();
            }
        }

        protected void ImgBtnExcellent_Click(object sender, ImageClickEventArgs e)
        {
            hdnMoodId.Value = "1";
            dvExcellent.Attributes.Add("class", "vary_happy sel_Journal");
            dvHappy.Attributes.Add("class", "happy");
            dvOK.Attributes.Add("class", "ok ");
            dvSad.Attributes.Add("class", "sad ");
            dvAngry.Attributes.Add("class", "angry ");
        }

        protected void ImgBtnHappy_Click(object sender, ImageClickEventArgs e)
        {
            hdnMoodId.Value =" 2";
            dvHappy.Attributes.Add("class", "happy sel_Journal");
            dvExcellent.Attributes.Add("class", "vary_happy");
            dvOK.Attributes.Add("class", "ok ");
            dvSad.Attributes.Add("class", "sad ");
            dvAngry.Attributes.Add("class", "angry ");
        }

        protected void ImgBtnOK_Click(object sender, ImageClickEventArgs e)
        {
            hdnMoodId.Value = "3";
            dvOK.Attributes.Add("class", "ok sel_Journal");
            dvExcellent.Attributes.Add("class", "vary_happy");
            dvHappy.Attributes.Add("class", "happy ");
            dvSad.Attributes.Add("class", "sad ");
            dvAngry.Attributes.Add("class", "angry ");
        }

        protected void ImgBtnSad_Click(object sender, ImageClickEventArgs e)
        {
            hdnMoodId.Value = "4";
            dvSad.Attributes.Add("class", "sad sel_Journal");
            dvExcellent.Attributes.Add("class", "vary_happy");
            dvHappy.Attributes.Add("class", "happy ");
            dvOK.Attributes.Add("class", "ok ");
            dvAngry.Attributes.Add("class", "angry ");
        }

        protected void ImgBtnAngry_Click(object sender, ImageClickEventArgs e)
        {
            hdnMoodId.Value = "5";
            dvAngry.Attributes.Add("class", "angry sel_Journal");
            dvExcellent.Attributes.Add("class", "vary_happy");
            dvHappy.Attributes.Add("class", "happy ");
            dvSad.Attributes.Add("class", "sad ");
            dvOK.Attributes.Add("class", "ok ");
        }

    }
}