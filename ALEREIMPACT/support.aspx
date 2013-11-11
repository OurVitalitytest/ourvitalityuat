<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="support.aspx.cs" Inherits="ALEREIMPACT.support" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vitality-Support</title>
    <link href="../CSS/Privacycss/privacy.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/newstyle.css" type="text/css" />
    <link href="../CSS/Privacycss/mission.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Privacycss/style.css" rel="stylesheet" type="text/css" />
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
    	width:50%;
}
.copy_right_rgt {
    color: #333333;
    float: right;
    font-family: Arial,Helvetica,sans-serif;
    font-size: 12px;
    font-weight: bold;
	margin-right:5%;
	
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
<body>
    <form id="form1" runat="server">
    <div class="main_btm_miss1" style="margin: 0 auto; overflow: hidden; width: 980px;">
        <div class="cont_miss1">
            <div class="main_cont_miss">
                <div class="top_header">
                    <div class="login_logo">
                        <asp:ImageButton ID="imgbtmLogo" runat="server" ImageUrl="~/images/imagesNew/vitality_welcomw.png"
                            OnClick="ImgRedirectTo_Click" />
                    </div>
                </div>
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
                <div style="float: left; margin-top: 35px; width: 500px;">
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
                    <img src="images/support.png" runat="server" style="width: 300px;" />
                </div>
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
</body>
</html>
