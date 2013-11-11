<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdminPostedMessage.ascx.cs"
    Inherits="ALEREIMPACT.User.ucAdminPostedMessage" %>
<style type="text/css">
    .box_text_messages
    {
        background: url("../images/first_box.png") repeat scroll 0 0 transparent;
        float: left;
        height: 96px;
        margin-left: -681px;
        margin-top: 56px;
        width: 980px;
    }
</style>
<asp:UpdatePanel ID="updatePanelWall" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <div class="center_section_mission">
                        <div class="tooltip" id="dvEmptyMessage" runat="server" visible="false" style="line-height: 30px">
                            Hi,
                            <br />
                            No Messages from Administrator have been posted yet.
                        </div>
                        <asp:GridView ID="grdPostedMessages" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdPostedMessages_RowDataBound"
                            OnRowCommand="grdPostedMessages_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="main_cmnt_box">
                                            <div class="box_text_messages">
                                                <div class="box_text_thumb">
                                                    <div class="mission_text">
                                                        <span class="heading_mission">
                                                            <asp:Label ID="lblPostedBy" runat="server" Text='<%#Eval("PostedMessageByAdmin")%>'></asp:Label></span>
                                                    </div>
                                                    <ul class="list_mission" id="dvMajorCommentOptions" runat="server">
                                                        <asp:Panel ID="dvPostSubComment" runat="server" Visible="false">
                                                            <asp:TextBox ID="txtReply" runat="server" Width="600px" MaxLength="120" Style="border: #FFFFFF;
                                                                color: #999999; font-size: 14px;" Text="your comments.." onblur="if (this.value == '') {this.value = 'your comments..';}"
                                                                onfocus="if (this.value == 'your comments..') {this.value = '';}" onkeypress="return handleSubComment(this,event)"></asp:TextBox>
                                                            <asp:Button ID="btnPostSubComment" runat="server" Text="Post" CommandName="ReplyComment"
                                                                Style="border-radius: 4px 4px 4px 4px; height: 20px; margin-top: 8px; padding-left: 0px;
                                                                padding-top: 0px; width: 37px; color: #1F7071; border: none; font-size: 11px;
                                                                background: #54A4A5;" OnClientClick="return postSubComment(this);" CommandArgument='<%#Eval("PostedMessageIDByAdmin")%>' />
                                                            <asp:ImageButton ID="imgCloseSubCommentBox" runat="server" ImageUrl="~/images/delete_button.gif"
                                                                CommandName="CloseSubCommentBox" Width="20px" Height="20px" />
                                                        </asp:Panel>
                                                        <div id="dvPostSubCommentOnMajor" runat="server">
                                                            <li>
                                                                <asp:LinkButton ID="lnkPostReply" runat="server" Text="Reply" CommandName="ClikedToPostReply"></asp:LinkButton>
                                                                Posted On :
                                                                <asp:Label ID="lblDateofComment" runat="server" Text='<%#Eval("PostedMessageOn")%>'></asp:Label>
                                                            </li>
                                                        </div>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="box_open_mission" id="dvSubComment" runat="server">
                                                <asp:GridView ID="grdSubComments" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <div class="mission_text2">
                                                                    <span class="heading_mission1">
                                                                        <asp:Label ID="lblSubComments" runat="server" Text='<%#Eval("ReplyMessage")%>'></asp:Label>
                                                                </div>
                                                                <ul class="list_mission1">
                                                                    <li class="like_btn">Replied On:
                                                                        <asp:Label ID="lblDateofSubComment" runat="server" Text='<%#Eval("RepliedOn")%>'></asp:Label>
                                                                    </li>
                                                                </ul>
                                                                </span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
