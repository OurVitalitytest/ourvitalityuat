<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTrackMission.ascx.cs"
    Inherits="ALEREIMPACT.User.ucTrackMission" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register Src="~/User/ucProgressBar.ascx" TagName="Progressbar" TagPrefix="uc1" %>
<%@ Register Src="~/User/ucProgressBarCaloriesEaten.ascx" TagName="ProgressbarCaloriesConsume"
    TagPrefix="uc2" %>

<script type="text/javascript" src="../scripts/jquery.js"></script>

<script type="text/javascript" src="../scripts/index.js"></script>

<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="../CSS/index.css">
<link href="../CSS/style.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="../CSS/default.css" />
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
            height: 39px;
            line-height: 39px;
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
        height: 39px;
        line-height: 39px;
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
        min-height: 100px;
    }
</style>
<style type="text/css">
    .background
    {
        opacity: 0.5 !important;
        width: 977px !important;
    }
    .tab_mission_runtime div div tr td input
    {
        float: none;
        margin-top: 5px;
    }
    .activity_textbox select
    {
        height: 20px;
    }
    #trackMission_drpGender
    {
        height: 20px;
    }
    .act_heading_text span
    {
        float: left;
        font-size: 15px;
        font-weight: bold;
        margin-right: 10px;
    }
    #trackMission_Panletxt_inches
    {
        margin-top: 5px;
    }
    #trackMission_ddlH_UnitInches
    {
        float: left;
        height: 22px;
        margin-top: 6px;
    }
    .act_col4_data
    {
        border-top: medium none !important;
        float: left !important;
        margin-bottom: 5px;
        margin-top: 13px;
        padding-left: 23px;
        text-align: right;
    }
    .activity_textbox input
    {
        border: 1px solid #CCCCCC;
        border-radius: 5px 5px 5px 5px;
        float: left;
        font-family: arial;
        font-size: 13px;
        height: 20px;
        padding-left: 10px;
        width: 50px;
    }
    .tab_mission_runtime div div
    {
        font-size: 19px;
        line-height: 28px !important;
    }
    .tab_mission_runtime div div
    {
        text-align: left !important;
    }
    .tab_mission_runtime div div
    {
        float: left;
        font-size: 14px;
        line-height: 10px;
    }
    .tab_mission_runtime div div
    {
        line-height: 10px !important;
    }
    .activity_button
    {
        float: left;
        margin-left: 15px;
        margin-top: 13px;
    }
</style>

<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>

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

    $(function() {
        $('.clsOnlyAlphs').bind("copy paste", function(e) {
            // alert(e.keyCode);
            e.preventDefault();
            alert("Copy and Paste not allowed.");
        });
    });


    function ShowFavContent(rowIndex) {
        //Foodlog_GrdFAvFoodLog
        var gridview = document.getElementById("<%=  GrdFavActivityLog.ClientID %>");
        var RowNumber = (+rowIndex + 1).toString();


        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }

        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_imgbtnDelete").style.display = 'block';



    }
    function HideFavContent(rowIndex) {
        var gridview = document.getElementById("<%=  GrdFavActivityLog.ClientID %>");
        var RowNumber = (+rowIndex + 1).toString();


        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }

        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_imgbtnDelete").style.display = 'none';


    }

    function showContents(rowIndex) {


        var gridview = document.getElementById("<%= GrdActivitiesLog.ClientID %>");
        var RowNumber = (+rowIndex + 1).toString();


        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }


        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImageButton1").style.display = 'block';



    }
    function HideElemments(rowIndex) {
        var gridview = document.getElementById("<%= GrdActivitiesLog.ClientID %>");

        var RowNumber = (+rowIndex + 1).toString();
        // alert(RowNumber);

        if (rowIndex < 10) {
            RowNumber = "0" + RowNumber;
        }



        document.getElementById(gridview.id.toString() + "_ctl" + RowNumber + "_ImageButton1").style.display = 'none';


    }
    function PopulateHidden() {
        document.getElementById('trackMission_hdnCheckPostback').value = 'No';

    }
    //    function RemoveHidden() {
    //        alert('1');
    //        document.getElementById('trackMission_hdnCheckPostback').value = '';
    //        alert(document.getElementById('trackMission_hdnCheckPostback').value);

    //    }
    $(function() {
        $('.searchactivity').bind('keydown', function(e) { //on keydown for all textboxes

            if (e.keyCode == 13) //if this is enter key
            {
                document.getElementById('trackMission_Panel1').style.display = 'none';
                document.getElementById('trackMission_Panel2').style.display = 'none';

                return false;
            }
        });
    });  
</script>

<script language="javascript" type="text/javascript">


    function calculateHeartRate() {
        var yearUnits = document.getElementById("trackMission_drpYear");
        var strYear = yearUnits.options[yearUnits.selectedIndex].value;
        var currentTime = new Date();
        var year = currentTime.getFullYear();

        document.getElementById('trackMission_txtHeartRateAvg').value = 220 - (year - strYear);

    }
    function checkPersonalDetails() {
        if (document.getElementById('trackMission_divGender').style.display == "block") {
            if (document.getElementById('trackMission_drpGender').value == "0") {
                alert('Please select your gender !');
                return false;
            }
        }



        if (document.getElementById('trackMission_divDOB').style.display == "block") {

            var yearUnits = document.getElementById("trackMission_drpYear");
            var strYear = yearUnits.options[yearUnits.selectedIndex].value;

            if (strYear == "0") {
                alert('Please select year of birth !');
                return false;
            }

            var MonthUnits = document.getElementById("trackMission_drpMonth");
            var strMonth = MonthUnits.options[MonthUnits.selectedIndex].value;

            if (strMonth == "0") {
                alert('Please select month of birth !');
                return false;

            }
            var dayUnits = document.getElementById("trackMission_drpMonth");
            var strDay = dayUnits.options[dayUnits.selectedIndex].value;

            if (strDay == "0") {

                alert('Please select day of birth !');
                return false;

            }
        }


        if (document.getElementById('trackMission_divWeight').style.display == "block") {
            if (document.getElementById('trackMission_txtWeight').value == '') {
                alert('Please enter your weight !');
                return false;
            }
            if (document.getElementById('trackMission_txtWeight').value == '0' || document.getElementById('trackMission_txtWeight').value == '00' || document.getElementById('trackMission_txtWeight').value == '000') {
                alert('Please enter correct weight !');
                return false;
            }
        }
        if (document.getElementById('trackMission_divWeight').style.display == "block") {

            var wUnits = document.getElementById("trackMission_drpUserWeightOptions");
            var strWeight = wUnits.options[wUnits.selectedIndex].value;

            if (strWeight == "0") {
                alert('Please select your weight units !');
                return false;
            }
        }
        if (document.getElementById('trackMission_dvHeight').style.display == "block") {
            if (document.getElementById('trackMission_txtHeight').value == '') {
                alert('Please enter your height !');
                return false;
            }
            if (document.getElementById('trackMission_txtHeight').value == '0' || document.getElementById('trackMission_txtHeight').value == '00' || document.getElementById('trackMission_txtHeight').value == '000') {
                alert('Please enter correct height !');
                return false;
            }
        }
        if (document.getElementById('trackMission_dvHeight').style.display == "block") {

            var hUnits = document.getElementById("trackMission_drpUserHeightOptions");
            var strHeight = hUnits.options[hUnits.selectedIndex].value;

            if (strHeight == "0") {
                alert('Please select your height units !');
                return false;
            }

        }
        if (document.getElementById('trackMission_dvHeartRate').style.display == "block") {
            if (document.getElementById('trackMission_txtHeartRateAvg').value == '') {
                alert('Please enter your heart rate !');
                return false;
            }

            if (document.getElementById('trackMission_txtHeartRateAvg').value != '') {

                var heartRate = document.getElementById('trackMission_txtHeartRateAvg').value;

                if (heartRate < 70 || heartRate > 220) {
                    alert('Heart rate should be between 70 and 220 !');
                    return false;
                }
            }
        }
    }
    function ShowalertForDistance() {
        alert('Please enter distance covered while performing the activity !');
        return false;
    }
    function ShowalertForNoActivity() {
        alert('Please enter an activity !');
    }
    function Showalert() {
        alert('Please type & wait for auto search drilldown list ... !');
    }
    function ShowalertForDuration() {
        alert('Please enter duration of the activity performed !');
    }
    function showIcon() {
        var autocomplete = document.getElementById('trackMission_txtSearchActivities');
        autocomplete.style.backgroundImage = 'url(../images/loader.gif)';
        autocomplete.style.backgroundRepeat = 'no-repeat';
        autocomplete.style.backgroundPosition = 'right';

    }

    function hideIcon() {
        var autocomplete = document.getElementById('trackMission_txtSearchActivities');
        autocomplete.style.backgroundImage = 'none';
    } 
</script>

<script type="text/javascript">

    function ShowProgresBarForActivities() {
        document.getElementById('<%=dvActivitySelectedProgressBar.ClientID %>').style.display = 'block';
    }


    function ShowImage(evt) {
        document.getElementById('<%= txtSearchActivities.ClientID %>').style.backgroundImage = 'url(../images/loader.gif)';
        document.getElementById('<%= txtSearchActivities.ClientID %>').style.backgroundRepeat = 'no-repeat';

        if (document.getElementById('<%= txtSearchActivities.ClientID %>').value == '') {

            document.getElementById('<%= txtSearchActivities.ClientID %>').style.backgroundImage = 'none';
        }
    }

</script>

<script language="javascript" type="text/javascript">
    function SelectSingleRadiobutton(rdbtnid) {
        var rdBtn = document.getElementById(rdbtnid);
        var rdBtnList = document.getElementsByTagName("input");
        for (i = 0; i < rdBtnList.length; i++) {
            if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                rdBtnList[i].checked = false;
            }
        }
    }
    function Validate_QuickLogRadioButtons() {

        var chks = document.getElementsByTagName('input');
        var hasChecked = false;
        for (var i = 0; i < chks.length; i++) {
            if (chks[i].checked) {
                hasChecked = true;
                break;
            }
        }
        if (hasChecked == false) {
            alert("Please select at least one activity..!");

            return false;
        }
        document.getElementById('<%=dvProgressBarOnModalPop.ClientID %>').style.display = 'block';
        return true;
    }
</script>

<script type="text/javascript">

    function getFlickerSolved() {
        document.getElementById('<%=pnlQuickLog.ClientID%>').style.display = 'none';
    }
    function getFlickerSolvedActivities() {

        document.getElementById('<%=pnlActivities.ClientID%>').style.display = 'none';
    }
    function PostToNewWindow(url) {

        window.open(url, 'na', 'left=50,top=20,width=1100,height=590,toolbar=1,resizable=0');
        return false;
    }

    function InvalidFitBitMsg() {
        alert('You have provided invalid fitbit consumer key and consumer secret !');
        window.location.href = 'FitBitAccountSettings.aspx';

    }
    function FitBitAccountMsg() {
        $('.fitbit_instructions').show();
        return false;
    }

    function closeFitBit() {

        $('.fitbit_instructions').hide();
        return false;
    }

    function SelectHeight() {
        if (document.getElementById('trackMission_drpUserHeightOptions').value == '2') {
            document.getElementById('<%= Panletxt_inches.ClientID %>').style.display = 'none';
            document.getElementById('<%= ddl_inches.ClientID %>').style.display = 'none';

        }
        else if (document.getElementById('trackMission_drpUserHeightOptions').value == '3') {
            document.getElementById('<%= Panletxt_inches.ClientID %>').style.display = 'block';
            document.getElementById('<%= ddl_inches.ClientID %>').style.display = 'block';
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
    function ShowManualCalorieConsumedOption() {

        if (document.getElementById('<%= dvConsumedManually.ClientID %>').style.display == 'none') {
            document.getElementById('<%= dvConsumedManually.ClientID %>').style.display = 'block';
            document.getElementById('<%= dvConsumed.ClientID %>').style.display = 'none';
        }
        else {

            document.getElementById('<%= dvConsumedManually.ClientID %>').style.display = 'none';
            document.getElementById('<%= dvConsumed.ClientID %>').style.display = 'block';

        }
        return false;
    }
    function ShowManualCalorieBurnedOption() {

        if (document.getElementById('<%= dvBurnedManually.ClientID %>').style.display == 'none') {

            document.getElementById('<%= dvBurnedManually.ClientID %>').style.display = 'block';
            document.getElementById('<%= dvBurned.ClientID %>').style.display = 'none';

        }
        else {
            document.getElementById('<%= dvBurnedManually.ClientID %>').style.display = 'none';
            document.getElementById('<%= dvBurned.ClientID %>').style.display = 'block';

        }
        return false;
    }
    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
    
</script>

<style type='text/css'>
    .header_items_css
    {
        color: #666666;
        display: block;
        float: left;
        font-family: arial;
        font-size: 15px;
        font-weight: bold;
        padding: 0;
        text-align: center;
        width: 465px;
    }
    .header_items_css .act_col1
    {
        width: 23% !important;
    }
    .header_items_css .act_col2
    {
        width: 25%;
    }
    .header_items_css .act_col3
    {
        width: 20%;
    }
    .header_items_css .act_col4
    {
        width: 15%;
        color: #666666;
        float: left;
        font-family: arial;
        font-size: 16px;
        font-weight: bold;
        margin-bottom: 5px;
        margin-top: 7px;
        text-align: left;
    }
    .scroller_food_item .act_col1_data
    {
        width: 23% !important;
    }
    .scroller_food_item .act_col2_data
    {
        width: 25%;
        padding: 0;
    }
    .scroller_food_item .act_col3_data
    {
        width: 20%;
        padding: 0;
    }
    .CompletionListCssClass1
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: .8em;
        font-weight: normal;
        border: solid 1px #006699;
        line-height: 20px;
        padding: 30px;
        background-color: white;
        margin-left: 30px;
        text-align: left;
    }
    .CompletionListItemCssClass1
    {
        border-bottom: dotted 1px white;
        cursor: pointer;
        color: Grey;
        text-align: left;
    }
    .CompletionListHighlightedItemCssClass1
    {
        color: #0E7C7D;
        background-color: white;
        cursor: pointer;
    }
    .just-td
    {
        background: #FFF;
        padding: 5px;
    }
    .just-td:hover
    {
        background: #eee;
    }
    .grdQuickLogCss td:hover
    {
        background-color: #eee;
        color: #0D0B0C;
    }
    .info, .success, .warning, .error, .validation
    {
        border: 1px solid;
        margin: 10px 0px;
        padding: 1px 12px 4px 44px;
        background-repeat: no-repeat;
        background-position: 10px center;
    }
    .warning
    {
        color: #9F6000;
        background-color: #FEE17A;
        background-image: url(   '../Images/warning.png' );
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
    .tab_mission_runtime div div
    {
        /* float:none !important; */
        line-height: 28px !important;
        font-size: 19px;
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
    /*.ajax__calendar_next
 {
   background-image: url("WebResource.axd?d=ayjpEXrdvWvOW2gTaAtztRBv6fPyXifU7GjqL6F2DmumYG-tHQluWz_kAzIBnRm70&t=634946142760000000");
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
        overflow: hidden !important;
        text-align: center !important;
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
        margin-top: -19px;
        text-align: center;
        width: 217px;
        margin-left: 0px !important;
        margin-right: 0px !important;
    }
    #trackMission_CalendarExtender1_yearsBody .ajax__calendar_year
    {
        font-size: 14px !important;
        line-height: 13px !important;
        color: #004080 !important;
    }
    #trackMission_CalendarExtender1_monthsBody .ajax__calendar_month
    {
        font-size: 14px !important;
        line-height: 13px !important;
        color: #004080 !important;
    }
    #trackMission_CalendarExtender1_daysBody .ajax__calendar_day
    {
        font-size: 14px !important;
    }
    #trackMission_CalendarExtender1_daysTableHeader .ajax__calendar_dayname
    {
        font-size: 14px !important;
    }
    #trackMission_CalendarExtender1_popupDiv .ajax__calendar_footer ajax__calendar_today
    {
        color: #004080;
    }
    .activity_left_section table tr:first-child td
    {
        color: #52ADAE;
        font-size: 15px;
        font-weight: bold;
    }
    .scroller_food_item .act_col3_data
    {
        padding: 0;
        width: 15% !important;
    }
    .scroller_food_item > td
    {
        float: left;
        height: 15px;
        width: 14%;
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
    }
    .ItemCSS1
    {
        border-right: 1px solid #ccc;
        text-align: center;
        width: 48% !important;
    }
    .ItemCSS2
    {
        border-right: 1px solid #ccc;
        text-align: center;
        width: 48% !important;
        font-size: 11px;
        font-family: Arial;
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
        width: 48% !important;
    }
    .HeaderCSSBorder2
    {
        text-align: center;
    }
    .Cross
    {
        border-width: 0;
        display: none;
        float: left;
        margin-left: 15px;
        margin-top: 10px;
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
        right: 67px;
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
        margin-left: 15px;
        z-index: 10;
    }
    .left_section_food_log .table_food_data > div > div
    {
        width: 100%;
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

<asp:HiddenField ID="hdnCheckPostback" runat="server" />
<body ondragstart="return false;" ondrop="return false;">
    <asp:UpdatePanel ID="updatePanelTrackMission" runat="server">
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
                <span class="buget_activity" style="background: none repeat scroll 0 0 #2AA6DC; border-radius: 16px 16px 16px 16px;
                    color: #FFFFFF; float: left; font-family: myriad pro; font-size: 13px; height: 16px;
                    margin-left: -749px; margin-top: 76px; padding: 3px 12px 0;">
                    <asp:LinkButton ID="LinkButton5" Text="Activity Log" runat="server" OnClick="imghistory_Click"
                        OnClientClick="showDiv2()">
                    </asp:LinkButton>
                    &nbsp;&nbsp; </span><span class="buget_activity" style="background: none repeat scroll 0 0 #4A5675;
                        border-radius: 16px 16px 16px 16px; color: #FFFFFF; float: left; font-family: myriad pro;
                        font-size: 13px; height: 16px; margin-left: -621px; margin-top: 76px; padding: 3px 12px 0;">
                        <asp:LinkButton ID="LinkButton6" Text="History" runat="server" OnClick="lnkGraphs_Click"
                            OnClientClick="showDiv2()"></asp:LinkButton>
                    </span>
            </div>
            <div class="center_food_log">
                <%--<div class="activity_left_section" style="height: 141px !important;">
                                <span class="category">
                                    <img src="../images/menu_activity.png" style="margin-left: 0px; margin-right: 14px;
                                        margin-top: 16px;" />Log</span>
                                <ul class="activity_list">
                                    <asp:LinkButton ID="lnkFood" runat="server" Text="" OnClick="lnkFood_Click" Style="padding: 0px;">
                                    <li style="height: 38px !important;">
                                    
                                        <div style="height: 48px; float: left; margin: 5px 0 0 10px; width: 59px;">
                                            <img src="../images/act_icon1.png" style="height: 27px !important; width: 28px !important;" /></div>
                                        <div style="height: 52px; float: left; font-size: 18px;">
                                           <span>Food</span>
                                        </div>
                                       
                                    </li>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkActivities" runat="server" Text="" OnClick="lnkActivities_Click"
                                        Style="padding: 0px;">
                                    <li class="activity_list_active" style="height: 38px !important;">
                                   
                                        <div style="height: 48px; float: left; margin: 2px 0 0 -109px; width: 59px;">
                                            <img src="../images/act_icon2.png" style="height: 27px !important; width: 28px !important;" /></div>
                                        <div style="float: left; font-size: 18px; margin-top: -7px !important;">
                                          <span>Activities</span>
                                        </div>
                                        
                                    </li>
                                    </asp:LinkButton>
                                </ul>
                                <ul style="list-style: none !important;">
                                    <li>&nbsp;
                                        <table style="margin-top: 80px; font-size: 12px; font-family: Arial; display: none;">
                                            <tr>
                                                <td>
                                                    <span>Today's Tacker Data</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Cal. Burnt :
                                                    <asp:Label ID="lblFitBitCalData" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Steps Covered :
                                                    <asp:Label ID="lblFitBitStepsData" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ul>
                            </div>--%>
                <div class="uppertab_log">
                    <div class="bg_sel_tab ">
                        <asp:LinkButton ID="lnkFood" runat="server" OnClick="lnkFood_Click" Style="padding: 0 0 0 18px;
                            color: #000; font-size: 17px !important;" Text="Food"></asp:LinkButton></div>
                    <div class="bg_sel_tab sel_log_tab">
                        <asp:LinkButton ID="lnkActivities" runat="server" OnClick="lnkActivities_Click" Style="color: #FFFFFF;
                            font-size: 17px !important; padding: 0 0 0 11px;" Text="Activity"></asp:LinkButton></div>
                </div>
                <div class="bottom_tab">
                    <div class="left_section_food_log">
                        <div class="table_section">
                            <span class="category">
                                <div class="food_log_bar">
                                    <div class="title_food_bar">
                                        Activity Log
                                        <div class="date_food_bar" style="float: right !important;">
                                            <asp:ImageButton ID="imgBtnPrevious" runat="server" ImageUrl="~/images/left_arrow_date.png"
                                                OnClick="imgBtnPrevious_Click" OnClientClick="showDivProgress()" Style="float: left;" />
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
                                    <asp:LinkButton ID="lnkBrowse1" Text="Browse" runat="server"></asp:LinkButton>|
                                    <asp:LinkButton ID="lnkSinkDataFromFitBit" runat="server" OnClick="lnkSinkDataFromFitBit_Click"
                                        Text="Sync with tracker"></asp:LinkButton>|
                                    <asp:LinkButton ID="lnkBrowseQuickLog" Text="Quick Log" runat="server"></asp:LinkButton>
                                </div>
                                <%--FitBit Insctruction--%>
                                <div class="fitbit_instructions" style="display: none;">
                                    <div class="top-bg">
                                        <div>
                                            <asp:LinkButton ID="close_message" runat="server" Text="X" Style="background: none repeat scroll 0 0 #CCCCCC;
                                                border-radius: 100px 100px 100px 100px; color: #FFFFFF !important; float: right;
                                                margin-left: 756px; margin-top: 1px; padding-left: 7px; padding-right: 7px; z-index: 999;"
                                                OnClientClick="return closeFitBit()"></asp:LinkButton>
                                        </div>
                                        <div class="info_section_alere">
                                            <div class="contct_des_alere">
                                                <div style="border-bottom: 1px solid; color: #52ADAE; float: left; font-size: 20px;
                                                    margin-left: 0; margin-top: -29px; padding-bottom: 9px; padding-left: 12px; width: 729px;">
                                                    If you have already integrated FitBit Tracker device.
                                                </div>
                                                <div class="text_des_btm_alere">
                                                    Step -1 : Please go to url : <a href='https://dev.fitbit.com/login' target='_blank'>
                                                        FitBit Consumer Key</a>
                                                </div>
                                                <div class="text_des_btm_alere">
                                                    Step -2 : Login into your account/ Or Create a new account and then login.
                                                </div>
                                                <div class="text_des_btm_alere">
                                                    Step -3 : Please look for the "Register and App" icon at the right hand side corner
                                                    of the home page.
                                                </div>
                                                <div class="text_des_btm_alere">
                                                    Step -4 : Fill in the details & Application Type : Browser<br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Default Access Type : Read & Write
                                                </div>
                                                <div class="text_des_btm_alere">
                                                    You will recieve a Consumer Secret & Consumer Key that you must register by clicking
                                                    here</div>
                                                <div class="ready_to_go" style="margin: 25px 10px 20px 260px">
                                                    <asp:ImageButton ID="ImgGetStartedNow" runat="server" ImageUrl="~/images/button_circle.png"
                                                        OnClick="ImgGetStartedNow_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <%--Fit Bit Ends--%>
                                <%-- Quick Log  Begins --%>
                                <asp:ModalPopupExtender ID="MdlQuickLog" runat="server" TargetControlID="lnkBrowseQuickLog"
                                    OnCancelScript="getFlickerSolved();" PopupControlID="pnlQuickLog" BackgroundCssClass="main_pop_up_box_miss"
                                    DropShadow="true" CancelControlID="btnQuickLogClose">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="pnlQuickLog" runat="server" CssClass="inner_box_pop_up_favourites"
                                    Style="background: none repeat scroll 0 0 #FFFFFF; border: 5px solid #999; box-shadow: 2px -5px 17px #555;
                                    float: left !important; height: 720px !important; margin: -125px auto -1px -65px !important;
                                    width: 863px !important; border-radius: 10px 10px 10px 10px; z-index: 999; display: none;
                                    opacity: 1;">
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnQuickLogClose" runat="server" Text="X" CssClass="close_img_pop_up"
                                                    Style="background: none repeat scroll 0 0 #999; border: medium none navy; border-radius: 30px 30px 30px 30px;
                                                    color: #FFFFFF; float: right; font-family: arial; font-size: 17px; margin-left: -9px;
                                                    margin-top: -17px; padding: 2px !important; position: absolute; width: 28px !important;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="gray_bg_favourties_track" style="float: left; width: 859px">
                                                    <span style="float: left; margin-left: 14px; margin-top: 9px; color: #444">Please select
                                                        one of the following options :</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #eee; border: 1px solid #ccc; color: black; font-size: 17px;
                                                margin: 1em 0 4em; padding: 0 3px 1px; text-align: center; font-family: arial;">
                                                <span>The following calories burned have been mentioned after performing activities
                                                    / 30 minutes for 154 lb</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="inner_heading_favourites" style="color: #444444; float: left !important;
                                                    font-family: Arial,Helvetica,sans-serif; font-size: 16px !important; height: 551px;
                                                    margin-left: 20px; margin-top: 3px; overflow-x: hidden; overflow-y: scroll; width: 839px;">
                                                    <asp:GridView ID="grdQuickLog" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                                        Style="height: 100px;">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderText="Activities" HeaderStyle-CssClass="check_invite"
                                                                HeaderStyle-Font-Underline="true" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <table width="800px">
                                                                        <tr>
                                                                            <td width="50px">
                                                                                <img src="../images/arrow_blue.png" style="margin-top: 10px; margin-left: 20px;" />
                                                                            </td>
                                                                            <td class="just-td" width="700px" align="left" valign="bottom">
                                                                                &nbsp;&nbsp;
                                                                                <asp:RadioButton ID="radQuickLog" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                                                                                <asp:Label ID="lblActivity" runat="server" Text='<%#Eval("activities") %>' Font-Size="14px"
                                                                                    Font-Bold="true" Style="margin-left: -18px;"></asp:Label>
                                                                                <%-- (<asp:Label ID="Label2" runat="server" Text='<%#Eval("activities_description") %>'
                                                                                        Font-Size="13px" ForeColor="Black"></asp:Label>)--%>
                                                                                <br />
                                                                                <span style="font-size: 13px; margin-left: -3px; color: #A14848">Calories Burned</span>
                                                                                <asp:Label ID="lblcalories" runat="server" Text='<%#Eval("calorie_range") %>' ForeColor="#A14848"
                                                                                    Font-Size="13px"></asp:Label>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Label ID="lblQuickLogCalories" runat="server" Text='<%#Eval("activities") + "@" + Eval("calories") %>'
                                                                                    Font-Size="14px" Style="display: none;"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="activity_button">
                                                    <asp:Button ID="btnSave_QuickLog" runat="server" OnClick="btnSave_QuickLog_Click"
                                                        OnClientClick="return Validate_QuickLogRadioButtons()" Text="Log Activity" Style="cursor: pointer;
                                                        margin-left: -14px;" />
                                                </div>
                                                <div id="dvProgressBarOnModalPop" runat="server" style="display: none; margin-left: -162px;
                                                    margin-top: 70px;">
                                                    <span style="font-family: Verdana; color: Black;">Processing Your Request ...</span><br />
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
                                OnCancelScript="getFlickerSolvedActivities();" CancelControlID="btnClosepnlActivities">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="pnlActivities" runat="server" CssClass="inner_box_pop_up_favourites"
                                Style="background: none repeat scroll 0 0 #FFFFFF; border: 5px solid #999; border-radius: 10px 10px 10px 10px;
                                box-shadow: 2px -5px 15px #555; float: left !important; height: 500px !important;
                                margin: -270px auto -1px -90px !important; width: 843px !important; z-index: 999;
                                display: none;">
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
                                                <span style="float: left; margin-left: 14px; margin-top: 9px;">Please select a category
                                                    and then an activity</span>
                                            </div>
                                            <div class="inner_heading_favourites" style="float: left !important; margin-left: 53px;">
                                                Category</div>
                                            <div class="inner_heading_favourites" style="float: left; margin-left: 60px;">
                                                Activity
                                                <img src="../images/spacer.gif" height="0px" width="100px" />
                                                <div id="dvActivitySelectedProgressBar" runat="server" style="display: none; margin-left: 220px;
                                                    margin-top: -48px;">
                                                    <span style="font-family: Verdana; color: Black;">Processing...</span><br />
                                                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" alt="hello" />
                                                </div>
                                            </div>
                                            <div style="border: 1px solid #CCCECD; margin-left: 3px; height: 419px; margin-top: 22px;">
                                                <div class="inner_box_left_favourites" style="height: 409px; overflow-x: hidden;
                                                    overflow-y: scroll; width: 240px;">
                                                    <ul class="left_link_favourites" style="overflow: hidden !important; height: auto !important;">
                                                        <asp:GridView ID="grdCategories" runat="server" OnRowDataBound="grdCategories_RowDataBound"
                                                            ShowHeader="false" OnRowCommand="grdCategories_RowCommand" AutoGenerateColumns="false"
                                                            Style="height: 100px;">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderText="  " HeaderStyle-CssClass="check_invite"
                                                                    HeaderStyle-Font-Underline="true" ItemStyle-Width="222px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <li class="sel_bg_favourites">
                                                                                        <asp:LinkButton ID="lnkCategory" runat="server" Text='<%# Eval("category") %>' CommandName="SelectCategory"
                                                                                            OnClientClick="return ShowProgresBarForActivities()" CommandArgument='<%# Eval("pk_category_master_id") %>'
                                                                                            Style="float: left; font-size: 14px; color: #444 !important"></asp:LinkButton>
                                                                                    </li>
                                                                                    <asp:GridView ID="grdSubCategories" runat="server" OnRowDataBound="grdSubCategories_RowDataBound"
                                                                                        OnRowCommand="grdSubCategories_RowCommand" AutoGenerateColumns="false" ShowHeader="false">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <li class="left_sub_links_favourties">
                                                                                                        <asp:LinkButton ID="lnkSubCategory" runat="server" Text='<%# Eval("sub_category") %>'
                                                                                                            OnClientClick="return ShowProgresBarForActivities()" CommandArgument='<%# Eval("fk_category_master_id") %>'
                                                                                                            CommandName="SelectSubCategory" Style="font-size: 14px; margin-left: 17px; float: left;"></asp:LinkButton>
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
                                                    overflow-x: hidden; overflow-y: scroll; width: 579px;">
                                                    <asp:GridView ID="grdActivities" runat="server" ShowHeader="false" CssClass="right_content_favourites"
                                                        AutoGenerateColumns="false" Style="line-height: 23px !important;" OnRowCommand="grdActivities_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkActivities" runat="server" Text='<%# Eval("activity") %>'
                                                                        OnClientClick="return ShowProgresBarForActivities()" CommandName="lnkActivity"
                                                                        CommandArgument='<%#Eval("activity") %>' CssClass="right_links_favourites" Style="color: #424242;
                                                                        font-size: 14px;"></asp:LinkButton>
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
                            <div class="act_heading_text" style="float: left !important; width: 200px; margin-left: -4px !important;
                                margin-top: 8px;">
                                Find an Activity to Log</div>
                            <div class="activity_search">
                                <asp:TextBox ID="txtSearchActivities" runat="server" CssClass="searchactivity clsOnlyAlphs"
                                    AutoPostBack="true" OnTextChanged="txtSearchActivities_TextChanged"></asp:TextBox>
                                <asp:Image ID="auto_processing_image" Style="visibility: hidden" src="../images/loader.gif"
                                    runat="server" Height="18px" Width="18px" />
                                <asp:TextBoxWatermarkExtender ID="txtAutoCompleteforActivities_waterMark" runat="server"
                                    TargetControlID="txtSearchActivities" WatermarkText="Type letters to search an Activity here and wait ..."
                                    Enabled="true">
                                </asp:TextBoxWatermarkExtender>
                                <div id="listActivities" style="height: 200px; overflow: scroll; overflow-x: hidden;
                                    display: none;">
                                </div>
                                <asp:AutoCompleteExtender ID="txtAutoCompleteforActivity_AutoCompleteExtender" MinimumPrefixLength="1"
                                    ContextKey="5" TargetControlID="txtSearchActivities" CompletionInterval="1" BehaviorID="AutoCompleteEx"
                                    ServiceMethod="GetRecords" ServicePath="/Service/alereimpactservice.asmx" runat="server"
                                    CompletionListCssClass="CompletionListCssClass1" CompletionListItemCssClass="CompletionListItemCssClass1"
                                    CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass1"
                                    OnClientPopulating="showIcon" OnClientPopulated="hideIcon" OnClientHiding="hideIcon">
                                </asp:AutoCompleteExtender>
                            </div>
                            <div id="divDuration" runat="server" style="display: none; border-bottom: 1px solid #ccc;"
                                class="act_heading_text">
                                <span style="float: left; margin-right: 10px;">Duration:</span><div class="activity_textbox">
                                    <asp:TextBox ID="txtHours" runat="server" MaxLength="2"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                        TargetControlID="txtHours">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtHours"
                                        WatermarkText="hrs." WatermarkCssClass="cls">
                                    </asp:TextBoxWatermarkExtender>
                                    <span class="act_colon">:</span></div>
                                <div class="activity_textbox">
                                    <asp:TextBox ID="txtminutes" runat="server" MaxLength="2"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers"
                                        TargetControlID="txtminutes">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtminutes"
                                        WatermarkText="min" WatermarkCssClass="cls">
                                    </asp:TextBoxWatermarkExtender>
                                    <span class="act_colon">:</span></div>
                                <div class="activity_textbox">
                                    <asp:TextBox ID="txtSec" runat="server" MaxLength="2"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers"
                                        TargetControlID="txtSec">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="txtSec"
                                        WatermarkText="sec" WatermarkCssClass="cls">
                                    </asp:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div id="divDistance" runat="server" style="display: none; float: left;" class="act_heading_text">
                                <span style="float: left;">Distance(in miles) :</span>
                                <div class="activity_textbox">
                                    <asp:TextBox ID="txtDistance" runat="server" MaxLength="2" Style="float: left; margin-left: 8px;
                                        margin-top: 5px;"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers"
                                        TargetControlID="txtDistance">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                                <div class="activity_textbox">
                                    <asp:DropDownList ID="DrpDIstance" runat="server" Style="float: left; margin-left: 8px;
                                        margin-top: 7px;">
                                        <asp:ListItem Text="Km" Value="Km"></asp:ListItem>
                                        <asp:ListItem Text="Miles" Value="Miles"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="divGender" runat="server" class="act_heading_text" style="display: none;">
                                <span style="float: left;">Gender :</span>
                                <div class="activity_textbox" style="float: left; margin-left: 13px; margin-top: 7px;">
                                    <asp:DropDownList ID="drpGender" runat="server" Style="float: left;">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                </div>
                            </div>
                            <div id="divDOB" runat="server" class="act_heading_text" style="display: none;">
                                <span style="float: left;">Date of Birth :</span>
                                <div class="activity_textbox" style="float: left; margin-left: 11px;">
                                    <asp:DropDownList ID="drpYear" runat="server" AppendDataBoundItems="true" CssClass="years"
                                        onchange="return calculateHeartRate();">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdndate" runat="server" />
                                    <asp:DropDownList ID="drpMonth" runat="server" AppendDataBoundItems="true" CssClass="month">
                                        <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DrpDAy" runat="server" AppendDataBoundItems="true" CssClass="days">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="divWeight" runat="server" class="act_heading_text" style="display: none;">
                                <span style="float: left;">Weight:</span>
                                <div class="activity_textbox">
                                    <asp:TextBox ID="txtWeight" runat="server" Style="float: left; margin-left: 8px;
                                        margin-top: 5px;" MaxLength="3"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers"
                                        TargetControlID="txtWeight">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:DropDownList ID="drpUserWeightOptions" runat="server" Width="90px" Style="float: left;
                                        height: 21px; margin-left: 8px; margin-top: 6px; width: 100px;">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="dvHeight" runat="server" class="act_heading_text" style="display: none;">
                                <span style="float: left;">Height:</span>
                                <div class="activity_textbox">
                                    <asp:TextBox ID="txtHeight" MaxLength="3" runat="server" Style="float: left; margin-left: 8px;
                                        margin-top: 5px;"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers"
                                        TargetControlID="txtHeight">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:DropDownList ID="drpUserHeightOptions" runat="server" Style="float: left; height: 22px;
                                        margin-left: 9px; margin-top: 5px; width: 100px;" onclick="return SelectHeight()">
                                        <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="cms" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Feet" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Panel ID="Panletxt_inches" runat="server" Style="display: none;">
                                        <asp:TextBox ID="txtheightInches" runat="server" Style="float: left; margin-left: 12px;
                                            width: 34px;" MaxLength="3"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterType="Custom"
                                            ValidChars="0123456789." TargetControlID="txtheightInches" />
                                    </asp:Panel>
                                    <asp:Panel ID="ddl_inches" runat="server" Style="float: left; margin-left: 10px;
                                        display: none;">
                                        <asp:DropDownList ID="ddlH_UnitInches" runat="server" Style="float: left;">
                                            <asp:ListItem Text="inches" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div id="dvHeartRate" runat="server" class="act_heading_text" style="display: none;">
                                <span style="float: left;">Average HeartRate :</span>
                                <div class="activity_textbox" style="float: left; margin-left: 13px; margin-top: 7px;">
                                    <asp:TextBox ID="txtHeartRateAvg" runat="server" Style="float: left; margin-left: 8px;
                                        margin-top: -2px;" MaxLength="3"></asp:TextBox>&nbsp;bpm
                                    <asp:FilteredTextBoxExtender ID="flttxtHeartRateAvg" runat="server" FilterType="Numbers"
                                        TargetControlID="txtHeartRateAvg">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                                <div style="float: right; font-size: 14px; margin-right: 16px; margin-top: 8px;">
                                    <a id="aCalucateclories" runat="server" style="color: #53B0B1 !important; cursor: pointer;">
                                        Calculate Heart Rate</a>
                                </div>
                            </div>
                            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="aCalucateclories"
                                PopupControlID="pnlSteps" BackgroundCssClass="main_pop_up_box_miss background"
                                DropShadow="true" CancelControlID="btnCloseCal">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="pnlSteps" runat="server" CssClass="inner_box_pop_up_favourites" Style="background: none repeat scroll 0 0 #FFFFFF;
                                border: 5px solid #999; border-radius: 10px 10px 10px 10px; box-shadow: 2px -5px 15px #555;
                                float: left !important; height: 500px !important; margin: -270px auto -1px -90px !important;
                                width: 843px !important; z-index: 999; display: none;">
                                <asp:Button ID="btnCloseCal" runat="server" Text="X" CssClass="close_img_pop_up"
                                    Style="background: none repeat scroll 0 0 #999999; border: medium none navy;
                                    border-radius: 30px 30px 30px 30px; color: #FFFFFF; float: right; font-family: arial;
                                    font-size: 17px; margin-left: -5px; margin-right: -16px !important; margin-top: -17px;
                                    padding: 2px !important; width: 27px !important; cursor: pointer;" />
                                <div style="height: 500px !important; overflow-x: hidden; overflow-y: scroll !important;">
                                    <table>
                                        <tr>
                                            <td>
                                            <tr>
                                                <td>
                                                    <div style="font-family: arial !important; font-size: 17px; font-weight: bold; margin-left: 224px;
                                                        text-align: left;">
                                                        <span style="color: #444444 !important;">Calculate Maximum & Target Heart Rate</span>
                                                    </div>
                                                </td>
                                            </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 16px; font-weight: bold;
                                                    margin-left: 12px;">
                                                    <span style="color: #444444 !important;">Step I</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 15px; margin-left: 25px;">
                                                    <span style="float: left; color: #444444 !important;">Calculate your maximum heart rate.
                                                        If you are a man, subtract your age in years from 220 and note your answer, which
                                                        is your estimated maximum heart rate in bpm. For example, if you are a man aged
                                                        56, your estimated maximum heart rate is 164 bpm. </span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 16px; font-weight: bold;
                                                    margin-left: 12px;">
                                                    <span style="color: #444444 !important;">Step II</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 15px; margin-left: 25px;">
                                                    <span style="color: #444444 !important;">Use a different calculation if you are a woman.
                                                        Multiply your age in years by .88 and then subtract your answer from 206. Note the
                                                        result, which is your estimated maximum heart rate in bpm. For example, if you are
                                                        a woman aged 48, your estimated maximum heart rate is 164 bpm. </span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 16px; font-weight: bold;
                                                    margin-left: 12px;">
                                                    <span style="color: #444444 !important;">Step III</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 15px; margin-left: 25px;">
                                                    <span style="color: #444444 !important;">Calculate 50 percent, 70 percent and 85 percent
                                                        of your estimated maximum heart rate. Multiply your maximum heart rate by .5, .7
                                                        and .85 respectively. Note these figures. For example, if your estimated maximum
                                                        heart rate is 164 bpm, your figures will be 82 bpm, 115 bpm and 139 bpm. </span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 16px; font-weight: bold;
                                                    margin-left: 12px;">
                                                    <span style="color: #444444 !important;">Step IV</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 15px; margin-left: 25px;">
                                                    <span style="color: #444444 !important;">Decide on the level of activity you will undertake.
                                                        If you intend to work out at moderate intensity, your target heart rate should be
                                                        between 50 percent and 70 percent of your maximum heart rate. For example, if your
                                                        estimated maximum heart rate is 164 bpm and you undertake a moderate workout, your
                                                        target heart rate should be between 82 bpm and 115 bpm. </span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 16px; font-weight: bold;
                                                    margin-left: 12px;">
                                                    <span style="color: #444444 !important;">Step V</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: left; font-family: arial !important; font-size: 15px; margin-left: 25px;">
                                                    <span style="color: #444444 !important;">Use different limits for a vigorous workout.
                                                        If you intend to exercise vigorously, your target heart rate should be between 70
                                                        percent and 85 percent of your maximum heart rate. For example, if your estimated
                                                        maximum heart rate is 164 bpm and you undertake a vigorous workout, your target
                                                        heart rate should be between 115 bpm and 139 bpm. </span>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                            <div class="activity_button">
                                <asp:Button ID="btn_Log" runat="server" OnClick="btn_Log_Click" Style="cursor: pointer;"
                                    OnClientClick="return checkPersonalDetails()" />
                            </div>
                            <div style="float: left;">
                                <span style="float: left; margin-left: 19px;">
                                    <asp:Label ID="lbNoofSteps" runat="server" Text="" Style="float: left; font-size: 14px;
                                        display: none; color: Black;"></asp:Label>
                                    <span style="float: left; font-size: 14px; font-weight: bold; margin-left: 5px; color: Black;
                                        display: none;">Steps</span> </span><span style="float: left; margin-left: 13px;">
                                            <asp:Label ID="lbDistanceMiles" runat="server" Text="" Style="float: left; font-size: 14px;
                                                color: Black; display: none;"></asp:Label>
                                            <asp:Label ID="lbDistanceUnit" runat="server" Text="" Style="float: left; font-size: 14px;
                                                color: Black; font-weight: bold; margin-left: 5px; display: none;"></asp:Label>
                                        </span><span style="float: left; margin-left: 23px;">
                                            <asp:Label ID="lbNoofCal" runat="server" Text="" Style="float: left; font-size: 14px;
                                                color: Black; display: none;"></asp:Label>
                                            <span style="float: left; font-size: 14px; font-weight: bold; margin-left: 5px; color: Black;
                                                display: none;">calories</span> </span>
                            </div>
                        </div>
                        <div class="table_section">
                            <div class="food_log_bar">
                                <div class="title_food_bar">
                                    Logged Activities</div>
                            </div>
                            <div class="table_food_data">
                                <div style="width: 100%; height: 393px; overflow-y: auto; overflow-x: hidden;">
                                    <asp:GridView ID="GrdActivitiesLog" runat="server" AutoGenerateColumns="false" Style="width: 100%;
                                        font-size: 11px; height: auto" OnRowDataBound="GrdActivitiesLog_RowDatabound"
                                        OnRowCommand="GrdActivitiesLog_RowCommand" OnRowDeleting="GrdActivitiesLog_RowDeleting">
                                        <RowStyle CssClass="table_food_detail" />
                                        <HeaderStyle CssClass="HeaderCSS" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Activity" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbID" runat="server" Text='<%#Eval("pk_mission_log_id") %>' Visible="false"></asp:Label>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="delete" ToolTip="Delete"
                                                        OnClientClick="PopulateHidden();" CommandArgument='<%#Eval("pk_mission_log_id") %>'
                                                        ImageUrl="~/images/delete-icon.png" Style="display: none; margin-top: 10px;"
                                                        CssClass="Cross" />
                                                    <asp:Label ID="lbName" runat="server" Text='<%#Eval("Activity") %>' ToolTip='<%#Eval("activity_selected") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbHour" runat="server" Text='<%#Eval("hours_of_activity") %>'></asp:Label><span
                                                        style="font-size: 11px; color: #666666;">hrs</span>
                                                    <asp:Label ID="lbmin" runat="server" Text='<%#Eval("minutes_of_activity") %>' Style="font-size: 11px;
                                                        color: #666666;"></asp:Label><span style="font-size: 11px; color: #666666;">min</span>
                                                    <asp:Label ID="lbsec" runat="server" Text='<%#Eval("seconds_of_activity") %>' Style="font-size: 11px;
                                                        color: #666666; display: none;"></asp:Label><span style="font-size: 11px; color: #666666;"></span>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Steps" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbsteps" runat="server" Text='<%#Eval("steps_covered") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cals Burn" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbCAlsBurn" runat="server" Text='<%#Eval("calories_burnt") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Distance(in miles)" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbDistCovered" runat="server" Text='<%#Eval("distance_covered") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Floors" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbFloors" runat="server" Text='<%#Eval("floors_covered") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fav" HeaderStyle-CssClass="HeaderCSSBorder">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgBtn_Log" runat="server" ImageUrl='<%#Eval("FavImage") %>'
                                                        ToolTip="Add To favourites" OnClientClick="PopulateHidden();" CommandName="IMGBtn_Log"
                                                        CommandArgument='<%#Eval("pk_mission_log_id") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemCSS" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <span style="font-family: Arial; font-size: 13px; margin-left: 10px; color: #A6A6A6;
                                                white-space: nowrap;">Activities not Logged yet.</span>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="rgt_section_food_log">
                        <div id="dvactivity_right_section" runat="server">
                            <div class="table_section">
                                <div class="food_log_bar">
                                    <div class="title_food_bar">
                                        Cal Stats</div>
                                    <div class="burned_box" style="height: 112px !important;">
                                        <span id="spCalToBurnToday" runat="server" style="font-size: 17px !important;"></span>
                                        <span id="spCalToBurnTodayMsg" runat="server" style="font-size: 17px !important;">
                                        </span><span><span id="spCaloriesBurnedToday" runat="server"></span></span><span
                                            class="act_value_text" style="font-size: 17px !important;"><span id="spBurnMsg" runat="server"
                                                style="font-size: 17px !important;"></span></span>
                                    </div>
                                    <div class="consumed_box">
                                        <span id="spConsumedCaloriesToday" runat="server" style="font-size: 17px !important;">
                                        </span><span id="spTodayMsg" runat="server" style="font-size: 17px !important;">
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <%--   <div class="act_rt1" id="dvRegionOfCalsBurn" runat="server" visible="false">
                                    <div>
                                        <%--  <uc2:ProgressbarCaloriesConsume ID="ProgressbarCaloriesConsume1" runat="server" BGColor="#E3DCDF"
                                            Blocks="20" Cellpadding="1" CellSpacing="1" FillColor="#555555" Height="14" Width="216"
                                            top="10" />--%>
                            <%--    <span class="act_value"><span id="spCalToBurnToday" runat="server"></span></span>
                                        <span class="act_value_text"><span id="spCalToBurnTodayMsg" runat="server" runat="server" ></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="act_rt2" id="dvRegionOfConsumedCaloriesToday" runat="server">
                                    <span class="act_value"><span style="" id="spConsumedCaloriesToday" runat="server"></span>
                                    </span><span class="act_value_text"><span id="spTodayMsg" runat="server"></span>
                                    </span>
                                </div>
                                <div class="act_rt3">
                                    <span class="act_value"><span id="spCaloriesBurnedToday" runat="server"></span></span>
                                    <span class="act_value_text"><span id="spBurnMsg" runat="server"></span></span>
                                </div>
                                <div class="act_rt_table">--%>
                            <div class="table_section">
                                <div class="food_log_bar">
                                    <div class="title_food_bar">
                                        My Favourite</div>
                                </div>
                                <div class="table_food_data" style="width: 100% !important;">
                                    <div style="width: 100%; height: 200px; overflow-y: auto; overflow-x: hidden;">
                                        <asp:GridView ID="GrdFavActivityLog" runat="server" AutoGenerateColumns="false" Width="247%"
                                            OnRowDeleting="GrdFavActivityLog_RowDeleting" OnRowDataBound=" GrdFavActivityLog_RowDatabound">
                                            <RowStyle CssClass="table_food_detail" />
                                            <HeaderStyle CssClass="HeaderCSS1" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Activity" HeaderStyle-CssClass="HeaderCSSBorder1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbFavId" runat="server" Text='<%#Eval("FA_ID") %>' Visible="false"></asp:Label>
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/images/delete-icon.png"
                                                            CommandName="delete" CommandArgument='<%#Eval("FA_ID") %>' Style="display: none;
                                                            margin-top: 10px;" CssClass="Cross1" />
                                                        <asp:Label ID="lbFavActivity" runat="server" Text='<%#Eval("FA_SHORT_NAME") %>' ToolTip='<%#Eval("FA_NAME") %>'
                                                            Style="font-size: 10px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="ItemCSS1" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cals Burn" HeaderStyle-CssClass="HeaderCSSBorder2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbCalBurn" runat="server" Text='<%#Eval("FA_CAL_BURNS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="ItemCSS2" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span style="font-family: Arial; font-size: 13px; margin-left: 10px; color: #A6A6A6;">
                                                    No activity favourites added yet</span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="table_section">
                                <div class="food_log_bar">
                                    <div class="title_food_bar">
                                        My Chart</div>
                                </div>
                                <asp:Chart ID="Chart1" runat="server" Height="189px" Width="218px">
                                    <Titles>
                                    </Titles>
                                    <Series>
                                        <asp:Series Name="Series1" CustomProperties="DrawingStyle=Pie,  
         PieDrawingStyle=Concave, MaxPixelPointWidth=300, Exploded=true " ShadowOffset="2" ChartType="Pie" IsValueShownAsLabel="True"
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
                                <asp:Label ID="lbChart1" runat="server" Visible="false" Style="color: #A6A6A6; float: left;
                                    font-family: arial; font-size: 18px; margin-bottom: 42px; margin-left: 26px;
                                    margin-top: 32px;"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer_miss">
            </div>
            <div class="btm_footer_miss">
                <div class="footer_text_miss">
                    <div class="copyrite_miss">
                        © 2011 OurHealth</div>
                    <div class="privcy_miss">
                        Privacy Policy Terms & Conditions</div>
                </div>
            </div>
            </body>
            <div id="tblMissionInput" runat="server">
                <div id="dvFav" runat="server" class="rgt_food" style="float: right !important; display: none;
                    line-height: 0px !important;">
                    <%--<a href="#" style="border: medium none;">--%>
                    <asp:ImageButton ID="imgFAV" runat="server" ImageUrl="../images/food_fav.png" Style="border: medium none;"
                        OnClick="imgFAV_Click" />
                    <%-- <img src="../images/food_fav.png" /></a>--%></div>
                <div class="main_food_section" id="dvWeightLooseMission" runat="server" visible="false">
                    <div class="lft_section_food">
                        <span class="food">Browse by Category</span>
                        <div id="acc2" class="accordion" style="background-color: #EEEEEE; margin-left: 0px;">
                            <h4>
                                <asp:Repeater ID="dMajor" runat="server" OnItemDataBound="dMajor_ItemDataBound" OnItemCommand="dMajor_ItemCommand">
                                    <ItemTemplate>
                                        <h4 style="border-bottom: 1px solid #CCCCCC;">
                                            <asp:Label ID="lbid" runat="server" Text='<%#Eval("CAT_ID") %>' Visible="false"></asp:Label>
                                            <a id="ancMajorCategories" runat="server" class="trigger" style="color: #444444;
                                                border-bottom: 1px solid #CCCCCC; border: medium none; font-size: 14px; font-weight: normal;"
                                                visible="false">
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("CAT_IMAGE") %>'
                                                    Style="float: left; height: 25px; width: 25px;" />
                                                <span style="float: left; margin-left: 9px;">
                                                    <%#Eval("CAT_NAME") %>
                                                </span></a>
                                            <asp:LinkButton ID="lnkCat" runat="server" CommandName="lnkCat" CommandArgument='<%#Eval("CAT_NAME") %>'
                                                Style="color: #444444; border: medium none; font-size: 14px; font-weight: normal;"
                                                Visible="false">
                                                <asp:Image ID="Ima" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("CAT_IMAGE") %>'
                                                    Style="float: left; height: 25px; width: 25px;" />
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("CAT_NAME") %>' Style="float: left;"></asp:Label>
                                            </asp:LinkButton>
                                        </h4>
                                        <div style="background-color: #EEEEEE;">
                                            <div>
                                            </div>
                                            <asp:Repeater ID="dMajorSubcat" runat="server" OnItemDataBound="dMajorSubcat_ItemDataBound"
                                                OnItemCommand="dMajorSubcat_ItemCommand">
                                                <ItemTemplate>
                                                    <h5 style="border-bottom: 1px solid #CCCCCC;">
                                                        <asp:Label ID="lbPsubcatid" runat="server" Text='<%#Eval("SUBCAT1_ID") %>' Visible="false"></asp:Label>
                                                        <a id="a1" runat="server" class="trigger" style="color: #444444; border: medium none;
                                                            margin-left: 10px; font-size: 14px; font-weight: normal;">
                                                            <asp:Image ID="img" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("SUBCAT1_IMAGE") %>'
                                                                Style="float: left; height: 25px; width: 25px;" />
                                                            <span style="float: left; margin-left: 9px;">
                                                                <%#Eval("SUBCAT1_NAME")%></span> </a>
                                                        <asp:LinkButton ID="lnkBtnMAjorSubcat" runat="server" CommandName="lnkBtnMAjorSubcat"
                                                            CommandArgument='<%#Eval("SUBCAT1_NAME") %>' Style="color: #444444; border: medium none;
                                                            font-size: 14px; font-weight: normal;" Visible="false">
                                                            <asp:Image ID="Ima" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("SUBCAT1_IMAGE") %>'
                                                                Style="float: left; height: 25px; width: 25px;" />
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUBCAT1_NAME") %>' Style="float: left;"></asp:Label>
                                                        </asp:LinkButton>
                                                    </h5>
                                                    <div style="background-color: #FFFFFF; border: medium none; margin-left: 45px; padding-bottom: 5px;
                                                        width: 246px; padding-top: 5px;">
                                                        <asp:Repeater ID="dSubcat" runat="server" OnItemCommand="dSubcat_ItemCommand">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbsubcatid" runat="server" Text='<%#Eval("SUBCAT2_ID") %>' Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="lnkBtnSubcat" runat="server" CommandName="lnkBtnSubcat" CommandArgument='<%#Eval("SUBCAT2_NAME") %>'
                                                                    Style="color: #444444; border: medium none; font-size: 14px; font-weight: normal;">
                                                                    <asp:Image ID="Ima" runat="server" ImageUrl='<%#"~/User/FoodCategoryImages/"+Eval("SUBCAT2_IMAGE") %>'
                                                                        Style="float: left; height: 25px; width: 25px;" />
                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUBCAT2_NAME") %>' Style="float: left;"></asp:Label>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </h4>
                        </div>
                    </div>
                    <div>
                        <asp:LinkButton ID="lnkSearch" Text="Search" runat="server" OnClientClick="return ShowSearchBar()"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkBrowse" Text="Browse" runat="server"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkQuickLog" Text="Quick Log" runat="server" OnClientClick="return ShowQuickLog()"></asp:LinkButton>
                    </div>
                    <br />
                    <div id="dvShowSearchBar" runat="server">
                    </div>
                    <br />
                    <div id="dvQuickLog" runat="server" style="display: none;">
                        <asp:DropDownList ID="drpQuickLog" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="rgt_section_food" style="line-height: 25px !important;">
                        <span>Food search</span> <span class="food_des_db" style="margin-left: -87px;">The trusted
                            calorie, carbohydrate and nutritional food database. </span>
                        <div class="search_box_food">
                            <asp:TextBox ID="txtSearch" runat="server" Style="float: left;" OnTextChanged="txtSearch_TextChanged"
                                onkeypress="return handleSubComment(this,event)"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtSearch"
                                WatermarkText="Search Here">
                            </asp:TextBoxWatermarkExtender>
                            <%-- <a href="#">Or Enter Calories Manually </a>--%>
                        </div>
                        <%-- <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                        <div class="cal_food">
                            <div class="left_arrow_cal" style="display: none;">
                                <img src="mission_img/back_img.png" visible="false" /></div>
                            <div class="center_value">
                            </div>
                            <div class="rgt_arrow_cal" style="display: none;">
                                <img src="mission_img/next_img.png" visible="false" /></div>
                        </div>
                        <%-- <asp:ImageButton ID="imgPrevious" runat="server" ImageUrl="~/images/arrowhl.png"
                        Visible="false" OnClick="imgPrevious_Click" />
                  
                    <asp:ImageButton ID="imgNext" runat="server" ImageUrl="~/images/arrowhr.png" OnClick="imgNext_Click"
                        Visible="false" />--%>
                        <div class="cal_box_food">
                            <div style="float: left; width: 255px;">
                                <div class="left_food_cal">
                                    <div class="bar_section">
                                        <uc2:ProgressbarCaloriesConsume ID="Progressbar2" runat="server" BGColor="#E3DCDF"
                                            Blocks="20" Cellpadding="1" CellSpacing="1" FillColor="#D46253" Height="14" Width="248"
                                            top="10" />
                                    </div>
                                    <span class="value"></span>
                                </div>
                                <span class="buget_activity" style="background: none repeat scroll 0 0 #2AA6DC; border-radius: 16px 16px 16px 16px;
                                    color: #FFFFFF; float: left; font-family: myriad pro; font-size: 13px; height: 16px;
                                    margin-left: 25px; margin-top: 23px; padding: 3px 2px 0;">
                                    <asp:LinkButton ID="LinkButton1" Text="Activity Log" runat="server" OnClick="imghistory_Click"
                                        Style="border: medium none; float: left !important; font-family: arial !important;
                                        margin-left: 5px !important;"></asp:LinkButton>
                                    &nbsp;&nbsp; </span><span class="buget_activity" style="background: none repeat scroll 0 0 #4A5675;
                                        border-radius: 16px 16px 16px 16px; color: #FFFFFF; float: left; font-family: myriad pro;
                                        font-size: 13px; height: 16px; margin-left: 7px; margin-top: 23px; padding: 3px 12px 0;">
                                        <asp:LinkButton ID="LinkButton2" Text="History" runat="server" OnClick="lnkGraphs_Click"
                                            Style="border: medium none; float: left !important; font-family: arial !important;
                                            margin-left: 5px !important;"></asp:LinkButton>
                                    </span>
                            </div>
                            <div class="rgt_food_cal" style="line-height: 25px !important; margin-left: 25px;">
                                <div class="top_food_bar" style="line-height: 25px !important; display: none;" id="dvConsumedManually"
                                    runat="server">
                                    Consumed
                                    <br />
                                    <asp:TextBox ID="txtManuallyConsumed" runat="server" MaxLength="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Input is Required"
                                        ValidationGroup="reqdCaloriesConsumed" Display="Dynamic" Style="font-size: 13px;"
                                        ControlToValidate="txtManuallyConsumed"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                        ValidChars="0123456789." TargetControlID="txtManuallyConsumed">
                                    </asp:FilteredTextBoxExtender>
                                    <br />
                                    Calories Today
                                    <br />
                                    <asp:ImageButton ID="imgManuallyConsumed" runat="server" ImageUrl="~/images/submit.gif"
                                        ValidationGroup="reqdCaloriesConsumed" />
                                </div>
                                <div class="top_food_bar" style="line-height: 25px !important; display: block;" id="dvConsumed"
                                    runat="server">
                                    Consumed
                                    <br />
                                    <br />
                                    Calories Today
                                </div>
                                <span>
                                    <asp:LinkButton ID="lnkManualCaloriesConsumed" runat="server" Style="border: medium none;">Enter Consumed calories Manually</asp:LinkButton>
                                </span>
                                <div class="top_food_bar" style="line-height: 25px !important; display: block;" id="dvBurnedManually"
                                    runat="server">
                                    Burned
                                    <br />
                                    <asp:TextBox ID="txtBurnedManually" runat="server" MaxLength="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqdInput" runat="server" ErrorMessage="Input is Required"
                                        ValidationGroup="reqdCaloriesBurnt" Display="Dynamic" ControlToValidate="txtBurnedManually"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="fltrInput" runat="server" FilterType="Numbers" ValidChars="0123456789."
                                        TargetControlID="txtBurnedManually">
                                    </asp:FilteredTextBoxExtender>
                                    <br />
                                    Calories Today
                                    <br />
                                    <br />
                                    <asp:ImageButton ID="imgManuallyBurnt" runat="server" ImageUrl="~/images/submit.gif"
                                        ValidationGroup="reqdCaloriesBurnt" />
                                </div>
                                <div class="btm_food_bar" style="line-height: 25px !important; display: block;" id="dvBurned"
                                    runat="server">
                                    Burned
                                    <br />
                                    Calories Today
                                </div>
                                <span>
                                    <asp:LinkButton ID="lnkManualCaloriesBurned" runat="server" Text="Enter Burned calories Manually
                                   " Style="border: medium none;"></asp:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="dvUploader" runat="server" style="display: none;">
                    <asp:Panel ID="Panel11" CssClass="overlay" runat="server">
                        <asp:Panel ID="Panel21" CssClass="loader11" runat="server">
                            <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                            </div>
                            <div style="float: left; margin-top: 17px; margin-left: -249px;">
                                <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                                    top: 45%;" alt="Processing Request" />
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </div>
            <%--steps mission display--%>
            <div class="main_mission_box_new">
                <div id="breadcrumb_mission" runat="server" style="display: none; background-color: #F6F6F6;
                    border: 1px solid #DBDADA; color: #990906; font-family: Trebuchet MS Arial Helvetica sans-serif;
                    font-size: 12px; height: 21px; margin: 11px 11px 11px 7px; padding-left: 10px;
                    padding-top: 5px; width: 924px;">
                    Missions
                    <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />List All
                    Missions
                    <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />Today's
                    Input towards your mission <span style="float: right;">Go To
                        <asp:LinkButton Text="List All Missions" runat="server" ID="lnkListMission" OnClick="lnkListMission_Click"
                            OnClientClick="showDivProgress()"></asp:LinkButton>
                    </span>
                </div>
                <div class="mission_header_tab" id="dvStepsCoveredMission" runat="server" visible="false">
                    <div class="steps_mission" style="float: left !important; font-family: bebas Neue !important;
                        font-size: 37px; line-height: 0 !important; margin-left: -283px; margin-top: 17px;">
                        Steps Cover Mission
                    </div>
                    <div class="input_box_step">
                        <asp:TextBox ID="txtStepsCovered" runat="server" Style="float: left; line-height: 0 !important;
                            margin-left: -590px; margin-top: 60px" MaxLength="5"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkText="Steps taken today"
                            TargetControlID="txtStepsCovered" WatermarkCssClass="wtaercss">
                        </asp:TextBoxWatermarkExtender>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                            ValidChars="0123456789." TargetControlID="txtStepsCovered">
                        </asp:FilteredTextBoxExtender>
                    </div>
                    <div style="float: left; line-height: 0 !important; margin-left: -579px; margin-top: 119px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Input is Required."
                            ValidationGroup="reqdCaloriesConsumed" Display="Dynamic" ControlToValidate="txtStepsCovered"></asp:RequiredFieldValidator>
                    </div>
                    <div class="input_box_step_submit" style="float: left; line-height: 0 !important;
                        margin-left: -599px; margin-top: 103px;">
                        <asp:Button ID="btnSubmitStepsCovered" runat="server" Text="Submit Input" OnClick="btnSubmitStepsCovered_Click"
                            ValidationGroup="reqdCaloriesConsumed" />
                    </div>
                    <br></br>
                    <br></br>
                    <div class="seprator_mission">
                    </div>
                    <div class="cal_box_food_steps">
                        <div style="float: left; width: 385px;">
                            <div class="left_food_cal">
                                <div class="bar_section">
                                    <uc1:Progressbar ID="ProgressbarSteps" runat="server" BGColor="#E3DCDF" Blocks="20"
                                        Cellpadding="1" CellSpacing="1" FillColor="#D46253" Height="14" Width="248" top="10" />
                                </div>
                                <span class="value"><span id="spStepsAccomplished" runat="server"></span></span>
                                <span class="cal_remainin">Accomplished</span>
                            </div>
                            <span class="buget_activity" style="background: none repeat scroll 0 0 #2AA6DC; border-radius: 16px 16px 16px 16px;
                                color: #FFFFFF; float: left; font-family: myriad pro; font-size: 13px; height: 16px;
                                margin-left: 25px; margin-top: 23px; padding: 3px 2px 0;">
                                <asp:LinkButton ID="LinkButton3" Text="Activity Log" runat="server" OnClick="imghistory_Click"
                                    Style="border: medium none;"></asp:LinkButton>
                                &nbsp;&nbsp; </span><span class="buget_activity" style="background: none repeat scroll 0 0 #4A5675;
                                    border-radius: 16px 16px 16px 16px; color: #FFFFFF; float: left; font-family: myriad pro;
                                    font-size: 13px; height: 16px; margin-left: 7px; margin-top: 23px; padding: 3px 12px 0;">
                                    <asp:LinkButton ID="LinkButton4" Text="History" runat="server" OnClick="lnkGraphs_Click"
                                        Style="border: medium none;"></asp:LinkButton>
                                </span>
                        </div>
                        <div class="rgt_food_cal_steps">
                            <div class="top_food_bar_steps">
                                <span style="border-right: 1px solid #bbb; margin-right: 4%; float: left; font-size: 20px !important;
                                    width: 44%;"><span style="color: #D46253"><span id="spDailyStepsTargeted" runat="server">
                                    </span></span>
                                    <br></br>
                                    daily steps targeted </span><span style="font-size: 20px !important;"><span style="color: #D46253">
                                        <span id="spTotalAccomplishedToday" runat="server"></span></span>
                                        <br></br>
                                        total accomplished today </span>
                            </div>
                            <div class="top_food_bar_steps">
                                <span style="float: left; width: 95%; text-align: center; font-size: 25px;"><span
                                    id="spTotalStepsLeft" runat="server"></span></span><span style="float: left; width: 95%;
                                        text-align: center; font-size: 25px;">Total left</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="updatePanelTrackMission">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader" runat="server">
                    <div style="float: left; margin-top: -633px; margin-left: -9px;">
                        <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;" />
                    </div>
                </asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</body>
