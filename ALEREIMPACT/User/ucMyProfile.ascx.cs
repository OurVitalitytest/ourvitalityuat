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
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
using System.Threading;
using System.IO;
using System.Text;
namespace ALEREIMPACT.User
{
    public partial class ucMyProfile : System.Web.UI.UserControl
    {  UserCirclesBAO objusercircles = new UserCirclesBAO();
        UserCirclesBAO objUserCircleBAO = new UserCirclesBAO();
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        PagedDataSource pagedatasourceCircle;
        PagedDataSource pagedatasourceMission;
        public static string cirlce_Color = string.Empty;
        public static string circleimage = string.Empty;
        ClsGeneric objClsGeneric = new ClsGeneric();
        SQLHelper ObjSqlHelper = new SQLHelper();
        int posCircle;
        int posMission;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    BindDrpDowns();
                    int currentyear = DateTime.Now.Year;
                    for (int year = currentyear; year >= 1900; year--)
                    {
                        drpYear.Items.Add(year.ToString());
                    }

                    for (int i = 1; i <= 31; i++)
                    {
                        DrpDAy.Items.Add(i.ToString());
                    }

                    DrpDAy.SelectedValue = "0";


                    DrpMonth.SelectedValue = "0";
                    drpYear.SelectedValue = "0";
                         
                    //BindLocations();
                    getProfile();

                    this.ViewState["vsCircle"] = 0;
                    this.ViewState["vsMission"] = 0;
                }
                posCircle = (int)this.ViewState["vsCircle"];
                posMission = (int)this.ViewState["vsMission"];

                BindCircle();
                BindMission();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void BindDrpDowns()
        {
            DataTable dtLoctaion = new DataTable();
            dtLoctaion = RegisterUserDAO.GetAllLocations();
            DrpLocation.DataSource = dtLoctaion;
            DrpLocation.DataTextField = "LocationName";
            DrpLocation.DataValueField = "LocationId";
            DrpLocation.DataBind();
            ObjSqlHelper.fillDrpControl(DrpRelation, "spFillDrpDown", "RS_NAME", "RS_ID", "RS");
            ObjSqlHelper.fillDrpControl(DrpReligion, "spFillDrpDown", "RELIGION_NAME", "RELIGION_ID", "RM");
            ObjSqlHelper.fillDrpControl(DrpWorkPlace, "spFillDrpDown", "WP_NAME", "WP_ID", "WPM");
            ObjSqlHelper.fillDrpControl(DrpEducation, "spFillDrpDown", "EDU_NAME", "EDU_ID", "EM1");
            ObjSqlHelper.fillDrpControl(DrpInterrest, "spFillDrpDown", "INTEREST_NAME", "INTEREST_ID", "IRM");

        }

        private void getProfile()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["user_image"].ToString() == "" || dt.Rows[0]["user_image"].ToString() == null)
                        {
                            imgProfile.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";
                            
                        }
                        else
                        {
                            imgProfile.ImageUrl = "~/User/profile_image/" + dt.Rows[0]["user_image"].ToString();
                        }
                        lbUserName.Text = dt.Rows[0]["name"].ToString();
                        DataTable dtEmail = new DataTable();
                        objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                        objUserCircleBAO.proceduretype = "GE1";
                        dtEmail = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                        if (dtEmail.Rows.Count > 0)
                        {
                            lbEmail.Visible = true;
                            lbEmail.Text = dt.Rows[0]["login_email"].ToString();
                        }
                        else
                        {
                            lbEmail.Visible = false;
                        }
                        //lbEmail.Text = dt.Rows[0]["login_email"].ToString();
                        if (dt.Rows[0]["dateOfBirth"].ToString() == "0" && dt.Rows[0]["monthOfBirth"].ToString() == "0" && dt.Rows[0]["yearOfBirth"].ToString() == "0")
                        {
                            //dvlbDOB.Style.Add("display", "none");
                           // ImgBtnDOBEdit.Visible = false;
                            //dvDOB.Style.Add("display", "");
                           
                           
                            
                          
                            lbDOB.Text = "--Not Specified--";
                        }
                        else
                        {
                            lbDOB.Text = dt.Rows[0]["monthOfBirth1"].ToString() + " " + dt.Rows[0]["dateOfBirth"].ToString() + ", " + dt.Rows[0]["yearOfBirth"].ToString();
                        }
                        DrpGender.SelectedValue = (dt.Rows[0]["gender"].ToString());
                        txtHeight.Text = (dt.Rows[0]["height"].ToString()).Replace(".00", "");
                        DrpHeightUnit.SelectedValue = (dt.Rows[0]["height_units"].ToString());
                        if (DrpHeightUnit.SelectedValue == "3")
                        {
                           // pnlInches.Visible = true;
                            txtheightInches.Visible = true;
                            txtheightInches.Text = (dt.Rows[0]["height_inches"].ToString());
                            incheslength.Style.Value = "display:block;";
                            unitofheight.Text = "ft.";
                            //DrpInches.SelectedValue = "2";
                        }
                        else
                        {
                            incheslength.Style.Value = "display:none;";
                            unitofheight.Text = "cms";
                           
                            //pnlInches.Visible = false;
                        }
                        txtWeight.Text = (dt.Rows[0]["weight"].ToString());
                        DrpWeightUnit.SelectedValue = (dt.Rows[0]["weight_units"].ToString());
                       DrpLocation.SelectedValue = (dt.Rows[0]["fk_location_id"].ToString());
                        if (dt.Rows[0]["Replationship"].ToString() == "0" || dt.Rows[0]["Replationship"].ToString() == "")
                        {
                            DrpRelation.SelectedValue = "0";
                        }
                        else
                        {
                            DrpRelation.SelectedValue = Convert.ToString(dt.Rows[0]["Replationship"]);
                        }
                        if (dt.Rows[0]["Workplace"].ToString() == "0" || dt.Rows[0]["Workplace"].ToString() == "")
                        {
                            DrpWorkPlace.SelectedValue = "0";
                        }
                        else
                        {
                            DrpWorkPlace.SelectedValue = Convert.ToString(dt.Rows[0]["Workplace"]);
                        }
                        if (dt.Rows[0]["Religion"].ToString() == "0" || dt.Rows[0]["Religion"].ToString() == "")
                        {
                            DrpReligion.SelectedValue = "0";
                        }
                        else
                        {
                            DrpReligion.SelectedValue = Convert.ToString(dt.Rows[0]["Religion"]);
                        }
                        if (dt.Rows[0]["Interest"].ToString() == "0" || dt.Rows[0]["Interest"].ToString() == "")
                        {
                            DrpInterrest.SelectedValue = "0";
                        }
                        else
                        {
                            DrpInterrest.SelectedValue = Convert.ToString(dt.Rows[0]["Interest"]);
                        }
                        if (dt.Rows[0]["Education"].ToString() == "0" || dt.Rows[0]["Education"].ToString() == "")
                        {
                            DrpEducation.SelectedValue = "0";
                        }
                        else
                        {
                  DrpEducation.SelectedValue = Convert.ToString(dt.Rows[0]["Education"]);
                            
                        }

                    }
                }

                DataTable dtFreinds = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MF";
                dtFreinds = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dtFreinds.Rows.Count > 0)
                {
                    GrdFreinds.DataSource = dtFreinds;
                    GrdFreinds.DataBind();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void BindCircle()
        {
           
            try
            {
                DataTable dtCircle = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MC";
                dtCircle = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dtCircle.Rows.Count > 0)
                {
                    if (dtCircle.Rows.Count < 9)
                    {
                        circlepaging.Visible = false;
                    }
                    else
                    {
                        circlepaging.Visible = true;
                    }
                    pagedatasourceCircle = new PagedDataSource();
                    pagedatasourceCircle.DataSource = dtCircle.DefaultView;
                    pagedatasourceCircle.PageSize = 8;
                    pagedatasourceCircle.AllowPaging = true;
                    pagedatasourceCircle.CurrentPageIndex = posCircle;
                    btnfirst.Enabled = !pagedatasourceCircle.IsFirstPage;
                    btnprevious.Enabled = !pagedatasourceCircle.IsFirstPage;
                    btnlast.Enabled = !pagedatasourceCircle.IsLastPage;
                    btnnext.Enabled = !pagedatasourceCircle.IsLastPage;
                    dlcirclelist.DataSource = pagedatasourceCircle;
                    dlcirclelist.DataBind();
                }
                else
                {
                    circlepaging.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFreinds_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnImahge = (HiddenField)e.Row.FindControl("hdnImahge");
                    ImageButton ImgFreind = (ImageButton)e.Row.FindControl("ImgFreind");
                    Label lbID=(Label)e.Row.FindControl("lbID");
                    if (hdnImahge.Value == "" || hdnImahge.Value == null)
                    {
                        ImgFreind.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";
                    }
                    else
                    {
                        if (MySession.Current.LoginId == Convert.ToString(lbID.Text))
                        {
                            ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImahge.Value;
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objUserCircleBAO.ID = Convert.ToInt32(lbID.Text);
                            objUserCircleBAO.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    ImgFreind.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImahge.Value;
                                }
                                else if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImahge.Value;
                                }

                            }
                            else
                            {
                                ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImahge.Value;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void dlcirclelist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdnColor = (HiddenField)e.Item.FindControl("hdnColor");
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    HtmlGenericControl divCircle = (HtmlGenericControl)e.Item.FindControl("divCircle");
                    HtmlGenericControl divHoverColor = (HtmlGenericControl)e.Item.FindControl("divHoverColor");
                    divCircle.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                    divHoverColor.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void imgProfile_Click(object sender, EventArgs e)
        {
            PnlInspirator_ModalPopupExtender.Show();
        }
        protected void btnfirst_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                posCircle = 0;
                this.ViewState["vsCircle"] = posCircle;
                BindCircle();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                posCircle = (int)this.ViewState["vsCircle"];
                posCircle -= 1;
                this.ViewState["vsCircle"] = posCircle;
                BindCircle();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                posCircle = (int)this.ViewState["vsCircle"];
                posCircle += 1;
                this.ViewState["vsCircle"] = posCircle;
                BindCircle();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnlast_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (pagedatasourceCircle != null)
                {
                    posCircle = pagedatasourceCircle.PageCount - 1;
                    this.ViewState["vsCircle"] = posCircle;
                }
                BindCircle();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void BindMission()
        {
            try
            {
                DataTable dtMission = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MM1";
                dtMission = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dtMission.Rows.Count > 0)
                {
                    if (dtMission.Rows.Count > 5)
                    {
                        no_of_mission.Visible =true;
                    }
                    else
                    {
                        no_of_mission.Visible = false;
                    }
                    btnfirst1.Visible = true;
                    btnprevious1.Visible = true;
                    btnlast1.Visible = true;
                    btnnext1.Visible = true;
                    lbNoMission.Visible = false;
                    pagedatasourceMission = new PagedDataSource();
                    pagedatasourceMission.DataSource = dtMission.DefaultView;
                    pagedatasourceMission.PageSize = 5;
                    pagedatasourceMission.AllowPaging = true;
                    pagedatasourceMission.CurrentPageIndex = posMission;
                    btnfirst1.Enabled = !pagedatasourceMission.IsFirstPage;
                    btnprevious1.Enabled = !pagedatasourceMission.IsFirstPage;
                    btnlast1.Enabled = !pagedatasourceMission.IsLastPage;
                    btnnext1.Enabled = !pagedatasourceMission.IsLastPage;
                    dlMissions.DataSource = pagedatasourceMission;
                    dlMissions.DataBind();
                }
                else
                {
                    lbNoMission.Visible = true;
                    btnfirst1.Visible = false;
                    btnprevious1.Visible = false;
                    btnlast1.Visible = false;
                    btnnext1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnfirst1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                posMission = 0;
                this.ViewState["vsMission"] = posMission;
                BindMission();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnprevious1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                posMission = (int)this.ViewState["vsMission"];
                posMission -= 1;
                this.ViewState["vsMission"] = posMission;
                BindMission();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnnext1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                posMission = (int)this.ViewState["vsMission"];
                posMission += 1;
                this.ViewState["vsMission"] = posMission;
                BindMission();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnlast1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                posMission = pagedatasourceMission.PageCount - 1;
                this.ViewState["vsMission"] = posMission;
                BindMission();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnDOBEdit_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                //   ImgBtnDOBEdit.OnClientClick = "ImgBtnDOBEdit_Click();return false;";
                dvlbDOB.Style.Add("display", "none");
                ImgBtnDOBEdit.Visible = false;
                dvDOB.Style.Add("display", "");

                //int currentyear = DateTime.Now.Year;
                //for (int year = currentyear; year >= 1900; year--)
                //{
                //    drpYear.Items.Add(year.ToString());
                //}

                //for (int i = 1; i <= 31; i++)
                //{
                //    DrpDAy.Items.Add(i.ToString());
                //}

                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["dateOfBirth"].ToString() == "0")
                    {
                        DrpDAy.SelectedValue = "0";
                    }
                    else
                    {
                        DrpDAy.SelectedValue = dt.Rows[0]["dateOfBirth"].ToString();
                    }
                    if (dt.Rows[0]["monthOfBirth"].ToString() == "0")
                    {
                        DrpMonth.SelectedValue = "0";
                    }
                    else
                    {
                        DrpMonth.SelectedValue = dt.Rows[0]["monthOfBirth"].ToString();
                    }
                    if (dt.Rows[0]["yearOfBirth"].ToString() != "0")
                    {
                        drpYear.SelectedValue = dt.Rows[0]["yearOfBirth"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void updateDOB()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(DrpDAy.SelectedValue);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(DrpMonth.SelectedValue);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(drpYear.SelectedValue);

                        if (dt.Rows[0]["weight"] != DBNull.Value)
                        {

                            objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        }
                        if (dt.Rows[0]["fk_location_id"] != DBNull.Value)
                        {
                            objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        }
                        if (dt.Rows[0]["height"] != DBNull.Value)
                        {
                            objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        }
                        if (dt.Rows[0]["height_units"] != DBNull.Value)
                        {
                            objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        }
                        if (dt.Rows[0]["height_inches"] != DBNull.Value)
                        {
                            objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        }
                        if (dt.Rows[0]["weight_units"] != DBNull.Value)
                        {
                            objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        }
                        if(dt.Rows[0]["gender"]!=DBNull.Value)
                        {
                        objUserRegisterBAO.Gender = (dt.Rows[0]["gender"].ToString());
                        }
                        if (dt.Rows[0]["Replationship"] != DBNull.Value)
                        {
                            objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        }
                        if (dt.Rows[0]["Workplace"] != DBNull.Value)
                        {
                            objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        }
                        if (dt.Rows[0]["Religion"] != DBNull.Value)
                        {
                            objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);
                        }
                        if (dt.Rows[0]["Interest"] != DBNull.Value)
                        {
                            objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        }
                        if (dt.Rows[0]["Education"] != DBNull.Value)
                        {
                            objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        }
                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnDOBUpdate_Click(object sender, ImageClickEventArgs e)
        {
            if (!Page.IsValid)
                return;
            ClsGeneric.ReplaceCookie();
            try
            {
               

                    updateDOB();
                    getProfile();
                    dvDOB.Style.Add("display", "none");
                    dvlbDOB.Style.Add("display", "");
                    ImgBtnDOBEdit.Visible = true;
               
               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void imgBtnDOBCancel_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                dvDOB.Style.Add("display", "none");
                dvlbDOB.Style.Add("display", "");
                ImgBtnDOBEdit.Visible = true;
                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
         }

        protected void ImgBtnGenderEdit_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpGender.Enabled = true;
                ImgBtnGenderCancel.Visible = true;
                ImgBtnGenderUpdate.Visible = true;
                ImgBtnGenderEdit.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnGenderUpdate_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateGender();
                getProfile();
                DrpGender.Enabled = false;
                ImgBtnGenderCancel.Visible = false;
                ImgBtnGenderUpdate.Visible = false;
                ImgBtnGenderEdit.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnGenderCancel_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                DrpGender.Enabled = false;
                ImgBtnGenderCancel.Visible = false;
                ImgBtnGenderUpdate.Visible = false;
                ImgBtnGenderEdit.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void updateGender()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        objUserRegisterBAO.Gender = DrpGender.SelectedValue;
                        objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);

                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void updateHeight()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        if (txtHeight.Text != "")
                        {
                            objUserRegisterBAO.Height = Convert.ToDecimal(txtHeight.Text);
                        }
                        else
                        {
                            objUserRegisterBAO.Height = 0;
                        }
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(DrpHeightUnit.SelectedValue);
                        if (DrpHeightUnit.SelectedValue == "3")
                        {
                            objUserRegisterBAO.HeightInches = Convert.ToInt32(txtheightInches.Text);
                        }
                        else
                        {
                            objUserRegisterBAO.HeightInches = 0;
                        }

                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        objUserRegisterBAO.Gender = (dt.Rows[0]["gender"].ToString());
                        objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);
                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void updateWeight()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        if (txtWeight.Text != "")
                        {
                            objUserRegisterBAO.Weight = Convert.ToInt32(txtWeight.Text);
                        }
                        else
                        {
                            objUserRegisterBAO.Weight = 0;
                        }
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(DrpWeightUnit.SelectedValue);
                        objUserRegisterBAO.Gender = (dt.Rows[0]["gender"].ToString());
                        objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);
                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void updateLocation()
        {
            DataTable dt = new DataTable();
            objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
            objUserCircleBAO.proceduretype = "MP";
            dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    int retval = 0;
                    objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                    objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                    objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                    objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                    objUserRegisterBAO.LocationId = Convert.ToInt32(DrpLocation.SelectedValue);
                    objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                    objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                    objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                    objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                    objUserRegisterBAO.Gender = (dt.Rows[0]["gender"].ToString());
                    objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                    objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                    objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                    objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                    objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);
                    objUserRegisterBAO.procedureType = "U";
                    retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                }
            }
        }
        protected void ImgBtnHeightEdit_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                txtHeight.ReadOnly = false;
                txtheightInches.ReadOnly = false;
                DrpHeightUnit.Enabled = true;
                ImgBtnHeightUpdate.Visible = true;
                ImgBtnHeightCancel.Visible = true;
                ImgBtnHeightEdit.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void DrpHeightUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (DrpHeightUnit.SelectedValue == "3")
                {
                    //pnlInches.Visible = true;
                    txtheightInches.Visible = true;
                    txtheightInches.Enabled = true;
                    //DrpInches.Enabled = true;
                }
                else
                {
                    //pnlInches.Visible = false;
                    txtheightInches.Visible = false;
                   // DrpInches.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnHeightUpdate_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateHeight();
                getProfile();
                txtHeight.ReadOnly = true;
                DrpHeightUnit.Enabled = false;
                txtheightInches.ReadOnly = true;
                //DrpInches.Enabled = false;
                ImgBtnHeightUpdate.Visible = false;
                ImgBtnHeightCancel.Visible = false;
                ImgBtnHeightEdit.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnHeightCancel_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                txtHeight.ReadOnly = true;
                DrpHeightUnit.Enabled = false;
                ImgBtnHeightUpdate.Visible = false;
                ImgBtnHeightCancel.Visible = false;
                ImgBtnHeightEdit.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnWeightEdit_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                txtWeight.ReadOnly = false;
                DrpWeightUnit.Enabled = true;
                ImgBtnWeightUpdate.Visible = true;
                ImgBtnWeightCancel.Visible = true;
                ImgBtnWeightEdit.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void ImgBtnWeightUpdate_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateWeight();
                getProfile();
                txtWeight.ReadOnly = true;
                DrpWeightUnit.Enabled = false;
                ImgBtnWeightUpdate.Visible = false;
                ImgBtnWeightCancel.Visible = false;
                ImgBtnWeightEdit.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnWeightCancel_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                txtWeight.ReadOnly = true;
                DrpWeightUnit.Enabled = false;
                ImgBtnWeightUpdate.Visible = false;
                ImgBtnWeightCancel.Visible = false;
                ImgBtnWeightEdit.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkPrivacy_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["Privacy"] = "True";
                Response.Redirect("FeedBackAndProblem.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //protected void ImgBtnLocationEdit_Click(object sender, ImageClickEventArgs e)
        //{
        //    DrpLocation.Enabled = true;
        //    ImgBtnLocationUpdate.Visible = true;
        //    ImgBtnLocationCancel.Visible = true;
        //    ImgBtnLocationEdit.Visible = false;
        //}

        //protected void ImgBtnLocationUpdate_Click(object sender, ImageClickEventArgs e)
        //{
        //    updateLocation();
        //    getProfile();
        //    DrpLocation.Enabled = false;
        //    ImgBtnLocationUpdate.Visible = false;
        //    ImgBtnLocationCancel.Visible = false;
        //    ImgBtnLocationEdit.Visible = true;
        //}
        //protected void ImgBtnLocationCancel_Click(object sender, ImageClickEventArgs e)
        //{
        //    getProfile();
        //    DrpLocation.Enabled = false;
        //    ImgBtnLocationUpdate.Visible = false;
        //    ImgBtnLocationCancel.Visible = false;
        //    ImgBtnLocationEdit.Visible = true;
        //}


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            string circleimagefile = "";
            string profileimagefile = "";
            try
            {
             string filename=   fuProfileImage.PostedFile.FileName;
                if (fuProfileImage.HasFile)
                {
                    if (objClsGeneric.checkRealFile(((FileUpload)fuProfileImage)) == true)
                    {
                        Int32 filesize = fuProfileImage.PostedFile.ContentLength;
                        if (filesize < 1048576)
                        {
                            DataTable dtColor = new DataTable();
                            objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objUserCircleBAO.proceduretype = "GC2";
                            dtColor = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                            if (dtColor.Rows.Count > 0)
                            {
                                Session["circlecolor"] = dtColor.Rows[0]["circle_color"].ToString();
                                string extension = System.IO.Path.GetExtension(fuProfileImage.PostedFile.FileName);
                                circleimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "InnerCircle" + extension;
                                profileimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "ProfilePhoto" + extension;
                                fuProfileImage.PostedFile.SaveAs(MapPath("~") + "/User/CircleImages/" + circleimagefile);
                                fuProfileImage.PostedFile.SaveAs(MapPath("~") + "/User/profile_image/" + profileimagefile);
                                objUserCircleBAO.circle_color = Convert.ToString(Session["circlecolor"]);
                                objUserCircleBAO.circle_name = profileimagefile;
                                objUserCircleBAO.circle_image = circleimagefile;
                                objUserCircleBAO.fk_circle_permission_id = 1;
                                objUserCircleBAO.fk_circle_id = 1;
                                objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                                objUserCircleBAO.proceduretype = "U";
                                Int32 newcircleId = 0;
                                newcircleId = UserCirclesDAO.AddNewCircle(objUserCircleBAO);


                                string extension1 = System.IO.Path.GetExtension(fuProfileImage.PostedFile.FileName);
                                circleimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "InnerCircle" + extension1;
                                profileimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + "ProfilePhoto" + extension1;
                                fuProfileImage.PostedFile.SaveAs(MapPath("~") + "/User/CircleImages/" + circleimagefile);
                                fuProfileImage.PostedFile.SaveAs(MapPath("~") + "/User/profile_image/" + profileimagefile);


                                objUserCircleBAO.circle_color = Convert.ToString(Session["circlecolor"]);

                                objUserCircleBAO.circle_name = profileimagefile;
                                objUserCircleBAO.circle_image = circleimagefile;
                                objUserCircleBAO.fk_circle_permission_id = 1;
                                objUserCircleBAO.fk_circle_id = 1;
                                objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                                objUserCircleBAO.proceduretype = "U1";
                                Int32 newcircleId1 = 0;
                                newcircleId1 = UserCirclesDAO.AddNewCircle(objUserCircleBAO);
                            }
                        }
                        else
                        {
                            
                            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Image Size should be less than 100Kb');", true);
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Upload image in (jpg or jpeg or png or gif ) format');", true);
                    }
               
                }
                Response.Redirect("~/User/MyProfile.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void GrdFreinds_RowCommand(object sender, GridViewCommandEventArgs  e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "ImgBtnFrnd")
                {
                    string id = e.CommandArgument.ToString();
                    if (MySession.Current.LoginId == Convert.ToString(id))
                    {

                    }
                    else
                    {
                        Session["USerProfile"] = true;
                    }
                    Response.Redirect("~/User/MyProfile.aspx?val=" + id, false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void dlMissions_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "LnkMission")
                {
                    string id = e.CommandArgument.ToString();
                    System.Threading.Thread.Sleep(1000);
                    Session["track_mission_graphs"] = "True";
                    Session["selected_mission_id"] = Convert.ToInt32(id);
                    Response.Redirect("~/User/Missions.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void dlcirclelist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkView")
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(';');
                    string userID = arg[0];
                    string CircleiD = arg[1];
                    string circlename = arg[2];
                    Int32 userid = Convert.ToInt32(userID);
                  Int32  circleid = Convert.ToInt32(CircleiD);
                   // MySession.Current.PublicCircleUserId = Convert.ToString(userid);
                   // MySession.Current.PublicCircleId = Convert.ToString(circleid);
                    //Session["USerProfile"] = true;
                  MySession.Current.SelectedCircleName = circlename;
                    MySession.Current.CircleId = CircleiD;
                    Session["selectedcircleid"] =userid + "-" + circleid;
                    Session["Topselcircle"] = circleid;
                    Session["NewcircleId"] = circleid;
                   Session["Notes"] = true;
                    Session["Circle"] = true;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);
                   
                }
                else if (e.CommandName == "openpopup")
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(';');
                    string userID = arg[0];
                    string CircleiD = arg[1];
                    string circlename = arg[2];
                    string circlecolor = arg[3];
                     circleimage = arg[4];
                    Int32 userid = Convert.ToInt32(userID);
                    Int32 circleid = Convert.ToInt32(CircleiD);
                    // MySession.Current.PublicCircleUserId = Convert.ToString(userid);
                    // MySession.Current.PublicCircleId = Convert.ToString(circleid);
                    //Session["USerProfile"] = true;
                    MySession.Current.SelectedCircleName = circlename;
                    MySession.Current.CircleId = CircleiD;
                    cirlce_Color = circlecolor;
                 
                    txtcirclecolor.Text = circlecolor;
                    Session["selectedcircleid"] = userid + "-" + circleid;
                    Session["Topselcircle"] = circleid;
                    Session["NewcircleId"] = circleid;
                    Session["Notes"] = true;
                    Session["Circle"] = true;
                    this.mpeeditcircle.Show();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void btncreatecircle_Click(object sender, EventArgs e)
        {

            ClsGeneric.ReplaceCookie();

            // PnlCircle.Visible = true;
            string circleimagefile = "";
            try
            {


                if (fucircleimage.HasFile)
                {
                    Int32 filesize = fucircleimage.PostedFile.ContentLength;

                   
                        string extension = System.IO.Path.GetExtension(fucircleimage.PostedFile.FileName);

                        circleimagefile = Convert.ToInt32(MySession.Current.LoginId) + "_" + MySession.Current.SelectedCircleName + extension;

                        string filepath = Server.MapPath("~/user/circleimages");
                        fucircleimage.PostedFile.SaveAs(filepath + "\\" + circleimagefile);


                   


                }
             
                    MySession.Current.PublicCircleUserId = "";
                    MySession.Current.PublicCircleUserId = "";

                    if (txtcirclecolor.Text == "")
                    {
                        objusercircles.circle_color = cirlce_Color;
                    }
                    else
                    {
                        objusercircles.circle_color = txtcirclecolor.Text;
                    }
                    objusercircles.circle_create_date = Convert.ToString(DateTime.Now);
                    if (fucircleimage.HasFile)
                    {
                        objusercircles.circle_image = circleimagefile;
                    }
                    else
                    {
                        objusercircles.circle_image = circleimage;
                    }
                    objusercircles.fk_circle_id = MySession.Current.CircleId;
                    
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.proceduretype = "UP";
                    Int32 newcircleId = 0;
                    newcircleId = UserCirclesDAO.AddNewCircle(objusercircles);
                    MySession.Current.SelectedCircleUserId = Convert.ToInt32(MySession.Current.LoginId).ToString();
                    MySession.Current.CircleId = Convert.ToInt32(newcircleId).ToString();
                    Session["NewcircleId"] = MySession.Current.CircleId;
                    string cid = MySession.Current.SelectedCircleUserId + "-" + MySession.Current.CircleId;
                    (Session["selectedcircleid"]) = cid;
                    
                    MySession.Current.SelectedCircleName = "";
                  
                    Response.Redirect("~/User/MyProfile.aspx", false);

                   
                
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
        }

        protected void ImgBtnEdit_Relation_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpRelation.Enabled = true;
                ImgBtnCancel_Relation.Visible = true;
                ImgBtnUpdate_Relation.Visible = true;
                ImgBtnEdit_Relation.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnEdit_Religion_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                 DrpReligion.Enabled = true;
                ImgBtnCancel_Religion.Visible = true;
                ImgBtnUpdate_Religion.Visible = true;
                ImgBtnEdit_Religion.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnEdit_Education_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpEducation.Enabled = true;
                ImgBtnCancel_Education.Visible = true;
                ImgBtnUpdate_Education.Visible = true;
                ImgBtnEdit_Education.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnEdit_WorkPlace_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpWorkPlace.Enabled = true;
                ImgBtnCancel_WorkPlace.Visible = true;
                ImgBtnUpdate_WorkPlace.Visible = true;
                ImgBtnEdit_WorkPlace.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnEdit_Interest_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpInterrest.Enabled = true;
                ImgBtnCancel_Interest.Visible = true;
                ImgBtnUpdate_Interest.Visible = true;
                ImgBtnEdit_Interest.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnEdit_Location_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.Enabled = true;
                ImgBtnCancel_Location.Visible = true;
                ImgBtnUpdate_Location.Visible = true;
                ImgBtnEdit_Location.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        protected void ImgBtnCancel_Relation_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                DrpRelation.Enabled = false;
                ImgBtnUpdate_Relation.Visible = false;
                ImgBtnCancel_Relation.Visible = false;
                ImgBtnEdit_Relation.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnCancel_Religion_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                DrpReligion.Enabled = false;
                ImgBtnUpdate_Religion.Visible = false;
                ImgBtnCancel_Religion.Visible = false;
                ImgBtnEdit_Religion.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnCancel_Education_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                DrpEducation.Enabled = false;
                ImgBtnUpdate_Education.Visible = false;
                ImgBtnCancel_Education.Visible = false;
                ImgBtnEdit_Education.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnCancel_WorkPlace_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                DrpWorkPlace.Enabled = false;
                ImgBtnUpdate_WorkPlace.Visible = false;
                ImgBtnCancel_WorkPlace.Visible = false;
                ImgBtnEdit_WorkPlace.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnCancel_Interest_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                DrpInterrest.Enabled = false;
                ImgBtnUpdate_Interest.Visible = false;
                ImgBtnCancel_Interest.Visible = false;
                ImgBtnEdit_Interest.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnCancel_Location_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                getProfile();
                DrpLocation.Enabled = false;
                ImgBtnUpdate_Location.Visible = false;
                ImgBtnCancel_Location.Visible = false;
                ImgBtnEdit_Location.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void updateRelation()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        objUserRegisterBAO.Gender = Convert.ToString(dt.Rows[0]["gender"]);
                        objUserRegisterBAO.RS_ID_FK = DrpRelation.SelectedValue;
                        objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);

                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void updateReligion()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        objUserRegisterBAO.Gender = Convert.ToString(dt.Rows[0]["gender"]);
                        objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        objUserRegisterBAO.RELIGION_ID_FK = DrpReligion.SelectedValue;

                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void updateWorkPlace()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        objUserRegisterBAO.Gender = Convert.ToString(dt.Rows[0]["gender"]);
                        objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        objUserRegisterBAO.WP_ID_FK = DrpWorkPlace.SelectedValue;
                        objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);

                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void updateInterest()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        objUserRegisterBAO.Gender = Convert.ToString(dt.Rows[0]["gender"]);
                        objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        objUserRegisterBAO.EDU_ID_FK = Convert.ToString(dt.Rows[0]["Education"]);
                        objUserRegisterBAO.INTEREST_ID_FK = DrpInterrest.SelectedValue;
                        objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);

                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void updateEducation()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.proceduretype = "MP";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        int retval = 0;
                        objUserRegisterBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserRegisterBAO.DateOfBirth = Convert.ToInt32(dt.Rows[0]["dateOfBirth"]);
                        objUserRegisterBAO.MonthOfBirth = Convert.ToInt32(dt.Rows[0]["monthOfBirth"]);
                        objUserRegisterBAO.YearOfBirth = Convert.ToInt32(dt.Rows[0]["yearOfBirth"]);
                        objUserRegisterBAO.Weight = Convert.ToInt32(dt.Rows[0]["weight"]);
                        objUserRegisterBAO.LocationId = Convert.ToInt32(dt.Rows[0]["fk_location_id"]);
                        objUserRegisterBAO.Height = Convert.ToDecimal(dt.Rows[0]["height"]);
                        objUserRegisterBAO.HeightUnits = Convert.ToInt32(dt.Rows[0]["height_units"]);
                        objUserRegisterBAO.HeightInches = Convert.ToInt32(dt.Rows[0]["height_inches"]);
                        objUserRegisterBAO.WeightUnits = Convert.ToInt32(dt.Rows[0]["weight_units"]);
                        objUserRegisterBAO.Gender = Convert.ToString(dt.Rows[0]["gender"]);
                        objUserRegisterBAO.RS_ID_FK = Convert.ToString(dt.Rows[0]["Replationship"]);
                        objUserRegisterBAO.WP_ID_FK = Convert.ToString(dt.Rows[0]["Workplace"]);
                        objUserRegisterBAO.EDU_ID_FK = DrpEducation.SelectedValue;
                        objUserRegisterBAO.INTEREST_ID_FK = Convert.ToString(dt.Rows[0]["Interest"]);
                        objUserRegisterBAO.RELIGION_ID_FK = Convert.ToString(dt.Rows[0]["Religion"]);

                        objUserRegisterBAO.procedureType = "U";
                        retval = RegisterUserDAO.UpdateMyProfile(objUserRegisterBAO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void ImgBtnUpdate_Relation_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateRelation();
                getProfile();
                DrpRelation.Enabled = false;
                ImgBtnUpdate_Relation.Visible = false;
                ImgBtnCancel_Relation.Visible = false;
                ImgBtnEdit_Relation.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnUpdate_Religion_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateReligion();
                getProfile();
                DrpReligion.Enabled = false;
                ImgBtnUpdate_Religion.Visible = false;
                ImgBtnCancel_Religion.Visible = false;
                ImgBtnEdit_Religion.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnUpdate_Education_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateEducation();
                getProfile();
                DrpEducation.Enabled = false;
                ImgBtnUpdate_Education.Visible = false;
                ImgBtnCancel_Education.Visible = false;
                ImgBtnEdit_Education.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnUpdate_WorkPlace_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateWorkPlace();
                getProfile();
                DrpWorkPlace.Enabled = false;
                ImgBtnUpdate_WorkPlace.Visible = false;
                ImgBtnCancel_WorkPlace.Visible = false;
                ImgBtnEdit_WorkPlace.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnUpdate_Interest_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateInterest();
                getProfile();
                DrpInterrest.Enabled = false;
                ImgBtnUpdate_Interest.Visible = false;
                ImgBtnCancel_Interest.Visible = false;
                ImgBtnEdit_Interest.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void ImgBtnUpdate_Location_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                updateLocation();
                getProfile();
                DrpLocation.Enabled = false;
                ImgBtnUpdate_Location.Visible = false;
                ImgBtnCancel_Location.Visible = false;
                ImgBtnEdit_Location.Visible = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


    }
}