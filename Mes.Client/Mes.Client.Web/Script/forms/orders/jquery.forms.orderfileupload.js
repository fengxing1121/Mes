(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var ordersfileuploadForm = {
        init: function () {
            ordersfileuploadForm.initControls();
            ordersfileuploadForm.controls.fileupload.on('click', ordersfileuploadForm.events.fileupload);//加载数据          

        },
        initControls: function () {
            ordersfileuploadForm.controls = {
                upload_form: $('#upload_form'),
                fileupload: $('#btn_fileupload'),
            }
             
        },
        events: {

            loadData: function () {
                var orderid = getUrlParam('orderid');
                if (orderid.length == 0) return;

                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                    data: { OrderID: orderid },
                    datatype: "json",
                    success: function (data) {
                        ordersfileuploadForm.controls.upload_form.form('load', data);
                        ordersfileuploadForm.controls.upload_form.find('input').each(function (index) {
                            //$(this).attr('readonly', true);
                            $(this).addClass('easyui-readonly');
                        });
                    }
                });
            },

            submitfile: function () {                 
                ordersfileuploadForm.controls.upload_form.form('submit', {
                    url: '/ashx/ordershandler.ashx?Method=FileUpload&' + jsNC(),
                    data: ordersfileuploadForm.controls.upload_form.serialize(),
                    loadMsg: '正在提交数据，请稍候...',
                    onSubmit: function () {
                        var isValid = ordersfileuploadForm.controls.upload_form.form('validate');
                        if (!isValid) {
                            return isValid;
                        }
                        else {
                            $('#btn_fileupload').linkbutton('disable');
                            return isValid;
                        }
                    },
                    success: function (result) {
                        $('#btn_fileupload').linkbutton('enable');
                        if (result) {
                        }
                    }
                });
            }
        }
    };
    $(function () {
        ordersfileuploadForm.init();
    });

})(jQuery);

 