<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="ForgotPassword.aspx.cs" Inherits="ALEREIMPACT.ForgotPassword" Title="Vitality - Forgot Password" %>

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
            <div class="memeber_login">
                <div class="member_login_text">
                    Forgot Password</div>
            </div>
            <asp:TextBox ID="txtemail" runat="server" class="email_text" placeholder="Please enter your Email ID"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="error"
                runat="server" ErrorMessage="*Please enter your email " Style="visibility: visible;
                color: #B20202;" ControlToValidate="txtemail" ValidationGroup="a"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                ValidationGroup="a" ControlToValidate="txtemail" runat="server" CssClass="error"
                ErrorMessage="*Please enter your valid email " Style="visibility: visible; color: #B20202;"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> 
            </asp:RegularExpressionValidator>
            <asp:Label ID="lberror" runat="server" Text="" Visible="false" Style="color: #B20202;
                float: left; font-family: arial; font-size: 12px; margin-left: 27px; width: 450px;"></asp:Label>
            <%-- <input type="text" class="email_text" placeholder="Please enter you Email ID" />--%>
            <div class="login_pass">
                <asp:ImageButton ID="btnsend" runat="server" ImageUrl="~/images/submit_forgot.jpg"
                    class="submit_btn_forgot" ValidationGroup="a" OnClick="btnsend_Click" />
                <a href="Login.aspx">
                    <img style="float: right; margin-left: 40%; margin-top: 3.3%;" src="images/nothanks.jpg" />
                </a>
                <%-- <a href="thankyou.html">  <input type="submit" class="submit_btn" value=""/></a>--%>
            </div>
        </div>
        <div id="dvFooter" runat="server">
        <div class="footer_miss">
        </div>
    </div>

    <div class="copyrgts" style=" margin-top: 220px !important;">
 
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
