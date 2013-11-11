<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Flags.aspx.cs" Inherits="ALEREIMPACT.Admin.Flags" Title="Flagged Inspirators" %>

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
        <td class="heading_bg"><div id="heading_table">Flags</div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
     
      <tr>
      <td style="padding-left:8px;">
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  AllowSorting="true"
              OnPageIndexChanging="GridView1_PageIndexChanging"  PageSize="10" 
              style="text-align:center;" onsorting="GridView1_Sorting">
                            <Columns>
                             <asp:TemplateField HeaderText="Created By" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("createdbyname") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Image" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/AlereImpactNew/User/InspiratorImages/" + Eval("Inspirator_image") %>' style="height:150px; width:150px;" />
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Text" HeaderStyle-ForeColor="#000">
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("Inspirator_desc") %>'></asp:Label>
                             </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Flagged By" HeaderStyle-ForeColor="#000">
                              
                               <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("flggedbyname") %>'></asp:Label>
                             </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Flagged On" SortExpression="flaggeddate" HeaderStyle-ForeColor="#31A5A0">
                              <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("flaggeddate") %>'></asp:Label>
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
