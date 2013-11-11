<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="ALEREIMPACT.ChangePassword" Title="Vitality-Change Password" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/style1.css" rel="stylesheet" type="text/css" />
    <link href="CSS/newstyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
      </style>
    <style type="text/css">
        #registration_bg
        {
            float: left;
            width: 100%;
            margin: 0px auto;
            min-height: 800px;
            background: url(images/bg1.jpg);
        }
    </style>
  <style type="text/css">
        .footer {
    background: url("../image/footer_img.png") repeat scroll 0 0 transparent;
    float: left;
    height: 586px;
    margin-top: 1px;
    width: 100%;
    z-index: -99;
}
.side_section_mission{ float:right; text-align:left;}
.copy_right_left {
    color: #333333;
    float: left;
    font-family: Arial,Helvetica,sans-serif;
    font-size: 12px;
    font-weight: bold;
    margin-bottom: 5px;
    margin-left: 5%;
}
.copy_right_rgt {
    color: #333333;
    float: right;
    font-family: Arial,Helvetica,sans-serif;
    font-size: 12px;
    font-weight: bold;
	margin-right:5%;
	width:50%;
	
}
.copy_right_rgt a{ float:right; color:#333333; text-decoration:none;}
.copyrgts {
    background: none repeat scroll 0 0 #EEEEEE;
    border-top: 1px solid #CFCFCF;
    clear: both;
    float: left;
    padding-bottom: 10px;
    padding-top: 10px;
    width: 100%;
}	
</style>
    <script src="scripts/AC_RunActiveContent.js" type="text/javascript"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script type="text/javascript">
    window.onbeforeunload = function() {
     $(document).ready(function() {
$.ajax({
type: "POST",
contentType: "application/json; charset=utf-8",
url: "ChangePassword.aspx/ProcessIT",
data: "{}",
dataType: "json",
success: function(data) {
//alert('');
},
error: function(result) {
//alert("");
}
});
});
}
    </script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script src="js/jquery.flexslider-min.js" type="text/javascript"></script>

    <%--<link href="CSS/style1.css" rel="stylesheet" type="text/css" />--%>
    <link href="CSS/flexslider.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
$(window).load(function() {
$('.flexslider').flexslider();
});
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="inner_box">
        <div class="top_header">
            <div class="login_logo">
            </div>
        </div>
        <div class="memeber_login">
            <div class="member_login_text">
                Change Password</div>
        </div>
        <div style="float: left; margin-bottom: 10px; margin-left: 74px; margin-top: 0; text-align: center;">
        </div>
        <asp:TextBox ID="txtCurrentPassword" runat="server" class="pass_text" TextMode="Password"
            onkeypress="return keypressed(event)" placeholder="Please Enter Current Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
            CssClass="error" Style="visibility: visible; color: #B20202;" ErrorMessage="Please Enter Current Password"
            ControlToValidate="txtCurrentPassword" ValidationGroup="a"></asp:RequiredFieldValidator>
        <asp:Label ID="lberror" runat="server" Text="" Visible="false" Style="color: #B20202;
            float: left; margin-left: 55px;"></asp:Label>
        <asp:TextBox ID="txtNewPassword" runat="server" class="pass_text" TextMode="Password"
            onkeypress="return keypressed(event)" placeholder="Please Enter New Password"
            MaxLength="12"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
            ErrorMessage="Please Enter New Password" ControlToValidate="txtNewPassword" ValidationGroup="a"
            CssClass="error" Style="visibility: visible; color: #B20202;"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNewPassword"
            runat="server" ErrorMessage="Password must be atleast 6 characters long and contain at least one number, one lower letter,one upper letter and one unique character"
            Style="color: #B20202; float: left; font-family: arial; font-size: 12px; line-height: 14px;
            margin-left: 56px; width: 432px;" ValidationExpression="^.*(?=.{6,12})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?@* ]).*$"
            ValidationGroup="a" Display="Dynamic">
        </asp:RegularExpressionValidator>
        <asp:TextBox ID="txtConfirmPassword" runat="server" class="pass_text" TextMode="Password"
            onkeypress="return keypressed(event)" placeholder="Please Enter Confirm Password"
            MaxLength="12"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
            ErrorMessage="Please Enter Confirm Password" ControlToValidate="txtConfirmPassword"
            ValidationGroup="a" CssClass="error" Style="visibility: visible; color: #B20202;"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" runat="server" ValidationGroup="a"
            CssClass="error" Style="visibility: visible; color: #B20202;" ControlToCompare="txtNewPassword"
            ControlToValidate="txtConfirmPassword" ErrorMessage="Password not matched"></asp:CompareValidator>
        <div class="login_pass">
            <div class="login_pass">
                <asp:ImageButton ID="btnchangePwd" runat="server" ImageUrl="~/images/change_pwd.jpg"
                    Style="border-width: 0; cursor: pointer; float: left; margin-bottom: 15px; margin-left: 120px;
                    margin-top: 28px;" OnClick="btnchangePwd_Click" ValidationGroup="a" />
                <asp:Button ID="btnBack" runat="server" Text="Back To Wall" CssClass="submit_box_reg"
                    OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
    <div id="dvFooter" runat="server">
        <div class="footer_miss">
        </div>
    </div>

    <div class="copyrgts" style="margin-top: 100px !important;">
 
         <div class="copy_right_left">
            © 2011 Vitality
        </div>
      <div class="copy_right_rgt">
       <asp:LinkButton ID="lnkSupport" runat ="server" OnClick ="lnkSupport_Click">| Support</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lnkprivacynPolicy" runat ="server" OnClick ="lnkprivacynPolicy_Click">| Privacy Policy</asp:LinkButton>
        &nbsp;
           <asp:LinkButton ID="lnkTermsnConditions" runat ="server" OnClick="lnkTermsnConditions_Click" >Terms & Conditions</asp:LinkButton>
          
        </div>
        </div>
</asp:Content>
