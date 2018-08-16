(function ($) {
'use strict';
document.msCapsLockWarningOff = true;
var ordersReviewForm = {
    init: function () {     
        ordersReviewForm.initControls();
        ordersReviewForm.events.loadData();
        ordersReviewForm.events.loadDoors();
        ordersReviewForm.controls.btn_review_save.on('click', ordersReviewForm.events.orderreview);
        ordersReviewForm.controls.revieworder_submit.on('click', ordersReviewForm.events.revieworder_submit);//审核通过
        ordersReviewForm.controls.review_reject.on('click',ordersReviewForm.events.review_reject);//审核拒绝
    },
    initControls: function () {
        ordersReviewForm.controls = {
            search_form: $("#search_form"),
            dgorder: $('#dgorder'),//产品信息
            dgdetail: $('#dgdetail'),//板件信息
            dgHardware: $('#dgHardware'),//五金信息
            dgdoors: $('#dgdoors'),//移门信息
            review_form: $('#search_form'),
            review_window: $('#review_window'),
            btn_review_save: $('#btn_review_save'),
            revieworder_submit: $('#btn_review_ok'),//审核
            review_reject: $('#btn_review_reject'),//拒绝      
        }
        $('#btn_search_ok').linkbutton();
    },
    events: {
        loadData: function () {
            var orderid = getUrlParam('OrderID');
            $("#OrderID").val(orderid);
            //订单信息
            $.ajax({
                url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                data: { OrderID: orderid },
                datatype: "json",
                success: function (data) {
                    ordersReviewForm.controls.search_form.form('load', data);

                    $("#Status").val(GetOrderStatusName(data.Status));//转换订单状态中文名称 该方法GetOrderStatusName在公共js里
                    $("#H_OrderNo").val(data.OrderNo);

                    //var QuoteNo = data.PurchaseNo;
                    ////spkFile
                    //ordersReviewForm.controls.skpFile.datagrid({
                    //    //idField: 'DoorID',
                    //    url: '/ashx/solutionhandler.ashx?Method=GetSolutionFiles',
                    //    collapsible: false,
                    //    singleSelect: true,
                    //    pageSize: 20,
                    //    fitColumns: true,
                    //    pagination: false,
                    //    columns: [[
                    //        { field: 'DoorID', title: '移门ID', hidden: true, width: 200, sortable: false, align: 'center' },
                    //        { field: 'FileName', title: '文件名称',width: 200, sortable: false, align: 'center' },                         
                    //        { field: 'Created', title: '上传时间', width: 120, sortable: false, align: 'center', },
                    //        {
                    //            field: 'action', title: '操作', width: 120, sortable: false, align: 'center',
                    //            formatter: function (value, rowData, rowIndex) {
                    //                var str = '<img style="cursor:pointer;" onclick="downloadfile(\'' + rowData.FileID + '\')" src="/Content/images/exticons/page/page_white_put.png" alt="下载文件"/>&nbsp;&nbsp;';
                    //                 return str;
                    //            }
                    //        }
                    //    ]],
                    //    onBeforeLoad: function (param) {
                    //        param['QuoteNo'] = QuoteNo;
                    //    }
                    //});

                    ordersReviewForm.controls.search_form.find('input').each(function (index) {
                        $(this).attr('readonly', true);
                        $('#BookingDate').val(new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                        $('#ShipDate').val(new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));
                        if (data.IsStandard == "True") {
                            $('#IsStandard').val("是");
                        } else {
                            $('#IsStandard').val("否");
                        }
                        if (data.IsOutsourcing == "True") {
                            $('#IsOutsourcing').val("是");
                        } else {
                            $('#IsOutsourcing').val("否");
                        }
                        if (('P,F,I,O').indexOf(data.Status) < 0) {
                            $('#ManufactureDate').val("未开始");
                        }
                        else {
                            $('#ManufactureDate').val(new Date(removeCN(data.ManufactureDate)).Formats('yyyy-MM-dd'));
                        }
                    });
                    $('#Amount').attr('readonly', false);
                    $('#Payee').attr('readonly', false);
                    $('#TransDate').attr('readonly', false);
                    $('#VoucherNo').attr('readonly', false);
                }
            });

            //产品列表
            //$.ajax({
            //    url: '/ashx/ordershandler.ashx?Method=GetCabinets&' + jsNC(),
            //    data: { OrderID: orderid },
            //    datatype: "json",
            //    success: function (data) {
            //        if (data) {
            //            $('#cabinets').append("<li class='item active'>全部</li>");
            //            $.each(data.rows, function (index, row) {
            //                $('#cabinets').append("<li class='item'>" + row.CabinetName + "</li>");
            //            });
            //        }
            //    }
            //});

            //产品明细
           ordersReviewForm.controls.dgorder.datagrid({
                sortName: 'Sequence',
                idField: 'CabinetID',
                url: '/ashx/ordershandler.ashx?Method=GetCabinets',
                collapsible: false,
                fitColumns: true,
                pagination: false,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                columns: [[
                    { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                    { field: 'Size', title: '成品尺寸', width: 120, sortable: false, halign: 'center', align: 'center' },
                    { field: 'MaterialStyle', title: '材质风格', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Color', title: '材质颜色', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'MaterialCategory', title: '材质类型', width: 100, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Qty', title: '数量', width: 60, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Unit', title: '单位', width: 50, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Price', title: '单价', width: 80, sortable: false, halign: 'center', align: 'center' },
                    { field: 'Remark', title: '备注', width: 150, sortable: false, halign: 'center', align: 'center' }
                ]],
                onBeforeLoad: function (param) {
                    param['OrderID'] = orderid;
                    param['CabinetName'] = $('#CabinetNum').val();
                }
           });

            //板件信息
           ordersReviewForm.controls.dgdetail.datagrid({
               idField: 'ItemID',
               url: '/ashx/ordershandler.ashx?Method=SearchOrderDetail&' + jsNC(),
               collapsible: false,
               fitColumns: true,
               pagination: true,
               striped: false,
               pageSize: 20,
               columns: [[
               { field: 'CabinetName', title: '产品名称', width: 180, align: 'center' },
               { field: 'BarcodeNo', title: '板件条码', width: 180, align: 'center' },
               { field: 'ItemName', title: '部件名称', width: 120, align: 'center' },
               { field: 'MaterialStyle', title: '材质风格', width: 100, sortable: false, align: 'center' },
               { field: 'Color', title: '材质颜色', width: 100, sortable: false, align: 'center' },
               {
                   field: 'MadeWidth', title: '开料宽度', width: 80, sortable: false, align: 'center',
                   formatter: function (value, rowData, rowIndex) {
                       if (value == undefined) return "";
                       return value.toString().replace('.00', '');
                   }
               },
               {
                   field: 'MadeLength', title: '开料长度', width: 80, sortable: false, align: 'center',
                   formatter: function (value, rowData, rowIndex) {
                       if (value == undefined) return "";
                       return value.toString().replace('.00', '');
                   }
               },
               {
                   field: 'EndWidth', title: '成品宽度', width: 80, sortable: false, align: 'center',
                   formatter: function (value, rowData, rowIndex) {
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
                 { field: 'Remarks', title: '备注', width: 150, sortable: false, align: 'center' }
               ]],
               toolbar: [
                  //{ text: '下载料单', iconCls: 'icon-add', handler: ordersdetailForm.events.downfile },
                  //{ text: '外购件清单', iconCls: 'icon-add', handler: ordersdetailForm.events.OutSourcingMaterials },
                  //{ text: '库存件清单', iconCls: 'icon-add', handler: ordersdetailForm.events.StorageMaterials },
                  //{ text: '备料清单', iconCls: 'icon-add', handler: ordersdetailForm.events.StockListing },
                  //{ text: '移门清单', iconCls: 'icon-add', handler: ordersdetailForm.events.SlidingDoor }
               ],
               onBeforeLoad: function (param) {
                   param['OrderID'] = orderid;
                   //param['CabinetNum'] = $('#CabinetNum').val();
               }
           });

           //五金信息
           ordersReviewForm.controls.dgHardware.datagrid({
               idField: 'OrderID',
               url: '/ashx/ordershandler.ashx?Method=SearchOrder2Hardwares&' + jsNC(),
               collapsible: false,
               fitColumns: true,
               pagination: true,
               striped: false,
               pageSize: 20,
               columns: [[
                   { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                   { field: 'HardwareCategory', title: '分类', width: 120, sortable: false, align: 'center' },
                   { field: 'HardwareCode', title: '物料编码', width: 120, sortable: false, align: 'center' },
                   { field: 'HardwareName', title: '名称', width: 150, sortable: false, align: 'center' },
                   { field: 'Style', title: '规格/型号', width: 150, sortable: false, align: 'center' },
                   { field: 'Qty', title: '数量', width: 150, sortable: false, align: 'center' },
                   { field: 'Unit', title: '单位', width: 200, sortable: false, align: 'center' }
               ]],
               toolbar: [
                     //{ text: '五金料单', iconCls: 'icon-add', handler: ordersdetailForm.events.hardwareReport }
               ],
               onBeforeLoad: function (param) {
                   param['OrderID'] = orderid;
                   param['CabinetName'] = $('#CabinetNum').val();
               }
           });
        },
     
        loadDoors: function () {
            var orderid = getUrlParam('OrderID');
            ordersReviewForm.controls.dgdoors.datagrid({
                idField: 'DoorID',
                url: '/ashx/OrdersHandler.ashx?Method=GetDoors',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'DoorID', title: '移门ID', hidden: true, width: 200, sortable: false, align: 'center' },
                { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                {
                    field: 'CabinetName', title: '产品名称', width: 100, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CabinetName',
                            textField: 'CabinetName',
                            method: 'get',
                            url: '/ashx/OrdersHandler.ashx?Method=GetCabinetName2Doors&OrderID=' + $('#OrderID').val(),
                            required: true,
                            onSelect: function (index) {
                                CabinetID = index.CabinetID;
                            }
                        }
                    }
                },
                {
                    field: 'DoorName', title: '移门名称', width: 120, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetDoorName',
                            required: true
                        }
                    }
                },
                {
                    field: 'DoorSize', title: '尺寸', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            required: true
                        }
                    }
                },

                {
                    field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center', editor: {
                        type: 'numberbox',
                        options: {
                            required: true
                        }
                    },
                },

                {
                    field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            //required: true
                        }
                    }
                },
                {
                    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                    formatter: function (value, row, index) {

                        var str = '<a href="#" onclick="cancelrow(\'' + row['DoorID'] + '\',' + index + ')"><span class="icon delete">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        //str += '<a href="#" onclick="copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                        return str;
                    }
                }
                ]],
                toolbar: [
                    //{ text: '增加', iconCls: 'icon-add', handler: ordersdetailForm.events.addrow },
                    //{
                    //    text: '取消', iconCls: 'icon-cancel', handler: ordersdetailForm.events.cancelall,
                    //},
                    //{
                    //    text: '提交数据', iconCls: 'icon-save', handler: ordersdetailForm.events.SaveDoors,
                    //},
                ],
                onBeforeLoad: function (param) {
                    param['OrderID'] = orderid;
                },
                //onClickCell: ordersdetailForm.events.onClickCell,
                //onEndEdit: ordersdetailForm.events.onEndEdit
            });
        },

        orderreview: function () {
            //var selRows = ordersMananerForm.controls.dgdetail.datagrid('getChecked');
            //if (!selRows.length) {
            //    showError('请选择待确认的订单。');
            //    return;
            //}
            ////根据订单状态打开窗口
            //if (selRows[0].Status == "N" || selRows[0].Status == "Z") {
              
            //} else {
            //    showError("请选择待审核或者待信息确认订单");
            //}

            ordersReviewForm.controls.review_window.window('open');
            $('#Remark').val(''); //清空textarea
        },

        //审核拒绝
        review_reject: function () {
            if (ordersReviewForm.controls.review_form.form('validate')) {
                var Remark = $('#option_Remark').val();
                if (Remark==='') {
                    showError("备注不能为空.");
                    return;
                }
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=RejectFinanceOrder',
                    data: { OrderID: $("#OrderID").val(), Remark: $('#option_Remark').val() },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 0) {
                                showError(returnData.message);
                            }
                            else {
                                $.messager.alert("提示", "操作成功", "info", function () {
                                    ordersReviewForm.controls.review_window.window('close');
                                    var pid = getUrlParam('OrderFinanceReviewPid');
                                    top.addTab("财务审核", "/View/orders/orderfinancereview.aspx?pid=" + pid, 'table');
                                    window.parent.closeTab();
                                });                            
                            }
                        }
                    }
                });
            }
        },

        //审核提交
        revieworder_submit: function () {
            if (ordersReviewForm.controls.review_form.form('validate')) {
                var Remark = $('#option_Remark').val();
                if (Remark === '') {
                    showError("备注不能为空.");
                    return;
                }
                var Amount = $('#Amount').val();
                var Payee = $('#Payee').val();
                var TransDate = $('#TransDate').datebox('getValue');
                var VoucherNo= $('#VoucherNo').val();
                var data = {
                    PartnerID: $('#PartnerID').val(),
                    OrderID: $('#OrderID').val(),
                    Amount: parseFloat(Amount).toFixed(2),
                    Payee: Payee,
                    TransDate: TransDate,
                    VoucherNo: VoucherNo,
                    Remark: Remark,
                };
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=FinanceReview',
                    data: data,
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 0) {
                                showError(returnData.message);
                            }
                            else {
                                $.messager.alert("提示", "审核成功", "info", function () {
                                    ordersReviewForm.controls.review_window.window('close');
                                    var pid = getUrlParam('OrderFinanceReviewPid');
                                    top.addTab("财务审核", "/View/orders/orderfinancereview.aspx?pid=" + pid, 'table');
                                    window.parent.closeTab();
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
        ordersReviewForm.init();
    });

})(jQuery);

