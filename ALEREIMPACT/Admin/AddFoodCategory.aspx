<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="AddFoodCategory.aspx.cs" Inherits="ALEREIMPACT.Admin.AddFoodCategory" Title="Add Food Categories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
    function txtrep() {
        
    var newtext = "Processing...";
   
    if(document.getElementById('<%= txtCatName.ClientID %>').value !='' && document.getElementById('<%= fuCategory.ClientID %>').value !='')
{
 document.getElementById('<%= btn_catCreate.ClientID %>').value = newtext;
}
}
    </script>

    <script type="text/javascript">
    function txtrep1() {
        
    var newtext = "Processing...";
    document.getElementById('<%= btn_Subcat1Create.ClientID %>').value = newtext;
}
    </script>

    <script type="text/javascript">
    function txtrep2() {
        
    var newtext = "Processing...";
    document.getElementById('<%= btn_Subcat2Create.ClientID %>').value = newtext;
}
    </script>

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
                                    Add Food Categories</div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-left: 14px; width: 300px; height: 280px; border-right: 1px solid;">
                                    <span style="color: #31A5A0; float: left; font-size: 13px; margin-left: 81px;">Parent
                                        Category</span>
                                    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 31px;">
                                        <tr>
                                            <td>
                                                <span style="float: left;">Name</span><span style="color: Red; float: left;">*</span>
                                                <asp:TextBox ID="txtCatName" runat="server" Style="float: left; margin-left: 36px;"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Name"
                                                    Style="margin-left: 73px;" ValidationGroup="a" Display="Dynamic" ControlToValidate="txtCatName"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 19px;">Description</span>
                                                <asp:TextBox ID="txtCatDesc" runat="server" TextMode="MultiLine" Style="float: left;
                                                    margin-left: 7px; margin-top: 7px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 19px;">Image</span><span style="color: Red;
                                                    float: left; margin-top: 19px;">*</span>
                                                <asp:FileUpload ID="fuCategory" runat="server" Style="margin-left: 29px; margin-top: 17px;" />
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Image"
                                                    Style="margin-left: 67px;" Display="Dynamic" ValidationGroup="a" ControlToValidate="fuCategory"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_catCreate" runat="server" Text="Create" OnClientClick="txtrep()"
                                                    ValidationGroup="a" Style="background-color: #31A5A0; border-radius: 15px 15px 15px 15px;
                                                    color: #FFFFFF; float: left; height: 31px; margin-left: 82px; margin-top: 56px;
                                                    width: 70px; cursor: pointer;" OnClick="btn_catCreate_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="float: left; margin-left: 14px; width: 300px; height: 280px; border-right: 1px solid;">
                                    <span style="color: #31A5A0; float: left; font-size: 13px; margin-left: 85px;">Parent
                                        Subcategory</span>
                                    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 31px;">
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 5px;">Category</span><span style="color: Red;
                                                    float: left; margin-top: 5px;">*</span>
                                                <asp:DropDownList ID="drpCategory" runat="server" Style="float: left; height: 31px;
                                                    margin-left: 21px; width: 184px;" AppendDataBoundItems="true">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Category"
                                                    Display="Dynamic" Style="margin-left: 75px;" ValidationGroup="b" InitialValue="0"
                                                    ControlToValidate="drpCategory"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 7px;">Name</span><span style="color: Red; float: left;
                                                    margin-top: 7px;">*</span>
                                                <asp:TextBox ID="txtSubcat1Name" runat="server" Style="float: left; margin-top: 8px;
                                                    margin-left: 39px;"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Name"
                                                    Display="Dynamic" Style="margin-left: 73px;" ValidationGroup="b" ControlToValidate="txtSubcat1Name"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 19px;">Description</span>
                                                <asp:TextBox ID="txtSubcat1Desc" runat="server" TextMode="MultiLine" Style="float: left;
                                                    margin-left: 11px; margin-top: 7px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 19px;">Image</span><span style="color: Red;
                                                    float: left; margin-top: 19px;">*</span>
                                                <asp:FileUpload ID="fuSubcat1" runat="server" Style="margin-left: 35px; margin-top: 15px;" />
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Image"
                                                    Display="Dynamic" Style="margin-left: 71px;" ValidationGroup="b" ControlToValidate="fuSubcat1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_Subcat1Create" runat="server" Text="Create" OnClientClick="txtrep1()"
                                                    ValidationGroup="b" Style="background-color: #31A5A0; border-radius: 15px 15px 15px 15px;
                                                    color: #FFFFFF; float: left; height: 31px; margin-left: 92px; margin-top: 22px;
                                                    width: 70px; cursor: pointer;" OnClick="btn_Subcat1Create_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="float: left; margin-left: 14px; width: 300px; height: 280px;">
                                    <span style="color: #31A5A0; float: left; font-size: 13px; margin-left: 93px;">Subcategory</span>
                                    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 31px;">
                                        <tr>
                                            <td>
                                                <span style="float: left;">Parent Subcategory</span><span style="color: Red; float: left;">*</span>
                                                <asp:DropDownList ID="drpSubcat" runat="server" Style="float: left; margin-left: 11px;
                                                    width: 169px;" AppendDataBoundItems="true">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select Parent Subcategory"
                                                    Style="margin-left: 122px;" Display="Dynamic" ValidationGroup="c" InitialValue="0"
                                                    ControlToValidate="drpSubcat"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 7px;">Name</span><span style="color: Red; float: left;
                                                    margin-top: 7px;">*</span>
                                                <asp:TextBox ID="txtSubcat2Name" runat="server" Style="float: left; margin-top: 9px;
                                                    margin-left: 40px;"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Name"
                                                    Display="Dynamic" Style="margin-left: 78px;" ValidationGroup="c" ControlToValidate="txtSubcat2Name"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 19px;">Description</span>
                                                <asp:TextBox ID="txtSubcat2Desc" runat="server" TextMode="MultiLine" Style="float: left;
                                                    margin-left: 13px; margin-top: 7px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="float: left; margin-top: 19px;">Image</span><span style="color: Red;
                                                    float: left; margin-top: 19px;">*</span>
                                                <asp:FileUpload ID="fuSubcat2" runat="server" Style="margin-left: 39px; margin-top: 17px;" />
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Select Image"
                                                    Display="Dynamic" Style="margin-left: 78px;" ValidationGroup="c" ControlToValidate="fuSubcat2"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_Subcat2Create" runat="server" Text="Create" OnClientClick="txtrep2()"
                                                    ValidationGroup="c" Style="background-color: #31A5A0; border-radius: 15px 15px 15px 15px;
                                                    color: #FFFFFF; float: left; height: 31px; margin-left: 100px; margin-top: 22px;
                                                    width: 70px; cursor: pointer;" OnClick="btn_Subcat2Create_Click" />
                                            </td>
                                        </tr>
                                    </table>
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
                                <div style="border: 1px solid #DBDBDB; background-color: #FFFFFF; float: left; margin-left: 5px;
                                    width: 300px; overflow: scroll; height: 430px; overflow-x: hidden;">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                                        CssClass="table_data" OnRowDataBound="GridView1_RowDataBound" ShowHeader="false"
                                        OnRowCommand="GridView1_RowCommand" Style="height: auto; text-align: center;
                                        margin-left: 5px; margin-top: 5px;" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbID1" runat="server" Text='<%#Eval("CAT_ID") %>' Visible="false"></asp:Label>
                                                    <asp:Image ID="Image2" runat="server" Style="width: 30px; height: 45px; float: left;"
                                                        ImageUrl='<%#"/AlereImpactNew/User/FoodCategoryImages/"+Eval("CAT_IMAGE") %>' />
                                                    <asp:TextBox ID="textname" runat="server" Text='<%#Eval("CAT_NAME") %>'></asp:TextBox>
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                                        CommandName="update" CommandArgument='<%#Eval("CAT_ID") %>' Style="float: right;" />
                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Cancel" ImageUrl="~/images/Actions-file-close-icon.png"
                                                        CommandArgument='<%#Eval("CAT_ID") %>' Style="float: right;" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbID" runat="server" Text='<%#Eval("CAT_ID") %>' Visible="false"></asp:Label>
                                                    <asp:LinkButton ID="lnk" runat="server" CommandName="Lnk" CommandArgument='<%#Eval("CAT_ID") %>'
                                                        Style="float: left; margin-left: 29px;">
                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("CAT_IMAGE") %>' />
                                                        <asp:Image ID="Image1" runat="server" Style="width: 30px; height: 45px;" />
                                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("CAT_NAME") %>'></asp:Label>
                                                    </asp:LinkButton>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Pencil-icon.png"
                                                        CommandName="Edit" CommandArgument='<%#Eval("CAT_ID") %>' Style="float: right;" />
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Actions-file-close-icon.png"
                                                        CommandName="Delete" CommandArgument='<%#Eval("CAT_ID") %>' Style="float: right;"
                                                        OnClientClick="return confirm('Are you sure you want to delete ?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="" Visible="false" Style="color: red;"></asp:Label>
                                </div>
                                <div style="border: 1px solid #DBDBDB; background-color: #FFFFFF; float: left; margin-left: 13px;
                                    width: 300px; overflow: scroll; height: 430px; overflow-x: hidden;">
                                    <asp:Label ID="Label4" runat="server" Text=" Select Food Category to see Parent Food Subcategory list."
                                        Style="border: 1px solid #DBDBDB; color: #A7A7A7; float: left; height: 60px;
                                        width: 269px; margin-left: 8px; margin-top: 5px;" Visible="false"></asp:Label>
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" GridLines="None"
                                        CssClass="table_data" OnRowDataBound="GridView2_RowDataBound" ShowHeader="false"
                                        OnRowCommand="GridView2_RowCommand" Style="margin-left: 4px; text-align: center;
                                        margin-top: 5px; height: auto;" OnRowCancelingEdit="GridView2_RowCancelingEdit"
                                        OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbID1" runat="server" Text='<%#Eval("SUBCAT1_ID") %>' Visible="false"></asp:Label>
                                                    <asp:Image ID="Image2" runat="server" Style="width: 30px; height: 45px; float: left;"
                                                        ImageUrl='<%#"/AlereImpactNew/User/FoodCategoryImages/"+Eval("SUBCAT1_IMAGE") %>' />
                                                    <asp:TextBox ID="textname" runat="server" Text='<%#Eval("SUBCAT1_NAME") %>'></asp:TextBox>
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                                        CommandName="Update" CommandArgument='<%#Eval("SUBCAT1_ID") %>' Style="float: right;" />
                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Cancel" ImageUrl="~/images/Actions-file-close-icon.png"
                                                        CommandArgument='<%#Eval("SUBCAT1_ID") %>' Style="float: right;" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbID" runat="server" Text='<%#Eval("SUBCAT1_ID") %>' Visible="false"></asp:Label>
                                                    <asp:LinkButton ID="lnk" runat="server" CommandName="Lnk" CommandArgument='<%#Eval("SUBCAT1_ID") %>'
                                                        Style="float: left; margin-left: 29px;">
                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("SUBCAT1_IMAGE") %>' />
                                                        <asp:Image ID="Image1" runat="server" Style="width: 30px; height: 45px;" />
                                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("SUBCAT1_NAME") %>'></asp:Label>
                                                    </asp:LinkButton>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Pencil-icon.png"
                                                        CommandName="Edit" CommandArgument='<%#Eval("SUBCAT1_ID") %>' Style="float: right;" />
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Actions-file-close-icon.png"
                                                        CommandName="Delete" CommandArgument='<%#Eval("SUBCAT1_ID") %>' OnClientClick="return confirm('Are you sure you want to delete ?');"
                                                        Style="float: right;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Select Food Category to see Parent Food Subcategory list.
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lbPSubcat" runat="server" Text="" Style="color: Red;" Visible="false"></asp:Label>
                                </div>
                                <div style="border: 1px solid #DBDBDB; background-color: #FFFFFF; float: left; margin-left: 26px;
                                    width: 300px; overflow: scroll; height: 430px; overflow-x: hidden;">
                                    <asp:Label ID="Label5" runat="server" Text="   Select Parent Subcategory to see  Subcategory list."
                                        Style="border: 1px solid #DBDBDB; color: #A7A7A7; float: left; height: 60px;
                                        width: 269px; margin-left: 8px; margin-top: 5px;" Visible="false"></asp:Label>
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" GridLines="None"
                                        CssClass="table_data" OnRowDataBound="GridView3_RowDataBound" ShowHeader="false"
                                        Style="margin-left: 4px; text-align: center; margin-top: 5px; height: auto;"
                                        OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowDeleting="GridView3_RowDeleting"
                                        OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbID1" runat="server" Text='<%#Eval("SUBCAT2_ID") %>' Visible="false"></asp:Label>
                                                    <asp:Image ID="Image2" runat="server" Style="width: 30px; height: 45px; float: left;"
                                                        ImageUrl='<%#"/AlereImpactNew/User/FoodCategoryImages/"+Eval("SUBCAT2_IMAGE") %>' />
                                                    <asp:TextBox ID="textname" runat="server" Text='<%#Eval("SUBCAT2_NAME") %>'></asp:TextBox>
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                                        CommandName="Update" CommandArgument='<%#Eval("SUBCAT2_ID") %>' Style="float: right;" />
                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Cancel" ImageUrl="~/images/Actions-file-close-icon.png"
                                                        CommandArgument='<%#Eval("SUBCAT2_ID") %>' Style="float: right;" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbID" runat="server" Text='<%#Eval("SUBCAT2_ID") %>' Visible="false"></asp:Label>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("SUBCAT2_IMAGE") %>' />
                                                    <asp:Image ID="Image1" runat="server" Style="width: 30px; height: 45px;" />
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("SUBCAT2_NAME") %>'></asp:Label>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Pencil-icon.png"
                                                        CommandName="Edit" CommandArgument='<%#Eval("SUBCAT2_ID") %>' Style="float: right;" />
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Actions-file-close-icon.png"
                                                        CommandName="Delete" CommandArgument='<%#Eval("SUBCAT2_ID") %>' Style="float: right;"
                                                        OnClientClick="return confirm('Are you sure you want to delete ?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Select Parent Subcategory to see Subcategory list.
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="lbSubcat" runat="server" Text="" Style="color: Red; margin-left: 15px;"
                                        Visible="false"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_catCreate" />
                    <asp:PostBackTrigger ControlID="btn_Subcat1Create" />
                    <asp:PostBackTrigger ControlID="btn_Subcat2Create" />
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
