<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFriendInspirator.ascx.cs" Inherits="ALEREIMPACT.User.ucFriendInspirator" %>
<div>
<asp:UpdatePanel ID="UpdatePanelInspirator" runat="server">
<ContentTemplate>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<div id="breadcrumb">
           
        
            <a href="Inspirators.aspx" >Inspirators</a>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#45B5B0;">Member's Inspirators</span>
        </div>
        
          <div  style="   float: right;
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
 <tr style="float:left; margin-left:12px;">
 <td  valign="top" style="float:left;">
 <asp:Label ID="lbNorecord" runat="server" Visible="false" style="color:Gray; text-align:center; margin-left: 350px;"></asp:Label>
     <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" 
         onitemdatabound="DataList1_ItemDataBound" 
         onitemcommand="DataList1_ItemCommand" >
     <ItemTemplate>
     <asp:Panel ID="PanelInsp" runat="server">
     <table style="border:1px solid #E2E2E2; margin-right:15px;     margin-bottom: 21px;" valign="top">
     <tr valign="top">
     <td>
         <asp:HiddenField ID="hdnUserid" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
          <asp:HiddenField ID="hdnInspiratorid" runat="server" Value='<%#Eval("pk_Inspirator_id") %>' />
          <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("Inspirator_image") %>' />
          <a id="aimage" runat="server">
         <asp:Image ID="Image1" runat="server" style="  border-width: 0;
    height: 200px;
    margin-left: 2px;
    width: 200px;" />
         </a>
</td>        
     </tr>
    
     <tr valign="top">
     <td>
         <asp:Label ID="lbDesc" runat="server" Text='<%#Eval("Inspirator_desc") %>' style="color: #444444;    float: left;
    font-family: arial;    font-size: 13px;    line-height: 14px;    width: 184px;"></asp:Label>
     </td>
     </tr>
     <tr valign="top" style="margin-top:5px;">
     <td style="float:left; margin-right:17px; margin-top:9px;">
         <asp:Label ID="lbLikeCount" runat="server" Text=""></asp:Label>
         <asp:LinkButton ID="lnkLike" runat="server" Text=""  style="color:#53AFB0;" CommandName="Like"  CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
         </td>
          <td style="float:left;  margin-right:19px; margin-top:9px;">
           <asp:Label ID="lbCommentCount" runat="server" Text=""></asp:Label>
         <asp:LinkButton ID="lnkComment" runat="server" Text="Comments" Enabled="false" style="color:#53AFB0;" CommandName="Comment"  CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
         </td>
        <td style=" float: left;  margin-right: 5px;  margin-top: 0px;">
             <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Flag as Inappropriate" CommandName="Inappropriate" CommandArgument='<%#Eval("pk_Inspirator_id") %>' ImageUrl="~/images/Flag-red-icon.png" OnClientClick="return confirm('Are you sure you want to flag this?')"  />
        <%-- <img src="../images/Flag-red-icon.png" alt="" runat="server" />--%>
         </td>
     </tr>
     </table>
     </asp:Panel>
     </ItemTemplate>
     
     </asp:DataList>
 </td>
 </tr>
 <tr>
 <td>
      <asp:LinkButton ID="lnkViewMore" runat="server" Text="View More"  style="   color: #53AFB0;  float: right; font-size: 20px; font-weight: bold;  padding-right: 113px; text-decoration: underline;" onclick="lnkViewMore_Click"></asp:LinkButton>

 </td>
 </tr>
 </table>

</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="UpdatePanelInspirator">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div>
                        Processing...
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" />
                </asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>