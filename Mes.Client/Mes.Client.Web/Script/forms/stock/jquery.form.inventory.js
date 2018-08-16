'use strict';
document.msCapsLockWarningOff = true;
var inventoryForm = {
    init: function () {
        inventoryForm.initControls();
        inventoryForm.controls.searchData.on('click', function () { inventoryForm.controls.dgdetail.datagrid('reload'); });//加载数据      
        inventoryForm.events.loadData();      
        inventoryForm.events.CabinetType();
    },
    initControls: function () {
        inventoryForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form'),//查询表单              
            steps_window: $('#steps_window')            
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
            inventoryForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'OrderID',
                url: '/ashx/ordershandler.ashx?Method=SearchOrders&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: true,
                columns: [[                 
                {
                    field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="inventory(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');">' + rowData['OrderNo'] + '</a>';
                        return strReturn;
                    }
                },
                { field: 'BattchNum', title: '批次号', width: 90, sortable: false, align: 'center' },
                { field: 'CabinetType', title: '产品类型', width: 60, sortable: false, align: 'center' },
                { field: 'PurchaseNo', title: '采购单号', width: 105, sortable: false, align: 'center' },
                { field: 'OrderType', title: '订单类型', width: 60, sortable: false, align: 'center' },
                { field: 'CustomerName', title: '客户名称', width: 105, sortable: false, halign: 'center', align: 'center' },
                { field: 'LinkMan', title: '联系人', width: 75, sortable: false, align: 'center' },
                { field: 'Mobile', title: '联系电话', width: 95, sortable: false, align: 'center' },
                {
                    field: 'BookingDate', title: '订货日期', width: 85, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                    }
                },
                {
                    field: 'ShipDate', title: '交货日期', width: 85, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                    }
                },
                
                {
                    field: 'IsStandard', title: '是否正标', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        if (value == "True")
                            return "是";
                        else
                            return "否";
                    }
                },
                
                {
                    field: 'Status', title: '订单状态', width: 60, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细" onClick="loadstep(\'' + rowData['OrderID'] + '\');"><span style="color:#0094ff;">' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                        return strReturn;
                    }
                }
                ]],                
                onBeforeLoad: function (param) {
                    inventoryForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    inventoryForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },         
        CabinetType: function () {
            $('#CabinetType').combobox({
                url: '/ashx/categoryhandler.ashx?Method=GetCabinetType',
                textField: 'CategoryName',
                valueField: 'CategoryName',
            });
        } 
    }
};
$(function () {
    inventoryForm.init();
});

//订单备货      
function inventory(id, no) {
    $.messager.confirm('系统提示', '您确定要提交备货申请吗?', function (flag) {
        if (flag) {
            $.ajax({
                url: '/ashx/OrdersHandler.ashx?Method=Inventory',
                data: { OrderID: id },
                success: function (returnData) {
                    if (returnData) {
                        if (returnData.isOk == 1) {
                            showInfo(returnData.message);
                            inventoryForm.controls.dgdetail.datagrid('reload');
                        } else {
                            showError(returnData.message);
                        }
                    }
                }
            });
        }

    });
   
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
        { field: 'Action', title: '发起步骤', width: 120, sortable: false, align: 'center' },
        { field: 'TargetStep', title: '目标步骤', width: 150, sortable: false, halign: 'center', align: 'center' },
        { field: 'StartedBy', title: '提交人', width: 150, sortable: false, halign: 'center', align: 'center' },
        {
            field: 'Started', title: '提交时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                if (value == undefined)
                    return "";
                var date = new Date(+new Date(value) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                return date;
            }
        },
        { field: 'EndedBy', title: '处理人', width: 120, sortable: false, align: 'center' },
        {
            field: 'Ended', title: '处理时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                if (value == undefined)
                    return "";
                var date = new Date(+new Date(value) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                return date;
            }
        },
        { field: 'Remark', title: '审核意见', width: 120, sortable: false, align: 'center' }
        ]],
        onBeforeLoad: function (param) {

        }
    });
    for (var i = 0; i < 20; i++) {
        $('#dgsteps').datagrid('reload');
    }
}
 