(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var jitForm = {
        init: function () {
            jitForm.initControls();
            jitForm.controls.searchData.on('click', function () { jitForm.controls.dgdetail.datagrid('reload'); });//加载数据
            jitForm.events.loadData();
        },
        initControls: function () {
            jitForm.controls = {
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                dgCabinet: $('#dgCabinet')//查询表单
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                jitForm.controls.dgdetail.datagrid({
                    sortName: 'Created',
                    idField: 'OrderID',
                    url: '/ashx/ordershandler.ashx?Method=SearchBatchNumOrders&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    {
                        field: 'BatchNum', title: '批次编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['BatchNum'] + '\');">' + rowData['BatchNum'] + '</a>';
                            return strReturn;
                        }
                    },
                    { field: 'CustomerName', title: '客户名称', width: 80, sortable: false, align: 'center' },
                    { field: 'BJNum', title: '板件数量', width: 80, sortable: false, align: 'center' },
                    {
                        field: 'p', title: '进度', width: 100, sortable: false, align: 'center', formatter: function (value, rowData, index) {
                            if (('P,F,I,O').indexOf(rowData.Status) < 0) {
                                return "待生产";
                            }
                            else {
                                var s = '<a href="javascript:void(0)"  title="订单生产图" onClick="showOrderMonitor(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');"><span class="icon chart_bar">&nbsp;</span>查看进度</a>';
                                return s;
                            }
                        }
                    }
                    ]],
                    onBeforeLoad: function (param) {
                        jitForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        jitForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    },
                    success: function (data) {
                        alert(2);
                    }
                });
            },
            formatProgress: function (value) {
                if (value) {
                    var s = '<div style="width:100%;border:1px solid #ccc">' +
                            '<div style="width:' + value + '%;background:#cc0000;color:#fff">' + value + '%' + '</div>'
                    '</div>';
                    return s;
                } else {
                    return '';
                }
            }

        }

    }

    $(function () {
        jitForm.init();
    });




})(jQuery);



function showdetail(BatchNum) {
    $('#edit_window').window({
        title: "查看【" + BatchNum + "】批次详细"
    }).window('open');
    $("#dgCabinet").datagrid({
        sortName: 'Sequence',
        idField: 'CabinetID',
        url: '/ashx/ordershandler.ashx?Method=SearchBatchNumOrdersDetail',
        collapsible: false,
        fitColumns: true,
        pagination: false,
        striped: false,
        pageSize: 20,
        loadMsg: '正在加载数据，请稍候....',
        columns: [[
         //{
         //    field: 'CreatedBy', title: (WorkFlowName + '(处理)人'), hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
         //        return MadeQty == 0 ? "待扫描" : value;
         //    }
         //},
          { field: 'OrderNo', title: '订单编号', width: 70, sortable: false, halign: 'center', align: 'center' },
          { field: 'CabinetName', title: '产品名称', width: 80, sortable: false, halign: 'center', align: 'center' },
          { field: 'BarcodeNo', title: '板件条码', width: 80, sortable: false, halign: 'center', align: 'center' },
          { field: 'ItemName', title: '板件名字', width: 70, sortable: false, halign: 'center', align: 'center' },
          { field: 'MaterialType', title: '材质颜色', width: 100, sortable: false, halign: 'center', align: 'center' },
          { field: 'MadeWidth', title: '开料宽度', width: 50, sortable: false, halign: 'center', align: 'center' },
          { field: 'MadeLength', title: '开料长度', width: 50, sortable: false, halign: 'center', align: 'center' },
          { field: 'EndWidth', title: '成品宽度', width: 50, sortable: false, halign: 'center', align: 'center' },
          { field: 'EndLength', title: '成品长度', width: 50, sortable: false, halign: 'center', align: 'center' },
          { field: 'MadeHeigth', title: '厚度', width: 50, sortable: false, halign: 'center', align: 'center' },
          { field: 'Qty', title: '数量', width: 50, sortable: false, halign: 'center', align: 'center' },
          { field: 'Remark', title: '备注', width: 50, sortable: false, halign: 'center', align: 'center' },
        //{ field: 'Price', title: '单价', width: 80, sortable: false, halign: 'center', align: 'center' },
        //{ field: 'Remark', title: '备注', width: 150, sortable: false, halign: 'center', align: 'center' }

        ]],
        onBeforeLoad: function (param) {
            param['BatchNum'] = BatchNum;
        },
        onLoadSuccess: function (data) {
            if (data.total == 0) {
                var body = $(this).data().datagrid.dc.body2;
                body.find('table tbody').append('<tr><td colspan="10" style="height: 35px;border-left: #ccc dotted 1px; text-align: center;"><h1>该工序暂未流入产品</h1></td></tr>');
            }

        }
    });
}
//查看详情        
//function showdetail(id, no) {
//    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
//}

function showOrderMonitor(id, no) {
    top.addTab("查看订单生产图【" + no + "】", "/View/orders/ordermonitor.aspx?orderid=" + id + "&" + jsNC());
}