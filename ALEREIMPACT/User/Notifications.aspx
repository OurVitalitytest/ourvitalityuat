﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="ALEREIMPACT.User.Notifications" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UCNotification" TagName="Notifications" Src="~/User/UCNIMNotification.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script type="text/javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Inspirators.aspx/ProcessIT",
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        
         <div class="center_section_mission">
        <div class="mission_tab">
            
        </div>
  
        <div class="tab_mission_runtime">
              <asp:UpdatePanel ID="updatePanelNMINotification" runat="server">
        <ContentTemplate>
             <div id="dvNotification" runat="server" >
                <UCNotification:Notifications ID="NMINotifications" runat="server" />
            </div>
             
             </ContentTemplate>
             </asp:UpdatePanel>
        </div>
       
    </div>
    </div>
    </form>
</body>
</html>
