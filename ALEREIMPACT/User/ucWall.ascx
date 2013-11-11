<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucWall.ascx.cs" Inherits="ALEREIMPACT.User.ucWall" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link rel="stylesheet" type="text/css" href="../js/jscrollpane.css" />
<!-- latest jQuery direct from google's CDN -->

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

<!-- the jScrollPane script -->
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

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
        width: 992px;
        height: 792px;
        margin: 20px auto;
        overflow: auto; /* showing scrollbars */
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
    function bind() {
        $('.container').jScrollPane();




    }
</script>

<script language="javascript" type="text/javascript">

    function handleSubComment(selectedId, e) {

        var newSubCommentBtnId = selectedId.id.replace('txtSubComments', 'btnPostSubComment');

        if (e.keyCode == 13) {
            if (document.getElementById(selectedId.id).value != "") {
                document.getElementById(newSubCommentBtnId).click();
                document.getElementById(selectedId.id).value = "";
                document.getElementById(selectedId.id).value = "Whats on your mind?";
                e.preventDefault();
            }
            else {
                alert('You must enter some text in the sub comment box !');
                return false;
            }
        }
    }

    function postSubComment(selBtnId) {
        var newSubCommenttxtBtnId = selBtnId.id.replace('btnPostSubComment', 'txtSubComments');

        if (document.getElementById(newSubCommenttxtBtnId).value == "Add a comment..") {
            alert('You must enter some text in the comment box !');
            return false;
        }

    }
    function postComment() {

        if (document.getElementById('MssionsTab_txtPostComments').value == "Whats on your mind?" || document.getElementById('MssionsTab_txtPostComments').value == "") {
            document.getElementById('MssionsTab_txtPostComments').focus();
            alert('You must enter some text in the comment box !');
            return false;
        }
    }
    function handle(e) {

        if (e.keyCode == 13) {
            if (document.getElementById('MssionsTab_txtPostComments').value != "") {
                document.getElementById('MssionsTab_btnPostComments').click();
                document.getElementById('MssionsTab_txtPostComments').value = "";
                document.getElementById('MssionsTab_txtPostComments').value = "Whats on your mind?";
                e.preventDefault();
            }
            else {
                alert('You must enter some text in the comment box !');
                return false;
            }
        }
    }
</script>

<div>
    <asp:UpdatePanel ID="updatePanelWallNotes" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <div class="white_text_area" id="dvpostcomments" runat="server">
                    <asp:TextBox ID="txtPostComments" Style="height: 25px; width: 865px;" runat="server"
                        MaxLength="400" Text="Whats on your mind?" onblur="if (this.value == '') {this.value = 'Whats on your mind?';}"
                        onfocus="if (this.value == 'Whats on your mind?') {this.value = '';}" onkeypress="return handle(event)">
                    </asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnPostComments" runat="server" Text="Post" OnClick="btnPostComments_Click"
                        OnClientClick="return postComment(this);" CssClass="post" Style="border: medium none;
                        border-radius: 9px 9px 9px 9px; height: 46px; margin-top: 19px; padding-left: 0;
                        padding-top: 0; width: 81px;" />
                </div>
                <div class="center_section_mission" id="dvWall" runat="server">
                    <div class="tooltip" id="welcomemsg" runat="server" visible="false" style="line-height: 30px">
                        Hi,
                        <asp:Label ID="lbUsrFirstName" runat="server"></asp:Label>
                        <br />
                        Welcome to <span>"</span><asp:Label ID="lbwelcomecircle" runat="server"></asp:Label><span>"</span>
                        space
                        <br />
                        You can post your comment(s) for this circle
                        <br />
                        <asp:LinkButton ID="lnkInvite" runat="server" Text="Let's start inviting Members for this circle"
                            Style="color: #0C7A75 !important;" OnClick="lnkInvite_Click"></asp:LinkButton>
                        <div class="arrow">
                        </div>
                    </div>
                    <div class="tooltip" id="dvmember" runat="server" visible="false" style="line-height: 30px">
                        Hi,
                        <asp:Label ID="lbUserMemberName" runat="server"></asp:Label><br />
                        Welcome to <span>"</span><asp:Label ID="lbwelcomemembercircle" runat="server"></asp:Label><span>"</span>
                        space
                        <br />
                        No notes has been posted yet
                    </div>
                    <div class="tooltip" id="DivOtherCircle" runat="server" visible="false" style="line-height: 30px">
                        Hi, You need to join this circle before posting comments.
                        <div class="arrow">
                        </div>
                    </div>
                    <div class="container">
                        <p>
                            <asp:GridView ID="grdComments" runat="server" OnRowDataBound="rptComments_RowDataBound"
                                AutoGenerateColumns="false" OnRowCommand="grdComments_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="main_cmnt_box">
                                                <div class="box_text">
                                                    <div class="box_text_thumb">
                                                        <asp:Label ID="lbUserid" runat="server" Text='<%#Eval("PrimaryKeyOfUser") %>' Visible="false"></asp:Label>
                                                        <asp:ImageButton ID="imgCommentSenderImage" runat="server" CommandName="MemberProfile"
                                                            CommandArgument='<%#Eval("PrimaryKeyOfUser") %>' CssClass="avatar" Style="border-width: 1px !important;
                                                            cursor: pointer;" /></div>
                                                    <div class="mission_text">
                                                        <span class="heading_mission">
                                                            <asp:Label ID="lblPostedBy" runat="server" Text='<%#Eval("UserName")%>'></asp:Label></span>
                                                        <span class="heading_desc"></span>
                                                        <asp:Label ID="lblMajorComments" runat="server" Text='<%#Eval("Comments")%>'></asp:Label>
                                                        </span>
                                                    </div>
                                                    <ul class="list_mission" id="dvMajorCommentOptions" runat="server">
                                                        <asp:Panel ID="dvPostSubComment" runat="server" Visible="false">
                                                            <asp:TextBox ID="txtSubComments" runat="server" Width="675px" MaxLength="260" Style="border: 1px solid #CCCCCC;
                                                                border-radius: 3px 3px 3px 3px; color: #999999; float: left; font-size: 14px;
                                                                height: 29px; line-height: 29px; margin-top: -4px; padding-left: 6px; width: 610px;"
                                                                Text="Add a comment.." onblur="if (this.value == '') {this.value = 'Add a comment..';}"
                                                                onfocus="if (this.value == 'Add a comment..') {this.value = '';}" onkeypress="return handleSubComment(this,event)"></asp:TextBox>
                                                            <asp:Button ID="btnPostSubComment" runat="server" Text="Post" CommandName="PostComment"
                                                                Style="background: none repeat scroll 0 0 #54A4A5; border: medium none; border-radius: 4px 4px 4px 4px;
                                                                color: #1F7071; float: left; font-size: 13px; height: 30px; margin-top: -3px;
                                                                padding-left: 0; width: 53px;" OnClientClick="return postSubComment(this);" CommandArgument='<%#Eval("PrimaryKeyOfComment")%>' />
                                                            <asp:ImageButton ID="imgCloseSubCommentBox" runat="server" ImageUrl="~/images/delete_button.gif"
                                                                CommandName="CloseSubCommentBox" Style="background: none repeat scroll 0 0 #FFFFFF;
                                                                border: 1px solid #CCCCCC; border-radius: 5px 5px 5px 5px; height: 20px; margin-top: -3px;
                                                                padding: 4px; width: 21px;" />
                                                        </asp:Panel>
                                                        <div id="dvPostSubCommentOnMajor" runat="server">
                                                            <li>
                                                                <asp:LinkButton ID="lnkLike" runat="server" CommandArgument='<%#Eval("PrimaryKeyOfComment")%>'
                                                                    Text="Like" CommandName="LikeComment"></asp:LinkButton>
                                                            </li>
                                                            <li>
                                                                <asp:LinkButton ID="lnkPostSubComment" runat="server" Text="Comment" CommandName="ClikedToPostSubComment"></asp:LinkButton>
                                                            </li>
                                                            <li>
                                                                <asp:ImageButton ID="lnkSupeLike" runat="server" ImageUrl="~/images/heart.png" ToolTip="Super Like"
                                                                    CommandName="lnkSuperlike" CommandArgument='<%#Eval("PrimaryKeyOfComment")%>'
                                                                    Style="float: right; margin: 0px 10px 0 0px;" />
                                                            </li>
                                                            <li class="like_btn" style="float: left; margin-left: 12px; margin-top: 11px;">
                                                                <asp:Label ID="lblDateofComment" runat="server" Text='<%#Eval("DateOfComment")%>'></asp:Label>
                                                            </li>
                                                        </div>
                                                    </ul>
                                                    <div class="thumb_mission">
                                                        <asp:Image ImageUrl="~/images/thumbs_up.png" runat="server" ID="imgThumbsUp" />
                                                        <asp:Label ID="lblCountLikes" runat="server" Style="font-weight: bold; font-size: 12px;"></asp:Label>
                                                        <asp:Image ImageUrl="~/images/heart.png" runat="server" ID="imgThumbSuper" Style="margin-left: 15px !important;
                                                            margin-top: 2px !important;" />
                                                        <asp:Label ID="lbSuperLike" runat="server" Style="font-weight: bold; font-size: 12px;"></asp:Label>
                                                        <asp:Image ImageUrl="~/images/count_subcomment.png" runat="server" ID="imgCountSubComments"
                                                            Height="20px" Style="margin-left: 10px;" />
                                                        <asp:Label ID="lblCountSubComments" runat="server" Style="font-weight: bold; font-size: 12px;"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="box_open_mission" id="dvSubComment" runat="server">
                                                    <asp:GridView ID="grdSubComments" runat="server" AutoGenerateColumns="false" OnRowCommand="grdSubComments_RowCommand"
                                                        OnRowDataBound="grdSubComments_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbIDIUser" runat="server" Text='<%#Eval("SubCommentPostedBy") %>'
                                                                        Visible="false"></asp:Label>
                                                                    <div class="box_text_thumb_small">
                                                                        <asp:Image ImageUrl="~/images/2nd_circle.png" ID="imgSubCommentSenderImage" CssClass="avatar"
                                                                            Style="border-width: 1px;" runat="server" />
                                                                    </div>
                                                                    <div class="mission_text2">
                                                                        <span class="heading_mission1">
                                                                            <asp:Label ID="lblPostedBy" runat="server" Text='<%#Eval("UserName")%>'></asp:Label></span>
                                                                        <asp:Label ID="lblSubComments" runat="server" Text='<%#Eval("SubComment")%>'></asp:Label>
                                                                    </div>
                                                                    <ul class="list_mission1" style="margin-top: 0;">
                                                                        <li class="like_btn">
                                                                            <asp:Label ID="lblDateofSubComment" runat="server" Text='<%#Eval("SubCommentTime")%>'></asp:Label>
                                                                        </li>
                                                                        <li>
                                                                            <asp:LinkButton ID="lnkLikeSubComment" runat="server" CommandArgument='<%#Eval("SubCommentID")%>'
                                                                                Text="Like" CommandName="LikeSubComment"></asp:LinkButton>
                                                                        </li>
                                                                        <li>
                                                                            <asp:Label ID="lblCountSubCommentsSuperLikes" runat="server" Style="margin: 0px 0 0 5px;
                                                                                font-size: 12px; float: right; font-weight: bold"></asp:Label>
                                                                            <asp:ImageButton ID="lnkSuperLikeSubComment" runat="server" CommandArgument='<%#Eval("SubCommentID")%>'
                                                                                ToolTip="Super Like" ImageUrl="~/images/heart.png" CommandName="SuperLikeSubComment"
                                                                                Style="float: right; margin: 2px 0 0;" />
                                                                        </li>
                                                                        <li>
                                                                            <asp:Image ImageUrl="~/images/thumbs_up.png" runat="server" ID="imgThumbsUpSubComments"
                                                                                Style="margin-top: 1px;" />
                                                                            <asp:Label ID="lblCountSubCommentsLikes" runat="server" Style="font-size: 12px; font-weight: bold"></asp:Label>
                                                                        </li>
                                                                    </ul>
                                                                    </span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Found.
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <table>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnkViewMore" Text="View More" runat="server" OnClick="lnkViewMore_Click"
                                            Style="float: left; font-size: 14px; margin-top: 10px;"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </p>
                    </div>
                </div>
                <asp:Image ImageUrl="~/images/spacer.gif" Height="0px" Width="18px" ID="imgFooterSpacer"
                    runat="server" BorderColor="Red" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPostComments" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="updatePanelWallNotes">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                        Processing...
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
