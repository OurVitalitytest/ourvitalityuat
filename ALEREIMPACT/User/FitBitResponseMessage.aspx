<%@ Page Title="" Language="C#" MasterPageFile="~/User/LoginUserMaster.Master" AutoEventWireup="true"
    CodeBehind="FitBitResponseMessage.aspx.cs" Inherits="ALEREIMPACT.User.FitBitResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMsgSuccess" runat="server" Text="Your Account has been connected"></asp:Label>
    <asp:Label ID="lblMsgDisconnected" runat="server" Text="Your Account has been disconnected"></asp:Label>
</asp:Content>
