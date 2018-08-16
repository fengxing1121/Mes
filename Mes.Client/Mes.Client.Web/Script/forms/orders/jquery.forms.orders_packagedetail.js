(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var ordersPackageForm = {
        init: function () {
            ordersPackageForm.initControls();
            ordersPackageForm.controls.searchData.on('click', function () { ordersPackageForm.controls.dgdetail.datagrid('reload'); });//加载数据
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
                    url: '/ashx/ordershandler.ashx?Method=SearchOrdersPackage&' + jsNC(),
                    collapsible: true,
                    fitColumns: false,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    frozenColumns: [[
                    {
                        field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onClick="showdetail(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');">' + rowData['OrderNo'] + '</a>';
                            return strReturn;
                        }
                    },
                    { field: 'OrderType', title: '订单类型', width: 80, sortable: false, align: 'center' },
                    { field: 'CustomerName', title: '客户名称', width: 150, sortable: false, halign: 'center', align: 'left' },
                    {
                        field: 'BookingDate', title: '订货日期', width: 120, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    },
                    {
                        field: 'ShipDate', title: '交货日期', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                        }
                    }
                    ]],
                    columns: [[
                    { field: 'CabinetName', title: '产品名称', width: 120, sortable: false, halign: 'center', align: 'left' },
                    { field: 'Size', title: '成品尺寸', width: 150, sortable: false, halign: 'center', align: 'left' },
                    { field: 'Color', title: '颜色', width: 150, sortable: false, halign: 'center', align: 'left' },
                    { field: 'MaterialStyle', title: '风格', width: 150, sortable: false, halign: 'center', align: 'left' },
                    { field: 'MaterialCategory', title: '材质', width: 150, sortable: false, halign: 'center', align: 'left' },

                        { field: 'BarcodeNo', title: '板件条码', width: 120, sortable: false, halign: 'center', align: 'left' },
                        { field: 'ItemName', title: '板件名称', width: 150, sortable: false, halign: 'center', align: 'left' },
                        {
                            field: '1', title: '开料尺寸', width: 150, sortable: false, halign: 'center', align: 'left', formatter: function (value, rowData, rowIndex) {
                                return rowData.MadeWidth + '*' + rowData.MadeLength + '*' + rowData.MadeHeight
                            }
                        },
                        {
                            field: '2', title: '成型尺寸', width: 150, sortable: false, halign: 'center', align: 'left', formatter: function (value, rowData, rowIndex) {
                                return rowData.EndWidth + '*' + rowData.EndLength + '*' + rowData.MadeHeight
                            }
                        },
                        { field: 'Qty', title: '数量', width: 60, sortable: false, halign: 'center', align: 'left' },
                        { field: 'PackageNum', title: '包号', width: 60, sortable: false, halign: 'center', align: 'left' },
                        { field: 'PackageBarcode', title: '装包条码', width: 120, sortable: false, halign: 'center', align: 'left' },
                        {
                            field: 'IsDisabled', title: '是否损坏', width: 60, sortable: false, halign: 'center', align: 'left', formatter: function (value, rowData, rowIndex) {
                                if (value.toLowerCase() == "false")
                                    return ""
                                else
                                    return "是"                                
                            }
                        }
                    ]],
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