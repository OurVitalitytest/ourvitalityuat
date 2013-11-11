<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserInvitation.aspx.cs" Inherits="ALEREIMPACT.Admin.UserInvitation" Title="User Invitation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .link
    {
    	text-align:center;
    	text-decoration: underline;
    	color:#58B1AE;
    	
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
                                        User Invitations
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
      <div style="float:left;">
      <span style="float:left; font-size:13px; margin-left: 27px;  margin-top: 11px;">Invitation Send To :</span>
          <asp:TextBox ID="txtEmail" runat="server" CssClass="box_dashboard" style="    height: 20px;    width: 232px;"></asp:TextBox>
         
          <asp:Button ID="btn_send" runat="server" Text="Send" ValidationGroup="a"  style="  height: 29px; margin-left: 16px; cursor:pointer; padding-top: 3px; width: 60px;"
              CssClass="dashborad_submit" onclick="btn_send_Click" />
              <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Email" style="float: left; margin-left: 176px; font-size:12px; margin-top: 5px;" ValidationGroup="a"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                                    CssClass="error" Style=" color: red;  font-family: arial;
    font-size: 12px; margin-left: 166px;  margin-top: 5px;  width: 177px;" ValidationGroup="a"
                                    Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ErrorMessage="Enter valid email"></asp:RegularExpressionValidator>
                
                
                
      </div>
      </td>
      </tr>
      <tr>
      <td>
      
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="50"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  style="text-align:center;  margin-left: 11px;" onpageindexchanging="GridView1_PageIndexChanging" 
              onrowcommand="GridView1_RowCommand" 
              onrowdatabound="GridView1_RowDataBound">
                            <Columns>
                            <asp:TemplateField HeaderText="Invited User's Email" HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:Label ID="lbId" runat="server" Text='<%#Eval("UI_ID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbMAil" runat="server" Text='<%#Eval("UI_USER_MAIL_ID") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invitation Date" HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                            <asp:Label ID="lbDAte" runat="server" Text='<%#Eval("UI_DATE") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mail Status" HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                            <asp:Label ID="lbMAilStatus" runat="server" Text='<%#Eval("UI_MAIL_STATUS") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invitation Status" HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                            <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkResend" runat="server" Text="Resend" CommandName="lnkResend" style="color:#31A5A0;" CommandArgument='<%#Eval("UI_ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                             <%--<ItemStyle  CssClass="link" />--%>
                            </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                            No Record Found....
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
</asp:Content>
