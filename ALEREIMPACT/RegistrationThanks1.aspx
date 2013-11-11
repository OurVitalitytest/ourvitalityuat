<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistrationThanks1.aspx.cs" Inherits="ALEREIMPACT.RegistrationThanks1" Title="Vitality-Registration Thanks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/style1.css" rel="stylesheet" type="text/css" />
<style type="text/css">#main_index{ float:left; width:100%; background:url(images/bg1.jpg); margin:0px auto;  min-height:800px; }</style>

    <script src="scripts/AC_RunActiveContent.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script src="js/jquery.flexslider-min.js" type="text/javascript"></script>

    <%--<link href="CSS/style1.css" rel="stylesheet" type="text/css" />--%>
    <link href="CSS/flexslider.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
		$(window).load(function() {
			$('.flexslider').flexslider();
		});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="main_index">
    <div class="top_box" style=" margin-right: 107px !important;
    width: 376px !important;"><Span class="top_text">Welcome To Vitality</Span> </div>
<%--<div class="bg_shadow">--%>
<%--<div class="vedio_index">

<div class="flexslider">
                    <ul class="slides">
                        <li>
                            <img src="images/1st.png" />
                            <p class="flex-caption">
                                It’s incredible. I used to have to take naps every day. I’d fall asleep in the middle
                                of the day. Once I was diagnosed with Type 2 and I committed to losing 2 pounds
                                a week, I have so much more energy now. I don’t need naps anymore!.</p>
                        </li>
                        <li>
                            <img src="images/2nd.png" />
                            <p class="flex-caption">
                                I was really scared when I first learned I had Diabetes. But connecting with my
                                doctor and building my own online support network has made me feel stronger. I am
                                making good progress improving my health and I’ve made some really great friends.</p>
                        </li>
                        <li>
                            <img src="images/3rd.png" />
                            <p class="flex-caption">
                                I’m seeing better results with my patients and they feel better supported.</p>
                        </li>
                    </ul>
                </div>
<%--<script src="http://admin.brightcove.com/js/BrightcoveExperiences.js" type="text/javascript"></script>
<object width="400" height="300" type="application/x-shockwave-flash" data="http://c.brightcove.com/services/viewer/federated_f9?&amp;width=400&amp;height=300&amp;flashID=myExperience2149850350001&amp;bgcolor=%23FFFFFF&amp;playerID=1042541708001&amp;playerKey=AQ~~%2CAAAA8me29Gk~%2CdrNvynwbXLohPfE6vixARhaoHdSnT-9k&amp;isVid=true&amp;dynamicStreaming=true&amp;%40videoPlayer=2149850350001&amp;autoStart=&amp;debuggerID=&amp;startTime=1364478633689" id="myExperience2149850350001" class="BrightcoveExperience" seamlesstabbing="undefined"><param name="allowScriptAccess" value="always"><param name="allowFullScreen" value="true"><param name="seamlessTabbing" value="false"><param name="swliveconnect" value="true"><param name="wmode" value="window"><param name="quality" value="high"><param name="bgcolor" value="#FFFFFF"></object>
<script type="text/javascript">brightcove.createExperiences();</script>
</div>--%>


<div class="login_form" style=" margin-top: 165px !important;">
    <label class="thanku">Thanks for signing up,check your email for your password so we can get you started.  </label>

<a  href="Login.aspx">
    <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/loginnew.png" style="float:right;margin-right:131px; margin-top:18px;" /></a> <br/>
    </div>
   <%-- </div>--%>
    </div>
</asp:Content>
