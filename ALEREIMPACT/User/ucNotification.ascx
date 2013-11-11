<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNotification.ascx.cs"
    Inherits="ALEREIMPACT.User.ucNotification" %>
<div>
    <asp:UpdatePanel ID="updateNotificationPanel" runat="server">
        <ContentTemplate>
            <div class="main_privacy">
                <div style="border-bottom: 1px solid #CCCCCC; color: #666666; margin: 9px auto; padding-bottom: 13px;
                    width: 966px;">
                    <a href="FeedBackAndProblem.aspx" style="color: #45B5B0; margin-left: 21px; font-family: Arial;">
                        Settings</a>
                    <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
                    <span style="color: #50514F; font-family: Arial;">Notifications</span>
                </div>
                <%-- <h1>Notifications </h1>--%>
                <div class="header_privacy">
                    <div class="first_heading" style="float: left; margin-left: 5px; width: 475px;">
                        &nbsp;
                    </div>
                    <div class="second_heading">
                        Daily</div>
                    <div class="second_heading">
                        Weekly</div>
                    <div class="second_heading">
                        Monthly</div>
                    <div class="second_heading">
                        Off</div>
                </div>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        Emails</div>
                    <div class="second_inner_btn">
                        <asp:RadioButtonList ID="rdbtnList" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                            Style="margin-left: -118px !important; width: 438px !important;">
                            <asp:ListItem Value="1" Text=""></asp:ListItem>
                            <asp:ListItem Value="2" Text=""></asp:ListItem>
                            <asp:ListItem Value="3" Text=""></asp:ListItem>
                            <asp:ListItem Value="4" Text=""></asp:ListItem>
                        </asp:RadioButtonList>
  
                       
                    </div>
                </div>
                <div class="privacy-footer">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="input" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="input" OnClick="btnCancel_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
