<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdminMessagesNew.ascx.cs"
    Inherits="ALEREIMPACT.User.ucAdminMessagesNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript" src="../js/Scroll.js"></script>

<script type="text/javascript">
    function parentwindow3() {

        window.parent.location.href = "Wall.aspx";
    }
</script>

<script type="text/javascript">

    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
</script>

<script type="text/javascript">
    function parentwindow() {

        window.parent.location.href = "Wall.aspx";
    }
</script>

<style type="text/css">
    .cls
    {
        margin-left: 10px;
    }
    .divmsgactive:active
    {
        background: #000000 !important;
    }
    .table-data_grd1 td
    {
        background: none repeat scroll 0 0 #FAF9F9;
        border: 1px solid #ECEAEA !important;
        float: left;
        height: 76px;
        margin-top: 15px;
        padding: 5px;
        width: 99%;
    }
	#ucAdminMessagesNew_panelRequestedUnresc table{ width: 100%;}
		#ucAdminMessagesNew_panelRequestedUnresc div{ width: 100%;}
		#ucAdminMessagesNew_GridView6_ctl02_lblMsg{ float: right;
    font-size: 13px;
    font-weight: bold;
    width: 243px !important;}
	
.table-data_grd_msg td:hover {
    background: none repeat scroll 0 0 #EEEEEE;
}
</style>
<div>
    <asp:HiddenField ID="keep" runat="server" Value="0" />
    <asp:UpdatePanel ID="updatePanelMessage" runat="server">
        <ContentTemplate>
            <div class="top_his_miss" style="border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC;
                border-right: 1px solid #CCCCCC; color: #666666; float: left; margin: 7px auto 0 5px;
                padding-bottom: 21px; width: 968px;">
                <table border="0" cellpadding="0" cellspacing="0" style="background: none repeat scroll 0 0 #FFFFFF;
                    border: 1px solid #CCCCCC; border-radius: 5px 5px 5px 5px; clear: both; float: left;
                    margin-top: 16px; padding: 5px; width: 968px;">
                    <div class="bread_miss" style="height: 12px;">
                        <span class="mission_miss" style="color: #555555; float: left; font-family: arial;
                            font-size: 16px; font-weight: bold; margin-top: 7px; padding-left: 25px;">Messages</span>
                    <tr>
                        <td>
                            <div id="scrollArea" önscroll="SetDivPosition()" runat="server" style="float: left;
                                font-size: 11px; overflow: scroll; overflow-x: hidden; height: 559px; line-height: 15px;
                                border-radius: 5px 5px 5px 5px; width: 269px;">
                                <asp:Label ID="lbNoMsg" runat="server" Text="No message found.." Visible="false"></asp:Label>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table-data_grd_msg"
                                    ShowHeader="false" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="lnkMessage" CommandArgument='<%#Eval("PostedMessageIDByAdmin")+"," +Eval("sender_name")+","+Eval("request_id") %>'
                                                    Style="text-decoration: none !important">
                                                    <div id="divMsg" runat="server" style="height: 35px; padding: 15px;" class="divmsgactive">
                                                        <asp:Label ID="lbHiddenId" runat="server" Text='<%#Eval("request_id") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("sender_name") %>' Style="font-size: 14px;
                                                            font-weight: bold;"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="LBID" runat="server" Text='<%#Eval("PostedMessageIDByAdmin") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("PostedMessageByAdmin") %>' Style="color: gray;"></asp:Label>
                                                        &nbsp;
                                                        <br />
                                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("PostedMessageOn") %>' Style="padding-left: 145px;"></asp:Label>
                                                    </div>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <span>No Messages Found..</span>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                            <asp:Panel ID="PanelReply" runat="server" Visible="false" Style="float: left; margin-top: 99px;
                                text-align: center;">
                                <asp:Label ID="Label21" runat="server" Text="No message found.." Visible="false"
                                    Style="color: #8E8E8E; padding-left: 287px; font-size: 14px; font-weight: bold;"></asp:Label>
                                <asp:Label ID="Label8" runat="server" Text="Please select message to see content"
                                    Style="color: #8E8E8E; padding-left: 160px; font-size: 14px; font-weight: bold;"></asp:Label>
                            </asp:Panel>
                            <div style="float: left; margin-left: 6px; width: 673px;">
                                <asp:Panel ID="Panel1" runat="server" Visible="false" Style="width: 674px; font-family: Arial;
                                    font-size: 12px;">
                                    <div style="margin-left: 17px; background-color: #FBFBFB; color: #151515; line-height: 15px;
                                        margin-bottom: 19px; padding: 15px 2px 5px 8px;">
                                        <asp:Label ID="lbmsg" runat="server" Text=""></asp:Label>
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                            GridLines="None" Style="width: 634px; border: medium none !important;">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text="Alere Vitality" Style="float: left; font-size: 14px;
                                                            font-weight: bold;"></asp:Label>
                                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("PostedMessageOn") %>' Style="float: right;
                                                            width: 111px;"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("GM_MESSAGE") %>' Style="font-size: 14px;
                                                            font-family: Arial;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <hr style="color: #CCCCCC; margin-left: 15px; margin-top: -13px; width: 664px;" />
                                    <div style="background-color: #F2F2F0; overflow: scroll; overflow-x: hidden; float: left;
                                        margin-left: 25px; margin-top: 16px;">
                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" Style="width: 634px;
                                            line-height: 14px; border: medium none !important;" ShowHeader="false" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("name") %>' Style="float: left;
                                                            font-size: 14px; font-weight: bold; margin-left: 9px; margin-top: 7px;"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("ReplyMessage") %>' Style="float: left;
                                                            font-size: 14px; margin-left: -38px; margin-top: 13px; width: 465px;"></asp:Label>
                                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("RepliedOn") %>' Style="float: right;
                                                            width: 111px;"></asp:Label>
                                                        <hr style="color: #CCCCCC; margin-left: 1px; margin-top: 38px; width: 663px;" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                No Reply Found....
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                    <div id="divreply" runat="server" style="float: left; display: none; margin-top: 30px;">
                                        <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Style="border: 1px solid #B8B8B8;
                                            border-radius: 5px 5px 5px 5px; float: left; height: 63px; margin-left: 26px;
                                            margin-right: 9px; width: 570px;"></asp:TextBox>
                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark_class"
                                            TargetControlID="txtReply" WatermarkText="Write a reply">
                                        </asp:TextBoxWatermarkExtender>
                                        <asp:Button ID="btnReply" runat="server" Text="Reply" CssClass="post" Style="height: 35px;
                                            margin-top: 12px; padding-left: 1px; padding-top: 4px; width: 67px;" OnClick="btnReply_Click"
                                            ValidationGroup="a" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAppForm" runat="server" Style="float: left;
                                            font-size: 14px; margin-left: 35px; margin-top: 15px;" ErrorMessage="Enter Reply"
                                            Display="Dynamic" ControlToValidate="txtReply" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="PanelMissionInvitation" runat="server" Visible="false" Style="border: none !important;">
                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" CssClass="table-data_grd1"
                                        ShowHeader="false" OnRowCommand="GridView4_RowCommand" OnRowDataBound="GridView4_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div style="float: left; line-height: 5px; margin-bottom: 7px; margin-left: 5px;
                                                                    margin-top: 5px;">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("pk_tblMission_Invitations_Id") %>'
                                                                        Visible="false"></asp:Label>
                                                                    <asp:Image ID="Image2" runat="server" Style="height: 20px; float: left; width: 20px;
                                                                        margin-top: -8px;" ImageUrl="~/images/Places-mail-message-icon.png" />
                                                                    <asp:Label ID="lbMsg12" runat="server" Text="Mission Invitation to join mission"
                                                                        Style="float: left; font-family: arial; font-size: 14px; margin-bottom: 26px;
                                                                        margin-left: 7px; margin-top: -2px;"></asp:Label>
                                                                    <br />
                                                                    <br />
                                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("inivitation_message") %>' Style="font-family: Arial;
                                                                        font-size: 14px;"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="margin-left: 60px; font-family: Arial;">
                                                        <tr>
                                                            <td>
                                                                <div style="float: left; margin-left: 6px; margin-top: 5px; margin-bottom: 5px;">
                                                                    <asp:Label ID="Label12" runat="server" Text="Invited By :" Style="font-size: 14px;
                                                                        margin-right: 48px;"></asp:Label>
                                                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("name") %>' Style="font-size: 14px;"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="margin-bottom: 6px; margin-left: 6px; margin-top: 8px;">
                                                                    <asp:Label ID="Label13" runat="server" Text="Invited On :" Style="font-size: 14px;
                                                                        margin-right: 45px;"></asp:Label>
                                                                    <asp:Label ID="Label14" runat="server" Text='<%#Eval("invited_on") %>' Style="font-size: 14px;"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="float: left; margin-bottom: 6px; margin-left: 6px; margin-top: 5px;">
                                                                    <asp:Label ID="Label15" runat="server" Text="Circle Name :" Style="font-size: 14px;
                                                                        margin-right: 36px;"></asp:Label>
                                                                    <asp:Label ID="Label16" runat="server" Text='<%#Eval("circle_name") %>' Style="font-size: 14px;"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="float: left; margin-bottom: 19px; margin-left: 6px; margin-top: 8px;">
                                                                    <asp:Label ID="Label17" runat="server" Text="Mission Name :" Style="font-size: 14px;
                                                                        margin-right: 24px;"></asp:Label>
                                                                    <asp:Label ID="Label18" runat="server" Text='<%#Eval("mission_name") %>' Style="font-size: 14px;"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="float: left; margin-bottom: 21px; margin-left: 13px; margin-top: 11px;">
                                                                    <asp:LinkButton ID="lnkAcceptInvitation" runat="server" Text="Accept" OnClientClick="return confirm('Are you sure you want to Accept invitation to join this mission ?');"
                                                                        CommandName="AcceptInvitation" Style="background-color: #006600; border: 1px solid #006600;
                                                                        border-radius: 20px 20px 20px 20px; color: #FFFFFF; float: left; font-size: 18px;
                                                                        height: 14px; margin-right: 21px; padding-left: 13px; padding-top: 11px; width: 69px;
                                                                        font-family: Arial;"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkRejectInvitation" runat="server" OnClientClick="return confirm('Are you sure you want to Reject this invitation ?');"
                                                                        Text="Reject" CommandName="RejectInvitation" Style="background-color: #FF0000;
                                                                        border: 1px solid #FF0000; border-radius: 20px 20px 20px 20px; color: #FFFFFF;
                                                                        float: left; font-size: 18px; height: 14px; margin-right: 21px; padding-left: 13px;
                                                                        padding-top: 13px; width: 69px; font-family: Arial;"></asp:LinkButton>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Arrow-Right-icon.png" Visible="false"
                                                                        Style="height: 20px; width: 20px;" />
                                                                    <asp:Label ID="lbmsg" runat="server" Text="" Style="font-family: arial; color: red;
                                                                        font-size: 19px;"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Panel ID="PanelRequested" runat="server">
                                    <div style="float: left;">
                                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" CssClass="table-data_grd1"
                                            ShowHeader="false" OnRowCommand="GridView5_RowCommand" OnRowDataBound="GridView5_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div style="float: left; line-height: 5px; margin-bottom: 7px; margin-left: 5px;
                                                                        margin-top: 5px;">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("pk_user_friend_id") %>' Visible="false"></asp:Label>
                                                                        <asp:Image ID="Image2" runat="server" Style="height: 20px; width: 20px; margin-top: -8px;"
                                                                            ImageUrl="~/images/Places-mail-message-icon.png" />
                                                                        <br />
                                                                        <br />
                                                                        <br />
                                                                        <asp:Label ID="Label19" Visible="false" runat="server" Text='<%#Eval("name") %>'
                                                                            Style="font-size: 14px; font-family: Arial; text-transform: capitalize;"></asp:Label>
                                                                        <asp:Label ID="Label10" runat="server" Text="Request to join circle" Style="font-family: Arial;
                                                                            font-size: 16px; font-weight: bold;"></asp:Label>
                                                                        <asp:Label ID="Label20" Visible="false" runat="server" Text='<%#Eval("circle_name") %>'
                                                                            Style="font-size: 14px;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <br />
                                                        <table style="margin-left: 60px; font-family: Arial;" border="1">
                                                            <tr>
                                                                <td>
                                                                    <div style="float: left; margin-left: 6px; margin-top: 5px; margin-bottom: 5px;">
                                                                        <asp:Label ID="Label12" runat="server" Text="Requested By :" Style="font-size: 14px;
                                                                            margin-right: 48px;"></asp:Label>
                                                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("name") %>' Style="font-size: 14px;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="margin-bottom: 6px; margin-left: 6px; margin-top: 8px;">
                                                                        <asp:Label ID="Label13" runat="server" Text="Requested On :" Style="font-size: 14px;
                                                                            margin-right: 44px;"></asp:Label>
                                                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("invited_on") %>' Style="font-size: 14px;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="float: left; margin-bottom: 6px; margin-left: 6px; margin-top: 5px;">
                                                                        <asp:Label ID="Label15" runat="server" Text="Circle Name :" Style="font-size: 14px;
                                                                            margin-right: 60px;"></asp:Label>
                                                                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("circle_name") %>' Style="font-size: 14px;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="float: left; margin-bottom: 21px; margin-left: 13px; margin-top: 11px;">
                                                                        <asp:LinkButton ID="lnkAcceptInvitation" runat="server" Text="Accept" OnClientClick="return confirm('Are you sure you want to Accept Request?');"
                                                                            CommandName="AcceptInvitation" CommandArgument='<%#Eval("pk_user_friend_id") %>'
                                                                            Style="background-color: #006600; border: 1px solid #006600; border-radius: 20px 20px 20px 20px;
                                                                            color: #FFFFFF; float: left; font-size: 18px; height: 14px; margin-right: 21px;
                                                                            padding-left: 13px; padding-top: 11px; width: 69px;"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkRejectInvitation" runat="server" OnClientClick="return confirm('Are you sure you want to Reject Request ?');"
                                                                            Text="Reject" CommandName="RejectInvitation" CommandArgument='<%#Eval("pk_user_friend_id") %>'
                                                                            Style="background-color: #FF0000; border: 1px solid #FF0000; border-radius: 20px 20px 20px 20px;
                                                                            color: #FFFFFF; float: left; font-size: 18px; height: 14px; margin-right: 21px;
                                                                            padding-left: 13px; padding-top: 13px; width: 69px;"></asp:LinkButton>
                                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Arrow-Right-icon.png" Visible="false"
                                                                            Style="height: 20px; width: 20px;" />
                                                                        <asp:Label ID="lbmsg" runat="server" Text="" Style="font-family: cursive; color: red;
                                                                            font-size: 19px;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="panelRequestedUnresc" runat="server">
                                    <div style="float: left;">
                                        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" CssClass="table-data_grd1"
                                            OnRowCommand="GridView6_RowCommand" OnRowDataBound="GridView6_RowDataBound" ShowHeader="false">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label22" runat="server" Text='<%#Eval("CI_ID") %>' Visible="false"
                                                            Style="float: left; font-size: 14px; font-weight: bold;"></asp:Label>
                                                        <asp:Image ID="Image2" runat="server" Style=" border-width: 0;
    float: left;    height: 16px;    margin-left: 10px;    margin-top: 8px;    width: 16px;" ImageUrl="~/images/Places-mail-message-icon.png" />
                                                        <asp:Label ID="Label24" runat="server" Style="float: left; font-family: Arial; font-size: 14px;
                                                            margin-top: 8px; margin-left: 5px;"></asp:Label>
                                                        <div style="float: left; width: 585px;">
                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("name") %>' Style="float: left;
                                                                font-size: 14px; font-weight: bold; margin-left: 8px; margin-top: 14px;"></asp:Label>
                                                            <span style="  float: left;    font-size: 14px;    margin-left: 10px;    margin-top: 13px;">would like you to join his/her public circle ,</span>
                                                            <asp:LinkButton ID="Label23" runat="server" Text='<%#Eval("circle_name") %>' Style=" color: #555555;    float: left;    font-family: Arial;    font-size: 14px;    font-weight: bold;    margin-left: 5px;  margin-top: 13px;"
                                                                CommandArgument='<%# Eval("fk_user_registration_Id") + ";" + Eval("fk_circle_id")%>'
                                                                CommandName="RedirectToCircle"></asp:LinkButton>
                                                        </div>
                                                        <div style="float: right; margin-top: 8px;">
                                                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("CI_DATE") %>' Style="float: right;
                                                                display: none; width: 111px;"></asp:Label>
                                                        </div>
                                                        <div style="clear: both; float: left; margin-left: 20px; margin-top: 30px;">
                                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("CI_MESSAGE") %>' Style="float: left;
                                                                display: none; font-family: Arial; font-size: 14px; margin-left: 0px;"></asp:Label>
                                                         </div>
                                                         <asp:Label ID="lblMsg" runat="server" Visible="false" Text="You have already joined this circle."></asp:Label>
                                                         <asp:Label ID="lblCircleId" runat="server" Text='<%#Eval("fk_circle_id") %>' style="display:none;"></asp:Label>
                                                        <asp:Button ID="btnJoin" runat="server" Text="Join" OnClientClick="return confirm('Are you sure you want to Accept invitation to join this circle ?');"
                                                            CommandName="Accept" Style=" background-color: #0C7A75;
    border: medium none;
    color: #FFFFFF;
    cursor: pointer;
    float: right;
    height: 31px;
    margin-right: 16px;
    margin-top:-24px;
    width: 82px;" CommandArgument='<%# Eval("fk_user_registration_Id") + ";" + Eval("fk_circle_id")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            </div>
            <div id="dvUploader" runat="server" style="display: none;">
                <asp:Panel ID="Panel11" CssClass="overlay" runat="server">
                    <asp:Panel ID="Panel21" CssClass="loader11" runat="server">
                        <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                            Processing...
                        </div>
                        <div style="float: left; margin-top: 17px; margin-left: -249px;">
                            <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                                top: 45%;" alt="Processing Request" />
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReply" />
        </Triggers>
    </asp:UpdatePanel>
</div>
