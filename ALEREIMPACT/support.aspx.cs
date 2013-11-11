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
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
namespace ALEREIMPACT
{
    public partial class support : System.Web.UI.Page
    {
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ClsGeneric.ReplaceCookie();
            //try
            //{

            //    Response.Redirect("login.aspx", false);
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }

        protected void ImgRedirectTo_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {

                Response.Redirect("login.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnSubmit_Click(object sender, ImageClickEventArgs e)
        {

            int retval = 0;
            objUserRegisterBAO.SUPPORT_ID = 0;
            objUserRegisterBAO.SUPPORT_NAME = txtName.Text;
            objUserRegisterBAO.SUPPORT_EMAIL = txtEmail.Text;
            objUserRegisterBAO.SUPPORT_MESSAGE = txtMessage.Text;
            objUserRegisterBAO.SUPPORT_DATE = DateTime.Now.ToString();
            objUserRegisterBAO.procedureType = "I";
            retval = RegisterUserDAO.InsertTblSupport(objUserRegisterBAO);
            if (retval != 0)
            {
                DVMSg.Visible = true;
              
            }
            txtName.Text = "";
            txtEmail.Text = "";
            txtMessage.Text = "";
        }

        protected void lnkTermsnConditions_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/termsandconditions.aspx", false);
        }

        protected void lnkprivacynPolicy_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/privacyandpolicy.aspx", false);
        }

        protected void lnkSupport_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/support.aspx", false);
        }
    }
}
