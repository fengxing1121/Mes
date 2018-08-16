'use strict';
document.msCapsLockWarningOff = true;
var ordersSplitForm = {
    init: function () {
        ordersSplitForm.initControls();
        ordersSplitForm.controls.searchData.on('click', function () { ordersSplitForm.controls.dgdetail.datagrid('reload'); });//加载数据
        ordersSplitForm.controls.returnorder.on('click', ordersSplitForm.events.returnorder);//退回订单
        ordersSplitForm.controls.applyorder.on('click', ordersSplitForm.events.applyorder);//弹窗的手工拆单
        ordersSplitForm.events.loadData();
        ordersSplitForm.events.loadCabinet();
        ordersSplitForm.events.verifyright();
    },
    initControls: function () {
        ordersSplitForm.controls = {
            pid: getUrlParam('pid'),
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            dgcabinet: $('#dgcabinet'),
            search_form: $('#search_form'),//查询表单
            edit_window: $('#edit_window'),
            edit_form: $('#edit_form'), 
            returnorder: $('#btn_edit_return'),//退回订单
            applyorder: $('#btn_edit_applyorder'),
            steps_window: $('#steps_window')
        }
        $('#btn_search_ok').linkbutton()
    },
    events: {
        loadData: function () {
            ordersSplitForm.controls.dgdetail.datagrid({
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
                        //{ field: 'cp', checkbox: true },
                        {
                            field: 'actiom', title: '操作', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['OrderID'] + '\');">' + "审核" + '</a>';
                                return strReturn;
                            }
                        },
                        {
                            field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详情" onClick="uploadfile(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');">' + rowData['OrderNo'] + '</a>';
                                return strReturn;
                            }
                        },
                       { field: 'PurchaseNo', title: '采购单号', width: 105, sortable: false, align: 'center' },
                        { field: 'CabinetType', title: '产品类型', width: 60, sortable: false, align: 'center' },
                       { field: 'OrderType', title: '订单类型', width: 60, sortable: false, align: 'center' },
                       { field: 'CustomerName', title: '客户名称', width: 85, sortable: false, align: 'center', halign: 'center' },
                       //{ field: 'Address', title: '客户地址', width: 220, sortable: false, align: 'center', halign: 'center' },
                       { field: 'LinkMan', title: '联系人', width: 70, sortable: false, align: 'center' },
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
                       //{
                       //    field: 'Created', title: '创建时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                       //        if (value == undefined) return "";
                       //        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                       //    }
                       //},
                       {
                           field: 'IsStandard', title: '是否正标', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                               if (value == undefined) return "";
                               if (value == "True")
                                   return "是";
                               else
                                   return "否";

                           }
                       },
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
                       }
                ]],
                toolbar: [
                    '-',
                  //{ text: '手工拆单', iconCls: 'shape_group', handler: ordersSplitForm.events.applyorder }
                  //'-',
                  //{ text: '云拆单', iconCls: 'shape_move_back', handler: ordersSplitForm.events.auto_split_order }
                ],
                onBeforeLoad: function (param) {
                    ordersSplitForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersSplitForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },

        loadCabinet: function () {
            ordersSplitForm.controls.dgcabinet.datagrid({
                sortName: 'Sequence',
                idField: 'CabinetID',
                url: '/ashx/ordershandler.ashx?Method=GetCabinets',
                collapsible: false,
                fitColumns: true,
                pagination: false,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                { field: 'Size', title: '成品尺寸', width: 120, sortable: false, halign: 'center', align: 'center' },
                { field: 'MaterialStyle', title: '材质风格', width: 100, sortable: false, halign: 'center', align: 'center' },
                { field: 'Color', title: '材质颜色', width: 100, sortable: false, halign: 'center', align: 'center' },
                { field: 'MaterialCategory', title: '材质类型', width: 100, sortable: false, halign: 'center', align: 'center' },
                { field: 'Qty', title: '数量', width: 60, sortable: false, halign: 'center', align: 'center' },
                { field: 'Unit', title: '单位', width: 50, sortable: false, halign: 'center', align: 'center' },
                { field: 'Price', title: '单价', width: 80, sortable: false, halign: 'center', align: 'center' },
                { field: 'Remark', title: '备注', width: 150, sortable: false, halign: 'center', align: 'center' }
                ]],
                onBeforeLoad: function (param) {
                    param["OrderID"] = ordersSplitForm.controls.edit_form.find('#OrderID').val();
                }
            });
        },

        applyorder: function () {
            var selRows = ordersSplitForm.controls.dgdetail.datagrid('getChecked');
            if (!selRows.length) {
                showError('请选择订单。');
                return;
            }
            var orderids = [];
            $.each(selRows, function (index, item) {
                orderids.push(item.OrderID);
            });

            $.messager.confirm('系统提示', '您确定要提交拆单申请吗?', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/ordershandler.ashx?Method=SplitOrders',
                        data: { OrderIDs: orderids.join(',') },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    $('#edit_window').window('close');
                                    ordersSplitForm.controls.dgdetail.datagrid('reload');
                                }
                            }
                        }
                    });
                }
            });

        },
        auto_split_order: function () {
            var selRows = ordersSplitForm.controls.dgdetail.datagrid('getChecked');
            if (!selRows.length) {
                showError('请选择订单。');
                return;
            }
            var orderids = [];
            $.each(selRows, function (index, item) {
                orderids.push(item.OrderID);
            });
            $.messager.confirm('系统提示', '您确定要提交云拆单申请吗?</br>提示：云拆单将按平方收取拆单费用。', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/ordershandler.ashx?Method=SplitOrdersAuto',
                        data: { OrderIDs: orderids.join(',') },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    ordersSplitForm.controls.dgdetail.datagrid('reload');
                                }
                            }
                        }
                    });
                }
            });
        },

        returnorder: function () {
            var orderid = $('#OrderID').val();
            $.messager.confirm('系统提示', '您确定要退回该订单吗?', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/ordershandler.ashx?Method=ReturnSplitOrder',
                        data: { OrderID: orderid },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    $('#edit_window').window('close');
                                    ordersSplitForm.controls.dgdetail.datagrid('reload');
                                }
                            }
                        }
                    });
                }
            });
        },

        //获取权限
        verifyright: function () {
            $.ajax({
                url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + ordersSplitForm.controls.pid,
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
            case 'HandSplit':
                $('div.datagrid-toolbar a').eq(0).show();
                $('div.datagrid-toolbar div').eq(0).show(); //第一条分隔线
                break;            
            default:
                break;
        }
    });
}
   

$(function () {
    ordersSplitForm.init();
});

function showdetail(id) {
    top.addTab("订单审核", "/View/orders/ordersreview.aspx?OrderID=" + id + "&" + jsNC(), 'table');
}

//查看详情        
function uploadfile(id, no) {
    $('#edit_form').form('clear');
    //初始化数据
    $.ajax({
        url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
        data: { OrderID: id },
        datatype: "json",
        async: false,
        success: function (data) {
            $('#edit_form').form('load', data);
            $("#Statu").val(GetOrderStatusName(data.Status));//转换订单状态中文名称
            $('#edit_form').find('input').each(function (index) {
                $(this).addClass('easyui-readonly');
                $('#BookingDate').val(new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                $('#ShipDate').val(new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));
                if (data.IsStandard == true) {
                    $('#IsStandard').val("是")
                } else {
                    $('#IsStandard').val("否")
                }
                if (data.IsOutsourcing == true) {
                    $('#IsOutsourcing').val("是")
                } else {
                    $('#IsOutsourcing').val("否")
                }
                if (('P,F,I,O').indexOf(data.Status) < 0) {
                    $('#ManufactureDate').val("未开始");
                }
                else {
                    $('#ManufactureDate').val(new Date(removeCN(data.ManufactureDate)).Formats('yyyy-MM-dd'));
                }
            });
        }
    });
    $('#dgcabinet').datagrid('reload');
    $('#edit_window').window('open');
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