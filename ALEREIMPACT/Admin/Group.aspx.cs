using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.FRAMEWORK;


namespace ALEREIMPACT.Admin
{
    public partial class Group : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        ArrayList arraylist1 = new ArrayList();
        ArrayList arraylist2 = new ArrayList();
        public static Int32 groupid = 0;
        public static string user_id = "";
        SQLHelper objSQLHelper = new SQLHelper();
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
                        if (Convert.ToString(Request.QueryString["val"]) != null || Convert.ToString(Request.QueryString["val"]) != null)
                        {
                            groupid = Convert.ToInt32(Request.QueryString["val"]);
                            btnsave.Visible = false;
                            btnupdate.Visible = true;
                            bindGrd();
                            bindGrd1();
                        }
                        else
                        {
                            btnsave.Visible = true;
                            btnupdate.Visible = false;
                            groupid = 0;
                            bindGrd();
                        }
                        getGroupname();
                    }
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void getGroupname()
        {
            
            try
            {
                if (groupid != 0)
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ProcedureType = "GN";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        txtGroup.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                        txtGroup.Enabled = false;
                        lbname.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                    }
                }
                else
                {
                    txtGroup.Text = "";
                    txtGroup.Enabled = true;
                    lbname.Text = "New Group";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindGrd()
        {
            try
            {
                DataTable dt = new DataTable();
               
                    if (DropDownList1.SelectedIndex == 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        if (Convert.ToString(Request.QueryString["val"]) == null || Convert.ToString(Request.QueryString["val"]) == null)
                        {
                            objAdminBAO.ProcedureType = "G";
                            dt = AdminDAO.GettbUserDetail(objAdminBAO);
                        }
                        else
                        {
                            objAdminBAO.ID = groupid;
                            objAdminBAO.ProcedureType = "G1";
                            dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                        }
                       
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID = DrpLocation.SelectedValue;
                        objAdminBAO.ProcedureType = "U1";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex != 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID = DrpStatus.SelectedValue;
                        objAdminBAO.ProcedureType = "U2";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex != 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ID = DrpUserType.SelectedValue;
                        objAdminBAO.ProcedureType = "U3";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex != 0)
                    {
                        objAdminBAO.ID = DrpRegisType.SelectedValue;
                        objAdminBAO.ProcedureType = "U4";
                        dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    }
                    else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                    {
                        objAdminBAO.ProcedureType = "G";
                        dt = AdminDAO.GettbUserDetail(objAdminBAO);
                    }
                
                    if (dt.Rows.Count > 0)
                    {
                        ListBox1.DataSource = dt;
                        ListBox1.DataTextField = "name";
                        ListBox1.DataValueField = "pk_user_registration_Id";
                        ListBox1.DataBind();
                        lbltxt.Visible = false;
                        lbtext1.Visible = false;
                    }
                    else
                    {
                        lbtext1.Visible = true;
                        lbltxt.Visible = false;
                        lbtext1.Text = "No Record Found";
                        ListBox1.Items.Clear();

                    }
            }
                
         
    
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void bindGrd1()
        {
            try
            {
                DataTable dt = new DataTable();
                if (DropDownList1.SelectedIndex == 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                {
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ProcedureType = "G";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex != 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                {
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ID1 = DrpLocation.SelectedValue;
                    objAdminBAO.ProcedureType = "G1";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex != 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                {
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ID1 = DrpStatus.SelectedValue;
                    objAdminBAO.ProcedureType = "G";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex != 0 && DrpRegisType.SelectedIndex == 0)
                {
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ID1 = DrpUserType.SelectedValue;
                    objAdminBAO.ProcedureType = "G2";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex != 0)
                {
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ID1 = DrpRegisType.SelectedValue;
                    objAdminBAO.ProcedureType = "G3";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                else if (DropDownList1.SelectedIndex != 0 && DrpLocation.SelectedIndex == 0 && DrpStatus.SelectedIndex == 0 && DrpUserType.SelectedIndex == 0 && DrpRegisType.SelectedIndex == 0)
                {
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ProcedureType = "G";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                }

                if (dt.Rows.Count > 0)
                {
                    ListBox2.DataSource = dt;
                    ListBox2.DataTextField = "name";
                    ListBox2.DataValueField = "pk_user_registration_Id";
                    ListBox2.DataBind();
                    lbtext1.Visible = false; 
                }
                else
                {
                    lbtext1.Visible = false;
                    lbltxt.Visible = true;
                    lbltxt.Text = "No Record Found";
                    ListBox2.Items.Clear();

                }
            }


            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        // move items single or multiple from one list to another list//
        protected void btn1_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                lbltxt.Visible = false;
                lbtext1.Visible = false;
                if (ListBox1.SelectedIndex >= 0)
                {
                    for (int i = 0; i < ListBox1.Items.Count; i++)
                    {
                        if (ListBox1.Items[i].Selected)
                        {
                            if (!arraylist1.Contains(ListBox1.Items[i]))
                            {
                                arraylist1.Add(ListBox1.Items[i]);
                            }
                        }
                    }
                    for (int j = 0; j < arraylist1.Count; j++)
                    {
                        if (!ListBox2.Items.Contains((ListItem)arraylist1[j]))
                        {
                            ListBox2.Items.Add((ListItem)arraylist1[j]);
                        }
                        ListBox1.Items.Remove((ListItem)arraylist1[j]);
                    }

                    ListBox2.SelectedIndex = -1;

                }
                else
                {
                    lbltxt.Visible = true;
                    lbltxt.Text = "Please select atleast one  to move";
                }
                if (ListBox1.Items.Count == 0)
                {
                    lbltxt.Visible = true;
                    lbltxt.Text = "No item to move";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        // move all items from one list to another list//
        protected void btn2_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (ListBox1.Items.Count != 0)
                {
                    lbltxt.Visible = false;
                    lbtext1.Visible = false;
                    while (ListBox1.Items.Count != 0)
                    {
                        for (int i = 0; i < ListBox1.Items.Count; i++)
                        {
                            ListBox2.Items.Add(ListBox1.Items[i]);
                            ListBox1.Items.Remove(ListBox1.Items[i]);
                        }
                    }
                }
                else
                {
                    lbtext1.Visible = true;
                    lbltxt.Visible = false;
                    lbtext1.Text = "No Item to move";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        // move items single or multiple from second  list to first list//
        protected void btn3_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                lbltxt.Visible = false;
                lbtext1.Visible = false;
                if (ListBox2.SelectedIndex >= 0)
                {
                    for (int i = 0; i < ListBox2.Items.Count; i++)
                    {
                        if (ListBox2.Items[i].Selected)
                        {
                            if (!arraylist2.Contains(ListBox2.Items[i]))
                            {
                                arraylist2.Add(ListBox2.Items[i]);
                            }
                        }
                    }
                    for (int j = 0; j < arraylist2.Count; j++)
                    {
                        if (!ListBox1.Items.Contains((ListItem)arraylist2[j]))
                        {
                            ListBox1.Items.Add((ListItem)arraylist2[j]);
                        }
                        ListBox2.Items.Remove((ListItem)arraylist2[j]);
                    }

                    ListBox1.SelectedIndex = -1;

                }
                else
                {
                    lbltxt.Visible = true;
                    lbtext1.Visible = false;
                    lbltxt.Text = "Please select atleast one  to move";
                }
                if (ListBox2.Items.Count == 0)
                {
                    lbltxt.Visible = true;
                    lbtext1.Visible = false;
                    lbltxt.Text = "No item to move";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        // move items all from second  list to first list//
        protected void btn4_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (ListBox2.Items.Count != 0)
                {
                    lbltxt.Visible = false;
                    lbtext1.Visible = false;
                    while (ListBox2.Items.Count != 0)
                    {
                        for (int i = 0; i < ListBox2.Items.Count; i++)
                        {
                            ListBox1.Items.Add(ListBox2.Items[i]);
                            ListBox2.Items.Remove(ListBox2.Items[i]);
                        }
                    }
                }
                else
                {
                    lbltxt.Visible = true;
                    lbtext1.Visible = false;
                    lbltxt.Text = "No Items to move";
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpStatus.SelectedIndex = 0;
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                if (DropDownList1.SelectedValue == "1")
                {
                    divLocation.Style.Add("display", "none");
                    divRegsType.Style.Add("display", "none");
                    divUserType.Style.Add("display", "none");
                    divStatus.Style.Add("display", "");
                    objSQLHelper.fillDrpControl(DrpStatus, "spFillDrpDown", "user_status", "pk_user_status_id", "S");
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    divLocation.Style.Add("display", "");
                    divRegsType.Style.Add("display", "none");
                    divUserType.Style.Add("display", "none");
                    divStatus.Style.Add("display", "none");
                    objSQLHelper.fillDrpControl(DrpLocation, "spFillDrpDown", "location_name", "pk_location_id", "L");
                }
                else if (DropDownList1.SelectedValue == "3")
                {
                    divLocation.Style.Add("display", "none");
                    divRegsType.Style.Add("display", "none");
                    divUserType.Style.Add("display", "");
                    divStatus.Style.Add("display", "none");
                    objSQLHelper.fillDrpControl(DrpUserType, "spFillDrpDown", "user_type_role", "pk_user_role_Id", "U");
                }
                else if (DropDownList1.SelectedValue == "4")
                {
                    divLocation.Style.Add("display", "none");
                    divRegsType.Style.Add("display", "");
                    divUserType.Style.Add("display", "none");
                    divStatus.Style.Add("display", "none");
                    objSQLHelper.fillDrpControl(DrpRegisType, "spFillDrpDown", "type_of_login", "pk_types_of_login_Id", "R");
                }
                else
                {

                    divStatus.Style.Add("display", "none");
                    divLocation.Style.Add("display", "none");
                    divUserType.Style.Add("display", "none");
                    divRegsType.Style.Add("display", "none");
                    DropDownList1.SelectedIndex = 0;
                    DrpStatus.SelectedIndex = 0;
                    DrpStatus.Items.Clear();
                    DrpStatus.Items.Add("--Please Select--");
                    DrpLocation.SelectedIndex = 0;
                    DrpLocation.Items.Clear();
                    DrpLocation.Items.Add("--Please Select--");
                    DrpUserType.Items.Clear();
                    DrpUserType.Items.Add("--Please Select--");
                    DrpRegisType.Items.Clear();
                    DrpRegisType.Items.Add("--Please Select--");
                    bindGrd();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DrpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
        }

        protected void DrpUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpStatus.SelectedIndex = 0;
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                DrpRegisType.Items.Clear();
                DrpRegisType.Items.Add("--Please Select--");
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void DrpRegisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DrpLocation.SelectedIndex = 0;
                DrpLocation.Items.Clear();
                DrpLocation.Items.Add("--Please Select--");
                DrpStatus.Items.Clear();
                DrpStatus.Items.Add("--Please Select--");
                DrpUserType.Items.Clear();
                DrpUserType.Items.Add("--Please Select--");
                bindGrd();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (ListBox2.Items.Count == 0)
                {
                    RequiredFieldValidator1.Enabled = true;
                }
                else
                {
                    RequiredFieldValidator1.Enabled = false;
                }
               
                int retval = 0;
                objAdminBAO.GROUP_ID = 0;
                objAdminBAO.GROUP_NAME = txtGroup.Text;
                objAdminBAO.ProcedureType = "I";
                retval = AdminDAO.InserttblGroupMaster(objAdminBAO);
                if (retval != 0)
                {
                    if (ListBox2.Items.Count > 0)
                    {
                        for (int i = 0; i < ListBox2.Items.Count; i++)
                        {
                            int param = 0;
                            objAdminBAO.GUD_ID = 0;
                            objAdminBAO.GROUP_ID_FK = retval;
                            objAdminBAO.fk_user_registration_Id = ListBox2.Items[i].Value ;
                            objAdminBAO.ProcedureType = "I";
                          param=  AdminDAO.InserttblGroupUserDetail(objAdminBAO);

                        }
                    }

                    Response.Redirect("GroupDetail.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                if (ListBox2.Items.Count > 0)
                {
                    for (int i = 0; i < ListBox2.Items.Count; i++)
                    {
                        if (user_id == "")
                        {
                            user_id = ListBox2.Items[i].Value;
                        }
                        else
                        {

                            user_id = user_id + "," + ListBox2.Items[i].Value;
                        }
                    }
                    int retval = 0;
                    objAdminBAO.user_id = user_id;
                    objAdminBAO.GROUP_ID_FK =groupid;
                    objAdminBAO.ProcedureType = "U";
                    retval = AdminDAO.UpdatetblGroupUserDetail(objAdminBAO);
                }
                else if (ListBox2.Items.Count == 0)
                {
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = groupid;
                    objAdminBAO.ProcedureType = "G2";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                }

                //DataTable dt1 = new DataTable();
                //objAdminBAO.ID = ( groupid);
                //objAdminBAO.ProcedureType = "GU";
                //dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                //if (dt1.Rows.Count > 0)
                //{
                    if (ListBox2.Items.Count >0)
                    {
                        for (int i = 0; i < ListBox2.Items.Count; i++)
                        {
                            int retval1= 0;
                            objAdminBAO.GUD_ID = 0;
                            objAdminBAO.GROUP_ID_FK = groupid;
                            objAdminBAO.fk_user_registration_Id = ListBox2.Items[i].Value;
                            objAdminBAO.ProcedureType = "I";
                            retval1 = AdminDAO.InserttblGroupUserDetail(objAdminBAO);

                        }

                    //}
                }
                    Response.Redirect("GroupDetail.aspx", false);

                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        protected void lnkGroup_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Response.Redirect("GroupDetail.aspx", false);
                Session["Group"] = true;
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }


       
    }
}
