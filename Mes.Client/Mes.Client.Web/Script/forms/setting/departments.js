(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var departmentForm = {
        init: function () {
            departmentForm.initControls();
            departmentForm.events.loadData();
            departmentForm.controls.searchData.on('click', departmentForm.events.loadData);//加载数据          
            departmentForm.controls.NewDepartment.on('click', departmentForm.events.NewDepartment);//新增
            departmentForm.controls.SaveDepartment.on('click', departmentForm.events.SaveDepartment);//保存
            departmentForm.controls.IsDisabled.on('click', departmentForm.events.IsDisabled);// 
            departmentForm.events.NewDepartment();

            departmentForm.events.verifyright();

        },
        initControls: function () {
            departmentForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#datagrid'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                NewDepartment: $('#btn_add'),
                SaveDepartment: $('#btn_save'),
                IsDisabled:$('#IsDisabled')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {

            loadData: function () {
                departmentForm.controls.dgdetail.datagrid({
                    sortName: "DepartmentCode",
                    sortOrder: "asc",
                    idField: 'DepartmentID',
                    url: '/ashx/DepartmentHandler.ashx?Method=List',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'DepartmentCode', title: '部门编号', width: 100, sortable: true, align: 'center' },
                    { field: 'DepartmentName', title: '部门名称', width: 250, sortable: true, align: 'center' },
                    { field: 'Tel', title: '部门电话', width: 150, sortable: true, align: 'center' },
                    { field: 'Fax', title: '传真', width: 150, sortable: true, align: 'center' },
                    {
                        field: 'IsDisabled', title: '禁用标志', width: 80, sortable: true, align: 'center'
                        , formatter: function (value, rowData, rowIndex) {
                            if (value == 'False') {
                                return "";
                            }
                            else {
                                return "<span style='color:red;'>√</span>";
                            }
                        }
                    }
                    ]],
                    onBeforeLoad: function (param) {
                        param.DepartmentID = departmentForm.controls.edit_form.find('#DepartmentID').val();
                        departmentForm.controls.search_form.find('input').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                       departmentForm.events. UpdateDepartment();
                    }
                     
                });
            },

            NewDepartment: function () {
                $.ajax({
                    url: '/ashx/DepartmentHandler.ashx?Method=NewDepartment&' + jsNC(),
                    success: function (data) {
                        departmentForm.controls.edit_form.form('load', data);
                        departmentForm.controls.SaveDepartment.show();
                    }
                });

            },
            SaveDepartment: function () {
                if (departmentForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/DepartmentHandler.ashx?Method=SaveDepartment',
                        data: departmentForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    showInfo(returnData.message);
                                    departmentForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }

            },

            UpdateDepartment: function () {

                var selectedRows = departmentForm.controls.dgdetail.datagrid('getSelections');
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/DepartmentHandler.ashx?Method=GetDepartment&DepartmentID=' + selectedRows[0]['DepartmentID'],
                        success: function (data) {
                            departmentForm.controls.edit_form.form('load', data);
                            departmentForm.controls.edit_form.find('#IsDisabled').prop('checked', data["IsDisabled"] == 'True' ? true : false);
                            departmentForm.controls.edit_form.find('#IsDisabled').val(data["IsDisabled"]);

                            if (!departmentForm.options.isModify)//不等于true，则隐藏保存图标
                            {
                                departmentForm.controls.SaveDepartment.hide();
                            }
                        }
                    });
                }
            },

            IsDisabled: function () {
                if ($(this)[0].checked == true)
                    $(this).val("true");
                else
                    $(this).val("false");
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + departmentForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(departmentForm.controls.NewDepartment, departmentForm.controls.SaveDepartment, data);
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
                    departmentForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        departmentForm.init();
    });

})(jQuery);

