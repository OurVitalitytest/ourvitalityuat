<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberList.ascx.cs"
    Inherits="ALEREIMPACT.User.ucMemberList" %>
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<div style="margin-top: 5px">
    <asp:UpdatePanel ID="udpUpdatePanelmemberList" runat="server">
        <ContentTemplate>
            <div class="main_cont_miss">
                <div class="top_his_miss" style="height: 0; margin-top: 0 !important; padding-left: 11px !important;
                    padding-top: 17px; width: 964px !important;">
                    <div class="bread_miss">
                        <span class="mission_miss" style="font-size: 16px; margin-top: 4px; font-weight: bold;">
                            Members List </span>
                        <div class="arrow_miss">
                        </div>
                    </div>
                    <div style="float: right; margin-right: 31px; margin-top: 5px;">
                        <asp:LinkButton ID="lnkInvite" runat="server" Text="Invite Members" Style="color: #0C7A75 !important;
                            font-family: arial; font-size: 16px; font-weight: bold;" OnClick="lnkInvite_Click"></asp:LinkButton>
                    </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>
                <div style="background: none repeat scroll 0 0 #FFFFFF; border-radius: 2px 2px 2px 2px;
                    float: left; margin-top: -15px !important; width: 974px; height: 800px; overflow: scroll;
                    overflow-x: hidden;">
                    <asp:Label ID="lbmsg" runat="server" Text="Members are only accessed by owner of that circle"
                        Visible="false" Style="color: #666666; float: left; font-family: arial; font-size: 16px;
                        font-weight: bold; margin-left: 272px; margin-top: 41px;"></asp:Label>
                    <asp:DataList ID="dlmemberlist" runat="server" CellPadding="3" CellSpacing="30" RepeatColumns="2"
                        BorderColor="Gray" BorderStyle="Solid" OnItemCommand="dlmemberlist_ItemCommand"
                        OnItemDataBound="dlmemberlist_ItemDataBound">
                        <ItemTemplate>
                            <div class="thuumb_des_pro">
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("frdimage") %>' />
                                <asp:ImageButton ID="frdimage" runat="server" CommandName="lnkImage" Style="float: left;
                                    height: 130px; width: 130px" CommandArgument='<%#Eval("userid") %>' />
                                <%-- <a id="aProfile" runat="server">
                                <asp:Image ID="frdimage" runat="server" CssClass="avatar1"  /></a>--%>
                                <div class="contact_detail_miss">
                                    <div class="name_miss_des">
                                        <asp:Label ID="frdregid" runat="server" Visible="false" Text='<%#Eval("userid")%>'></asp:Label>
                                        <asp:Label ID="lbfrdname" runat="server" Text='<%#Eval("frdName")%>'></asp:Label></div>
                                    <div class="email_miss_des" style="width: 150px; word-wrap: break-word;">
                                        <asp:Label ID="lbfrdaddress" runat="server" Text='<%#Eval("email")%>' Visible="false"></asp:Label></div>
                                </div>
                            </div>
                            <%--<div>
                                <div style="float: left; padding-bottom: 0; padding-left: 0px;">
                                    <asp:Image ID="frdimage" runat="server" CssClass="avatar1" ImageUrl='<%# "profile_image/" + Eval("frdimage") %>' />
                                </div>
                                <div style="height: 20px; padding-left: 112px; line-height: 20px; font-size: 12px;
                                    width: 98px">
                                    <asp:Label ID="frdregid" runat="server" Visible="false" Text='<%#Eval("userid")%>'></asp:Label>
                                    <asp:Label ID="lbfrdname" runat="server" Text='<%#Eval("frdName")%>'></asp:Label><br />
                                    <asp:Label ID="lbfrdaddress" runat="server" Text='<%#Eval("frdaddress")%>'></asp:Label>
                                </div>
                            </div>--%>
                        </ItemTemplate>
                    </asp:DataList>
                    <%--<asp:GridView ID="grdPendingRequests" runat="server" AutoGenerateColumns="False"
                    CssClass="table-data !important" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="av_img">
                                    <div style="float: left; padding-bottom: 0; padding-left: 120px;">
                                        <asp:Image ID="frdimage" runat="server" CssClass="avatar1" ImageUrl='<%# "profile_image/" + Eval("frdimage") %>' />
                                        <asp:Label ID="frdregid" runat="server" Visible="false" Text='<%#Eval("userid")%>'></asp:Label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div style="float: left; margin-left: 48px;">
                                    <asp:Label ID="lbfrdname" runat="server" Text='<%#Eval("frdName")%>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lbfrdaddress" runat="server" Text='<%#Eval("frdaddress")%>'></asp:Label>
                                </div>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No member found for this circle
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle ForeColor="Gray" HorizontalAlign="Center" Font-Size="Small" />
                    <FooterStyle BackColor="White" ForeColor="" />
                    <PagerStyle BackColor="" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="" Font-Bold="True" ForeColor="White" />
                </asp:GridView>--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpUpdatePanelmemberList">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div>
                  
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" /></asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
