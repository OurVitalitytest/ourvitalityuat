<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="ALEREIMPACT.User.Progress" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<%@ Register TagPrefix="ucProgressGraph" TagName="MissionsGraphProgress" Src="~/User/ucProgressGraph.ascx" %>--%>
<%@ Register TagPrefix="ucProgressGraph" TagName="MissionsGraphProgress" Src="~/User/ucProgressGraphs.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="headmission" runat="server">
    <title></title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
    <%--    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/index.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/mission.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false">
    </asp:ToolkitScriptManager>
    <div class="center_section_mission">
        <div class="mission_tab">
            <div class="tab_mission_runtime">
                <div id="dvMissionGraphs" runat="server">
                    <ucProgressGraph:MissionsGraphProgress ID="MissionsGraphsProgress" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
