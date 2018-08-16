(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var warehouse_in_detailForm = {
        init: function () {
            warehouse_in_detailForm.initControls();
             warehouse_in_detailForm.events.loadData();//加载数据           
            
        },
        initControls: function () {
            warehouse_in_detailForm.controls = {
                
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form')//查询表单
            }
            
        },
        events: {

            loadData: function () {
                //初始化数据   
                var inid = getUrlParam('inid');
                if (inid.length == 0) return;
                $('#InID').val(inid);
                $.ajax({
                    url: '/ashx/WarehouseInMainHandler.ashx?Method=GetInMain&' + jsNC(),
                    data: { InID: inid },
                    datatype: "json",
                    success: function (data) {
                        warehouse_in_detailForm.controls.search_form.form('load', data.rows[0]);
                        
                        warehouse_in_detailForm.controls.search_form.find('input').each(function (index) {
                            $(this).attr('readonly', true);
                        });
                    }
                });
                warehouse_in_detailForm.controls.dgdetail.datagrid({
                    idField: 'DetailID',
                    url: '/ashx/WarehouseInMainHandler.ashx?Method=SearchInMainDetail&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                    { field: 'MaterialName', title: '材料名称', width: 120, sortable: false, align: 'center' },
                     { field: 'WarehouseName', title: '仓位名称', width: 150, align: 'center' },
                    
                     {
                         field: 'Qty', title: '数量', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                             return value.toString().replace('.00', '');
                         }
                     },
                     { field: 'Price', title: '单价', width: 150, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        param['InID'] = $('#InID').val();
                        //param['CabinetNum'] = $('#CabinetNum').val();
                    }
                });
            }
        }

    };
    $(function () {
        warehouse_in_detailForm.init();
    });

})(jQuery);
 