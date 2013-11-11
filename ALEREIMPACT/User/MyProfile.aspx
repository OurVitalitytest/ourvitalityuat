<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="ALEREIMPACT.User.MyProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UCMyProfile" TagName="Profile" Src="~/User/ucMyProfile.ascx" %>
<%@ Register TagPrefix="UCUserProfile" TagName="UserProfile" Src="~/User/ucUserProfile.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../CSS/stylenewdesign.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Circlestyle.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/global.css" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script type="text/javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "MyProfile.aspx/ProcessIT",
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="center_section_mission">
        <div class="mission_tab">
            <asp:UpdatePanel ID="UpdatePAnelProfile" runat="server">
                <ContentTemplate>
                    <div class="tab_mission_runtime">
                        <div id="dvMyProfile" runat="server">
                            <UCMyProfile:Profile ID="MyPrfile" runat="server" />
                        </div>
                         <div id="dvUserProfile" runat="server" visible="false">
                    <UCUserProfile:UserProfile ID="UserProfile" runat="server" />
                </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
