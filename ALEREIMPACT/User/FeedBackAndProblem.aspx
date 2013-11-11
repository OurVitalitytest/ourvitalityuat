<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedBackAndProblem.aspx.cs" Inherits="ALEREIMPACT.User.FeedBackAndProblem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UCSetting" TagName="Setting" Src="~/User/ucSettingOption.ascx" %>
<%@ Register TagPrefix="UCFeedBack" TagName="FeedBack" Src="~/User/ucUserFeedBack.ascx" %>
<%@ Register TagPrefix="UCReportProblem" TagName="REportProblem" Src="~/User/ucReportProblem.ascx" %>
<%@ Register TagPrefix="UCTickets" TagName="Tickets" Src="~/User/ucTickets.ascx" %>
<%@ Register TagPrefix="UCChangePassword" TagName="ChangePassword" Src="~/User/ucChangePassword.ascx" %>
<%@ Register TagPrefix="UCPrivacy" TagName="Privacy" Src="~/User/ucPrivacySettings.ascx" %>
<%@ Register TagPrefix="UCNotification" TagName="Notification" Src="~/User/ucNotification.ascx" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title></title>
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
    <form id="frmFeed" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="center_section_mission">
        <div class="mission_tab">
            
        </div>
  
        <div class="tab_mission_runtime">
              <asp:UpdatePanel ID="updatePanelOtopn" runat="server">
        <ContentTemplate>
             <div id="dvSetting" runat="server" >
                <UCSetting:Setting ID="SettingOption" runat="server" />
            </div>
             <div id="dvFeedBack" runat="server" visible="false">
                <UCFeedBack:FeedBack ID="FeedBackMessages" runat="server" />
            </div>
             <div id="dvREportProblem" runat="server" visible="false">
                <UCReportProblem:REportProblem ID="REportProblems1" runat="server" />
            </div>
                    <div id="dvTickets" runat="server" visible="false">
                <UCTickets:Tickets ID="Tickets1" runat="server" />
            </div>
                <div id="dvChangePassword" runat="server" visible="false">
                <UCChangePassword:ChangePassword ID="Password" runat="server" />
            </div>
             <div id="dvPrivacy" runat="server" visible="false">
                <UCPrivacy:Privacy ID="PrivacySetting" runat="server" />
            </div>
             <div id="dvNotification" runat="server" visible="false">
                <UCNotification:Notification ID="NotificationSetting" runat="server" />
            </div>
             </ContentTemplate>
             </asp:UpdatePanel>
        </div>
       
    </div>
    </div>
    </form>
</body>
</html>
