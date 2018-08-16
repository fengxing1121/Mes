'use strict';
document.msCapsLockWarningOff = true;
var ordersOptimizeForm = {
    init: function () {
        ordersOptimizeForm.initControls();
        ordersOptimizeForm.controls.searchData.on('click', function () {
            ordersOptimizeForm.controls.battchs_tree.tree('reload');
            ordersOptimizeForm.controls.dgdetail.datagrid('reload');
        });//加载数据
        //ordersOptimizeForm.controls.optimize_submit.on('click', function () { ordersOptimizeForm.events.Optimize(); });
        $('#btn_optimize_close').on('click', function () { ordersOptimizeForm.controls.optimize_window.window('close'); });
        ordersOptimizeForm.events.loadbattchs();
        ordersOptimizeForm.controls.currentno = '-1';
        ordersOptimizeForm.events.loadData();
    },
    initControls: function () {
        ordersOptimizeForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form'),//查询表单
            loading: $('#submit_window'),
            optimize_form: $('#optimize_form'),
            optimize_window: $('#optimize_window'),
            optimize_submit: $('#btn_optimize'),
            steps_window: $('#steps_window'),
            battchs_tree: $('#battchs_tree'),
            currentno: null
        }
        $('#btn_search_ok').linkbutton()
        $('#BookingDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var BookingDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var BookingDateFrom = $("#BookingDateFrom").datebox("getValue");
                if (BookingDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#BookingDateTo').datebox("setValue", '');
                }
                if (BookingDateFrom > BookingDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#BookingDateTo').datebox("setValue", '');
                }
            }
        });

        $('#ShipDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var ShipDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var ShipDateFrom = $("#ShipDateFrom").datebox("getValue");
                if (ShipDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }
                if (ShipDateFrom > ShipDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }

            }
        });
    },
    events: {
        loadbattchs: function () {
            ordersOptimizeForm.controls.battchs_tree.tree({
                url: '/ashx/ordershandler.ashx?Method=GetBattchsTree',
                loadMsg: '正在加载数据，请稍候....',
                state: 'closed',
                onBeforeLoad: function (node, param) {
                    //ordersOptimizeForm.controls.search_form.find('select').each(function (index) {
                    //    param[this.name] = $(this).val();
                    //});
                    //ordersOptimizeForm.controls.search_form.find('input').each(function (index) {
                    //    if (this.name != "")
                    //        param[this.name] = $(this).val();
                    //});
                },
                onClick: function (node) {
                    ordersOptimizeForm.controls.currentno = node.id;
                    ordersOptimizeForm.controls.dgdetail.datagrid('reload')
                    //ordersOptimizeForm.events.loadData(node.id);
                },
                onCheck: function (node, checked) {
                    //ordersSchedulingForm.events.reload();
                },
                onLoadSuccess: function (node, param) {
                    var nd = ordersOptimizeForm.controls.battchs_tree.tree('getRoot');
                    ordersOptimizeForm.controls.battchs_tree.tree('expand', nd.target);
                }
            });
        },
        loadData: function () {
            ordersOptimizeForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'OrderID',
                url: '/ashx/ordershandler.ashx?Method=SearchOrder2Cabinets&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: true,
                columns: [[
                {
                    field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');">' + rowData['OrderNo'] + '</a>';
                        return strReturn;
                    }
                },
                { field: 'BattchCode', title: '批次号', width: 90, sortable: false, align: 'center' },
                { field: 'CabinetName', title: '柜体名称', width: 60, sortable: false, align: 'center' },
                { field: 'Size', title: '柜体尺寸', width: 105, sortable: false, align: 'center' },
                { field: 'Color', title: '颜色', width: 60, sortable: false, align: 'center' },
                { field: 'CustomerName', title: '客户名称', width: 105, sortable: false, halign: 'center', align: 'center' },
                { field: 'LinkMan', title: '联系人', width: 75, sortable: false, align: 'center' },
                { field: 'Mobile', title: '联系电话', width: 95, sortable: false, align: 'center' },
                {
                    field: 'BookingDate', title: '订货日期', width: 85, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                    }
                },
                {
                    field: 'ShipDate', title: '交货日期', width: 85, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                    }
                },
                {
                    field: 'op', title: '操作', width: 85, sortable: false, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                        return '<a href="javascript:void(0)" iconcls="clock_delete" class="easyui-linkbutton" onClick="resetSchedule(\'' + rowData.CabinetID + '\')">重新排产</a>'
                    }
                }
                ]],
                toolbar: [
                      { text: '优化开料', iconCls: 'icon-add', handler: ordersOptimizeForm.events.Optimize },
                ],
                onBeforeLoad: function (param) {
                    param['BattchNo'] = ordersOptimizeForm.controls.currentno;
                    ordersOptimizeForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersOptimizeForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },
        SelectBattchNum: function () {
            ordersOptimizeForm.controls.optimize_form.form('clear');
            ordersOptimizeForm.controls.optimize_window.window('open');
        },
        Optimize: function () {
            var BattchNum = ordersOptimizeForm.controls.currentno;
            if (BattchNum == null || BattchNum == "-1") {
                showError("请选择优化批次号。");
                return;
            }

            $.messager.confirm('系统提示', '确定要下载优化开料文件吗？', function (flag) {
                if (flag) {
                    var form = $("<form>");   //定义一个form表单
                    form.attr('style', 'display:none');   //在form表单中添加查询参数
                    form.attr('target', '');
                    form.attr('method', 'post');
                    form.attr('action', "/View/download/download_optimize.aspx");
                    var down = $('<input>');
                    down.attr('type', 'hidden');
                    down.attr('name', 'BattchNum');
                    down.attr('value', BattchNum);
                    $('body').append(form);  //将表单放置在web中 
                    form.append(down);   //将查询参数控件提交到表单上
                    form.submit();
                }
            });
            //window.open("/View/download/download_optimize.aspx?BattchNum=" + BattchNum);
            
        }
    }
};
$(function () {
    ordersOptimizeForm.init();
});

//查看详情        
function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
}

//加载审核明细
function loadstep(orderid) {
    $('#steps_window').window('open');
    $('#dgsteps').datagrid({
        sortName: 'StepNo',
        idField: 'OrderID',
        url: '/ashx/ordershandler.ashx?Method=GetStepsByOrder&OrderID=' + orderid,
        collapsible: false,
        fitColumns: true,
        pagination: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        loadMsg: '正在加载数据，请稍候....',
        columns: [[
        { field: 'Action', title: '发起步骤', width: 120, sortable: false, align: 'center' },
        { field: 'TargetStep', title: '目标步骤', width: 150, sortable: false, halign: 'center', align: 'center' },
        { field: 'StartedBy', title: '提交人', width: 150, sortable: false, halign: 'center', align: 'center' },
        {
            field: 'Started', title: '提交时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                if (value == undefined)
                    return "";
                var date = new Date(+new Date(value) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                return date;
            }
        },
        { field: 'EndedBy', title: '处理人', width: 120, sortable: false, align: 'center' },
        {
            field: 'Ended', title: '处理时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                if (value == undefined)
                    return "";
                var date = new Date(+new Date(value) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                return date;
            }
        },
        { field: 'Remark', title: '审核意见', width: 120, sortable: false, align: 'center' }
        ]],
        onBeforeLoad: function (param) {

        }
    });
    for (var i = 0; i < 20; i++) {
        $('#dgsteps').datagrid('reload');
    }
}

function resetSchedule(id) {
}