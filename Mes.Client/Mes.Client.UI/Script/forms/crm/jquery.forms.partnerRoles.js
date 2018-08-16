(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var partnerRolesForm = {
        init: function () {
            partnerRolesForm.initControls();
            partnerRolesForm.events.loadTree();
            partnerRolesForm.events.LoadGroup();
            partnerRolesForm.controls.newGroup.on('click', partnerRolesForm.events.newGroup);//组
            partnerRolesForm.controls.newRole.on('click', partnerRolesForm.events.newRole);//角色
            partnerRolesForm.controls.SaveMenuFun.on('click', partnerRolesForm.events.SaveMenuFun);//保存角色
            partnerRolesForm.controls.group_role_IsDisabledOrIsLocked.on('click', partnerRolesForm.events.group_role_IsDisabledOrIsLocked);
            partnerRolesForm.events.verifyright();
        },
        initControls: function () {
            partnerRolesForm.controls = {
                pid: getUrlParam('pid'),
                tree1: $("#tree1"),
                tree2: $("#tree2"),
                tree3: $("#tree3"),
                edit_form_item: $("#edit_form_item"),
                newRole: $('#btn_newrole'),
                newGroup: $('#btn_newgroup'),
                SaveMenuFun: $('#btn_save'),
                group_role_IsDisabledOrIsLocked: $('#group_IsDisabled,#group_IsLocked, #role_IsDisabled,#role_IsLocked'),
            };
        },
        events: {
            //加载角色
            loadTree: function () {
                partnerRolesForm.controls.tree1.tree({
                    url: "/ashx/partnerUserHandler.ashx?Method=RoleTree",
                    onClick: function (node) {
                        var IsMenu = node.attributes['IsMenu'];
                        if (IsMenu == "2") {                          
                            partnerRolesForm.events.LoadGroupInfo(node.id);
                            $('.easyui-tabs').tabs('select', '组信息');//默认选中
                            $('.easyui-tabs').tabs('getTab', '组信息').panel('options').tab.show();
                            $('.easyui-tabs').tabs('getTab', '角色信息').panel('options').tab.hide();
                            $('.easyui-tabs').tabs('getTab', '角色权限').panel('options').tab.hide();
                            $('.easyui-tabs').tabs('getTab', '角色用户').panel('options').tab.hide();
                            $('#dataType').val('2');//用于判断保存是哪个选项卡信息
                        }
                        if (IsMenu == "3") {
                            partnerRolesForm.events.LoadRoleInfo(node.id);
                            $('.easyui-tabs').tabs('getTab', '组信息').panel('options').tab.hide();
                            $('.easyui-tabs').tabs('getTab', '角色信息').panel('options').tab.show();
                            $('.easyui-tabs').tabs('select', '角色信息'); //默认选中
                            $('.easyui-tabs').tabs('getTab', '角色权限').panel('options').tab.show();
                            $('.easyui-tabs').tabs('getTab', '角色用户').panel('options').tab.show();
                            $('#dataType').val('3');//用于判断保存是哪个选项卡信息

                            partnerRolesForm.events.SetMenuFun(node.id);
                            partnerRolesForm.events.loadUserTree(node.id);
                            partnerRolesForm.controls.edit_form_item.find("#RoleID").val(node.id);
                            partnerRolesForm.controls.edit_form_item.find("#GroupID").val(node.attributes['ParentID']);
                        }
                        if (!partnerRolesForm.events.options.isModify) 
                        {
                            partnerRolesForm.controls.SaveMenuFun.hide();
                        }
                    }
                });
            },
            //加载组信息
            LoadGroupInfo:function(GroupID){
                if (GroupID != "") {
                    $.ajax({
                        url: '/ashx/partnerRolesHandler.ashx?Method=GetGroupInfo&GroupID=' + GroupID,
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
            //加载角色信息
            LoadRoleInfo: function (RoleID) {
                if (RoleID!="") {
                    $.ajax({
                        url: '/ashx/partnerRolesHandler.ashx?Method=GetRoleInfo&RoleID=' + RoleID,
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
            //加载组
            LoadGroup: function () {
                $('#role_GroupID').combobox({
                    url: '/ashx/partnerRolesHandler.ashx?Method=GetGroupList',
                    valueField: 'GroupID',
                    textField: 'GroupName',
                    editable: false
                });
            },
            //加载角色用户
            loadUserTree: function (RoleID) {
                partnerRolesForm.controls.tree3.tree({
                    url: '/ashx/partnerRolesHandler.ashx?Method=UserTree&UserRoleID=' + RoleID,
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
            //加载角色权限
            SetMenuFun: function (RoleID) {
                partnerRolesForm.controls.tree2.tree({
                    url: '/ashx/privilegehandler.ashx?method=CrmTree&RoleID=' + RoleID,
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
            //添加组
            newGroup: function () {
                $('#group_GroupID').val(partnerRolesForm.events.loadNewGuid());
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
            //添加角色
            newRole: function () {
                $('#role_RoleID').val(partnerRolesForm.events.loadNewGuid());
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

                partnerRolesForm.events.SetMenuFun($('#role_RoleID').val());
                partnerRolesForm.events.loadUserTree($('#role_RoleID').val());
                partnerRolesForm.controls.edit_form_item.find("#RoleID").val($('#role_RoleID').val());
            },
            //保存或修改
            SaveMenuFun:function(){
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
                        url: '/ashx/partnerRolesHandler.ashx?Method=SaveGroup',
                        data: { GroupID: groupID, GroupName: groupName, Description: description, IsDisabled: isDisabled, IsLocked: isLocked },
                        success: function (groupData) {
                            if (groupData) {
                                if (groupData.isOk == 1) {
                                    partnerRolesForm.controls.tree1.tree('reload');
                                    partnerRolesForm.events.LoadGroup();
                                    showInfo(groupData.message);
                                } else {
                                    showError(groupData.message);
                                }
                            }
                        }
                    });
                }
                if ($('#dataType').val() == "3") {
                    //==============================保存角色信息===============================
                    partnerRolesForm.events.SaveRole();
                    //==============================保存角色权限================================
                    var selectedNodes = partnerRolesForm.controls.tree2.tree('getChecked');
                    var selectedMenuFunID = [];
                    $.each(selectedNodes, function (index, node) {
                        if (node.attributes.IsMenu != '1') {
                            selectedMenuFunID.push(node.id);
                        }
                    });
                    var roleID = partnerRolesForm.controls.edit_form_item.find("#RoleID").val();
                    if (roleID == "")
                        return;                   
                    $.ajax({
                        url: '/ashx/partnerRolesHandler.ashx?Method=SaveRoleMenuFun',
                        data: { RoleID: roleID, PrivilegeItemS: selectedMenuFunID.join(',') },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    partnerRolesForm.controls.tree2.tree('reload');
                                    //==============================保存角色用户================================
                                    var userNodes = partnerRolesForm.controls.tree3.tree('getChecked');
                                    var userFunID = [];
                                    $.each(userNodes, function (index, node) {
                                        if (node.attributes.IsMenu == '2') {
                                            userFunID.push(node.id);
                                        }
                                    });
                                    $("#UserRoles").val(userFunID.join(','));
                                    $.ajax({
                                        url: '/ashx/partnerRolesHandler.ashx?Method=SaveUserRoleFun',
                                        data: { RoleID: roleID, UserIDs: userFunID.join(',') },
                                        success: function (data) {
                                            if (data) {
                                                if (data.isOk == 1) {
                                                    showInfo(data.message);
                                                    partnerRolesForm.controls.tree3.tree('reload');
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
            //保存角色信息
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
                        url: '/ashx/partnerRolesHandler.ashx?Method=SaveRoleInfo',
                        data: { GroupID: roleGroupID, RoleID: roleID, RoleName: roleName, Description: roledescription, IsDisabled: roleisDisabled, IsLocked: roleisLocked },
                        success: function (roleData) {
                            if (roleData) {
                                if (roleData.isOk == 0) {
                                    showError(roleData.message);
                                } else {
                                    partnerRolesForm.controls.tree1.tree('reload');
                                }
                            }
                        }
                    });
                }
            },
            //禁用或死锁
            group_role_IsDisabledOrIsLocked: function () {
                if ($(this)[0].checked == true)
                    $(this).val("True");
                else
                    $(this).val("False");
            },
            //Guid
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
            //权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetPartnerRight&pid=' + partnerRolesForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(data);
                        }
                    }
                });
            },
            //用于判断是否有编辑权限
            options: {
                isModify: false
            }
        }
    };

    function rightType(data) {
        //console.log(data);
        partnerRolesForm.controls.newRole.hide();
        partnerRolesForm.controls.newGroup.hide();
        partnerRolesForm.controls.SaveMenuFun.hide();

        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    partnerRolesForm.controls.newRole.show();
                    partnerRolesForm.controls.newGroup.show();
                    partnerRolesForm.controls.SaveMenuFun.show();
                    break;
                case 'Modify':
                    partnerRolesForm.controls.newGroup.show();
                    partnerRolesForm.controls.newGroup.show();
                    partnerRolesForm.controls.SaveMenuFun.show();
                    partnerRolesForm.events.options.isModify = true;
                    break;
            }
        });
    }
    $(function () {
        partnerRolesForm.init();
    });
})(jQuery);