(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var warehouse_out_detailForm = {
        init: function () {
            warehouse_out_detailForm.initControls();
            warehouse_out_detailForm.events.loadData();//加载数据           

        },
        initControls: function () {
            warehouse_out_detailForm.controls = {

                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
            }

        },
        events: {

            loadData: function () {
                //初始化数据   
                var outid = getUrlParam('outid');
                if (outid.length == 0) return;
                $('#OutID').val(outid);
                $.ajax({
                    url: '/ashx/WarehouseOutMainHandler.ashx?Method=GetOutMain&' + jsNC(),
                    data: { OutID: outid },
                    datatype: "json",
                    success: function (data) {
                        warehouse_out_detailForm.controls.search_form.form('load', data.rows[0]);
                        $('#WorkShopID').val(data.rows[0].WorkShopName)//车间
                        warehouse_out_detailForm.controls.search_form.find('input').each(function (index) {
                            $(this).attr('readonly', true);
                        });
                    }
                });
                warehouse_out_detailForm.controls.dgdetail.datagrid({
                    idField: 'DetailID',
                    url: '/ashx/WarehouseOutMainHandler.ashx?Method=SearchOutMainDetail&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'MaterialName', title: '材料名称', width: 120, sortable: false, align: 'center' },
                    { field: 'Warehouse', title: '仓位', width: 150, align: 'center' },
                  
                    {
                        field: 'Qty', title: '数量', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            return value.toString().replace('.00', '');
                        }
                    }
                    ]],
                    onBeforeLoad: function (param) {
                        param['OutID'] = $('#OutID').val();
                    }
                });
            }
        }

    };
    $(function () {
        warehouse_out_detailForm.init();
    });

})(jQuery);