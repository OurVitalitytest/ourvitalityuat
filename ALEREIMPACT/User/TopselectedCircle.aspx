<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopselectedCircle.aspx.cs"
    Inherits="ALEREIMPACT.User.TopselectedCircle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/stylenewdesign.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Circlestyle.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/global.css" type="text/css" />
</head>
<body style="background: none transparent;">
    <form id="form1" runat="server">
    <div>
        <div id="dvtopimagecircle" runat="server" class="topthumb" style="margin-top: 0px;">
            <asp:Image ID="imgtopcircle" runat="server" CssClass="topavatar" ImageUrl="" />
        </div>
        <div class="name_miss">
        </div>
        <%--    You are here: --%>
        <div class="manepersn_miss">
            <asp:Label ID="lbcirclename" runat="server" Style="font-family: arial; color: #669933;
                font-size: 19px; margin-top: 10px; position: absolute;"></asp:Label>
        </div>
    <%--    <div id="DVAdminMessage" runat="server" style="background-color: #FFD3D3; border: 1px solid #FF6F6F;
            border-radius: 5px 5px 5px 5px; float: left; font-family: arial; margin-left: 288px;
            margin-top: 7px; padding: 0; text-align: center; width: 124px; display: none;">
            <asp:LinkButton ID="lnkClick" runat="server" Text="Admin
                    Sent you a message" Style="color: #A00000; float: left; font-size: 9px; margin-left: 3px;
                padding-bottom: 5px; padding-top: 7px;" OnClick="lnkClick_Click"></asp:LinkButton>
            <asp:ImageButton ID="ImgBtnClose" runat="server" ImageUrl="../images/delete-icon.png"
                Style="border-width: 0; float: left; height: 5px; margin-left: 121px; margin-top: -16px;
                width: 5px;" OnClick="ImgBtnClose_Click" />
        </div>--%>
    </div>
    </form>
</body>
</html>
