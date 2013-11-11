<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="ALEREIMPACT.User.MemberList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UserMemberlist" TagName="Form" Src="~/User/ucMemberList.ascx" %>
<%@ Register TagPrefix="UserCircles" TagName="Form" Src="~/User/ucCircleList.ascx" %>
<%@ Register TagPrefix="UserCtMemberProfile" TagName="MemberProfile" Src="~/User/ucMemberProfile.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="headmission" runat="server">
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
                    url: "MemberList.aspx/ProcessIT",
                    data: "{}",
                    dataType: "json",
                    success: function(data) {

                    },
                    error: function(result) {

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
            <%--  <a href="Wall.aspx">
                <div class="mission_tab_num sel">
                    Notes</div>
            </a><a href="Inspirators.aspx">
                <div class="mission_tab_num ">
                    inspirators</div>
            </a><a href="Missions.aspx">
                <div class="mission_tab_num ">
                    missions</div>
            </a><a href="progress.html">
                <div class="mission_tab_num ">
                    Progress</div>
            </a><a href="journal.html">
                <div class="mission_tab_num ">
                    Journal</div>
            </a>--%>
        </div>
        <asp:UpdatePanel ID="udpUpdatePaneMList" runat="server">
            <ContentTemplate>
                <div id="dvmemberlist" runat="server">
                    <UserMemberlist:Form ID="frmfriendlist" runat="server" />
                </div>
                <div id="dvcircles" runat="server">
                    <UserCircles:Form ID="frmAllCircles" runat="server" />
                </div>
                <div id="divMemberProfile" runat="server">
                    <UserCtMemberProfile:MemberProfile ID="ucMemberProfile" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
