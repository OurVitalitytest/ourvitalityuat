<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPendingFriendRequests.ascx.cs"
    Inherits="ALEREIMPACT.User.ucPendingFriendRequests" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
         function parentwindow() {
            window.parent.location.href = "Wall.aspx";
        }
</script>

<style>
    .thumb_img_c
    {
        float: left;
    }
    .left_btm_miss span
    {
        float: left;
        font-family: arial;
        font-size: 14px;
        margin-left: 6px;
        margin-top: 1px;
    }
    .thumb
    {
        background-color: #FFFFFF;
        border: 5px solid #0B706B;
        border-radius: 120px 120px 120px 120px;
        float: left;
        height: 60px;
        margin-bottom: 31px;
        margin-left: 2px;
        margin-top: -32px;
        width: 60px;
    }
    .friend_circle_req
    {
        float: right;
        margin-right: 67px;
        margin-top: -9px;
        margin-left: 86px;
    }
</style>
<div class="main_cont_miss">
    <asp:UpdatePanel ID="udpUpdatePanelPendingrequests" runat="server">
        <ContentTemplate>
            <%-- <div style="padding-top: 18px; padding-bottom: 20px; font-size: 14px; border-radius: 5px 5px 0 0;
                font-family: arial; font-weight: normal; color: White; width: 980px; background-color: #388A82">
                <span style="padding-left: 10px;">Pending Invitation List</span> <span style="width: 430px;
                    float: right; font-size: 14px">* Click on the Circle to know more about it and to
                    join the Circle</span>
            </div>--%>
              
              <div class="top_his_miss" style="margin-top: 0 !important; padding-left: 11px !important;
                    width: 964px !important;">
                    <div class="bread_miss">
                        <span class="mission_miss" style="font-size: 16px; margin-top: 4px; font-weight: bold;">
                            Pending Invitation List </span>
                        <div class="arrow_miss">
                        </div>
                    </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>
            <div class="pending_circle_list">
                <asp:DataList ID="dlPendingRequests" runat="server" CellPadding="3" CellSpacing="30"
                    RepeatColumns="2" BorderColor="Gray" BorderStyle="Solid" OnItemDataBound="dlPendingRequests_ItemDataBound"
                    OnItemCommand="dlPendingRequests_ItemCommand">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("pk_user_circle_id") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnCircleId" runat="server" Value='<%#Eval("Mcircleid") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("Muserid") %>'></asp:HiddenField>
                        <asp:HiddenField ID="hdnColor" runat="server" Value='<%#Eval("circle_color") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("Mcircleimage") %>'>
                        </asp:HiddenField>
                        <div class="border_list">
                            <div class="left_pending_list_circle">
                                <div class="thumb_bg_pending_list_main">
                                <asp:HiddenField ID="hdnIMIMage" runat="server" Value='<%#Eval("memberimage") %>' />
                                    <asp:Image ID="frdimage" runat="server" CssClass="thumb_img_c" Style="height: 119px;
                                        width: 124px;"  />
                                    <div class="blue_bar_name">
                                        <span style="height: 28px; width: 126px;">
                                            <asp:Label ID="lbfrdname" runat="server" Text='<%#Eval("membernametop") %>' ToolTip='<%#Eval("membername") %>'></asp:Label></span>
                                    </div>
                                </div>
                                <div class="cirlce_pending" style="float: left; margin-left: 200px; margin-top: -140px;">
                                    <ul class="ch-grid1" style="float: left; margin-left: 28px;">
                                        <li>
                                            <asp:LinkButton ID="lnkBtnView" runat="server" CommandName="lnkView" CommandArgument='<%#Eval("Muserid")+";"+Eval("Mcircleid") %>'
                                                Style="cursor: pointer;">
                                                <div id="divCircle" runat="server" class="ch-item1 ch-img-31">
                                                    <span style="float: left; font-family: arial; margin-left: -30px; margin-top: -17px;
                                                        width: 64px; word-wrap: break-word;">
                                                        <%#Eval("Mcirclename")%></span>
                                                    <div id="divHoverColor" runat="server" class="ch2-info1" style="margin-top: -60px !important;  cursor:pointer;">
                               
                                                        <span style="border-bottom: medium none; float: left; font-family: arial; margin-top: 40px;
                                                            text-transform: none !important; width: 90px; word-wrap: break-word;">
                                                            <%#Eval("membername")%></span>
                                                        <%-- <span style=" font-family: arial;
    font-size: 14px;
    line-height: 15px;
    text-align: center;
    width: 101px;
    word-wrap: break-word;"><%#Eval("circle_name")%></span>--%>
                                                        <%--<p style=" padding: 0px !important; font-family: arial;"><%#Eval("members")%> Members <br/><%#Eval("missions")%> Missions</p>--%>
                                                    </div>
                                                </div>
                                            </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                                <div class="pendin_text_circle" style="width: 400px;">
                                <asp:HiddenField  ID="hdnMEmbername" runat="server" Value='<%#Eval("membername")%>'/>
                                    <asp:HiddenField  ID="hdnCircleName" runat="server" Value='<%#Eval("Mcirclename")%>'/>
                                      <asp:HiddenField  ID="hdnPermissionId" runat="server" Value='<%#Eval("fk_request_status_id")%>'/>
                                    
                                    <asp:Label ID="lbJoinCircle" runat="server" Text="Label"></asp:Label>
                                    <%--"" &nbsp; has invited you to Join their &nbsp; "<%#Eval("Mcirclename")%>"--%>
                                </div>
                            </div>
                        </div>
                        <%--<div id="dvborder" runat="server" class="border_list" style="margin-left: 183px; height: 260px;">
                        </div>--%>
                    </ItemTemplate>
                </asp:DataList>
            </div>
          
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpUpdatePanelPendingrequests">
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
