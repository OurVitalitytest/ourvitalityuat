<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Circles.aspx.cs" Inherits="ALEREIMPACT.Admin.Circles" Title="Circles" %>

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
        <td class="heading_bg"><div id="heading_table">User Management </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
      <td>
       <div id="breadcrumb">
        
           <asp:LinkButton ID="lnkUser" runat="server" onclick="lnkUser_Click" style="color:#31A5A0;">User List</asp:LinkButton></a>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;">Circles &nbsp;(<asp:Label ID="lbname" runat="server" Text=""></asp:Label>
            &nbsp;<asp:Label ID="lbname2" runat="server" Text=""></asp:Label>
            )</span>
        </div>
      </td>
      </tr>
      <tr>
      <td style="padding-left:8px;">
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                            AllowPaging="true" GridLines="None"  CssClass="table_data" 
              onpageindexchanging="GridView1_PageIndexChanging"  PageSize="10"
              onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound" style="text-align:center;">
                            <Columns>
                            
                             <asp:TemplateField HeaderText=" Circle Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                               <asp:Label ID="lbId" runat="server" Text='<%#Eval("pk_circle_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbcirclename" runat="server" Text='<%#Eval("circle_name") %>' style="text-align:left;"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number Of Friends" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFrnd" runat="server" Text="" CommandName="friend" CommandArgument='<%#Eval("pk_circle_id") %>' style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle CssClass="link" />
                            </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Found.....
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
      </div>
</asp:Content>
