(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var checkoutdetailForm = {
        init: function () {
           checkoutdetailForm.initControls();
           checkoutdetailForm.events.loadGrid();
        },
        initControls: function () {
            checkoutdetailForm.controls = {               
                dgdetail: $('#dgdetail'),
                search_form: $('#search_form')            
            }            
        },
        events: {
            loadGrid: function () {                 
                var TransportID = getUrlParam('TransportID');
                if (TransportID.length == 0) return;
                $('#TransportID').val(TransportID);
                $.ajax({
                    url: '/ashx/TransportMainHandler.ashx?Method=GetOutMain&' + jsNC(),
                    data: { TransportID: TransportID },
                    datatype: "json",
                    success: function (data) {
                        checkoutdetailForm.controls.search_form.form('load', data.rows[0]);
                        
                        checkoutdetailForm.controls.search_form.find('input').each(function (index) {
                            $(this).attr('readonly', true);
                        });
                    }
                });


                checkoutdetailForm.controls.dgdetail.datagrid({
                    idField: 'TransportID',
                    url: '/ashx/TransportMainHandler.ashx?Method=SearchOutMainDetail&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                      { field: 'OrderNo', title: '订单编号', width: 80, align: 'center'},                    
                      { field: 'CustomerName', title: '客户名称', width: 85, sortable: false, halign: 'center', align: 'center' },
                      { field: 'CustomerAddress', title: '客户地址', width: 200, sortable: false, halign: 'center', align: 'center' },
                      { field: 'CustomerMobile', title: '联系电话', width: 90, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        param['TransportID'] = $('#TransportID').val();
                    }
                });
            }            
        }
    };
    
    $(function () {
        checkoutdetailForm.init();
    });

})(jQuery);

 
