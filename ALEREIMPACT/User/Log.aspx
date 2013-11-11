<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="ALEREIMPACT.User.Log" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UserTrackMission" TagName="Log" Src="~/User/ucTrackMission.ascx" %>
<%@ Register TagPrefix="UserFoodLog" TagName="FoodLog" Src="~/User/ucFoodLog.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <link rel="stylesheet" href="../CSS/stylenewdesign.css" type="text/css" />
<%--    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/Circlestyle.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/global.css" type="text/css" />
<style type="text/css">
.tab_mission_runtime div div
{
    line-height: 10px !important;
}


.scroller_food_item .act_col3_data {
    padding: 0;
    text-align: center;
    width: 15% !important;
}
.scroller_food_item .act_col2_data {
    padding: 0;
    width: 17% !important;
}
.header_items_css .act_col2 {
    font-size: 14px !important;
    text-align: center;
    width: 17% !important;
}

.scroller_food_item > td {
    float: left;
    height: 15px;
    width: 8% !important;
}
.act_col2_data {
    border-top: medium none !important;
    float: left !important;
    margin-bottom: 5px;
    margin-top: 7px;
    padding-left: 13px;
    text-align: left;
    width: 19% !important;
}
.act_col2 {
    color: #666666;
    float: left;
    font-family: arial;
    font-size: 14px;
    font-weight: bold;
    margin-bottom: 5px;
    margin-top: 7px;
    text-align: left;}
	
	.act_col3 {
    color: #666666;
    float: left;
    font-family: arial;
    font-size: 14px;
    font-weight: bold;
    margin-bottom: 5px;
    margin-top: 7px;
    text-align: left;
   
   }
.header_items_css .act_col4 {
    color: #666666;
    float: left;
    font-family: arial;
    font-size: 14px !important;
    font-weight: bold;
    margin-bottom: 5px;
    margin-top: 7px;
    text-align: center !important;
    width: 12% !important;
}

.header_items_css .act_col4 {
        width: 11% !important;;
}

#trackMission_GrdActivitiesLog .header_items_css .act_col1 {
    font-size: 14px !important;
    text-align: center;
    width: 13% !important;
}
.header_items_css .act_col3 {
    font-size: 14px !important;
    line-height: 17px !important;
    margin-top: 13px;
    text-align: center;
    width: 16% !important; 
}
a {
    color: #444444;

}

#trackMission_GrdActivitiesLog .scroller_food_item .act_col1_data {
    width: 13% !important;
}
.act_col1 {padding-left: 4px !important;}
.header_items_css { 

    width: 476px !important;
}
</style>
    <script type="text/javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Log.aspx/ProcessIT",
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
    <form id="formLog" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="center_section_mission">
        <div class="mission_tab">
        
         <div class="tab_mission_runtime">
           <div id="dvTrackMission" runat="server">
                    <UserTrackMission:Log ID="trackMission" runat="server" />
                </div>
                 <div id="dvFoodLog" runat="server" visible="false">
                    <UserFoodLog:FoodLog ID="Foodlog" runat="server" />
                </div>
        </div>
    </div>
    
    </div>
    </form>
</body>
</html>
