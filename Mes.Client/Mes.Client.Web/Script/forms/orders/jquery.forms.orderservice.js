//(function ($) {
'use strict';
document.msCapsLockWarningOff = true;

var editIndex = undefined;
var orderdetail_editIndex = undefined;
var hardware_editIndex = undefined;

var addorderForm = {
    init: function () {
        addorderForm.initControls();
        addorderForm.events.loadCabinet();//加载数据          
        addorderForm.events.loadOrderDetail();//加载数据        
        addorderForm.events.loadHardware();//加载数据    
        addorderForm.events.loadOrder();
        addorderForm.events.loadCustomer();
        addorderForm.controls.saveorder.on('click', addorderForm.events.saveorder);//保存 
        addorderForm.controls.searchCustomer.on('click', addorderForm.events.searchCustomer);//查询客户
        addorderForm.controls.SearchOrder.on('click', addorderForm.events.searchOrder);//查询订单
        addorderForm.events.createneworder();
        addorderForm.events.CabinetType();
        $('#OrderType').val('补货');
        addorderForm.events.addrow();//添加固定行
    },
    initControls: function () {
        addorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            dgOrderDetail: $('#dgOrderDetail'),
            dgHardware: $('#dgHardware'),
            edit_form: $('#edit_form'),
            saveorder: $('#btn_edit_save'),
            searchCustomer: $('#btn_search_customer'),//查询客户
            SearchOrder: $('#btnSearchOrder')
        }
        var mydate = new Date();
        var yy = mydate.getFullYear();
        var mm = mydate.getMonth() + 1;
        var dd = mydate.getDate();
        var NowDay = yy + '-' + (mm < 10 ? ('0' + mm) : mm) + '-' + (dd < 10 ? ('0' + dd) : dd);
        //$("#BookingDate").val(NowDay);//默认当天

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
        //$('#ShipDate').datebox({
        //    onSelect: function (date) {
        //        showError("请选择订单类型！");
        //        $("#ShipDate").datebox("setValue", '');
        //        return;
        //    }
        //});
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
                //{ field: 'cp', checkbox: true },
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
                }
                //{
                //    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                //    formatter: function (value, row, index) {

                //        var str = '<a href="#" onclick="cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                //        str += '<a href="#" onclick="copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                //        return str;
                //    }
                //}
                ]],
                //toolbar: [
                //    { text: '增加', iconCls: 'icon-add', handler: addorderForm.events.addrow },
                //    { text: '取消', iconCls: 'icon-cancel', handler: addorderForm.events.cancelall }                    
                //],
                onClickCell: addorderForm.events.onClickCell,
                onEndEdit: addorderForm.events.onEndEdit
            });
        },
        loadOrderDetail: function () {
            addorderForm.controls.dgOrderDetail.datagrid({
                idField: 'ItemID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'ItemID', title: 'ItemID', hidden: true, width: 200, sortable: false, align: 'center' },
                {
                    field: 'ItemName', title: '部件名称', width: 150, sortable: false, align: 'center',
                    editor: {
                        type: 'textbox',
                        options: {
                            required: true
                        }
                    }
                },
                {
                    field: 'MaterialType', title: '材质颜色', width: 120, sortable: false, align: 'center',
                    editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetColorType'
                        }
                    }
                },
                {
                    field: 'MadeLength', title: '开料长度', width: 120, sortable: false, align: 'center',
                    editor: {
                        type: 'numberbox',
                        options: {
                            required: true,
                            min: 20,
                            max: 2440
                        }
                    }
                },
                {
                    field: 'MadeWidth', title: '开料宽度', width: 120, sortable: false, align: 'center',
                    editor: {
                        type: 'numberbox',
                        options: {
                            required: true,
                            min: 20,
                            max: 2440
                        }
                    }
                },
                {
                    field: 'MadeHeight', title: '厚度', width: 120, sortable: false, align: 'center',
                    editor: {
                        type: 'numberbox',
                        options: {
                            required: true
                        }
                    }
                },
                {
                    field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center',
                    editor: {
                        type: 'numberbox',
                        options: {
                            required: true
                        }
                    },
                },
                {
                    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                    formatter: function (value, row, index) {
                        var str = '<a href="#" onclick="orderdetail_cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        str += '<a href="#" onclick="orderdetail_copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                        return str;
                    }
                }
                ]],
                toolbar: [
                    { text: '增加', iconCls: 'icon-add', handler: addorderForm.events.orderdetail_addrow },
                    { text: '取消', iconCls: 'icon-cancel', handler: addorderForm.events.orderdetail_cancelall }
                ],
                onClickCell: addorderForm.events.orderdetail_onClickCell,
                onEndEdit: addorderForm.events.orderdetail_onEndEdit
            });
        },
        loadHardware: function () {
            addorderForm.controls.dgHardware.datagrid({
                idField: 'ItemID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'ItemID', title: 'ItemID', hidden: true, width: 200, sortable: false, align: 'center' },
                {
                    field: 'ItemName', title: '部件名称', width: 150, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            required: true
                        }
                    }
                },
                {
                    field: 'MaterialType', title: '规格/型号', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox'
                    }
                },
                {
                    field: 'Unit', title: '单位', width: 120, sortable: false, align: 'center', editor: {
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
                            required: true
                        }
                    },
                },
                {
                    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                    formatter: function (value, row, index) {

                        var str = '<a href="#" onclick="hardware_cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        str += '<a href="#" onclick="hardware_copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                        return str;
                    }
                }
                ]],
                toolbar: [
                    { text: '增加', iconCls: 'icon-add', handler: addorderForm.events.hardware_addrow },
                    { text: '取消', iconCls: 'icon-cancel', handler: addorderForm.events.hardware_cancelall },
                ],
                onClickCell: addorderForm.events.hardware_onClickCell,
                onEndEdit: addorderForm.events.hardware_onEndEdit
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
        loadOrder: function () {
            $('#PurchaseNo').combogrid({
                panelWidth: 640,
                panelHeight: 480,
                idField: 'OrderNo',
                textField: 'OrderNo',
                fitColumns: true,
                sortName: 'OrderNo',
                toolbar: '#order_bar',
                url: '/ashx/ordershandler.ashx?Method=SearchOrders',
                pagination: true,
                editable: false,
                nowrap: false,
                columns: [[
                        { field: 'OrderNo', title: '订单编号', width: 100, align: 'center' },
                        { field: 'CustomerName', title: '客户名称', width: 100, align: 'center' },
                        {
                            field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                return (row.Province) + (row.City) + row.Address;
                            }
                        },
                        { field: 'LinkMan', title: '联系人', width: 80, sortable: false, align: 'center' },
                        { field: 'Mobile', title: '电话', width: 80, sortable: false, align: 'center' }

                ]],
                onBeforeLoad: function (param) {
                    $('#search_form_order').find('input').each(function (index) { param[this.name] = $(this).val(); });
                },
                onSelect: function (index, row) {
                    $('#H_CustomerID').val(row.CustomerName);
                    addorderForm.controls.edit_form.form('load', row);
                    $("#Address").val(row.Province + row.City + row.Address);
                    addorderForm.controls.edit_form.find('#OrderType').val('补货');
                    addorderForm.controls.edit_form.find('#Status').val('待拆单');
                    addorderForm.controls.edit_form.find('#PurchaseNo').val(row.OrderNo);
                    addorderForm.controls.edit_form.find('#BookingDate').datebox('setValue', (new Date()).Formats('yyyy-MM-dd'));
                    addorderForm.controls.edit_form.find('#ShipDate').datebox('setValue', '');
                    addorderForm.controls.edit_form.find('#OrderNo').val('自动生成');
                }
            });

        },
        CabinetType: function () {
            $('#CabinetType,#SearchCabinetType').combobox({
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
            if (addorderForm.events.hardware_endEditing()) {
                addorderForm.controls.dgHardware.datagrid('acceptChanges');
            }
            if (addorderForm.events.orderdetail_endEditing()) {
                addorderForm.controls.dgOrderDetail.datagrid('acceptChanges');
            }
            //产品明细
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
                    CabinetID: rows[i].CabinetID, CabinetName: rows[i].CabinetName, Size: rows[i].Size,
                    MaterialStyle: rows[i].MaterialStyle, Qty: rows[i].Qty, Price: rows[i].Price,
                    Color: rows[i].Color, MaterialCategory: rows[i].MaterialCategory, Unit: rows[i].Unit, Remark: rows[i].Remark
                });
            }
            //序列化对象为Json字符串
            var sd = JSON.stringify(kv);
            $('#Cabinets').val(sd);

            //板件明细
            var detailrows = addorderForm.controls.dgOrderDetail.datagrid('getRows');
            var kv_details = [];
            for (var i = 0; i < detailrows.length; i++) {
                if (detailrows[i].Qty == 0) {
                    showError("板件明细数量不能为0");
                    return;
                }
                kv_details.push({
                    ItemID: detailrows[i].ItemID,
                    ItemName: detailrows[i].ItemName,
                    MaterialType: detailrows[i].MaterialType,
                    MadeLength: detailrows[i].MadeLength,
                    MadeWidth: detailrows[i].MadeWidth,
                    MadeHeight: detailrows[i].MadeHeight,
                    Qty: detailrows[i].Qty
                });
            }
            var od = JSON.stringify(kv_details);
            $('#OrderDetails').val(od);

            //五金明细
            var hardware_rows = addorderForm.controls.dgHardware.datagrid('getRows');
            var kv_hardwares = [];
            for (var i = 0; i < hardware_rows.length; i++) {
                if (hardware_rows[i].Qty == 0) {
                    showError("板件明细数量不能为0");
                    return;
                }
                kv_hardwares.push({
                    ItemID: hardware_rows[i].ItemID,
                    ItemName: hardware_rows[i].ItemName,
                    MaterialType: hardware_rows[i].MaterialType,
                    Unit: hardware_rows[i].Unit,                  
                    Qty: hardware_rows[i].Qty
                });
            }

            var hd = JSON.stringify(kv_details);
            $('#HardwareDetails').val(hd);

            addorderForm.controls.edit_form.form('submit', {
                url: '/ashx/ordershandler.ashx?Method=SaveOrderDetails&' + jsNC(),
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
                        showInfo(returnData.message);
                        addorderForm.events.createneworder();
                        top.closeTab('新增订单');
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
        addrow: function () {
            if (addorderForm.events.endEditing()) {
                addorderForm.controls.dgcabinet.datagrid('appendRow',
                    {
                        CabinetID: NewGuid(),
                        CabinetName: '售后补货',
                        Size: '无',
                        Color: '无',
                        MaterialStyle: '无',
                        MaterialCategory: '无',
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
                    CabinetID: addorderForm.events.loadNewGuid(),
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
        },
        searchOrder: function () {
            $('#PurchaseNo').combogrid("grid").datagrid("reload");
        },
        //添加板件明细
        orderdetail_addrow: function () {
            if (addorderForm.events.orderdetail_endEditing()) {
                addorderForm.controls.dgOrderDetail.datagrid('appendRow',
                    {
                        ItemID: NewGuid(),
                        ItemName: '层板',
                        MaterialType: '摩登时代',
                        MadeLength: 300,
                        MadeWidth: 200,
                        MadeHeight: 18,
                        Qty: 1
                    });
                orderdetail_editIndex = addorderForm.controls.dgOrderDetail.datagrid('getRows').length - 1;
                addorderForm.controls.dgOrderDetail.datagrid('selectRow', orderdetail_editIndex).datagrid('beginEdit',orderdetail_editIndex);
            }
        },
        orderdetail_endEditing: function () {
            if (orderdetail_editIndex == undefined) { return true }
            if (addorderForm.controls.dgOrderDetail.datagrid('validateRow', orderdetail_editIndex)) {
                addorderForm.controls.dgOrderDetail.datagrid('endEdit', orderdetail_editIndex);
                orderdetail_editIndex = undefined;
                return true;
            }
            else {
                return false;
            }
        },
        orderdetail_onEndEdit: function (index, row) {
            var ed = $(this).datagrid('getEditor', {
                index: index,
                field: 'MaterialType'
            });
            row.MaterialType = $(ed.target).combobox('getText');
        },
        orderdetail_onClickCell: function (index, field) {
            if (orderdetail_editIndex != index) {
                if (addorderForm.events.orderdetail_endEditing()) {
                    addorderForm.controls.dgOrderDetail.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = addorderForm.controls.dgOrderDetail.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }
                    orderdetail_editIndex = index;
                } else {
                    setTimeout(function () {
                        addorderForm.controls.dgOrderDetail.datagrid('selectRow', orderdetail_editIndex);
                    }, 0);
                }
            }
        },
        orderdetail_cancelall: function () {
            addorderForm.controls.dgOrderDetail.datagrid('rejectChanges');
        },

        //添加五金明细
        hardware_addrow: function () {
            if (addorderForm.events.hardware_endEditing()) {
                addorderForm.controls.dgHardware.datagrid('appendRow',
                    {
                        ItemID: NewGuid(),
                        ItemName: '',
                        MaterialType: '',
                        Unit: '个',
                        Qty: 1
                    });
                hardware_editIndex = addorderForm.controls.dgHardware.datagrid('getRows').length - 1;
                addorderForm.controls.dgHardware.datagrid('selectRow', hardware_editIndex)
                        .datagrid('beginEdit', hardware_editIndex);
            }
        },
        hardware_endEditing: function () {
            if (hardware_editIndex == undefined) { return true }
            if (addorderForm.controls.dgHardware.datagrid('validateRow', hardware_editIndex)) {
                addorderForm.controls.dgHardware.datagrid('endEdit', hardware_editIndex);
                hardware_editIndex = undefined;
                return true;
            }
            else {
                return false;
            }
        },
        hardware_onEndEdit: function (index, row) {
            //var ed = $(this).datagrid('getEditor', {
            //    index: index,
            //    field: 'MaterialType'
            //});
            //row.MaterialType = $(ed.target).combobox('getText');
        },
        hardware_onClickCell: function (index, field) {
            if (hardware_editIndex != index) {
                if (addorderForm.events.hardware_endEditing()) {
                    addorderForm.controls.dgHardware.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = addorderForm.controls.dgHardware.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }
                    hardware_editIndex = index;
                } else {
                    setTimeout(function () {
                        addorderForm.controls.dgHardware.datagrid('selectRow', hardware_editIndex);
                    }, 0);
                }
            }
        },
        hardware_cancelall: function () {
            addorderForm.controls.dgHardware.datagrid('rejectChanges');
        },
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

function orderdetail_cancelrow(index) {
    if (addorderForm.events.orderdetail_endEditing()) {
        if (index == undefined) { return }
        addorderForm.controls.dgOrderDetail.datagrid('deleteRow', index);
        var rows = addorderForm.controls.dgOrderDetail.datagrid("getRows");
        addorderForm.controls.dgOrderDetail.datagrid("loadData", rows);
        index = undefined;
    }
}

function hardware_cancelrow(index) {
    if (addorderForm.events.hardware_endEditing()) {
        if (index == undefined) { return }
        addorderForm.controls.dgHardware.datagrid('deleteRow', index);
        var rows = addorderForm.controls.dgHardware.datagrid("getRows");
        addorderForm.controls.dgHardware.datagrid("loadData", rows);
        index = undefined;
    }
}


$(function () {
    addorderForm.init();
});

//})(jQuery);

function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
}

//产品复制行
function copyrow(index) {
    addorderForm.controls.dgcabinet.datagrid('selectRow', index)
                         .datagrid('beginEdit', index);
    var row = $('#dgCabinet').datagrid('getSelected');
    if (addorderForm.events.endEditing()) {
        $('#dgCabinet').datagrid('appendRow', {
            CabinetID: addorderForm.events.loadNewGuid(),
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

//板件复制行
function orderdetail_copyrow(index) {
    addorderForm.controls.dgOrderDetail.datagrid('selectRow', index)
                         .datagrid('beginEdit', index);
    var row = addorderForm.controls.dgOrderDetail.datagrid('getSelected');
    if (addorderForm.events.orderdetail_endEditing()) {
        addorderForm.controls.dgOrderDetail.datagrid('appendRow', {
            ItemID: NewGuid(),
            ItemName: row.ItemName,
            MaterialType: row.MaterialType,
            MadeLength: row.MadeLength,
            MadeWidth: row.MadeWidth,
            MadeHeight: row.MadeHeight,
            Qty: 1
        });
    }
}

//五金复制行
function hardware_copyrow(index) {
    addorderForm.controls.dgHardware.datagrid('selectRow', index)
                         .datagrid('beginEdit', index);
    var row = addorderForm.controls.dgHardware.datagrid('getSelected');
    if (addorderForm.events.hardware_endEditing()) {
        addorderForm.controls.dgHardware.datagrid('appendRow', {
            ItemID: NewGuid(),
            ItemName: row.ItemName,
            MaterialType: row.MaterialType,
            Unit: row.Unit,
            Qty: 1
        });
    }
}

