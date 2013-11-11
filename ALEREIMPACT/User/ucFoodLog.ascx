<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFoodLog.ascx.cs" Inherits="ALEREIMPACT.User.ucFoodLog" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="~/User/ucProgressBar.ascx" TagName="Progressbar" TagPrefix="uc1" %>
<%@ Register Src="~/User/ucProgressBarCaloriesEaten.ascx" TagName="ProgressbarCaloriesConsume"
    TagPrefix="uc2" %>

<script type="text/javascript" src="../scripts/jquery.js"></script>

<script src="../js/jquery-1.8.0.min.js" type="text/javascript"></script>

<script type="text/javascript" src="../scripts/index.js"></script>

<link rel="stylesheet" type="text/css" href="../CSS/default.css" />
<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="../CSS/index.css">
<link href="../CSS/style.css" type="text/css" rel="stylesheet" />
<style type="text/css">

    @media screen and (-webkit-min-device-pixel-ratio:0)
    {
        .listItem
        {
            width: 300px !important;
            float: left;
            line-height: 15px !important;
            color: #444 !important;
            font-size: 9px !important;
        }
        .itemHighlighted
        {
            font-size: 5px !important;
            background: #ccc !important;
            color: #000 !important;
            font-family: arial;
            font-size: 9px;
            float: left;
            line-height: 15px !important;
        }
        .completionList li:hover
        {
            width: 300px !important;
            background: #ccc !important;
            line-height: 15px !important;
            font-size: 9px !important;
        }
        .completionList ul
        {
            font-size: 9px !important;
            font-family: Arial;
            font-weight: bold !important;
            line-height: 9px !important;
            width: 300px !important;
        }
        .completionList li
        {
            font-size: 9px !important;
            font-family: Arial;
            font-weight: bold !important;
            line-height: 9px !important;
            width: 300px !important;
        }
        .completionList
        {
            background-color: #FFFFFF;
            border: 0 none !important;
            box-shadow: 1px 0 2px 2px #CCCCCC;
            float: left;
            font-size: 9px !important;
            font-weight: bold !important;
            height: auto;
            margin-bottom: 0;
            width: 100%;
            margin-left: 3px !important;
            margin-right: 0;
            margin-top: 3px !important;
            overflow: hidden;
            padding: 2px;
            width: 37% !important;
        }
        .ae
        {
            height: 50px;
            border-bottom: 1px solid #ccc;
        }
        .ae1
        {
            margin-top: 6px;
            float: left;
            margin-left: 7px;
        }
        .ae2
        {
            font-size: 9px !important;
            float: left;
            margin-left: 10px;
            margin-top: 8px;
            font-family: arial;
            font-weight: normal;
        }
        .ae3
        {
            float: left;
            margin-left: 10px;
            margin-top: 8px;
            font-size: 9px !important;
            font-family: arial;
            font-weight: bold;
        }
        .profile
        {
            float: left;
        }
        .completionList li
        {
            width: 100%;
            float: left;
            font-size: 13px !important;
            width: 350px !important;
            border-bottom: 1px solid #ccc;
            padding: 2px;
            line-height: 21px;
            text-transform: capitalize;
        }
        .completionList li:hover
        {
            width: 350px !important;
            line-height: 21px;
            text-transform: capitalize;
        }
        .middle_date_new
        {
            background: none repeat scroll 0 0 rgba(0, 0, 0, 0);
            border-radius: 4px 4px 4px 4px;
            color: #FFFFFF;
            font-size: 12px;
            margin-left: 7px;
            width: 66px !important;
        }
        .act_right_arrow
        {
            float: left;
            margin: 1px 10px 0;
        }
        .link_top_bar
        {
            clear: both;
            color: #888888;
            float: right !important;
            font-size: 12px !important;
            margin-bottom: 12px;
            margin-right: 9px;
            margin-top: 5px;
        }
        .center_section_mission
        {
            float: left;
            width: 99%;
        }
        #Foodlog_GrdFAvFoodLog span
        {
            font-family: arial;
            font-size: 11px !important;
            line-height: 20px;
            text-transform: lowercase;
        }
        .center_food_log
        {
            border: 1px solid #EEEEEE;
            border-radius: 4px 4px 4px 4px;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12px;
            margin: 5px auto;
            overflow: hidden;
            padding: 15px;
            width: 95%;
        }
        .left_section_food_log
        {
            background: none repeat scroll 0 0 #F8F6F6;
            border: 1px solid #EDEDED;
            float: left !important;
            margin-right: 1%;
            padding: 10px;
            width: 66%;
        }
        .rgt_section_food_log
        {
            background: none repeat scroll 0 0 #F8F6F6;
            border: 1px solid #EDEDED;
            float: right !important;
            padding: 10px;
            width: 28%;
        }
        .tab_mission_runtime
        {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #CCCCCC;
            border-radius: 4px 4px 4px 4px;
            float: left;
            margin-left: 4px;
            margin-top: 10px;
            padding-bottom: 15px;
            width: 99%;
        }
        .burned_box
        {
            background: none repeat scroll 0 0 #F8E1E1;
            border-bottom: 9px solid #CE5959;
            color: #CE5959;
            float: left;
            font-size: 17px;
            padding: 14px;
            text-align: center;
            width: 36%;
            min-height: 100px;
        }
        .select_option_food
        {
            box-shadow: 1px 2px 4px 2px #DDDDDD;
            color: #999999;
            height: 35px;
            line-height: 33px;
            margin-top: 5px;
            padding: 9px 5px;
            width: 65%;
        }
        #Foodlog_spTodayMsg
        {
            font-size: 17px;
            line-height: 19px;
        }
        .table_food_data
        {
            border: 1px solid #EEEEEE;
            margin: 0 auto;
            overflow: hidden;
            width: 100%;
        }
        .table_food_header
        {
            background: url("../images/bg_log.png") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
            float: left;
            width: 100%;
        }
        .table_food_header_fav
        {
            background: url("../images/bg_log.png") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
            float: left;
            width: 272px;
            font-size: 10px;
        }
        .serving_table
        {
            border-right: 1px solid #CCCCCC;
            color: #666666;
            float: left;
            line-height: 42px;
            padding-left: 0;
            text-align: center;
            width: 10%;
        }
        .fav_table
        {
            color: #666666;
            float: left;
            line-height: 42px;
            margin-top: 1px;
            padding-left: 0;
            text-align: center;
            width: 4%;
        }
        .cal_table
        {
            border-right: 1px solid #CCCCCC;
            color: #666666;
            float: left;
            line-height: 42px;
            padding-left: 0;
            text-align: center;
            width: 7%;
        }
        .fat_table
        {
            border-right: 1px solid #CCCCCC;
            color: #666666;
            float: left;
            line-height: 42px;
            padding-left: 0;
            text-align: center;
            width: 8%;
        }
        .sod_table
        {
            border-right: 1px solid #CCCCCC;
            color: #666666;
            float: left;
            line-height: 42px;
            padding-left: 0;
            text-align: center;
            width: 8%;
        }
        #Foodlog_GrdFoodLog
        {
            width: 100%;
        }
        #Foodlog_lnkActivities
        {
            color: #000;
        }
        #Foodlog_lnkFood
        {
            float: left;
            padding: 3px 0 0 18px;
        }
        .bg_sel_tab
        {
            line-height: 23px;
        }
        #Foodlog_spBurnMsg
        {
            font-size: 17px;
            line-height: 28.5px;
        }
        .box_search_food
        {
            font-size: 13px;
            text-transform: capitalize;
            font-family: Arial;
        }
        .food_table
        {
            border-right: 1px solid #CCCCCC;
            color: #666666;
            float: left;
            line-height: 42px;
            padding-left: 2%;
            width: 43%;
        }
        .fav_table input
        {
            margin-top: 10px;
            float: left;
        }
        .fav_table
        {
            color: #666666;
            float: left;
            line-height: 42px;
            margin-top: 1px;
            padding-left: 0;
            text-align: center;
            width: 6%;
        }
        .left_section_food_log div#Foodlog_modPopUpASddCustomPopUp_foregroundElement, div#Foodlog_modalPopActivities_foregroundElement, .table_section > div#Foodlog_MdlQuickLog_FoodLog_foregroundElement
        {
            top: 50px !important;
        }
        .left_section_food_log > div#Foodlog_modPopUpASddCustomPopUp_backgroundElement, div#Foodlog_modalPopActivities_backgroundElement, .table_section > div#Foodlog_MdlQuickLog_FoodLog_backgroundElement
        {
            background: none repeat scroll 0 0 #9F9F9F !important;
            opacity: 0.5 !important;
            width: 1025px !important;
        }
        .consumed_box span
        {
            float: left;
            font-size: 20px;
            text-align: center;
            width: 100%;
        }
        .burned_box span
        {
            color: #CE5959;
            float: left;
            font-size: 20px;
            text-align: center;
            width: 100%;
        }
        .consumed_box
        {
            background: none repeat scroll 0 0 #E1FFE9;
            border-bottom: 9px solid #24A655;
            color: #24A655;
            float: left;
            font-size: 17px;
            padding: 14px;
            text-align: center;
            width: 41%;
        }
    }
    .listItem
    {
        width: 300px !important;
        float: left;
        line-height: 15px !important;
        color: #444 !important;
        font-size: 9px !important;
    }
    .itemHighlighted
    {
        font-size: 5px !important;
        background: #ccc !important;
        color: #000 !important;
        font-family: arial;
        font-size: 9px;
        float: left;
        line-height: 15px !important;
    }
    .completionList li:hover
    {
        width: 300px !important;
        background: #ccc !important;
        line-height: 15px !important;
        font-size: 9px !important;
    }
    .completionList ul
    {
        font-size: 9px !important;
        font-family: Arial;
        font-weight: bold !important;
        line-height: 9px !important;
        width: 300px !important;
    }
    .completionList li
    {
        font-size: 9px !important;
        font-family: Arial;
        font-weight: bold !important;
        line-height: 9px !important;
        width: 300px !important;
    }
    .completionList
    {
        background-color: #FFFFFF;
        border: 0 none !important;
        box-shadow: 1px 0 2px 2px #CCCCCC;
        float: left;
        font-size: 9px !important;
        font-weight: bold !important;
        height: auto;
        margin-bottom: 0;
        width: 100%;
        margin-left: 3px !important;
        margin-right: 0;
        margin-top: 3px !important;
        overflow: hidden;
        padding: 2px;
        width: 37% !important;
    }
    .ae
    {
        height: 50px;
        border-bottom: 1px solid #ccc;
    }
    .ae1
    {
        margin-top: 6px;
        float: left;
        margin-left: 7px;
    }
    .ae2
    {
        font-size: 9px !important;
        float: left;
        margin-left: 10px;
        margin-top: 8px;
        font-family: arial;
        font-weight: normal;
    }
    .ae3
    {
        float: left;
        margin-left: 10px;
        margin-top: 8px;
        font-size: 9px !important;
        font-family: arial;
        font-weight: bold;
    }
    .profile
    {
        float: left;
    }
    .completionList li
    {
        width: 100%;
        float: left;
        font-size: 13px !important;
        width: 350px !important;
        border-bottom: 1px solid #ccc;
        padding: 2px;
        line-height: 21px;
        text-transform: capitalize;
    }
    .completionList li:hover
    {
        width: 350px !important;
        line-height: 21px;
        text-transform: capitalize;
    }
    .middle_date_new
    {
        background: none repeat scroll 0 0 rgba(0, 0, 0, 0);
        border-radius: 4px 4px 4px 4px;
        color: #FFFFFF;
        font-size: 12px;
        margin-left: 7px;
        width: 66px !important;
    }
    .act_right_arrow
    {
        float: left;
        margin: 1px 10px 0;
    }
    .link_top_bar
    {
        clear: both;
        color: #888888;
        float: right !important;
        font-size: 12px !important;
        margin-bottom: 12px;
        margin-right: 9px;
        margin-top: 5px;
    }
    .center_section_mission
    {
        float: left;
        width: 99%;
    }
    #Foodlog_GrdFAvFoodLog span
    {
        font-family: arial;
        font-size: 11px !important;
        line-height: 20px;
        text-transform: lowercase;
    }
    .center_food_log
    {
        border: 1px solid #EEEEEE;
        border-radius: 4px 4px 4px 4px;
        font-family: Arial,Helvetica,sans-serif;
        font-size: 12px;
        margin: 5px auto;
        overflow: hidden;
        padding: 15px;
        width: 95%;
    }
    .left_section_food_log
    {
        background: none repeat scroll 0 0 #F8F6F6;
        border: 1px solid #EDEDED;
        float: left !important;
        margin-right: 1%;
        padding: 10px;
        width: 66%;
    }
    .rgt_section_food_log
    {
        background: none repeat scroll 0 0 #F8F6F6;
        border: 1px solid #EDEDED;
        float: right !important;
        padding: 10px;
        width: 28%;
    }
    .tab_mission_runtime
    {
        background: none repeat scroll 0 0 #FFFFFF;
        border: 1px solid #CCCCCC;
        border-radius: 4px 4px 4px 4px;
        float: left;
        margin-left: 4px;
        margin-top: 10px;
        padding-bottom: 15px;
        width: 99%;
    }
    .burned_box
    {
        background: none repeat scroll 0 0 #F8E1E1;
        border-bottom: 9px solid #CE5959;
        color: #CE5959;
        float: left;
        font-size: 17px;
        padding: 14px;
        text-align: center;
        width: 36%;
        min-height: 100px;
    }
    .select_option_food
    {
        box-shadow: 1px 2px 4px 2px #DDDDDD;
        color: #999999;
        height: 35px;
        line-height: 33px;
        margin-top: 5px;
        padding: 9px 5px;
        width: 65%;
    }
    #Foodlog_spTodayMsg
    {
        font-size: 17px;
        line-height: 19px;
    }
    .table_food_data
    {
        border: 1px solid #EEEEEE;
        margin: 0 auto;
        overflow: hidden;
        width: 100%;
    }
    .table_food_header
    {
        background: url("../images/bg_log.png") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
        float: left;
        width: 100%;
    }
    .table_food_header_fav
    {
        background: url("../images/bg_log.png") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
        float: left;
        width: 272px;
        font-size: 10px;
    }
    .serving_table
    {
        border-right: 1px solid #CCCCCC;
        color: #666666;
        float: left;
        line-height: 42px;
        padding-left: 0;
        text-align: center;
        width: 10%;
    }
    .fav_table
    {
        color: #666666;
        float: left;
        line-height: 42px;
        margin-top: 1px;
        padding-left: 0;
        text-align: center;
        width: 4%;
    }
    .cal_table
    {
        border-right: 1px solid #CCCCCC;
        color: #666666;
        float: left;
        line-height: 42px;
        padding-left: 0;
        text-align: center;
        width: 7%;
    }
    .fat_table
    {
        border-right: 1px solid #CCCCCC;
        color: #666666;
        float: left;
        line-height: 42px;
        padding-left: 0;
        text-align: center;
        width: 8%;
    }
    .sod_table
    {
        border-right: 1px solid #CCCCCC;
        color: #666666;
        float: left;
        line-height: 42px;
        padding-left: 0;
        text-align: center;
        width: 8%;
    }
    #Foodlog_GrdFoodLog
    {
        width: 100%;
    }
    .lnkActivitiess
    {
        color: #000;
        padding: 0px 0px 0px 11px !important;
    }
    #Foodlog_lnkFood
    {
        float: left;
        padding: 3px 0 0 18px;
    }
    .bg_sel_tab
    {
        line-height: 23px;
    }
    #Foodlog_spBurnMsg
    {
        font-size: 17px;
        line-height: 28.5px;
    }
    .box_search_food
    {
        font-size: 13px;
        text-transform: capitalize;
        font-family: Arial;
    }
    .food_table
    {
        border-right: 1px solid #CCCCCC;
        color: #666666;
        float: left;
        line-height: 42px;
        padding-left: 2%;
        width: 43%;
    }
    .fav_table input
    {
        margin-top: 10px;
        float: left;
    }
    .fav_table
    {
        color: #666666;
        float: left;
        line-height: 42px;
        margin-top: 1px;
        padding-left: 0;
        text-align: center;
        width: 6%;
    }
    .left_section_food_log div#Foodlog_modPopUpASddCustomPopUp_foregroundElement, div#Foodlog_modalPopActivities_foregroundElement, .table_section > div#Foodlog_MdlQuickLog_FoodLog_foregroundElement
    {
        top: 50px !important;
    }
    .left_section_food_log > div#Foodlog_modPopUpASddCustomPopUp_backgroundElement, div#Foodlog_modalPopActivities_backgroundElement, .table_section > div#Foodlog_MdlQuickLog_FoodLog_backgroundElement
    {
        background: none repeat scroll 0 0 #9F9F9F !important;
        opacity: 0.5 !important;
        width: 1025px !important;
    }
    .consumed_box span
    {
        float: left;
        font-size: 20px;
        text-align: center;
        width: 100%;
    }
    .burned_box span
    {
        color: #CE5959;
        float: left;
        font-size: 20px;
        text-align: center;
        width: 100%;
    }
    .consumed_box
    {
        background: none repeat scroll 0 0 #E1FFE9;
        border-bottom: 9px solid #24A655;
        color: #24A655;
        float: left;
        font-size: 17px;
        padding: 14px;
        text-align: center;
        width: 41%;
        min-height: 100px;
    }
	
</style>
<style type="text/css">
.select_option_food
        {
            height: 35px;
		}
</style>

<script type="text/javascript">
    $(function() {
        $('.clsOnlyAlphs').keydown(function(e) {
            // alert(e.keyCode);
            if (e.ctrlKey || e.altKey) {
                e.preventDefault();
            } else {
                var key = e.keyCode;
                if (!((key == 8) || (key == 32) || (key == 9) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                    e.preventDefault();
                }
               
            }
        });
    });
    //cpna
    $(function () {
        $('.clsOnlyAlphs').bind("copy paste", function(e) {
            // alert(e.keyCode);
            e.preventDefault();
            alert("Copy and Paste not allowed.");


        });
    });
    $(function() {
    $('.cpna').bind("copy paste", function(e) {
    // alert(e.keyCode);
            
            e.preventDefault();
            alert("Copy and Paste not allowed.");


        });
    });

    $(function() {
        $('.clsOnlyNumeric').keydown(function(e) {
            if (e.shiftKey || e.ctrlKey || e.altKey) {
                e.preventDefault();
            } else {
                var key = e.keyCode;
                if (!((key == 8) || (key == 46) || (key == 9) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
                    e.preventDefault();
                }
            }
        });
    });


    window.onload = function() {


        //document.getElementById('GrdFoodLog_ctl02_ImageButton13').style.display = 'none';
    };

    function HideSearch() {

        document.getElementById('dvSerach').style.display = 'none';

    }

    function Checkvalidity() {




        if (document.getElementById('<%= txtSearch.ClientID %>').value == 'Search Food') {

            alert(" Please Enter Food Name");
            return false;
        }
        else {
            return true;
        }

    }
    function ShowFavContent(rowIndex) {
        //Foodlog_GrdFAvFoodLog
        var gridview = document.getElementById("<%= GrdFAvFoodLog.ClientID %>");
        var RowNumber = (+rowIndex + 1).toString();


        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }

        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImgLnkdelete").style.display = 'block';
        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImgAddLog").style.display = 'block';


    }
    function HideFavContent(rowIndex) {
        var gridview = document.getElementById("<%= GrdFAvFoodLog.ClientID %>");
        var RowNumber = (+rowIndex + 1).toString();


        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }

        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImgLnkdelete").style.display = 'none';
        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImgAddLog").style.display = 'none';

    }
    function showContents(rowIndex) {


        var gridview = document.getElementById("<%= GrdFoodLog.ClientID %>");
        var RowNumber = (+rowIndex + 1).toString();


        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }

        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImageButton13").style.display = 'block';
        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImageButton1").style.display = 'block';



    }
    function HideElemments(rowIndex) {
        var gridview = document.getElementById("<%= GrdFoodLog.ClientID %>");

        var RowNumber = (+rowIndex + 1).toString();
        // alert(RowNumber);

        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }
        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImageButton13").style.display = 'none';


        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImageButton1").style.display = 'none';


    }


    var searh_critereia;
    var findcirle_new_pos;
    var findallmember;
    function OnClientPopulated(sender, e) {
        var autoList = $find("AutoCompleteEx").get_completionList();
        //autoList.childNodes[0].innerHTML = " Food    Calories    Fat   Carb   Protien ";

        autoList.childNodes[0].innerHTML = "<table width='100%' style='font-size:12px; height:20px;'><td width='42%'>" + "Food Name" + "</td><td width='10%'>" + "Size" + "</td><td width='10%'>" + "Cal" + "</td><td width='10%'>" + "chol" + "</td> <td width='10%'>" + "Fiber" + "</td> <td width='10%'>" + "Sugar" + "</td><td width='10%'>" + "Fat" + "</td></table>";
        for (i = 1; i < autoList.childNodes.length; i++) {

            var text = autoList.childNodes[i].firstChild.nodeValue;

            autoList.childNodes[i]._value = text;

            var memname = text.split('|');
            // autoList.childNodes[i].innerHTML = "<div class='ae2'>" + memname[0] + "&nbsp;" + memname[1] + ":" + memname[2] + memname[3] + "</div>";

            autoList.childNodes[i].innerHTML = "<table width='100%' class='ae2'><tr><td width='40%'>" + memname[0] + "</td><td width='10%'>" + memname[1] + "</td><td width='10%'>" + memname[2] + "</td><td width='10%'>" + memname[3] + "</td><td width='10%'>" + memname[4] + "</td><td width='10%'>" + memname[5] + "</td><td width='10%'>" + memname[6] + "</td></table>";
            // Consider value as image path

        }

        if (document.getElementById('<%= txtSearch.ClientID %>').value == '' || document.getElementById('<%= txtSearch.ClientID %>').value == "Search Food") {


            document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';
        }


        var findcircele = autoList.childNodes.length;
        findcirle_new_pos = findcircele - 2;
        findallmember = findcircele - 1;
        searh_critereia = document.getElementById('<%= txtSearch.ClientID %>').value;
        autoList.childNodes[findallmember].innerHTML = "See More Results for:" + "  " + document.getElementById('<%= txtSearch.ClientID %>').value;



    }


    function ace1_itemSelected(source, e) {



        var selInd = $find("AutoCompleteEx")._selectIndex;

        if (selInd != -1)
            if (selInd == 0) {


            document.getElementById('<%= txtSearch.ClientID %>').value = "";
            $find("AutoCompleteEx").get_element().value = "Search Food";
            return;
        }
        if (selInd == findallmember) {


            document.getElementById('<%= hdsearhresult.ClientID %>').value = searh_critereia;

            document.getElementById('Foodlog_btnseachfoodlog').click();



        }
        else {


            var selval = $find("AutoCompleteEx").get_completionList().childNodes[selInd]._value;


            var selvalmemname = selval.split('|');

            $find("AutoCompleteEx").get_element().value = selvalmemname[0];

            document.getElementById('<%= hdproducname.ClientID %>').value = selvalmemname[0];
            document.getElementById('<%= hdproductsize.ClientID %>').value = selvalmemname[1];
            document.getElementById('servingsize').style.display = 'block';
            document.getElementById('servingSizeValue').innerHTML = document.getElementById('<%= hdproductsize.ClientID %>').value;
            document.getElementById('<%= hdcal.ClientID %>').value = selvalmemname[2];
            document.getElementById('<%= hdchol.ClientID %>').value = selvalmemname[3];
            document.getElementById('<%= hdfiber.ClientID %>').value = selvalmemname[4];
            document.getElementById('<%= hdsugars.ClientID %>').value = selvalmemname[5];
            document.getElementById('<%= hdfat.ClientID %>').value = selvalmemname[6];
        }

        //  var memid = $find("AutoCompleteEx").get_element().value.split('|');


    }


    function SaveFoodLog() {
        var hdn1 = document.getElementById('<%= hdproducname.ClientID %>').value;
        var hdn2 = document.getElementById('<%= hdproductsize.ClientID %>').value;
        var hdn3 = document.getElementById('<%= hdcal.ClientID %>').value;
        var hdn4 = document.getElementById('<%= hdchol.ClientID %>').value;
        var hdn5 = document.getElementById('<%= hdfiber.ClientID %>').value;
        var hdn6 = document.getElementById('<%= hdsugars.ClientID %>').value;
        var hdn7 = document.getElementById('<%= hdfat.ClientID %>').value;





    }
</script>

<script type="text/javascript">

    function ShowImage() {

        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'url(../images/searchload.gif)';
        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundRepeat = 'no-repeat';
        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundPosition = 'right';

        if (document.getElementById('<%= txtSearch.ClientID %>').value == '') {

            document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';
        }

    }
    function HideImage() {

        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';

    }
    var typingTimer;                //timer identifier
    var doneTypingInterval = 6000;  //time in ms, 5 second for example

    function displayunicode(e) {
        //alert(e.keyCode);
        //        clearTimeout(typingTimer);
        //        typingTimer = setTimeout(doneTyping, doneTypingInterval);

        if (e.keyCode == 13) {
            searh_critereia = document.getElementById('<%= txtSearch.ClientID %>').value;
            document.getElementById('<%= hdsearhresult.ClientID %>').value = searh_critereia;

            document.getElementById('Foodlog_btnseachfoodlog').click();

        }
        if (e.keyCode == 38 || e.keyCode == 40) {

        }
        if (e.keyCode == 8 || e.keyCode == 46) {
          
            var searh_length = document.getElementById('<%= txtSearch.ClientID %>').value;

            var searh_text_len = searh_length.length;
            

            if (searh_text_len == 0) {
                
                document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';

            }
            

//            var searh_length = document.getElementById('<%= txtSearch.ClientID %>').value.trim();

//            var searh_text_len = searh_length.length;

//            if (searh_text_len == 2) {


//                document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';

//            }


        }

    }
    //user is "finished typing," do something
    function doneTyping() {
        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';

    }

   
</script>

<script language="javascript" type="text/javascript">
    function alphanumeric_only(event) {
        var keycode;

        keycode = event.keyCode ? event.keyCode : event.which;


        if ((keycode == 32) || (keycode == 8) || (keycode >= 47 && keycode <= 57)) {

            return true;

        }

        else {
            return false;

        }
        return true;

    }


    function showConfirmForImages() {
        var msg = confirm('Are you sure you wish to add the selected food item as todays input ?');

        if (msg == true) {
            document.getElementById('<%=dvProgressBarForImages.ClientID %>').style.display = 'block';
            return true;
        }
        else {
            return false;
        }
    }
    function handleSubComment(selectedId, e) {

        var charCode = (e.which) ? e.which : e.keyCode

        if (charCode >= 65 && charCode <= 90 || charCode >= 97 && charCode <= 122 || charCode == 8 || charCode == 13 || charCode == 32) {

            if (e.keyCode == 13) {
                if (document.getElementById(selectedId.id).value != "") {
                    __doPostBack("txtSearch", "TextChanged");
                    document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';
                    e.preventDefault();
                }
                else {
                    alert('You must enter some keyword(s) in the search box !');
                    return false;
                }
            }
            return true;
        }
        else {
            return false;
        }



    }
    function ShowRegionForOptionOne() {
        document.getElementById('<%= tdRegionOptionOne.ClientID %>').style.display = 'block';
        document.getElementById('<%= tdRegionOptionTwo.ClientID %>').style.display = 'none';
        document.getElementById('<%= radOptionTwo.ClientID %>').checked = false;
        document.getElementById('<%= btnSave_QuickLog_2.ClientID %>').style.display = 'none';
        document.getElementById('<%= btnSave_QuickLog_1.ClientID %>').style.display = 'none';
        document.getElementById('<%= dvErrorMsgForYesterDayCalories.ClientID %>').style.display = 'none';
        document.getElementById('<%= spCalorieComparison.ClientID %>').innerHTML = '';
        document.getElementById('<%= tdComparison.ClientID %>').style.display = 'none';
        document.getElementById('<%= radLessthanYesterday.ClientID %>').checked = false;
        document.getElementById('<%= radMorethanYesterday.ClientID %>').checked = false;



    }
    function ShowRegionForOptionTwo() {
        document.getElementById('<%= tdRegionOptionOne.ClientID %>').style.display = 'none';
        document.getElementById('<%= tdRegionOptionTwo.ClientID %>').style.display = 'block';
        document.getElementById('<%= radOptionOne.ClientID %>').checked = false;
        document.getElementById('<%= btnSave_QuickLog_2.ClientID %>').style.display = 'block';
        document.getElementById('<%= btnSave_QuickLog_1.ClientID %>').style.display = 'none';
        document.getElementById('<%= dvErrorMsgForYesterDayCalories.ClientID %>').style.display = 'none';

    }
    function ShowRegionForLessCaloriesConsume() {
        document.getElementById('<%= tdComparison.ClientID %>').style.display = 'block';
        document.getElementById('<%= spCalorieComparison.ClientID %>').innerHTML = '';
        document.getElementById('<%= spCalorieComparison.ClientID %>').innerHTML = 'We will be assuming about 75 calories LESS than yesterday’s breakfast';
        document.getElementById('<%= radMorethanYesterday.ClientID %>').checked = false;
        document.getElementById('<%= dvErrorMsgForYesterDayCalories.ClientID %>').style.display = 'none';
    }
    function ShowRegionForMoreCaloriesConsume() {
        document.getElementById('<%= tdComparison.ClientID %>').style.display = 'block';
        document.getElementById('<%= spCalorieComparison.ClientID %>').innerHTML = '';
        document.getElementById('<%= spCalorieComparison.ClientID %>').innerHTML = 'We will be assuming about 75 calories MORE than yesterday’s breakfast';
        document.getElementById('<%= radLessthanYesterday.ClientID %>').checked = false;
        document.getElementById('<%= dvErrorMsgForYesterDayCalories.ClientID %>').style.display = 'none';
    }
    function SelectSingleRadiobutton(rdbtnid) {
        var rdBtn = document.getElementById(rdbtnid);
        var rdBtnList = document.getElementsByTagName("input");
        for (i = 0; i < rdBtnList.length; i++) {
            if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                rdBtnList[i].checked = false;
            }
        }
    }
    function Validate_QuickLogRadioButtons_FoodLog_Option1() {

        var valid = false;
        var gv = document.getElementById('Foodlog_dtFoodLogActivityImages');
        var chks = gv.getElementsByTagName('input');
        var hasChecked = false;
        for (var i = 0; i < chks.length; i++) {
            if (chks[i].checked) {
                hasChecked = true;
                break;
            }
        }
        if (hasChecked == false) {
            alert("Please select at least one option..!");

            return false;
        }


        document.getElementById('<%=dvProgressBarOnModalPop.ClientID %>').style.display = 'block';
        return true;
    }
    function Validate_QuickLogRadioButtons_FoodLog_Option2() {

        if (!document.getElementById('<%= radLessthanYesterday.ClientID %>').checked && !document.getElementById('<%= radMorethanYesterday.ClientID %>').checked) {
            alert("Please select at least one option..!");
            return false;
        }
        else {
            document.getElementById('<%=dvProgressBarOnModalPop.ClientID %>').style.display = 'block';
            return true;
        }
    }
</script>

<script type="text/javascript">
    function makeArray() {
        for (i = 0; i < makeArray.arguments.length; i++)
            this[i + 1] = makeArray.arguments[i];
    }
    function CheckMissionHistoryDate(sender, args) {
        var toDate = new Date();


        var selectedDate = sender._selectedDate;

        toDate.setMinutes(0);
        toDate.setSeconds(0);
        toDate.setHours(0);
        toDate.setMilliseconds(0);

        selectedDate.setMinutes(0);
        selectedDate.setSeconds(0);
        selectedDate.setHours(0);
        selectedDate.setMilliseconds(0);

        if (selectedDate > toDate) {

            alert("You can not select a Future Date !");
            document.getElementById('<%= txtCalendarNavigation.ClientID %>').value = '';

            var currentdate_date = new Date()
            var month = currentdate_date.getMonth() + 1;
            var currentdate = currentdate_date.getDate();
            var yy = currentdate_date.getYear();
            var year = (yy < 1000) ? yy + 1900 : yy;

            var months = new makeArray('January', 'February', 'March', 'April', 'May',
'June', 'July', 'August', 'September', 'October', 'November', 'December');

            document.getElementById('<%= txtCalendarNavigation.ClientID %>').value = currentdate + " " + months[month] + " " + year;

            return false;
        }
        else {
            document.getElementById('<%= hdnSelectedDateForMissionHistory.ClientID %>').value = document.getElementById('<%= txtCalendarNavigation.ClientID %>').value;
        }
    }

    function ShowProgresBarForFood() {
        document.getElementById('<%=dvFoodSelectedProgressBar.ClientID %>').style.display = 'block';

    }
    function showDivProgress() {
        if (document.getElementById('<%=txtAddNewFood.ClientID %>').value != '' && document.getElementById('<%=txtBrandName.ClientID %>').value != ''
            && document.getElementById('<%=txtServingSize.ClientID %>').value != '') {
            document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

        }
        else {
            document.getElementById('<%=dvUploader.ClientID %>').style.display = 'none';


        }
    }

    function ValidateInput(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if ((charCode < 48 || charCode > 57) && (charCode < 32 || charCode > 47) && (charCode < 58 || charCode > 64) && (charCode < 91 || charCode > 96) && (charCode < 123 || charCode > 126))
            return true;

        return false;
    }
</script>

<style type='text/css'>
    .just-td
    {
        background: #FFF;
        padding: 5px;
    }
    .just-td:hover
    {
        background: #eee;
    }
    #Foodlog_grData_ctl02_panel_pop
    {
        top: 0px !important;
    }
    .info, .success, .warning, .error, .validation
    {
        border: 1px solid;
        margin: 10px 0px;
        padding: 15px 10px 15px 50px;
        background-repeat: no-repeat;
        background-position: 10px center;
    }
    .warning
    {
        color: #9F6000;
        background-color: #FEE17A;
        background-image: url(     '../Images/warning.png' );
    }
    *
    {
        margin: 0;
        padding: 0;
    }
    /* --- Page Structure  --- */html
    {
        height: 100%;
    }
    .tab_mission_runtime div div tr td select
    {
        float: left !important;
        margin-left: 2px;
        margin-top: 3px;
    }
    body
    {
        min-width: 480px;
        width: 100%;
        height: 101%;
        color: #333;
        font: 76%/1.6 verdana,geneva,lucida, 'lucida grande' ,arial,helvetica,sans-serif;
        text-align: center;
    }
    #wrapper
    {
        margin-bottom: 30px;
        padding: 10px 2.5%;
        border-top: 0.1em solid #ccc;
        background: #fff;
        text-align: left;
        overflow: hidden;
    }
    #container
    {
        float: left;
        width: 100%;
        margin-right: -19em;
        padding: 0 0 1em;
        position: relative;
        min-height: 0;
    }
    #main
    {
        margin-right: 19em;
        position: relative;
        min-height: 0;
    }
    #side
    {
        float: right;
        display: inline;
        width: 18em;
        padding-bottom: 1.3em;
        position: relative;
        color: #e3e3e3;
        overflow: hidden;
    }
    p
    {
        margin: 0 10px 1em;
    }
    .strong
    {
        font-weight: 700;
    }
    .clear
    {
        clear: both;
    }
    img
    {
        border: 0 none;
    }
    /* --- Headings --- */h1
    {
        font-family: georgia, 'times new roman' ,times,serif;
        font-size: 2.5em;
        font-weight: normal;
        color: #f90;
    }
    h1, h2, h3
    {
        margin-bottom: 1em;
    }
    h2, h3, h4 a, h5 a
    {
        padding: 3px 10px;
    }
    h2, h3, h4, h5
    {
        font-size: 1em;
    }
    #main h2
    {
        background-color: #f0f0f0;
    }
    #side, #side h2, #side h3
    {
        background: #000;
        color: #e3e3e3;
    }
    #side h2
    {
        border-bottom: 1px solid #484b51;
    }
    /* --- Links --- */a
    {
        padding: 1px;
        color: #05b;
    }
    a:hover, a:focus, a:active
    {
        border-color: #bcd;
        text-decoration: none;
        outline: 0 none;
    }
    #side a
    {
        display: block;
        border-width: 0 0 1px;
        border-color: #445;
        color: #f0f0f0;
    }
    #side a:hover, #side a:active, #side a:focus
    {
        background-color: #334;
    }
    /* --- Accordion --- */.js #main .accordion
    {
        visibility: hidden;
    }
    .js #side .accordion
    {
        display: none;
    }
    .accordion
    {
        margin: 0;
        padding: 0 10px;
    }
    .accordion li
    {
        list-style-type: none;
    }
    .accordion li.last-child
    {
        margin-left: 19px;
        list-style-type: disc;
    }
    #side ul.accordion ul
    {
        margin: 0;
        padding: 0 0 0 20px;
    }
    .accordion .outer
    {
        border-width: 0 1px 1px;
        background: #EEE;
    }
    .accordion .inner
    {
        margin-bottom: 0;
        position: relative;
        overflow: hidden;
    }
    .accordion .inner .inner
    {
        padding-bottom: 0;
    }
    .accordion .h
    {
        padding-top: .3em;
    }
    /* vertical padding instead of vertical margin (ie8) */.accordion p
    {
        margin: .5em 1px 1em;
    }
    /*  
  Add styles for all links in the 'accordion':
.accordion a {...}
*/a.trigger
    {
        display: block;
        padding-left: 20px;
        background-image: url(../style/img/plus.gif);
        background-repeat: no-repeat;
        background-position: 1px 50%;
        font-weight: 700;
        padding-left: 20px;
        height: 25px;
        padding-left: 2px;
        width: 270px;
        background-color: #EEEEEE;
        cursor: pointer;
    }
    a.trigger.open
    {
        background-image: url(../style/img/minus.gif);
    }
    .last-child a.trigger
    {
        padding-left: 1px;
        background-image: none;
        font-weight: normal;
    }
    #main a.trigger
    {
        background-color: #EEEEEE;
    }
    #main a.trigger.open
    {
        border-color: #dadada;
        background-color: #e7e7e7;
    }
    #main a:hover.trigger.open, #main a:focus.trigger.open, #main a:active.trigger.open
    {
        border-color: #bcd;
    }
    #side a.active
    {
        font-weight: 700;
        color: #f72;
        text-decoration: none;
    }
    .wtaercss
    {
        color: #6E6E6E;
    }
    .tab_mission_runtime div div tr td input
    {
        float: none;
    }
    .tab_mission_runtime div div
    {
        /* float:none !important; */
        line-height: 28px !important;
        font-size: 17px;
    }
    .cls
    {
        color: #ACACAC;
    }
    .cal_Theme1 .ajax__calendar_container
    {
        background-color: #DEF1F4;
        border: solid 1px #77D5F7;
    }
    .cal_Theme1 .ajax__calendar_header
    {
        background-color: #ffffff;
        margin-bottom: 4px;
    }
    .ajax__calendar_container
    {
        cursor: default;
        font-family: tahoma,verdana,helvetica;
        font-size: 11px;
        height: 220px;
        padding: 4px;
        text-align: center;
        width: 220px;
    }
    /* .ajax__calendar_next
    {
        background-image: url(   "WebResource.axd?d=ayjpEXrdvWvOW2gTaAtztRBv6fPyXifU7GjqL6F2DmumYG-tHQluWz_kAzIBnRm70&t=634946142760000000" );
        background-position: 50% 50%;
        background-repeat: no-repeat;
        cursor: pointer;
        float: right !important;
        height: 15px;
        width: 15px;
    }*/.ajax__calendar_dayname
    {
        height: 17px;
        padding: 0 2px;
        text-align: right;
        width: 25px;
    }
    .ajax__calendar_body
    {
        height: 139px;
        margin: 7px auto auto;
        overflow: hidden;
        position: relative;
        width: 200px;
    }
    .ajax__calendar_header
    {
        height: 30px;
        width: 100%;
    }
    .cal_Theme1 .ajax__calendar_title, .cal_Theme1 .ajax__calendar_next, .cal_Theme1 .ajax__calendar_prev
    {
        color: #004080;
        padding-top: 3px;
    }
    .cal_Theme1 .ajax__calendar_body
    {
        background-color: #ffffff;
        border: solid 1px #77D5F7;
    }
    .cal_Theme1 .ajax__calendar_dayname
    {
        text-align: center;
        font-weight: bold;
        margin-bottom: 4px;
        margin-top: 2px;
        color: #004080;
    }
    .cal_Theme1 .ajax__calendar_day
    {
        color: #004080;
        text-align: center;
    }
    .ajax__calendar_days, .ajax__calendar_months, .ajax__calendar_years
    {
        height: 139px;
        left: 0;
        margin: auto;
        position: absolute;
        text-align: center;
        top: 0;
        width: 200px;
        font-size: 14px !important;
    }
    .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year, .cal_Theme1 .ajax__calendar_active
    {
        color: #004080;
        font-weight: bold;
        background-color: #DEF1F4;
    }
    .cal_Theme1 .ajax__calendar_today
    {
        font-weight: bold;
    }
    .cal_Theme1 .ajax__calendar_other, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title
    {
        color: #bbbbbb;
    }
    .ajax__calendar_next
    {
        position: absolute;
        right: 7px;
    }
    .ajax__calendar_title
    {
        margin-left: 30px !important;
        margin-right: 0 !important;
        margin-top: -8px;
        text-align: center !important;
        overflow: hidden;
    }
    #Foodlog_CalendarExtender1_yearsBody .ajax__calendar_year
    {
        font-size: 14px !important;
        line-height: 13px !important;
        color: #004080 !important;
    }
    #Foodlog_CalendarExtender1_monthsBody .ajax__calendar_month
    {
        font-size: 14px !important;
        line-height: 13px !important;
        color: #004080 !important;
    }
    #Foodlog_CalendarExtender1_daysBody .ajax__calendar_day
    {
        font-size: 14px !important;
    }
    #Foodlog_CalendarExtender1_daysTableHeader .ajax__calendar_dayname
    {
        font-size: 14px !important;
    }
    #Foodlog_btnCrateCustomFood
    {
        margin-left: -9px !important;
    }
    #Foodlog_pnlCreateCustomFood .gray_bg_favourties
    {
        background: none repeat scroll 0 0 #CCCCCC;
        border-radius: 4px 4px 0 0;
        float: left;
        height: 50px;
        width: 688px;
    }
    #Foodlog_pnlCreateCustomFood .gray_bg_favourties span
    {
        color: #000000;
        float: left;
        font-family: Arial,Helvetica,sans-serif;
        font-size: 19px;
        font-weight: bold;
        margin-left: 20px;
        margin-top: 12px;
    }
    #Foodlog_pnlCreateCustomFood tr td
    {
        background: none repeat scroll 0 0 #F1F1F1;
        float: left;
        height: 37px;
        line-height: 32px;
        margin-top: 1px;
        width: 100%;
    }
    #Foodlog_pnlCreateCustomFood tr td input
    {
        border: 1px solid #DDDDDD;
        box-shadow: 0 1px 0 #CCCCCC inset;
        float: right;
        height: 31px;
        margin-right: 200px;
        margin-top: 2px;
        width: 286px;
    }
    #Foodlog_imgBtnSaveCustomFood
    {
        border-width: 0 !important;
        height: 53px !important;
        margin-bottom: 25px !important;
        margin-top: 38px !important;
        width: 250px !important;
    }
    #Foodlog_pnlCreateCustomFood tr td span
    {
        margin-left: 20px;
    }
    .food_new_create tr td
    {
    }
    .date_food_bar
    {
        float: right !important;
    }
    .date_food_bar input
    {
        float: left;
    }
    .table_food_data > div
    {
        width: 100%;
    }
    .table_food_data table#Foodlog_grData tr
    {
        width: 100%;
    }
    #Foodlog_dvSerach > div#Foodlog_dvNextBtn
    {
        width: 100%;
    }
    .table_food_data #Foodlog_GrdFoodLog, .table_food_data #Foodlog_GrdFoodLog tr
    {
        width: 100%;
    }
    .table_food_data div
    {
        width: 100% !important;
    }
    .food_table_fav > input
    {
        margin: 7px 5px 7px 0 !important;
    }
    .cal_table_fav > input
    {
        margin: 4px 5px 0 5px !important;
    }
    .HeaderCSS
    {
        background: url(../images/bg_log.png) repeat-x;
        font-family: arial;
        font-size: 11px;
        line-height: 38px;
    }
    .HeaderCSS1
    {
        background: url("../images/bg_log.png") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
        font-family: arial;
        font-size: 11px;
        line-height: 38px;
    }
    .ItemCSS
    {
        border-right: 1px solid #ccc;
        text-align: center;
        position: relative;
    }
    .ItemCSS1
    {
        border-right: 1px solid #ccc;
        text-align: left;
        width: 62% !important;
        margin-left: 4px;
    }
    .ItemCSS2
    {
        border-right: 1px solid #ccc;
        text-align: center;
        width: 36% !important;
    }
    .HeaderCSSBorder
    {
        border-right: 1px solid #FFF;
        text-align: center;
    }
    .HeaderCSSBorder1
    {
        border-right: 1px solid #FFF;
        text-align: center;
        width: 62% !important;
    }
    .HeaderCSSBorder2
    {
        text-align: center;
        width: 36%;
    }
    .Cross
    {
        border-width: 0;
        display: none;
        float: left !important;
        margin-left: 27px;
        margin-top: 11px;
        position: absolute;
        z-index: 10;
    }
    .Edit
    {
        border-width: 0;
        display: none;
        margin-right: 19px;
        margin-top: 3px;
        position: absolute;
        width: 15px;
        z-index: 10;
    }
    .Edit1
    {
        border-width: 0;
        margin-top: -16px;
        position: absolute;
        right: 10%;
        width: 15px;
        z-index: 10;
    }
    .Cross1
    {
        border-width: 0;
        margin-right: 0;
        margin-top: 8px;
        position: absolute;
        float: left;
        z-index: 10;
    }
</style>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>

<script type="text/javascript" src="../scripts/JScript.js"></script>

<script type="text/javascript">
    $(document).ready(function() {
        $("html").addClass("js");
        $.fn.accordion.defaults.container = false;
        $(function() {
            $("#acc3").accordion({ initShow: "#current" });
            $("#acc1").accordion({
                el: ".h",
                head: "h4, h5",
                next: "div",
                initShow: "div.outer:eq(1)"
            });
            $("#acc2").accordion({
                obj: "div",
                wrapper: "div",
                el: ".h",
                head: "h4, h5",
                next: "div",
                showMethod: "slideFadeDown",
                hideMethod: "slideFadeUp",
                initShow: "div.shown",
                elToWrap: "sup, img"
            });
            $("html").removeClass("js");
        });
    });
</script>

<script>


    function LoadCssOnLinkBtnClick() {
        $(document).ready(function() {
            $("html").addClass("js");
            $.fn.accordion.defaults.container = false;
            $(function() {
                $("#acc3").accordion({ initShow: "#current" });
                $("#acc1").accordion({
                    el: ".h",
                    head: "h4, h5",
                    next: "div",
                    initShow: "div.outer:eq(1)"
                });
                $("#acc2").accordion({
                    obj: "div",
                    wrapper: "div",
                    el: ".h",
                    head: "h4, h5",
                    next: "div",
                    showMethod: "slideFadeDown",
                    hideMethod: "slideFadeUp",
                    initShow: "div.shown",
                    elToWrap: "sup, img"
                });
                $("html").removeClass("js");
            });
        });
    }
</script>
<body ondragstart="return false;" ondrop="return false;">
<div id="upfoodlog">
    <asp:UpdatePanel ID="updatePanelFoodLog" runat="server">
        <ContentTemplate>
            <div id="dvBreadCrumInput" runat="server" style="margin-left: 15px; display: none;
                margin-top: 10px;" class="bread_miss">
                <span class="mission_miss">Member List</span>
                <div class="arrow_miss">
                    <img src="../images/red_arrow.png"></div>
                <span class="mission_miss">List all missions </span>
                <div class="arrow_miss">
                    <img src="../images/red_arrow.png"></div>
                <span class="mission_miss" style="color: #53afb0;">Todays input towards your mission</span>
            </div>
            <div id="tblWarning" runat="server" visible="false">
                <div class="warning">
                    This is a private mission created by <span id="spCreatedByUserName" runat="server">&nbsp;
                    </span>. You can only follow the progress of this mission.
                </div>
            </div>
            <div class="center_food_log">
                <div class="uppertab_log">
                    <div class="bg_sel_tab sel_log_tab">
                        <asp:LinkButton ID="lnkFood" runat="server" OnClick="lnkFood_Click" Style="padding: 0 0 0 18px;
                            color: #fff;" Text="Food"></asp:LinkButton></div>
                    <div class="bg_sel_tab">
                        <asp:LinkButton ID="lnkActivities" CssClass="lnkActivitiess" runat="server" OnClick="lnkActivities_Click"
                            Style="padding: 0px;" Text="Activity"></asp:LinkButton></div>
                </div>
                <div class="bottom_tab">
                    <!--left section start here-->
                    <div class="left_section_food_log">
                        <!--table_section start here-->
                        <div class="table_section">
                            <div class="food_log_bar">
                                <div class="title_food_bar">
                                    Food Log
                                    <div class="date_food_bar">
                                        <asp:ImageButton ID="imgBtnPrevious" runat="server" ImageUrl="~/images/left_arrow_date.png"
                                            OnClick="imgBtnPrevious_Click" OnClientClick="showDivProgress()" />
                                        <asp:HiddenField ID="hdnSelectedDateForMissionHistory" runat="server" />
                                        <asp:TextBox ID="txtCalendarNavigation" runat="server" CssClass="middle_date_new"
                                            Style="border: medium none; border-radius: 0 0 0 0; float: left; height: 24px;
                                            width: 87px;" OnTextChanged="txtCalendarNavigation_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalendarNavigation"
                                            Format="dd MMM yyyy" OnClientDateSelectionChanged="CheckMissionHistoryDate" CssClass=" cal_Theme1"
                                            PopupButtonID="txtCalendarNavigation" />
                                        <asp:ImageButton ID="ImgBtnNextDate" runat="server" ImageUrl="~/images/rgt_arrow_date.png"
                                            OnClick="ImgBtnNextDate_Click" CssClass="act_right_arrow" OnClientClick="showDivProgress()" />
                                    </div>
                                </div>
                            </div>
                            <div class="link_top_bar">
                                <asp:LinkButton ID="lnkCrateCustomFood" Text="Add a new Food" runat="server"></asp:LinkButton>|
                                <asp:LinkButton ID="lnkBrowse1" Text="Browse" runat="server"></asp:LinkButton>
                                |
                                <asp:LinkButton ID="lnkBrowseQuickLog_FoodLog" Text="Quick Log" runat="server"></asp:LinkButton>
                            </div>
                            <%-- Quick Log  Begins --%>
                            <asp:ModalPopupExtender ID="MdlQuickLog_FoodLog" runat="server" TargetControlID="lnkBrowseQuickLog_FoodLog"
                                PopupControlID="pnlQuickLog_FoodLog" DropShadow="true" CancelControlID="btnQuickLogClose_FoodLog">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="pnlQuickLog_FoodLog" runat="server" CssClass="inner_box_pop_up_favourites"
                                Style="background: none repeat scroll 0 0 #FFFFFF; border: 6px solid #ccc; height: 500px;
                                border-radius: 10px 10px 10px 10px; box-shadow: 5px 5px 5px #555555; float: left !important;
                                height: 700px !important; margin: 0 auto -18px -35px !important; opacity: 1;
                                position: relative; width: 893px !important; z-index: 999; display: none;">
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnQuickLogClose_FoodLog" runat="server" Text="X" CssClass="close_img_pop_up"
                                                Style="background: none repeat scroll 0 0 #999; border: medium none navy; border-radius: 30px 30px 30px 30px;
                                                color: #FFFFFF; float: right; font-family: arial; font-size: 17px; margin-left: -9px;
                                                margin-top: -17px; padding: 2px !important; position: absolute; width: 28px !important;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="gray_bg_favourties" style="float: left;">
                                                <span style="float: left;">Please select one of the following options :</span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="color: Black; font-family: Arial; font-size: 14px; padding-left: 31px;
                                            text-align: left;" valign="top">
                                            <asp:RadioButton ID="radOptionOne" runat="server" Width="10px" Style="margin-top: 8px;"
                                                onclick="return ShowRegionForOptionOne()" />
                                            <span runat="server" id="spMsg1" style="margin-left: 10px;">About how much did you eat
                                                this morning ?</span>
                                            <br />
                                            <asp:RadioButton ID="radOptionTwo" runat="server" Width="10px" Style="margin-top: 8px;"
                                                onclick="return ShowRegionForOptionTwo()" />
                                            <span runat="server" id="spMsg2" style="margin-left: 10px;">Did you eat more or less
                                                than you did yesterday at this time?</span>
                                            <div id="dvProgressBarForImages" runat="server" style="display: none; margin-left: 585px;
                                                background-color: #FFFFFF; border: 1px solid #CCCCCC; margin-top: -57px;">
                                                <span style="font-family: Arial; color: Black;">Processing Your Request ...</span><br />
                                                <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" alt="hello" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdRegionOptionOne" runat="server" style="display: none;">
                                            <div style="float: left !important; margin-left: 0px;">
                                                <div>
                                                    <div class="inner_box_pop_up_favourites_log" style="-moz-border-bottom-colors: none;
                                                        -moz-border-left-colors: none; -moz-border-right-colors: none; -moz-border-top-colors: none;
                                                        background: none repeat scroll 0 0 #FFFFFF; border-color: #CCCCCC -moz-use-text-color -moz-use-text-color;
                                                        border-image: none; border-radius: 0 0 0 0; border-right: 0 none; border-style: solid none none;
                                                        box-shadow: none; border-width: 1px 0 0; margin: -2px -5px 125px 2px; min-height: 550px;
                                                        overflow: hidden; padding-bottom: 16px; width: 889px; z-index: 999;">
                                                        <asp:DataList ID="dtFoodLogActivityImages" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                            OnItemCommand="dtFoodLogActivityImages_RowCommand" RepeatLayout="Table">
                                                            <ItemTemplate>
                                                                <div class="img_food_log5">
                                                                    <div class="gray_bg_food">
                                                                        <%#Eval("calorie_range") %>&nbsp;&nbsp;Calories
                                                                    </div>
                                                                    <div class="purple_bg_food">
                                                                        <span class="head_food_log_alere">
                                                                            <%#Eval("calorie_type") %></span>
                                                                        <asp:Label ID="lblActivity" runat="server" Text='<%#Eval("activities") %>'></asp:Label>
                                                                    </div>
                                                                    <asp:ImageButton ID="imgLogImage" runat="server" ImageUrl='<%#"~/Images/" +Eval("log_images") %>'
                                                                        OnClientClick="return showConfirmForImages();" CommandArgument='<%#Eval("calories")%>'
                                                                        CommandName="AddFoodLogSelected" />
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdRegionOptionTwo" runat="server" style="display: none; background-color: #eee;
                                            border: 1px solid #ccc; color: black; font-size: 17px; margin: 1em 0 4em; padding: 0 222px 1px;
                                            text-align: center;">
                                            <asp:RadioButton ID="radLessthanYesterday" runat="server" Text="less than yesterday’s calorie intake ? "
                                                Style="margin-top: 8px;" ForeColor="Black" onclick="return ShowRegionForLessCaloriesConsume()" />
                                            <br />
                                            <asp:RadioButton ID="radMorethanYesterday" runat="server" Text="more than yesterday’s calorie intake ? "
                                                Style="margin-top: 8px;" ForeColor="Black" onclick="return ShowRegionForMoreCaloriesConsume()" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color: Black; font-family: Arial; font-size: 16px; background-color: #eee;
                                            border: 1px solid #ccc; color: black; font-size: 17px; margin: 1em 0 4em; padding: 0 222px 1px;
                                            text-align: center;" valign="top" id="tdComparison" runat="server">
                                            <span id="spCalorieComparison" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="activity_button">
                                                <asp:Button ID="btnSave_QuickLog_1" runat="server" OnClick="btnSave_QuickLog_Click"
                                                    OnClientClick="return Validate_QuickLogRadioButtons_FoodLog_Option1()" Text="Log Food"
                                                    Style="cursor: pointer; margin-left: -14px; display: none;" />
                                                <asp:Button ID="btnSave_QuickLog_2" runat="server" OnClick="btnSave_QuickLog_Click"
                                                    OnClientClick="return Validate_QuickLogRadioButtons_FoodLog_Option2()" Text="Log Food"
                                                    Style="cursor: pointer; margin-left: -14px; display: none;" />
                                            </div>
                                            <div id="dvErrorMsgForYesterDayCalories" runat="server" style="display: none;">
                                                <span style="font-family: Arial; color: Green; font-size: 18px; margin-left: -305px;
                                                    margin-top: 118px;">You have not submitted yesterday's calorie consume input.</span>
                                                <span style="font-family: Arial; color: Green; font-size: 18px; margin-left: 0px;
                                                    margin-top: 138px;">Please select the other option !</span>
                                            </div>
                                            <div id="dvProgressBarOnModalPop" runat="server" style="display: none; margin-left: -162px;
                                                margin-top: 160px;">
                                                <span style="font-family: Arial; color: Black;">Processing Your Request ...</span><br />
                                                <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" alt="hello" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            </span>
                            <%--  Quick Log Ends --%>
                            <%--The Activities and Categories Pop up begin--%>
                            <asp:ModalPopupExtender ID="modalPopActivities" runat="server" TargetControlID="lnkBrowse1"
                                PopupControlID="pnlActivities" BackgroundCssClass="main_pop_up_box_miss" DropShadow="true"
                                CancelControlID="btnClosepnlActivities">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="pnlActivities" runat="server" CssClass="inner_box_pop_up_favourites"
                                Style="background: none repeat scroll 0 0 #FFFFFF; border: 5px solid #CCCCCC;
                                border-radius: 10px 10px 10px 10px; box-shadow: 0px 0px 5px #888888; float: left !important;
                                height: 500px !important; margin: 0px auto -1px -90px !important; opacity: 1;
                                position: relative; width: 843px !important; z-index: 999; display: none;">
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnClosepnlActivities" runat="server" Text="X" CssClass="close_img_pop_up"
                                                Style="background: none repeat scroll 0 0 #999; border: medium none navy; border-radius: 30px 30px 30px 30px;
                                                color: #FFFFFF; float: right; font-family: arial; font-size: 17px; margin-left: -9px;
                                                margin-top: -17px; padding: 2px !important; position: absolute; width: 28px !important;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="gray_bg_favourties_track" style="float: left;">
                                                <span style="float: left; margin-left: 15px; margin-top: 10px;">Please select a category
                                                    and then Food</span>
                                            </div>
                                            <div class="inner_heading_favourites" style="float: left !important;">
                                                Categories</div>
                                            <div class="inner_heading_favourites" style="float: left; margin-left: -31px;">
                                                Food
                                                <img src="../images/spacer.gif" height="0px" width="100px" />
                                                <div id="dvFoodSelectedProgressBar" runat="server" style="display: none; margin-left: 320px;
                                                    margin-top: -48px;">
                                                    <span style="font-family: Verdana; color: Black;">Processing...</span><br />
                                                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" alt="hello" />
                                                </div>
                                            </div>
                                            <div style="border: 1px solid #CCCECD; margin-left: 3px; height: 419px; margin-top: 22px;">
                                                <div class="inner_box_left_favourites" style="height: 409px; overflow-x: hidden;
                                                    overflow-y: scroll; width: 296px;">
                                                    <ul class="left_link_favourites" style="overflow: hidden !important; height: auto !important;">
                                                        <asp:GridView ID="grdCategoriesfood" runat="server" OnRowDataBound="grdCategoriesfood_RowDataBound"
                                                            ShowHeader="false" OnRowCommand="grdCategoriesfood_RowCommand" AutoGenerateColumns="false"
                                                            Style="height: 100px;">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderText="  " HeaderStyle-CssClass="check_invite"
                                                                    HeaderStyle-Font-Underline="true" ItemStyle-Width="222px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <li class="sel_bg_favourites">
                                                                                        <asp:LinkButton ID="lnkCategory" runat="server" CommandName="SelectCategory" CommandArgument='<%# Eval("CAT_ID") +";"+ Eval("CAT_NAME")%>'
                                                                                            Style="float: left; font-size: 14px; color: #FFFFFF !important">
                                                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("CAT_IMAGE") %>'
                                                                                                Style="border: 1px solid; float: left; height: 25px; margin-left: -4px; margin-right: 5px;
                                                                                                margin-top: 5px; width: 25px;" />
                                                                                            <asp:Label ID="lbname" runat="server" Text='<%# Eval("CAT_NAME") %>' Style="color: Black;"></asp:Label>
                                                                                        </asp:LinkButton>
                                                                                    </li>
                                                                                    <asp:GridView ID="grdSubCategoriesfood" runat="server" OnRowDataBound="grdSubCategoriesfood_RowDataBound"
                                                                                        OnRowCommand="grdSubCategoriesfood_RowCommand" AutoGenerateColumns="false" ShowHeader="false">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <li class="left_sub_links_favourties">
                                                                                                        <asp:LinkButton ID="lnkSubCategory" runat="server" Text="" CommandArgument='<%# Eval("SUBCAT1_ID") +";"+Eval("SUBCAT1_NAME") %>'
                                                                                                            OnClientClick="return ShowProgresBarForFood()" CommandName="SelectSubCategory"
                                                                                                            Style="font-size: 14px; margin-left: 17px; float: left;">
                                                                                                            <asp:Image ID="img" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("SUBCAT1_IMAGE") %>'
                                                                                                                Style="border: 1px solid #CCCCCC; float: left; height: 25px; margin-right: 3px;
                                                                                                                margin-top: 4px; width: 25px;" />
                                                                                                            <asp:Label ID="lbname12" runat="server" Text='<%# Eval("SUBCAT1_NAME") %>' Style="color: Black;"></asp:Label>
                                                                                                        </asp:LinkButton>
                                                                                                    </li>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ul>
                                                </div>
                                                <div style="float: left;">
                                                </div>
                                                <div class="inner_box_right_favourites" style="height: 409px; margin-left: 12px;
                                                    overflow-x: hidden; overflow-y: scroll; width: 520px; float: left;">
                                                    <asp:GridView ID="grdActivitiesfood" runat="server" ShowHeader="false" CssClass="right_content_favourites"
                                                        AutoGenerateColumns="false" Style="line-height: 23px !important;" OnRowCommand="grdActivitiesfood_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbId" runat="server" Text='<%#Eval("SUBCAT2_ID") %>' Visible="false"></asp:Label>
                                                                    <asp:LinkButton ID="lnkActivities" runat="server" Text="" CommandName="lnkActivity"
                                                                        OnClientClick="return ShowProgresBarForFood()" CommandArgument='<%#Eval("SUBCAT2_ID")+";"+ Eval("SUBCAT2_NAME") %>'
                                                                        CssClass="right_links_favourites" Style="color: #424242; font-size: 14px;">
                                                                        <asp:Image ID="Ima" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("SUBCAT2_IMAGE") %>'
                                                                            Style="float: left; height: 25px; width: 25px;" />
                                                                        <asp:Label ID="lbname3" runat="server" Text='<%# Eval("SUBCAT2_NAME") %>' Style="color: Black;"></asp:Label>
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <%--  Pop up ends --%>
                            <div class="clear" style="clear: both">
                            </div>
                            <div class="find_food">
                                <span>Find Food to Log?</span>
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="box_search_food clsOnlyAlphs"
                                    onChange="ShowImage();" onkeyup="displayunicode(event)"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtendermemberlist" BehaviorID="AutoCompleteEx"
                                    FirstRowSelected="false" runat="server" TargetControlID="txtSearch" MinimumPrefixLength="1"
                                    ServiceMethod="FoodEssentialAPISearch" ContextKey="5" ServicePath="~/Service/FoodEssentialAPI.asmx"
                                    CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                    EnableCaching="true" CompletionListHighlightedItemCssClass="itemHighlighted"
                                    CompletionInterval="1000" OnClientPopulated="OnClientPopulated" OnClientItemSelected="ace1_itemSelected">
                                </asp:AutoCompleteExtender>
                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtSearch"
                                    WatermarkText="Search Food">
                                </asp:TextBoxWatermarkExtender>
                            </div>
                            <div class="find_serving">
                                <span>Serving?</span>
                                <%--  <asp:TextBox runat="server" ID="txtservingfood" ReadOnly="true" Text="1" CssClass="box_serving_food"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlservingsize" runat="server" AppendDataBoundItems="true"
                                    Style="float: left;" CssClass="select_option_food">
                                    <asp:ListItem Text="0.5" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="2" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="1.5" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="2.5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="3.5" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="8"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnseachfoodlog" runat="server" Text="Button" Style="display: none;"
                                    OnClick="btnseachfoodlog_Click" />
                            </div>
                            <div class="find_time">
                                <span>Time?</span>
                                <asp:DropDownList ID="drpserving_time" runat="server" AppendDataBoundItems="true"
                                    Style="float: left;" CssClass="select_option_food">
                                    <asp:ListItem Text="Breakfast" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Morning Snacks" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Lunch" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Unclassified" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Evening Snacks" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Dinner" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="Log Food" OnClick="Button1_Click" CssClass="food_log_submit"
                                OnClientClick="return Checkvalidity();" />
                            <div id="servingsize" style="float: left; margin-left: 171px; font-size: 13px; width: 170px;
                                display: none;">
                                Serving Size: <span id="servingSizeValue"></span>
                            </div>
                            <!-- <input type="submit" value="Log Food" class="food_log_submit"/>-->
                        </div>
                        <!--table_section end  here-->
                        <!--table_section start here-->
                        <div id="dvSerach" runat="server" class="table_section">
                            <div class="food_log_bar">
                                <div class="title_food_bar">
                                    <asp:ImageButton runat="server" ID="imgclosesearch" OnClick="imgclosesearch_Click"
                                        OnClientClick="HideSearch();" Style="border-width: 0; float: left; height: 30px;
                                        margin-left: -8px; margin-top: -4px; width: 30px;" ImageUrl="http://www.developertips.net/demos/popup-dialog/img/x.png" />
                                    Search Results</div>
                            </div>
                            <div class="table_food_data" style="height: 200px !important; overflow-x: hidden;
                                width: 100%; overflow-y: scroll;">
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="13px"></asp:Label>
                                <asp:GridView ID="grData" runat="server" AutoGenerateColumns="false" PageSize="10"
                                    Style="width: 100%; font-size: 11px; height: auto" OnRowDataBound="grData_RowDataBound"
                                    OnRowCommand="grData_RowCommand">
                                    <RowStyle CssClass="table_food_detail" />
                                    <HeaderStyle CssClass="HeaderCSS" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Food" HeaderStyle-CssClass="HeaderCSSBorder">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUpc" runat="server" Text='<%# Eval("upc") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblproduct_name" runat="server" Text='<%# Eval("product_name") %>'
                                                    Style="text-align: left;"></asp:Label>
                                                <%-- <asp:LinkButton ID="lnkProductName" runat="server"  Text='<%# Eval("product_name") %>'
                                                        CommandName="lnkProName" CommandArgument='<%# Eval("upc")+";"+Eval("product_size")+";"+ Eval("product_name")%>'></asp:LinkButton>
                                                    <asp:ModalPopupExtender ID="Pnl_ModalPopupExtender11" runat="server" DynamicServicePath=""
                                                        Enabled="True" TargetControlID="lnkProductName" PopupControlID="panel_pop" BackgroundCssClass="main_pop_up_box_miss"
                                                        DropShadow="false" CancelControlID="img1">
                                                    </asp:ModalPopupExtender>
                                                    <div id="panel_pop" runat="server" class="inner_box_pop_up_fav" style="border: 4px solid #CCCCCC !important;
                                                        height: 500px !important; left: 80px !important; position: fixed; top: 6px !important;
                                                        width: 313px; z-index: 1000011;">
                                                        <div class="close_img_pop_up">
                                                            <img id="img1" runat="server" src="../images/close_btn11.png" style="float: right;
                                                                margin-left: 785px; margin-top: -19px; position: absolute;" />
                                                        </div>
                                                        <div class="left_fav">
                                                            <span style="color: #FFFFFF; float: left; font-family: Arial,Helvetica,sans-serif;
                                                                font-size: 25px; font-weight: lighter; margin-left: 15px; margin-top: 6px;">Nutrition
                                                                Facts </span>
                                                            <div class="list_view_fav">
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Calories
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbTotalcal" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Fat
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbtotalfat" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Cholestrol
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbtotalchol" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Sodium
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbTotalSodium" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Carbohydrates
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbtotalCarbs" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Fiber
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbTotalFiber" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Protiens
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbTotalProteins" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="list_fav">
                                                                    <div class="fav_lst_left">
                                                                        Total Sugar
                                                                    </div>
                                                                    <div class="fav_lst_rgt">
                                                                        <asp:Label ID="lbTotalSugar" runat="server" Style="color: Black;"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="rgt_fav">
                                                            <span class="cal_search" style="background: none repeat scroll 0 0 #51acae; border-radius: 5px 5px 0 0;
                                                                color: #FFFFFF; float: left; font-family: Arial,Helvetica,sans-serif; font-size: 38px;
                                                                height: 90px; line-height: 90px; margin-bottom: 32px; margin-top: 0; text-align: center;
                                                                width: 100%;">Calories
                                                                <asp:Label ID="lbCalsTotal" runat="server" Text=""></asp:Label>
                                                            </span>
                                                            <img style="float: right; margin-right: 172px; margin-top: -43px;" src="../images/aq.png" />
                                                            <div style="background: none repeat scroll 0 0 #FFFFFF; float: left; height: 2px;
                                                                margin-bottom: 8%; margin-left: 2%; width: 96%;">
                                                            </div>
                                                            <div>
                                                                <asp:ImageButton ID="ImgAddLog" runat="server" ImageUrl="~/images/add_log.png" CommandName="lnkADDFL"
                                                                    OnClientClick="showDivProgress();" CommandArgument='<%#Eval("product_name")+";"+Eval("product_size")+";"+Eval("cal")+";"+Eval("Fat")
                                    +";"+Eval("Cholesterol")+";"+Eval("Fiber")+";"+Eval("Sugars") %>' Style="margin-bottom: 15px; margin-left: 10px;" />
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Size" HeaderStyle-CssClass="HeaderCSSBorder">
                                            <ItemTemplate>
                                                <asp:Label ID="lbServing" runat="server" Text='<%# Eval("product_size") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cals" HeaderStyle-CssClass="HeaderCSSBorder">
                                            <ItemTemplate>
                                                <asp:Label ID="lbcal" runat="server" Text='<%# Eval("cal") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fat" HeaderStyle-CssClass="HeaderCSSBorder" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbfat" runat="server" Text='<%# Eval("Fat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chol" HeaderStyle-CssClass="HeaderCSSBorder" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbChol" runat="server" Text='<%# Eval("Cholesterol") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fiber" HeaderStyle-CssClass="HeaderCSSBorder" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbFiber" runat="server" Text='<%# Eval("Fiber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sugars" HeaderStyle-CssClass="HeaderCSSBorder" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lbSugar" runat="server" Text='<%# Eval("Sugars") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="HeaderCSSBorder">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/images/add.png" ToolTip="Add to FoodLog"
                                                    OnClientClick="showDivProgress();" CommandName="ImgAddFood" CommandArgument='<%#Eval("product_name")+";"+Eval("product_size")+";"+Eval("cal")+";"+Eval("Fat")
                                    +";"+Eval("Cholesterol")+";"+Eval("Fiber")+";"+Eval("Sugars") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="ItemCSS" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <span style="font-family: Arial; font-size: 13px; margin-left: 10px; color: #A6A6A6;">
                                            No Record Found..</span>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                            <div id="dvNextBtn" runat="server" visible="false" align="center">
                                <asp:ImageButton ID="ImgBtnPrev" runat="server" ToolTip="Previous" ImageUrl="~/images/arrow_lft.png"
                                    OnClientClick="showDivProgress();" Style="float: left; height: 26px; margin-bottom: 5px;
                                    margin-top: 5px; margin-left: 11px; width: 30px;" OnClick="ImgBtnPrev_Click" />
                                <asp:ImageButton ID="ImgBtnNext" runat="server" ToolTip="Next" ImageUrl="~/images/arrow_rgt.png"
                                    OnClientClick="showDivProgress();" Style="float: right !important; height: 26px;
                                    margin-bottom: 5px; margin-top: 5px; margin-left: 379px; width: 30px;" OnClick="ImgBtnNext_Click" />
                            </div>
                        </div>
                        <div class="table_section">
                            <div class="food_log_bar">
                                <div class="title_food_bar">
                                    Logged Food</div>
                            </div>
                            <div class="table_food_data">
                                <div style="width: 100%; height: 393px; overflow-y: auto; overflow-x: hidden;">
                                    <asp:GridView ID="GrdFoodLog" runat="server" AutoGenerateColumns="false" OnRowCommand="GrdFoodLog_RowCommand"
                                        Style="width: 100%; font-size: 11px; height: auto" OnRowUpdating="GrdFoodLog_RowUpdating"
                                        OnRowEditing="GrdFoodLog_RowEditing" OnRowCancelingEdit="GrdFoodLog_RowCancelingEdit"
                                        OnRowDeleting="GrdFoodLog_RowDeleting" OnRowDataBound="GrdFoodLog_RowDataBound">
                                        <RowStyle CssClass="table_food_detail" />
                                        <HeaderStyle CssClass="HeaderCSS" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Food" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbID" runat="server" Text='<%# Eval("UFL_ID") %>' Visible="false"></asp:Label>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="delete" ToolTip="Delete"
                                                        OnClientClick="showDivProgress();" CommandArgument='<%#Eval("UFL_ID") %>' ImageUrl="~/images/delete-icon.png"
                                                        Style="display: none;" CssClass="Cross" />
                                                    <asp:Label ID="lblproduct_name" runat="server" Text='<%#Eval("SHORT_FOOD_NAME") %>'
                                                        ToolTip='<%# Eval("Food") %>' Style="text-transform: lowercase;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Servings" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="drpServing" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                                        OnSelectedIndexChanged="drpServing_SelectedIndexChanged" SelectedValue='<%#Eval("Product_Size") %>'>
                                                        <asp:ListItem Text="0.5" Value="0.5"></asp:ListItem>
                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="1.5" Value="1.5"></asp:ListItem>
                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="2.5" Value="2.5"></asp:ListItem>
                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="3.5" Value="3.5"></asp:ListItem>
                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="ImageButton11" runat="server" ToolTip="Update" CommandName="update"
                                                        OnClientClick="showDivProgress();" CommandArgument='<%#Eval("UFL_ID") %>' ImageUrl="~/images/Files-Edit-file-icon.png"
                                                        Style="float: left; height: 15px; width: 15px; margin-top: 5px;" />
                                                    <asp:ImageButton ID="ImageButton41" runat="server" ToolTip="Cancel" CommandName="cancel"
                                                        OnClientClick="showDivProgress();" CommandArgument='<%#Eval("UFL_ID") %>' ImageUrl="~/images/delete.png"
                                                        Style="float: left; height: 15px; width: 15px; margin-top: 5px;" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbServing" runat="server" Text='<%# Eval("Product_Size") %>'></asp:Label>
                                                    <asp:ImageButton ID="ImageButton13" runat="server" CommandName="Edit" ToolTip="Edit"
                                                        OnClientClick="showDivProgress();" CommandArgument='<%#Eval("UFL_ID") %>' ImageUrl="~/images/edit.png"
                                                        Style="display: none; margin: -22px 0 0 78px;" CssClass="Edit" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eating Time" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="drpEating" runat="server" AppendDataBoundItems="true" Style="float: left;"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Text="Breakfast" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Morning Snacks" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Lunch" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Unclassified" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Evening Snacks" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Dinner" Value="6"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbEatingTime" runat="server" Text="" Style="font-size: 14px; color: #666666;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cals" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbcal" runat="server" Text='<%# Eval("Cals") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fat" HeaderStyle-CssClass="HeaderCSSBorder"">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbfat" runat="server" Text='<%# Eval("fat") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Chol" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbchol" runat="server" Text='<%# Eval("Chol") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fiber" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbFiber" runat="server" Text='<%# Eval("Fiber") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sugars" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbSugars" runat="server" Text='<%# Eval("Sugars") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fav" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton31" runat="server" CommandName="lnkAddFAv" ToolTip="Add to Favourite"
                                                        Style="margin-top: 6px;" ImageUrl='<%#Eval("FavImage") %>' OnClientClick="showDivProgress();"
                                                        CommandArgument='<%#Eval("UFL_ID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <span style="font-family: Arial; font-size: 13px; margin-left: 10px; color: #A6A6A6;">
                                                Food not logged yet</span>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <asp:ModalPopupExtender ID="modPopUpASddCustomPopUp" runat="server" TargetControlID="lnkCrateCustomFood"
                            PopupControlID="pnlCreateCustomFood" DropShadow="true" CancelControlID="btnCrateCustomFood">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlCreateCustomFood" runat="server" CssClass="inner_box_pop_up_favourites"
                            Style="background: none repeat scroll 0 0 #FFFFFF; border: 3px solid #CCCCCC;
                            border-radius: 5px 5px 5px 5px; box-shadow: 0px 0px 5px #CCCCCC; float: left !important;
                            height: 540px !important; margin: 0 auto -18px -93px !important; opacity: 1;
                            position: relative; width: 692px !important; z-index: 999; display: none;">
                            <table>
                                <tr>
                                    <td align="right" style="background: none repeat scroll 0 0 #FFFFFF; float: left;
                                        height: 0; line-height: 0; margin-top: 0; width: 100%;">
                                        <asp:Button ID="btnCrateCustomFood" runat="server" Text="X" CssClass="close_img_pop_up"
                                            Style="background: none repeat scroll 0 0 #999999; border: medium none navy;
                                            border-radius: 30px 30px 30px 30px; color: #FFFFFF; float: left; font-family: arial;
                                            font-size: 17px; margin-left: 113px; margin-top: -14px; padding: 2px !important;
                                            position: absolute; width: 28px !important;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="gray_bg_favourties" style="float: left;">
                                            <span style="float: left;">Add New Food</span>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <div class="food_new_create" style="height: 455px !important; margin-top: 12px; overflow-x: hidden;
                                width: 695px;">
                                <table style="float: left; padding-left: 0; width: 100%; font-size: 14px;">
                                    <tr>
                                        <td>
                                            <span>Food Name</span>
                                            <asp:TextBox ID="txtAddNewFood" runat="server" ValidationGroup="CustomFoodVal" CssClass="cpna"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqFoodName" runat="server" ErrorMessage="Required"
                                                ValidationGroup="CustomFoodVal" SetFocusOnError="true" ControlToValidate="txtAddNewFood"></asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Food Brand</span>
                                            <asp:TextBox ID="txtBrandName" runat="server" ValidationGroup="CustomFoodVal" CssClass="cpna"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqFoodBrand" runat="server" ErrorMessage="Required"
                                                ValidationGroup="CustomFoodVal" SetFocusOnError="true" ControlToValidate="txtBrandName"></asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>
                                                <span>Nutrition Facts</span></h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Serving Size</span>
                                            <asp:TextBox ID="txtServingSize" runat="server" CssClass="custominputtxt clsOnlyNumeric cpna"
                                                ValidationGroup="CustomFoodVal" MaxLength="3" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqServings" runat="server" ErrorMessage="Required"
                                                ValidationGroup="CustomFoodVal" SetFocusOnError="true" ControlToValidate="txtServingSize"></asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Calories</span>
                                            <asp:TextBox ID="txtCalories" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)" ValidationGroup="CustomFoodVal"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqCalories" runat="server" ErrorMessage="Required"
                                                ValidationGroup="CustomFoodVal" SetFocusOnError="true" ControlToValidate="txtCalories"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Calories From Fat</span>
                                            <asp:TextBox ID="txtCaloriesFat" runat="server" Text="0.00" MaxLength="6" onkeypress="return alphanumeric_only(event)" CssClass="cpna"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Total Fat</span>
                                            <asp:TextBox ID="txtTotalFat" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>(g)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Saturated Fat</span>
                                            <asp:TextBox ID="txtSaturatedFat" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>(g)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Trans Fat</span>
                                            <asp:TextBox ID="txtTransFat" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>(g)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Cholesterol</span>
                                            <asp:TextBox ID="txtCholesterol" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>(mg)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Sodium</span>
                                            <asp:TextBox ID="txtSodium" runat="server" Text="0.00" MaxLength="6" onkeypress="return alphanumeric_only(event)" CssClass="cpna"></asp:TextBox>(mg)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Potassium</span>
                                            <asp:TextBox ID="txtPotassium" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>(mg)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Total Carbohydrate</span>
                                            <asp:TextBox ID="txtTotalCarbohydrate" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>(g)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Dietary Fiber</span>
                                            <asp:TextBox ID="txtDietaryFiber" runat="server" Text="0.00" MaxLength="6" onkeypress="return alphanumeric_only(event)" CssClass="cpna"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Sugars</span>
                                            <asp:TextBox ID="txtSugars" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"> </asp:TextBox>(g)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Protein</span>
                                            <asp:TextBox ID="txtProtein" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>(g)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Viatmin A</span>
                                            <asp:TextBox ID="txtVitaminA" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Viatmin C</span>
                                            <asp:TextBox ID="txtVitaminC" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Calcium</span>
                                            <asp:TextBox ID="txtCalcium" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Iron</span>
                                            <asp:TextBox ID="txtIron" runat="server" Text="0.00" CssClass="custominputtxt cpna" MaxLength="6"
                                                onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Thiamin</span>
                                            <asp:TextBox ID="txtThiamin" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Riboflavin</span>
                                            <asp:TextBox ID="txtRiboflavin" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Vitamin B6</span>
                                            <asp:TextBox ID="txtVitaminB6" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Vitamin B12</span>
                                            <asp:TextBox ID="txtVitaminB12" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Vitamin E</span>
                                            <asp:TextBox ID="txtVitaminE" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Folic Acid</span>
                                            <asp:TextBox ID="txtFolicAcid" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Niacin</span>
                                            <asp:TextBox ID="txtNiacin" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Magnesium</span>
                                            <asp:TextBox ID="txtMagnesium" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Phosphorus</span>
                                            <asp:TextBox ID="txtPhosphorus" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Iodine</span>
                                            <asp:TextBox ID="txtIodine" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Zinc</span>
                                            <asp:TextBox ID="txtZinc" runat="server" Text="0.00" CssClass="custominputtxt cpna" MaxLength="6"
                                                onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Copper</span>
                                            <asp:TextBox ID="txtCopper" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Biotin</span>
                                            <asp:TextBox ID="txtBiotin" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Pantothenic Acid</span>
                                            <asp:TextBox ID="txtPantothenicAcid" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Vitamin D</span>
                                            <asp:TextBox ID="txtVitaminD" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Carbohydrates</span>
                                            <asp:TextBox ID="txtcarbohydrates" runat="server" Text="0.00" CssClass="custominputtxt cpna"
                                                MaxLength="6" onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>Fiber</span>
                                            <asp:TextBox ID="txtfiber" runat="server" Text="0.00" CssClass="custominputtxt cpna" MaxLength="6"
                                                onkeypress="return alphanumeric_only(event)"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtnSaveCustomFood" runat="server" ImageUrl="~/images/add_log.png"
                                                ValidationGroup="CustomFoodVal" OnClick="imgBtnSaveCustomFood_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <!--table_section end  here-->
                    </div>
                    <!--left section end here-->
                    <div class="rgt_section_food_log">
                        <!--table_section start here-->
                        <div class="table_section">
                            <div class="food_log_bar">
                                <div class="title_food_bar">
                                    Calories Stats</div>
                                <div class="burned_box">
                                    <span id="spCalToBurnToday" runat="server"></span><span id="spCalToBurnTodayMsg"
                                        runat="server"></span><span><span id="spCaloriesBurnedToday" runat="server"></span>
                                    </span><span class="act_value_text"><span id="spBurnMsg" runat="server"></span></span>
                                </div>
                                <div class="consumed_box">
                                    <span style="" id="spConsumedCaloriesToday" runat="server"></span><span id="spTodayMsg"
                                        runat="server"></span>
                                </div>
                            </div>
                        </div>
                        <!--table_section end  here-->
                        <!--table_section start here-->
                        <div class="table_section">
                            <div class="food_log_bar">
                                <div class="title_food_bar">
                                    My Favourite</div>
                            </div>
                            <div class="table_food_data">
                                <div style="width: 100%; height: 200px; overflow-y: auto; overflow-x: hidden;">
                                    <asp:GridView ID="GrdFAvFoodLog" runat="server" AutoGenerateColumns="false" OnRowDeleting="GrdFAvFoodLog_RowDeleting"
                                        OnRowCommand="GrdFAvFoodLog_RowCommand" Width="100%" OnRowDataBound="GrdFAvFoodLog_RowDataBound">
                                        <RowStyle CssClass="table_food_detail" />
                                        <HeaderStyle CssClass="HeaderCSS1" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Food" HeaderStyle-CssClass="HeaderCSSBorder1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbUpc" runat="server" Text='<%#Eval("UAF_ID") %>' Visible="false"></asp:Label>
                                                    <asp:ImageButton ID="ImgLnkdelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete-icon.png"
                                                        CommandName="delete" CommandArgument='<%#Eval("UAF_ID") %>' Style="display: none;"
                                                        CssClass="Cross1" />
                                                    <asp:Label ID="lbFood" runat="server" Text='<%#Eval("SHORT_FOOD_NAME") %>' ToolTip='<%#Eval("FOOD_NAME") %>'
                                                        Style="margin-left: 13px !important;"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS1" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Calories" HeaderStyle-CssClass="HeaderCSSBorder2">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbCAl" runat="server" Text='<%#Eval("CALORIES") %>'></asp:Label>
                                                    <asp:ImageButton ID="ImgAddLog" runat="server" ImageUrl="~/images/add.png" CommandName="lnkADDFL"
                                                        ToolTip="Add To Daily log" OnClientClick="showDivProgress();" CommandArgument='<%#Eval("FOOD_NAME")+";"+Eval("Product_Size")+";"+Eval("CALORIES")+";"+Eval("FAT")
                                    +";"+Eval("CHOLESTROL")+";"+Eval("FIBER")+";"+Eval("SUGAR") %>' Style="display: none;" CssClass="Edit1" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS2" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <span style="font-family: Arial; font-size: 13px; margin-left: 10px; color: #A6A6A6;">
                                                No food favourites added yet</span>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <!--table_section end  here-->
                        <!--table_section start here-->
                        <div class="table_section">
                            <div class="food_log_bar">
                                <div class="title_food_bar">
                                    My Chart</div>
                            </div>
                            <asp:Chart ID="Chart2" runat="server" OnClick="Chart2_Click" Height="189px" Width="218px">
                                <Titles>
                                </Titles>
                                <Series>
                                    <asp:Series Name="Series1" CustomProperties="DrawingStyle=Pie,  
         PieDrawingStyle=Concave, MaxPixelPointWidth=300 " ShadowOffset="2" ChartType="Pie" IsValueShownAsLabel="True"
                                        ShadowColor="Black">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-IsRightAngleAxes="true" AlignmentStyle="AxesView"
                                        Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true" Area3DStyle-WallWidth="30"
                                        Area3DStyle-LightStyle="Simplistic">
                                        <AxisX>
                                            <MajorGrid Enabled="true" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                            <asp:Label ID="lbChart" runat="server" Style="color: #A6A6A6; float: left; font-family: arial;
                                font-size: 13px; margin-bottom: 42px; margin-left: 17px;" Visible="false"></asp:Label>
                        </div>
                        <!--table_section end  here-->
                    </div>
                </div>
            </div>
            </div> </div> </div>
            <div id="dvUploader" runat="server" style="display: none;">
                <asp:Panel ID="Panel11" CssClass="overlay" runat="server">
                    <asp:Panel ID="Panel21" CssClass="loader11" runat="server">
                        <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                        </div>
                        <div style="float: left; margin-top: 28px; margin-left: -249px;">
                            <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                                top: 45%;" alt="Processing Request" />
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
            <asp:HiddenField ID="hdsearhresult" runat="server" />
            <asp:HiddenField ID="hdproducname" runat="server" />
            <asp:HiddenField ID="hdproductsize" runat="server" />
            <asp:HiddenField ID="hdcal" runat="server" />
            <asp:HiddenField ID="hdchol" runat="server" />
            <asp:HiddenField ID="hdfiber" runat="server" />
            <asp:HiddenField ID="hdsugars" runat="server" />
            <asp:HiddenField ID="hdfat" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
            <asp:PostBackTrigger ControlID="btnseachfoodlog" />
        </Triggers>
    </asp:UpdatePanel>
</div>
</body>