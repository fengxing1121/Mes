/*!
 @Name：新增订单  
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
        addorderForm.events.loadCabinet();//加载数据          
        addorderForm.events.loadCustomer();
        addorderForm.controls.saveorder.on('click', addorderForm.events.saveorder);//保存 
        addorderForm.controls.cancelorder.on('click', addorderForm.events.reload);
        addorderForm.controls.searchCustomer.on('click', addorderForm.events.searchCustomer);//查询客户
        addorderForm.events.createneworder();
        addorderForm.events.OrderType();
    },
    initControls: function () {
        addorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            edit_form: $('#edit_form'),
            saveorder: $('#btn_edit_save'),
            cancelorder: $('#btn_edit_cancel'),
            searchCustomer: $('#btn_search_customer')//查询客户
        }
        var mydate = new Date();
        var yy = mydate.getFullYear();
        var mm = mydate.getMonth() + 1;
        var dd = mydate.getDate();
        var NowDay = yy + '-' + (mm < 10 ? ('0' + mm) : mm) + '-' + (dd < 10 ? ('0' + dd) : dd);
        $("#BookingDate").val(NowDay);//默认当天

        //订货日期
        $('#BookingDate').datebox({
            onSelect: function (date) {
                $("#ShipDate").datebox("setValue", '');
            }
        });
        //交货日期
        $('#ShipDate').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var ShipDate = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var BookingDate = $("#BookingDate").datebox("getValue");
                if (BookingDate == "") {
                    showError("请选择订货日期！");
                    $('#ShipDate').datebox("setValue", '');
                }
                if (BookingDate > ShipDate) {
                    showError("交货日期不能小于订货日期！");
                    $('#ShipDate').datebox("setValue", '');
                }
            }
        });
    },
    events: {
        //添加产品
        loadCabinet: function () {
            addorderForm.controls.dgcabinet.datagrid({
                idField: 'ProductID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'ProductID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                {
                    field: 'ProductName', title: '产品名称', width: 150, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetCabinetName',
                            required: true,
                            onSelect: function (obj) {
                                var ed = addorderForm.controls.dgcabinet.datagrid('getEditor', { index: editIndex, field: "ProductGroup" });
                                if (ed) {
                                    $(ed.target).textbox("setValue", obj.CategoryCode);
                                    console.log($(ed.target).val())
                                }

                            }
                        },
                    }
                },
                {
                    field: 'ProductGroup', title: '产品编号', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            required: true,
                        }
                    }
                },
                {
                    field: 'Size', title: '产品规格', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            //required: true
                        }
                    }
                },
                {
                    field: 'Color', title: '颜色', width: 120, sortable: false, align: 'center', editor: {
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
                    field: 'MaterialStyle', title: '风格', width: 120, sortable: false, align: 'center', editor: {
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
                {
                    field: 'MaterialCategory', title: '材质', width: 120, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        required: true,
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetMaterialCategory'
                            //required: true
                        }
                    }
                },
                {
                    field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        required: true,
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetUnitCategory'
                        }
                    }
                },
                {
                    field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center', editor: {
                        type: 'numberbox',
                        options: {
                            required: true,
                            precision: 2
                        }
                    },
                },
                {
                    field: 'Price', title: '单价', width: 80, sortable: false, align: 'center', editor: {
                        type: 'numberbox',
                        options: {
                            required: true,
                            min: 0
                        }
                    }
                },
                {
                    field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            //required: true
                        }
                    }
                },
                {
                    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                    formatter: function (value, row, index) {

                        var str = '<a href="#" onclick="cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        str += '<a href="#" onclick="copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                        return str;
                    }
                }
                ]],
                toolbar: [
                    { text: '增加', iconCls: 'icon-add', handler: addorderForm.events.addrow },
                    { text: '取消', iconCls: 'icon-cancel', handler: addorderForm.events.cancelall },
                    //{ text: '复制', iconCls: 'icon-add', handler: addorderForm.events.copyrow },
                ],
                onClickCell: addorderForm.events.onClickCell,
                onEndEdit: addorderForm.events.onEndEdit
            });
        },
        OrderType: function () {
            $('#OrderType').combobox({
                valueField: 'CategoryName',
                textField: 'CategoryName',
                method: 'get',
                url: '/ashx/categoryhandler.ashx?Method=GetOrderType',
                required: true,
            });
        },
        loadCustomer: function () {
            $('#CustomerID').combogrid({
                panelWidth: 640,
                panelHeight: 480,
                idField: 'CustomerID',
                textField: 'CustomerName',
                fitColumns: true,
                sortName: 'CustomerID',
                toolbar: '#tb',
                url: '/ashx/customerhandler.ashx?Method=SearchCustomers',
                pagination: true,
                editable: false,
                nowrap: false,
                columns: [[
                        { field: 'PartnerName', title: '门店名称', width: 100, align: 'center' },
                        { field: 'CustomerName', title: '客户名称', width: 100, align: 'center' },
                        { field: 'Mobile', title: '移动电话', width: 80, sortable: false, align: 'center' },
                        {
                            field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                return (row.Province) + (row.City) + row.Address;
                            }
                        },  
                ]],
                onBeforeLoad: function (param) {
                    $('#search_form_customer').find('input').each(function (index) { param[this.name] = $(this).val(); });
                },
                onSelect: function (index, row) {
                    $('#H_CustomerID').val(row.CustomerName);
                    addorderForm.controls.edit_form.form('load', row);
                    $("#Address").val(row.Province + row.City + row.Address);
                }
            });

        },
        //保存
        saveorder: function () {
            if (addorderForm.events.endEditing()) {
                addorderForm.controls.dgcabinet.datagrid('acceptChanges');
            }
            var rows = addorderForm.controls.dgcabinet.datagrid('getRows');
            var kv = [];
            if (rows.length == 0) {
                showError("最少需要添加一个订单产品。");
                return;
            }
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].Qty == 0) {
                    showError("产品数量不能为0");
                    return;
                }
                kv.push({
                    ProductID: rows[i].ProductID,
                    ProductGroup: rows[i].ProductGroup,
                    ProductName: rows[i].ProductName,
                    Size: rows[i].Size,
                    MaterialStyle: rows[i].MaterialStyle,
                    MaterialCategory: rows[i].MaterialCategory,
                    Qty: rows[i].Qty,
                    Price: rows[i].Price,
                    Color: rows[i].Color,                   
                    Unit: rows[i].Unit,
                    Remark: rows[i].Remark
                });
            }
            //序列化对象为Json字符串
            var sd = JSON.stringify(kv);
            $('#Cabinets').val(sd);
            addorderForm.controls.edit_form.form('submit', {
                url: '/ashx/ordershandler.ashx?Method=SaveOrder&' + jsNC(),
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
                        showInfo("保存成功！您可继续录入新订单");
                        addorderForm.events.createneworder();
                    }
                }
            });
        },
        createneworder: function () {
            addorderForm.controls.edit_form.form('clear');
            $('#search_form_customer').form('clear');//清空客户列表查询项
            addorderForm.controls.dgcabinet.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
            $("#OrderID").val(addorderForm.events.loadNewGuid());
            $('#CustomerID').combogrid("grid").datagrid("reload", {});
        },
        reload: function () {
            $.messager.confirm('系统提示', '您确定要清空所有填订单信息?', function (flag) {
                if (flag) {
                    addorderForm.events.createneworder();
                }
            });
        },
        addrow: function () {
            if (addorderForm.events.endEditing()) {
                addorderForm.controls.dgcabinet.datagrid('appendRow',
                    {
                        ProductID: addorderForm.events.loadNewGuid(),
                        ProductName: '直拼A型门框',
                        ProductGroup: 'MK003-Z',
                        Size: '1600*1200*600',
                        Color: '14版（仿古）原木6#色',
                        MaterialStyle: '摩登时代',
                        MaterialCategory: '直纹樱桃贴面',
                        Unit: '套',
                        Qty: 1,
                        Price: 0
                    });
                editIndex = addorderForm.controls.dgcabinet.datagrid('getRows').length - 1;
                addorderForm.controls.dgcabinet.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }
        },
        copyrow: function () {
            var row = $('#dgCabinet').datagrid('getChecked');
            if (row.length == 0) {
                showError('请选择一条记录。');
                return;
            }
            if (addorderForm.events.endEditing()) {
                $('#dgCabinet').datagrid('appendRow', {
                    ProductID: addorderForm.events.loadNewGuid(),
                    ProductGroup: row[0].ProductGroup,
                    ProductName: row[0].ProductName,
                    Size: row[0].Size,
                    Color: row[0].Color,
                    MaterialStyle: row[0].MaterialStyle,
                    MaterialCategory: row[0].MaterialCategory,
                    Unit: row[0].Unit,
                    Remark: row[0].Remark,
                    Qty: row[0].Qty,
                    Price: row[0].Price
                });
                editIndex = addorderForm.controls.dgcabinet.datagrid('getRows').length - 1;
                addorderForm.controls.dgcabinet.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }
        },
        endEditing: function () {
            if (editIndex == undefined) { return true }
            if (addorderForm.controls.dgcabinet.datagrid('validateRow', editIndex)) {
                addorderForm.controls.dgcabinet.datagrid('endEdit', editIndex);
                if (!addorderForm.events.isRepeartRow()) {
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
            return false;
        },
        //取消所有行
        cancelall: function () {
            addorderForm.controls.dgcabinet.datagrid('rejectChanges');
        },
        onClickCell: function (index, field) {
            if (editIndex != index) {
                if (addorderForm.events.endEditing()) {
                    addorderForm.controls.dgcabinet.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = addorderForm.controls.dgcabinet.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }
                    editIndex = index;
                } else {
                    setTimeout(function () {
                        addorderForm.controls.dgcabinet.datagrid('selectRow', editIndex);
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
        }
    }
};

function cancelrow(index) {
    if (addorderForm.events.endEditing()) {
        if (index == undefined) { return }
        $('#dgCabinet').datagrid('deleteRow', index);
        var rows = $('#dgCabinet').datagrid("getRows");
        $('#dgCabinet').datagrid("loadData", rows);
        index = undefined;
    }
}

$(function () {
    addorderForm.init();
 
    setTimeout(function () {
        $(".tooltip-right").hide();
    }, 500);
});

function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
}

//复制行
function copyrow(index) {
    addorderForm.controls.dgcabinet.datagrid('selectRow', index)
                         .datagrid('beginEdit', index);
    var row = $('#dgCabinet').datagrid('getSelected');
    if (addorderForm.events.endEditing()) {
        $('#dgCabinet').datagrid('appendRow', {
            ProductID: addorderForm.events.loadNewGuid(),
            ProductGroup: row.ProductGroup,
            ProductName: row.ProductName,
            Size: row.Size,
            Color: row.Color,
            MaterialStyle: row.MaterialStyle,
            MaterialCategory: row.MaterialCategory,
            Unit: row.Unit,
            Remark: row.Remark,
            Qty: row.Qty,
            Price: row.Price
        });
    }

}
