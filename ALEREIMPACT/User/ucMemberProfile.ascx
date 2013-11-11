<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberProfile.ascx.cs"
    Inherits="ALEREIMPACT.User.ucMemberProfile" %>

<script type="text/javascript">
         function parentwindow1() {
        
            window.parent.location.href = "Wall.aspx";
        }
</script>

<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Circlestyle.css" rel="stylesheet" type="text/css" />
<div>
    <asp:UpdatePanel ID="UpdatePanel_Profile" runat="server">
        <ContentTemplate>
            <div class="main_cont_miss">
                <div class="bread_miss" style="margin-left: 15px; margin-top: 10px;">
                    <span class="mission_miss">Member Profile</span>
                </div>
                <div class="thumb_img_miss">
                    <div class="thuumb_des_pro" style="border: 1px solid #CCCCCC; border-radius: 2px 2px 2px 2px;
                        float: left; margin-bottom: 34px; margin-left: 52px; margin-top: 32px; width: 877px;">
                        <asp:Image ID="Image1" runat="server" Style="float: left; width: 180px; height: 180px;" />
                        <div class="contact_detail_miss" style="float: left; margin: 61px 0 0 40px; width: auto;">
                            <div class="name_miss_des">
                                <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="email_miss_des">
                                <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="msg_send" style="margin-top: 131px !important;">
                            <asp:LinkButton ID="lnkMessage" runat="server" Text="Message" OnClick="lnkMessage_Click"></asp:LinkButton>
                        </div>
                        <div class="friends" style="margin-top: 72px !important;">
                            <asp:LinkButton ID="lnkMembers" runat="server" Text="Members" OnClick="lnkMembers_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <br />
                <div id="dvPublic" runat="server" style=" display:none; float: left;
  height: 390px;
    overflow-x: hidden;
    overflow-y: scroll;
    width: 972px;">
                    <span style=" font-size: 18px; margin-bottom: 11px; margin-left: 50px;    font-family: arial;
                        margin-top: 9px;">Public Unrestricted Circles </span>
                    <br />
                    <asp:Label ID="lbPublicUnres" runat="server" Text="No Record Found.." Visible="false"></asp:Label>
                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="6"
                        OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand" style="margin-left: 22px;">
                        <ItemTemplate>
                            <div id="dvimagecircle" runat="server" style="    margin-top: 36px;">
                                 <asp:HiddenField ID="hdnId" runat="server" Value='<%# Container.ItemIndex + 1 %>' />
                                <asp:HiddenField ID="hiddenCircleID" runat="server" Value='<%#Eval("fk_circle_id")%>' />
                                <asp:HiddenField ID="HiddenUserID" runat="server" Value='<%#Eval("fk_user_registration_Id")%>' />
                                <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image")%>' />
                                   <asp:LinkButton ID="lnkBtnView" runat="server" CommandName="lnkView" OnClick="lnkBtnView_Click" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("pk_circle_id") %>' style="cursor:pointer;">
                      <ul class="ch-grid">
					<li>
						<div id="divCircle" class="ch-item ch-img-1" runat="server"><span style="  color: #FFFFFF !important; font-family: arial; font-size: 14px;
    margin-left: -36px !important;  margin-top: 55px !important;  text-align: center;  width: 71px; word-wrap: break-word;"><%#Eval("circle_name")%></span>
							<div id="divHoverColor" runat="server" class="ch-info" style=" margin-top: 0 !important;cursor: pointer;line-height: 16px !important;">
								<span style="border-bottom:none; margin-top:30px; float:left;font-family: arial;  font-size: 14px; "><%#Eval("name")%></span><br/>
                                <span style=" font-family: arial;
    font-size: 14px;
    text-align: center;
    width: 109px;
    word-wrap: break-word;"><%#Eval("circle_name")%></span>
								<p><%#Eval("members")%> Members <br/><%#Eval("missions")%> Missions</p>
							</div>
						</div>
					</li> 
                        </ul>
                        </asp:LinkButton>
                             <%--   <asp:ImageButton ID="imgBtnImage" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>'
                                    OnClick="imgBtnImage_Click" />--%>
                                <%--<asp:Image ID="Image2" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>' />--%>
                            </div>
                        <%-- <br />
                            <asp:Label ID="lbCircle" runat="server" Text='<%#Eval("circle_name") %>' Style="float: left;
                                font-size: 15px; margin-left: 30px !important;"></asp:Label>--%>
                        </ItemTemplate>
                    </asp:DataList>
                    <br />
                    <hr style="   margin-left: 7px;
    margin-top: 30px;
    width: 964px;"/>
                    </div>
                      
               
                    <div id="dicPublicRestricted" runat="server" style="width: 972px; display:none; float: left;
height: 390px;
    overflow-x: hidden;
    overflow-y: scroll;">
                    <span style=" font-size: 18px; margin-bottom: 11px; margin-left: 50px;font-family:Arial;
                        margin-top: 9px;">Public Restricted Circles </span>
                    <br />
                     <asp:Label ID="lbREs" runat="server" Text="No Record Found.." Visible="false"></asp:Label>
                    <asp:DataList ID="DataList2" runat="server"  RepeatDirection="Horizontal" RepeatColumns="6" OnItemDataBound="DataList2_ItemDataBound" OnItemCommand="DataList2_ItemCommand">
                    <ItemTemplate>
                    <div id="dvimagecircleRestricted" runat="server" style=" margin-top: 36px;">
                                 <asp:HiddenField ID="hdnIdRestricted" runat="server" Value='<%# Container.ItemIndex + 1 %>' />
                                <asp:HiddenField ID="hiddenCircleIDRestricted" runat="server" Value='<%#Eval("fk_circle_id")%>' />
                                <asp:HiddenField ID="HiddenUserIDRestricted" runat="server" Value='<%#Eval("fk_user_registration_Id")%>' />
                                <asp:HiddenField ID="hndcolorRestricted" runat="server" Value='<%#Eval("circle_color")%>' />
                                <asp:HiddenField ID ="hdnPermissionID" runat ="server" Value='<%#Eval("fk_circle_permission_id") %>' />
                    <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image")%>' />
                                <%--<asp:ImageButton ID="imgBtnImageRestricted" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>'
                                    OnClick="imgBtnImageRestricted_Click" />--%>
                                     <asp:LinkButton ID="lnkBtnView1" runat="server" CommandName="lnkView" OnClick="lnkBtnView1_Click" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("pk_circle_id") %>' style="cursor:pointer;">
                      <ul class="ch-grid">
					<li>
						<div id="divCircle" class="ch-item ch-img-1" runat="server"><span style=" color: #FFFFFF !important; font-family: arial; font-size: 14px;
    margin-left: -36px !important;  margin-top: 55px !important;  text-align: center;  width: 71px; word-wrap: break-word;"><%#Eval("circle_name")%></span>
							<div id="divHoverColor" runat="server" class="ch-info" style=" margin-top: 0 !important;cursor: pointer;line-height: 16px !important;">
								<span style="border-bottom:none; margin-top:30px; float:left;font-family: arial;  font-size: 14px; "><%#Eval("name")%></span><br/>
                                <span style=" font-family: arial;
    font-size: 14px;
    text-align: center;
    width: 109px;
    word-wrap: break-word;"><%#Eval("circle_name")%></span>
								<p><%#Eval("members")%> Members <br/><%#Eval("missions")%> Missions</p>
							</div>
						</div>
					</li> 
                        </ul>
                        </asp:LinkButton> 
                                    
                                    
                               
                            </div>
                            
                          <%--  <br />
                            <asp:Label ID="lbCircleRestricted" runat="server" Text='<%#Eval("circle_name") %>' Style="float: left;
                                font-size: 15px; margin-left: 30px !important;"></asp:Label>--%>
                    
                    </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
