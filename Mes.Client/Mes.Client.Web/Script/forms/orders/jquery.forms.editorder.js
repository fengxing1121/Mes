//(function ($) {
'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var editorderForm = {
    init: function () {
        editorderForm.initControls();
        editorderForm.events.loadCabinet();//加载数据          
        editorderForm.events.loadCustomer();
        editorderForm.events.loadData();
        editorderForm.controls.saveorder.on('click', editorderForm.events.saveorder);//保存 
        editorderForm.controls.cancelorder.on('click', editorderForm.events.cancelorder);//取消订单
        editorderForm.controls.searchCustomer.on('click', editorderForm.events.searchCustomer);//查询客户
        editorderForm.events.createneworder();
        editorderForm.events.CabinetType();
    },
    initControls: function () {
        editorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            edit_form: $('#edit_form'),
            saveorder: $('#btn_edit_save'),
            searchCustomer: $('#btn_search_customer'),//查询客户
            cancelorder: $('#btn_cancelorder')//取消订单
        }
        var mydate = new Date();
        var yy = mydate.getFullYear();
        var mm = mydate.getMonth() + 1;
        var dd = mydate.getDate();
        var NowDay = yy + '-' + (mm < 10 ? ('0' + mm) : mm) + '-' + (dd < 10 ? ('0' + dd) : dd);
        
        var orderid = getUrlParam('orderid');
        if (orderid.length == 0) return;
        $('#OrderID').val(orderid);
        $.ajax({
            url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
            data: { OrderID: orderid },
            datatype: "json",
            success: function (data) {
                var type = data.OrderType;
                if (type == "正常" || type == "加急" || type == "工程" || type == "展会") {
                    editorderForm.events.ShipDatebyType();
                } else {
                    editorderForm.events.ShipDate2Replenish();
                }
            }
        });
        

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
       

        //根据订单类型判断交货日期天数
        $('#OrderType').combobox({
            onSelect: function () {
                var type = $("#OrderType").combobox('getValue');
                if (type == "") {
                    showError("请选择订单类型");
                }
                if (type == "正常" || type == "加急" || type == "工程" || type == "展会") {
                    editorderForm.events.ShipDatebyType();
                } else {
                    editorderForm.events.ShipDate2Replenish();
                }

            }
        });
    },
    events: {

        //正常" || type == "加急" || type == "工程" || type == "展会
        ShipDatebyType: function () {
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
        },

        //补货类型
        ShipDate2Replenish: function () {
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
        
        //加载订单信息
        loadData: function () {
            var orderid = getUrlParam('orderid');
            if (orderid.length == 0) return;
            $('#OrderID').val(orderid);
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                data: { OrderID: orderid },
                datatype: "json",
                success: function (data) {
                    editorderForm.controls.edit_form.form('load', data); 
                    $("#Status").val(GetOrderStatusName(data.Status));//转换订单状态中文名称 该方法GetOrderStatusName在公共js里
                    $("#BookingDate").datebox("setValue", new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                    $("#ShipDate").datebox("setValue", new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));
                    if (data.IsStandard == "True") {
                        $('#IsStandard').combobox('setText', '是');
                    } else {
                        $('#IsStandard').combobox('setText', '否');
                    }
                    if (data.IsOutsourcing == "True") {
                        $('#IsOutsourcing').combobox('setText', '是');
                    } else {
                        $('#IsOutsourcing').combobox('setText', '否');
                    }
                }
            });
        },

        //添加产品
        loadCabinet: function () {
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
                    field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center'
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
                        var str = '<a href="#" onclick="cancelrow(\'' + row['CabinetID'] + '\',' + index + ')"><span class="icon delete">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        str += '<a href="#" onclick="copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                        return str;
                    }
                }
                ]],
                
                onBeforeLoad: function (param) {
                    var orderid = getUrlParam('orderid');
                    param['OrderID'] = orderid;
                   
                },
                toolbar: [
                    { text: '增加', iconCls: 'icon-add', handler: editorderForm.events.addrow },
                    { text: '取消', iconCls: 'icon-cancel', handler: editorderForm.events.cancelall }
                ],
                onClickCell: editorderForm.events.onClickCell,
                onEndEdit: editorderForm.events.onEndEdit
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
                    editorderForm.controls.edit_form.form('load',row);
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

        //修改订单保存
        saveorder: function () {
            if (editorderForm.events.endEditing()) {
                editorderForm.controls.dgcabinet.datagrid('acceptChanges');
            }
            var rows = editorderForm.controls.dgcabinet.datagrid('getRows');
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
                    CabinetID: rows[i].CabinetID, CabinetName: rows[i].CabinetName, Size: rows[i].Size,
                    MaterialStyle: rows[i].MaterialStyle, Qty: rows[i].Qty, Price: rows[i].Price,
                    Color: rows[i].Color, MaterialCategory: rows[i].MaterialCategory, Unit: rows[i].Unit, Remark: rows[i].Remark
                });

            }

            //序列化对象为Json字符串
            var sd = JSON.stringify(kv);
            $('#Cabinets').val(sd);
            $.messager.confirm('系统提示', '您确定要修改该订单吗?', function (flag) {
                if (flag) {
                    editorderForm.controls.edit_form.form('submit', {
                        url: '/ashx/ordershandler.ashx?Method=SaveOrder&edit=true&' + jsNC(),
                        data: editorderForm.controls.edit_form.serialize(),
                        datatype: 'json',
                        onSubmit: function () {
                            var isValid = editorderForm.controls.edit_form.form('validate');
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
                                showInfo(returnData.message);
                                editorderForm.events.createneworder();
                                top.closeTab("修改订单");//关闭tab
                            }
                        }
                    });
                }
            });
          
        },

        createneworder: function () {
            editorderForm.controls.edit_form.form('clear');
            $('#search_form_customer').form('clear');//清空客户列表查询项
            editorderForm.controls.dgcabinet.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
            $("#OrderID").val(editorderForm.events.loadNewGuid());
            $('#CustomerID').combogrid("grid").datagrid("reload", {});
        },

        addrow: function () {
            if (editorderForm.events.endEditing()) {
                editorderForm.controls.dgcabinet.datagrid('appendRow', { CabinetID: editorderForm.events.loadNewGuid(), Qty: 1, Price: 0 });
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
            var rows = editorderForm.controls.dgcabinet.datagrid('getRows');
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
            editorderForm.controls.dgcabinet.datagrid('rejectChanges');
        },
         

        onClickCell: function (index, field) {
            if (editIndex != index) {
                if (editorderForm.events.endEditing()) {
                    editorderForm.controls.dgcabinet.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = editorderForm.controls.dgcabinet.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }
                    editIndex = index;
                } else {
                    setTimeout(function () {
                        editorderForm.controls.dgcabinet.datagrid('selectRow', editIndex);
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
        },

        //取消订单
        cancelorder: function () {
            var orderid = getUrlParam('orderid');
            if (orderid == "") {
                return;
            }
            $.messager.confirm('系统提示', '您确定要取消该订单吗?', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/ordershandler.ashx?Method=CancelOrder',
                        data: { OrderID: orderid },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    showInfo(returnData.message);
                                    top.closeTab("修改订单");//关闭tab
                                }
                            }
                        }
                    });
                }
            });
        },

    }
};


//移除并删除数据库的产品明细
function cancelrow(id,index) {
    //if (editIndex == undefined) { return }
    //$('#dgCabinet').datagrid('cancelEdit', editIndex)
    //        .datagrid('deleteRow', editIndex);
    //editIndex = undefined;

    if (editorderForm.events.endEditing()) {
        if (index == undefined) { return }
        $('#dgCabinet').datagrid('deleteRow', index);
        var rows = $('#dgCabinet').datagrid("getRows");
        $('#dgCabinet').datagrid("loadData", rows);
        index = undefined;
    }

    $.ajax({
        url: '/ashx/ordershandler.ashx?Method=DeleteByCabinetID&' + jsNC(),
        data: { CabinetID: id },
        datatype: "json",
        success: function (data) {
            if (data.isOk == 0) {
                
            }
            else {
                 
            }
        }
    });
}

$(function () {
    editorderForm.init();
});


//复制行
function copyrow(index) {
    editorderForm.controls.dgcabinet.datagrid('selectRow', index)
                         .datagrid('beginEdit', index);
    var row = $('#dgCabinet').datagrid('getSelected');
    if (editorderForm.events.endEditing()) {
        $('#dgCabinet').datagrid('appendRow', {
            CabinetID: editorderForm.events.loadNewGuid(),
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
