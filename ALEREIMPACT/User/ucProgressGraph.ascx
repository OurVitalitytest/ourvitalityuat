<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProgressGraph.ascx.cs"
    Inherits="ALEREIMPACT.User.ucProgressGraph" %>
<%@ Register TagPrefix="ajaxControl" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register TagPrefix="ajaxtoolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<style type="text/css">
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
    .ajax__calendar_next
    {
        background-image: url(       "WebResource.axd?d=ayjpEXrdvWvOW2gTaAtztRBv6fPyXifU7GjqL6F2DmumYG-tHQluWz_kAzIBnRm70&t=634946142760000000" );
        background-position: 50% 50%;
        background-repeat: no-repeat;
        cursor: pointer;
        float: right !important;
        height: 15px;
        width: 15px;
    }
    .ajax__calendar_dayname
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
        margin-top: -19px;
        text-align: center;
        width: 217px;
    }
    input#MissionsGraphsProgress_txtGraphCalendarNavigation
    {
        background: none repeat scroll 0 0 #E9ECEC;
        border: 0 none;
        border-radius: 5px 5px 5px 5px !important;
        box-shadow: 0 0 6px #9F9F9F inset;
        color: #444A4A;
        float: right !important;
        font-size: 12px;
        font-weight: bold;
        height: auto !important;
        margin: 12px 4px;
        padding: 7px !important;
        text-align: center;
        width: 180px !important;
    }
    #MissionsGraphsProgress_tblChartInfo input
    {
        font-size: 11px;
        margin: 8px 0 0 3px;
        padding: 4px 3px;
        outline: none;
    }
    .active_selection_Tab
    {
        background: none repeat scroll 0 0 #4CBFBF;
    }
    .de_active_selection_Tab
    {
        background: none repeat scroll 0 0 #0E7C77;
    }
    #MissionsGraphsProgress_btnAll
    {
        margin-top: -2px !important;
    }
    #MissionsGraphsProgress_btnToday
    {
        margin-left: 37px !important;
    }
    #MissionsGraphsProgress_dvShowMultipleCalendars input#MissionsGraphsProgress_txtDateFrom, #MissionsGraphsProgress_dvShowMultipleCalendars input#MissionsGraphsProgress_txtDateTo
    {
        float: left;
        margin: 8px 0 0;
        width: 150px;
    }
    #MissionsGraphsProgress_dvShowMultipleCalendars td:last-child
    {
        width: 84%;
    }
    #MissionsGraphsProgress_dvShowMultipleCalendars input#MissionsGraphsProgress_btnGo
    {
        float: right;
        margin-right: 11px;
        margin-bottom: 20px;
    }
</style>

<script type="text/javascript" language="javascript">

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

        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none';
        document.getElementById('<%= txtGraphCalendarNavigation.ClientID %>').style.display = 'block';
        showDivProgress();
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

        showDivProgress();
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

        var week_date = currentdate;

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

        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none';
        showDivProgress();
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

        var week_date = null;
        if (week_Back_date.getDate() != 1)
            week_date = week_Back_date.getDate() - 1;
        else
            week_date = week_Back_date.getDate();

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

        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none';
        showDivProgress();
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
        document.getElementById('<%= dvShowMultipleCalendars.ClientID %>').style.display = 'none;';

        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value = document.getElementById('<%= hdnDateFrom.ClientID %>').value;
        document.getElementById('<%= txtDefaultWeekelyCalendar.ClientID %>').value += "-" + document.getElementById('<%= hdnDateTo.ClientID %>').value;
        showDivProgress();
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

<style type="text/css">
    .seprator_mission
    {
        background: url("../images/sap_bar_mission.png") repeat-x scroll 0 0 transparent;
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
    .subheaderStyle th
    {
        padding-top: 5px;
        width: 980px;
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
</style>

<script type="text/javascript">
    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
</script>

<asp:UpdatePanel ID="updatePanelTrackProgress" runat="server">
    <ContentTemplate>
        <h2>
            Progress</h2>
        <div class="main_cont_miss">
            <table width="100%" align="center" id="tblHeader" runat="server" visible="false">
                <tr>
                    <td>
                        <div class="top_his_miss">
                            <div class="bread_miss">
                                <span class="mission_miss">Mission</span><div class="arrow_miss">
                                    <img src="../images/red_arrow.png" /></div>
                                <span class="mission_miss" style="color: #53afb0;">Daily Progress</span>
                            </div>
                            <div class="golist_miss">
                                <span class="go_miss">Go To List All Missions</span>
                                <img style="margin-top: 2px;" src="../images/meni.png" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="100%" align="left" id="tblChartInfo" runat="server">
                <tr>
                    <td width="30%">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnToday" runat="server" Text="Today" OnClientClick="return ShowTodayDv();"
                                        OnClick="btnSelection_Click" Style="cursor: pointer;" />&nbsp;
                                    <asp:Button ID="btnWeek" runat="server" Text="Week" OnClientClick="return ShowWeekDv();"
                                        OnClick="btnSelection_Click" Style="cursor: pointer;" />&nbsp;
                                    <asp:Button ID="btnMonth" runat="server" Text="Month" OnClientClick="return ShowMonthDv()"
                                        OnClick="btnSelection_Click" Style="cursor: pointer;" />&nbsp;
                                    <asp:Button ID="btnYear" runat="server" Text="Year" OnClientClick="return ShowYearDv()"
                                        OnClick="btnSelection_Click" Style="cursor: pointer;" />&nbsp;
                                    <asp:Button ID="btnAll" runat="server" Text="All" OnClick="btnSelection_Click" Style="cursor: pointer;" />
                                    <asp:HiddenField ID="hdnDateFrom" runat="server" />
                                    <asp:HiddenField ID="hdnDateTo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtGraphCalendarNavigation" runat="server" CssClass="act_middle_date"
                                        ReadOnly="true" Style="border: medium none; border-radius: 0 0 0 0; float: left;
                                        height: 31px; width: 187px;" AutoPostBack="true" onclick="return ShowMultipleDates();"></asp:TextBox>
                                    <asp:TextBox ID="txtDefaultWeekelyCalendar" runat="server" CssClass="act_middle_date"
                                        Style="border: medium none; border-radius: 0 0 0 0; float: left; height: 31px;
                                        width: 187px;" AutoPostBack="true"></asp:TextBox>
                                    <div id="dvShowMultipleCalendars" runat="server" style="display: block; width: 400px;">
                                        <table>
                                            <tr>
                                                <td>
                                                    <ajaxControl:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd MMM yyyy"
                                                        TargetControlID="txtDateTo" OnClientDateSelectionChanged="CheckForOtherSelectionTwo"
                                                        CssClass="cal_Theme1" PopupButtonID="txtDateTo" />
                                                    <ajaxControl:CalendarExtender ID="CalendarE1" runat="server" Format="dd MMM yyyy"
                                                        TargetControlID="txtDateFrom" OnClientDateSelectionChanged="CheckForOtherSelection"
                                                        CssClass="cal_Theme1" PopupButtonID="txtDateFrom" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDateFrom" runat="server" ReadOnly="true"></asp:TextBox>
                                                    <br />
                                                    <asp:TextBox ID="txtDateTo" runat="server" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnGo" runat="server" Text="Go" OnClientClick="FinalizeMultipleDates()"
                                                        OnClick="btnGo_click" Style="cursor: pointer;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
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
                            <tr>
                                <td>
                                    <div class="top_his_miss">
                                        <div class="bread_miss">
                                            <span class="mission_miss" style="padding-left: 40px;">Food : </span><span id="spCalConsume"
                                                runat="server"></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="top_his_miss">
                                        <div class="bread_miss">
                                            <span class="mission_miss" style="padding-left: 40px;">Burned : </span><span id="spCalBurned"
                                                runat="server"></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="top_his_miss">
                                        <div class="bread_miss">
                                            <span class="mission_miss" style="padding-left: 40px;">Activity : </span><span id="spStepsTaken"
                                                runat="server"></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="top_his_miss">
                                        <div class="bread_miss">
                                            <span class="mission_miss" style="padding-left: 40px;">Weight : </span><span id="spWeight"
                                                runat="server"></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left">
                        <br />
                        <div style="overflow-x: auto; width: 900px;" id="dvChart" runat="server">
                            <ajaxtoolkit:LineChart ID="LineChart2" runat="server" ChartHeight="250" ChartWidth="450"
                                ChartType="Basic" CssClass="chartCss" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
                                ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                            </ajaxtoolkit:LineChart>
                            <asp:Image ID="imgEmptyChartImage" runat="server" ImageUrl="~/images/empty_Graph.png" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="mission_miss" style="padding-left: 60px;">Steps Current Stats</span>
                    </td>
                    <td>
                        <div style="overflow-x: auto; width: 715px;" id="Div2" runat="server">
                            <ajaxtoolkit:LineChart ID="lncSteps" runat="server" ChartHeight="250" ChartWidth="450"
                                ChartType="Basic" CssClass="chartCss" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
                                ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                            </ajaxtoolkit:LineChart>
                            <asp:Image ID="imgEmptyChartForSteps" runat="server" ImageUrl="~/images/empty_StepsGraph.png" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="mission_miss" style="padding-left: 60px;">Weight's Current Stats</span>
                    </td>
                    <td>
                        <div style="overflow-x: auto; width: 715px;" id="Div1" runat="server">
                            <ajaxtoolkit:LineChart ID="lnchweigth" runat="server" ChartHeight="250" ChartWidth="450"
                                ChartType="Basic" CssClass="chartCss" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
                                ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                            </ajaxtoolkit:LineChart>
                            <asp:Image ID="imgEmptyChartForWeights" runat="server" ImageUrl="~/images/empty_WeightGraph.png" />
                        </div>
                    </td>
                </tr>
            </table>
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
    </ContentTemplate>
</asp:UpdatePanel>
