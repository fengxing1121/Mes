'use strict';
var editIndex = undefined;
var comboOrder = undefined;
var OrderID = "";
var OrderNo = "";
var CustomerName = "";
var CustomerAddress = "";
var CustomerMobile = "";
document.msCapsLockWarningOff = true;
var orders_checkOutForm = {
    init: function () {
        orders_checkOutForm.initControls();
        orders_checkOutForm.controls.searchData.on('click', function () { orders_checkOutForm.controls.dgdetail.datagrid('reload'); });//加载数据
        orders_checkOutForm.controls.SearchOrder.on('click', orders_checkOutForm.events.SearchOrder);//查询订单
        orders_checkOutForm.controls.SearchCar.on('click', orders_checkOutForm.events.SearchCar);//查询车
        orders_checkOutForm.controls.SaveWareHouseOut.on('click', orders_checkOutForm.events.SaveWareHouseOut);//保存 
        orders_checkOutForm.controls.edit_cancel.on('click', orders_checkOutForm.events.Cancel);// 取消       
        orders_checkOutForm.events.loadData();
        orders_checkOutForm.events.loadCar();        
        orders_checkOutForm.events.CabinetType();
        orders_checkOutForm.events.dgWareHouseOut();
    },
    initControls: function () {
        orders_checkOutForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form'),//查询表单   
            edit_window: $('#edit_window'),
            edit_form: $('#edit_form'),
            SearchOrder: $('#btnSearchOrder'),
            SaveWareHouseOut: $('#btn_edit_save'),//保存按钮
            edit_cancel: $('#btn_edit_cancel'),//取消 
            SearchCar: $('#search_car'),
            dgWareHouseOut: $('#dgWareHouseOut'),
        }
        $('#btn_search_ok').linkbutton()
        $('#search_car').linkbutton()
        $('#BookingDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var BookingDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var BookingDateFrom = $("#BookingDateFrom").datebox("getValue");
                if (BookingDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#BookingDateTo').datebox("setValue", '');
                }
                if (BookingDateFrom > BookingDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#BookingDateTo').datebox("setValue", '');
                }

            }
        });
        $('#ShipDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var ShipDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var ShipDateFrom = $("#ShipDateFrom").datebox("getValue");
                if (ShipDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }
                if (ShipDateFrom > ShipDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }

            }
        });

        //隐藏搜索页面
        $('#order_bar').find('form[id="search_form_order"]').css('display', 'none');
    },
    events: {
        loadData: function () {
            orders_checkOutForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'TransportID',
                url: '/ashx/TransportMainHandler.ashx?Method=SearchWarehouseOutMain&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: true,
                columns: [[
                {
                    field: 'TransportNo', title: '运输单号', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showoutdetail(\'' + rowData['TransportID'] + '\',\'' + rowData['TransportNo'] + '\');">' + rowData['TransportNo'] + '</a>';
                        return strReturn;
                    }
                },
                { field: 'EnterpriseName', title: '物流名称', width: 120, align: 'center' },
                { field: 'PlateNo', title: '车牌号', width: 75, sortable: false, halign: 'center', align: 'center' },
                { field: 'DriverName', title: '驾驶人', width: 70, sortable: false, halign: 'center', align: 'center' },
                { field: 'Source', title: '出发地', width: 70, sortable: false, halign: 'center', align: 'center' },
                { field: 'Target', title: '目的地', width: 95, sortable: false, align: 'center' },
                { field: 'Price', title: '运输费用', width: 75, sortable: false, align: 'center' },
                {
                    field: 'Created', title: '出库时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                    }
                } 
                ]],
                toolbar: [
                      { text: '订单发货', iconCls: 'icon-add', handler: orders_checkOutForm.events.CheckOut },
                ],
                onBeforeLoad: function (param) {
                    orders_checkOutForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    orders_checkOutForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },

        dgWareHouseOut: function () {
            orders_checkOutForm.controls.dgWareHouseOut.datagrid({
                idField: 'TransportID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'TransportID', title: '运输ID', hidden: true },
                { field: 'OrderID', title: 'ID', hidden: true },
                {
                    field: 'OrderNo', title: '订单编号', width: 150, sortable: false, align: 'center', editor: {
                        type: 'combogrid',
                        options: {
                            panelWidth: 740,
                            panelHeight: 280,
                            idField: 'OrderNo',
                            textField: 'OrderNo',
                            fitColumns: true,
                            sortName: 'OrderID',
                            toolbar: '#order_bar',
                            url: '/ashx/ordershandler.ashx?Method=SearchOrders',
                            pagination: true,
                            editable: false,
                            nowrap: false,
                            required: true,
                            columns: [[
                                     { field: 'OrderID', title: 'ID', hidden: true },
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
                            onShowPanel: function () {
                                comboOrder = this;
                            },

                            onBeforeLoad: function (param) {
                                $('#search_form_order').find('input').each(function (index) { param[this.name] = $(this).val(); });
                            },
                            onSelect: function (index, row) {
                                OrderNo = row.OrderNo;
                                OrderID = row.OrderID;
                                CustomerName = row.CustomerName;
                                CustomerAddress =row.Address;
                                CustomerMobile = row.Mobile;
                            }
                        }
                    }
                },
                { field: 'CustomerName', title: '客户名称', width: 85, sortable: false, halign: 'center', align: 'center' },
                { field: 'Address', title: '客户地址', width: 200, sortable: false, halign: 'center', align: 'center' },
                { field: 'Mobile', title: '联系电话', width: 90, sortable: false, align: 'center' },                
                {
                    field: 'action', title: '操作', width: 50, align: 'center', formatter: function (value, row, index) {
                        return '<a href="#"   onclick="cancelrow(' + index + ')"><span class="delete">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;移除</a>';
                    }
                }
                ]],
                toolbar: [
                    { text: '增加', iconCls: 'icon-add', handler: orders_checkOutForm.events.addrow },
                    { text: '取消', iconCls: 'icon-cancel', handler: orders_checkOutForm.events.cancelall }
                ],
                onClickCell: orders_checkOutForm.events.onClickCell,
                onEndEdit: orders_checkOutForm.events.onEndEdit
            });
        },

        loadCar: function () {
            $('#CarID').combogrid({
                panelWidth: 640,
                panelHeight: 380,
                idField: 'CarID',
                textField: 'CarName',
                fitColumns: true,               
                toolbar: '#car_bar',
                url: '/ashx/CarHandler.ashx?Method=SearchCars&' + jsNC(),
                pagination: true,
                editable: false,
                nowrap: false,
                columns: [[
                    { field: 'PlateNo', title: '车牌号码', width: 150, align: 'center' },
                    { field: 'CarName', title: '车名', width: 80, sortable: false, align: 'center' },
                    { field: 'CarStyle', title: '车型', width: 120, sortable: false, align: 'center' },
                    { field: 'DriverName', title: '驾驶人', width: 120, sortable: false, align: 'center' },
                    { field: 'Mobile', title: '移动电话', width: 100, sortable: false, align: 'center' },

                ]],
                onBeforeLoad: function (param) {
                    $('#search_form_car').find('input').each(function (index) { param[this.name] = $(this).val(); });
                },
                onSelect: function (index, row) {
                    //$('#H_CustomerID').val(row.OrderNo);
                    //addorderForm.controls.edit_form.form('load', row);
                    //$("#Address").val(row.Province + row.City + row.Address);
                    //addorderForm.controls.edit_form.find('#OrderType').val('补货');
                    //addorderForm.controls.edit_form.find('#Status').val('待拆单');
                    //addorderForm.controls.edit_form.find('#PurchaseNo').val(row.OrderNo);
                    //addorderForm.controls.edit_form.find('#BookingDate').datebox('setValue', (new Date()).Formats('yyyy-MM-dd'));
                    //addorderForm.controls.edit_form.find('#ShipDate').datebox('setValue', '');
                    //addorderForm.controls.edit_form.find('#OrderNo').val('自动生成');
                }
            });

        },

        CheckOut: function () {             
            $('#edit_window').window('open');
            orders_checkOutForm.controls.edit_form.form('clear');
            orders_checkOutForm.controls.dgWareHouseOut.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 

            $("#TransportID").val(orders_checkOutForm.events.loadNewGuid());
        },
        
        CabinetType: function () {
            $('#CabinetType').combobox({
                url: '/ashx/categoryhandler.ashx?Method=GetCabinetType',
                textField: 'CategoryName',
                valueField: 'CategoryName',
            });
        },

        SaveWareHouseOut: function () {
            if (orders_checkOutForm.events.endEditing()) {
                orders_checkOutForm.controls.dgWareHouseOut.datagrid('acceptChanges');
            }
            

            var rows = orders_checkOutForm.controls.dgWareHouseOut.datagrid('getRows');
            var kv = [];
            if (rows.length == 0) {
                showError("最少需要添加一个出库订单。");
                return;
            }
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].OrderID == undefined || rows[i].OrderID==null) {
                    showError("请选择出库订单");
                    return false;
                }
                kv.push({ TransportID: rows[i].TransportID, OrderID: rows[i].OrderID });
            }
            if ($('#TransportNo').val() == "")
            {
                showError("请输入运输单号");
                return false;
            }


            //序列化对象为Json字符串
            var sd = JSON.stringify(kv);
            $('#OutDetail').val(sd);

            orders_checkOutForm.controls.edit_form.form('submit', {
                url: '/ashx/TransportMainHandler.ashx?Method=SaveTransportMainOut&' + jsNC(),
                data: orders_checkOutForm.controls.edit_form.serialize(),
                datatype: 'json',
                onSubmit: function () {
                    var isValid = orders_checkOutForm.controls.edit_form.form('validate');
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
                        orders_checkOutForm.controls.edit_window.window('close');
                        orders_checkOutForm.controls.dgdetail.datagrid('reload');
                    }
                }
            });

        },

        SearchCar: function () {
            $('#CarID').combogrid("grid").datagrid("reload");
        },

        Cancel: function () {
            orders_checkOutForm.controls.edit_window.window('close');
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

        ////添加行
        addrow: function () {
            if (orders_checkOutForm.events.endEditing()) {
                orders_checkOutForm.controls.dgWareHouseOut.datagrid('appendRow', {
                    TransportID: orders_checkOutForm.events.loadNewGuid(),
                    OrderNo:"请选择...."
                });
                editIndex = orders_checkOutForm.controls.dgWareHouseOut.datagrid('getRows').length - 1;
                orders_checkOutForm.controls.dgWareHouseOut.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }
            ////打开搜索页面
            $('#order_bar').find('form[id="search_form_order"]').css('display', 'block');
        },

        endEditing: function () {
            if (editIndex == undefined) { return true }
            if (orders_checkOutForm.controls.dgWareHouseOut.datagrid('validateRow', editIndex)) {
                orders_checkOutForm.controls.dgWareHouseOut.datagrid('endEdit', editIndex);
                if (!orders_checkOutForm.events.isRepeartRow()) {
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

        ////是否重复
        isRepeartRow: function () {
            var rows = orders_checkOutForm.controls.dgWareHouseOut.datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                for (var j = i + 1; j < rows.length; j++) {
                    if (rows[i].OrderNo == rows[j].OrderNo) {
                        showError("订单【" + rows[j].OrderNo + "】重复添加。");
                        return false;
                    }
                }
            }
            return false;
        },

        onClickCell: function (index, field) {
            if (editIndex != index) {
                if (orders_checkOutForm.events.endEditing()) {
                    orders_checkOutForm.controls.dgWareHouseOut.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = orders_checkOutForm.controls.dgWareHouseOut.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }

                    editIndex = index;
                } else {
                    setTimeout(function () {
                        orders_checkOutForm.controls.dgWareHouseOut.datagrid('selectRow', editIndex);
                    }, 0);
                }
            }
        },

        onEndEdit: function (index, row) {
            if (OrderID != "") {
                row.OrderID = OrderID;
            }
            if (OrderNo != "") {
                row.OrderNo = OrderNo;
            }
            if (CustomerName != "") {
                row.CustomerName = CustomerName;
            }
            if (CustomerAddress != "") {
                row.Address = CustomerAddress;
            }
            if (CustomerMobile != "") {
                row.Mobile = CustomerMobile;
            }
            orders_checkOutForm.controls.dgWareHouseOut.datagrid('refreshRow', index);
            OrderID = "";
            OrderNo = "";
            CustomerName = "";
            CustomerAddress = "";
            CustomerMobile = "";
        },
        
        //取消所有行
        cancelall: function () {
            if (orders_checkOutForm.events.endEditing()) {
                orders_checkOutForm.controls.dgWareHouseOut.datagrid('rejectChanges');
            }
        },

        SearchOrder: function () {
            if (comboOrder != undefined) {
                $(comboOrder).combogrid('grid').datagrid('reload');
            }

        }
    }
};

//移除
function cancelrow(index) {

    if (orders_checkOutForm.events.endEditing()) {
        if (index == undefined) { return false }
        $('#dgWareHouseOut').datagrid('deleteRow', index);
        var rows = $('#dgWareHouseOut').datagrid("getRows");
        $('#dgWareHouseOut').datagrid("loadData", rows);
        index = undefined; 
    }     
}


$(function () {
    orders_checkOutForm.init();
});

//查看详情
function showoutdetail(id, no) {
    top.addTab("查看详情-" + no, "/View/orders/orders_checkoutDetail.aspx?TransportID=" + id + "&" + jsNC(), 'table');
}
