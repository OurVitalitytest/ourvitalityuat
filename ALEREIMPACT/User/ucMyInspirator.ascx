<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMyInspirator.ascx.cs"
    Inherits="ALEREIMPACT.User.ucMyInspirator" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type ="text/javascript">

    function checkfilesize(source, arguments) {
        arguments.IsValid = false;
        var size = document.getElementById("<%=fuInspiratorImage.ClientID%>").files[0].size;


       if (size > 1048576) {
            
      
        
            arguments.IsValid = false;
            return false;
        }
        else {
           
            arguments.IsValid = true;
            return true;
        }


    }
</script>
<div>
    
    <asp:UpdatePanel ID="UpdatepnInspirator" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <div id="breadcrumb">
                    
                        <a href="Inspirators.aspx">Inspirators</a>
                        <img alt="" border="0" height="12" src="../images/arow.jpg" width="13" />
                        <span style="color: #45B5B0;">My Inspirators</span>
                    
                </div>
                <div style="float: right; margin-bottom: 19px; margin-left: -55px; margin-right: 30px;
                    margin-top: -37px;">
                    <span style="float: left; font-family: arial; font-size: 13px; padding: 5px 20px 0 16px;
                        color: #50514F;">Choose a option :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Style="border: 1px solid #50514F; color: #50514F; width: 172px;">
                        <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
                        <asp:ListItem Value="1" Text="My Inspirators"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Member's Inspirators"></asp:ListItem>
                        <asp:ListItem Value="3" Text="My Library"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="color: #4DA3A4; float: right; font-size: 15px !important; font-weight: bold;
                    margin-right: -262px;">
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Add New Inspirator" 
                        onclick="LinkButton1_Click"></asp:LinkButton>
                </div>
                                <tr>
                    <td>
                        <asp:Label ID="lbNorecord" runat="server" Visible="false" Style="color: Gray; text-align: center;
                            margin-left: 350px;"></asp:Label>
                        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                            OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand"
                            Style="vertical-align: top;">
                            <ItemTemplate>
                                <table style="background: none repeat scroll 0 0 #F6F6F6; border: 1px solid #E2E2E2;
                                    border-radius: 4px 4px 0 0; margin-left: 24px; margin-right: 15px; padding: 5px 3px 0 5px;">
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdnUserid" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                            <asp:HiddenField ID="hdnInspiratorid" runat="server" Value='<%#Eval("pk_Inspirator_id") %>' />
                                            <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("Inspirator_image") %>' />
                                            <a id="aimage" runat="server">
                                                <asp:Image ID="Image1" runat="server" Style="border-width: 0; height: 150px; margin-left: 2px;
                                                    width: 180px;" />
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbDesc" runat="server" Text='<%#Eval("Inspirator_desc") %>' Style="color: #444444;
                                                float: left; font-family: arial; font-size: 13px; line-height: 14px; width: 184px;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="margin-top: 5px;">
                                        <td style="float: left; margin-right: 17px; margin-top: 9px;">
                                            <asp:Label ID="lbLikeCount" runat="server" Text=""></asp:Label>
                                            <asp:LinkButton ID="lnkLike" runat="server" Text="" Style="color: #53AFB0;" CommandName="Like"
                                                CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
                                        </td>
                                        <td style="float: left; margin-right: 19px; margin-top: 9px;">
                                            <asp:Label ID="lbCommentCount" runat="server" Text=""></asp:Label>
                                            <asp:LinkButton ID="lnkComment" runat="server" Text="Comments" Enabled="false" Style="color: #53AFB0;"
                                                CommandName="Comment" CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
                                        </td>
                                        <td style="float: left; margin-right: 5px; margin-top: 0px;">
                                            <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Flag as Inappropriate"
                                                CommandName="Inappropriate" CommandArgument='<%#Eval("pk_Inspirator_id") %>'
                                                ImageUrl="~/images/Flag-red-icon.png" OnClientClick="return confirm('Are you sure you want to flag this?')" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkViewMore" runat="server" Text="View More" Style="color: #53AFB0;
                            float: right; font-size: 20px; font-weight: bold; padding-right: 113px; text-decoration: underline;"
                            OnClick="lnkViewMore_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath=""
                    TargetControlID="LinkButton1" PopupControlID="panel32" BackgroundCssClass="modalBackground"
                    DropShadow="false" CancelControlID="btnClose">
                </asp:ModalPopupExtender>
                <asp:Panel ID="panel32" runat="server" Visible="false">
                    <div class="popup_wall">
                        <table border="0" cellpadding="5" cellspacing="5" width="100%" align="left" style="">
                            <tr>
                                <td style="padding-bottom: 30px; padding-left: 96px;">
                                    <strong>Add new Inspirator</strong><br />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 56px; padding-bottom: 2px;">
                                    <span style="float: left; font-size: 13px; padding-left: 5px; padding-top: 5px; padding-right: 54px;">
                                        Image : </span>&nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:FileUpload ID="fuInspiratorImage" runat="server" ValidationGroup="a" Style="float: left;
                                        margin-left: 18px;" />
                                    <span style="float: left; font-size: 11px; padding-top: 7px;">(Maximum Size 1MB)</span>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAppForm" runat="server" Style="float: left;
                                        padding-left: 127px; font-size: 13px; padding-top: 8px; color: #B20202;" ErrorMessage="Upload Inspirator Image "
                                        Display="Dynamic" ControlToValidate="fuInspiratorImage" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        
                                         <br />
                                        <asp:CustomValidator ID="NewPasswordCustomValidator" runat="server"  
                    ToolTip="FileSize should not exceed 1MB" Style="color: #FF0000;
                                        display: inline; float: left; font-family: arial; font-size: 13px; margin-left: -98px;
                                        margin-top: 44px;" ValidationGroup="a"
                    ErrorMessage="FileSize Exceeds the Limits." 
                    ControlToValidate="fuProfileImage"  
                   ClientValidationFunction = "checkfilesize"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 13px; margin-left: 59px;">Description:</span> &nbsp; &nbsp;
                                    &nbsp; &nbsp;
                                    <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" ValidationGroup="a"
                                        Style="width: 221px;"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="padding-left: 183px;
                                        font-size: 13px; color: #B20202;" ErrorMessage="Enter Description" Display="Dynamic"
                                        ControlToValidate="txtdesc" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="center" valign="middle">
                                <td style="padding-left: 115px;">
                                    <asp:Button ID="btnadd" runat="server" Text="Add" Style="margin-left: 71px; margin-right: 5px;"
                                        ValidationGroup="a" OnClick="btnadd_Click" />&nbsp;
                                    <asp:Button ID="btnClose" runat="server" Text="Close" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

        </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="LinkButton1" />
             <asp:PostBackTrigger ControlID="btnadd" />
    
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="UpdatepnInspirator">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div>
                        Processing...
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" /></asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
