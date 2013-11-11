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
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;

namespace ALEREIMPACT.User
{
    public partial class Support : System.Web.UI.Page
    {
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}
