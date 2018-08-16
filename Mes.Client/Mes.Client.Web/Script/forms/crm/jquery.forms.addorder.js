(function ($) {
    document.msCapsLockWarningOff = true;
    var addOrderForm = {
        init: function () {
            addOrderForm.initControls();
            addOrderForm.controls.SolutionID = getUrlParam('sid');
            addOrderForm.controls.QuoteID = getUrlParam('qid');
            addOrderForm.controls.QuoteNo = getUrlParam('qno');
            addOrderForm.controls.DesignerID = getUrlParam('DesignID');
            addOrderForm.controls.TaskID = getUrlParam('taskid');
            addOrderForm.events.initCustomer();
            addOrderForm.events.CabinetType();
            addOrderForm.controls.btn_edit_save.on('click', addOrderForm.events.SaveOrder);//保存
            $("#TaskID").val(addOrderForm.controls.TaskID);
            $("#DesignerID").val(addOrderForm.controls.DesignerID);
        },
        initControls: function () {
            addOrderForm.controls = {
                dgcabinet: $("#dgcabinet"),
                dgdetail: $("#dgdetail"),
                dghardware: $("#dghardware"),
                TaskID: null,
                SolutionID: null,
                DesignerID: null,
                QuoteID: null,
                QuoteNo: null,
                Status: null,
                PartnerID: null,
                add_form: $("#add_form"),
                btn_edit_save: $("#btn_edit_save")
            };


            var mydate = new Date();
            var yy = mydate.getFullYear();
            var mm = mydate.getMonth() + 1;
            var dd = mydate.getDate();
            var NowDay = yy + '-' + (mm < 10 ? ('0' + mm) : mm) + '-' + (dd < 10 ? ('0' + dd) : dd);
            $("#BookingDate").val(NowDay);//默认当天

            //交货日期 先选择订单类型
            $('#ShipDate').datebox({
                onSelect: function (date) {
                    showError("请选择订单类型！");
                    $("#ShipDate").datebox("setValue", '');
                    return;
                }
            });

            //根据订单类型判断交货日期天数
            $('#ShipDate').datebox({
                onSelect: function (date) {
                    var OrderType = $("#OrderType").combobox('getValue');
                    var BookingDate = $("#BookingDate").datebox("getValue"); //订货日期
                    var ShipDate = $("#ShipDate").datebox("getValue");       //交货日期
                    if (OrderType == "") {
                        showError("请选择订单类型！");
                        $("#ShipDate").datebox("setValue", '');
                        return;
                    }
                    if (OrderType == "正常" || OrderType == "工程" || OrderType == "展会") {
                        if (BookingDate == ShipDate || BookingDate > ShipDate) {
                            showError("交货日期必须大于15天！");
                            $("#ShipDate").datebox("setValue", '');
                            return;
                        }
                        var bookingTemp = BookingDate.split("-");
                        var bDate = new Date(bookingTemp[0] + '-' + bookingTemp[1] + '-' + bookingTemp[2]); //转换为MM-DD-YYYY格式    
                        var shipTemp = ShipDate.split("-");
                        var sDate = new Date(shipTemp[0] + '-' + shipTemp[1] + '-' + shipTemp[2]); //转换为MM-DD-YYYY格式  
                        var iDays = parseInt(Math.abs(sDate - bDate) / 1000 / 60 / 60 / 24); //把相差的毫秒数转换为天数
                        if (iDays < 15) {
                            showError("交货日期必须为订货日期的15天之后！");
                            $("#ShipDate").datebox("setValue", '');
                            return;
                        }
                    }
                    if (OrderType == "加急" || OrderType == "补货") {
                        if (BookingDate == ShipDate || ShipDate < BookingDate) {
                            showError("交货日期必须大于今天！");
                            $("#ShipDate").datebox("setValue", '');
                            return;
                        }
                        var bookingTemp = BookingDate.split("-");
                        var bDate = new Date(bookingTemp[0] + '-' + bookingTemp[1] + '-' + bookingTemp[2]); //转换为MM-DD-YYYY格式    
                        var shipTemp = ShipDate.split("-");
                        var sDate = new Date(shipTemp[0] + '-' + shipTemp[1] + '-' + shipTemp[2]); //转换为MM-DD-YYYY格式  
                        var iDays = parseInt(Math.abs(sDate - bDate) / 1000 / 60 / 60 / 24); //把相差的毫秒数转换为天数
                        if (iDays < 3) {
                            showError("交货日期必须为订货日期的3天之后！");
                            $("#ShipDate").datebox("setValue", '');
                            return;
                        }
                    }
                }
            });
        },
        events: {
            initCustomer: function () {
                $.ajax({
                    url: '/ashx/quotehandler.ashx?Method=GetCustomer&' + jsNC(),
                    data: { SolutionID: addOrderForm.controls.SolutionID, ReferenceID: addOrderForm.controls.DesignerID },
                    datatype: "json",
                    success: function (data) {
                        if (data) {
                            if (data.isOk == 0) {
                                showError(data.message);
                            }
                            else {
                                addOrderForm.controls.add_form.form('load', data);
                            }
                        }
                    }
                });

                $.ajax({
                    url: '/ashx/quotehandler.ashx?Method=GetQuoteMainBySolutionID',
                    data: { SolutionID: addOrderForm.controls.SolutionID },
                    datatype: "json",
                    success: function (data) {
                        if (data) {
                            addOrderForm.controls.Status = data.Status;
                            addOrderForm.controls.PartnerID = data.PartnerID;
                            addOrderForm.controls.QuoteID = data.QuoteID;
                            addOrderForm.controls.QuoteNo = data.SolutionCode;
                            $('#QuoteID').val(data.QuoteID);
                            $('#SolutionID').val(data.SolutionID);
                            $("#OutOrderNo").val(data.DesignerNo);
                            $("#PartnerID").val(data.PartnerID);

                            //$("#PurchaseNo").val(data.SolutionCode);
                            //$("#OrderNo").val(data.SolutionCode);
                        }
                    }
                });
            },
            //五金
            loadHardware: function () {
                addOrderForm.controls.dghardware.datagrid({
                    url: '/ashx/quoteshowHandler.ashx?Method=GetQuoteDetail',
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fit: true,
                    fitColumns: true,
                    pagination: false,
                    columns: [[
                        { field: 'ItemName', title: '部件名称', width: 150, sortable: false, align: 'center' },
                        { field: 'ItemStyle', title: '型号', width: 120, sortable: false, align: 'center' },
                        { field: 'Qty', title: '数量', width: 100, sortable: false, align: 'center' },
                        { field: 'Price', title: '单价', width: 120, sortable: false, align: 'center' },
                        { field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        param['QuoteID'] = addOrderForm.controls.QuoteID;
                        param['ItemGroup'] = "五金";
                    }
                });
            },
            //部件
            loadQuoteDetail: function () {
                addOrderForm.controls.dgdetail.datagrid({
                    url: '/ashx/quoteshowHandler.ashx?Method=GetQuoteDetail',
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fit: true,
                    fitColumns: true,
                    pagination: false,
                    columns: [[
                        { field: 'ItemName', title: '部件名称', width: 150, sortable: false, align: 'center' },
                        { field: 'ItemStyle', title: '型号', width: 120, sortable: false, align: 'center' },
                        { field: 'Qty', title: '数量', width: 100, sortable: false, align: 'center' },
                        { field: 'Price', title: '单价', width: 120, sortable: false, align: 'center' },
                        { field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center' }
                    ]],
                    groupField: 'ItemGroup',
                    view: groupview,
                    groupFormatter: function (value, rows) {
                        return value + ' - ' + rows.length + ' Item(s)';
                    },
                    onBeforeLoad: function (param) {
                        param['QuoteID'] = addOrderForm.controls.QuoteID;
                    }
                });
            },
            //产品明细
            loadCabinet: function () {
                addOrderForm.controls.dgcabinet.datagrid({
                    url: '/ashx/solutionhandler.ashx?Method=GetCabinets',
                    idField: 'CabinetID',
                    collapsible: false,
                    singleSelect: true,
                    fit: true,
                    fitColumns: true,
                    //pageSize: 20,
                    pagination: false,
                    columns: [[
                        { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                        { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                        { field: 'Size', title: '成品尺寸', width: 120, sortable: false, align: 'center' },
                        { field: 'Color', title: '材质颜色', width: 120, sortable: false, align: 'center' },
                        { field: 'MaterialStyle', title: '材质风格', width: 120, sortable: false, align: 'center' },
                        { field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center' },
                        { field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center' },
                        { field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center' },
                        { field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center' },
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
                        param['id'] = addOrderForm.controls.SolutionID;
                    }
                });
            },
            //产品类型
            CabinetType: function () {
                $('#CabinetType').combobox({
                    url: '/ashx/categoryhandler.ashx?Method=GetCabinetType',
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                });
            },
            //保存
            SaveOrder: function () {

                if (addOrderForm.controls.Status == "M") {
                    showError("该方案订单已到生产线排产，不能重复提交！");
                    return;
                };

                if (!addOrderForm.controls.add_form.form('validate')) {
                    showError('请完善信息后再提交');
                    return;
                }


                var Amount = $('#Amount').val();
                if (Amount === '0.00') {
                    showError('收款不能为零');
                    return;
                }
                //$("#OrderID").val(addOrderForm.events.loadNewGuid);//订单号

                $("#OrderID").val(addOrderForm.controls.SolutionID);
                $.ajax({
                    url: "/ashx/partnerOrdersHandler.ashx?Method=SaveOrder",
                    data: addOrderForm.controls.add_form.serialize(),
                    success: function (data) {
                        if (data.isOk == 1) {
                            $.messager.alert("提示", "生成订单成功", "info", function () {
                                window.top.RefreshTask('我的任务');
                                window.parent.closeTab();
                            });
                        }
                        else {
                            showError(data.message);
                        }
                    }
                });
            },
            //Guid
            loadNewGuid: function () {
                var guid = " ";
                for (var i = 1; i <= 32; i++) {
                    var n = Math.floor(Math.random() * 16.0).toString(16);
                    guid += n;
                    if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                        guid += "-";
                }
                return guid;
            }
        }
    };

    $(function () {
        addOrderForm.init();
    });
})(jQuery);