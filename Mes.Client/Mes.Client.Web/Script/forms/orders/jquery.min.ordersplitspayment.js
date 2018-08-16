'use strict';
document.msCapsLockWarningOff = true;
var ordersPaymentForm = {
    init: function () {
        this.initControls();
        this.controls.searchData.on('click', function () { ordersPaymentForm.controls.dgdetail.datagrid('reload'); });//加载数据
        this.events.loadData();
        this.controls.pay_confirm.on('click', function () { ordersPaymentForm.events.submit_pay(); });//加载数据
        this.controls.pay_cancel.on('click', function () { ordersPaymentForm.controls.payment_window.window('close'); });//加载数据
        //this.events.verifyright();
    },
    initControls: function () {
        ordersPaymentForm.controls = {
            pid: getUrlParam('pid'),
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form'),//查询表单
            payment_window: $('#payment_window'),
            payment_form: $('#payment_form'),
            pay_confirm: $('#btn_confirm_pay'),
            pay_cancel: $('#btn_cancel'),
            dgpayment: $('#dgpayment'),
            loading_window: $('#loading_window')
        }
        $('#btn_search_ok').linkbutton();
    },
    events: {
        loadData: function () {
            ordersPaymentForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'OrderID',
                url: '/ashx/ordershandler.ashx?Method=SearchOrders&Review=true&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: false,
                columns: [[
                        { field: 'cp', checkbox: true },
                        {
                            field: 'OrderNo', title: '订单编号', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详情" onClick="showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');">' + rowData['OrderNo'] + '</a>';
                                return strReturn;
                            }
                        },
                       { field: 'OrderType', title: '订单类型', width: 120, sortable: false, align: 'center' },
                       { field: 'CustomerName', title: '客户名称', width: 150, sortable: false, align: 'left', halign: 'center' },
                       { field: 'Address', title: '客户地址', width: 250, sortable: false, align: 'left', halign: 'center' },
                       { field: 'LinkMan', title: '联系人', width: 100, sortable: false, align: 'center' },
                       { field: 'Mobile', title: '联系电话', width: 100, sortable: false, align: 'center' },
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
                       {
                           field: 'Created', title: '创建时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                               if (value == undefined) return "";
                               return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                           }
                       },
                       { field: 'TotalAreal', title: '拆单面积', width: 100, sortable: false, align: 'center' },
                       { field: 'Amount', title: '费用', width: 100, sortable: false, align: 'center' },
                       {
                           field: 'Status', title: '订单状态', width: 100, sortable: false, align: 'center', formatter: function (value, row, index) {
                               return GetOrderStatusName(value);
                           }
                       }
                ]],
                toolbar: [
                    '-',
                  { text: '拆单确认', iconCls: 'money_yen', handler: ordersPaymentForm.events.payment_splitorder },
                ],
                onBeforeLoad: function (param) {
                    ordersPaymentForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersPaymentForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },
        payment_splitorder: function () {
            var selRows = ordersPaymentForm.controls.dgdetail.datagrid('getChecked');
            if (!selRows.length) {
                showError('请选择待确认的订单。');
                return;
            }
            var orderids = [];
            $.each(selRows, function (index, item) {
                orderids.push(item.OrderID);
            });
            ordersPaymentForm.controls.payment_form.find('#OrderIDs').val(orderids.join(','));
            $.messager.confirm('系统提示', '您确定要提交吗?', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/ordershandler.ashx?Method=GetPaymentOrders&' + jsNC(),
                        data: { OrderIDs: orderids.join(',') },
                        success: function (result) {
                            if (result) {
                                ordersPaymentForm.controls.payment_form.form('load', result.account);
                                ordersPaymentForm.controls.dgpayment.datagrid({
                                    sortName: 'Created',
                                    idField: 'OrderID',
                                    data: result.data,
                                    collapsible: false,
                                    fitColumns: true,
                                    pagination: false,
                                    striped: false,   //设置为true将交替显示行背景。
                                    showFooter: true,
                                    columns: [[
                                           { field: 'OrderNo', title: '订单编号', width: 150, align: 'center' },
                                           { field: 'OrderType', title: '订单类型', width: 120, sortable: false, align: 'center' },
                                           { field: 'CustomerName', title: '客户名称', width: 150, sortable: false, align: 'left', halign: 'center' },
                                           {
                                               field: 'ShipDate', title: '交货日期', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                                   if (value == undefined) return "";
                                                   var dt = (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                                                   if (dt === "")
                                                       return value;
                                                   else
                                                       return dt;
                                               }
                                           },
                                           {
                                               field: 'TotalAreal', title: '拆单面积', width: 100, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                                   if (value === "")
                                                       return "0";
                                                   else
                                                       return value;
                                               }
                                           },
                                           {
                                               field: 'Amount', title: '费用', width: 100, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                                   if (rowData.TotalAreal == 0) {
                                                       return '<span style="color:#f00;">￥0.00</span>';
                                                   }
                                                   else {
                                                       return '<span style="color:#f00;">￥' + (rowData.TotalAreal * 1.5).toFixed(2) + '</span>';
                                                   }
                                               }
                                           }
                                    ]]
                                });

                                var rows = ordersPaymentForm.controls.dgpayment.datagrid('getFooterRows');
                                rows[0]["ShipDate"] = "合计：";
                                rows[0]["TotalAreal"] = result.account.TotalAreal;
                                rows[0]["Amount"] = '<span style="color:#f00;">￥' + (result.account.TotalAreal * 1.5).toFixed(2) + '</span>';
                                ordersPaymentForm.controls.dgpayment.datagrid('reloadFooter');
                                ordersPaymentForm.controls.payment_window.window('open');
                            }
                        },
                        onLoadError: function () {
                        }
                    });

                }
            });
        },
        submit_pay: function () {
            ordersPaymentForm.controls.payment_form.form('submit', {
                url: '/ashx/ordershandler.ashx?Method=PaySplitmentOrders&' + jsNC(),
                data: ordersPaymentForm.controls.payment_form.serialize(),
                datatype: 'json',
                onSubmit: function () {
                    var isValid = ordersPaymentForm.controls.payment_form.form('validate');
                    if (!isValid) {
                        return isValid;
                    }
                    else {
                        ordersPaymentForm.controls.pay_confirm.linkbutton('disable');
                        ordersPaymentForm.controls.loading_window.window('open');
                        return isValid;
                    }
                },
                success: function (returnData) {
                    ordersPaymentForm.controls.pay_confirm.linkbutton('enable');
                    ordersPaymentForm.controls.loading_window.window('close');
                    returnData = eval('(' + returnData + ')');
                    if (returnData.isOk == 0) {
                        showError(returnData.message);
                    }
                    else {
                        ordersPaymentForm.controls.payment_window.window('close');
                        ordersPaymentForm.controls.dgdetail.datagrid('reload');
                    }
                },
                onLoadError: function () {
                    ordersPaymentForm.controls.loading_window.window('close');
                }
            });
        },
        verifyright: function () {
            $.ajax({
                url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + ordersPaymentForm.controls.pid,
                success: function (data) {
                    if (data) {
                        rightType(data);
                    }
                }
            });
        }
    }

};
function rightType(data) {
    $('div.datagrid-toolbar a').eq(0).hide();
    $('div.datagrid-toolbar div').eq(0).hide(); //隐藏第一条分隔线

    $(data).each(function (i, obj) {
        switch (obj.PrivilegeItemCode) {
            case 'OrderSplit':
                $('div.datagrid-toolbar a').eq(0).show();
                $('div.datagrid-toolbar div').eq(0).show(); //隐藏第一条分隔线
                break;
            default:
                break;
        }
    });
}

$(function () {
    ordersPaymentForm.init();
});

