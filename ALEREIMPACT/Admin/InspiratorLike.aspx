<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InspiratorLike.aspx.cs" Inherits="ALEREIMPACT.Admin.InspiratorLike" Title="Inspirator Like " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="main_grid">

<div id="Div1">


  <div id="right_section">
  
  <asp:UpdatePanel ID="UpdatePanel" runat="server" ChildrenAsTriggers="true">
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
            <span style="color:#50514F;">Inspirator Likes &nbsp;(<asp:Label ID="lbname" runat="server" Text=""></asp:Label>
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
                            AllowPaging="true" GridLines="None"  CssClass="table_data" style="text-align:center;" 
                            onpageindexchanging="GridView1_PageIndexChanging">
                            <Columns>
                            
                             <asp:TemplateField HeaderText="User Code" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                              
                              
                                <asp:Label ID="lbname" runat="server" Text='<%#Eval("usercode") %>'></asp:Label>
                               <%-- &nbsp;
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("last_name") %>'></asp:Label>--%>
                            </ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField HeaderText="Date" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbdate" runat="server" Text='<%#Eval("InspiratorLiked_on") %>'></asp:Label>
                            </ItemTemplate>
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
  </div>
  </div>
  </div>
</asp:Content>
