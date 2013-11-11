<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeCircles.aspx.cs"
    Inherits="ALEREIMPACT.User.ChangeCircles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">--%>
<head id="Head1" runat="server">
    <title>Welcome to Our Vitality</title>
    <link rel="stylesheet" href="../css/newstyle.css" type="text/css" />
    <%--  <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
--%>
    <%--    <script type="text/javascript">

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
--%>

    <script type="text/javascript" language="javascript">
        function Randomize() {
            var images = new Array("bg.jpg", "bg1.jpg", "bg2.jpg");
            var imageNum = Math.floor(Math.random() * images.length);
            document.getElementById("main_index").style.backgroundImage = "url('../images/" + images[imageNum] + "')";
        }
        window.onload = Randomize;

    </script>

    <%-- <style type="text/css">
        #main_index
        {
            float: left;
            width: 100%;
            margin: 0px auto;
            min-height: 800px;
        }
    </style>
--%>

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

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.10.1.min.js"></script>

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
       function checkHeight() {
        var d = document.getElementById('txtEmail').value;
        //var seleced_Height = d.options[d.selectedIndex].value;
        if (d == "") {
            alert("*Email required");
            return false;
        }
         if (d != "") {
             $('#btnInvite').removeClass("submit_invite");
             $('#btnInvite').addClass("submit_invite_sending");
//              $('#btnInvite').attr('disabled',true);
           
        }
    }

    </script>

    <style type="text/css">
        .right_section
        {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 3px solid #EEEEEE;
            border-radius: 5px 5px 5px 5px;
            box-shadow: 1px 2px 3px #444444;
            float: left;
            margin: 47px auto 47px 9%;
            overflow: hidden;
            width: 80%;
        }
        .footer_miss
        {
            width: 100%;
        }
        .copyrgts
        {
            background: none repeat scroll 0 0 #EEEEEE;
            border-top: 1px solid #CFCFCF;
            clear: both;
            float: left;
            padding-bottom: 10px;
            padding-top: 10px;
            width: 100%;
        }
        .copy_right_left
        {
            color: #333333;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12px;
            font-weight: bold;
            margin-bottom: 5px;
            margin-left: 5%;
        }
        .copy_right_rgt
        {
            color: #333333;
            float: right;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12px;
            font-weight: bold;
            margin-right: 5%;
        }
    </style>
</head>
<body id="login">
    <div>
        <form id="form1" runat="server" autocomplete="off">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="body_about">
            <div class="header">
                <div class="header_inner_cont">
                    <div class="logo">
                        <asp:ImageButton ID="imgbtmLogo" runat="server" ImageUrl="~/images/imagesNew/vitality_welcomw.png"
                            OnClick="ImgRedirectTo_Click" />
                    </div>
                    <div class="right_header">
                        <div class="profile">
                            <asp:ImageButton ID="imgprofile" runat="server" ToolTip="My Profile" OnClick="imgprofile_Click"
                                Height="35px" Width="35px" Style="float: left;" />
                            <span style="float: left; margin-left: 19px; margin-top: 9px;">Welcome&nbsp;: </span>
                            <asp:Label ID="lblWelcomeUser" runat="server" Style="color: #FFFFFF; float: left;
                                font-size: 13px; font-weight: bold; margin-left: 0; margin-top: 9px;"></asp:Label>
                            <span style="margin-left: 5px; margin-top: 9px;">|</span>
                            <div class="logout" style="margin-top: 11px !important;">
                                <asp:ImageButton ID="lklogout" runat="server" Style="text-decoration: underline;
                                    font-family: Arial; font-size: 13px;" OnClick="lklogout_Click" ImageUrl="~/images/imagesNew/logout.png"
                                    ToolTip="Logout"></asp:ImageButton></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="left_section" style="margin-top: 10% !important;">
                <asp:LinkButton ID="lnkAbout" runat="server" OnClick="lnkAbout_Click">
                    <div id="divleft_sectionAbout" runat="server" class="about_circle">
                        <%--<a href="about.html">ABOUT US</a>--%>
                        ABOUT US
                    </div>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkEditCircle" runat="server" OnClick="lnkEditCircle_Click">
                    <div class="about_circle" id="divEditCircle" runat="server">
                        EDIT CIRCLE</div>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkInvite" runat="server" OnClick="lnkInvite_Click">
                    <div class="about_circle" id="divleft_sectionInvite" runat="server">
                        INVITE
                    </div>
                </asp:LinkButton>
            </div>
            <div class="right_section" id="divright_section" runat="server">
                <div id="DvAbout" runat="server" class="main_hover_circle">
                    <div class="welcome_alere">
                        Welcome to Vitality!</div>
                    <div class="connect_emp" style="margin-left: 32px !important; margin-top: 27px !important;">
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
                                we work together to improve everyone’s health.
                                <asp:LinkButton ID="lnktextPointerInvite" runat="server" OnClick="lnkInvite_Click">
                                
                                 I’m ready,I’d like to invite some friends now!"
                                </asp:LinkButton>
                            </div>
                            <%-- <a style="cursor: pointer; text-decoration: underline;"
                                    >--%>
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
                                in images from around the internet, or browse what motivates other Vitality members
                                and save your favorites to your personal library.</div>
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
            <div id="divInvite" runat="server" class="right_section email_bg">
                <%--<div class="main_hover_circle_close">
                  <asp:LinkButton ID="LinkButton1" runat="server" Text="X" Style="padding: 10px 6px !important;"></asp:LinkButton>
                </div>--%>
                <div class="rgt_mail">
                    <div class="top_rgt_bar">
                        <img src="../images/imagesNew/invite_mail.jpg" /></div>
                    <div class="text_mail" style="font-size: 15px;">
                        <span>Email :</span>
                        <asp:TextBox ID="txtEmail" runat="server" class="mail_box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="*Email required" ValidationGroup="a" Style="color: Red;
                            font-family: arial; font-size: 13px; margin-left: 143px;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                            Style="margin-left: 143px; font-family: arial; font-size: 13px;" ValidationGroup="a"
                            Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage="Valid email required"></asp:RegularExpressionValidator>
                    </div>
                    <div class="text_mail" style="font-size: 15px;">
                        <span>Message :</span>
                        <asp:TextBox ID="txtmessage" runat="server" class="text_area1" ValidationGroup="a"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="text_mail">
                        <asp:Button ID="btnInvite" runat="server" class="submit_invite" ValidationGroup="a"
                            OnClick="btnInvite_Click" OnClientClick="return checkHeight();" />
                        <%--  OnClientClick="return checkHeight();"
                       OnClientClick="return txtrep2();"--%>
                    </div>
                    <asp:Label ID="lbMsg" runat="server" Text="" Visible="false" Style="color: red; font-family: Arial;
                        float: left; font-size: 15px !important; margin-left: 265px !important; margin-top: -38px !important;"></asp:Label>
                </div>
            </div>
            <div id="DIVEditCirclesss" class="right_section circle_bg" runat="server">
                <asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server">
                    <ContentTemplate>
                        <div id="DVcircles" runat="server" class="circle">
                            <div id="divCircle" runat="server">
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
                                        <div style="border-color: #FF0033;" class="thumb" id="dvcircleimg" runat="server">
                                            <asp:LinkButton ID="lkmovetocircle" runat="server" OnClick="lkmovetocircle_Click">
                                                <asp:Image ID="imgInnercircle" runat="server" class="avatar" ImageUrl="~/images/imagesNew/DefaultInnerCircle.jpg" />
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
                                    <a href="#" style="margin-top: -42px !important;">Encouraging</a>
                                </div>
                            </div>
                            <div style="width: 40%;" align="right" id="divCircle1" runat="server">
                                <asp:Panel ID="PnlCircle" runat="server" Style="display: none">
                                    <div id="popup_wall" runat="server" style="background-color: #F2F0F0;">
                                        <table border="0" cellpadding="5" cellspacing="5" width="100%" align="left" style="border: 1px solid #AAACAD;
                                            background: #FFF; border-radius: 5px; padding: 30px; position: relative; font-family: arial;
                                            font-size: 15px;">
                                            <tr>
                                                <td colspan="3">
                                                    <strong><span style="font-size: 16px; font-weight: bold">Update your Inner Circle:</span></strong>
                                                    <a id="btnClose" style="position: absolute; top: 6px; right: 6px; cursor: pointer;"
                                                        title="Close">
                                                        <img src="../images/cclose.png" /></a>
                                                    <br />
                                                    <br />
                                                    Customize your circle. Make it your own.
                                                </td>
                                            </tr>
                                            <tr>
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
                                            <tr align="center" valign="middle">
                                                <td colspan="3">
                                                    <asp:Button ID="btnupdatecircle" runat="server" class="update-circle" Text="Update"
                                                        ValidationGroup="circle" OnClick="btnupdatecircle_Click" />
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
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnupdatecircle" />
                        <%-- <asp:AsyncPostBackTrigger ControlID="btnInvite" />--%><ajax:PostBackTrigger
                            ControlID="btnupdatecircle"></ajax:PostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpOutterUpdatePanel">
                    <ProgressTemplate>
                        <asp:Panel ID="Panel1" class="inner_circle" runat="server" Style="padding-right: 50px;">
                            <asp:Panel ID="Panel2" class="circle" runat="server">
                                <div style="float: left; margin-left: 539px; margin-right: 295px; margin-top: -485px;">
                                    Processing...
                                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                                        top: 45%;" alt="Processing Request" />
                            </asp:Panel>
                        </asp:Panel>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div style="float: left; margin-left: 484px; margin-top: -33px;">
            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"
                AutoPostBack="true" />
            <span style="color: #4B4B4B; font-family: arial; font-size: 13px; font-weight: bold;">
                Thanks. I got this. Don't show this intro again</span>
        </div>
        <div id="dvFooter" runat="server">
            <div class="footer_miss">
            </div>
        </div>
        <div class="copyrgts">
            <div class="copy_right_left">
                © 2011 Vitality
            </div>
            <div class="copy_right_rgt">
                <asp:LinkButton ID="lnkTermsnConditions" runat="server" OnClick="lnkTermsnConditions_Click"
                    Style="color: #333333 !important;">Terms & Conditions</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkSupport" runat="server" OnClick="lnkSupport_Click" Style="color: #333333 !important;">| Support</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkprivacynPolicy" runat="server" OnClick="lnkprivacynPolicy_Click"
                    Style="color: #333333 !important;">| Privacy Policy</asp:LinkButton>
            </div>
        </div>
        </form>
    </div>
</body>
