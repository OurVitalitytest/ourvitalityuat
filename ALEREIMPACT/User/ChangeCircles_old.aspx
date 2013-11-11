<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeCircles_old.aspx.cs"
    Inherits="ALEREIMPACT.User.ChangeCircles_old" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link rel="stylesheet" href="../CSS/style.css" type="text/css" />
<script src="<%=ResolveClientUrl("~/scripts/jquery-1.7.1.min.js")%>" type="text/javascript"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Welcome to Vitality</title>
 <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon">

    <script type="text/javascript">

        $(document).ready(function() {    
            //first slide down and blink the message box   
            $('.main_hover_circle').animate({ top: "30px", left: "50px"   
            }, 1000);

            //close the message box when cross red image is clicked
            $("#close_message").click(function() {
                $('.main_hover_circle').hide();
                return false;
            });

            $(".lnk_close_message").click(function() {
                $('.main_hover_circle').hide();
                return false;
            });
        });



    </script>

    <script type="text/javascript" language="javascript">
        function Randomize() {
            var images = new Array("bg.jpg", "bg1.jpg", "bg2.jpg");
            var imageNum = Math.floor(Math.random() * images.length);
            document.getElementById("main_index").style.backgroundImage = "url('../images/" + images[imageNum] + "')";
        }
        window.onload = Randomize;

    </script>

    <style type="text/css">
        #main_index
        {
            float: left;
            width: 100%;
            margin: 0px auto;
            min-height: 800px;
        }
    </style>
    <link rel="stylesheet" href="../CSS/style_mainpage.css" type="text/css" />

    <script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>

    <script type="text/javascript">
        function colorChanged(sender) {
            sender.get_element().style.color =
       "#" + sender.get_selectedColor();
        } 
    </script>

    <script type="text/javascript">
        $('div.directory').on({
            mouseenter: function() {
                $(this).children('a.delete, a.add').show();
            },
            mouseleave: function() {
                $(this).children('a.delete, a.add').hide();
            }
        });
    </script>

    <script type="text/javascript">
        function getImg(input, max, accepted) {
            var upImg = new Image(), test, size, msg = input.form;
            msg = msg.elements[0].children[0];

            return input.files ? validate() :
	(upImg.src = input.value, upImg.onerror = upImg.onload = validate);
            "author: b.b. Troy III p.a.e";
            function validate() {
                test = (input.files ? input.files[0] : upImg);
                size = (test.size || test.fileSize) / 1024;
                mime = (test.type || test.mimeType);
                mime.match(RegExp(accepted, 'i')) ?
	size > max ? (input.form.reset(), alert("Image size should be less than 100KB !")) :
	msg.innerHTML = "Upload ready..." :
	(input.form.reset(), msg.innerHTML = accepted + " file type(s) only!")
            }
        }
    </script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script type="text/javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ChangeCircles.aspx/ProcessIT",
                    data: "{}",
                    dataType: "json",
                    success: function(data) {
                        //alert('');
                    },
                    error: function(result) {
                        //alert("");
                    }
                });
            });
        }
    </script>

    <script type="text/javascript">

        $(document).ready(function() {
            setTimeout(function() {
                $('#lbMsg').fadeOut('fast');
            }, 6000); // <-- time in milliseconds
        });

    </script>

    <script type="text/javascript">
        function txtrep2() {
            var email = document.getElementById('<%#txtEmail.ClientID %>').value;
            if (email != "") {
                var newtext = "Sending...";
                document.getElementById('btnInvite').value = newtext;
            }



        }
    </script>

</head>
<body id="circle">
    <div id="main_index">
        <form id="form1" runat="server" autocomplete="off">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="main_hover_circle">
            <div class="main_hover_circle_close">
                <asp:LinkButton ID="close_message" runat="server" Text="X"></asp:LinkButton>
                <div class="welcome_alere">
                    Welcome to Vitality!</div>
                <div class="connect_emp">
                    We’d like to help you Connect and Empower you to make Smarter health decisions.
                    This is how we do it.</div>
                <div class="info_section_alere">
                    <div class="contct_img">
                        <asp:ImageButton ID="imgFromCircles" runat="server" ImageUrl="~/Images/2013-07-08_0836_03.jpg"
                            OnClick="ImgRedirectTo_Click" />
                    </div>
                    <div class="contct_des_alere">
                        <div class="line_alere">
                            <div class="head_alere_orange">
                                Connect</div>
                        </div>
                        <div class="text_des_btm_alere">
                            As a new member of Vitality you get to create your own private online community
                            called your<strong> Inner Circle.</strong> Invite your friends, family, churchmembers,
                            anyone that will help share in your journey to better health.<strong> Next,</strong>
                            Join or Create additional circles for any other interests or groups. This is how
                            we work together to improve everyone’s health. <a style="cursor: pointer; text-decoration: underline;"
                                class='lnk_close_message'>I’m ready,I’d like to invite some friends now!"</a></div>
                    </div>
                </div>
                <div class="info_section_alere">
                    <div class="contct_img">
                        <asp:ImageButton ID="imgFromInspirators" runat="server" ImageUrl="~/Images/2013-07-08_0836_06.jpg"
                            OnClick="ImgRedirectTo_Click" />
                    </div>
                    <div class="contct_des_alere">
                        <div class="line_alere">
                            <div class="head_alere_green">
                                Empower</div>
                        </div>
                        <div class="text_des_btm_alere">
                            <strong>What motivates you?</strong> Share and collect the images that inspire you
                            to want to improve your health and the health of your community around you. Bring
                            in images from around the internet, or browse what motivates other Vitality
                            members and save your favorites to your personal library.</div>
                    </div>
                </div>
                <div class="info_section_alere">
                    <div class="contct_img">
                        <asp:ImageButton ID="imgFromMissions" runat="server" ImageUrl="~/Images/2013-07-08_0836_09.jpg"
                            OnClick="ImgRedirectTo_Click" />
                    </div>
                    <div class="contct_des_alere">
                        <div class="line_alere">
                            <div class="head_alere_blue">
                                Smart</div>
                        </div>
                        <div class="text_des_btm_alere">
                            Establish personal or group missions, public or private missions. Every step you
                            take, every pound you lose will contribute to all missions you participate in. Alere
                            Vitality <strong>learns how you like to get healthier </strong>and what tools will
                            help you best achieve your missions and then customizes how we give you the tools
                            you need to succeed!
                        </div>
                    </div>
                </div>
                <div class="ready_to_go">
                    <asp:ImageButton ID="ImgAddLog" runat="server" ImageUrl="~/images/button_circle.png"
                        OnClick="ImgRedirectTo_Click" />
                </div>
            </div>
        </div>
        <%-- <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
        <div class="top_box" style="width: 376px !important;">
            <span class="top_text">Welcome To Vitality</span>
        </div>
        <div class="user_login">
            <div class="login_circle" style="font-weight: bold; color: white; font-size: 13px;
                vertical-align: middle; font-family: Arial;">
                <asp:ImageButton ID="imgprofile" runat="server" ToolTip="My Profile" Height="35px"
                    Width="35px" OnClick="imgprofile_Click" />
                <%--  <asp:Image  />--%>
                <div style="margin-left: 38px; margin-top: -27px;">
                    &nbsp;&nbsp;<span style="float:left;">Welcome : </span>
                    <asp:Label ID="lblWelcomeUser" runat="server" Style="color: white; float: left; font-size: 13px;
                        font-weight: bold;  margin-left: -8px;"></asp:Label>
                    &nbsp;
                    <asp:LinkButton ID="lklogout" runat="server" OnClick="lklogout_Click" Style="text-decoration: underline;
                        font-family: Arial; font-size: 13px;">Logout</asp:LinkButton>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server">
            <ContentTemplate>
                <div class="email_invite">
                    <div style="height: 110px; padding: 16px 0 0 120px;">
                        <img src="../images/icon_email_index.png" /></div>
                    <div style="background: #D6E5E3; color: #044343; font-family: 'Arial'; font-size: 21px;
                        margin: 0 3px; padding-left: 15px;">
                        Invite through Email</div>
                    <div style="color: #252525; font-size: 16px; width: 324px; height: auto; font-family: Arial, Helvetica, sans-serif;
                        padding-left: 20px;">
                        <span style="margin-top: 10px; margin-bottom: 10px; font-family: Arial;">Email:
                            <asp:TextBox ID="txtEmail" runat="server" Style="margin-top: 10px; margin-bottom: 5px;
                                margin-left: 28px; width: 225px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                                Display="Dynamic" ErrorMessage="Email required" ValidationGroup="a" Style="color: Red;
                                font-family: arial; font-size: 13px; margin-left: 81px;"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                                Style="margin-left: 81px; font-family: arial; font-size: 13px;" ValidationGroup="a"
                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="Valid email required"></asp:RegularExpressionValidator>
                            <%--<input name="text" type="text" style="margin-top:10px; margin-bottom:10px; margin-left:28px; width:225px;" />--%><br />
                            <div style="width: 78px; float: left; font-family: Arial;">
                                Message:</div>
                            <asp:TextBox ID="txtmessage" runat="server" Style="width: 225px; height: 60px;" TextMode="MultiLine"></asp:TextBox>
                            <%--<textarea name="text" cols="" rows="" style="width:225px; height:60px;"></textarea>--%><br />
                            <%-- <a href="#" style="text-decoration:none;">--%>
                            <asp:Button ID="btnInvite" runat="server" Text="Invite" OnClientClick="return txtrep2();"
                                class="standard_blue" Style="float: right !important; cursor: pointer; margin-right: 17px !important;"
                                ValidationGroup="a" OnClick="btnInvite_Click" />
                            <%--  <input name="button" type="button" value="Invite" class="standard_blue"/>--%>
                            <%--</a>--%>
                    </div>
                    <asp:Label ID="lbMsg" runat="server" Text="" Visible="false" Style="color: red; font-family: Arial;
                        float: left; margin-left: 81px; margin-top: 2px;"></asp:Label>
                </div>
                <div class="circle">
                    <div class="inner_circle">
                        <a href="#">Invite those closest to you</a>
                    </div>
                    <div class="center_circle">
                        <div class="orange_circle">
                            <a href="#">
                                <p>
                                    P</p>
                                <p>
                                    e</p>
                                <p>
                                    r</p>
                                <p>
                                    s</p>
                                <p>
                                    o</p>
                                <p>
                                    n</p>
                                <p>
                                    a</p>
                                <p>
                                    l
                                </p>
                            </a>
                        </div>
                        <div class="thumb_circle">
                            Welcome to Inner Circle
                            <div class="thumb" id="dvcircleimg" runat="server">
                                <asp:LinkButton ID="lkmovetocircle" runat="server" OnClick="lkmovetocircle_Click">
                                    <asp:Image ID="imgInnercircle" runat="server" CssClass="avatar" />
                                </asp:LinkButton>
                            </div>
                            <div style="color: maroon; float: left; font-family: arial; font-size: 13px; font-weight: bold;
                                height: 145px; margin-left: 11px; margin-top: -26px; width: 160px;">
                                <asp:LinkButton ID="lkupdatecircle" runat="server" Text="Edit Circle Picture" Style="font-size: 11px;
                                    color: #095151; font-family: arial; padding-left: 17px;"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="green_circle">
                            <a href="#">
                                <p>
                                    P</p>
                                <p>
                                    r</p>
                                <p>
                                    i</p>
                                <p>
                                    v</p>
                                <p>
                                    a</p>
                                <p>
                                    t</p>
                                <p>
                                    e
                                </p>
                            </a>
                        </div>
                    </div>
                    <div class="gray_circle">
                        <a href="#">Encouraging</a>
                    </div>
                </div>
                <div style="width: 40%" align="right">
                    <asp:Panel ID="PnlCircle" runat="server" Style="display: none">
                        <div class="popup_wall" style="background-color: #F2F0F0;">
                            <table border="0" cellpadding="5" cellspacing="5" width="100%" align="left" style="padding-bottom: 10px;">
                                <tr>
                                    <td colspan="3">
                                        <strong><span style="font-size: 16px; font-weight: bold">Update your Inner Circle:</span></strong>
                                        <a id="btnClose" title="Close">
                                            <img src="../images/close_btn.png" style="padding-left: 148px;" /></a>
                                        <br />
                                        <br />
                                        Customize your circle. Make it your own.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        Color:
                                    </td>
                                    <td align="left">
                                        <asp:ColorPickerExtender runat="server" ID="ColorPickerExtender1" TargetControlID="txtcirclecolor"
                                            OnClientColorSelectionChanged="colorChanged" />
                                        <asp:TextBox ID="txtcirclecolor" runat="server"></asp:TextBox>
                                        <br />
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
                                        <asp:FileUpload ID="fucircleimage" runat="server" ValidationGroup="circle" /><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="circle"
                                            Display="Dynamic" ErrorMessage="Upload circle image" ControlToValidate="fucircleimage"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lbuploadimger" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <td>
                                </td>
                                <tr align="center" valign="middle">
                                    <td colspan="3">
                                        <asp:Button ID="btnupdatecircle" runat="server" Text="Update" ValidationGroup="circle"
                                            OnClick="btnupdatecircle_Click" />
                                        <%--  <asp:Button ID="btnClose" runat="server" Text="Close" />--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lkupdatecircle"
                        PopupControlID="PnlCircle" BackgroundCssClass="modalBackground" DropShadow="false"
                        CancelControlID="btnClose">
                    </asp:ModalPopupExtender>
                </div>
                <%--<div class="text_gnrl_box">
                    <span style="font-family:Arial; font-size: 14px;">I was really scared when I first learned I had Diabetes. But connecting with my
                        doctor and building my own online support network has made me feel stronger. I am
                        making good progress improving my health and I’ve made some really great friends.
                    </span>
                </div>--%>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnupdatecircle" />
                <asp:AsyncPostBackTrigger ControlID="btnInvite" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpOutterUpdatePanel">
            <ProgressTemplate>
                <asp:Panel ID="Panel1" CssClass="overlay" runat="server" Style="padding-right: 50px;">
                    <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                        <div style="float: left; margin-left: 539px; margin-right: 295px; margin-top: -485px;">
                            Processing...
                            <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                                top: 45%;" alt="Processing Request" />
                    </asp:Panel>
                </asp:Panel>
            </ProgressTemplate>
        </asp:UpdateProgress>
        </form>
    </div>
</body>
</html>
