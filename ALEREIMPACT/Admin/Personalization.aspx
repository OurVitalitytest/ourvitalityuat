<%@ Page Title="User Personalization" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="Personalization.aspx.cs" Inherits="ALEREIMPACT.Admin.Personalization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">


        function showFileUpload(selBtnId) {
            var newFileUploadId = selBtnId.id.replace('lnkEdit', 'fupNewImage');
            var newSaveBtnId = selBtnId.id.replace('lnkEdit', 'imgUploadNew');
            var newCancelBtnId = selBtnId.id.replace('lnkEdit', 'imgCancel');


            document.getElementById(newFileUploadId).style.display = 'block';
            document.getElementById(newCancelBtnId).style.display = 'block';
            document.getElementById(newSaveBtnId).style.display = 'block';

            return false;
        }
        function hideFileUpload(selBtnId) {
            var newFileUploadId = selBtnId.id.replace('imgCancel', 'fupNewImage');
            var newSaveBtnId = selBtnId.id.replace('imgCancel', 'imgUploadNew');

            document.getElementById(selBtnId.id).style.display = 'none';
            document.getElementById(newFileUploadId).style.display = 'none';
            document.getElementById(newSaveBtnId).style.display = 'none';

            return false;
        }

    
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="main_grid">
        <div id="right_section">
            <table width="695" border="0" cellspacing="0" cellpadding="0" style="background: none;"
                class="table_bg">
                <tr>
                    <td class="heading_bg">
                        <div id="heading_table">
                            User Personalization
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 17px; padding-right: 17px;">
                        <table border="0" cellpadding="0" cellspacing="0" width="102%">
                            <tr>
                                <td>
                                    <asp:GridView ID="grdPersonalization" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" GridLines="None" CssClass="table_data" Style="text-align: center;"
                                        OnRowCommand="grdPersonalization_RowCommand" OnRowDataBound="grdPersonalization_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Type" HeaderStyle-ForeColor="#31A5A0">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("personalization_Type") %>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Images" HeaderStyle-ForeColor="#31A5A0">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgImage" runat="server" Width="50px" Height="50px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Replace Image" HeaderStyle-ForeColor="#31A5A0" HeaderStyle-Width="335px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" Style="color: #31A5A0; text-decoration: underline;"
                                                        OnClientClick="return showFileUpload(this);" CommandArgument='<%#Eval("pk_tblPersonalization_types_Images_Id") + "&" + Eval("fk_tblPersonalization_types_Id") %>'></asp:LinkButton>
                                                    <asp:FileUpload ID="fupNewImage" runat="server" Style="display: none;" />
                                                    <asp:ImageButton ID="imgUploadNew" runat="server" ImageUrl="~/images/tick_chk.png"
                                                        Style="display: none;margin-left:125px;" ToolTip="Click to save new Image" CommandName="EditImage" />
                                                    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/images/Close_1.png" 
                                                        OnClientClick="return hideFileUpload(this);"
                                                        Style="display: none;margin-top:-22px;margin-left:149px;" ToolTip="Click to close." />
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
        </div>
    </div>
</asp:Content>
