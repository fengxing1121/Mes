//(function ($) {
//(function ($) {
//'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var addorderForm = {
    init: function () {
        addorderForm.initControls();
        addorderForm.events.loadCabinet();//加载数据          
        addorderForm.events.loadCustomer();
        addorderForm.controls.saveorder.on('click', addorderForm.events.saveorder);//保存 
        addorderForm.controls.searchCustomer.on('click', addorderForm.events.searchCustomer);//查询客户
        addorderForm.events.createneworder();
        addorderForm.events.CabinetType();
    },
    initControls: function () {
        addorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            edit_form: $('#edit_form'),
            saveorder: $('#btn_edit_save'),
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
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var SelectDay = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                if (SelectDay > NowDay) {
                    showError("订货日期必须是：" + NowDay + ",或者之前的日期，请重新选择！");
                    $("#BookingDate").datebox("setValue", '');
                }
            }
        });

        //交货日期 先选择订单类型
        $('#ShipDate').datebox({
            onSelect: function (date) {
                showError("请选择订单类型！");
                $("#ShipDate").datebox("setValue", '');
                return;
            }
        });

        //根据订单类型判断交货日期天数
        $('#OrderType').combobox({
            onSelect: function () {
                var type = $("#OrderType").combobox('getValue');
                if (type == "") {
                    showError("请选择订单类型");
                }
                if (type == "正常" || type == "加急" || type == "工程" || type == "展会") {
                    //交货日期
                    $('#ShipDate').datebox({
                        onSelect: function (date) {
                            var BookingDate = "";
                            BookingDate = $("#BookingDate").datebox("getValue");
                            if (BookingDate == "") {
                                showError("请选择订货日期！");
                                return;
                            }
                            var ShipDate = $("#ShipDate").datebox("getValue");
                            var bookingTemp = BookingDate.split("-");
                            var bDate = new Date(bookingTemp[0] + '-' + bookingTemp[1] + '-' + bookingTemp[2]); //转换为MM-DD-YYYY格式    
                            var shipTemp = ShipDate.split("-");
                            var sDate = new Date(shipTemp[0] + '-' + shipTemp[1] + '-' + shipTemp[2]); //转换为MM-DD-YYYY格式  
                            var iDays = parseInt(Math.abs(sDate - bDate) / 1000 / 60 / 60 / 24); //把相差的毫秒数转换为天数
                            if (iDays < 10) {
                                showError("交货日期必须为订货日期的10天之后！");
                                $("#ShipDate").datebox("setValue", '');
                            }
                        }
                    });
                } else {
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
                }

            }
        });
    },
    events: {
        //添加产品
        loadCabinet: function () {
            addorderForm.controls.dgcabinet.datagrid({
                idField: 'CabinetID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                {
                    field: 'CabinetGroup', title: '区域', width: 150, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'text',
                            textField: 'value',
                            data: [
                                { 'text': '全屋产品', 'value': '全屋产品' }
                                ,{'text':'客厅','value':'客厅'}
                                , { 'text': '厨房', 'value': '厨房' }
                                ,{'text':'主卧','value':'主卧'}
                                ,{'text':'次卧','value':'次卧'}
                                ,{'text':'儿童房','value':'儿童房'}
                                ,{'text':'客房','value':'客房'}
                                ,{'text':'保姆房','value':'保姆房'}
                                ,{'text':'其他','value':'其他'}
                            ],                        
                            method: 'get',
                            required: true
                        }
                    }
                },
                {
                    field: 'CabinetCode', title: '产品编号', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            required: true,
                        }
                    }
                },
                {
                    field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetCabinetName',
                            required: true
                        }
                    }
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
                {
                    field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center', editor: {
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
                        { field: 'CustomerName', title: '客户名称', width: 100, align: 'center' },
                        {
                            field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                return (row.Province) + (row.City) + row.Address;
                            }
                        },
                        { field: 'LinkMan', title: '联系人', width: 80, sortable: false, align: 'center' },
                        { field: 'Mobile', title: '移动电话', width: 80, sortable: false, align: 'center' }

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
        CabinetType: function () {
            $('#CabinetType').combobox({
                url: '/ashx/categoryhandler.ashx?Method=GetCabinetType',
                textField: 'CategoryName',
                valueField: 'CategoryName',
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
                    CabinetID: rows[i].CabinetID,
                    CabinetCode: rows[i].CabinetCode,
                    CabinetName: rows[i].CabinetName,
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
                        $.messager.alert('操作提示', '新订单提交成功。', 'info', function () {
                            window.top.RefreshTask('订单查询');
                            window.parent.closeTab();
                        });
                    }
                }
            });
        },
        createneworder: function () {
            addorderForm.controls.edit_form.form('clear');
            $('#search_form_customer').form('clear');                                    //清空客户列表查询项
            addorderForm.controls.dgcabinet.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
            $("#OrderID").val(addorderForm.events.loadNewGuid());
            $('#CustomerID').combogrid("grid").datagrid("reload", {});
        },
        addrow: function () {
            if (addorderForm.events.endEditing()) {
                addorderForm.controls.dgcabinet.datagrid('appendRow',
                    {
                        CabinetGroup: '全屋产品',
                        CabinetCode: '',
                        CabinetName: '定制衣柜A',
                        Size: '1600*1200*600',
                        Color: '暖白',
                        MaterialStyle: '摩登时代',
                        MaterialCategory: '颗粒板',
                        Unit: '套',
                        CabinetID: addorderForm.events.loadNewGuid(),
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
                    CabinetID: addorderForm.events.loadNewGuid(),
                    CabinetCode: '',
                    CabinetName: row[0].CabinetName,
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
            var rows = addorderForm.controls.dgcabinet.datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                for (var j = i + 1; j < rows.length; j++) {
                    if (rows[i].CabinetName == rows[j].CabinetName) {
                        showError("产品名称【" + rows[j].CabinetName + "】重复添加。");
                        return false;
                    }
                }
            }
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
                field: 'CabinetName'
            });
            row.CabinetName = $(ed.target).combobox('getText');
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
            CabinetID: addorderForm.events.loadNewGuid(),
            CabinetGroup: row.CabinetGroup,
            CabinetCode: row.CabinetCode,
            CabinetName: row.CabinetName,
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
