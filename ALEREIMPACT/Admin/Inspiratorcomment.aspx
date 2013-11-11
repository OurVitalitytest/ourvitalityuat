﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Inspiratorcomment.aspx.cs" Inherits="ALEREIMPACT.Admin.Inspiratorcomment" Title="Inspirator Comments" %>

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

<div id="Div1">



  <div id="right_section">
  
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
  <ContentTemplate>
   <table width="695" border="0" cellspacing="0" cellpadding="0" style="background:none;" class="table_bg">
      <tr>
        <td class="heading_bg"><div id="heading_table">Inspirator Management </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
      <td>
       <div id="breadcrumb">
        
           <asp:LinkButton ID="lnkInsp" runat="server" style="color: #45B5B0 !important;" 
               onclick="lnkInsp_Click">Inspirator Management</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;">Inspirator Comments &nbsp;(<asp:Label ID="lbname" runat="server" Text=""></asp:Label>
            &nbsp;<asp:Label ID="lbname2" runat="server" Text=""></asp:Label>
            )</span>
        </div>
      </td>
      </tr>
      <tr>
        <td>
              
        <div style="padding-left: 9px; padding-right: 10px;">
        
         <table border="0" cellpadding="0" cellspacing="0" width="102%">
                    <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="10"
                            AllowPaging="true" GridLines="None"  CssClass="table_data" 
                            onpageindexchanging="GridView1_PageIndexChanging" 
                            onrowdeleting="GridView1_RowDeleting">
                            <Columns>
                            
                             <asp:TemplateField HeaderText="User Code" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                              
                                <asp:Label ID="lbid" runat="server" Text='<%#Eval("pk_InspiratorComments_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbname" runat="server" Text='<%#Eval("usercode") %>'></asp:Label>
                               <%-- &nbsp;
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("last_name") %>'></asp:Label>--%>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                              <asp:Label ID="Lbcomment" runat="server" Text='<%#Eval("InspiratorComment_text") %>'></asp:Label>
                                         </ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField HeaderText="Date" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbdate" runat="server" Text='<%#Eval("InspiratorComment_on") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                      <asp:TemplateField  HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" Text="Delete" style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>                            </ItemTemplate>
                          
                            </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Found....
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                    </tr>
                    </table>
               
        </div>
        
        
        
        </td></tr>
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
  </div>
</asp:Content>
