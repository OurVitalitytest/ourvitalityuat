<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GroupEmail.aspx.cs" Inherits="ALEREIMPACT.Admin.GroupEmail" Title="Group Email" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <td class="heading_bg"><div id="heading_table">Group Management </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
       <tr>
      <td>
       <div id="breadcrumb">
           
        
           <asp:LinkButton ID="lnkGroup" runat="server" onclick="lnkGroup_Click" style="color: #45B5B0 !important;">Group List</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;">Group Email &nbsp;(<asp:Label ID="lbname" runat="server" Text=""></asp:Label>
            )</span>
        </div>
      </td>
      </tr>
      <tr>
      <td >
      <table border="0" cellpadding="0" cellspacing="0" width="102%">
                    <tr>
                    <td>
                    <span style="float:left; padding-left: 10px; padding-right: 48px;">
                        To:</span>
                    <span style="float:left;">
                    <asp:Label ID="lbTo" runat="server" Text=""></asp:Label>&nbsp; Group
                        </span>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        &nbsp;
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <span style="float:left;padding-left: 10px; padding-right: 20px;   padding-top: 5px;">
                        Subject:</span>
                    <span style="float:left;">
                        <asp:TextBox ID="txtSubject" runat="server" style="width:874px; margin-bottom: 10px;  border: 1px solid #A7A7A7;"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="a" ControlToValidate="txtSubject" Display="Dynamic" ErrorMessage="Enter Subject"></asp:RequiredFieldValidator>
                        </span>
                        
                    </td>
                    </tr>
                     <tr>
                    <td>
                        &nbsp;
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <span style="float:left; padding-left: 10px; padding-right: 11px;padding-top: 49px;"> 
                        Messgae:</span>
                    <span style="float:left;">
                        <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" style="width:878px; margin-bottom: 10px; height: 150px;  border: 1px solid #A7A7A7;"></asp:TextBox><br />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmessage"  ValidationGroup="a" Display="Dynamic" ErrorMessage="Enter Message"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                    </tr>
                     <tr>
                    <td>
                        &nbsp;
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <span style="float:left;">
                        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn_save"   ValidationGroup="a"
                            style="  background: none repeat scroll 0 0 #31A5A0 !important;
    border-radius: 10px 10px 10px 10px !important;    color: #FFFFFF;   margin-bottom: 35px;  margin-left: 80px;  margin-top: 15px;" 
                            onclick="btnSend_Click"/></span>
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
