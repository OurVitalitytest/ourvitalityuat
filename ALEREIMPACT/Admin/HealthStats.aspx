<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="HealthStats.aspx.cs" Inherits="ALEREIMPACT.Admin.HealthStats" Title="Health Stats" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="float: right; margin-right: 40px; margin-top: 5px;">
        <span style="float: left;">Export to Excel</span>
        <asp:ImageButton ID="ImgBtnExportExcel" runat="server" ImageUrl="~/images/Excel-icon.png"
            OnClick="ImgBtnExportExcel_Click" Style="margin-left: 5px;" />
    </div>
    <div style="float: left; margin-left: 11px; width: 988px; margin-top: -11px;">
        <asp:GridView ID="GrdMissionProgess" runat="server" CssClass="table_data" 
            AllowPaging="true" PageSize="20"
            AutoGenerateColumns="false"  OnPageIndexChanging="GrdMissionProgess_PageIndexChanging"
            OnRowDataBound="GrdMissionProgess_RowDataBound" 
            Style="text-align: center;" onrowcommand="GrdMissionProgess_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="User Code" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lbId" runat="server" Text='<%#Eval("pk_user_registration_Id") %>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="lbName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cals Consumed" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lbCalconsumed" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cals Burned" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lbCalBurned" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Steps" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lbSteps" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Current Weight" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lbCWeight" runat="server" Text='<%#Eval("weight") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandArgument='<%#Eval("pk_user_registration_Id")%>'
                            CommandName="lnkViewChart" Style="color: #31A5A0;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
