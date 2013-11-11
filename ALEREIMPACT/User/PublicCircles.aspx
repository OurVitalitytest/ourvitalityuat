<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicCircles.aspx.cs" Inherits="ALEREIMPACT.User.PublicCircles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UserCirclePublic" TagName="Public" Src="~/User/ucAllCircles.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <script type="text/javascript" language="javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "PublicCircles.aspx/ProcessIT",
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

    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    <div class="center_section_mission">
        <div class="mission_tab">
        
         <div class="tab_mission_runtime">
           <div id="dvPublicCircle" runat="server">
                    <UserCirclePublic:Public ID="UserPublicCircles" runat="server" />
                </div>
              
        </div>
    </div>
    
    </div>
    </form>
</body>
</html>
