<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTickets.ascx.cs" Inherits="ALEREIMPACT.User.ucTickets" %>
<div>
    <asp:UpdatePanel ID="UpdatePanelTickets" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <div style="border-bottom: 1px solid #CCCCCC; color: #666666; margin: 9px auto; padding-bottom: 13px;
                            width: 966px;">
                            <a href="FeedBackAndProblem.aspx" style="color: #45B5B0; margin-left: 21px; font-family: Arial;">
                                Settings</a>
                            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
                            <span style="color: #50514F; font-family: Arial;">Tickets</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; height: 33px; margin-bottom: 16px; margin-left: 2px; margin-top: -5px;
                            font-family: Arial; font-size: 14px; width: 964px;">
                            <asp:Label ID="Label1" runat="server" Text="Your Ticket Details" Style="color: #54B0B1;
                                float: left; font-family: Arial; font-size: 17px; font-weight: bold; margin-left: 22px;
                                margin-top: 11px;"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; line-height: 23px; margin-left: 13px;">
                            <asp:Label ID="Label2" runat="server" Text="Enter your ticket details below. If you are reporting a problem, please remember to provide as much <br/> information that is relevant to the issue as possible."
                                Style="float: left; font-size: 14px; margin-bottom: 8px; margin-left: 22px; margin-top: 0;
                                font-family: Arial; padding-bottom: 5px;"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 38px; margin-top: 10px;">
                            <asp:TextBox ID="txtTickets" runat="server" TextMode="MultiLine" Style="border: 1px solid #54B1B2;
                                height: 166px; width: 895px;"></asp:TextBox>
                            <div style="float: left; margin-top: 6px;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ticket details required"
                                    ValidationGroup="a" ControlToValidate="txtTickets"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: right; margin-right: 31px;">
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                                ValidationGroup="a" />
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
