(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var rolesForm = {
        init: function () {
            rolesForm.initControls();
            rolesForm.events.loadTree();
            rolesForm.controls.newRole.on('click', rolesForm.events.newRole);//角色
            rolesForm.controls.role_cancel.on('click', rolesForm.events.role_cancel);// 角色取消

            rolesForm.controls.newGroup.on('click', rolesForm.events.newGroup);//角色组
            rolesForm.controls.cancel_group.on('click', rolesForm.events.cancel_group);// 角色组取消

            rolesForm.controls.save_group.on('click', rolesForm.events.submitgroup);//角色组保存
            rolesForm.controls.save_role.on('click', rolesForm.events.submitrole);// 角色保存
            rolesForm.controls.SaveMenuFun.on('click', rolesForm.events.SaveMenuFun);// 角色保存 
             
        },
        initControls: function () {
            rolesForm.controls = {
                pid: getUrlParam('pid'),
                tree1: $('#tree1'),
                tree2: $('#tree2'),
                edit_form_item: $('#edit_form_item'),
                newRole: $('#btn_newrole'),
                role_form: $('#edit_form_role'),
                role_window: $('#edit_window_role'),
                role_cancel: $('#btn_role_cancel'),

                newGroup: $('#btn_newgroup'),
                group_form: $('#edit_form_group'),
                group_window: $('#edit_window_group'),
                cancel_group: $('#btn_cancel_group'),
                save_group: $('#btn_save_group'),
                save_role: $('#btn_save_role'),
                SaveMenuFun: $('#btn_save'),
            }
        },
        events: {
            loadTree: function () {
                rolesForm.controls.tree1.tree({
                    url: '/ashx/rolehandler.ashx?Method=RoleTree',
                    onClick: function (node) {
                        var IsMenu = node.attributes['IsMenu'];
                        if (IsMenu == "3") {
                            rolesForm.events.SetMenuFun(node.id);
                            rolesForm.controls.edit_form_item.find("#RoleID").val(node.id);
                            rolesForm.controls.edit_form_item.find("#GroupID").val(node.attributes['ParentID'])
                        }
                    },
                    onLoadSuccess: function (node, param) {
                    }
                });
            },
            SetMenuFun: function (RoleID) {
                rolesForm.controls.tree2.tree({
                    url: '/ashx/privilegehandler.ashx?method=Tree&ProleID=' + RoleID,
                    checkbox: true,
                    // onlyLeafCheck: true,
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

            newRole: function () {
                rolesForm.controls.role_form.form('clear');//添加之前先清空表单
                rolesForm.controls.role_form.find('#RoleID').val(rolesForm.events.loadNewGuid());
                //初始化用户组
                rolesForm.controls.role_form.find('#GroupID').combobox(
                    {
                        url: '/ashx/rolehandler.ashx?Method=ListUserGroup',
                        valueField: 'GroupID',
                        textField: 'GroupName',
                        editable: false
                    });
                //打开角色窗口
                rolesForm.controls.role_window.window('open');
            },

            role_cancel: function () {
                rolesForm.controls.role_window.window('close');

            },

            newGroup: function () {
                rolesForm.controls.group_form.form('clear');//添加之前先清空表单
                //初始化用户组
                rolesForm.controls.group_form.find('#GroupID').val(rolesForm.events.loadNewGuid());
                //打开用户组窗口
                rolesForm.controls.group_window.window('open');
            },

            cancel_group: function () {
                rolesForm.controls.group_window.window('close');
            },

            submitgroup: function () {
                if (rolesForm.controls.group_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/rolehandler.ashx?Method=SaveUserGroup',
                        data: rolesForm.controls.group_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    rolesForm.controls.group_window.window('close');
                                    showInfo(returnData.message);
                                    rolesForm.controls.tree1.tree('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },

            submitrole: function () {

                if (rolesForm.controls.role_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/rolehandler.ashx?Method=SaveRole',
                        data: rolesForm.controls.role_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    rolesForm.controls.role_window.window('close');
                                    showInfo(returnData.message);
                                    rolesForm.controls.tree1.tree('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },

            SaveMenuFun: function () {
                var selectedNodes = rolesForm.controls.tree2.tree('getChecked');
                var selectedMenuFunID = [];
                $.each(selectedNodes, function (index, node) {
                    if (node.attributes.IsMenu != '1') {
                        selectedMenuFunID.push(node.id);
                    }
                });
                var roleid = rolesForm.controls.edit_form_item.find("#RoleID").val();
                if (roleid == "")
                    return;
                $.ajax({
                    url: '/ashx/rolehandler.ashx?Method=SaveRoleMenuFun',
                    data: { Proleid: roleid, menufunids: selectedMenuFunID.join(',') },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 1) {
                                showInfo(returnData.message);
                                rolesForm.controls.tree2.tree('reload');
                            } else {
                                showError(returnData.message);
                            }
                        }
                    }
                });
            }, 
        },
    };

 

    $(function () {
        rolesForm.init();
    });

})(jQuery);

