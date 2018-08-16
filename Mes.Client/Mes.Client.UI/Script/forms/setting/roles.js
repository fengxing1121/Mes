(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var rolesForm = {
        init: function () {
            rolesForm.initControls();  
            rolesForm.events.loadTree();
            rolesForm.controls.newRole.on('click', rolesForm.events.newRole);//角色
            rolesForm.controls.newGroup.on('click', rolesForm.events.newGroup);//角色组  
            rolesForm.controls.SaveMenuFun.on('click', rolesForm.events.SaveMenuFun);// 角色保存 
            rolesForm.controls.group_role_IsDisabledOrIsLocked.on('click', rolesForm.events.group_role_IsDisabledOrIsLocked);//             
            rolesForm.events.LoadGroup();
            //rolesForm.events.verifyright();
        },
        initControls: function () {
            rolesForm.controls = {
                pid: getUrlParam('pid'),
                tree1 : $('#tree1'),
                tree2: $('#tree2'),
                tree3: $('#tree3'),
                edit_form_item: $('#edit_form_item'),
                newRole:$('#btn_newrole'), 
                newGroup:$('#btn_newgroup'), 
                SaveMenuFun: $('#btn_save'), 
                group_role_IsDisabledOrIsLocked: $('#group_IsDisabled,#group_IsLocked, #role_IsDisabled,#role_IsLocked'),                
            }             
        },
        events: {
            loadTree: function () {
                rolesForm.controls.tree1.tree({
                    url: '/ashx/rolehandler.ashx?Method=RoleTree',
                    onClick: function (node) {
                        var IsMenu = node.attributes['IsMenu'];
                        if (IsMenu == "2") {
                            rolesForm.events.LoadGroupInfo(node.id);
                            $('.easyui-tabs').tabs('select', '组信息');//默认选中
                            $('.easyui-tabs').tabs('getTab', '组信息').panel('options').tab.show();
                            $('.easyui-tabs').tabs('getTab', '角色信息').panel('options').tab.hide();
                            $('.easyui-tabs').tabs('getTab', '角色权限').panel('options').tab.hide();
                            $('.easyui-tabs').tabs('getTab', '角色用户').panel('options').tab.hide();
                            $('#dataType').val('2');//用于判断保存是哪个选项卡信息
                        }
                        if (IsMenu == "3") {
                            rolesForm.events.LoadRoleInfo(node.id);
                            $('.easyui-tabs').tabs('getTab', '组信息').panel('options').tab.hide();
                            $('.easyui-tabs').tabs('getTab', '角色信息').panel('options').tab.show();
                            $('.easyui-tabs').tabs('select', '角色信息'); //默认选中
                            $('.easyui-tabs').tabs('getTab', '角色权限').panel('options').tab.show();
                            $('.easyui-tabs').tabs('getTab', '角色用户').panel('options').tab.show();
                            $('#dataType').val('3');//用于判断保存是哪个选项卡信息
 
                            rolesForm.events.SetMenuFun(node.id);
                            rolesForm.events.loadUserTree(node.id);
                            rolesForm.controls.edit_form_item.find("#RoleID").val(node.id);
                            rolesForm.controls.edit_form_item.find("#GroupID").val(node.attributes['ParentID'])
                        }
                    },
                    onLoadSuccess: function (node, param) {
                    }
                });
            },
            loadUserTree: function (RoleID) {
                rolesForm.controls.tree3.tree({
                    url: '/ashx/rolehandler.ashx?Method=UserTree&UserRoleID=' + RoleID,
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
            LoadGroupInfo: function (GroupID) {
                if (GroupID != "") {
                    $.ajax({
                        url: '/ashx/rolehandler.ashx?Method=GetGroupInfo&GroupID=' + GroupID,
                        success: function (data) {
                            $('#group_GroupID').val(data.GroupID);
                            $('#group_GroupName').val(data.GroupName);
                            $('#group_Description').val(data.Description);
                            $('#group_IsDisabled').prop('checked', data["IsDisabled"] == 'True' ? true : false);
                            $('#group_IsDisabled').val(data["IsDisabled"]);

                            $('#group_IsLocked').prop('checked', data["IsLocked"] == 'True' ? true : false);
                            $('#group_IsLocked').val(data["IsLocked"]);
                        }
                    });
                }
            },
            LoadRoleInfo: function (RoleID) {
                if (RoleID != "") {
                    $.ajax({
                        url: '/ashx/rolehandler.ashx?Method=GetRoleInfo&RoleID=' + RoleID,
                        success: function (data) {
                            $('#role_GroupID').combobox('setValue', data.GroupID);
                            $('#role_RoleID').val(data.RoleID);
                            $('#role_RoleName').val(data.RoleName);
                            $('#role_Description').val(data.Description);
                            $('#IsSystem').val(data.IsSystem); //用于判断是否是系统账户
                            $('#role_IsDisabled').prop('checked', data.IsDisabled == "True" ? true : false);
                            $('#role_IsDisabled').val(data.IsDisabled);

                            $('#role_IsLocked').prop('checked', data.IsLocked == "True" ? true : false);
                            $('#role_IsLocked').val(data.IsLocked);
                        }
                    });
                }
            },
            LoadGroup: function () {
                $('#role_GroupID').combobox({
                    url: '/ashx/rolehandler.ashx?Method=ListUserGroup',
                    valueField: 'GroupID',
                    textField: 'GroupName',
                    editable: false
                });
            },
            group_role_IsDisabledOrIsLocked: function () {
                if ($(this)[0].checked == true)
                    $(this).val("True");
                else
                    $(this).val("False");
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
                $('#role_RoleID').val(rolesForm.events.loadNewGuid());
                $('#role_RoleName').val('');
                $('#role_Description').val('');
                $('#IsSystem').val('False'); //设为非系统默认角色
                //$('#role_IsDisabled').attr('checked', 'false');
                //$('#role_IsLocked').attr('checked', 'false');

                $('.easyui-tabs').tabs('getTab', '组信息').panel('options').tab.hide();
                $('.easyui-tabs').tabs('getTab', '角色信息').panel('options').tab.show();
                $('.easyui-tabs').tabs('select', '角色信息'); //默认选中
                $('.easyui-tabs').tabs('getTab', '角色权限').panel('options').tab.show();
                $('.easyui-tabs').tabs('getTab', '角色用户').panel('options').tab.show();
                $('#dataType').val('3');//用于判断保存是哪个选项卡信息   

                rolesForm.events.SetMenuFun($('#role_RoleID').val());
                rolesForm.events.loadUserTree($('#role_RoleID').val());
                rolesForm.controls.edit_form_item.find("#RoleID").val($('#role_RoleID').val());
            },
            newGroup: function () {
                $('#group_GroupID').val(rolesForm.events.loadNewGuid());
                $('#group_GroupName').val(''); 
                $('#group_Description').val('');
                //$('#group_IsDisabled').attr('checked', 'false');
                //$('#group_IsLocked').attr('checked', 'false');

                $('.easyui-tabs').tabs('select', '组信息');//默认选中
                $('.easyui-tabs').tabs('getTab', '组信息').panel('options').tab.show();
                $('.easyui-tabs').tabs('getTab', '角色信息').panel('options').tab.hide();
                $('.easyui-tabs').tabs('getTab', '角色权限').panel('options').tab.hide();
                $('.easyui-tabs').tabs('getTab', '角色用户').panel('options').tab.hide();
                $('#dataType').val('2');//用于判断保存是哪个选项卡信息
            },
            SaveRole: function () {
                if ($('#IsSystem').val() == 'True') {
                    alert('该角色是系统账户，除了角色信息不能修改，其他选项可以修改！');
                } else {
                    if ($('#role_RoleName').val() == "") {
                        alert('角色名称不能为空');
                        return;
                    }
                    var roleGroupID = $('#role_GroupID').combobox('getValue');
                    var roleID = $('#role_RoleID').val();
                    var roleName = $('#role_RoleName').val();
                    var roledescription = $('#role_Description').val();
                    var roleisDisabled = $('#role_IsDisabled').val();
                    var roleisLocked = $('#role_IsLocked').val();
                    $.ajax({
                        url: '/ashx/rolehandler.ashx?Method=SaveRoleInfo',
                        data: { GroupID: roleGroupID, RoleID: roleID, RoleName: roleName, Description: roledescription, IsDisabled: roleisDisabled, IsLocked: roleisLocked },
                        success: function (roleData) {
                            if (roleData) {
                                if (roleData.isOk == 0) {
                                    showError(roleData.message);
                                } else {
                                    rolesForm.controls.tree1.tree('reload');
                                }
                            }
                        }
                    });
                }
            },
            SaveMenuFun: function () {
                //dataType=2 表示保存组信息，3表示保存角色信息&角色权限&角色用户信息, 
                if ($('#dataType').val() == "2") {
                    // ==============================保存组信息================================
                    if ($('#group_GroupName').val() == "") {
                        alert('请输入用户组名称');
                        return;
                    }
                    var groupID = $('#group_GroupID').val();
                    var groupName = $('#group_GroupName').val();
                    var description = $('#group_Description').val();
                    var isDisabled = $('#group_IsDisabled').val();
                    var isLocked = $('#group_IsLocked').val();
                    $.ajax({
                        url: '/ashx/rolehandler.ashx?Method=SaveGroup',
                        data: { GroupID: groupID, GroupName: groupName, Description: description, IsDisabled: isDisabled, IsLocked: isLocked },
                        success: function (groupData) {
                            if (groupData) {
                                if (groupData.isOk == 1) {
                                    rolesForm.controls.tree1.tree('reload');
                                    rolesForm.events.LoadGroup();
                                    showInfo(groupData.message);
                                } else {
                                    showError(groupData.message);
                                }
                            }
                        }
                    });
                } 
                if ($('#dataType').val() == "3") {
                    //==============================保存角色信息================================
                    rolesForm.events.SaveRole();
                    //==============================保存角色权限================================
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
                                    rolesForm.controls.tree2.tree('reload');

                                    //==============================保存角色用户================================
                                    var userNodes = rolesForm.controls.tree3.tree('getChecked');
                                    var userFunID = [];
                                    $.each(userNodes, function (index, node) {
                                        if (node.attributes.IsMenu == '3') {
                                            userFunID.push(node.id);
                                        }
                                    });
                                    $("#UserRoles").val(userFunID.join(','));
                                    $.ajax({
                                        url: '/ashx/rolehandler.ashx?Method=SaveUserRoleFun',
                                        data: { RoleID: roleid, userfunids: userFunID.join(',') },
                                        success: function (data) {
                                            if (data) {
                                                if (data.isOk == 1) {
                                                    showInfo(data.message);
                                                    rolesForm.controls.tree3.tree('reload');
                                                } else {
                                                    showError(data.message);
                                                }
                                            }
                                        }
                                    });
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + rolesForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(data);
                        }
                    }
                });
            }
        }
    };

    function rightType(data) {         
        rolesForm.controls.newRole.hide();
        rolesForm.controls.newGroup.hide();
        rolesForm.controls.SaveMenuFun.hide();

        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'AddRole':                    
                    rolesForm.controls.newRole.show();                    
                    break;
                case 'AddGroup':
                    rolesForm.controls.newGroup.show();                    
                    break;
                case 'RightSet':                     
                    rolesForm.controls.SaveMenuFun.show();
                    break;
                default: break;
            }
        });
    }

    $(function () {
        rolesForm.init();
    });

})(jQuery);

