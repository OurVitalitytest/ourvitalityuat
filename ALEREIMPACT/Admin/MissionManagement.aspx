<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MissionManagement.aspx.cs" Inherits="ALEREIMPACT.Admin.MissionManagement" Title=" Mission Management" %>

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
                                        Mission Management
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
     
                            <tr>
                                <td style="padding-left: 17px; padding-right: 17px;">
                                    <table border="0" cellpadding="0" cellspacing="0" width="102%">
                                        <tr>
                                            <td>
                                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  style="text-align:center;" AllowSorting="true"
                            OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" 
                                                    OnSorting="GridView1_Sorting" onrowdatabound="GridView1_RowDataBound" >
                            <Columns>
                            
                             <asp:TemplateField HeaderText="Name" SortExpression="User Code" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                               <asp:Label ID="lbId" runat="server" Text='<%#Eval("fk_user_registration_Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbIId" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Number Of Missions" SortExpression="noofmission" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                               <asp:LinkButton ID="lnkMission" runat="server" Text='<%#Eval("noofmission") %>' Style="color: #31A5A0;
                         text-decoration: underline;" CommandName="lnkMission" CommandArgument='<%#Eval("fk_user_registration_Id") %>'></asp:LinkButton>
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
