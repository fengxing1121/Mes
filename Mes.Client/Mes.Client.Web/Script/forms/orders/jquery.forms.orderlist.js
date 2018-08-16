/*!
 @Name：订单修改列表
 @Author：刘胜伟
 @Remark：新增
 @Date：2018-03-12
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
                url: '/ashx/ordershandler.ashx?Method=SearchOrders&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                {
                    field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');"><span style="color:#0094ff;">' + rowData['OrderNo'] + '</span></a>';
                        return strReturn;
                    }
                },
                { field: 'OutOrderNo', title: '导入单号', width: 105, sortable: false, halign: 'center', align: 'center' },
                //{ field: 'PurchaseNo', title: '采购单号', width: 105, sortable: false, halign: 'center', align: 'center' },
                //{ field: 'BattchNum', title: '批次号', width: 80, sortable: false, halign: 'center', align: 'center' },
                { field: 'CabinetType', title: '产品类型', width: 60, sortable: false, align: 'center' },
                { field: 'OrderType', title: '订单类型', width: 60, sortable: false, align: 'center' },
                {
                    field: 'CustomerName', title: '客户名称', width: 105, sortable: false, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (!IsNullOrEmpty(rowData['CustomerName']) && !IsNullOrEmpty(rowData['PartnerName'])) return (rowData['PartnerName'] + "(" + rowData['CustomerName'] + ")");
                        if (!IsNullOrEmpty(rowData['CustomerName'])) return (rowData['CustomerName']);
                        if (!IsNullOrEmpty(rowData['PartnerName'])) return (rowData['PartnerName']);
                    }
                },
                //{ field: 'LinkMan', title: '联系人', width: 70, sortable: false, halign: 'center', align: 'center' },
                { field: 'Mobile', title: '联系电话', width: 95, sortable: false, align: 'center' },
                {
                    field: 'BookingDate', title: '订货日期', width: 85, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                    }
                },
                //{
                //    field: 'ShipDate', title: '交货日期', width: 85, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                //        if (value == undefined) return "";
                //        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                //    }
                //},
                {
                    field: 'Created', title: '创建时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                    }
                },
                //{
                //    field: 'IsStandard', title: '是否正标', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                //        if (value == undefined) return "";
                //        if (value == "True")
                //            return "是";
                //        else
                //            return "否";

                //    }
                //},
                //{
                //    field: 'IsOutsourcing', title: '是否外购', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                //        if (value == undefined) return "";
                //        if (value == "True")
                //            return "是";
                //        else
                //            return "否";
                //    }
                //},
                {
                    field: 'Status', title: '订单状态', width: 60, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细" onClick="loadstep(\'' + rowData['OrderID'] + '\');"><span style="color:#0094ff;">' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                        return strReturn;
                    }
                },
                {
                    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                    formatter: function (value, row, index) {
                        if (row['Status'] == "T") {
                            var str = '<a href="#" onclick="showdeditorder(\'' + row['OrderID'] + '\',\'' + row['OrderNo'] + '\');"><span class="icon style_edit">&nbsp;&nbsp;&nbsp;&nbsp;</span>直接修改</a>';
                            return str;
                        }
                        else if (row['Status'] == "P") {
                            var str = '<a href="#" onclick="showeditproduct(\'' + row['OrderID'] + '\',\'' + row['OrderNo'] + '\');"><span class="icon shape_rotate_anticlockwise">&nbsp;&nbsp;&nbsp;&nbsp;</span>申请改单</a>';
                            return str;
                        }
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

//加载审核明细
function loadstep(orderid) {
    $('#edit_window').window('open');
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

function showdetail(id, no) {
    top.addTab("查看详情-" + no, "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC(), 'table');
}
function showdeditorder(id, no) {
    top.addTab("修改订单-" + no, "/View/orders/editorder.aspx?orderid=" + id + "&" + jsNC(), 'table');
}
function showeditproduct(id, OrderNo) {
    top.addTab("提交申请-" + OrderNo, "/View/product/editproduct.aspx?OrderNo=" + OrderNo + "&" + jsNC(), 'table');
}

