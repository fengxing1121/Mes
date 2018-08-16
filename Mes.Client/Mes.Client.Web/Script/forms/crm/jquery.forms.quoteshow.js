(function ($) {
    //'use strict';
    document.msCapsLockWarningOff = true;
    var quoteshowForm = {
        init: function () {
            quoteshowForm.initControls();
            quoteshowForm.controls.SolutionID = getUrlParam('sid');
            quoteshowForm.controls.QuoteID = getUrlParam('qid');
            quoteshowForm.controls.QuoteNo = getUrlParam('qno');
            quoteshowForm.events.initCustomer();
            quoteshowForm.events.loadQuoteMain();
            quoteshowForm.events.loadData();
            quoteshowForm.events.loadCabinet();
            quoteshowForm.controls.btn_certain.on('click', quoteshowForm.events.certainQuoteDetailStatus); //确认报价
            quoteshowForm.controls.btn_cancel.on('click', quoteshowForm.events.cancelQuoteDetailStatus);   //取消报价
            quoteshowForm.controls.printview.on('click', quoteshowForm.events.print_view);   //预览报价
        },
        initControls: function () {
            quoteshowForm.controls = {
                dgdetail: $("#dgdetail"),
                dgcabinet: $("#dgcabinet"),
                search_form: $("#search_form"),
                SolutionID: null,
                QuoteID: null,
                QuoteNo: null,
                btn_certain: $("#btn_certain"),
                btn_cancel: $("#btn_cancel"),
                printview: $("#btn_rptView")
            };
            $("#SolutionID").val(quoteshowForm.controls.SolutionID);
            $("#QuoteID").val(quoteshowForm.controls.QuoteID);
            $("#QuoteNo").val(quoteshowForm.controls.QuoteNo);
        },
        events: {
            initCustomer: function () {
                $.ajax({
                    url: '/ashx/quotehandler.ashx?Method=GetCustomerBySolutionID&' + jsNC(),
                    data: { SolutionID: quoteshowForm.controls.SolutionID },
                    datatype: "json",
                    success: function (data) {
                        if (data) {
                            quoteshowForm.controls.search_form.form('load', data);
                        }
                    }
                });
            },
            loadQuoteMain: function () {
                $.ajax({
                    url: "/ashx/quoteshowHandler.ashx?Method=GetQutoMain",
                    data: { QuoteID: quoteshowForm.controls.QuoteID },
                    datatype: "json",
                    success: function (data) {
                        if (data) {
                            quoteshowForm.controls.search_form.form('load', data);
                            $("#ExpiryDate").val(ChangeDateFormat(data.ExpiryDate));
                            $("#Status").val(getQuoteMainStatusName(data.Status));
                            quoteshowForm.events.btnShowOrHide(data.Status);
                        }
                    }
                });
            },
            loadData: function () {
                quoteshowForm.controls.dgdetail.datagrid({
                    url: '/ashx/quoteshowHandler.ashx?Method=GetQuoteDetail',
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: true,
                    pagination: true,
                    showFooter: true,
                    columns: [[
                        //{ field: 'ItemGroup', title: '部件名称', width: 150, sortable: false, align: 'center' },
                        { field: 'ItemName', title: '部件名称', width: 150, sortable: false, align: 'center' },
                        { field: 'ItemStyle', title: '型号', width: 120, sortable: false, align: 'center' },
                        { field: 'Qty', title: '数量', width: 100, sortable: false, align: 'center' },
                        { field: 'Price', title: '单价', width: 120, sortable: false, align: 'center' },
                        {
                            field: 'Amount', title: '金额', width: 120, sortable: false, align: 'center', formatter: function (value, row, index) {
                                if (!isNaN(row.Price)) {
                                    return (row.Price * row.Qty).toFixed(2);
                                }
                                else {
                                    return value;
                                }
                            }
                        },
                        { field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center' }
                    ]],
                    groupField: 'ItemGroup',
                    view: groupview,
                    groupFormatter: function (value, rows) {
                        return value + ' - ' + rows.length + ' Item(s)';
                    },
                    onBeforeLoad: function (param) {
                        param['QuoteID'] = quoteshowForm.controls.QuoteID;
                    },
                    onLoadSuccess: function (data) {
                        //统计板件金额
                        quoteshowForm.controls.dgdetail.datagrid('reloadFooter', [{ 'ItemName': '<font color="Red">折扣：</font>', 'ItemStyle': '<font color="Red">' + parseFloat(data.rows[0].DiscountPercent) * 100 + '%</font>', 'Price': '<font color="Red">金额合计：</font>', 'Amount': '<font color="red">￥' + data.rows[0].TotalAmount + '</font>' }]);
                    },
                });
            },
            //产品明细  
            loadCabinet: function () {
                quoteshowForm.controls.dgcabinet.datagrid({
                    url: '/ashx/solutionhandler.ashx?Method=GetCabinets',
                    idField: 'CabinetID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fit: true,
                    fitColumns: true,
                    pagination: true,
                    columns: [[
                        { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                        { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                        { field: 'Size', title: '成品尺寸', width: 120, sortable: false, align: 'center' },
                        { field: 'Color', title: '材质颜色', width: 120, sortable: false, align: 'center' },
                        { field: 'MaterialStyle', title: '材质风格', width: 120, sortable: false, align: 'center' },
                        { field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center' },
                        { field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center' },
                        { field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center' },
                        { field: 'Remark', title: '备注', width: 120, hidden: true, sortable: false, align: 'center' },
                    ]],
                    onBeforeLoad: function (param) {
                        param['SolutionID'] = quoteshowForm.controls.SolutionID;
                    }
                });
            },
            cancelQuoteDetailStatus: function () {
                $.ajax({
                    url: '/ashx/quoteshowHandler.ashx?Method=ModifyQuoteMainStatus&' + jsNC(),
                    data: { Status: "C", QuoteID: quoteshowForm.controls.QuoteID },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 1) {
                                showInfo(returnData.message);
                                top.addTab("产品报价", "/View/crm/quoteset.aspx", 'table');
                                top.closeTab('报价详情');
                            } else {
                                showError(returnData.message);
                            }
                        }
                    }
                });
            },
            certainQuoteDetailStatus: function () {
                var SolutionID = $("#SolutionID").val();
                var QuoteID = $("#QuoteID").val();
                var QuoteNo = $("#QuoteNo").val();
                var Status = getQuoteMainStatusValue($("#Status").val());

                //var DiscountPercent = $('#DiscountPercent').val(); //折扣率
                //var TotalAmount = $('#TotalAmount').val();         //总金额
                //var DiscountAmount = $('#DiscountAmount').val();   //折扣金额
                $.ajax({
                    url: '/ashx/quoteshowHandler.ashx?Method=FindQuoteMainStatus&' + jsNC(),
                    data: { Status: Status, QuoteID: quoteshowForm.controls.QuoteID },
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 1) {
                                top.addTab("生成订单", "/View/crm/addorder.aspx?sid=" + SolutionID + "&qid=" + QuoteID + "&qno=" + QuoteNo, 'table');
                            } else {
                                showError(returnData.message);
                                window.parent.closeTab();
                            }
                        }
                    }
                });
            },
            //显示或隐藏按钮
            btnShowOrHide: function (value) {
                switch (value.toUpperCase()) {
                    case "N": //确认中
                        quoteshowForm.controls.btn_cancel.css('display', 'block');
                        quoteshowForm.controls.btn_certain.css('display', 'block');
                        break;
                    case "F": //已确认
                        quoteshowForm.controls.btn_cancel.css('display', 'block');
                        break;
                    default:
                        break;
                }
            },
            print_view: function () {
                top.addTab("报表预览", "/View/reports/reportsView.aspx?ReportPath=/MES/Report/rptQuote&QuoteID=" + $('#QuoteID').val(), "table");
            }
        }
    };

    $(function () {
        quoteshowForm.init();
    });
})(jQuery);

//将序列化成json格式后日期(毫秒数)转成日期格式
function ChangeDateFormat(cellval) {
    var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    return date.getFullYear() + "-" + month + "-" + currentDate;
}
