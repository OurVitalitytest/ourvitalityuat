<%@ Page Title="Vitality " Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="RegisterProfile.aspx.cs" Inherits="ALEREIMPACT.RegisterProfile" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function checkDate(sender, args) {
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
        function ValidateProfileImage(source, args) {
            if ($("#ctl00_ContentPlaceHolder1_fupProfileImage").val() != '') {
                $("#ctl00_ContentPlaceHolder1_form19Challan_txtReceipt").val('' + $("#ctl00_ContentPlaceHolder1_txtProfileImage").val() + '');
            }
        }       
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table>
        <tr>
            <td>
                Surname :
            </td>
            <td>
                <asp:TextBox ID="txtSurname" runat="server">
                </asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="regNameOnly" runat="server" ControlToValidate="txtSurname"
                    ValidationGroup="newUserProfile" Display="Dynamic" ValidationExpression="^([a-zA-Z '-]+)$"
                    ErrorMessage="Your name can contain characters only."></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Height :
            </td>
            <td>
                <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="ftrHeight" runat="server" FilterType="Custom"
                    ValidChars="0123456789." TargetControlID="txtHeight">
                </asp:FilteredTextBoxExtender>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Weight :
            </td>
            <td>
                <asp:TextBox ID="txtWeight" runat="server">
                </asp:TextBox>
                <asp:FilteredTextBoxExtender ID="ftrWeight" runat="server" FilterType="Numbers" ValidChars="0123456789."
                    TargetControlID="txtWeight">
                </asp:FilteredTextBoxExtender>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Date Of Birth :
            </td>
            <td>
                <asp:DropDownList ID="drpAge" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ImageButton ID="imgProfileAdded" runat="server" ImageUrl="~/images/submit.png"
                    ValidationGroup="newUserProfile" OnClick="imgProfileAdded_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
