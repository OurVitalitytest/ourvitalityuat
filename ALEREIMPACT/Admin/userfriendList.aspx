<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="userfriendList.aspx.cs" Inherits="ALEREIMPACT.Admin.userfriendList" Title=" Member List" %>

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
        <td class="heading_bg"><div id="heading_table">User Management </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
      <td>
       <div id="breadcrumb">
          <%--  <img src="../images/home.jpg" alt="" border="0" />--%>
          <asp:Panel ID="PanelUser" runat="server" Visible="false" style="float:left;">
           <asp:LinkButton ID="LinkButton3" runat="server" 
                onclick="LinkButton3_Click" style="color: #45B5B0 !important;">User List</asp:LinkButton>
             <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
           <asp:LinkButton ID="LinkButton1" runat="server" Text="Circles" 
                onclick="LinkButton1_Click" style="color: #45B5B0 !important;"></asp:LinkButton>
                </asp:Panel>
                     <asp:Panel ID="PanelCircle" runat="server" Visible="false" style="float:left;">
                      <asp:LinkButton ID="LinkButton4" runat="server" 
                onclick="LinkButton4_Click" style="color: #45B5B0 !important;">Circle Management</asp:LinkButton>
             <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
           <asp:LinkButton ID="LinkButton2" runat="server" Text="Self Created Circle Detail" 
                onclick="LinkButton2_Click" style="color: #45B5B0 !important;"></asp:LinkButton>
                     </asp:Panel>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
          <span style="color:#50514F;"> <asp:Label ID="lbcirename" runat="server" Text=""></asp:Label></span>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
           <span style="color:#50514F;">  Member List</span>
        </div>
      </td>
      </tr>
      <tr>
      <td style="padding-left:8px;">
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  PageSize="10"
              onpageindexchanging="GridView1_PageIndexChanging" style="text-align:center;">
                            <Columns>
                            <asp:TemplateField HeaderText="User Code" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbname1" runat="server" Text='<%#Eval("usercode") %>'></asp:Label>
                                 <%--<asp:Label ID="lbname2" runat="server" Text='<%#Eval("last_name") %>'></asp:Label>--%>
                            </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Email" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbemail" runat="server" Text='<%#Eval("login_email") %>'></asp:Label>
                            </ItemTemplate>
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
       <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel" runat="server">
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
