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
        addorderForm.events.loadCabinet(getUrlParam('componentid'));
    },
    initControls: function () {
        addorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            edit_form: $('#edit_form'),
        }

    },
    events: {
        //添加产品
        loadCabinet: function (ComponentID) {
            addorderForm.controls.dgcabinet.datagrid({
                idField: 'ID',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                pageSize: 20,
                striped: false,
                showFooter: false,
                url: '/ashx/WorkOrderHandler.ashx?Method=SearchProductComponents&' + jsNC(),
                columns: [[
                    { field: 'MaterialCode', title: '物料编码', width: 100, align: 'center' },
                    { field: 'MaterialName', title: '名称', width: 50, sortable: false, align: 'center' },
                    { field: 'Specification', title: '规格', width: 100, sortable: false, align: 'center' },
                    { field: 'Unit', title: '单位', width: 100, sortable: false, align: 'center' },
                    { field: 'Quantity', title: '用量', width: 100, sortable: false, align: 'center' },
                    { field: 'PlateName', title: '板件名称', width: 100, sortable: false, align: 'center' },
                    { field: 'Material', title: '材质', width: 120, sortable: false, align: 'center' },
                    { field: 'Color', title: '颜色', width: 100, sortable: false, align: 'center' },
                    { field: 'Length', title: '长', width: 70, sortable: false, align: 'center' },
                    { field: 'Width', title: '宽', width: 70, sortable: false, align: 'center' },
                    { field: 'Height', title: '高', width: 70, sortable: false, align: 'center' },
                    { field: 'Routing', title: '工艺路线', width: 100, sortable: false, align: 'center' },
                ]],
                //groupField: 'ComponentTypeName',
                //view: groupview,
                //groupFormatter: function (value, rows) {
                //    return value;
                //},
                onBeforeLoad: function (param) {
                    param["ComponentID"] = ComponentID;
                },
            });
        },
        loadOrder: function () {
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
                    $("#OrderNo").attr("disabled", "disabled");
                    $("#ProductionOrderNo").val(getUrlParam('produceno'));
                }
            });
        },
    }
};


$(function () {
    addorderForm.init();

    setTimeout(function () {
        $(".tooltip-right").hide();
    }, 500);

});