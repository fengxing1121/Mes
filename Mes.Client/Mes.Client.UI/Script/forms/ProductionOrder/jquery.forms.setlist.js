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
        ordersForm.events.loadProductionSet();
        ordersForm.controls.searchData.on('click', function () { ordersForm.controls.dgproductionset.datagrid('reload'); });
        ordersForm.events.GetOrderStatus();
        ordersForm.events.GetOrderType();
    },
    initControls: function () {
        ordersForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgDayDetail'),//填充数据
            search_form: $('#search_form'),//查询表单
            dgproductionset: $('#dgproductionset'),//填充数据
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
        loadData: function (SetID) {
            console.log(SetID);
            ordersForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'OrderID',
                url: '/ashx/ProductionSetHandler.ashx?Method=SearchProductionSetDayDetail&' + jsNC(),
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: false,
                columns: [[
                    {
                        field: 'Datetime', title: '排单日期', width: 210, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'TotalAreal', title: '未排单量', width: 210, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return value + "㎡";
                        }
                    },
                    {
                        field: 'MadeTotalAreal', title: '已排单量', width: 210, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return value + "㎡";
                        }
                    },
                ]],
                groupField: 'WeekNo',
                view: groupview,
                groupFormatter: function (value, rows) {
                    console.log(rows);
                    return "第" + value + "周" + '（比列：' + rows[0].WeekDetailMaxCapacity + '%，总量：' + rows[0].WeekDetailTotalAreal + '㎡）';
                },
                onBeforeLoad: function (param) {
                    param["SetID"] = SetID;
                },
            });
        },
        loadProductionSet: function () {
            ordersForm.controls.dgproductionset.datagrid({
                sortName: 'Created',
                idField: 'SetID',
                url: '/ashx/ProductionSetHandler.ashx?Method=SearchProductionSet&' + jsNC(),
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: true,
                columns: [[
                    {
                        field: 'Started', title: '开始日期', width: 120, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'Ended', title: '截至日期', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'Weeks', title: '周数', width: 80, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return "共" + value + "周";
                        }
                    },
                    {
                        field: 'Days', title: '天数', width: 80, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return "共"+value + "天";
                        }
                    },
                    {
                        field: 'TotalAreal', title: '排单总量', width: 110, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return value + "㎡";
                        }
                    },
                    {
                        field: 'Created', title: '创建时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                ]],
                toolbar: [
                    { text: '月销售预测量设置', iconCls: 'icon-cog', handler: ordersForm.events.showdetail }
                ],
                onSelect: function () {
                    var row = ordersForm.controls.dgproductionset.datagrid('getSelected');
                    if (row != null) {
                        ordersForm.events.loadData(row.SetID);
                    }
                },
                onBeforeLoad: function (param) {
                    ordersForm.controls.search_form.find("input").each(function (index) {
                        param[this.name] = $(this).val();
                    });
                },
                onLoadSuccess: function (data) {
                    if (data.total > 0) {
                        ordersForm.events.loadData(data.rows[0].SetID);
                    }
                }
            });
        },
        showdetail: function () {
            top.addTab("月销售预测量设置 ", "/View/ProductionOrder/set.aspx");
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
