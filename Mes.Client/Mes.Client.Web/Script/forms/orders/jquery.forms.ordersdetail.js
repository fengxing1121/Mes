//(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var editIndex = undefined;
    var CabinetID = "";
    var ordersdetailForm = {
        init: function () {
            ordersdetailForm.initControls();
            ordersdetailForm.events.loadGrid();
            ordersdetailForm.events.loadDoors();//加载移门数据  
            ordersdetailForm.events.cleardata();
            ordersdetailForm.controls.btn_review_open.on('click', ordersdetailForm.events.orderreview);
            ordersdetailForm.controls.btn_review_ok.on('click',ordersdetailForm.events.revieworder_submit);
            ordersdetailForm.controls.btn_review_reject.on('click',ordersdetailForm.events.review_reject);
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
                skpFile: $('#skpFile'),//skp文件
                review_window: $('#review_window'),//审核窗口
                review_form:$('#review_form'),
                btn_review_ok: $('#btn_review_ok'),//通过审核
                btn_review_reject: $('#btn_review_reject'),//审核拒绝
                btn_review_open: $('#btn_review_open')
            }
            getUrlParam('flag') == 'true' ? ordersdetailForm.controls.btn_review_open.show() : ordersdetailForm.controls.btn_review_open.hide();

            $('#div_content').delegate('li', 'click', function () {
                var CabinetName = $(this).text();
                $(this).parent().find('.active').removeClass("active");
                $(this).addClass("active");
                if (CabinetName == "全部") CabinetName = '';
                $('#CabinetNum').val(CabinetName);
                ordersdetailForm.events.reload();
            });
        },
        events: {
            refresh:function()
            {
                top.RefreshTab('订单查询','Refresh_Order');
            },
            loadGrid: function () {
                //初始化数据   
                var orderid = getUrlParam('orderid');
                if (orderid.length == 0) return;
                $('#OrderID').val(orderid);
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                    data: { OrderID: orderid },
                    datatype: "json",
                    success: function (data) {
                        ordersdetailForm.controls.search_form.form('load', data);

                        $("#Status").val(GetOrderStatusName(data.Status));//转换订单状态中文名称 该方法GetOrderStatusName在公共js里
                        $("#H_OrderNo").val(data.OrderNo);
                        var QuoteNo = data.PurchaseNo;

                        //spkFile
                        ordersdetailForm.controls.skpFile.datagrid({
                            //idField: 'DoorID',
                            url: '/ashx/solutionhandler.ashx?Method=GetSolutionFiles',
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
                                param['QuoteNo'] = QuoteNo;
                            }
                        });


                        ordersdetailForm.controls.search_form.find('input').each(function (index) {
                            $(this).attr('readonly', true);
                            $('#BookingDate').val(new Date(removeCN(data.BookingDate)).Formats('yyyy-MM-dd'));
                            $('#ShipDate').val(new Date(removeCN(data.ShipDate)).Formats('yyyy-MM-dd'));
                            if (data.IsStandard == "True") {
                                $('#IsStandard').val("是")
                            } else {
                                $('#IsStandard').val("否")
                            }
                            if (data.IsOutsourcing == "True") {
                                $('#IsOutsourcing').val("是")
                            } else {
                                $('#IsOutsourcing').val("否")
                            }
                            if (('P,F,I,O').indexOf(data.Status) < 0) {
                                $('#ManufactureDate').val("未开始");
                            }
                            else {
                                $('#ManufactureDate').val(new Date(removeCN(data.ManufactureDate)).Formats('yyyy-MM-dd'));
                            }
                        });
                    }
                });

                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=GetCabinets&' + jsNC(),
                    data: { OrderID: orderid },
                    datatype: "json",
                    success: function (data) {
                        if (data) {
                            $('#cabinets').append("<li class='item active'>全部</li>");
                            $.each(data.rows, function (index, row) {
                                $('#cabinets').append("<li class='item'>" + row.CabinetName + "</li>");
                            });
                        }
                    }
                });
                
                ordersdetailForm.controls.dgorder.datagrid({
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

                ordersdetailForm.controls.dgdetail.datagrid({
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
                    { field: 'MaterialType', title: '材质颜色', width: 100, sortable: false, align: 'center' },
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
                       { text: '外购清单', iconCls: 'icon-add', handler: ordersdetailForm.events.PurchaseMaterials },
                       { text: '二次加工清单', iconCls: 'icon-add', handler: ordersdetailForm.events.FactoryMaterials },
                       { text: '部件清单(薄板)', iconCls: 'icon-add', handler: ordersdetailForm.events.rptOrderDetails_9mm },
                       { text: '部件清单(厚板)', iconCls: 'icon-add', handler: ordersdetailForm.events.rptOrderDetails }
                    ],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = $('#OrderID').val();// orderid;
                        param['CabinetNum'] = $('#CabinetNum').val();
                    }
                });

                ordersdetailForm.controls.dgHardware.datagrid({
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
                          { text: '五金料单', iconCls: 'icon-add', handler: ordersdetailForm.events.hardwareReport }
                    ],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = orderid;
                        param['CabinetName'] = $('#CabinetNum').val();
                    }
                });


                ordersdetailForm.controls.dgDrawing.datagrid({
                    idField: "FileID",
                    url: '/ashx/ordershandler.ashx?Method=SearchOrderProcessFiles&FileType=DrawingFile&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,
                    pageSize: 20,
                    columns: [[
                        { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                        { field: 'FileType', title: '文件类型', hidden: true, width: 150, sortable: false, align: 'center' },
                        { field: 'FileName', title: '文件名称', width: 150, sortable: false, align: 'center' },
                        { field: 'Created', title: '上传时间', width: 150, sortable: false, align: 'center' },
                        {
                            field: 'op', title: '操作', width: 90, sortable: false, align: 'center',
                            formatter: function (value, rowData, rowIndex) {
                                var str = '<img style="cursor:pointer;" onclick="downloadfile(\'' + rowData.FileID + '\')" src="/Content/images/exticons/page/page_white_put.png" alt="下载文件"/>&nbsp;&nbsp;';
                                return str;
                            }
                        }
                    ]],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = orderid;
                        param['CabinetName'] = $('#CabinetNum').val();
                    }
                });

                //加工生产文件
                ordersdetailForm.controls.dgProcessFile.datagrid({
                    idField: "FileID",
                    url: '/ashx/ordershandler.ashx?Method=SearchOrderProcessFiles&FileType=CSV,XML,CNC',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,
                    pageSize: 20,
                    columns: [[
                        { field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center' },
                        { field: 'FileType', title: '文件类型', hidden: true, width: 150, sortable: false, align: 'center' },
                        { field: 'FileName', title: '文件名称', width: 150, sortable: false, align: 'center' },
                        { field: 'Created', title: '上传时间', width: 150, sortable: false, align: 'center' }
                    ]],
                    toolbar: [
                       { text: '下载', iconCls: 'icon-add', handler: ordersdetailForm.events.downLoadProcessfile},
                    ],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = orderid;
                        param['CabinetName'] = $('#CabinetNum').val();
                    }
                });

                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=SearchOrderProcessFiles&' + jsNC(),
                    collapsible: false,
                    fitColumns: false,
                    striped: false,   //设置为true将交替显示行背景。 
                    data: { FileType: 'RenderingFile', OrderID: orderid },
                    datatype: "json",
                    success: function (data) {
                        if (data.isOk == 0) {
                            return;
                        }
                        $('#list').html('');
                        $.each(data.rows, function (index, row) {
                            $('#list').append("<li style='width:480px;height:320px; float:left; border:1px solid #eee;padding:5px;text-align:center;'><div style='width:480px;height:320px;'><img src='/ashx/download_file.ashx?fid=" + row.FileID + "' style='max-width:480px;width:480px auto;max-height:320px;height:320px auto;' alt=''/><br/><span>" + row.FileName + "</span></div></li>");
                        });
                    }
                });
            },
            //添加移门数据
            loadDoors: function () {
                var orderid = getUrlParam('orderid');
                if (orderid.length == 0) return;
                $('#OrderID').val(orderid);

                ordersdetailForm.controls.dgDoors.datagrid({
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
                        { text: '增加', iconCls: 'icon-add', handler: ordersdetailForm.events.addrow },
                        {
                            text: '取消', iconCls: 'icon-cancel', handler: ordersdetailForm.events.cancelall,
                        },
                        {
                            text: '提交数据', iconCls: 'icon-save', handler: ordersdetailForm.events.SaveDoors,
                        },
                    ],
                    onBeforeLoad: function (param) {
                        param['OrderID'] = orderid;                       
                    },
                    onClickCell: ordersdetailForm.events.onClickCell,
                    onEndEdit: ordersdetailForm.events.onEndEdit
                });
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
            addrow: function () {
                if (ordersdetailForm.events.endEditing()) {
                    ordersdetailForm.controls.dgDoors.datagrid('appendRow',
                        {
                            DoorID:ordersdetailForm.events.loadNewGuid(),
                            CabinetID: CabinetID,
                            CabinetName:"请选择...",
                            DoorName: '左移门',
                            DoorSize: '1600*1200*600',                          
                            Qty: 1,
                          
                        });
                    editIndex = ordersdetailForm.controls.dgDoors.datagrid('getRows').length - 1;
                    ordersdetailForm.controls.dgDoors.datagrid('selectRow', editIndex)
                            .datagrid('beginEdit', editIndex);
                }
            },
            endEditing: function () {
                if (editIndex == undefined) { return true }
                if (ordersdetailForm.controls.dgDoors.datagrid('validateRow', editIndex)) {
                    ordersdetailForm.controls.dgDoors.datagrid('endEdit', editIndex);
                    if (!ordersdetailForm.events.isRepeartRow()) {
                        editIndex = undefined;
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return false;
                }
            },
            isRepeartRow: function () {
                var rows = ordersdetailForm.controls.dgDoors.datagrid('getRows');
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].CabinetID == rows[j].CabinetID  ) {
                            if (rows[i].DoorName == rows[j].DoorName) {
                                showError("产品【" + rows[i].CabinetName + "】的【" + rows[i].DoorName + "】重复添加");
                                return false;
                            }
                        }
                    }
                }
                return false;
            },
            //取消所有行
            cancelall: function () {
                ordersdetailForm.controls.dgDoors.datagrid('rejectChanges');
            },
            onClickCell: function (index, field) {
                if (editIndex != index) {
                    if (ordersdetailForm.events.endEditing()) {
                        ordersdetailForm.controls.dgDoors.datagrid('selectRow', index)
                                .datagrid('beginEdit', index);
                        var ed = ordersdetailForm.controls.dgDoors.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }
                        editIndex = index;
                    } else {
                        setTimeout(function () {
                            ordersdetailForm.controls.dgDoors.datagrid('selectRow', editIndex);
                        }, 0);
                    }
                }
            },
            onEndEdit: function (index, row) {
                var ed = $(this).datagrid('getEditor', {
                    index: index,
                    field: 'CabinetName'
                });
                row.CabinetName = $(ed.target).combobox('getText');
                row.CabinetID = CabinetID;
            },
            SaveDoors:function()
            {
                if (ordersdetailForm.events.endEditing()) {
                    ordersdetailForm.controls.dgDoors.datagrid('acceptChanges');
                }
                var rows = ordersdetailForm.controls.dgDoors.datagrid('getRows');
                var kv = [];
                if (rows.length == 0) {
                    showError("最少需要添加一个产品的移门数据。");
                    return;
                }

                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].Qty == 0) {
                        showError("产品数量不能为0");
                        return;
                    }
                    if (rows[i].CabinetName == "请选择..." || rows[i].CabinetName == null) {
                        i = i + 1;
                        showError("第" + i + "行未选择订单产品");                         
                        return false;
                    }
                    kv.push({
                        DoorID: rows[i].DoorID, CabinetID: rows[i].CabinetID, DoorName: rows[i].DoorName, DoorSize: rows[i].DoorSize,
                         Qty: rows[i].Qty, Remark: rows[i].Remark
                    });
                }

                //序列化对象为Json字符串
                //var sd = JSON.stringify(kv);
                var sd = encodeURI(JSON.stringify(kv));
                $('#Doors').val(sd);

                $.ajax({
                    type: "POST",
                    url: '/ashx/ordershandler.ashx?Method=SaveDoors' ,
                    data: { Doors: $('#Doors').val(), OrderID: $('#OrderID').val() },
                    datatype:'json',
                    success: function (returnData) {                        
                        if (returnData.isOk == 0) {
                            showError(returnData.message);
                        }
                        else {
                            showInfo(returnData.message);
                            //ordersdetailForm.events.cleardata();
                            ordersdetailForm.controls.dgDoors.datagrid('reload');
                        }
                    }

                }); 
            },
            cleardata: function () {
                //ordersdetailForm.controls.dgDoors.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
               
            },
            reload: function () {
                ordersdetailForm.controls.dgdetail.datagrid('reload');
                ordersdetailForm.controls.dgHardware.datagrid('reload');
                ordersdetailForm.controls.dgDrawing.datagrid('reload');
                ordersdetailForm.controls.dgProcessFile.datagrid('reload');
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

                ordersdetailForm.controls.review_window.window('open');
                $('#Remark').val(''); //清空textarea
            },
            downLoadProcessfile: function () {
                $.messager.confirm('系统提示', '确定要下载此文件吗？', function (flag) {
                    if (flag) {
                        var form = $("<form>");   //定义一个form表单
                        form.attr('style', 'display:none');   //在form表单中添加查询参数
                        form.attr('target', '');
                        form.attr('method', 'post');
                        //form.attr('action',"/ashx/OrdersHandler.ashx?Method=DownloadOutFile");
                        form.attr('action', "/View/download/download_ProcessFile.aspx");
                        var down = $('<input>');
                        down.attr('type', 'hidden');
                        down.attr('name', 'OrderID');
                        down.attr('value', $('#OrderID').val());
                        $('body').append(form);  //将表单放置在web中 
                        form.append(down);   //将查询参数控件提交到表单上
                        form.submit();
                    }
                });
            },
            hardwareReport: function () {
                top.addTab("查看五金报表", "/View/reports/HardWareReportView.aspx?ReportPath=/MES/Report/rptHartWareReport&H_OrderNo=" + $('#H_OrderNo').val(), "table");
            },
            PurchaseMaterials: function () {
                top.addTab("外购清单", "/View/reports/frmReportView.aspx?ReportPath=/MES/Report/rptPurchase&OrderID=" + $('#OrderID').val(), "table");
            },
            FactoryMaterials: function () {
                top.addTab("二次加工清单", "/View/reports/frmReportView.aspx?ReportPath=/MES/Report/rptFactory&OrderID=" + $('#OrderID').val(), "table");
            },
            rptOrderDetails_9mm: function () {
                top.addTab("部件清单(薄)", "/View/reports/frmReportView.aspx?ReportPath=/MES/Report/rptOrderDetails_9mm&OrderID=" + $('#OrderID').val(), "table");
            },
            rptOrderDetails: function () {
                top.addTab("部件清单(厚)", "/View/reports/frmReportView.aspx?ReportPath=/MES/Report/rptOrderDetails&OrderID=" + $('#OrderID').val(), "table");
            },
            StorageMaterials: function () {
                top.addTab("查看库存件报表", "/View/reports/StorageMaterials.aspx?ReportPath=/MES/Report/rptStorageMaterials&H_OrderNo=" + $('#H_OrderNo').val(), "table");
            },
            StockListing: function () {
                top.addTab("查看备料清单", "/View/reports/StorageMaterials.aspx?ReportPath=/MES/Report/rptStockListingReport&H_OrderNo=" + $('#H_OrderNo').val(), "table");
            },
            SlidingDoor: function () {
                top.addTab("查看移门清单", "/View/reports/StorageMaterials.aspx?ReportPath=/MES/Report/rptSlidingDoor&H_OrderNo=" + $('#H_OrderNo').val(), "table");
            },
            //审核提交
            revieworder_submit: function () {
                if (ordersdetailForm.controls.review_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/ordershandler.ashx?Method=ReviewOrder',
                        data: { OrderID: $("#OrderID").val(),Remark:$('#option_remark').val()},
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    $.messager.alert("提示","审核成功", "info", function () {
                                        ordersdetailForm.controls.review_window.window('close');
                                        var pid = getUrlParam('OrdersManagerPid');
                                        top.addTab("订单审核", "/View/orders/ordersmanager.aspx?pid=" + pid, 'table');
                                        window.parent.closeTab();                                       
                                    });                                   
                                }
                            }
                        }
                    });
                }
            },
            //审核拒绝
            review_reject: function () {                
                if (ordersdetailForm.controls.review_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/ordershandler.ashx?Method=RejectOrder',
                        data: { OrderID: $("#OrderID").val(), Remark: $('#option_remark').val() },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    $.messager.alert("提示", "操作成功", "info", function () {
                                        ordersdetailForm.controls.review_window.window('close');
                                        var pid = getUrlParam('OrdersManagerPid');
                                        top.addTab("订单审核", "/View/orders/ordersmanager.aspx?pid=" + pid, 'table');
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
        ordersdetailForm.init();
    });

//})(jQuery);


function cancelrow(id,index) {
        if (ordersdetailForm.events.endEditing()) {
            if (index == undefined) { return }
            $('#dgdoors').datagrid('deleteRow', index);
            var rows = $('#dgdoors').datagrid("getRows");
            $('#dgdoors').datagrid("loadData", rows);
            index = undefined;
        }
        $.ajax({
            url: '/ashx/ordershandler.ashx?Method=DeleteByDoorID&' + jsNC(),
            data: { DoorID: id },
            datatype: "json",
            success: function (data) {
                if (data.isOk == 0) {

                }
                else {

                }
            }
        });
    }

function downloadfile() {
    var fileid = arguments[0];
    $.messager.confirm('系统提示', '确定要下载此文件吗？', function (flag) {
        if (flag) {
            var form = $("<form>");   //定义一个form表单
            form.attr('style', 'display:none');   //在form表单中添加查询参数
            form.attr('target', '');
            form.attr('method', 'post');
            form.attr('action', "/View/download/download_DrawingFile.aspx");
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



