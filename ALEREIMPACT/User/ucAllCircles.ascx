<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAllCircles.ascx.cs"
    Inherits="ALEREIMPACT.User.ucAllCircles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/newstyle.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .cls
    {
        color: #777777;
    }
    #listActivities1 table
    {
        width: 100%;
    }
</style>

<script type="text/javascript">
         function parentwindow1() {
        
            window.parent.location.href = "Wall.aspx";
        }
</script>

<script type="text/javascript">
    function OnClientPopulated(sender, e) {
        var autoList = $find("AutoCompleteEx").get_completionList();
        for (i = 0; i < autoList.childNodes.length; i++) {      


            //First node will have the text
            var text =  autoList.childNodes[i].firstChild.nodeValue;
         
            autoList.childNodes[i]._value = text;
            var memname = text.split('|')

            //Height and Width of the mage can be customized here...
            autoList.childNodes[i].innerHTML = memname[1] + '';
            
            document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';
        }
    }
    
     function ace1_itemSelected(source, e) {
  
        var selInd = $find("AutoCompleteEx")._selectIndex;
        
        if (selInd != -1)
       
        var selval = $find("AutoCompleteEx").get_completionList().childNodes[selInd]._value;
        var selvalmemname = selval.split('|');
      
       // $find("AutoCompleteEx").get_element().value = selvalmemname[1];

      //  var memid = $find("AutoCompleteEx").get_element().value.split('|');
        var ace1Value = $get('<%= hdnUserid.ClientID %>');
          var ace2Value = $get('<%= hdnCircleid.ClientID %>');
        ace1Value.value = selvalmemname[0];
      ace2Value.value=selvalmemname[2];
        document.getElementById("<%= btnCircleSearch.ClientID %>").click();

    }
</script>

<script type="text/javascript">
    function ShowImage() {

        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'url(../images/loader.gif)';
        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundRepeat = 'no-repeat';
       
        if (document.getElementById('<%= txtSearch.ClientID %>').value == '') {

            document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'none';
        }
        else
        {  document.getElementById('<%= txtSearch.ClientID %>').style.backgroundImage = 'url(../images/loader.gif)';
        document.getElementById('<%= txtSearch.ClientID %>').style.backgroundRepeat = 'no-repeat';
        }
    }   
</script>

<div style="margin-top: 5px">
    <%-- <asp:UpdatePanel ID="udpUpdatePanelallcircles" runat="server">
        <ContentTemplate>--%>
    <%-- <div class="main_cont_miss" style="float: left !important; margin-left: 2px !important;
                margin-top: -7px !important; width: 965px !important; border: 0px !important;">--%>
    <div class="center" style="margin-top: -6px !important;">
        <div class="graph_progress">
            <%-- <div class="top_his_miss" style="border-bottom: 1px solid #CCCCCC; border-top: 1px solid #CCCCCC;
                    color: #666666; float: left; margin: 0 auto 0 -2px; padding-bottom: 21px; width: 971px;">--%>
            <%--  <div class="bread_miss" style="height: 12px;">--%>
            <%--<span class="mission_miss" style="color: #555555; float: left; font-family: arial;
                            font-size: 16px; font-weight: bold; margin-top: 7px; padding-left: 25px;">All Circles</span>--%>
            <h2 class="graph_head">
                All Circles</h2>
            <div class="search_miss" style="float: right; height: 43px; margin-left: 625px; margin-top: -21px;
                width: 316px;">
                <asp:Button ID="btnCircleSearch" runat="server" Text="server_btn" OnClick="btnCircleSearch_Click"
                    Style="display: none;" />
                <asp:HiddenField ID="hdnUserid" runat="server" />
                <asp:HiddenField ID="hdnCircleid" runat="server" />
                <asp:TextBox ID="txtSearch" runat="server" Style="border: medium none; float: left;
                    height: 20px; margin-left: 35px; margin-top: 8px; background-position: right;
                    padding-bottom: 2px; width: 260px;"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="Search"
                    TargetControlID="txtSearch" WatermarkCssClass="cls">
                </asp:TextBoxWatermarkExtender>
                <div id="listActivities1" style="height: 200px; overflow: scroll; overflow-x: hidden;
                    font-size: 14px; line-height: 50px !important; width: 100px; top: 38px !important;">
                </div>
                <asp:AutoCompleteExtender ID="txtAutoComplActivity_AutoCompleteExtender" MinimumPrefixLength="1"
                    ContextKey="5" CompletionListCssClass="completionList1" CompletionListItemCssClass="listItem1"
                    CompletionListHighlightedItemCssClass="itemHighlighted1" TargetControlID="txtSearch"
                    CompletionInterval="1" BehaviorID="AutoCompleteEx" ServiceMethod="FindCircles"
                    ServicePath="~/Service/alereimpactservice.asmx" runat="server" CompletionListElementID="listActivities1"
                    OnClientPopulated="OnClientPopulated" OnClientItemSelected="ace1_itemSelected">
                </asp:AutoCompleteExtender>
            </div>
            <%-- <div class="arrow_miss">--%>
            <%-- </div>--%>
            <%-- </div>
                    <div class="golist_miss">
                        <span class="go_miss"></span>
                    </div>
                </div>--%>
            <div class="circle_class_center" style="height: 822px !important; overflow-x: hidden;
                overflow-y: scroll; width: 964px !important;">
                <%--  <div class="container">
                    <section class="main">--%>
                <%-- <div style="  background: none repeat scroll 0 0 #FFFFFF;
    border-radius: 2px 2px 2px 2px;
    
    float: left;
   height: 850px;
    margin-left: 2px !important;
    margin-top: 0;
    overflow-x: hidden;
    overflow-y: scroll;
    width: 967px;">--%>
                <asp:DataList ID="dlcirclelist" runat="server" CellPadding="0" CellSpacing="0" RepeatColumns="2"
                    BorderColor="Gray" BorderStyle="Solid" OnItemDataBound="dlcirclelist_ItemDataBound"
                    OnItemCommand="dlcirclelist_ItemCommand">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnCircleId" runat="server" Value='<%#Eval("pk_circle_id") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("fk_user_registration_Id") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnColor" runat="server" Value='<%#Eval("circle_color") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image") %>'>
                        </asp:HiddenField>
                        <asp:HiddenField ID="hdnName" runat="server" Value='<%#Eval("circle_name") %>'></asp:HiddenField>
                        <div class="left_circle" style="float: left; height: 150px !important; margin-left: 43px;
                            width: 380px !important;">
                            <div class="left_img_circle">
                                <ul class="ch-grid" style="float: left !important; margin-left: -75px !important;
                                    margin-top: -25px !important;">
                                    <li>
                                        <asp:LinkButton ID="lnkBtnView" runat="server" CommandName="lnkView" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("pk_circle_id")+";"+Eval("circle_name") %>'
                                            Style="cursor: pointer;">
                                            <div id="divCircle" class="ch-item ch-img-1" runat="server" style="line-height: 15px !important;">
                                                <span style="color: #FFFFFF !important; font-family: arial; font-size: 14px; margin-left: 33px !important;
                                                    margin-top: 55px !important; text-align: center; text-transform: capitalize;
                                                    width: 72px; word-wrap: break-word;">
                                                    <%#Eval("circle_name")%></span>
                                                <div id="divHoverColor" runat="server" class="ch-info" style=" margin-top: 4px !important;
                                                    cursor: pointer; line-height: 16px !important;">
                                                    <span style="border-bottom: none; margin-top: 30px; margin-left: 22px; text-align: center;
                                                        float: left; font-family: arial; font-size: 14px; width: 101px; word-wrap: break-word;">
                                                        <%#Eval("name")%></span><br />
                                                    <p style="padding: 0px !important; font-family: arial;">
                                                        <%#Eval("members")%>
                                                        Members
                                                        <br />
                                                        <%#Eval("missions")%>
                                                        Missions</p>
                                                </div>
                                            </div>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                            <div class="rgt_class_des" style="float: left !important; line-height: 20px !important;
                                width: 50%;">
                                <span class="heading_text" style="float: left !important; width: 100% !important;
                                    margin-left: 10px !important; margin-top: 4px !important; width: 70% !important;
                                    word-wrap: break-word;">
                                    <%#Eval("circle_name")%></span>
                                <div class="des_circle_info" style="float: left !important; width: 100%; margin-top: 7px !important;
                                    margin-left: 10px !important;">
                                    <img src="../images/persn.jpg" style="float: left !important;" /><span style="float: left !important;
                                        width: 70% !important; word-wrap: break-word;"><%#Eval("name")%></span></div>
                                <div class="des_circle_info" style="float: left !important; width: 100%; margin-top: 7px !important;
                                    margin-left: 10px !important;">
                                    <img src="../images/members.jpg" style="float: left !important;" /><span style="float: left !important;"><%#Eval("members")%>
                                        Members</span></div>
                                <div class="des_circle_info" style="float: left !important; width: 100%; margin-top: 7px !important;
                                    margin-left: 10px !important;">
                                    <img src="../images/member.jpg" style="float: left !important;" /><span style="float: left !important;"><%#Eval("Inspirators")%>
                                        Insipirators</span></div>
                                <div class="des_circle_info" style="float: left !important; width: 100%; margin-top: 7px !important;
                                    margin-left: 10px !important;">
                                    <img src="../images/mission1.jpg" style="float: left !important;" /><span style="float: left !important;"><%#Eval("missions")%>
                                        Missions</span></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <asp:Label ID="lbNorecord" runat="server" Text="" Visible="false"></asp:Label>
                <%--  </div>--%>
                <%-- </section>
                </div>--%>
            </div>
        </div>
    </div>
    <%-- </div>--%>
    <%--</ContentTemplate>
       
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpUpdatePanelallcircles">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader13" runat="server">
                    <div>
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" /></asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</div>
