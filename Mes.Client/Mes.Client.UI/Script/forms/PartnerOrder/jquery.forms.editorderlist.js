/*!
 @Name：订单修改列表  
 @Author：
 @Remark：新增
 @Date：2018-07-05
 @License：MES  
 */
'use strict';
document.msCapsLockWarningOff = true;
var ordersForm = {
    init: function () {
        ordersForm.initControls();
        ordersForm.events.loadData();
        ordersForm.controls.searchData.on('click', function () { ordersForm.controls.dgdetail.datagrid('reload'); });
        ordersForm.events.GetOrderStatus();
        ordersForm.events.GetOrderType();
    },
    initControls: function () {
        ordersForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form')//查询表单
        }
        $('#btn_search_ok').linkbutton()

        $('#BookingDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var BookingDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var BookingDateFrom = $("#BookingDateFrom").datebox("getValue");
                if (BookingDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#BookingDateTo').datebox("setValue", '');
                }
                if (BookingDateFrom > BookingDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#BookingDateTo').datebox("setValue", '');
                }
            }
        });

        $('#ShipDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var ShipDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var ShipDateFrom = $("#ShipDateFrom").datebox("getValue");
                if (ShipDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }
                if (ShipDateFrom > ShipDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }
            }
        });
    },
    events: {
        loadData: function () {
            ordersForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'OrderID',
                url: '/ashx/PartnerOrderHandler.ashx?Method=SearchPartnerOrder&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    {
                        field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="修改订单" onclick="ordersForm.events.editorder(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\',\'' + rowData['StepNo'] + '\');"><span style="color:#0094ff;">' + rowData['OrderNo'] + '</span></a>';
                            return strReturn;
                        }
                    },
                    { field: 'OrderType', title: '订单类型', width: 90, sortable: false, align: 'center' },
                    {
                        field: 'BookingDate', title: '订货日期', width: 90, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'ShipDate', title: '交货日期', width: 90, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    { field: 'PartnerName', title: '门店名称', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'CustomerName', title: '客户名称', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Mobile', title: '联系电话', width: 100, sortable: false, align: 'center' },
                    { field: 'SalesMan', title: '业务人员', width: 100, sortable: false, halign: 'center', align: 'center' },
                    {
                        field: 'Status', title: '订单状态', width: 110, align: 'center', formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细" onClick="loadstep(\'' + rowData['OrderID'] + '\');"><span style="color:#0094ff;">' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                            return strReturn;
                        }
                    }
                ]],

                onBeforeLoad: function (param) {
                    ordersForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                    param["StepNo"] = GetOrderStepNo(partneraddorder);
                }
            });
        },
        editorder: function (id, no, stepno) {
            top.addTab("修改【" + no + "】", "/View/PartnerOrder/editorder.aspx?orderid=" + id + "&stepno=" + stepno + "&" + jsNC(), 'table');

        },
        GetOrderStatus: function () {
            $('#Status').combobox({
                valueField: 'CategoryName',
                textField: 'CategoryName',
                method: 'get',
                url: '/ashx/categoryhandler.ashx?Method=GetOrderStatus',
            });
        },

        GetOrderType: function () {
            $('#OrderType').combobox({
                valueField: 'CategoryName',
                textField: 'CategoryName',
                method: 'get',
                url: '/ashx/categoryhandler.ashx?Method=GetOrderType',
            });
        },
    }
};

$(function () {
    ordersForm.init();
});

//加载审核明细
function loadstep(orderid) {
    $('#steps_window').window('open');
    $('#dgsteps').datagrid({
        sortName: 'StepNo',
        idField: 'OrderID',
        url: '/ashx/ordershandler.ashx?Method=GetStepsByOrder&OrderID=' + orderid,
        collapsible: false,
        fitColumns: true,
        pagination: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        loadMsg: '正在加载数据，请稍候....',
        columns: [[
                { field: 'StepName', title: '订单进度', width: 120, sortable: false, align: 'center' },
                { field: 'StartedBy', title: '提交人', width: 150, sortable: false, halign: 'center', align: 'center' },
                {
                    field: 'Started', title: '提交时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined)
                            return "";
                        var date = new Date(+new Date(value) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                        return date;
                    }
                },
                { field: 'Remark', title: '审核意见', width: 300, sortable: false, align: 'center' }
        ]]
    });
}


