<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CircleMissionDetail.aspx.cs" Inherits="ALEREIMPACT.Admin.CircleMissionDetail" Title="Mission Detail" %>

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
                                        Circle Management
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
        
            <asp:LinkButton ID="lnkCirle" runat="server" onclick="lnkCirle_Click" style="color: #45B5B0 !important;">Circle 
           Management</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
             <asp:LinkButton ID="LinkButton1" runat="server" Text="Self Created Circle Detail" 
                onclick="LinkButton1_Click" style="color: #45B5B0;" ></asp:LinkButton>
                       <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;"><asp:Label ID="lbname" runat="server" Text="Mission Detail"></asp:Label>
            &nbsp;(<asp:Label ID="lbname2" runat="server" Text=""></asp:Label>
            )</span>
        </div>
      </td>
      </tr>
                            <tr>
                                <td style="padding-left: 17px; padding-right: 17px;">
                                    <table border="0" cellpadding="0" cellspacing="0" width="102%">
                                        <tr>
                                            <td>
                                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data" 
                            onpageindexchanging="GridView1_PageIndexChanging" >
                            <Columns>
                            
                             <asp:TemplateField HeaderText=" S.No." HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                               <asp:Label ID="lbId" runat="server" Text='<%#Eval("fk_created_by_user_Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbIId" runat="server" Text='<%#Eval("Pk_mission_id") %>' Visible="false"></asp:Label>
<%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Mission Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                          <asp:Label ID="lbtext" runat="server" Text='<%#Eval("mission_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Mission Theme" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbtext" runat="server" Text='<%#Eval("mission_theme") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText=" Mission Type" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbtext" runat="server" Text='<%#Eval("mission_type") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Created Date" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbtext" runat="server" Text='<%#Eval("date_created_on") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Target Date" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbtext" runat="server" Text='<%#Eval("deadline_date_set") %>'></asp:Label>
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
