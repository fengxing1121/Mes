<%@ Page Title="生产排单详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="workcenterState.aspx.cs" Inherits="Mes.Client.Web.View.Workcenters.workcenterState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/workcenters/jquery.forms.workcenterstate.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>          
        </div>
    </div>   
</asp:Content>
