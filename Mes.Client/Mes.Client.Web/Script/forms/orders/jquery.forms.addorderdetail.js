//(function ($) {
    var orderdetail_editIndex = undefined;
    var editIndex = undefined;
    var AddOrderDetailForm = {
        init: function () {
            AddOrderDetailForm.initControls();
            AddOrderDetailForm.events.loadOrderIsLeak();
            AddOrderDetailForm.events.loadOrderIsDamage();
            AddOrderDetailForm.events.loadCabinetType();
            AddOrderDetailForm.controls.IsLeak.on('click', AddOrderDetailForm.events.IsLeak);
            AddOrderDetailForm.controls.IsDamage.on('click', AddOrderDetailForm.events.IsDamage);
            AddOrderDetailForm.controls.btn_search_orderIsLeak.on('click',AddOrderDetailForm.events.SearchOrderIsLeak);
            AddOrderDetailForm.controls.btn_search_orderIsDamage.on('click', AddOrderDetailForm.events.SearchOrderIsDamage);
            AddOrderDetailForm.controls.btn_edit_save.on('click', AddOrderDetailForm.events.SaveOrderCabinet);
            AddOrderDetailForm.controls.btn_search_order.on('click', AddOrderDetailForm.events.LoadOrder2DetailIsDamage);
        },
        initControls: function () {
            AddOrderDetailForm.controls={
                add_orderdetail_from: $('#add_orderdetail_from'),
                IsLeak: $('#IsLeak'),
                IsDamage: $('#IsDamage'),
                dgOrderDetailIsIsLeak: $('#dgOrderDetailIsIsLeak'),
                dgOrderDetailsIsDamage: $('#dgOrderDetailsIsDamage'),
                btn_search_orderIsLeak: $('#btn_search_orderIsLeak'),
                btn_search_orderIsDamage: $('#btn_search_orderIsDamage'),
                btn_edit_save: $('#btn_edit_save'),
                btn_search_order: $('#btn_search_order'),
            }
            //$('.easyui-tabs').tabs('getTab', '补漏件').panel('options').tab.show();
            //$('.easyui-tabs').tabs('getTab', '补损件').panel('options').tab.hide();
        },
        events: {
            //补漏件
            loadOrderIsLeak: function () {                
                $('#IsLeakDiv').find('input[name="OrderID"]').combogrid({
                    panelWidth: 850,
                    panelHeight: 450,
                    idField: 'OrderID',
                    textField: 'OrderNo',
                    fitColumns: true,
                    sortName: 'Created',
                    toolbar: '#order_IsLeak_bar',
                    url: '/ashx/ordershandler.ashx?Method=SearchOrders&' + jsNC(),
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    columns: [[
                            { field: 'OrderNo', title: '订单号', width: 105, sortable: false, halign: 'center', align: 'center' },
                            { field: 'PurchaseNo', title: '报价单号', width: 105, sortable: false, halign: 'center', align: 'center' },
                            { field: 'CabinetType', title: '产品类型', width: 60, sortable: false, align: 'center' },
                            { field: 'OrderType', title: '订单类型', width: 60, sortable: false, align: 'center' },
                            { field: 'CustomerName', title: '客户名称', width: 85, sortable: false, halign: 'center', align: 'center' },
                            { field: 'LinkMan', title: '联系人', width: 70, sortable: false, halign: 'center', align: 'center' },
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
                            {
                                field: 'IsStandard', title: '是否正标', width: 60, sortable: false, align: 'center',
                                formatter: function (value, rowData, rowIndex) {
                                    if (value == undefined) return "";
                                    if (value == "True")
                                        return "是";
                                    else
                                        return "否";
                                }
                            },
                            {
                                field: 'Status', title: '订单状态', width: 100, align: 'center',
                                formatter: function (value, rowData, rowIndex) {
                                    var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细"><span style="color:#0094ff;">' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                                    return strReturn;
                                }
                            }
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_orderIsLeak').find('input').each(function (index) {
                            if (this.name!="") {
                                param[this.name] = $(this).val();
                            }
                        });
                    },
                    onSelect: function (index,row) {
                        $('#IsLeakDiv').find('input[name="CabinetType"]').val(row.CabinetType);
                        $('#IsLeakDiv').find('input[name="CustomerName"]').val(row.CustomerName);
                        AddOrderDetailForm.events.LoadOrder2CabinetIsLeak(row.OrderID);
                    }
                });              
            }, 
            LoadOrder2CabinetIsLeak: function (OrderID) {                
                $('#CabinetIDIsLeak').combogrid({
                    panelWidth: 800,
                    panelHeight: 450,
                    idField: 'CabinetID',
                    textField: 'CabinetName',
                    url: '/ashx/ordershandler.ashx?Method=GetCabinets',
                    collapsible: false,
                    fitColumns: true,
                    pagination: false,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....', 
                    columns: [[
                        { field: 'CabinetGroup', title: '产品分组', width: 150, sortable: false, align: 'center' },
                        { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                        { field: 'Size', title: '成品尺寸', width: 300, sortable: false, halign: 'center', align: 'center' },
                        { field: 'MaterialStyle', title: '材质风格', width: 150, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Color', title: '材质颜色', width: 100, sortable: false, halign: 'center', align: 'center' },
                        { field: 'MaterialCategory', title: '材质类型', width: 100, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Qty', title: '数量', width: 60, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Unit', title: '单位', width: 50, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Price', title: '单价', width: 80, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Remark', title: '备注', width: 150, sortable: false, halign: 'center', align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = OrderID;
                    },
                    onSelect: function (index, row) {
                        AddOrderDetailForm.events.LoadOrder2DetailIsLeak();
                    }
                });
            },
            LoadOrder2DetailIsLeak: function () {
                $('#dgOrderDetailIsIsLeak').datagrid({
                    idField: 'ItemID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: true,
                    pagination: true,
                    columns: [[
                            { field: 'ItemID', title: 'ItemID', hidden: true, width: 200, sortable: false, align: 'center' },
                            { field: 'CabinetID', title: 'ItemID', hidden: true, width: 200, sortable: false, align: 'center' },
                            {
                                field: 'ItemName', title: '部件名称', width: 150, sortable: false, align: 'center',
                                editor: {
                                    type: 'textbox',
                                    options: {
                                        required: true
                                    }
                                }
                            },
                            { field: 'BarcodeNo', title: '板件条码', width: 180, sortable: false, align: 'center' },
                            {
                                field: 'MaterialType', title: '材质颜色', width: 150, sortable: false, align: 'center',
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
                                }
                            },
                            //{
                            //    field: 'DamageQty', title: '损耗数量', width: 60, sortable: false, align: 'center',
                            //    editor: {
                            //        type: 'numberbox',
                            //        options: {
                            //            required: true
                            //        }
                            //    }
                            //},
                            {
                                field: 'Remarks', title: '备注', width: 100, sortable: false, align: 'center',
                                editor: {
                                    type: 'validatebox',
                                    options: {
                                        //required: true
                                    }
                                }
                            },
                            {
                                field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                                formatter: function (value, row, index) {
                                    var str = '<a href="#" onclick="orderdetail_cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                                    //str += '<a href="#" onclick="orderdetail_copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                                    return str;
                                }
                            }
                    ]],
                    toolbar: [
                        { text: '增加', iconCls: 'icon-add', handler: AddOrderDetailForm.events.orderdetail_addrow },
                        { text: '取消', iconCls: 'icon-cancel', handler: AddOrderDetailForm.events.orderdetail_cancelall }
                    ],
                    onClickCell: AddOrderDetailForm.events.orderdetail_onClickCell,
                    onEndEdit: AddOrderDetailForm.events.orderdetail_onEndEdit
                });
            },

            //补损件
            loadOrderIsDamage: function () {
                $('#IsDamageDiv').find('input[name="OrderID"]').combogrid({
                    panelWidth: 850,
                    panelHeight: 450,
                    idField: 'OrderID',
                    textField: 'OrderNo',
                    fitColumns: true,
                    sortName: 'Created',
                    toolbar: '#order_IsDamage_bar',
                    url: '/ashx/ordershandler.ashx?Method=SearchOrders&' + jsNC(),
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    columns: [[
                            { field: 'OrderNo', title: '订单号', width: 105, sortable: false, halign: 'center', align: 'center' },
                            { field: 'PurchaseNo', title: '报价单号', width: 105, sortable: false, halign: 'center', align: 'center' },
                            { field: 'CabinetType', title: '产品类型', width: 60, sortable: false, align: 'center' },
                            { field: 'OrderType', title: '订单类型', width: 60, sortable: false, align: 'center' },
                            { field: 'CustomerName', title: '客户名称', width: 85, sortable: false, halign: 'center', align: 'center' },
                            { field: 'LinkMan', title: '联系人', width: 70, sortable: false, halign: 'center', align: 'center' },
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
                            {
                                field: 'IsStandard', title: '是否正标', width: 60, sortable: false, align: 'center',
                                formatter: function (value, rowData, rowIndex) {
                                    if (value == undefined) return "";
                                    if (value == "True")
                                        return "是";
                                    else
                                        return "否";
                                }
                            },
                            {
                                field: 'Status', title: '订单状态', width: 100, align: 'center',
                                formatter: function (value, rowData, rowIndex) {
                                    var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细"><span style="color:#0094ff;">' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                                    return strReturn;
                                }
                            }
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_orderIsDamage').find('input').each(function (index) {
                            if (this.name != "") {
                                param[this.name] = $(this).val();
                            }
                        });
                    },
                    onSelect: function (index, row) {
                        $('#IsDamageDiv').find('input[name="CabinetType"]').val(row.CabinetType);
                        $('#IsDamageDiv').find('input[name="CustomerName"]').val(row.CustomerName);
                        AddOrderDetailForm.events.LoadOrder2CabinetIsDamage(row.OrderID);
                    }
                });
            },
            LoadOrder2CabinetIsDamage: function (OrderID) {
                $('#CabinetIDIsDamage').combogrid({
                    panelWidth: 800,
                    panelHeight: 450,
                    idField: 'CabinetID',
                    textField: 'CabinetName',
                    url: '/ashx/ordershandler.ashx?Method=GetCabinets',
                    collapsible: false,
                    //fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                        { field: 'CabinetGroup', title: '产品分组', width: 150, sortable: false, align: 'center' },
                        { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                        { field: 'Size', title: '成品尺寸', width: 300, sortable: false, halign: 'center', align: 'center' },
                        { field: 'MaterialStyle', title: '材质风格', width: 150, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Color', title: '材质颜色', width: 100, sortable: false, halign: 'center', align: 'center' },
                        { field: 'MaterialCategory', title: '材质类型', width: 100, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Qty', title: '数量', width: 60, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Unit', title: '单位', width: 50, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Price', title: '单价', width: 80, sortable: false, halign: 'center', align: 'center' },
                        { field: 'Remark', title: '备注', width: 150, sortable: false, halign: 'center', align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = OrderID;
                    },
                    onSelect: function (index, row) {
                        $('#IsDamageDiv').find('input[name="OrderID"]').val(row.OrderID);
                        $('#IsDamageDiv').find('input[name="CabinetID"]').val(row.CabinetID);
                    }
                });
            },
            LoadOrder2DetailIsDamage: function () {
                var OrderID = $.trim($('#IsDamageDiv').find('input[name="OrderID"]').val());
                var CabinetID =$.trim($('#IsDamageDiv').find('input[name="CabinetID"]').val());
                var BarcodeNo =$.trim($('#IsDamageDiv').find('input[name="BarcodeNo"]').val());
                if (OrderID === "") {
                    showError('请选择订单');
                    return;
                }
                if (CabinetID==="") {
                    showError('请选择产品');
                    return;
                }
                //if (BarcodeNo==="") {
                //    showError('请输入板件板件条码');
                //    return;
                //} 
                
                $("#dgOrderDetailsIsDamage").datagrid({
                    idField: 'ItemID',
                    url: '/ashx/ordershandler.ashx?Method=SearchOrderDetail',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: false,
                    pagination: false,
                    columns: [[
                             { field: 'ItemID', title: 'ItemID', hidden: true,align: 'center'},
                             { field: 'CabinetID', title: 'ItemID', hidden: true, align: 'center'},
                             { field: 'ItemName', title: '部件名称', width: 150, align: 'center'},
                             { field: 'BarcodeNo', title: '板件条码', width: 180, align: 'center'},
                             { field: 'MaterialType', title: '材质颜色', width: 150, align: 'center'},
                             { field: 'MadeLength', title: '开料长度', width: 120, align: 'center' },
                             { field: 'MadeWidth', title: '开料宽度', width: 120, align: 'center'},
                             { field: 'MadeHeight', title: '厚度', width: 120,  align: 'center'},
                             {
                                 field: 'Qty', title: '数量', width: 60,  align: 'center',
                                 editor: {                                  
                                     type: 'numberbox',
                                     options: {
                                         required: true
                                     }
                                 }
                             },
                             {
                                 field: 'DamageQty', title: '损耗数量', width: 60, align: 'center',
                                 editor: {
                                     type: 'numberbox',
                                     options: {
                                         required: true
                                     }
                                 }
                             },
                             {
                                 field: 'Remarks', title: '备注', width: 100, sortable: false, align: 'center',
                                 editor: {
                                     type: 'validatebox',
                                     options: {
                                         //required: true
                                     }
                                 }
                             },
                             {
                                 field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                                 formatter: function (value, row, index) {
                                     var str = '<a href="#" onclick="onClickCell(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;补损件</a>';
                                     //str += '<a href="#" onclick="copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                                     return str;
                                 }
                             }
                    ]],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = OrderID;
                        param['CabinetID'] = CabinetID;
                        param['BarcodeNo'] = BarcodeNo;
                    },
                    //toolbar: [
                    //    //{ text: '增加', iconCls: 'icon-add', handler: AddOrderDetailForm.events.orderdetail_addrow },
                    //    //{ text: '取消', iconCls: 'icon-cancel', handler: AddOrderDetailForm.events.cancelall }
                    //],
                    //onClickCell: AddOrderDetailForm.events.onClickCell,
                    onEndEdit: AddOrderDetailForm.events.onEndEdit
                });
            },

            //产品类型
            loadCabinetType: function () {
                $('#SearchCabinetType').combobox({
                    url: '/ashx/categoryhandler.ashx?Method=GetCabinetType',
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                });
            },
            IsLeak: function () {
                var flag = $('#IsLeak').prop('checked'); //补漏检
                if (flag) {
                    $('#IsDamage').attr('checked', false);
                    $('#IsLeakDiv').css('display','block');
                    $('#IsDamageDiv').css('display', 'none');
                    $('#dgOrderDetailIsIsLeakDiv').css('display', 'block');
                    $('#dgOrderDetailsIsDamageDiv').css('display', 'none');
                    //$('.easyui-tabs').tabs('getTab', '补漏检').panel('options').tab.show();
                    //$('.easyui-tabs').tabs('getTab', '补损件').panel('options').tab.hide();
                    $('#IsLeakDiv').find('input').each(function (index) {
                        $(this).val('');
                    });
                    $('#IsDamageDiv').find('input').each(function (index) {
                        $(this).val('');
                    });                    
                } 
            },
            IsDamage: function () {
                var flag = $('#IsDamage').prop('checked');//补损件
                if (flag) {                  
                    $('#IsLeak').attr('checked', false);
                    $('#IsLeakDiv').css('display', 'none');                   
                    $('#IsDamageDiv').css('display', 'block');
                    $('#dgOrderDetailIsIsLeakDiv').css('display', 'none');
                    $('#dgOrderDetailsIsDamageDiv').css('display', 'block');
                    //$('.easyui-tabs').tabs('getTab', '补损件').panel('options').tab.show();
                    //$('.easyui-tabs').tabs('getTab', '补漏检').panel('options').tab.hide();
                    $('#IsLeakDiv').find('input').each(function (index) {
                        $(this).val('');
                    }); 
                    $('#IsDamageDiv').find('input').each(function (index) {
                        $(this).val('');
                    });
                }
            },

            //补漏件
            orderdetail_isRepeartRow: function () {
                var rows = AddOrderDetailForm.controls.dgOrderDetail.datagrid("getRows");
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length ; j++) {
                        if (rows[i].ItemName == rows[j].ItemName) {
                            showError("板件【" + rows[j].ItemName + "】重复添加。");
                            return true;
                        }
                    }
                }
                return false;
            },
            orderdetail_addrow: function () {
                var OrderID = $('#OrderIDIsLeak').combogrid('getValue');
                var CabinetID = $('#CabinetIDIsLeak').combogrid('getValue');
                if (OrderID==="") {
                    showError('请选择订单');
                    return;
                }
                if (CabinetID==="") {
                    showError('请选择产品:');
                    return;
                }
                if (AddOrderDetailForm.events.orderdetail_endEditing()) {
                    AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('appendRow',
                        {
                            ItemID: AddOrderDetailForm.events.loadNewGuid(),
                            ItemName: '层板',
                            BarcodeNo:'自动生成',
                            MaterialType: '摩登时代',
                            MadeLength: 300,
                            MadeWidth: 200,
                            MadeHeight: 18,
                            Qty: 1,
                            //DamageQty: 0,
                            Remarks:""
                        });
                    orderdetail_editIndex = AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('getRows').length - 1;
                    AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('selectRow', orderdetail_editIndex).datagrid('beginEdit', orderdetail_editIndex);
                }
            },
            orderdetail_endEditing: function () {
                if (orderdetail_editIndex == undefined) { return true;}
                if (AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('validateRow', orderdetail_editIndex)) {
                    AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('endEdit', orderdetail_editIndex);
                    return true;
                }
                else {
                    return false;
                }
            },
            orderdetail_onEndEdit: function (index, row) {
               // var ed = $(this).datagrid('getEditor',{
                    //index: index,
                    //field: 'MaterialType'
               // });
               // row.MaterialType = $(ed.target).combobox('getText');
            },
            orderdetail_onClickCell: function (index, field) {
                if (orderdetail_editIndex != index) {
                    if (AddOrderDetailForm.events.orderdetail_endEditing()) {
                        AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('selectRow', index).datagrid('beginEdit', index);
                        var ed = AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }
                        orderdetail_editIndex = index;
                    } else {
                        setTimeout(function () {
                            AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('selectRow', orderdetail_editIndex);
                        }, 0);
                    }
                }
            },
            orderdetail_cancelall: function () {
                AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('rejectChanges');
            },
            
            //补损件
            isRepeartRow: function () {
                var rows = AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid("getRows");
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length ; j++) {
                        if (rows[i].ItemName == rows[j].ItemName) {
                            showError("板件【" + rows[j].ItemName + "】重复添加。");
                            return true;
                        }
                    }
                }
                return false;
            },
            addrow: function () {
                if (AddOrderDetailForm.events.endEditing()) {
                    AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('appendRow',
                        {
                            ItemID: AddOrderDetailForm.events.loadNewGuid(),
                            ItemName: '层板',
                            BarcodeNo: '自动生成',
                            MaterialType: '摩登时代',
                            MadeLength: 300,
                            MadeWidth: 200,
                            MadeHeight: 18,
                            Qty: 1,
                            DamageQty: 0,
                            Remarks: ""
                        });
                    editIndex = AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('getRows').length - 1;
                    AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('selectRow',editIndex).datagrid('beginEdit',editIndex);
                }
            },
            endEditing: function () {
                if (editIndex == undefined) { return true; }
                if (AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('validateRow',editIndex)) {
                    AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('endEdit',editIndex);
                    return true;
                }
                else {
                    return false;
                }
            },
            onEndEdit: function (index, row) {
                // var ed = $(this).datagrid('getEditor',{
                //index: index,
                //field: 'MaterialType'
                // });
                // row.MaterialType = $(ed.target).combobox('getText');
            },          
            cancelall: function () {
                AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('rejectChanges');
            },

            SearchOrderIsLeak: function () {
                //补漏件
                $('#OrderIDIsLeak').combogrid("grid").datagrid("reload");
            },
            SearchOrderIsDamage: function () {
                //补损件
                $('#OrderIDIsDamage').combogrid("grid").datagrid("reload");
            },
           
            SaveOrderCabinet: function () {
                var IsLeakOrDamage = $.trim($('input[name="IsCheck"]:checked').val());
                if (IsLeakOrDamage==="") {
                    showError("请选择补货类型：补漏检或补损件.");
                    return;
                }
                switch(IsLeakOrDamage)
                {
                    case "补漏件":
                        AddOrderDetailForm.events.SaveOrderCabinetIsLeak();
                        break;
                    case "补损件":
                        AddOrderDetailForm.events.SaveOrderCabinetLsDamage();
                        break;
                    default:
                        break;
                }
            },
            SaveOrderCabinetIsLeak: function () {
                var OrderID = $('#OrderIDIsLeak').combogrid('getValue');
                var ItemGroup = $('#CabinetIDIsLeak').combobox('getText');
                var CabinetID = $('#CabinetIDIsLeak').combogrid('getValue');
                if (OrderID==="") {
                    showError('请选择订单');
                    return;
                }
                if (CabinetID==="") {
                    showError('请选择产品');
                     return;
                }
                var orderdetails = [];
                if (AddOrderDetailForm.events.orderdetail_endEditing()) {
                    AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('acceptChanges');
                } 
              

                var OrderDetails = AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('getRows');
                if (OrderDetails.length == 0) {
                    showError('至少添加一个板件');
                    return;
                }
                if (OrderDetails.length > 0) {
                    for (var i = 0; i < OrderDetails.length; i++) {
                        if (OrderDetails[i].Qty == 0) {
                            showError('板件明细数量不能为0');
                            return;
                        }
                        orderdetails.push({
                            ItemID: OrderDetails[i].ItemID,
                            ItemGroup: ItemGroup,
                            CabinetID: CabinetID,
                            ItemName: OrderDetails[i].ItemName,
                            MaterialType: OrderDetails[i].MaterialType,
                            MadeLength: OrderDetails[i].MadeLength,
                            MadeWidth: OrderDetails[i].MadeWidth,
                            MadeHeight: OrderDetails[i].MadeHeight,
                            DamageQty: OrderDetails[i].DamageQty,
                            Qty: OrderDetails[i].Qty,
                            Remarks: OrderDetails[i].Remarks
                        });
                    }
                }
                var OrderDetails = JSON.stringify(orderdetails);
                
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=SaveOrderDetailsIsLeak&' + jsNC(),
                    data: { OrderID: OrderID, CabinetID: CabinetID,OrderDetails: OrderDetails },
                    datatype: 'json',
                    success: function (returnData) {
                        if (returnData.isOk == 0) {
                            showError(returnData.message);
                        } else {
                            //showInfo(returnData.message);
                            $.messager.alert("提示", returnData.message, "info", function () {
                                AddOrderDetailForm.controls.add_orderdetail_from.form('clear');
                                window.parent.closeTab();
                                //AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('loadData', {});
                            });                           
                        }
                    }
                });
            },
            SaveOrderCabinetLsDamage: function () {
                var OrderID = $('#OrderIDIsDamage').combogrid('getValue');
                var ItemGroup = $('#CabinetIDIsDamage').combobox('getText');
                var CabinetID = $('#CabinetIDIsDamage').combogrid('getValue');
                if (OrderID === "") {
                    showError('请选择订单');
                    return;
                }
                if (CabinetID === "") {
                    showError('请选择产品');
                    return;
                }
                var orderdetails = [];
                if (AddOrderDetailForm.events.endEditing()) {
                    AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('acceptChanges');
                }
                var OrderDetails = AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('getRows');
                if (OrderDetails.length == 0)  return;
                if (OrderDetails.length > 0) {
                    for (var i = 0; i < OrderDetails.length; i++) {
                        if (OrderDetails[i].Qty == 0) {
                            showError('板件明细数量不能为0');
                            return;
                        }
                        orderdetails.push({
                            ItemID: OrderDetails[i].ItemID,
                            ItemGroup: ItemGroup,
                            CabinetID: CabinetID,
                            ItemName: OrderDetails[i].ItemName,
                            MaterialType: OrderDetails[i].MaterialType,
                            MadeLength: OrderDetails[i].MadeLength,
                            MadeWidth: OrderDetails[i].MadeWidth,
                            MadeHeight: OrderDetails[i].MadeHeight,
                            DamageQty: OrderDetails[i].DamageQty,
                            Qty: OrderDetails[i].Qty,
                            Remarks: OrderDetails[i].Remarks
                        });
                    }
                }
                var OrderDetails = JSON.stringify(orderdetails);

                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=SaveOrderDatailsLsDamage&' + jsNC(),
                    data: { OrderID: OrderID,OrderDetails: OrderDetails },
                    datatype: 'json',
                    success: function (returnData) {
                        if (returnData.isOk == 0) {
                            showError(returnData.message);
                        } else {
                            $.messager.alert("提示", returnData.message, "info", function () {
                                AddOrderDetailForm.controls.add_orderdetail_from.form('clear');
                                window.parent.closeTab();
                            });
                        }
                    }
                });
            },
            //Guid
            loadNewGuid: function () {
                var guid = " ";
                for (var i = 1; i <= 32; i++) {
                    var n = Math.floor(Math.random() * 16.0).toString(16);
                    guid += n;
                    if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                        guid += "-";
                }
                return guid;
            }
        }
    };

    function orderdetail_cancelrow(index) {
        if (AddOrderDetailForm.events.orderdetail_endEditing()) {
            if (index == undefined) return;
            AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('deleteRow', index);
            var rows = AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('getRows');
            AddOrderDetailForm.controls.dgOrderDetailIsIsLeak.datagrid('loadData', rows);
            index = undefined;
        }     
    }
    function cancelrow(index) {
        if (AddOrderDetailForm.events.endEditing()) {
            if (index == undefined) return;
            AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('deleteRow', index);
            var rows = AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('getRows');
            AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('loadData', rows);
            index = undefined;
        }
    }

    //补损件
    function endEditing() {
        if (editIndex == undefined) { return true; }
        if (AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('validateRow',editIndex)) {
        AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('endEdit',editIndex);
            return true;
        }
        else {
            return false;
        }
    }
    function onClickCell (index, field) {
        if (editIndex != index) {
            if (AddOrderDetailForm.events.endEditing()) {
                AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('selectRow',index).datagrid('beginEdit',index);
                var ed = AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('getEditor',{ index: index, field: field });
                if (ed) {
                    ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                }
                editIndex = index;
            } else {
                setTimeout(function () {
                    AddOrderDetailForm.controls.dgOrderDetailsIsDamage.datagrid('selectRow',editIndex);
                }, 0);
            }
        }
    }
    $(function () {
        AddOrderDetailForm.init();
    });
//})(jQuery);



