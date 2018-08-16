(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var followupForm = {
        init: function () {
            followupForm.initControls();
            followupForm.events.loadData();
            followupForm.controls.searchData.on('click', followupForm.events.loadData);//加载数据   
            followupForm.controls.savefollowup.on('click', followupForm.events.savefollowup);//保存
            followupForm.controls.edit_cancel.on('click', followupForm.events.Cancel);// 取消       
            followupForm.controls.searchCustomer.on('click', followupForm.events.searchCustomer);//查询客户
            followupForm.events.loadCustomer();

            followupForm.events.verifyright();
        },
        initControls: function () {
            followupForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
               
                savefollowup: $('#btn_edit_save'),//保存
                edit_window: $('#edit_window'),
                edit_cancel: $('#btn_edit_cancel'),
                searchCustomer: $('#btn_search_customer')//查询客户

            }
            $('#btn_search_ok').linkbutton()
            $('#btn_search_customer').linkbutton();


        },
        events: {
            loadData: function () {
                followupForm.controls.dgdetail.datagrid({
                    idField: 'FollowID',
                    url: '/ashx/FollowUpHandler.ashx?Method=SearchFollowUps&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                               { field: 'CustomerName', title: '客户名称', width: 100, align: 'center' },
                               { field: 'FollowType', title: '跟进方式', width: 150, align: 'center' },
                               { field: 'Title', title: '跟进主题', width: 120, sortable: false, align: 'center' },
                               { field: 'Remark', title: '跟进内容', width: 100, sortable: false, align: 'center' },
                               { field: 'ImportantResult', title: '重要信息及结果', width: 120, sortable: false, align: 'center' },
                               { field: 'Suggest', title: '建议及应对策略', width: 200, sortable: false, align: 'center' },
                               { field: 'CreatedBy', title: '跟进人', width: 120, sortable: false, align: 'center' },
                               { field: 'Created', title: '跟进时间', width: 120, sortable: false, align: 'center' }
                    ]],
                    toolbar: ['-'
                      , { text: '新增', iconCls: 'icon-add', handler: function () {followupForm.events.newfollowup(); } }, '-'                       
                      , { text: '详细', iconCls: 'icon-search', handler: function () { followupForm.events.updateFollowUp('view'); } }, '-'
                    ],
                    onBeforeLoad: function (param) {
                        followupForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        followupForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                         
                    }
                    
                });
            },

            loadCustomer: function () {
                $('#CustomerID').combogrid({
                    panelWidth: 750,
                    panelHeight: 480,
                    idField: 'CustomerID',
                    textField: 'CustomerName',
                    fitColumns: true,
                    sortName: 'CustomerID',
                    toolbar: '#tb',
                    url: '/ashx/customerhandler.ashx?Method=SearchCustomers',
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    columns: [[
                            { field: 'CustomerName', title: '客户名称', width: 100, align: 'center' },
                            {
                                field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                    return (row.Province) + (row.City) + row.Address;
                                }
                            },
                            { field: 'LinkMan', title: '联系人', width: 80, sortable: false, align: 'center' },
                            { field: 'Tel', title: '固定电话', width: 80, sortable: false, align: 'center' },
                            { field: 'Mobile', title: '移动电话', width: 80, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_customer').find('input').each(function (index) { param[this.name] = $(this).val(); });
                    },
                    onSelect: function (index, row) {
                        followupForm.controls.edit_form.form('load', row);
                    }
                });
            },

            newfollowup: function () {
                followupForm.controls.edit_window.find('div[region="south"]').css('display', 'block');
                followupForm.controls.edit_window.window('open');
                $('#edit_form').form('clear');//添加之前先清空表单
                $('#search_form_customer').form('clear');//清空客户列表查询项
                $("#FollowID").val( followupForm.events.loadNewGuid());
                $('#CustomerID').combogrid("grid").datagrid("reload", {});
            },
            
            updateFollowUp: function (action) {
                switch (action) {
                    case 'update':
                        var selectedRows = me.dgdetail.datagrid('getSelections');
                        if (selectedRows.length > 0) {
                            $.ajax({
                                url: '/ashx/FollowUpHandler.ashx?Method=UpdateFollowUp&FollowID=' + selectedRows[0][me.idFiled],
                                success: function (data) {
                                    followupForm.controls.edit_form.form('load', data);
                                }
                            });
                            followupForm.controls.edit_window.find('div[region="south"]').css('display', 'block');


                            $('#search_form_customer').form('clear');//清空客户列表查询项
                            $('#CustomerID').combogrid("grid").datagrid("reload");

                            followupForm.controls.edit_window.window('open');
                        } else {
                            showError('请选择一条记进行操作!');
                            return;
                        }
                        break;

                    case 'view':
                        var selectedRows = followupForm.controls.dgdetail.datagrid('getSelections');
                        if (selectedRows.length > 0) {
                            $.ajax({
                                url: '/ashx/FollowUpHandler.ashx?Method=UpdateFollowUp&FollowID=' + selectedRows[0]['FollowID'],
                                success: function (data) {
                                    followupForm.controls.edit_form.form('load', data);
                                }
                            });
                            followupForm.controls.edit_window.window('open');
                            followupForm.controls.edit_window.find('div[region="south"]').css('display', 'none');
                        } else {
                            showError('请选择一条记进行操作!');
                            return;
                        }
                        break;
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

            savefollowup: function () {
                if (followupForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/FollowUpHandler.ashx?Method=SaveFollowUp',
                        data: followupForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    followupForm.controls.edit_window.window('close');
                                    followupForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            
            Cancel: function () {
                followupForm.controls.edit_window.window('close');
            },
             
            searchCustomer: function () {
                $('#CustomerID').combogrid("grid").datagrid("reload");
            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + followupForm.controls.pid,
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
        $('div.datagrid-toolbar a').eq(0).hide()//toolbar第一按钮
        $('div.datagrid-toolbar div').eq(0).hide(); //隐藏第一条分隔线
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $('div.datagrid-toolbar a ').eq(0).show();
                    $('div.datagrid-toolbar div').eq(0).show();
                    break;
                //case 'Modify':
                //    $(eleSave).show();
                //    followupForm.options.isModify = true;
                //    break;
                default: break;
            }
        });
    }

    $(function () {
        followupForm.init();
    });

})(jQuery);

