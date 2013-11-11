<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySearch.aspx.cs" Inherits="ALEREIMPACT.User.CategorySearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="en" />
    <meta name="language" content="en" />
    <meta name="robots" content="index, follow" />
    <meta name="author" content="Adriana Palazova - www.adipalaz.com" />
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
   
    <style type='text/css'>
*
        {
            margin: 0;
            padding: 0;
        }
        /* --- Page Structure  --- */html
        {
            height: 100%;
        }
        body
        {
            min-width: 480px;
            width: 100%;
            height: 101%;
            background: #fff;
            color: #333;
            font: 76%/1.6 verdana,geneva,lucida, 'lucida grande' ,arial,helvetica,sans-serif;
            text-align: center;
        }
        #wrapper
        {
            margin-bottom: 30px;
            padding: 10px 2.5%;
            border-top: 0.1em solid #ccc;
            background: #fff;
            text-align: left;
            overflow: hidden;
        }
        #container
        {
            float: left;
            width: 100%;
            margin-right: -19em;
            padding: 0 0 1em;
            position: relative;
            min-height: 0;
        }
        #main
        {
            margin-right: 19em;
            position: relative;
            min-height: 0;
        }
        #side
        {
            float: right;
            display: inline;
            width: 18em;
            padding-bottom: 1.3em;
            position: relative;
            color: #e3e3e3;
            overflow: hidden;
        }
        p
        {
            margin: 0 10px 1em;
        }
        .strong
        {
            font-weight: 700;
        }
        .clear
        {
            clear: both;
        }
        img
        {
            border: 0 none;
        }
        /* --- Headings --- */h1
        {
            font-family: georgia, 'times new roman' ,times,serif;
            font-size: 2.5em;
            font-weight: normal;
            color: #f60;
        }
        h1, h2, h3
        {
            margin-bottom: 1em;
        }
        h2, h3, h4 a, h5 a
        {
            padding: 3px 10px;
        }
        h2, h3, h4, h5
        {
            font-size: 1em;
        }
        #main h2
        {
            background-color: #f0f0f0;
        }
        #side, #side h2, #side h3
        {
            background: #000;
            color: #e3e3e3;
        }
        #side h2
        {
            border-bottom: 1px solid #484b51;
        }
        /* --- Links --- */a
        {
            padding: 1px;
            border: 1px solid #e0e0e0;
            color: #05b;
        }
        a:hover, a:focus, a:active
        {
            border-color: #bcd;
            text-decoration: none;
            outline: 0 none;
        }
        #side a
        {
            display: block;
            border-width: 0 0 1px;
            border-color: #445;
            color: #f0f0f0;
        }
        #side a:hover, #side a:active, #side a:focus
        {
            background-color: #334;
        }
        /* --- Accordion --- */.js #main .accordion
        {
            visibility: hidden;
        }
        .js #side .accordion
        {
            display: none;
        }
        .accordion
        {
            margin: 0;
            padding: 0 10px;
        }
        .accordion li
        {
            list-style-type: none;
        }
        .accordion li.last-child
        {
            margin-left: 19px;
            list-style-type: disc;
        }
        #side ul.accordion ul
        {
            margin: 0;
            padding: 0 0 0 20px;
        }
        .accordion .outer
        {
            border: 1px solid #dadada;
            border-width: 0 1px 1px;
            background: #fff;
        }
        .accordion .inner
        {
            margin-bottom: 0;
            padding: .5em 20px 1em;
            position: relative;
            overflow: hidden;
        }
        .accordion .inner .inner
        {
            padding-bottom: 0;
        }
        .accordion .h
        {
            padding-top: .3em;
        }
        /* vertical padding instead of vertical margin (ie8) */.accordion p
        {
            margin: .5em 1px 1em;
        }
        /*  
  Add styles for all links in the 'accordion':
.accordion a {...}
*/a.trigger
        {
            display: block;
            padding-left: 20px;
            background-image: url(../style/img/plus.gif);
            background-repeat: no-repeat;
            background-position: 1px 50%;
            font-weight: 700;
        }
        a.trigger.open
        {
            background-image: url(../style/img/minus.gif);
        }
        .last-child a.trigger
        {
            padding-left: 1px;
            background-image: none;
            font-weight: normal;
        }
        #main a.trigger
        {
            background-color: #f0f0f0;
        }
        #main a.trigger.open
        {
            border-color: #dadada;
            background-color: #e7e7e7;
        }
        #main a:hover.trigger.open, #main a:focus.trigger.open, #main a:active.trigger.open
        {
            border-color: #bcd;
        }
        #side a.active
        {
            font-weight: 700;
            color: #f72;
            text-decoration: none;
        }
    </style>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>

    <script type="text/javascript" src="../scripts/JScript.js"></script>

    <script type="text/javascript">
<!--        //--><![CDATA[//><!--
        $("html").addClass("js");
        $.fn.accordion.defaults.container = false;
        $(function() {
            $("#acc3").accordion({ initShow: "#current" });
            $("#acc1").accordion({
                el: ".h",
                head: "h4, h5",
                next: "div",
                initShow: "div.outer:eq(1)"
            });
            $("#acc2").accordion({
                obj: "div",
                wrapper: "div",
                el: ".h",
                head: "h4, h5",
                next: "div",
                showMethod: "slideFadeDown",
                hideMethod: "slideFadeUp",
                initShow: "div.shown",
                elToWrap: "sup, img"
            });
            $("html").removeClass("js");
        });
        //--><!]]>
    </script>

    <!--<![endif]-->
    <!-- This is NOT a part of the example code (Google Analytics) -->

    <script type="text/javascript">
<!--        //--><![CDATA[//><!--
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-1761759-2']);
        _gaq.push(['_setDomainName', 'www.adipalaz.com']);
        _gaq.push(['_trackPageview']);
        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
        //--><!]]>
    </script>
</head>
<body>
   <form id="form1" runat="server">


    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
     <table border="0" cellpadding="0" cellspacing="0">
     
     <tr>
  <td>
   <div id="container">
        <div id="main">
            <div id="acc2" class="accordion">
                <h4>
                    <asp:Repeater ID="dMajor" runat="server" OnItemDataBound="dMajor_ItemDataBound">
                        <ItemTemplate>
                        
                         
                            <h4>
                                                <asp:Label ID="lbid" runat="server" Text='<%#Eval("CAT_ID") %>' Visible="false"></asp:Label>
                                <a id="ancMajorCategories" runat="server" class="trigger" ><%#Eval("CAT_NAME") %>
                                 <asp:Image ID="Image1" runat="server" ImageUrl='<%#"/User/FoodCategoryImages/"+Eval("CAT_IMAGE") %>' style="float:left; height:30px; width:30px;" />
             </a>
                            
                                </h4>
                               
                                <div class="inner">
                   
                        <div class="inner">
                  
                        </div>
                          <asp:Repeater ID="dMajorSubcat" runat="server" OnItemDataBound="dMajorSubcat_ItemDataBound">
                        <ItemTemplate>
                        <h5>
                      
                         <asp:Label ID="lbPsubcatid" runat="server" Text='<%#Eval("SUBCAT1_ID") %>' Visible="false"></asp:Label>
   
                             <a id="a1" runat="server" class="trigger" ><%#Eval("SUBCAT1_NAME")%>
                              <asp:Image ID="img" runat="server" ImageUrl='<%#"/User/FoodCategoryImages/"+Eval("SUBCAT1_IMAGE") %>' style="float:left; height:30px; width:30px;" />
                             </a>
                             
                             </h5>
                        <div class="inner">
                            <p>
                             <asp:Repeater ID="dSubcat" runat="server">
                        <ItemTemplate>
                          <asp:Label ID="lbsubcatid" runat="server" Text='<%#Eval("SUBCAT2_ID") %>' Visible="false"></asp:Label>
                           
                            <asp:LinkButton ID="LinkButton1" runat="server" >
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUBCAT2_NAME") %>'></asp:Label>
                               <asp:Image ID="Ima" runat="server" ImageUrl='<%#"/User/FoodCategoryImages/"+Eval("SUBCAT2_IMAGE") %>' style="float:left; height:30px; width:30px;" />
                            </asp:LinkButton>
                        </ItemTemplate>
                       </asp:Repeater>
                            </p>
                            
                        </div>
                        </ItemTemplate>
                            </asp:Repeater>
                    </div>
                        </ItemTemplate>
                  </asp:Repeater>
                    
                </h4>
               
            </div>
         
        </div>
    </div>
  </td>
     </tr>
     
            <tr>
                <td>
                <div style=" float: left;
    margin-left: 12px;
    margin-top: 24px;
    width: 310px;">
                <span style="float:left;">Category :</span>
                    <asp:DropDownList ID="DrpCategory" runat="server" AppendDataBoundItems="true" 
                        AutoPostBack="true" style="float:left;   margin-left: 10px; width: 216px;" 
                        onselectedindexchanged="DrpCategory_SelectedIndexChanged">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                  <div style="  float: left;
    margin-left: 5px;
    margin-top: 24px;
    width: 376px;">
                <span style="float:left;">Parent Subcategory :</span>
                    <asp:DropDownList ID="DrpParentSubcat" runat="server" AppendDataBoundItems="true" 
                          AutoPostBack="true" style="float:left;   margin-left: 10px; width: 216px;" 
                          onselectedindexchanged="DrpParentSubcat_SelectedIndexChanged">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                      <div style=" float: left;
    margin-left: 5px;
    margin-top: 24px;
    width: 341px;">
                <span style="float:left;">Subcategory :</span>
                    <asp:DropDownList ID="DrpSubcat" runat="server" AppendDataBoundItems="true" style="float:left;margin-left: 10px; width: 216px;">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                       <div style="float:left;  margin-top: 20px;">
                           <asp:Button ID="btn_search" runat="server" Text="Search" 
                               OnClick="btn_search_Click" />
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
                <div style="float:left; overflow:scroll; overflow-x:hidden;">
                
                <asp:GridView ID="GridView1" runat="server" GridLines="Vertical" CssClass="table-data"
                            Style="overflow: scroll; line-height: 25px;" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
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
                               
                            </Columns>
                        </asp:GridView>
                </div>
                </td>
                </tr>
                
               
                </table>
    
    </div>
    </form>
</body>
</html>
