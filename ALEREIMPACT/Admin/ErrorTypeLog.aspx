<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ErrorTypeLog.aspx.cs" Inherits="ALEREIMPACT.Admin.ErrorTypeLog" Title="Error Log" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
   
             <div id="main_grid">
            <div id="right_section">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <table width="695" border="0" cellspacing="0" cellpadding="0" style="background: none;"
                            class="table_bg">
                            <tr>
                                <td class="heading_bg">
                                    <div id="heading_table">
                                        Error Log
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
      <tr>
      <td>
      <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">
      <div style=" background-color: #3FB9C4; border-radius: 20px 20px 20px 20px;
    color: white;  float: left;  height: 36px;  margin-bottom: 30px;  margin-left: 206px;
    margin-top: 52px; padding-left: 19px;  padding-top: 17px; width: 223px;">
          
              <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Error-icon.png" style=" padding-left: 10px;" />
              &nbsp;
              <asp:Label ID="Label1" runat="server" Text="User Reported Errors" style="  color: white; font-size: 15px;"></asp:Label>
         </div>
          </asp:LinkButton>
          
          
          
          <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" Enabled="false">
          <div style=" background-color: #3FB9C4; border-radius: 20px 20px 20px 20px;
    color: white;  float: left;  height: 36px;  margin-bottom: 30px;  margin-left: 60px;
    margin-top: 52px; padding-left: 19px;  padding-top: 17px; width: 223px;">
              <asp:Image ID="Image2" runat="server" ImageUrl="~/images/server-error-icon.png" />
              &nbsp;
              <asp:Label ID="Label2" runat="server" Text="Server Monitoring Errors" style="  color: white; font-size: 15px;"></asp:Label>
               </div>
          </asp:LinkButton>
         
      </td>
   
      </tr>
    
      
                            
                        </table>
                    </ContentTemplate>
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
</asp:Content>
