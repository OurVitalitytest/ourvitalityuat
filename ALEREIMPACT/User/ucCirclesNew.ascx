<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCirclesNew.ascx.cs"
    Inherits="ALEREIMPACT.User.ucCirclesNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript" src="../scripts/jquery.js"></script>

<%--<script type="text/javascript" src="../scripts/index.js"></script>--%>
<link rel="stylesheet" type="text/css" href="../CSS/index.css" />
<link rel="stylesheet" type="text/css" href="../CSS/reset.css" />

<script src="../scripts/jquery-1.3.2.min.js" type="text/javascript"></script>

<%--   <script type="text/javascript">

        $(document).ready(function() {

        $("#lnkChangeCircle").click(function() {

        $("#notesreload").load("ucWall.ascx");
                

            });
        });
    
    </script>--%>
<%--<script type = "text/javascript">
         $("#dvcirclecolor").live("click", function() {
             $.ajax({
                 type: "POST",
                 url: "MyPage.aspx/LoadUserControl",
                 data: "{message: '" + $("#message").val() + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function(r) {
                     $("#Content").append(r.d);
                 }
             });
         });
    </script>
    --%>

<script type="text/javascript">
    function circleselection(selectedId) {
        var newSubCommentBtnId = selectedId.id.replace('dvcirclecolor', 'lnkChangeCircle');
        document.getElementById(newSubCommentBtnId).click();

    }
</script>

<%--<script type="text/javascript">

    $(document).ready(function() {

        $("#dvcirclecolor").click(function() {

            $("#notes").load("ucWall.ascx");

        });


    });
    
</script>--%>

<script type="text/javascript">
    function colorChanged(sender) {
        sender.get_element().style.color =
       "#" + sender.get_selectedColor();
    } 
</script>

<script type="text/javascript">
    // config

    var d1 = 200;
    var d2 = 100;
    var height = 600;
    var delay = 300;
    var xindent = 40;
    var yindent = 100;

    var subr = 70;
    var subd = 50;
    var subf = 5;
    var subdf = 1.2;

    Math.sign = function(x) {
        return x > 0 ? 1 : x < 0 ? -1 : 0;
    };

    $(function() {
        var container = $("#bubbles");
        var bubbles = container.children();
        container.select = function(num) {
            var t = delay;

            if (num === undefined) {
                var label = $('#<%=lblMessage.ClientID%>').val();
                //  alert(label);
                var num1 = label;
                num = num1
                //  alert(num);
                //num = 0;
                t = 0;
            }
            var length = bubbles.length;
            var c = Math.max(num, length - num - 1);
            var middle = height / 2;
            var df = Math.PI / 2 / c;
            var dy = (middle - yindent) / c;
            bubbles.each(function(i) {
                var q = i - num;
                var d = q === 0 ? d1 : d2;
                var x = xindent * Math.cos(df * q);
                var y = middle + dy * q + (yindent - dy) * Math.sign(q) - d / 2;
                $(this).stop().animate({
                    width: d,
                    height: d,
                    left: x,
                    top: y
                }, t);
            });
            if (container.num !== undefined) {
                $(bubbles[container.num]).children().stop().animate({
                    opacity: 0
                }, t);
            }
            $(bubbles[num]).children().stop().animate({
                opacity: 1
            }, t);
            container.num = num;
        }
        bubbles.each(function() {
            this.hitTest = function(x, y) {
                var r = this.offsetWidth / 2;
                var dx = this.offsetLeft + r - x;
                var dy = this.offsetTop + r - y;
                return (dx * dx + dy * dy < r * r);
            }
            var pr = subr / d1 * 100;
            var pd = subd / d1 * 100;
            $(this).children().each(function(i) {
                var x = pr * Math.cos(subf + subdf * i) + 50 - pd / 2;
                var y = -pr * Math.sin(subf + subdf * i) + 50 - pd / 2;
                $(this).css({
                    width: pd + "%",
                    height: pd + "%",
                    top: y + "%",
                    left: x + "%"
                });
            });
        });
        container.click(function(e) {

            //       $("#notesreload").load("ucWall.ascx");

            var offset = container.offset();
            var x = e.pageX - offset.left;
            var y = e.pageY - offset.top;
            var i;
            for (i = bubbles.length - 1; i >= 0; i--) {

                if (bubbles[i].hitTest(x, y)) {
                    if (i === container.num) {
                        //alert($(e.target).data("href"));
                    } else {

                        container.select(i);
                    }
                    return;
                }
            }
        });
        container.css({
            width: xindent + d1 + "px",
            height: height + "px"
        });
        bubbles.children().css({
            opacity: 0
        });
        container.select();
    });

</script>

<asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server">
    <ContentTemplate>
        <div style="width: 80%" id="bubbles">
            <asp:HiddenField ID="lblMessage" runat="server" />
            <asp:Repeater ID="repCircles" runat="server" OnItemDataBound="repCircles_ItemDataBound"
                OnItemCommand="repCircles_ItemCommand">
                <ItemTemplate>
                    <%--<div id="bubbles">--%>
                    <div style="width: 100px !important; height: 100px !important;" id="dvcirclecolor"
                        runat="server" onclick="circleselection(this);">
                        <asp:HiddenField ID="repid" runat="server" Value='<%# Container.ItemIndex + 1 %>' />
                        <asp:HiddenField ID="hndUserId" runat="server" Value='<%#Eval("fk_user_registration_Id")%>' />
                        <asp:HiddenField ID="hndCircleId" runat="server" Value='<%#Eval("fk_circle_id")%>' />
                        <asp:HiddenField ID="hnducId" runat="server" Value='<%#Eval("pk_user_circle_id")%>' />
                        <asp:HiddenField ID="hndCName" runat="server" Value='<%#Eval("circle_name")%>' />
                        <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                        <div data-href="face" id="dv1img" runat="server">
                        </div>
                        <div data-href="face" id="dv2img" runat="server">
                        </div>
                        <div data-href="face" id="dv3img" runat="server">
                        </div>
                        <div data-href="face" id="dv4img" runat="server">
                        </div>
                        <div data-href="face" id="dv5img" runat="server">
                        </div>
                        <div class="info-container">
                            <span title='members'>
                                <asp:LinkButton ID="lkfriendscount" runat="server"  CommandName="ShowSelectedCircleMembers" CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'> </asp:LinkButton> </span>| <span title='missions'>
                                <asp:LinkButton ID="lkmissioncount" runat="server"></asp:LinkButton> </span>
                            <p style="color:White;padding-right:20px;padding-top:6px"><%#Eval("circle_name")%></p>
                        </div>
                        <asp:LinkButton ID="lnkChangeCircle" runat="server" CommandName="ShowForSelectedCircle"
                            CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'>
                        </asp:LinkButton>
                    </div>
                    <%--</div>--%>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ContentTemplate>
    <%--<Triggers>
    <asp:AsyncPostBackTrigger ControlID="lnkChangeCircle" />
    </Triggers>--%>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
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
                                <asp:Button ID="btncreatecircle" runat="server" Text="Create" OnClick="btncreatecircle_Click"
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
<%--</div>--%>
