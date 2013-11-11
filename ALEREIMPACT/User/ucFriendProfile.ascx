<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFriendProfile.ascx.cs"
    Inherits="ALEREIMPACT.User.ucFriendProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript">
         function parentwindow1() {
        
            window.parent.location.href = "Wall.aspx";
        }
</script>

<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function txtrep() {
        
    var newtext = "Please wait...";
    document.getElementById('<%= btnsendfrdrequest.ClientID %>').value = newtext;
}
</script>

<script type="text/javascript">
    function txtrep1() {
        
    var newtext = "Please wait...";
    document.getElementById('<%= btnSendMessage.ClientID %>').value = newtext;
}
</script>

<style type="text/css">
    .cls
    {
        color: #C4C4C4;
    }
</style>
<asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server">
    <ContentTemplate>
        <div class="main_cont_miss">
            <div class="thumb_img_miss">
                <div class="thuumb_des_miss">
                    <a href="#">
                        <img src="" id="imgFriendphoto" runat="server" width="105" height="120" /></a></div>
                <div class="contact_detail_miss">
                    <div class="name_miss_des">
                        <asp:Label ID="lbName" runat="server"></asp:Label></div>
                    <asp:Label ID="lbAddress" runat="server" Style="display: none;"></asp:Label>
                    <div class="email_miss_des">
                        <asp:Label ID="lbemail" runat="server"></asp:Label></div>
                    <div class="send_invitation">
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Style="float: left;
                            height: 87px; margin-right: 17px; width: 234px;"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtMessage"
                            WatermarkText="Type Message" WatermarkCssClass="cls">
                        </asp:TextBoxWatermarkExtender>
                        <asp:Button ID="btnsendfrdrequest" runat="server" Text="Send Invitation" OnClientClick="txtrep()"
                            OnClick="btnsendfrdrequest_Click" class="submit_req" Style="background: none repeat scroll 0 0 #28A88F;
                            border: medium none navy; border-radius: 3px 3px 3px 3px; color: #FFFFFF; float: left;
                            font-family: myriad pro; font-size: 17px; padding: 5px; cursor: pointer;"></asp:Button>
                        <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" OnClientClick="txtrep1()"
                            OnClick="btnSendMessage_Click" class="submit_req" Style="margin-top: 28px; background: none repeat scroll 0 0 #28A88F;
                            border: medium none navy; border-radius: 3px 3px 3px 3px; color: #FFFFFF; float: left;
                            font-family: myriad pro; font-size: 17px; padding: 5px; cursor: pointer;" />
                    </div>
                    <div style="padding-top: 40px">
                        <asp:Label ID="lbmemberinvitation" runat="server" Text="" Visible="false" Style="color: #52ADAE;
                            float: left; font-family: myriad pro; font-size: 16px; font-weight: bold; line-height: 17px;
                            margin-top: 9px;"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <div  style="float: left; margin-top: 15px;">
                <div id="divUnres" runat="server" style="float: left;  height: 390px;
    overflow-x: hidden;
    overflow-y: scroll;">
                    <span style="float: left; font-size: 18px; margin-bottom: 11px; margin-left: 50px;
                        font-family: Arial; margin-top: 9px;">Public Unrestricted Circles </span>
                    <asp:Label ID="lbl_public_circle_msg" runat="server" Text="Not Found" Visible="false"
                        Style="color: red; float: left; font-size: 14px;font-family:Arial; margin-left: 45px; margin-top: 8px;"></asp:Label>
                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                        OnItemDataBound="DataList1_ItemDataBound">
                        <ItemTemplate>
                            <div id="dvimagecircle" runat="server" style="margin-top: 36px;">
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%# Container.ItemIndex + 1 %>' />
                                <asp:HiddenField ID="hiddenCircleID" runat="server" Value='<%#Eval("fk_circle_id")%>' />
                                <asp:HiddenField ID="HiddenUserID" runat="server" Value='<%#Eval("fk_user_registration_Id")%>' />
                                <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image")%>' />
                                <%-- <asp:ImageButton ID="imgBtnImage" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>'
                                    OnClick="imgBtnImage_Click" />--%>
                                <asp:LinkButton ID="lnkBtnView" runat="server" CommandName="lnkView"  OnClick="lnkBtnView_Click" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("pk_circle_id") %>'
                                    Style="cursor: pointer;">
                                    <ul class="ch-grid">
                                        <li>
                                            <div id="divCircle" class="ch-item ch-img-1" runat="server">
                                                <span style="  color: #FFFFFF !important; font-family: arial; font-size: 14px;
    margin-left: -36px !important;  margin-top: 55px !important;  text-align: center;  width: 71px; word-wrap: break-word;">
                                                    <%#Eval("circle_name")%></span>
                                                <div id="divHoverColor" runat="server" class="ch-info" style="margin-top: 0 !important;
                                                    cursor: pointer; line-height: 16px !important;">
                                                    <span style="border-bottom: none; margin-top: 30px; float: left; font-family: arial;
                                                        font-size: 14px;">
                                                        <%#Eval("name")%></span><br />
                                                    <span style="  font-family: arial;
    font-size: 14px;
    text-align: center;
    width: 109px;
    word-wrap: break-word;">
                                                        <%#Eval("circle_name")%></span>
                                                    <p>
                                                        <%#Eval("members")%>
                                                        Members
                                                        <br />
                                                        <%#Eval("missions")%>
                                                        Missions</p>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </asp:LinkButton>
                                <%--<asp:Image ID="Image2" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>' />--%>
                            </div>
                            <%--  <br />
                            <asp:Label ID="lbCircle" runat="server" Text='<%#Eval("circle_name") %>' Style="float: left;
                                font-size: 15px; margin-left: 35px !important;"></asp:Label>--%>
                        </ItemTemplate>
                    </asp:DataList>
                    <br />
                    <hr style="margin-left: 7px; margin-top: 30px; width: 961px;" />
                </div>
                <div style="float: left; margin-top: 15px; height: 390px;  width: 985px;
    overflow-x: hidden;
    overflow-y: scroll;" id="divPublicRestricted" runat="server">
                    <span style="float: left; font-size: 18px; margin-bottom: 11px; margin-left: 50px;
                        font-family: Arial; margin-top: 9px;">Public Restricted Circles </span>
                    <asp:Label ID="lblRestrictedMsg" runat="server" Text="Not Found" Visible="false"
                        Style="color: red; float: left; font-size: 14px;font-family:Arial; margin-left: 45px; margin-top: 8px;"></asp:Label>
                    <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                        OnItemDataBound="DataList2_ItemDataBound">
                        <ItemTemplate>
                            <div id="dvimagecircleRestricted" runat="server" style="margin-top: 36px;">
                                <asp:HiddenField ID="hdnIdRestricted" runat="server" Value='<%# Container.ItemIndex + 1 %>' />
                                <asp:HiddenField ID="hiddenCircleIDRestricted" runat="server" Value='<%#Eval("fk_circle_id")%>' />
                                <asp:HiddenField ID="HiddenUserIDRestricted" runat="server" Value='<%#Eval("fk_user_registration_Id")%>' />
                                <asp:HiddenField ID="hndcolorRestricted" runat="server" Value='<%#Eval("circle_color")%>' />
                                <asp:HiddenField ID="hdnPermissionID" runat="server" Value='<%#Eval("fk_circle_permission_id") %>' />
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image")%>' />
                                <%--  <asp:ImageButton ID="imgBtnImageRestricted" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>'
                                    OnClick="imgBtnImageRestricted_Click" />--%>
                                <asp:LinkButton ID="lnkBtnView1" runat="server" CommandName="lnkView" OnClick="lnkBtnView1_Click" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("pk_circle_id") %>'
                                    Style="cursor: pointer;">
                                    <ul class="ch-grid">
                                        <li>
                                            <div id="divCircle" class="ch-item ch-img-1" runat="server">
                                                <span style=" color: #FFFFFF !important; font-family: arial; font-size: 14px;
    margin-left: -36px !important;  margin-top: 55px !important;  text-align: center;  width: 71px; word-wrap: break-word;">
                                                    <%#Eval("circle_name")%></span>
                                                <div id="divHoverColor" runat="server" class="ch-info" style="margin-top: 0 !important;
                                                    cursor: pointer; line-height: 16px !important;">
                                                    <span style="border-bottom: none; margin-top: 30px; float: left; font-family: arial;
                                                        font-size: 14px;">
                                                        <%#Eval("name")%></span><br />
                                                    <span style="  font-family: arial;
    font-size: 14px;
    text-align: center;
    width: 109px;
    word-wrap: break-word;">
                                                        <%#Eval("circle_name")%></span>
                                                    <p>
                                                        <%#Eval("members")%>
                                                        Members
                                                        <br />
                                                        <%#Eval("missions")%>
                                                        Missions</p>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </asp:LinkButton>
                                <%--<asp:Image ID="Image2" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>' />--%>
                            </div>
                            <%-- <br />
                            <asp:Label ID="lbCircleRestricted" runat="server" Text='<%#Eval("circle_name") %>' Style="float: left;
                                font-size: 15px; margin-left: 30px !important;"></asp:Label>--%>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <%--<div style="background: none repeat scroll 0 0 #FFFFFF; border-radius: 2px 2px 2px 2px;
            box-shadow: 1px 1px 3px #999999; float: left; margin-top: 12px; width: 980px;
            height: 500px">
            <div id="content" class="clearfix">
                <section id="left">
			<div id="userStats" class="clearfix">
				<div class="pic">
					
				</div>
				
				<div class="data">
					<h1></h1>
					<h3></h3>
					<h4></h4>
					
					<div class="sep"></div>
					<div style="padding-top:0px">
					
					</div>
					
					
				</div>
			</div>

		</section>
                <section id="right">

		</section>
            </div>
        </div>--%>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnsendfrdrequest" />
    </Triggers>
</asp:UpdatePanel>
