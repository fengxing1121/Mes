/*!
 @Name：改单申请
 @Author：刘胜伟
 @Remark：新增
 @Date：2018-03-06
 @License：MES  
 */

'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var editorderForm = {
    init: function () {
        editorderForm.initControls();
        editorderForm.events.loadCabinet();
    },
    initControls: function () {
        editorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            searchorder: $('#btn_searchorder'),
            edit_form: $('#edit_form'),
        }
    },
    events: {
        loadCabinet: function () {
            $("#OrderNo").val(getUrlParam('OrderNo'));
            var OrderNo = $("#OrderNo").val();

            if (IsNullOrEmpty(OrderNo)) {
                showError("参数错误");
                return;
            }
            editorderForm.controls.dgcabinet.datagrid({
                sortName: 'Sequence',
                idField: 'CabinetID',
                collapsible: false,
                url: '/ashx/ordershandler.ashx?Method=GetCabinets',
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                //{
                //    field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center', editor: {
                //        type: 'combobox',
                //        options: {
                //            valueField: 'CategoryName',
                //            textField: 'CategoryName',
                //            method: 'get',
                //            url: '/ashx/categoryhandler.ashx?Method=GetCabinetName',
                //            required: true
                //        }
                //    }
                //},
                {
                    field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center'
                },
                {
                    field: 'Size', title: '成品尺寸', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            //required: true
                        }
                    }
                },

                {
                    field: 'Color', title: '材质颜色', width: 120, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetColorType'
                            //required: true
                        }
                    }
                },
                {
                    field: 'MaterialStyle', title: '材质风格', width: 120, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        required: true,
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetMaterialStyle',
                            required: true
                        }
                    }
                },
                //{
                //    field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center', editor: {
                //        type: 'combobox',
                //        required: true,
                //        options: {
                //            valueField: 'CategoryName',
                //            textField: 'CategoryName',
                //            method: 'get',
                //            url: '/ashx/categoryhandler.ashx?Method=GetMaterialCategory'
                //            //required: true
                //        }
                //    }
                //},
                {
                    field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center'
                },
                //{
                //    field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center', editor: {
                //        type: 'combobox',
                //        required: true,
                //        options: {
                //            valueField: 'CategoryName',
                //            textField: 'CategoryName',
                //            method: 'get',
                //            url: '/ashx/categoryhandler.ashx?Method=GetUnitCategory'
                //        }
                //    }
                //},
                {
                    field: 'Unit', title: '单位', width: 60, sortable: false, align: 'center'
                },
                {
                    field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center'
                },
                {
                    field: 'Remark', title: '申请详情', width: 105, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" onClick="loadOrder2CabinetLogs(\'' + rowData['CabinetID'] + '\');"><span style="color:#0094ff;">' + (rowData['applyCount'] > 0 ? rowData['applyCount'] + '次(查看)' : '') + '</span></a>';
                        return strReturn;
                    }
                },
                //{
                //    field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center', editor: {
                //        type: 'numberbox',
                //        options: {
                //            required: true,
                //            precision: 2
                //        }
                //    },
                //},
                //{
                //    field: 'Price', title: '单价', width: 80, sortable: false, align: 'center', editor: {
                //        type: 'numberbox',
                //        options: {
                //            required: true,
                //            min: 0
                //        }
                //    }
                //},
                //{
                //    field: 'Price', title: '单价', width: 80, sortable: false, align: 'center'
                //},
                //{
                //    field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center', editor: {
                //        type: 'textbox',
                //        options: {
                //            //required: true
                //        }
                //    }
                //},
                //{
                //    field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center'
                //},
                {
                    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                    formatter: function (value, row, index) {
                        console.log(row['ReviewedStatus'].trim());
                        if (row['ReviewedStatus'].trim() == 'N') {
                            var str = "";

                            str += $.formatstring('<a href="javascript:void(0)" data-row="btnUpdate_{0}" onclick="applyUpdate({1});" ><span class="icon pencil_add">&nbsp;&nbsp;</span>改单</a>', [index, index]);
                            str += $.formatstring('<a href="javascript:void(0)" data-row="btnDel_{0}"  onclick="applyDelete(\'{1}\',\'{2}\');" ><span class="icon pencil_delete">&nbsp;&nbsp;&nbsp;</span>消单</a>', [index, row['CabinetID'], row['OrderID']]);

                            str += $.formatstring('<a hidden href="javascript:void(0)" data-row="btnSave_{0}" onclick="editorderForm.events.saveUpdate(\'{1}\',\'{2}\');" ><span class="icon disk_multiple">&nbsp;&nbsp;</span>保存</a>', [index, row.id, index]);
                            str += $.formatstring('<a hidden href="javascript:void(0)" data-row="btnCancel_{0}" onclick="revoke(\'{1}\',\'{2}\');" ><span class="icon cancel">&nbsp;&nbsp;</span>取消</a>', [index, row.id, index]);
                            //console.log(str);

                            return str;
                        }
                        return GetCabinetStatusName(row['ReviewedStatus']);
                    }
                },
                ]],

                onBeforeLoad: function (param) {
                    param['OrderID'] = OrderNo;
                    param['OrderNo'] = OrderNo;
                },
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        var body = $(this).data().datagrid.dc.body2;
                        body.find('table tbody').append('<tr><td colspan="12" style="height: 35px;border-left: #ccc dotted 1px; text-align: center;"><h1>暂无订单产品记录</h1></td></tr>');
                        $(".datagrid-toolbar").hide();
                    }
                    else {
                        $(".datagrid-toolbar").show();
                    }
                },
                //toolbar: [
                //    { text: '增加', iconCls: 'icon-add', handler: editorderForm.events.addrow },
                //    { text: '取消', iconCls: 'icon-cancel', handler: editorderForm.events.cancelall }
                //],
                //onClickCell: editorderForm.events.onClickCell,
                //onEndEdit: editorderForm.events.onEndEdit

            });
        },
        //申请改单
        saveUpdate: function (id, rowIndex) {
            if (editorderForm.events.endEditing()) {
                editorderForm.controls.dgcabinet.datagrid('acceptChanges');
            }
            var rows = editorderForm.controls.dgcabinet.datagrid('getData').rows[rowIndex];
            //console.log(JSON.stringify(rows));
            var kv = [];
            kv.push({
                CabinetID: rows.CabinetID,
                CabinetName: rows.CabinetName,
                Size: rows.Size,
                MaterialStyle: rows.MaterialStyle,
                Qty: rows.Qty,
                Price: rows.Price,
                Color: rows.Color,
                MaterialCategory: rows.MaterialCategory,
                Unit: rows.Unit,
                Remark: rows.Remark
            });
            console.log(JSON.stringify(kv));
            $("#Cabinets").val(JSON.stringify(kv));
            $.messager.confirm('系统提示', '修改产品后需生产办审核，您确实要修改?', function (flag) {
                if (flag) {
                    $.ajax({
                        type: "post",
                        dataType: "json",
                        data: { Cabinets: $("#Cabinets").val(), OrderNo: $("#OrderNo").val(), OprationType: "applyUpdate" },
                        url: '/ashx/ordershandler.ashx?Method=UpdateCabinetStatus&' + jsNC(),
                        success: function (objdata) {
                            if (objdata.message == '') {
                                showInfo("改单申请已提交，请等待生产审核！");
                                editorderForm.events.loadCabinet();
                            }
                            else {
                                showError(objdata.message);
                            }
                        },
                        error: function (e) {
                            alert(JSON.stringify(e));
                        }
                    });
                }
                else {
                    editorderForm.events.loadCabinet();
                }
            });
        },


        addrow: function () {
            if (editorderForm.events.endEditing()) {
                editorderForm.controls.dgcabinet.datagrid('appendRow', { Qty: 1, Price: 0 });//editorderForm.events.loadNewGuid()
                editIndex = editorderForm.controls.dgcabinet.datagrid('getRows').length - 1;
                editorderForm.controls.dgcabinet.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }
        },

        endEditing: function () {
            if (editIndex == undefined) { return true }
            if (editorderForm.controls.dgcabinet.datagrid('validateRow', editIndex)) {
                editorderForm.controls.dgcabinet.datagrid('endEdit', editIndex);
                if (!editorderForm.events.isRepeartRow()) {
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

        },
        //取消所有行
        cancelall: function () {
            editorderForm.controls.dgcabinet.datagrid('rejectChanges');
        },


        onClickCell: function (index, field) {
            if (field == "action") return;
            if (editorderForm.events.endEditing()) {
                editorderForm.controls.dgcabinet.datagrid('selectRow', index).datagrid('beginEdit', index);
                var ed = editorderForm.controls.dgcabinet.datagrid('getEditor', { index: index, field: field });
                if (ed) {
                    ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                }
                editIndex = index;

                $("a[data-row='btnUpdate_" + index + "']").attr("hidden", true);
                $("a[data-row='btnDel_" + index + "']").attr("hidden", true);
                $("a[data-row='btnSave_" + index + "']").removeAttr("hidden");
                $("a[data-row='btnCancel_" + index + "']").removeAttr("hidden");
            } else {
                setTimeout(function () {
                    editorderForm.controls.dgcabinet.datagrid('selectRow', editIndex);
                }, 0);
            }
        },

        onEndEdit: function (index, row) {
            //var ed = $(this).datagrid('getEditor', {
            //    index: index,
            //    field: 'CabinetName'
            //});
            //row.CabinetName = $(ed.target).combobox('getText');
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
            $('#CustomerID').combogrid("grid").datagrid("reload");
        },
    }
};

function revoke(id, rowIndex) {
    editorderForm.controls.dgcabinet.datagrid('cancelEdit', rowIndex);
    $("a[data-row='edit_" + rowIndex + "']").linkbutton({ text: '双击行数据更改', plain: true, iconCls: 'icon-edit' });
};
//申请消单
function applyDelete(CabinetID, OrderID) {
    $.messager.confirm('系统提示', '确定要取消该订单?', function (flag) {
        if (flag) {
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=UpdateCabinetStatus&' + jsNC(),
                data: { CabinetID: CabinetID, OrderID: OrderID, OprationType: 'applyDelete' },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 1) {
                        showInfo("消单申请已提交，请等待生产审核！");
                        editorderForm.events.loadCabinet();
                    }
                    else {
                        showError(data.message);
                    }
                }
            });
        }
    });

}

$(function () {
    editorderForm.init();
});

function applyUpdate(index) {
    editorderForm.events.onClickCell(index, "Color")
}

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
        { field: 'OldSize', title: '申请尺寸', width: 120, sortable: false, align: 'center' },
        { field: 'OldColor', title: '申请颜色', width: 120, sortable: false, align: 'center' },
        { field: 'OldMaterialStyle', title: '申请风格', width: 120, sortable: false, align: 'center' },
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