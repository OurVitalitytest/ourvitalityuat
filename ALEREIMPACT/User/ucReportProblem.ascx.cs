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

namespace ALEREIMPACT.User
{
    public partial class ucReportProblem : System.Web.UI.UserControl
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        SQLHelper objSqlHelper = new SQLHelper();
        public static string filename;
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
                        fillDrpDown();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void fillDrpDown()
        {
            objSqlHelper.fillDrpControl(DrpPage, "spFillDrpDown", "PAGE_NAME", "PAGE_ID", "P");

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (txtProblem.Text != "")
                {
                    if (FileUpload1.HasFile)
                    {
                        Int32 filesize = FileUpload1.PostedFile.ContentLength;

                        string PhotoFileName = FileUpload1.FileName;
                        string fileext = System.IO.Path.GetExtension(PhotoFileName.ToString());
                        Session["_ReportProblem"] = PhotoFileName;
                        MySession.Current.Image = PhotoFileName;
                        filename = PhotoFileName;
                        FileUpload1.PostedFile.SaveAs(MapPath("~") + "/User/ReportErrorImages/" + filename);
                    }
                            int retval = 0;
                            ObjRegisterUserBAO.ER_ID = 0;
                            ObjRegisterUserBAO.PAGE_ID_FK = Convert.ToInt32(DrpPage.SelectedValue);
                            ObjRegisterUserBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                            ObjRegisterUserBAO.ER_MESSAGE = txtProblem.Text;
                            ObjRegisterUserBAO.ER_IMAGE = filename;
                            ObjRegisterUserBAO.ER_POST_DATE = DateTime.Now.ToString();
                            ObjRegisterUserBAO.ER_STATUS = "False";
                            ObjRegisterUserBAO.procedureType = "I";
                            retval = RegisterUserDAO.InserttblErrorDetail(ObjRegisterUserBAO);
                            txtProblem.Text = "";
                            DrpPage.SelectedIndex = 0;
                            Response.Redirect("FeedBackAndProblem.aspx?val=" + 2, false);
                        //}
                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



    }
}