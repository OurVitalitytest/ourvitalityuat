<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListMissions.ascx.cs"
    Inherits="ALEREIMPACT.User.ucListMissions" %>
<%@ Register TagPrefix="ajaxCtrl" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<link rel="stylesheet" href="../CSS/style.css" type="text/css" />
<link rel="stylesheet" type="text/css" href="../js/mission_jscrollpane.css" />
<!-- latest jQuery direct from google's CDN -->

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

<!-- the jScrollPane script -->

<script type="text/javascript" src="../js/mission_jscrollpane.min.js"></script>

<!-- CSS -->
<style>
    *
    {
        margin: 0;
        padding: 0;
    }
    .container
    {
        width: 963px;
        height: 600px;
        margin: 6px auto; /* overflow: scroll; /* showing scrollbars */
    }
    {{{{{{margin:002em0;}
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
    function ShowCheckUnchek(chk) {

        if (chk.checked == true) {
            chk.checked = true;
        }
        else {
            chk.checked = false;
        }
    }

    $(document).ready(function() {
        $('.container').jScrollPane();

    });
    function bind() {
        $('.container').jScrollPane();




    }
</script>

<style type="text/css">
    .GridviewScrollHeader
    {
    }
    .pop_up_msg
    {
    }
    .main_pop_up_box_miss
    {
        background: none repeat scroll 0 0 #F9F9F9;
        height: 1600px;
        opacity: 0.91 !important;
        position: absolute;
        width: 100%;
        z-index: 9999;
    }
    .inner_box_pop_up
    {
        background: none repeat scroll 0 0 #FFFFFF;
        border: 5px solid #444444;
        border-radius: 10px 10px 10px 10px;
        box-shadow: 2px 5px 4px #444444;
        height: 411px;
        margin: -150px auto;
        opacity: 1;
        width: 475px;
        z-index: 999;
    }
    .close_img_pop_up img
    {
        float: right;
        margin-left: 451px;
        margin-top: -19px;
        position: absolute;
    }
    .heading_pop_up
    {
        float: left;
        font-family: arial;
        font-size: 20px;
        margin: 15px 0 0 15px;
        width: 500px;
    }
    .gridViewMembersCircle
    {
        background: none repeat scroll 0 0 #CCCCCC;
        float: left;
        font-family: Arial,Helvetica,sans-serif;
        padding-bottom: 4px;
        width: 470px !important;
    }
    .gridViewMembersCircle .check_invite
    {
        float: left;
        font-size: 14px;
        font-weight: bold;
        margin-left: 0;
        margin-top: 4px;
        width: 33%;
    }
    .gridViewMembersCircle .check_member
    {
        float: left;
        font-size: 14px;
        font-weight: lighter;
        margin-left: 15px;
        margin-top: 4px;
    }
    .gridViewMembersCircle th
    {
        background: none repeat scroll 0 0 #EEEEEE;
        float: left;
        font-family: Arial,Helvetica,sans-serif;
        padding-bottom: 5px;
        width: 100%;
    }
    .subheaderStyle
    {
        background-color: #4DA3A4;
        color: #FFFFFF;
        font-family: Arial;
        font-size: 12px;
        height: 23px;
        padding-top: 17px;
        font-weight: bold;
    }
    .subheaderStylenew
    {
        text-align: center !important;
    }
    .subheaderStyle th
    {
        padding-top: 10px;
        width: 980px;
    }
    .itemStyle
    {
        background-color: #FBFBFB;
        color: #444444 !important;
        font-family: Arial;
        font-size: 12px;
        font-weight: bold;
        line-height: 25px;
        padding-bottom: 5px;
        padding-top: 5px;
    }
    .itemStyle td
    {
        padding-top: 2px;
    }
    .checkboxitem
    {
        padding-top: 10px !important;
    }
    .alternateItemStyle
    {
        background-color: #FFFFFF;
        font-size: 12px;
        line-height: 25px;
        font-family: Arial;
        font-weight: bold;
        color: #444444 !important;
    }
    .optioninfo
    {
        background-color: #ffffff;
        font-family: Verdana;
        font-size: 15px;
        color: Red;
        border: 1px solid #D4D4D4;
        margin: 0;
        padding: 5px;
        width: 711px;
        height: 155px;
        line-height: 20px;
    }
    .tab_mission_runtime div div tr td input
    {
        float: none;
    }
    .gridViewMembersCircle
    {
        background: none repeat scroll 0 0 #CCCCCC;
        float: left;
        font-family: Arial,Helvetica,sans-serif;
        padding-bottom: 4px;
        width: 470px !important;
    }
    .gridViewMembersCircle .GridviewScrollHeader
    {
        background: none repeat scroll 0 0 #EEEEEE;
        clear: both;
        float: left;
        width: 470px;
    }
    .gridViewMembersCircle .GridviewScrollHeader .check_invite
    {
        float: left; /* width: 111px; */
    }
    #misList_grdMissionList_ctl12_grdOtherCircleMembers tr
    {
        float: left;
        width: 454px;
    }
    .OtherMemberGridviewScrollItem td span
    {
        float: left !important;
        text-align: left !important;
        width: 296px !important;
    }
    .OtherMemberGridviewScrollItem td
    {
        float: left;
        text-align: center !important;
        width: 139px !important;
    }
    .OtherMemberGridviewScrollItem tr td input
    {
        float: left;
        text-align: center !important;
        width: 140px;
    }
    .OtherMemberGridviewScrollItem td span input
    {
        float: left !important;
        font-size: 12px;
        line-height: 14px;
        margin-left: 0;
        margin-top: 0;
        padding-right: 2px;
        padding-top: 10px !important;
        text-align: center !important;
        width: 140px !important;
    }
    .pop_chkebox
    {
        background: none repeat scroll 0 0 #EEEEEE;
        float: left;
        overflow: hidden;
        width: 470px !important;
    }
    .check_box_middle
    {
        width: 50px !important;
    }
    .row_style
    {
        float: left;
        width: 470px;
    }
</style>

<script type="text/javascript" language="javascript">

    function ShowInvitation_ProgressBar(id) {
        var btnId = id;
        btnId = btnId.replace('btnInvite', 'dvUploaderInvitationMsg');
        document.getElementById(btnId).style.display = 'block';

    }


</script>

<div class="missin_list_wall" style="margin-top: 65px; font-size: 14px; line-height: 32px;
    margin-left: 0px !important; margin-top: -15px !important; width: 945px;">
    <div class="top_his_miss" style="border-bottom: 1px solid #CCCCCC; color: #666666;
        height: 3px; padding-bottom: 20px; padding-left: 11px; padding-top: 14px; width: 960px;">
        Missions
        <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
        List All Missions <span style="float: right; margin-right: 10px;">
            <asp:LinkButton Text="Create Mission" runat="server" ID="lnkCreateMission" OnClick="lnkCreateMission_Click"></asp:LinkButton></span>
    </div>
    <asp:UpdatePanel ID="updatePanelListMission" runat="server">
        <ContentTemplate>
            <div class="top_blue_miss" style="border-radius: 8px 8px 0 0; width: 956px;">
                <div class="left_blue_miss">
                    <img class="clock_miss" src="../images/menil.png" style="margin: 10px;">
                    <span class="activity_miss"><span style="color: #f1c50e; margin-right: 785px; float: left;
                        margin-top: 5px;">Mission List :</span> </span>
                </div>
                <div class="rgt_blue_miss">
                    <img src="../images/drop_arrow.png">
                </div>
            </div>
            <%--<div class="table_miss_list" style="border: 0;">--%>
            <div class="container" style="margin-top: 0px; margin-left: 0px;">
                <p>
                    <asp:GridView ID="grdMissionList" runat="server" AutoGenerateColumns="False" EmptyDataText="No Mission Added Yet !"
                        EmptyDataRowStyle-Font-Size="15px" EmptyDataRowStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Left" RowStyle-HorizontalAlign="Left" EmptyDataRowStyle-ForeColor="Red"
                        AllowPaging="false" Height="100%" Width="956px" AllowSorting="true" CellPadding="4"
                        Style="margin-left: 2px;" GridLines="None" OnRowCommand="grdMissionList_RowCommand"
                        OnPageIndexChanging="grdMissionList_PageIndexChanging" OnSorting="grdMissionList_Sorting"
                        OnRowDataBound="grdMissionList_RowDataBound">
                        <AlternatingRowStyle CssClass="alternateItemStyle" />
                        <HeaderStyle CssClass="subheaderStyle" Height="30px" VerticalAlign="Middle" />
                        <RowStyle CssClass="itemStyle" />
                        <Columns>
                      
                            <asp:TemplateField HeaderText="Invite" ItemStyle-Width="10px" HeaderStyle-Width="6%"
                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="checkboxitem">
                                <ItemTemplate>
                                <asp:HiddenField ID="HdnCrestedid" runat="server" Value='<%# Eval("Pk_created_by_user_Id") %>' />
                                    <asp:CheckBox ID="chkSelectedMissionid" runat="server" Style="float: right; padding-left: 19px;
                                        vertical-align: middle !important;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Underline="false" HeaderStyle-Width="10%"
                                FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Image ID="imgPublicPrivate" runat="server" />
                                    |
                                    <asp:Image ID="imgGroupIndividual" runat="server" />
                                    <ajaxCtrl:ModalPopupExtender ID="modalPopInviteOthers" runat="server" TargetControlID="chkSelectedMissionid"
                                        PopupControlID="pnlInviteOtherMembers" BackgroundCssClass="main_pop_up_box_miss"
                                        DropShadow="false" CancelControlID="btnCloseInviteOtherPopUp">
                                    </ajaxCtrl:ModalPopupExtender>
                                    <asp:Panel ID="pnlInviteOtherMembers" runat="server" Style="display: none;" CssClass="inner_box_pop_up">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="btnCloseInviteOtherPopUp" runat="server" Text="X" CssClass="close_img_pop_up"
                                                        Style="background: none repeat scroll 0 0 #000000; border: medium none navy;
                                                        border-radius: 30px 30px 30px 30px; color: #FFFFFF; float: left; font-family: arial;
                                                        font-size: 17px; margin-left: -46px; margin-top: -17px; padding: 2px !important;
                                                        position: absolute; width: 28px !important;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="heading_pop_up">
                                                        <asp:Label ID="lblMissionName1" runat="server" Text='<%# Eval("mission_CompleteName") %>'
                                                            CssClass="mission_for_othermembers" Style="font-size: 20px; font-weight: bold;
                                                            width: 95%; margin-bottom: 10px; text-align: left;"></asp:Label>
                                                        <asp:Label ID="lblMissionId" runat="server" Text='<%# Eval("Pk_Mission_id") %>' Style="display: none;"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="overflow: scroll; height: 200px; width: 470px;">
                                                        <asp:GridView ID="grdOtherCircleMembers" runat="server" OnRowDataBound="grdOtherCircleMembers_RowDataBound"
                                                            CssClass="gridViewMembersCircle" EmptyDataText="No Members yet in this circle !"
                                                            AutoGenerateColumns="false">
                                                            <RowStyle CssClass="itemStyle row_style" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-VerticalAlign="Middle" HeaderText="Check To Invite"
                                                                    HeaderStyle-CssClass="check_invite" HeaderStyle-Font-Underline="true" ItemStyle-Width="222px"
                                                                    ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkOtherMembers" runat="server" OnClick='<%# Eval("userid") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Member Name" HeaderStyle-Font-Underline="true" HeaderStyle-CssClass="check_invite"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMemberName" runat="server" Text='<%# Eval("MemberName") %>' Style="margin-left: 33px;
                                                                            padding-left: 3px; text-align: left; width: 313px;"></asp:Label>
                                                                        <asp:Label ID="lblMemberId" runat="server" Text='<%# Bind("userid") %>' Style="display: none;"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="pop_chkebox" />
                                                            <%--  <RowStyle CssClass="OtherMemberGridviewScrollItem" />--%>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtInvitationMessage" runat="server" TextMode="MultiLine" Style="height: 70px;
                                                        margin-left: 9px; margin-top: 13px; width: 450px;"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="dvUploaderInvitationMsg" runat="server" style="display: none;">
                                                        <asp:Panel ID="Panel11" CssClass="overlay" runat="server">
                                                            <asp:Panel ID="Panel21" CssClass="loader11" runat="server">
                                                                <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                                                                    Sending your invitation ...
                                                                </div>
                                                                <div style="float: left; margin-top: 17px; margin-left: -249px;">
                                                                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                                                                        top: 45%;" alt="Processing Request" />
                                                                </div>
                                                            </asp:Panel>
                                                        </asp:Panel>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="float: left; height: 27px; margin-left: 237px; margin-top: 14px; width: auto;">
                                                    <asp:Button ID="btnInvite" runat="server" Text="Invite Selected Members" OnClick="btnInvite_Click"
                                                        ForeColor="Black" OnClientClick="javascript:return ShowInvitation_ProgressBar(this.id);"
                                                        Style="background: none repeat scroll 0 0 #CCCCCC; border: 1px solid #777777;
                                                        border-radius: 3px 3px 3px 3px; color: #333333; float: left; font-family: arial;
                                                        font-size: 17px; margin-left: 32px; margin-right: 31px; margin-top: -3px; padding: 3px;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" SortExpression="mission_name" HeaderStyle-ForeColor="White"
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblMissionName" runat="server" Text='<%# Eval("mission_name") %>'
                                        Style="text-align: left;" ToolTip='<%# Eval("mission_CompleteName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created By" SortExpression="created_by" HeaderStyle-HorizontalAlign="Left"
                                HeaderStyle-Width="12%" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="lblcreated_by" runat="server" Text='<%# Eval("created_by") %>' Style="text-align: left;"
                                        ToolTip='<%# Eval("created_by") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DateCreated" SortExpression="date_created_on" HeaderStyle-ForeColor="White"
                                HeaderStyle-Width="12%">
                                <ItemTemplate>
                                    <asp:Label ID="lbldate_created_on" runat="server" Text='<%# Eval("date_created_on") %>'
                                        Style="text-align: left;" ToolTip='<%# Eval("date_created_on") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Target Date" SortExpression="deadline_date_set" HeaderStyle-ForeColor="White"
                                HeaderStyle-Width="12%">
                                <ItemTemplate>
                                    <asp:Label ID="lbldeadline_date_set" runat="server" Text='<%# Eval("deadline_date_set") %>'
                                        Style="text-align: left;" ToolTip='<%# Eval("deadline_date_set") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Today's Input" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="11%">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkTrackMission" runat="server" Text="Submit" CommandName="TrackMission"
                                        ImageUrl="~/images/submit.gif" ToolTip="Click To enter today's input" CommandArgument='<%# Eval("Pk_mission_id") + ";" + Eval("group_individual") + ";" + Eval("public_private")%>'>
                                    </asp:ImageButton>
                                    <asp:ImageButton ID="imgAskOptions" runat="server" ImageUrl="~/images/options.png"
                                        ToolTip="The target date has reached for this mission" CommandName="AskOptions"
                                        CommandArgument='<%# Eval("Pk_mission_id") %>' />
                                    <asp:Image ID="mission_accomplished" runat="server" Style="display: none;" ToolTip="This mission is Accomplished"
                                        ImageUrl="~/images/finished-work.png"></asp:Image>
                                    <asp:Image ID="imgMissionClosed" runat="server" Style="display: none;" ToolTip="This mission is Closed"
                                        ImageUrl="~/images/close-red.png"></asp:Image>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="History" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="11%"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkTrackHistory" runat="server" Text="Track" CommandName="TrackMissionHistory"
                                        ImageUrl="~/images/trackhistory.png" ToolTip="Track All your Inputs for this Mission"
                                        CommandArgument='<%# Eval("Pk_mission_id") %>'></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Progress" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="11%"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkCheckProgress" runat="server" Text="Daily Progress" CommandName="CheckProgress"
                                        ImageUrl="~/images/dailyprogress.png" ToolTip="Track your Progress for this Mission"
                                        CommandArgument='<%# Eval("Pk_mission_id") %>'></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <span style="color: #50514F; font-family: candara; font-size: 18px; font-weight: bold;
                                margin-top: 60px;">No Missions added yet. </span>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle BackColor="#F2F2F0" />
                    </asp:GridView>
                </p>
            </div>
            <%-- </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="updatePanelListMission">
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
