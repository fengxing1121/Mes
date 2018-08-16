(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var workinglineForm = {
        init: function () {
            workinglineForm.initControls();
            workinglineForm.events.loadData();
            workinglineForm.controls.searchData.on('click', workinglineForm.events.loadData);//加载数据           
            workinglineForm.controls.newWorkingLine.on('click', workinglineForm.events.newWorkingLine);
            workinglineForm.controls.saveWorkingLine.on('click', workinglineForm.events.saveWorkingLine);
            workinglineForm.events.newWorkingLine();
            workinglineForm.events.verifyright();
        },
        initControls: function () {
            workinglineForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                newWorkingLine: $('#btn_new'),
                saveWorkingLine: $('#btn_save'),
                 
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                workinglineForm.controls.dgdetail.datagrid({
                    idField: 'WorkingLineID',
                    url: '/ashx/workinglinehandler.ashx?Method=SearchWorkingLines&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[                     
                     { field: 'WorkingLineName', title: '生产线名称', width: 150, align: 'center' },
                     { field: 'Remark', title: '备注', width: 200, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        workinglineForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        workinglineForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        workinglineForm.events.ModifyWorkingLine();
                    }
                });
            },

            newWorkingLine: function () {
                $.ajax({
                    url: '/ashx/workinglinehandler.ashx?Method=newWorkingLine&' + jsNC(),
                    success: function (data) {
                        workinglineForm.controls.edit_form.form('load', data);
                        
                        //workinglineForm.controls.saveWorkShop.show();//显示保存按钮

                    }
                });
            },

            saveWorkingLine: function () {
                
                if (workinglineForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/workinglinehandler.ashx?Method=SaveWorkingLine',
                        data: workinglineForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    workinglineForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }

            },

            ModifyWorkingLine: function () {
                var row = workinglineForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/workinglinehandler.ashx?Method=GetWorkingLine&WorkingLineID=' + row.WorkingLineID,
                        success: function (data) {
                            workinglineForm.controls.edit_form.form('load', data);

                            if (!workinglineForm.options.isModify) {
                                workinglineForm.controls.saveWorkingLine.hide();
                            }
                        }
                    }); 
                }
            },

            
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + workinglineForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(workinglineForm.controls.newWorkingLine, workinglineForm.controls.saveWorkingLine, data);
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
                    workinglineForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        workinglineForm.init();
    });

})(jQuery);
