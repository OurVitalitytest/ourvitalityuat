<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewTicketsReply.aspx.cs" Inherits="ALEREIMPACT.Admin.ViewTicketsReply" Title="View Tickets Reply" %>

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
      <td>
       <div id="breadcrumb" style="width: 955px !important;">
        
          <asp:LinkButton ID="lnkMsg" runat="server" onclick="lnkMsg_Click" style="color: #45B5B0 !important;">Feedback And Tickets</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
           <asp:LinkButton ID="lnkTicket" runat="server" onclick="lnkTicket_Click" style="color: #45B5B0 !important;"> Tickets</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;">
           <asp:Label  ID="lbname" runat="server" Text="View Ticket Reply"></asp:Label>
          ( <asp:Label  ID="lbTicketNumber" runat="server" Text=""></asp:Label>)
            </span>
        </div>
      </td>
      </tr>
                        <tr>
      <td>
    
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="20"
                                   CssClass="table_data"  GridLines="None"  AllowPaging="true"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" style="text-align: center; margin-left: 12px;" >
                                <Columns>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="Black">
                                <ItemTemplate> 
                                    <asp:Label ID="lbID" runat="server" Text='<%#Eval("TR_ID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lbName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                </ItemTemplate>
                                
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ticket Number" HeaderStyle-ForeColor="Black">
                                <ItemTemplate> 
                                    <asp:Label ID="lbNUmber" runat="server" Text='<%#Eval("T_ID_FK") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Reply" HeaderStyle-ForeColor="Black">
                                <ItemTemplate> 
                                    <asp:Label ID="lbreply" runat="server" Text='<%#Eval("TR_REPLY") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Date" HeaderStyle-ForeColor="Black">
                                <ItemTemplate> 
                                    <asp:Label ID="lbdate" runat="server" Text='<%#Eval("TR_DATE") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                No Reply  Found.....
                                </EmptyDataTemplate>
                                </asp:GridView>        
                     
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
