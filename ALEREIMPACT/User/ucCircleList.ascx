<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCircleList.ascx.cs"
    Inherits="ALEREIMPACT.User.ucCircleList" %>
<div style="margin-top: 65px">
    <asp:UpdatePanel ID="udpUpdatePanelPendingrequests" runat="server">
        <ContentTemplate>
            <div align="center" style="padding-top: 10px; padding-bottom: 20px; font-size: 18px;
                font-family: myriad pro; font-weight: normal; color: White; width: 980px; background-color: #52AFB0">
                All Circles
            </div>
            <div style="background: none repeat scroll 0 0 #FFFFFF; border-radius: 2px 2px 2px 2px;
                box-shadow: 1px 1px 3px #999999; float: left; margin-top: 0; width: 980px; height: 800px">
                <asp:DataList ID="dlcirclelist" runat="server" CellPadding="3" CellSpacing="30" RepeatColumns="4"
                    BorderColor="Gray" BorderStyle="Solid" CssClass="table-data_List" 
                    onitemdatabound="dlcirclelist_ItemDataBound" >
                    <ItemTemplate>
                        <div style="padding-top:60px">
                            <div runat="server" id="dvcircleimage" style="float: left; padding-bottom: 0; padding-left: 0px;margin-bottom:0px!important;margin-left:0px!important;" class="thumb" >
                                <asp:Image ID="frdimage" runat="server" CssClass="avatar" ImageUrl='<%# "CircleImages/" + Eval("circle_image") %>' />
                            </div>
                            <div style="height: 20px; padding-left: 112px; line-height: 20px; font-size: 12px;
                                width: 98px">
                                <asp:HiddenField ID="hndcolor" runat="server" Value='<%#Eval("circle_color")%>' />
                                <asp:Label ID="frdregid" runat="server" Visible="false" Text='<%#Eval("fk_user_registration_Id")%>'></asp:Label>
                                <asp:Label ID="lbcirlcename" runat="server" Text='<%#Eval("circle_name")%>'></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
