<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMissionOptions.ascx.cs"
    Inherits="ALEREIMPACT.User.ucMissionOptions" %>
<link rel="stylesheet" href="../CSS/style.css" type="text/css" />
<%@ Register TagPrefix="ajaxCtrl" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<script type="text/javascript">
    function SelectCustomDateMsg() {
        if (document.getElementById('MissionsOpt_pnlChangeDeadline').style.display = 'block') {
            if (document.getElementById('<%= hdnProposedEndDate.ClientID %>').value == '') {
                document.getElementById('MissionsOpt_spUserSelectedEndDate').textContent = 'Click to select a date.';
                return false;
            }
            else {
                if (confirm("Are you sure you want to set a new target date for this mission ?")) {
                    document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

                    return true;
                } else {
                    return false;
                }
            }
        }
    }

    function CheckPreviousDate(sender, args) {

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

        //alert(sender._selectedDate < toDate);
        //var difference = sender._selectedDate - toDate;

        if (selectedDate < toDate) {

            alert("You can not select a Past Date !");
            document.getElementById('<%= txtInspectionDate.ClientID %>').value = "";
            return false;
        }
        else {
            document.getElementById('<%= hdnProposedEndDate.ClientID %>').value = document.getElementById('<%= txtInspectionDate.ClientID %>').value;
        }
    }
</script>

<script type="text/javascript">

    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
</script>

<style type="text/css">
    .input_mission_from_history
    {
        background: none repeat scroll 0 0 #181818 !important;
        border: medium none navy;
        border-radius: 3px 3px 3px 3px;
        color: #FFFFFF;
        float: left;
        font-family: myriad pro;
        font-size: 17px;
        margin-left: 723px !important;
        margin-top: -14px !important;
        padding: 5px !important;
    }
    .flc:after
    {
        clear: both;
        content: ".";
        display: block;
        height: 0;
        visibility: hidden;
    }
    .flc:after
    {
        clear: both;
        content: ".";
        display: block;
        height: 0;
        visibility: hidden;
    }
    #track_data
    {
        background: none repeat scroll 0 0 #FFFFFF;
        box-shadow: 0 0 6px #AAAAAA;
        margin: 0 0 20px;
        min-height: 182px;
        padding: 20px 0 20px 20px;
        position: relative;
        color: #4D528C;
        font: 12px verdana,geneva,lucida, 'lucida grande' ,arial,helvetica,sans-serif;
        text-decoration: none;
    }
    .miss_header
    {
        font: 18px verdana,geneva,lucida, 'lucida grande' ,arial,helvetica,sans-serif;
    }
    #track_data label
    {
        display: block;
        font-size: 16px;
        font-weight: bold;
        margin: 0 0 10px;
    }
</style>
<asp:UpdatePanel ID="updatePanelMissionOptions" runat="server">
    <ContentTemplate>
        <table width="100%" align="center">
            <tr>
                <div id="breadcrumb">
                    Missions
                    <img alt="" border="0" height="12" src="../images/arow.jpg" width="13" />
                    List Of Missions <span style="float: right;">Go To
                        <asp:LinkButton ID="lnkListMission" runat="server" OnClientClick="showDivProgress();"
                            OnClick="lnkListMission_Click" Text="List All Missions"></asp:LinkButton>
                    </span>
                    <img alt="" border="0" height="12" src="../images/arow.jpg" width="13" />
                    Change Status Of Mission
                </div>
            </tr>
        </table>
        <div style="float: left; margin-left: 16px; width: 450px;">
            <div id="track_data" class="flc" align="center" style="min-height: 150px; padding: 0;">
                <div style="background: none repeat scroll 0 0 #fff; float: left; height: 33px; padding-left: 19px;
                    padding-top: 9px; width: 431px;">
                    <div style="height: 35px">
                        <span class="miss_header">Mission Name:</span>
                    </div>
                    <div style="float: left; font-family: arial; font-size: 17px; height: 35px; margin-left: 14px;
                        margin-top: 8px;">
                        <asp:Label ID="lblMissionName" runat="server"></asp:Label>
                    </div>
                </div>
                <div style="background: none repeat scroll 0 0 #EEEEEE; float: left; height: 33px;
                    padding-left: 19px; padding-top: 9px; width: 431px;">
                    <div style="height: 35px">
                        <span class="miss_header">Mission Type:</span>
                    </div>
                    <div style="float: left; font-family: arial; font-size: 17px; height: 35px; margin-left: 14px;
                        margin-top: 0px;">
                        <asp:Image ID="imgMission_GroupIndividual" runat="server" style="float:left;" />
                        <span style="float: left; margin-left: 8px; margin-right: 7px; margin-top: 6px;">|</span>
                        <asp:Image ID="imgMission_PublicPrivate" runat="server" />
                    </div>
                </div>
                <div style="background: none repeat scroll 0 0 #fff; float: left; height: 33px; padding-left: 19px;
                    padding-top: 9px; width: 431px;">
                    <div style="height: 35px">
                        <span class="miss_header">Date Created:</span>
                    </div>
                    <div style="float: left; font-family: arial; font-size: 17px; height: 35px; margin-left: 14px;
                        margin-top: 8px;">
                        <asp:Label ID="lblDateCreated" runat="server"></asp:Label>
                    </div>
                </div>
                <div style="background: none repeat scroll 0 0 #EEEEEE; float: left; height: 33px;
                    padding-left: 19px; padding-top: 9px; width: 431px;">
                    <div style="height: 35px;">
                        <span class="miss_header">Target Date:</span>
                    </div>
                    <div style="float: left; font-family: arial; font-size: 17px; height: 35px; margin-left: 14px;
                        margin-top: 8px;">
                        <asp:Label ID="lblDeadline" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left; margin-left: 63px; margin-top:63px; width: 420px;">
            <table id="Table1" class="flc" align="center">
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkChangeDeadline" runat="server" Text="Would you like to extend this mission?"></asp:LinkButton>
                        Or
                        <asp:LinkButton ID="lnkEndMission" runat="server" Text="End this mission?" OnClick="lnkEndMission_Click"
                            OnClientClick="return confirm('Are you sure you want to close this mission ?')"></asp:LinkButton>
                        <br />
                        <div style="float: left;">
                            <tr>
                                <td>
                                    <ajaxCtrl:CollapsiblePanelExtender ID="cpe" runat="Server" TargetControlID="pnlChangeDeadline"
                                        CollapsedSize="0" ExpandedSize="300" Collapsed="True" ExpandControlID="lnkChangeDeadline"
                                        CollapseControlID="lnkChangeDeadline" AutoCollapse="False" AutoExpand="False"
                                        ScrollContents="false" TextLabelID="Label1" CollapsedText="Show Details..." ExpandedText="Hide Details"
                                        ImageControlID="Image1" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg"
                                        ExpandDirection="Vertical" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlChangeDeadline" runat="server" Style="display: none; height: 155px">
                                        <table>
                                            <tr>
                                                <td style="float: left; margin-bottom: 7px; margin-top: 11px;">
                                                    <span style="float: left;">Select a new Target Date for your mission :</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="float: left; margin-bottom: 8px; margin-top: 9px;">
                                                    <asp:HiddenField ID="hdnProposedEndDate" runat="server" />
                                                    <asp:TextBox ID="txtInspectionDate" runat="server" ReadOnly="true"></asp:TextBox>
                                                    <ajaxCtrl:CalendarExtender ID="putOnHoldCalendar" runat="server" PopupButtonID="txtInspectionDate"
                                                        Format="dd/MM/yyyy" TargetControlID="txtInspectionDate" OnClientDateSelectionChanged="CheckPreviousDate">
                                                    </ajaxCtrl:CalendarExtender>
                                                    <br />
                                                    <span id="spUserSelectedEndDate" runat="server" style="color: Red;"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="float: left;">
                                                    <asp:Button ID="imgSubmitNewDeadline" runat="server" Text="Submit" OnClientClick="return SelectCustomDateMsg();"
                                                        OnClick="imgSubmitNewDeadline_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnActivityLog" runat="server" Text="Activity Log" OnClientClick="showDivProgress();"
                            OnClick="btnActivityLog_Click" />
                        &nbsp;
                        <asp:Button ID="btnMissions" runat="server" Text="List Of Missions" OnClientClick="showDivProgress();"
                            OnClick="lnkListMission_Click" />
                    </td>
                </tr>
            </table>
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
    </ContentTemplate>
</asp:UpdatePanel>
