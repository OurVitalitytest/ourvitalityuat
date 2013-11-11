<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProgressGraphs.ascx.cs"
    Inherits="ALEREIMPACT.User.ucProgressGraphs" %>
<%@ Register TagPrefix="ajaxControl" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register TagPrefix="ajaxtoolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<script src="../js/prototype.js" type="text/javascript"></script>

<script src="../js/effects.js" type="text/javascript"></script>

<script src="../js/accordion.js" type="text/javascript"></script>

<link href="../CSS/newstyle.css" rel="stylesheet" type="text/css" />
<%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.min.js"></script>--%>

<script type="text/javascript" language="javascript">
 $(document).ready(function () {
        $('#MissionsGraphsProgress_btnAll').click();        
 }); 
//setTimeout( function(){ 

//    ClickBtn();
//  }
// , 3000 );
//         function ClickBtn() {
//         alert('');
//            $('#MissionsGraphsProgress_btnAll').click();     
//         }
//      

       function ShowTodayDv() {

        var currentdate_date = new Date()
        var month = currentdate_date.getMonth() + 1;
        var currentdate = currentdate_date.getDate();
        var yy = currentdate_date.getYear();
        var year = (yy < 1000) ? yy + 1900 : yy;

        var months = new makeArray('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec');

        document.getElementById('<%= txtGraphCalendarNavigation.ClientID %>').value = currentdate + ", " + months[month] + " " + year;
        document.getElementById('<%= hdnDateFrom.ClientID %>').value = currentdate + " " + months[month] + " " + year;
        document.getElementById('<%= hdnDateTo.ClientID %>').value = document.getElementById('<%= hdnDateFrom.ClientID %>').value;

        // a//
        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none';
        document.getElementById('<%= txtGraphCalendarNavigation.ClientID %>').style.display = 'block';
       // showDivProgress();
    }
    function ShowWeekDv() {

        var currentdate_date = new Date();
        var month = currentdate_date.getMonth() + 1;
        var currentdate = currentdate_date.getDate();
        var yy = currentdate_date.getYear();
        var year = (yy < 1000) ? yy + 1900 : yy;


        /****** 7 days behind from selected date ************/

        var week_Back_date = new Date();
        var week_month = week_Back_date.getMonth() + 1;
        var week_date = week_Back_date.getDate() - 7;

        if (week_date == 0 || week_date < 1) {

            var week_month = week_Back_date.getMonth();

            var newDate = new Date(week_Back_date.getTime() - (60 * 60 * 24 * 7 * 1000));

            week_date = newDate;
            var week_dateNew = week_date.getDate();
            week_month = week_date.getMonth() + 1;
            week_year = week_date.getFullYear();
        }
        else {
            var week_dateNew = week_Back_date.getDate() - 7;
        }
        var week_yy = week_Back_date.getYear();
        var week_year = (week_yy < 1000) ? week_yy + 1900 : week_yy;

        /****** 7 days behind from selected date ************/



        var months = new makeArray('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec');

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value = week_dateNew + ", " + months[week_month] + " " + week_year;
        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value += "-" + currentdate + ", " + months[month] + " " + year;

        document.getElementById('<%= txtDateFrom.ClientID %>').value = week_dateNew + " " + months[week_month] + " " + week_year;
        document.getElementById('<%= txtDateTo.ClientID %>').value = currentdate + " " + months[month] + " " + year;

        document.getElementById('<%= hdnDateFrom.ClientID %>').value = document.getElementById('<%= txtDateFrom.ClientID %>').value;
        document.getElementById('<%= hdnDateTo.ClientID %>').value = document.getElementById('<%= txtDateTo.ClientID %>').value;

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').style.display = 'block';
        document.getElementById('<%= txtGraphCalendarNavigation.ClientID %>').style.display = 'none';

        //showDivProgress();
    }

    function ShowMonthDv() {

        var currentdate_date = new Date();
        var month = currentdate_date.getMonth() + 1;
        var currentdate = currentdate_date.getDate();
        var yy = currentdate_date.getYear();
        var year = (yy < 1000) ? yy + 1900 : yy;


        /****** 1 month  behind from selected date ************/

        var week_Back_date = new Date();
        var week_month = week_Back_date.getMonth();
        var week_date = week_Back_date.getDate() - 1;
        var week_yy = week_Back_date.getYear();
        var week_year = (week_yy < 1000) ? week_yy + 1900 : week_yy;

        /****** 1 month behind from selected date ************/



        var months = new makeArray('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec');

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value = currentdate + ", " + months[month] + " " + year;
        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value += "-" + week_date + ", " + months[week_month] + " " + week_year;

        document.getElementById('<%= txtDateFrom.ClientID %>').value = week_date + " " + months[week_month] + " " + week_year;
        document.getElementById('<%= txtDateTo.ClientID %>').value = currentdate + " " + months[month] + " " + year;



        document.getElementById('<%= hdnDateFrom.ClientID %>').value = document.getElementById('<%= txtDateFrom.ClientID %>').value;
        document.getElementById('<%= hdnDateTo.ClientID %>').value = document.getElementById('<%= txtDateTo.ClientID %>').value;

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').style.display = 'none';
        document.getElementById('<%= txtGraphCalendarNavigation.ClientID %>').style.display = 'block';

        // a//
        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none';
        //showDivProgress();
    }
    function ShowMultipleDates() {
        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'block';

        document.getElementById('<%= txtDateFrom.ClientID %>').value = document.getElementById('<%= hdnDateFrom.ClientID %>').value;
        document.getElementById('<%= txtDateTo.ClientID %>').value = document.getElementById('<%= hdnDateTo.ClientID %>').value;
        return false;
    }
    function ShowYearDv() {

        var currentdate_date = new Date();
        var month = currentdate_date.getMonth() + 1;
        var currentdate = currentdate_date.getDate();
        var yy = currentdate_date.getYear();
        var year = (yy < 1000) ? yy + 1900 : yy;


        /****** 1 year behind from selected date ************/

        var week_Back_date = new Date();
        var week_month = week_Back_date.getMonth() + 1;
        var week_date = week_Back_date.getDate() - 1;
        var week_yy = week_Back_date.getYear() - 1;
        var week_year = (week_yy < 1000) ? week_yy + 1900 : week_yy;

        /****** 1 year behind from selected date ************/

        var months = new makeArray('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec');

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value = week_date + ", " + months[month] + " " + week_year;
        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value += "-" + currentdate + ", " + months[week_month] + " " + year;

        document.getElementById('<%= txtDateFrom.ClientID %>').value = week_date + " " + months[week_month] + " " + week_year;
        document.getElementById('<%= txtDateTo.ClientID %>').value = currentdate + " " + months[month] + " " + year;



        document.getElementById('<%= hdnDateFrom.ClientID %>').value = document.getElementById('<%= txtDateFrom.ClientID %>').value;
        document.getElementById('<%= hdnDateTo.ClientID %>').value = document.getElementById('<%= txtDateTo.ClientID %>').value;

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').style.display = 'none';
        document.getElementById('<%= txtGraphCalendarNavigation.ClientID %>').style.display = 'block';

        // a//
        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none';
    //    showDivProgress();
    }

    function makeArray() {
        for (i = 0; i < makeArray.arguments.length; i++)
            this[i + 1] = makeArray.arguments[i];
    }
    function CheckForTodaySelection(sender, args) {
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

        document.getElementById('<%= hdnDateFrom.ClientID %>').value = document.getElementById('<%= txtGraphCalendarNavigation.ClientID %>').value;

        return false;
    }



    function CheckForOtherSelection(sender, args) {


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

        document.getElementById('<%= hdnDateFrom.ClientID %>').value = document.getElementById('<%= txtDateFrom.ClientID %>').value;


        return false;
    }
    function FinalizeMultipleDates() {
        // a//
        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none;';

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value = document.getElementById('<%= hdnDateFrom.ClientID %>').value;
        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value += "-" + document.getElementById('<%= hdnDateTo.ClientID %>').value;
        //showDivProgress();
    }
    function CheckForOtherSelectionTwo(sender, args) {

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

        document.getElementById('<%= hdnDateTo.ClientID %>').value = document.getElementById('<%= txtDateTo.ClientID %>').value;


        return false;
    }
</script>

<script type="text/javascript">
			
		//
		//  In my case I want to load them onload, this is how you do it!
		// 
		Event.observe(window, 'load', loadAccordions, false);
	
		//
		//	Set up all accordions
		//
		function loadAccordions() {
			var topAccordion = new accordion('horizontal_container', {
				classNames : {
					toggle : 'horizontal_accordion_toggle',
					toggleActive : 'horizontal_accordion_toggle_active',
					content : 'horizontal_accordion_content'
				},
				defaultSize : {
					width : 525
				},
				direction : 'horizontal'
			});
			
			var bottomAccordion = new accordion('vertical_container');
			
			var nestedVerticalAccordion = new accordion('vertical_nested_container', {
			  classNames : {
					toggle : 'vertical_accordion_toggle',
					toggleActive : 'vertical_accordion_toggle_active',
					content : 'vertical_accordion_content'
				}
			});
			
			// Open first one
			bottomAccordion.activate($$('#vertical_container .accordion_toggle')[0]);
			
			// Open second one
			topAccordion.activate($$('#horizontal_container .horizontal_accordion_toggle')[2]);
		}
		
</script>

<style type="text/css">
    h1 span
    {
        font-family: arial;
        font-size: 18px;
        font-weight: normal;
        margin: 5px 5px 5px 16px;
        text-align: left;
    }
    .box_graph_steps
    {
        background: none repeat scroll 0 0 #DADADA;
        box-shadow: 1px 1px 2px 2px #CCCCCC;
        float: none;
        margin: 15px auto;
        overflow: hidden;
        width: 99%;
    }
    .graph_cal span
    {
        border-bottom: 8px solid #359207;
        float: left;
        font-size: 18px;
        line-height: 42px;
        text-align: center;
        width: 100%;
    }
    .rgt_bar_graph
    {
        background: none repeat scroll 0 0 #EDEDED;
        box-shadow: 1px 1px 2px 2px #CCCCCC;
        float: right !important;
        margin-right: 0.7%;
        width: 24%;
    }
    .graph_bar
    {
        float: none;
        font-family: arial;
        height: 50px;
        margin: 15px auto 0;
        overflow: hidden;
        width: 99.5%;
    }
    .center
    {
        border: medium none;
        border-radius: 4px 4px 4px 4px;
        margin: 15px auto;
        overflow: hidden;
        width: 970px;
    }
    .rgt_bar_graph img
    {
        float: right;
        margin-top: 4px;
    }
    .rgt_bar_graph span
    {
        color: #444444;
        float: left;
        padding: 14px;
    }
    .graph_burned span
    {
        font-size: 18px;
    }
    .graph_weight span
    {
        font-size: 18px;
    }
    .graph_steps span
    {
        font-size: 18px;
    }
    .box_graph_steps h1
    {
        font-size: 29px;
        margin: 12px 0 0;
        padding-top: 13px;
        text-align: center;
    }
    .accordion_toggle
    {
        background: url(../images/imagesNew/close_tab_acor.png) no-repeat scroll right top #A9D06A;
        border-bottom: 1px solid #FFFFFF;
        color: #000000;
        cursor: pointer;
        display: block;
        font-size: 20px;
        font-weight: normal;
        height: 45px;
        line-height: 45px;
        margin: 0;
        outline: medium none;
        padding: 0 10px;
        text-decoration: none;
        float: left;
        width: 97.9%;
        font-family: arial;
    }
    .accordion_toggle_active
    {
        background: url(../images/imagesNew/acor_bar_open.png) no-repeat top right #e0542f;
        color: #ffffff;
        border-bottom: 1px solid #fff;
    }
    .accordion_content
    {
        overflow: hidden;
    }
    .accordion_content h2
    {
        margin: 15px 0 5px 10px;
        color: #0099FF;
    }
    .accordion_content p
    {
        line-height: 150%;
        padding: 5px 10px 15px 10px;
    }
    #container
    {
        margin: 20px auto 0;
        width: 960px;
    }
    #vertical_container
    {
        overflow: hidden;
        width: 99%;
    }
    #vertical_container h2
    {
        font-size: 15px;
        font-family: Arial, Helvetica, sans-serif;
    }
    .seprator_mission
    {
        background: url(                                              "../images/sap_bar_mission.png" ) repeat-x scroll 0 0 transparent;
        float: left;
        height: 7px;
        margin-left: 14px;
        margin-top: 15px !important;
        margin-bottom: 15px !important;
        width: 920px;
    }
    .chartCss
    {
        width: 500px;
    }
    .loader11 img
    {
        float: left;
        margin-left: 40% !important;
        margin-top: 17% !important;
    }
    .overlay
    {
        position: fixed !important;
        z-index: 99 !important;
        top: 0px !important;
        left: 0px !important;
        background-color: #FFFFFF !important;
        width: 100% !important;
        height: 100% !important;
        filter: Alpha(Opacity=70) !important;
        opacity: 0.70 !important;
        -moz-opacity: 0.70 !important;
    }
    .missioninfo
    {
        background-color: #41A317;
        font-family: Verdana;
        font-size: 15px;
        color: white;
        border: 1px solid #D4D4D4;
        margin: 0;
        padding: 5px;
        width: 711px;
        line-height: 20px;
    }
    .headerStyle
    {
        background-color: #FFFFFF;
        color: black;
        float: left;
        font-size: 10pt;
        font-weight: bold;
        margin-bottom: 5px;
        margin-top: 5px;
    }
    .subheaderStyle
    {
        background-color: #F0DF95;
        color: Black;
        font-size: 10pt;
        font-weight: bold;
        height: 23px;
        padding-top: 3px;
    }
    #MissionsGraphsProgress_txtDateFrom
    {
        height: 18px;
        margin-top: 9px;
    }
    #MissionsGraphsProgress_txtDateTo
    {
        height: 18px;
        margin-top: 9px;
    }
    #MissionsGraphsProgress_btnGo
    {
        padding: 1px !important;
        font-size: 15px !important;
    }
    .sel_graph input
    {
        color: #FFFFFF !important;
    }
    .graph_head
    {
        background: none repeat scroll 0 0 rgba(0, 0, 0, 0) !important;
        margin: 0 !important;
        padding: 0 !important;
    }
    .subheaderStyle th
    {
        padding-top: 5px;
        width: 980px;
    }
    .left_bar_graph ul li input
    {
        background: none !important;
        border: 0 !important;
        color: #444;
        cursor: pointer;
    }
    .itemStyle
    {
        background-color: #FFFFEE;
        color: #000000;
        font-size: 9pt;
        line-height: 15px;
    }
    .alternateItemStyle
    {
        background-color: #FFFFFF;
        color: #000000;
        font-size: 8pt;
    }
    .input_mission_from_history
    {
        background: none repeat scroll 0 0 #56BDD2;
        border: 1px solid #359DB2;
        border-radius: 5px 5px 5px 5px;
        box-shadow: 0 2px 1px #CCCCCC;
        color: #FFFFFF;
        float: left;
        font-family: myriad pro;
        font-size: 20px;
        margin-left: 723px;
        margin-top: -108px;
        padding-bottom: 7px;
        padding-top: 6px;
        text-align: center;
        width: 230px;
    }
    .activity_log_from_history
    {
        background: none repeat scroll 0 0 #48CB9B;
        border: 1px solid #23A072;
        border-radius: 5px 5px 5px 5px;
        color: #FFFFFF;
        float: left;
        font-family: myriad pro;
        font-size: 20px;
        margin-left: 723px;
        margin-top: -93px;
        padding-bottom: 12px;
        padding-top: 12px;
        text-align: center;
        width: 230px;
        cursor: pointer;
    }
    .empty
    {
        background-color: #F0DF95;
        background-image: linear-gradient(#FFFFFF, orange 100px);
        font-family: Verdana;
        font-size: 17px;
        color: Red;
        border: 1px solid #D4D4D4;
        margin: 363px;
        padding: 5px;
        width: 711px;
        line-height: 20px;
    }
    #MissionsGraphs_LineChart1__ParentDiv
    {
        border-style: none !important;
        margin-left: -171px;
    }
    div.main_cont_miss div.top_his_miss
    {
        background: none repeat scroll 0 0 transparent;
        border: 0 none;
        padding-left: 20px;
        width: 210px;
    }
    div.main_cont_miss table table
    {
        width: 210px;
    }
    div.main_cont_miss table table tr:first-child div.top_his_miss div.bread_miss span
    {
        color: #53AFB0 !important;
        font-size: 30px !important;
        margin-bottom: 5px !important;
        margin-top: 15px !important;
    }
    div.top_his_miss span
    {
        color: #53AFB0 !important;
        font-family: arial;
        font-size: 15px !important;
        line-height: 5px !important;
        margin: 0;
    }
    div#MissionsGraphsProgress_updatePanelTrackProgress .main_cont_miss
    {
        background: none repeat scroll 0 0 #FFFFFF;
        border: 1px solid #CCCCCC;
        border-radius: 5px 5px 5px 5px;
        float: left;
        margin-top: 1px;
        padding-bottom: 15px;
        padding-right: 5px;
        width: 955px;
        overflow: hidden;
    }
    .main_cont_miss div#MissionsGraphsProgress_dvChart
    {
        width: 715px !important;
    }
    table#MissionsGraphsProgress_tblChartInfo span.mission_miss
    {
        color: #53AFB0 !important;
        font-family: arial;
        font-size: 15px;
        line-height: 5px !important;
        margin: 0;
    }
    #MissionsGraphsProgress_LineChart2 > div#MissionsGraphsProgress_LineChart2__ParentDiv
    {
        border: 1px solid Grey !important;
    }
    #MissionsGraphsProgress_lnchweigth > div#MissionsGraphsProgress_lnchweigth__ParentDiv
    {
        border: 1px solid Grey !important;
    }
    div#MissionsGraphsProgress_updatePanelTrackProgress h2
    {
        background: none repeat scroll 0 0 #eee;
        border-radius: 3px 3px 0 0;
        color: #555555;
        font-family: arial;
        font-size: 16px;
        font-weight: bold;
        padding: 15px 20px 10px;
        width: 931px;
    }
    .cal_Theme1 .ajax__calendar_container
    {
        background-color: #e2e2e2;
        border: solid 1px #cccccc;
    }
    .cal_Theme1 .ajax__calendar_header
    {
        background-color: #ffffff;
        margin-bottom: 4px;
    }
    .cal_Theme1 .ajax__calendar_title, .cal_Theme1 .ajax__calendar_next, .cal_Theme1 .ajax__calendar_prev
    {
        color: #004080;
        padding-top: 3px;
    }
    .cal_Theme1 .ajax__calendar_body
    {
        background-color: #e9e9e9;
        border: solid 1px #cccccc;
    }
    .cal_Theme1 .ajax__calendar_dayname
    {
        text-align: center;
        font-weight: bold;
        margin-bottom: 4px;
        margin-top: 2px;
    }
    .cal_Theme1 .ajax__calendar_day
    {
        text-align: center;
    }
    .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year, .cal_Theme1 .ajax__calendar_active
    {
        color: #004080;
        font-weight: bold;
        background-color: #ffffff;
    }
    .cal_Theme1 .ajax__calendar_today
    {
        font-weight: bold;
    }
    .cal_Theme1 .ajax__calendar_other, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title
    {
        color: #bbbbbb;
    }
</style>
<asp:UpdatePanel ID="updatePanelTrackProgress" UpdateMode="Conditional" ChildrenAsTriggers="true"
    runat="server">
    <ContentTemplate>
        <div class="center">
            <div class="graph_progress">
                <h2 class="graph_head">
                    Progress:</h2>
                <div class="graph_bar">
                    <!--progress bar-->
                    <div class="left_bar_graph">
                        <ul>
                            <li id="libtnToday" runat="server">
                                <asp:Button ID="btnToday" runat="server" Text="Today" OnClientClick="return ShowTodayDv();"
                                    OnClick="btnSelection_Click" Style="cursor: pointer; height: 34px; width: 111px;" />&nbsp;</li>
                            <li id="libtnWeek" runat="server">
                                <asp:Button ID="btnWeek" runat="server" Text="Week" OnClientClick="return ShowWeekDv();"
                                    OnClick="btnSelection_Click" Style="cursor: pointer; height: 34px; width: 111px;" /></li>
                            <li id="libtnMonth" runat="server">
                                <asp:Button ID="btnMonth" runat="server" Text="Month" OnClientClick="return ShowMonthDv()"
                                    OnClick="btnSelection_Click" Style="cursor: pointer; height: 34px; width: 111px;" /></li>
                            <li id="libtnYear" runat="server">
                                <asp:Button ID="btnYear" runat="server" Text="Year" OnClientClick="return ShowYearDv()"
                                    OnClick="btnSelection_Click" Style="cursor: pointer; height: 34px; width: 111px;" /></li>
                            <li id="libtnAll" class="sel_graph" runat="server" onclick="btnSelection_Click">
                                <asp:Button ID="btnAll" runat="server" Text="All" OnClick="btnSelection_Click" Style="cursor: pointer;
                                    height: 34px; width: 111px;" /></li>
                        </ul>
                        <asp:HiddenField ID="hdnDateFrom" runat="server" />
                        <asp:HiddenField ID="hdnDateTo" runat="server" />
                    </div>
                    <%-- <div class="rgt_bar_graph">
                       
                    </div>--%>
                </div>
                <%--<div>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <td width="30%">
                                <table width="100%" align="left" id="tblChartInfo" runat="server">
                                    <tr>
                                        <td>
                                            <div class="top_his_miss">
                                                <div class="bread_miss">
                                                    <span class="mission_miss"><span id="spHeadingMsg" runat="server"></span></span>
                                                    <div class="arrow_miss">
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left">
                                <br />
                            </td>
                        </table>
                    </div>--%>
                <div>
                    <tr>
                        <td>
                            <div id="dvShowMultipleCalendars" runat="server" style="width: 450px; float: left;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellpadding="0" cellspacing="3">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtDateFrom" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDateTo" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top">
                                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClientClick="FinalizeMultipleDates()"
                                                OnClick="btnGo_click" Style="cursor: pointer;" />
                                            <img style="margin-top: 8px;" src="../images/imagesNew/clock.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <ajaxControl:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd MMM yyyy"
                                                TargetControlID="txtDateTo" OnClientDateSelectionChanged="CheckForOtherSelectionTwo"
                                                CssClass="cal_Theme1" PopupButtonID="txtDateTo" />
                                            <ajaxControl:CalendarExtender ID="CalendarE1" runat="server" Format="dd MMM yyyy"
                                                TargetControlID="txtDateFrom" OnClientDateSelectionChanged="CheckForOtherSelection"
                                                CssClass="cal_Theme1" PopupButtonID="txtDateFrom" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 292px;display:none;">
                                 <asp:TextBox ID="txtGraphCalendarNavigation" runat="server" CssClass="act_middle_date"
                                        ReadOnly="true" Style="border: medium none; border-radius: 0 0 0 0; float: left;
                                        height: 31px; width: 187px;" AutoPostBack="true" onclick="return ShowMultipleDates();"></asp:TextBox>
                                    <asp:TextBox ID="txtDefaultWeekelyCalendar" runat="server" CssClass="act_middle_date"
                                        Style="border: medium none; border-radius: 0 0 0 0; float: left; height: 31px;
                                        width: 187px;" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </div>
                <!--cal bar chart-->
                <div class="box_graph_steps">
                    <div class="graph_cal">
                        <h1 id="spCalConsume" runat="server">
                        </h1>
                        <span>Cals Consumed</span></div>
                    <div class="graph_burned">
                        <h1 id="spCalBurned" runat="server">
                        </h1>
                        <span>Cals Burned</span></div>
                    <div class="graph_steps">
                        <h1 id="spStepsTaken" runat="server">
                        </h1>
                        <span>Steps</span></div>
                    <div class="graph_weight">
                        <h1 id="spWeight" runat="server">
                        </h1>
                        <span>Weight</span></div>
                </div>
                <!--acordian chart-->
                <div id="container">
                    <div id="vertical_container">
                        <h1 class="accordion_toggle">
                            <span>Cals Consumed and Burned :</span></h1>
                        <div class="accordion_content">
                            <div style="overflow-x: auto; width: 900px;" id="dvChart" runat="server">
                                <ajaxtoolkit:LineChart ID="LineChart2" runat="server" ChartHeight="250" ChartWidth="450"
                                    ChartType="Basic" CssClass="chartCss" Visible="false" ChartTitleColor="#0E426C"
                                    CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                                </ajaxtoolkit:LineChart>
                                <asp:Image ID="imgEmptyChartImage" runat="server" ImageUrl="~/images/empty_Graph.png" />
                            </div>
                        </div>
                        <h1 class="accordion_toggle">
                            <span>Steps Covered:</span></h1>
                        <div class="accordion_content">
                            <div id="horizontal_container">
                                <div style="overflow-x: auto; width: 715px;" id="Div2" runat="server">
                                    <ajaxtoolkit:LineChart ID="lncSteps" runat="server" Visible="false" ChartHeight="250"
                                        ChartWidth="450" ChartType="Basic" CssClass="chartCss" ChartTitleColor="#0E426C"
                                        CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                                    </ajaxtoolkit:LineChart>
                                    <asp:Image ID="imgEmptyChartForSteps" runat="server" ImageUrl="~/images/empty_StepsGraph.png" />
                                </div>
                            </div>
                        </div>
                        <h1 class="accordion_toggle">
                            <span>Weight:</span></h1>
                        <div class="accordion_content">
                            <div id="vertical_nested_container">
                                <ajaxtoolkit:LineChart ID="lnchweigth" runat="server" Visible="false" ChartHeight="250"
                                    ChartWidth="450" ChartType="Basic" CssClass="chartCss" ChartTitleColor="#0E426C"
                                    CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                                </ajaxtoolkit:LineChart>
                                <asp:Image ID="imgEmptyChartForWeights" runat="server" ImageUrl="~/images/empty_WeightGraph.png" />
                            </div>
                        </div>
                    </div>
                    <!--acordian chart-->

                    <script type="text/javascript">
  
	//
	// You can hide the accordions on page load like this, it maintains accessibility
	//
	// Special thanks go out to Will Shaver @ http://primedigit.com/
	//
	var verticalAccordions = $$('.accordion_toggle');
	verticalAccordions.each(function(accordion) {
		$(accordion.next(0)).setStyle({
		  height: '0px'
		});
	});

	
                    </script>

                    <script type="text/javascript" src="http://www.google-analytics.com/urchin.js"></script>

                    <script type="text/javascript">_uacct = "UA-624845-2";urchinTracker();</script>

                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnToday" />
        <asp:PostBackTrigger ControlID="btnWeek" />
        <asp:PostBackTrigger ControlID="btnMonth" />
        <asp:PostBackTrigger ControlID="btnYear" />
        <asp:PostBackTrigger ControlID="btnAll" />
        <asp:PostBackTrigger ControlID="btnGo" />
    </Triggers>
</asp:UpdatePanel>
<!--acordian chart-->

<script type="text/javascript">
  
	//
	// You can hide the accordions on page load like this, it maintains accessibility
	//
	// Special thanks go out to Will Shaver @ http://primedigit.com/
	//
	var verticalAccordions = $$('.accordion_toggle');
	verticalAccordions.each(function(accordion) {
		$(accordion.next(0)).setStyle({
		  height: '0px'
		});
	});

	
</script>

<script type="text/javascript" src="http://www.google-analytics.com/urchin.js"></script>

<script type="text/javascript">_uacct = "UA-624845-2";urchinTracker();</script>

<%--<script type="text/javascript" language="javascript">
   function clickAll()
   {
        $('#btnAll').click();
   }
   function SetupAccordion(){
        $(".accordion_toggle").accordion();
   }
   $(document).ready(function () {
     SetupAccordion();
     if (typeof Sys.WebForms != 'undefined') {
       Sys.WebForms.PageRequestManager.getInstance().add_endRequest(SetupAccordion);
     }
   });   
</script>--%>
<%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.min.js"></script>--%>
<%--<script type="text/javascript"> 
$(document).ready(function(){
    var prm = Sys.WebForms.PageRequestManager.getInstance();    
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);
   // on page ready first init of your accordion
   $('.accordion_toggle').accordion();
});


function InitializeRequest(sender, args) {      
}

function EndRequest(sender, args) {
     // after the UpdatePanel finish the render from ajax call
     //  and the DOM is ready, re-initilize the accordion
     $('.accordion_toggle').accordion();
}
</script>--%>