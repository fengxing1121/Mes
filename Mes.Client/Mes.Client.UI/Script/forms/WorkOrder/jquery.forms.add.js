/*!
 @Name：订单查询  
 @Author：
 @Remark：新增
 @Date：2018-07-05
 @License：MES  
 */

var t = null;
var min = 0; //分
var sec = 0; //秒
var hour = 0; //小时

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
            search_form: $('#search_form'),//查询表单
            loading: $('#submit_window'),
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
                idField: 'ProductionID',
                url: '/ashx/ProductionOrderHandler.ashx?Method=SearchProductionOrder&' + jsNC(),
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: false,
                frozenColumns: [[
                    {
                        field: 'ProductionID', width: 50, checkbox: true
                    },
                    {
                        field: 'ProduceNo', title: '生产订单号', width: 130, align: 'center', formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="ordersForm.events.showProductionOrder(\'' + rowData['OrderID'] + '\',\'' + rowData['ProduceNo'] + '\');"><span style="color:#0094ff;">' + rowData['ProduceNo'] + '</span></a>';
                            return strReturn;
                        }
                    },
                    { field: 'Quantity', title: CabinetsName + '数量', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Amount', title: CabinetsName + '面积(㎡)', width: 120, sortable: false, halign: 'center', align: 'center' },
                    {
                        field: 'ProductionStatus', title: '排单状态', width: 100, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return GetProductionStatus(value);
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
                toolbar: [
                    { text: '新建工单', iconCls: 'icon-cog', handler: ordersForm.events.SchedulingProductionOrder }
                ],
                onBeforeLoad: function (param) {
                    ordersForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                    param["ProductionStatus"] = "Y";
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
        SchedulingProductionOrder: function (id, no) {
            var selRows = ordersForm.controls.dgdetail.datagrid('getChecked');
            if (selRows.length == 0) {
                showError("请选择需要排产的订单。");
                return;
            }
            var ProductionIDs ="";
            for (var i = 0; i < selRows.length; i++) {
                ProductionIDs += selRows[i].ProductionID + ",";
            }
            var url = '/ashx/WorkOrderHandler.ashx?Method=SaveWorkOrders&' + jsNC();
            var data = { ProductionIDs: ProductionIDs };
            t = null;
            hour = 0;
            min = 0;
            sec = 0;
            $('.runtime').html('');
            setInterval(function () { t = ordersForm.events.timedCount(); }, 1000);
            ordersForm.controls.loading.window('open');

            $.post(url,data,function (returnData) {
                if (returnData.isOk == 1) {
                    showInfo(returnData.message);
                    ordersForm.events.loadData();
                } else {
                    showError(returnData.message);
                }
            }, 'json')
            .done(function () {
                ordersForm.events.stopCount();
                ordersForm.controls.loading.window('close');
            })
            .error(function () {
                ordersForm.events.stopCount();
                ordersForm.controls.loading.window('close');
            });
        },
        timedCount: function () {
            if (sec == 60) {
                sec = 0;
                min += 1;
            }
            if (min == 60) {
                min = 0;
                hour += 1;
            }
            $('.runtime').html('已经运行：' + cast(hour) + ':' + cast(min) + ':' + cast(sec));
            sec = sec + 1
        },
        stopCount: function () {
            clearTimeout(t)
        },
    }
};

$(function () {
    ordersForm.init();
});

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}

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
