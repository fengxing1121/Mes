/*!
 @Name：提交报价  
 @Author：
 @Remark：新增
 @Date：2018-07-05
 @License：MES  
 */
'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var editorderForm = {
    init: function () {
        editorderForm.initControls();
        editorderForm.events.loadCabinet();//加载数据          
        editorderForm.events.loadData();
        editorderForm.controls.saveorder.on('click', editorderForm.events.saveorder);//保存 
        editorderForm.events.loadCustomer();
    },
    initControls: function () {
        editorderForm.controls = {
            dgcabinet: $('#dgCabinet'),
            edit_form: $('#edit_form'),
            saveorder: $('#btn_edit_save'),
        }
    },
    events: {
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
                    console.log(JSON.stringify(data));

                    $("#BookingDate").val(new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                    $("#ShipDate").val(new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));

                    if (data.StepNo != (GetOrderStepNo(ordersprice)-1)) {
                        window.location.href = "/view/403.html";
                        return;
                    }
                }
            });
        },

        //添加产品
        loadCabinet: function () {
            editorderForm.controls.dgcabinet.datagrid({
                sortName: 'Sequence',
                idField: 'ProductID',
                collapsible: false,
                url: '/ashx/ordershandler.ashx?Method=GetOrderProducts',
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                    { field: 'ProductID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                    { field: 'ProductName', title: '产品名称',  width: 150, sortable: false, align: 'center' },
                    { field: 'ProductGroup', title: '产品编号',  width: 120, sortable: false, align: 'center' },
                    { field: 'Size', title: '产品规格', width: 120, sortable: false, align: 'center' },
                    { field: 'Color', title: '颜色', width: 120, sortable: false, align: 'center' },
                    { field: 'MaterialStyle', title: '风格',  width: 120, sortable: false, align: 'center' },
                    { field: 'Unit', title: '材质',  width: 120, sortable: false, align: 'center' },
                    { field: 'ProductName', title: '单位', width: 150, sortable: false, align: 'center' },
                    { field: 'Qty', title: '数量',  width: 150, sortable: false, align: 'center' },
                    { field: 'Price', title: '单价', width: 150, sortable: false, align: 'center' },
                    {
                        field: 'SalePrice', title: '报价(￥)', width: 80, sortable: false, align: 'center', editor: {
                            type: 'numberbox',
                            options: {
                                required: true,
                                min: 0
                            }
                        }
                    },
                    { field: 'Remark', title: '备注', width: 150, sortable: false, align: 'center' },
                ]],
                
                onBeforeLoad: function (param) {
                    var orderid = getUrlParam('orderid');
                    param['OrderID'] = orderid;
                   
                },
                onClickCell: editorderForm.events.onClickCell,
                onEndEdit: editorderForm.events.onEndEdit
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
                if (rows[i].SalePrice == 0) {
                    showError("【"+rows[i].ProductName + "】产品报价不能为0");
                    return;
                }
                kv.push({
                    ProductID: rows[i].ProductID,
                    SalePrice: rows[i].SalePrice,
                });
            }

            //序列化对象为Json字符串
            var sd = JSON.stringify(kv);
            $('#Cabinets').val(sd);
            editorderForm.controls.edit_form.form('submit', {
                url: '/ashx/ordershandler.ashx?Method=OrdersPrize&' + jsNC(),
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
                        $.messager.alert("提示", returnData.message, "info", function () {
                            var currTab = top.$(".tabs").find(".tabs-selected").text();
                            top.closeTab(currTab);
                        });
                    }
                }
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
                    editorderForm.controls.edit_form.form('load', row);
                    $("#Address").val(row.Province + row.City + row.Address);
                }
            });

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
            return false;
        },
        onEndEdit: function (index, row) {
            var ed = $(this).datagrid('getEditor', {
                index: index,
                field: 'ProductID'
            });
            //row.ProductName = $(ed.target).combobox('getText');
        },
    }
};

$(function () {
    editorderForm.init();
    setTimeout(function () {
        $(".tooltip-right").hide();
    }, 500);
});