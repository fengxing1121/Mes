/*!
@Name：订单详情  
@Author：
@Remark：新增
@Date：2018-07-05
@License：MES  
*/
'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var ProductID = "";
var ordersdetailForm = {
    init: function () {
        ordersdetailForm.initControls();
        ordersdetailForm.events.loadTabs();

        //订单初审
        ordersdetailForm.controls.btn_confirm_open.on('click', ordersdetailForm.events.confirmorder_open);
        ordersdetailForm.controls.btn_confirm_ok.on('click', ordersdetailForm.events.confirmorder_submit);
        ordersdetailForm.controls.btn_confirm_reject.on('click', ordersdetailForm.events.confirmorder_reject);

        //财务审核
        ordersdetailForm.controls.btn_review_open.on('click', ordersdetailForm.events.revieworder_open);
        ordersdetailForm.controls.btn_review_ok.on('click', ordersdetailForm.events.revieworder_submit);
        ordersdetailForm.controls.btn_review_reject.on('click', ordersdetailForm.events.revieworder_reject);
    },
    initControls: function () {
        ordersdetailForm.controls = {
            dgorder: $('#dgorder'),
            dgdetail: $('#dgdetail'),
            search_form: $('#search_form'),
            dgHardware: $('#dgHardware'),
            dgDrawing: $('#dgDrawing'),
            dgProcessFile: $('#dgProcessFile'),
            dgDoors: $('#dgdoors'),
            test_door: $('#test_door'),
            btn_refresh: $('#btn_refresh'),
            skpFile: $('#skpFile'),

            //订单初审
            confirm_window: $('#confirm_window'),
            confirm_form: $('#confirm_form'),
            btn_confirm_ok: $('#btn_confirm_ok'),
            btn_confirm_reject: $('#btn_confirm_reject'),
            btn_confirm_open: $('#btn_confirm_open'),

            //财务审核
            review_window: $('#review_window'),
            review_form: $('#review_form'),
            btn_review_ok: $('#btn_review_ok'),
            btn_review_reject: $('#btn_review_reject'),
            btn_review_open: $('#btn_review_open'),
        }

        $('#div_content').delegate('li', 'click', function () {
            var ProductName = $(this).text();
            $(this).parent().find('.active').removeClass("active");
            $(this).addClass("active");
            if (ProductName == "全部") ProductName = '';
            $('#CabinetNum').val(ProductName);
            ordersdetailForm.events.reload();
        });
    },
    events: {
        loadTabs: function () {
 
            var orderid = getUrlParam('orderid');
            if (orderid.length == 0) return;
            $('#OrderID').val(orderid);
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                data: { OrderID: orderid },
                datatype: "json",
                success: function (data) {
                    ordersdetailForm.controls.search_form.form('load', data);

                    $("#BookingDate").val(new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                    $("#ShipDate").val(new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));

                    if (!IsNullOrEmpty(data.AttachmentFile)) {
                        $("#downfile").attr("href", data.AttachmentFile).show();
                    }

                    var source = getUrlParam('source');
                    if (!IsNullOrEmpty(source)) {
                        switch (source) {
                            case "confirm":
                                if (data.StepNo != (GetOrderStepNo(ordersconfirm)-1)) {
                                    window.location.href = "/view/403.html";
                                    return;
                                }
                                ordersdetailForm.controls.btn_confirm_open.show();
                                break; 
                            case "review":
                                if (data.StepNo != (GetOrderStepNo(ordersreview) - 1)) {
                                    window.location.href = "/view/403.html";
                                    return;
                                }
                                ordersdetailForm.controls.btn_review_open.show();
                                break;
                        }
                    }
                }
            });

            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=GetOrderProducts&' + jsNC(),
                data: { OrderID: orderid },
                datatype: "json",
                success: function (data) {
                    if (data) {
                        $('#cabinets').append("<li class='item active'>全部</li>");
                        $.each(data.rows, function (index, row) {
                            $('#cabinets').append("<li class='item'>" + row.ProductName + "</li>");
                        });
                    }
                }
            });
                
            ordersdetailForm.controls.dgorder.datagrid({
                sortName: 'Sequence',
                idField: 'ProductID',
                url: '/ashx/ordershandler.ashx?Method=GetOrderProducts',
                collapsible: false,
                fitColumns: true,
                pagination: false,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    { field: 'ProductCode', title: '产品ID', width: 150, sortable: false, align: 'center' },
                    { field: 'ProductName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                    { field: 'ProductGroup', title: '产品编号', width: 150, sortable: false, align: 'center' },
                    { field: 'Size', title: '产品规格', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Color', title: '颜色', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'MaterialStyle', title: '风格', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'MaterialCategory', title: '材质', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Unit', title: '单位', width: 60, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Qty', title: '数量', width: 50, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Price', title: '单价', width: 80, sortable: false, halign: 'center', align: 'center' },
                    { field: 'SalePrice', title: '报价', width: 80, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Remark', title: '备注', width: 150, sortable: false, halign: 'center', align: 'center' }
                ]],
                onBeforeLoad: function (param) {
                    param['OrderID'] = orderid;
                    param['ProductName'] = $('#CabinetNum').val();
                }
            });

            //ordersdetailForm.controls.dgdetail.datagrid({
            //    idField: 'ItemID',
            //    url: '/ashx/ordershandler.ashx?Method=SearchOrderDetail&' + jsNC(),
            //    collapsible: false,
            //    fitColumns: true,
            //    pagination: true,
            //    striped: false,
            //    pageSize: 20,
            //    columns: [[
            //    { field: 'ProductName', title: '产品名称', width: 180, align: 'center' },
            //    { field: 'BarcodeNo', title: '板件条码', width: 180, align: 'center' },
            //    { field: 'ItemName', title: '部件名称', width: 120, align: 'center' },                    
            //    { field: 'MaterialType', title: '材质颜色', width: 100, sortable: false, align: 'center' },
            //    {
            //        field: 'MadeWidth', title: '开料宽度', width: 80, sortable: false, align: 'center',
            //        formatter: function (value, rowData, rowIndex) {
            //            if (value == undefined) return "";
            //            return value.toString().replace('.00', '');
            //        }
            //    },
            //    {
            //        field: 'MadeLength', title: '开料长度', width: 80, sortable: false, align: 'center',
            //        formatter: function (value, rowData, rowIndex) {
            //                if (value == undefined) return "";
            //                return value.toString().replace('.00', '');
            //        }
            //    },
            //    {
            //        field: 'EndWidth', title: '成品宽度', width: 80, sortable: false, align: 'center',
            //        formatter: function (value, rowData, rowIndex) {
            //                if (value == undefined) return "";
            //                return value.toString().replace('.00', '');
            //        }
            //    },
            //        {
            //            field: 'EndLength', title: '成品长度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
            //                if (value == undefined) return "";
            //                return value.toString().replace('.00', '');
            //            }
            //        },
            //        {
            //            field: 'MadeHeight', title: '厚度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
            //                if (value == undefined) return "";
            //                return value.toString().replace('.00', '');
            //            }
            //        },
            //        {
            //            field: 'Qty', title: '数量', width: 50, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
            //                if (value == undefined) return "";
            //                return value.toString().replace('.00', '');
            //            }
            //        },
            //        { field: 'Remarks', title: '备注', width: 150, sortable: false, align: 'center' }
            //    ]],
            //    toolbar: [
            //        //{ text: '下载料单', iconCls: 'icon-add', handler: ordersdetailForm.events.downfile },
            //        { text: '外购清单', iconCls: 'icon-add', handler: ordersdetailForm.events.PurchaseMaterials },
            //        { text: '二次加工清单', iconCls: 'icon-add', handler: ordersdetailForm.events.FactoryMaterials },
            //        { text: '部件清单(薄板)', iconCls: 'icon-add', handler: ordersdetailForm.events.rptOrderDetails_9mm },
            //        { text: '部件清单(厚板)', iconCls: 'icon-add', handler: ordersdetailForm.events.rptOrderDetails }
            //    ],
            //    onBeforeLoad: function (param) {
            //        param['OrderID'] = $('#OrderID').val();// orderid;
            //        param['CabinetNum'] = $('#CabinetNum').val();
            //    }
            //});

            //ordersdetailForm.controls.dgHardware.datagrid({
            //    idField: 'OrderID',
            //    url: '/ashx/ordershandler.ashx?Method=SearchOrder2Hardwares&' + jsNC(),
            //    collapsible: false,
            //    fitColumns: true,
            //    pagination: true,
            //    striped: false,
            //    pageSize: 20,
            //    columns: [[
            //        { field: 'ProductName', title: '产品名称', width: 150, sortable: false, align: 'center' },
            //        { field: 'HardwareCategory', title: '分类', width: 120, sortable: false, align: 'center' },
            //        { field: 'HardwareCode', title: '物料编码', width: 120, sortable: false, align: 'center' },
            //        { field: 'HardwareName', title: '名称', width: 150, sortable: false, align: 'center' },
            //        { field: 'Style', title: '规格/型号', width: 150, sortable: false, align: 'center' },
            //        { field: 'Qty', title: '数量', width: 150, sortable: false, align: 'center' },
            //        { field: 'Unit', title: '单位', width: 200, sortable: false, align: 'center' }
            //    ]],
            //    toolbar: [
            //            { text: '五金料单', iconCls: 'icon-add', handler: ordersdetailForm.events.hardwareReport }
            //    ],
            //    onBeforeLoad: function (param) {
            //        param['OrderID'] = orderid;
            //        param['ProductName'] = $('#CabinetNum').val();
            //    }
            //});

            //ordersdetailForm.controls.dgDrawing.datagrid({
            //    idField: "FileID",
            //    url: '/ashx/ordershandler.ashx?Method=SearchOrderProcessFiles&FileType=DrawingFile&' + jsNC(),
            //    collapsible: false,
            //    fitColumns: true,
            //    pagination: true,
            //    striped: false,
            //    pageSize: 20,
            //    columns: [[
            //        { field: 'ProductName', title: '产品名称', width: 150, sortable: false, align: 'center' },
            //        { field: 'FileType', title: '文件类型', hidden: true, width: 150, sortable: false, align: 'center' },
            //        { field: 'FileName', title: '文件名称', width: 150, sortable: false, align: 'center' },
            //        { field: 'Created', title: '上传时间', width: 150, sortable: false, align: 'center' },
            //        {
            //            field: 'op', title: '操作', width: 90, sortable: false, align: 'center',
            //            formatter: function (value, rowData, rowIndex) {
            //                var str = '<img style="cursor:pointer;" onclick="downloadfile(\'' + rowData.FileID + '\')" src="/Content/images/exticons/page/page_white_put.png" alt="下载文件"/>&nbsp;&nbsp;';
            //                return str;
            //            }
            //        }
            //    ]],
            //    onBeforeLoad: function (param) {
            //        param['OrderID'] = orderid;
            //        param['ProductName'] = $('#CabinetNum').val();
            //    }
            //});

            //ordersdetailForm.controls.dgProcessFile.datagrid({
            //    idField: "FileID",
            //    url: '/ashx/ordershandler.ashx?Method=SearchOrderProcessFiles&FileType=CSV,XML,CNC',
            //    collapsible: false,
            //    fitColumns: true,
            //    pagination: true,
            //    striped: false,
            //    pageSize: 20,
            //    columns: [[
            //        { field: 'ProductName', title: '产品名称', width: 150, sortable: false, align: 'center' },
            //        { field: 'FileType', title: '文件类型', hidden: true, width: 150, sortable: false, align: 'center' },
            //        { field: 'FileName', title: '文件名称', width: 150, sortable: false, align: 'center' },
            //        { field: 'Created', title: '上传时间', width: 150, sortable: false, align: 'center' }
            //    ]],
            //    toolbar: [
            //        { text: '下载', iconCls: 'icon-add', handler: ordersdetailForm.events.downLoadProcessfile},
            //    ],
            //    onBeforeLoad: function (param) {
            //        param['OrderID'] = orderid;
            //        param['ProductName'] = $('#CabinetNum').val();
            //    }
            //});

            //$.ajax({
            //    url: '/ashx/ordershandler.ashx?Method=SearchOrderProcessFiles&' + jsNC(),
            //    collapsible: false,
            //    fitColumns: false,
            //    striped: false,   //设置为true将交替显示行背景。 
            //    data: { FileType: 'RenderingFile', OrderID: orderid },
            //    datatype: "json",
            //    success: function (data) {
            //        if (data.isOk == 0) {
            //            return;
            //        }
            //        $('#list').html('');
            //        $.each(data.rows, function (index, row) {
            //            $('#list').append("<li style='width:480px;height:320px; float:left; border:1px solid #eee;padding:5px;text-align:center;'><div style='width:480px;height:320px;'><img src='/ashx/download_file.ashx?fid=" + row.FileID + "' style='max-width:480px;width:480px auto;max-height:320px;height:320px auto;' alt=''/><br/><span>" + row.FileName + "</span></div></li>");
            //        });
            //    }
            //});
        },
        loadNewGuid: function () {
            var guid = " ";
            for (var i = 1; i <= 32; i++) {
                var n = Math.floor(Math.random() * 16.0).toString(16);
                guid += n;
                if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                    guid += "-";
            }
            return guid;
        },
       
        reload: function () {
            //ordersdetailForm.controls.dgdetail.datagrid('reload');
            //ordersdetailForm.controls.dgHardware.datagrid('reload');
            //ordersdetailForm.controls.dgDrawing.datagrid('reload');
            //ordersdetailForm.controls.dgProcessFile.datagrid('reload');
        },
        

        //订单初审
        confirmorder_open: function () {
            ordersdetailForm.controls.confirm_window.window('open');
            $('#Remark').val(''); 
        },
        confirmorder_submit: function () {
            ordersdetailForm.events.ConfirmOrder(true);
        },
        confirmorder_reject: function () {
            ordersdetailForm.events.ConfirmOrder(false);
        },
        ConfirmOrder: function (ConfirmState) {
            if (ordersdetailForm.controls.confirm_form.form('validate')) {
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=OrdersConfirm',
                    data: { OrderID: $("#OrderID").val(), Remark: $('#option_remark').val(), ConfirmState: ConfirmState },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 0) {
                                showError(returnData.message);
                            }
                            else {
                                $.messager.alert("提示", "审核成功", "info", function () {
                                    parent.closeTabs();
                                });
                            }
                        }
                    }
                });
            }
        },

        //财务审核
        revieworder_open: function () {
            ordersdetailForm.controls.review_window.window('open');
        },
        revieworder_submit: function () {
            ordersdetailForm.events.revieworder(true);
        },
        revieworder_reject: function () {
            ordersdetailForm.events.revieworder(false);
        },
        revieworder: function (ConfirmState) {
            if (ordersdetailForm.controls.review_form.form('validate')) {
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=OrderReview',
                    data: {
                        OrderID: $("#OrderID").val(),
                        Payee: $("#Payee").val(),
                        Amount: $("#Amount").val(),
                        TransDate:$("#TransDate").datebox("getValue"),
                        VoucherNo: $("#VoucherNo").val(),
                        Remark: $("#option_Remark").val(),
                        ConfirmState: ConfirmState
                    },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 0) {
                                showError(returnData.message);
                            }
                            else {
                                $.messager.alert("提示", "审核成功", "info", function () {
                                    parent.closeTabs();
                                });
                            }
                        }
                    }
                });
            }
        },
    }
};
$(function () {
    ordersdetailForm.init();
});


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



