<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="HealthstatChart.aspx.cs" Inherits="ALEREIMPACT.Admin.HealthstatChart"
    Title="Health Stats" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .seprator_mission
        {
            background: url(          "../images/sap_bar_mission.png" ) repeat-x scroll 0 0 transparent;
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
           background-color: #999999;
    background-image: linear-gradient(#FFFFFF, #999999 100px);
    border: 1px solid #D4D4D4;
    color: #999999;
    font-family: Verdana;
    font-size: 17px;
    line-height: 20px;
    margin: 363px;
    padding: 5px;
    width: 711px;
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
           font-size: 20px !important;
            line-height: 15px !important;
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
            width: 738px !important;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="breadcrumb">
        <asp:LinkButton ID="lnkHealthstats" runat="server" OnClick="lnkHealthstats_Click"
            Style="color: #45B5B0 !important;">Health Stats</asp:LinkButton>
        <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
        <span style="color: #50514F;">Health Stats Chart &nbsp;(<asp:Label ID="lbname" runat="server"
            Text=""></asp:Label>)</span>
    </div>
      <table id="tblEmptyRow" runat="server" width="100%" align="left">
                <tr>
                    <td>
                        <span class="empty" style="margin-left: 356px">No Record Found.</span>
                    </td>
                </tr>
            </table>
    <table width="100%" align="left" id="tblChartInfo" runat="server">
        <tr>
            <td style="float: left; width: 190px !important;">
                <table>
                    <tr>
                        <td>
                            <div class="top_his_miss">
                                <div class="bread_miss">
                                    <span class="mission_miss" style="float: left; margin-bottom: 8px; margin-left: 7px;">
                                        Overall</span><div class="arrow_miss">
                                        </div>
                                </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="bread_miss" style="float: left; margin-left: 17px;">
                                <span class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                                    color: #53AFB0 !important;">Food : </span><span id="spCalConsume" runat="server"
                                        class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                                        color: #53AFB0 !important; margin-left: 5px;"></span>&nbsp;<span class="mission_miss"
                                            style="float: left; font-size: 13px; font-weight: bold; color: #53AFB0 !important;
                                            margin-left: 5px;">Cals</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="bread_miss" style="float: left; margin-left: 17px;">
                                <span class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                                    color: #53AFB0 !important;">Burned : </span><span id="spCalBurned" runat="server"
                                        class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                                        color: #53AFB0 !important; margin-left: 5px;"></span>&nbsp;<span class="mission_miss"
                                            style="float: left; font-size: 13px; font-weight: bold; color: #53AFB0 !important;
                                            margin-left: 5px;">Cals</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="bread_miss" style="float: left; margin-left: 17px;">
                                <span class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                                    color: #53AFB0 !important;">Activity : </span><span id="spStepsTaken" runat="server"
                                        class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                                        color: #53AFB0 !important; margin-left: 5px;"></span>&nbsp;<span class="mission_miss"
                                            style="float: left; font-size: 13px; font-weight: bold; color: #53AFB0 !important;
                                            margin-left: 5px;">Steps</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="bread_miss" style="float: left; margin-left: 17px;">
                                <span class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                                    color: #53AFB0 !important;">Weight : </span><span id="spWeight" runat="server" class="mission_miss"
                                        style="float: left; font-size: 13px; font-weight: bold; color: #53AFB0 !important;
                                        margin-left: 5px;"></span>&nbsp; <span id="spWeightunit" runat="server" class="mission_miss"
                                            style="float: left; font-size: 13px; font-weight: bold; color: #53AFB0 !important;
                                            margin-left: 5px;"></span>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" style="float: left; margin-left: 168px; margin-top: -88px; width: 790px;">
                <div style="overflow-x: auto; width: 900px;" id="dvChart" runat="server">
                    <asp:LineChart ID="LineChart2" runat="server" ChartHeight="300" ChartWidth="450"
                        ChartType="Basic" CssClass="chartCss" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
                        ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                    </asp:LineChart>
                </div>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="float: left; width: 190px !important;">
                <span class="mission_miss" style="float: left; font-size: 13px; font-weight: bold;
                    margin-left: 18px; color: #53AFB0 !important;">Weight's Current Stats</span>
            </td>
            <td style="float: left; margin-left: 168px; margin-top: -41px; width: 790px;">
                <div style="overflow-x: auto; width: 900px;" id="Div1" runat="server">
                    <asp:LineChart ID="lnchweigth" runat="server" ChartHeight="300" ChartWidth="450"
                        ChartType="Basic" CssClass="chartCss" ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9"
                        ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                    </asp:LineChart>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
