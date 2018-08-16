/*!
 @Name：改单审核
 @Author：刘胜伟
 @Remark：新增
 @Date：2018-03-06
 @License：MES  
 */
'use strict';
document.msCapsLockWarningOff = true;
var ordersForm = {
    init: function () {
        ordersForm.initControls();
        ordersForm.events.loadData();
        ordersForm.controls.searchData.on('click', function () { ordersForm.controls.dgdetail.datagrid('reload'); });//加载数据  
        ordersForm.events.CabinetType();
    },
    initControls: function () {
        ordersForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form')//查询表单
        }
        $('#btn_search_ok').linkbutton()

    },
    events: {
        loadData: function () {
            ordersForm.controls.dgdetail.datagrid({
                url: '/ashx/ordershandler.ashx?Method=GetOrder2CabinetLogs&' + jsNC() + '&OrderNo=' + $("#OrderNo").val(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                {
                    field: 'OrderNo', title: '订单编号', width: 105, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');"><span style="color:#0094ff;">' + rowData['OrderNo'] + '</span></a>';
                        return strReturn;
                    }
                },
                { field: 'OutOrderNo', title: '导入单号', width: 105, sortable: false, halign: 'center', align: 'center' },
                { field: 'CabinetName', title: '产品名称', width: 105, sortable: false, halign: 'center', align: 'center' },
                { field: 'Size', title: '现有尺寸', width: 90, sortable: false, halign: 'center', align: 'center' },
                {
                    field: 'OldSize', title: '新尺寸', width: 90, align: 'center', formatter: function (value, rowData, rowIndex) {
                        return (rowData['IsFinish'] == "True" ? "" : (value == rowData['Size'] ? "" : value));
                    }
                },
                { field: 'Color', title: '现有颜色', width: 90, sortable: false, align: 'center' },
                {
                    field: 'OldColor', title: '新颜色', width: 90, align: 'center', formatter: function (value, rowData, rowIndex) {
                        return (rowData['IsFinish'] == "True" ? "" : (value == rowData['Color'] ? "" : value));
                    }
                },
                { field: 'MaterialStyle', title: '现有风格', width: 105, sortable: false, align: 'center' },
                {
                    field: 'OldMaterialStyle', title: '新风格', width: 105, align: 'center', formatter: function (value, rowData, rowIndex) {
                        return (rowData['IsFinish'] == "True" ? "" : (value == rowData['MaterialStyle'] ? "" : value));
                    }
                },
                //{ field: 'CustomerName', title: '客户名称', width: 85, sortable: false, halign: 'center', align: 'center' },
                {
                    field: 'CabinetStatus', title: '申请事由', width: 105, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" onClick="loadOrder2CabinetLogs(\'' + rowData['CabinetID'] + '\');"><span style="color:#0094ff;">' + rowData['Action'] + '</span></a>';
                        return strReturn;
                    }
                },
                {
                    field: 'Status', title: '订单状态', width: 100, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细" onClick="loadstep(\'' + rowData['OrderID'] + '\');"><span style="color:#0094ff;">' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                        return strReturn;
                    }
                },
                {
                    field: 'action', title: '<span iconCls="icon-add"></span>审核操作', width: 120, align: 'center',
                    formatter: function (value, row, index) {
                        var str = "";
                        console.log(row['IsFinish'] + ',' + row['ActionType'])
                        if (row['IsFinish'] == "True") {
                            str = row['Remark'];
                        }
                        else if (row['ActionType'] == 1) {
                            str = '<a href="javascript:void();" onclick="allowUpdate(\'' + row['CabinetID'] + '\',\'' + row['OrderID'] + '\')"><span class="icon disk_multiple">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;允许</a>';
                            str += '<a href="javascript:void();" onclick="cancelUpdate(\'' + row['CabinetID'] + '\',\'' + row['OrderID'] + '\')"><span class="icon medal_gold_delete">&nbsp;&nbsp;</span>&nbsp;撤销</a>';
                        }
                        else if (row['ActionType'] == -1) {
                            str = '<a href="javascript:void();" onclick="allowDelete(\'' + row['CabinetID'] + '\',\'' + row['OrderID'] + '\')"><span class="icon disk_multiple">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;允许</a>';
                            str += '<a href="javascript:void();" onclick="cancelDelete(\'' + row['CabinetID'] + '\',\'' + row['OrderID'] + '\')"><span class="icon medal_gold_delete">&nbsp;&nbsp;</span>&nbsp;撤销</a>';
                        }
                        return str;
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
    ordersForm.init();
    window.top["Refresh_Order"] = function () {
        $("#dgdetail").datagrid("reload");
    };
});

//允许改单
function allowUpdate(CabinetID, OrderID) {
    $.messager.confirm('系统提示', '确定允许该产品改单申请?', function (flag) {
        if (flag) {
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=UpdateCabinetStatus&' + jsNC(),
                data: { CabinetID: CabinetID, OrderID: OrderID, OprationType: 'allowUpdate' },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 1) {
                        ordersForm.events.loadData();
                    }
                    else {
                        showError(data.message);
                    }
                }
            });
        }
    });
};

//撤销改单
function cancelUpdate(CabinetID, OrderID) {
    $.messager.confirm('系统提示', '确定撤销该产品改单申请?', function (flag) {
        if (flag) {
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=UpdateCabinetStatus&' + jsNC(),
                data: { CabinetID: CabinetID, OrderID: OrderID, OprationType: 'cancelUpdate' },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 1) {
                        ordersForm.events.loadData();
                    }
                    else {
                        showError(data.message);
                    }
                }
            });
        }
    });
};

//允许消单
function allowDelete(CabinetID, OrderID) {
    $.messager.confirm('系统提示', '确定允许该产品消单申请?', function (flag) {
        if (flag) {
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=UpdateCabinetStatus&' + jsNC(),
                data: { CabinetID: CabinetID, OrderID: OrderID, OprationType: 'allowDelete' },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 1) {
                        ordersForm.events.loadData();
                    }
                    else {
                        showError(data.message);
                    }
                }
            });
        }
    });
};

//撤销消单
function cancelDelete(CabinetID, OrderID) {
    $.messager.confirm('系统提示', '确定撤销该产品消单申请?', function (flag) {
        if (flag) {
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=UpdateCabinetStatus&' + jsNC(),
                data: { CabinetID: CabinetID, OrderID: OrderID, OprationType: 'cancelDelete' },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 1) {
                        ordersForm.events.loadData();
                    }
                    else {
                        showError(data.message);
                    }
                }
            });
        }
    });
};

//加载审核明细
function loadstep(orderid) {
    $('#order_window').window('open');
    $('#dgorder').datagrid({
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
                return getdateTime(value);
            }
        },
        { field: 'EndedBy', title: '处理人', width: 120, sortable: false, align: 'center' },
        {
            field: 'Ended', title: '处理时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                return getdateTime(value);
            }
        },
        { field: 'Remark', title: '审核意见', width: 120, sortable: false, align: 'center' }
        ]],
        onBeforeLoad: function (param) {

        }
    });
    for (var i = 0; i < 20; i++) {
        $('#dgorder').datagrid('reload');
    }
}


//审核记录
function loadOrder2CabinetLogs(CabinetID) {
    $('#edit_window').window('open');
    $('#dgsteps').datagrid({
        sortName: 'StepNo',
        idField: 'OrderID',
        url: '/ashx/ordershandler.ashx?Method=GetOrder2CabinetLog&CabinetID=' + CabinetID,
        collapsible: false,
        fitColumns: true,
        pagination: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        loadMsg: '正在加载数据，请稍候....',
        columns: [[
        { field: 'Action', title: '发起步骤', width: 120, sortable: false, align: 'center' },
        //{ field: 'TargetStep', title: '目标步骤', width: 150, sortable: false, halign: 'center', align: 'center' },
        { field: 'StartedBy', title: '提交人', width: 150, sortable: false, halign: 'center', align: 'center' },
        {
            field: 'Started', title: '提交时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                return getdateTime(value);
            }
        },
        { field: 'EndedBy', title: '处理人', width: 120, sortable: false, align: 'center' },
        {
            field: 'Ended', title: '处理时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                return getdateTime(value);
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

function showdetail(id, no) {
    top.addTab("查看详情-" + no, "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC(), 'table');
}

