'use strict';
document.msCapsLockWarningOff = true;  
var editIndex = undefined;
var comboLocation = undefined;
var LocationID = "";
var Category = "";
var LocationCode = "";
var CabinetNum = "";
var LayerNum = "";
var orders_checkinForm = {
    init: function () {
        orders_checkinForm.initControls();
        orders_checkinForm.controls.searchData.on('click', function () { orders_checkinForm.controls.dgdetail.datagrid('reload'); });//加载数据
        orders_checkinForm.controls.SearchLocation.on('click', orders_checkinForm.events.SearchLocation);//查询位置       
        orders_checkinForm.controls.SearchOrder.on('click', orders_checkinForm.events.searchOrder);//查询订单
        orders_checkinForm.controls.edit_save.on('click', orders_checkinForm.events.edit_save);//提交
        orders_checkinForm.controls.edit_cancel.on('click', orders_checkinForm.events.cancel);//取消       
        orders_checkinForm.events.loadData();
        orders_checkinForm.events.loadOrder();
        orders_checkinForm.events.loadPackages();       
        orders_checkinForm.events.CabinetType(); 
    },
    initControls: function () {
        orders_checkinForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据           
            search_form: $('#search_form'),//查询表单   
            edit_window: $('#edit_window'),
            edit_form: $('#edit_form'),
            SearchLocation: $('#btnSearchLocation'),
            edit_cancel: $('#btn_edit_cancel'), 
            edit_save: $('#btn_edit_save'),
            SearchOrder: $('#btnSearchOrder'), 
            selectedPackages: $('#selectedPackages')
        }
        $('#btn_search_ok').linkbutton()
        $('#btnSearchOrder').linkbutton()
        $('#btnSearchLocation').linkbutton()
                 
        //隐藏搜索页面
        $('#order_bar').find('form[id="search_form_order"]').css('display', 'none');
        $('#Location_bar').find('form[id="search_form_location"]').css('display', 'none');       
    },
    events: {
        loadData: function () {
            orders_checkinForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'OrderID',
                url: '/ashx/ProductWarehouseMainHandler.ashx?Method=SearchProductWarehouseMain&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: true,               
                columns: [[                
                {
                    field: 'BillNo', title: '入库单号', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showindetail(\'' + rowData['InID'] + '\',\'' + rowData['BillNo'] + '\');">' + rowData['BillNo'] + '</a>';
                        return strReturn;
                    }
                },
                { field: 'OrderNo', title: '订单编号', width: 120, align: 'center' },
                { field: 'CustomerName', title: '客户名称', width: 85, sortable: false, halign: 'center', align: 'center' },               
                { field: 'Address', title: '客户地址', width: 220, sortable: false, halign: 'center', align: 'center' },
                { field: 'LinkMan', title: '联系人', width: 70, sortable: false, halign: 'center', align: 'center' },
                { field: 'Mobile', title: '联系电话', width: 95, sortable: false, align: 'center' },                
                {
                    field: 'Created', title: '入库时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                    }
                }
                  
                ]],
                toolbar: [
                      { text: '订单上架', iconCls: 'icon-add', handler: orders_checkinForm.events.CheckIn },
                ],
                onBeforeLoad: function (param) {
                    orders_checkinForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    orders_checkinForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },
                  
        loadOrder: function () {
            $('#OrderID').combogrid({
                panelWidth: 640,
                panelHeight: 380,
                idField: 'OrderID',
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
                    $('#H_OrderNo').val(row.OrderNo);
                    orders_checkinForm.controls.selectedPackages.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
                    orders_checkinForm.events.loadRows(row.OrderID);
                    $('#Location_bar').find('form[id="search_form_location"]').css('display', 'block');
                }
            });

        },

        loadPackages: function () {  
            orders_checkinForm.controls.selectedPackages.datagrid({
                sortName: 'Created',
                idField: 'OrderID',
                //url: '/ashx/OrdersHandler.ashx?Method=PackageNumTree&OrderID=' + id,
                collapsible: false,
                fitColumns: true,
                pagination: false,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,               
                singleSelect: false,
                columns: [[
                { field: 'cp', checkbox: true },
                { field: 'OrderNo', title: '订单号', width: 90, align: 'center' },
                { field: 'CabinetName', title: '产品名称', width: 90, align: 'center' },
                { field: 'PackageNum', title: '包号', width: 50, align: 'center' },                
                {
                    field: 'Location', title: '仓位', width: 150, sortable: false, align: 'center', editor: {
                        type: 'combogrid',
                        options: {
                            panelWidth: 500,
                            panelHeight: 250,
                            idField: 'LocationCode',
                            textField: 'LocationCode',
                            fitColumns: true,
                            sortName: 'LocationCode',
                            toolbar: '#Location_bar',
                            url: '/ashx/warehousehandler.ashx?Method=SearchOrderLocation',
                            pagination: true,
                            editable: false,
                            nowrap: false,
                            columns: [[
                                    { field: 'Category', title: '所属仓库', width: 100, align: 'center' },
                                    { field: 'LocationCode', title: '位置编号', width: 100, align: 'center' },
                                    { field: 'CabinetNum', title: '货架号', width: 100, align: 'center' },
                                    { field: 'LayerNum', title: '层号', width: 100, align: 'center' },
                            ]],
                            onShowPanel: function () {
                                comboLocation = this;
                            },
                            onBeforeLoad: function (param) {
                                $('#search_form_location').find('input').each(function (index) { param[this.name] = $(this).val(); });
                            },
                            onSelect: function (index, row) {                               
                                LocationID = row.LocationID;
                                Category = row.Category;
                                LocationCode = row.LocationCode;
                                CabinetNum = row.CabinetNum;
                                LayerNum = row.LayerNum;
                            }
                        }
                    }
                },
                { field: 'Category', title: '仓库名', width: 70, align: 'center' },
                { field: 'CabinetNum', title: '货架号', width: 70, align: 'center' },
                { field: 'LayerNum', title: '层号', width: 70, align: 'center' }
                ]],               
                onBeforeLoad: function (param) {
                    orders_checkinForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    orders_checkinForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });                   
                },
                onClickCell: orders_checkinForm.events.onClickCell,
                onEndEdit: orders_checkinForm.events.onEndEdit                 
            });
        },

        loadRows: function (orderid) {
            $.ajax({
                url: '/ashx/OrdersHandler.ashx?Method=PackageNumTree',
                data: { OrderID: orderid },
                datatype: "json",
                success: function (data) {
                    if (data) {
                        for (var i = 0; i < data.total; i++) {
                            if (orders_checkinForm.events.endEditing()) {
                                orders_checkinForm.controls.selectedPackages.datagrid('appendRow',
                                    {
                                        OrderNo: $('#H_OrderNo').val(),
                                        PackageID: data.rows[i].PackageID,
                                        CabinetName: data.rows[i].CabinetName,
                                        PackageNum: data.rows[i].PackageNum,
                                        Weight: data.rows[i].Weight
                                    });
                            }
                        }
                    }
                }
            });
        },

        onClickCell: function (index, field) {
            if (editIndex != index) {
                if (orders_checkinForm.events.endEditing()) {
                    orders_checkinForm.controls.selectedPackages.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = orders_checkinForm.controls.selectedPackages.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }
                    editIndex = index;
                } else {
                    setTimeout(function () {
                        orders_checkinForm.controls.selectedPackages.datagrid('selectRow', index);
                    }, 0);
                }
            }
        },

        onEndEdit: function (index, row) {
            if (LocationID != "") {
                row.LocationID = LocationID;
            }
            if (Category != "") {
                row.Category = Category;
            }           
            if (LocationCode != "") {
                row.LocationCode = LocationCode;
            }
            if (CabinetNum != "") {
                row.CabinetNum = CabinetNum;
            }
            if (LayerNum != "") {
                row.LayerNum = LayerNum;
            }
            orders_checkinForm.controls.selectedPackages.datagrid('refreshRow', index);
            LocationID = "";
            Category = "";
            LocationCode = "";
            CabinetNum = "";
            LayerNum = "";
            orders_checkinForm.events.getChecked(row.LocationID,row.Category, row.LocationCode, row.CabinetNum, row.LayerNum);
        },
         
        endEditing: function () {
            if (editIndex == undefined) { return true }
            if (orders_checkinForm.controls.selectedPackages.datagrid('validateRow', editIndex)) {
                orders_checkinForm.controls.selectedPackages.datagrid('endEdit', editIndex);
                editIndex = undefined;
                return false;
                //if (!orders_checkinForm.events.isRepeartRow()) {
                //    editIndex = undefined;
                //    return true;
                //}
                //else {
                //    return false;
                //}
            }
            else {
                return false;
            }
        },

        getChecked: function (LocationID, Category, LocationCode, CabinetNum, LayerNum) {
            var rows= orders_checkinForm.controls.selectedPackages.datagrid('getChecked');
            for (var i = 0; i < rows.length; i++) {
                var rowIndex = orders_checkinForm.controls.selectedPackages.datagrid('getRowIndex', rows[i]);
                orders_checkinForm.controls.selectedPackages.datagrid('updateRow', {
                    index: rowIndex,
                    row: {
                        LocationID: LocationID,
                        Category: Category,
                        Location: LocationCode,
                        CabinetNum: CabinetNum,
                        LayerNum: LayerNum                    }
                });
            }             
            orders_checkinForm.controls.selectedPackages.datagrid('clearSelections');
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

        CheckIn: function () {
            $('#edit_window').window('open');
            orders_checkinForm.controls.edit_form.form('clear');
            orders_checkinForm.controls.selectedPackages.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存          
            $('#order_bar').find('form[id="search_form_order"]').css('display', 'block');
            $('#Location_bar').find('form[id="search_form_location"]').css('display', 'none');
        },
                
        //提交
        edit_save: function () {
            if (orders_checkinForm.events.endEditing()) {
                orders_checkinForm.controls.selectedPackages.datagrid('acceptChanges');
            }
            var rows = orders_checkinForm.controls.selectedPackages.datagrid('getRows');
            var kv = [];           
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].LocationID == undefined || rows[i].LocationID == null) {
                    i = i + 1;
                    showError("第"+i+"行未选择仓位");
                    return false;
                }
                kv.push({ PackageID: rows[i].PackageID, LocationID: rows[i].LocationID, Weight: rows[i].Weight });
            }
            if ($('#BillNo').val() == "") {
                showError("请输入入库单号");
                return false;
            }

            //序列化对象为Json字符串
            var sd = JSON.stringify(kv);
            $('#InDetail').val(sd);

            orders_checkinForm.controls.edit_form.form('submit', {
                url: '/ashx/ProductWarehouseMainHandler.ashx?Method=OrderCheckIn&' + jsNC(),
                data: orders_checkinForm.controls.edit_form.serialize(),
                datatype: 'json',
                onSubmit: function () {
                    var isValid = orders_checkinForm.controls.edit_form.form('validate');
                    if (!isValid) {
                        return isValid;
                    }
                    else {
                        $('<div id="unloadMask"></div>').appendTo('body').height($("body").height());
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
                        orders_checkinForm.controls.edit_window.window('close');
                        orders_checkinForm.controls.dgdetail.datagrid('reload');
                        orders_checkinForm.events.loadOrder();
                        //刷新仓位
                        if (comboLocation != undefined) {
                            $(comboLocation).combogrid('grid').datagrid('reload');
                        }
                    }
                }
            });
        },

        //取消
        cancel: function () {
            orders_checkinForm.controls.edit_window.window('close');
            $('#Location_bar').find('form[id="search_form_location"]').css('display', 'none');
        },

        CabinetType: function () {
            $('#CabinetType').combobox({
                url: '/ashx/categoryhandler.ashx?Method=GetCabinetType',
                textField: 'CategoryName',
                valueField: 'CategoryName',
            });
        },

        searchOrder: function () {
            $('#OrderID').combogrid("grid").datagrid("reload");
        },

        SearchLocation: function () {
            if (comboLocation != undefined) {
                $(comboLocation).combogrid('grid').datagrid('reload');
            }
        }
    }
};
$(function () {
    orders_checkinForm.init();
});
 

//查看详情
function showindetail(id, no) {
    top.addTab("查看详情-" + no, "/View/orders/orders_checkinDetail.aspx?inid=" + id + "&" + jsNC(), 'table');
}
