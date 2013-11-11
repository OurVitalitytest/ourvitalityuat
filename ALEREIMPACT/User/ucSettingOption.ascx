<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSettingOption.ascx.cs"
    Inherits="ALEREIMPACT.User.ucSettingOption" %>
<div>
    <asp:UpdatePanel ID="updatePanelSetting" runat="server">
        <ContentTemplate>
            <div class="top_his_miss" style="border-top: 1px solid #CCCCCC; border-left: 0px solid #CCCCCC;
                border-right: 0px solid #CCCCCC; color: #666666; float: left; margin: -1px auto 0 0px;
                font-family: Arial; padding-bottom: 26px; width: 971px;">
                <div class="bread_miss" style="height: 12px;">
                    <span class="mission_miss" style="color: #555555; float: left; font-family: arial;
                        font-size: 16px; font-weight: bold; margin-top: 7px; padding-left: 25px;">Settings</span></div>
            </div>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <span style="float: left; margin-top: 8px;">
                            <asp:Label ID="Label1" runat="server" Text="Thanks for contacting VITALITY."
                                Visible="false" Style="color: Red; margin-left: 31px;"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="We would like you to know that your report will be used to improve ALERE VITALITY."
                                Visible="false" Style="color: Red; margin-left: 31px;"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 38px; margin-top: 11px; margin-bottom: 19px;">
                            <asp:LinkButton ID="lnkFeedBAck" runat="server" Text="Send Feedback" Style="text-decoration: none;
                                color: #53AFB0;" OnClick="lnkFeedBAck_Click"></asp:LinkButton>
                        </div>
                        <br />
                        <div style="float: left; margin-bottom: 33px; margin-left: -101px; margin-top: 32px;">
                            <span style="float: left; font-family: Arial;">
                                <asp:Label ID="Label2" runat="server" Text="Tell us about your VITALITY experience"></asp:Label>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="margin-top: -13px; width: 967px; color: #EFEFEF" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td>
                        <div style="float: left; margin-left: 38px; margin-top: 11px; margin-bottom: 19px;">
                            <asp:LinkButton ID="LnkProblem" runat="server" Text="Report a Problem" Style="text-decoration: none;
                                color: #53AFB0;" OnClick="LnkProblem_Click"></asp:LinkButton>
                        </div>
                        <br />
                        <div style="float: left; margin-bottom: 33px; margin-left: -109px; margin-top: 32px;">
                            <span style="float: left; font-family: Arial;">
                                <asp:Label ID="Label3" runat="server" Text="Let us know about a broken feature"></asp:Label>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="margin-top: -13px; width: 967px; color: #EFEFEF" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 38px; margin-top: 11px; margin-bottom: 19px;">
                            <asp:LinkButton ID="lnkTicket" runat="server" Text="Submit a Ticket" Style="text-decoration: none;
                                color: #53AFB0;" OnClick="lnkTicket_Click"></asp:LinkButton>
                        </div>
                        <div style="float: left; line-height: 21px; margin-bottom: 33px; margin-left: -95px;
                            margin-top: 37px;">
                            <span style="float: left; font-family: Arial;">
                                <asp:Label ID="Label5" runat="server" Text="If you are reporting a problem, please remember to provide as much <br/> information that is relevant to the issue as possible."></asp:Label>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="margin-top: -13px; width: 967px; color: #EFEFEF" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 38px; margin-top: 11px; margin-bottom: 19px;">
                            <asp:LinkButton ID="lnkChangePassword" runat="server" Text="Change Password" Style="text-decoration: none;
                                color: #53AFB0;" OnClick="lnkChangePassword_Click"></asp:LinkButton>
                        </div>
                         <div style="float: left; line-height: 21px; margin-bottom: 33px; margin-left: -113px;
                            margin-top: 37px;">
                            <span style="float: left;font-family:Arial;">
                                <asp:Label ID="Label6" runat="server" Text="We highly recommend you create a secure password"></asp:Label>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="margin-top: -13px; width: 967px; color: #EFEFEF" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 38px; margin-top: 11px; margin-bottom: 19px;">
                            <asp:LinkButton ID="lnkPrivacy" runat="server" Text="Privacy Settings" Style="text-decoration: none;
                                color: #53AFB0;" OnClick="lnkPrivacy_Click"></asp:LinkButton>
                        </div>
                         <div style="float: left; line-height: 21px; margin-bottom: 33px; margin-left: -113px;
                            margin-top: 37px;">
                            <span style="float: left;font-family:Arial;">
<%--                                <asp:Label ID="Label7" runat="server" Text="We highly recommend you create a secure password"></asp:Label>
--%>                            </span>
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <hr style="margin-top: -13px; width: 967px; color: #EFEFEF" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 38px; margin-top: 11px; margin-bottom: 19px;">
                            <asp:LinkButton ID="lnkNotification" runat="server" Text="Notification" Style="text-decoration: none;
                                color: #53AFB0;" OnClick="lnkNotification_Click"></asp:LinkButton>
                        </div>
                         <div style="float: left; line-height: 21px; margin-bottom: 33px; margin-left: -113px;
                            margin-top: 37px;">
                            <span style="float: left;font-family:Arial;">
<%--                                <asp:Label ID="Label7" runat="server" Text="We highly recommend you create a secure password"></asp:Label>
--%>                            </span>
                        </div>
                    </td>
                </tr>
            </table>
            <%--</div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
