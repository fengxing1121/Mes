(function ($) {
    document.msCapsLockWarningOff = true;
    var flag = false;
    var partnerUserManagerForm = {
        init: function () {
            partnerUserManagerForm.initControls();
            partnerUserManagerForm.events.loadData();
            partnerUserManagerForm.controls.btn_search.on('click', partnerUserManagerForm.events.loadData);//搜索
            partnerUserManagerForm.controls.btn_save.on('click', partnerUserManagerForm.events.SavePartnerManagerUser);//保存
            partnerUserManagerForm.controls.btn_editpass.on('click', partnerUserManagerForm.events.EditPwd);//重置密码
            partnerUserManagerForm.controls.IsLockOrDisabled.on('click',partnerUserManagerForm.events.IsLockOrDisabled);
            partnerUserManagerForm.events.verifyright();
        },
        initControls: function () {
            partnerUserManagerForm.controls = {
                pid:getUrlParam('pid'),
                dgdetail: $("#dgdetail"),
                search_form: $("#search_form"),
                btn_search: $("#btn_search_ok"),
                btn_save:$("#btn_save"),
                edit_form: $("#edit_form"),
                btn_editpass: $("#btn_editpass"),
                IsLockOrDisabled: $('#IsLocked,#IsDisabled'),
                tree: $('#tree')
            };
        },
        events: {
            //加载权限
            loadTree: function (PartnerID) {
                partnerUserManagerForm.controls.tree.tree({
                    url: '/ashx/privilegehandler.ashx?method=PartnerTree&PartnerID=' + PartnerID,
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
            loadData: function () {
                partnerUserManagerForm.controls.dgdetail.datagrid({
                    sortName: "Created",
                    sortOrder: "desc",
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
                            //{ field: 'Sex', title: '性别', width: 60, sortable: false, align: 'center' },
                            //{ field: 'Position', title: '职位', width: 100, sortable: false, align: 'center' },
                            //{
                            //    field: 'Email', title: '电子邮件', width: 100, sortable: false, align: 'center'
                            //    //formatter: function (value, rowData, rowIndex) {
                            //    //if (value != "") {
                            //    //return "<a href='mailto:" + value + "' target='_blank'>" + value + "</a>";
                            //    //value;
                            //    // }
                            //    //}
                            //},
                            { field: 'Mobile', title: '移动电话', width: 100, sortable: false, align: 'center' },
                            {
                                field: 'MemberClass', title: '会员类型', width: 100, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    var MemberClass = "";
                                    switch (value) {
                                        case "-1": MemberClass = "待审会员"; break;
                                        case "0": MemberClass = "试用会员"; break;
                                        case "1": MemberClass = "正式会员"; break;
                                        case "2": MemberClass = "内部账户"; break;
                                    }
                                    return MemberClass;
                                }
                            },
                            {
                                field: 'Created', title: '注册日期', width: 85,align: 'center', formatter: function (value, rowData, rowIndex) {
                                    if (value == undefined) return "";
                                    return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                                }
                            },
                            {
                                field: 'EndDate', title: '截止日期', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    if (rowData['MemberClass']!="-1")
                                        return value;
                                }
                            },
                            //{
                            //    field: 'IsAxamine', title: '审核状态', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            //        return (value == "True" ? "<span style='color:red;'>√</span>" : "");
                            //    }
                            //},
                            //{ field: 'Description', title: '备注', width: 150, sortable: false, align: 'center' },
                            {
                                field: 'IsDisabled', title: '禁用', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    if (value == "True") {
                                        return "<span style='color:red;'>√</span>";
                                    }
                                    return "";
                                }
                            },
                            {
                                field: 'IsLocked', title: '锁定', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    if (value == "True") {
                                        return "<span style='color:red;'>√</span>";
                                    }
                                    return "";
                                }
                            },
                    ]],
                    onBeforeLoad: function (param) {
                        partnerUserManagerForm.controls.search_form.find("input").each(function (index) {
                            param[this.name] = $(this).val();
                            param["IsSystem"] = true;
                        });
                    },
                    onSelect: function (index, row) {
                        partnerUserManagerForm.events.loadTree(row.PartnerID);
                        partnerUserManagerForm.events.UpdatePartnerUser();
                    }
                });
            },
            UpdatePartnerUser: function () {
                var row = partnerUserManagerForm.controls.dgdetail.datagrid('getSelected');
                if(row!=null)
                {
                    $.ajax({
                        url: '/ashx/partnerUserHandler.ashx?Method=GetPartnerUser',
                        data: { UserID: row.UserID },
                        success: function (data) {
                            console.log(JSON.stringify(data));
                            partnerUserManagerForm.controls.edit_form.form('load', data);

                            if (data["EndDate"] != "0001/1/1 0:00:00") {
                                $("#EndDate").datebox("setValue", new Date(removeCN(data.EndDate)).Formats('yyyy-MM-dd'));
                            }
                            else {
                                $("#EndDate").datebox("setValue", "");
                            }
                            partnerUserManagerForm.controls.edit_form.find("#IsDisabled").prop('checked', data["IsDisabled"] == 'True' ? true : false);
                            partnerUserManagerForm.controls.edit_form.find("#IsDisabled").val(data["IsDisabled"]);
                            partnerUserManagerForm.controls.edit_form.find("#IsLocked").prop('checked', data["IsLocked"] == 'True' ? true : false);
                            partnerUserManagerForm.controls.edit_form.find("#IsLocked").val(data["IsLocked"]);
                            partnerUserManagerForm.controls.edit_form.find("#UserID").val(data["UserID"]);
                            flag = true;
                            if (!partnerUserManagerForm.events.options.isModify)//不等于true，则隐藏保存图标
                            {
                                partnerUserManagerForm.controls.btn_save.hide();
                                partnerUserManagerForm.controls.btn_editpass.hide();
                            }
                        }
                    });
                }
            },
            SavePartnerManagerUser: function () {
                //debugger;
                if (!flag) {
                    showError("请选择一条记录!");
                    return;
                }
                var selectedNodes = partnerUserManagerForm.controls.tree.tree('getChecked');
                var selectedMenuFunID = [];
                $.each(selectedNodes, function (index, node) {
                   if (node.attributes.IsMenu != '1') {
                       selectedMenuFunID.push(node.id);
                   }
                });
                if (selectedMenuFunID.length < 1) {
                    showError("请勾选经销商权限!");
                    return;
                }
                $("#PrivilegeItemS").val(selectedMenuFunID.join(','));
                if (partnerUserManagerForm.controls.edit_form.form("validate")) {
                    var MemberClass = $("#MemberClass").combobox("getValue");
                    if (MemberClass == "-1") {
                        $.messager.confirm("系统提示", "当前选择得是待审会员，是否继续?", function (flag) {
                            if (flag) {
                                partnerUserManagerForm.events.KuJiaLe();
                            }
                        });
                    }
                    else {
                        partnerUserManagerForm.events.KuJiaLe();
                    } 
                }          
            },
            KuJiaLe: function () {
                $.ajax({
                    url: '/ashx/KuJiaLe/DesignHandler.ashx?Method=KJL_SSO',//注册账户
                    data: { username: $("#UserCodes").val() },
                    success: function (obj) {
                        console.log(obj);
                        if (obj.c != "0" && obj.c != "100013") {
                            alert(obj.m);
                            return;
                        };
                        $.ajax({
                            url: '/ashx/KuJiaLe/DesignHandler.ashx?Method=KJL_SetDisabled',//启用|禁用账户
                            data: { appuid: $("#UserCodes").val(), disabled: !$('#IsDisabled').is(':checked') },
                            success: function (obj) {
                                console.log(obj);
                                if (obj.c != "0" ) {
                                    alert(obj.m);
                                    return;
                                };
                                $.ajax({
                                    url: '/ashx/partnerUserHandler.ashx?Method=SavePartnerManagerUser',//保存信息
                                    data: partnerUserManagerForm.controls.edit_form.serialize(),
                                    success: function (returnData) {
                                        if (returnData) {
                                            if (returnData.isOk == 1) {
                                                showInfo(returnData.message);
                                                partnerUserManagerForm.controls.dgdetail.datagrid('reload');
                                            } else {
                                                showError(returnData.message);
                                            }
                                        }
                                    }
                                });
                            },
                            error: function (e) {
                                alert(JSON.stringify(e));
                            }
                        });

                    },
                    error: function (e) {
                        alert(JSON.stringify(e));
                    }
                });
            },
            EditPwd: function () {
                var row = partnerUserManagerForm.controls.dgdetail.datagrid("getSelected");
                if (row == null) {
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
            IsLockOrDisabled: function () {
                if ($(this)[0].checked == true)
                    $(this).val("True");
                else
                    $(this).val("False");
            },
            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + partnerUserManagerForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(partnerUserManagerForm.controls.btn_save,data);
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
    
    function rightType(eleSave, data) {
        $(eleSave).hide();
        partnerUserManagerForm.controls.btn_editpass.hide();
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {          
                case 'Modify':
                    $(eleSave).show();
                    partnerUserManagerForm.controls.btn_editpass.show();
                    partnerUserManagerForm.events.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
         partnerUserManagerForm.init();
    });
})(jQuery);
