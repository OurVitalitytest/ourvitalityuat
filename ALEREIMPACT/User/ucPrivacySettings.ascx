<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPrivacySettings.ascx.cs"
    Inherits="ALEREIMPACT.User.ucPrivacySettings" %>
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<div>
    <asp:UpdatePanel ID="updatePrivacyPanel" runat="server">
        <ContentTemplate>
            <div class="main_privacy">
                <div style="border-bottom: 1px solid #CCCCCC; color: #666666; margin: 9px auto; padding-bottom: 13px;
                    width: 966px;">
                    <a href="FeedBackAndProblem.aspx" style="color: #45B5B0; margin-left: 21px; font-family: Arial;">
                        Settings</a>
                    <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
                    <span style="color: #50514F; font-family: Arial;">Privacy Settings</span>
                </div>
                <%-- <h1>Privacy Settings</h1>--%>
                <div class="header_privacy">
                    <div class="first_heading">
                        Visible when viewed by:
                    </div>
                    <div class="second_heading">
                        You</div>
                    <div class="second_heading">
                        Friends
                    </div>
                    <div class="second_heading">
                        Anyone</div>
                </div>
                <h2>
                    Personal Info</h2>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        Profile Picture</div>
                    <asp:RadioButtonList ID="rdbtnProfilepic" runat="server" RepeatDirection="Horizontal"
                        CssClass="second_inner_btn" AutoPostBack="true">
                        <asp:ListItem Value="1" Text=""></asp:ListItem>
                        <asp:ListItem Value="2" Text=""></asp:ListItem>
                        <asp:ListItem Value="3" Text=""></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        Height</div>
                    <asp:RadioButtonList ID="rdbtnHeight" runat="server" RepeatDirection="Horizontal"
                        CssClass="second_inner_btn" AutoPostBack="true">
                        <asp:ListItem Value="1" Text=""></asp:ListItem>
                        <asp:ListItem Value="2" Text=""></asp:ListItem>
                        <asp:ListItem Value="3" Text=""></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        Weight</div>
                    <asp:RadioButtonList ID="rdbtnWeight" runat="server" RepeatDirection="Horizontal"
                        CssClass="second_inner_btn" AutoPostBack="true">
                         <asp:ListItem Value="1" Text=""></asp:ListItem>
                        <asp:ListItem Value="2" Text=""></asp:ListItem>
                        <asp:ListItem Value="3" Text=""></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        DOB</div>
                    <asp:RadioButtonList ID="rdbtnDOB" runat="server" RepeatDirection="Horizontal" CssClass="second_inner_btn"
                        AutoPostBack="true">
                       <asp:ListItem Value="1" Text=""></asp:ListItem>
                        <asp:ListItem Value="2" Text=""></asp:ListItem>
                        <asp:ListItem Value="3" Text=""></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        Location</div>
                    <asp:RadioButtonList ID="rdbtnLocation" runat="server" RepeatDirection="Horizontal"
                        CssClass="second_inner_btn" AutoPostBack="true">
                      <asp:ListItem Value="1" Text=""></asp:ListItem>
                        <asp:ListItem Value="2" Text=""></asp:ListItem>
                        <asp:ListItem Value="3" Text=""></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        Members</div>
                    <asp:RadioButtonList ID="rdbtnFreinds" runat="server" RepeatDirection="Horizontal"
                        CssClass="second_inner_btn" AutoPostBack="true">
                        <asp:ListItem Value="1" Text=""></asp:ListItem>
                        <asp:ListItem Value="2" Text=""></asp:ListItem>
                        <asp:ListItem Value="3" Text=""></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="inner_privacy">
                    <div class="first_inner_heading">
                        Email</div>
                    <asp:RadioButtonList ID="rdbtnEmail" runat="server" RepeatDirection="Horizontal"
                        CssClass="second_inner_btn" AutoPostBack="true" style="  width: 251px !important;">
                        <asp:ListItem Value="1" Text=""></asp:ListItem>
                        <asp:ListItem Value="2" Text=""></asp:ListItem>
                       
                    </asp:RadioButtonList>
                </div>
                <div class="privacy-footer">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="input" 
                        onclick="btnUpdate_Click"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CssClass="input" 
                        onclick="btnCancel_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
