//'use strict';
(function ($) {
    document.msCapsLockWarningOff = true;
    var editIndex = undefined;
    var hardwares_editIndex = undefined;
    var comboMaterial = undefined;
    var HardwareName = "";
    var ItemStyle = "";
    var Price = "";
    var Unit = "";
    var doors_editIndex = undefined;
    var others_editIndex = undefined;
    var newquoteForm = {
        init: function () {
            newquoteForm.initControls();
            newquoteForm.initevents();
            newquoteForm.controls.SolutionID = getUrlParam('SolutionID');
            //newquoteForm.controls.Status = getUrlParam('Status');
            newquoteForm.events.initCustomer();
            newquoteForm.events.loadDetails();//加载数据     
            newquoteForm.events.loadHardwares();//加载数据     
            newquoteForm.events.loadDoors();//加载数据     
            newquoteForm.events.loadOthers();//加载数据  
            newquoteForm.events.loadComboboxMaterial();//加载数据
            newquoteForm.controls.saveorder.on('click', newquoteForm.events.saveorder);//保存    
            newquoteForm.controls.search_material.on('click', newquoteForm.events.searchMaterial);//材料      
        },
        initControls: function () {
            newquoteForm.controls = {
                dgdetail: $('#dgdetail'),
                dghardware: $('#dghardware'),
                dgdoors: $('#dgdoors'),
                dgohers: $('#dgohers'),
                edit_form: $('#edit_form'),
                saveorder: $('#btn_edit_save'),
                SolutionID: null,
                //Status: null,
                search_material: $("#btn_form_material"),
                upload_window: $('#upload_window'),
                upload_form: $('#upload_form'),
                uploadfile: $('#btn_upload_splitfile'),
            }

            var mydate = new Date();
            var yy = mydate.getFullYear();
            var mm = mydate.getMonth() + 1;
            var dd = mydate.getDate();
            var NowDay = yy + '-' + (mm < 10 ? ('0' + mm) : mm) + '-' + (dd < 10 ? ('0' + dd) : dd);

            //失效时期
            $('#ExpiryDate').datebox({
                onSelect: function (date) {
                    var y = date.getFullYear();
                    var m = date.getMonth() + 1;
                    var d = date.getDate();
                    var SelectDay = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                    if (SelectDay == NowDay || SelectDay < NowDay) {
                        showError("失效时期必须大于 今天 请重新选择！");
                        $("#ExpiryDate").datebox("setValue", '');
                    }
                }
            });

            $('#btn_form_material').linkbutton();

            //隐藏搜索页面
            $('#tbMaterial').find('form[id="search_form_material"]').css('display', 'none');
        },
        initevents: function () {
            newquoteForm.controls.uploadfile.on('click', newquoteForm.events.open_uploadwindow);

            //solutionForm.controls.close_uploadwindow.on('click', solutionForm.events.close_uploadwindow);
            //solutionForm.controls.fileupload_submit.on('click', solutionForm.events.fileupload_submit);
            //solutionForm.controls.btn_quote.on('click', solutionForm.events.quote);

            $("#solution_uploadify").uploadify({
                width: 307,
                height: 30,
                uploader: '/ashx/solutionhandler.ashx?Method=FileUpload',
                swf: '/Script/uploadify/uploadify.swf',
                queueSizeLimit: 6,
                checkExisting: '/ashx/solutionhandler.ashx?Method=CheckFileExists',
                buttonText: '点击上传文件',
                fileSizeLimit: '300MB',
                auto: true,
                multi: true,
                fileTypeExts: '*.skp; *.xml;',
                fileDesc: '只能选择格式 (.skp, .xml)文件',
                queueID: 'Solution_queue',
                onQueueComplete: function (event, data) {
                    if (event.errorMsg != '' || event.errorMsg != undefined) return;
                    solutionForm.events.close_uploadwindow();
                },
                onUploadSuccess: function (file, data, response) {
                    if (data.file_url == undefined && data != undefined) {
                        data = eval('(' + data + ')');
                    }
                    if (data.isOk == 0) {
                        showError(data.message);
                    }
                    else {
                        solutionForm.controls.dgcabinet.datagrid('reload');
                        $('#SolutionFileUrl').val(data.file_url);
                        $("#imgSolution").attr('src', "/Content/images/upload_success.png");
                    }
                },
                onUploadStart: function (file) {
                    $("#solution_uploadify").uploadify("settings", "formData", { SolutionID: $("#SolutionID").val(), CabinetID: $('#CabinetID').val(), FileType: 'SolutionFile' });
                },
                onUploadError: function (event, queueId, fileObj, errorObj) {
                    //$("#solution_uploadify").attr('disable', false);
                    showInfo(errorObj.type + "：" + errorObj.info);
                }
            });

            $('#imgSolution').on('click', function () {
                //$('#solution_uploadify').uploadify('upload', '*');          
            });
        },
        events: {
            initCustomer: function () {
                $.ajax({
                    url: '/ashx/quotehandler.ashx?Method=GetCustomer&' + jsNC(),
                    data: { SolutionID: newquoteForm.controls.SolutionID},
                    datatype: "json",
                    success: function (data) {
                        if (data) {
                            newquoteForm.controls.edit_form.form('load', data);
                        }
                    }
                });
            },

            //部件  
            loadDetails: function () {
                var TotalAmount = 0;
                var SolutionID = getUrlParam('SolutionID');
                newquoteForm.controls.dgdetail.datagrid({
                    url: '/ashx/quotehandler.ashx?Method=SearchSolutionQuoteDetail',
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: true,
                    pagination: false,
                    showFooter: true,
                    columns: [[
                    { field: 'DetailID', title: '明细ID', hidden: true, width: 200, sortable: false, align: 'center' },
                    {
                        field: 'ItemName', title: '部件名称', width: 150, sortable: false, align: 'center',
                        //editor: {
                        //    type: 'textbox',
                        //    options: {
                        //        required: true
                        //    }
                        //}
                    },
                    { field: 'MaterialName', title: '材质颜色', width: 120, sortable: false, align: 'center' },
                    {
                        field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center',
                        formatter: function (value, row, index) {
                            if (value == undefined || value == null) {
                                return '块';
                            }
                            else
                                return value;
                        }
                    },
                    {
                        field: 'TotalQty', title: '板件数量', width: 100, sortable: false, align: 'center',
                        //editor: {
                        //    type: 'numberbox',
                        //    options: {
                        //        required: true
                        //    }
                        //}
                    },
                    {
                        field: 'TotalAreal', title: '用料面积', width: 100, sortable: false, align: 'center',
                        //editor: {
                        //    type: 'numberbox',
                        //    options: {
                        //        required: true
                        //    }
                        //}
                    },
                    {
                        field: 'QuotedPrice', title: '单价', width: 120, sortable: false, align: 'center',
                        //editor: {
                        //    type: 'numberbox',
                        //    options: {
                        //        required: true
                        //    }
                        //}
                    },
                    {
                        field: 'Amount', title: '金额', width: 120, sortable: false, halign: 'center', align: 'right',
                        formatter: function (value, row, index) {
                            if (!isNaN(parseFloat(value))) {
                                TotalAmount += parseFloat(value)
                                return '<font color="red">￥' + value + '</font>'

                            }
                            else
                                return value;
                        }
                    },
                    {
                        field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center',
                        editor: {
                            type: 'textbox',
                            options: {
                                //required: true
                            }
                        }
                    }
                    ]],
                    groupField: 'CabinetName',
                    view: groupview,
                    groupFormatter: function (value, rows) {
                        return value + ' - ' + rows.length + ' Item(s)';
                    },
                    onBeforeLoad: function (param) {
                        param['SolutionID'] = newquoteForm.controls.SolutionID;
                    },
                    onLoadSuccess: function (data) {
                        //统计板件金额
                        newquoteForm.controls.dgdetail.datagrid('reloadFooter', [{ 'Unit': '', 'QuotedPrice': '金额合计：', 'Amount': '<font color="red">￥' + TotalAmount.toFixed(2) + '</font>' }]);
                    },
                    onClickCell: newquoteForm.events.onClickCell,//后期注释
                    onEndEdit: newquoteForm.events.onEndEdit//后期注释
                });
            },
            //五金
            loadHardwares: function () {
                var TotalAmount = 0;
                newquoteForm.controls.dghardware.datagrid({
                    url: '/ashx/quotehandler.ashx?Method=SearchSolutionQuoteHardwareDetail',
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: true,
                    pagination: false,
                    showFooter: true,
                    columns: [[
                    { field: 'DetailID', title: '明细ID', hidden: true, width: 200, sortable: false, align: 'center' },
                    {
                        field: 'HardwareName', title: '五金名称', width: 150, sortable: false, align: 'center', editor: {
                            type: 'combogrid',
                            options: {
                                panelWidth: 740,
                                panelHeight: 350,
                                idField: 'MaterialID',
                                textField: 'MaterialName',
                                fitColumns: true,
                                sortName: 'MaterialID',
                                toolbar: '#tbMaterial',
                                url: '/ashx/materialhandler.ashx?Method=SearchMaterials',
                                pagination: true,
                                editable: false,
                                nowrap: false,
                                required: true,
                                columns: [[
                                        { field: 'MaterialID', title: 'ID', hidden: true },
                                        { field: 'MaterialCode', title: '五金编号', width: 150, sortable: false, align: 'center' },
                                        { field: 'Category', title: '材料类型', width: 150, halign: 'center', align: 'center' },
                                        { field: 'MaterialName', title: '名称', width: 150, align: 'center' },
                                        { field: 'Style', title: '型号/款式', width: 150, sortable: false, align: 'center' },
                                        { field: 'Unit', title: '单位', width: 100, hidden: false, sortable: false, align: 'center' },
                                        { field: 'QuotedPrice', title: '价格', width: 150, sortable: false, align: 'center' },
                                ]],
                                onShowPanel: function () {
                                    comboMaterial = this;
                                },
                                onBeforeLoad: function (param) {
                                    param['Category'] = '五金';
                                    $('#search_form_material').find('input').each(function (index) {
                                        param[this.name] = $(this).val();
                                    });
                                },
                                onSelect: function (index, row) {
                                    HardwareName = row.MaterialName;
                                    ItemStyle = row.Style;
                                    Price = row.Price;
                                    Unit = row.Unit;
                                }
                            }
                        }
                    },
                    {
                        field: 'Style', title: '规格型号', width: 120, sortable: false, align: 'center'
                    },
                    {
                        field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center'
                    },
                    {
                        field: 'TotalQty', title: '数量', width: 60, sortable: false, align: 'center'
                    },
                    {
                        field: 'QuotedPrice', title: '单价', width: 100, sortable: false, align: 'center'
                    },
                    {
                        field: 'Amount', title: '金额', width: 120, sortable: false, align: 'center',
                        formatter: function (value, row, index) {
                            if (!isNaN(parseFloat(value))) {
                                TotalAmount += parseFloat(value)
                                return '<font color="red">￥' + value + '</font>'

                            }
                            else
                                return value;
                        }
                    },
                    {
                        field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center',
                        editor: {
                            type: 'textbox',
                            options: {
                                //required: true
                            }
                        }
                    }
                    //{
                    //    field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                    //    formatter: function (value, row, index) {
                    //        var str = '<a href="#" onclick="hardwares_cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                    //        return str;
                    //    }
                    //}
                    ]],
                    toolbar: [
                        { text: '增加', iconCls: 'icon-add', handler: newquoteForm.events.hardware_addRow },
                        {
                            text: '取消', iconCls: 'icon-cancel', handler: function () {
                                newquoteForm.events.cancelall(newquoteForm.controls.dghardware);
                            }
                        }
                    ],
                    onBeforeLoad: function (param) {
                        param['SolutionID'] = newquoteForm.controls.SolutionID;
                    },
                    onLoadSuccess: function (data) {
                        //统计板件金额
                        newquoteForm.controls.dghardware.datagrid('reloadFooter', [{ 'Unit': '', 'QuotedPrice': '金额合计：', 'Amount': '<font color="red">￥' + TotalAmount.toFixed(2) + '</font>' }]);
                    },
                    onClickCell: newquoteForm.events.hardware_onClickCell,
                    onEndEdit: newquoteForm.events.hardware_onEndEdit
                });
            },
            //移门
            loadDoors: function () {
                newquoteForm.controls.dgdoors.datagrid({
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: true,
                    pagination: false,
                    columns: [[
                    { field: 'DetailID', title: '明细ID', hidden: true, width: 200, sortable: false, align: 'center' },
                    {
                        field: 'ItemName', title: '移门名称', width: 150, sortable: false, align: 'center',
                        editor: {
                            type: 'combobox',
                            options: {
                                valueField: 'text',
                                textField: 'value',
                                data: [
                                   { "text": "移门", "value": "移门" },
                                   { "text": "左移门", "value": "左移门" },
                                   { "text": "中移门", "value": "中移门" },
                                   { "text": "右移门", "value": "右移门" }
                                ],
                                required: true
                            }
                        }
                    },
                    {
                        field: 'ItemStyle', title: '规格型号', width: 120, sortable: false, align: 'center',
                        editor: {
                            type: 'textbox',
                            options: {
                                required: true
                            }
                        }
                    },
                    {
                        field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center',
                        editor: {
                            type: 'textbox',
                            options: {
                                required: true
                            }
                        }
                    },
                    {
                        field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center',
                        editor: {
                            type: 'numberbox',
                            options: {
                                required: true,
                                precision: 2
                            }
                        }
                    },
                    {
                        field: 'Price', title: '单价', width: 80, sortable: false, align: 'center',
                        editor: {
                            type: 'numberbox',
                            options: {
                                required: true,
                                min: 0
                            }
                        }
                    },
                    //{ field: 'Amount', title: '小计', width: 80, align: 'center' },
                    {
                        field: 'Remark', title: '备注', width: 120, sortable: false, align: 'center',
                        editor: {
                            type: 'textbox',
                            options: {
                                //required: true
                            }
                        }
                    },
                    {
                        field: 'action', title: '<span iconCls="icon-add"></span>操作', width: 100, align: 'center',
                        formatter: function (value, row, index) {
                            var str = '<a href="#" onclick="doors_cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                            return str;
                        }
                    }
                    ]],
                    toolbar: [
                        { text: '增加', iconCls: 'icon-add', handler: newquoteForm.events.doors__addRow },
                        {
                            text: '取消', iconCls: 'icon-cancel', handler: function () {
                                newquoteForm.events.cancelall(newquoteForm.controls.dgdoors);
                            }
                        }
                    ],
                    onClickCell: newquoteForm.events.doors_onClickCell,
                    onEndEdit: newquoteForm.events.doors_onEndEdit
                });
            },
            //其他
            loadOthers: function () {
                newquoteForm.controls.dgohers.datagrid({
                    idField: 'DetailID',
                    collapsible: false,
                    singleSelect: true,
                    pageSize: 20,
                    fitColumns: true,
                    pagination: false,
                    columns: [[
                    { field: 'DetailID', title: '明细ID', hidden: true, width: 200, sortable: false, align: 'center' },
                    {
                        field: 'ItemName', title: '项目名称', width: 150, sortable: false, align: 'center', editor: {
                            type: 'textbox',
                            options: {
                                required: true
                            }
                        }
                    },
                    {
                        field: 'ItemStyle', title: '项目说明', width: 120, sortable: false, align: 'center', editor: {
                            type: 'textbox',
                            options: {
                                required: true
                            }
                        }
                    },
                    {
                        field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center',
                        editor: {
                            type: 'combobox',
                            options: {
                                required: true,
                                valueField: 'CategoryName',
                                textField: 'CategoryName',
                                method: 'get',
                                url: '/ashx/categoryhandler.ashx?Method=GetUnitCategory'
                            }
                        }
                    },
                    {
                        field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center',
                        editor: {
                            type: 'numberbox',
                            options: {
                                required: true,
                                precision: 2
                            }
                        }
                    },
                    {
                        field: 'Price', title: '单价', width: 80, sortable: false, align: 'center', editor: {
                            type: 'numberbox',
                            options: {
                                required: true,
                                min: 0
                            }
                        }
                    },
                    //{ field: 'Amount', title: '小计', width: 80, align: 'center' },
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

                            var str = '<a href="#" onclick="orthers_cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                            return str;
                        }
                    }
                    ]],
                    toolbar: [
                        { text: '增加', iconCls: 'icon-add', handler: newquoteForm.events.others_addRow },
                        {
                            text: '取消', iconCls: 'icon-cancel', handler: function () {
                                newquoteForm.events.cancelall(newquoteForm.controls.dgohers);
                            }
                        },
                    ],
                    onClickCell: newquoteForm.events.others_onClickCell,
                    onEndEdit: newquoteForm.events.others__onEndEdit
                });
            },

            //材料类型联动子类
            loadComboboxMaterial: function () {
                $('#SearchCategoryID').combobox({
                    url: '/ashx/materialhandler.ashx?Method=GetCategories',
                    textField: 'CategoryName',
                    valueField: 'CategoryName',
                    onSelect: function (record) {
                        $('#SearchSubCategoryID').combobox({
                            url: '/ashx/materialhandler.ashx?Method=GetSubCategories&id=' + record.CategoryID,
                            textField: 'CategoryName',
                            valueField: 'CategoryName'
                        });
                    }
                });
            },

            //部件
            addrow: function () {
                if (newquoteForm.events.endEditing()) {
                    newquoteForm.controls.dgdetail.datagrid('appendRow',
                    {
                        ItemName: "",
                        ItemStyle: "颗粒板",
                        Unit: "",
                        TotalQty: "",
                        TotalAreal: "",
                        Price: "",
                        Amount: "",
                        Remark: ""
                    });
                    editIndex = newquoteForm.controls.dgdetail.datagrid('getRows').length - 1;
                    newquoteForm.controls.dgdetail.datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
                }
            },
            endEditing: function () {
                if (editIndex == undefined) { return true }
                if (newquoteForm.controls.dgdetail.datagrid('validateRow', editIndex)) {
                    newquoteForm.controls.dgdetail.datagrid('endEdit', editIndex);
                    if (!newquoteForm.events.isRepeartRow()) {
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
                //var rows = newquoteForm.controls.dgdetail.datagrid('getRows');
                return false;
            },
            onClickCell: function (index, field) {
                if (editIndex != index) {
                    if (newquoteForm.events.endEditing()) {
                        newquoteForm.controls.dgdetail.datagrid('selectRow', index).datagrid('beginEdit', index);
                        var ed = newquoteForm.controls.dgdetail.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }
                        editIndex = index;
                    } else {
                        setTimeout(function () {
                            newquoteForm.controls.dgdetail.datagrid('selectRow', editIndex);
                        }, 0);
                    }
                }
            },
            onEndEdit: function (index, row) {
                var ed = $(this).datagrid('getEditor', {
                    index: index,
                    field: 'ItemStyle'
                });
                //row.ItemStyle = $(ed.target).combobox('getText');
                //row.Amount = (row.TotalAreal * row.Price).toFixed(2);
            },

            //五金
            hardware_isRepeartRow: function () {
                var rows = newquoteForm.controls.dghardware.datagrid("getRows");
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length ; j++) {
                        if (rows[i].HardwareName == rows[j].HardwareName) {
                            showError("产品名称【" + rows[j].HardwareName + "】重复添加。");
                            return true;
                        }
                    }
                }
                return false;
            },
            hardware_endEditing: function () {
                if (hardwares_editIndex == undefined) { return true; }
                if (newquoteForm.controls.dghardware.datagrid("validateRow", hardwares_editIndex)) {
                    newquoteForm.controls.dghardware.datagrid("endEdit", hardwares_editIndex);
                    if (!newquoteForm.events.hardware_isRepeartRow()) {
                        hardwares_editIndex = undefined;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            },
            hardware_onClickCell: function (index, field) {
                if (hardwares_editIndex != index) {
                    if (newquoteForm.events.hardware_endEditing()) {
                        newquoteForm.controls.dghardware.datagrid("selectRow", index).datagrid("beginEdit", index);
                        var ed = newquoteForm.controls.dghardware.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }
                        hardwares_editIndex = index;
                    } else {
                        setTimeout(function () {
                            newquoteForm.controls.dghardware.datagrid("selectRow", hardwares_editIndex);
                        }, 0);
                    }
                }
                $('#tbMaterial').find('form[id="search_form_material"]').css('display', 'block');
            },
            hardware_onEndEdit: function (index, row) {
                var ed = $(this).datagrid('getEditor', {
                    index: index,
                    field: 'Unit'
                });
                if (HardwareName != "") {
                    row.HardwareName = HardwareName;
                }
                if (ItemStyle != "") {
                    row.ItemStyle = ItemStyle;
                }
                if (Price != "") {
                    row.Price = Price;
                }
                if (Unit != "") {
                    row.Unit = Unit;
                }
                newquoteForm.controls.dghardware.datagrid("refreshRow", index);
                HardwareName = "";
                ItemStyle = "";
                Price = "";
                Unit = "";
                //row.Unit = $(ed.target).combobox('getText');
                //row.Amount = (row.RowNumber * row.TotalQty).toFixed(2);          
            },
            hardware_addRow: function () {
                if (newquoteForm.events.hardware_endEditing()) {
                    newquoteForm.controls.dghardware.datagrid("appendRow", {
                        HardwareName: "",
                        ItemStyle: "",
                        Unit: "",
                        TotalQty: "1.00",
                        RowNumber: "0.00",//要修改
                        Amount: "",
                        Remark: "",
                    });
                    hardwares_editIndex = newquoteForm.controls.dghardware.datagrid('getRows').length - 1;
                    newquoteForm.controls.dghardware.datagrid("selectRow", hardwares_editIndex).datagrid("beginEdit", hardwares_editIndex);
                }
                //打开搜索页面
                $('#tbMaterial').find('form[id="search_form_material"]').css('display', 'block');
            },

            //移门 
            doors_isRepeartRow: function () {
                var rows = newquoteForm.controls.dgdoors.datagrid("getRows");
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length ; j++) {
                        if (rows[i].ItemName == rows[j].ItemName) {
                            showError("产品名称【" + rows[j].ItemName + "】重复添加。");
                            return true;
                        }
                    }
                }
                return false;
            },
            doors_onClickCell: function (index, field) {
                if (doors_editIndex != index) {
                    if (newquoteForm.events.doors_endEditing()) {
                        newquoteForm.controls.dgdoors.datagrid("selectRow", index).datagrid("beginEdit", index);
                        var ed = newquoteForm.controls.dghardware.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }
                        doors_editIndex = index;
                    } else {
                        setTimeout(function () {
                            newquoteForm.controls.dgdoors.datagrid("selectRow", doors_editIndex);
                        }, 0);
                    }
                }
            },
            doors_onEndEdit: function (index, row) {
                //row.Amount = (row.Price * row.Qty).toFixed(2);         
            },
            doors_endEditing: function () {
                if (doors_editIndex == undefined) return true;
                if (newquoteForm.controls.dgdoors.datagrid("validateRow", doors_editIndex)) {
                    newquoteForm.controls.dgdoors.datagrid("endEdit", doors_editIndex);
                    if (!newquoteForm.events.doors_isRepeartRow()) {
                        doors_editIndex = undefined;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            },
            doors__addRow: function () {
                if (newquoteForm.events.doors_endEditing()) {
                    newquoteForm.controls.dgdoors.datagrid("appendRow", {
                        ItemName: "",
                        ItemStyle: "",
                        Unit: "条",
                        Qty: "1.00",
                        Price: "",
                        Remark: ""
                    });
                    doors_editIndex = newquoteForm.controls.dgdoors.datagrid('getRows').length - 1;
                    newquoteForm.controls.dgdoors.datagrid("selectRow", doors_editIndex).datagrid("beginEdit", doors_editIndex);
                }
            },

            //其他
            others_isRepeartRow: function () {
                var rows = newquoteForm.controls.dgohers.datagrid("getRows");
                for (var i = 0; i < rows.length; i++) {
                    for (var j = i + 1; j < rows.length ; j++) {
                        if (rows[i].ItemName == rows[j].ItemName) {
                            showError("产品名称【" + rows[j].ItemName + "】重复添加。");
                            return true;
                        }
                    }
                }
                return false;
            },
            others_endEditing: function () {
                if (others_editIndex == undefined) return true;
                if (newquoteForm.controls.dgohers.datagrid("validateRow", others_editIndex)) {
                    newquoteForm.controls.dgohers.datagrid("endEdit", others_editIndex);
                    if (!newquoteForm.events.others_isRepeartRow()) {
                        others_editIndex = undefined;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            },
            others_addRow: function () {
                if (newquoteForm.events.others_endEditing()) {
                    newquoteForm.controls.dgohers.datagrid("appendRow", {
                        ItemName: "",
                        ItemStyle: "",
                        Unit: "",
                        Qty: "1.00",
                        Price: "",
                        Remark: ""
                    });
                    others_editIndex = newquoteForm.controls.dgohers.datagrid('getRows').length - 1;
                    newquoteForm.controls.dgohers.datagrid("selectRow", doors_editIndex).datagrid("beginEdit", others_editIndex);
                }
            },
            others_onClickCell: function (index, field) {
                if (others_editIndex != index) {
                    if (newquoteForm.events.others_endEditing()) {
                        newquoteForm.controls.dgohers.datagrid("selectRow", index).datagrid("beginEdit", index);
                        var ed = newquoteForm.controls.dgohers.datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }
                        others_editIndex = index;
                    } else {
                        setTimeout(function () {
                            newquoteForm.controls.dgohers.datagrid("selectRow", doors_editIndex);
                        }, 0);
                    }
                }
            },
            others__onEndEdit: function (index, row) {
                //row.Amount = (row.Price * row.Qty).toFixed(2);
            },

            //取消所有行
            cancelall: function (selector) {
                selector.datagrid('rejectChanges');
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

            //搜索
            searchCustomer: function () {
                $('#CustomerID').combogrid("grid").datagrid("reload");
            },
            searchMaterial: function () {
                if (comboMaterial != undefined) {
                    $(comboMaterial).combogrid('grid').datagrid('reload');
                }
            },

            //上传文件
            open_uploadwindow:function(){
                newquoteForm.controls.upload_window.window('open');
            },

            //保存
            saveorder: function () {
                if (!newquoteForm.controls.edit_form.form("validate")) {
                    showError("请完善信息后提交。");
                    return;
                }

                var kv = [];

                //部件
                if (newquoteForm.events.endEditing()) {
                    newquoteForm.controls.dgdetail.datagrid('acceptChanges');
                }
                var dgdetails = newquoteForm.controls.dgdetail.datagrid("getRows");
                if (dgdetails.length > 0) {
                    for (var i = 0; i < dgdetails.length; i++) {
                        var price = 0;
                        if (!isNaN(parseFloat(dgdetails[i].QuotedPrice))) {
                            price = dgdetails[i].QuotedPrice;
                        }
                        kv.push({
                            ItemGroup: "部件",
                            ItemName: dgdetails[i].ItemName,
                            ItemStyle: dgdetails[i].MaterialName,
                            Qty: dgdetails[i].TotalAreal,//使用面积
                            Price: price, //每平方价格： Price
                            ItemRemark: ''//dgdetails[i].Remark,
                        });
                    }
                }

                //五金
                if (newquoteForm.events.hardware_endEditing()) {
                    newquoteForm.controls.dghardware.datagrid("acceptChanges");
                }
                var dghardwares = newquoteForm.controls.dghardware.datagrid("getRows");
                if (dghardwares.length > 0) {
                    for (var i = 0; i < dghardwares.length ; i++) {
                        var price = 0;
                        if (!isNaN(parseFloat(dghardwares[i].QuotedPrice))) {
                            price = dghardwares[i].QuotedPrice;
                        }
                        kv.push({
                            ItemGroup: "五金",
                            ItemName: dghardwares[i].HardwareName,
                            ItemStyle: dghardwares[i].Style,
                            Qty: dghardwares[i].TotalQty,
                            Price: price,
                            ItemRemark: ''// dghardwares[i].Remark,
                        });
                    }
                }

                //移门
                if (newquoteForm.events.doors_endEditing()) {
                    newquoteForm.controls.dgdoors.datagrid("acceptChanges");
                }
                var dgdoors = newquoteForm.controls.dgdoors.datagrid("getRows");
                if (dgdoors.length > 0) {
                    for (var i = 0; i < dgdoors.length ; i++) {
                        if (dgdoors[i].Price == 0) {
                            showError(dgdoors[i].ItemName + "单价不能0");
                        }
                        kv.push({
                            ItemGroup: "移门",
                            ItemName: dgdoors[i].ItemName,
                            ItemStyle: dgdoors[i].ItemStyle,
                            Qty: dgdoors[i].Qty,
                            Price: dgdoors[i].Price,
                            ItemRemark: dgdoors[i].Remark,
                        });
                    }
                }

                //其他
                if (newquoteForm.events.others_endEditing()) {
                    newquoteForm.controls.dgohers.datagrid("acceptChanges");
                }
                var dgohers = newquoteForm.controls.dgohers.datagrid("getRows");
                if (dgohers.length > 0) {
                    for (var i = 0; i < dgohers.length ; i++) {
                        if (dgohers[i].Price == 0) {
                            showError(dgohers[i].ItemName + "单价不能0");
                            return;
                        }
                        kv.push({
                            ItemGroup: "其他",
                            ItemName: dgohers[i].ItemName,
                            ItemStyle: dgohers[i].ItemStyle,
                            Qty: dgohers[i].Qty,
                            Price: dgohers[i].Price,
                            ItemRemark: dgohers[i].Remark,
                        });
                    }
                }

                //序列化对象为Json字符串
                var sd = JSON.stringify(kv);
                $('#QuoteDetails').val(sd);
                $("#QuoteID").val(newquoteForm.events.loadNewGuid);
                $("#SolutionID").val(newquoteForm.controls.SolutionID);

                $.ajax({
                    url: "/ashx/quotehandler.ashx?Method=SaveQuote",
                    data: newquoteForm.controls.edit_form.serialize(),
                    datatype: 'json',
                    success: function (returnData) {
                        if (returnData.isOk == 1) {
                            $.messager.alert("提示", returnData.message,"info", function () {
                                top.addTab("方案管理", "/View/crm/solutions.aspx", 'table');
                                top.closeTab('方案报价');
                            });                          
                        }
                        else {
                            showError(returnData.message);
                        }
                    }
                });
            }
        }
    };

    function hardwares_cancelrow(index) {
        newquoteForm.controls.dghardware.datagrid("cancelEdit", index).datagrid('deleteRow', index);
    }

    function doors_cancelrow(index) {
        newquoteForm.controls.dgdoors.datagrid("cancelEdit", index).datagrid('deleteRow', index);
    }

    function orthers_cancelrow(index) {
        newquoteForm.controls.dgohers.datagrid("cancelEdit", index).datagrid('deleteRow', index);
    }

    $(function () {
        newquoteForm.init();
    });

})(jQuery);

function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
}

//复制行
function copyrow(index) {
    newquoteForm.controls.dgcabinet.datagrid('selectRow', index)
                         .datagrid('beginEdit', index);
    var row = $('#dgCabinet').datagrid('getSelected');
    if (newquoteForm.events.endEditing()) {
        $('#dgCabinet').datagrid('appendRow', {
            CabinetID: newquoteForm.events.loadNewGuid(),
            CabinetName: row.CabinetName,
            Size: row.Size,
            Color: row.Color,
            MaterialStyle: row.MaterialStyle,
            MaterialCategory: row.MaterialCategory,
            Unit: row.Unit,
            Remark: row.Remark,
            Qty: row.Qty,
            Price: row.Price
        });
    }
}

