(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var editcount = 0;
    var priviegesForm = {
        init: function () {
            priviegesForm.initControls();
            priviegesForm.events.loadCategoryData();//加载主菜单 
            priviegesForm.events.PrivilegeCategory()
            priviegesForm.controls.SaveData.on('click', priviegesForm.events.SaveData);//保存
            priviegesForm.controls.edit_cancel.on('click', priviegesForm.events.edit_cancel);//取消           
            priviegesForm.controls.IsDisabled.on('click', priviegesForm.events.IsDisabled);//     
            priviegesForm.events.loadCombobox(); //主菜单添加后，子菜单同步加载    
        },
        initControls: function () {
            priviegesForm.controls = {              
                datagrid1: $('#datagrid1'),
                datagrid3: $('#datagrid3'),
                edit_window: $('#edit_window'),
                SaveData: $('#btn_edit_ok'),
                edit_form: $('#edit_form'),
                edit_cancel: $('#btn_edit_cancel'),
                IsDisabled: $('#IsDisabled'),
                opertiontree: $('#opertiontree'),
                priviegeitems: $("#PriviegeItems")
            }
            $('#btn_edit_ok,#btn_edit_cancel').linkbutton();
        },
        events: {
            loadOpertionTree: function () {
                priviegesForm.controls.opertiontree.tree({
                    url: '/ashx/categoryhandler.ashx?Method=LoadCategoryTreeByCategoryCode&CategoryCode=Operation&RootName=%u64CD%u4F5C%u529F%u80FD',
                    checkbox: true,
                    onBeforeLoad: function (node, param) {
                        param["PrivilegeID"] = priviegesForm.controls.edit_form.find("#PrivilegeID").val();
                    }
                });
            },
            loadCategoryData: function () {
                priviegesForm.controls.datagrid3.datagrid({
                    sortName: "Sequence",
                    idField: 'CategoryID',
                    url: '/ashx/privilegehandler.ashx?Method=GetAllPrivilegeCategorys',
                    collapsible: false,
                    singleSelect: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'CategoryID', title: '分组编号', hidden: true, width: 200, sortable: true, align: 'center' },
                     { field: 'CategoryName', title: '分组名称', width: 150, sortable: true, align: 'center', editor: "validatebox" },
                     { field: 'IconClass', title: '图标icon', width: 150, sortable: true, align: 'center', editor: "validatebox" },
                     { field: 'Sequence', title: '排序', width: 50, sortable: true, align: 'center', editor: 'numberbox' },
                     {
                         field: 'action', title: '操作', width: 70, align: 'center',
                         formatter: function (value, row, index) {
                             if (row.editing) {

                                 var s = '<a href="#" iconCls="icon-save" onclick="saverow(' + index + ')">保存</a> ';
                                 var c = '<a href="#" onclick="cancelrow(' + index + ')">取消</a>';
                                 return s + c;

                             } else {

                                 var e = '<a href="#" onclick="editrow(' + index + ')">编辑</a> ';
                                 return e;

                             }
                         }
                     }
                    ]],
                    toolbar: [
                      { text: '增加', iconCls: 'icon-add', handler: priviegesForm.events.addrow },
                      { text: '取消', iconCls: 'icon-cancel', handler: priviegesForm.events.cancelall }
                    ],
                    onBeforeEdit: function (index, row) {
                        row.editing = true;
                        $('#datagrid3').datagrid('refreshRow', index);
                        editcount++;
                    },
                    onAfterEdit: function (index, row) {
                        row.editing = false;
                        $('#datagrid3').datagrid('refreshRow', index);
                        editcount--;
                        var flag = priviegesForm.events.SaveDataCategory(row, index);
                        if (!flag) {
                            $('#datagrid3').datagrid('beginEdit', index);
                        }
                    },
                    onCancelEdit: function (index, row) {
                        row.editing = false;
                        $('#datagrid3').datagrid('refreshRow', index);
                        editcount--;
                    },
                    onSelect: function (rowIndex, rowData) {
                        priviegesForm.events.SetPrivilege(rowData.CategoryID);
                    }

                });
            },
            SetPrivilege: function (param) {
                if (param == "") return;
                priviegesForm.controls.edit_form.find('#PCategoryID').val(param);
                priviegesForm.events.loadGrid();
            },
            //子菜单 菜单项  
            //Loading list
            loadGrid: function () {
                var CategoryID = priviegesForm.controls.edit_form.find('#PCategoryID').val();
                priviegesForm.controls.datagrid1.datagrid({
                    idField: 'PrivilegeID',
                    url: '/ashx/privilegehandler.ashx?Method=ListByCategory&CategoryID=' + CategoryID,
                    pagination: false,
                    fitColumns: true,
                    striped: false,
                    nowrap: true,
                    columns: [[
                     { field: 'PrivilegeName', title: '权限名称', width: 150, sortable: false, align: 'center' },
                     { field: 'PrivilegeCode', title: '权限编码', width: 120, sortable: false, align: 'center' },
                     { field: 'PageURL', title: '页面地址', width: 300, sortable: false, align: 'left', halign: 'center' },
                     { field: 'Sequence', title: '排序', width: 50, sortable: false, align: 'center' },
                     { field: 'Description', title: '描述', width: 200, sortable: false, align: 'left' },
                     {
                         field: 'IsDisabled', title: '是否禁用', width: 80, align: 'center',
                         formatter: function (value, rowIndex, rowData) {
                             if (value.toString().toLowerCase() == "true")
                                 return "<span style='color:red;'>√</span>";
                             else
                                 return "";

                         },
                     }
                    ]],
                    toolbar: ['-'
                    , { text: '新增', iconCls: 'icon-add', handler: function () { priviegesForm.events.NewPrivilege(); } }, '-'
                    , { text: '编辑', iconCls: 'icon-edit', handler: function () { priviegesForm.events.AddOrUpdate('update'); } }, '-'
                    , { text: '详细', iconCls: 'icon-search', handler: function () { priviegesForm.events.AddOrUpdate('view'); } }, '-'
                    ]
                });

            },

            //菜单组列表
            PrivilegeCategory: function () {
                $.ajax({
                    url: '/ashx/privilegehandler.ashx?Method=getallprivilegecategorys&' + jsNC(),
                    cache: true,
                    datatype: "json",
                    success: function (data) {
                        data = eval(data);
                        $.each(data.rows, function (key, item) {
                            $("[name='CategoryID']").append("<option value=\"" + item.CategoryID + "\">" + item.CategoryName + "</option>");
                        })
                    }
                })
            },

            addrow: function () {
                if (editcount > 0) {
                    $.messager.alert('警告', '当前还有' + editcount + '记录正在编辑，不能增加记录。');
                    return;
                }

                var guid = priviegesForm.events.loadNewGuid();
                $('#datagrid3').datagrid('appendRow', {
                    CategoryID: guid,
                    CategoryName: '',
                    Sequence: 99
                });
                var editIndex = $('#datagrid3').datagrid('getRows').length - 1;
                $('#datagrid3').datagrid('selectRow', editIndex);
                $('#datagrid3').datagrid('beginEdit', editIndex);
            },

            cancelall: function () {
                $('#datagrid3').datagrid('rejectChanges');
            },
            //saverow: function (index) {
            //    $('#datagrid3').datagrid('endEdit', index);
            //},
            //cancelrow: function (index) {
            //    $('#datagrid3').datagrid('cancelEdit', index);
            //},
            IsDisabled: function () {
                if ($(this)[0].checked == true)
                    $(this).val("true");
                else
                    $(this).val("false");
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

            loadCombobox: function () {
                $('#CategoryID').combobox({
                    url: '/ashx/PrivilegeHandler.ashx?Method=GetSubCategory&' + jsNC(),
                    textField: 'CategoryName',
                    valueField: 'CategoryID',

                });
            },

            NewPrivilege: function () {
                priviegesForm.events.loadCombobox(); //主菜单添加后，子菜单同步加载
                var categoryid = priviegesForm.controls.edit_form.find('#PCategoryID').val();
                if (categoryid == "") {
                    showError('请选择所属菜单分组后再操作！');
                    return;
                }
                $.ajax({
                    url: '/ashx/privilegehandler.ashx?Method=NewPrivilege&' + jsNC(),
                    data: { CategoryID: categoryid },
                    success: function (data) {
                        priviegesForm.controls.edit_form.form('load', data);
                        priviegesForm.controls.edit_form.find('#IsDisabled').val(false);
                        priviegesForm.controls.edit_window.find('div[region="south"]').css('display', 'block');
                        priviegesForm.events.loadOpertionTree();
                        priviegesForm.controls.edit_window.window('open');
                    }
                });
            },

            AddOrUpdate: function (action) {

                switch (action) {
                    case 'updatedisabled':
                        $.ajax({
                            url: '/ashx/privilegehandler.ashx?Method=UpdateDisabled',
                            data: { PrivilegeID: arguments[1], IsDisabled: arguments[2] },
                            success: function (returnData) {
                                if (returnData) {
                                    if (returnData.isOk == 1) {
                                        priviegesForm.controls.datagrid1.datagrid('reload');
                                    } else {
                                        showError(returnData.message);
                                    }
                                }
                            }
                        });
                        break;
                    case 'update':
                        var selectedRows = priviegesForm.controls.datagrid1.datagrid('getSelections');
                        if (selectedRows.length > 0) {
                            $.ajax({
                                url: '/ashx/privilegehandler.ashx?Method=AddOrUpdate&PrivilegeID=' + selectedRows[0]['PrivilegeID'],
                                success: function (data) {
                                    priviegesForm.controls.edit_form.form('load', data);
                                    priviegesForm.controls.edit_form.find('#IsDisabled').prop('checked', data["IsDisabled"].toLowerCase() == 'true' ? true : false);
                                    priviegesForm.events.loadOpertionTree();
                                    priviegesForm.controls.edit_form.find('#IsDisabled').val(data["IsDisabled"]);
                                }
                            });
                            //me.edit_window.find('#CategoryID').attr('disabled', false);
                            priviegesForm.controls.edit_window.find('div[region="south"]').css('display', 'block');
                            priviegesForm.controls.edit_window.window('open');
                        } else {
                            showError('请选择一条记进行操作!');
                            return;
                        }
                        break;
                    case 'view':
                        var selectedRows = priviegesForm.controls.datagrid1.datagrid('getSelections');
                        if (selectedRows.length > 0) {
                            $.ajax({
                                url: '/ashx/privilegehandler.ashx?Method=AddOrUpdate&PrivilegeID=' + selectedRows[0]['PrivilegeID'],
                                success: function (data) {
                                    priviegesForm.controls.edit_form.form('load', data);
                                    priviegesForm.controls.edit_form.find('#IsDisabled').prop('checked', data["IsDisabled"] == 'True' ? true : false);
                                    priviegesForm.controls.edit_form.find('#IsDisabled').val(data["IsDisabled"]);
                                }
                            });
                            priviegesForm.controls.edit_window.find('div[region="south"]').css('display', 'none');
                            priviegesForm.controls.edit_window.window('open');
                        } else {
                            showError('请选择一条记进行操作!');
                            return;
                        }
                        break;
                }
            },
            SaveData: function () {
                if (priviegesForm.controls.edit_form.form('validate')) {
                    var nodes = priviegesForm.controls.opertiontree.tree('getChecked');
                    var items = [];
                    $.each(nodes, function (index, item) {
                        items.push({ Code: item.id, Name: item.text });
                    });
                    priviegesForm.controls.priviegeitems.val(JSON.stringify(items));
                    var PCategoryID = priviegesForm.controls.edit_form.find('#PCategoryID').val();
                    $.ajax({
                        url: '/ashx/privilegehandler.ashx?Method=Save',
                        data: priviegesForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    priviegesForm.controls.edit_window.window('close');
                                    priviegesForm.controls.datagrid1.datagrid('reload');

                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            edit_cancel: function () {
                priviegesForm.controls.edit_window.window('close');
            },
            //更新分组
            SaveDataCategory: function (parm_rows, index) {
                if (parm_rows.CategoryName == "" || parm_rows.Sequence == "") {
                    showError('注意：分组名称、排序都不能为空!');
                    $('#datagrid3').datagrid('beginEdit', index);
                    return false;
                }
                var flag = true;
                $.ajax({
                    url: '/ashx/privilegehandler.ashx?Method=SavePrivilegeCategory&' + jsNC(),
                    data: parm_rows,
                    async: false,
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 1) {
                                priviegesForm.controls.datagrid3.datagrid('reload');
                            } else {
                                flag = false;
                                showError(returnData.message);
                            }
                        }
                    }
                });
                return flag;
            }

            ////获取权限
            //verifyright: function () {
            //    $.ajax({
            //        url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + priviegesForm.controls.pid,
            //        success: function (data) {
            //            if (data) {
            //                rightType( data);
            //            }
            //        }
            //    });
            //},
        }
        //用于判断是否有编辑权限
        //options: {
        //    isModify: false,
        //    isAdd:false,
        //}
    };
    //function rightType( data) {
    //    $('div.datagrid-toolbar').hide();
    //    //priviegesForm.controls.datagrid3.datagrid("hideColumn", "action");


    //    $(data).each(function (i, obj) {
    //        switch (obj.PrivilegeItemCode) {
    //            case 'Add':
    //                $('div.datagrid-toolbar').show();

    //                //priviegesForm.options.isAdd=true

    //                break;
    //            case 'Modify':


    //                //priviegesForm.options.isModify = true;
    //                break;
    //            default: break;
    //        }
    //    });
    //}


    $(function () {
        priviegesForm.init();
    });

})(jQuery);

function editrow(index) {
    $('#datagrid3').datagrid('beginEdit', index);
}

function saverow(index) {
    $('#datagrid3').datagrid('endEdit', index);
}

function cancelrow(index) {
    $('#datagrid3').datagrid('cancelEdit', index);
}