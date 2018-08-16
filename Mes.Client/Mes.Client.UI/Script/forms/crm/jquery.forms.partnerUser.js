(function ($) {
    //'use strict';
    document.msCapsLockWarningOff = true;
    var parterUserForm = {
        init: function () {
            parterUserForm.initControls();
            parterUserForm.events.loadData();
            parterUserForm.events.NewParterUser();
            parterUserForm.controls.searchData.on('click',parterUserForm.events.loadData);//加载
            parterUserForm.controls.newPartnerUser.on('click',parterUserForm.events.NewParterUser);//新增
            parterUserForm.controls.savePartnerUser.on('click',parterUserForm.events.SavePartnerUser);//保存
            parterUserForm.controls.editPassWord.on('click', parterUserForm.events.EditPartnerUser);//重置密码
            parterUserForm.controls.IsLockOrDisabled.on('click',parterUserForm.events.IsLockOrDisabled);//选择按钮
            parterUserForm.events.verifyright();
        },
        initControls: function () {
            parterUserForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $("#btn_search_ok"),
                dgdetail: $("#datagrid"),
                tree: $("#tree"),
                search_form: $("#search_form"),
                edit_form: $("#edit_form"),
                newPartnerUser: $("#btn_new"),
                savePartnerUser: $("#btn_save"),
                editPassWord: $("#editpass"),
                IsLockOrDisabled: $('#IsLocked,#IsDisabled')
            };
        },
        events: {
            loadData: function () {
                parterUserForm.controls.dgdetail.datagrid({
                    sortName: "UserCode",
                    //sortOrder: "asc",
                    idField: 'UserID',
                    url: '/ashx/partnerUserHandler.ashx?Method=SearchPartnerUser',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                            { field: 'UserCode', title: '用户编号', width: 100, sortable: true, align: 'center' },
                            { field: 'UserName', title: '姓名', width: 100, sortable: true, align: 'center' },
                            { field: 'Sex', title: '性别', width: 60, sortable: false, align: 'center' },
                            { field: 'Position', title: '职位', width: 100, sortable: false, align: 'center' },
                            {
                                field: 'Email', title: '电子邮件', width: 150, sortable: false, align: 'center'
                                //formatter: function (value, rowData, rowIndex) {
                                    //if (value != "") {
                                        //return "<a href='mailto:" + value + "' target='_blank'>" + value + "</a>";
                                        //value;
                                  // }
                                //}
                            },
                            { field: 'Mobile', title: '移动电话', width: 100, sortable: false, align: 'center' },                
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
                        parterUserForm.controls.search_form.find("input").each(function(index){
                            param[this.name] = $(this).val();
                            param["IsSystem"] = false;
                        });
                    },
                    onSelect: function () {
                        parterUserForm.events.UpdatePartnerUser();                      
                    }
                });
            },
            NewParterUser: function () {
                $("#edit_form").form('clear');
                parterUserForm.events.loadTree();
                $("#UserID").val(parterUserForm.events.loadNewGuid());             
            },
            UpdatePartnerUser: function () {
                var row = parterUserForm.controls.dgdetail.datagrid('getSelected');
                if (row != null)
                {
                    $.ajax({
                        url: '/ashx/partnerUserHandler.ashx?Method=GetPartnerUser',
                        data:{UserID:row.UserID},
                        success: function (data) {
                            parterUserForm.controls.edit_form.form('load',data);
                            parterUserForm.controls.edit_form.find("#IsDisabled").prop('checked',data["IsDisabled"] == 'True' ? true : false);
                            parterUserForm.controls.edit_form.find("#IsDisabled").val(data["IsDisabled"]);
                            parterUserForm.controls.edit_form.find("#IsLocked").prop('checked',data["IsLocked"] == 'True' ? true : false);
                            parterUserForm.controls.edit_form.find("#IsLocked").val(data["IsLocked"]);
                            parterUserForm.controls.edit_form.find("#UserID").val(data["UserID"]);
                            parterUserForm.events.loadTree();
                            if (!parterUserForm.events.options.isModify)//不等于true，则隐藏保存图标
                            {
                                parterUserForm.controls.savePartnerUser.hide();
                                parterUserForm.controls.editPassWord.hide();
                            }
                        }
                    });
                }
            },
            SavePartnerUser: function () {
                if (parterUserForm.controls.edit_form.form('validate')) {
                    var selectedNodes = parterUserForm.controls.tree.tree("getChecked");                  
                    var selectedRolesFunID = [];
                    $.each(selectedNodes, function (index, node) {
                        if (node.attributes.IsMenu == '3') {
                            selectedRolesFunID.push(node.id);
                        }
                    });                 
                    $("#RoleIDs").val(selectedRolesFunID.join(','));

                    $.ajax({
                            url: '/ashx/partnerUserHandler.ashx?Method=SavePartnerUser',
                            data: parterUserForm.controls.edit_form.serialize(),
                            success: function (returnData) {
                                 if (returnData) {
                                     if (returnData.isOk == 1) {
                                         showInfo(returnData.message);
                                         parterUserForm.controls.tree.tree('reload');
                                         parterUserForm.controls.dgdetail.datagrid('reload');                                        
                                     } else {
                                            showError(returnData.message);
                                     }
                               }
                         }
                   });
                }
            },
            EditPartnerUser: function () {
                var row = parterUserForm.controls.dgdetail.datagrid("getSelected");
                if (row == null)
                {
                    showInfo("请选择一行记录?");
                    return;
                }
                $.messager.confirm("系统提示", "你确定要重置用户密码吗?", function (flag) {
                    if (flag) {
                        $.ajax({
                            url: "/ashx/partnerUserHandler.ashx?Method=ResetPwd",
                            data: { UserID: row.UserID },
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
            },
            loadTree: function () {
                parterUserForm.controls.tree.tree({
                    url: '/ashx/partnerUserHandler.ashx?Method=RoleTree&UserID=' + parterUserForm.controls.edit_form.find('#UserID').val(),
                    checkbox:true,
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
            IsLockOrDisabled: function () {
                //console.log($(this));
                if ($(this)[0].checked == true)
                    $(this).val("True");
                else
                    $(this).val("False");
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + parterUserForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(parterUserForm.controls.newPartnerUser,parterUserForm.controls.savePartnerUser,data);
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
    function rightType(eleAdd, eleSave, data) {
        $(eleAdd).hide(); 
        $(eleSave).hide();
        parterUserForm.controls.editPassWord.hide();
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $(eleAdd).show();
                    $(eleSave).show();
                    break;
                case 'Modify':
                    $(eleSave).show();
                    parterUserForm.controls.editPassWord.show();
                    parterUserForm.events.options.isModify = true;
                    break;
                default: break;
            }
        });
    }
    $(function () {
        parterUserForm.init();
    });
})(jQuery);