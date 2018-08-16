(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var workshiftForm = {
        init: function () {
            workshiftForm.initControls();
            workshiftForm.events.loadData();
            workshiftForm.controls.searchData.on('click', workshiftForm.events.loadData);//加载数据           
            workshiftForm.controls.newWorkShift.on('click', workshiftForm.events.newWorkShift);
            workshiftForm.controls.saveWorkShift.on('click', workshiftForm.events.saveWorkShift);
            workshiftForm.events.newWorkShift();
            workshiftForm.events.verifyright();
        },
        initControls: function () {
            workshiftForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                newWorkShift: $('#btn_new'),
                saveWorkShift: $('#btn_save')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {

            loadData: function () {
                workshiftForm.controls.dgdetail.datagrid({
                    idField: 'WorkShiftID',
                    url: '/ashx/workshifthandler.ashx?Method=SearchWorkShifts&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'WorkShiftCode', title: '班组编号', width: 100, align: 'center' },
                      { field: 'WorkShiftName', title: '班组名称', width: 150, align: 'center' },
                      { field: 'Started', title: '上班时间', width: 120, sortable: false, align: 'center' },
                      { field: 'Ended', title: '下班时间', width: 120, sortable: false, align: 'center' },
                      { field: 'Remark', title: '备注', width: 200, sortable: false, align: 'center' }
                    ]],
                   
                    onBeforeLoad: function (param) {
                        workshiftForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        workshiftForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                       workshiftForm.events. ModifyWorkShift();
                    }
                });
            },

            newWorkShift: function () {
                $.ajax({
                    url: '/ashx/workshifthandler.ashx?Method=newWorkShift&' + jsNC(),
                    success: function (data) {
                        workshiftForm.controls.edit_form.form('load', data);

                        workshiftForm.controls.saveWorkShift.show();//显示保存按钮
                    }
                });
            },
            saveWorkShift: function () {
                if (workshiftForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/workshifthandler.ashx?Method=SaveWorkShift',
                        data: workshiftForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    workshiftForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            ModifyWorkShift: function () {
                var row = workshiftForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/workshifthandler.ashx?Method=GetWorkShift&WorkShiftID=' + row.WorkShiftID,
                        success: function (data) {
                            workshiftForm.controls.edit_form.form('load', data);
                            if (!workshiftForm.options.isModify) {
                                workshiftForm.controls.saveWorkShift.hide();
                            }
                        }
                    });
                }
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + workshiftForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(workshiftForm.controls.newWorkShift, workshiftForm.controls.saveWorkShift, data);
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
                    workshiftForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        workshiftForm.init();
    });

})(jQuery);

