(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var ordersPackageForm = {
        init: function () {
            ordersPackageForm.initControls();
            ordersPackageForm.controls.searchData.on('click', function () { ordersPackageForm.controls.dgdetail.datagrid('reload');} );//加载数据
            ordersPackageForm.events.loadData();
        },
        initControls: function () {
            ordersPackageForm.controls = {
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form')//查询表单
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {

            loadData: function () {
                ordersPackageForm.controls.dgdetail.datagrid({
                    sortName: 'Created',
                    idField: 'OrderID',
                    url: '/ashx/ordershandler.ashx?Method=SearchOrders&Review=true&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    {
                        field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                          var  strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');">' + rowData['OrderNo'] + '</a>';
                            return strReturn;
                        }
                    },
                    { field: 'OrderType', title: '订单类型', width: 80, sortable: false, align: 'center' },
                    //{ field: 'CustomerName', title: '客户名称', width: 150, sortable: false, halign: 'center', align: 'left' },
                    { field: 'LinkMan', title: '客户名称', width: 150, sortable: false, halign: 'center', align: 'left' },
                    { field: 'Address', title: '客户地址', width: 200, sortable: false, halign: 'center', align: 'left' },
                    //{ field: 'LinkMan', title: '联系人', width: 120, sortable: false, align: 'center' },
                    { field: 'Mobile', title: '联系电话', width: 120, sortable: false, align: 'center' },
                    { field: 'BookingDate', title: '订货日期', width: 120, hidden: false, sortable: false, align: 'center' },
                    { field: 'ShipDate', title: '交货日期', width: 120, sortable: false, align: 'center' },
                    {
                        field: 'Created', title: '创建时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                        }
                    },
                     {
                         field: 'Status', title: '是否分包', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                             switch (value.toUpperCase()) {
                                 case 'N':
                                     return '否';
                                 case 'Y':
                                     return '是'
                             }
                         }
                     }
                    
                    ]],
                    toolbar: [
                      { text: '处理分包', iconCls: 'icon-add', handler: ordersPackageForm.events. CreatePackage },
                    ],
                    onBeforeLoad: function (param) {
                        ordersPackageForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        ordersPackageForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                });
            },

            CreatePackage:  function () {
                var selRows = ordersPackageForm.controls.dgdetail.datagrid('getChecked');
                var orderids = [];
                $.each(selRows, function (index, item) {
                    orderids.push(item.OrderID);
                });
                if (orderids == "")
                    return;                
    
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=CreatePackage&' + jsNC(),
                    data: { OrderIDs: orderids.join(',') },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 1) {
                                //showInfo(returnData.message);
                                ordersPackageForm.controls.dgdetail.datagrid('reload');
                            } else {
                                showError(returnData.message);
                            }
                        }
                    }
                });
            }
        }

    };
    $(function () {
        ordersPackageForm.init();
    });

})(jQuery);


//查看详情        
function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
}