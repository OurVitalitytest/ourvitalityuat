<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InspiratorCircleDetail.aspx.cs" Inherits="ALEREIMPACT.Admin.InspiratorCircleDetail" Title="Inspirators Detail" %>

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
                onclick="LinkButton1_Click" style="color: #45B5B0 !important;"
></asp:LinkButton>
                       <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;"><asp:Label ID="lbname" runat="server" Text="Inspirator Detail"></asp:Label>
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
                                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="10"
                            AllowPaging="true" GridLines="None"  CssClass="table_data" 
                            onpageindexchanging="GridView1_PageIndexChanging" >
                            <Columns>
                            
                             <asp:TemplateField HeaderText=" S.No." HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                               <asp:Label ID="lbId" runat="server" Text='<%#Eval("fk_user_registration_Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbIId" runat="server" Text='<%#Eval("pk_Inspirator_id") %>' Visible="false"></asp:Label>
<%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Image" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
   <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/AlereImpactNew/User/InspiratorImages/" + Eval("Inspirator_image") %>' style="height:100px; width:100px;" />
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Text" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbtext" runat="server" Text='<%#Eval("Inspirator_desc") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText=" Created Date" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbtext" runat="server" Text='<%#Eval("Inspirator_createdon") %>'></asp:Label>
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
