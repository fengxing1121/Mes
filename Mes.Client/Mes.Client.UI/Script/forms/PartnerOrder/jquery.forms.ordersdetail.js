/*!
@Name：订单详情  
@Author：
@Remark：新增
@Date：2018-07-05
@License：MES  
*/
'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var ProductID = "";
var ordersdetailForm = {
    init: function () {
        ordersdetailForm.initControls();
        ordersdetailForm.events.loadTabs();

        //订单初审
        ordersdetailForm.controls.btn_confirm_open.on('click', ordersdetailForm.events.confirmorder_open);
        ordersdetailForm.controls.btn_confirm_ok.on('click', ordersdetailForm.events.confirmorder_submit);
        ordersdetailForm.controls.btn_confirm_reject.on('click', ordersdetailForm.events.confirmorder_reject);

        //一键导入
        ordersdetailForm.controls.btn_Import.on('click', ordersdetailForm.events.Importorder);
    },
    initControls: function () {
        ordersdetailForm.controls = {
            dgorder: $('#dgorder'),
            dgdetail: $('#dgdetail'),
            search_form: $('#search_form'),
            dgHardware: $('#dgHardware'),
            dgDrawing: $('#dgDrawing'),
            dgProcessFile: $('#dgProcessFile'),
            dgDoors: $('#dgdoors'),
            test_door: $('#test_door'),
            btn_refresh: $('#btn_refresh'),
            skpFile: $('#skpFile'),

            //订单初审
            confirm_window: $('#confirm_window'),
            confirm_form: $('#confirm_form'),
            btn_confirm_ok: $('#btn_confirm_ok'),
            btn_confirm_reject: $('#btn_confirm_reject'),
            btn_confirm_open: $('#btn_confirm_open'),

            //一键导入
            btn_Import: $('#btn_Import'),
        }

        $('#div_content').delegate('li', 'click', function () {
            var ProductName = $(this).text();
            $(this).parent().find('.active').removeClass("active");
            $(this).addClass("active");
            if (ProductName == "全部") ProductName = '';
            $('#CabinetNum').val(ProductName);
            ordersdetailForm.events.reload();
        });
    },
    events: {
        loadTabs: function () {
            //初始化数据   
            var orderid = getUrlParam('orderid');
            if (orderid.length == 0) return;
            $('#OrderID').val(orderid);
            $.ajax({
                url: '/ashx/PartnerOrderHandler.ashx?Method=GetPartnerOrder&' + jsNC(),
                data: { OrderID: orderid },
                datatype: "json",
                success: function (data) {
                    ordersdetailForm.controls.search_form.form('load', data);

                    $("#BookingDate").val(new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                    $("#ShipDate").val(new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));

                    if (!IsNullOrEmpty(data.AttachmentFile)) {
                        $("#downfile").attr("href", data.AttachmentFile).show();
                    }

                    var source = getUrlParam('source');
                    if (!IsNullOrEmpty(source)) {
                        switch (source) {
                            case "confirm":
                                if (data.StepNo != (GetOrderStepNo(partnerordersconfirm)-1)) {
                                    window.location.href = "/view/403.html";
                                    return;
                                }
                                ordersdetailForm.controls.btn_confirm_open.show();
                                break;
                            case "import":
                                if (data.StepNo != (GetOrderStepNo(importorder) - 1)) {
                                    window.location.href = "/view/403.html";
                                    return;
                                }
                                ordersdetailForm.controls.btn_Import.show();
                                break;
                        }
                    }
                }
            });
 
            ordersdetailForm.controls.dgorder.datagrid({
                sortName: 'Sequence',
                idField: 'ProductID',
                url: '/ashx/PartnerOrderHandler.ashx?Method=GetPartnerOrderProduct',
                collapsible: false,
                fitColumns: true,
                pagination: false,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    { field: 'ProductCode', title: '产品ID', width: 150, sortable: false, align: 'center' },
                    { field: 'ProductName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                    { field: 'ProductGroup', title: '产品编号', width: 150, sortable: false, align: 'center' },
                    { field: 'Size', title: '产品规格', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Color', title: '颜色', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'MaterialStyle', title: '风格', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'MaterialCategory', title: '材质', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Unit', title: '单位', width: 60, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Qty', title: '数量', width: 50, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Price', title: '单价', width: 80, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Remark', title: '备注', width: 150, sortable: false, halign: 'center', align: 'center' }
                ]],
                onBeforeLoad: function (param) {
                    param['OrderID'] = orderid;
                    param['ProductName'] = $('#CabinetNum').val();
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
        addrow: function () {
            if (ordersdetailForm.events.endEditing()) {
                ordersdetailForm.controls.dgDoors.datagrid('appendRow',
                    {
                        DoorID:ordersdetailForm.events.loadNewGuid(),
                        ProductID: ProductID,
                        ProductName:"请选择...",
                        DoorName: '左移门',
                        DoorSize: '1600*1200*600',                          
                        Qty: 1,
                          
                    });
                editIndex = ordersdetailForm.controls.dgDoors.datagrid('getRows').length - 1;
                ordersdetailForm.controls.dgDoors.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }
        },
        endEditing: function () {
            if (editIndex == undefined) { return true }
            if (ordersdetailForm.controls.dgDoors.datagrid('validateRow', editIndex)) {
                ordersdetailForm.controls.dgDoors.datagrid('endEdit', editIndex);
                if (!ordersdetailForm.events.isRepeartRow()) {
                    editIndex = undefined;
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        },
        isRepeartRow: function () {
            var rows = ordersdetailForm.controls.dgDoors.datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                for (var j = i + 1; j < rows.length; j++) {
                    if (rows[i].ProductID == rows[j].ProductID  ) {
                        if (rows[i].DoorName == rows[j].DoorName) {
                            showError("产品【" + rows[i].ProductName + "】的【" + rows[i].DoorName + "】重复添加");
                            return false;
                        }
                    }
                }
            }
            return false;
        },
        cancelall: function () {
            ordersdetailForm.controls.dgDoors.datagrid('rejectChanges');
        },
        onClickCell: function (index, field) {
            if (editIndex != index) {
                if (ordersdetailForm.events.endEditing()) {
                    ordersdetailForm.controls.dgDoors.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = ordersdetailForm.controls.dgDoors.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }
                    editIndex = index;
                } else {
                    setTimeout(function () {
                        ordersdetailForm.controls.dgDoors.datagrid('selectRow', editIndex);
                    }, 0);
                }
            }
        },
        onEndEdit: function (index, row) {
            var ed = $(this).datagrid('getEditor', {
                index: index,
                field: 'ProductName'
            });
            row.ProductName = $(ed.target).combobox('getText');
            row.ProductID = ProductID;
        },
        reload: function () {
            ordersdetailForm.controls.dgdetail.datagrid('reload');
            ordersdetailForm.controls.dgHardware.datagrid('reload');
            ordersdetailForm.controls.dgDrawing.datagrid('reload');
            ordersdetailForm.controls.dgProcessFile.datagrid('reload');
        },
        //订单初审
        confirmorder_open: function () {
            ordersdetailForm.controls.confirm_window.window('open');
            $('#Remark').val('');
        },
        confirmorder_submit: function () {
            ordersdetailForm.events.ConfirmOrder(true);
        },
        confirmorder_reject: function () {
            ordersdetailForm.events.ConfirmOrder(false);
        },
        ConfirmOrder: function (ConfirmState) {
            if (ordersdetailForm.controls.confirm_form.form('validate')) {
                $.ajax({
                    url: '/ashx/PartnerOrderHandler.ashx?Method=OrdersConfirm',
                    data: { OrderID: $("#OrderID").val(), Remark: $('#option_remark').val(), ConfirmState: ConfirmState },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 0) {
                                showError(returnData.message);
                            }
                            else {
                                $.messager.alert("提示", "审核成功", "info", function () {
                                    var currTab = top.$(".tabs").find(".tabs-selected").text();
                                    top.closeTab(currTab);
                                });
                            }
                        }
                    }
                });
            }
        },
        //一键导入
        Importorder: function () {
            $.messager.confirm('系统提示', '您确定要导入该订单吗?', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/PartnerOrderHandler.ashx?Method=ImportPartnerOrder',
                        data: { OrderID: $("#OrderID").val() },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    $.messager.alert("提示", "导入成功", "info", function () {
                                        var currTab = top.$(".tabs").find(".tabs-selected").text();
                                        top.closeTab(currTab);
                                    });
                                }
                            }
                        }
                    });
                }
            });
        },
    }
};
$(function () {
    ordersdetailForm.init();
});

function cancelrow(id,index) {
    if (ordersdetailForm.events.endEditing()) {
        if (index == undefined) { return }
        $('#dgdoors').datagrid('deleteRow', index);
        var rows = $('#dgdoors').datagrid("getRows");
        $('#dgdoors').datagrid("loadData", rows);
        index = undefined;
    }
    $.ajax({
        url: '/ashx/PartnerOrderHandler.ashx?Method=DeleteByDoorID&' + jsNC(),
        data: { DoorID: id },
        datatype: "json",
    });
}