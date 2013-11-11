<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TicketMesssages.aspx.cs" Inherits="ALEREIMPACT.Admin.TicketMesssages" Title="Tickets" %>

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
                                      Feedback And Tickets
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
       <div id="breadcrumb" style="width: 955px !important;">
        
           <asp:LinkButton ID="lnkMsg" runat="server" onclick="lnkMsg_Click" style="color: #45B5B0 !important;">Feedback And Tickets</asp:LinkButton>
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;">
           <asp:Label  ID="lbname" runat="server" Text=" Tickets"></asp:Label>
            </span>
        </div>
      </td>
      </tr>
                        <tr>
      <td>
    
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                                   CssClass="table_data"   GridLines="None"  AllowPaging="true" 
                                    OnRowCommand="GridView1_RowCommand" 
                                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                                    onrowdatabound="GridView1_RowDataBound" style=" text-align:center; width: 963px; margin-left: 9px; margin-right: 16px;">
                                <Columns>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate> 
                                    <asp:Label ID="lbID" runat="server" Text='<%#Eval("T_ID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lbName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                </ItemTemplate>
                                
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ticket Number" HeaderStyle-Width="123" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate> 
                                    <asp:Label ID="lbNUmber" runat="server" Text='<%#Eval("T_ID") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Message" HeaderStyle-Width="550"  HeaderStyle-ForeColor="Black" >
                                <ItemTemplate> 
                                    <asp:Label ID="lbMSg" runat="server" Text='<%#Eval("T_MESSAGE") %>' style="width:100px;"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Size="10" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate> 
                                    <asp:Label ID="lbDAte" runat="server" Text='<%#Eval("T_DATE") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reply Status" HeaderStyle-ForeColor="Black" >
                                <ItemTemplate> 
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("T_REPLYSTATUS") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText=" ">
                                <ItemTemplate> 
                                          <asp:LinkButton ID="lnkReply" runat="server" Text="Reply" CommandName="lnkReply" style="color:#31A5A0;" CommandArgument='<%#Eval("T_ID")+","+Eval("fk_user_registration_id") %>'></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText=" ">
                                <ItemTemplate> 
                                          <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="lnkView" style="color:#31A5A0;" CommandArgument='<%#Eval("T_ID")+","+Eval("fk_user_registration_id") %>'></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                               
                                </Columns>
                                <EmptyDataTemplate>
                                No Record Found.....
                                </EmptyDataTemplate>
                                </asp:GridView>
                           
           <asp:LinkButton ID="dummy" runat="server" ></asp:LinkButton>
                            
                              <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="dummy" PopupControlID="divadd"
            runat="server" BackgroundCssClass="modalBackground" DropShadow="true" CancelControlID="Img2">
        </asp:ModalPopupExtender>
        <div id="divadd" runat="server" class="modalPopup" style="height: 260px;   width: 645px; display: none;">
         <asp:Panel ID="panel2" runat="server"  >
             <table width="637" style=" height: 265px;    margin-top: -9px;    width: 643px; background: none repeat scroll 0 0 #EAEAEA;" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td>
                        <img id="Img2" src="~/images/Close-icon.png" alt="cross" style="float: right; cursor:pointer; height: 20px;padding-right: 10px"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                <td>
                <span style=" float:left ; margin-left: 13px;   margin-top: -27px;">Ticket Number :</span>
                    <asp:Label ID="lbTicketN" runat="server" Text="" style="  float: left;       margin-left: 114px;
    margin-top: -28px;"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <span style=" float:left ; margin-left: 13px;   margin-top: -7px;">To :</span>
                    <asp:Label ID="lbEmail" runat="server" Text="" style="  float: left;        margin-left: 38px;
    margin-top: -7px;"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <span style="    float: left; margin-left: 11px;  margin-top: -23px;  padding-top: 7px;"> Reply :</span>
                    <asp:TextBox ID="txtREply" runat="server" TextMode="MultiLine" style="  float: left;  height:132px; margin-left: 63px;  margin-top: -29px; width: 466px;"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td>
                    <asp:Button ID="btn_Reply" runat="server" Text="Reply" 
                        onclick="btn_Reply_Click" style="  background: none repeat scroll 0 0 #222222 !important;
    border-radius: 5px 5px 5px 5px !important;    color: #FFFFFF;    margin-left: 125px; width: 77px; cursor:pointer; height: 31px;" />
                </td>
                </tr>
                </table>
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
</asp:Content>
