<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Missions.aspx.cs" Inherits="ALEREIMPACT.User.Missions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UserCt" TagName="Missions" Src="~/User/ucMission.ascx" %>
<%@ Register TagPrefix="UserListMission" TagName="Missions" Src="~/User/ucListMissions.ascx" %>

<%@ Register TagPrefix="ucMissionHistory" TagName="MissionsHistory" Src="~/User/ucMissionHistory.ascx" %>
<%@ Register TagPrefix="ucMissionGraph" TagName="MissionsGraph" Src="~/User/ucMissionGraph.ascx" %>
<%@ Register TagPrefix="ucMissionFoodEssentials" TagName="MissionsFoodEssentials"
    Src="~/User/ucFoodEssentials.ascx" %>
<%@ Register TagPrefix="ucMissionOptions" TagName="MissionsOptions" Src="~/User/ucMissionOptions.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="headmission" runat="server">
    <title></title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <link rel="stylesheet" href="../CSS/stylenewdesign.css" type="text/css" />
<%--    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/Circlestyle.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/global.css" type="text/css" />

    <script type="text/javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Missions.aspx/ProcessIT",
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
    <form id="frmmission" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="center_section_mission">
        <div class="mission_tab">
            <%-- <a href="Wall.aspx">
                <div class="mission_tab_num">
                    Notes</div>
            </a><a href="Inspirators.aspx">
                <div class="mission_tab_num ">
                    inspirators</div>
            </a><a href="Missions.aspx">
                <div class="mission_tab_num sel">
                    missions</div>
            </a><a href="progress.html">
                <div class="mission_tab_num ">
                    Progress</div>
            </a><a href="journal.html">
                <div class="mission_tab_num ">
                    Journal</div>
            </a>--%>
            <div class="tab_mission_runtime">
                <div id="dvCreateMission" runat="server" visible="false">
                    <UserCt:Missions ID="misCreate" runat="server" />
                </div>
                <div id="dvListMissions" runat="server" visible="false">
                    <UserListMission:Missions ID="misList" runat="server" />
                </div>
              
                <div id="dvMissionHistory" runat="server" visible="false">
                    <ucMissionHistory:MissionsHistory ID="historyMission" runat="server" />
                </div>
                <div id="dvMissionGraphs" runat="server" visible="false">
                    <ucMissionGraph:MissionsGraph ID="MissionsGraphs" runat="server" />
                </div>
                <div id="divMissionFoodEssentials" runat="server" visible="false">
                    <ucMissionFoodEssentials:MissionsFoodEssentials ID="MissionFoodEssentials" runat="server" />
                </div>
                <div id="divMissionOptions" runat="server" visible="false">
                    <ucMissionOptions:MissionsOptions ID="MissionsOpt" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
