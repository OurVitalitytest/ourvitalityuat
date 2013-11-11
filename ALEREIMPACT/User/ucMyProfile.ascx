<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMyProfile.ascx.cs"
    Inherits="ALEREIMPACT.User.ucMyProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../CSS/circle_css/common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/css.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/demo.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/circle_css/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/mission.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="../CSS/newstyle.css" />

<script src="../js/jquery-1.8.0.min.js" type="text/javascript"></script>

<script type="text/javascript">

    window.onload = function() {
        var parm = document.getElementById("<%=DrpHeightUnit.ClientID %>");
        var selected_Unit = parm.options[parm.selectedIndex].text;

        if (selected_Unit == "cms") {



            // var height_in_cms = (getheight_feet * 30) + (getheight_inches * 2.5);
            document.getElementById("<%=unitofheight.ClientID%>").innerHTML = "cms";
            //txtheightInches
            document.getElementById('<%=incheslength.ClientID %>').style.display = 'none';
            // document.getElementById("<%=txtHeight.ClientID%>").value = height_in_cms;
            //alert(getheight_feet);


        }
        else if (selected_Unit == "feet") {

            document.getElementById("<%=unitofheight.ClientID%>").innerHTML = "ft.";
            document.getElementById('<%=incheslength.ClientID %>').style.display = 'block';


        }
    };
    function CheckHeightUnit() {
        //alert("hello");

        var parm = document.getElementById("<%=DrpHeightUnit.ClientID %>");
        var selected_Unit = parm.options[parm.selectedIndex].text;

        if (selected_Unit == "cms") {


            document.getElementById("<%=txtHeight.ClientID%>").value = 0;

            document.getElementById("<%=txtheightInches.ClientID%>").value = 0;
            // var height_in_cms = (getheight_feet * 30) + (getheight_inches * 2.5);
            document.getElementById("<%=unitofheight.ClientID%>").innerHTML = "cms";
            //txtheightInches
            document.getElementById('<%=incheslength.ClientID %>').style.display = 'none';
            // document.getElementById("<%=txtHeight.ClientID%>").value = height_in_cms;
            //alert(getheight_feet);


        }
        else if (selected_Unit == "feet") {


            document.getElementById("<%=txtHeight.ClientID%>").value = 0;
            document.getElementById("<%=txtheightInches.ClientID%>").value = 0;
            document.getElementById("<%=unitofheight.ClientID%>").innerHTML = "ft.";
            document.getElementById('<%=incheslength.ClientID %>').style.display = 'block';


        }


    }

    //    $(function() {

    //        $('.profile_bg_img').mouseover(function() {

    //            $('.btm_name_bg').css("display", "block");

    //        });
    //        $('.profile_bg_img').mouseout(function() {
    //            $('.btm_name_bg').css("display", "none");
    //        });
    //    });
    //    
   
</script>

<style type="text/css">
    .circle_edit
    {
        background: none repeat scroll 0 0 #000000;
        border-bottom: medium none;
        border-radius: 2px 2px 2px 2px;
        clear: both;
        color: #FFFFFF;
        float: left;
        font-family: arial !important;
        line-height: 26px;
        margin-left: 21%;
        margin-top: 45%;
        opacity: 0.5;
        padding: 0;
        position: absolute;
        text-align: center;
        text-decoration: none;
        width: 60%;
    }
    .circle_edit:hover
    {
        opacity: 0.5;
        text-decoration: none;
    }
    .friends_dp_pic
    {
        float: left;
        margin-bottom: 10px;
        margin-left: 20px;
    }
    .user_info_profile input#MyPrfile_txtHeight
    {
        width: 20px !important;
    }
    #MyPrfile_pnlInches > input#MyPrfile_txtheightInches
    {
        margin-left: 5px;
        margin-right: 8px;
        width: 51px !important;
    }
    .number_circle > input
    {
        padding: 0 !important;
    }
    @media screen and (-webkit-min-device-pixel-ratio:0)
    {
        #MyPrfile_ImgBtnDOBUpdate
        {
            margin-top: 8px !important;
            margin-left: 0px !important;
        }
    }
    .list_rgt_profile select
    {
        border: 1px solid #CCCCCC;
        color: #888888;
        float: left;
        height: 31px;
        margin-right: 3%;
        padding: 5px 10px 5px 6px;
        width: 140px;
    }
    #MyPrfile_pnlInches
    {
        width: 100px;
    }
    #MyPrfile_txtHeight
    {
        border: 1px solid #CCCCCC;
        height: 28px !important;
        padding-left: 0;
        text-align: center;
        width: 42px !important;
    }
    #MyPrfile_drpYear
    {
        width: 85px;
    }
    #MyPrfile_unitofheight
    {
        width: auto;
        margin-right: 10px;
    }
    #MyPrfile_DrpMonth
    {
        width: 170px;
    }
    #MyPrfile_DrpDAy
    {
        width: 100px;
    }
    .email_profile
    {
        float: left;
        font-size: 13px;
        margin-top: 7px;
    }
    .friends_dp_pic span
    {
        float: left;
        font-family: Arial,Helvetica,sans-serif;
        font-size: 15px;
        margin-left: 10px;
        margin-top: 28px;
        width: 140px;
    }
    .list_rgt_profile span
    {
        float: left;
        margin-top: 10px;
        text-align: center;
        width: 130px;
    }
    #MyPrfile_dvlbDOB
    {
        border: 1px solid #CCCCCC;
        color: #888888;
        float: left;
        font-weight: normal;
        height: 28px;
        margin-left: 0 !important;
        width: 140px;
    }
    .select_profile_weight
    {
        width: 140px !important;
    }
    .box_height
    {
        border: 1px solid #CCCCCC;
        color: #888888;
        height: 30px;
        padding-left: 0;
        text-align: center;
        width: 46px;
    }
    #MyPrfile_lbNoMission
    {
        float: left;
        font-family: Arial;
        margin-bottom: 12px;
        margin-top: 18px;
        margin-left: 8px;
    }
    .top_green_miss1
    {
        background: none repeat scroll 0 0 #F1F1F1;
        float: left;
        width: 100%;
        margin-top: 1px;
    }
    .height_weight_profile
    {
        float: left;
        line-height: 47px;
        width: 47%;
        color: #888;
    }
    #MyPrfile_ImgBtnWeightCancel
    {
        border-width: 0;
        float: right;
        height: 16px;
        margin-left: 0;
        margin-top: 8px !important;
        width: 16px;
    }
    #MyPrfile_ImgBtnWeightUpdate
    {
        border-width: 0;
        float: right;
        height: 16px;
        margin-right: 3px;
        margin-top: 9px;
        width: 16px;
    }
    #MyPrfile_dlcirclelist li
    {
        height: 130px;
        width: 130px;
    }
    .inner_box_pop_up
    {
        background: none repeat scroll 0 0 #FFFFFF;
        border: 2px solid #CCCCCC;
        border-radius: 5px 5px 5px 5px;
        box-shadow: -1px 3px 24px #888888;
        height: 348px;
        margin: 125px auto 0 29%;
        opacity: 1;
        position: absolute;
        width: 380px;
        z-index: 999;
    }
    .inner_box_pop_up .close_img_pop_up
    {
        float: right;
    }
    #MyPrfile_panelPuic
    {
        background: none !important;
    }
    #MyPrfile_txtheightInches
    {
        background: none repeat scroll 0 0 #F5F5F5;
        border: 1px solid #CCCCCC;
        color: #888888;
        float: left;
        height: 28px !important;
        margin-right: 0;
        text-align: center;
        width: 51px !important;
    }
    #MyPrfile_RequiredFieldValidator1
    {
        width: 15px !important;
        float: left;
    }
    #MyPrfile_DrpInches
    {
        width: 130px;
    }
    .height_weight_profile_weight
    {
        width: 28%;
    }
    #MyPrfile_dlMissions
    {
        float: left;
        margin-bottom: 16px;
        width: 100%;
    }
    #MyPrfile_dlMissions tr
    {
        border-bottom: 1px solid #CCCCCC;
        float: left;
        height: 26px;
        line-height: 23px;
        width: 100%;
    }
    #MyPrfile_dlMissions tr span
    {
        color: #888;
        font-size: 16px;
        margin-left: 20px;
    }
    .odd_dp_mission span
    {
        color: #888 !important;
        font-size: 16px !important;
    }
    .odd_dp_mission
    {
        background: none repeat scroll 0 0 #FFFFFF;
        float: left;
        height: 26px;
        line-height: 23px;
        width: 100%;
    }
    .top_his_proflie
    {
        background: none repeat scroll 0 0 #F5F7F4;
        border-bottom: 1px solid #CCCCCC;
        border-radius: 5px 5px 0 0;
        color: #666666;
        float: left;
        font-family: arial;
        height: 3px;
        padding-bottom: 20px;
        padding-left: 1%;
        padding-top: 11px;
        width: 99%;
    }
    .main_pop_up_box_miss_new
    {
        background: none repeat scroll 0 0 rgba(0, 0, 0, 0);
        height: 1250px !important;
        left: 0 !important;
        opacity: 1 !important;
        position: absolute !important;
        top: -2px !important;
        width: 100% !important;
        z-index: 100001 !important;
    }
    #MyPrfile_dlMissions a:hover
    {
        text-decoration: none;
    }
</style>

<script type="text/javascript">

    function checkfilesize() {

        var size = document.getElementById("<%=fuProfileImage.ClientID%>").files[0].size;


        if (size > 1048576) {



            alert("Image Size Exceeds Limits");
            return false;
        }
        else {


            return true;
        }


    }
    function checkcircleImage() {

        var size = document.getElementById("<%=fucircleimage.ClientID%>").files[0].size;


        if (size > 1048576) {



            alert("Image Size Exceeds Limits");
            return false;
        }
        else {


            return true;
        }


    }
    function checkHeight() {
        var d = document.getElementById("<%=DrpHeightUnit.ClientID %>");
        var Height=document.getElementById("<%=txtHeight.ClientID %>").value;
        var HeightInches=document.getElementById("<%=txtheightInches.ClientID %>").value;
        var seleced_Height = d.options[d.selectedIndex].value;
        if (seleced_Height == 0) {
            alert("Select Height");
            return false;
        }
        else if(Height==0)
        {
            alert('Height cannot be zero');
            document.getElementById("<%=txtHeight.ClientID %>").value='';
            document.getElementById("<%=txtHeight.ClientID %>").focus();
            return false;
        }
        else if(Height>8 && seleced_Height==3)
        {
            alert('Maximum height in feet is 8 feet');
            document.getElementById("<%=txtHeight.ClientID %>").focus();
            document.getElementById("<%=txtHeight.ClientID %>").value='';
            return false;
        }
        else if(Height<3 && seleced_Height==3)
        {
            alert('Minimum height in feet is 3 feet');
            document.getElementById("<%=txtHeight.ClientID %>").focus();
            document.getElementById("<%=txtHeight.ClientID %>").value='';
            return false;
        }
        else if(HeightInches>11 && seleced_Height==3)
        {
            alert('Maximum height in inches is 11 inches');
            document.getElementById("<%=txtheightInches.ClientID %>").focus();
            document.getElementById("<%=txtheightInches.ClientID %>").value='';
            return false;
        }
        else if(Height>244 && seleced_Height==1)
        {
            alert('Maximum height in cm is 244 cm');
            document.getElementById("<%=txtHeight.ClientID %>").focus();
            document.getElementById("<%=txtHeight.ClientID %>").value='';
            return false;
        }
        else if(Height<90 && seleced_Height==1)
        {
            alert('Minimum height is 90 cm');
            document.getElementById("<%=txtHeight.ClientID %>").focus();
            document.getElementById("<%=txtHeight.ClientID %>").value='';
            return false;
        }
        else {
            return true;
        }
    }
    
    function checkweigth() {
        var w = document.getElementById("<%=DrpWeightUnit.ClientID %>");
        var weight = document.getElementById("<%=txtWeight.ClientID %>").value;
        var selectedWeight = w.options[w.selectedIndex].value;
        
//        alert(selectedWeight);
//        alert(weight);
       
        
        if (selectedWeight == 0) {
            alert("Select Weight");
            return false;
        }
        
        if(selectedWeight==1)
        {
            if(weight>200)
            {
                alert('Maximum weight is 200 kg');
                return false;
            }
            if(weight<40)
            {
                alert('Minimum weight is 40 kg');
                return false;
            }        
        }
        if(selectedWeight==2)
        {
            if(weight>440)
            {
                alert('Maximum weight is 440 lbs');
                return false;
            }
            if(weight<88)
            {
                alert('Minimum weight is 88 lbs');
                return false;
            }
        }
         else {
            return true;
        }
       
    }
    
     function checkEducation() {
        var w = document.getElementById("<%=DrpEducation.ClientID %>");
        var selectedWeight = w.options[w.selectedIndex].value;
        if (selectedWeight == 0) {
            alert("Select Education");
            return false;
        }
        else {
            return true;
        }
    }
    function checkRelation() {
        var w = document.getElementById("<%=DrpRelation.ClientID %>");
        var selectedWeight = w.options[w.selectedIndex].value;
        if (selectedWeight == 0) {
            alert("Select Relation");
            return false;
        }
        else {
            return true;
        }
    }
    function checkReligion() {
        var w = document.getElementById("<%=DrpReligion.ClientID %>");
        var selectedWeight = w.options[w.selectedIndex].value;
        if (selectedWeight == 0) {
            alert("Select Religion");
            return false;
        }
        else {
            return true;
        }
    }
     function checkWorkPlace() {
        var w = document.getElementById("<%=DrpWorkPlace.ClientID %>");
        var selectedWeight = w.options[w.selectedIndex].value;
        if (selectedWeight == 0) {
            alert("Select Work Place");
            return false;
        }
        else {
            return true;
        }
    }
    
    function checkInterest() {
        var w = document.getElementById("<%=DrpInterrest.ClientID %>");
        var selectedWeight = w.options[w.selectedIndex].value;
        if (selectedWeight == 0) {
            alert("Select Interest");
            return false;
        }
        else {
            return true;
        }
    }
    function checkLocation() {
        var w = document.getElementById("<%=DrpLocation.ClientID %>");
        var selectedWeight = w.options[w.selectedIndex].value;
        if (selectedWeight == 0) {
            alert("Select Location");
            return false;
        }
        else {
            return true;
        }
    }
   
    function Check_Validdity() {


        var e = document.getElementById("<%=DrpMonth.ClientID%>");
        var selected_Month = e.options[e.selectedIndex].value;
        var g = document.getElementById("<%=DrpDAy.ClientID%>");
        var seleced_day = g.options[g.selectedIndex].value;
        if (selected_Month == 0) {
            alert("Select Month.");
            return false;
        }
        if (seleced_day == 0) {
            alert("Select Day of Month");
            return false;
        }
        if (selected_Month == 4 || selected_Month == 6 || selected_Month == 9 || selected_Month == 11) {

            if (seleced_day > 30) {
                alert("Select valid day for Selected Month");
                return false;
            }
            else {
                return true;
            }
        }
        if (selected_Month == 2) {
            if (seleced_day > 29) {
                alert("Select valid day for Selected Month");


                return false;
            }
            else {
                return true;
            }
        }
    }

    function Check_Gender() {
        var b = document.getElementById("<%=DrpGender.ClientID%>");
        var seleted_Gender = b.options[b.selectedIndex].value;
        if (seleted_Gender == 0) {
            alert("Please select gender");
            return false;
        }
        else {
            return true;
        }
    }
    
</script>

<script type="text/javascript">
    function parentwindow1() {

        window.parent.location.href = "Wall.aspx";
    }
</script>

<div>
    <asp:UpdatePanel ID="udpUpdatePanelMyProfile" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="main_cont_miss_new">
                <div class="top_his_proflie">
                    My Profile
                    <img width="13" height="12" border="0" alt="" src="../images/arow.jpg">
                </div>
                <div class="left_section_profile">
                    <div class="profile_bg_img" id="profile_img">
                        <asp:ImageButton ID="imgProfile" runat="server" OnClick="imgProfile_Click" Style="border-width: 0;
                            height: 140px; margin-left: 22px; padding-top: 10px; width: 140px;" />
                        <div class="btm_name_bg">
                            <asp:LinkButton ID="lnkChangePic" runat="server" Text="Change profile pic"></asp:LinkButton></div>
                        <asp:ModalPopupExtender ID="PnlInspirator_ModalPopupExtender" runat="server" DynamicServicePath=""
                            Enabled="True" TargetControlID="lnkChangePic" PopupControlID="panelPuic" BackgroundCssClass="modalBackground"
                            DropShadow="false" CancelControlID="ImgClose">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="panelPuic" runat="server" Style="display: none; left: 6px !important;"
                            CssClass="main_pop_up_box_miss">
                            <div class="inner_box_pop_up" style="float: left; margin-left: 315px; height: 180px !important;">
                                <div class="close_img_pop_up">
                                    <asp:Image ID="ImgClose" Style="border-width: 0; float: right; height: 30px; margin-left: 345px;
                                        margin-top: -22px; width: 30px;" runat="server" ImageUrl="http://www.developertips.net/demos/popup-dialog/img/x.png"
                                        OnClientClick="Clear()" /></div>
                                <div class="heading_pop_up">
                                    <span style="float: left; font-family: arial; font-size: 20px; margin-left: 4px;
                                        margin-top: 3px; color: #666666;">Upload Picture</span>
                                </div>
                                <div style="margin-left: 118px !important; margin-top: 33px !important; width: 300px;">
                                    <span class="input_box">
                                        <asp:FileUpload ID="fuProfileImage" runat="server" Style="float: left; margin-left: -99px;
                                            margin-top: 6px;" />
                                        <br />
                                        <span style="color: #000000; float: left; font-family: arial; font-size: 11px; margin-left: -200px;
                                            margin-top: 22px; line-height: 18px !important;">File formats: JPG, GIF, PNG
                                            <br>
                                            Max size: 1MB</span>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAppForm" runat="server" Style="color: #FF0000;
                                            display: inline; float: left; font-family: arial; font-size: 13px; margin-left: -201px;
                                            margin-top: 51px;" ErrorMessage="Upload  image " Display="Dynamic" ControlToValidate="fuProfileImage"
                                            ValidationGroup="a"></asp:RequiredFieldValidator>
                                        <br />
                                        <%--<asp:CustomValidator ID="NewPasswordCustomValidator" runat="server" ToolTip="FileSize should not exceed 1MB"
                                            Style="color: #FF0000; display: inline; float: left; font-family: arial; font-size: 13px;
                                            margin-left: -98px; margin-top: 44px;" ValidationGroup="a" ErrorMessage="FileSize Exceeds the Limits."
                                            ControlToValidate="fuProfileImage" ClientValidationFunction="checkfilesize"></asp:CustomValidator>--%>
                                    </span>
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="create" ValidationGroup="a"
                                        OnClientClick="return checkfilesize();" OnClick="btnUpload_Click" Style="border-radius: 6px 6px 6px 6px !important;
                                        clear: both; float: left; font-size: 17px; height: 33px; margin-left: 275px;
                                        margin-top: -35px !important; padding-bottom: 5px; padding-top: 1px; text-transform: capitalize !important;
                                        width: 87px;" />&nbsp;
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="name_des_profile">
                        <span class="name_profile">
                            <asp:Label ID="lbUserName" runat="server"></asp:Label></span> <span class="email_profile">
                                <asp:Label ID="lbEmail" runat="server" Visible="false"></asp:Label></span>
                    </div>
                    <div class="profile_member_bg">
                        Members</div>
                    <asp:GridView ID="GrdFreinds" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                        OnRowDataBound="GrdFreinds_RowDataBound" OnRowCommand="GrdFreinds_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lbID" runat="server" Text='<%#Eval("fk_user_registration_Id") %>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hdnImahge" runat="server" Value='<%#Eval("user_image") %>' />
                                    <asp:ImageButton ID="ImgFreind" runat="server" Style="height: 70px; float: left;
                                        width: 70px;" CommandName="ImgBtnFrnd" CommandArgument='<%#Eval("fk_user_registration_Id") %>' />
                                    <%-- <asp:Image ID="ImgFreind" runat="server" Style="height: 70px; width: 70px;" />--%>
                                    <asp:Label ID="lbName" runat="server" Text='<%#Eval("name") %>' CssClass="meber_name_list"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="friends_dp_pic" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="rgt_section_profile">
                    <div class="rgt_box_bg_profile">
                        <span>Personal Details</span>
                        <img src="../images/arrow_down.png" />
                    </div>
                    <div class="list_rgt_profile">
                        <span>Gender :</span>
                        <asp:DropDownList ID="DrpGender" runat="server" Enabled="false" Style="float: left;">
                            <asp:ListItem Text="Gender" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:ImageButton ID="ImgBtnGenderEdit" runat="server" ImageUrl="~/images/edit.png"
                            ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                            margin-top: 7px; width: 16px;" OnClick="ImgBtnGenderEdit_Click" />
                        <asp:ImageButton ID="ImgBtnGenderUpdate" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                            ToolTip="Update" Style="border-width: 0; height: 16px; float: left; margin-left: 4px;
                            margin-top: 6px; width: 16px;" OnClick="ImgBtnGenderUpdate_Click" OnClientClick="return Check_Gender();"
                            Visible="false" />
                        <asp:ImageButton ID="ImgBtnGenderCancel" runat="server" ImageUrl="~/images/delete.png"
                            ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                            margin-top: 5px; width: 16px;" OnClick="ImgBtnGenderCancel_Click" Visible="false" />
                        <asp:LinkButton ID="lnkPrivacy" runat="server" Text="Privacy Settings" OnClick="lnkPrivacy_Click"></asp:LinkButton>
                    </div>
                    <div class="list_rgt_profile">
                        <span>BirthDay :</span>
                        <div id="dvlbDOB" runat="server" style="float: left; margin-left: 32px;">
                            <asp:Label ID="lbDOB" runat="server" Text="" Style="margin-left: 7px;"></asp:Label>
                        </div>
                        <asp:ImageButton ID="ImgBtnDOBEdit" runat="server" ImageUrl="~/images/edit.png" ToolTip="Edit"
                            Style="border-width: 0; height: 16px; margin-left: 0px; margin-top: -7px; width: 16px;
                            float: right;" OnClick="ImgBtnDOBEdit_Click" />
                        <div id="dvDOB" style="float: left; margin-left: -4px; margin-top: -3px; width: 470px;
                            display: none;" runat="server">
                            <asp:DropDownList ID="DrpMonth" runat="server" Style="float: left; margin-left: 5px;">
                                <asp:ListItem Text="Month" Value="0"></asp:ListItem>
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="DrpDAy" runat="server" AppendDataBoundItems="true" Style="float: left;
                                margin-left: 5px;" ValidationGroup="updob">
                                <asp:ListItem Text="Day" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="drpYear" runat="server" AppendDataBoundItems="true" Style="float: left;
                                margin-left: 5px;">
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImgBtnDOBUpdate" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                ToolTip="Update" Style="border-width: 0; height: 16px; float: left; margin-left: 5px;
                                margin-top: 8px; width: 16px;" OnClick="ImgBtnDOBUpdate_Click" OnClientClick="return Check_Validdity();" />
                            <asp:ImageButton ID="imgBtnDOBCancel" runat="server" ImageUrl="~/images/delete.png"
                                ToolTip="Cancel" Style="border-width: 0; float: left; height: 16px; margin-top: 7px;
                                width: 16px;" OnClick="imgBtnDOBCancel_Click" />
                        </div>
                    </div>
                    <div class="list_rgt_profile">
                        <span>Height :</span>
                        <div class="height_weight_profile">
                            <asp:TextBox ID="txtHeight" runat="server" ReadOnly="true" CssClass="box_height"
                                MaxLength="3"></asp:TextBox>
                            <asp:Label ID="unitofheight" runat="server" Text="ft"></asp:Label>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtHeight"
                                FilterType="Numbers">
                            </asp:FilteredTextBoxExtender>
                            <%--  <asp:Panel ID="pnlInches" runat="server" Visible="false">--%>
                            <div id="incheslength" runat="server">
                                <asp:TextBox ID="txtheightInches" runat="server" ReadOnly="true" Style="height: 19px;
                                    width: 50px; float: left;" MaxLength="2"></asp:TextBox>
                                <span style="width: auto; margin-left: 4px;">in.</span></div>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtheightInches"
                                FilterType="Numbers">
                            </asp:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ValidationGroup="a" ControlToValidate="txtheightInches"></asp:RequiredFieldValidator>
                            <%-- <asp:DropDownList ID="DrpInches" runat="server" Enabled="false" AppendDataBoundItems="false"
                                    Style="height: 20px; margin-left: 0px;">
                                    <asp:ListItem Text="Inches" Value="2"></asp:ListItem>
                                </asp:DropDownList>--%>
                            <%-- </asp:Panel>--%>
                            <asp:DropDownList ID="DrpHeightUnit" runat="server" Enabled="false" onchange="CheckHeightUnit();"
                                AppendDataBoundItems="false" CssClass="select_profile_weight" Style="width: 80px !important;">
                                <%--   <asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                                <asp:ListItem Text="cms" Value="1"></asp:ListItem>
                                <asp:ListItem Text="feet" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImgBtnHeightEdit" runat="server" ImageUrl="~/images/edit.png"
                                ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                width: 16px;" OnClick="ImgBtnHeightEdit_Click" />
                            <asp:ImageButton ID="ImgBtnHeightUpdate" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                ToolTip="Update" Style="border-width: 0; height: 16px; margin-left: 0px; margin-top: 8px;
                                float: left; width: 16px;" OnClick="ImgBtnHeightUpdate_Click" Visible="false"
                                OnClientClick="return checkHeight();" />
                            <asp:ImageButton ID="ImgBtnHeightCancel" runat="server" ImageUrl="~/images/delete.png"
                                ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-top: 8px; margin-left: 0px;
                                float: left; width: 16px;" OnClick="ImgBtnHeightCancel_Click" Visible="false" />
                        </div>
                        <div class="clear_profile" style="height: 1px">
                        </div>
                    </div>
                    <div class="list_rgt_profile">
                        <span>Weight :</span>
                        <div class="height_weight_profile_weight">
                            <asp:TextBox ID="txtWeight" runat="server" ReadOnly="true" CssClass="box_height"
                                MaxLength="3"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtWeight"
                                FilterType="Custom" ValidChars="0123456789.">
                            </asp:FilteredTextBoxExtender>
                            <asp:DropDownList ID="DrpWeightUnit" runat="server" Enabled="false" CssClass="select_profile_weight"
                                Style="width: 80px !important;" AppendDataBoundItems="false">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                <asp:ListItem Text="lbs" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImgBtnWeightEdit" runat="server" ImageUrl="~/images/edit.png"
                                ToolTip="Edit" Style="border-width: 0; height: 16px; width: 16px;" OnClick="ImgBtnWeightEdit_Click" />
                            <asp:ImageButton ID="ImgBtnWeightUpdate" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                ToolTip="Update" Style="border-width: 0; height: 16px; width: 16px; float: left"
                                OnClick="ImgBtnWeightUpdate_Click" Visible="false" OnClientClick="return checkweigth();" />
                            <asp:ImageButton ID="ImgBtnWeightCancel" runat="server" ImageUrl="~/images/delete.png"
                                ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                margin-top: -3px; width: 16px;" OnClick="ImgBtnWeightCancel_Click" Visible="false" />
                        </div>
                        <div class="clear_profile">
                        </div>
                    </div>
                    <div class="list_rgt_profile" style="width: 100% !important;">
                        <div style="width: 50% !important;">
                            <span>Relation Status:</span>
                            <div class="height_weight_profile_weight" style="width: 50% !important;">
                                <asp:DropDownList ID="DrpRelation" runat="server" Enabled="false" CssClass="select_profile_weight"
                                    AppendDataBoundItems="false">
                                    <asp:ListItem Text="Select Relation" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnEdit_Relation" runat="server" ImageUrl="~/images/edit.png"
                                    ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 5px; margin-top: 8px;
                                    width: 16px;" OnClick="ImgBtnEdit_Relation_Click" />
                                <asp:ImageButton ID="ImgBtnUpdate_Relation" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                    ToolTip="Update" Style="border-width: 0; height: 16px; width: 16px; float: left"
                                    Visible="false" OnClientClick="return checkRelation();" OnClick="ImgBtnUpdate_Relation_Click" />
                                <asp:ImageButton ID="ImgBtnCancel_Relation" runat="server" ImageUrl="~/images/delete.png"
                                    ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                    margin-top: -3px; width: 16px;" Visible="false" OnClick="ImgBtnCancel_Relation_Click" />
                            </div>
                        </div>
                        <div style="width: 50% !important;">
                            <span>Religion:</span>
                            <div class="height_weight_profile_weight" style="width: 50% !important;">
                                <asp:DropDownList ID="DrpReligion" runat="server" Enabled="false" CssClass="select_profile_weight"
                                    AppendDataBoundItems="false">
                                    <asp:ListItem Text="Select Religion" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnEdit_Religion" runat="server" ImageUrl="~/images/edit.png"
                                    ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 5px; margin-top: 8px;
                                    width: 16px;" OnClick="ImgBtnEdit_Religion_Click" />
                                <asp:ImageButton ID="ImgBtnUpdate_Religion" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                    ToolTip="Update" Style="border-width: 0; height: 16px; width: 16px; float: left"
                                    Visible="false" OnClientClick="return checkReligion();" OnClick="ImgBtnUpdate_Religion_Click" />
                                <asp:ImageButton ID="ImgBtnCancel_Religion" runat="server" ImageUrl="~/images/delete.png"
                                    ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                    margin-top: -3px; width: 16px;" Visible="false" OnClick="ImgBtnCancel_Religion_Click" />
                            </div>
                        </div>
                        <div class="clear_profile">
                        </div>
                    </div>
                    <div class="list_rgt_profile" style="width: 100% !important;">
                        <div style="width: 50% !important;">
                            <span>Education:</span>
                            <div class="height_weight_profile_weight" style="width: 50% !important;">
                                <asp:DropDownList ID="DrpEducation" runat="server" Enabled="false" CssClass="select_profile_weight"
                                    AppendDataBoundItems="false">
                                    <asp:ListItem Text="Select Education" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnEdit_Education" runat="server" ImageUrl="~/images/edit.png"
                                    ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 5px; margin-top: 8px;
                                    width: 16px;" OnClick="ImgBtnEdit_Education_Click" />
                                <asp:ImageButton ID="ImgBtnUpdate_Education" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                    ToolTip="Update" Style="border-width: 0; height: 16px; width: 16px; float: left"
                                    Visible="false" OnClientClick="return checkEducation();" OnClick="ImgBtnUpdate_Education_Click" />
                                <asp:ImageButton ID="ImgBtnCancel_Education" runat="server" ImageUrl="~/images/delete.png"
                                    ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                    margin-top: -3px; width: 16px;" Visible="false" OnClick="ImgBtnCancel_Education_Click" />
                            </div>
                        </div>
                        <div style="width: 50% !important;">
                            <span>Work Place:</span>
                            <div class="height_weight_profile_weight" style="width: 50% !important;">
                                <asp:DropDownList ID="DrpWorkPlace" runat="server" Enabled="false" CssClass="select_profile_weight"
                                    AppendDataBoundItems="false">
                                    <asp:ListItem Text="Select Work Place" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnEdit_WorkPlace" runat="server" ImageUrl="~/images/edit.png"
                                    ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 5px; margin-top: 8px;
                                    width: 16px;" OnClick="ImgBtnEdit_WorkPlace_Click" />
                                <asp:ImageButton ID="ImgBtnUpdate_WorkPlace" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                    ToolTip="Update" Style="border-width: 0; height: 16px; width: 16px; float: left"
                                    Visible="false" OnClientClick="return checkWorkPlace();" OnClick="ImgBtnUpdate_WorkPlace_Click" />
                                <asp:ImageButton ID="ImgBtnCancel_WorkPlace" runat="server" ImageUrl="~/images/delete.png"
                                    ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                    margin-top: -3px; width: 16px;" Visible="false" OnClick="ImgBtnCancel_WorkPlace_Click" />
                            </div>
                        </div>
                        <div class="clear_profile">
                        </div>
                    </div>
                    <div class="list_rgt_profile" style="width: 100% !important;">
                        <div style="width: 50% !important;">
                            <span>Interest:</span>
                            <div class="height_weight_profile_weight" style="width: 50% !important;">
                                <asp:DropDownList ID="DrpInterrest" runat="server" Enabled="false" CssClass="select_profile_weight"
                                    AppendDataBoundItems="false">
                                    <asp:ListItem Text="Select Interest" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnEdit_Interest" runat="server" ImageUrl="~/images/edit.png"
                                    ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 5px; margin-top: 8px;
                                    width: 16px;" OnClick="ImgBtnEdit_Interest_Click" />
                                <asp:ImageButton ID="ImgBtnUpdate_Interest" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                    ToolTip="Update" Style="border-width: 0; height: 16px; width: 16px; float: left"
                                    Visible="false" OnClientClick="return checkInterest();" OnClick="ImgBtnUpdate_Interest_Click" />
                                <asp:ImageButton ID="ImgBtnCancel_Interest" runat="server" ImageUrl="~/images/delete.png"
                                    ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                    margin-top: -3px; width: 16px;" Visible="false" OnClick="ImgBtnCancel_Interest_Click" />
                            </div>
                        </div>
                        <div style="width: 50% !important;">
                            <span>Location:</span>
                            <div class="height_weight_profile_weight" style="width: 50% !important;">
                                <asp:DropDownList ID="DrpLocation" runat="server" Enabled="false" CssClass="select_profile_weight"
                                    AppendDataBoundItems="false" Style="width: 140px !important;">
                                    <asp:ListItem Text="Select Location" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnEdit_Location" runat="server" ImageUrl="~/images/edit.png"
                                    ToolTip="Edit" Style="border-width: 0; height: 16px; margin-left: 5px; margin-top: 8px;
                                    width: 16px;" OnClick="ImgBtnEdit_Location_Click" />
                                <asp:ImageButton ID="ImgBtnUpdate_Location" runat="server" ImageUrl="~/images/Files-Edit-file-icon.png"
                                    ToolTip="Update" Style="border-width: 0; height: 16px; width: 16px; float: left"
                                    Visible="false" OnClientClick="return checkLocation();" OnClick="ImgBtnUpdate_Location_Click" />
                                <asp:ImageButton ID="ImgBtnCancel_Location" runat="server" ImageUrl="~/images/delete.png"
                                    ToolTip="Cancel" Style="border-width: 0; height: 16px; margin-left: 0px; float: left;
                                    margin-top: -3px; width: 16px;" Visible="false" OnClick="ImgBtnCancel_Location_Click" />
                            </div>
                        </div>
                        <div class="clear_profile">
                        </div>
                    </div>
                    <div class="rgt_box_bg_profile">
                        <span>Circles</span>
                        <img src="../images/arrow_down.png">
                    </div>
                    <div class="circle_section_profile">
                        <asp:DataList ID="dlcirclelist" runat="server" CellPadding="3" CellSpacing="30" RepeatColumns="4"
                            BorderColor="Gray" BorderStyle="Solid" OnItemDataBound="dlcirclelist_ItemDataBound"
                            OnItemCommand="dlcirclelist_ItemCommand">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("fk_user_registration_Id") %>' />
                                <asp:HiddenField ID="hdnCircleId" runat="server" Value='<%#Eval("fk_circle_id") %>' />
                                <asp:HiddenField ID="hdnColor" runat="server" Value='<%#Eval("circle_color") %>'>
                                </asp:HiddenField>
                                <asp:HiddenField ID="hdnImage" runat="server" Value='<%#Eval("circle_image") %>'>
                                </asp:HiddenField>
                                <li>
                                    <asp:LinkButton ID="lnkBtnView" runat="server" CommandName="lnkView" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("fk_circle_id")+";"+Eval("circle_name") %>'
                                        Style="cursor: pointer;">
                                        <div id="divCircle" runat="server" class="ch-item1 ch-img-21">
                                            <span style="float: left; line-height: 12px !important; margin-left: 24px; width: 65px;
                                                word-wrap: break-word;">
                                                <%#Eval("circle_name") %></span>
                                            <div id="divHoverColor" runat="server" class="ch1-info1" style="margin-top: -60px !important;
                                                line-height: 30px !important; font-family: Arial !important;">
                                                <span style="border-bottom: medium none; float: left; font-family: arial !important;
                                                    margin-left: 24px !important; margin-top: 43px">Members (<%#Eval("freinds")%>)</span><br>
                                                <span style="border-bottom: medium none; float: left; font-family: arial !important;
                                                    margin-left: 24px !important;">Missions (<%#Eval("missions")%>) </span>
                                                <asp:LinkButton runat="server" CssClass="circle_edit" ID="lnkeditcircle" Text="Edit"
                                                    CommandName="openpopup" CommandArgument='<%#Eval("fk_user_registration_Id")+";"+Eval("fk_circle_id")+";"+Eval("circle_name")+";"+Eval("circle_color")+";"+Eval("circle_image") %>'></asp:LinkButton>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                        <asp:Panel ID="PnlCircle" runat="server" Style="display: none" CssClass="main_pop_up_box_miss_new">
                            <div class="overlay_popup" style="background: none repeat scroll 0 0 #FFFFFF; float: left;
                                height: 100%; opacity: 0.5; width: 100%;">
                                &nbsp;</div>
                            <div class="inner_box_pop_up" style="height: 300px;">
                                <div class="close_img_pop_up">
                                    <asp:Image ID="Image1" Style="margin-left: -18px; margin-top: -25px; cursor: pointer;
                                        opacity: 0.5;" runat="server" ImageUrl="~/images/close_btn111.png" /></div>
                                <div class="heading_pop_up">
                                    <span style="float: left; font-family: arial; font-size: 20px; margin-top: 15px;">Edit
                                        Circle:</span> <span style="float: left; margin-top: 23px;">Customize your circle. Make
                                            it your own.</span>
                                </div>
                                </tr>
                                <div class="list_popup">
                                    <span class="text_form_pop" style="float: left; margin-left: 17px !important; margin-right: 0;
                                        width: 100px;">Color:<span style="color: #FF0000"> </span></span><span class="input_box">
                                            <asp:ColorPickerExtender runat="server" ID="cpe" TargetControlID="txtcirclecolor">
                                            </asp:ColorPickerExtender>
                                            <asp:TextBox ID="txtcirclecolor" runat="server" TabIndex="2"></asp:TextBox><br />
                                        </span>
                                </div>
                                <div style="height: 60px; width: auto; float: left; margin-top: 18px;">
                                    <span class="text_form_pop" style="float: left; margin-bottom: 14px; margin-left: 15px !important;
                                        margin-right: -2px; width: 117px;">Upload an image:</span> <span class="input_box"
                                            style="width: 245px !important; float: left;">
                                            <asp:FileUpload ID="fucircleimage" runat="server" CssClass="browse" TabIndex="3"
                                                Style="width: 245px !important;" />
                                            <%--   <asp:FileUpload ID="fucircleimage" runat="server" CssClass="browse" ValidationGroup="circle"
                                                    TabIndex="3" onchange="getImg(this,100,'jpeg|png|jpg')" Style="width: 180px !important;" />--%>
                                            <br />
                                            <br />
                                            <span style="float: left; font-family: Arial; font-size: 12px; margin-left: 16px;
                                                margin-right: 45px; margin-top: 9px;">Max size: 1MB </span>
                                            <asp:Label ID="lbuploadimger" runat="server" Visible="false"></asp:Label>
                                            <br />
                                            <%-- <asp:CustomValidator ID="NewPasswordCustomValidator" runat="server" ToolTip="FileSize should not exceed 1MB"
                                                    Style="float: left; font-family: Arial; font-size: 12px; margin-left: 204px;
                                                    margin-right: 45px; margin-top: -4px;" ValidationGroup="circle" ErrorMessage="FileSize Exceeds the Limits."
                                                    ControlToValidate="fucircleimage" ClientValidationFunction="checkfilesize"></asp:CustomValidator>--%>
                                        </span>
                                </div>
                                <div class="list_popup">
                                    <asp:Button ID="btncreatecircle" runat="server" CssClass="create" Text="Update" OnClick="btncreatecircle_Click"
                                        OnClientClick="return checkcircleImage();" TabIndex="5" Style="clear: both; float: left;
                                        font-size: 15px; height: 37px; margin-left: 140px; margin-top: 10px; padding-bottom: 9px !important;
                                        width: 91px;" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:ModalPopupExtender ID="mpeeditcircle" runat="server" TargetControlID="btnShowPopup"
                            PopupControlID="PnlCircle" BackgroundCssClass="modalBackground" DropShadow="false"
                            RepositionMode="RepositionOnWindowResize" CancelControlID="Image1">
                        </asp:ModalPopupExtender>
                        <div class="number_circle" id="circlepaging" runat="server">
                            <asp:Button ID="btnfirst" runat="server" Font-Bold="true" Text="<<" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnfirst_Click" />
                            <asp:Button ID="btnprevious" runat="server" Font-Bold="true" Text="<" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnprevious_Click" />
                            <asp:Button ID="btnnext" runat="server" Font-Bold="true" Text=">" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnnext_Click" />
                            <asp:Button ID="btnlast" runat="server" Font-Bold="true" Text=">>" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnlast_Click" />
                        </div>
                    </div>
                    <div class="rgt_box_bg_profile">
                        <span>Missions</span>
                        <img src="../images/arrow_down.png">
                    </div>
                    <div class="top_green_miss1">
                        <asp:DataList ID="dlMissions" runat="server" CellPadding="0" CellSpacing="0" RepeatColumns="1"
                            BorderColor="Gray" BorderStyle="Solid" OnItemCommand="dlMissions_ItemCommand">
                            <AlternatingItemStyle CssClass="odd_dp_mission" />
                            <ItemTemplate>
                                <li>
                                    <asp:LinkButton ID="lnkMission" runat="server" CommandName="LnkMission" CommandArgument='<%#Eval("Pk_mission_id") %>'>
                                        <asp:Label ID="lbID" runat="server" Text='<%#Eval("Pk_mission_id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbUserID" runat="server" Text='<%#Eval("fk_created_by_user_Id") %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lbMission" runat="server" Text='<%#Eval("mission_name") %>'></asp:Label>
                                    </asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label ID="lbNoMission" runat="server" Visible="false" Text="No Mission Found.."
                            Style="font-family: Arial;"></asp:Label>
                        <div class="number_circle" id="no_of_mission" runat="server">
                            <asp:Button ID="btnfirst1" runat="server" Font-Bold="true" Text="<<" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnfirst1_Click" />
                            <asp:Button ID="btnprevious1" runat="server" Font-Bold="true" Text="<" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnprevious1_Click" />
                            <asp:Button ID="btnnext1" runat="server" Font-Bold="true" Text=">" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnnext1_Click" />
                            <asp:Button ID="btnlast1" runat="server" Font-Bold="true" Text=">>" Style="font-size: 11px;
                                font-weight: bold; height: 23px; width: 32px;" OnClick="btnlast1_Click" />
                        </div>
                    </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ImgBtnDOBEdit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnDOBUpdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnDOBCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnGenderEdit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnGenderUpdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnGenderCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnHeightEdit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnHeightUpdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnHeightCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnWeightEdit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnWeightUpdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ImgBtnWeightCancel" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btncreatecircle" />
            <asp:PostBackTrigger ControlID="btnShowPopup" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upProgress" DynamicLayout="false" runat="server" AssociatedUpdatePanelID="udpUpdatePanelMyProfile">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" CssClass="overlay" runat="server">
                <asp:Panel ID="Panel2" CssClass="loader11" runat="server">
                    <div>
                    </div>
                    <img src="<%=ResolveClientUrl("~/images/progressimage.gif")%>" style="position: relative;
                        top: 45%;" alt="Processing Request" /></asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
