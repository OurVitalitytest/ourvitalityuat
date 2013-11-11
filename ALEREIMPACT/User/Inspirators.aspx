<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inspirators.aspx.cs" Inherits="ALEREIMPACT.User.Inspirators" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UserCt" TagName="Inspirators" Src="~/User/ucInspirators.ascx" %>
<%@ Register TagPrefix="UserInspiratorLibrary" TagName="Inspirators" Src="~/User/LibraryInspirators.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="headIns" runat="server">
    <title></title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />

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
    <form id="frmins" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="center_section_mission">
        <div class="mission_tab">
            <%-- <a href="Wall.aspx">
                <div class="mission_tab_num ">
                    Notes</div>
            </a><a href="Inspirators.aspx">
                <div class="mission_tab_num sel">
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
        <div class="tab_mission_runtime"  style="padding-bottom:0px !important; height:923px !important;">
            <div id="dvInspirator" runat="server" visible="false">
                <UserCt:Inspirators ID="Inspirator" runat="server" />
            </div>
            
            <div id="dvInspLibrary" runat="server" visible="false">
                <UserInspiratorLibrary:Inspirators ID="InspiratorsLibrary" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
