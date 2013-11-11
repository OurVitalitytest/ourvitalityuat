<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Notes.aspx.cs" Inherits="ALEREIMPACT.Admin.Notes" Title="USer Analytics" %>

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
                             <div id="breadcrumb" style="width:947px !important;">
        
            <a href="UserAnalytics.aspx" style="color: #45B5B0 !important;" >User Analytics </a>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            
            <asp:Panel  ID="PanleNotes" runat="server" Visible="false" style="  margin-left: 111px; margin-top: -16px;" >
             <span style="color:#50514F;">
           <asp:Label ID="lblink" runat="server" Text=" Notes"></asp:Label>&nbsp;
            (<asp:Label ID="lbname2" runat="server" Text="" style="margin-top:5px;"></asp:Label>
            )
           </span>
           </asp:Panel>
           <asp:Panel  ID="PanelCircle" runat="server"  Visible="false" style="  margin-left: 111px; margin-top: -16px;" >
           <span style="color:#50514F;">
           <asp:Label ID="Label3" runat="server" Text="Circles"></asp:Label>
           &nbsp;
            (<asp:Label ID="lbname3" runat="server" Text="" style="margin-top:5px;"></asp:Label>
            )
           </span>
           </asp:Panel>
             <asp:Panel  ID="PanelInspirator" runat="server"  Visible="false" style="  margin-left: 111px; margin-top: -16px;">
             <span style="color:#50514F;">
           <asp:Label ID="Label4" runat="server" Text="Inspirators"></asp:Label>
           &nbsp;
            (<asp:Label ID="lbname1" runat="server" Text="" style="margin-top:5px;"></asp:Label>
            )
           </span>
           </asp:Panel>
             <asp:Panel  ID="PanelMission" runat="server"  Visible="false" style="  margin-left: 111px; margin-top: -16px;" >
             <span style="color:#50514F;">
           <asp:Label ID="Label5" runat="server" Text="Missions"></asp:Label>
           &nbsp;
            (<asp:Label ID="lbname" runat="server" Text="" style="margin-top:5px;"></asp:Label>
            )
            </span>
           </asp:Panel>
           
            
        </div>
                            </td>
                            </tr>
                            <tr>
                            <td>
                            <asp:Panel ID="PanleGrdNote" runat="server" Visible="false">
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"   OnPageIndexChanging="GridView1_PageIndexChanging" style="text-align:center; margin-left:8px;" >
                            <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                               <%# Container.DataItemIndex+1 %>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("pk_comment_id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Notes" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("comment_text") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Circle Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("circle_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                            </asp:Panel>
                               <asp:Panel ID="PanelGRdCircle" runat="server" Visible="false">
                                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"   OnPageIndexChanging="GridView2_PageIndexChanging" style="text-align:center;margin-left:8px;" >
                            <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                               <%# Container.DataItemIndex+1 %>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("pk_user_circle_id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Circle Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("circle_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Circle Permission" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("circle_permission") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Circle Image" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                 <div id="dvimagecircle" runat="server" class="thumb" >
                                                                 <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                            <asp:Image ID="Image1" runat="server" CssClass="avatar" ImageUrl='<%# "../User/CircleImages/" + Eval("circle_image") %>'  />
                            </div>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                            </asp:Panel>
                            
                             <asp:Panel ID="PanelGrdInsprator" runat="server" Visible="false">
                                 <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"   OnPageIndexChanging="GridView3_PageIndexChanging" style="text-align:center;margin-left:8px;" >
                            <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                               <%# Container.DataItemIndex+1 %>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("pk_Inspirator_id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Circle Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("circle_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Image" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                 <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../User/InspiratorImages/" + Eval("Inspirator_image") %>' style="height:150px; width:150px;" />
                            </ItemTemplate>
                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("Inspirator_desc") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                            </asp:Panel>
                               <asp:Panel ID="PanelGrdMission" runat="server" Visible="false">
                                 <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"   OnPageIndexChanging="GridView4_PageIndexChanging" style="text-align:center;margin-left:8px;" >
                            <Columns>
                            <asp:TemplateField HeaderText="S.No." HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                               <%# Container.DataItemIndex+1 %>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Pk_mission_id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Circle Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("circle_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Mission Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("mission_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mission Theme" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("mission_theme") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mission Type" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("mission_type") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                            </asp:Panel>
                            
                            </td>
                            </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </div>
                            </div>
                            </div>
</asp:Content>
