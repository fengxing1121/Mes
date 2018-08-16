(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var supplierForm = {
        init: function () {
            supplierForm.initControls();
            supplierForm.events.loadData();
            supplierForm.controls.searchData.on('click', supplierForm.events.loadData);//加载数据    
            supplierForm.controls.newsupplier.on('click', supplierForm.events.newsupplier);//新增
            supplierForm.controls.savesupplier.on('click', supplierForm.events.savesupplier);//保存    
            supplierForm.events.newsupplier();
            supplierForm.events.loadProvince();
            supplierForm.events.loadCombobox();
            supplierForm.events.loadSearchCombobox();
            supplierForm.events.verifyright();
                   
        },
        initControls: function () {
            supplierForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                newsupplier: $('#btn_new'),//新增按钮
                savesupplier: $('#btn_save')//保存
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                supplierForm.controls.dgdetail.datagrid({
                    idField: 'SupplierID',
                    url: '/ashx/SupplierHandler.ashx?Method=SearchSuppliers&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                            { field: 'SupplierName', title: '供应商名称', width: 150, align: 'center' },
                            { field: 'Category', title: '供应商类型', width: 150, align: 'center' },
                            { field: 'SupplierCode', title: '供应商编号', width: 150, align: 'center' },
                            {
                                field: 'p', title: '供应商地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                    return (row.Province) + (row.City) + row.Address
                                }
                            },                             
                          
                            { field: 'LinkMan', title: '联系人', width: 150, sortable: false, align: 'center' },
                            { field: 'Tel', title: '固定电话', width: 150, sortable: false, align: 'center' },
                            { field: 'Mobile', title: '移动电话', width: 150, sortable: false, align: 'center' },
                            { field: 'Email', title: '邮箱', width: 100, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        supplierForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        supplierForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        supplierForm.events.updatesupplier();
                    }
                });
            },


            newsupplier: function () {
                $.ajax({
                    url: '/ashx/SupplierHandler.ashx?Method=NewSupplier&' + jsNC(),
                    success: function (data) {
                        supplierForm.controls.edit_form.form('load', data);
                        supplierForm.controls.savesupplier.show();//显示保存按钮
                    }
                });
            },
            savesupplier: function () {
                if (supplierForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/SupplierHandler.ashx?Method=SaveSupplier',
                        data: supplierForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    supplierForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            updatesupplier: function () {
                var selectedRows = supplierForm.controls.dgdetail.datagrid('getSelections');
                var row = supplierForm.controls.dgdetail.datagrid('getSelected');
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/SupplierHandler.ashx?Method=GetSupplier&SupplierID=' + selectedRows[0]['SupplierID'],
                        success: function (data) {
                            supplierForm.controls.edit_form.form('load', data);
                            $("#City").combobox('setValue', data.City); //加载城市并获取值

                            if (!supplierForm.options.isModify) {
                                supplierForm.controls.savesupplier.hide();
                            }
                        }
                    });
                }

            },

            loadProvince: function () {
                $("#Province").combobox({
                    data: citydata,
                    valueField: 'provincecode',
                    textField: 'provincename',
                    required: true,
                    editable: false,
                    loadFilter: function (data) {
                        var defaultItem = [{ provincecode: '', provincename: '请选择省份' }];
                        var province = [];
                        $.each(data, function (i, val) {
                            var item = {};
                            item.provincecode = val.province;
                            item.provincename = val.province;
                            province.push(item);
                        });
                        return defaultItem.concat(province);//defaultItem.concat(data);
                    },
                    onChange: function (newvalue, oldvalue) {
                        supplierForm.events.LoadCity(newvalue);
                    },
                    onLoadError: function () {
                    }
                });
            },

            LoadCity: function (province) {
                $("#City").combobox('clear');
                $("#City").combobox({
                    data: citydata,
                    valueField: 'cityname',
                    textField: 'cityname',
                    required: true,
                    editable: false,
                    loadFilter: function (data) {
                        var defaultItem = [{ citycode: '', cityname: '请选择城市' }];
                        var p = data.filter(function (v) {
                            return v.province === province;
                        });
                        var city = [];
                        if (p.length > 0) {
                            $.each(p[0].city, function (i, val) {
                                var item = {};
                                item.citycode = val;
                                item.cityname = val;
                                city.push(item);
                            });
                        }
                        return defaultItem.concat(city);
                    },
                    onChange: function (newvalue, oldvalue) {
                        //customerForm.events.LoadCity(newvalue);
                    },
                    onLoadError: function () {
                    }
                });
                $("#City").combobox('setValue','');
            },

            

            loadCombobox: function ()
            {
                $('#CategoryID').combobox({
                    url: '/ashx/SupplierHandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                    editable: false
                });                
            },
            loadSearchCombobox: function () {

                $('#SearchCategoryID').combobox({
                    url: '/ashx/SupplierHandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryName'
                });
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + supplierForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(supplierForm.controls.newsupplier, supplierForm.controls.savesupplier, data);
                        }
                    }
                });
            }

        },
        //用于判断是否有编辑权限
        options: {
            isModify: false
        }

    };
    function rightType(eleAdd, eleSave, data) {
        $(eleAdd).hide();
        $(eleSave).hide();

        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $(eleAdd).show();
                    $(eleSave).show();

                    break;
                case 'Modify':
                    $(eleSave).show();
                    supplierForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        supplierForm.init();
    });

})(jQuery);

