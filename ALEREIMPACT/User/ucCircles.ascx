<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCircles.ascx.cs" Inherits="ALEREIMPACT.User.ucCircles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript">
    function colorChanged(sender) {
        sender.get_element().style.color =
       "#" + sender.get_selectedColor();
    } 
</script>


<%--  <div style="height:1000px; overflow:scroll">--%>
<asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server">
    <ContentTemplate>
        <div style="width: 80%">
            <asp:Repeater ID="repCircles" runat="server" OnItemDataBound="repCircles_ItemDataBound"
                OnItemCommand="repCircles_ItemCommand">
                <ItemTemplate>
                    <div class="bg_left_mission">
                        <div class="left_mission_text">
                            <asp:HiddenField ID="hndUserId" runat="server" Value='<%#Eval("fk_user_registration_Id")%>' />
                            <asp:HiddenField ID="hndCircleId" runat="server" Value='<%#Eval("fk_circle_id")%>' />
                            <asp:HiddenField ID="hnducId" runat="server" Value='<%#Eval("pk_user_circle_id")%>' />
                            <asp:HiddenField ID="hndCName" runat="server" Value='<%#Eval("circle_name")%>' />
                            <asp:LinkButton ID="lkfriends" runat="server" ToolTip="Members" Style="color: White;
                                font-size: 29px; font-weight: bold; font-family: Courier New; text-decoration: none"
                                CommandName="ShowSelectedCircleMembers" CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'></asp:LinkButton>
                        </div>
                        <div class="left_mission_text_1">
                            <asp:LinkButton ID="lkmissions" runat="server" ToolTip="Missions" Style="color: Black;
                                font-size: 29px; font-weight: bold; font-family: Courier New; text-decoration: none"
                                CommandName="ShowSelectedCircleMissions" CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'></asp:LinkButton>
                        </div>
                    </div>
                    <div id="dvimagecircle" runat="server" class="thumb">
                        <asp:LinkButton ID="lnkChangeCircle" runat="server" CommandName="ShowForSelectedCircle"
                            CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'>
                            
                            <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                            <asp:Image ID="Image1" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>'
                                ToolTip='<%#Eval("circle_name")%>' />
                                
                        </asp:LinkButton>
                       
                    </div>
                    
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="width: 40%" align="right">
            <asp:ImageButton ID="imgaddcircle" runat="server" ImageUrl="~/images/AddCircle.png"
                ToolTip="Add New Circle" />
            <asp:Panel ID="PnlCircle" runat="server" Style="display: none">
                <div class="popup_wall">
                    <table border="0" cellpadding="5" cellspacing="5" width="100%" align="left" style="">
                        <tr>
                            <td colspan="3">
                                <strong>Create a new Circle:</strong><br />
                                <br />
                                Customize your circle. Make it your own.
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                Name:<span style="color: red">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtcirclename" runat="server" ValidationGroup="circle"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="circle"
                                    Display="Dynamic" ErrorMessage="Enter circle name" ControlToValidate="txtcirclename"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                color:
                                <asp:Label ID="Label1" runat="server" Text="*" Style="color: red"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:ColorPickerExtender runat="server" ID="ColorPickerExtender1" TargetControlID="txtcirclecolor"
                                    OnClientColorSelectionChanged="colorChanged" />
                                <asp:TextBox ID="txtcirclecolor" runat="server"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="circle"
                                    Display="Dynamic" ErrorMessage="choose circle color" ControlToValidate="txtcirclecolor"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                Upload an image:<span style="color: red">*</span>
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="fucircleimage" runat="server" ValidationGroup="circle" onchange="getImg(this,100,'jpeg|png|jpg')" /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="circle"
                                    Display="Dynamic" ErrorMessage="Upload circle image" ControlToValidate="fucircleimage"></asp:RequiredFieldValidator>
                                <asp:Label ID="lbuploadimger" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                Set your Circle Specs.<span style="color: red">*</span>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlcirclespec" runat="server" AppendDataBoundItems="true" ValidationGroup="circle">
                                    <asp:ListItem Text="--Choose--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                    ValidationGroup="circle" ErrorMessage="Choose circle specs" ControlToValidate="ddlcirclespec"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <td>
                        </td>
                        <tr align="center" valign="middle">
                            <td colspan="3">
                                <asp:Button ID="btncreatecircle" runat="server"  Text="Create" OnClick="btncreatecircle_Click"
                                    ValidationGroup="circle" />
                                <asp:Button ID="btnClose" runat="server" Text="Close" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="imgaddcircle"
                PopupControlID="PnlCircle" BackgroundCssClass="modalBackground" DropShadow="false"
                CancelControlID="btnClose">
            </asp:ModalPopupExtender>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btncreatecircle" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpOutterUpdatePanel">
    <ProgressTemplate>
        <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
            <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                    Processing...
                </div>
                <div style="float: left; margin-top: 17px; margin-left: -249px;">
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" />
                </div>
            </asp:Panel>
        </asp:Panel>
    </ProgressTemplate>
</asp:UpdateProgress>
<%--</div>--%>
