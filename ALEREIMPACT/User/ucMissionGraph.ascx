<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMissionGraph.ascx.cs"
    Inherits="ALEREIMPACT.User.ucMissionGraph" %>
<%@ Register TagPrefix="ajaxtoolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<style type="text/css">
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
        font-family: Arial;
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
        font-family: Arial;
        font-size: 20px;
        margin-top: 0px;
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
        font-family: Arial;
        font-size: 20px;
        margin-top: -72px;
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
        font-family: Arial;
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
        border: 1px solid #000000 !important;
        margin-left: 0;
        overflow: auto;
    }
    #MissionsGraphs_LineChart2 > div#MissionsGraphs_LineChart2__ParentDiv
    {
        overflow: auto;
    }
    .mission_miss
    {
        color: #53AFB0 !important;
        font-family: Arial;
        font-size: 15px;
        line-height: 5px !important;
        margin: 0;
    }
</style>

<script type="text/javascript">

    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
</script>

<asp:UpdatePanel ID="updatePanelTrackMission" runat="server">
    <ContentTemplate>
        <div class="main_cont_miss">
            <table width="100%" align="center">
                <tr>
                    <td>
                        <div class="top_his_miss">
                            <div class="bread_miss">
                                <span class="mission_miss">Mission</span><div class="arrow_miss">
                                    <img src="../images/red_arrow.png" /></div>
                                <span class="mission_miss" style="color: #53afb0;">Daily Progress</span>
                            </div>
                            <div class="golist_miss">
                                <asp:LinkButton Text="List All Missions" runat="server" ID="lnkListMission" OnClick="lnkListMission_Click"
                                    OnClientClick="showDivProgress();">
                    <img style="margin-top: 2px;"
                        src="../images/meni.png" /> <span class="go_miss">Go To List All Missions</span></asp:LinkButton>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td width="200px">
                                    <div class="left_gray_miss_graph">
                                        <div class="left_gray_miss">
                                            <div class="green_miss_graph">
                                                <asp:Image ImageUrl="../images/MissionNameIco.png" ToolTip="Mission Name" ID="imgMissionName"
                                                    runat="server" />
                                                <span class="name_des_miss" style="float: none;">
                                                    <asp:Label ID="lblMissionName" runat="server"> </asp:Label>
                                                </span>
                                            </div>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="200px">
                                    <div class="left_gray_miss_graph">
                                        <div class="left_gray_miss">
                                            <div class="green_miss_graph">
                                                <asp:Image ImageUrl="../images/list.png" ToolTip="Mission Description" ID="Image1"
                                                    runat="server" />
                                                <span class="name_des_miss" style="float: none;">
                                                    <asp:Label ID="lblMissionDescription" runat="server"> </asp:Label>
                                                </span>
                                            </div>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #F9F9F7; display: none;">
                                    <div class="left_gray_miss_graph">
                                        <div class="yellow_miss_graph">
                                            <asp:Image ImageUrl="../images/target1.png" ToolTip="Target calories to burn" ID="imgTarget"
                                                runat="server" />
                                            <span class="name_des_miss" style="float: none;">
                                                <asp:Label ID="lblMissionTarget" runat="server"> </asp:Label></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #F9F9F7">
                                    <div class="left_gray_miss_graph">
                                        <div class="orange_miss_graph">
                                            <asp:Image ImageUrl="../images/deadline.png" ToolTip="Target date of the mission"
                                                ID="imgDeadline" runat="server" />
                                            <span class="name_des_miss" style="float: none;">
                                                <asp:Label ID="lblDeadline" runat="server"> </asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td height="35px">
                                    <asp:Button ID="lnkSubmitAgain" runat="server" Text="Log" class="input_mission_from_history"
                                        Style="cursor: pointer; margin-left: 0px !important;" OnClientClick="showDivProgress();"
                                        OnClick="lnkSubmitAgain_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnActivityLog" runat="server" Text="History" class="activity_log_from_history"
                                        Style="margin-left: 0px;" OnClientClick="showDivProgress();" OnClick="btnActivityLog_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <div style="width: 900px;" id="dvChart" runat="server">
                            <span class="mission_miss" style="padding-left: 60px; line-height: 40px !important;
                                font-size: 27px; margin-bottom: 5px;">Calories Burnt and Consumed</span>
                            <ajaxtoolkit:LineChart ID="LineChart2" runat="server" Style="clear: both;" ChartHeight="300"
                                ChartType="Basic" ChartWidth="200" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
                                ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                            </ajaxtoolkit:LineChart>
                        </div>
                        <asp:Image ID="imgEmptyChartImage" runat="server" ImageUrl="~/images/empty_Graph.png" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <div style="width: 900px;" id="dvLineChart" runat="server">
                            <span class="mission_miss" style="padding-left: 60px; line-height: 40px !important;
                                font-size: 27px; margin-bottom: 5px;">Steps Covered</span>
                            <ajaxtoolkit:LineChart ID="lncSteps" Style="clear: both;" runat="server" ChartHeight="300"
                                ChartType="Basic" ChartWidth="200" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
                                ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                            </ajaxtoolkit:LineChart>
                        </div>
                        <asp:Image ID="imgEmptyChartImageSteps" runat="server" ImageUrl="~/images/empty_StepsGraph.png" />
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
