<%@ Page Title="订单生产监控" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordermonitorBatchNum.aspx.cs" Inherits="Mes.Client.Web.View.Orders.ordermonitorBatchNum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
        <style>
        ul li{list-style: none;}
        .window-state:hover {
            color: red;
        }
    </style>
    <script src="/Script/forms/orders/jquery.forms.ordermonitorBatchNum.js?ver=1.0"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <div title="产品总数" region="c-enter" style="border: 0px;">
        <ul id="listinfo" style="list-style: none; padding-top: 10px; padding-left: 0px;">
        </ul>       
    </div>

    <div id="edit_window" class="easyui-window" closed="true" data-options="iconCls:'icon-save'" style="width: 1050px; height: 480px; background: #fff;" minimizable="true" maximizable="true">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgCabinet"></table>
            </div>
        </div>
    </div>
</asp:Content>
