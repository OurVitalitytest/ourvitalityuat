<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminChangePassword.aspx.cs" Inherits="ALEREIMPACT.Admin.AdminChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ALERE</title>
    <link href="../CSS/AdminStyle.css" rel="stylesheet" type="text/css" />
  
</head>
<body>
    <form id="form1" runat="server">
        <div id="main_wraper">
<div id="main_body">
<div id="header">
<div id="logo_top"><a href="AdminDashboard.aspx" style="font-size:18px; font-weight:bold;" > VITALITY</a></div>
<div id="header_welcome">
  <ul>
    <li>Welcome&nbsp;Admin</li>&nbsp;
    <li> <a href="AdminChangePassword.aspx" class="txt_blue">Change Password</a></li>|
    <li> <a href="AdminLogin.aspx" class="txt_blue" title="Logout">Logout</a></li>
  </ul>
  </div>
 <div id="main_grid">

<div class="main_dashborad">
<div class="dashborad_haed">
<a href="AdminDashboard.aspx" style=" color:#fff; text-decoration:none; font-size: 22px;">Dashboard</a>

</div>


<div class="first_box_dash"  style="height:193px;">
<div class="img_thumb"> <img alt="" src="../images/user_profile.png"/></div>
<div class="img_thumb_head"> User Management</div>
<div class="img_thumb"> <a  href="AdminPanel.aspx" >User Management</a></div>
<div class="img_thumb"> <a href="GroupDetail.aspx">Group Management</a></div>
<div class="img_thumb" > <a href="UserInvitation.aspx" > User Invitations </a>  </div>
<div class="img_thumb"> <a href="CircleManagement.aspx">Circle Management</a></div>

</div>
<div class="first_box_dash"  style="height:193px;">
<div class="img_thumb"> <img alt="" src="../images/mission_pro.png"/></div>
<div class="img_thumb_head"> Inspirators</div>
<div class="img_thumb"> <a href="InspiratorManagement.aspx">Inspirator Management</a></div>
<div class="img_thumb"> <label style="color:#999999 !important; font-size:13px;">API Links</label></div>
<div class="img_thumb"> <label style="color:#999999 !important; font-size:13px;">Create an API</label></div>

</div>

<div class="first_box_dash"  style="height:193px;">
<div class="img_thumb"><img alt="" src="../images/mission.jpg"/></div>
<div class="img_thumb_head"> Mission</div>
<div class="img_thumb"> <a href="MissionManagement.aspx">Mission Management</a></div>
<div class="img_thumb"> <label style="color:#999999 !important; font-size:13px;">Messages</label></div>
<div class="img_thumb"> <label style="color:#999999 !important; font-size:13px;">Triggers/Rules</label></div>
<div class="img_thumb"> <label style="color:#999999 !important; font-size:13px;">Mood Analytics</label></div>

</div>

<div class="first_box_dash"  style="height:193px;">
<div class="img_thumb"> <img alt="" src="../images/analytic.png"/></div>
<div class="img_thumb_head"> Analytics</div>
<div class="img_thumb"> <label style="color:#999999 !important; font-size:13px;">Usage Stats</label></div>
<div class="img_thumb"> <label style="color:#999999 !important; font-size:13px;">Health Stats</label></div>
<div class="img_thumb"> <a href="UserAnalytics.aspx">  User Analytics</a> </div>

</div>


<div class="first_box_dash"  style="height:193px;">
<div class="img_thumb"> <img alt="" src="../images/help.png"/></div>
<div class="img_thumb_head">Help Desk</div>
<div class="img_thumb"> <a href="ErrorTypeLog.aspx">  Error Log</a></div>
<div class="img_thumb"> <a href="Flags.aspx" >Flags</a></div>
<div class="img_thumb">
                    <a href="GlobalMessageDetail.aspx">Messages Detail</a></div>
<div class="img_thumb"> <a href="MessagesandTickets.aspx">    Feedback/Tickets</a></div>
</div>

  <div id="right_section">


    <table width="980" border="0" cellspacing="0" cellpadding="0" style="background:none;" class="table_bg">
      <tr>
        <td class="heading_bg"><div id="heading_table">Change Password </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="16%" height="35" align="left" style="padding-right:5px; padding-left: 18px;">
                                     <span style="padding-bottom:5px;">  Password</span> <span  style="color:Red;">*</span>
                                    </td>
                                    <td width="27%" height="35" align="left">
                                        <asp:TextBox ID="txtPassword"  runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                                        <asp:Label ID="lberrormsg" runat="server" Visible="false" CssClass="error"></asp:Label>
                                        <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" style="width:50px;"  ErrorMessage="Enter Password"  ControlToValidate="txtPassword" ValidationGroup="ChkPass"></asp:RequiredFieldValidator>
                        </div>
                                    </td>
                                    <td width="2%" height="35" align="left">&nbsp;   
                                    </td>
                                    </tr>
                                    <tr>
                                    <td width="16%" height="35" align="left"  style="padding-right:5px; padding-left: 18px;">
                                        New Password<span  style="color:Red;">*</span>
                                    </td>
                                    <td width="27%" height="35" align="left">
                                        <asp:TextBox ID="txtNewPassword" runat="server"  CssClass="input"  TextMode="Password"
                                            MaxLength="12"></asp:TextBox>
                                         <div> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" style="width:50px;"   ErrorMessage="Enter New Password" ControlToValidate="txtNewPassword" ValidationGroup="ChkPass"></asp:RequiredFieldValidator>
                        </div>
                                    </td>
                                     <td width="2%" height="35" align="left">&nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                  <td width="16%" height="35" align="left"  style="padding-right:5px; padding-left: 18px;">
                                        Confirm Password<span style="color:Red;">*</span>
                                    </td>
                                   <td width="27%" height="35" align="left">
                                        <asp:TextBox ID="txtConfirmPassword"  runat="server"  CssClass="input" TextMode="Password"></asp:TextBox>
                                        <div > 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="Enter Confirm Password" ControlToValidate="txtConfirmPassword" ValidationGroup="ChkPass"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" runat="server" ValidationGroup="ChkPass" style="  padding-right: 35px;" 
                                                ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password not matched"></asp:CompareValidator>
                        </div>
                                        <div>
                                           
                                        </div>
                                    </td>
                                    <td width="2%" height="35" align="left">&nbsp;
                                        
                                    </td>
                                   
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="50" align="right" >
                            <div style="float:left;  padding-left: 200px;  padding-top: 22px;" >
                                
                                <asp:Button ID="btnchgpwd"  runat="server" Text="Change Password" 
                                    CssClass="dashborad_submit"   ValidationGroup="ChkPass"  style="cursor:pointer;  border-radius: 20px 20px 20px 20px;    padding-top: 3px;    width: 166px;"
                                    onclick="btnchgpwd_Click"/>
                            </div>
                        <%--</td>
                        <td height="50" align="right" style="width:50px;">--%>
                            <div style="float:left;  padding-top: 20px;">
                                <asp:Button ID="btnLogout" runat="server"  CssClass="dashborad_submit" style=" cursor:pointer; border-radius: 20px 20px 20px 20px;    margin-left: 21px;      padding-left: 6px;  margin-top: 8px;    padding-top: 2px;    width: 166px;"                                    Text="Back to HomePage" onclick="btnLogout_Click"   />
                            </div>
                        </td>
                        <tr><td>&nbsp;</td></tr>
                    </tr>
                </table>
           
 </div>
 </div>
 </div>
    </div>
       <div id="footer">
         <div class="footer_area"></div>
         </div>
      </div>
 </div>
    </form>
</body>
</html>
