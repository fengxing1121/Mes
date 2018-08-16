(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var materialsForm = {
        init: function () {
            materialsForm.initControls();
            materialsForm.events.loadData();
            materialsForm.controls.searchData.on('click', materialsForm.events.loadData);//加载数据    
            materialsForm.controls.newmaterial.on('click', materialsForm.events.newmaterial);//新增
            materialsForm.controls.savematerial.on('click', materialsForm.events.savematerial);//保存    
            materialsForm.events.newmaterial();
            materialsForm.events.loadCombobox();
            materialsForm.events.loadSearchCobobox();
            materialsForm.events.verifyright();
        },
        initControls: function () {
            materialsForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                newmaterial: $('#btn_edit_new'),//新增按钮
                savematerial: $('#btn_edit_save')//保存 
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                //初始化数据    
                materialsForm.controls.dgdetail.datagrid({
                    idField: 'MaterialID',
                    url: '/ashx/materialhandler.ashx?Method=SearchMaterials&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'Category', title: '材料类型', width: 150, align: 'center' },
                    //{ field: 'SubCategory', title: '子类型', width: 150, align: 'center' },
                    { field: 'MaterialCode', title: '材料编号', width: 150, sortable: false, align: 'center' },
                    { field: 'MaterialName', title: '材料名称', width: 150, sortable: false, align: 'center' },
                    { field: 'Style', title: '型号/款式', width: 150, sortable: false, align: 'center' },
                    { field: 'Color', title: '颜色', width: 150, sortable: false, align: 'center' },
                    {
                        field: 'Deepth', title: '厚度', width: 100, sortable: false, align: 'center',
                        formatter: function (value, row, index) {
                            if (value == 0)
                                return "-";
                            else
                                return value;
                        }
                    },
                    //{
                    //     field: 'QuotedPrice', title: '报价(元)', width: 100, sortable: false, align: 'center',
                    //     formatter: function (value,row) {
                    //         if (value == "")
                    //             return "0.00";
                    //         return value;
                    //     }
                    // },                  
                    { field: 'Unit', title: '单位', width: 150, sortable: false, align: 'center' },
                    { field: 'SafetyStock_Qty', title: '安全库存', width: 120, sortable: false, align: 'center' },
                    { field: 'Withholding_Qty', title: '预扣数量', width: 120, sortable: false, align: 'center' },
                    {
                        field: 'QuotedPrice', title: '销售价', width: 120, sortable: false, align: 'center',
                        formatter: function (value,row) {
                                     if (value == "")
                                         return "0.00";
                                     return value;
                         }
                    }
                    ]],                     
                    onBeforeLoad: function (param) {
                        materialsForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        materialsForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                         materialsForm.events.modifymaterial();
                    }
                });
            },
            newmaterial: function () {
                $.ajax({
                    url: '/ashx/materialhandler.ashx?Method=NewMaterial&' + jsNC(),
                    success: function (data) {
                        materialsForm.controls.search_form.find("#MaterialID").val(data.MaterialID);
                        materialsForm.controls.edit_form.form('load', data);
                        materialsForm.controls.savematerial.show();
                    }
                });
            },
            savematerial: function () {
                if (materialsForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/materialhandler.ashx?Method=SaveMaterial',
                        data: materialsForm.controls.edit_form.serialize(),
                        loadMsg: '正在提交数据，请稍候....',
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    showInfo(returnData.message);
                                    materialsForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            modifymaterial: function () {
                var row = materialsForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/materialhandler.ashx?Method=GetMaterial',
                        data: { MaterialID: row.MaterialID },
                        success: function (data) {
                            materialsForm.controls.edit_form.form('load', data);
                            if (!materialsForm.options.isModify)//不等于true，则隐藏保存图标
                            {
                                materialsForm.controls.savematerial.hide();
                            }
                        }
                    });
                }
            },
            loadCombobox: function () {
                $('#CategoryID').combobox({
                    url: '/ashx/materialhandler.ashx?Method=GetCategories&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                    onSelect: function (record) {
                        $('#SubCategoryID').combobox({
                            url: '/ashx/materialhandler.ashx?Method=GetSubCategories&id=' + record.CategoryID,
                            textField: 'CategoryName',
                            valueField: 'CategoryName'
                        });
                    }
                });
            },
            loadSearchCobobox: function () {
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
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + materialsForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(materialsForm.controls.newmaterial, materialsForm.controls.savematerial, data);
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
                    materialsForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }
    $(function () {
        materialsForm.init();
    });

})(jQuery);
