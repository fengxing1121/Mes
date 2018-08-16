
//(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var comboMaterial = undefined;
    var comboLocation = undefined;
    var MaterialID = "";
    var MaterialName = "";
    var MaterialCode = "";
    var MateriaQty = "";
    var LocationID = "";
    

    var editIndex = undefined;

    var warehouse_outForm = {
        init: function () {
            warehouse_outForm.initControls();
            warehouse_outForm.events.loadData();
            warehouse_outForm.controls.searchData.on('click', warehouse_outForm.events.loadData);//加载数据            
            warehouse_outForm.controls.SaveWareHouseOut.on('click', warehouse_outForm.events.SaveWareHouseOut);//保存 
            warehouse_outForm.controls.edit_cancel.on('click', warehouse_outForm.events.Cancel);// 取消       
            warehouse_outForm.events.loadWareHouseOut();            
            warehouse_outForm.events.loadComboboxMaterial();
            warehouse_outForm.events.loadComboboxWorkShop();
            
            warehouse_outForm.events.verifyright();
        },
        initControls: function () {
            warehouse_outForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                edit_window: $('#edit_window'),
                dgWareHouseOut: $('#dgWareHouseOut'),                
                SaveWareHouseOut: $('#btn_edit_save'),//保存按钮
                edit_cancel: $('#btn_edit_cancel'),//取消
                
                search_material: $('#btn_form_material'),
                search_location: $('#btn_form_location')
            }
            $('#btn_search_ok').linkbutton()
            $('#btn_form_material').linkbutton();
            $('#btn_form_location').linkbutton();

            //隐藏搜索页面
            $('#tbMaterial').find('form[id="search_form_material"]').css('display', 'none');
            $('#tbLocation').find('form[id="search_form_location"]').css('display', 'none');
            
        },

        events: {

            loadData: function () {
                warehouse_outForm.controls.dgdetail.datagrid({
                    idField: 'OutID',
                    url: '/ashx/WarehouseOutMainHandler.ashx?Method=SearchWarehouseOutMain&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                        {
                            field: 'BillNo', title: '出库单号', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['OutID'] + '\',\'' + rowData['BillNo'] + '\');">' + rowData['BillNo'] + '</a>';
                                return strReturn;
                            }
                        },
	                    { field: 'WorkShopName', title: '使用车间', width: 150, align: 'center' },
                        { field: 'HandlerMan', title: '经手人', width: 150, sortable: false, align: 'center' },
                        {
                            field: 'CheckOutDate', title: '出库时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                if (value == undefined) return "";
                                return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                            }
                        }
                    ]],
                    toolbar: ['-'
                        , { text: '添加出库', iconCls: 'icon-add', handler: function () { warehouse_outForm.events. NewWarehouseOut(); } }, '-'
                    ],
                    onBeforeLoad: function (param) {
                        warehouse_outForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        warehouse_outForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                })
            },

            loadWareHouseOut: function () {
                warehouse_outForm.controls.dgWareHouseOut.datagrid({
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: true,
                    pagination: false,
                    columns: [[
                    { field: 'DetailID', title: '产品ID', hidden: true },
                    { field: 'MaterialID', title: 'ID', hidden: true },
                    {
                        field: 'MaterialName', title: '材料名称', width: 150, sortable: false, align: 'center', editor: {
                            type: 'combogrid',
                            options: {
                                panelWidth: 740,
                                panelHeight: 380,
                                idField: 'MaterialID',
                                textField: 'MaterialName',
                                fitColumns: true,
                                sortName: 'MaterialID',
                                toolbar: '#tbMaterial',
                                url: '/ashx/warehousehandler.ashx?Method=SearchWarehouse',
                                pagination: true,
                                editable: false,
                                nowrap: false,
                                required: true,
                                columns: [[
                                        { field: 'MaterialID', title: 'ID', hidden: true },
                                        { field: 'LocationID', title: 'ID', hidden: true },
                                        { field: 'MaterialName', title: '材料名称', width: 150, align: 'center' },
                                        { field: 'Category', title: '材料类型', width: 150, halign: 'center', align: 'center' },
                                        { field: 'SubCategory', title: '材料子类型', width: 150, sortable: false, align: 'center' },
                                        { field: 'MaterialCode', title: '材料编号', width: 150, sortable: false, align: 'center' },
                                        { field: 'WarehouseName', title: '所属仓库', width: 150, align: 'center' },
                                        { field: 'Qty', title: '数量', width: 100, align: 'center' }
                                ]],
                                onShowPanel: function () {
                                    comboMaterial = this;
                                },
                                onBeforeLoad: function (param) {
                                    $('#search_form_material').find('input').each(function (index) { param[this.name] = $(this).val(); });
                                },
                                onSelect: function (index, row) {
                                    MaterialName = row.MaterialName;
                                    MaterialID = row.MaterialID;
                                    LocationID = row.LocationID;
                                    MaterialCode = row.MaterialCode;
                                    MateriaQty = row.Qty;
                                }
                            }
                        }
                    },
                    { field: 'MateriaQty', title: '库存数量', width: 100, sortable: false, align: 'center' },
                  
                    {
                        field: 'Qty', title: '出库数量', width: 100, sortable: false, align: 'center', editor: {
                            type: 'numberbox',
                            required: true,
                            min: 1,
                            max: 10
                        }
                    },
                    {
                        field: 'action', title: '操作', width: 50, align: 'center',
                        formatter: function (value, row, index) {
                            return '<a href="#" onclick="cancelrow(' + index + ')"><span class="delete">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        }
                    }
                    ]],
                    toolbar: [
                        { text: '增加', iconCls: 'icon-add', handler: warehouse_outForm.events.addrow },
                        { text: '取消', iconCls: 'icon-cancel', handler: warehouse_outForm.events.cancelall }
                    ],
                    onClickCell:warehouse_outForm.events. onClickCell,
                    onEndEdit: warehouse_outForm.events.onEndEdit
                });

            },


            NewWarehouseOut: function () {

                warehouse_outForm.controls.edit_window.window('open');
                warehouse_outForm.controls.edit_form.form('clear');
                warehouse_outForm.controls.dgWareHouseOut.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
                $("#OutID").val(warehouse_outForm.events.loadNewGuid());

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

            SaveWareHouseOut: function () {
                if (warehouse_outForm.events. endEditing()) {
                    warehouse_outForm.controls.dgWareHouseOut.datagrid('acceptChanges');
                }
                var rows = warehouse_outForm.controls.dgWareHouseOut.datagrid('getRows');
                var kv = [];
                if (rows.length == 0) {
                    showError("最少需要添加一个出库产品。");
                    return;
                }
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].Qty == 0) {
                        showError("出库数量不能为0");
                        return;
                    }
                    if (rows[i].Qty > rows[i].MateriaQty) {
                        showError("出库数量不能大于入库数量");
                        return;
                    }
                    kv.push({ DetailID: rows[i].DetailID, MaterialID: rows[i].MaterialID, LocationID: rows[i].LocationID, Qty: rows[i].Qty });
                }

                //序列化对象为Json字符串
                var sd = JSON.stringify(kv);
                $('#WarehouseOutDetail').val(sd);

                warehouse_outForm.controls.edit_form.form('submit', {
                    url: '/ashx/WarehouseOutMainHandler.ashx?Method=SaveWareHouseOut&' + jsNC(),
                    data: warehouse_outForm.controls.edit_form.serialize(),
                    datatype: 'json',
                    onSubmit: function () {
                        var isValid = warehouse_outForm.controls.edit_form.form('validate');
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
                            warehouse_outForm.controls.edit_window.window('close');
                            warehouse_outForm.controls.dgdetail.datagrid('reload');
                        }
                    }
                });
            },


            Cancel: function () {
                warehouse_outForm.controls.edit_window.window('close');
            },

            //查看详情        
            showdetail: function (id, no) {
                top.addTab("查看【" + no + "】", "/Warehouse/WarehouseOutDetail.aspx?outid=" + id + "&" + jsNC());
            },           

            searchMaterial: function () {
                if (comboMaterial != undefined) {
                    $(comboMaterial).combogrid('grid').datagrid('reload');
                }

            },

            //searchLocation: function () {
            //    if (comboLocation != undefined) {
            //        $(comboLocation).combogrid('grid').datagrid('reload');
            //    }

            //},

            loadComboboxMaterial: function () {
                //材料类型联动子类
                $('#SearchCategoryID').combobox({
                    url: '/ashx/materialhandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                    onSelect: function (record) {
                        $('#SearchSubCategoryID').combobox({
                            url: '/ashx/materialhandler.ashx?Method=GetSubCategories&id=' + record.CategoryID,
                            textField: 'CategoryName',
                            valueField: 'CategoryName'

                        });
                    }
                });

            },

            loadComboboxWorkShop: function () {                 
                $('#WorkShopID').combobox({
                    url: '/ashx/workshophandler.ashx?Method=GetWorkShops&' + jsNC(),
                    textField: 'WorkShopName',
                    valueField: 'WorkShopID'

                });
            },

            ////添加行
            addrow: function () {
                if (warehouse_outForm.events.endEditing()) {
                    warehouse_outForm.controls.dgWareHouseOut.datagrid('appendRow', { DetailID: warehouse_outForm.events.loadNewGuid(), Qty: 1, Price: 0 });

                    editIndex = warehouse_outForm.controls.dgWareHouseOut.datagrid('getRows').length - 1;
                    warehouse_outForm.controls.dgWareHouseOut.datagrid('selectRow', editIndex)
                            .datagrid('beginEdit', editIndex);

                }
                //打开搜索页面
                $('#tbMaterial').find('form[id="search_form_material"]').css('display', 'block');
                $('#tbLocation').find('form[id="search_form_location"]').css('display', 'block');

            },

            //取消所有行
            cancelall: function () {
                warehouse_outForm.controls.dgWareHouseOut.datagrid('rejectChanges');
            },


            endEditing: function () {
                if (editIndex == undefined) { return true }
                if (warehouse_outForm.controls.dgWareHouseOut.datagrid('validateRow', editIndex)) {
                    warehouse_outForm.controls.dgWareHouseOut.datagrid('endEdit', editIndex);
                    if (!warehouse_outForm.events.isRepeartRow()) {
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
                var rows = warehouse_outForm.controls.dgWareHouseOut.datagrid('getRows');
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].MaterialName == rows[j].MaterialName) {
                            showError("产品名称【" + rows[j].MaterialName + "】重复添加。");
                            return false;
                        }
                    }
                }
                return false;
            },

            onClickCell: function (index, field) {
                if (editIndex != index) {
                    if (warehouse_outForm.events. endEditing()) {
                        warehouse_outForm.controls.dgWareHouseOut.datagrid('selectRow', index)
                                .datagrid('beginEdit', index);
                        var ed = warehouse_outForm.controls.dgWareHouseOut.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }

                        editIndex = index;
                    } else {
                        setTimeout(function () {
                            warehouse_outForm.controls.dgWareHouseOut.datagrid('selectRow', editIndex);
                        }, 0);
                    }
                }
            },

            onEndEdit: function (index, row) {                                   
                    
                    if (MaterialID != "") {
                        row.MaterialID = MaterialID;
                    }
                    if (MaterialName != "") {
                        row.MaterialName = MaterialName;
                    }
                    if (MaterialCode != "") {
                        row.MaterialCode = MaterialCode;
                    }
                    if (LocationID != "") {
                        row.LocationID = LocationID;
                    }
                    if (MateriaQty != "") {
                        row.MateriaQty = MateriaQty;
                    }
                    warehouse_outForm.controls.dgWareHouseOut.datagrid('refreshRow', index);
                    MaterialID = "";
                    MaterialCode = "";
                    MaterialName = "";
                    LocationID = "";
                    MateriaQty = "";

            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + warehouse_outForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(data);
                        }
                    }
                });
            }
        }
    };

    function rightType(data) {

        $('div.datagrid div.datagrid-toolbar').hide()
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $('div.datagrid div.datagrid-toolbar').show();
                    break;

                default: break;
            }
        });
    }
//移除
    function cancelrow() {
        if (editIndex == undefined) { return }
        $('#dgWareHouseOut').datagrid('cancelEdit', editIndex)
                .datagrid('deleteRow', editIndex);
        editIndex = undefined;
    }
    $(function () {
        warehouse_outForm.init();
    });

//})(jQuery);




//查看详情        
function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/managerment/Warehouse/WarehouseOutDetail.aspx?outid=" + id + "&" + jsNC());
}
