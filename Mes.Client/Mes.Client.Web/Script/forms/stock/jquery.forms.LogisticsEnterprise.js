(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var LogisticsForm = {
        init: function () {
            LogisticsForm.initControls();
            LogisticsForm.events.loadData();
            LogisticsForm.controls.searchData.on('click', LogisticsForm.events.loadData);//加载数据    
            LogisticsForm.controls.newLogistic.on('click', LogisticsForm.events.newLogistic);//新增
            LogisticsForm.controls.saveLogistic.on('click', LogisticsForm.events.saveLogistic);//保存   
           

            LogisticsForm.events.newLogistic();
            LogisticsForm.events.verifyright();
        },
        initControls: function () {
            LogisticsForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                newLogistic: $('#btn_new'),//新增按钮
                saveLogistic: $('#btn_save')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
             LogisticsForm.controls.dgdetail.datagrid({
                 idField: 'EnterpriseID',
                 url: '/ashx/LogisticsEnterpriseHandler.ashx?Method=SearchLogistics&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                    { field: 'EnterpriseName', title: '物流名称', width: 150, align: 'center' },
                    { field: 'Address', title: '地址', width: 280, sortable: false, align: 'center' },
                    { field: 'LinkMan', title: '联系人', width: 120, sortable: false, align: 'center' },
                    { field: 'Mobile', title: '移动电话', width: 100, sortable: false, align: 'center' },    
                    { field: 'Tel', title: '固定电话', width: 100, sortable: false, align: 'center' }                                    
                    ]],
                    onBeforeLoad: function (param) {
                        LogisticsForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        LogisticsForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        LogisticsForm.events.updateLogistic();
                    }
                });
            },             
            newLogistic: function () {
                $('#edit_form').form('clear');//添加之前先清空表单
                $("#EnterpriseID").val(LogisticsForm.events.loadNewGuid());
                LogisticsForm.controls.saveLogistic.show();//显示保存按钮

            },
            saveLogistic: function () {
                if (LogisticsForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/LogisticsEnterpriseHandler.ashx?Method=SaveLogistic',
                        data: LogisticsForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    LogisticsForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },

            updateLogistic: function () {
                var selectedRows = LogisticsForm.controls.dgdetail.datagrid('getSelections');               
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/LogisticsEnterpriseHandler.ashx?Method=GetLogistic&EnterpriseID=' + selectedRows[0]['EnterpriseID'],
                        success: function (data) {
                            LogisticsForm.controls.edit_form.form('load', data);  
                            if (!LogisticsForm.options.isModify) {
                                LogisticsForm.controls.savecustomer.hide();
                            }
                        }
                    });
                }
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
 
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + LogisticsForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(LogisticsForm.controls.newLogistic, LogisticsForm.controls.saveLogistic, data);
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
                    LogisticsForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        LogisticsForm.init();
    });

})(jQuery);

