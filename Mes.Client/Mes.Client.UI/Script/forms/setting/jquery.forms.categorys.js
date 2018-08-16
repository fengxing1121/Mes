(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var categoryForm = {
        init: function () {
            categoryForm.initControls();
            categoryForm.events.loadData();//加载数据 
            categoryForm.events.loadCombobox();
            categoryForm.controls.newcategory.on('click', categoryForm.events.newcategory);//新增
            categoryForm.controls.submitcategory.on('click', categoryForm.events.submitcategory);//保存
            categoryForm.controls.deletecategory.on('click', categoryForm.events.deletecategory);//删除
            categoryForm.controls.IsDisabled.on('click', categoryForm.events.IsDisabled);// 
            categoryForm.events.newcategory();
            categoryForm.events.verifyright();

        },
        initControls: function () {
            categoryForm.controls = {
                pid: getUrlParam('pid'),
                category_tree: $('#category_tree'),
                edit_form: $('#edit_form'),
                newcategory: $('#btn_edit_new'),
                submitcategory: $('#btn_edit_save'),
                deletecategory: $('#btn_delete'),
                IsDisabled: $('#IsDisabled')
            }

        },
        events: {
            loadCombobox: function () {
                $('#ParentID').combotree({
                    url: '/ashx/categoryhandler.ashx?Method=CategoryTree',
                    state: 'closed',
                    required: true,
                    editable: false,                    
                    onLoadSuccess: function (node, param) {
                        var nd = $('#ParentID').combotree('tree').tree('getRoot');
                        if (nd != undefined) {
                            $('#ParentID').combotree('tree').tree('expand', nd.target);
                        }
                    }
                });
            },

            loadData: function () {
                categoryForm.controls.category_tree.tree({
                    url: '/ashx/categoryhandler.ashx?Method=CategoryTree',
                    loadMsg: '正在加载数据，请稍候....',
                    state: 'closed',
                    onClick: function (node) {
                        categoryForm.events.modifycategory(node.id);
                    },
                    onLoadSuccess: function (node, param) {
                        var nd = categoryForm.controls.category_tree.tree('getRoot');
                        categoryForm.controls.category_tree.tree('expand', nd.target);
                    }
                });
            },
            newcategory: function () {
                var n = categoryForm.controls.edit_form.find('#ParentID').combotree('getValue');
                $.ajax({
                    url: '/ashx/categoryhandler.ashx?Method=NewCategory',
                    success: function (data) {
                        categoryForm.controls.edit_form.form('load', data);
                        //var n = $('#category_tree').tree('getSelected');                        
                        if (n == null || n == '') {
                            categoryForm.controls.edit_form.find('#ParentID').combotree('setValue', '00000000-0000-0000-0000-000000000000');
                        }
                        else {
                            categoryForm.controls.edit_form.find('#ParentID').combotree('setValue', n);
                        }
                        categoryForm.controls.edit_form.find('#IsDisabled').attr('checked', false);
                        categoryForm.controls.edit_form.find('#IsDisabled').val(false);
                        categoryForm.controls.submitcategory.show();
                    }
                })
            },

            submitcategory: function () {
                if (categoryForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/categoryhandler.ashx?Method=SaveCategory',
                        data: categoryForm.controls.edit_form.serialize(),
                        loadMsg: '正在提交数据，请稍候....',
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                } else {
                                    categoryForm.controls.category_tree.tree('reload');
                                    $('#ParentID').combotree('reload');
                                }
                            }
                        }
                    });
                }
            },
            deletecategory:function()
            {
                if ($('#CategoryID').val() === '') {
                    showError('请选择需要删除的数据字典。');
                    return;
                }
                $.messager.confirm('系统提示', '确定要删除此数据字典吗?', function (r) {
                    if (r) {
                        $.ajax({
                            url: '/ashx/categoryhandler.ashx?Method=DeleteCategory',
                            data: categoryForm.controls.edit_form.serialize(),
                            loadMsg: '正在提交数据，请稍候....',
                            success: function (returnData) {
                                if (returnData) {
                                    if (returnData.isOk == 0) {
                                        showError(returnData.message);
                                    }
                                    else {
                                        categoryForm.controls.category_tree.tree('reload');
                                        $('#ParentID').combotree('reload');
                                        //$('#ParentID').combobox('reload');
                                        //categoryForm.controls.edit_form.find('#ParentID').combobox('reload');
                                        $('#CategoryID,#CategoryCode,#CategoryName,#ShortName,#Sequence').val('');
                                    }
                                }
                            }
                        });
                    }
                });
            },
            modifycategory: function (id) {
                $.ajax({
                    url: '/ashx/categoryhandler.ashx?Method=GetCategory',
                    data: { CategoryID: id },
                    success: function (data) {
                        categoryForm.controls.edit_form.form('load', data);
                        categoryForm.controls.edit_form.find('#IsDisabled').prop('checked', data["IsDisabled"] == 'True' ? true : false);
                        categoryForm.controls.edit_form.find('#IsDisabled').val(data["IsDisabled"]);

                        if (!categoryForm.options.isModify)//不等于true，则隐藏保存图标
                        {
                            categoryForm.controls.submitcategory.hide();
                        }
                    }
                });

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
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + categoryForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(categoryForm.controls.newcategory, categoryForm.controls.submitcategory, data);
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
                    categoryForm.options.isModify = true;
                    break;
                default: break;
            }
        });
    }

    $(function () {
        categoryForm.init();
    });

})(jQuery);

