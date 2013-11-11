<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MessagesandTickets.aspx.cs" Inherits="ALEREIMPACT.Admin.MessagesandTickets" Title="Feedback/Tickets" %>

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
                                      Feedback And Tickets
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        <tr>
      <td style="float:left;margin-left: 59px;">
      <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">
      <div style=" background-color: #3FB9C4; border-radius: 20px 20px 20px 20px;
    color: white;  float: left;  height: 36px;  margin-bottom: 30px;  margin-left: 206px;
    margin-top: 52px; padding-left: 19px;  padding-top: 17px; width: 142px;">
          
              <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Messages-icon.png" style=" padding-left: 5px;" />
              &nbsp;
              <asp:Label ID="Label1" runat="server" Text="Feedback" style="  color: white; font-size: 18px;"></asp:Label>
         </div>
          </asp:LinkButton>
          
          
          
          <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">
          <div style=" background-color: #3FB9C4; border-radius: 20px 20px 20px 20px;
    color: white;  float: left;  height: 36px;  margin-bottom: 30px;  margin-left: 60px;
    margin-top: 52px; padding-left: 19px;  padding-top: 17px; width: 142px;">
              <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Help-icon.png" style="margin-left: 17px;" />
              &nbsp;
              <asp:Label ID="Label2" runat="server" Text="Tickets" style="  color: white; font-size: 19px;"></asp:Label>
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
