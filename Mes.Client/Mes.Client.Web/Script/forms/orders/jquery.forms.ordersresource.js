
(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var t = null;
    var min = 0; //分
    var sec = 0; //秒
    var hour = 0; //小时

    var ordersResourceForm = {
        init: function () {
            ordersResourceForm.initControls();
            ordersResourceForm.controls.searchData.on('click', function () { ordersResourceForm.controls.dgdetail.datagrid('reload'); });//加载数据
            ordersResourceForm.controls.fileupload.on('click', ordersResourceForm.events.submitfile);//  
            ordersResourceForm.controls.returnorder.on('click', ordersResourceForm.events.returnorder);//退回订单
            ordersResourceForm.controls.sumbitorder.on('click', ordersResourceForm.events.sumbitorder);//提交完成
            ordersResourceForm.controls.upload_window_cancel.on('click', ordersResourceForm.events.uploadcancel);
            ordersResourceForm.controls.upload_form.find('#IsHandmade').change(function () {
                if($(this).is(':checked'))
                    $(this).val('True');
                else
                    $(this).val('False');
            });
            ordersResourceForm.events.loadCabinet();
            ordersResourceForm.events.loadData();
        },
        initControls: function () {
            ordersResourceForm.controls = {
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                dgcabinet: $('#dgcabinet'),
                search_form: $('#search_form'),//查询表单
                edit_window: $('#edit_window'),
                edit_form: $('#edit_form'),
                fileupload: $('#btn_fileupload'),
                upload_form: $('#upload_form'),
                upload_window: $('#upload_window'),
                upload_window_cancel: $('#btn_cancel'),
                loading: $('#submit_window'),
                steps_window: $('#steps_window'),
                returnorder: $('#btn_edit_return'),//退回订单
                sumbitorder: $('#btn_edit_finish')//提交完成
            }
            $('#btn_search_ok').linkbutton()
        },
        events: {
            loadData: function () {
                ordersResourceForm.controls.dgdetail.datagrid({
                    sortName: 'Created',
                    idField: 'OrderID',
                    url: '/ashx/ordershandler.ashx?Method=SearchOrders&Review=true&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    loadMsg: '正在加载数据，请稍候....',
                    columns: [[
                            {
                                field: 'OrderNo', title: '订单编号', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="上传文件" onClick="uploadfile(\'' + rowData['OrderID'] + '\',\'' + rowData['OrderNo'] + '\');"><span style="color:#0094ff;">' + rowData['OrderNo'] + '</span></a>';
                                    return strReturn;
                                }
                            },
                             { field: 'PurchaseNo', title: '采购单号', width: 105, sortable: false, align: 'center' },
                             { field: 'CabinetType', title: '产品类型', width: 60, sortable: false, align: 'center' },
                            { field: 'OrderType', title: '订单类型', width: 60, sortable: false, align: 'center' },
                            { field: 'CustomerName', title: '客户名称', width: 85, sortable: false, align: 'center', halign: 'center' },
                            //{ field: 'Address', title: '客户地址', width: 220, sortable: false, align: 'center', halign: 'center' },
                            { field: 'LinkMan', title: '联系人', width: 70, sortable: false, align: 'center' },
                            { field: 'Mobile', title: '联系电话', width: 95, sortable: false, align: 'center' },
                            {
                                field: 'BookingDate', title: '订货日期', width: 85, hidden: false, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    if (value == undefined) return "";
                                    return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                                }
                            },
                            {
                                field: 'ShipDate', title: '交货日期', width: 85, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    if (value == undefined) return "";
                                    return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd");
                                }
                            },
                            //{
                            //    field: 'Created', title: '创建时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            //        if (value == undefined) return "";
                            //        return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm");
                            //    }
                            //},
                            {
                                field: 'IsStandard', title: '是否正标', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                    if (value == undefined) return "";
                                    if (value == "True")
                                        return "是";
                                    else
                                        return "否";

                                }
                            },
                           //{
                           //    field: 'IsOutsourcing', title: '是否外购', width: 60, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                           //        if (value == undefined) return "";
                           //        if (value == "True")
                           //            return "是";
                           //        else
                           //            return "否";
                           //    }
                           //},

                           {
                               field: 'Status', title: '订单状态', width: 60, align: 'center', formatter: function (value, rowData, rowIndex) {
                                   var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="审核明细" onClick="loadstep(\'' + rowData['OrderID'] + '\');"><span style="color:#0094ff;">' + GetOrderStatusName(rowData['Status']) + '</span></a>';
                                   return strReturn;
                               }
                           }
                    ]],
                    onBeforeLoad: function (param) {
                        ordersResourceForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        ordersResourceForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                });
            },

            loadCabinet: function () {
                ordersResourceForm.controls.dgcabinet.datagrid({
                    sortName: 'Sequence',
                    idField: 'OrderID',
                    url: '/ashx/ordershandler.ashx?Method=GetCabinets&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: false,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    singleSelect: true,
                    async: true,
                    columns: [[
                    { field: 'OrderID', title: '订单ID', width: 20, hidden: true, sortable: false, align: 'left', halign: 'center' },
                    { field: 'CabinetName', title: '产品名称', width: 200, sortable: false, align: 'center', halign: 'center' },
                    { field: 'Size', title: '成品尺寸', width: 200, sortable: false, align: 'center' },
                    { field: 'Color', title: '材质颜色', width: 110, sortable: false, align: 'center' },
                    { field: 'MaterialStyle', title: '材质风格', width: 110, sortable: false, align: 'center' },
                    { field: 'MaterialCategory', title: '材质类型', width: 110, sortable: false, align: 'center' },
                    { field: 'Unit', title: '单位', width: 50, sortable: false, align: 'center' },
                    { field: 'Qty', title: '数量', width: 50, sortable: false, align: 'center' },
                    {
                        field: 'FileUploadFlag', title: '上传状态', width: 80, sortable: false, align: 'center', formatter: function (value, row, index) {
                            if (value) {
                                return "<span style='color:red;'>√</span>";
                            }
                            else
                                return "";
                        }
                    },
                    {
                        field: 'op', title: '操作', width: 120, sortable: false, align: 'center', formatter: function (value, row, index) {
                            if (!row.FileUploadFlag) {
                                return '<a href="#" onclick="openUploadFileWindow(\'' + row.OrderID + '\',\'' + row.CabinetID + '\')"><span class="bullet_go">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;上传文件</a>';
                            }
                            else
                                return '<a href="#" onclick="reloadUploadFileWindow(\'' + row.OrderID + '\',\'' + row.CabinetID + '\')"><span class="bullet_go">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;重新上传</a>';
                        }
                    }
                    ]],
                    onBeforeLoad: function (param) {
                        param["OrderID"] = ordersResourceForm.controls.edit_form.find('#OrderID').val();
                    }
                });
            },

            submitfile: function () {
                t = null;
                hour = 0;
                min = 0;
                sec = 0;
                $('.runtime').html('');               

                ordersResourceForm.controls.upload_form.form('submit', {
                    url: '/ashx/ordershandler.ashx?Method=FileUpload&ReloadUploadFile=True&' + jsNC(),
                    data: ordersResourceForm.controls.upload_form.serialize(),
                    datatype: "json",
                    loadMsg: "正在提交数据，请稍候...",
                    onSubmit: function () {
                        var isValid = ordersResourceForm.controls.upload_form.form('validate');
                        if (!isValid) {
                            return isValid;
                        }
                        else {
                            setInterval(function () { t = ordersResourceForm.events.timedCount(); }, 1000);
                            ordersResourceForm.controls.loading.window('open');
                            $('<div id="unloadMask"></div>').appendTo('body').height($("body").height());
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
                            if (result) {
                                if (result.isOk == 0) {
                                    showError(result.message);
                                    ordersResourceForm.events.stopCount();
                                    ordersResourceForm.controls.loading.window('close');
                                } else {
                                    ordersResourceForm.controls.upload_window.window('close'); //关闭上传文件窗口                                   
                                    ordersResourceForm.controls.dgcabinet.datagrid('reload');
                                    ordersResourceForm.events.stopCount();
                                    ordersResourceForm.controls.loading.window('close');//进度条窗口
                                }
                            }
                        }
                        catch (e) {
                            showError(e.message);
                            ordersResourceForm.events.stopCount();
                            ordersResourceForm.controls.loading.window('close');
                        }
                    }
                });
            },

            //上传文件取消
            uploadcancel: function () {
                ordersResourceForm.controls.upload_window.window('close');
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

            //退回订单
            returnorder: function () {
                var orderid = $('#OrderID').val();
                $.messager.confirm('系统提示', '您确定要退回该订单吗?', function (flag) {
                    if (flag) {
                        $.ajax({
                            url: '/ashx/ordershandler.ashx?Method=ReturnSplitOrder',
                            data: { OrderID: orderid },
                            success: function (returnData) {
                                if (returnData) {
                                    if (returnData.isOk == 0) {
                                        showError(returnData.message);
                                    }
                                    else {
                                        $('#edit_window').window('close');
                                        ordersResourceForm.controls.dgdetail.datagrid('reload');
                                    }
                                }
                            }
                        });
                    }
                });
            },

            //提交完成
            sumbitorder: function () {
                var orderid = $('#OrderID').val();
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=UploadFinish&' + jsNC(),
                    data: { OrderID: orderid },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 0) {
                                showError("请上传完成文件再提交");
                            }
                            else {
                                $('#edit_window').window('close');
                                ordersResourceForm.controls.dgdetail.datagrid('reload');
                            }
                        }
                    }
                });
            }
        }
    };
    $(function () {
        ordersResourceForm.init();
    });

})(jQuery);

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}

function uploadfile(orderid, no) {
    $('#edit_form').form('clear');
    //初始化数据
    $.ajax({
        url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
        data: { OrderID: orderid },
        datatype: "json",
        async: false,
        success: function (data) {
            $('#edit_form').form('load', data);
            $("#Statu").val(GetOrderStatusName(data.Status));//转换订单状态中文名称
            $('#edit_form').find('input').each(function (index) {
                $(this).addClass('easyui-readonly');
                $('#BookingDate').val(new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                $('#ShipDate').val(new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));
                if (('P,F,I,O').indexOf(data.Status) < 0) {
                    if (data.IsStandard == true) {
                        $('#IsStandard').val("是")
                    } else {
                        $('#IsStandard').val("否")
                    }
                    if (data.IsOutsourcing == true) {
                        $('#IsOutsourcing').val("是")
                    } else {
                        $('#IsOutsourcing').val("否")
                    }
                    $('#ManufactureDate').val("未开始");
                }
                else {
                    $('#ManufactureDate').val(new Date(removeCN(data.ManufactureDate)).Formats('yyyy-MM-dd'));
                }
            });
        }
    });
    $('#dgcabinet').datagrid('reload');
    $('#edit_window').window('open');
}


function openUploadFileWindow(orderid, cabinetid) {
    $('#upload_form').form('clear');
    $.ajax({
        url: '/ashx/ordershandler.ashx?Method=GetCabinet',
        data: { CabinetID: cabinetid },
        datatype: "json",
        success: function (data) {
            if (data.FileUploadFlag.toLowerCase() == "true") {
                showInfo('【' + data.CabinetName + '】拆单文件已经上传。');
                $('#dgcabinet').datagrid('reload');
            }
            else {
                $('#upload_form').find('#OrderID').val(orderid);
                $('#upload_form').find('#CabinetID').val(cabinetid);
                $('#upload_window').window('open');
            }
        }
    });
}

//重新上传文件
function reloadUploadFileWindow(orderid, cabinetid) {
    $('#upload_form').form('clear');
    $.ajax({
        url: '/ashx/ordershandler.ashx?Method=GetCabinet',
        data: {
            CabinetID: cabinetid
        },
        datatype: "json",
        success: function (data) {
            $('#upload_form').find('#OrderID').val(orderid);
            $('#upload_form').find('#CabinetID').val(cabinetid);
            $('#upload_window').window('open');
        }
    });
}

//加载审核明细
function loadstep(orderid) {
    $('#steps_window').window('open');
    $('#dgsteps').datagrid({
        sortName: 'StepNo',
        idField: 'OrderID',
        url: '/ashx/ordershandler.ashx?Method=GetStepsByOrder&OrderID=' + orderid,
        collapsible: false,
        fitColumns: true,
        pagination: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        loadMsg: '正在加载数据，请稍候....',
        columns: [[
        { field: 'Action', title: '发起步骤', width: 120, sortable: false, align: 'center' },
        { field: 'TargetStep', title: '目标步骤', width: 150, sortable: false, halign: 'center', align: 'center' },
        { field: 'StartedBy', title: '提交人', width: 150, sortable: false, halign: 'center', align: 'center' },
        {
            field: 'Started', title: '提交时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                if (value == undefined)
                    return "";
                var date = new Date(+new Date(value) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                return date;
            }
        },
        { field: 'EndedBy', title: '处理人', width: 120, sortable: false, align: 'center' },
        {
            field: 'Ended', title: '处理时间', width: 150, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                if (value == undefined)
                    return "";
                var date = new Date(+new Date(value) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                return date;
            }
        },
        { field: 'Remark', title: '审核意见', width: 120, sortable: false, align: 'center' }
        ]],
        onBeforeLoad: function (param) {

        }
    });
    for (var i = 0; i < 20; i++) {
        $('#dgsteps').datagrid('reload');
    }
}