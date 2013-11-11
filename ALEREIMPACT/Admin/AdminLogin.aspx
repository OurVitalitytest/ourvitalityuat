<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ALEREIMPACT.Admin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Vitality</title>
    <link href="../CSS/AdminStyle.css" rel="stylesheet" type="text/css" />
  
  
    <script src="../scripts/md5.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function md5auth() {
            var passwordid = '<%= txtPassword.ClientID %>';
            var password = document.getElementById(passwordid).value;
            var hash = hex_md5(password);
            document.getElementById(passwordid).value = hash;
            return true;
        }
    
    </script>
<%--    <script  language="javascript" type="text/javascript">
    function validate()
{
      if (document.getElementById("<%=txtusername.ClientID%>").value=="")
      {
                 alert("Enter User Name ");
                 document.getElementById("<%=txtusername.ClientID%>").focus();
                 return false;
      }
      if (document.getElementById("<%=txtPassword.ClientID%>").value=="")
      {
                 alert("Enter Password ");
                 document.getElementById("<%=txtPassword.ClientID%>").focus();
                 return false;
      }
      }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
      <div id="member_container">
        
        <!--SOF member main-->
      <div id="member_main">
            
            <!--SOF member header-->
            <div id="member_header" style="height:146px;">
            
               <!--SOF member topbar-->
              <!--<div class="member_topbar">
                <div class="links">
                  <div class="links_icon"><img src="images/member.png" alt="" border="0" /></div>
                     <div class="links_text"><a href="#">Member</a></div>
                     <div class="clear"></div>
                </div>
                  <div class="links" style="margin:11px 40px;">
                     <div class="links_icon"><img src="images/account.png" alt="" border="0" /></div>
                     <div class="links_text"><a href="#">My Account</a></div>
                     <div class="clear"></div>
                </div>
                  <div class="links">
                     <div class="links_icon"><img src="images/home.png" alt="" border="0" /></div>
                     <div class="links_text"><a href="#">Home</a></div>
                     <div class="clear"></div>
                </div>
                  <div class="clear"></div>
              </div>-->
               <!--EOF member topbar-->
               
               <!--SOF member logo area-->
              <div id="logo_area">
<div id="logo"> VITALITY</div>
                <div class="clear"></div>
               </div>
               <!--EOF member logo area-->
               
            </div>
            <!--EOF member header-->
            
            
            <div class="member_content">
            
               <div id="login_div">
                  <div class="login">LOGIN</div>
                   <div class="login_form">
                     <div class="login_feild">
                  
                   
                        <div class="user_name">
                            <asp:TextBox ID="txtusername" runat="server" CssClass="login_input"></asp:TextBox>
                        </div>
                        
                        <div  style="padding-top:9px;"> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   ErrorMessage="Enter User Name" ControlToValidate="txtusername" ValidationGroup="a"></asp:RequiredFieldValidator>
<br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" style="   padding-left: 2px;" 
                        ValidationGroup="a" ControlToValidate="txtusername" runat="server" ErrorMessage="Enter valid Username "
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  >
                    </asp:RegularExpressionValidator>
                        </div>
                        <div class="clear"></div>
                     </div>
                     <div class="login_feild">
                       <div class="password">
                           <asp:TextBox ID="txtPassword" runat="server" CssClass="login_input" TextMode="Password"  onchange="md5auth(); "></asp:TextBox>
                       </div>
                       <div style="padding-top:31px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   ErrorMessage="Enter Password" ControlToValidate="txtPassword" ValidationGroup="a"></asp:RequiredFieldValidator>
                       </div>
                       <div class="clear"></div>
                     </div>
                     <div class="login_btn_area">
                       <div class="login_btn">
                           <asp:ImageButton ID="ImageButton1" runat="server"  
                               ImageUrl="~/images/login_btnadmin.png"  ValidationGroup="a" 
                       onclick="ImageButton1_Click"/></div>
                        <div class="clear"></div>
                    </div>
                 <div class="clear"></div>
                           </div>
                  <div class="clear"></div>
               </div>
               <div class="clear"></div>
               
            </div>
            <!--EOF member content-->
            <div class="clear"></div>
                       
      </div>
      <!--EOF member main-->
        
      <!--SOF member footer-->  
      <div id="footer">
         <div class="footer_area"></div>
      </div>
      <!--EOF member footer-->
        
    </div>
    <!--EOF member container-->
    </form>
</body>
</html>
