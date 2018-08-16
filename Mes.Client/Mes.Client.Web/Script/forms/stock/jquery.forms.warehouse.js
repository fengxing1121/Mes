(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var warehouseForm = {
        init: function () {
            warehouseForm.initControls();
            //warehouseForm.events.loadData();
            warehouseForm.controls.searchData.on('click', warehouseForm.events.loadData);//加载数据
            warehouseForm.controls.newcategory.on('click', warehouseForm.events.newcategory);//新增
            warehouseForm.controls.savecategory.on('click', warehouseForm.events.savecategory);//保存           
            warehouseForm.events.newcategory();
            warehouseForm.events.verifyright();
        },
        initControls: function () {
            warehouseForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                newcategory: $('#btn_edit_new'),//新增按钮
                savecategory: $('#btn_edit_save')//保存按钮
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {

            loadData: function () {
                warehouseForm.controls.dgdetail.datagrid({
                    idField: 'CategoryID',
                    url: '/ashx/categoryhandler.ashx?Method=SearchCategory&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                        { field: 'ParentID', title: '', hidden: true, width: 150, align: 'center' },
                        { field: 'CategoryCode', title: '仓库编码', width: 150, align: 'center' },
                        { field: 'CategoryName', title: '仓库名称', width: 150, align: 'center' },
                        { field: 'Sequence', title: '排序编号', width: 150, sortable: false, align: 'center' },
                    ]],
                    onBeforeLoad: function (param) {
                        warehouseForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        warehouseForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        warehouseForm.events.modifywarehouse();
                    }
                })
            },
            
            newcategory: function () {               
                $.ajax({
                    url: '/ashx/categoryhandler.ashx?Method=NewCategory',
                    success: function (data) {
                        warehouseForm.controls.search_form.find("#ParentID").val(data.ParentID);
                        warehouseForm.controls.edit_form.form('load', data);
                        warehouseForm.controls.savecategory.show();
                    }
                });

            },

            savecategory: function () {               
                if (warehouseForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/categoryhandler.ashx?Method=SaveCategory',
                        data: warehouseForm.controls.edit_form.serialize(),
                        loadMsg: '正在提交数据，请稍候....',
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);                        
                                } else {
                                    //warehouseForm.controls.dgdetail.datagrid('reload');
                                    warehouseForm.events.loadData();
                                }
                            }
                        }
                    });
                }
            },

            modifywarehouse: function () {              
                var row = warehouseForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/categoryhandler.ashx?Method=GetCategory',
                        data: { CategoryID: row.CategoryID },
                        success: function (data) {
                            warehouseForm.controls.edit_form.form('load', data);

                            if (!warehouseForm.options.isModify)//不等于true，则隐藏保存图标
                            {
                                warehouseForm.controls.savecategory.hide();
                            }
                        }
                    });
                }
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + warehouseForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(warehouseForm.controls.newcategory, warehouseForm.controls.savecategory, data);
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
                    warehouseForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }


    $(function () {
        warehouseForm.init();        
    });

})(jQuery);
