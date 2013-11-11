<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminDashboard.aspx.cs" Inherits="ALEREIMPACT.Admin.AdminDashboard"
    Title="Admin Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Grd
        {
            line-height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="margin-bottom: -13px; text-align: center;">
        <asp:Label ID="lbMsg" runat="server" Text="Message Sent Successfully" Visible="false"
            Style="color: red; font-size: 14px;"></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="comment_box">
                <span class="Post_Message">Post a Global Message:</span>
                <asp:TextBox ID="txtMessage" runat="server" CssClass="box_dashboard" Style="margin-right: 110px;
                    margin-top: 27px; width: 479px;"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="float: left;
                    padding-left: 194px; padding-right: 96px; width: 86px" ErrorMessage="Enter Message"
                    ControlToValidate="txtMessage" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                    Style="float: left; margin-left: 327px; margin-top: -28px; width: 152px;">
                    <asp:ListItem Value="0" Text="Web"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Mobile"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="a" CssClass="dashborad_submit"
                    Style="cursor: pointer; float: right; height: 31px; margin-right: 16px; margin-top: -33px;"
                    OnClick="btnSubmit_Click" />
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtMessage"
                    WatermarkText="Post a Global Message">
                </asp:TextBoxWatermarkExtender>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select atleast one option"
                    ControlToValidate="RadioButtonList1" ValidationGroup="a" Display="Dynamic" Style="color: #FF0000;
                    display: inline; float: left; margin-left: 295px;"></asp:RequiredFieldValidator>
            </div>
            <table width="98%" border="0">
                <tr>
                    <td style="width: 980px;">
                        <div style="float: left; height: 650px; margin-left: 5px; margin-right: 26px; overflow: scroll;
                            overflow-x: hidden; width: 574px; scroll-bar: vertical;">
                            <div style="margin-left: 6px; margin-top: 8px;">
                                <asp:Label ID="Label2" runat="server" Text="Current Activity :" Style="font-size: 18px;
                                    font-family: arial;"></asp:Label>
                            </div>
                            <asp:GridView ID="GrdCreateCircle" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                GridLines="None" Style="background-color: #EEEEEE !important; border: 0px !important;"
                                CssClass="table_data">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("createdate") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("name") %>' Style="color: #660000;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label6" runat="server" Text="added a" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("circle_permission") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label7" runat="server" Text="Circle " Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("circle_name") %>' Style="color: Blue;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#EEEEEE" BorderColor="#EEEEEE" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="GrdPostComment" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                GridLines="None" Style="background-color: #EEEEEE !important; border: 0px !important;
                                margin-top: 1px;" CssClass="table_data">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("commenttime") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("name") %>' Style="color: #660000;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label6" runat="server" Text="posted to" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("circle_permission") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label7" runat="server" Text="Circle " Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("circle_name") %>' Style="color: Blue;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#EEEEEE" BorderColor="#EEEEEE" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="GrdAddMission" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                GridLines="None" Style="background-color: #EEEEEE !important; border: 0px !important;
                                margin-top: 1px;" CssClass="table_data">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("createdate") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("name") %>' Style="color: #660000;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label6" runat="server" Text="added a mission" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("mission_name") %>' Style="color: #165C67;
                                                font-size: 16px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label9" runat="server" Text="in" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("circle_permission") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label7" runat="server" Text="Circle " Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("circle_name") %>' Style="color: Blue;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#EEEEEE" BorderColor="#EEEEEE" CssClass="Grd" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:GridView ID="GrdAddInspirator" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                GridLines="None" Style="background-color: #EEEEEE !important; border: 0px !important;
                                margin-top: 1px;" CssClass="table_data">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("createddate") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("name") %>' Style="color: #660000;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label6" runat="server" Text="added a inspirator" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label9" runat="server" Text="in" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("circle_permission") %>' Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label7" runat="server" Text="Circle " Style="font-size: 14px;"></asp:Label>&nbsp;
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("circle_name") %>' Style="color: Blue;
                                                font-size: 18px;"></asp:Label>&nbsp;
                                        </ItemTemplate>
                                        <ItemStyle BackColor="#EEEEEE" BorderColor="#EEEEEE" CssClass="Grd" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="float: left; margin-left: -9px; width: 350px; overflow: scroll; overflow-x: hidden;
                            height: 650px;">
                            <div style="background-color: #A2A2A2; color: White; padding-bottom: 2px; padding-left: 83px;
                                padding-top: 2px; width: 266px;">
                                <asp:Label ID="lbname" runat="server" Text="Login Detail For Current Date"></asp:Label>
                            </div>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                                Style="background-color: #A2A2A2 !important;" CssClass="table_data" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="#A2A2A2">
                                        <ItemTemplate>
                                            <asp:Label ID="lbname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Login Time" HeaderStyle-BackColor="#A2A2A2">
                                        <ItemTemplate>
                                            <asp:Label ID="lblogin" runat="server" Text='<%#Eval("logintime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Logout Time" HeaderStyle-BackColor="#A2A2A2">
                                        <ItemTemplate>
                                            <asp:Label ID="lblogout" runat="server" Text='<%#Eval("logouttime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-BackColor="#A2A2A2">
                                        <ItemTemplate>
                                            <asp:Label ID="lbimage" runat="server" Text='<%#Eval("AT_ONLINE") %>' Visible="false"></asp:Label>
                                            <asp:Image ID="Image1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Found...
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
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
</asp:Content>
