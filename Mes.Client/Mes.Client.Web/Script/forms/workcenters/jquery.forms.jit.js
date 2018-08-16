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
                search_form: $('#search_form')//查询表单
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {

            loadData: function () {
                jitForm.controls.dgdetail.datagrid({
                    sortName: 'Created',
                    idField: 'OrderID',
                    url: '/ashx/ordershandler.ashx?Method=SearchOrders&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    {
                        field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');">' + rowData['OrderNo'] + '</a>';
                            return strReturn;
                        }
                    },
                    { field: 'OutOrderNo', title: '外部订单号', width: 80, sortable: false, align: 'center' },
                    { field: 'PurchaseNo', title: '采购单号', width: 80, sortable: false, align: 'center' },
                    { field: 'CabinetType', title: '产品类型', width: 60, sortable: false, align: 'center' },
                    { field: 'OrderType', title: '订单类型', width: 70, sortable: false, align: 'center' },
                    { field: 'CustomerName', title: '客户名称', width: 150, sortable: false, halign: 'center', align: 'center' },                   
                    //{ field: 'Address', title: '客户地址', width: 250, sortable: false, halign: 'center', align: 'center' },
                    { field: 'LinkMan', title: '联系人', width: 120, sortable: false, align: 'center' },
                    { field: 'Mobile', title: '联系电话', width: 90, sortable: false, align: 'center' },
                    {
                        field: 'BookingDate', title: '订货日期', width: 90, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'ShipDate', title: '交货日期', width: 90, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    //{
                    //    field: 'Created', title: '创建时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                    //        if (value == undefined) return "";
                    //        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                    //    }
                    //},
                    {
                        field: 'IsStandard', title: '是否正标', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            if (value == "True")
                                return "是";
                            else
                                return "否";

                        }
                    },
                   //{
                   //    field: 'IsOutsourcing', title: '是否外购', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                   //        if (value == undefined) return "";
                   //        if (value == "True")
                   //            return "是";
                   //        else
                   //            return "否";
                   //    }
                   //},

                    {
                        field: 'Status', title: '订单状态', width: 65, sortable: false, align: 'center', formatter: function (value, row, index) {
                            return GetOrderStatusName(value);
                        }
                    },
                    {
                        field: 'p', title: '进度', width: 100, sortable: false, align: 'center', formatter: function (value, rowData, index) {
                            if (('P,F,I,O').indexOf(rowData.Status) < 0) {
                                return "未开始";
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

//查看详情        
function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
}

function showOrderMonitor(id, no) {
    top.addTab("查看订单生产图【" + no + "】", "/View/orders/ordermonitor.aspx?orderid=" + id + "&" + jsNC());
}