(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var workshopForm = {
        init: function () {
            workshopForm.initControls();
            workshopForm.events.loadData();
            workshopForm.controls.searchData.on('click', workshopForm.events.loadData);//加载数据           
            workshopForm.controls.newWorkShop.on('click', workshopForm.events.newWorkShop);
            workshopForm.controls.saveWorkShop.on('click', workshopForm.events.saveWorkShop);
            workshopForm.events.newWorkShop();
            workshopForm.events.verifyright();
            workshopForm.events.loadCoboboxWorkingLine();
        },
        initControls: function () {
            workshopForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                newWorkShop: $('#btn_new'),
                saveWorkShop: $('#btn_save'),
                dgWorkShift: $('#dgWorkShift')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                workshopForm.controls.dgdetail.datagrid({
                    idField: 'WorkShopID',
                    url: '/ashx/workshophandler.ashx?Method=SearchWorkShops&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                     { field: 'WorkShopCode', title: '车间编号', width: 100, align: 'center' },                     
                     { field: 'WorkShopName', title: '车间名称', width: 150, align: 'center' },
                     { field: 'WorkingLineName', title: '生产线名称', width: 150, align: 'center' },
                     { field: 'Remark', title: '备注', width: 200, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        workshopForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        workshopForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        workshopForm.events.ModifyWorkShop();
                    }
                });
            },

            newWorkShop: function () {
                $.ajax({
                    url: '/ashx/workshophandler.ashx?Method=newWorkShop&' + jsNC(),
                    success: function (data) {
                        workshopForm.controls.edit_form.form('load', data);
                        workshopForm.events.loadWorkShift(data.WorkShopID);
                        workshopForm.controls.saveWorkShop.show();//显示保存按钮

                    }
                });
            },

            saveWorkShop: function () {
                var selectedNodes = workshopForm.controls.dgWorkShift.tree('getChecked');
                if (selectedNodes.length == 0||selectedNodes.length == 1&&selectedNodes[0].id=='0') {
                    showError("请选择班组");
                    return;
                }                
                var selectedWorkShiftIDs = [];
                $.each(selectedNodes, function (index, node) { 
                    if (node.attributes.IsMenu == '2') {
                        selectedWorkShiftIDs.push(node.id);
                    }
                });
                $("#WorkShiftIDs").val(selectedWorkShiftIDs.join(','));
                if (workshopForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/workshophandler.ashx?Method=SaveWorkShop',
                        data: workshopForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    workshopForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },

            ModifyWorkShop: function () {
                var row = workshopForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/workshophandler.ashx?Method=GetWorkShop&WorkShopID=' + row.WorkShopID,
                        success: function (data) {
                            workshopForm.controls.edit_form.form('load', data);

                            if (!workshopForm.options.isModify) {
                                workshopForm.controls.saveWorkShop.hide();
                            }
                        }
                    });
                    workshopForm.events.loadWorkShift(row.WorkShopID);
                }
            },

            loadWorkShift: function (WorkShopID) {
                workshopForm.controls.dgWorkShift.tree({
                    url: '/ashx/workshophandler.ashx?Method=GetWorkShiftTree&WorkShopID=' + WorkShopID,
                    checkbox: true,
                    checkboxFn: function (node) {
                        return true;
                    },
                    onSelect: function (node) {
                        if (node.checked) {
                            $(this).tree('uncheck', node.target);
                        } else {
                            $(this).tree('check', node.target);
                        }
                    }
                });
            },

            loadCoboboxWorkingLine: function () {
                $('#WorkingLineID').combobox({
                    url: '/ashx/workinglinehandler.ashx?Method=GetWorkingLines&' + jsNC(),
                    textField: 'WorkingLineName',
                    valueField: 'WorkingLineID',
                    editable: false
                });
            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + workshopForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(workshopForm.controls.newWorkShop, workshopForm.controls.saveWorkShop, data);
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
                    workshopForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        workshopForm.init();
    });

})(jQuery);
