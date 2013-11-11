<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFitBitAccountSettings.ascx.cs"
    Inherits="ALEREIMPACT.User.ucFitBitAccountSettings" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />
<link href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet">

<script type="text/javascript">
    function PostToNewWindow(url) {

        window.open(url, 'na', 'left=50,top=20,width=1100,height=590,toolbar=1,resizable=0');
        return false;
    }
    function ShowProgresBarForSettings() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';
    }
    function HideProgresBarForSettings() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'none';
    }
    function confirmAction() {
        if (confirm('Are you sure you want to disconnect your fitbit account from vitality ?')) {
            ShowProgresBarForSettings();
            return true;
        }
        else {
            document.getElementById('<%=dvUploader.ClientID %>').style.display = 'none';
            return false;

        }
    }  
</script>

<script type="text/javascript">

    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
</script>

<style>
    .main_head_fitbit
    {
        color: #379396;
        font-family: arial;
        font-size: 22px;
        font-weight: bold;
        margin-top: 25px;
        text-align: center;
        width: 100%;
    }
    #main
    {
        background: none repeat scroll 0 0 #FFFFFF;
        border: 1px solid #ECECEC;
        margin: 25px auto;
        overflow: hidden;
        padding: 20px 20px 20px 31px;
        width: 917px;
    }
    #FitBitAcc_subNavbg
    {
        float: left;
        overflow: hidden;
    }
    .featured_apps li
    {
        border-bottom: 1px solid #EEEEEE;
        float: left;
        width: 930px;
    }
    .featured_apps img
    {
        float: left;
    }
    .featured_apps li p
    {
        float: left;
        font-family: arial;
        font-size: 13px;
        line-height: 22px;
        margin-left: 21px;
        text-align: left;
        width: 800px;
    }
    .featured_apps h4
    {
        float: left;
        font-family: arial;
    }
    .featured_apps span
    {
        clear: both;
        float: left;
        font-family: arial;
    }
    .new_button
    {
        float: left;
        margin-top: 5px;
        text-align: center;
        width: 103px;
    }
    
#FitBitAcc_dvDevices p {
    clear: both;
    margin-left: 20px;
    text-align: left;
}
#FitBitAcc_dvDevices h4 {
    float: left;
}#FitBitAcc_dvDevices img {
    float: left;
    margin:0 10px 10px 20px;
}
#FitBitAcc_dvDevices span {
    display: inline-block;
    margin: 5px 0 20px 20px;
}
</style>
<div id="main">
    <div id="dvDevices" runat="server">
        <table>
            <tr>
                <td>
                    <img src="../images/FitBitIcon.png" alt="fitbit device 1" />
                    <h4>
                       Fitbit Aria Wi-Fi Smart Scale</h4><br />
                    By Fitbit
                    <p>The Fitbit Aria Wi-Fi Smart Scale measures your weight, body fat percentage and body mass index (BMI) to provide a full picture of your weight trends. Your stats automatically upload to your Fitbit dashboard over Wi-Fi. Track trends on your computer or mobile device.</p>
                    <span>
                        <asp:LinkButton ID="lnkSinkDataFromFitBit" runat="server" OnClick="lnkSinkDataFromFitBit_Click"></asp:LinkButton>
                    </span>
                </td>
                </tr>
                <tr>
                <td>
                    <img src="../images/FitBitIcon.png" alt="fitbit device 2" />
                    <h4>
                        Fitbit Tracker</h4><br />
                    By Fitbit
                    <p>Fitbit Trackers monitor your steps, distance, calories burned and more. Automatically sync the data to your Fitbit account via your computer and select smartphones. Set goals and stay motivated to keep on your path to fitness with graphs, badges, and friendly competitions.</p>
                    <span>
                        <asp:LinkButton ID="lnkSinkDataFromFitBit2" runat="server" OnClick="lnkSinkDataFromFitBit_Click"></asp:LinkButton>
                    </span>
                </td>
            </tr>
        </table>
    </div>
    <div id="dvMessage" runat="server" visible="false">
        <h2 class="main_head_fitbit">
            Congratulation! Your fitbit tracker is now connected to Vitality.</h2>
        <br />
        <div style="margin-left: 350px; font-weight: bold;">
            <asp:LinkButton ID="lnkRedirectToActivityLog" runat="server" OnClick="lnkRedirectToActivityLog_Click"
                Text="Get Started Now !"></asp:LinkButton>
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
