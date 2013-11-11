<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFoodEssentials.ascx.cs"
    Inherits="ALEREIMPACT.User.ucFoodEssentials" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div>
    <style type="text/css">
        .table_data
        {
            border: #DBDBDB solid 1px;
            width: 97%;
            margin-top: 15px;
            text-align: center;
        }
        .table_data th
        {
            background-color: #F0DF95;
            border: 1px solid #F0DF95;
            color: #000000;
            font-size: 11px;
            padding: 5px 0 0;
            font-weight: bold;
        }
        .table_data td
        {
            border: #F0DF95 solid 1px;
            padding: 5px;
            background-color: #F9F9CD;
            line-height: 17px;
        }
        .table_data
        {
            border-collapse: collapse;
            border-style: none solid solid none;
            empty-cells: show;
            text-align: center;
        }
    </style>
<script type="text/javascript">

    function showDivProgress() {
    if(document.getElementById('<%=txtSearch.ClientID %>').value=="")
    {document.getElementById('<%=dvUploader.ClientID %>').style.display = 'none';
    }
    else
    {
    
        document.getElementById('<%=dvUploader.ClientID %>').style.display = 'block';
}
    }
</script>
    <asp:UpdatePanel ID="UpdatePanelFE" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="mission_page">
                <tr>
                    <td>
                        <span style="float: left; margin-left: 6px; margin-top: 20px;">Search :</span>
                        <asp:TextBox ID="txtSearch" runat="server" Style="border: 1px solid #53AEAF; border-radius: 5px 5px 5px 5px;
                            float: left; height: 26px; margin-left: 12px; margin-top: 11px; width: 200px;"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="showDivProgress();"
                            Style="float: left; height: 30px; margin-left: 24px; margin-top: 8px; width: 84px;
                            cursor: pointer;" OnClick="btnSearch_Click" ValidationGroup="a" />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Product"
                            ControlToValidate="txtSearch" ValidationGroup="a" style="  float: left; margin-left: -86px;  margin-top: 13px;"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lbSearch" runat="server" Text="" style="text-transform:capitalize;  color: #0C7A75;  font-size: 23px;  margin-left: 15px;"></asp:Label> 
                    </td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="divFESearch" runat="server" style="float: left; overflow: scroll; display: none;  height: 550px;">
                            <asp:GridView ID="GridView1" runat="server" GridLines="Both" CssClass="table_data"
                                Width="100%" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="UPC">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView1" runat="server" Text='<%#Eval("UPC") %>' CommandName="lnkView"
                                                CommandArgument='<%#Eval("UPC") +","+Eval("Product_Name") %>' OnClientClick="showDivProgress();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Brand">
                                        <ItemTemplate>
                              
                                            <asp:Label ID="lbBrand" runat="server" Text='<%#Eval("Brand") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Manafacturer" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbMAnafacturer" runat="server" Text='<%#Eval("Manafacturer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbname" runat="server" Text='<%#Eval("Product_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Size"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lbsize" runat="server" Text='<%#Eval("Product_Size") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Data Found...
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <asp:LinkButton ID="dummy" runat="server"></asp:LinkButton>
                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" Enabled="True" TargetControlID="dummy"
                            PopupControlID="PanleFE" BackgroundCssClass="modalBackground" DropShadow="false"
                            CancelControlID="Img2">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="PanleFE" runat="server" Style="display: none;    border: 1px solid #F0DF95;   margin-left: -55px !important;  margin-top: -134px !important;  background-color: #EFEFEF;" >
                            <table border="0" cellpadding="0" cellspacing="0"  align="left" style="">
                                <tr>
                                    <td>
                                    <span style="float: left; margin-bottom: 18px;  margin-left: 20px; margin-top: 14px;"><asp:Label ID="Label1" runat="server" Text="" style="text-transform:capitalize;  color: #0C7A75;"></asp:Label>  </span>
                                        <img id="Img2" src="~/images/Close-icon1.png" alt="cross" style="float: right; height: 20px;
                                            padding-right: 10px" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="  background-color: #EFEFEF;  height: 400px;  overflow-x: hidden; overflow-y: scroll; width: 750px;">
                                            <div style="float: left;">
                                            <div style=" background-color: #D7D7D7;
    float: left;
    height: 19px;
    margin-left: 13px;
    padding-left: 16px;
    padding-top: 10px;
    width: 676px;">
                                                <span style="float: left;">Nutrients </span>
                                                </div>
                                                <asp:GridView ID="GrdNutrients" runat="server" GridLines="Both" Style="float: left;  margin-left:12px;  text-align: center;  width: 701px;"                                                   CssClass="table_data"  AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Nutrient Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("nutrient_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Nutrient Value">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbvalue" runat="server" Text='<%#Eval("nutrient_value") %>'></asp:Label>&nbsp;
                                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("nutrient_uom") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <br />
                                            <div style="float: left;">
                                            <div style=" background-color: #D7D7D7;
    float: left;
    height: 19px;
    margin-left: 13px;
    padding-left: 16px;
    padding-top: 10px;
    width: 676px; margin-top: 15px;">
                                                <span style="float: left;">Additives </span>
                                                </div>
                                                <asp:GridView ID="GrdAdditives" runat="server" GridLines="Both" Style="text-align: center; margin-left:13px;"
                                                    CssClass="table_data" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Additive Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbname" runat="server" Text='<%#Eval("additive_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Additive Red Ingredients">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbIngr" runat="server" Text='<%#Eval("Additive_Red_Ingredients") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Additive Value">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbAVAlue" runat="server" Text='<%#Eval("Additive_Value") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Additive Yellow Ingredients">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbYA" runat="server" Text='<%#Eval("Additive_Yellow_Ingredients") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <br />
                                            <div style="float: left;">
                                            <div style=" background-color: #D7D7D7;
    float: left;
    height: 19px;
    margin-left: 13px;
    padding-left: 16px;
    padding-top: 10px;
    width: 676px; margin-top: 15px;">
                                                <span style="float: left;">Allergens </span>
                                                </div>
                                                <asp:GridView ID="GrdAllergens" runat="server" GridLines="Both" Style="text-align: center; margin-left:13px;"
                                                    CssClass="table_data"  AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Allergen Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbAN" runat="server" Text='<%#Eval("allergen_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allergen Red Ingredients">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbAR" runat="server" Text='<%#Eval("allergen_red_ingredients") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allergen Value">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbAAValue" runat="server" Text='<%#Eval("allergen_value") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allergen Yellow Ingredients">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbAAY" runat="server" Text='<%#Eval("allergen_yellow_ingredients") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
           <div id="dvUploader" runat="server" style="display: none;">
            <asp:Panel ID="Panel11" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel21" CssClass="loader11" runat="server">
                    <div style="float: left; margin-top: 71px; font-size: 15px; margin-left: 535px;">
                        Please Wait...
                    </div>
                    <div style="float: left; margin-top: 17px; margin-left: -249px;">
                        <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                            top: 45%;" alt="Processing Request" />
                    </div>
                </asp:Panel>
            </asp:Panel>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
