<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucInspirators.ascx.cs"
    Inherits="ALEREIMPACT.User.ucInspirators" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link rel="stylesheet" type="text/css" href="../js/ins_jscrollpane.css" />
<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

<!-- the jScrollPane script -->

<script type="text/javascript" src="../js/ins_jscrollpane.min.js"></script>
<script type ="text/javascript">

    function checkfilesize() {

        var size = document.getElementById("<%=fuInspiratorImage.ClientID%>").files[0].size;


        if (size > 1048576) {

            alert("Image size exceeds Limit.");

            return false;
        }
        else {


            return true;
        }


    }
</script>

<!-- CSS -->
<style>
    *
    {
        margin: 0;
        padding: 0;
    }
    .container
    {
      /*  width: 992px;
        height: 860px;
        margin: 6px auto;
        overflow: scroll;  showing scrollbars */
        
        width: 975px;
        height: 792px;
        margin: 20px auto;
        overflow: auto; /* showing scrollbars */
        
    }
    p
    {
        margin: 0 0 2em 0;
    }
    ::-webkit-scrollbar
    {
        width: 15px;
    }
    /* this targets the default scrollbar (compulsory) */::-webkit-scrollbar-track
    {
        background-color: #F0F0F0;
    }
    /* the new scrollbar will have a flat appearance with the set background color */::-webkit-scrollbar-thumb
    {
        background-color: rgba(0, 0, 0, 0.2);
    }
    /* this will style the thumb, ignoring the track */::-webkit-scrollbar-button
    {
        background-color: #F0F0F0;
    }
    /* optionally, you can style the top and the bottom buttons (left and right for horizontal bars) */::-webkit-scrollbar-corner
    {
        background-color: black;
    }
    /* if both the vertical and the horizontal bars appear, then perhaps the right bottom corner also needs to be styled */.jspPane
    {
        margin-left: 13px !important;
        margin-top: -35px;
        position: absolute;
    }
    .tab_mission_runtime div div
    {
        margin-left: 0px;
    }
</style>

<script type="text/javascript">
    $(document).ready(function() { 
      
        $('.container').jScrollPane();

    });
    function bind() {
    
        $('.container').jScrollPane();

    }
</script>

<script type="text/javascript">
    function Count(text, long) {
        var maxlength = new Number(long); // Change number to your max length.
        if (document.getElementById('<%=txtdesc.ClientID%>').value.length > maxlength) {
            text.value = text.value.substring(0, maxlength);
            //alert(" Only " + long + " chars");
        }
    }
</script>

<script type="text/javascript">
 function Clear() {

  if(document.getElementById('<%#txtdesc.ClientID %>').value.length>0)
 {
 document.getElementById('<%#txtdesc.ClientID %>').value="";
 }
  if(document.getElementById('<%#fuInspiratorImage.ClientID %>').value.length>0)
 {
 document.getElementById('<%#fuInspiratorImage.ClientID %>').value="";
 }
 
 }
</script>

<script type="text/javascript">

    function showDivProgress() {
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';

    }
</script>

<div>
    <asp:UpdatePanel ID="UpdatePanelInspirator" runat="server">
        <ContentTemplate>
            <div class="top_his_miss" style="border-bottom: 1px solid #CCCCCC; color: #666666;
                margin: 1px auto; padding-bottom: 9px; width: 970px;">
                <div id="DivDrp" runat="server" style="float: left; margin-top: 8px; margin-left: 16px;">
                    <span style="color: black; float: left; font-family: arial; font-size: 13px; margin-top: -5px;
                        padding-right: 10px;">Choose an option :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Style="border: 1px solid #50514F; color: #50514F; width: 172px; margin-top: -8px;">
                        <asp:ListItem Value="1" Text="All Inspirators"></asp:ListItem>
                        <asp:ListItem Value="2" Text="My Library"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Panel ID="PanelMy" runat="server" Visible="false" Style="float: right;">
                <div style="color: #4DA3A4; float: right; font-size: 15px !important; font-weight: bold;
                    margin-right: 40px; margin-top: -42px;">
                    <asp:LinkButton ID="lnkAddInspirator" runat="server" Text="Add New Inspirator" Style="color: #555555;
                        font-family: arial; float: left; margin-top: 14px; text-decoration: none;" OnClick="lnkAddInspirator_Click"></asp:LinkButton>
                    <img src="../images/add_ins.png" style="vertical-align: top;">
                </div>
                <asp:ModalPopupExtender ID="PnlInspirator_ModalPopupExtender" runat="server" DynamicServicePath=""
                    Enabled="True" TargetControlID="lnkAddInspirator" PopupControlID="panel1" BackgroundCssClass="modalBackground"
                    DropShadow="false" CancelControlID="ImgClose">
                </asp:ModalPopupExtender>
                <asp:Panel ID="panel1" runat="server" Style="display: none; left: 6px !important;"
                    CssClass="main_pop_up_box_miss">
                    <div class="inner_box_pop_up" style="float: left; margin-left: 315px; height: 300px !important;">
                        <div class="close_img_pop_up">
                            <asp:Image ID="ImgClose" Style="float: right; margin-left: 453px; margin-top: -25px;"
                                runat="server" ImageUrl="~/images/close_btn111.png" OnClientClick="Clear()" /></div>
                        <div class="heading_pop_up">
                            <span style="float: left; font-family: arial; font-size: 20px; margin-left: 4px;
                                margin-top: 3px; color: #000000;">Add new Inspirator</span>
                        </div>
                        <div style="margin-top: 30px !important; margin-left: 35px !important;">
                            <span class="text_form_pop" style="float: left; color: #000000; margin-left: 26px !important;
                                margin-top: 10px;">Image : </span><span class="input_box">
                                    <asp:FileUpload ID="fuInspiratorImage" runat="server" ValidationGroup="a" Style="float: left;
                                        margin-left: -117px; margin-top: 6px;" />
                                    <br />
                                    <span style="color: #000000; float: left; font-family: arial; font-size: 11px; margin-left: -200px;
                                        margin-top: 22px;">(Maximum Size 1MB)</span>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAppForm" runat="server" Style="color: red;
                                        float: left; font-family: arial; font-size: 13px; padding-left: 129px; padding-top: 20px;"
                                        ErrorMessage="Upload inspirator image " Display="Dynamic" ControlToValidate="fuInspiratorImage"
                                        ValidationGroup="a"></asp:RequiredFieldValidator>
                                </span>
                        </div>
                        <div style="margin-left: 35px !important;">
                            <span class="text_form_pop" style="float: left; color: #000000; margin-left: 26px !important;
                                margin-top: 45px;">Description:</span> <span class="input_box">
                                    <asp:TextBox ID="txtdesc" runat="server" MaxLength="300" TextMode="MultiLine" onKeyUp="javascript:Count(this,300);"
                                        onChange="javascript:Count(this,300);" Columns="5" Rows="5" ValidationGroup="a"
                                        Style="float: left; border: 1px solid #9B9B9B; height: 57px; margin-left: -117px;
                                        margin-top: 26px; width: 221px;"></asp:TextBox>
                                </span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="color: red;
                                display: inline; float: left; font-family: arial; font-size: 13px; margin-top: 7px;
                                padding-left: 129px;" ErrorMessage="Inspirator description required" Display="Dynamic"
                                ControlToValidate="txtdesc" ValidationGroup="a"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="create" ValidationGroup="a" OnClientClick="return checkfilesize();"
                                OnClick="btnadd_Click" Style="clear: both; padding-top: 1px; float: left; font-size: 17px;
                                height: 29px; margin-left: 192px; margin-top: 21px; padding-bottom: 5px; width: 85px;" />&nbsp;
                        </div>
                    </div>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="PanelUser" runat="server" Visible="false">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="mission_page">
                    <tr>
                        <%--<td id="tdUser" runat="server" style="color: Gray; display: none; text-align: center;
                            margin-left: 350px; line-height: 30px;">--%>
                        <%--  </td>--%>
                        <td align="center" valign="top">
                            <asp:Label ID="lbNorecord" runat="server" Visible="false" Style="color: #50514F;
                                float: left; font-family: candara; font-size: 18px; font-weight: bold; line-height: 37px;
                                margin-left: 300px; margin-top: 15px;"></asp:Label>
                            <div class="mission_main_box4" style="vertical-align: top; text-align: justify; margin-left: -4px;">
                                <div class="container">
                                    <p>
                                        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                            OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand"
                                            Style="vertical-align: text-top;">
                                            <ItemTemplate>
                                                <div id="divInsp" class="mission_box" style="margin-right: 10px; vertical-align: text-top;"
                                                    runat="server">
                                                    <table style="vertical-align: text-top; border-collapse: collapse;">
                                                        <tr valign="top" style="height: auto;">
                                                            <td valign="top">
                                                                <asp:HiddenField ID="hdnUserid" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                                                <asp:HiddenField ID="hdnInspiratorid" runat="server" Value='<%#Eval("pk_Inspirator_id") %>' />
                                                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("Inspirator_image") %>' />
                                                                <a id="aimage" runat="server">
                                                                    <%--                        <asp:Image ID="Image1" runat="server"   ImageAlign="Top" />--%>
                                                                    <asp:ImageButton ID="ImageButton3" class="mission_thumb_img" runat="server" Style="height: 250;
                                                                        width: 200px; float: left; padding-left: 5px;" ImageAlign="Top" CommandName="PopUp"
                                                                        CommandArgument='<%#Eval("pk_Inspirator_id") %>' />
                                                                </a>
                                                            </td>
                                                        </tr>
                                                        <tr id="trDesc" valign="top" style="height: auto;" runat="server">
                                                            <td valign="top">
                                                                <p style="width: 202px; margin-left: 7px; padding-left: 7px;">
                                                                    <asp:Label ID="lbDesc" runat="server" Text='<%#Eval("Inspirator_desc") %>' Style="color: #000000;
                                                                        line-height: 16px; text-align: justify; font-family: arial !important; font-size: 13px;
                                                                        margin-top: 7px; padding-bottom: 5px; word-wrap: break-word; padding-right: 2px;"></asp:Label></p>
                                                            </td>
                                                        </tr>
                                                        <tr class="mission_btm_cont" valign="top" style="height: 30px;">
                                                            <td style="float: left; margin-left: 0px; margin-right: -8px; margin-top: -7px;">
                                                                <asp:Image ID="Image2" runat="server" Style="height: 15px; width: 15px; padding-top: 11px;"
                                                                    class="mission_btn_img" />
                                                            </td>
                                                            <td style="float: left; margin-right: 0px; margin-top: 6px; margin-left: 4px;">
                                                                <asp:Label ID="lbLikeCount" runat="server" Text="" class="mission_txt_conut"></asp:Label>
                                                                <asp:LinkButton ID="lnkLike" runat="server" Text="" Enabled="false" class="mission_txt_conut"
                                                                    Style="margin-left: 4px;" CommandName="Like" CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
                                                            </td>
                                                            <td style="float: left; margin-right: 0px; margin-top: 6px; margin-left: 1px;">
                                                                <asp:Label ID="lbCommentCount" runat="server" Text="" class="mission_txt_conut"></asp:Label>
                                                                <asp:LinkButton ID="lnkComment" runat="server" Text="Comments" Enabled="false" class="mission_txt_conut"
                                                                    Style="margin-left: 4px;" CommandName="Comment" CommandArgument='<%#Eval("pk_Inspirator_id") %>'></asp:LinkButton>
                                                            </td>
                                                            <td style="float: left; margin-right: 0px; margin-top: -3px;">
                                                                <span class="sep" style="color: #FFFFFF; float: left; height: 12px; margin-left: 4px;
                                                                    margin-top: 13px; padding-bottom: 0px;">|</span>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Flag as Inappropriate"
                                                                    Enabled="false" CommandName="Inappropriate" CommandArgument='<%#Eval("pk_Inspirator_id") %>'
                                                                    class="mission_btn_img" Style="margin-left: -1px; margin-top: 8px;" ImageUrl="~/images/flag.png"
                                                                    OnClientClick="return confirm('Are you sure you want to flag this?')" />
                                                                <%-- <img src="../images/Flag-red-icon.png" alt="" runat="server" />--%>
                                                            </td>
                                                            <td style="float: left; margin-right: 0px; margin-top: -7px; margin-bottom: 10px;">
                                                                <span class="sep" style="color: #FFFFFF; float: left; height: 12px; margin-top: 17px;
                                                                    padding-bottom: 0px;">|</span>
                                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Add" CommandArgument='<%#Eval("pk_Inspirator_id") %>'
                                                                    class="mission_btn_img" Style="margin-left: 4px; height: 15px; width: 15px; padding-top: 11px;"
                                                                    ToolTip="Add To Library" ImageUrl="~/images/Sign-Add-icon.png" OnClick="ImageButton2_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </p>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkViewMore" runat="server" Text="View More" Style="color: #53AFB0;
                                float: right; font-size: 12px; font-weight: bold; padding-right: 35px; text-decoration: underline;"
                                OnClick="lnkViewMore_Click"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="display: none;">
                <asp:ImageButton ID="dummy" runat="server" ImageUrl="" Style="color: white; border: 0px;" /></div>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath=""
                Enabled="True" TargetControlID="dummy" PopupControlID="panel4" BackgroundCssClass="main_pop_up_box_miss"
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
                    <asp:Panel ID="PanelHS" runat="server">
                        <div class="ins_like">
                            <asp:ImageButton ID="ImageButton1" runat="server" Style="height: 15px; width: 15px;"
                                ImageUrl="~/images/flag_red.png" OnClick="ImageButton1_Click" ToolTip="Flag as Inappropriate"
                                OnClientClick="return confirm('Are you sure you want to flag this?')" /></div>
                        <div class="ins_like">
                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/pluss.png" Style="height: 15px;
                                width: 15px;" CausesValidation="false" AlternateText="Add To Library" ToolTip="Add To Library"
                                OnClick="ImageButton4_Click" /></div>
                    </asp:Panel>
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
            <div id="dvUploader" runat="server" style="display: none;">
                <asp:Panel ID="Panel11" CssClass="overlay" runat="server">
                    <asp:Panel ID="Panel21" CssClass="loader11" runat="server">
                        <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                        </div>
                        <div style="float: left; margin-top: 17px; margin-left: -249px;">
                            <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                                top: 45%;" alt="Processing Request" />
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnadd" />
            <asp:AsyncPostBackTrigger ControlID="btnComment" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="UpdatePanelInspirator">
        <ProgressTemplate>
            <asp:Panel ID="Panel3" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader13" runat="server">
                    <div>
                    
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" /></asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
