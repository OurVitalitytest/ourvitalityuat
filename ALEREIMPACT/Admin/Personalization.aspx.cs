using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
namespace ALEREIMPACT.Admin
{
    public partial class Personalization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                //Response.Cache.SetNoStore();
                //Response.AppendHeader("Pragma", "no-cache");
           
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        BindPersonalisationImages();

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void BindPersonalisationImages()
        {
            AdminBAO objAdminBAO = null;
            DataTable dtTable = null;
            try
            {
                objAdminBAO = new AdminBAO();
                dtTable = new DataTable();
                objAdminBAO.PersonalizationTypesImage = string.Empty;
                objAdminBAO.PersonalizationTypesImagesId = string.Empty;
                objAdminBAO.ProcedureType = 1;
                dtTable = AdminDAO.GetPersonalization_Images(objAdminBAO);
                grdPersonalization.DataSource = dtTable;
                grdPersonalization.DataBind();
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
            finally
            {
                objAdminBAO = null;
                dtTable = null;
            }
        }
        protected void grdPersonalization_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string imageName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "personalization_Type_Image"));
                    Image imgImageWithPath = (Image)e.Row.FindControl("imgImage");
                    imgImageWithPath.ImageUrl = "../User/PersonalizationImages/" + imageName;

                    if (e.Row.RowIndex % 3 == 0)
                    {
                        e.Row.Cells[0].Attributes.Add("rowspan", "3");
                    }
                    else
                    {
                        e.Row.Cells[0].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                FileUpload FileUpload1 = (FileUpload)grdPersonalization.Rows[e.RowIndex].FindControl("FileUpload1");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void grdPersonalization_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();

            if (e.CommandName == "EditImage")
            {
                ImageButton row = e.CommandSource as ImageButton;

                FileUpload fupNewImage = (FileUpload)row.FindControl("fupNewImage");
                if (fupNewImage.HasFile)
                {
                    LinkButton lnkEdit = (LinkButton)row.FindControl("lnkEdit");

                    AdminBAO objAdminBAO = null;
                    DataTable dtTable = null;
                    try
                    {
                        string[] argArr = new string[2];
                        argArr = lnkEdit.CommandArgument.ToString().Split('&');

                        objAdminBAO = new AdminBAO();
                        dtTable = new DataTable();
                        objAdminBAO.PersonalizationTypesImage = argArr[1] + "_" + fupNewImage.FileName;
                        objAdminBAO.PersonalizationTypesImagesId = argArr[0];
                        objAdminBAO.ProcedureType = 2;
                        dtTable = AdminDAO.GetPersonalization_Images(objAdminBAO);
                        fupNewImage.SaveAs(Server.MapPath("~/" + "User/PersonalizationImages/" + argArr[1] + "_" + fupNewImage.FileName));
                        BindPersonalisationImages();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('The new Image has been successfully uploaded !');", true);
                    }
                    catch (Exception ex)
                    {
                        Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
                    }
                    finally
                    {
                        objAdminBAO = null;
                        dtTable = null;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('You must select a new file to upload !');", true);
                }
            }
        }
    }
}


