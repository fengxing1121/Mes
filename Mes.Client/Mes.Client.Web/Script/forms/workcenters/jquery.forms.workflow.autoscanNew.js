/*!
 @Name：工位扫描  优化版 
 @Author：刘胜伟
 @Remark：支持按产品备料勾选，支持进度跟踪实时展示
 @Date：2018-05-14
 @License：MES  
 */

'use strict';
document.msCapsLockWarningOff = true;
var scanForm = {
    init: function () {
        scanForm.initControls();
        scanForm.controls.btnPrint.on('click', function () { scanForm.events.btnfinish(); });
    },
    initControls: function () {
        scanForm.controls = {
            unscan_view: $('#dgUnScan'),
            scan_view: $('#dgScan'),
            barcode: $('#Barcode'),
            edit_form: $('#edit_form'),
            btnPrint: $('#btnPrint'),
            loading: $('#submit_window'),
            scanresult: $('.msg_scanresult'),
        }
    },
    events: {
        //待扫描产品
        load_unscan_view: function (OrderID) {
            scanForm.controls.unscan_view.datagrid({
                url: '/ashx/ordershandler.ashx?Method=SearchScanListByOrderWorkFlow&' + jsNC(),
                idField: 'WorkingID',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                singleSelect: true,
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    { field: 'cp', checkbox: true },
                    //{ field: 'OrderNo', title: '订单号', width: 110, align: 'center' },
                   // { field: 'OutOrderNo', title: '外部单号', width: 110, align: 'center' },
                    { field: 'ItemGroup', title: '板件组', width: 60, align: 'center' },
                    { field: 'ItemName', title: '板件名称', width: 120, align: 'center' },
                    //{ field: 'Size', title: '规格(mm)', width: 100, align: 'center' },
                    { field: 'MaterialType', title: '材质', width: 100, align: 'center' },
                    { field: 'SourceWorkFlowName', title: '工序', width: 60, align: 'center' },
                    { field: 'BarcodeNo', title: '板件(二维)码', width: 120, align: 'left' },
                    { field: 'MadeWidth', title: '宽', width: 50, align: 'center' },
                    { field: 'MadeHeight', title: '高', width: 50, align: 'center' },
                    { field: 'MadeLength', title: '面积', width: 50, align: 'center' },
                ]],
                onBeforeLoad: function (param) {
                    param['OrderID'] = OrderID;
                    param['MadeQty'] = "0";
                },
                onClickRow: function (index, row) {
                    $('#Barcode').val(row.Barcode);
                },
                onSelect: function (index, row) {
                    $('#Barcode').val(row.Barcode);
                },
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        var body = $(this).data().datagrid.dc.body2;
                        body.find('table tbody').append('<tr><td colspan="10" style="height: 35px;border-left: #ccc dotted 1px; text-align: center;"><h1>当前订单暂无待扫描产品</h1></td></tr>');
                    }
                }
            });
        },
        //已扫描产品
        load_scan_view: function (OrderID) {
            scanForm.controls.scan_view.datagrid({
                url: '/ashx/ordershandler.ashx?Method=SearchScanListByOrderWorkFlow&' + jsNC(),
                idField: 'WorkingID',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                singleSelect: true,
                pageSize: 20,
                height: 100,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    { field: 'cp', checkbox: true },
                    //{ field: 'OrderNo', title: '订单号', width: 110, align: 'center' },
                   // { field: 'OutOrderNo', title: '外部单号', width: 110, align: 'center' },
                    { field: 'ItemGroup', title: '板件组', width: 100, align: 'center' },
                    { field: 'ItemName', title: '名称', width: 120, align: 'center' },
                    //{ field: 'Size', title: '规格(mm)', width: 100, align: 'center' },
                    { field: 'MaterialType', title: '材质', width: 100, align: 'center' },
                    { field: 'Processed', title: '扫描时间', width: 150, align: 'center' },
                    { field: 'SourceWorkFlowName', title: '工序', width: 60, align: 'center' },
                    { field: 'BarcodeNo', title: '板件(二维)码', width: 120, align: 'left' },
                    { field: 'MadeWidth', title: '宽', width: 50, align: 'center' },
                    { field: 'MadeHeight', title: '高', width: 50, align: 'center' },
                    { field: 'MadeLength', title: '面积', width: 50, align: 'center' },
                ]],
                onBeforeLoad: function (param) {
                    param['OrderID'] = OrderID;
                    param['MadeQty'] = "1";
                },
                onClickRow: function (index, row) {
                    console.log(JSON.stringify(row));
                    $('#Barcode').val(row.Barcode);
                },
                onSelect: function (index, row) {
                    $('#Barcode').val(row.Barcode);
                },
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        var body = $(this).data().datagrid.dc.body2;
                        body.find('table tbody').append('<tr><td colspan="10" style="height: 35px;border-left: #ccc dotted 1px; text-align: center;"><h1>当前订单暂无已扫描产品</h1></td></tr>');
                    }
                }
            });
        },
        //订单数据
        loadGrid: function (OrderID) {
            if (IsNullOrEmpty(OrderID)) return;
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                data: { OrderID: OrderID },
                datatype: "json",
                success: function (data) {
                    //console.log(JSON.stringify(data));
                    scanForm.controls.edit_form.form('load', data);//id一定要在edit_form
                    scanForm.controls.edit_form.find('#Status').val(GetOrderStatusName(data.Status));
                    scanForm.controls.edit_form.find('#IsStandard').val(data.IsStandard == "True" ? "是" : "否");
                }
            });
        },
        //刷新表格
        loadTable: function () {
            scanForm.events.scanfocus();
            scanForm.controls.unscan_view.datagrid('clearSelections');//清除之前选项
            scanForm.controls.scan_view.datagrid('clearSelections');
            scanForm.controls.unscan_view.datagrid('reload');
            scanForm.controls.scan_view.datagrid('reload');
        },
        scanfocus: function () {
            $('.textbox-prompt').focus();
        },
        AutoScan: function (IsScan) {

            var url_ = '/ashx/ordershandler.ashx?Method=AutoScanByBarcode&' + jsNC();//默认扫描
            if (!IsScan) {
                url_ = '/ashx/ordershandler.ashx?Method=ReworkScanByBarcode&' + jsNC();//返工
            }

            $.ajax({
                type: "post",
                dataType: "json",
                data: { Barcode: $('#Barcode').val() },
                url: url_,
                success: function (result) {

                    scanForm.controls.unscan_view.datagrid('clearSelections');//清除之前选项
                    scanForm.controls.scan_view.datagrid('clearSelections');

                    if (result.isOk == 1) {
                        setProcessHtml(result.WorkFlowNo, result.ItemID);
                        scanForm.events.loadGrid(result.OrderID);
                        showMessage(true, result.message);
                        $('#Barcode').val("");
                        scanForm.events.scanfocus();
                        scanForm.events.load_unscan_view(result.OrderID);
                        scanForm.events.load_scan_view(result.OrderID);
                    }
                    else {
                        showMessage(false, result.message);
                        scanForm.controls.edit_form.form('clear');
                        cleanProcessHtml();
                        scanForm.events.load_unscan_view(result.OrderID);
                        scanForm.events.load_scan_view(result.OrderID);
                        setTimeout(function () {
                            $('#Barcode').val("");
                        }, 2000);
                    }
                },
                error: function (e) {
                    alert(JSON.stringify(e));
                }
            });
        },
        cleandetail: function () {
            scanForm.controls.edit_form.form('clear');
            //scanForm.controls.barcode.val('');
        },
        btnfinish: function () {



            if ($('#Barcode').val().length == 0) {
                showMessage(false, "订单或产品码不能为空！");
                return;
            }
            //scanForm.controls.edit_form.form('clear');
            //cleanProcessHtml();
            showMessage(true, "处理中请稍候...");

            if ($('#ckRework').prop('checked')) {
                scanForm.events.AutoScan(false);
            }
            else {
                scanForm.events.AutoScan(true);
            }
        }
    }
}
$(function () {
    scanForm.init();
    cleanProcessHtml();
    scanForm.events.load_unscan_view("");
    scanForm.events.load_scan_view("");
    window.setInterval(function () {
        scanForm.events.scanfocus();
    }, 3000);
});
$(window).load(function () {
    scanForm.events.scanfocus();
});

$(document).keydown(function (e) {
    //console.log(e.keyCode);
    if (e.keyCode == 13) {
        //console.log("=====");
        scanForm.events.btnfinish();
    }
});

function CheckScanRework() {
    $('#Barcode').focus();
    if ($('#ckRework').prop('checked') == true) {
        $.messager.confirm('系统提示', '确认选择工序返工?', function (flag) {
            if (flag) {
                $(".l-btn-text").text("确认返工");
            } else {
                $('#ckRework').prop('checked', false);
            }
        });
    }
    else {
        $(".l-btn-text").text("确认完工");
    }
    $('#Barcode').focus();
};

//设置扫描进度
function setProcessHtml(WorkFlowNo, ItemID) {
    $.ajax({
        type: "post",
        dataType: "json",
        data: { ItemID: ItemID },
        url: '/ashx/ordershandler.ashx?Method=GetOrderWorkFlowsByProcessed&' + jsNC(),
        success: function (obj) {
            var htmlstr = '';
            $.each(obj.rows, function (i, item) {
                if (i == obj.rows.length - 1) {
                    htmlstr += '<div class="' + ((item.WorkFlowNo > WorkFlowNo) ? "process_flow_right_wait" : "process_flow_right_arrive") + '">';
                }
                else {
                    htmlstr += '<div class="' + ((item.WorkFlowNo > WorkFlowNo) ? "process_flow_wait" : "process_flow_arrive") + '">';
                }
                htmlstr += '    <a title="' + item.Action + '" class="process_flow_input">' + item.Action + '</a>';
                htmlstr += '    <span>'
                htmlstr += '        <p class="name">' + item.Action + '</p>';
                htmlstr += '        <p class="name">' + (IsNullOrEmpty(item.Processed) ? "00-00 00:00" : item.Processed) + '</p>';
                htmlstr += '    </span>';
                htmlstr += ' </div>';
            });
            $("#process_flow").empty().html(htmlstr);
            //console.log(htmlstr);
        },
        error: function (e) {
            alert(JSON.stringify(e));
        }
    });
};
//清空进度跟踪条
function cleanProcessHtml() {
    $.ajax({
        type: "post",
        dataType: "json",
        data: { ItemID: "" },
        url: '/ashx/ordershandler.ashx?Method=GetOrderWorkFlowsByProcessed&' + jsNC(),
        success: function (obj) {
            var htmlstr = '';
            $.each(obj.rows, function (i, item) {
                if (i == obj.rows.length - 1) {
                    htmlstr += '<div class="process_flow_right_wait">';
                }
                else {
                    htmlstr += '<div class="process_flow_wait">';
                }
                htmlstr += '    <a title="' + item.WorkFlowName + '" class="process_flow_input">' + item.WorkFlowName + '</a>';
                htmlstr += '    <span>'
                htmlstr += '        <p class="name">' + item.WorkFlowName + '</p>';
                htmlstr += '        <p class="name">00-00 00:00</p>';
                htmlstr += '    </span>';
                htmlstr += ' </div>';
            });
            $("#process_flow").empty().html(htmlstr);
        },
        error: function (e) {
            alert(JSON.stringify(e));
        }
    });
};

function showMessage(state, message) {
    if (state) {
        scanForm.controls.scanresult.html("信息提示：" + message).css("color", "green");
    }
    else {
        scanForm.controls.scanresult.html("信息提示：" + message).css("color", "red");
    }
}