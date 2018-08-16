/*!
 @Name：新增销售订单
 @Author：
 @Remark：新增
 @Date：2018-07-05
 @License：MES  
 */
'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var addorderForm = {
    init: function () {
        addorderForm.initControls();     
        addorderForm.events.loadOrder();
        addorderForm.controls.saveorder.on('click', addorderForm.events.saveorder);//保存 
        addorderForm.controls.cancelorder.on('click', addorderForm.events.reload);
        addorderForm.controls.searchCustomer.on('click', addorderForm.events.searchCustomer);//查询客户
        //addorderForm.events.createneworder();
        addorderForm.events.loadCabinet("");
    },
    initControls: function () {
        addorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            edit_form: $('#edit_form'),
            saveorder: $('#btn_edit_save'),
            cancelorder: $('#btn_edit_cancel'),
            searchCustomer: $('#btn_search_customer')//查询客户
        }
        
    },
    events: {
        //添加产品
        loadCabinet: function (OrderID) {
            addorderForm.controls.dgcabinet.datagrid({
                idField: 'ProductID',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                pageSize: 20,
                striped: false,
                showFooter: false,
                url: '/ashx/ProductionOrderHandler.ashx?Method=SearchProductComponents&' + jsNC(),
                columns: [[
                    { field: 'ComponentID', title: '序号', hidden: true, width: 0, sortable: false, align: 'center' },
                    { field: 'ComponentCode', title: '成品编号', width: 50, sortable: false, align: 'center' },
                    { field: 'ComponentTypeName', title: '名称', width: 100, sortable: false, align: 'center' },
                    { field: 'Quantity', title: '数量', width: 150, sortable: false, align: 'center' },
                    { field: 'Amount', title: '面积(㎡)', width: 100, sortable: false, align: 'center' },
                ]],
                groupField: 'ProductName',
                view: groupview,
                groupFormatter: function (value, rows) {
                    return value + ' - ' + rows.length + ' Item(s)';
                },
                onBeforeLoad: function (param) {
                    param["OrderID"] = OrderID;
                },
            });
        },
        loadOrder: function () {
            var produceno = getUrlParam('produceno');
            if (IsNullOrEmpty(produceno)) {
                addorderForm.controls.saveorder.show();
                addorderForm.controls.cancelorder.show();

                $('#OrderNo').combogrid({
                    panelWidth: 640,
                    panelHeight: 480,
                    sortName: 'Created',
                    idField: 'OrderID',
                    url: '/ashx/ProductionOrderHandler.ashx?Method=SearchOrders&' + jsNC(),
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    frozenColumns: [[
                    {
                        field: 'OrderNo', title: '订单编号', width: 130, align: 'center',
                    },
                    ]],
                    columns: [[
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
                            field: 'Status', title: '订单状态', width: 160, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细"><span>' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                                return strReturn;
                            }
                        }
                    ]],
                    onSelect: function (index, row) {
                        addorderForm.controls.edit_form.form('load', row);
                        $("#BookingDate").val(new Date(removeCN(row.BookingDate)).Formats('yyyy-MM-dd'));
                        $("#ShipDate").val(new Date(removeCN(row.ShipDate)).Formats('yyyy-MM-dd'));
                        addorderForm.events.loadCabinet(row.OrderID);
                    }
                });
            }
            else {
                var orderid = getUrlParam('orderid');
                if (orderid.length == 0) return;
                $('#OrderID').val(orderid);
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                    data: { OrderID: orderid },
                    datatype: "json",
                    success: function (row) {
                        addorderForm.controls.edit_form.form('load', row);
                        $("#BookingDate").val(new Date(removeCN(row.BookingDate)).Formats('yyyy-MM-dd'));
                        $("#ShipDate").val(new Date(removeCN(row.ShipDate)).Formats('yyyy-MM-dd'));
                        addorderForm.events.loadCabinet(row.OrderID);
                        $("#OrderNo").attr("disabled", "disabled");
                        $("#ProductionOrderNo").val(getUrlParam('produceno'));
                    }
                });
            }
        },
        //保存
        saveorder: function () {
            var rows = addorderForm.controls.dgcabinet.datagrid('getRows');
            var kv = [];
            if (rows.length == 0) {
                showError("订单未导入制成品信息");
                return;
            }
            for (var i = 0; i < rows.length; i++) {
                kv.push({
                    ComponentID: rows[i].ComponentID,
                });
            };
            var sd = JSON.stringify(kv);
            $('#Cabinets').val(sd);
            addorderForm.controls.edit_form.form('submit', {
                url: '/ashx/ProductionOrderHandler.ashx?Method=SaveProductionOrder&' + jsNC(),
                data: addorderForm.controls.edit_form.serialize(),
                datatype: 'json',
                onSubmit: function () {
                    var isValid = addorderForm.controls.edit_form.form('validate');
                    if (!isValid) {
                        return isValid;
                    }
                    else {
                        $('#btn_edit_save').linkbutton('disable');
                        return isValid;
                    }
                },
                success: function (returnData) {
                    $('#btn_edit_save').linkbutton('enable');
                    returnData = eval('(' + returnData + ')');
                    if (returnData.isOk == 0) {
                        showError(returnData.message);
                    }
                    else {
                        showInfo("生产成功！");
                        addorderForm.events.createneworder();
                        addorderForm.events.loadOrder();
                    }
                }
            });
        },
        createneworder: function () {
            addorderForm.controls.edit_form.form('clear');
            $('#search_form_customer').form('clear');//清空客户列表查询项
            addorderForm.controls.dgcabinet.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
            $("#OrderID").val(addorderForm.events.loadNewGuid());
            $('#OrderNo').combogrid("grid").datagrid("reload", {});
        },
        reload: function () {
            $.messager.confirm('系统提示', '您确定要清空所有填订单信息?', function (flag) {
                if (flag) {
                    addorderForm.events.createneworder();
                }
            });
        },
        loadNewGuid: function () {
            var guid = " ";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            return guid;
        },
        searchCustomer: function () {
            $('#OrderNo').combogrid("grid").datagrid("reload");
        }
    }
};


$(function () {
    addorderForm.init();

    setTimeout(function () {
        $(".tooltip-right").hide();
    }, 500);

});