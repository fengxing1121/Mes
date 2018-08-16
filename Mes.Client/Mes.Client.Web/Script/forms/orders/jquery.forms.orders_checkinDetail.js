(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var checkindetailForm = {
        init: function () {
            checkindetailForm.initControls();
            checkindetailForm.events.loadGrid();
        },
        initControls: function () {
            checkindetailForm.controls = {
                dgdetail: $('#dgdetail'),
                search_form: $('#search_form')
            }
        },
        events: {
            loadGrid: function () {
                var inid = getUrlParam('inid');
                if (inid.length == 0) return;
                $('#InID').val(inid);
                $.ajax({
                    url: '/ashx/ProductWarehouseMainHandler.ashx?Method=GetInMain&' + jsNC(),
                    data: { InID: inid },
                    datatype: "json",
                    success: function (data) {
                        checkindetailForm.controls.search_form.form('load', data.rows[0]);
                        checkindetailForm.controls.search_form.find('input').each(function (index) {
                            $(this).attr('readonly', true);
                        });
                    }
                });


                checkindetailForm.controls.dgdetail.datagrid({
                    idField: 'DetailID',
                    url: '/ashx/ProductWarehouseMainHandler.ashx?Method=SearchInMainDetail&InID='+inid ,
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                       { field: 'CabinetName', title: '产品名称', width: 180, align: 'center' },
                       { field: 'Size', title: '成品尺寸', width: 100, sortable: false, align: 'center' },
                       { field: 'MaterialStyle', title: '材质风格', width: 100, sortable: false, align: 'center' },
                       { field: 'MaterialCategory', title: '材质类型', width: 100, sortable: false, align: 'center' },
                       { field: 'Color', title: '颜色', width: 100, sortable: false, align: 'center' },                        
                       { field: 'LocationCode', title: '仓位编号', width: 100, sortable: false, align: 'center' },
                       { field: 'LayerNum', title: '层号', width: 100, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        param['TransportID'] = $('#TransportID').val();
                    }
                });
            }
        }
    };

    $(function () {
        checkindetailForm.init();
    });

})(jQuery);


