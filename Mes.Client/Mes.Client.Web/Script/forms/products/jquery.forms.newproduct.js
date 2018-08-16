'use strict';
document.msCapsLockWarningOff = true;
var t = null;
var min = 0; //分
var sec = 0; //秒
var hour = 0; //小时
var newproduct = {
    init: function () {
        newproduct.initControls();
        newproduct.controls.ProductID.val(NewGuid());
        newproduct.events.loadCategory();
        $("#btnProductImg_Upload").uploadify({
            width: 307,
            height: 30,
            uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
            swf: '/Script/uploadify/uploadify.swf',
            queueSizeLimit: 6,
            formData: { ProductID: $("#ProductID").val(), FileType: 'HeadImg' },
            checkExisting: '/ashx/fileuploadhandler.ashx?Method=CheckFileExists',//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            buttonText: '点击上传文件',
            fileSizeLimit: '1MB',
            auto: true,
            multi: true,
            fileTypeExts: '*.gif; *.jpg; *.png',
            fileDesc: '只能选择格式 (.JPG, .GIF, .PNG)',
            queueID: 'HeadImg_queue',
            onQueueComplete: function (queueData) {
                $("#btnProductImg_Upload").uploadify('disable', true);
            },
            onUploadSuccess: function (file, data, response) {
                if (data.file_url == undefined && data != undefined) {
                    data = eval('(' + data + ')');
                }
                $('#HeadImgUrl').val(data.file_url);
                $("#imgMain").attr('src', data.file_url);
            },            
            onUploadError: function (event, queueId, fileObj, errorObj) {
                $("#btnProductImg_Upload").uploadify('disable', false);
                showInfo(errorObj.type + "：" + errorObj.info);
            }            
        });
        $("#BOM_uploadify").uploadify({
            width: 307,
            height: 30,
            uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
            formData: { ProductID: $("#ProductID").val(), FileType: 'BOM' },
            swf: '/Script/uploadify/uploadify.swf',
            queueSizeLimit: 1,
            checkExisting: '/ashx/fileuploadhandler.ashx?Method=CheckFileExists',
            fileSizeLimit: '2MB',
            auto: true,
            multi: false,
            buttonText: '点击上传料单文件',
            fileTypeExts: '*.xls; *.xlsx;',
            fileDesc: '只能选择Excel文件 (.xls, .xlsx)',
            queueID: 'BOM_queue',
            onQueueComplete: function (event) {
                $("#BOM_uploadify").uploadify('disable', true);
            },
            onUploadSuccess: function (file, data, response) {
                if (data.file_url == undefined && data != undefined) {
                    data = eval('(' + data + ')');
                }
                $('#BOMFileUrl').val(data.file_url);
                $("#imgBOM").attr('src', "/Content/images/upload_success.png");
            },
            onUploadError: function (event, queueId, fileObj, errorObj) {
                $("#BOM_uploadify").uploadify('disable', false);
                showInfo(errorObj.type + "：" + errorObj.info);
            }
        });

        $("#Hardware_uploadify").uploadify({
            width: 307,
            height: 30,
            uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
            formData: { ProductID: $("#ProductID").val(), FileType: 'HardWare' },
            swf: '/Script/uploadify/uploadify.swf',
            queueSizeLimit: 1,
            checkExisting: '/ashx/fileuploadhandler.ashx?Method=CheckFileExists',
            fileSizeLimit: '1MB',
            auto: true,
            multi: false,
            buttonText: '点击上传五金文件',
            fileTypeExts: '*.xls; *.xlsx;',
            fileDesc: '只能选择Excel文件 (.xls, .xlsx)',
            queueID: 'Hardware_queue',
            onQueueComplete: function (event) {
                $("#Hardware_uploadify").uploadify('disable', true);
            },
            onUploadSuccess: function (file, data, response) {
                if (data.file_url == undefined && data != undefined) {
                    data = eval('(' + data + ')');
                }
                $('#HardwareFileUrl').val(data.file_url);
                $("#imgHardware").attr('src', "/Content/images/upload_success.png");
            },
            onUploadError: function (event, queueId, fileObj, errorObj) {
                $("#Hardware_uploadify").uploadify('disable', false);
                showInfo(errorObj.type + "：" + errorObj.info);
            }
        });
        $("#CNC_uploadify").uploadify({
            width: 307,
            height: 30,
            uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
            formData: { ProductID: $("#ProductID").val(), FileType: 'CNC' },
            swf: '/Script/uploadify/uploadify.swf',
            queueSizeLimit: 999,
            checkExisting: '/ashx/fileuploadhandler.ashx?Method=CheckFileExists',
            fileSizeLimit: '1MB',
            auto: true,
            multi: true,
            buttonText: '点击上传NC文件',
            fileTypeExts: '*.nc; *.csv;*.xml;*.mpr;',
            fileDesc: '只能选择Excel文件 (.nc, .csv,*.xml;*.mpr)',
            queueID: 'CNC_queue',
            onQueueComplete: function (event) {
                $("#CNC_uploadify").uploadify('disable', true);
            },
            onUploadSuccess: function (file, data, response) {
                if (data.file_url == undefined && data != undefined) {
                    data = eval('(' + data + ')');
                }
                var temp = $('#CNCFileUrl').val();
                if (temp == '')
                    temp = data.file_url;
                else
                    temp += ',' + data.file_url;
                $('#CNCFileUrl').val(temp);
                $("#imgCNC").attr('src', "/Content/images/upload_success.png");
            },
            onUploadError: function (event, queueId, fileObj, errorObj) {
                $("#CNC_uploadify").uploadify('disable', false);
                showInfo(errorObj.type + "：" + errorObj.info);
            }
        });
        $("#Drawing_uploadify").uploadify({
            width: 307,
            height: 30,
            uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
            formData: { ProductID: $("#ProductID").val(), FileType: 'Drawing' },
            swf: '/Script/uploadify/uploadify.swf',
            queueSizeLimit: 999,
            checkExisting: '/ashx/fileuploadhandler.ashx?Method=CheckFileExists',
            fileSizeLimit: '1MB',
            auto: true,
            multi: true,
            buttonText: '点击上传图纸文件',
            fileTypeExts: '*.dxf; *.dwg;*.pdf;*.png;*.bmp;*.jpg;*.gif',
            fileDesc: '只能选择这些文件 (*.dxf; *.dwg;*.pdf;*.png;*.bmp;*.jpg;*.gif)',
            queueID: 'Drawing_queue',
            onQueueComplete: function (event) {
                $("#Drawing_uploadify").uploadify('disable', true);
            },
            onUploadSuccess: function (file, data, response) {
                if (data.file_url == undefined && data != undefined) {
                    data = eval('(' + data + ')');
                }
                var temp = $('#DrawingFileUrl').val();
                if (temp == '')
                    temp = data.file_url;
                else
                    temp += ',' + data.file_url;
                $('#DrawingFileUrl').val(temp);
                $("#imgDrawing").attr('src', "/Content/images/upload_success.png");
            },
            onUploadError: function (event, queueId, fileObj, errorObj) {
                $("#Drawing_uploadify").uploadify('disable', false);
                showInfo(errorObj.type + "：" + errorObj.info);
            }
        });
        $("#Rendering_uploadify").uploadify({
            width: 307,
            height: 30,
            uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
            formData: { ProductID: $("#ProductID").val(), FileType: 'Rendering' },
            swf: '/Script/uploadify/uploadify.swf',
            queueSizeLimit: 999,
            checkExisting: '/ashx/fileuploadhandler.ashx?Method=CheckFileExists',
            fileSizeLimit: '1MB',
            auto: true,
            multi: true,
            buttonText: '点击上传效果文件',
            fileTypeExts: '*.gif; *.jpg; *.png;*.bmp',
            fileDesc: '只能选择格式 (.JPG, .GIF, .PNG,BMP)',
            queueID: 'Rendering_queue',
            onQueueComplete: function (event) {
                $("#Rendering_uploadify").uploadify('disable', true);
            },
            onUploadSuccess: function (file, data, response) {
                if (data.file_url == undefined && data != undefined) {
                    data = eval('(' + data + ')');
                }
                var temp = $('#RenderingFileUrl').val();
                if (temp == '')
                    temp = data.file_url;
                else
                    temp += ',' + data.file_url;
                $('#RenderingFileUrl').val(temp);
                $("#imgRendering").attr('src', "/Content/images/upload_success.png");
            },            
            onUploadError: function (event, queueId, fileObj, errorObj) {
                $("#Rendering_uploadify").uploadify('disable', false);
                showInfo(errorObj.type + "：" + errorObj.info);
            }
        });

        newproduct.controls.submit.on('click', newproduct.events.submit);
    },
    initControls: function () {
        newproduct.controls = {
            ProductID: $("#ProductID"),
            actionUrl: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
            checkExistingUrl: '/ashx/fileuploadhandler.ashx?Method=CheckFileExists',
            ExcelFileTypeExts: '*.xls; *.xlsx;',
            ImageFileTypeExts: '*.gif; *.jpg; *.png',
            edit_form: $('#edit_form'),
            loading: $('#submit_window'),
            submit: $('#btn_submit'),
        }

    },
    events: {
        loadCategory: function () {
            $('#CategoryID').combotree({
                url: '/ashx/categoryhandler.ashx?Method=GetCategoryTreeByCategoryCode&CategoryCode=ProductCategory&RootName=' + escape('产品分类'),
                state: 'closed',
                required: true,
                editable: false,
                onLoadSuccess: function (node, param) {
                    var nd = $('#CategoryID').combotree('tree').tree('getRoot');
                    if (nd != undefined) {
                        $('#CategoryID').combotree('tree').tree('expand', nd.target);
                    }
                }
            });
        },
        submit: function () {
            t = null,
            hour = 0,
            min = 0,
            sec = 0;
            $('.runtime').html('');
            //效果文件            
            if ($('#HeadImgUrl').val() == '') {
                $("#btnProductImg_Upload").uploadify('disable', false);
                showError('请上传效果文件。');
                return;
            }
            //处理BOM
            if ($('#BOMFileUrl').val() == '') {
                $("#BOM_uploadify").uploadify('disable', false);
                showError('请上传BOM文件。');
                return;
            }

            //处理五金单
            if ($('#HardwareFileUrl').val() == '') {
                $("#Hardware_uploadify").uploadify('disable', false);
                showError('请上传五金文件。');
                return;
            }
            //处理加工文件
            if ($('#CNCFileUrl').val() == '') {
                $("#CNC_uploadify").uploadify('disable', false);
                showError('请上传NC文件。');
                return;
            }

            //处理图纸文件
            if ($('#DrawingFileUrl').val() == '') {
                $("#Drawing_uploadify").uploadify('disable', false);
                showError('请上传图纸文件。');
                return;
            }
            //处理效果图文件
            if ($('#RenderingFileUrl').val() == '') {
                $("#Rendering_uploadify").uploadify('disable', false);
                showError('请上传效果图文件。');
                return;
            }
            newproduct.controls.edit_form.form('submit', {
                url: '/ashx/producthandler.ashx?Method=SaveProduct&' + jsNC(),
                data: newproduct.controls.edit_form.serialize(),
                datatype: "json",
                loadMsg: "正在提交数据，请稍候...",
                onSubmit: function () {
                    var isValid = newproduct.controls.edit_form.form('validate');
                    if (!isValid) {
                        return isValid;
                    }
                    else {
                        setInterval(function () { t = newproduct.events.timedCount(); }, 1000);
                        newproduct.controls.loading.window('open');
                        $('<div id="unloadMask"></div>').appendTo('body').height($("body").height());
                        newproduct.controls.submit.linkbutton('disable');
                        return isValid;
                    }
                },
                success: function (result) {
                    try {
                        newproduct.controls.submit.linkbutton('enable');
                        if (result.isOk == undefined) {
                            result = eval('(' + result + ')');
                        }
                        if (result) {
                            if (result.isOk == 0) {
                                showError(result.message);
                                newproduct.events.stopCount();
                                newproduct.controls.loading.window('close');
                            } else {
                                newproduct.events.stopCount();
                                newproduct.controls.loading.window('close');//进度条窗口
                                top.closeTab('新增产品');
                            }
                        }
                    }
                    catch (e) {
                        showError(e.message);
                        newproduct.events.stopCount();
                        newproduct.controls.loading.window('close');
                    }
                }
            });
        },
        timedCount: function () {
            if (sec == 60) {
                sec = 0;
                min += 1;
            }
            if (min == 60) {
                min = 0;
                hour += 1;
            }
            $('.runtime').html('已经运行：' + cast(hour) + ':' + cast(min) + ':' + cast(sec));
            sec = sec + 1
        },
        stopCount: function () {
            clearTimeout(t)
        }
    }
};

$(function () {
    newproduct.init();
});

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}


