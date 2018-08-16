'use strict';
document.msCapsLockWarningOff = true;
var smsLogForm = {
    init: function () {
        smsLogForm.initControls();
        smsLogForm.events.loadData();
        smsLogForm.controls.searchData.on('click', function () { smsLogForm.controls.dgdetail.datagrid('reload'); });//加载数据  
    },
    initControls: function () {
        smsLogForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form')//查询表单
        }
        $('#btn_search_ok').linkbutton();

        $('#CreatedDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var CreatedDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var CreatedDateFrom = $("#CreatedDateFrom").datebox("getValue");
                if (CreatedDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#CreatedDateTo').datebox("setValue", '');
                }
                if (CreatedDateFrom > CreatedDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#CreatedDateTo').datebox("setValue", '');
                }
            }
        });
    },
    events: {
        loadData: function () {
            smsLogForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'ID',
                url: '/ashx/partnerhandlerRegister_EGui.ashx?Method=SearchSMSLogs&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                { field: 'Phone', title: '手机号码', width: 120, sortable: false, halign: 'center', align: 'center' },
                { field: 'Message', title: '验证码', width: 105, sortable: false, halign: 'center', align: 'center' },
                {
                    field: 'Created', title: '创建日期', width: 85, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                    }
                }
                ]],
                onBeforeLoad: function (param) {
                    smsLogForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    smsLogForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        }
    }
};

$(function () {
    smsLogForm.init();
    window.top["TaskRefresh"] = function () {
        $("#dgdetail").datagrid("reload");
    };
});
