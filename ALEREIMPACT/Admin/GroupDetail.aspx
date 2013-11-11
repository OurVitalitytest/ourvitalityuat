<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GroupDetail.aspx.cs" Inherits="ALEREIMPACT.Admin.GroupDetail" Title="Group Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .link
    {
    	text-align:center;
    	text-decoration: underline;
    	color:Blue;
    	
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
     <div id="main_grid">

  <div id="right_section">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
  <ContentTemplate>
   <table width="695" border="0" cellspacing="0" cellpadding="0" style="background:none;" class="table_bg">
      <tr>
        <td class="heading_bg"><div id="heading_table">Group Management <asp:LinkButton ID="lnkAdd" runat="server" Text="Add New Group" 
                style="padding-left:682px; color:#31A5A0; font-size: 14px; text-decoration: underline;" 
                onclick="lnkAdd_Click"></asp:LinkButton>  </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
      <td style="  padding-left: 17px; padding-right: 17px;">
      <table border="0" cellpadding="0" cellspacing="0" width="102%">
                    <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="20"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  AllowSorting="true"
                            onpageindexchanging="GridView1_PageIndexChanging" style="text-align:center;"
                            onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound">
                            <Columns>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbid" runat="server" Text='<%#Eval("GROUP_ID") %>' Visible="false"></asp:Label>
                                 <asp:Label ID="lbname" runat="server" Text='<%#Eval("GROUP_NAME") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number Of Members" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbMembers" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Update" CommandName="lnkedit" CommandArgument='<%#Eval("GROUP_ID") %>' style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                                 <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEmail" runat="server" Text="Email to Group" CommandName="lnkemail" CommandArgument='<%#Eval("GROUP_ID") %>' style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkComment" runat="server" Text="Post Comment" CommandName="lnkcomment" CommandArgument='<%#Eval("GROUP_ID") %>' style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
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
      <asp:LinkButton ID="Dummy" runat="server"></asp:LinkButton>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="Dummy" PopupControlID="divadd"
            runat="server" BackgroundCssClass="modalBackground" DropShadow="true" CancelControlID="Img2">
        </asp:ModalPopupExtender>
        <div id="divadd" runat="server" class="modalPopup" style="height: 260px; width: 637px; display: none">
         <asp:Panel ID="panel1" runat="server"  >
            <table width="637" style="height:260px; margin-top: -9px;  background: none repeat scroll 0 0 #EAEAEA;" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr >
                    <td style="height:50px;">
                        <img id="Img2" src="~/images/Close-icon.png" alt="cross" style="float: right;height: 20px; margin-top: -12px; padding-right: 10px"
                            runat="server" />
                 
              <span style="float: left;    font-size: 20px;    font-weight: bold;        margin-left: 148px;"> Post Comment to "  <asp:Label ID="lbGroup" runat="server" Text="" style="font-size:20px;"></asp:Label>&nbsp;Group "</span> 
                </td>
                 
                </tr>
                
                <tr >
                    <td style="height:200px;">
               <span style=" float: left;    margin-top: -57px;    padding-left: 49px;"> Post Comment : </span> &nbsp; &nbsp; &nbsp; &nbsp;
               
               
                        <asp:TextBox ID="txtComment" runat="server" CssClass="box_dashboard" MaxLength="300" style=" float: left; margin-left: 146px;  margin-top: -59px; width: 315px;border: 1px solid #000000 !important;"></asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorAppForm" runat="server" CssClass="error" style=" float: left;    margin-left: 159px;    margin-top: -17px;" ErrorMessage="Enter Comment " Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="a"></asp:RequiredFieldValidator>
                         
                        <asp:Button ID="btnadd" runat="server" Text="Comment" CssClass="btn_save"  ValidationGroup="a"
                            onclick="btnadd_Click" style=" background: none repeat scroll 0 0 #31A5A0 !important;
    border-radius: 5px 5px 5px 5px !important;    color: #FFFFFF; float: right !important;
    margin-right: 66px !important;
    margin-top: -56px; " />
                    </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    </div>
      
      </ContentTemplate>
      <Triggers>
    </Triggers>
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
