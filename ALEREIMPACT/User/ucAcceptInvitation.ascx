<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAcceptInvitation.ascx.cs" Inherits="ALEREIMPACT.User.ucAcceptInvitation" %>
  <script type="text/javascript">
      function parentwindow() {
        
            window.parent.location.href = "Wall.aspx";
        }
    </script>
    <script type="text/javascript">
         function parentwindow1() {
        
            window.parent.location.href = "Wall.aspx";
        }
</script>
   <%-- <link rel="stylesheet" href="../CSS/stylenewdesign.css" type="text/css" />--%>
<%--    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/Circlestyle.css" type="text/css" />
    <link rel="stylesheet" href="../CSS/global.css" type="text/css" />--%>
    
<asp:UpdatePanel ID="UpdateAcceptInvitation" runat="server">
<ContentTemplate>
<%--<div class="accept_invitation_btn" style=" float: left; margin-left: 1057px; margin-top: 15px !important;
    padding: 2px !important;  position: absolute; width: 128px !important;">
    <asp:Button ID="btnAcceptInvitation" runat="server" Text="Accept Invitation" OnClick="btnAcceptInvitation_Click"  style=" background: none repeat scroll 0 0 #0B7974;  border-radius: 3px 3px 3px 3px;  box-shadow: 1px 2px 5px #CCCCCC;
    color: #FFFFFF; padding: 2px;" />
   
</div>--%>
<asp:Button ID ="btnJoinPublicGroup" runat ="server" style=" background-color: #009999;
    border-radius: 5px 5px 5px 5px;
    border-width: 0;
    color: #FFFFFF;
    cursor: pointer;
    float: right;
    font-size: 15px;
    font-weight: bold;
    height: 22px;
    margin: 10px 42px 0 873px;
    padding-top: 0;
    position: absolute;
    width: 55px;"
   Text="Join" ToolTip="Join Public Circle" BorderColor="Black" BackColor="#009999" OnClick="btnJoinPublicGroup_Click" />
   <br />
    <asp:Label ID="lbJoin" runat="server" Visible="false" Text="You will need approve all  requests before someone can join this circle" style=" color: gray;
    float: right;
    font-family: arial;
    font-size: 12px;
    margin-right: 194px;
    margin-top: 19px;"></asp:Label>
    
    <asp:ImageButton ID="btnAcceptInvitation" runat="server" ImageUrl="~/images/send-_req11.png" style="   border-width: 0;
    float: right;
    margin: -3px 42px 0 873px;
    position: absolute;" OnClick="btnAcceptInvitation_Click" />
   
</ContentTemplate>
<%--<ContentTemplate>


</ContentTemplate>--%>
<Triggers>
<asp:PostBackTrigger ControlID="btnAcceptInvitation" />
</Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="uplblMsg" runat="server" Visible="false">
<ContentTemplate>
<asp:Label ID="lblmsgRequestSent" runat="server" Height="22px" style=" background-color: #009999;
    border: medium none;
    display: inline-block;
    float: right;
    font-size: 15px;
    font-weight: bold;
    height: 22px;
    margin: 3px 42px 0 839px;
    padding-left: 8px;
    padding-top: 3px;
    position: absolute;
    width: 98px; " Text="Request Sent" Width="22px"></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>
 <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="UpdateAcceptInvitation">
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