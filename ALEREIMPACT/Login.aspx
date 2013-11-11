<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ALEREIMPACT.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="CSS/newstyle.css" rel="stylesheet" type="text/css" />
  
    <title>Login</title>
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
</head>
<style>
.login_pass_rem { color: #999999; float: right; font-family: arial;  font-size: 14px;  margin-right: 47px;}
#dvfeatures{float: right; width: 350px;}
#dvfeatures a{  color: #000000; float: left; font-family: arial; font-size: 13px;  margin-left: 3px; margin-right: 5px; margin-top: 2px;}
</style>
<body id="login">
    <asp:Panel ID="panel1" runat="server" DefaultButton="btnLogin">
        <table width="100%">
            <tr>
                <td style="color: #B20202; padding-left: 50px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRegisterNewUserMsg" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <form id="form1" runat="server">
        <div class="inner_box">
            <div class="top_header">
                <div class="login_logo">
                </div>
            </div>
            <div class="memeber_login">
                <div class="member_login_text">
                    Member Login</div>
            </div>
            <div style="float: left; margin-bottom: 10px; margin-left: 74px; margin-top: 0; text-align: center;">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblWrongCredentials" runat="server" Style="color: #B20202; float: left;
                                font-family: arial; font-size: 14px; margin-bottom: -82px; margin-left: 44px;
                                margin-top: 11px; width: 283px;"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:TextBox ID="txtUserName" runat="server" class="email_text" placeholder="Please enter your Email ID"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqNameOnly" runat="server" ErrorMessage="*Please enter your valid email "
                ValidationGroup="LoginAlere" Display="Dynamic" ControlToValidate="txtUserName"
                CssClass="error" Style="visibility: visible; color: #B20202;"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtUserName"
                CssClass="error" Style="visibility: visible; color: #B20202; visibility: visible;" ValidationGroup="LoginAlere"
                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="*Please enter your valid email"></asp:RegularExpressionValidator>
            <%-- <input type="password" />--%>
            </td> </tr>
            <asp:TextBox ID="txtPassword" runat="server" class="pass_text" placeholder="Please enter your Password"
                TextMode="Password" onkeypress="return keypressed(event)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqdPwd" runat="server" ErrorMessage="*Please enter your Password"
               CssClass="error" Style="visibility: visible; color: #B20202;" ValidationGroup="LoginAlere" Display="Dynamic" ControlToValidate="txtPassword"
               ></asp:RequiredFieldValidator>
    <div class="login_pass_rem">
    <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me" />
    </div>
            <div class="login_pass">
                <div class="login_pass">
                    <asp:Button ID="btnLogin" runat="server" ValidationGroup="LoginAlere" class="login_btn"
                        OnClick="btnLogin_Click" />
                    <div class="forgot">
                        <a href="ForgotPassword.aspx">Forgot Password? </a>
                    </div>
                </div>
            </div>
            <div class="or"></div>
            <div class="fb" style ="text-align: center;">
                <a href="#">
                <asp:ImageButton ID="imgFacebookLogin" runat="server" src="images/imagesNew/fb.png"
                                    AlternateText="facebooklogin" OnClick="imgFacebookLogin_Click" />
                   <%-- <img src="images/imagesNew/fb.png" />--%>
                   </a></div>
            <div class="gplus" style ="text-align: center;">
                <a href="#">
                <asp:ImageButton ID="imgGoogleLogin" runat="server" src="images/imagesNew/gplus.png"
                                    OnCommand="imgGoogleLogin_Click" CommandArgument="https://www.google.com/accounts/o8/id" />
                               
                
                </a></div>
            <div class="gplus" style ="text-align: center;">
                <a href="#">
                 <asp:ImageButton ID="ImageButton1" runat="server" src="images/imagesNew/alere.png" />
                  
                    </a></div>
            <div class="btm_bg">
                <div class="text">
                    Don't have an account? <span>
                   <%-- <asp:Button ID="btnRegister" runat="server" CssClass="register" OnClick="btnRegister_Click1" />--%>
                   <asp:LinkButton ID="btnRegister" runat="server" CssClass="register" OnClick="btnRegister_Click1" Text="Register Now »"></asp:LinkButton>
                  <%--  <a href="btnRegister_Click1">Register Now »</a></span>--%>
                </div>
            </div>
        </div>
        <div id="dvFooter" runat="server">
        <div class="footer_miss">
        </div>
    </div>

    <div class="copyrgts">
 
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
     
        </form>
    </asp:Panel>
</body>
</html>
