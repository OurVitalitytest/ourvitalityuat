<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUserProfile.ascx.cs"
    Inherits="ALEREIMPACT.User.ucUserProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .friends_dp_pic
    {
        float: left;
        margin-bottom: 10px;
        margin-left: 20px;
    }
    .cls
    {
        color: #777777;
    }
    .ins_box_pop_up {
    background: none repeat scroll 0 0 #FFFFFF;
    border: 5px solid #444444;
    border-radius: 10px 10px 10px 10px;
    box-shadow: 2px 5px 4px #444444;
    height: 450px;
    margin: 125px auto !important;
    opacity: 1;
    width: 750px;
    z-index: 999;
}
.heading_pop_up {
    float: left;
    font-family: arial;
    font-size: 20px;
    margin: 15px 0 0 15px;
    width: 500px;
}
.ins_popup {
    float: left;
    margin-left: 15px;
    margin-top: 10px;
    width: 250px;
}
.ins_text {
    float: left !important;
    font-family: arial;
    font-size: 13px !important;
    line-height: 20px !important;
    width: 475px !important;
}
.ins_like {
    float: left !important;
    font-family: arial !important;
    font-size: 11px !important;
    font-weight: bold !important;
    margin-right: 10px !important;
    margin-top: 15px !important;
}
.ins_submit {
    background: none repeat scroll 0 0 #333333;
    border-radius: 5px 5px 5px 5px;
    color: #FFFFFF;
    float: right !important;
    font-family: arial !important;
    font-size: 12px !important;
    margin-right: 36px !important;
    margin-top: 7px !important;
    padding: 2px 5px !important;
}
.main_pop_up_box_miss {
    background: none repeat scroll 0 0 #F9F9F9;
    height: 1250px !important;
    left: 0 !important;
    opacity: 1 !important;
    position: absolute !important;
    top: -2px !important;
    width: 100% !important;
    z-index: 100001 !important;
}
.ins_submit {
    color: #FFFFFF;
    font-family: arial !important;
    font-size: 12px !important;
}

.ins_des_box {
    background: none repeat scroll 0 0 #EEEEEE;
    float: left !important;
    line-height: 10px !important;
    margin-top: 1px;
    width: 100%;
}
.left_ins_comment {
    float: left !important;
    font-family: arial;
    font-size: 14px !important;
    font-weight: bold;
    margin-left: 7px !important;
    margin-right: 5px;
    padding-bottom: 2px;
    padding-top: 2px;
}
.rgt_ins_comments {
    float: none !important;
    font-family: arial;
    font-size: 13px !important;
    margin-left: 7px !important;
    padding-bottom: 2px;
    padding-top: 2px;
}
.ins_comment_box {
    float: left !important;
    height: 150px;
    margin-top: 24px;
    overflow-x: hidden;
    overflow-y: scroll;
    width: 484px;
}
</style>

<script type="text/javascript">
         function parentwindow3() {

            window.parent.location.href = "Wall.aspx";
        }
</script>

<div>
    <asp:UpdatePanel ID="udpUpdatePanelUserProfile" runat="server">
        <ContentTemplate>
            <div class="main_cont_miss" style="margin-left: 0 !important; margin-top: 0 !important;
                width: 969px !important;">
                <div class="top_his_miss" style="height: 3px; margin-top: 0 !important; padding-left: 11px !important;
                    padding-top: 11px; width: 958px !important;">
                    <div class="bread_miss">
                        <span class="mission_miss" style="font-size: 16px; margin-top: 4px; font-weight: bold;">
                            Profile </span>
                        <div class="arrow_miss">
                        </div>
                    </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>
                <div class="user_info_profile" style="margin-left: 3px !important;">
                    <div class="profile_pic">
                        <asp:Image ID="imgProfile" runat="server" Style="height: 100px; width: 100px;" />
                    </div>
                    <div class="right_dp_info" style="margin-bottom: 40px !important; margin-left: 135px !important;
                        margin-top: -65px !important;">
                        <div class="profile_user_name" style="line-height: 19px !important; font-size: 14px !important;">
                            <asp:Label ID="lbUserName" runat="server"></asp:Label>
                        </div>
                        <div class="profile_user_circlename" style="line-height: 19px !important; font-size: 13px !important;">
                            <asp:Label ID="lbEmail" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left;">
                        <div id="dvDOB" runat="server" visible="false" style="overflow:hidden; width:94%; padding:10px; border-bottom: 1px solid #CCCCCC;">
                            <span style="float: left;width: 85px;">D.O.B :</span>
                            <div style="float: left;">
                                <asp:Label ID="lbDOB" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div id="dvHeight" runat="server" visible="false" style="overflow:hidden; width:94%; padding:10px; border-bottom: 1px solid #CCCCCC;">
                            <span style="float: left;width: 85px;">Height :</span>
                            <div style="float: left;">
                                <asp:Label ID="lbHeight" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div id="dvWeight" runat="server" visible="false" style="overflow:hidden; width:94%; padding:10px; border-bottom: 1px solid #CCCCCC;">
                            <span style="float: left;width: 85px;">Weight :</span>
                            <div style="float: left;">
                                <asp:Label ID="lbWeight" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div id="dvLocation" runat="server" visible="false" style="overflow:hidden; width:94%; padding:10px; border-bottom: 1px solid #CCCCCC;">
                            <span style="float: left;width: 85px;">Location :</span>
                            <div style="float: left;">
                                <asp:Label ID="lbLocation" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="friends_lst_head" style="line-height: 21px !important; font-size: 18px !important;">
                        <span>Circles</span>
                    </div>
                    <div class="friends_lst" style="overflow: scroll; height: 275px; overflow-x: hidden;">
                        <asp:Label ID="lbCircle" runat="server" Text="No Circle Found.." Visible="false"
                            Style="font-family: Arial;"></asp:Label>
                        <ul class="ch-grid1" style="margin-top: -29px !important;">
                            <asp:DataList ID="dlcirclelist" runat="server" CellPadding="3" CellSpacing="30" RepeatColumns="2"
                                BorderColor="Gray" BorderStyle="Solid" OnItemDataBound="dlcirclelist_ItemDataBound" OnItemCommand="dlcirclelist_ItemCommand">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                    <asp:HiddenField ID="hdnCircleId" runat="server" Value='<%#Eval("fk_circle_id") %>' />
                                    <asp:HiddenField ID="hdnColor" runat="server" Value='<%#Eval("circle_color") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image") %>'>
                                    </asp:HiddenField>
                                    <li>
                                     <asp:LinkButton ID="lnkBtnView" runat="server" CommandName="lnkView" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("fk_circle_id")+";"+Eval("circle_name") %>' style="cursor:pointer;">
                                        <div id="divCircle" runat="server" class="ch-item1 ch-img-21" style="line-height: 14px !important;">
                                            <span style="float: left; margin-left: 25px !important; width: 65px !important; word-wrap: break-word;">
                                                <%#Eval("circle_name") %></span>
                                            <div id="divHoverColor" runat="server" class="ch1-info1" style="margin-top: -60px !important;
                                                line-height: 30px !important; font-family: Arial !important;">
                                                <span style="border-bottom: none; margin-top: 30px; margin-left: 22px !important;
                                                    float: left; font-family: arial !important;">Members (<%#Eval("freinds")%>)</span><br>
                                                <span style="border-bottom: none; font-family: arial !important; margin-left: 22px !important;">
                                                    Missions (<%#Eval("missions")%>) </span>
                                            </div>
                                        </div>
                                        </asp:LinkButton>
                                    </li>
                                    
                                </ItemTemplate>
                            </asp:DataList>
                        </ul>
                    </div>
                    <br />
                    <div class="friends_lst_head" style="line-height: 21px !important; font-size: 18px !important;
                        margin-top: 21px;">
                        <span>Members</span>
                    </div>
                    <div class="friends_lst" style="overflow: scroll; height: 275px; overflow-x: hidden;">
                        <asp:Label ID="lbmsg" runat="server" Text="Members are only accessed by owner of that circle"
                            Visible="false" Style="color: #666666; float: left; font-family: arial; font-size: 16px;
                            font-weight: bold; line-height: 27px; margin-left: 27px; margin-top: 22px; width: 264px;"></asp:Label>
                        <asp:GridView ID="GrdFreinds" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                            OnRowDataBound="GrdFreinds_RowDataBound" OnRowCommand="GrdFreinds_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("fk_user_registration_Id") %>'
                                            Visible="false"></asp:Label>
                                        <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("user_image") %>' />
                                        <asp:ImageButton ID="ImgFreind" runat="server" Style="height: 70px; float: left;
                                            width: 70px;" CommandName="ImgBtnFrnd" CommandArgument='<%#Eval("fk_user_registration_Id") %>' />
                                        <%--<asp:Image ID="ImgFreind" runat="server" Style="height: 70px; width: 70px;" />--%>
                                        <asp:Label ID="lbName" runat="server" Text='<%#Eval("name") %>' Style="margin-left: 88px !important;
                                            margin-top: -38px !important;"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="friends_dp_pic" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <span style="font-family: Arial;">No Members Found..</span>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
                <div class="rgt_rrow_dp">
                    <img src="../images/rgt_arrow.png" /></div>
                <div class="user_info_profile_detail">
                    <div class="user_circle_details" style="margin-top: 0px;">
                        <div class="heading_circle_dp_details" style="height: 119px !important; margin-top: -5px !important;">
                            <ul class="ch-grid1" style="margin-top: -31px !important; margin-left: -19px !important;">
                                <asp:DataList ID="dlCircle" runat="server" CellPadding="3" CellSpacing="30" RepeatColumns="1"
                                    BorderColor="Gray" BorderStyle="Solid" OnItemDataBound="dlCircle_ItemDataBound" >
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                        <asp:HiddenField ID="hdnCircleId" runat="server" Value='<%#Eval("fk_circle_id") %>' />
                                        <asp:HiddenField ID="hdnColor" runat="server" Value='<%#Eval("circle_color") %>'>
                                        </asp:HiddenField>
                                        <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image") %>'>
                                        </asp:HiddenField>
                                        <li>
                                        
                                            <div id="divCircle" runat="server" class="ch-item1 ch-img-21" style="line-height: 14px !important;">
                                                <span style="float: left; margin-left: 25px !important; width: 65px !important; word-wrap: break-word;">
                                                    <%#Eval("circle_name") %></span>
                                                <div id="divHoverColor" runat="server" class="ch1-info1" style="margin-top: -60px !important;
                                                    line-height: 30px !important; font-family: Arial !important;">
                                                    <span style="border-bottom: none; margin-left: 22px !important; margin-top: 30px;
                                                        float: left; font-family: arial !important;">Members (<%#Eval("freinds")%>)</span><br>
                                                    <span style="border-bottom: none; margin-left: 22px !important; font-family: arial !important;">
                                                        Missions (<%#Eval("missions")%>) </span>
                                                </div>
                                            </div>
                                           
                                        </li>
                                    </ItemTemplate>
                                </asp:DataList>
                            </ul>
                            <div id="DVDefaulrt" runat="server" visible="false">
                                <ul class="ch-grid1">
                                    <li>
                                        <div class="ch-item1 ch-img-21" style="background: none repeat scroll 0 0 #CCCCCC  !important;">
                                            <asp:Label ID="lbname1" runat="server" Style="float: left; margin-left: 32px !important;
                                                margin-top: 47px; width: 65px !important; word-wrap: break-word;">
                                            </asp:Label>
                                            <div class="ch1-info1" style="background: none repeat scroll 0 0 #CCCCCC  !important;">
                                                <asp:Label ID="lbname11" runat="server" Style="border: medium none; float: left;
                                                    font-family: arial; font-size: 13px; margin-left: 31px !important; margin-top: 45px;
                                                    width: 65px !important; word-wrap: break-word;">
                                                </asp:Label>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div id="divmsg" runat="server" visible="false" style="float: left; margin-left: 147px;
                            margin-top: -107px;">
                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Style="height: 65px;
                                padding: 5px; width: 233px;"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtMessage"
                                WatermarkText="This is my public circle, request you to join this circle." WatermarkCssClass="cls">
                            </asp:TextBoxWatermarkExtender>
                        </div>
                        <div style="float: right; margin-top: -90px;">
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" Visible="false" Style="background-color: #0C7A75;
                                border: medium none; color: #FFFFFF; cursor: pointer; float: right; height: 31px;
                                margin-right: 44px; margin-top: 0px; width: 82px;" OnClick="btnRemove_Click" />
                            <asp:Button ID="btnJoin" runat="server" Text="Join" Visible="false" Style="background-color: #0C7A75;
                                border: medium none; color: #FFFFFF; cursor: pointer; float: right; height: 31px;
                                margin-right: 44px; margin-top: 0px; width: 82px;" OnClick="btnJoin_Click" />
                                 <asp:Button ID="btnSendmsg" runat="server" Text="Send Invitation" Visible="false" Style="background-color: #0C7A75;
                                border: medium none; color: #FFFFFF; cursor: pointer; float: right; height: 36px;
                                margin-right: 44px; margin-top: 0px; width: 126px;" OnClick="btnSendmsg_Click" />
                            <asp:Label ID="lbmsgsent" runat="server" Text="Invitation to Join Circle has been sent." Visible="false" Style="float: left;
                                font-family: arial; color: #0C7A75; margin-left: 105px; margin-top: 38px;"></asp:Label>
                            <asp:Label ID="lbJoin" runat="server" Text="You will need approve all  requests before someone can join this circle"
                                Visible="false" Style="float: left; color: #0C7A75; font-family: arial; margin-left: 105px;
                                margin-top: 38px;"></asp:Label>
                            <asp:Button ID="btnInvitation" runat="server" Text="Send Invitation" Visible="false"
                                Style="background-color: #0C7A75; border: medium none; color: #FFFFFF; cursor: pointer;
                                height: 33px; margin-right: 28px; width: 124px;" OnClick="btnInvitation_Click" />
                            <asp:Button ID="btnAcceptInvitation" runat="server" Text="Accept" Visible="false"
                                Style="background-color: #0C7A75; border: medium none; color: #FFFFFF; cursor: pointer;
                                height: 33px; margin-right: 5px; width: 75px;" OnClick="btnAcceptInvitation_Click" />
                            <asp:Button ID="btnRejectInvitation" runat="server" Text="Reject" Visible="false"
                                Style="background-color: #0C7A75; border: medium none; color: #FFFFFF; cursor: pointer;
                                height: 33px; margin-right: 5px; width: 75px;" OnClick="btnRejectInvitation_Click" />
                        </div>
                    </div>
                </div>
                <%-- <div class="user_circle_details">
                        <div class="heading_circle_dp" style="line-height: 21px !important; font-size: 18px !important;">
                            Notes :
                        </div>
                        <div class="heading_mission_dp_details">
                            <ul class="mission_dp">
                                <asp:Label ID="lbNotes" runat="server" Text="No Notes Found.." Visible="false"></asp:Label>
                                <asp:DataList ID="dlNotes" runat="server" CellPadding="0" CellSpacing="0" RepeatColumns="1"
                                    BorderColor="Gray" BorderStyle="Solid">
                                    <AlternatingItemStyle CssClass="odd_dp_mission" />
                                    <ItemTemplate>
                                        <li>
                                            <asp:Label ID="lbID" runat="server" Text='<%#Eval("pk_comment_id") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lbUserID" runat="server" Text='<%#Eval("fk_user_registration_Id") %>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lbMission" runat="server" Text='<%#Eval("comment_text") %>'></asp:Label>
                                        </li>
                                    </ItemTemplate>
                                </asp:DataList>
                            </ul>
                        </div>
                    </div>--%>
                <div class="user_info_profile_detail">
                    <div class="user_circle_details" style="margin-top: 0px !important;">
                        <div class="heading_circle_dp" style="line-height: 21px !important; font-size: 18px !important;">
                            Inspirators :
                        </div>
                        <div class="heading_mission_dp_details" style="padding-top: 5px; padding-bottom: 5px;">
                            <asp:Label ID="lbInspiartor" runat="server" Text="No Inspirator Found.." Style="font-family: Arial;"
                                Visible="false"></asp:Label>
                            <asp:DataList ID="dlInspirators" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                                Style="vertical-align: text-top;" OnItemCommand="dlInspirators_ItemCommand">
                                <ItemTemplate>
                                    <div id="divInsp" class="mission_box" style="margin-right: -5px; vertical-align: text-top;
                                        width: 170px !important; word-wrap: break-word;" runat="server">
                                        <table style="vertical-align: text-top; border-collapse: collapse;">
                                            <tr valign="top" style="height: auto;">
                                                <td valign="top">
                                                    <asp:HiddenField ID="hdnUserid" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                                    <asp:HiddenField ID="hdnInspiratorid" runat="server" Value='<%#Eval("pk_Inspirator_id") %>' />
                                                    <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("Inspirator_image") %>' />
                                                    <asp:ImageButton ID="Image" runat="server" ImageUrl='<%#"~/User/InspiratorImages/"+Eval("Inspirator_image") %>' Style="float: left; height: 170px; width: 170px;" CommandName="lnkViewInsp" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("pk_Inspirator_id") %>'/>
                                                    <%--<asp:Image ID="Image" runat="server" ImageUrl='<%#"~/User/InspiratorImages/"+Eval("Inspirator_image") %>'
                                                        Style="float: left; height: 170px; width: 170px;" />--%>
                                                </td>
                                            </tr>
                                            <tr id="trDesc" valign="top" style="height: auto;" runat="server">
                                                <td valign="top">
                                                    <p style="width: 148px; margin-left: 7px; padding-left: 7px; word-wrap: break-word;">
                                                        <asp:Label ID="lbDesc" runat="server" Text='<%#Eval("Inspirator_desc")+"..." %>'
                                                            Style="color: #000000; line-height: 16px; text-align: justify; font-family: arial !important;
                                                            font-size: 13px; margin-top: 7px; padding-bottom: 5px; padding-right: 2px;"></asp:Label></p>
                                                </td>
                                            </tr>
                                            <tr class="mission_btm_cont" valign="top" style="height: 30px; width: 162px !important;">
                                                <td style="float: left; margin-right: 0px; margin-top: 4px; margin-left: 4px;">
                                                    <asp:Label ID="lbLikeCount" runat="server" Text='<%#Eval("likes") %>' class="mission_txt_conut"></asp:Label>
                                                    <asp:LinkButton ID="lnkLike" runat="server" Text="Like" Enabled="false" class="mission_txt_conut"
                                                        Style="margin-left: 4px;"></asp:LinkButton>
                                                </td>
                                                <td style="float: left; margin-right: 0px; margin-top: 4px; margin-left: 1px;">
                                                    <asp:Label ID="lbCommentCount" runat="server" Text='<%#Eval("comments") %>' class="mission_txt_conut"></asp:Label>
                                                    <asp:LinkButton ID="lnkComment" runat="server" Text="Comments" Enabled="false" class="mission_txt_conut"
                                                        Style="margin-left: 4px;"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <asp:ImageButton ID="dummy1" runat="server"  style="color:#FFF; display:none;" />
                          <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath=""
                Enabled="True" TargetControlID="dummy1" PopupControlID="panel4" BackgroundCssClass="main_pop_up_box_miss"
                DropShadow="false" CancelControlID="Image3">
            </asp:ModalPopupExtender>
            <div id="panel4" runat="server" style="display: none; left: 159.5px; position: fixed;
                top: -63px !important; z-index: 100001;">
                <div class="ins_box_pop_up" style="height: 500px !important;">
                    <div class="close_img_pop_up1">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/close_btn111.png" Style="border-width: 0;
                            float: right; margin-top: -22px; margin-left: 733px !important;" /></div>
                    <div class="heading_pop_up">
                        Inspirator's Description
                    </div>
                    <div class="ins_popup">
                        <asp:Image ID="Image1" runat="server" Style="border-width: 0; float: left; height: 220px;
                            margin-left: 5px !important; margin-top: 33px !important; width: 220px;" /></div>
                    <div class="ins_text">
                        <span style="font-family: arial; font-weight: bold;">Posted By : &nbsp;
                            <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                        </span>
                        <br />
                        <asp:Label ID="lbDesc" runat="server" Text="" Style="word-wrap: break-word;"></asp:Label></div>
                    <div class="ins_like">
                        <asp:Label ID="lbLikeCount" runat="server" Text="" ToolTip="Like"></asp:Label>
                        <asp:LinkButton ID="lnkInspLike" runat="server" Text="" OnClick="lnkInspLike_Click"></asp:LinkButton></div>
                    <div class="ins_like">
                        <asp:Label ID="lbCommentCount" runat="server" Text=""></asp:Label>
                        <asp:LinkButton ID="lnkComments" runat="server" Enabled="false" Text="Comments" OnClick="lnkComments_Click"></asp:LinkButton></div>
                   
                    <div class="ins_textarea">
                        <asp:TextBox ID="txtComments" runat="server" ValidationGroup="b" Style="height: 70px;
                            margin-left: 9px; margin-top: 13px; width: 450px;"></asp:TextBox></div>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Comment required"
                        ControlToValidate="txtComments" ValidationGroup="b" Style="float: left; padding-left: 10px;
                        padding-top: 8px;"></asp:RequiredFieldValidator>
                    <div class="ins_submit">
                        <asp:Button ID="btnComment" runat="server" Text="Comment" OnClick="btnComment_Click"
                            ValidationGroup="b" Style="background-color: #393B3A !important; border: medium none !important;
                            color: #FFFFFF;" />
                    </div>
                    <div id="divComments" runat="server" class="ins_comment_box" style="line-height: 12px !important;">
                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="ins_des_box">
                                    <div class="left_ins_comment">
                                        <asp:Label ID="lbCName" runat="server" Text='<%#Eval("first_name") %>'></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text=":"></asp:Label>
                                    </div>
                                    <div class="rgt_ins_comments" style="margin-top: -5px !important; line-height: 18px !important;">
                                        <asp:Label ID="lbCDesc" runat="server" Text='<%#Eval("InspiratorComment_text") %>'
                                            Style="word-wrap: break-word;"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
                    </div>
                </div>
                <div class="user_info_profile_detail">
                    <div class="user_circle_details" style="margin-top: 0px !important;">
                        <div class="heading_circle_dp" style="line-height: 21px !important; font-size: 18px !important;">
                            Missions :
                        </div>
                        <div class="heading_mission_dp_details" style="padding-top: 5px; padding-bottom: 5px;">
                            <asp:Label ID="lbMission" runat="server" Text="No Mission Found.." Visible="false"></asp:Label>
                            <ul class="mission_dp">
                                <asp:DataList ID="dlMissions" runat="server" CellPadding="0" CellSpacing="0" RepeatColumns="1"
                                    BorderColor="Gray" BorderStyle="Solid" OnItemCommand="dlMissions_ItemCommand">
                                    <AlternatingItemStyle CssClass="odd_dp_mission" />
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton ID="lnkMission" runat="server" CommandName="LnkMission" CommandArgument='<%#Eval("Pk_mission_id")+";"+Eval("fk_created_by_user_Id") %>'>
                                                <asp:Label ID="lbID" runat="server" Text='<%#Eval("Pk_mission_id") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lbUserID" runat="server" Text='<%#Eval("fk_created_by_user_Id") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lbMission" runat="server" Text='<%#Eval("mission_name") %>'></asp:Label>
                                            </asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:DataList>
                            </ul>
                        </div>
                    </div>
                </div>
                <asp:LinkButton ID="dummy" runat="server" ></asp:LinkButton>
                <asp:ModalPopupExtender ID="PnlInspirator_ModalPopupExtender" runat="server" DynamicServicePath=""
                    Enabled="True" TargetControlID="dummy" PopupControlID="panelPuic" BackgroundCssClass="modalBackground"
                    DropShadow="false" CancelControlID="ImgClose">
                </asp:ModalPopupExtender>
                <asp:Panel ID="panelPuic" runat="server" Style="display: none; left: 6px !important;"
                    CssClass="main_pop_up_box_miss">
                    <div class="inner_box_pop_up" style="float: left; margin-left: 315px; height: 180px !important;">
                        <div class="close_img_pop_up">
                            <asp:Image ID="ImgClose" Style="float: right; height: 21px; margin-left: 451px; margin-top: 2px;
                                width: 21px;" runat="server" ImageUrl="~/images/close_btn.png" OnClientClick="Clear()" /></div>
                        <div class="heading_pop_up">
                            <span style="float: left; font-family: arial; font-size: 20px; margin-left: 4px;
                                margin-top: 3px; color: #666666;">Mission Detail</span>
                        </div>
                        <div style="float: left; margin-left: 20px; margin-top: 22px; width: 452px;">
                            <span style="float: left; font-family: arial; font-size: 16px; font-weight: bold;">Mission
                                Name: </span>&nbsp;
                            <asp:Label ID="lbMissionName" runat="server" Text="" Style="float: left; margin-left: 10px;"></asp:Label>
                        </div>
                        <div style="float: left; margin-left: 21px; margin-top: 17px; width: 452px;">
                            <span style="float: left; font-family: arial; font-size: 16px; font-weight: bold;">Created
                                By: </span>&nbsp;
                            <asp:Label ID="lbUsersname" runat="server" Text="" Style="float: left; margin-left: 32px;"></asp:Label>
                        </div>
                        <div style="float: left; margin-left: 20px; margin-top: 18px; width: 452px;">
                            <span style="float: left; font-family: arial; font-size: 16px; font-weight: bold;">Created
                                Date:</span>&nbsp;
                            <asp:Label ID="lbCDate" runat="server" Text="" Style="float: left; margin-left: 18px;"></asp:Label>
                        </div>
                        <div style="float: left; margin-left: 20px; margin-top: 18px; width: 452px;">
                            <span style="float: left; font-family: arial; font-size: 16px; font-weight: bold;">Deadline
                                Date:</span>&nbsp;
                            <asp:Label ID="lbDDate" runat="server" Text="" Style="float: left; margin-left: 8px;"></asp:Label>
                        </div>
                        <div style="float: left; margin-left: 68px; margin-top: 19px; width: 452px;">
                            <span style="float: left; font-family: arial; font-size: 15px; font-weight: bold;">You
                                need to join the circle to join this mission</span>&nbsp;
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpUpdatePanelUserProfile">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div>
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" /></asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
