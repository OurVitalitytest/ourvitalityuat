<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserReportedErrorLog.aspx.cs" Inherits="ALEREIMPACT.Admin.UserReportedErrorLog" Title="Error Log" %>

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
                                        Error Log
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
        
            <asp:LinkButton ID="lnkError" runat="server" onclick="lnkError_Click" style="color: #45B5B0 !important;">Error Log</asp:LinkButton> 
            <img src="../images/arow.jpg" width="13" height="12" alt="" border="0" />
            <span style="color:#50514F;"><asp:Label ID="lbname" runat="server" Text=" User Reported Errors"></asp:Label>
            </span>
        </div>
      </td>
      </tr>
      
      <tr>
      <td>
      <div style="float:left; height: 500px;    overflow: scroll; margin-left:5px;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                                    CssClass="table-data" ShowHeader="false" GridLines="None" 
                                    OnRowCommand="GridView1_RowCommand" 
                                    onrowdatabound="GridView1_RowDataBound">
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate> 
                                <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="lnkMessage" CommandArgument='<%#Eval("ER_ID") %>' 
                                        style="float:left; height: 35px; color: #151515;">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ER_ID") %>' Visible="false"></asp:Label>
                                     <asp:Label ID="Label2" runat="server" Text='<%#Eval("name") %>' style="font-size: 17px; text-transform:capitalize;" ></asp:Label>
                                     <br />
                                     
                                      <asp:Label ID="Label3" runat="server" Text='<%#Eval("ER_MESSAGE") %>' style="margin-right:5px;"></asp:Label>
                                  
                                       <asp:Label ID="Label4" runat="server" Text='<%#Eval("ER_POST_DATE") %>'></asp:Label>
                                       </asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Found.....
                                </EmptyDataTemplate>
                                </asp:GridView>
                                </div>
        <div style="float:left; ">
                            <asp:Panel ID="PanelReply" runat="server" Visible="false" style="float:left; text-align:center;">
                             <asp:Label ID="Label8" runat="server" Text="Please select a message to see message detail" style="color: #8E8E8E; padding-left: 160px; font-size: 14px; font-weight: bold;"></asp:Label>
                            </asp:Panel>
                            <asp:Panel ID="Panel1" runat="server" Visible="false" style=" width: 701px; ">
                             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" 
                                    CssClass="table-data" ShowHeader="false" GridLines="None" 
                                    OnRowCommand="GridView2_RowCommand" 
                                    onrowdatabound="GridView2_RowDataBound" >
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                  <div style="float:left;   width: 685px;   margin-left: 5px;    margin-top: 5px;">
                                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("ER_ID") %>' Visible="false"></asp:Label>
                                  <asp:Label ID="Label2" runat="server" Text='<%#Eval("name") %>' style="font-size: 17px; text-transform:capitalize; " ></asp:Label>
                                      &nbsp;
                                  <asp:Label ID="Label9" runat="server" Text='<%#Eval("ER_POST_DATE") %>' style=" float: right; margin-right: 11px; " ></asp:Label>
                                    </div>
                                    <br />
                                     <div style="float:left;margin-left: 5px;    margin-top: 5px;">
                                    <asp:Label ID="Label5" runat="server" Text="Page Name : " style="float:left; font-size: 17px;"></asp:Label> 
                                         &nbsp;
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("PAGE_NAME") %>' style="font-size: 14px; text-transform:capitalize;" ></asp:Label>
                                </div>
                                 <br />
                                  <div style="float:left;margin-bottom: 33px; margin-left: 5px; margin-top: 5px;">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("ER_MESSAGE") %>' ></asp:Label>
                        </div>
                         <br />
                          <div id="DivImage"  runat="server" style="float:left;">
                             <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="lnkImage" CommandArgument='<%#Eval("ER_ID") %>' 
                                        style="float:left; height: 137px; color: #151515;">
                                 <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ER_IMAGE") %>' />
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#"/AlereImpactNew/User/ReportErrorImages/" + Eval("ER_IMAGE") %>' style="height:100px; width:100px;" />
                                    <br />
                                    <span style="float:left;">Click on image to view enlarge</span>
                                  </asp:LinkButton>
                                   </div> 
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                            </asp:Panel>
            <asp:LinkButton ID="dummy" runat="server" ></asp:LinkButton>
                            
                              <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="dummy" PopupControlID="divadd"
            runat="server" BackgroundCssClass="modalBackground" DropShadow="true" CancelControlID="Img2">
        </asp:ModalPopupExtender>
        <div id="divadd" runat="server" class="modalPopup" style="height: 500px;  width: 750px; display: none;">
         <asp:Panel ID="panel2" runat="server"  >
            <table width="637" style="height:500px; margin-top: -9px; width:750px;  background: none repeat scroll 0 0 #EAEAEA;" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td>
                        <img id="Img2" src="~/images/Close-icon.png" alt="cross" style="float: right; cursor:pointer; height: 20px;padding-right: 10px"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                <td>
                    <asp:Image ID="Image2" runat="server" style=" height: 450px; margin-left: 8px; width: 740px;" />
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
