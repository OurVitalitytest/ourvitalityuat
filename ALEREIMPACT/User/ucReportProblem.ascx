<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucReportProblem.ascx.cs"
    Inherits="ALEREIMPACT.User.ucReportProblem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div>
    <style type="text/css">
        .txtCls
        {
            color: #5C6974;
        }
    </style>
    <table border="0" cellpadding="0" cellspacing="0">
        <asp:UpdatePanel ID="updatePanelProblem" runat="server">
            <ContentTemplate>
            <tr>
            <td>
            <div style=" border-bottom: 1px solid #CCCCCC;
    color: #666666;
    margin: 9px auto;
    padding-bottom: 13px;
    width: 966px;">
           
        
            <a href="FeedBackAndProblem.aspx" style="color:#45B5B0; margin-left:21px;">Settings</a>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span  style="color:#50514F;">Report a Problem</span>
        </div>
        </td>
            </tr>
                <tr>
                    <td>
                        <div style="background-color: #54B1B2; border: 1px solid #54B1B2; float: left; height: 33px;
                            margin-bottom: 16px; margin-left: 8px; margin-top: 10px;  width: 947px;">
                            <span style="float: left; font-size: 17px; font-weight: bold; margin-left: 25px;
                                margin-top: 11px;">Report a Problem </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 26px; margin-top: 12px;">
                            <asp:DropDownList ID="DrpPage" runat="server" AppendDataBoundItems="true" Style="width: 271px;">
                                <asp:ListItem Value="0" Text="Select Page"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Page"
                                Display="Dynamic" ControlToValidate="DrpPage" ValidationGroup="a" InitialValue="0"  style="   float: left;
    font-family: arial;
    font-size: 13px;
    margin-top: 7px;"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 25px; margin-top: 16px;">
                            <asp:Label ID="Label1" runat="server" Text="Describe the bug in as much detail as possible."
                                Style="font-weight: bold;"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; line-height: 27px; margin-left: 56px; margin-top: 16px;">
                            <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Square">
                                <asp:ListItem Text="What were you doing when you experienced the problem?" Value="0"></asp:ListItem>
                                <asp:ListItem Text="What steps can we follow to reproduce the problem?" Value="1"></asp:ListItem>
                            </asp:BulletedList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 26px; margin-top: 11px;">
                            <asp:TextBox ID="txtProblem" runat="server" TextMode="MultiLine" Style="height: 127px;
                                width: 383px;"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtProblem"
                                WatermarkText="Please provide steps that we can follow to reproduce the problem"
                                WatermarkCssClass="txtCls">
                            </cc1:TextBoxWatermarkExtender>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Description"
                                Display="Dynamic" ControlToValidate="txtProblem" ValidationGroup="a"   style="   float: left;
    font-family: arial;
    font-size: 13px;
    margin-top: 7px;"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-bottom: 9px; margin-left: 25px; margin-top: 11px;">
                            <asp:Label ID="Label2" runat="server" Text="Upload Screenshot(s) :" Style="float: left;"></asp:Label>
                        </div>
                    </td>
                </tr>
            </ContentTemplate>
        </asp:UpdatePanel>
        <tr>
            <td>
                <div style="float: left; margin-left: 26px; margin-top: 7px;">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="float: left;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                        ValidationGroup="a" />
                </div>
                <div style="float: left;">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="a" OnClick="btnCancel_Click" />
                </div>
            </td>
        </tr>
    </table>
</div>
