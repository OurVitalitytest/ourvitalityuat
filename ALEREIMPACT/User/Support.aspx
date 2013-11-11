<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="ALEREIMPACT.User.Support" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Our Vitality-Support</title>
     <link href="../CSS/Privacycss/privacy.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/newstyle.css" type="text/css" />
    <link href="../CSS/Privacycss/mission.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Privacycss/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="main_btm_miss1" style="margin: 0 auto; overflow: hidden; width: 980px;">
        <div class="cont_miss1">
            <div class="main_cont_miss" >
                
                <div class="top_his_miss" style="height: 3px; margin-top: 0 !important; padding-left: 11px !important;
                    padding-top: 22px; width: 964px !important;">
                    <div class="bread_miss">
                        <span class="mission_miss" style="font-size: 16px; font-weight: bold; margin-top: -15px !important;
                            width: 340px;">Support</span>
                        <div class="arrow_miss">
                        </div>
                    </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>
                <div style="float: left; margin-top: 35px;   width: 415px;">
                    <div style="float: left; margin-left: 112px; margin-top: 30px; width: 350px;">
                        <span style="float: left; font-family: arial; font-size: 15px;">Name :</span> &nbsp;
                        <asp:TextBox ID="txtName" runat="server" Style="border: 1px solid #D6D6D6; float: left;
                            margin-left: 39px; width: 250px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqNameOnly" runat="server" ErrorMessage="Please enter your name"
                            CssClass="error" ValidationGroup="support" Display="Dynamic" ControlToValidate="txtName"
                            Style="color: #B20202; float: left; font-family: arial; font-size: 12px; margin-left: 89px;
                            margin-top: 3px; visibility: visible; width: 133px;"></asp:RequiredFieldValidator>
                    </div>
                    <div style="float: left; margin-left: 112px; margin-top: 30px; width: 350px;">
                        <span style="float: left; font-family: arial; font-size: 15px;">Email :</span> &nbsp;
                        <asp:TextBox ID="txtEmail" runat="server" Style="border: 1px solid #D6D6D6; float: left;
                            margin-left: 39px; width: 250px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your email"
                            CssClass="error" ValidationGroup="support" Display="Dynamic" ControlToValidate="txtEmail"
                            Style="color: #B20202; float: left; font-family: arial; font-size: 12px; margin-left: 89px;
                            margin-top: 3px; visibility: visible; width: 133px;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                            CssClass="error" Style="float: left; font-family: arial; font-size: 12px; margin-left: 89px;
                            width: 144px; color: #B20202; visibility: visible;" ValidationGroup="support"
                            Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage="Please enter valid email"></asp:RegularExpressionValidator>
                    </div>
                    <div style="float: left; margin-left: 112px; margin-top: 30px; width: 350px;">
                        <span style="float: left; font-family: arial; font-size: 15px;">Message :</span>
                        &nbsp;
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Style="border: 1px solid #D6D6D6;
                            float: left; margin-left: 15px; width: 250px; height: 100px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your message"
                            CssClass="error" ValidationGroup="support" Display="Dynamic" ControlToValidate="txtMessage"
                            Style="color: #B20202; float: left; font-family: arial; font-size: 12px; margin-left: 89px;
                            margin-top: 3px; visibility: visible; width: 159px;"></asp:RequiredFieldValidator>
                    </div>
                    <div style="float: left; margin-left: 112px; margin-top: 30px; width: 350px;">
                        <asp:ImageButton ID="ImgBtnSubmit" runat="server" ValidationGroup="support" ImageUrl="~/images/submit_forgot.jpg"
                            Style="border-width: 0; float: left; margin-left: 82px; width: 100px;" OnClick="ImgBtnSubmit_Click" />
                    </div>
                    <div id="DVMSg" runat="server" visible="false" style="float: left; margin-left: 112px;
                        margin-top: 30px; width: 350px;">
                        <asp:Label ID="Label1" runat="server" Style="color: #FF0000; font-family: arial;
                            font-size: 16px;" Text="Thank you! If we need more information related to your message, we will contact you shortly."></asp:Label>
                    </div>
                </div>
                <div style="float: left; margin-left: 165px; margin-top: 14px;">
                    <img id="Img1" src="~/images/support.png" runat="server" style="width: 300px;" />
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
