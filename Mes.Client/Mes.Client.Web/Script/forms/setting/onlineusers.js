(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var onlineUserForm = {
        init: function () {
            onlineUserForm.initControls();             
            onlineUserForm.events.loadGrid();
            onlineUserForm.events.verifyright();

        },
        initControls: function () {
            onlineUserForm.controls = {
                pid: getUrlParam('pid'),
                datagrid1 : $('#datagrid1')
            }
        },
        events: {
            loadGrid: function () {
                onlineUserForm.controls.datagrid1.datagrid({
                    sortName: 'ID',
                    idField: 'ID',
                    url: '/ashx/usershandle.ashx?Method=GetOnlineUser',
                    collapsible: false,
                    pagination: true,
                    pageSize: 20,
                    columns: [[

                     { field: 'UserCode', title: '用户编号', width: 200, sortable: false, align: 'center' },

                     { field: 'UserName', title: '用户名', width: 200, sortable: false, align: 'center' },

                     { field: 'LoginIP', title: '登陆IP', width: 200, sortable: false, align: 'center' },

                     { field: 'LoginTime', title: '登陆时间', width: 200, sortable: false, align: 'center' },

                     { field: 'MacAddress', title: 'MAC地址', width: 200, sortable: false, align: 'center' },

                    ]],
                    toolbar: ['-'
                    , { text: '踢出', iconCls: 'icon-edit', handler: function () { onlineUserForm.events. DelUser(); } }, '-'
                    ],
                    onBeforeLoad: function (param) {
                        //param.ParamterID = me.edit_form.find('#ParamterID').val();
                        //me.search_form.find('input').each(function (index) { param[this.name] = $(this).val(); });
                    }
                });

            },
            //踢出用户
            DelUser: function () {
                var selectedRows = onlineUserForm.controls.datagrid1.datagrid('getSelections');
                if (selectedRows.length > 0) {
                    $.ajax({
                        url: '/ashx/loginhandler.ashx?Method=LoginOut',
                        data: { UserID: selectedRows[0]['ID'] },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    location.href = '/Login.aspx';
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
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + onlineUserForm.controls.pid,
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
        $('div.datagrid-toolbar').hide();
        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Delete':
                    $('div.datagrid-toolbar').show();
                    break;                
                   
                default: break;
            }
        });
    }

    $(function () {
        onlineUserForm.init();
    });

})(jQuery);

