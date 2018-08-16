<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Components_View.aspx.cs" Inherits="Mes.Client.Web.View.Components.Components_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true">
        <div region="north" style="height: 100px;">
            <h2>Client Side Pagination in DataGrid</h2>
            <p>This sample shows how to implement client side pagination in DataGrid.</p>
            <div style="margin: 20px 0;"></div>
        </div>
        <div region="center">
            <table id="dg">
            </table>
        </div>
    </div>
    <script>
        $(function () {
            $('#dg').datagrid({
                sortName: 'inv',
                idField: "inv",
                url: '../ashx/test.ashx',//?Method=SearchParts
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                columns: [[
                { field: 'inv', title: '产品名称', width: 150, sortable: false, align: 'center' },
                { field: 'date', title: '成品长(mm)', width: 100, sortable: false, align: 'center' },
                { field: 'name', title: '成品宽(mm)', width: 100, sortable: false, align: 'center' },
                { field: 'amount', title: '厚度(mm)', width: 150, sortable: false, align: 'center' },
                { field: 'price', title: '品牌', width: 120, sortable: false, align: 'center' },
                { field: 'cost', title: '设计师', width: 150, sortable: false, align: 'center' },
                { field: 'note', title: '设计软件', width: 200, hidden: false, sortable: false, align: 'center' }
                ]],
                onLoadError: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.alert('加载数据错误！原因：' + errorThrown.message);
                }
            });
        });
    </script>
</asp:Content>
