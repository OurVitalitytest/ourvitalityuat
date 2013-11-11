<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CirclesNew.aspx.cs" Inherits="ALEREIMPACT.User.CirclesNew" %>

<%@ Register TagPrefix="UserCt" TagName="Form" Src="~/User/ucCircles.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UserCt" TagName="Notes" Src="~/User/ucWall.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="../scripts/jquery.js"></script>

    <%--<script type="text/javascript" src="../scripts/index.js"></script>--%>
    <link rel="stylesheet" type="text/css" href="../CSS/index.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/reset.css" />

    <script type="text/javascript">
        function circleselection(selectedId) {
            var newSubCommentBtnId = selectedId.id.replace('dvcirclecolor', 'lnkChangeCircle');
            //document.getElementById(newSubCommentBtnId).click();
           

        }
    </script>

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
                            alert($(e.target).data("href"));
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

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <%-- <UserCt:Form ID="frmFriendProfile" runat="server" />--%>
    </div>
    <asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server">
        <ContentTemplate>
         <%-- <asp:Button ID="btnUpdate2" runat="server" Text="Update This Panel"  />--%>
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
                                    <asp:LinkButton ID="lkfriendscount" runat="server" CommandName="ShowSelectedCircleMembers"
                                        CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'> </asp:LinkButton>
                                </span>| <span title='missions'>
                                    <asp:LinkButton ID="lkmissioncount" runat="server"></asp:LinkButton>
                                </span>
                                <p style="color: White; padding-right: 20px; padding-top: 6px">
                                    <%#Eval("circle_name")%></p>
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
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upNotesPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <UserCt:Notes ID="MssionsTab" runat="server" />
            </div>+63.
        </ContentTemplate>
        <%-- <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnUpdate2" EventName="Click" />
            </Triggers>--%>
    </asp:UpdatePanel>
    </form>
</body>
</html>
