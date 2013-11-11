<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucInspiratorDescription.ascx.cs"
    Inherits="ALEREIMPACT.User.ucInspiratorDescription" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<div>
<asp:UpdatePanel ID="UpdatePnlInspirator" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="line-height: 12px !important;">
            <div id="breadcrumb">
                    <a href="Inspirators.aspx" style="float:left;">Inspirators</a>
                    <asp:Panel ID="panellink" runat="server" Visible="false" style="float:left;">
                    <img alt="" border="0" height="12" src="../images/arow.jpg" width="13" />
                    <asp:LinkButton ID="lnkInspirator" runat="server" onclick="lnkInspirator_Click"></asp:LinkButton>
                    </asp:Panel>
                    <img alt="" border="0" height="12" src="../images/arow.jpg" width="13" />
                    <span style="color:#45B5B0;">Inspirator Description</span>
         
        </div>
        
        <div id="divdrp" runat="server"  style="   float: right;
    margin-bottom: 19px;
    margin-left: -55px;
    margin-right: 30px;
    margin-top: -37px;">
<span style=" float: left; font-family: arial;  font-size: 13px;    padding: 5px 20px 0 16px; color:#50514F;">Choose a option :</span>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
         OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="border: 1px solid #50514F;
    color: #50514F;
    width: 172px; ">
    <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
    <asp:ListItem Value="1" Text="My Inspirators"></asp:ListItem>
    <asp:ListItem Value="2" Text="Member's Inspirators"></asp:ListItem>
     <asp:ListItem Value="3" Text="My Library"></asp:ListItem>
    </asp:DropDownList>
    
</div>
                <tr>
                    <td class="img" style=" height: 150px;    width: 345px;">
                        <asp:Image ID="Image1" runat="server" style=" border-radius: 3px 3px 3px 3px;
    border-width: 0;    height: 300px;    margin-bottom: 10px;    margin-left: 9px;    margin-top: 10px;    width: 300px;" />
                    </td>
                   <td style="float:left; margin-top: -290px; padding-left: 14px;">
                         <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                    </td>
                        <td style="  float: left;    line-height: 16px;    margin-top: -260px;  padding-left: 14px;
    width: 550px;">
                         <asp:Label ID="lbDesc" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="float:left; margin-top: -190px; padding-left: 14px;">
                    <asp:Label ID="lbLikeCount" runat="server" Text="" ToolTip="Like"></asp:Label>
                   <asp:LinkButton ID="lnkInspLike" runat="server" 
                   Text="" Style="color: #53AFB0;" onclick="lnkInspLike_Click"></asp:LinkButton>
                    </td>
                    <td style="float:left; margin-top: -190px; padding-left: 68px;">
                    <asp:Label ID="lbCommentCount" runat="server" Text=""></asp:Label>
                     <asp:LinkButton ID="lnkComments" runat="server"  Enabled="false"
                       Text="Comments" Style="color: #53AFB0;" onclick="lnkComments_Click"></asp:LinkButton>
                    </td>
                   <asp:Panel ID="PanelHS" runat="server">
                    <td  style="float:left;  margin-left: 158px; margin-top: -190px;">
                    <asp:LinkButton ID="lnkcollect" runat="server" Text="Collect Inspirator" 
                            Style="color: #53AFB0;" onclick="lnkcollect_Click"></asp:LinkButton>
                    </td>
                    <td style="float:left;    margin-left: 282px;  margin-top: -190px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/images/Flag-red-icon.png" 
                            onclick="ImageButton1_Click" ToolTip="Flag as Inappropriate" OnClientClick="return confirm('Are you sure you want to flag this?')"  />
                    </td>
                    </asp:Panel>
                    <td style="float:left;">
                    <asp:TextBox ID="txtComments" runat="server" ValidationGroup="a" style="   border: 1px solid #CCCCCC; 
    border-radius: 2px 2px 2px 2px;    float: left;    height: 43px;    margin-left: 18px;    margin-top: -114px;
    padding-left: 7px;    text-align: left;    width: 309px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Comment" ControlToValidate="txtComments" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:Button ID="btnComment" runat="server" Text="Comment"  
                            style=" float: right;    margin-right: 181px;    margin-top: -101px;" onclick="btnComment_Click" ValidationGroup="a"/>
                    </td>
					  </tr>
            </table>
                    
                    <div style="  margin-left: 368px;   margin-top: -63px;">
                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                            <div style=" background: none repeat scroll 0 0 #0E7C77; border-bottom: 1px solid #FFFFFF; color: #FFFFFF; margin-left: -5px; padding-bottom: 5px; padding-top: 5px; width: 427px;">                                   
                                        <div style="float: left;    padding-left: 15px; width:90px;">
                                           
                                            <asp:Label ID="lbCName" runat="server" Text='<%#Eval("first_name") %>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text=":"></asp:Label>
                                        </div>
                                        <div style="float:left;   padding-left: 15px; width:300px; ">
                                         <asp:Label ID="lbCDesc" runat="server" Text='<%#Eval("InspiratorComment_text") %>'></asp:Label>
                                        </div>
                              
								
                                </div>
								<br/>
								<br/>
								
								
                         </ItemTemplate>
                        </asp:Repeater>
                    </div>
					
              
        </ContentTemplate>
    </asp:UpdatePanel>
    
     <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="UpdatePnlInspirator">
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
