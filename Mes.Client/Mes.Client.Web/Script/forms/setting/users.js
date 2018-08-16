(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var usersForm = {
        init: function () {
            usersForm.initControls();
            usersForm.events.loadData();
            usersForm.controls.searchData.on('click', usersForm.events.loadData);//加载数据          
            usersForm.controls.newUser.on('click', usersForm.events.newUser);//新增
            usersForm.controls.SaveUser.on('click', usersForm.events.SaveUser);//保存用户
            usersForm.controls.PWDConfirm.on('click', usersForm.events.PWDConfirm);//保存密码
            usersForm.controls.PWDCancel.on('click', usersForm.events.PWDCancel);//密码取消
            usersForm.controls.EditPassWord.on('click', usersForm.events.PWDConfirm);//重置密码
            usersForm.controls.IsLockOrDisabled.on('click', usersForm.events.IsLockOrDisabled);// 
            usersForm.events.newUser();
            usersForm.events.loadDepartment();
            usersForm.events.loadTree();
            usersForm.events.verifyright();
        },
        initControls: function () {
            usersForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#datagrid'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),
                newUser: $('#btn_newuser'),
                tree: $('#tree'),
                SaveUser: $('#btn_save'),
                win_changepwd: $('#win_changepwd'),//密码窗体
                win_changepwd_form: $('#win_changepwd_form'),//密码表单
                PWDConfirm:$('#btnConfirm'),
                PWDCancel: $('#btnCancel'),
                EditPassWord: $('#editpass'),
                IsLockOrDisabled:$('#IsLocked,#IsDisabled')
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                usersForm.controls.dgdetail.datagrid({
                    sortName: "Created",
                    sortOrder: "desc",
                    idField: 'UserID',
                    url: '/ashx/UsersHandle.ashx?Method=SearchUser',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[                    
                    {
                        field: 'UserCode', title: '用户编号', width: 100, sortable: true, align: 'center'
                    },
                    { field: 'UserName', title: '姓名', width: 100, sortable: true, align: 'center' },
                    { field: 'Sex', title: '性别', width: 60, sortable: false, align: 'center' },
                    { field: 'DepartmentName', title: '部门', width: 150, sortable: true, align: 'center' },
                    { field: 'Position', title: '职位', width: 100, sortable: false, align: 'center' },
                    {
                        field: 'Email', title: '电子邮件', width: 150, hidden: true, sortable: false, halign: 'center', align: 'left', formatter: function (value, rowData, rowIndex) {
                            if (value != "") {
                                return "<a href='mailto:" + value + "' target='_blank'>Mail：" + value + "</a>";
                            }
                        }
                    },
                    { field: 'Mobile', title: '移动电话', width: 100, sortable: false, align: 'center' },
                    { field: 'IDNumber', title: '证件号码', width: 150, hidden:true, sortable: false, align: 'center' },
                    {
                        field: 'IsLocked', title: '锁定', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == "True") {
                                return "<span style='color:red;'>√</span>";
                            }
                            return "";
                        }
                    },
                    {
                        field: 'IsDisabled', title: '禁用', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == "True") {
                                return "<span style='color:red;'>√</span>";
                            }
                            return "";
                        }
                    }
                    ]],
                    onBeforeLoad: function (param) {
                        param.UserID = usersForm.controls.edit_form.find('#UserID').val();
                        usersForm.controls.search_form.find('input').each(function (index) {
                              param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        usersForm.events.UpdateUser();
                    }
                });
            },
            newUser: function () {
                $('#edit_form').form('clear');//添加之前先清空表单                 
                usersForm.events.loadTree(); //重新加载角色 把原来的角色清空
                $("#UserID").val(usersForm.events.loadNewGuid());
                usersForm.controls.SaveUser.show();
            },
            SaveUser: function () {
                if (usersForm.controls.edit_form.form('validate')) {
                    var selectedNodes = usersForm.controls.tree.tree('getChecked');
                    var selectedRolesFunID = [];
                    $.each(selectedNodes, function (index, node) {
                        if (node.attributes.IsMenu == '3') {
                            selectedRolesFunID.push(node.id);
                        }
                    });
                    $("#RoleIDs").val(selectedRolesFunID.join(','));

                    $.ajax({
                        url: '/ashx/UsersHandle.ashx?Method=SaveUser',
                        data: usersForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    //==============================保存所属角色================================
                                    var userid = usersForm.controls.edit_form.find('#UserID').val();
                                    $.ajax({
                                        url: '/ashx/UsersHandle.ashx?Method=SaveRoles',
                                        data: { UserID: userid, rolesfunids: selectedRolesFunID.join(',') },
                                        success: function (returnData) {
                                            if (returnData) {
                                                if (returnData.isOk == 1) {
                                                    showInfo(returnData.message);
                                                    usersForm.controls.tree.tree('reload');
                                                } else {
                                                    showError(returnData.message);
                                                }
                                            }
                                        }
                                    });
                                    usersForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            UpdateUser: function () {
                var selectedRows = usersForm.controls.dgdetail.datagrid('getSelections');
                var row = usersForm.controls.dgdetail.datagrid('getSelected');
                if (selectedRows.length > 0) {
                    console.log(selectedRows[0]['UserID']);
                    $.ajax({
                        url: '/ashx/usershandle.ashx?Method=GetUser&UserID=' + selectedRows[0]['UserID'] ,
                        success: function (data) {
                            console.log(JSON.stringify(data));
                            usersForm.controls.edit_form.form('load', data); 
                            usersForm.controls.edit_form.find('#IsDisabled').prop('checked', data["IsDisabled"] == 'True' ? true : false);
                            usersForm.controls.edit_form.find('#IsDisabled').val(data["IsDisabled"]);
                            usersForm.controls.edit_form.find('#IsLocked').prop('checked', data["IsLocked"] == 'True' ? true : false);
                            usersForm.controls.edit_form.find('#IsLocked').val(data["IsLocked"]);
                            usersForm.controls.edit_form.find('#UserID').val(data["UserID"]);
                            usersForm.events.loadTree();
                            if (!usersForm.options.isModify)//不等于true，则隐藏保存图标
                            {
                                usersForm.controls.SaveUser.hide();
                                usersForm.controls.EditPassWord.hide();
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
            loadDepartment: function () {
                $('#DepartmentID,#DepartmentIDs').combobox({
                    url: '/ashx/UsersHandle.ashx?Method=DepartmentName',
                    textField: 'text',
                    valueField: 'value',
                });
            },
            loadTree: function () {
                usersForm.controls.tree.tree({
                    url: '/ashx/rolehandler.ashx?Method=RoleTree&UserID=' + usersForm.controls.edit_form.find('#UserID').val(),
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
            PWDConfirm: function () {
                var selectedRows = usersForm.controls.dgdetail.datagrid('getSelections');
                if (selectedRows.length > 0) {
                    $.messager.confirm('系统提示', '您确定要重置该用户密码吗?', function (flag) {
                        if (flag){
                            $.ajax({                                
                                url: '/ashx/usershandle.ashx?Method=ResetPsw&UserID=' + selectedRows[0]['UserID'] ,
                                success: function (returnData) {
                                    if (returnData) {
                                        if (returnData.isOk == 1) {
                                            showInfo('恭喜，密码重置成功！');
                                        } else {
                                            showError(returnData.message);
                                        }
                                    }
                                }
                            });
                        }
                    });
                }
                else {
                    showError('请选择一条记进行操作!');
                    return;
                }
            },
            PWDCancel:function(){
                usersForm.controls.win_changepwd.window('close');
            },
            IsLockOrDisabled: function () {
                if ($(this)[0].checked == true)
                    $(this).val("True");
                else
                    $(this).val("False");
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + usersForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(usersForm.controls.newUser, usersForm.controls.SaveUser, data);
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
        usersForm.controls.EditPassWord.hide();
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $(eleAdd).show();
                    $(eleSave).show();                     
                    break;
                case 'Modify':
                    $(eleSave).show();
                    usersForm.controls.EditPassWord.show();
                    usersForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }
    $(function () {
        usersForm.init();
    });
})(jQuery);

