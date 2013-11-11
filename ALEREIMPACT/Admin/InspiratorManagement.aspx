<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InspiratorManagement.aspx.cs" Inherits="ALEREIMPACT.Admin.InspiratorManagement" Title="Inspirator Management" %>

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
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
   <table  border="0" cellspacing="0" cellpadding="0" style="background:none;" class="table_bg">
      <tr>
        <td class="heading_bg"><div id="heading_table">Inspirator Management
        <asp:LinkButton ID="lnkAdd" runat="server" Text="Add New Inspirator" 
                style="padding-left:632px; color:#31A5A0; font-size: 14px; text-decoration: underline;" 
                onclick="lnkAdd_Click"></asp:LinkButton> 
         </div></td>

      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
      <td>
      <table border="0" cellpadding="0" cellspacing="0" style="width:980px;">
                    <tr>
                    <td style="width:51px;">
                     <span style="float:left;  padding-left: 18px; padding-top: 5px;  padding-right: 29px;">
                        Filter Search:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                        <asp:ListItem Text="Filter By" Value="0"></asp:ListItem>
                        <asp:ListItem Text="By Status" Value="1"></asp:ListItem>
                        <asp:ListItem Text="By User Type" Value="2"></asp:ListItem>
                          <asp:ListItem Text="By Circle Type" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:51px;">
                     <div id="divStatus" style="display:none"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Status:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpStatus" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true"  
                             onselectedindexchanged="DrpStatus_SelectedIndexChanged">
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div id="divUserType"  style="display:none;"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select User Type:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpUserType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                             onselectedindexchanged="DrpUserType_SelectedIndexChanged" >
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="divCircle" style="display:none;"    runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Circle Type:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpCircleType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                             onselectedindexchanged="DrpCircleType_SelectedIndexChanged" >
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    </td>
                    </tr>
                    </table>
      </td>
      </tr>
      <tr>
        <td>
              
        <div style="width:980px;">
        
        
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="10"
                            AllowPaging="true" GridLines="None"  CssClass="table_data"  AllowSorting="true"
                            onpageindexchanging="GridView1_PageIndexChanging" 
                            onrowcommand="GridView1_RowCommand" 
                            onrowdatabound="GridView1_RowDataBound" onsorting="GridView1_Sorting" 
                            onrowcancelingedit="GridView1_RowCancelingEdit" 
                            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                            onrowupdating="GridView1_RowUpdating" style="width:980px;">
                            <Columns>
                            
                             <asp:TemplateField HeaderText="User Code" SortExpression="usercode" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                               <asp:Label ID="lbId" runat="server" Text='<%#Eval("fk_user_registration_Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbIId" runat="server" Text='<%#Eval("pk_Inspirator_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbname" runat="server" Text='<%#Eval("usercode") %>'></asp:Label>
                               <%-- &nbsp;
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("last_name") %>'></asp:Label>--%>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Image" HeaderStyle-ForeColor="#000" >
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Inspirator_image") %>' /> 
                                <asp:Image ID="Image1" runat="server" style="width:100px; height:100px;" />
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Text" HeaderStyle-ForeColor="#000" HeaderStyle-Width="350">
                            <ItemTemplate>
                                <asp:Label ID="lbtext" runat="server" Text='<%#Eval("Inspirator_desc") %>' style="width:40px;"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText=" User Type" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbusertype" runat="server" Text='<%#Eval("user_type_role") %>' style="width:40px;"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText=" Circle Type" HeaderStyle-ForeColor="#000">
                            <ItemTemplate>
                                <asp:Label ID="lbcircletype" runat="server" Text='<%#Eval("circle_name") %>' style="width:40px;"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number of Likes" SortExpression="noofollike" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnklike" runat="server" Text='<%#Eval("noofollike") %>' CommandName="like"   CommandArgument='<%#Eval("pk_Inspirator_id")+";"+Eval("fk_user_registration_Id") %>'  style="color:#31A5A0; text-decoration:underline; "></asp:LinkButton>
                            </ItemTemplate>
                           
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number of Comments" SortExpression="noofcomments" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkComments" runat="server" Text='<%#Eval("noofcomments") %>' CommandName="comments"  CommandArgument='<%#Eval("pk_Inspirator_id")+";"+Eval("fk_user_registration_Id") %>' style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>

                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number of Inappropriate" SortExpression="noofinappropriate" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkInappropriate" runat="server" Text='<%#Eval("noofinappropriate") %>' CommandName="Inappropriate" CommandArgument='<%#Eval("pk_Inspirator_id") +";"+Eval("fk_user_registration_Id")%>' style="color:#31A5A0;text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>
 
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Library" SortExpression="noofLibrary" HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnklibrary" runat="server" Text='<%#Eval("noofLibrary") %>' CommandName="Library" CommandArgument='<%#Eval("pk_Inspirator_id")+";"+Eval("fk_user_registration_Id") %>' style="color:#31A5A0;text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>
       
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="#000">
                             <EditItemTemplate>
                                 <asp:DropDownList ID="drpstatuschange" runat="server" AppendDataBoundItems="true" style=" border: 1px outset; width: 100px;">
                                 </asp:DropDownList>
                             </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbstatus" runat="server" Text='<%#Eval("user_status") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="" >
                             <EditItemTemplate>
                              <asp:LinkButton ID="lnkupdate" runat="server" Text="Update" CommandName="update"  style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
                                 /  
                               <asp:LinkButton ID="lnkcancel" runat="server" Text="Cancel" CommandName="cancel" style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>  
                             </EditItemTemplate>
                            <ItemTemplate>
                               <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="edit" style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton> 
                                /
                               <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="delete" OnClientClick="return confirm('Are you sure want to delete this inspirator?')" style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton> 
                                 
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Record Found....
                            </EmptyDataTemplate>
                        </asp:GridView>
                  
               
        </div>
        
        
        
        </td></tr>
        </table>
     <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="lnkAdd" PopupControlID="divadd"
            runat="server" BackgroundCssClass="modalBackground" DropShadow="true" CancelControlID="Img2">
        </asp:ModalPopupExtender>
        <div id="divadd" runat="server" class="modalPopup" style="height: 260px; width: 637px; display: none;">
         <asp:Panel ID="panel1" runat="server"  >
            <table width="637" style="height:260px; margin-top: -9px;  background: none repeat scroll 0 0 #EAEAEA;" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td>
                        <img id="Img2" src="~/images/Close-icon.png" alt="cross" style="float: right; height: 20px;padding-right: 10px"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                <td align="center" style="margin-top:5px; font-weight:bold; font-size:20px;">
                Add New Inspirator
                </td>
                </tr>
                <tr>
                    <td style="padding-left:133px;">
               <span style=" padding-left: 5px; padding-top: 16px; font-size:13px;"> Image : </span> &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                       
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorAppForm" runat="server" CssClass="error"
                                    ErrorMessage="Select File " Display="Dynamic" ControlToValidate="FileUpload1" ValidationGroup="a"></asp:RequiredFieldValidator>
                         
                    </td>
                    </tr>
                    <tr>
                    <td >
                  <span style="   font-size: 13px; margin-left: 139px; float:left; ">  Description:</span>  &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:TextBox ID="txtdesc" runat="server" CssClass="input" MaxLength="300" style=" float: left;    border: 1px solid; height: 24px; margin-right: 176px;  margin-top: -8px; padding-right: 58px;"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="error" style=" margin-right: 111px;   float:right;  margin-top: -23px;"   ErrorMessage="Enter Description" Display="Dynamic" ControlToValidate="txtdesc" ValidationGroup="a"></asp:RequiredFieldValidator> 
                    </td>
                    </tr>
                    <tr>
                    <td style="padding-left:140px;">
                        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn_save"  ValidationGroup="a"
                            onclick="btnadd_Click" style="  background: none repeat scroll 0 0 #222222 !important;
    border-radius: 5px 5px 5px 5px !important;    color: #FFFFFF;    margin-left: 125px" />
                    </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    </div>
      
    </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="lnkAdd" />
        <asp:PostBackTrigger ControlID="btnadd" />
        <asp:PostBackTrigger ControlID="DropDownList1" />
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
