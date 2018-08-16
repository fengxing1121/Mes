(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var workcenterForm = {
        init: function () {
            workcenterForm.initControls();
            workcenterForm.events.loadData();
            workcenterForm.controls.searchData.on('click', workcenterForm.events.loadData);//加载数据           
            workcenterForm.controls.newWorkCenter.on('click', workcenterForm.events.newWorkCenter);
            workcenterForm.controls.SaveWorkCenter.on('click', workcenterForm.events.SaveWorkCenter);
            workcenterForm.events.loadCoboboxWorkShop();
            workcenterForm.events.loadComboboxWorkFlow();
            workcenterForm.events.newWorkCenter();
            workcenterForm.events.verifyright();
        },
        initControls: function () {
            workcenterForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                newWorkCenter: $('#btn_new'),
                SaveWorkCenter: $('#btn_save')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                workcenterForm.controls.dgdetail.datagrid({
                    idField: 'WorkCenterID',
                    url: '/ashx/workcenterhandler.ashx?Method=SearchWorkCenters&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'WorkCenterCode', title: '设备编号', width: 100, align: 'center' },
                    { field: 'WorkCenterName', title: '设备名称', width: 150, align: 'center' },
                    { field: 'WorkShopName', title: '加工中心名称', width: 150, align: 'center' },
                    { field: 'WorkFlowName', title: '对应工序', width: 120, sortable: false, align: 'center' },
                    { field: 'MaxCapacity', title: '最大产能', width: 120, sortable: false, align: 'center' },
                    {
                        field: 'CountCapacityType', title: '产能计算方式', width: 120, sortable: false, align: 'center', formatter: function (value, row, index) {
                            switch (value) {
                                case 'A':
                                    return '面积';
                                    break;
                                case 'L':
                                    return '长度';
                                    break;
                                case 'Q':
                                    return '板件数量';
                                    break;
                            }
                        }
                    },
                    { field: 'Style', title: '规格', width: 200, sortable: false, align: 'center' },
                    { field: 'Model', title: '型号', width: 200, sortable: false, align: 'center' },
                    { field: 'Remark', title: '备注', width: 200, sortable: false, align: 'center' },
                    { field: 'Sequence', title: '排序', width: 100, sortable: false, align: 'center' }
                    ]],

                    onBeforeLoad: function (param) {
                        workcenterForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        workcenterForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        workcenterForm.events.ModifyWorkCenter();
                    }
                });
            },

            newWorkCenter: function () {
                $.ajax({
                    url: '/ashx/workcenterhandler.ashx?Method=newWorkCenter&' + jsNC(),
                    success: function (data) {
                        workcenterForm.controls.edit_form.form('load', data);

                        workcenterForm.controls.SaveWorkCenter.show();//显示保存按钮
                    }
                });
            },
            SaveWorkCenter: function () {
                if ($('#MaxCapacity').val() == 0) {
                    showError('最大产能不为能为0！');
                    return;
                }
                if (workcenterForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/workcenterhandler.ashx?Method=SaveWorkCenter',
                        data: workcenterForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    workcenterForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            ModifyWorkCenter: function () {
                var row = workcenterForm.controls.dgdetail.datagrid('getSelected');
                if (row) {
                    $.ajax({
                        url: '/ashx/workcenterhandler.ashx?Method=GetWorkCenter&WorkCenterID=' + row.WorkCenterID,
                        success: function (data) {
                            workcenterForm.controls.edit_form.form('load', data);
                            if (!workcenterForm.options.isModify) {
                                workcenterForm.controls.SaveWorkCenter.hide();
                            }

                        }
                    });
                }
            },

            loadComboboxWorkFlow: function () {
                $('#WorkFlowID').combobox({
                    url: '/ashx/workcenterhandler.ashx?Method=GetWorkFlows&' + jsNC(),
                    textField: 'WorkFlowName',
                    valueField: 'WorkFlowID',
                    editable: false
                });
            },
            loadCoboboxWorkShop: function () {
                $('#WorkShopID').combobox({
                    url: '/ashx/workshophandler.ashx?Method=GetWorkShops&' + jsNC(),
                    textField: 'WorkShopName',
                    valueField: 'WorkShopID',
                    editable: false
                });
            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + workcenterForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(workcenterForm.controls.newWorkCenter, workcenterForm.controls.SaveWorkCenter, data);
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
                    workcenterForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        workcenterForm.init();
    });

})(jQuery);
