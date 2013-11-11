<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMissionHistory.ascx.cs"
    Inherits="ALEREIMPACT.User.ucMissionHistory" %>
<%@ Register TagPrefix="ajaxCtrl" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<link rel="stylesheet" type="text/css" href="../js/jscrollpane.css" />
<!-- latest jQuery direct from google's CDN -->

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

<!-- the jScrollPane script -->

<script type="text/javascript" src="../js/jscrollpane.min.js"></script>

<!-- CSS -->
<style>
    *
    {
        margin: 0;
        padding: 0;
    }
    .container
    {
        width: 965px;
        height: 600px;
        margin: 20px auto;
        overflow: scroll; /* showing scrollbars */
    }
    p
    {
        margin: 0 0 2em 0;
    }
    ::-webkit-scrollbar
    {
        width: 15px;
    }
    /* this targets the default scrollbar (compulsory) */::-webkit-scrollbar-track
    {
        background-color: #F0F0F0;
    }
    /* the new scrollbar will have a flat appearance with the set background color */::-webkit-scrollbar-thumb
    {
        background-color: rgba(0, 0, 0, 0.2);
    }
    /* this will style the thumb, ignoring the track */::-webkit-scrollbar-button
    {
        background-color: #F0F0F0;
    }
    /* optionally, you can style the top and the bottom buttons (left and right for horizontal bars) */::-webkit-scrollbar-corner
    {
        background-color: black;
    }
    /* if both the vertical and the horizontal bars appear, then perhaps the right bottom corner also needs to be styled */</style>

<script type="text/javascript">

    $(document).ready(function() {
        $('.container').jScrollPane();

    });

</script>

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
        background-color: #F0DF95;
        background-image: linear-gradient(#FFFFFF, #F0DF95 100px);
        font-family: Arial;
        font-size: 15px;
        color: Red;
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
        background-color: #4DA3A4;
        color: #FFFFFF;
        font-family: Arial;
        font-size: 13px;
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
        background-color: #FBFBFB;
        color: #666666;
        font-size: 9pt;
        line-height: 25px;
        font-family: Arial;
    }
    .alternateItemStyle
    {
        background-color: #FFFFFF;
        color: #000000;
        font-size: 8pt;
        font-family: Arial;
    }
    .input_mission_from_history
    {
        background: none repeat scroll 0 0 #0E7C77 !important;
        border: medium none navy;
        border-radius: 3px 3px 3px 3px;
        color: #FFFFFF;
        float: left;
        font-family: Arial;
        font-size: 17px;
        margin-left: 723px !important;
        margin-top: -14px !important;
        padding: 5px !important;
    }
    .empty
    {
        font-family: Arial;
        font-size: 17px;
        color: Red;
        margin: 363px;
        padding: 5px;
        width: 711px;
        line-height: 20px;
    }
    #historyMission_grdDates tr:last-child td table
    {
        margin-left: 2px !important;
        width: 930px !important;
    }
</style>

<script type="text/javascript">

    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
</script>

<asp:UpdatePanel ID="updatePanelHistory" runat="server">
    <ContentTemplate>
        <%--start--%>
        <div class="main_cont_miss">
            <div class="top_his_miss">
                <div class="bread_miss">
                    <span class="mission_miss">Mission</span><div class="arrow_miss">
                        <img src="../images/red_arrow.png" /></div>
                    <span class="mission_miss" style="color: #53afb0;">Track History</span>
                </div>
                <div class="golist_miss">
                    <asp:LinkButton Text="List All Missions" runat="server" ID="lnkListMission" OnClick="lnkListMission_Click">
                    <img style="margin-top: 2px;"
                        src="../images/meni.png" /><span class="go_miss">Go To List All Missions</span></asp:LinkButton>
                </div>
                <div class="left_miss" id="dvLeftDescription" runat="server">
                    <div class="left_gray_miss">
                        <div class="green_miss">
                            <asp:Image ImageUrl="../images/MissionNameIco.png" ToolTip="Mission Name" ID="imgMissionName"
                                runat="server" />
                            <span class="name_des_miss">
                                <asp:Label ID="lblMissionName" runat="server"> </asp:Label>
                            </span>
                        </div>
                    </div>
                    <div class="left_gray_miss" style="display: none;">
                        <div class="yellow_miss">
                            <asp:Image ImageUrl="../images/target.png" ToolTip="Target calories to burn" ID="imgTarget"
                                runat="server" />
                            <span class="name_des_miss">
                                <asp:Label ID="lblMissionTarget" runat="server"> </asp:Label>
                            </span>
                        </div>
                    </div>
                    <div class="left_gray_miss">
                        <div class="orange_miss">
                            <asp:Image ImageUrl="~/images/list.png" ToolTip="Description of mission" ID="imgMissionDescription"
                                runat="server" />
                            <span class="name_des_miss">
                                <asp:Label ID="lblMIssionDescription" runat="server"> </asp:Label>
                            </span>
                        </div>
                    </div>
                    <div class="left_gray_miss">
                        <div class="orange_miss">
                            <asp:Image ImageUrl="../images/deadline.png" ToolTip="Target date of the mission"
                                ID="imgDeadline" runat="server" />
                            <span class="name_des_miss">
                                <asp:Label ID="lblDeadline" runat="server"> </asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="rgt_miss" id="dvRightButtons" runat="server">
                    <%--<div class="submit_miss">--%>
                    <asp:Button ID="lnkSubmitAgain" runat="server" Text="Log" OnClientClick="showDivProgress();"
                        Style="cursor: pointer;" class="submit_miss" OnClick="lnkSubmitAgain_Click" />
                    <%--</div>--%>
                    <div>
                        <asp:Button ID="btnDailyProgress" runat="server" Text="Check Daily Progress" class="check_miss"
                            OnClientClick="showDivProgress();" OnClick="btnDailyProgress_Click" />
                    </div>
                </div>
            </div>
            <div class="table_miss" style="overflow: auto; height: 550px;">
                <asp:GridView ID="grdDates" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdDates_RowDataBound"
                    EmptyDataRowStyle-Font-Size="15px" EmptyDataRowStyle-HorizontalAlign="Center"
                    EmptyDataRowStyle-ForeColor="Red" Width="960px" EmptyDataText="No Inputs for this mission yet !"
                    EmptyDataRowStyle-CssClass="empty">
                    <AlternatingRowStyle CssClass="alternateItemStyle" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellspacing="0">
                                    <tr>
                                        <td>
                                            <div class="top_blue_miss">
                                                <div class="left_blue_miss">
                                                    <img class="clock_miss" src="../images/clock.png" />
                                                    <span class="activity_miss"><span style="color: #f1c50e">Activity Date : </span>
                                                        <asp:Label ID="lblDateOfInput" Text='<%# Eval("DateOfCaloriesBurnt","{0:MM/d/yyyy}") %>'
                                                            runat="server" Style="color: #FFFFFF"></asp:Label></span></div>
                                                <div class="rgt_blue_miss">
                                                    <img src="../images/drop_arrow.png" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%-- <td></td>--%>
                                        <td width="950px">
                                            <table cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdCaloriesBurnt" runat="server" AutoGenerateColumns="false" Width="950px"
                                                            OnRowDataBound="grdCaloriesBurnt_RowDataBound" RowStyle-HorizontalAlign="Center"
                                                            BorderColor="Black">
                                                            <HeaderStyle CssClass="subheaderStyle" />
                                                            <RowStyle CssClass="itemStyle" />
                                                            <Columns>
                                                                <asp:BoundField DataField="CreatedBy" HeaderText="Input By" />
                                                                <asp:BoundField DataField="CaloriesBurnt" />
                                                                <asp:BoundField DataField="CaloriesEaten" />
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                No Record Found..
                                                            </EmptyDataTemplate>
                                                            <AlternatingRowStyle BackColor="#F2F2F0" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <%--End--%>
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
