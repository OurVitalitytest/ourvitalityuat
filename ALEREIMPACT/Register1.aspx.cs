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
using System.Configuration;
using ALEREIMPACT.DAL.User;

namespace ALEREIMPACT.User
{
    public partial class Register1 : System.Web.UI.Page
    {
        RegisterUserBAO ObjRegisterUserBAO = new RegisterUserBAO();
        RegisterUserDAO ObjRegisterUserDAO = new RegisterUserDAO();
        PrivacySettingBAO objUserPrivacySettings = new PrivacySettingBAO();
        UserFoodLogBAO objUserFoodLogBAo = new UserFoodLogBAO();
        public static Int32 id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               

                if (!Page.IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["val"]))
                    {

                        id = Convert.ToInt32(Request.QueryString["val"]);
                    }
                    bindYearDay();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
     

        private void bindYearDay()
        {
            try
            {
                int currentyear = DateTime.Now.Year;
                for (int year = currentyear; year >= 1900; year--)
                {
                    drpYear.Items.Add(year.ToString());
                }

                for (int i = 1; i <= 31; i++)
                {
                    DrpDAy.Items.Add(i.ToString());
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private Int32 SubmitDetails(bool profileHasNotChangedStatus)
        {
            Int32 resReturned = 0;
            try
            {
                

                ObjRegisterUserBAO.LoginEmail = txtEmail.Text.Trim().ToString();

                Session["registering_email_address"] = ObjRegisterUserBAO.LoginEmail;

                string createPwd = Guid.NewGuid().ToString().Split(new char[] { '-' })[0];
                ObjRegisterUserBAO.LoginPassword = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(createPwd);
                ObjRegisterUserBAO.UserRoleId = "2";
                ObjRegisterUserBAO.PasswordSalt = string.Empty;
                ObjRegisterUserBAO.IsPasswordChanged = false;
                ObjRegisterUserBAO.LoginStatus = 0;
                ObjRegisterUserBAO.FirstName = txtName.Text.Trim();
                ObjRegisterUserBAO.LastName = txtLname.Text;
                ObjRegisterUserBAO.UserAddress = string.Empty;
                if (drpYear.SelectedIndex != 0)
                {
                   // drpYear.SelectedValue= hdndate.Value ;
                    ObjRegisterUserBAO.YearOfBirth = Convert.ToInt32(drpYear.SelectedValue);
                }
                else
                {
                    ObjRegisterUserBAO.YearOfBirth = 0;
                }
                if (drpMonth.SelectedIndex != 0)
                {
                    ObjRegisterUserBAO.MonthOfBirth = Convert.ToInt32(drpMonth.SelectedValue);
                }
                else
                {
                    ObjRegisterUserBAO.MonthOfBirth = 0;
                }
                if (DrpDAy.SelectedIndex != 0)
                {
                    ObjRegisterUserBAO.DateOfBirth = Convert.ToInt32(DrpDAy.SelectedValue);
                }
                else
                {
                    ObjRegisterUserBAO.DateOfBirth = 0;

                }
                ObjRegisterUserBAO.LocationId = 0;
                ObjRegisterUserBAO.Zip = 0;
                ObjRegisterUserBAO.Gender = "";
                ObjRegisterUserBAO.MobileNumber = "0";
                ObjRegisterUserBAO.HomeContact1 = "0";
                ObjRegisterUserBAO.HomeContact2 = "0";
                ObjRegisterUserBAO.OfficeContact = "0";
                if ((txtHeight.Text) != "")
                {
                    ObjRegisterUserBAO.Height = Convert.ToDecimal(txtHeight.Text);
                    ObjRegisterUserBAO.HeightUnits = Convert.ToInt32(drpUserHeightOptions.SelectedValue);
                }
                else
                {
                    ObjRegisterUserBAO.Height = 0;
                    ObjRegisterUserBAO.HeightUnits = 0;
                }

                if ((txtWeight.Text) != "")
                {
                    ObjRegisterUserBAO.Weight = Convert.ToInt32(txtWeight.Text);
                    ObjRegisterUserBAO.WeightUnits = Convert.ToInt32(drpUserWeightOptions.SelectedValue);
                }
                else
                {
                    ObjRegisterUserBAO.Weight = 0;
                    ObjRegisterUserBAO.WeightUnits = 0;
                }
                if (drpUserHeightOptions.SelectedValue == "3")
                {
                    if (txtheightInches.Text != "0" || txtheightInches.Text != null)
                    {
                        ObjRegisterUserBAO.HeightInches = Convert.ToInt32(txtheightInches.Text);
                    }
                    else
                    {
                        ObjRegisterUserBAO.HeightInches = 0;
                    }
                }
                else
                {

                    ObjRegisterUserBAO.HeightInches = 0;
                }


                ObjRegisterUserBAO.RegistrationTypeId = 1;
                ObjRegisterUserBAO.HasProfileAdded = profileHasNotChangedStatus;
                ObjRegisterUserBAO.RS_ID_FK = 9;
                ObjRegisterUserBAO.EDU_ID_FK = 10;
                ObjRegisterUserBAO.WP_ID_FK = 15;
                ObjRegisterUserBAO.INTEREST_ID_FK = 10;
                ObjRegisterUserBAO.RELIGION_ID_FK = 10;
                DataTable dt = new DataTable();
                dt = RegisterUserDAO.SubmitNewUser(ObjRegisterUserBAO);

                resReturned = Convert.ToInt32(dt.Rows[0][0]);

                ClsGeneric objGeneric = new ClsGeneric();
                if (resReturned != 0)
                {

                    DataTable dtPrivacy = new DataTable();
                    objUserFoodLogBAo.ProcedureType = "PS";
                    dtPrivacy = UserFoodLogDAO.GetFoodCategories(objUserFoodLogBAo);
                    if (dtPrivacy.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtPrivacy.Rows.Count; i++)
                        {
                            int retval1 = 0;
                            objUserPrivacySettings.UPS_ID = 0;
                            objUserPrivacySettings.PS_ID_FK = Convert.ToInt32(dtPrivacy.Rows[i]["PS_ID"]);
                            objUserPrivacySettings.fk_user_registration_id = resReturned;
                            if (i == 0)
                            {
                                objUserPrivacySettings.UPS_ANYONE = true;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                            else if (i == 1)
                            {
                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;

                            }
                            else if (i == 2)
                            {


                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                            }
                            else if (i == 3)
                            {

                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = true;

                            }
                            else if (i == 4)
                            {

                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = true;


                            }
                            else if (i == 5)
                            {

                                objUserPrivacySettings.UPS_ANYONE = false;
                                objUserPrivacySettings.UPS_YOU = false;
                                objUserPrivacySettings.UPS_FRIENDS = true;


                            }
                            else if (i == 6)
                            {

                                objUserPrivacySettings.UPS_YOU = true;
                                objUserPrivacySettings.UPS_FRIENDS = false;
                                objUserPrivacySettings.UPS_ANYONE = false;

                            }
                            objUserPrivacySettings.ProcedureType = "I";
                            retval1 = privacySettingDAO.InserttblUserPrivacySetting(objUserPrivacySettings);
                        }
                    }



                    Session["registering_Id"] = resReturned;
                    Session["register_success"] = "Thank you for registering with us. You will be recieving an email shortly !";
                    objGeneric.SendMail(ObjRegisterUserBAO.LoginEmail, "Hi "+"&nbsp;" + txtName.Text.Trim() + "," + "<br /><br />" + "Thanks for joining Vitality.We’re excited to have you try out our Beta version." +
                        "<br /><br />" + "Your login email :" + "&nbsp;" + ObjRegisterUserBAO.LoginEmail + "&nbsp;" + " and your password :" + "&nbsp;" + createPwd + "<br /><br />" + "Improving your health and the health of your community of loved ones is very" + " <br />" +
                        "important to us. We’ve tried to develop an easy-to-use and smart tool, but that’s"+" <br />"+
                        "really for you to judge. Your input is critical to how we continue to build and adjust"+" <br />"+
                        " Vitality. Please never hesitate to be open and honest, and in return we will"+" <br />"+
                        "make sure to incorporate feedback and fixes as quickly as possible."+" <br /><br/>"+
                        "We’re excited to be a part of your journey for better health! "+" <br /><br />"+
                        "Let’s get started: Click Here to visit" + "&nbsp;" + "http://alerevitality.com/" + "&nbsp;" + " now!"
                        + " <br /><br />" + "With Support and Respect,"+"<br />"+
                       
                        "The Vitality Team", "Vitality : Registration");
                    if (!string.IsNullOrEmpty(Request.QueryString["val"]))
                    {
                        DataTable dt1 = new DataTable();
                        ObjRegisterUserBAO.ID = id;
                        ObjRegisterUserBAO.procedureType = "SG";
                        dt1 = RegisterUserDAO.GetInvitationDetail(ObjRegisterUserBAO);
                        if (dt1.Rows.Count > 0)
                        {
                            int retval2 = 0;
                            ObjRegisterUserBAO.UI_ID = id;
                            ObjRegisterUserBAO.fk_user_registration_id = 1;
                            ObjRegisterUserBAO.UI_USER_MAIL_ID = txtEmail.Text.Trim();
                            ObjRegisterUserBAO.UI_STATUS = "True";
                            ObjRegisterUserBAO.UI_CODE = 1;
                            ObjRegisterUserBAO.UI_DATE = dt1.Rows[0]["UI_DATE"].ToString();
                            ObjRegisterUserBAO.UI_MAIL_STATUS = "Successfull";
                            ObjRegisterUserBAO.procedureType = "U";
                            retval2 = RegisterUserDAO.UpdatetblUserInvitation(ObjRegisterUserBAO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resReturned;
        }



        // Register Now//

        protected void Button1_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (Page.IsValid)
                {
                    DataTable dt = new DataTable();
                    ObjRegisterUserBAO.LoginEmail = txtEmail.Text;
                    ObjRegisterUserBAO.procedureType = "S";
                    dt = RegisterUserDAO.GetEmailDetail(ObjRegisterUserBAO);
                    if (dt.Rows.Count > 0)
                    {
                        lblMessage.Text = "This email id has already been taken !";
                    }
                    else
                    {

                        Int32 resultOutput = SubmitDetails(true);

                        if (resultOutput == 0)
                        {
                            lblMessage.Text = "This email id has already been taken !";
                        }
                        else
                        {
                            Response.Redirect("~/RegistrationThanks.aspx", false);
                        }

                    }

                    txtEmail.Text = "";
                    txtHeight.Text = "";
                    txtName.Text = "";
                    txtLname.Text = "";
                    txtWeight.Text = "";
                    txtheightInches.Text = "";
                    DrpDAy.SelectedIndex = 0;
                    drpMonth.SelectedIndex = 0;
                    drpYear.SelectedIndex = 0;


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void drpYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int year = DateTime.Now.Year;
                int value = Convert.ToInt32(drpYear.SelectedValue);

                int year1 = year - 16;
                if (value > year)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Future Year cannot be selected');", true);
                    drpYear.SelectedIndex = 0;
                    return;
                }
                else if (year == value || value > year1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('Age cannot be less than 16 years.');", true);
                    drpYear.SelectedIndex = 0;
                    return;
                }
                else if (value < year1 || value == year1)
                {
                    hdndate.Value = drpYear.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            Session["sure"] =true;
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            Response.Redirect("Login.aspx", false);
        }

        protected void DrpHeightUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (drpUserHeightOptions.SelectedValue == "3")
                {
                    txtHeight.Style.Add("width", "54px");
                    txt_inches.Visible = true;
                    ddl_inches.Visible = true;
                    ddlH_UnitInches.SelectedValue = "1";
                    //                  txtheightInches.Text = "0";

                }
                else
                {
                    txtHeight.Style.Add("width", "190px");

                    txt_inches.Visible = false;
                    ddl_inches.Visible = false;
                    ddlH_UnitInches.SelectedValue = "1";

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void txtHeight_TextChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (txtHeight.Text == "0")
                {
                    drpUserHeightOptions.SelectedValue = "0";
                }
                else
                {
                    drpUserHeightOptions.SelectedValue = "3";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    
    }
}
