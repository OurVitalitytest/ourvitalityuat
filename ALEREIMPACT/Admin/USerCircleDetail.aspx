<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="USerCircleDetail.aspx.cs" Inherits="ALEREIMPACT.Admin.USerCircleDetail" Title="Circle Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .cls
    {
    	 padding-left: 110px !important;
    }
</style>
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
            <span style="color:#50514F;"><asp:Label ID="lbname" runat="server" Text=""></asp:Label>
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
                                            <asp:Panel ID="PanelUSerCircle" runat="server" Visible="false">
                                                <asp:GridView ID="grdCirclesDetail" runat="server" AutoGenerateColumns="false" 
                                                    PageSize="20" AllowSorting="true"
                                                    AllowPaging="true" GridLines="None" CssClass="table_data" Style="text-align: center;"
                                                    OnPageIndexChanging="grdCirclesDetail_PageIndexChanging" OnRowCommand="grdCirclesDetail_RowCommand"
                                                    OnSorting="grdCirclesDetail_Sorting" OnRowDataBound="grdCirclesDetail_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Name" SortExpression="circle_name" HeaderStyle-ForeColor="#31A5A0">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbid" runat="server" Text='<%#Eval("fk_user_registration_Id") %>'
                                                                    Visible="false"></asp:Label>
                                                                      <asp:Label ID="lbid1" runat="server" Text='<%#Eval("fk_circle_id") %>'
                                                                    Visible="false"></asp:Label>
                                                                <asp:Label ID="lbname" runat="server" Text='<%#Eval("circle_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Circle Image" HeaderStyle-ForeColor="#000">
                                                            <ItemTemplate>
                                                            <div id="dvimagecircle" runat="server" class="thumb" style="float:left;">
                                                                 <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                            <asp:Image ID="Image1" runat="server" CssClass="avatar" ImageUrl='<%# "/AlereImpactNew/User/CircleImages/" + Eval("circle_image") %>' />
                            </div>
                                                            </ItemTemplate>
                                                           
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Number Of Members" SortExpression="noofmembers" HeaderStyle-ForeColor="#31A5A0">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkMember" runat="server" Text='<%#Eval("noofmembers") %>' Style="color: #31A5A0;
                                                                    text-decoration: underline;" CommandName="lnkMember" CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Number Of Inspirators"  SortExpression="noofinspirators" HeaderStyle-ForeColor="#31A5A0">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkInspirator" runat="server" Text='<%#Eval("noofinspirators") %>' Style="color: #31A5A0;
                                                                    text-decoration: underline;" CommandName="lnkInspirator" CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Number Of Missions" SortExpression="noofmission" HeaderStyle-ForeColor="#31A5A0">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkMission" runat="server" Text='<%#Eval("noofmission") %>' Style="color: #31A5A0;
                                                                    text-decoration: underline;" CommandName="lnkMission" CommandArgument='<%#Eval("fk_circle_id")+ "," + Eval("fk_user_registration_Id") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Found....
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                                
                                                </asp:Panel>
                                                <asp:Panel ID="PanelFreindCircle" runat="server" Visible="false">
                                                <asp:GridView ID="GrdFriendCircleDetail" runat="server" AutoGenerateColumns="false" 
                                                    PageSize="20" AllowSorting="true"
                                                    AllowPaging="true" GridLines="None" CssClass="table_data" Style="text-align: center;"
                                                    OnPageIndexChanging="GrdFriendCircleDetail_PageIndexChanging" 
                                                    OnSorting="GrdFriendCircleDetail_Sorting" OnRowDataBound="GrdFriendCircleDetail_RowDataBound">
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="User Code" SortExpression="name" HeaderStyle-ForeColor="#31A5A0">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbid" runat="server" Text='<%#Eval("friend_registration_Id") %>'
                                                                    Visible="false"></asp:Label>
                                                                      <asp:Label ID="lbid1" runat="server" Text='<%#Eval("fk_circle_id") %>'
                                                                    Visible="false"></asp:Label>
                                                                <asp:Label ID="lbname12" runat="server" Text='<%#Eval("name") %>' style="float:left;"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="cls" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Circle Name" SortExpression="circle_name" HeaderStyle-ForeColor="#31A5A0">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbname" runat="server" Text='<%#Eval("circle_name") %>' style="float:left;"></asp:Label>
                                                            </ItemTemplate>
                                                              <ItemStyle CssClass="cls" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Circle Image" HeaderStyle-ForeColor="#000" >
                                                            <ItemTemplate>
                                                            <div id="dvimagecircle" runat="server" class="thumb" >
                                                                 <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                            <asp:Image ID="Image1" runat="server" CssClass="avatar" ImageUrl='<%# "/AlereImpactNew/User/CircleImages/" + Eval("circle_image") %>'  />
                            </div>
                                                            </ItemTemplate>
                                                        <ItemStyle CssClass="cls" />
                                                        </asp:TemplateField>
                                                       
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No Record Found....
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                                </asp:Panel>
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
