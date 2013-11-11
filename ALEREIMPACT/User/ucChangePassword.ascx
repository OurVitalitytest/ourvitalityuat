<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChangePassword.ascx.cs"
    Inherits="ALEREIMPACT.User.ucChangePassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript" language="javascript">
function showMessage()
{
var currentpwd=document.getElementById('Password_txtPassword').value;
var newpwd=document.getElementById('Password_txtNewPassword').value;
var confirmpwd=document.getElementById('Password_txtConfirmPwd').value;
if(currentpwd != "" && newpwd != "" && confirmpwd != "")
{
var checkMsg = '<%=_pwd_Message %>';

if(checkMsg == 'Failed')
{

document.getElementById('Password_dvError').style.display = 'block';


}
else if(checkMsg == 'Success')
{ 

    document.getElementById('Password_dvMsg').style.display = 'block';

}
}
else 
{
if( currentpwd == "")
{
document.getElementById('Password_RequiredFieldValidator1').style.visibility='block';
}
if(newpwd == "")
{
document.getElementById('Password_RequiredFieldValidator2').style.visibility='block';
}
if(confirmpwd == "")
{
document.getElementById('Password_RequiredFieldValidator3').style.visibility='block';
}
if(newpwd != confirmpwd)
{
document.getElementById('Password_CompareValidator1').style.visibility='block';
}
}
}

</script>

<div>
    <asp:UpdatePanel ID="updatePanelChangePAssword" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="float: left; margin-left: 6px;
                margin-top: 5px; padding-bottom: 20px; padding-right: 20px;">
                <tr>
                    <td>
                        <div style="border-bottom: 1px solid #CCCCCC; color: #666666; margin: 9px auto; padding-bottom: 13px;
                            width: 966px;">
                            <a href="FeedBackAndProblem.aspx" style="color: #45B5B0; margin-left: 21px; font-family: Arial;">
                                Settings</a>
                            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
                            <span style="color: #50514F; font-family: Arial;">Change Password</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="dvMsg" runat="server" style="display: none; color: red; font-family: arial;
                            font-size: 13px; margin-left: 62px; margin-top: 14px;">
                            Password Changed Successfully.
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 58px; margin-top: 39px;">
                            <span style="float: left; font-family: Arial; margin-top: 7px;">Current Password :</span>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="float: left;
                                height: 20px; margin-left: 45px; width: 187px;"></asp:TextBox>
                            <br />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Current Password Required"
                                ControlToValidate="txtPassword" ValidationGroup="a" Style="font-family: arial;
                                margin-left: 165px; font-size: 11px;">
                            </asp:RequiredFieldValidator>
                            <div id="dvError" runat="server" style="display: none; color: red; font-family: arial;
                                font-size: 11px; margin-left: 166px;">
                                Password Not Found.
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 62px; margin-top: 20px;">
                            <span style="float: left; font-family: Arial; margin-top: 8px;">New Password :</span>
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" MaxLength="12"
                                Style="float: left; height: 20px; margin-left: 62px; width: 187px;"></asp:TextBox><br />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNewPassword"
                                runat="server" ErrorMessage="Password must be atleast 6 characters long and contain at least one number, one lower letter,one upper letter and one unique character"
                                Style="color: red; display: inline; float: left; font-family: arial; font-size: 12px;
                                line-height: 14px; margin-left: 158px; width: 211px;" ValidationExpression="^.*(?=.{6,12})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?@* ]).*$"
                                ValidationGroup="a" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="New Password Required"
                                ControlToValidate="txtNewPassword" ValidationGroup="a" Style="font-family: arial;
                                margin-left: 160px; font-size: 11px;">
                            </asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; margin-left: 63px; margin-top: 24px;">
                            <span style="float: left; font-family: Arial; margin-top: 8px;">Confirm Password :</span>
                            <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" MaxLength="12"
                                Style="float: left; height: 20px; margin-left: 36px; width: 187px;"></asp:TextBox><br />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm Password Required"
                                ControlToValidate="txtConfirmPwd" ValidationGroup="a" Style="font-family: arial;
                                font-size: 11px; margin-left: 159px;">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" runat="server" ValidationGroup="a"
                                Style="visibility: visible; color: #B20202;" ControlToCompare="txtNewPassword"
                                ControlToValidate="txtConfirmPwd" ErrorMessage="Password not matched"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left;">
                            <asp:Button ID="BtnChangePwd" runat="server" Text="Change Password" ValidationGroup="a"
                                OnClientClick="showMessage();" OnClick="BtnChangePwd_Click" Style="cursor: pointer;
                                margin-left: 263px; margin-top: 32px;" />
                        </div>
                    </td>
                </tr>
            </table>
            <img style="margin-left: 610px; margin-top: -233px;" src="../images/lock_pass.png" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
