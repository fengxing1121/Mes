//(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var comboMaterial = undefined;
    var comboLocation = undefined;
    var MaterialID = "";
    var MaterialName = "";
    var MaterialCode = "";

    var LocationID = "";
    var Category = "";
    var LocationCode = "";

    var editIndex = undefined;

    var warehouse_inForm = {
        init: function () {
            warehouse_inForm.initControls();
            warehouse_inForm.events.loadData();
            warehouse_inForm.controls.searchData.on('click', warehouse_inForm.events.loadData);//加载数据            
            warehouse_inForm.controls.SaveWareHouseIn.on('click', warehouse_inForm.events.SaveWareHouseIn);//保存           
            warehouse_inForm.controls.edit_cancel.on('click', warehouse_inForm.events.Cancel);// 取消       
            warehouse_inForm.events.loadWareHouseIn();
            warehouse_inForm.events.loadSupplier();
            warehouse_inForm.events.loadComboboxMaterial();
            warehouse_inForm.events.loadComboboxWarehouse();
            warehouse_inForm.controls.search_supplier.on('click', warehouse_inForm.events.searchSupplier);//供应商 
            warehouse_inForm.controls.search_material.on('click', warehouse_inForm.events.searchMaterial);//材料  
            warehouse_inForm.controls.search_location.on('click', warehouse_inForm.events.searchLocation);//仓位 

            warehouse_inForm.events.verifyright();

        },
        initControls: function () {
            warehouse_inForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                edit_window: $('#edit_window'),
                dgWareHouseIn : $('#dgWareHouseIn'),                 
                SaveWareHouseIn: $('#btn_edit_save'),//保存按钮
                edit_cancel:$('#btn_edit_cancel'),            
                search_supplier: $('#btn_search_supplier'),
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
                warehouse_inForm.controls.dgdetail.datagrid({
                    idField: 'InID',
                    url: '/ashx/WarehouseInMainHandler.ashx?Method=SearchWarehouseInMain&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                        {
                            field: 'BillNo', title: '入库单号', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var  strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['InID'] + '\',\'' + rowData['BillNo'] + '\');">' + rowData['BillNo'] + '</a>';
                                return strReturn;
                            }
                        },
		               { field: 'BattchNo', title: '批次号', width: 150, align: 'center' },
                       { field: 'SupplierName', title: '供应商', width: 150, align: 'center' },
                       { field: 'HandlerMan', title: '经手人', width: 150, sortable: false, align: 'center' },
                       {
                           field: 'CheckInDate', title: '入库时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                               if (value == undefined) return "";
                               return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                           }
                       }
                    ]],
                    toolbar: ['-'
                     , { text: '新增入库', iconCls: 'icon-add', handler: function () { warehouse_inForm.events.NewWarehouseIn(); } }, '-'
                    ],
                    onBeforeLoad: function (param) {
                        warehouse_inForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        warehouse_inForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                })
            },

            loadSupplier: function () {
                $('#SupplierID').combogrid({
                    panelWidth: 750,
                    panelHeight: 480,
                    idField: 'SupplierID',
                    textField: 'SupplierName',
                    fitColumns: true,
                    sortName: 'SupplierID',
                    toolbar: '#tb',
                    url: '/ashx/Supplierhandler.ashx?Method=SearchSuppliers',
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    columns: [[
                            { field: 'SupplierName', title: '供应商名称', width: 100, align: 'center' },
                            { field: 'Category', title: '供应商类型', width: 200, halign: 'center', align: 'center' },
                            { field: 'SupplierCode', title: '供应商编号', width: 80, sortable: false, align: 'center' },
                            {
                                field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                    return (row.Province) + (row.City) + row.Address;
                                }
                            },
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_supplier').find('input').each(function (index) { param[this.name] = $(this).val(); });
                    },
                    onSelect: function (index, row) {
                        warehouse_inForm.controls.edit_form.form('load', row);
                    }
                });

            },

            loadWareHouseIn: function () {
                warehouse_inForm.controls.dgWareHouseIn.datagrid({
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
                        field: 'MaterialName', title: '材料名称', width: 150, sortable: false, align: 'center',
                        editor: {
                            type: 'combogrid',
                            options: {
                                panelWidth: 740,
                                panelHeight: 380,
                                idField: 'MaterialID',
                                textField: 'MaterialName',
                                fitColumns: true,
                                sortName: 'MaterialID',
                                toolbar: '#tbMaterial',
                                url: '/ashx/materialhandler.ashx?Method=SearchMaterials',
                                pagination: true,
                                editable: false,
                                nowrap: false,
                                required: true,
                                columns: [[
                                        { field: 'MaterialID', title: 'ID', hidden: true },
                                        { field: 'MaterialName', title: '材料名称', width: 150, align: 'center' },
                                        { field: 'Category', title: '材料类型', width: 150, halign: 'center', align: 'center' },
                                        { field: 'SubCategory', title: '材料子类型', width: 150, sortable: false, align: 'center' },
                                        { field: 'MaterialCode', title: '材料编号', width: 150, sortable: false, align: 'center' }
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
                                    MaterialCode = row.MaterialCode;
                                }
                            }
                        }
                    },
                    { field: 'LocationID', title: 'ID', hidden: true },
                    {
                        field: 'Category', title: '仓位', width: 150, sortable: false, align: 'center', editor: {
                            type: 'combogrid',
                            options: {
                                panelWidth: 740,
                                panelHeight: 380,
                                idField: 'LocationID',
                                textField: 'Category',
                                fitColumns: true,
                                sortName: 'LocationID',
                                toolbar: '#tbLocation',
                                url: '/ashx/warehousehandler.ashx?Method=SearchLocation',
                                pagination: true,
                                editable: false,
                                nowrap: false,
                                required: true,
                                columns: [[
                                        { field: 'LocationID', title: 'ID', hidden: true },
                                        { field: 'Category', title: '所属仓库', width: 150, align: 'center' },
                                        { field: 'LocationCode', title: '位置编号', width: 150, halign: 'center', align: 'center' },
                                        { field: 'CabinetNum', title: '货架号', width: 150, sortable: false, align: 'center' },
                                        { field: 'LayerNum', title: '层号', width: 150, sortable: false, align: 'center' }
                                ]],
                                onShowPanel: function () {
                                    comboLocation = this;
                                },
                                onBeforeLoad: function (param) {
                                    $('#search_form_location').find('input').each(function (index) { param[this.name] = $(this).val(); });
                                },
                                onSelect: function (index, row) {
                                    Category = row.Category;
                                    LocationID = row.LocationID;
                                    LocationCode = row.LocationCode;
                                }
                            }
                        }
                    },

                    {
                        field: 'Qty', title: '数量', width: 100, sortable: false, align: 'center', editor: {
                            type: 'numberbox',
                            required: true,
                            min: 1,
                            max: 10
                        }
                    },
                    {
                        field: 'Price', title: '零售单价', width: 120, sortable: false, align: 'center', editor: {
                            type: 'numberbox',
                            required: true,
                            min: 0
                        }
                    },
                    {
                        field: 'action', title: '操作', width: 50, align: 'center', formatter: function (value, row, index) {
                            return '<a href="#"   onclick="cancelrow(' + index + ')"><span class="delete">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        }
                    }
                    ]],
                    toolbar: [
                        { text: '增加', iconCls: 'icon-add', handler: warehouse_inForm.events.addrow },
                        { text: '取消', iconCls: 'icon-cancel', handler: warehouse_inForm.events.cancelall }
                    ],
                    onClickCell: warehouse_inForm.events.onClickCell,
                    onEndEdit: warehouse_inForm.events.onEndEdit
                });
            },

            NewWarehouseIn: function () {

                warehouse_inForm.controls.edit_window.window('open');
                warehouse_inForm.controls.edit_form.form('clear');
                warehouse_inForm.controls.dgWareHouseIn.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
                $('#search_form_supplier').form('clear');//清空供应商列表查询项
                $('#search_form_material').form('clear');//清空材料列表查询项
                $('#search_form_location').form('clear');//清空仓位列表查询项
                $("#InID").val(warehouse_inForm.events.loadNewGuid());
                $('#SupplierID').combogrid("grid").datagrid("reload", {});

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

            SaveWareHouseIn: function () {
                if (warehouse_inForm.events.endEditing()) {
                    warehouse_inForm.controls.dgWareHouseIn.datagrid('acceptChanges');
                }
                var rows = warehouse_inForm.controls.dgWareHouseIn.datagrid('getRows');
                var kv = [];
                if (rows.length == 0) {
                    showError("最少需要添加一个入库产品。");
                    return;
                }
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].Qty == 0) {
                        showError("产品数量不能为0");
                        return;
                    }
                    kv.push({ DetailID: rows[i].DetailID, MaterialID: rows[i].MaterialID, LocationID: rows[i].LocationID, Qty: rows[i].Qty, Price: rows[i].Price });
                }

                //序列化对象为Json字符串
                var sd = JSON.stringify(kv);
                $('#WarehouseInDetail').val(sd);

                warehouse_inForm.controls.edit_form.form('submit', {
                    url: '/ashx/WarehouseInMainHandler.ashx?Method=SaveWareHouseIn&' + jsNC(),
                    data: warehouse_inForm.controls.edit_form.serialize(),
                    datatype: 'json',
                    onSubmit: function () {
                        var isValid = warehouse_inForm.controls.edit_form.form('validate');
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
                            warehouse_inForm.controls.edit_window.window('close');
                            warehouse_inForm.controls.dgdetail.datagrid('reload');
                        }
                    }
                });
            },

            Cancel: function () {
                warehouse_inForm.controls.edit_window.window('close');
            },

            searchSupplier: function () {
                $('#SupplierID').combogrid("grid").datagrid("reload");
            },

            searchMaterial: function () {
                if (comboMaterial != undefined) {
                    $(comboMaterial).combogrid('grid').datagrid('reload');
                }
            },

            searchLocation: function () {
                if (comboLocation != undefined) {
                    $(comboLocation).combogrid('grid').datagrid('reload');
                }
            },

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

            loadComboboxWarehouse: function () {
                //车间下拉
                $('#WarehouseID').combobox({
                    url: '/ashx/warehousehandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryID'

                });
            },

            ////添加行
            addrow: function () {
                if (warehouse_inForm.events.endEditing()) {
                    warehouse_inForm.controls.dgWareHouseIn.datagrid('appendRow', { DetailID: warehouse_inForm.events.loadNewGuid(), Qty: 1, Price: 0 });

                    editIndex = warehouse_inForm.controls.dgWareHouseIn.datagrid('getRows').length - 1;
                    warehouse_inForm.controls.dgWareHouseIn.datagrid('selectRow', editIndex)
                            .datagrid('beginEdit', editIndex);

                }
                //打开搜索页面
                $('#tbMaterial').find('form[id="search_form_material"]').css('display', 'block');
                $('#tbLocation').find('form[id="search_form_location"]').css('display', 'block');

            },
             
            endEditing: function () {
                if (editIndex == undefined) { return true }
                if (warehouse_inForm.controls.dgWareHouseIn.datagrid('validateRow', editIndex)) {
                    warehouse_inForm.controls.dgWareHouseIn.datagrid('endEdit', editIndex);
                    if (!warehouse_inForm.events.isRepeartRow()) {
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
                var rows = warehouse_inForm.controls.dgWareHouseIn.datagrid('getRows');
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].MaterialName == rows[j].MaterialName) {
                            showError("产品名称【" + rows[j].MaterialName + "】重复添加。");
                            return true;
                        }
                    }
                }
                return false;
            },

            onClickCell: function (index, field) {
                if (editIndex != index) {
                    if (warehouse_inForm.events.endEditing()) {
                        warehouse_inForm.controls.dgWareHouseIn.datagrid('selectRow', index)
                                .datagrid('beginEdit', index);
                        var ed = warehouse_inForm.controls.dgWareHouseIn.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }

                        editIndex = index;
                    } else {
                        setTimeout(function () {
                            warehouse_inForm.controls.dgWareHouseIn.datagrid('selectRow', editIndex);
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
                if (LocationCode != "") {
                    row.LocationCode = LocationCode;
                }
                if (Category != "") {
                    row.Category = Category;
                }
                warehouse_inForm.controls.dgWareHouseIn.datagrid('refreshRow',index);
                MaterialID = "";
                MaterialCode = "";
                MaterialName = "";
                LocationID = "";
                LocationCode = "";
                Category = "";

            },

            //取消所有行
            cancelall: function () {
                warehouse_inForm.controls.dgWareHouseIn.datagrid('rejectChanges');
            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + warehouse_inForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(data);
                        }
                    }
                });
            }
        }

    };
    function rightType( data) {
        
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

    //移除行
    function cancelrow() {
        if (editIndex == undefined) { return }
        $('#dgWareHouseIn').datagrid('cancelEdit', editIndex)
                .datagrid('deleteRow', editIndex);
        editIndex = undefined;
    }

    $(function () {
        warehouse_inForm.init();
    });

//})(jQuery);

 


//查看详情        
function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/managerment/warehouse/WarehouseInDetail.aspx?inid=" + id + "&" + jsNC());
}