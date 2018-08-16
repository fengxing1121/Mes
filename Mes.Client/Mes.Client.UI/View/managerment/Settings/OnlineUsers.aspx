<%@ Page Title="在线用户列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnlineUsers.aspx.cs" Inherits="Mes.Client.UI.View.Management.Settings.OnlineUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/setting/onlineusers.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="在线用户列表" region="center" border="false">
        <table id="datagrid1">
        </table>
    </div>
</asp:Content>
