<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMission.ascx.cs" Inherits="ALEREIMPACT.User.ucMission" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<link rel="stylesheet" href="../CSS/style.css" type="text/css" />
<style type="text/css">
    .accept_reject
    {
        width: 140px;
    }
    .groupIndividualCssClass
    {
        color: Snow;
        background-color: DarkOrchid;
        font-family: Comic Sans MS;
        font-size: large;
        font-style: italic;
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
    .fldset
    {
        background-color: #FCFCFC;
        border: 1px solid #A8A8A8;
        display: inline;
        margin-left: 34px;
        width: 482px;
    }
    .fldsetlegend
    {
        background-color: #FFFFFF;
        color: #0E7C77;
        font-size: 18px;
        font-variant: small-caps;
        font-weight: bold;
        margin: 2px 8px 8px 7px;
        line-height: 16px;
    }
</style>

<script language="javascript" type="text/javascript">
    function FocusStep1() {
        document.getElementById('misCreate_txtMissionName').focus();
        document.getElementById('misCreate_hdnProfileValue').value = 'theme';
    }
    function CheckProposedDates_radLessAggressive() {

        document.getElementById('misCreate_dvLessAggressiveData').style.display = 'block';
        document.getElementById('misCreate_dvAverageData').style.display = 'none';
        document.getElementById('misCreate_dvMoreaggressive').style.display = 'none';

        document.getElementById('misCreate_radAverage').checked = false;
        document.getElementById('misCreate_radMoreAggressive').checked = false;
        document.getElementById('misCreate_radLessAggresive').checked = true;

    }
    function CheckProposedDates_radMoreAggressive() {

        document.getElementById('misCreate_dvLessAggressiveData').style.display = 'none';
        document.getElementById('misCreate_dvAverageData').style.display = 'none';
        document.getElementById('misCreate_dvMoreaggressive').style.display = 'block';

        document.getElementById('misCreate_radLessAggresive').checked = false;
        document.getElementById('misCreate_radMoreAggressive').checked = true;
        document.getElementById('misCreate_radAverage').checked = false;

    }
    function CheckProposedDates_radAverage() {

        document.getElementById('misCreate_dvLessAggressiveData').style.display = 'none';
        document.getElementById('misCreate_dvAverageData').style.display = 'block';
        document.getElementById('misCreate_dvMoreaggressive').style.display = 'none';

        document.getElementById('misCreate_radAverage').checked = true;
        document.getElementById('misCreate_radMoreAggressive').checked = false;
        document.getElementById('misCreate_radLessAggresive').checked = false;
    }

    function CheckOnProposedDates() {
        CheckOnFinalize();

        if (document.getElementById('misCreate_radLessAggresive').checked || document.getElementById('misCreate_radAverage').checked || document.getElementById('misCreate_radMoreAggressive').checked) {
            document.getElementById('misCreate_misCreate_btnFinalizeMission').style.display = 'none';
            document.getElementById('misCreate_misCreate_btnRegisterWithProposedDate').style.display = 'none';
            return true;
        }
        else {
            alert('Please select any of the three recommended dates !');
            return false;
        }
    }
    function missionNameInputCheck(e) {
        var k;
        document.all ? k = e.keyCode : k = e.which;
        return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
    }


    function HideStepSix() {
        document.getElementById('misCreate_tblInitialMessage').style.display = 'none';
        document.getElementById('misCreate_pnlMissionCompletionDate').style.display = 'none';
        document.getElementById('misCreate_btnFinalizeMission').style.display = 'none';

        document.getElementById('<%= hdnProposedDate.ClientID %>').value = '';
        if (document.getElementById('misCreate_drpPreferenceOptions').value == '0') {
            ShowFinalizeMission();
        }

    }
    function ShowFinalizeMission() {

        document.getElementById('<%= pnlMissionCompletionDate.ClientID %>').style.display = 'none';
        document.getElementById('<%= pnlCaloriesNotFeasible.ClientID %>').style.display = 'none';
        document.getElementById('<%= btnFin2.ClientID %>').style.display = 'none';
        document.getElementById('<%= hdnProposedDate.ClientID %>').value = '';
        document.getElementById('<%= txtDateOfMissionCompletion.ClientID %>').value = '';
        if (document.getElementById('misCreate_drpSelectMissionType').value == '1') {

            if (document.getElementById('misCreate_txtWeightToLose').value == '' || document.getElementById('misCreate_drpWeightToLooseOptions').value == '0') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Both Fields are Required';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'none;';
                return false;

            }
            if (document.getElementById('misCreate_drpPreferenceOptions').value == '0') {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = 'Required';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'none;';
                return false;
            }
            else {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = '';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'block';
                return false;
            }
        }
        else {
            if (document.getElementById('misCreate_txtWeightToLose').value == '') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Required';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'none;';
                return false;
            }
            else {
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'block';
                return false;
            }
        }


        if (document.getElementById('misCreate_drpPreferenceOptions').value == '0') {
            document.getElementById('misCreate_btnFinalizeMission').style.display = 'none';
            return false;
        }
    }


    function CheckOnFinalize() {

        if (document.getElementById('misCreate_txtMissionName').value.replace(/\s/g, "").length == '0') {
            document.getElementById('misCreate_spMissionNameRequiredMsg').textContent = 'Required';
            return false;
        }
        if (document.getElementById('misCreate_drpSelectMissionType').value == '1') {

            if (document.getElementById('misCreate_txtWeightToLose').value == '' || document.getElementById('misCreate_drpWeightToLooseOptions').value == '0') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Both Fields are Required';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'none;';
                return false;

            }
            if (document.getElementById('misCreate_drpPreferenceOptions').value == '0') {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = 'Required';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'none;';
                return false;
            }
            else {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = '';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'block';

            }
        }
        else {
            if (document.getElementById('misCreate_txtWeightToLose').value == '') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Required';
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'none;';
                return false;
            }
            else {
                document.getElementById('misCreate_btnFinalizeMission').style.display = 'block';
            }
        }
        document.getElementById('<%= pnlMissionCompletionDate.ClientID %>').style.display = 'none';
        //        document.getElementById('<%= hdnProposedDate.ClientID %>').value = '';


    }





    function CheckForStepFive() {

        if (document.getElementById('misCreate_txtMissionName').value.replace(/\s/g, "") == '') {
            document.getElementById('misCreate_spMissionNameRequiredMsg').textContent = 'Required';
            return false;
        }
        if (document.getElementById('misCreate_drpSelectMissionType').value == '1') {

            if (document.getElementById('misCreate_txtWeightToLose').value == '' || document.getElementById('misCreate_drpWeightToLooseOptions').value == '0') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Both Fields are Required';
                document.getElementById('misCreate_spInvalidInput').textContent = '';
                return false;
            }
            if (document.getElementById('misCreate_txtWeightToLose').value == '0') {
                document.getElementById('misCreate_spInvalidInput').textContent = 'Must be greater than 0';
                document.getElementById('misCreate_spweightToLoseMessage').textContent = '';
                return false;
            }

            if (document.getElementById('misCreate_drpPreferenceOptions').value == '0') {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = 'Required';
                return false;
            }
            else {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = '';
            }
        }
        else {
            if (document.getElementById('misCreate_txtWeightToLose').value == '') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Required';
                return false;
            }
            if (document.getElementById('misCreate_txtWeightToLose').value == '0') {
                document.getElementById('misCreate_spInvalidInput').textContent = 'Must be greater than 0';
                document.getElementById('misCreate_spweightToLoseMessage').textContent = '';
                return false;
            }
        }
    }
    function changesOnMissionTypeSelection() {

        if (document.getElementById('misCreate_drpSelectMissionType').value == '2') {
            document.getElementById('misCreate_btnFinalizeMission').style.display = 'none';
            document.getElementById('misCreate_txtWeightToLose').setAttribute('maxlength', 6);
            document.getElementById('misCreate_spWeightSteps').textContent = 'Steps needed to take';
            document.getElementById('misCreate_txtWeightToLose').value = '';
            document.getElementById('misCreate_drpWeightToLooseOptions').style.display = 'none';
            document.getElementById('misCreate_drpWeightToLooseOptions').value = '0';
            document.getElementById('misCreate_tblStepFive').style.display = 'none';
            document.getElementById('misCreate_pnlMissionCompletionDate').style.display = 'none';

            if (document.getElementById('misCreate_tblStepFour').style.display == 'block') {
                document.getElementById('misCreate_btnCalculate').style.display = 'block';
            }
            else {
                document.getElementById('misCreate_btnCalculate').style.display = 'none';
            }


            document.getElementById('misCreate_tblInitialMessage').style.display = 'none';
            document.getElementById('misCreate_btnShowStepFive').style.display = 'none';
        }
        else {

            document.getElementById('misCreate_btnCalculate').style.display = 'none';
            document.getElementById('misCreate_spWeightSteps').textContent = 'Weight(lbs or kgs) \nneeded to lose';
            document.getElementById('misCreate_drpWeightToLooseOptions').style.display = 'block';
            document.getElementById('misCreate_btnShowStepFive').style.display = 'block';
            document.getElementById('misCreate_txtWeightToLose').setAttribute('maxlength', 3);


            if (document.getElementById('misCreate_tblStepFour').style.display == 'block') {
                document.getElementById('misCreate_btnShowStepFive').style.display = 'block';
            }
            else {
                document.getElementById('misCreate_btnShowStepFive').style.display = 'none';
            }
        }

        if (document.getElementById('misCreate_tblStepFive').style.display == 'block') {
            document.getElementById('misCreate_btnCalculate').style.display = 'block';
        }
    }


    function ClosePeriodicThemeArea() {

        document.getElementById('misCreate_dvPeriodic').style.display = 'none';
        document.getElementById('misCreate_drpSelectMissionTheme').value = 1;
        return false;
    }
    function showThemeSelections() {
        if (document.getElementById('misCreate_drpSelectMissionTheme').value == 2) {

            document.getElementById('misCreate_dvPeriodic').style.display = 'block';
            document.getElementById('misCreate_btnCalculate').innerHTML = "Calculate";
        }
        else {
            document.getElementById('misCreate_dvPeriodic').style.display = 'none';
        }

    }

    function OpenStepTwo() {

        if (document.getElementById('misCreate_txtMissionName').value.replace(/\s/g, "") != '') {
            var showForStepTwo = document.getElementById('misCreate_hdnProfileValue').value;


            if (showForStepTwo == 'features') {
                document.getElementById('misCreate_pnlFeatures').style.display = 'block';

                document.getElementById('misCreate_hdnProfileValue').value = '';
            }
            else if (showForStepTwo == 'theme') {

                document.getElementById('misCreate_tblStepTwo').style.display = 'block';
                document.getElementById('misCreate_btnShowStepThree').style.display = 'block';

                document.getElementById('misCreate_tr_steptwo').style.display = 'block';
                document.getElementById('misCreate_spMissionNameRequiredMsg').textContent = '';
                document.getElementById('misCreate_hdnProfileValue').value = 'theme';
            }

            return false;
        }
        else {
            document.getElementById('misCreate_spMissionNameRequiredMsg').textContent = 'Required';
            return false;
        }
    }
    function OpenStepThree() {
        document.getElementById('misCreate_tblStepThree').style.display = 'block';
        document.getElementById('misCreate_btnShowStepFour').style.display = 'block';

        if (document.getElementById('misCreate_drpSelectMissionType').value == '1') {
            document.getElementById('misCreate_txtWeightToLose').maxLength = 3;

        }
        else if (document.getElementById('misCreate_drpSelectMissionType').value == '2') {
            document.getElementById('misCreate_txtWeightToLose').maxLength = 6;

        }

        return false;
    }
    function OpenStepFive() {
        if (document.getElementById('misCreate_txtWeightToLose').value != '0') {
            if (document.getElementById('misCreate_drpSelectMissionType').value == '1') {
                if (document.getElementById('misCreate_txtWeightToLose').value != '' && document.getElementById('misCreate_drpWeightToLooseOptions').value != '0') {
                    document.getElementById('misCreate_tblStepFive').style.display = 'block';
                    document.getElementById('misCreate_btnCalculate').style.display = 'block';

                    document.getElementById('misCreate_spweightToLoseMessage').textContent = '';

                }
                else {
                    document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Both Fields are Required';
                    document.getElementById('misCreate_spInvalidInput').textContent = '';
                }
            }
            else {
                document.getElementById('misCreate_btnCalculate').style.display = 'block';
                document.getElementById('misCreate_spInvalidInput').textContent = '';
                document.getElementById('misCreate_spweightToLoseMessage').textContent = '';
            }
            return false;
        }
        else {
            document.getElementById('misCreate_spweightToLoseMessage').textContent = '';
            document.getElementById('misCreate_spInvalidInput').textContent = 'Must be greater than 0';
            return false;
        }
    }

    function OpenStepFour() {

        document.getElementById('misCreate_tblStepFour').style.display = 'block';


        if (document.getElementById('misCreate_drpSelectMissionType').value == '1') {

            document.getElementById('misCreate_btnShowStepFive').style.display = 'block';

            document.getElementById('misCreate_spWeightSteps').InnerHTML = "Weight needed to lose";
            document.getElementById('misCreate_drpWeightToLooseOptions').style.display = 'block';


            if (document.getElementById('misCreate_tblStepFive').style.display == 'block'
            ) {
                document.getElementById('misCreate_btnCalculate').style.display = 'block';
            } else {
                document.getElementById('misCreate_btnCalculate').style.display = 'none';
            }
        }
        else {
            document.getElementById('misCreate_btnShowStepFive').style.display = 'none';
            document.getElementById('misCreate_btnCalculate').style.display = 'block';
        }
        return false;

    }


    function getCheckedRadio() {

        if (document.getElementById('misCreate_radPeriodicOptions_0').checked) {
            document.getElementById("misCreate_spPeriodicMessage").innerHTML = 'Number of week(s) selected are : ';
        }
        else if (document.getElementById('misCreate_radPeriodicOptions_1').checked) {
            document.getElementById("misCreate_spPeriodicMessage").innerHTML = 'Number of month(s) selected are : ';
        }
    }

    function closeCalendarToChange() {
        document.getElementById('<%= pnlMissionCompletionDate.ClientID %>').style.display = 'none';
        document.getElementById('<%= hdnProposedDate.ClientID %>').value = '';
        return false;
    }
    function showCalendarToChange() {
        document.getElementById('<%= pnlMissionCompletionDate.ClientID %>').style.display = 'block';
        document.getElementById('<%= pnlCaloriesNotFeasible.ClientID %>').style.display = 'none';
        document.getElementById('<%= btnFin2.ClientID %>').style.display = 'none';
        document.getElementById('<%= hdnProposedDate.ClientID %>').value = '';
        document.getElementById('misCreate_btnFinalizeMission').style.display = 'none';
        document.getElementById('misCreate_spUserSelectedDate').textContent = '';
        return false;
    }
    function SelectCustomDateMsg() {

        if (document.getElementById('misCreate_txtMissionName').value.replace(/\s/g, "").length == '0') {
            document.getElementById('misCreate_spMissionNameRequiredMsg').textContent = 'Required';
            return false;
        }



        if (document.getElementById('<%= pnlMissionCompletionDate.ClientID %>').style.display = 'block') {
            if (document.getElementById('<%= hdnProposedDate.ClientID %>').value == '') {
                document.getElementById('misCreate_spUserSelectedDate').textContent = 'Click to select a date.';
                return false;
            }
        }

        if (document.getElementById('misCreate_drpSelectMissionType').value == '1') {

            if (document.getElementById('misCreate_txtWeightToLose').value == '' || document.getElementById('misCreate_drpWeightToLooseOptions').value == '0') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Both Fields are Required';
                return false;
            }
            if (document.getElementById('misCreate_drpPreferenceOptions').value == '0') {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = 'Required';
                return false;
            }
            else {
                document.getElementById('misCreate_spPrefernceOptionsMsg').textContent = '';
            }
        }
        else {
            if (document.getElementById('misCreate_txtWeightToLose').value == '') {
                document.getElementById('misCreate_spweightToLoseMessage').textContent = 'Required';
                return false;
            }
        }
    }

    function SelectHeight() {
        if (document.getElementById('misCreate_drpUserHeightOptions').value == '2') {
            document.getElementById('<%= Panletxt_inches.ClientID %>').style.display = 'none';
            document.getElementById('<%= ddl_inches.ClientID %>').style.display = 'none';

        }
        else if (document.getElementById('misCreate_drpUserHeightOptions').value == '3') {
            document.getElementById('<%= Panletxt_inches.ClientID %>').style.display = 'block';
            document.getElementById('<%= ddl_inches.ClientID %>').style.display = 'block';
        }
    }
    
</script>

<script type="text/javascript">
    function checkDate(sender, args) {
        sender._textbox.set_Value(sender._selectedDate.format(sender._format))
    }       
</script>

<script type="text/javascript">
    function checkDate(sender, args) {
        var toDate = new Date();
        toDate.setMinutes(0);
        toDate.setSeconds(0);
        toDate.setHours(0);
        toDate.setMilliseconds(0);
        var date = new Date();
        var dateyearselected = sender._selectedDate.getFullYear();
        var dateyeartoday = date.getFullYear();
        var dateyeartoday18 = dateyeartoday - 16;
        var datemonth = date.getDate();
        var dateday = date.getMonth();
        var dateday1 = dateday + 1;
        var y = dateyeartoday18 + "/" + dateday1 + "/" + datemonth;
        var scheduleDate = new Date(y);
        if (sender._selectedDate < toDate) {

            alert("Today's / Past date cannot be selected!");
            document.getElementById('<%= txtDateOfMissionCompletion.ClientID %>').value = "";
            document.getElementById('<%= hdnProposedDate.ClientID %>').value = "";
        }
        else if (sender._selectedDate < scheduleDate) {



            alert("cannot select this date");
            document.getElementById('<%= txtDateOfMissionCompletion.ClientID %>').value = "";
        }
        else {


            document.getElementById('<%= hdnProposedDate.ClientID %>').value = document.getElementById('<%= txtDateOfMissionCompletion.ClientID %>').value;
        }

    }
</script>

<div style="margin-top: 2px;">
    <asp:HiddenField ID="hdnProfileValue" runat="server" />
    <div class="top_his_miss" style="border-bottom: 1px solid #CCCCCC; color: #666666;
        height: 6px; margin: -2px auto; padding-bottom: 20px; padding-left: 11px; padding-top: 14px;
        width: 960px;">
        <span style="margin-top: 6px;">Missions
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" /></span>
        Create Mission <span style="float: right; margin-top: 6px; margin-right: 13px;">Go To
            <asp:LinkButton Text="List All Missions" runat="server" ID="lnkListMission" OnClick="lnkListMission_Click"></asp:LinkButton>
        </span>
    </div>
    <asp:UpdatePanel ID="updatePanelMission" runat="server">
        <ContentTemplate>
            <table>
                <%--Step - 1 --%>
                <tr>
                    <td>
                        <span style="border-bottom: 1px solid; color: #0b7974; float: left; font-family: myriad pro;
                            font-size: 24px; font-weight: normal; margin-top: 15px; margin-left: 33px; padding-bottom: 5px;
                            width: auto;">Step-1</span>
                    </td>
                </tr>
                <tr>
                    <td class="weight_loose" align="left" style="background: none repeat scroll 0 0 #EEEEEE;
                        border: 1px solid #CCCCCC; border-radius: 5px 5px 5px 5px; float: left; margin-bottom: 16px;
                        margin-left: 35px; margin-top: 5px; padding: 4px 10px 2px 9px; width: 485px;">
                        Name my Mission : <span id="spMissionNameRequiredMsg" runat="server" style="color: Red;">
                        </span>
                        <asp:TextBox ID="txtMissionName" runat="server" onkeypress="return missionNameInputCheck(event)"
                            MaxLength="40"></asp:TextBox>
                    </td>
                    <td class="submit_class" style="float: left; margin-left: 525px; margin-top: -61px;">
                        <asp:Button ID="btnShowStepTwo" runat="server" Text="OK, onto Step-2" OnClientClick="return OpenStepTwo()" />
                    </td>
                </tr>
                <%--Step - 2 Details or Select Theme --%>
                <tr id="tr_steptwo" style="display: none;" runat="server">
                    <td valign="top">
                        <span style="border-bottom: 1px solid; color: #0b7974; float: left; font-family: myriad pro;
                            font-size: 24px; font-weight: normal; margin-top: 0px; margin-left: 33px; padding-bottom: 5px;
                            width: auto;">Step -2</span>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Panel ID="pnlFeatures" runat="server" Style="display: none;">
                            <fieldset class="fldset">
                                <legend class="fldsetlegend">To help us better manage your mission, we'll need a bit
                                    more information about you</legend>
                                <table height="300px" width="100%" style="margin-top: 25px;">
                                    <tr>
                                        <td align="right">
                                            <span>Date of Birth :</span>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="drpYear" runat="server" Style="float: left; margin-left: 39px;
                                                width: 100px;">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqdAgeYear" runat="server" ErrorMessage="Required"
                                                Style="color: Red; display: inline; float: left; font-size: 12px; margin-left: 10px;
                                                margin-top: 5px;" InitialValue="- Select -" ValidationGroup="MissionCreate" Display="Dynamic"
                                                ControlToValidate="drpYear"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <span>Height :</span>
                                        </td>
                                        <td align="left" valign="middle">
                                            <asp:DropDownList ID="drpUserHeightOptions" runat="server" Style="float: left; margin-left: 39px;
                                                width: 100px;" onclick="return SelectHeight()">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="cms" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Feet" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqdHeightFeature" runat="server" ErrorMessage="Required"
                                                Style="color: Red; display: inline; float: left; font-size: 12px; margin-top: 5px;
                                                margin-left: 11px;" ValidationGroup="MissionCreate" Display="Dynamic" ControlToValidate="txtHeight"></asp:RequiredFieldValidator>
                                            <asp:FilteredTextBoxExtender ID="fltrFeatureHeight" runat="server" FilterType="Custom"
                                                ValidChars="0123456789." TargetControlID="txtHeight">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:TextBox ID="txtHeight" runat="server" MaxLength="5" Width="40px" Style="float: left;
                                                margin-left: 10px; margin-right: 10px; width: 30px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqdheightOptions" runat="server" ErrorMessage="Required"
                                                Style="color: Red; display: inline; float: left; font-size: 12px; margin-left: 3px;
                                                margin-top: 4px;" InitialValue="0" ValidationGroup="MissionCreate" Display="Dynamic"
                                                ControlToValidate="drpUserHeightOptions"></asp:RequiredFieldValidator>
                                            <asp:Panel ID="ddl_inches" runat="server" Style="float: left; display: none;">
                                                <asp:DropDownList ID="ddlH_UnitInches" runat="server" Style="float: left;">
                                                    <asp:ListItem Text="inches" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </asp:Panel>
                                            <asp:Panel ID="Panletxt_inches" runat="server" Style="display: none;">
                                                <asp:TextBox ID="txtheightInches" runat="server" Text="0" Style="float: left; margin-left: 12px;
                                                    width: 34px;" MaxLength="3"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                                    ValidChars="0123456789." TargetControlID="txtheightInches" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <span>Weight :</span>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="drpUserWeightOptions" runat="server" Width="90px" Style="float: left;
                                                margin-left: 39px; width: 100px;">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                                Style="color: Red; display: inline; float: left; font-size: 12px; margin-top: 5px;
                                                margin-left: 11px;" ValidationGroup="MissionCreate" Display="Dynamic" ControlToValidate="txtWeight"></asp:RequiredFieldValidator>
                                            <asp:FilteredTextBoxExtender ID="fltrFeatureWeight" runat="server" FilterType="Numbers"
                                                TargetControlID="txtWeight">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:TextBox ID="txtWeight" runat="server" MaxLength="3" Width="35px" Style="float: left;
                                                margin-left: 11px; width: 30px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqdrpUserWeightOptions" runat="server" ErrorMessage="Required"
                                                Style="color: Red; display: inline; float: left; font-size: 12px; margin-left: 11px;
                                                margin-top: 4px;" InitialValue="- Select -" ValidationGroup="MissionCreate" Display="Dynamic"
                                                ControlToValidate="drpUserWeightOptions"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <span>Gender :</span>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="drpGender" runat="server" Style="float: left; margin-left: 39px;
                                                width: 100px;">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqddrpGender" runat="server" ErrorMessage="Required"
                                                Style="color: Red; display: inline; float: left; font-size: 12px; margin-left: 13px;
                                                margin-top: 4px;" InitialValue="0" ValidationGroup="MissionCreate" Display="Dynamic"
                                                ControlToValidate="drpGender"></asp:RequiredFieldValidator>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnSubmitDetails" runat="server" Text="Submit" OnClick="btnSubmitDetails_Click"
                                                ValidationGroup="MissionCreate" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tblStepTwo" style="display: block;" runat="server">
                            <tr>
                                <td class="weight_loose" align="left" style="background: none repeat scroll 0 0 #EEEEEE;
                                    border: 1px solid #CCCCCC; border-radius: 5px 5px 5px 5px; float: left; margin-bottom: 16px;
                                    margin-left: 35px; margin-top: 5px; padding: 4px 10px 2px 9px; width: 485px;">
                                    Mission Type :
                                    <asp:DropDownList ID="drpSelectMissionType" runat="server" onclick="return changesOnMissionTypeSelection()">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:DropDownList ID="drpGroupIndividual" runat="server">
                                        <asp:ListItem Text="Group" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Individual" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:DropDownList ID="drpPublicPrivate" runat="server">
                                        <asp:ListItem Text="Public" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Private" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="submit_class" style="float: left; margin-left: -443px; margin-top: -4px;
                        position: absolute;">
                        <asp:Button ID="btnShowStepThree" runat="server" Text="OK, onto Step-3" OnClientClick="return OpenStepThree()"
                            Style="display: none;" />
                    </td>
                </tr>
                <%--Step - 3 --%>
                <tr>
                    <td>
                        <table id="tblStepThree" style="display: none;" runat="server">
                            <tr>
                                <td>
                                    <span style="border-bottom: 1px solid; color: #0b7974; float: left; font-family: myriad pro;
                                        font-size: 24px; font-weight: normal; margin-top: 15px; margin-left: 33px; padding-bottom: 5px;
                                        width: auto;">Step -3</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="weight_loose" align="left" style="background: none repeat scroll 0 0 #EEEEEE;
                                    border: 1px solid #CCCCCC; border-radius: 5px 5px 5px 5px; float: left; margin-bottom: 16px;
                                    margin-left: 35px; margin-top: 5px; padding: 4px 10px 2px 9px; width: 485px;">
                                    Is this a one-time mission or one you’d
                                    <br />
                                    <br />
                                    like to accomplish on a regular basis? :
                                    <asp:DropDownList ID="drpSelectMissionTheme" runat="server" Style="margin-top: -16px !important;"
                                        onclick="return showThemeSelections();">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="submit_class" style="float: left; margin-left: -440px; margin-top: 32px;
                        position: absolute;">
                        <asp:Button ID="btnShowStepFour" runat="server" Text="OK, onto Step-4" OnClientClick="return OpenStepFour()"
                            Style="display: none;" />
                    </td>
                </tr>
                <%-- Choose periodic / weekely --%>
                <tr>
                    <td>
                        <div style="-moz-border-bottom-colors: none; -moz-border-image: none; -moz-border-left-colors: none;
                            -moz-border-right-colors: none; -moz-border-top-colors: none; background: none repeat scroll 0 0 #EEEEEE;
                            border-color: navy #CCCCCC #CCCCCC; border-radius: 0 0 5px 5px; border-right: 1px solid #CCCCCC;
                            border-style: none solid solid; border-width: medium 1px 1px; float: left; height: 39px;
                            margin-left: 39px; margin-top: -21px; padding-right: 9px; padding-top: 28px;
                            display: none;" id="dvPeriodic" runat="server">
                            <div style="margin-right: 9px; margin-top: -10px; padding-right: 1px;">
                                <asp:RadioButtonList ID="radPeriodicOptions" runat="server" onclick="javascript:getCheckedRadio();"
                                    Style="padding-right: 5px;">
                                    <asp:ListItem Text="Weekely" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Monthly" Value="2" style="margin-top: 10px;"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <span style="float: left;" id="spPeriodicMessage" runat="server">Number of week(s) selected
                                are : </span>
                            <div style="margin-top: -4px;">
                                <asp:DropDownList ID="drpPeriodicTime" runat="server">
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                    <asp:ListItem Text="6"></asp:ListItem>
                                    <asp:ListItem Text="7"></asp:ListItem>
                                    <asp:ListItem Text="8"></asp:ListItem>
                                    <asp:ListItem Text="9"></asp:ListItem>
                                    <asp:ListItem Text="10"></asp:ListItem>
                                    <asp:ListItem Text="11"></asp:ListItem>
                                    <asp:ListItem Text="12"></asp:ListItem>
                                    <asp:ListItem Text="13"></asp:ListItem>
                                    <asp:ListItem Text="14"></asp:ListItem>
                                    <asp:ListItem Text="15"></asp:ListItem>
                                    <asp:ListItem Text="16"></asp:ListItem>
                                    <asp:ListItem Text="17"></asp:ListItem>
                                    <asp:ListItem Text="18"></asp:ListItem>
                                    <asp:ListItem Text="19"></asp:ListItem>
                                    <asp:ListItem Text="20"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div style="margin-left: -6px; margin-top: -21px;">
                                <asp:Button ID="btnClosePeriodic" runat="server" Text="Close" OnClientClick="return ClosePeriodicThemeArea()"
                                    Style="background: none repeat scroll 0 0 #0E7C77; border: medium none navy;
                                    border-radius: 3px 3px 3px 3px; color: #FFFFFF; float: left; font-family: arial;
                                    font-size: 11px; margin-left: 29px; margin-right: 5px; margin-top: 19px; padding: 0;" />
                            </div>
                        </div>
                    </td>
                </tr>
                <%--Step - 4 --%>
                <tr>
                    <td>
                        <table id="tblStepFour" style="display: none;" runat="server">
                            <tr>
                                <td>
                                    <span style="border-bottom: 1px solid; color: #0b7974; float: left; font-family: myriad pro;
                                        font-size: 24px; font-weight: normal; margin-top: 15px; margin-left: 33px; padding-bottom: 5px;
                                        width: auto;">Step -4</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="weight_loose" style="background: none repeat scroll 0 0 #EEEEEE; border: 1px solid #CCCCCC;
                                    border-radius: 5px 5px 5px 5px; float: left; margin-bottom: 16px; margin-left: 35px;
                                    margin-top: 5px; padding: 4px 10px 2px 9px; width: 485px;">
                                    <span id="spWeightSteps" runat="server" style="width: 200px;">Weight(lbs or kgs) needed
                                        <br />
                                        <br />
                                        to lose</span> </span> <span id="spweightToLoseMessage" runat="server" style="color: Red;">
                                        </span><span id="spInvalidInput" runat="server" style="color: Red;"></span>
                                    <asp:TextBox ID="txtWeightToLose" runat="server" Width="35px" Style="clear: both;"></asp:TextBox>
                                    <asp:DropDownList ID="drpWeightToLooseOptions" runat="server" Style="clear: both !important;
                                        float: right !important; margin-top: 20px;">
                                        <asp:ListItem Text="- Select -" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Kilograms (kgs)" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Pounds (lbs)" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:FilteredTextBoxExtender ID="fltrWeight" runat="server" FilterType="Numbers"
                                        TargetControlID="txtWeightToLose">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="submit_class" style="float: right; margin-left: -442px; margin-top: 31px;
                        position: absolute;">
                        <asp:Button ID="btnShowStepFive" runat="server" Text="OK, onto Step-5" OnClientClick="return OpenStepFive()"
                            Style="display: none;" />
                    </td>
                </tr>
                <%--Step - 5 --%>
                <tr>
                    <td>
                        <table id="tblStepFive" style="display: none;" runat="server">
                            <tr>
                                <td>
                                    <span style="border-bottom: 1px solid; color: #0b7974; float: left; font-family: myriad pro;
                                        font-size: 24px; font-weight: normal; margin-top: 0px; margin-left: 33px; padding-bottom: 5px;
                                        width: auto;">Step -5</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="weight_loose" style="background: none repeat scroll 0 0 #EEEEEE; border: 1px solid #CCCCCC;
                                    border-radius: 5px 5px 5px 5px; float: left; margin-bottom: 16px; margin-left: 35px;
                                    margin-top: 5px; padding: 4px 10px 2px 9px; width: 485px;">
                                    Great. Thanks. What’s easier for you:
                                    <br />
                                    <span id="spPrefernceOptionsMsg" runat="server" style="color: Red; line-height: 25px;">
                                    </span>
                                    <asp:DropDownList ID="drpPreferenceOptions" runat="server" onChange="return HideStepSix();">
                                        <asp:ListItem Text="- Select -" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="To eat less" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Increase your activity" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--Step - Group / Individual --%>
                <%-- Calculate --%>
                <tr>
                    <td class="submit_class" style="float: left; margin-left: 195px; margin-top: -10px;">
                        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click"
                            OnClientClick="return CheckForStepFive();" Style="display: none;" />
                    </td>
                </tr>
                <%--Step - 6 --%>
                <tr>
                    <td>
                        <table id="tblInitialMessage" runat="server" style="display: none;">
                            <tr>
                                <td>
                                    <span style="border-bottom: 1px solid; color: #0b7974; float: left; font-family: myriad pro;
                                        font-size: 24px; font-weight: normal; margin-top: 5px; margin-left: 33px; padding-bottom: 5px;
                                        width: auto;"><span id="spStepSixFive" runat="server"></span></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="float: left; font-size: 14px; line-height: 21px; margin-left: 39px;
                                        margin-top: 15px; width: 677px;">We calculate that given your current activity,
                                        you should be able to achieve this mission&nbsp;<span id="spConsumeAmount" runat="server"></span>
                                        till <span id="spEstimatedDate" runat="server"></span>.&nbsp;&nbsp;Will that work
                                        for you? </span>
                                </td>
                                <td class="accept_reject">
                                    <asp:Button ID="btnAcceptedByUser" runat="server" Text="YES" OnClientClick="return ShowFinalizeMission();"
                                        Style="background: none repeat scroll 0 0 #0E7C77; border: medium none navy;
                                        border-radius: 3px 3px 3px 3px; color: #FFFFFF; float: left; font-family: arial;
                                        font-size: 17px; margin-left: 36px; margin-top: 12px; padding: 5px; width: 41px;" />
                                    &nbsp;
                                    <asp:Button ID="btnRejectedByUser" runat="server" Text="NO" OnClientClick="return showCalendarToChange();"
                                        Style="background: none repeat scroll 0 0 #0E7C77; border: medium none navy;
                                        border-radius: 3px 3px 3px 3px; color: #FFFFFF; float: left; font-family: arial;
                                        font-size: 17px; margin-left: 19px; margin-top: 2px; padding: 5px; width: 41px;" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnFinalizeMission" runat="server" Text="Finalize Mission" OnClientClick="return CheckOnFinalize();"
                            OnClick="btnAcceptedByUser_Click" Style="margin-left: 227px; margin-top: 10px;
                            display: none;" />
                    </td>
                </tr>
                <%-- Mission CompletionDate --%>
                <tr>
                    <td>
                        <asp:Panel ID="pnlMissionCompletionDate" runat="server" Style="display: none;">
                            <table>
                                <tr>
                                    <td style="float: left; font-size: 18px; font-style: italic; font-weight: bold; margin-left: 33px;
                                        color: #966338;">
                                        Ok. When would you like to accomplish this mission?
                                    </td>
                                </tr>
                                <tr>
                                    <td class="close_wall">
                                        <asp:HiddenField ID="hdnProposedDate" runat="server" />
                                        <asp:TextBox ID="txtDateOfMissionCompletion" runat="server" ReadOnly="true"></asp:TextBox>
                                        <span class="calc">
                                            <asp:CalendarExtender ID="calMissionCompletion" runat="server" OnClientDateSelectionChanged="checkDate"
                                                CssClass="cal_Theme1" TargetControlID="txtDateOfMissionCompletion" />
                                        </span>
                                        <br />
                                        <span id="spUserSelectedDate" runat="server" style="color: Red;"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnRegisterWithProposedDate" runat="server" Text="Finalize Mission"
                                            OnClick="btnAcceptedByUser_Click" OnClientClick="return SelectCustomDateMsg();" />
                                        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="return closeCalendarToChange();" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <%-- Mission Message --%>
                <tr>
                    <td>
                        <asp:Panel ID="pnlCaloriesNotFeasible" runat="server" Style="margin-left: 176px;
                            margin-top: 20px; display: none;">
                            <table style="margin-bottom: 8px; margin-left: 133px">
                                <tr>
                                    <td align="center" style="background: none repeat scroll 0 0 transparent; color: #0B7974;
                                        float: left; font-family: myriad pro; font-size: 17px; font-weight: bold; margin-bottom: 5px;
                                        margin-left: 32px; text-align: left;">
                                        There is no way to do that safely. Please recommend another date
                                        <br />
                                        <br />
                                        Or "If Level of your exercise is any of the following"
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background: none repeat scroll 0 0 #EEEEEE; border: 1px solid #CCCCCC;
                                        border-radius: 7px 7px 7px 6px; float: left; margin-bottom: -7px; margin-left: 34px;
                                        margin-top: 1px; padding: 9px 8px 9px 14px; width: 483px;">
                                        <asp:RadioButton ID="radLessAggresive" runat="server" onclick="return CheckProposedDates_radLessAggressive()" />
                                        <span style="font-family: Verdana; color: Black; font-size: 14px; font-weight: bold;">
                                            Less aggressive</span><br />
                                        <br />
                                        <div id="dvLessAggressiveData" runat="server" style="display: none;">
                                            Calories to Consume&nbsp;&nbsp;&nbsp;&nbsp;= &nbsp;<asp:Label ID="lblLessAggressiveCalConsume"
                                                runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            Date Recommended&nbsp;&nbsp;&nbsp;&nbsp;= &nbsp;<asp:Label ID="lblLessAggressiveDateRecommended"
                                                runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background: none repeat scroll 0 0 #EEEEEE; border: 1px solid #CCCCCC;
                                        border-radius: 7px 7px 7px 6px; float: left; margin-bottom: -7px; margin-left: 34px;
                                        margin-top: 1px; padding: 9px 8px 9px 14px; width: 483px;">
                                        <asp:RadioButton ID="radAverage" runat="server" onclick="return CheckProposedDates_radAverage()" />
                                        <span style="font-family: Verdana; color: Black; font-size: 14px; font-weight: bold;">
                                            Average </span>
                                        <br />
                                        <br />
                                        <div id="dvAverageData" runat="server" style="display: none;">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Calories to Consume&nbsp;&nbsp;&nbsp;&nbsp;
                                            = &nbsp;<asp:Label ID="lblAverageCalConsume" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            Date Recommended&nbsp;&nbsp;&nbsp;&nbsp;= &nbsp;<asp:Label ID="lblAverageDateRecommended"
                                                runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background: none repeat scroll 0 0 #EEEEEE; border: 1px solid #CCCCCC;
                                        border-radius: 7px 7px 7px 6px; float: left; margin-bottom: -7px; margin-left: 34px;
                                        margin-top: 1px; padding: 9px 8px 9px 14px; width: 483px;">
                                        <asp:RadioButton ID="radMoreAggressive" runat="server" onclick="return CheckProposedDates_radMoreAggressive()" />
                                        <span style="font-family: Verdana; color: Black; font-size: 14px; font-weight: bold;">
                                            More aggressive </span>
                                        <br />
                                        <br />
                                        <div id="dvMoreaggressive" runat="server" style="display: none;">
                                            Calories to Consume&nbsp;&nbsp;&nbsp;&nbsp; = &nbsp;<asp:Label ID="lblMoreAggressiveCalCosnume"
                                                runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            Date Recommended&nbsp;&nbsp;&nbsp;&nbsp;= &nbsp;<asp:Label ID="lblMoreAggressiveDateRecommended"
                                                runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnFin2" runat="server" Text="Finalize Mission" OnClick="btnFin2_Click"
                                            OnClientClick="return CheckOnProposedDates();" Style="margin-left: 227px; margin-top: 7px;
                                            display: none;" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnNew" runat="server" Text="Recommend New date" OnClientClick="return showCalendarToChange();"
                                            Style="margin-left: 103px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlMissionCompletionMessage" runat="server" Style="margin-left: 176px;
                            margin-top: 20px;">
                            <table style="margin-bottom: 8px; margin-left: 133px">
                                <tr>
                                    <td align="center" style="background: none repeat scroll 0 0 transparent; color: #0B7974;
                                        float: left; font-family: myriad pro; font-size: 25px; font-weight: bold; margin-bottom: 5px;
                                        margin-left: 206px; text-align: left;">
                                        Done !
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background: none repeat scroll 0 0 #288C87; border-radius: 5px 5px 5px 5px;
                                        color: #FFFFFF; float: left; font-family: myriad pro; font-size: 18px; font-weight: normal;
                                        height: 25px; margin-bottom: 8px; margin-left: -1px; margin-top: 8px; padding-left: 10px;
                                        padding-right: 11px; padding-top: 10px;">
                                        Thanks for that. We've now developed a plan for your mission.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="line-height: 21px; width: 480px; margin-left: 0px;" id="spFinalMessage"
                                            runat="server"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnCreateNew" runat="server" Text="Create New" OnClick="btnCreateNew_Click"
                                            OnClientClick="FocusStep1()" Style="margin-left: 103px;" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnListAllMissions" runat="server" Text="List All Missions" OnClick="btnListAllMissions_Click"
                                            Style="margin-left: 8px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlErrorMsg" runat="server" Style="margin-left: 176px; margin-top: 20px;
                            display: none;">
                            <table style="margin-bottom: 8px; margin-left: 133px">
                                <tr>
                                    <td style="background: none repeat scroll 0 0 #288C87; border-radius: 5px 5px 5px 5px;
                                        color: #FFFFFF; float: left; font-family: myriad pro; font-size: 18px; font-weight: normal;
                                        height: 40px; line-height: 18px; margin-bottom: 8px; margin-left: -102px; margin-top: 6px;
                                        padding-left: 10px; padding-right: 11px; padding-top: 10px;">
                                        As per the weight mentioned in your profile, we recommend you to not to lose any
                                        more calories and update your weight in the profile page.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Create New" OnClick="btnCreateNew_Click"
                                            OnClientClick="FocusStep1()" Style="margin-left: 103px;" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button2" runat="server" Text="List All Missions" OnClick="btnListAllMissions_Click"
                                            Style="margin-left: 8px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                    </div>
                    <div style="float: left; margin-top: 17px; margin-left: -249px;">
                        <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                            top: 45%;" alt="Processing Request" />
                    </div>
                </asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
