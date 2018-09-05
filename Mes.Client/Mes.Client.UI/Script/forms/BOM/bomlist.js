'use strict';
document.msCapsLockWarningOff = true;
var bomForm = {
    init: function () {
        bomForm.initControls();
        bomForm.events.loadData();
        bomForm.controls.searchData.on('click', function () { bomForm.controls.dgdetail.datagrid('reload'); });
    },
    initControls: function () {
        bomForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgdetail: $('#dgdetail'),//填充数据
            search_form: $('#search_form')//查询表单
        }

    },
    events: {
        loadData: function () {
            bomForm.controls.dgdetail.datagrid({
                sortName: 'Created',
                idField: 'ID',
                url: '/ashx/ProductBOMHandler.ashx?Method=List&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    {
                        field: 'BOMID', title: 'BOMID', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (rowData['Status'] == 'False') {
                                return rowData['BOMID'];
                            } else {
                                return '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="bomForm.events.showdetail(\'' + rowData['BOMID'] + '\',\'' + rowData['BOMID'] + '\');"><span style="color:#0094ff;">' + rowData['BOMID'] + '</span></a>';
                            }
                        }
                    },
                    { field: 'ProductCode', title: '产品编号', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'ProductName', title: '产品名称', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Created', title: '创建日期', width: 80, sortable: false, halign: 'center', align: 'center' },
                    { field: 'CreatedBy', title: '创建人', width: 110, sortable: false, halign: 'center', align: 'center' },
                    {
                        field: 'StatusName', title: '状态', width: 80, sortable: false, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                            return rowData['Status'] == 'False' ? '待导入' : '<font style="color:#158144">已导入</font>';
                        }
                    },
                    {
                        field: 'TODO', title: '操作', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (rowData['Status'] == 'False') {
                                return '<a href="#" class="l-btn l-btn-small" icon="icon-redo" onclick="importBOM(\'' + rowData["BOMID"] + '\',\'' + rowData["ProductCode"] + '\')"><span class="l-btn-left l-btn-icon-left"><span class="l-btn-text">导入</span><span class="l-btn-icon icon-redo">&nbsp;</span></span></a>';
                            } else {
                                return '<a href="#" class="l-btn l-btn-small l-btn-disabled" icon="icon-redo"><span class="l-btn-left l-btn-icon-left"><span class="l-btn-text">导入</span><span class="l-btn-icon icon-redo">&nbsp;</span></span></a>';
                            }
                        }
                    }
                ]],
                toolbar: [
                  {
                      text: '下载BOM模版', iconCls: 'icon-ok', handler: bomForm.events.downLoadBOM
                  }
                ],
                onBeforeLoad: function (param) {
                    bomForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    bomForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                    param["pid"] = getUrlParam('pid');
                }
            });
        },
        downLoadBOM: function (_postData) {
            var form = $("<form>");   //定义一个form表单
            form.attr('style', 'display:none');   //在form表单中添加查询参数
            form.attr('target', '_blank');
            form.attr('method', 'post');
            form.attr('action', "/View/BOM/download.aspx");
            //if (_postData) {
            //    for (var prop in _postData) {
            //        var down = $('<input>');
            //        down.attr('type', 'hidden');
            //        down.attr('name', prop);
            //        down.attr('value', _postData[prop]);
            //        form.append(down);   //将查询参数控件提交到表单上
            //    }
            //}
            $('body').append(form);  //将表单放置在web中
            form.submit();
        },
        showdetail: function (id, no) {
            top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id);
        },
        initUploadWindow: function () {
            $("#hdnBOMID").val("");
            $("#hdnAttachmentFile").val("");
            $("#i_stream_files_queue").find("ul>li").remove();

            $(".stream-total-tips").empty();
            $(".stream-total-tips").append('	上传总进度：<span class="stream-process-bar"><span style="width: 0%;"></span></span>	<span class="stream-percent">0%</span>，已上传<strong class="_stream-total-uploaded">&nbsp;</strong>	，总文件大小<strong class="_stream-total-size">&nbsp;</strong>');
        }
    }
};

$(function () {
    bomForm.init();

    $('#btn_search_ok').linkbutton();

    $('#CreatedTo').datebox({
        onSelect: function (date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();
            var CreatedTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
            var CreatedFrom = $("#CreatedFrom").datebox("getValue");
            if (CreatedFrom == "") {
                showInfo("请选择开始日期！");
                //alert("请选择开始日期！");
                $('#CreatedTo').datebox("setValue", '');
            }
            if (CreatedFrom > CreatedTo) {
                showInfo("结束日期不能小于开始日期！");
                $('#CreatedTo').datebox("setValue", '');
            }
        }
    });

    $("#btn_save").click(function () {
        var bomID = $("#hdnBOMID").val(),
            productCode = $("#hdnProductCode").val(),
            attachmentFile = $("#hdnAttachmentFile").val();
        if (attachmentFile === undefined || attachmentFile === '') {
            showError('请先上传要导入的BOM文件');
            return false;
        }
        if (bomID === undefined || bomID === '') {
            showError("BOMID不能为空");
            return false;
        }
        var postData = {
            BOMID: bomID,
            ProductCode: productCode,
            FilePath: attachmentFile
        };
        $.invokeApi("/Ashx/ProductBOMHandler.ashx?Method=ImportBOM", postData, false, 'POST', function (result) {
            if (result) {
                if (result['Code'] == 1) {
                    showInfo(result['Msg']);
                    $('#Upload_window').window('close'); //关闭上传窗口
                    bomForm.events.initUploadWindow();
                    bomForm.controls.dgdetail.datagrid('reload');
                } else {
                    showError(result['Msg']);
                }
            }
        });
    });

    $("#btn_cancel").click(function () {
        _t.cancel();
    });

    var config = {
        browseFileId: "i_select_files",
        browseFileBtn: "<div>请选择文件</div>",
        dragAndDropArea: "i_select_files",
        dragAndDropTips: "<span>把文件拖拽(点击)到这里</span>",
        filesQueueId: "i_stream_files_queue",
        filesQueueHeight: 200,
        messagerId: "i_stream_message_container",
        multipleFiles: false, /** 多个文件一起上传, 默认: false */
        autoUploading: true, /** 选择文件后是否自动上传, 默认: true */
        autoRemoveCompleted: false, /** 是否自动删除容器中已上传完毕的文件, 默认: false */
        maxSize: 104857600,//, /** 单个文件的最大大小，默认:2G */
        tokenURL: "/ashx/StreamUploadHandler.ashx?Method=tk",
        uploadURL: "/ashx/StreamUploadHandler.ashx?Method=upload",
        simLimit: 1, /** 单次最大上传文件个数 */
        extFilters: [".xls", ".xlsx"],
        onSelect: function (list) {
            console.log(JSON.stringify(list));
        },
        onMaxSizeExceed: function (size, limited, name) { showError('文件大小超出限制！'); },
        onFileCountExceed: function (selected, limit) { showError('文件数量超出(' + limit + '个)限制！'); },
        onCancel: function (file) { console.log('Canceled:  ' + file.name) }, /** 取消上传文件的响应事件 */        onComplete: function (file) {
            //console.log(JSON.stringify(file));
            var obj = JSON.parse(file.msg);
            if (obj.success) {
                $("#hdnAttachmentFile").val(decodeURIComponent(obj.filePath));
                //$('#Upload_window').window('close');
            }
        },
        onQueueComplete: function () {
            //showError('onQueueComplete')
            //单个文件上传完毕的响应事件
        },
        onUploadError: function (status, msg) {
            showError('onUploadError' + status + ":" + msg);
        }
    };

    var _t = new Stream(config);
});

function importBOM(bomID, productCode) {
    $('#Upload_window').find("#hdnBOMID").val(bomID);
    $('#Upload_window').find('#hdnProductCode').val(productCode);
    $('#Upload_window').window('open');
}