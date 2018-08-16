(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var locationForm = {
        init: function () {
            
            locationForm.initControls();
            locationForm.events.loadData();
            locationForm.controls.searchData.on('click', locationForm.events.loadData);//加载数据
            locationForm.controls.newlocations.on('click', locationForm.events.newlocations);//新增
            locationForm.controls.savelocations.on('click', locationForm.events.savelocations);//保存    
            locationForm.controls.IsDisabled.on('click', locationForm.events.IsDisabled);// 是否禁用
            locationForm.controls.edit_cancel.on('click', locationForm.events.edit_cancel)
            locationForm.controls.batch_edit_save.on('click', locationForm.events.SaveBatchLocations)
            locationForm.events.newlocations();
            locationForm.events.loadCombobox();
            locationForm.events.verifyright();

        },
        initControls: function () {
            locationForm.controls = {
                pid:getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form_manage'),//编辑表单
                newlocations: $('#btn_edit_new'),//新增按钮
                savelocations: $('#btn_edit_submit'),//保存按钮
                edit_window:$('#edit_window'),//批量添加仓位
                IsDisabled: $('#IsDisabled'),         
                edit_cancel: $('#btn_edit_cancel'),
                batch_edit_save: $('#btn_edit_save'),//批量保存
                batch_edit_form: $('#edit_form')
            }
            $('#btn_search_ok').linkbutton();
           
        },
        events: {

            loadData: function () {
                locationForm.controls.dgdetail.datagrid({
                    sortName: 'Created',
                    idField: 'LocationID',
                    url: '/ashx/warehousehandler.ashx?Method=SearchLocation',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[                     
                    { field: 'Category', title: '所属仓库', width: 120, sortable: false, align: 'center' },
                    { field: 'LocationCode', title: '位置编号', width: 150, align: 'center' },
                    { field: 'CabinetNum', title: '货架号', width: 150, sortable: false, align: 'center' },
                    { field: 'LayerNum', title: '层号', width: 100, sortable: false, align: 'center' },
                    { field: 'Weight', title: '重量(kg)', width: 100, sortable: false, align: 'center' },
                    { field: 'MaxWeight', title: '最大重量(kg)', width: 100, sortable: false, align: 'center' },
                    { field: 'PackageQty', title: '存放包数', width: 100, sortable: false, align: 'center' },
                    { field: 'MaxPackage', title: '最大包数', width: 100, sortable: false, align: 'center' },
                    
                    {
                        field: 'IsDisabled', title: '是否禁用', width: 80, sortable: false, align: 'center', formatter: function (value, row, index) {
                            if (value == "True") {
                                return "<span style='color:red;'>√</span>";
                            }
                            return "";
                        }
                    },
                    {
                        field: 'Flag', title: '是否占用', width: 80, sortable: false, align: 'center', formatter: function (value, row, index) {
                            if (value == "True") {
                                return "<span style='color:red;'>√</span>";
                            }
                            return "";
                        }
                    },
                    
                    ]],
                    toolbar: [
                        { text: '批量添加仓位', iconCls: 'icon-add', handler: locationForm.events.batchlocations }
                    ],
                    onBeforeLoad: function (param) {

                        locationForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        locationForm.controls.search_form.find('input').each(function (index) {
                            locationForm.controls.search_form.find('select').each(function (index) {
                                param[this.name] = $(this).val();
                            });
                            locationForm.controls.search_form.find('input').each(function (index) {
                                if (this.name != "")
                                    param[this.name] = $(this).val();

                            });
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        locationForm.events.modifylocation();
                        
                    }
                });

                
            },

            batchlocations:function(){
                locationForm.controls.edit_window.window('open');
            },

            newlocations: function () {
                
                $.ajax({
                    url: '/ashx/warehousehandler.ashx?Method=NewLocation',
                    success: function (data) {
                        locationForm.controls.search_form.find("#LocationlID").val(data.LocationlID);
                        locationForm.controls.edit_form.form('load', data);

                        locationForm.controls.savelocations.show();
                    }
                });

            },

            savelocations: function () {
                if (locationForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/warehousehandler.ashx?Method=SaveLocation',
                        data: locationForm.controls.edit_form.serialize(),
                        loadMsg: '正在提交数据，请稍候....',
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                } else {                                   
                                    locationForm.controls.dgdetail.datagrid('reload');
                                }
                            }
                        }
                    });
                }
            },

            modifylocation: function () {
                var row = locationForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/warehousehandler.ashx?Method=GetLocation ',
                        data: { LocationID: row.LocationID },
                        success: function (data) {                            
                            locationForm.controls.edit_form.form('load', data);
                            locationForm.controls.edit_form.find('#IsDisabled').prop('checked', data["IsDisabled"] == 'True' ? true : false);
                            locationForm.controls.edit_form.find('#IsDisabled').val(data["IsDisabled"]);
                            if (!locationForm.options.isModify)//不等于true，则隐藏保存图标
                            {
                                locationForm.controls.savelocations.hide();
                            }
                        }
                    });
                }
            },

            loadCombobox: function () {
                $('#Warehouse,#WarehouseID,#SearchWarehouseID').combobox({
                    url: '/ashx/warehousehandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryID',
                    editable: false
                });
            },

            IsDisabled: function () {
                if ($(this)[0].checked == true)
                    $(this).val("True");
                else
                    $(this).val("False");

            },

            edit_cancel: function () {
                locationForm.controls.edit_window.window('close');
            },

            SaveBatchLocations: function () {
                if (locationForm.controls.batch_edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/warehousehandler.ashx?Method=SaveBattchLocation',
                        data: locationForm.controls.batch_edit_form.serialize(),
                        loadMsg: '正在提交数据，请稍候....',
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {                                    
                                    locationForm.controls.dgdetail.datagrid('reload');
                                    locationForm.controls.edit_window.window('close');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }

            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + locationForm.controls.pid,
                    success: function (data) {
                        if(data)
                        {
                            rightType(locationForm.controls.newlocations, locationForm.controls.savelocations, data);                         
                        }
                    }
                });
            }
        },
        //用于判断是否有编辑权限
        options: {
            isModify:false
        }

    };
    function rightType(eleAdd, eleSave, data) {
        $(eleAdd).hide();
        $(eleSave).hide();
        $('div.datagrid div.datagrid-toolbar').hide()//批量仓位隐藏
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $(eleAdd).show();
                    $(eleSave).show();
                    $('div.datagrid div.datagrid-toolbar').show();
                    break;
                case 'Modify':
                    $(eleSave).show();
                    locationForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        locationForm.init();
    });

})(jQuery);

