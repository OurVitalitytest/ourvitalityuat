﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitBitAccountSettings.aspx.cs" Inherits="ALEREIMPACT.User.FitBitAccountSettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UserCtAdminMessagesNew" TagName="AdminMessageNew" Src="~/User/ucAdminMessagesNew.ascx" %>
<%@ Register TagPrefix="ucFitBitAccount" TagName="Form" Src="~/User/ucFitBitAccountSettings.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Circlestyle.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/global.css" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script type="text/javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Wall.aspx/ProcessIT",
                    dataType: "json"

                });
            });

        }
    </script>

</head>
<body>
    <form id="frmadminmsgs" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="center_section_mission">
        <div class="mission_tab">
        
            <asp:UpdatePanel ID="updatePanelmsges" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                                    
                    <div id="divAdminMessageNew" runat="server">
                         <ucFitBitAccount:Form ID="FitBitAcc" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
