<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APISearch.aspx.cs" Inherits="ALEREIMPACT.User.APISearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <%--  <script type="text/javascript">
    function OnClientPopulated(sender, e) {
        var autoList = $find("AutoCompleteEx").get_completionList();
        for (i = 0; i < autoList.childNodes.length; i++) {
            // Consider value as image path
            var Brand = autoList.childNodes[i]._value;
            //First node will have the text
            var text = autoList.childNodes[i].firstChild.nodeValue;
            autoList.childNodes[i]._value = text;
            var memname = text.split('|')
            //Height and Width of the mage can be customized here...
            autoList.childNodes[i].innerHTML =  Brand + "&nbsp;-&nbsp;" + memname[1];
            document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';
        }
    }

    function ace1_itemSelected(source, e) {

        var selInd = $find("AutoCompleteEx")._selectIndex;
        if (selInd != -1)
        var selval = $find("AutoCompleteEx").get_completionList().childNodes[selInd]._value;
        var selvalmemname = selval.split('|');
        
        $find("AutoCompleteEx").get_element().value = selvalmemname[1];
        
      //  var memid = $find("AutoCompleteEx").get_element().value.split('|');
        var ace1Value = $get('<%= ace1Value.ClientID %>');
        ace1Value.value = selvalmemname[0];
    document.getElementById("<%= btn_search.ClientID %>").click();

    }

    </script>--%>

    <script language="javascript">
      function CheckPreviousDate(sender, args) {

        var toDate = new Date();


        var selectedDate = sender._selectedDate;

        toDate.setMinutes(0);
        toDate.setSeconds(0);
        toDate.setHours(0);
        toDate.setMilliseconds(0);

        selectedDate.setMinutes(0);
        selectedDate.setSeconds(0);
        selectedDate.setHours(0);
        selectedDate.setMilliseconds(0);

        //alert(sender._selectedDate < toDate);
        //var difference = sender._selectedDate - toDate;
        document.getElementById('hdfromdate').value = document.getElementById('txtCalender').value;
        //alert(document.getElementById('hdfromdate').value);
    }

    </script>

    <script type="text/javascript" language="javascript">
    function DoPostBack()
        {
           __doPostBack("txtCalender", "TextChanged");
        }
    </script>

    <style type="text/css">
        .table-data
        {
            border: #b8b8b8 solid 1px;
        }
        .table-data th
        {
            background: url(../images/heding_bg_table.gif) repeat-x;
            font-size: 12pt;
            padding: 0px;
            color: #444444;
            border: #b8b8b8 solid 1px;
        }
        .table-data td
        {
            border: #b8b8b8 solid 1px;
            padding: 5px;
        }
        .table-data
        {
            border-collapse: collapse;
            border-style: none solid solid none;
            empty-cells: show;
        }
    </style>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
   
    <form id="form1" runat="server">
    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="search_Product">
        <table>
            <tr>
                <td>
                    <div style="float: left;">
                     <asp:HiddenField ID="hdfromdate" runat="server" />
                        <asp:TextBox ID="txtCalender" runat="server" ReadOnly="true" AutoPostBack="true"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalender"
                            OnClientDateSelectionChanged="CheckPreviousDate" PopupButtonID="txtCalender">
                        </asp:CalendarExtender>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-left: 33px; margin-top: 21px;">
                        <span style="float: left; font-size: 14px; margin-top: 8px;">Search : </span>
                        <asp:TextBox ID="textSearch" runat="server" Style="float: left;"></asp:TextBox>
                    </div>
                    <div style="float: left; margin-left: 45px; margin-top: 21px;">
                        <asp:TextBox ID="txtQuantity" runat="server" Style="float: left; width: 42px;"></asp:TextBox>
                        <asp:DropDownList ID="DrpQuanityUnit" runat="server" AppendDataBoundItems="true"
                            Style="float: left; height: 22px; margin-left: 5px; width: 75px;">
                        </asp:DropDownList>
                        <asp:Button ID="btn_search" runat="server" Text="Search" Style="float: left;" OnClick="btn_search_Click" />
                    </div>
                    <%--  <div style="float: left; margin-left: 50px; margin-top: 58px;">
                        <span style="float: left; font-size: 13px; font-weight: bold;">What did you eat?</span>
                    </div>
                    <div style="float: left; margin-left: 133px; margin-top: 58px;">
                        <span style="float: left; font-size: 13px; font-weight: bold;">How Much?</span>
                    </div>
                    <div style="float: left; margin-left: 37px; margin-top: 58px;">
                        <span style="float: left; font-size: 13px; font-weight: bold;">When?</span>
                    </div>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="dvSearch" runat="server" style="float: left; height: 300px; margin-left: 45px;
                        overflow: scroll; text-align: center; width: 1000px;">
                        <asp:GridView ID="GridView1" runat="server" GridLines="Vertical" CssClass="table-data"
                            Style="overflow: scroll; line-height: 25px;" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound"
                            OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Food">
                                    <ItemTemplate>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("UPC") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbname" runat="server" Text='<%#Eval("Product_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Brand">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBrand" runat="server" Text='<%#Eval("Brand") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lbSize" runat="server" Text='<%#Eval("Product_Size") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cal">
                                    <ItemTemplate>
                                        <asp:Label ID="lbCal" runat="server" Text='<%#Eval("cal_value") %>'></asp:Label>
                                        <asp:Label ID="lbcalunit" runat="server" Text='<%#Eval("cal_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fat">
                                    <ItemTemplate>
                                        <asp:Label ID="lbfat" runat="server" Text='<%#Eval("Fat_value") %>'></asp:Label>
                                        <asp:Label ID="lbfatunit" runat="server" Text='<%#Eval("Fat_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chol">
                                    <ItemTemplate>
                                        <asp:Label ID="lbchol" runat="server" Text='<%#Eval("cholestrol_value") %>'></asp:Label>
                                        <asp:Label ID="lbcholunit" runat="server" Text='<%#Eval("cholestrol_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sodium">
                                    <ItemTemplate>
                                        <asp:Label ID="lbsodium" runat="server" Text='<%#Eval("Sodium_value") %>'></asp:Label>
                                        <asp:Label ID="lbSodiumunit" runat="server" Text='<%#Eval("Sodium_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Carbs">
                                    <ItemTemplate>
                                        <asp:Label ID="lbcarbs" runat="server" Text='<%#Eval("Carbohydrates_value") %>'></asp:Label>
                                        <asp:Label ID="lbcarbsunit" runat="server" Text='<%#Eval("Carbohydrates_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fiber">
                                    <ItemTemplate>
                                        <asp:Label ID="lbfiber" runat="server" Text='<%#Eval("Fiber_value") %>'></asp:Label>
                                        <asp:Label ID="lbfiberunit" runat="server" Text='<%#Eval("Fiber_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prot">
                                    <ItemTemplate>
                                        <asp:Label ID="lbprot" runat="server" Text='<%#Eval("Proteins_value") %>'></asp:Label>
                                        <asp:Label ID="lbprotunit" runat="server" Text='<%#Eval("Proteins_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sugars">
                                    <ItemTemplate>
                                        <asp:Label ID="lbsugar" runat="server" Text='<%#Eval("Sugar_value") %>'></asp:Label>
                                        <asp:Label ID="lbsugarunit" runat="server" Text='<%#Eval("Sugar_unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkAdd" runat="server" Text="Add to Food Log" CommandName="lnkAdd"
                                            CommandArgument='<%#Eval("Product_Name")+","+Eval("cal_value")+","+Eval("Fat_value")+","+Eval("cholestrol_value")
                                    +","+Eval("Sodium_value")+","+Eval("Carbohydrates_value")+","+Eval("Fiber_value")+","+Eval("Proteins_value")+","+Eval("Sugar_value")+","+Eval("Product_Size") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <%--  <div style="float: left; margin-left: 35px; margin-top: 25px;">
                        <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click"
                            Style="display: none;" />
                        <asp:HiddenField ID="ace1Value" runat="server" />
                        <asp:TextBox ID="txtSearch" runat="server" Style="width: 250px;" 
                            ontextchanged="txtSearch_TextChanged"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" BehaviorID="AutoCompleteEx"
                            TargetControlID="txtSearch" ServicePath="~/Service/FoodEssentialAPI.asmx" MinimumPrefixLength="1"
                            ServiceMethod="FoodEssentialAPISearch" ContextKey="5" CompletionListCssClass="completionList1"
                            CompletionListItemCssClass="listItem1" CompletionListHighlightedItemCssClass="itemHighlighted1"
                            CompletionInterval="1" OnClientPopulated="OnClientPopulated" OnClientItemSelected="ace1_itemSelected">
                        </asp:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter  what did you eat?" ControlToValidate="txtSearch" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </div>
                    <div style="float: left;  margin-left: -101px; margin-top: 25px;">
                        <asp:TextBox ID="txtQuantity" runat="server" Style="float: left; width: 42px;"></asp:TextBox>
                        
                        &nbsp;
                        <asp:DropDownList ID="DrpQuanityUnit" runat="server" AppendDataBoundItems="true"
                            Style="float: left; height: 22px; margin-left: 5px; width: 75px;">
                        </asp:DropDownList>
                         
                      
                    </div>
                    <div style="float: left; margin-left: 14px; margin-top: 25px;">
                        <asp:DropDownList ID="DrpTime" runat="server" AppendDataBoundItems="true" Style="float: left;
                            height: 22px; margin-left: 5px; width: 166px;">
                        </asp:DropDownList>
                        
                    </div>
                    <div style="float: left;">
                        <asp:Button ID="btnAte" runat="server" Text="I Ate This" ValidationGroup="a" 
                            onclick="btnAte_Click" />
                    </div>--%>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; line-height: 25px;">
                        <asp:GridView ID="GridView2" runat="server" GridLines="Vertical" CssClass="table-data"
                            AutoGenerateColumns="false" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowCommand="GridView2_RowCommand"
                            OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating"
                            OnRowDataBound="GridView2_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Food">
                                    <ItemTemplate>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("UFL_ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbname" runat="server" Text='<%#Eval("Food") %>'></asp:Label>
                                        (
                                        <asp:Label ID="lbSize" runat="server" Text='<%#Eval("Product_Size") %>'></asp:Label>)
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Servings">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtServings" runat="server" Text='<%#Eval("Servings") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbServing" runat="server" Text='<%#Eval("Servings") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eating Time">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DrpEatTime" runat="server" AppendDataBoundItems="true" Style="width: 100px;">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbEatingtime" runat="server" Text='<%#Eval("ET_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cals">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtcals" runat="server" Text='<%#Eval("Cals") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbcal" runat="server" Text='<%#Eval("Cals") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fat">
                                    <ItemTemplate>
                                        <asp:Label ID="lbFat" runat="server" Text='<%#Eval("Fat") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chol">
                                    <ItemTemplate>
                                        <asp:Label ID="lbchol" runat="server" Text='<%#Eval("Chol") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sodium">
                                    <ItemTemplate>
                                        <asp:Label ID="lbsodium" runat="server" Text='<%#Eval("Sodium") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Carbs">
                                    <ItemTemplate>
                                        <asp:Label ID="lbcarbs" runat="server" Text='<%#Eval("Carbs") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fiber">
                                    <ItemTemplate>
                                        <asp:Label ID="lbFiber" runat="server" Text='<%#Eval("Fiber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prot">
                                    <ItemTemplate>
                                        <asp:Label ID="lbProt" runat="server" Text='<%#Eval("Prot") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sugars">
                                    <ItemTemplate>
                                        <asp:Label ID="lbsugar" runat="server" Text='<%#Eval("Sugars") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkupdate" runat="server" Text="Update" CommandName="update"
                                            CommandArgument='<%#Eval("UFL_ID") %>'></asp:LinkButton>/
                                        <asp:LinkButton ID="lnkcancel" runat="server" Text="Cancel" CommandName="cancel"
                                            CommandArgument='<%#Eval("UFL_ID") %>'></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("UFL_ID") %>'></asp:LinkButton>/
                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                                            CommandArgument='<%#Eval("UFL_ID") %>' OnClientClick="return confirm('Are you sure you want to delete ?');"></asp:LinkButton>/
                                        <asp:LinkButton ID="lnkAddFAv" runat="server" Text="Add To Favourite" CommandName="lnkAddFAv"
                                            CommandArgument='<%#Eval("UFL_ID") %>' OnClientClick="return confirm('Are you sure you want to Add this to your Favourite ?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
              
                    <div  style="float: left; margin-left: 27px; margin-top: 29px;">
                        <span style="font-size: 16px; font-weight: bold;">Daily Intake Totals </span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div  style="float: left; margin-left: 19px; margin-top: 40px;">
                        <span style="font-size: 12px; margin-left: 5px;">Cals</span> <span style="font-size: 12px;
                            margin-left: 25px">Fat</span> <span style="font-size: 12px; margin-left: 25px">Cholesterol</span>
                        <span style="font-size: 12px; margin-left: 25px">Sodium</span> <span style="font-size: 12px;
                            margin-left: 25px">Carbs</span> <span style="font-size: 12px; margin-left: 25px">Fiber</span>
                        <span style="font-size: 12px; margin-left: 25px">Protein</span> <span style="font-size: 12px;
                            margin-left: 25px">Sugars</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-left: 16px; margin-top: 25px;">
                        <asp:Label ID="lbCal" runat="server" Text="" Style="margin-left: 5px;"></asp:Label>
                        <asp:Label ID="lbFat" runat="server" Text="" Style="margin-left: 16px;"></asp:Label>
                        <asp:Label ID="lbChol" runat="server" Text="" Style="margin-left: 25px;"></asp:Label>
                        <asp:Label ID="lbSodium" runat="server" Text="" Style="margin-left: 53px;"></asp:Label>
                        <asp:Label ID="lbCrabs" runat="server" Text="" Style="margin-left: 35px;"></asp:Label>
                        <asp:Label ID="lbFiber" runat="server" Text="" Style="margin-left: 29px;"></asp:Label>
                        <asp:Label ID="lbProt" runat="server" Text="" Style="margin-left: 34px;"></asp:Label>
                        <asp:Label ID="lbSugars" runat="server" Text="" Style="margin-left: 43px;"></asp:Label>
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
                    <div id="dvChart" runat="server" style="float: left; margin-left: 86px;">
                        <asp:Chart ID="Chart2" runat="server" Height="250px" Width="350px" OnClick="Chart2_Click">
                            <Titles>
                            </Titles>
                            <Series>
                                <asp:Series Name="Series1" CustomProperties="DrawingStyle=Pie,  
         PieDrawingStyle=Concave, MaxPixelPointWidth=300 " ShadowOffset="2" ChartType="Pie" IsValueShownAsLabel="True"
                                    ShadowColor="Black">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" Area3DStyle-IsRightAngleAxes="true" AlignmentStyle="AxesView"
                                    Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true" Area3DStyle-WallWidth="30"
                                    Area3DStyle-LightStyle="Simplistic">
                                    <AxisX>
                                        <MajorGrid Enabled="true" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
