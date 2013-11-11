<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserAnalytics.aspx.cs" Inherits="ALEREIMPACT.Admin.UserAnalytics" Title="User Analytics" %>

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
                                        User Analytics
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
                              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  AllowSorting="true"
                            OnPageIndexChanging="GridView1_PageIndexChanging" 
                                    OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" 
                                    onrowdatabound="GridView1_RowDataBound" >
                            <Columns>
                            <asp:TemplateField HeaderText="User Code" SortExpression="name" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:Label ID="lbId" runat="server" Text='<%#Eval("fk_user_registration_Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbname" runat="server"  Text='<%#Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Login Time" SortExpression="AT_LOGINTIME" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                              <asp:Label ID="lblogintitme" runat="server"  Text='<%#Eval("AT_LOGINTIME") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Logout Time" SortExpression="AT_LOGOUTTIME" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                              <asp:Label ID="lblogouttitme" runat="server"  Text='<%#Eval("AT_LOGOUTTIME") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number OF Notes" SortExpression="noofComments" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkNotes" runat="server" Text='<%#Eval("noofComments") %>' CommandName="LnkNotes" CommandArgument='<%#Eval("fk_user_registration_Id")+","+Eval("AT_LOGINTIME")+","+ Eval("AT_LOGOUTTIME")%>'></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number OF Circles" SortExpression="noofCircle" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCircles" runat="server" Text='<%#Eval("noofCircle") %>' CommandName="LnkCircles" CommandArgument='<%#Eval("fk_user_registration_Id")+","+Eval("AT_LOGINTIME")+","+ Eval("AT_LOGOUTTIME")%>'></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Number OF Inspirators" SortExpression="noofinspirators" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkInspirators" runat="server" Text='<%#Eval("noofinspirators") %>' CommandName="LnkInspirators" CommandArgument='<%#Eval("fk_user_registration_Id")+","+Eval("AT_LOGINTIME")+","+ Eval("AT_LOGOUTTIME")%>'></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number OF Missions" SortExpression="noofmission" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMission" runat="server" Text='<%#Eval("noofmission") %>' CommandName="LnkMission" CommandArgument='<%#Eval("fk_user_registration_Id")+","+Eval("AT_LOGINTIME")+","+ Eval("AT_LOGOUTTIME")%>'></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                            </td>
                            </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </div>
                            </div>
                            </div>
                            
</asp:Content>
