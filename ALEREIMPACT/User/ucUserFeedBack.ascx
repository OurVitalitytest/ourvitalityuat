<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUserFeedBack.ascx.cs"
    Inherits="ALEREIMPACT.User.ucUserFeedBack" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div>
    <style type="text/css">
        .ratingEmpty
        {
            background-image: url(../images/ratingStarEmpty.gif);
            width: 18px;
            height: 18px;
        }
        .ratingFilled
        {
            background-image: url(../images/ratingStarFilled.gif);
            width: 18px;
            height: 18px;
        }
        .ratingSaved
        {
            background-image: url(../images/ratingStarSaved.gif);
            width: 18px;
            height: 18px;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanelFeedback" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <div style="border-bottom: 1px solid #CCCCCC; color: #666666; margin: 9px auto; padding-bottom: 13px;
                            width: 966px;">
                            <a href="FeedBackAndProblem.aspx" style="color: #45B5B0; margin-left: 21px;font-family:Arial;">Settings</a>
                            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
                            <span style="color: #50514F;font-family:Arial;">User Feedback</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 9px;">
                            <span style="color: #54B0B1; float: left; font-size: 17px; font-weight: bold;font-family:Arial;">
                                <asp:Label ID="Label1" runat="server" Text="Your Feedback About VITALITY"></asp:Label>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <span style="float: left;font-family:Arial;">
                                <asp:Label ID="Label2" runat="server" Text="Let us know how we can improve your experience with  VITALITY"></asp:Label>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <span style="float: left; font-size: 12px; font-weight: bold;font-family:Arial;">
                                <asp:Label ID="Label3" runat="server" Text="Please Rate Your Experience Using VITALITY"></asp:Label>
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <asp:Rating ID="ratingControl" AutoPostBack="true" runat="server" StarCssClass="ratingEmpty"
                                WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled">
                            </asp:Rating>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <span style="float: left;">Page </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <asp:DropDownList ID="DrpPage" runat="server" AppendDataBoundItems="true" Style="width: 271px;">
                                <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Page"
                                Display="Dynamic" ControlToValidate="DrpPage" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <span style="float: left;">Your Feedback </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Style="float: left;
                                height: 112px; width: 265px;"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Your Feedback required"
                                Display="Dynamic" ControlToValidate="txtFeedback" ValidationGroup="a"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 21px; margin-top: 13px;">
                            <span style="float: left; line-height: 24px;">Thanks for taking time to give us feedback.
                                We don't typically respond to feedback emails,
                                <br />
                                but we are reviewing them. </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 0px; margin-top: 13px;">
                            <asp:Button ID="btn_send" runat="server" Text="Send" Style="width: 78px;" OnClick="btn_send_Click"
                                ValidationGroup="a" />
                        </div>
                    </td>
                </tr>
            </table>  
            
            <img style="margin-left: 650px; margin-top: -394px; position:absolute; "  src="../images/send_feedback.png" />
            
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
