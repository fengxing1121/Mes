(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var workflowForm = {
        init: function () {
            workflowForm.initControls();
            workflowForm.events.loadData();
            workflowForm.controls.searchData.on('click', workflowForm.events.loadData);//加载数据           
            workflowForm.controls.newWorkflow.on('click', workflowForm.events.newWorkflow);
            workflowForm.controls.saveWorkflow.on('click', workflowForm.events.saveWorkflow);
        },
        initControls: function () {
            workflowForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                newWorkflow: $('#btn_new'),
                saveWorkflow: $('#btn_save')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                workflowForm.controls.dgdetail.datagrid({
                    idField: 'WorkFlowID',
                    url: '/ashx/workflowhandler.ashx?Method=SearchWorkFlow&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'WorkFlowCode', title: '工序编号', width: 100, align: 'center' },
                    { field: 'WorkFlowName', title: '工序名称', width: 150, align: 'center' },
                    { field: 'ImageUrl', title: '图片', width: 200, sortable: false, align: 'center' },
                    { field: 'SortNo', title: '排序', width: 80, sortable: false, align: 'center' },
                    { field: 'Remark', title: '备注', width: 200, sortable: false, align: 'center' },
                    ]],

                    onBeforeLoad: function (param) {
                        workflowForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        workflowForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        workflowForm.events.ModifyWorkFlow();
                    }
                });
            },

            newWorkflow: function () {
                workflowForm.controls.edit_form.form('clear');
            },
            saveWorkflow: function () {
                if (workflowForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/workflowhandler.ashx?Method=SaveWorkFlow',
                        data: workflowForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    workflowForm.controls.dgdetail.datagrid('reload');
                                    workflowForm.controls.edit_form.form('clear');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            ModifyWorkFlow: function () {
                var row = workflowForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/workflowhandler.ashx?Method=GetWorkFlow&WorkFlowID=' + row.WorkFlowID,
                        success: function (data) {
                            workflowForm.controls.edit_form.form('load', data);
                        }
                    });
                }
            },
        },
    };

    $(function () {
        workflowForm.init();
    });

})(jQuery);
 