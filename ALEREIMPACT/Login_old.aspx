<%@ Page Title="Vitality - Login" Language="C#" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Login_old.aspx.cs" Inherits="ALEREIMPACT.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script src="scripts/AC_RunActiveContent.js" type="text/javascript"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script src="js/jquery.flexslider-min.js" type="text/javascript"></script>

    <link href="CSS/flexslider.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(window).load(function() {
            $('.flexslider').flexslider();
        });
    </script>

    <script language="javascript" type="text/javascript">
        function keypressed(e) {

            var intKey = (window.Event) ? e.which : e.keyCode;
            if (intKey == 13) {

                document.getElementById('<%= btnLogin.ClientID %>').click();
                return false;
            }
        }

    </script>

    <script type="text/javascript" language="javascript">
        function Randomize() {
            var images = new Array("bg.jpg", "bg1.jpg", "bg2.jpg");
            var imageNum = Math.floor(Math.random() * images.length);
            document.getElementById("main_index").style.backgroundImage = "url('images/" + images[imageNum] + "')";
        }
        window.onload = Randomize;

    </script>

    <style type="text/css">
        #main_index
        {
            float: left;
            width: 100%;
            margin: 0px auto;
            min-height: 800px;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function md5auth() {

            var passwordid = '<%= txtPassword.ClientID %>';
            var password = document.getElementById(passwordid).value;
            var hash = hex_md5(password);
            document.getElementById(passwordid).value = hash;
            return true;
        }
    
    </script>

    <script language="javascript" src="scripts/md5.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main_index">
        <div class="top_box" style="margin-right: 102px !important; width: 380px !important;">
            <span class="top_text">Welcome To Vitality</span>
        </div>
        <div class="login_form" style="margin-top: 170px !important;">
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
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblWrongCredentials" runat="server" Style="color: #B20202; float: left;
                                font-family: arial; margin-bottom: -82px; margin-left: 44px; font-size: 14px;
                                margin-top: 66px; width: 283px;"></asp:Label>
                            <label class="form_text">
                                Email
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="text_box"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="reqNameOnly" runat="server" ErrorMessage="*Please enter your valid email "
                                ValidationGroup="LoginAlere" Display="Dynamic" ControlToValidate="txtUserName"
                                CssClass="error" Style="visibility: visible; color: #B20202;"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtUserName"
                                CssClass="error" Style="float: left; font-family: arial; font-size: 12px; margin-left: 34px;
                                width: 177px; color: #B20202; visibility: visible;" ValidationGroup="LoginAlere"
                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="*Please enter your valid email"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="form_pass">
                                Password
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="text_box" TextMode="Password"
                                onkeypress="return keypressed(event)"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="reqdPwd" runat="server" ErrorMessage="*Please enter your Password"
                                CssClass="error" ValidationGroup="LoginAlere" Display="Dynamic" ControlToValidate="txtPassword"
                                Style="visibility: visible; color: #B20202;"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="ForgotPassword.aspx"><span class="forgort_pass">Forgotten your <span style="color: #222">
                                password ? </span></span></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRegister" runat="server" CssClass="register" OnClick="btnRegister_Click1" />
                            <asp:Button ID="btnLogin" runat="server" ValidationGroup="LoginAlere" CssClass="login"
                                OnClick="btnLogin_Click" />
                                <br />
                                
                                 &nbsp;<asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me" />
                        </td>
              
                    </tr>
                    <tr>
                        <td>
                            <div class="fav_icon">
                                <asp:ImageButton ID="imgFacebookLogin" runat="server" ImageUrl="~/images/fb_icon.png"
                                    AlternateText="facebooklogin" OnClick="imgFacebookLogin_Click" />
                                <asp:ImageButton ID="imgGoogleLogin" runat="server" ImageUrl="~/images/gplus1.png"
                                    OnCommand="imgGoogleLogin_Click" CommandArgument="https://www.google.com/accounts/o8/id" />
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/well.png" />
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
