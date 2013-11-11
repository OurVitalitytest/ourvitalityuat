<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="ALEREIMPACT.Register" Title="Vitality - Registration" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/newstyle.css" rel="stylesheet" type="text/css" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript"></script>

    <style type="text/css">
        .footer
        {
            background: url(           "../image/footer_img.png" ) repeat scroll 0 0 transparent;
            float: left;
            height: 586px;
            margin-top: 1px;
            width: 100%;
            z-index: -99;
        }
        .side_section_mission
        {
            float: right;
            text-align: left;
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
            width: 50%;
        }
        .copy_right_rgt a
        {
            float: right;
            color: #333333;
            text-decoration: none;
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
        .clsOnlyAlphs
        {
        }
    </style>

    <script type="text/javascript">

    $(function () {
    $('.clsOnlyAlphs').keydown(function (e) {
   // alert(e.keyCode);
    if (e.ctrlKey || e.altKey) {
    e.preventDefault();
    } else {
    var key = e.keyCode;
    if (!((key == 8) || (key == 32)  || (key == 9) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
    e.preventDefault();
    }
    }
    });
    });
    
         $(function () {
            $('.clsOnlyNumeric').keydown(function (e) {
            if (e.shiftKey || e.ctrlKey || e.altKey) {
            e.preventDefault();
            } else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 46)  || (key == 9) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
            e.preventDefault();
            }
            }
            });
         });
         
      function CheckFeetLength() {
      var Unit=$('#ctl00_ContentPlaceHolder1_drpUserHeightOptions').val();
      var val=$('#ctl00_ContentPlaceHolder1_txtHeight').val();
      if(val!='')
      {
        if(Unit==3)
          {
                if(val>8)
                {
                    alert('Maximum limit in feet is 8 feet');
                    $('#ctl00_ContentPlaceHolder1_txtHeight').val('');
                    return false;
                }
                if(val<3)
                {
                    alert('Minimum limit in feet is 3 feet');
                    $('#ctl00_ContentPlaceHolder1_txtHeight').val('');
                    return false;
                }
                else if(val==0)
                {
                 alert('Height cannot be zero.');
                 $('#ctl00_ContentPlaceHolder1_txtHeight').val('');
                    return false;
                
                }
                else 
                {
                    return true;
                }
           }
           
          else if(Unit==1)
          {
                if(val>244)
                {
                    alert('Maximum limit in cm is 244');
                    $('#ctl00_ContentPlaceHolder1_txtHeight').val('');
                    return false;
                }
                else if(val==0)
                {
                 alert('Height cannot be zero.');
                 $('#ctl00_ContentPlaceHolder1_txtHeight').val('');
                 return false;
                }
                else if(val<90)
                {
                 alert('Minimum limit is 90 cm.');
                 $('#ctl00_ContentPlaceHolder1_txtHeight').val('');
                 return false;
                }
                else 
                {
                    return true;
                }
           }
        }
     }
     
     function WghtCheck() {
      var Unit=$('#ctl00_ContentPlaceHolder1_drpUserWeightOptions').val();
      var WeightVal=$('#ctl00_ContentPlaceHolder1_txtWeight').val();
      
//      alert(Unit);
//  alert(WeightVal);
    if(WeightVal!='')
    {  
      if(Unit==1)
          {
                   if(WeightVal<40 || WeightVal>200)
                   {
                    alert('Please enter valid weight.');
                    $('#ctl00_ContentPlaceHolder1_txtWeight').val('');
                    return false;
                   }   
          }
          
      else if(Unit==2)
          {
                   if(WeightVal<88 || WeightVal>440)
                   {
                    alert('Please enter valid weight.');
                    $('#ctl00_ContentPlaceHolder1_txtWeight').val('');
                    return false;
                   }  
          }
      }
     }
     
     function CheckInchesLength() {
      var val=$('#ctl00_ContentPlaceHolder1_txtheightInches').val();
      if(val!='')
      {
        if(val>11)
        {
            alert('Maximum height in inches is 11');
            $('#ctl00_ContentPlaceHolder1_txtheightInches').val('');
            return false;
        }
        else if(val==0)
        {
         alert('Height cannot be zero.');
          $('#ctl00_ContentPlaceHolder1_txtheightInches').val('');
            return false;
        
        }
        else 
        {
            return true;
        }
      }
     }
     
    function GetHeight() {
        var parm = document.getElementById("<%=drpUserHeightOptions.ClientID %>");
        var selected_Unit = parm.options[parm.selectedIndex].text;

        if (selected_Unit == "cms") {

            //var getheight_feet = document.getElementById("<%=txtHeight.ClientID%>").value;
            // var getheight_inches = document.getElementById("<%=txtheightInches.ClientID%>").value;
            // var height_in_cms = (getheight_feet * 30) + (getheight_inches * 2.5);
            document.getElementById("<%=unitofheight.ClientID%>").innerHTML = "cms";
            //txtheightInches
            document.getElementById("incheslength").style.display = "none";
            // document.getElementById("<%=txtHeight.ClientID%>").value = height_in_cms;
            //alert(getheight_feet);


        }
        else if (selected_Unit == "Feet") {

            document.getElementById("<%=unitofheight.ClientID%>").innerHTML = "Feet";
            document.getElementById("incheslength").style.display = "block";
        }
        
        CheckFeetLength();


    }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inner_box">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="top_header">
            <div class="login_logo">
            </div>
        </div>
        <div class="memeber_login">
            <div class="member_login_text">
                Member Registration</div>
        </div>
        <div class="center_register">
            <asp:Label ID="lblMessage" runat="server" Style="color: #B20202; float: left; font-family: arial;
                font-size: 12px; margin-left: 26px; visibility: visible; width: 245px;"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" MaxLength="15" class="firstname clsOnlyAlphs"
                placeholder="Please enter your Firstname">
            </asp:TextBox>
            <asp:TextBox ID="txtLname" runat="server" MaxLength="15" class="lastname clsOnlyAlphs"
                placeholder="Please enter your lastName">
            </asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="reqNameOnly" runat="server" ErrorMessage="*Please enter first name"
                CssClass="error" ValidationGroup="newUser" Display="Dynamic" ControlToValidate="txtName"
                Style="color: #B20202; float: left; font-family: arial; font-size: 12px; margin-left: 51px;
                margin-top: 3px; visibility: visible; width: 133px;"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Please enter last name"
                CssClass="error" ValidationGroup="newUser" Display="Dynamic" ControlToValidate="txtLname"
                Style="color: #B20202; float: right; font-family: arial; font-size: 12px; margin-left: 8px;
                margin-top: 0px; visibility: visible; width: 170px !important;"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" class="email_reg" placeholder="Please enter your Email">
            </asp:TextBox>
            <div>
                <asp:RequiredFieldValidator ID="reqEmail" ValidationGroup="newUser" runat="server"
                    CssClass="error" Style="float: left; font-family: arial; font-size: 12px; margin-top: 3px;
                    margin-left: 51px; color: #B20202; width: 153px; visibility: visible;" ErrorMessage="*Please enter valid email"
                    Display="Dynamic" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                    CssClass="error" Style="float: left; font-family: arial; font-size: 12px; margin-left: 27px;
                    width: 144px; color: #B20202; visibility: visible;" ValidationGroup="newUser"
                    Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ErrorMessage="*Please enter valid email"></asp:RegularExpressionValidator>
            </div>
            <br />
            <div id="divHeiWei" style="float: left; width: 462px;">
                <asp:TextBox ID="txtHeight" runat="server" class="text_box_new clsOnlyNumeric" onblur="return CheckFeetLength();"
                    placeholder="Height" MaxLength="3"></asp:TextBox>
                <asp:Label ID="unitofheight" runat="server" Text="Feet"></asp:Label>
                <div id="incheslength">
                    <asp:TextBox ID="txtheightInches" runat="server" class="text_box_new clsOnlyNumeric"
                        onblur="return CheckInchesLength();" placeholder="Height" MaxLength="2"></asp:TextBox>
                    <asp:Label ID="heightinches" runat="server" Text="inches"></asp:Label>
                </div>
                <asp:DropDownList ID="drpUserHeightOptions" runat="server" onchange="GetHeight()"
                    class="option_value">
                    <asp:ListItem Text="Feet" Value="3"></asp:ListItem>
                    <asp:ListItem Text="cms" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:TextBox ID="txtWeight" Style="width: 133px;" onblur="WghtCheck();" runat="server"
                class="firstname" placeholder="Weight" MaxLength="3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TextBox>
            <asp:FilteredTextBoxExtender ID="ftrWeight" runat="server" FilterType="Numbers" TargetControlID="txtWeight">
            </asp:FilteredTextBoxExtender>
            <asp:DropDownList ID="drpUserWeightOptions" runat="server" class="option_value">
                <asp:ListItem Text="Kilograms (kgs)" Value="1"></asp:ListItem>
                <asp:ListItem Text="Pounds (lbs)" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:HiddenField ID="hdndate" runat="server" />
            <asp:DropDownList ID="drpYear" runat="server" AppendDataBoundItems="true" class="year">
            </asp:DropDownList>
            <asp:DropDownList ID="drpMonth" runat="server" AppendDataBoundItems="true" class="month">
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
            <asp:DropDownList ID="DrpDAy" runat="server" AppendDataBoundItems="true" class="day">
            </asp:DropDownList>
            <asp:ImageButton ID="Button1" runat="server" ImageUrl="~/images/imagesNew/register.png"
                OnClientClick="WghtCheck();" class="submit_class_reg" OnClick="Button1_Click"
                ValidationGroup="newUser" Style="border-width: 0; margin-left: 65px; margin-top: 24px;" />
            <a href="Login.aspx">
                <img style="float: left; margin-left: 18%; margin-top: 5.2%;" src="images/nothanks.jpg" />
            </a>
            <%--  <a href="about.html"> <input type="submit" value="" class="submit_class_reg"/></a>--%>
        </div>
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
            <asp:LinkButton ID="lnkSupport" runat="server" OnClick="lnkSupport_Click">| Support</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lnkprivacynPolicy" runat="server" OnClick="lnkprivacynPolicy_Click">| Privacy Policy</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="lnkTermsnConditions" runat="server" OnClick="lnkTermsnConditions_Click">Terms & Conditions</asp:LinkButton>
        </div>
    </div>
</asp:Content>
