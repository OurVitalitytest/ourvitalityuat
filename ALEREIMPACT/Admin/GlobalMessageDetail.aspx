<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GlobalMessageDetail.aspx.cs" Inherits="ALEREIMPACT.Admin.GlobalMessageDetail" Title="Message Detail" %>

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
                                        Messages Detail
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
                            <div style="float:left; height: 500px;    overflow: scroll;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                                    CssClass="table-data" ShowHeader="false" GridLines="None" 
                                    onrowcommand="GridView1_RowCommand">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("GM_ID") %>' Visible="false" ></asp:Label>
                                    <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="lnkMessage" CommandArgument='<%#Eval("GM_ID") %>' 
                                        style="float:left; height: 16px; color: #151515;">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("GM_MESSAGE") %>'></asp:Label>
                                    &nbsp;
                                      <asp:Label ID="Label3" runat="server" Text='<%#Eval("GM_DATE") %>'></asp:Label>
                                    </asp:LinkButton>
                                    
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </div>
                          
                            <div style="float:left; ">
                            <asp:Panel ID="PanelReply" runat="server" Visible="false" style="float:left; text-align:center;">
                             <asp:Label ID="Label8" runat="server" Text="Please select a message to see message detail" style="color: #8E8E8E; padding-left: 160px; font-size: 14px; font-weight: bold;"></asp:Label>
                            </asp:Panel>
                            <asp:Panel ID="Panel1" runat="server" Visible="false" style=" width: 701px; ">
                            <div style="border: 1px solid #BBBBBB; margin-left: 17px;color: #151515;   line-height: 15px;  margin-bottom: 19px;padding: 3px 2px 5px 8px;">
                                <asp:Label ID="lbmsg" runat="server" Text=""></asp:Label>
                              
                                </div>
                                <div style=" margin-left: 17px;  height:400px;     margin-bottom: 19px; overflow:scroll; overflow-x:hidden;">
                                  <asp:Label ID="lbreply" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Repeater ID="Repeater1" runat="server"    >
                                <HeaderTemplate>
                                 <table class="table-data"  width="100%" cellpadding="0" cellspacing="0" style=" line-height: 15px;  color: #151515;">
                                 <tr>
                                 <th>
                                                                   <asp:Label ID="Label4" runat="server" Text="Name" style="float:left; width: 62px;"></asp:Label>
                                 </th>
                                 <th style="width: 324px;">
                                                             <asp:Label ID="Label5" runat="server" Text="Reply" style="float:left; width:319px;"></asp:Label>   &nbsp;
                                 </th>
                                 <th>
                                                         <asp:Label ID="Label6" runat="server" Text="Date" style="float:left; width: 46px;"></asp:Label>   &nbsp;
                                 </th>
                                 </tr>
                                 </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                <table class="table-data"  width="100%" cellpadding="0" cellspacing="0" style=" line-height: 15px;  color: #151515;">
                                
                                <tr style="line-height:15px;">
                                <td >
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("name") %>' style="float:left; width:80px;"></asp:Label>
                                </td>
                                <td style="width:314px;">
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("GMR_MESSAGE") %>' style="float:left; width:300px;"></asp:Label>   &nbsp;
                                </td>
                                <td >
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("GMR_DATE") %>' style="float:left; width:60px;"></asp:Label>   &nbsp;
                                </td>
                                </tr>
                                </table>
                                </ItemTemplate>
                                </asp:Repeater>
                                </div>
                                </asp:Panel>
                            </div>
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
