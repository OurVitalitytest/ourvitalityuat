<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MissionDetail.aspx.cs" Inherits="ALEREIMPACT.Admin.MissionDetail" Title="Mission Detail" %>

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
      <td>
       <div id="breadcrumb">
        
           <asp:LinkButton ID="lnkMission"  runat="server" 
               style="color: #45B5B0 !important;" onclick="lnkMission_Click" >Mission 
           Management</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;"><asp:Label ID="lbname" runat="server" Text="Mission Detail"></asp:Label>
            &nbsp;(<asp:Label ID="lbname2" runat="server" Text=""></asp:Label>
            )</span>
        </div>
      </td>
      </tr>
      <tr>
      <td>
      <table border="0" cellpadding="0" cellspacing="0" width="102%">
                    <tr>
                    <td style="width:51px;">
                     <span style="float:left;  padding-left: 18px; padding-top: 5px;  padding-right: 29px;">
                        Filter Search:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true"  style="width:185px;"
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged"  >
                        <asp:ListItem Text="Filter By" Value="0"></asp:ListItem>
                        <asp:ListItem Text="By Mission Theme" Value="1"></asp:ListItem>
                        <asp:ListItem Text="By  Mission Type" Value="2"></asp:ListItem>
                          <asp:ListItem Text="By Circle Type" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:51px;">
                     <div id="divTheme" style="display:none"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Mission Theme:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpMTheme" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true"  style="width:185px;"
                             onselectedindexchanged="DrpMTheme_SelectedIndexChanged">
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div id="divType"  style="display:none;"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Mission Type:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpMType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true"  style="width:185px;"
                             onselectedindexchanged="DrpMType_SelectedIndexChanged"  >
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="divCircle" style="display:none;"    runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Circle Type:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpCircleType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true"  style="width:185px;"
                            onselectedindexchanged="DrpCircleType_SelectedIndexChanged"  >
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    </td>
                    </tr>
                    </table>
      </td>
      </tr>
                            <tr>
                                <td style="padding-left: 17px; padding-right: 17px;">
                                    <table border="0" cellpadding="0" cellspacing="0" width="102%">
                                        <tr>
                                            <td>
                                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  style="text-align:center;" AllowSorting="true"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                                                    OnSorting="GridView1_Sorting" >
                            <Columns>
                            
                             <asp:TemplateField HeaderText="Mission Name" SortExpression="mission_name" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                               <asp:Label ID="lbId" runat="server" Text='<%#Eval("Pk_mission_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbIId" runat="server" Text='<%#Eval("mission_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mission Theme" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbmtheeme" runat="server" Text='<%#Eval("mission_theme") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
          <asp:TemplateField HeaderText="Mission Type" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbtype" runat="server" Text='<%#Eval("mission_type") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Circle Type" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbCtype" runat="server" Text='<%#Eval("circle_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Date"  SortExpression="mission_name" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:Label ID="lbCdate" runat="server" Text='<%#Eval("date_created_on") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Target date"  SortExpression="mission_name" HeaderStyle-ForeColor="#31A5A0" >
                            <ItemTemplate>
                                <asp:Label ID="lbDDate" runat="server" Text='<%#Eval("deadline_date_set") %>'></asp:Label>
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
