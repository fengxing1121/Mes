'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var solutionForm = {
    init: function () {
        solutionForm.initControls();
        solutionForm.initevents();
        //初始化数据   
        solutionForm.controls.SolutionID = getUrlParam('SolutionID');
        solutionForm.events.init();//加载数据
        solutionForm.controls.cancelsolution.on('click', solutionForm.events.cancel_solution); //取消方案
    },
    initControls: function () {
        solutionForm.controls = {
            dgcabinet: $('#dgcabinet'),
            dgdetail: $('#dgdetail'),
            dgHardware: $('#dgHardware'),
            skpFile: $('#skpfile'),
            edit_form: $('#edit_form'),
            upload_window: $('#upload_window'),
            upload_form: $('#upload_form'),
            uploadfile: $('#btn_upload_splitfile'),
            cancelsolution: $('#btn_cancel'),
            close_uploadwindow: $('#btn_close'),
            fileupload_submit: $('#btn_fileupload'),
            btn_quote: $('#btn_quote'),
            SolutionID: null
        }
    },
    initevents: function () {
        solutionForm.controls.uploadfile.on('click', function () {
            solutionForm.controls.upload_form.form('clear');
            solutionForm.events.open_uploadwindow();
        });
        solutionForm.controls.close_uploadwindow.on('click', solutionForm.events.close_uploadwindow);
        solutionForm.controls.fileupload_submit.on('click', solutionForm.events.fileupload_submit);
        solutionForm.controls.btn_quote.on('click', solutionForm.events.quote);

        $("#solution_uploadify").uploadify({
            width: 307,
            height: 30,
            uploader: '/ashx/solutionhandler.ashx?Method=FileUpload',
            swf: '/Script/uploadify/uploadify.swf',
            queueSizeLimit: 6,
            checkExisting: '/ashx/solutionhandler.ashx?Method=CheckFileExists',
            buttonText: '点击上传文件',
            fileSizeLimit: '300MB',
            auto: true,
            multi: true,
            fileTypeExts: '*.skp; *.xml;',
            fileDesc: '只能选择格式 (.skp, .xml)文件',
            queueID: 'Solution_queue',
            onQueueComplete: function (event, data) {
                if (event.errorMsg != '' || event.errorMsg != undefined) return;
                solutionForm.events.close_uploadwindow();
            },
            onUploadSuccess: function (file, data, response) {
                if (data.file_url == undefined && data != undefined) {
                    data = eval('(' + data + ')');
                }
                if (data.isOk == 0) {
                    showError(data.message);
                }
                else {
                    solutionForm.controls.dgcabinet.datagrid('reload');
                    $('#SolutionFileUrl').val(data.file_url);
                    $("#imgSolution").attr('src', "/Content/images/upload_success.png");
                }
            },
            onUploadStart: function (file) {
                $("#solution_uploadify").uploadify("settings", "formData", { SolutionID: $("#SolutionID").val(), CabinetID: $('#CabinetID').val(), FileType: 'SolutionFile' });
            },
            onUploadError: function (event, queueId, fileObj, errorObj) {
                //$("#solution_uploadify").attr('disable', false);
                showInfo(errorObj.type + "：" + errorObj.info);
            }
        });

        $('#imgSolution').on('click', function () {
            //$('#solution_uploadify').uploadify('upload', '*');          
        });
    },
    events: {
        init: function () {
            //解决方案
            $.ajax({
                url: '/ashx/solutionhandler.ashx?Method=GetSolution',
                data: { SolutionID: solutionForm.controls.SolutionID },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 0) {
                        showError(data.message);
                        return;
                    }
                    solutionForm.controls.edit_form.form('load', data);
                    solutionForm.events.getCustomer(data.CustomerID);
                    $("#Status").val(getSolutionStatusName(data.Status).replace('<font color="red">', '').replace('</font>', ''));
                    solutionForm.controls.edit_form.find('input').each(function (index) {
                        $(this).attr('readonly', true);
                    });
                    if (data.Status == 'P') {
                        $('#btn_quote,#btn_fileupload').show();
                    }
                    else {
                        $('#btn_quote,#btn_fileupload').hide();
                    }
                }
            });
            //产品明细
            solutionForm.controls.dgcabinet.datagrid({
                url: '/ashx/solutionhandler.ashx?Method=GetCabinets',
                idField: 'CabinetID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: true,
                columns: [[
                { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                { field: 'CabinetGroup', title: '产品名称', width: 150, sortable: false, align: 'center' },
                { field: 'CabinetName', title: '柜体名称', width: 150, sortable: false, align: 'center' },
                { field: 'Size', title: '柜体尺寸', width: 120, sortable: false, align: 'center' },
                { field: 'Color', title: '柜体颜色', width: 120, sortable: false, align: 'center' },
                { field: 'MaterialStyle', title: '材质风格', width: 120, sortable: false, align: 'center' },
                { field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center' },
                { field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center' },
                { field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center' },
                { field: 'Remark', title: '备注', width: 120, hidden: true, sortable: false, align: 'center' },
                //{
                //    field: 'op', title: '方案文件', width: 120, sortable: false, align: 'center', formatter: function (value, row, index) {
                //        if (!row.FileUploadFlag) {
                //            return '<a href="javascript:void(0);" onclick="uploadFile(\'' + row.CabinetID + '\')">上传方案文件</a>'
                //        }
                //        else {
                //            return '<a href="javascript:void(0);" onclick="downloadFile(\'' + row.CabinetID + '\')">下载方案文件</a>'
                //        }
                //    }
                //}
                ]],
                onBeforeLoad: function (param) {
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                }
            });
            //板件明细
            solutionForm.controls.dgdetail.datagrid({
                idField: 'ItemID',
                url: '/ashx/solutionhandler.ashx?Method=GetSolutionDetails&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                pageSize: 20,
                striped: false,
                showFooter: false,
                columns: [[
                    { field: 'CabinetName', title: '产品名称', width: 180, align: 'center' },
                    { field: 'BarcodeNo', title: '板件条码', width: 180, align: 'center' },
                    { field: 'ItemName', title: '部件名称', width: 120, align: 'center' },
                    { field: 'MaterialType', title: '材质', width: 100, sortable: false, align: 'center' },
                    { field: 'ItemType', title: '颜色', width: 100, sortable: false, align: 'center' },
                    {
                        field: 'MadeWidth', title: '开料宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return value.toString().replace('.00', '');
                        }
                    },
                    {
                        field: 'MadeLength', title: '开料长度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return value.toString().replace('.00', '');
                        }
                    },
                    {
                        field: 'EndWidth', title: '成品宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return value.toString().replace('.00', '');
                        }
                    },
                    {
                        field: 'EndLength', title: '成品长度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return value.toString().replace('.00', '');
                        }
                    },
                    {
                        field: 'MadeHeight', title: '厚度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return value.toString().replace('.00', '');
                        }
                    },
                    {
                        field: 'Qty', title: '数量', width: 50, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return value.toString().replace('.00', '');
                        }
                    },
                    {
                        field: 'FilePathUrl', title: '浏览', width: 70, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            //console.log(value.indexOf(".mpr"));
                            //if (value == undefined) return "";
                            if (value.indexOf(".mpr") != -1) {

                                var str = '<a style="cursor:pointer;" onclick="viewDetail(\'' + rowData['ItemID'] + '\',' + rowIndex + ')">查看</a>';//&nbsp;&nbsp;|&nbsp;&nbsp;
                                // str += '<a style=\"cursor:pointer;\" onclick="downDetail(\'' + rowData['FilePathUrl'] + '\',' + rowIndex + ')">下载</a>';
                                return str;
                            }
                        }
                    },
                    //{ field: 'Remarks', title: '备注', width: 150, sortable: false, align: 'center' }
                ]],
                groupField: 'CabinetName',
                view: groupview,
                groupFormatter: function (value, rows) {
                    return value + ' - ' + rows.length + ' Item(s)';
                },
                onBeforeLoad: function (param) {
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                },
                //onClickRow: function () {
                //    var row = solutionForm.controls.dgdetail.datagrid('getSelected');
                //    console.log(JSON.stringify(row));
                //    if (!row) {
                //        return;
                //    }
                //    console.log(row.ItemID);
                //    viewDetail(row.ItemID);
                //},
            });

            //五金明细
            solutionForm.controls.dgHardware.datagrid({
                idField: 'ItemID',
                url: '/ashx/solutionhandler.ashx?Method=GetSolutionHardwares&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                pageSize: 20,
                columns: [[
                { field: 'HardwareCategory', title: '分类', width: 120, sortable: false, align: 'center' },
                { field: 'HardwareCode', title: '物料编码', width: 120, sortable: false, align: 'center' },
                { field: 'HardwareName', title: '名称', width: 150, sortable: false, align: 'center' },
                { field: 'Style', title: '规格/型号', width: 150, sortable: false, align: 'center' },
                { field: 'Qty', title: '数量', width: 150, sortable: false, align: 'center' },
                { field: 'Unit', title: '单位', width: 200, sortable: false, align: 'center' }
                ]],
                onBeforeLoad: function (param) {
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                }
            });

            //spkFile
            solutionForm.controls.skpFile.datagrid({
                //idField: 'DoorID',
                url: '/ashx/solutionhandler.ashx?Method=GetSoltionSpkFile',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                    { field: 'DoorID', title: '移门ID', hidden: true, width: 200, sortable: false, align: 'center' },
                    { field: 'FileName', title: '文件名称', width: 200, sortable: false, align: 'center' },
                    { field: 'Created', title: '上传时间', width: 120, sortable: false, align: 'center', },
                    {
                        field: 'action', title: '操作', width: 120, sortable: false, align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            var str = '<img style="cursor:pointer;" onclick="downloadSpkFile(\'' + rowData.FileID + '\')" src="/Content/images/exticons/page/page_white_put.png" alt="下载文件"/>&nbsp;&nbsp;';
                            return str;
                        }
                    }
                ]],
                onBeforeLoad: function (param) {
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                }
            });
        },
        getCustomer: function () {
            $.ajax({
                url: '/ashx/customerhandler.ashx',
                data: { Method: 'GetCustomer', CustomerID: arguments[0] },
                success: function (data) {
                    if (data.isOk == 0) {
                    }
                    else {
                        solutionForm.controls.edit_form.form('load', data);
                    }
                }
            });
        },
        open_uploadwindow: function () {
            solutionForm.controls.upload_window.window('open');
            $("#imgSolution").attr('src', "/Content/images/solution_bg.png");
        },
        close_uploadwindow: function () {
            solutionForm.controls.upload_window.window('close');
        },
        cancel_solution: function () {
            $.messager.confirm('系统提示', '确定要取消此方案吗？', function (r) {
                if (!r) {
                    return;
                }
            });
            $.ajax({
                url: '/ashx/solutionhandler.ashx?Method=CancelSolution&' + jsNC(),
                data: { id: solutionForm.controls.id },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 0) {
                        showError(data.message);
                        return;
                    }
                    solutionForm.controls.edit_form.form('load', data);
                    solutionForm.events.getCustomer(data.CustomerID);
                    $("#Status").val(getSolutionStatusName(data.Status).replace('<font color="red">', '').replace('</font>', ''));
                    solutionForm.controls.edit_form.find('input').each(function (index) {
                        $(this).attr('readonly', true);
                    });
                }
            });
        },
        fileupload_submit: function () {

        },
        quote: function () {
            var solutionid = $('#SolutionID').val();
            var url = '/View/crm/newquote.aspx?SolutionID=' + solutionid;
            var icon = 'table';
            var status = getSolutionStatusValue($("#Status").val());
            $.ajax({
                url: "/ashx/solutionhandler.ashx?Method=GetSolutionStatus",
                data: { Status: status, SolutionID: solutionid },
                success: function (data) {
                    if (data.isOk == 1) {
                        top.addTab('方案报价', url, icon);
                    } else {
                        showError(data.message);
                        top.addTab("方案管理", "/View/crm/solutions.aspx", 'table');
                        top.closeTab('方案详情');
                    }
                }
            });
        }
    }
};

$(function () {
    solutionForm.init();
});

function uploadFile() {
    solutionForm.controls.upload_form.form('clear');
    $("#solution_uploadify").attr('disable', false);
    $('#CabinetID').val(arguments[0]);
    solutionForm.events.open_uploadwindow();
}

function viewDetail(ItemID) {
    var source = getUrlParam('source');
    if (source == "null" || source == null) {//ems
        parent.$('#iframeView').attr('src', '/View/mpr/Index.aspx?ItemID=' + ItemID + '&ver=' + +jsNC());
        parent.$('#view_window').dialog('open');
    }
    else {
        $('#iframeView_sub').attr('src', '/View/mpr/Index.aspx?ItemID=' + ItemID + '&ver=' + +jsNC());
        $('#view_window_sub').dialog('open');
    }
}

function downDetail(path) {
    var array = path.split(',');
    for (var i = 0; i < array.length; i++) {
        $("#btndown").attr("href", "/" + array[i]);
        //$("#btndown").trigger('click');
        document.getElementById("btndown").click();
    }
    //alert("11");
    //window.open(path);

}

function downloadSpkFile() {
    var fileid = arguments[0];
    $.messager.confirm('系统提示', '确定要下载此文件吗？', function (flag) {
        if (flag) {
            var form = $("<form>");   //定义一个form表单
            form.attr('style', 'display:none');   //在form表单中添加查询参数
            form.attr('target', '');
            form.attr('method', 'post');
            form.attr('action', "/View/download/download_skpFile.aspx");
            var down = $('<input>');
            down.attr('type', 'hidden');
            down.attr('name', 'FileID');
            down.attr('value', fileid);
            $('body').append(form);  //将表单放置在web中 
            form.append(down);   //将查询参数控件提交到表单上
            form.submit();
        }
    });
}
