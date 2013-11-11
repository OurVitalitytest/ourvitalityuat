<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucInviteMembers.ascx.cs"
    Inherits="ALEREIMPACT.User.ucInviteMembers" %>
<%-- <script type="text/javascript">
        function txtrep() {

            var newtext = "Sending..";
            document.getElementById('<%#BtnInvite.ClientID %>').value = newtext;
        }
    </script>--%>
<div>
    <asp:UpdatePanel ID="updatepnlInviteMember" runat="server">
        <ContentTemplate>
            <div class="main_cont_miss">
                <div class="top_his_miss" style="height: 0; margin-top: 0 !important; padding-left: 11px !important;
                    padding-top: 17px; width: 951px !important;">
                    <div class="bread_miss">
                        <span class="mission_miss" style="font-size: 16px; margin-top: 4px; font-weight: bold;">
                            Invite Members </span><asp:Label ID="Label1" runat="server" Text="No Search Result Found.." Visible="false" style="   color: #616161; margin-left:246px;
    font-family: arial;
    font-size: 17px;"></asp:Label>
                        <div class="arrow_miss">
                        </div>
                    </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>
                <span style="font-size:16px; font-weight:bold; margin-top:10px; padding:82px 34px 82px 382px;" visible="false" id="sptips" runat="server" >Search Tips</span>
                <div style=" font-style:normal; font-size:16px; padding:13px 34px 82px 395px; display:none;" id="showtips" runat="server">
                  
                  <ul>
                  <li>Ensure Words are spelled correctly.</li>
                  <li>Try less specific Keywords</li>
                  <li>Make your queries as concise as possible.</li>
                  </ul>
                </div>
                <div style="float: left; height: 900px; overflow-x: hidden; overflow-y: scroll; margin-top: -15px; width: 961px;">
                
                   
                    <asp:Repeater ID="rptrFreindList" runat="server" OnItemDataBound="rptrFreindList_ItemDataBound"
                        OnItemCommand="rptrFreindList_ItemCommand">
                        <ItemTemplate>
                            <div style="border-bottom: 1px solid #CCCCCC; float: left; margin-top: 10px; padding-bottom: 12px;
                                width: 100%;">
                                <asp:HiddenField ID="hdnUserID" runat="server" Value='<%#Eval("pk_user_registration_Id") %>' />
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("user_image") %>' />
                                <div style="float: left; margin-left: 30px;">
                                    <%-- <asp:Image ID="ImgFreind" runat="server" Style="height: 100px; width: 100px;" />--%>
                                    <asp:ImageButton ID="ImgFreind" runat="server" Style="height: 100px; width: 100px;"
                                        CommandName="ImgFrendClick" CommandArgument='<%#Eval("pk_user_registration_Id") %>' />
                                </div>
                                <div style="float: left; margin-left: 50px; margin-top: 37px; line-height: 16px;">
                                    <asp:Label ID="lbNAme" runat="server" Text='<%#Eval("name") %>' Style="font-family: arial;
                                        font-size: 15px; text-transform: capitalize;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lbEMail" runat="server" Text='<%#Eval("login_email") %>' Visible="false"
                                        Style="font-family: arial; font-size: 14px;"></asp:Label>
                                </div>
                                <div style="float: right; margin-right: 105px; margin-top: 30px;">
                                    <asp:Label ID="lbPending" runat="server" Text="Approval Pending" Visible="false"
                                        Style="color: #0C7A75; font-family: arial; font-size: 14px; padding-right: 0px;"></asp:Label>
                                    <asp:Button ID="BtnInvite" runat="server" Text="Invite" OnClick="btnInvite_Click"
                                        Style="background-color: #0C7A75; border: medium none !important; border-radius: 5px 5px 5px 5px;
                                        color: #FFFFFF; font-family: arial; font-size: 14px; font-weight: bold; height: 31px;
                                        cursor: pointer; width: 90px;" CommandArgument='<%#Eval("pk_user_registration_Id") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                   
                    <asp:Repeater ID="RpterCircle" runat="server" OnItemDataBound="RpterCircle_ItemDataBound" OnItemCommand="RpterCircle_ItemCommand">
                        <ItemTemplate>
                            <div style="border-bottom: 1px solid #CCCCCC; float: left; margin-top: 10px; padding-bottom: 12px;
                                width: 100%;">
                                <asp:HiddenField ID="hdnUserID" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image") %>' />
                                <asp:HiddenField ID="hdnColor" runat="server" Value='<%#Eval("circle_color") %>' />
                                <div id="dvtopimagecircle" runat="server" class="topthumb" style="height: 100px !important;
                                    margin-bottom: 0 !important; margin-left: 23px !important; margin-top: 8px; width: 100px !important;">
                                    <asp:ImageButton ID="imgtopcircle" runat="server" Style="height: 88px !important;
                                        padding: 5px 3px 3px 5px !important; width: 87px !important;" CssClass="topavatar"
                                        CommandName="imgtopcircleClick" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("fk_circle_id") %>' />
                                </div>
                                <div style="float: left; margin-left: 50px; margin-top: 37px; line-height: 16px;">
                                    <asp:Label ID="lbNAme" runat="server" Text='<%#Eval("circle_name") %>' Style="font-family: arial;
                                        font-size: 15px; text-transform: capitalize;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lbEMail" runat="server" Text='<%#Eval("username") %>' Visible="false"
                                        Style="font-family: arial; font-size: 14px;"></asp:Label>
                                </div>
                                <div style="float: right; margin-right: 105px; margin-top: 30px;">
                                    <asp:Label ID="lbPending" runat="server" Text="Approval Pending" Visible="false"
                                        Style="color: #0C7A75; font-family: arial; font-size: 14px; padding-right: 0px;"></asp:Label>
                                    <asp:Button ID="BtnInvite" runat="server" Text="Invite" OnClick="btnInvite_Click"
                                        Style="background-color: #0C7A75; border: medium none !important; border-radius: 5px 5px 5px 5px;
                                        color: #FFFFFF; font-family: arial; font-size: 14px; font-weight: bold; height: 31px;
                                        cursor: pointer; width: 90px;" CommandArgument='<%#Eval("fk_user_registration_Id") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="updatepnlInviteMember">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div>
                    </div>
                    <%-- <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" />--%></asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
