<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LibraryInspirators.ascx.cs"
    Inherits="ALEREIMPACT.User.LibraryInspirators" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style>
    *
    {
        margin: 0;
        padding: 0;
    }
    .container
    {
        width: 992px;
        height: 860px;
        margin: 6px auto;
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
    /* if both the vertical and the horizontal bars appear, then perhaps the right bottom corner also needs to be styled */.jspPane
    {
        margin-left: 13px !important;
        margin-top: -35px;
        position: absolute;
    }
    .tab_mission_runtime div div
    {
        margin-left: 0px;
    }
</style>
<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div>
    <asp:UpdatePanel ID="UpdateLibInspirator" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <div class="top_his_miss" style="border-bottom: 1px solid #CCCCCC; color: #666666;
                    margin: 1px auto; padding-bottom: 20px; width: 970px;padding-top: 14px; height: 6px;">
                    <a href="Inspirators.aspx" style="color: #666666; margin-left: 16px; font-family: Arial;
                        font-size: 12px; text-decoration: none;">Inspirators</a>
                    <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
                    <span style="color: #53AFB0; font-family: arial; font-size: 12px;">My Library</span>
                </div>
                <div style="float: right; margin-bottom: 19px; margin-left: -55px; margin-right: 30px;
                    margin-top: -37px;">
                    <span style="float: left; font-family: arial; font-size: 13px; padding: 5px 20px 0 16px;
                        color: Black;">Choose an option :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Style="border: 1px solid #50514F; color: #50514F; width: 172px;">
                        <asp:ListItem Value="1" Text="All Inspirators"></asp:ListItem>
                        <asp:ListItem Value="2" Text="My Library"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <tr>
                    <td id="tdREc" runat="server" style="color: Gray; text-align: center; display: none;
                        margin-left: 350px; line-height: 30px;">
                        <asp:Label ID="lbNorecord" runat="server" Visible="false" Style="color: #50514F;
                            float: left; font-family: candara; font-size: 18px; font-weight: bold; line-height: 37px;
                            margin-left: 300px; margin-top: 15px;"></asp:Label>
                    </td>
                    <td>
                        <div class="mission_main_box4" style="vertical-align: top; text-align: justify; margin-left: 8px;">
                            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand"
                                Style="vertical-align: top;">
                                <ItemTemplate>
                                    <div class="mission_box" style="margin-right: 10px;">
                                        <table style="vertical-align: text-top; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hdnUserid" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                                    <asp:HiddenField ID="hdnInspiratorid" runat="server" Value='<%#Eval("pk_Inspirator_id") %>' />
                                                    <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("Inspirator_image") %>' />
                                                    <asp:ImageButton ID="ImageButton2" class="mission_thumb_img" runat="server" Style="height: 250;
                                                        width: 200px; float: left; padding-left: 5px;" ImageAlign="Top" CommandName="PopUp"
                                                        CommandArgument='<%#Eval("pk_Inspirator_id") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <p style="margin-left: 7px; padding-left: 7px; width: 202px;">
                                                        <asp:Label ID="lbDesc" runat="server" Text='<%#Eval("Inspirator_desc") %>' Style="color: #000000;
                                                            font-family: arial !important; font-size: 13px; line-height: 16px; margin-top: 7px;
                                                            padding-bottom: 5px; padding-right: 2px; text-align: justify; word-wrap: break-word;"></asp:Label></p>
                                                </td>
                                            </tr>
                                            <tr class="mission_btm_cont" valign="top" style="height: 30px;">
                                                <td style="float: left; margin-right: 17px; margin-top: 6px;">
                                                    <asp:Label ID="lbLikeCount" runat="server" Text="" class="mission_txt_conut"></asp:Label>
                                                    <asp:LinkButton ID="lnkLike" runat="server" Text="" class="mission_txt_conut" Style="margin-left: 4px;"
                                                        CommandName="Like" CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
                                                </td>
                                                <td style="float: left; margin-right: 19px; margin-top: 6px;">
                                                    <asp:Label ID="lbCommentCount" runat="server" Text="" class="mission_txt_conut"></asp:Label>
                                                    <asp:LinkButton ID="lnkComment" runat="server" class="mission_txt_conut" Text="Comments"
                                                        Style="margin-left: 4px;" Enabled="false" CommandName="Comment" CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkViewMore" runat="server" Text="View More" Style="color: #53AFB0;
                            float: right; font-size: 20px; font-weight: bold; padding-right: 113px; text-decoration: underline;"
                            OnClick="lnkViewMore_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
            <div style="display: none;">
                <asp:ImageButton ID="dummy" runat="server" ImageUrl="" Style="color: white; border: 0px;" /></div>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath=""
                Enabled="True" TargetControlID="dummy" PopupControlID="panel4" BackgroundCssClass="modalBackground"
                DropShadow="false" CancelControlID="Image3">
            </asp:ModalPopupExtender>
            <div id="panel4" runat="server" style="display: none; left: 159.5px; position: fixed;
                top: -63px !important; z-index: 100001;">
                <div class="ins_box_pop_up" style="height: 500px !important;">
                    <div class="close_img_pop_up1">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/close_btn111.png" Style="border-width: 0;
                            float: right;margin-top: -13px;margin-left: 733px !important;
    margin-top: -22px; " /></div>
                    <div class="heading_pop_up">
                        Inspirator's Description
                    </div>
                    <div class="ins_popup">
                        <asp:Image ID="Image1" runat="server" Style="border-width: 0; float: left; height: 220px;
                            margin-left: 5px !important; margin-top: 33px !important; width: 220px;" /></div>
                    <div class="ins_text">
                        <span style="font-family: arial; font-weight: bold;">Posted By : &nbsp;
                            <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                        </span>
                        <br />
                        <asp:Label ID="lbDesc" runat="server" Text="" Style="word-wrap: break-word;"></asp:Label></div>
                    <div class="ins_like">
                        <asp:Label ID="lbLikeCount" runat="server" Text="" ToolTip="Like"></asp:Label>
                        <asp:LinkButton ID="lnkInspLike" runat="server" Text="" OnClick="lnkInspLike_Click"></asp:LinkButton></div>
                    <div class="ins_like">
                        <asp:Label ID="lbCommentCount" runat="server" Text=""></asp:Label>
                        <asp:LinkButton ID="lnkComments" runat="server" Enabled="false" Text="Comments" OnClick="lnkComments_Click"></asp:LinkButton></div>
                    <asp:Panel ID="PanelHS" runat="server" Visible="false">
                        <div class="ins_like">
                            <asp:ImageButton ID="ImageButton1" runat="server" Style="height: 15px; width: 15px;"
                                ImageUrl="~/images/flag_red.png" OnClick="ImageButton1_Click" ToolTip="Flag as Inappropriate"
                                OnClientClick="return confirm('Are you sure you want to flag this?')" /></div>
                        <div class="ins_like">
                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/pluss.png" Style="height: 15px;
                                width: 15px;" CausesValidation="false" AlternateText="Add To Library" ToolTip="Add To Library"
                                OnClick="ImageButton4_Click" /></div>
                    </asp:Panel>
                    <div class="ins_textarea">
                        <asp:TextBox ID="txtComments" runat="server" ValidationGroup="b" Style="height: 70px;
                            margin-left: 9px; margin-top: 13px; width: 450px;"></asp:TextBox></div>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Comment required"
                        ControlToValidate="txtComments" ValidationGroup="b" Style="float: left; padding-left: 10px;
                        padding-top: 8px;"></asp:RequiredFieldValidator>
                    <div class="ins_submit">
                        <asp:Button ID="btnComment" runat="server" Text="Comment" OnClick="btnComment_Click"
                            ValidationGroup="b" Style="background-color: #393B3A !important; border: medium none !important;
                            color: #FFFFFF;" />
                    </div>
                    <div id="divComments" runat="server" class="ins_comment_box" style="line-height: 12px !important;">
                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="ins_des_box">
                                    <div class="left_ins_comment">
                                        <asp:Label ID="lbCName" runat="server" Text='<%#Eval("first_name") %>'></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text=":"></asp:Label>
                                    </div>
                                    <div class="rgt_ins_comments" style="margin-top: -5px !important; line-height: 18px !important;">
                                        <asp:Label ID="lbCDesc" runat="server" Text='<%#Eval("InspiratorComment_text") %>'
                                            Style="word-wrap: break-word; float:left;"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="UpdateLibInspirator">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div>
          
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" />
                </asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
