<%@ Page Title="Vitality - Register " Language="C#" MasterPageFile="~/SiteMaster.Master"
    AutoEventWireup="true" CodeBehind="Register1.aspx.cs" Inherits="ALEREIMPACT.User.Register1" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/style1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        function Randomize() {
            var images = new Array("bg.jpg", "bg1.jpg", "bg2.jpg");
            var imageNum = Math.floor(Math.random() * images.length);
            document.getElementById("registration_bg").style.backgroundImage = "url('images/" + images[imageNum] + "')";
        }
        window.onload = Randomize;

    </script>

    <style type="text/css">
        #main_index
        {
            float: left;
            width: 100%;
            background: url(image/bg1.jpg);
            margin: 0px auto;
        }
        #registration_bg
        {
            float: left;
            width: 100%;
            margin: auto;
            min-height: 800px;
        }
        #circle
        {
            background: url(images/bg.jpg) no-repeat;
            float: left;
            width: 100%;
            margin: auto;
        }
        #divsure div
        {
            float: left;
        }
    </style>
    <%-- <script type="text/javascript">
        function ToggleDiv(Flag) {
            if (Flag == "first") {
                document.getElementById('divsure').style.display = 'block';

                document.getElementById('trbutton').style.display = 'none';
              
            }
            else {
                document.getElementById('divsure').style.display = 'none';
                document.getElementById('trbutton').style.display = 'none';

            }
        }
    </script>--%>

    <script type="text/javascript">
        function divhide(sender, args) {
            if (document.getElementById('divsure').style.display = 'block') {
                document.getElementById('divsure').style.display = 'block';
                var drpYear = document.getElementById("<%=drpYear.ClientID%>");
                var date = new Date();
                var dateyearselected = drpYear.options[drpYear.selectedIndex].value;
                var dateyeartoday = date.getFullYear();
                var dateyeartoday18 = dateyeartoday - 16;
                var datemonth = date.getDate();
                var dateday = date.getMonth();
                var dateday1 = dateday + 1;
                var y = dateyeartoday18 + "/" + dateday1 + "/" + datemonth;
                var scheduleDate = new Date(y);
                if (dateyeartoday <= dateyearselected) {
                    alert("Future or Present Year cannot be selected!");
                    document.getElementById('<%= drpYear.ClientID %>').value = "";

                }
                else if (dateyeartoday18 <= dateyearselected) {
                    alert("age cannot be less than 16 years");
                    document.getElementById('<%= drpYear.ClientID %>').value = "";
                }
                else {
                    document.getElementById('<%= hdndate.ClientID %>').value = document.getElementById('<%= drpYear.ClientID %>').value;
                }
            }
            else {
                document.getElementById('divsure').style.display = 'none';
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="registration_bg">
        <div class="top_box" style="  width: 376px !important;">
            <asp:LinkButton ID="lnkLogin" runat="server" CssClass="top_text" Style="text-decoration: none;"
                OnClick="lnkLogin_Click">Welcome To
            Vitality</asp:LinkButton>
            <%-- <span class="top_text">Welcome To Alere Vitality</span>--%>
        </div>
        <div style="margin: 0 auto; width: 400px;">
            <div class="register_form" style="">
                <table>
                    <tr>
                        <td style="color: #B20202; padding-left: 54px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Style="color: #B20202; float: left; font-family: arial;
                                margin-bottom: -43px; margin-left: 26px; margin-top: 59px; width: 283px;"></asp:Label>
                            <label class="reg_text">
                                First Name
                            </label>
                            <label class="reg_text1">
                                Last Name
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" MaxLength="15" CssClass="reg_box">
                            </asp:TextBox>
                            <asp:TextBox ID="txtLname" runat="server" MaxLength="15" CssClass="reg_box1">
                            </asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="reqNameOnly" runat="server" ErrorMessage="*Please enter first name"
                                CssClass="error" ValidationGroup="newUser" Display="Dynamic" ControlToValidate="txtName"
                                Style="color: #B20202; float: left; font-family: arial; font-size: 12px; margin-left: 26px;
                                visibility: visible; width: 133px;"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Please enter last name"
                                CssClass="error" ValidationGroup="newUser" Display="Dynamic" ControlToValidate="txtLname"
                                Style="color: #B20202; float: right; font-family: arial; font-size: 12px; margin-left: 8px;
                                margin-top: 0px; visibility: visible; width: 177px !important;"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="reg_pass">
                                Email
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtName"
                            FilterType="Custom" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                        </asp:FilteredTextBoxExtender>--%>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="reg_box" Style="border-radius: 0 5px 0 5px !important;
                                width: 254px !important;">
                            </asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="reqEmail" ValidationGroup="newUser" runat="server"
                                CssClass="error" Style="float: left; font-family: arial; font-size: 12px; margin-top: 0px;
                                margin-left: 24px; color: #B20202; width: 153px; visibility: visible;" ErrorMessage="*Please enter valid email"
                                Display="Dynamic" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                                CssClass="error" Style="float: left; font-family: arial; font-size: 12px; margin-left: 27px;
                                width: 144px; color: #B20202; visibility: visible;" ValidationGroup="newUser"
                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="*Please enter valid email"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <%-- <tr id="trbutton">
                    <td>
                        <span class="text_form_like">Would you like to add more info to your profile 
                        now?
                        
                        
                        
                        
                        </span><span class="sure">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Sure" 
                            OnClientClick="ToggleDiv('first');return false;" ></asp:LinkButton>
                        </span><span class="may_be_ltr">
                            <asp:LinkButton ID="LinkButton2" runat="server" Text="May be later" Style="color: #000;"
                                OnClientClick="ToggleDiv('second');return false;"></asp:LinkButton>
                        </span>
                    </td>
                </tr>--%>
                    <tr>
                        <td>
                            <div id="divsure" style="display: Block;">
                                <table>
                                    <tr>
                                        <td>
                                            <label class="form_text1">
                                                Height
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtHeight" runat="server" class="text_box" Style="width: 190px;"
                                                MaxLength="6"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftrHeight" runat="server" FilterType="Custom" ValidChars="0123456789."
                                                TargetControlID="txtHeight">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:DropDownList ID="drpUserHeightOptions" runat="server" Style="margin: 9px 0 0 1px;
                                                float: left;" OnSelectedIndexChanged="DrpHeightUnit_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="cms" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Feet" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Panel ID="txt_inches" runat="server" Visible="false">
                                                <asp:TextBox ID="txtheightInches" runat="server" Style="margin-left: 5px; width: 54px;"
                                                    class="text_box" MaxLength="3"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                                    ValidChars="0123456789." TargetControlID="txtheightInches" />
                                            </asp:Panel>
                                            <asp:Panel ID="ddl_inches" runat="server" Visible="false" Style="margin-top: 0px;
                                                float: left;">
                                                <asp:DropDownList ID="ddlH_UnitInches" runat="server" Style="margin: 9px 0 0 1px;
                                                    float: left;">
                                                    <asp:ListItem Text="inches" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="form_text1">
                                                Weight
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtWeight" Style="width: 133px;" runat="server" class="text_box"
                                                MaxLength="3">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftrWeight" runat="server" FilterType="Numbers" TargetControlID="txtWeight">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:DropDownList ID="drpUserWeightOptions" runat="server" Style="margin: 9px 0 0 1px;">
                                                <asp:ListItem Text="Kilograms (kgs)" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Pounds (lbs)" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="form_text1" style="width: 111px;">
                                                Date Of Birth</label>
                                            <asp:DropDownList ID="drpYear" runat="server" AppendDataBoundItems="true" CssClass="years">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdndate" runat="server" />
                                            <asp:DropDownList ID="drpMonth" runat="server" AppendDataBoundItems="true" CssClass="month">
                                                <%--  <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>--%>
                                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DrpDAy" runat="server" AppendDataBoundItems="true" CssClass="days">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="background: #eee;">
                                <asp:ImageButton ID="Button1" runat="server" ImageUrl="~/images/registernow.png"
                                    class="Register_now" OnClick="Button1_Click" ValidationGroup="newUser" /></div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="dvBottom" runat="server" class="btm_cronr_img" style="float: left; margin-left: 46px;
                margin-top: 0; width: 229px;">
                <img style="width: 337.5px;" src="images/btm_corner.png" /></div>
        </div>
    </div>
</asp:Content>
