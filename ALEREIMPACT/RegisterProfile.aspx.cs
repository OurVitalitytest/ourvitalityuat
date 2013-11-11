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
using ALEREIMPACT.BAL.User;

namespace ALEREIMPACT
{
    public partial class RegisterProfile : System.Web.UI.Page
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        RegisterUserDAO ObjRegisterUserDAO = new RegisterUserDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
                    
            if (!Page.IsPostBack)
            {
                BindAgeInYears();

            }
            if (String.IsNullOrEmpty(Convert.ToString(Session["registering_email_address"])))
            {
                Response.Redirect("~/Register.aspx", false);
            }
        }
        private void BindAgeInYears()
        {
            drpAge.Items.Clear();
            drpAge.Items.Insert(0, new ListItem("Select"));
            for (int year = 2013; year >= 1920; year--)
            {
                drpAge.Items.Add(year.ToString());
            }
        }


        //protected void imgProfileAdded_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //        ObjRegisterUserBAO.LoginEmail = Session["registering_email_address"].ToString();

        //        ObjRegisterUserBAO.UserRoleId = "1";
        //        ObjRegisterUserBAO.PasswordSalt = string.Empty;

        //        ObjRegisterUserBAO.LastName = txtSurname.Text.Trim();
        //        ObjRegisterUserBAO.UserAddress = txtAddress.Text.Trim();
        //        if (drpAge.SelectedValue.Trim().ToLower() == "select")
        //            ObjRegisterUserBAO.YearOfBirth = 0;
        //        else
        //            ObjRegisterUserBAO.YearOfBirth = Convert.ToInt32(drpAge.SelectedValue.Trim());

        //        string profileImage = "";
        //        if (!String.IsNullOrEmpty(Convert.ToString(txtProfileImage.Text)))
        //        {
        //            profileImage = txtProfileImage.Text;
        //            fupProfileImage.SaveAs(Server.MapPath(("~/User/profile_image" + "\\" + Session["registering_Id"] + "_" + txtProfileImage.Text)));
        //            fupProfileImage.SaveAs(Server.MapPath(("~/User/CircleImages" + "\\" + Session["registering_Id"] + "_" + txtProfileImage.Text)));
        //            ObjRegisterUserBAO.UserImage = Session["registering_Id"] + "_" + txtProfileImage.Text;
        //        }
        //        if (!String.IsNullOrEmpty(Convert.ToString(txtHomeContactOne.Text.Trim())))
        //        {
        //            ObjRegisterUserBAO.HomeContact1 = txtHomeContactOne.Text.Trim();
        //        }
        //        else
        //        {
        //            ObjRegisterUserBAO.HomeContact1 = "0";
        //        }
        //        if (!String.IsNullOrEmpty(Convert.ToString(txtHomeContactTwo.Text.Trim())))
        //        {
        //            ObjRegisterUserBAO.HomeContact2 = txtHomeContactTwo.Text.Trim();
        //        }
        //        else
        //        {
        //            ObjRegisterUserBAO.HomeContact2 = "0";
        //        }
        //        if (!String.IsNullOrEmpty(Convert.ToString(txtOfficeContact.Text.Trim())))
        //        {
        //            ObjRegisterUserBAO.OfficeContact = txtOfficeContact.Text.Trim();
        //        }
        //        else
        //        {
        //            ObjRegisterUserBAO.OfficeContact = "0";
        //        }


        //        if (!String.IsNullOrEmpty(Convert.ToString(txtZip.Text.Trim())))
        //        {
        //            ObjRegisterUserBAO.Zip = Convert.ToInt32(txtZip.Text.Trim());
        //        }
        //        else
        //        {
        //            ObjRegisterUserBAO.Zip = 0;
        //        }
        //        string gender = null;
        //        if (radGender.SelectedValue != "1" && radGender.SelectedValue != "2")
        //        {
        //            gender = string.Empty;
        //        }
        //        else
        //        {
        //            if (radGender.SelectedValue == "1")
        //            {
        //                gender = "Male";
        //            }
        //            else if (radGender.SelectedValue == "2")
        //            {
        //                gender = "FeMale";
        //            }
        //        }

        //        ObjRegisterUserBAO.Gender = gender;
        //        ObjRegisterUserBAO.HeightInFeets = Convert.ToInt32(drpFeets.SelectedValue);
        //        ObjRegisterUserBAO.HeightInInches = Convert.ToInt32(drpInches.SelectedValue);

        //        if (String.IsNullOrEmpty(Convert.ToString(txtWeight.Text.Trim())))
        //            ObjRegisterUserBAO.Weight = 0;
        //        else
        //            ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeight.Text);

        //        RegisterUserDAO.SubmitNewUser(ObjRegisterUserBAO);
        //        Session["register_success"] = "Thank you for registering with us. You will be recieving an email shortly !";
        //        Response.Redirect("~/Login.aspx", false);
        //    }
        //}
        //protected void checkfilesize_fup_ProfileImage(object source, ServerValidateEventArgs args)
        //{
        //    string data = args.Value;
        //    args.IsValid = false;
        //    double filesize = fupProfileImage.FileContent.Length;
        //    if (filesize > Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["profileImage"].ToString()))
        //    {
        //        args.IsValid = false;
        //    }
        //    else
        //    {
        //        txtProfileImage.Text = System.IO.Path.GetFileName(fupProfileImage.FileName);
        //        args.IsValid = true;
        //    }
        //}



    }
}
