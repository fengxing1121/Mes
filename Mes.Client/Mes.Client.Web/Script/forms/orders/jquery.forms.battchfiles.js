'use strict';
document.msCapsLockWarningOff = true;
var t = null;
var min = 0; //分
var sec = 0; //秒
var hour = 0; //小时
var battchfiles_form = {
    init: function () {
        battchfiles_form.initControls();
        battchfiles_form.controls.search.on('click', function () { battchfiles_form.controls.dgdetail.datagrid('reload'); });//加载数据
        battchfiles_form.controls.submit.on('click', function () { battchfiles_form.events.submit(); });
        battchfiles_form.controls.cancel.on('click', function () { battchfiles_form.controls.upload_window.window('close'); });
        battchfiles_form.events.loadData();
        battchfiles_form.events.loadWorkingLine();
    },
    initControls: function () {
        battchfiles_form.controls = {
            search: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form'),//查询表单
            loading: $('#submit_window'),
            upload_form: $('#upload_form'),
            upload_window: $('#upload_window'),
            submit: $('#btn_fileupload'),
            cancel: $('#btn_cancel')
        }
        $('#btn_search_ok').linkbutton();
    },
    events: {
        loadData: function () {
            battchfiles_form.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'FileID',
                url: '/ashx/battchfilehandler.ashx?Method=SearchBattchFiles&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: true,
                columns: [[
                { field: 'FileID', title: '文件ID', hidden: true, width: 120, align: 'center' },
                { field: 'BattchNum', title: '批次号', width: 120, align: 'center' },
                { field: 'WorkingLineName', title: '生产线', width: 150, sortable: false, align: 'center' },
                { field: 'FileType', title: '文件类型', width: 100, sortable: false, align: 'center' },
                { field: 'FileName', title: '文件名称', width: 150, sortable: false, align: 'center' },
                
                {
                    field: 'Created', title: '上传时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                    }
                },
                {
                    field: 'IsDownload', title: '已下载', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        else if (value.toLowerCase() === 'true') {
                            return "<span style='color:green;'>是</span>";
                        }
                        else return "<span style='color:red;'>否</span>";
                    }
                },
                { field: 'CreatedBy', title: '上传人', width: 120, sortable: false, align: 'center' },
                { field: 'ModifiedBy', title: '下载人', width: 120, sortable: false, align: 'center' },
                {
                    field: 'op', title: '操作', width: 90, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        var str = '<img style="cursor:pointer;" onclick="downloadbattchfile(\'' + rowData.FileID + '\')" src="/Content/images/exticons/page/page_white_put.png" alt="下载文件"/>&nbsp;&nbsp;';
                        str += '<img style="cursor:pointer;" onclick="deletebattchfile(\'' + rowData.FileID + '\')" src="/Content/images/exticons/cancel.png" alt="删除行"/>';
                        return str;
                    }
                }
                ]],
                toolbar: [
                      { text: '上传文件', iconCls: 'page_white_put', handler: battchfiles_form.events.open_uploadfile },
                ],
                onBeforeLoad: function (param) {
                    battchfiles_form.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    battchfiles_form.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },
        loadWorkingLine: function () {
            battchfiles_form.controls.upload_form.find('#WorkingLineID').combobox({
                url: '/ashx/workinglinehandler.ashx?Method=GetWorkingLines&' + jsNC(),
                textField: 'WorkingLineName',
                valueField: 'WorkingLineID',
                editable: false
            });

            battchfiles_form.controls.search_form.find('#WorkingLineID').combobox({
                url: '/ashx/workinglinehandler.ashx?Method=GetWorkingLines&' + jsNC(),
                textField: 'WorkingLineName',
                valueField: 'WorkingLineID',
                editable: false
            });
        },
        open_uploadfile: function () {
            battchfiles_form.controls.upload_form.form('clear');
            battchfiles_form.controls.upload_window.window('open');
        },
        submit: function () {
            t = null;
            hour = 0;
            min = 0;
            sec = 0;
            $('.runtime').html('');
           
            battchfiles_form.controls.upload_form.form('submit', {
                url: '/ashx/battchfilehandler.ashx?Method=UploadBattchFile&' + jsNC(),
                data: battchfiles_form.controls.upload_form.serialize(),
                loadMsg: '正在提交数据，请稍候...',
                onSubmit: function () {
                    var isValid = battchfiles_form.controls.upload_form.form('validate');
                    if (!isValid) {
                        return isValid;
                    }
                    else {
                        setInterval(function () { t = battchfiles_form.events.timedCount(); }, 1000);
                        battchfiles_form.controls.loading.window('open');
                        $('#btn_fileupload').linkbutton('disable');
                        return isValid;
                    }
                },
                success: function (result) {
                    try {
                        $('#btn_fileupload').linkbutton('enable');
                        if (result.isOk == undefined) {
                            result = eval('(' + result + ')');
                        }
                        if (result.isOk == 1) {
                            battchfiles_form.controls.dgdetail.datagrid('reload');
                            battchfiles_form.controls.upload_window.window('close');

                            battchfiles_form.events.stopCount();
                            battchfiles_form.controls.loading.window('close');//进度条窗口
                        } else {
                            battchfiles_form.events.stopCount();
                            battchfiles_form.controls.loading.window('close');
                        }
                    }
                    catch (e) {
                        showError(e.message);
                        battchfiles_form.events.stopCount();
                        battchfiles_form.controls.loading.window('close');
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
        },
    }
};

function deletebattchfile() {
    var fileid = arguments[0];
    $.messager.confirm('系统提示', '确定要删除此文件吗？', function (result) {
        if (result) {
            
            $.ajax({
                url: '/ashx/battchfilehandler.ashx?Method=DeleteBattchFile&' + jsNC(),
                data: { FileID: fileid },
                success: function (result) {
                    if (result.isOk == 1) {
                        showInfo('文件已经删除。');
                        battchfiles_form.controls.dgdetail.datagrid('reload');
                    }
                    else {
                        showError('文件删除失败。原因:' + result.message);
                    }
                }
            });
        }
    });
}

function downloadbattchfile() {
    var fileid = arguments[0];
    $.messager.confirm('系统提示', '确定要下载此文件吗？', function (flag) {
        if (flag) {           
            var form = $("<form>");   //定义一个form表单
            form.attr('style', 'display:none');   //在form表单中添加查询参数
            form.attr('target', '');
            form.attr('method', 'post');
            form.attr('action', "/ashx/battchfilehandler.ashx?Method=DownloadBattchFile");
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
$(function () {
    battchfiles_form.init();
});

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}
