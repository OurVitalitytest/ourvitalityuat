<%@ Page Title="" Language="C#" MasterPageFile="~/User/LoginUserMaster.Master" AutoEventWireup="true"
    CodeBehind="Wall.aspx.cs" Inherits="ALEREIMPACT.User.Wall" %>

<%@ MasterType VirtualPath="~/User/LoginUserMaster.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="UserCt" TagName="Notes" Src="~/User/ucWall.ascx" %>
<%@ Register TagPrefix="UserCtAdminMessages" TagName="AdminMessages" Src="~/User/ucAdminPostedMessage.ascx" %>
<%@ Register TagPrefix="UserCtAdminMessagesNew" TagName="AdminMessageNew" Src="~/User/ucAdminMessagesNew.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

     

    <script type="text/javascript">
        window.onbeforeunload = function() {
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Wall.aspx/ProcessIT",
                    dataType: "json"

                });
            });

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="center_section_mission">
        <div class="mission_tab">
            <%--            <a href="Wall.aspx">
                <div class="mission_tab_num sel">
                    Notes</div>
            </a><a href="Inspirators.aspx">
                <div class="mission_tab_num ">
                    inspirators</div>
            </a><a href="Missions.aspx">
                <div class="mission_tab_num ">
                    missions</div>
            </a><a href="progress.html">
                <div class="mission_tab_num ">
                    Progress</div>
            </a><a href="journal.html">
                <div class="mission_tab_num ">
                    Journal</div>
            </a>--%>
            <div id="dvwall" runat="server" visible="false">
                <asp:UpdatePanel ID="updatePanelWall" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%-- <UserCt:Notes ID="MssionsTab" runat="server" />--%>
                        <div id="divAdminMessageNew" runat="server" visible="false">
                            <UserCtAdminMessagesNew:AdminMessageNew ID="ucAdminMessagesNew" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <%--<div>
        <ajax:TabContainer ID="TabContainer1" runat="server">
            <ajax:TabPanel ID="tbpnluser" runat="server">
                <HeaderTemplate>
                    Notes
                </HeaderTemplate>
                <ContentTemplate>
                   <UserCt:Notes ID="MyHeader" runat="server" />
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="tbpnlusrdetails" runat="server">
                <HeaderTemplate>
                    Inspirators
                </HeaderTemplate>
                <ContentTemplate>
                   
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="tbpnljobdetails" runat="server">
                <HeaderTemplate>
                    Missions
                </HeaderTemplate>
                <ContentTemplate>
                  <UserCt:Missions ID="MissionsUc" runat="server" />
                </ContentTemplate>
            </ajax:TabPanel>
        </ajax:TabContainer>
    </div>--%>
</asp:Content>
