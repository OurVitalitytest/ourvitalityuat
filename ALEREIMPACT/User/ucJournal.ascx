<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJournal.ascx.cs" Inherits="ALEREIMPACT.User.ucJournal" %>
<div>
    <link href="../CSS/newstyle.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanelJoyrnal" runat="server">
        <ContentTemplate>
            <div class="center_journal">
                <div class="journal">
                    <h2 class="graph_head">
                        Journal :</h2>
                </div>
                <div class="inner_body_journal">
                    <div class="left_journal">
                        How are you feeling today?
                    </div>
                    <div class="mood_icon">
                        <asp:HiddenField ID="hdnMoodId" runat="server" />
                        <div id="dvExcellent" runat="server" class="vary_happy">
                            <asp:ImageButton ID="ImgBtnExcellent" runat="server" ImageUrl="~/images/veryhappy.png"
                                Style="margin-left: 22px;" OnClick="ImgBtnExcellent_Click" />
                            <span>Excellent</span></div>
                        <div id="dvHappy" runat="server" class="happy">
                            <asp:ImageButton ID="ImgBtnHappy" runat="server" ImageUrl="~/images/happy.png" Style="margin-left: 25px;"
                                OnClick="ImgBtnHappy_Click" />
                            <span>Happy</span></div>
                        <div id="dvOK" runat="server" class="ok">
                            <asp:ImageButton ID="ImgBtnOK" runat="server" ImageUrl="~/images/ok.png" Style="margin-left: 5px;"
                                OnClick="ImgBtnOK_Click" />
                            <span>Ok</span></div>
                        <div id="dvSad" runat="server" class="sad">
                            <asp:ImageButton ID="ImgBtnSad" runat="server" ImageUrl="~/images/sad.png" Style="margin-left: 9px;"
                                OnClick="ImgBtnSad_Click" />
                            <span>Sad</span></div>
                        <div id="dvAngry" runat="server" class="angry">
                            <asp:ImageButton ID="ImgBtnAngry" runat="server" ImageUrl="~/images/angry.png" Style="margin-left: 14px;"
                                OnClick="ImgBtnAngry_Click" />
                            <span>Angry</span></div>
                    </div>
                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Title Here" CssClass="title_hournal"></asp:TextBox>
                    <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Title"
                            ValidationGroup="a" ControlToValidate="txtTitle" Style="color: #FF0000; float: left;
                            font-family: arial; font-size: 14px; margin-left: 28px; margin-top: 8px;">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div style="float: left; margin-left: 30px;">
                        <asp:TextBox ID="txtContent" runat="server" Rows="4" Columns="50" CssClass="center_journal_text"
                            TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Content"
                            ValidationGroup="a" ControlToValidate="txtContent" Style="color: #FF0000; float: left;
                            margin-left: 1px; margin-top: 11px;"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="btnJournalSubmit" runat="server" CssClass="sumbit_journal" OnClick="btnJournalSubmit_Click"
                        ValidationGroup="a" />
                    <div style="float: left; height: 554px; margin-top: 5px; overflow-x: hidden; overflow-y: scroll; width:100%;">
                        <asp:Repeater ID="RpMoodDeatil" runat="server" OnItemDataBound="RpMoodDeatil_ItemDataBound"
                            OnItemCommand="RpMoodDeatil_ItemCommand">
                            <ItemTemplate>
                                <div class="post_comment_journal">
                                    <div class="headin_pst_left">
                                        <asp:HiddenField ID="hdnJournalId" runat="server" Value='<%#Eval("JOURNAL_ID") %>' />
                                        <asp:HiddenField ID="hdnUserid" runat="server" Value='<%#Eval("fk_user_registration_id") %>' />
                                        <asp:Label ID="lbTitle" runat="server" Text='<%#Eval("JOURNAL_TITLE") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnMood" runat="server" Value='<%#Eval("MOOD_ID_FK") %>' />
                                        <asp:Image ID="ImgMood" runat="server" Style="border-width: 0; height: 19px; width: 19px;"  />
                                    </div>
                                    <div class="rgt_date_icon">
                                        <asp:Label ID="Label1" runat="server" Text="Date: "></asp:Label>
                                        <asp:Label ID="lbDAte" runat="server" Text='<%#Eval("JOURNAL_DATE") %>'></asp:Label>
                                         <asp:Label ID="lbTime" runat="server" Text='<%#Eval("time") %>'></asp:Label>
                                    </div>
                                    <asp:ImageButton ID="ImgDelete" runat="server" CssClass="cross_journal" ImageUrl="~/images/crossJournal.png"
                                        CommandName="ImgBtnDelete" CommandArgument='<%#Eval("JOURNAL_ID") %>' />
                                    <div class="des_journal_tex">
                                        <asp:Label ID="lbContent" runat="server" Text='<%#Eval("JOURNAL_CONTENT") %>'></asp:Label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
