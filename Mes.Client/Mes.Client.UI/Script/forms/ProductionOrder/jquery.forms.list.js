/*!
 @Name：订单查询  
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
        $('#btn_search_ok').linkbutton();

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
                url: '/ashx/ProductionOrderHandler.ashx?Method=SearchProductionOrder&' + jsNC(),
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: false,
                frozenColumns: [[
                    {
                        field: 'ProduceNo', title: '生产订单号', width: 130, align: 'center',formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="ordersForm.events.showProductionOrder(\'' + rowData['OrderID'] + '\',\'' + rowData['ProduceNo'] + '\');"><span style="color:#0094ff;">' + rowData['ProduceNo'] + '</span></a>';
                            return strReturn;
                        }
                    },
                    { field: 'Quantity', title: CabinetsName+'数量', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Amount', title: CabinetsName + '面积(㎡)', width: 120, sortable: false, halign: 'center', align: 'center' },
                    {
                        field: 'ProductionStatus', title: '排单状态', width: 100, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return GetProductionStatus(value);
                        }
                    },
                    {
                        field: 'Datetime', title: '排入日期', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (rowData['ProductionStatus'] == "N") return "";
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'SchedulingCreatedBy', title: '排单人', width: 180, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (rowData['ProductionStatus'] == "N") return "";
                            if (value == undefined) return "";
                            return value;
                        }
                    },
                    {
                        field: 'SchedulingCreated', title: '操作时间', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (rowData['ProductionStatus'] == "N") return "";
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                ]],
                //groupField: 'ProduceNo',
                //view: groupview,
                //groupFormatter: function (value, rows) {
                //    return value + ' - ' + rows.length + ' Item(s)';
                //},
                columns: [[
                    {
                        field: 'OrderNo', title: '订单编号', width: 130, align: 'center', frozen:true,formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="ordersForm.events.showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');"><span style="color:#0094ff;">' + rowData['OrderNo'] + '</span></a>';
                            return strReturn;
                        }
                    },
                    { field: 'OutOrderNo', title: '来源单号', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'OrderType', title: '订单类型', width: 90, sortable: false, align: 'center' },
                    {
                        field: 'BookingDate', title: '订货日期', width: 120, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'ShipDate', title: '交货日期', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    { field: 'PartnerName', title: '门店名称', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'CustomerName', title: '客户名称', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Mobile', title: '联系电话', width: 120, sortable: false, align: 'center' },
                    { field: 'SalesMan', title: '业务人员', width: 100, sortable: false, halign: 'center', align: 'center' },
                    {
                        field: 'Status', title: '订单状态', width: 130, align: 'center', formatter: function (value, rowData, rowIndex) {
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
                }
            });
        },
        showdetail: function (id, no) {
            top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id);
        },
        showProductionOrder: function (id, no) {
            top.addTab("查看【" + no + "】", "/View/ProductionOrder/add.aspx?orderid=" + id + "&produceno=" + no);
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
