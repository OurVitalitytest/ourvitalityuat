<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="ALEREIMPACT.Admin.AdminPanel" Title=" Admin Panel" %>
 <%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %> 

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="../ckfinder/ckfinder/ckfinder.js"></script>
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
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
  <ContentTemplate>
   <table width="980" border="0" cellspacing="0" cellpadding="0" style="background:none;" class="table_bg">
      <tr>
        <td class="heading_bg"><div id="heading_table">User Management 
        </div></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>
              <table border="0" cellpadding="0" cellspacing="0" width="102%">
                    <tr>
                    <td style="width:51px;">
                     <span style="float:left;  padding-left: 18px; padding-top: 5px;  padding-right: 29px;">
                        Filter Search:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
                        <asp:ListItem Text="Filter By" Value="0"></asp:ListItem>
                        <asp:ListItem Text="By Status" Value="1"></asp:ListItem>
                        <asp:ListItem Text="By Location" Value="2"></asp:ListItem>
                        <asp:ListItem Text="By User Type" Value="3"></asp:ListItem>
                        <asp:ListItem Text="By Registration Type" Value="4"></asp:ListItem>
                         <asp:ListItem Text="By Name" Value="5"></asp:ListItem>
                          <asp:ListItem Text="By Email" Value="6"></asp:ListItem>
                           <asp:ListItem Text="By User Code" Value="7"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:51px;">
                    <div id="divLocation" style="display:none"   runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                        Select Location:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpLocation" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                            onselectedindexchanged="DrpLocation_SelectedIndexChanged">
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
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
                    <div id="divRegsType"  style="display:none"  runat="server" >
                     <span style=" float: left;  padding-left: 14px;  padding-right: 26px;  padding-top: 5px;"> 
                         Select Registration Type:</span>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DrpRegisType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="true" 
                            onselectedindexchanged="DrpRegisType_SelectedIndexChanged" >
                        <asp:ListItem Text="--Please Select--" Value="--Please Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                              <div id="divname"  style="display:none"  runat="server" >
                     <span style=" float: left;  padding-left: 1px;  padding-right: 10px;  padding-top: 5px;"> 
                                  Enter Name:</span>&nbsp;&nbsp;&nbsp;
                                  <asp:TextBox ID="txtname" runat="server" CssClass="box_dashboard" style="    height: 21px;    margin-top: -2px;"></asp:TextBox>
                    </div>
                       <div id="divUsercode"  style="display:none"  runat="server" >
                     <span style=" float: left;  padding-left: 1px;  padding-right: 10px;  padding-top: 5px;"> 
                                  Enter User Code:</span>&nbsp;&nbsp;&nbsp;
                                  <asp:TextBox ID="txtUserCode" runat="server" CssClass="box_dashboard" style="    height: 21px;    margin-top: -2px;"></asp:TextBox>
                    </div>
                     <div id="divEmail"  style="display:none"  runat="server" >
                     <span style=" float: left;  padding-left: 1px;  padding-right: 10px;  padding-top: 5px;"> 
                         Enter Email:</span>&nbsp;&nbsp;&nbsp;
                                  <asp:TextBox ID="txtemail" runat="server" CssClass="box_dashboard" style="  height: 21px;    margin-top: -2px;"></asp:TextBox>
                    </div>
                     <div id="divButton" style="display:none"   runat="server" >
                     <span style="  float: left; margin-top: -17px; padding-left: 10px; padding-right: 0; padding-top: 0;"> 
                         <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="dashborad_submit"  style=" cursor:pointer;    border-radius: 10px 10px 10px 10px;  height: 22px; margin-left: 5px; margin-top: 2px; padding-top: 0; width: 75px;"
                             onclick="btnsearch_Click" />
                                
                    </div>
                   
                    </td>
                    
                    
                    </tr>
                    
                   
                    </table>
        <div>
        
         <table border="0" cellpadding="0" cellspacing="0" width="102%">
                    <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  PageSize="50"
                            AllowPaging="true" GridLines="None"  CssClass="table_data" AllowSorting="true" 
                            onpageindexchanging="GridView1_PageIndexChanging" 
                            onrowdatabound="GridView1_RowDataBound" 
                            onrowcancelingedit="GridView1_RowCancelingEdit" 
                            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                            onrowcommand="GridView1_RowCommand" onsorting="GridView1_Sorting">
                            <Columns>
                            
                             <asp:TemplateField HeaderText="UserCode" SortExpression="user_code" HeaderStyle-ForeColor="#31A5A0 ">
                            <ItemTemplate>
                               <asp:Label ID="lbId" runat="server" Text='<%#Eval("pk_user_registration_Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("user_code_initial")+""+Eval("user_code") %>'></asp:Label>
                               <%-- <asp:Label ID="lbname" runat="server" Text='<%#Eval("user_code") %>'></asp:Label>--%>
                            </ItemTemplate>
                          
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Email"  HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:Label ID="lbemail" runat="server" Text='<%#Eval("login_email") %>' style="width:50px;"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                                   <asp:TemplateField HeaderText="User Type"  HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:Label ID="lbusertype" runat="server" Text='<%#Eval("user_type_role") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Registration Type"  HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:Label ID="lbregistrtype" runat="server" Text='<%#Eval("type_of_login") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Location" SortExpression="location_name"  HeaderStyle-ForeColor="#31A5A0">
                            <ItemTemplate>
                                <asp:Label ID="lblocation" runat="server" Text='<%#Eval("location_name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number of Circles"  HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCircle" runat="server" Text="" CommandName="circle" CommandArgument='<%#Eval("pk_user_registration_Id") %>' style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>
                      
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Number of Inspirator"  HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkInspirator" runat="server" Text="" CommandName="Inspirator" CommandArgument='<%#Eval("pk_user_registration_Id") %>' style="color:#31A5A0;text-decoration:underline;"></asp:LinkButton>
                            </ItemTemplate>
   
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Status"  HeaderStyle-ForeColor="Black">
                             <EditItemTemplate>
                                 <asp:DropDownList ID="drpstatuschange" runat="server" AppendDataBoundItems="true" style=" border: 1px outset; width: 100px;">
                                 </asp:DropDownList>
                             </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbstatus" runat="server" Text='<%#Eval("user_status") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Contact"  HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkContact" runat="server" Text="Contact" 
                                    CommandName="Contact" CommandArgument='<%#Eval("pk_user_registration_Id") %>' 
                                    style="color:#31A5A0;" ></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle  CssClass="link" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Options"  HeaderStyle-ForeColor="Black" >
                             <EditItemTemplate>
                              <asp:LinkButton ID="lnkupdate" runat="server" Text="Update" CommandName="update"  style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>
                                 /  
                               <asp:LinkButton ID="lnkcancel" runat="server" Text="Cancel" CommandName="cancel" style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>  
                             </EditItemTemplate>
                            <ItemTemplate>
                               <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="edit" style="color:#31A5A0; text-decoration:underline;"></asp:LinkButton>   
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
        </div>
     
          <asp:LinkButton ID="dummy1" runat="server"></asp:LinkButton>
          
        <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="dummy1" PopupControlID="divGrdEsc"
            runat="server" BackgroundCssClass="modalBackground" DropShadow="true" CancelControlID="Img2" >
        </asp:ModalPopupExtender>
        <div id="divGrdEsc" runat="server" class="modalPopup" style="height: 471px; width: 810px;  z-index:10001 !important; display: none; background: none repeat scroll 0 0 #EAEAEA;">
         <asp:Panel ID="panel1" runat="server">
            <table width="800" border="0" align="center" style="height:448px;  background: none repeat scroll 0 0 #EAEAEA;" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td>
                        <img id="Img2" src="~/images/Close-icon.png" alt="cross" style="float: right; height:20px; padding-right: 10px"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    Email:  &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lbemail" runat="server" Text=""></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td>
                   
               <CKEditor:CKEditorControl ID="CKEditor1" BasePath="~/ckeditor/" runat="server" Style=" height: 400px; margin-left: 62px; margin-top: 27px; width: 617px;"></CKEditor:CKEditorControl>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Message" ValidationGroup="a" ControlToValidate="CKEditor1"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Send"  CssClass="btn_save" style="   background: none repeat scroll 0 0 #222222 !important;    border-radius: 5px 5px 5px 5px !important;    color: #FFFFFF;        margin-left: 323px;    margin-top: 8px;" onclick="Button1_Click" ValidationGroup="a" />
    </div>
    <div>
        <asp:label runat="server" ID="lblText"></asp:label>
    </div>
    <div>
        <asp:label runat="server" ID="lbl2"></asp:label>
    </div>
                    </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    </div>
                    
        
        </td></tr>
        </table>
    
      
  </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="Button1" />
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
      </div>
     
 </div>
</asp:Content>
