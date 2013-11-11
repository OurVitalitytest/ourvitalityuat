<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="RegistrationThanks.aspx.cs" Inherits="ALEREIMPACT.RegistrationThanks"
    Title="Vitality-Registration Thanks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/newstyle.css" type="text/css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <body id="login">
        <div class="inner_box">
            <div class="top_header">
                <div class="login_logo">
                </div>
            </div>
            <label style="float: left; font-size: 16px; font-weight: bold; margin-left: 30px;
                margin-top: 18px; width: 439px; word-wrap: break-word;">
                Thanks for signing up,check your email for your password so we can get you started.
            </label>
            <%-- <div class="member_login_text_thankyou">Thank you for submitting your request. Your 
password has been sent to your email.</div>--%>
            <div class="login_pass">
                <a href="Login.aspx">
                    <%-- <input type="submit" class="login_btn login_thanku" value=""/>--%>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/imagesNew/login.png" class="login_btn login_thanku" /></a>
                <br />
            </div>
        </div>
       <div id="dvFooter" runat="server">
        <div class="footer_miss">
        </div>
    </div>

    <div class="copyrgts" style="    margin-top: 290px !important;">
 
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
    </body>
</asp:Content>
