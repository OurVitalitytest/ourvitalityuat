<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNIMNotification.ascx.cs"
    Inherits="ALEREIMPACT.User.UCNIMNotification" %>
<div>
    <link href="../CSS/Privacycss/privacy.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/newstyle.css" type="text/css" />
    <link href="../CSS/Privacycss/mission.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Privacycss/style.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePnlNMINotification" runat="server">
        <ContentTemplate>
            <div class="center_food_log" style="height: 700px !important; margin: 0 !important;
                overflow-x: hidden; overflow-y: scroll;">
                <div class="top_his_miss" style="float: left; height: 5px; margin-left: -17px; margin-top: -15px !important;
                    padding-left: 11px !important; padding-top: 26px; width: 961px !important">
                    <div class="bread_miss">
                        <span class="mission_miss" style="font-size: 16px; font-weight: bold; margin-top: -15px !important;
                            width: 340px;">Your Notifications</span>
                        <div class="arrow_miss">
                        </div>
                    </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>
                <asp:GridView ID="GrdDAte" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                    OnRowDataBound="GrdDAte_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="date_list">
                                    <asp:HiddenField ID="hdnDate" runat="server" Value='<%#Eval("Date") %>' />
                                    <asp:Label ID="lbDate" runat="server" Text=""></asp:Label>
                                </div>
                                <asp:GridView ID="GrdNotification" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                    OnRowDataBound="GrdNotification_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="des_list_post">
                                                    <asp:HiddenField ID="hdnDAte1" runat="server" Value='<%#Eval("Date") %>' />
                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("status") %>' />
                                                    <asp:HiddenField ID="hdnName" runat="server" Value='<%#Eval("sendername") %>' />
                                                    <asp:HiddenField ID="hdnCirclename" runat="server" Value='<%#Eval("circlename") %>' />
                                                    <asp:HiddenField ID="hdnCircleowner" runat="server" Value='<%#Eval("Circleowner") %>' />
                                                    <asp:Image ID="ImgLogo" runat="server" />&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="LBnAME" runat="server" Text="" CssClass="name_of_target" Style="margin-left: 11px;"></asp:Label>
                                                    <asp:Label ID="lbComment" runat="server" Text="" CssClass="normal_text"></asp:Label>
                                                   
                                                    <asp:Label ID="lbCircleName" runat="server" Text="" CssClass="name_of_target"></asp:Label>
                                                    <div style="float: right; margin-left: 411px;">
                                                         <asp:Label ID="Label1" runat="server" Text='<%#Eval("time") %>' CssClass="normal_text"></asp:Label>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lbCircleName" runat="server" Text="No notifications found.." CssClass="normal_text"
                                            Style="color: #808080; float: left; margin-left: 37px !important; margin-top: 14px !important;"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
