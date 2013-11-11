using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data;

namespace ALEREIMPACT.FRAMEWORK
{
   public  class ControlHelper
    {
        public static string GetTextFromLabel(Control label)
        {
            Label myLabel = (Label)label;
            return myLabel.Text.Trim();
        }
        public static string GetStringFromTextBox(Control textBox)
        {
            TextBox myTextBox = (TextBox)textBox;
            return myTextBox.Text;
        }
        public static string GetDateFromTextBox(Control textBox)
        {
            TextBox myTextBox = (TextBox)textBox;
            return Convert.ToDateTime(myTextBox.Text).ToString();
        }
        public static int GetIntFromTextBox(Control textBox)
        {
            TextBox myTextBox = (TextBox)textBox;
            return Convert.ToInt32(myTextBox.Text);
        }
        public static string GetStringFromLabel(Control label)
        {
            Label myLabel = (Label)label;
            return myLabel.Text.Trim();
        }
        public static string GetDateFromLabel(Control label)
        {
            Label myLabel = (Label)label;
            return Convert.ToDateTime(myLabel.Text).ToString().Trim();
        }
        public static int GetIntFromLabel(Control label)
        {
            Label myLabel = (Label)label;
            return Convert.ToInt32(myLabel.Text.Trim());
        }
        public static bool GetBoolFromCheckbox(Control checkBox)
        {
            CheckBox myCheckBox = (CheckBox)checkBox;
            return myCheckBox.Checked;
        }
        public static int GetIntFromDropDownList(Control dropDownList)
        {
            DropDownList myDropDownList = (DropDownList)dropDownList;
            return Convert.ToInt32(myDropDownList.SelectedValue);
        }
        public static void GetBindFromDropDownList(Control dropDownList, string dataTextField, String dataValueField, DataTable dt)
        {
            DropDownList myDropDownList = (DropDownList)dropDownList;
            myDropDownList.DataTextField = dataTextField;
            myDropDownList.DataValueField = dataValueField;
            myDropDownList.DataSource = dt;
            myDropDownList.DataBind();
            myDropDownList.Items.Insert(0, "--Please Select--");


        }
        public static void GetBindFromCheckBoxList(Control chkBoxList, string dataTextField, String dataValueField, DataTable dt)
        {
            CheckBoxList myCheckBoxList = (CheckBoxList)chkBoxList;
            myCheckBoxList.DataTextField = dataTextField;
            myCheckBoxList.DataValueField = dataValueField;
            myCheckBoxList.DataSource = dt;
            myCheckBoxList.DataBind();
            //myCheckBoxList.Items.Insert(0, "--Please Select--");


        }
        public static void GetBindFromListBox(Control chkBoxList, string dataTextField, String dataValueField, DataTable dt)
        {
            ListBox myCheckBoxList = (ListBox)chkBoxList;
            myCheckBoxList.DataTextField = dataTextField;
            myCheckBoxList.DataValueField = dataValueField;
            myCheckBoxList.DataSource = dt;
            myCheckBoxList.DataBind();
            //myCheckBoxList.Items.Insert(0, "--Please Select--");


        }

        public static void GetBindFromRadioButtonList(Control RadioList, string dataTextField, String dataValueField, DataTable dt)
        {
            RadioButtonList myRadioList = (RadioButtonList)RadioList;
            myRadioList.DataTextField = dataTextField;
            myRadioList.DataValueField = dataValueField;
            myRadioList.DataSource = dt;
            myRadioList.DataBind();
            //myCheckBoxList.Items.Insert(0, "--Please Select--");


        }

        public static string GetFileName(string filename)
        {
            string newFileNameGUID = string.Empty;
            try
            {

                string ext = filename.Substring(filename.LastIndexOf("."));
                string newFileName = filename.Substring(0, filename.LastIndexOf("."));
                newFileNameGUID = newFileName + "_" + Guid.NewGuid().ToString() + ext;
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
            return newFileNameGUID;
        }

    }
}
