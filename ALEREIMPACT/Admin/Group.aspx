<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="ALEREIMPACT.Admin.Group" Title="Group Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .link
    {
    	text-align:center;
    	text-decoration: underline;
    	color:Blue;
    	
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<div id="main_grid">


  <div id="right_section">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
  <ContentTemplate>
  
   <table width="695" border="0" cellspacing="0" cellpadding="0" style="background:none;" class="table_bg">
      <tr>
        <td class="heading_bg"><div id="heading_table">Group Management  </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
       <tr>
      <td>
       <div id="breadcrumb">
        
           <asp:LinkButton ID="lnkGroup" runat="server" onclick="lnkGroup_Click" style="color: #45B5B0 !important;">Group List</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;">Group User List &nbsp;(<asp:Label ID="lbname" runat="server" Text=""></asp:Label>)</span>
        </div>
      </td>
      </tr>
      <tr>
      <td>
            <table border="0" cellpadding="0" cellspacing="0" width="102%">
                    <tr>
                    <td style="width:51px;">
                     <span style="float:left;  padding-left: 18px; padding-top: 5px;  padding-right: 29px;">
                        Filter Search:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true"  style=" width:185px;"
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
                        <asp:ListItem Text="Filter By" Value="0"></asp:ListItem>
                        <asp:ListItem Text="By Status" Value="1"></asp:ListItem>
                            <asp:ListItem Text="By Location" Value="2"></asp:ListItem>
                        <asp:ListItem Text="By User Type" Value="3"></asp:ListItem>
                          <asp:ListItem Text="By Registration Type" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:51px;">
                     <div id="divStatus" style="display:none"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Status:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpStatus" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true"  style=" width:185px;"
                             onselectedindexchanged="DrpStatus_SelectedIndexChanged">
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div id="divLocation" style="display:none"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Location:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpLocation" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" style=" width:185px;"
                            onselectedindexchanged="DrpLocation_SelectedIndexChanged">
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div id="divUserType"  style="display:none;"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select User Type:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpUserType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" style=" width:185px;"
                             onselectedindexchanged="DrpUserType_SelectedIndexChanged" >
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                      <div id="divRegsType"  style="display:none"  runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                          Select Registration Type:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpRegisType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" style=" width:185px;"
                            onselectedindexchanged="DrpRegisType_SelectedIndexChanged" >
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    </td>
                    </tr>
                    </table>
      </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>
     <table align="center" width="98%">
<tr>
<td>
<asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="300px" SelectionMode="Multiple" style="background:none; font-size: 12px; color: black; margin-left:8px; margin-right:134px;border: 1px solid #878787;">
</asp:ListBox>

</td>
<td>
<table>
<tr>
<td>
<asp:Button ID="btn1" runat="server" Text=">" Width="45px" onclick="btn1_Click"  />
</td>
</tr>
<tr>
<td>
<asp:Button ID="btn2" runat="server" Text=">>" Width="45px" onclick="btn2_Click"  />
</td>
</tr>
<tr>
<td>
<asp:Button ID="btn3" runat="server" Text="<" Width="45px" onclick="btn3_Click"  />
</td>
</tr>
<tr>
<td>
<asp:Button ID="btn4" runat="server" Text="<<" Width="45px" onclick="btn4_Click"  />
</td>
</tr>
</table>
</td>
<td >
<asp:ListBox ID="ListBox2" runat="server" Height="300px" Width="300px"  SelectionMode="Multiple" style="background:none; color: black; margin-left:135px; font-size: 12px; border: 1px solid #878787;">

</asp:ListBox>
<br />
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Add Some Users" Enabled="false" ControlToValidate="ListBox2" ValidationGroup="a" ></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td colspan="3">
<asp:Label ID="lbltxt" runat="server" ForeColor="Red" style="    float: right;
    margin-right: 125px;"></asp:Label>
    <asp:Label ID="lbtext1" runat="server" ForeColor="Red" style=" float: left;  margin-left: 17px;
    "></asp:Label>
</td>
</tr>
</table>
    
                </td>
                </tr>
               <tr>
               <td>
                   &nbsp;
               </td>
                  
               </tr>
          <tr>
          <td>
           <table align="center">
          <tr>
          <td>
          <span style="float:left; padding:7px 24px 20px 15px;">Group Name:  </span><span  style="float:none;">
              <asp:TextBox ID="txtGroup" runat="server"  MaxLength="50" CssClass="box_dashboard" ValidationGroup="a" style="margin-top:0px; margin-left:0px;"></asp:TextBox></span>
              <br />
 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Group Name" ControlToValidate="txtGroup" ValidationGroup="a" ></asp:RequiredFieldValidator>
          </td>
          </tr>
           <tr>
           <td style="  padding-left: 112px;">
            <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="dashborad_submit" ValidationGroup="a"  style=" cursor:pointer;  border-radius: 10px 10px 10px 10px;    padding-top: 5px !important;    width: 69px;"
                   onclick="btnsave_Click"   />
            <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="dashborad_submit"  style="cursor:pointer;  border-radius: 10px 10px 10px 10px;    padding-top: 5px !important;    width: 85px;"
                   onclick="btnupdate_Click"  /> 
     </td>
           </tr>
           </table>
          </td>
          </tr>      
          
                </table>
        </ContentTemplate>
        <Triggers>
    </Triggers>
    </asp:UpdatePanel>
     <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <div id="progressBackgroundFilter1" class="progressBackgroundFilter">
                </div>
                <div id="processMessage1" class="processMessage">
                    <img src="../images/please_wait.gif" alt="Please Wait..." />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        
</div>
</div>
        </div>
</asp:Content>
