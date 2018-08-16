/*!
 @Name：打印条码
 @Author：刘胜伟
 @Remark：新增
 @Date：2018-01-27
 @License：MES  
 */

var t = null;
var min = 0; //分
var sec = 0; //秒
var hour = 0; //小时


var OrderID = "";

'use strict';
document.msCapsLockWarningOff = true;
var scanForm = {
    init: function () {
        scanForm.initControls();
        scanForm.events.load_unscan_view();
        scanForm.events.load_scan_view();
        scanForm.controls.btnPrint.on('click', function () { scanForm.events.PrintCode(); });
    },
    initControls: function () {
        scanForm.controls = {
            unscan_view: $('#dgUnScan'),
            scan_view: $('#dgScan'),
            barcode: $('#Barcode'),
            edit_form: $('#edit_form'),
            btnPrint: $('#btnPrint'),
            loading: $('#submit_window'),
        }
    },
    events: {
        //未打印
        load_unscan_view: function () {
            //if ($('#Barcode').val().length > 11) {
            //    var bc = $('#Barcode').val();
            //    bc = bc.substr(bc.lastIndexOf('C') - 1, 11);
            //    $('#Barcode').val(bc);
            //};
            scanForm.controls.unscan_view.datagrid({
                url: '/ashx/ordershandler.ashx?Method=SearchPrintListByOrderWorkFlow&' + jsNC(),
                idField: 'WorkingID',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                singleSelect: false,
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    { field: 'cp', checkbox: true },
                    //{ field: 'OrderNo', title: '订单号', width: 110, align: 'center' },
                   // { field: 'OutOrderNo', title: '外部单号', width: 110, align: 'center' },
                    { field: 'ItemGroup', title: '板件组', width: 60, align: 'center' },
                    { field: 'ItemName', title: '板件名', width: 100, align: 'center' },
                    { field: 'MaterialType', title: '板件材质', width: 200, align: 'left', headalign: 'left' },
                    //{ field: 'Size', title: '规格(mm)', width: 100, align: 'center' },
                    //{ field: 'MaterialStyle', title: '材质', width: 100, align: 'center' },
                    { field: 'SourceWorkFlowName', title: '工序', width: 60, align: 'center' },
                    { field: 'Barcode', title: '板件(二维)码', width: 200, align: 'left' },

                ]],
                onBeforeLoad: function (param) {
                    param['OrderNo'] = $('#Barcode').val();
                    param['PrintCount'] = "0";
                },
                onClickRow: function (index, row) {
                    OrderID = row.OrderID;
                    var Barcode = $('#Barcode').val()
                    $('#Barcode').val(row.OrderNo);
                    //优化相同订单号重复加载数据问题
                    if (Barcode != row.OrderNo && IsNullOrEmpty($("#OrderNo").val())) {
                        scanForm.events.loadGrid();
                        scanForm.events.loadTable();
                    }
                },
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        var body = $(this).data().datagrid.dc.body2;
                        body.find('table tbody').append('<tr><td colspan="10" style="height: 35px;border-left: #ccc dotted 1px; text-align: center;"><h1>暂无待打印产品</h1></td></tr>');
                    }
                    else if (!IsNullOrEmpty($("#Barcode").val())) {
                        OrderID = data.rows[0].OrderID;
                        scanForm.events.loadGrid();
                    }
                }
            });
        },
        //已打印
        load_scan_view: function () {
            //if ($('#Barcode').val().length > 11) {
            //    var bc = $('#Barcode').val();
            //    bc = bc.substr(bc.lastIndexOf('C') - 1, 11);
            //    $('#Barcode').val(bc);
            //};
            scanForm.controls.scan_view.datagrid({
                url: '/ashx/ordershandler.ashx?Method=SearchPrintListByOrderWorkFlow&' + jsNC(),
                idField: 'WorkingID',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                singleSelect: false,
                pageSize: 20,
                height: 100,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    { field: 'cp', checkbox: true },
                    { field: 'ItemGroup', title: '板件组', width: 60, align: 'center' },
                    { field: 'ItemName', title: '板件名', width: 100, align: 'center' },
                    { field: 'MaterialType', title: '板件材质', width: 200, align: 'left', headalign: 'left' },
                    //{ field: 'Size', title: '规格(mm)', width: 100, align: 'center' },
                    //{ field: 'MaterialStyle', title: '材质', width: 100, align: 'center' },
                    { field: 'PrintDate', title: '打印时间', align: 'center' },
                    { field: 'SourceWorkFlowName', title: '工序', width: 60, align: 'center' },
                    { field: 'Barcode', title: '板件(二维)码', width: 200, align: 'left' },
                ]],
                onBeforeLoad: function (param) {
                    param['OrderNo'] = $('#Barcode').val();
                    param['PrintCount'] = "1";
                },
                onClickRow: function (index, row) {
                    OrderID = row.OrderID;
                    var Barcode = $('#Barcode').val()
                    $('#Barcode').val(row.OrderNo);
                    if (Barcode != row.OrderNo && IsNullOrEmpty($("#OrderNo").val())) {
                        scanForm.events.loadGrid();
                        scanForm.events.loadTable();
                    }
                },
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        var body = $(this).data().datagrid.dc.body2;
                        body.find('table tbody').append('<tr><td colspan="10" style="height: 35px;border-left: #ccc dotted 1px; text-align: center;"><h1>暂无已打印产品</h1></td></tr>');
                    }
                    else if (!IsNullOrEmpty($("#Barcode").val()) && IsNullOrEmpty($("#OrderNo").val())) {
                        OrderID = data.rows[0].OrderID;
                        scanForm.events.loadGrid();
                    }
                }
            });
        },
        //订单数据
        loadGrid: function () {
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
                    //scanForm.controls.edit_form.find('#ManufactureDate').val(('P,F,I,O').indexOf(data.Status) < 0 ? "未开始" : "已开始");
                }
            });
        },
        //打印条码
        PrintCode: function () {
            var jsData = [];

            //支持未打印产品和已打印产品同时打印
            var selRows = scanForm.controls.unscan_view.datagrid('getChecked');
            $.each(selRows, function (index, item) {
                jsData.push(item);
            });
            var selRows = scanForm.controls.scan_view.datagrid('getChecked');
            $.each(selRows, function (index, item) {
                jsData.push(item);
            });

            // console.log(JSON.stringify(jsData));
            if (IsNullOrEmpty(jsData)) {
                showError("请选择要打印的产品。");
                return;
            }

            t = null;
            hour = 0;
            min = 0;
            sec = 0;
            $('.runtime').html('');
            setInterval(function () { t = scanForm.events.timedCount(); }, 1000);
            scanForm.controls.loading.window('open');
            //console.log(JSON.stringify(jsData));

            var Barcode = "", WorkingID = "";
            $.each(jsData, function (index, item) {
                //console.log(item);

                Barcode += item.Barcode + ",";
                WorkingID += item.WorkingID + ",";

                if (index == (jsData.length - 1)) {
                    setTimeout(function () {
                        scanForm.events.cleandetail();
                        scanForm.events.loadTable();
                        scanForm.events.stopCount();
                        scanForm.controls.loading.window('close');
                    }, (index + 1) * 2000);
                }
            });

            var parameter = "?template=package&Barcode=" + Barcode + "&WorkingID=" + WorkingID + "&isview=" + $('#checkview').is(":checked");
            InsertIframe(parameter);

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
        cleandetail: function () {
            scanForm.controls.edit_form.form('clear');
            //scanForm.controls.barcode.val('');
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
}
$(function () {
    scanForm.init();
});
$(window).load(function () {
    scanForm.events.scanfocus();
    window.setInterval(function () {
        scanForm.events.scanfocus();
    }, 3000);
    $(".l-btn-icon-left").click(function () {
        scanForm.events.load_unscan_view();
        scanForm.events.load_scan_view();
    })
});
$(document).keydown(function (e) {
    console.log(e.keyCode);
    if (e.keyCode == 13) {
        console.log("=====");
        scanForm.events.load_unscan_view();
        scanForm.events.load_scan_view();
    }
});

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}