<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="UsersDetails.aspx.cs" Inherits="ALEREIMPACT.Admin.UsersDetails" Title="Users Details-" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="dvMain">
        <div id="dvright_section">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="960" border="0" cellspacing="0" cellpadding="0" style="background: none;"
                        class="table_bg">
                        <tr>
                            <td class="heading_bg">
                                <div id="heading_table">
                                    User Statistics Details
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
                                <div id="dvmain" runat="server">
                                    <table border="0" cellpadding="0" cellspacing="0" width="98.5%">
                                        <tr>
                                            <td style="text-align: center; width: 150px;">
                                                <%--  style="width: 51px;"--%>
                                                <asp:Label ID="lblUsersStats" runat="server" Text="Users Statistics"></asp:Label>
                                            </td>
                                            <td style="width: 350px;">
                                                <span>
                                                    <%-- style="float: left; padding-left: 18px; padding-top: 5px; padding-right: 29px;"--%>
                                                    <asp:DropDownList ID="ddlUserstats" runat="server" OnSelectedIndexChanged="ddlUserstats_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Text="New User Registered" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Users Login more than once in a Week" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Users Invited Other Users" Value="3"></asp:ListItem>
                                                         <asp:ListItem Text="Users Actively Tracking steps and Accomplishing Missions" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                            </td>
                                            <td style="width: 350px;">
                                                <span>
                                                    <asp:DropDownList ID="ddlduration" runat="server">
                                                        <%-- onselectedindexchanged="ddlduration_SelectedIndexChanged" AutoPostBack="true" --%>
                                                        <asp:ListItem Text="Weekly" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Monthly" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:ImageButton ID="Imgbtnresult" runat="server" Text="Go" OnClick="Imgbtnresult_Click" ImageUrl="~/images/Excel-icon11.png" />
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="dvgrdNewUserdetails" runat="server" visible="false">
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 800px; text-align: center;
                                        margin: 0 auto">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblmsg" runat="server" Text="No Result Found" Visible="false"></asp:Label>
                                                <asp:GridView ID="GridView1" runat="server" PageSize="50" AutoGenerateColumns="false"
                                                    AllowPaging="True" GridLines="None" CssClass="table_data" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Registration Number" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbRegId" runat="server" Text='<%#Eval("REGISTRATION_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                            <asp:HiddenField ID="HdnName" runat="server" Value='<%#Eval("Name") %>' />
                                                                <asp:Label ID="lbl1" runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Login Email" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("LOGIN_EMAIL") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DOB (MM,DD)" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnMonth" runat="server" Value='<%#Eval("MonthName") %>' />
                                                                <asp:HiddenField ID="hdnDate" runat="server"  Value='<%#Eval("DOB") %>'/>
                                                              <asp:Label ID="LbMonth" runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Created On" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl4" runat="server" Text='<%#Eval("CREATED_ON") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="User Code" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl5" runat="server" Text='<%#Eval("USER_CODE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                </div>
                                <div id="divLoggedInMore" runat="server" visible="false">
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 800px; text-align: center;
                                        margin: 0 auto">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gdLoggedInMore" runat="server" PageSize="50" AutoGenerateColumns="false"
                                                    AllowPaging="True" GridLines="None" CssClass="table_data" AllowSorting="True" OnRowDataBound="gdLoggedInMore_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Registration Number" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl6" runat="server" Text='<%#Eval("fk_user_registration_Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Login Email" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl7" runat="server" Text='<%#Eval("login_email") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                            <asp:HiddenField ID="HdnName" runat="server" Value='<%#Eval("Name") %>' />
                                                                <asp:Label ID="lbl8" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No. of Times LoggedIn" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl9" runat="server" Text='<%#Eval("login_No_of_times") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                </div>
                                <div id="div1" runat="server" visible="false">
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 800px; text-align: center;
                                        margin: 0 auto">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView2" runat="server" PageSize="50" AutoGenerateColumns="false"
                                                    AllowPaging="True" GridLines="None" CssClass="table_data" AllowSorting="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Name(Invited by)" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl10" runat="server" Text='<%#Eval("NameFriendRequestSendBy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Invited by ID" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl11" runat="server" Text='<%#Eval("FriendRequestSentBy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Invited to ID" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl12" runat="server" Text='<%#Eval("FriendRequestSentTo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Friend Name" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl13" runat="server" Text='<%#Eval("NameFriendRequestSendTo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl14" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Login Email ID" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl15" runat="server" Text='<%#Eval("login_email") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                </div>
                                <div id="div2" runat="server" visible="false">
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 800px; text-align: center;
                                        margin: 0 auto">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView3" runat="server" PageSize="50" AutoGenerateColumns="false"
                                                    AllowPaging="True" GridLines="None" CssClass="table_data" AllowSorting="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Registration ID" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl16" runat="server" Text='<%#Eval("fk_login_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl17" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Calories Burnt" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl18" runat="server" Text='<%#Eval("calories_burnt") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Calories Intake" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl19" runat="server" Text='<%#Eval("calories_eaten_today") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date for Calories Burnt/Intake" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl20" runat="server" Text='<%#Eval("date_of_calories_burnt") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Time Spent for Activity" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl21" runat="server" Text='<%#Eval("Time_Activity_Spent") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Steps Covered" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl23" runat="server" Text='<%#Eval("steps_covered") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Floors Covered" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl24" runat="server" Text='<%#Eval("floors_covered") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Deadline Status" HeaderStyle-ForeColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl25" runat="server" Text='<%#Eval("Deadline_Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                </div>
                            </td>
                        </tr>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
