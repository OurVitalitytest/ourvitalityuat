<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSearchFriends.ascx.cs"
    Inherits="ALEREIMPACT.User.ucSearchFriends" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style>
    .listItem
    {
        float: left;
        line-height: 25px !important;
        font-size: 12px !important;
        color: #444 !important;
    }
    .itemHighlighted
    {
        background: #ccc !important;
        color: #000 !important;
        font-family: arial;
        font-size: 12px;
        float: left;
        line-height: 25px !important;
    }
    .completionList li:hover
    {
        background: #ccc !important;
        line-height: 25px !important;
    }
    .completionList li
    {
        font-size: 12px !important;
        font-family: Arial;
        font-weight: bold !important;
        line-height: 25px !important;
    }
    .completionList
    {
        font-weight: bold !important;
        font-size: 12px;
        background-color: #FFFFFF;
        border: 0 none !important;
        box-shadow: 1px 0 2px 2px #CCCCCC;
        float: left;
        height: auto;
        margin-bottom: 0;
        margin-left: -60px !important;
        margin-right: 0;
        margin-top: 8px !important;
        overflow: hidden;
        padding: 2px;
        width: 28% !important;
    }
    .ae
    {
        height: 50px;
        border-bottom: 1px solid #ccc;
    }
    .ae1
    {
        margin-top: 6px;
        float: left;
        margin-left: 7px;
    }
    .ae2
    {
        float: left;
        margin-left: 10px;
        margin-top: 8px;
        font-family: arial;
        font-weight: normal;
    }
     .ae3
    {
        float: left;
        margin-left: 10px;
        margin-top: 8px;
        font-size:13px;
        font-family: arial;
        font-weight: bold;
    }
    .profile
    {
        float: left;
    }
    .completionList li
    {
        width: 100%;
        float: left;
        border-bottom: 1px solid #ccc;
        padding: 2px;
    }
</style>

<script type="text/javascript">
    var searh_critereia;
    var findcirle_new_pos;
    var findallmember;
    function OnClientPopulated(sender, e) {
        var autoList = $find("AutoCompleteEx").get_completionList();
        for (i = 0; i < autoList.childNodes.length; i++) {
            // Consider value as image path
            var imgeUrl = autoList.childNodes[i]._value;
            if (imgeUrl != '') {
                imgeUrl = autoList.childNodes[i]._value;
            }
            else {
                imgeUrl = 'profileBlankPhoto.jpg';
            }
            //First node will have the text
            var text = autoList.childNodes[i].firstChild.nodeValue;
            autoList.childNodes[i]._value = text;
            var memname = text.split('|')
            //Height and Width of the image can be customized here...

            autoList.childNodes[i].innerHTML = "<img class='profile' height=40 width=40 top=10 src='profile_image/" + imgeUrl + "' /><div class='ae2'>" + memname[2] + "</div>";


            if (document.getElementById('<%= txtfindfriend.ClientID %>').value == '' || document.getElementById('<%= txtfindfriend.ClientID %>').value == "Search") {


                document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundImage = 'none';
            }
        }
        searh_critereia = document.getElementById('<%= txtfindfriend.ClientID %>').value;

        var findcircele = autoList.childNodes.length;
        findcirle_new_pos = findcircele - 2;
        findallmember = findcircele - 1;
        // autoList.childNodes[findcirle_new_pos].innerHTML = "<span style='font-size:15px;'>" + "Find All Circle named:" + "  " + document.getElementById('<%= txtfindfriend.ClientID %>').value + "<img style='float:left' height=50 width=50 src='http://righttoplay.org/images/green_circle.png'/>" + "</span>";

        autoList.childNodes[findcirle_new_pos].innerHTML = "<img class='profile' height=40 width=40 top=10 src='profile_image/green_circle.png'/><div class='ae3'>Find all circles named:" + document.getElementById('<%= txtfindfriend.ClientID %>').value + "</div>";
        
        autoList.childNodes[findallmember].innerHTML = "See More Results for:" + "  " + document.getElementById('<%= txtfindfriend.ClientID %>').value;
    }


    function ace1_itemSelected(source, e) {



        var selInd = $find("AutoCompleteEx")._selectIndex;
        
        if (selInd != -1)
            if (selInd == findallmember) {
                if (findallmember == 0) {
                    var selval = $find("AutoCompleteEx").get_completionList().childNodes[selInd]._value;

                    var selvalmemname = selval.split('|');

                    $find("AutoCompleteEx").get_element().value = selvalmemname[2];

                    document.getElementById('<%= ace1Value.ClientID %>').value = selvalmemname[0];
                    document.getElementById("<%= btnfindfriend.ClientID %>").click();
                    
                
                 }
                else {
                    var ace1Value = $get('<%= ace1Value.ClientID %>');
                    ace1Value = searh_critereia;

                    document.getElementById("<%=btnInviteMember.ClientID %>").click();
                }

        }
        else if (selInd == findcirle_new_pos) {




           // var ace1Value = $get('<%= ace1Value.ClientID %>');
        document.getElementById('<%= ace1Value.ClientID %>').value = searh_critereia;
           // ace1Value = searh_critereia;
            
            //alert(ace1Value);

            document.getElementById("<%= btnInviteMember.ClientID %>").click();



        }
        else {
           
            var selval = $find("AutoCompleteEx").get_completionList().childNodes[selInd]._value;

            var selvalmemname = selval.split('|');

            $find("AutoCompleteEx").get_element().value = selvalmemname[2];

            //  var memid = $find("AutoCompleteEx").get_element().value.split('|');
            var ace1Value = $get('<%= ace1Value.ClientID %>');
            ace1Value.value = selvalmemname[0];
            document.getElementById("<%= btnfindfriend.ClientID %>").click();
        }

    }

</script>

<script type="text/javascript">

    function ShowImage() {

        document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundImage = 'url(../images/searchload.gif)';
        document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundRepeat = 'no-repeat';

        if (document.getElementById('<%= txtfindfriend.ClientID %>').value == '') {

            document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundImage = 'none';
        }
    }
    function HideImage() {
        document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundImage = 'none';

    }
    var typingTimer;                //timer identifier
    var doneTypingInterval = 1000;  //time in ms, 5 second for example

    function displayunicode(e) {
          //alert(e.keyCode);
        clearTimeout(typingTimer);
        typingTimer = setTimeout(doneTyping, doneTypingInterval);

                if (e.keyCode == 13) {
                    document.getElementById("<%= btnInviteMember.ClientID %>").click();
               }
               if (e.keyCode == 38 || e.keyCode == 40) {
                   document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundImage = 'none';
               
                }
        if (e.keyCode == 8 || e.keyCode == 46) {
            if (document.getElementById('<%= txtfindfriend.ClientID %>').value == '' || document.getElementById('<%= txtfindfriend.ClientID %>').value == "Search") {
                document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundImage = 'none';
            }

        }

    }
    //user is "finished typing," do something
    function doneTyping() {
        document.getElementById('<%= txtfindfriend.ClientID %>').style.backgroundImage = 'none';
    }

   
</script>

<%--<script type="text/javascript">
    function ace1_itemSelected(sender, e) {
       
    }
</script>--%>
<div class="search_wall" id="dvsearch" runat="server">
    <asp:Button ID="btnfindfriend" runat="server" Text="server_btn" OnClick="btnfindfriend_Click"
        Style="display: none;" />
    <asp:Button ID="btnInviteMember" runat="server" Text="server_btn" OnClick="btnInviteMember_Click"
        Style="display: none;" />
    <asp:HiddenField ID="ace1Value" runat="server" />
    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtfindfriend"
        WatermarkText="Search" />
    <asp:TextBox ID="txtfindfriend" runat="server" Width="24%" Style="background-position: right;"
        onChange="ShowImage();" onkeyup="displayunicode(event)"></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtendermemberlist" BehaviorID="AutoCompleteEx"
        FirstRowSelected="false" runat="server" TargetControlID="txtfindfriend" MinimumPrefixLength="1"
        ServiceMethod="FindFriends" ContextKey="5" ServicePath="/Service/alereimpactservice.asmx"
        CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="1"
        OnClientPopulated="OnClientPopulated" OnClientItemSelected="ace1_itemSelected">
    </asp:AutoCompleteExtender>
    <%--<asp:AutoCompleteExtender ID="AutoCompleteExtenderSPECGname" runat="server" TargetControlID="txtfindfriend"
        MinimumPrefixLength="1" ServiceMethod="FindFriends" ContextKey="5" ServicePath="/Service/alereimpactservice.asmx"
        CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="1" OnClientItemSelected="ace1_itemSelected" >
    </asp:AutoCompleteExtender>--%>
    <br />
</div>
