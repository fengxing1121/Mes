var ArrayPath = [];//上传文件路径

(function ($) {
    document.msCapsLockWarningOff = true;
    var t = null;
    var min = 0; //分
    var sec = 0; //秒
    var hour = 0; //小时

    var partnerTaskForm = {
        init: function () {
            partnerTaskForm.initControls();
            partnerTaskForm.events.loadTask();
            partnerTaskForm.events.loadUser();
            partnerTaskForm.events.loadUploadFile();
            partnerTaskForm.events.UploadSolutionFile();
            partnerTaskForm.events.UnDoSolutionFile();
            partnerTaskForm.controls.btn_search_task.on('click', partnerTaskForm.events.searchTask);
            partnerTaskForm.controls.btn_search_partneruser.on('click', partnerTaskForm.events.searchPartnerUser);
            partnerTaskForm.controls.btn_edit_cancel.on('click', partnerTaskForm.events.cancelSaveWindow);
            partnerTaskForm.controls.btn_save_cancel.on('click', partnerTaskForm.events.cancelSolutionWindow);
            partnerTaskForm.controls.btn_edit_save.on('click', partnerTaskForm.events.saveTask);
            partnerTaskForm.controls.btn_search_customer.on('click', partnerTaskForm.events.searchCustomer);
            partnerTaskForm.controls.btn_save_solution.on('click', partnerTaskForm.events.saveSolution);
            partnerTaskForm.controls.btn_save_quote.on('click', partnerTaskForm.events.SaveQuote);
            partnerTaskForm.controls.btn_cancel_solution.on('click', partnerTaskForm.events.cancelSolution);
            partnerTaskForm.controls.btn_undo_solution.on('click', partnerTaskForm.events.UndoSolution);
            partnerTaskForm.controls.btn_show_roomdesigner.on('click', partnerTaskForm.events.ShowRoomDesignerDetail);
            partnerTaskForm.controls.cancelQuoteWindow.on('click', partnerTaskForm.events.cancelQuoteWindow);
            partnerTaskForm.controls.btn_order_save.on('click', partnerTaskForm.events.SaveOrder);
        },
        initControls: function () {
            partnerTaskForm.controls = {
                dgdetail: $('#datagrid'),
                search_form: $('#search_form'),
                save_form: $('#save_form'),
                detail_form: $('#detail_form'),
                task_detail_window: $('#task_detail_window'),
                upload_solotionfile_window: $('#upload_solotionfile_window'),
                btn_search_task: $('#btn_search_ok'),
                btn_search_partneruser: $('#btn_search_partneruser'),
                btn_search_customer: $('#btn_search_customer'),
                btn_edit_cancel: $('#btn_edit_cancel'),
                btn_edit_save: $('#btn_edit_save'),
                btn_save_cancel: $('#btn_save_cancel'),
                btn_save_solution: $('#btn_save_solution'),
                btn_cancel_solution: $('#btn_cancel_solution'),
                btn_undo_solution: $('#btn_upload_splitfile'),
                btn_show_roomdesigner: $('#btn_show_roomdesigner'),
                save_window: $('#save_window'),
                save_solution_form: $('#save_solution_form'),
                save_solution_window: $('#save_solution_window'),
                save_quote_window: $('#save_quote_window'),
                save_quote_form: $('#save_quote_form'),
                btn_save_quote: $('#btn_save_quote'),
                cancelQuoteWindow: $('#cancelQuoteWindow'),
                upload_splitfile_window: $('#upload_splitfile_window'),
                upload_splitfile_form: $('#upload_splitfile_form'),
                btn_order_save: $('#btn_order_save'),
                loading: $('#Loding_window'),
            };

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
        },
        events: {
            //Load
            loadTask: function () {
                partnerTaskForm.controls.dgdetail.datagrid({
                    //idField: 'CustomerID',
                    url: '/ashx/PartnerTaskHandler.ashx?Method=SearchPartnerTask&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    singleSelect: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                        { field: 'TaskID', hidden: true, width: 150, align: 'center' },
                        //{
                        //    field: 'TaskNo', title: '任务编号', width: 120, sortable: false, align: 'center',
                        //    formatter: function (value, row, index) {
                        //        var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="任务详情" onClick="load(\'' + row['StepName'] + '\',\'' + row['TaskID'] + '\',\'' + row['TaskNo'] + '\',\'' + row['TaskType'] + '\',\'' + row['ReferenceID'] + '\');"><span style="color:#0094ff;">' + row['TaskNo'] + '</span></a>';
                        //        return strReturn;
                        //    }
                        //},
                    {
                        field: 'DesignerNo', title: '订单编号', width: 120, sortable: false, align: 'center',
                        formatter: function (value, row, index) {
                            var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="任务详情" onClick="load(\'' + row['DesignerNo'] + '\',\'' + row['StepName'] + '\',\'' + row['TaskID'] + '\',\'' + row['TaskNo'] + '\',\'' + row['TaskType'] + '\',\'' + row['ReferenceID'] + '\',\'' + row['CustomerID'] + '\');"><span style="color:#0094ff;">' + row['DesignerNo'] + '</span></a>';
                            return strReturn;
                        }
                    },
                    { field: 'KJLDesignID', title: '酷家乐方案ID', width: 120, sortable: false, align: 'center' },
                    { field: 'PartnerName', title: '经销商门店', width: 120, sortable: false, align: 'center' },
                    { field: 'DesignerName', title: '经销商', width: 120, sortable: false, align: 'center' },
                    { field: 'CustomerName', title: '经销商客户', width: 120, sortable: false, align: 'center' },
                    { field: 'StepName', title: '下一步骤', width: 120, sortable: false, align: 'center' },
                        { field: 'StepNo', title: 'StepNo', width: 50, sortable: false, align: 'center' },
                        { field: 'Modified', title: '更新时间', width: 180, sortable: false, align: 'center' },
                        {
                            field: 'SentSplit', title: '当前状态', width: 120, sortable: false, align: 'center',
                            formatter: function (value, row, index) {
                                if (row['StepNo'] == 2) {
                                    var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="新建设计" onClick="load(\'' + row['DesignerNo'] + '\',\'新建设计\',\'' + row['TaskID'] + '\',\'' + row['TaskNo'] + '\',\'' + row['TaskType'] + '\',\'' + row['ReferenceID'] + '\',\'' + row['CustomerID'] + '\');"><span style="color:#0094ff;">新建设计</span></a>';
                                } else if (row['StepNo'] == 3) {
                                    // var strReturn = '<input type="button" style=" width: 88px; height: 28px; background: rgb(0, 148, 255); color: rgb(255, 255, 255);" id="sendSplit" value="一键拆单"  onClick="load(\'' + row['DesignerNo'] + '\',\'拆单\',\'' + row['TaskID'] + '\',\'' + row['TaskNo'] + '\',\'' + row['TaskType'] + '\',\'' + row['ReferenceID'] + '\',\'' + row['CustomerID'] + '\');"/>';
                                    var strReturn = '<a href="#" class="loda-btn" id="sendSplit" text="导入拆单文件"  onClick="load(\'' + row['DesignerNo'] + '\',\'导入\',\'' + row['TaskID'] + '\',\'' + row['TaskNo'] + '\',\'' + row['TaskType'] + '\',\'' + row['ReferenceID'] + '\',\'' + row['CustomerID'] + '\');"><span aria-hidden="true" class="loda-icon icon-upload"></span>导入拆单文件</a>';
                                } else if (row['StepNo'] == 4) {
                                    strReturn = "已导入完成";
                                } else if (row['StepNo'] == 5) {
                                    strReturn = "已生成报价明细";
                                } else if (row['StepNo'] == 6) {
                                    strReturn = "订单已提交";
                                } else if (row['StepNo'] == 7) {
                                    strReturn = "完成";
                                }
                                //var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="任务详情" onClick="load(\'' + row['StepName'] + '\',\'' + row['TaskID'] + '\',\'' + row['TaskNo'] + '\',\'' + row['TaskType'] + '\',\'' + row['ReferenceID'] + '\');"><span style="color:#0094ff;" id="SentSplit">拆 单</span></a>';
                                return strReturn;
                            }
                        },
                    ]],
                    toolbar: [
                         //{ text: '分配任务', iconCls: 'icon-add', handler: partnerTaskForm.events.assignTask},
                         //{ text: '任务详情', iconCls: 'icon-add', handler: partnerTaskForm.events.taskDetail},
                    ],
                    onBeforeLoad: function (param) {
                        partnerTaskForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                });
            },
            loadUser: function () {
                $('#UserCode').combogrid({
                    panelWidth: 600,
                    panelHeight: 400,
                    fitColumns: true,
                    toolbar: '#tb',
                    sortName: "UserCode",
                    idField: 'UserCode',
                    url: '/ashx/partnerUserHandler.ashx?Method=SearchPartnerUser',
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    textField: 'UserName',
                    columns: [[
                            { field: 'UserCode', title: '帐号', width: 80, sortable: false, align: 'center' },
                            { field: 'UserName', title: '姓名', width: 100, align: 'center' },
                            { field: 'Position', title: '职位', width: 80, sortable: false, align: 'center' },
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_partneruser').find('input').each(function (index) {
                            param[this.name] = $(this).val();
                            param["IsSystem"] = false;
                            param["IsDisabled"] = false;
                        });
                    },
                    onSelect: function (index, row) {
                        partnerTaskForm.controls.save_form.form('load', row);
                    }
                });
            },
            loadCustomer: function () {
                //$('#CustomerName').combogrid({
                //    panelWidth: 640,
                //    panelHeight: 480,
                //    idField: 'CustomerID',
                //    textField: 'CustomerName',
                //    fitColumns: true,
                //    sortName: 'CustomerID',
                //    toolbar: '#tb_customer',
                //    url: '/ashx/customerhandler.ashx?Method=SearchCustomers',
                //    pagination: true,
                //    editable: false,
                //    nowrap: false,
                //    columns: [[
                //            { field: 'CustomerName', title: '客户名称', width: 100, align: 'center' },
                //            {
                //                field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                //                    return (row.Province) + (row.City) + row.Address;
                //                }
                //            },
                //            { field: 'LinkMan', title: '联系人', width: 80, sortable: false, align: 'center' },
                //            { field: 'Mobile', title: '移动电话', width: 80, sortable: false, align: 'center' }
                //    ]],
                //    onBeforeLoad: function (param) {
                //        $('#search_form_customer').find('input').each(function (index) { param[this.name] = $(this).val(); });
                //    },
                //    onSelect: function (index, row) {
                //        $('#CustomerName').val(row.CustomerName);
                //        partnerTaskForm.controls.save_solution_form.form('load',row);
                //        $("#Address").val(row.Province + row.City + row.Address);
                //    }
                //});
            },
            loadUploadFile: function () {
                $("#solution_uploadify").uploadify({
                    width: 307,
                    height: 30,
                    uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
                    swf: '/Script/uploadify/uploadify.swf',
                    buttonText: '点击上传文件',
                    fileSizeLimit: '300MB',
                    auto: true,
                    fileTypeExts: '*.zip;',
                    fileDesc: '只能选择格式 (.zip)文件',
                    queueID: 'Solution_queue',
                    onQueueComplete: function (event, data) {
                        if (event.errorMsg != '' || event.errorMsg != undefined) return;
                        //solutionForm.events.close_uploadwindow();
                    },
                    onUploadSuccess: function (file, data, response) {
                        if (data.file_url == undefined && data != undefined) {
                            data = eval('(' + data + ')');
                        }
                        if (data.isOk == 0) {
                            showError(data.message);
                        }
                        else {
                            $('#SolutionFileUrl').val(data.file_url);
                            $("#imgSolution").attr('src', "/Content/images/upload_success.png");
                        }
                    },
                    onUploadStart: function (file) {
                        alert($("#DesignerID").val());
                        $("#solution_uploadify").uploadify("settings", "formData", { ProductID: $("#SolutionID").val(), FileType: 'SolutionFile', DesignerID: $("#DesignerID").val() });
                    },
                    onUploadError: function (file, errorCode, errorMsg, errorString) {
                        if (errorMsg == 500) {
                            showInfo("请上传对应的客户设计方案文件");
                        } else {
                            showInfo(errorString);
                            //showInfo("文件上传错误，请稍候再试");
                        }
                    }
                });
            },
            UploadSolutionFile: function () {
                $("#solotionfile").uploadify({
                    width: 307,
                    height: 30,
                    uploader: '/ashx/PartnerTaskHandler.ashx?Method=UploadSolutionFile',
                    swf: '/Script/uploadify/uploadify.swf',
                    queueSizeLimit: 6,
                    checkExisting: '/ashx/solutionhandler.ashx?Method=CheckFileExists',
                    buttonText: '点击上传文件',
                    fileSizeLimit: '300MB',
                    auto: true,
                    fileTypeExts: '*.skp;*.xml;',
                    multi: true,
                    fileDesc: '只能选择格式 (.skp)文件',
                    queueID: 'Solution_queue',
                    onQueueComplete: function (event, data) {
                        if (event.errorMsg != '' || event.errorMsg != undefined) return;
                        //solutionForm.events.close_uploadwindow();
                    },
                    onUploadSuccess: function (file, data, response) {
                        if (data != "") {
                            data = eval('(' + data + ')');
                            if (data.isOk == 1) {
                                $("#imgsolution").attr('src', "/Content/images/upload_success.png");
                                $('#datagrid').datagrid('reload');
                            }
                        }
                    },
                    onUploadStart: function (file) {
                        $("#solotionfile").uploadify("settings", "formData", { TaskID: $('#upload_solotionfile_form').find('input[name="TaskID"]').val(), FileType: 'SolutionFile' });
                    },
                    onUploadError: function (event, queueId, fileObj, errorObj) {
                        showInfo(errorObj.type + "：" + errorObj.info);
                    }
                });
            },
            UnDoSolutionFile: function () {
                $("#undosolotionfile").uploadify({
                    width: 307,
                    height: 30,
                    uploader: '/ashx/PartnerTaskHandler.ashx?Method=UploadSolutionFile',
                    swf: '/Script/uploadify/uploadify.swf',
                    buttonText: '点击上传文件',
                    fileSizeLimit: '300MB',
                    auto: true,
                    fileTypeExts: '*.skp;',
                    queueID: 'File_queue',
                    fileDesc: '只能选择格式 (.skp)文件',
                    onQueueComplete: function (event, data) {
                        if (event.errorMsg != '' || event.errorMsg != undefined) return;
                        //solutionForm.events.close_uploadwindow();
                    },
                    onUploadSuccess: function (file, data, response) {
                        if (data != "") {
                            data = eval('(' + data + ')');
                            if (data.isOk == 1) {
                                $("#imgundosolution").attr('src', "/Content/images/upload_success.png");
                                $('#datagrid').datagrid('reload');
                            }
                        }
                    },
                    onUploadStart: function (file) {
                        $("#undosolotionfile").uploadify("settings", "formData", { TaskID: $('#undo_solotionfile_form').find('input[name="TaskID"]').val(), ReferenceID: $('#undo_solotionfile_form').find('input[name="ReferenceID"]').val(), FileType: 'SolutionFile' });
                    },
                    onUploadError: function (file, errorCode, errorMsg, errorString) {
                        showInfo("文件上传错误，请稍候再试");
                    }
                });
            },
            //Search
            searchTask: function () {
                partnerTaskForm.controls.dgdetail.datagrid('reload');
            },
            searchCustomer: function () {
                $('#CustomerName').combogrid("grid").datagrid("reload");
            },
            searchPartnerUser: function () {
                $('#UserCode').combogrid("grid").datagrid("reload");
            },

            //Show
            ShowRoomDesignerDetail: function () {
                var DesignerID = $('#save_solution_form').find('input[name="DesignerID"]').val();
                top.addTab("量尺详情", "/View/crm/roomdesignerShow.aspx?DesignerID=" + DesignerID + "&" + jsNC(), 'table');
            },

            //Save
            saveTask: function () {
                if (!partnerTaskForm.controls.save_form.form('validate')) {
                    showError("请完善信息后提交");
                    return;
                }
                $.ajax({
                    url: "/ashx/PartnerTaskHandler.ashx?Method=SavePartnerTask",
                    data: partnerTaskForm.controls.save_form.serialize(),
                    success: function (returnData) {
                        if (returnData.isOk == 1) {
                            showInfo(returnData.message);
                            partnerTaskForm.controls.dgdetail.datagrid("reload");
                            partnerTaskForm.events.cancelSaveWindow();
                        } else {
                            showError(returnData.message);
                        }
                    }
                });
            },
            saveSolution: function () {
                //效果文件            
                if ($('#SolutionFileUrl').val() == '') {
                    //$("#SolutionFileUrl").uploadify('disable', false);
                    showError('请上传方案文件。');
                    return;
                }
                $('#SolutionID').val(partnerTaskForm.events.loadNewGuid);
                partnerTaskForm.controls.save_solution_form.form('submit', {
                    url: '/ashx/solutionhandler.ashx?Method=SaveSolution&' + jsNC(),
                    data: partnerTaskForm.controls.save_solution_form.serialize(),
                    datatype: 'json',
                    onSubmit: function () {
                        var isValid = partnerTaskForm.controls.save_solution_form.form('validate');
                        if (!isValid) {
                            return isValid;
                        }
                        else {
                            $('#btn_save_solution').linkbutton('disable');
                            return isValid;
                        }
                    },
                    success: function (returnData) {
                        $('#btn_save_solution').linkbutton('enable');
                        returnData = eval('(' + returnData + ')');
                        if (returnData.isOk == 0) {
                            showError(returnData.message);
                        }
                        else {
                            $.messager.alert('系统提示', '方案提交成功。', 'info', function () {
                                partnerTaskForm.events.cancelSolutionWindow();
                            });
                        }
                    }
                });
            },
            SaveQuote: function () {
                if (!partnerTaskForm.controls.save_quote_form.form("validate")) {
                    showError("请完善信息后提交。");
                    return;
                }

                var kv = [];

                //部件
                //if (newquoteForm.events.endEditing()) {
                //        newquoteForm.controls.dgdetail.datagrid('acceptChanges');
                //}
                var dgdetails = $('#dgdetail').datagrid("getRows");
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
                //if (newquoteForm.events.hardware_endEditing()) {
                //    newquoteForm.controls.dghardware.datagrid("acceptChanges");
                //}
                var dghardwares = $('#dghardware').datagrid("getRows");
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
                if (doors_endEditing()) {
                    $('#dgdoors').datagrid("acceptChanges");
                }
                var dgdoors = $('#dgdoors').datagrid("getRows");
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
                if (others_endEditing()) {
                    $('#dgothers').datagrid("acceptChanges");
                }
                var dgohers = $('#dgothers').datagrid("getRows");
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
                $('#save_quote_form').find('input[name="QuoteDetails"]').val(sd);
                $('#save_quote_form').find('input[name="QuoteID"]').val(partnerTaskForm.events.loadNewGuid);

                $.ajax({
                    url: "/ashx/quotehandler.ashx?Method=SaveQuote",
                    data: partnerTaskForm.controls.save_quote_form.serialize(),
                    datatype: 'json',
                    success: function (returnData) {
                        if (returnData.isOk == 1) {
                            $.messager.alert("提示", returnData.message, "info", function () {
                                partnerTaskForm.events.cancelQuoteWindow();
                            });
                        }
                        else {
                            showError(returnData.message);
                        }
                    }
                });
            },
            SaveOrder: function () {
                if (ArrayPath.length < 1) {
                    showError("请先上传订单文件！");
                    return;
                }
                t = null;
                hour = 0;
                min = 0;
                sec = 0;
                setInterval(function () { t = partnerTaskForm.events.timedCount(); }, 1000);
                partnerTaskForm.controls.loading.window('open');
                console.log(JSON.stringify(ArrayPath));
                var designID = $('#upload_splitfile_form').find('input[name="DesignID"]').val();
                $.ajax({
                    url: '/ashx/OrdersHandler.ashx?Method=ConversionOrderNew&' + jsNC(),
                    data: { OrderFileUrl: JSON.stringify(ArrayPath), DesignID: designID },
                    success: function (obj) {
                        console.log(JSON.stringify(obj));
                        if (obj.isOk) {
                            $("#" + ArrayPath[0].id).remove();
                            delArrayPathById(ArrayPath[0].id);
                            console.log(JSON.stringify(ArrayPath));
                            partnerTaskForm.events.closeLodingWindow();
                            showInfo(obj.message);
                            partnerTaskForm.events.cancelUploadSplitWindow()
                        } else {
                            partnerTaskForm.events.closeLodingWindow();
                            showError(obj.message);
                        }
                    }, error: function (XMLHttpRequest, textStatus, errorThrown) {
                        // 状态码
                        console.log(XMLHttpRequest.status);
                        // 状态
                        console.log(XMLHttpRequest.readyState);
                        // 错误信息   
                        console.log(textStatus);
                    }
                });
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
            closeLodingWindow: function () {
                setTimeout(function () {
                    partnerTaskForm.events.stopCount();
                    partnerTaskForm.controls.loading.window('close');
                }, 1000);
            },

            //设计师重新上传拆单文件
            UndoSolution: function () {
                $.messager.confirm('系统提示', '确定要重置拆单吗？', function (r) {
                    if (r) {
                        var ReferenceID = $('#save_quote_form').find('input[name="ReferenceID"]').val();
                        var TaskID = $('#save_quote_form').find('input[name="TaskID"]').val();
                        $.ajax({
                            url: '/ashx/solutionhandler.ashx?Method=UndoSolution&' + jsNC(),
                            data: { ReferenceID: ReferenceID, TaskID: TaskID },
                            datatype: "json",
                            success: function (data) {
                                debugger;
                                if (data.isOk == 1) {
                                    partnerTaskForm.events.cancelQuoteWindow();
                                    showInfo(data.message);
                                } else {
                                    showError(data.message);
                                }
                            }
                        });
                    }
                })
            },
            //Cancel
            cancelSolution: function () {
                $.messager.confirm('系统提示', '确定要取消此方案吗？', function (r) {
                    if (r) {
                        var ReferenceID = $('#save_quote_form').find('input[name="ReferenceID"]').val();
                        var TaskID = $('#save_quote_form').find('input[name="TaskID"]').val();
                        $.ajax({
                            url: '/ashx/solutionhandler.ashx?Method=CancelSolution&' + jsNC(),
                            data: { ReferenceID: ReferenceID, TaskID: TaskID },
                            datatype: "json",
                            success: function (data) {
                                if (data.isOk == 1) {
                                    partnerTaskForm.events.cancelQuoteWindow();
                                    showInfo(data.message);
                                } else {
                                    showError(data.message);
                                }
                            }
                        });
                    }
                });
            },
            cancelSaveWindow: function () {
                partnerTaskForm.controls.save_form.form('clear');
                partnerTaskForm.controls.save_window.window('close');
                partnerTaskForm.controls.dgdetail.datagrid('reload');
            },
            cancelSolutionWindow: function () {
                $('#imgSolution').attr('src', "/Content/images/solution_bg.png");
                partnerTaskForm.controls.save_solution_form.form('clear');
                partnerTaskForm.controls.save_solution_window.window('close');
                partnerTaskForm.controls.dgdetail.datagrid('reload');
            },
            cancelQuoteWindow: function () {
                partnerTaskForm.controls.save_quote_form.form('clear');
                partnerTaskForm.controls.save_quote_window.window('close');
                partnerTaskForm.controls.dgdetail.datagrid('reload');
            },
            cancelUploadSplitWindow: function () {
                partnerTaskForm.controls.upload_splitfile_form.form('clear');
                partnerTaskForm.controls.upload_splitfile_window.window('close');
                partnerTaskForm.controls.dgdetail.datagrid('reload');
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
        }
    };

    $(function () {
        partnerTaskForm.init();
        window.top['TaskRefresh'] = function () {
            partnerTaskForm.controls.dgdetail.datagrid('reload');
        }
    });

})(jQuery);

function loadstep(TaskID) {
    $('#taskdetail').datagrid({
        //idField: 'CustomerID',
        url: '/ashx/PartnerTaskHandler.ashx?Method=SearchPartTasksStep&' + jsNC(),
        collapsible: false,
        fitColumns: true,
        pagination: true,
        queryParams: { TaskID: TaskID },
        singleSelect: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        columns: [[
            { field: 'TaskID', hidden: true, width: 150, align: 'center' },
            { field: 'StepNo', title: '编号', width: 120, sortable: false, align: 'center' },
            { field: 'StepName', title: '任务名称', width: 120, sortable: false, align: 'center' },
            { field: 'TargetStep', title: '下一步', width: 150, sortable: false, align: 'center' },
            { field: 'EndedBy', title: '创建者', width: 180, sortable: false, align: 'center' },
            { field: 'Ended', title: '创建时间', width: 150, sortable: false, align: 'center' },
        ]]
    });
    $('#taskstep_window').window('open');
}

function loadtask(TaskID, TaskNo, TaskType, StepName, ReferenceID) {
    $('#save_form').find('input').each(function () {
        $(this).attr('readonly', true);
    });
    $.ajax({
        url: '/ashx/quotehandler.ashx?Method=initCustomer&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (row) {
            if (row) {
                $('#save_form').find('input[name="CustomerName"]').val(row.CustomerName);
                $('#save_form').find('input[name="LinkMan"]').val(row.LinkMan);
                $('#save_form').find('input[name="Address"]').val(row.Address);
            }
        }
    });
    $.ajax({
        url: '/ashx/RoomDesignerHandler.ashx?Method=GetRoomDesigner&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (row) {
            if (row) {
                $('#save_form').form('load', row);
                $('#Designed').val(ChangeDateFormat(row.Designed));
                $('#Status').val(getRoomDesigerStatusName(row.Status));
            }
        }
    });
    $('#save_form').find('#TaskID').val(TaskID);
    $('#save_form').find('#TaskType').val(TaskType);
    $('#save_form').find('#TaskNo').val(TaskNo);
    $('#save_form').find('#StepName').val(StepName);
    $('#save_form').find('#ReferenceID').val(ReferenceID);
    $('#save_window').window('open');
}

function load(DesignerNo, StepName, TaskID, TaskNo, TaskType, ReferenceID, CustomerID) {
    var _self = $(this);
    switch ($.trim(StepName)) {
        // case "分派设计师":
        //case "设计师设计方案":
        case "分派设计师":
            loadtask(TaskID, TaskNo, TaskType, StepName, ReferenceID);
            break;
        case "新建设计":
            window.parent.open("/design/Index.aspx");
            //loadtask(TaskID, TaskNo, TaskType, StepName, ReferenceID);
            break;
        case "待酷家乐设计":
            window.parent.location.href = "/design/list.aspx";
            //loadtask(TaskID, TaskNo, TaskType, StepName, ReferenceID);
            break;
        case "酷家乐设计":
            loadtask(TaskID, TaskNo, TaskType, StepName, ReferenceID);
            break;
        case "待工厂拆单处理":
            saveSolution(TaskID, ReferenceID);
            break;
            //case "待导入拆单文件":
            //    saveSolution(TaskID, ReferenceID);
            //    break;
        case "待工厂拆单上传":
            saveSolution(TaskID, ReferenceID);
            break;
        case "生成报价明细":
            saveQuote(TaskID, ReferenceID);
            break;
        case "待提交订单":
            $.ajax({
                url: '/ashx/solutionhandler.ashx?Method=GetSolutionByDesignerID',
                data: { DesignerID: ReferenceID },
                datatype: "json",
                success: function (data) {
                    if (data) {
                        var url = "/View/crm/addorder.aspx";
                        OpTab('方案设计-' + StepName, url + '?taskid=' + TaskID + '&sid=' + data.SolutionID + '&DesignID=' + ReferenceID + '&' + jsNC(), 'table');
                    }
                    else {
                        showError('方案数据有误。');
                    }
                }
            });
            break;
        case "重新上传方案":
            uploadSolutionFile(TaskID, ReferenceID);
            break;
        case "设计师重传方案":
            unDoSolutionFile(TaskID, ReferenceID);
        case "导入":
            uploadOrderSplitFile(TaskID, ReferenceID);
            //OpTab('导入拆单文件', '/View/orders/orders_import.aspx?DesignID=' + ReferenceID);
            //window.parent.open("/View/orders/orders_import.aspx");
            break;
        case "拆单":
            //触发陈工api
            //target为显示spiner的父容器


            //$('.loda-btn')
            //    .lodaButton()
            //    .click(function (e) {
            //        e.preventDefault();
            //        _self.lodaButton('start');
            //    });
            //_self.lodaButton('stop');
            //sleep(2000);

            //return;
            $.ajax({
                url: '/ashx/kujiale/chenSplit.ashx?Method=ToSplit',
                data: { DesignerID: ReferenceID, DesignerNo: DesignerNo },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 1) {
                        $.ajax({
                            url: '/ashx/solutionhandler.ashx?Method=SaveSolution',
                            data: { TaskID: TaskID, SolutionFileUrl: data.message, CustomerID: CustomerID, ReferenceID: ReferenceID },
                            datatype: "json",
                            success: function (data) {

                                $('#datagrid').datagrid('reload');
                                return;
                            }
                        })
                    }
                    else {
                        showError(data.message);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    debugger;
                    /*错误信息处理*/
                }
            });

            $('#datagrid').datagrid('reload');
            //$('.loda-btn')
            //    .lodaButton()
            //    .click(function (e) {
            //        e.preventDefault();
            //        var _self = $(this);
            //        _self.lodaButton('stop');

            //    });
            break;
        default:
            break;
    }
}

/*js实现sleep功能 单位：毫秒*/
function sleep(numberMillis) {
    var now = new Date();
    var exitTime = now.getTime() + numberMillis;
    while (true) {
        now = new Date();
        if (now.getTime() > exitTime)
            return;
    }
}
function saveSolution(TaskID, ReferenceID) {
    $.ajax({
        url: '/ashx/quotehandler.ashx?Method=initCustomer&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (data) {
            if (data) {
                $('#save_solution_form').form('load', data);
            }
        }
    });
    $.ajax({
        url: '/ashx/RoomDesignerHandler.ashx?Method=GetRoomDesigner&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (data) {
            if (data) {
                $('#save_solution_form').find('input[name="DesignerNo"]').val(data.DesignerNo);
                $('#save_solution_form').find('input[name="DesignerID"]').val(data.DesignerID);
            }
        }
    });
    $('#save_solution_form').find('input[name="ReferenceID"]').val(ReferenceID);
    $('#save_solution_form').find('input[name="TaskID"]').val(TaskID);
    $('#save_solution_window').window('open');
}

function saveQuote(TaskID, ReferenceID) {
    initCustomer(ReferenceID);//客户信息
    loadDetails(ReferenceID);//部件 
    loadHardwares(ReferenceID);//五金
    loadDoors();//移门
    loadOthers();//其他
    $('#save_quote_form').find('input[name="ReferenceID"]').val(ReferenceID);
    $('#save_quote_form').find('input[name="TaskID"]').val(TaskID);
    $('#save_quote_window').window('open');
}

function uploadSolutionFile(TaskID, ReferenceID) {
    $.ajax({
        url: '/ashx/quotehandler.ashx?Method=GetCustomer&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (data) {
            if (data) {
                $('#upload_solotionfile_form').form('load', data);
            }
        }
    });
    $("#imgsolution").attr('src', "/Content/images/solution_bg.png");
    $('#upload_solotionfile_form').find('input[name="TaskID"]').val(TaskID);
    $('#upload_solotionfile_form').find('input[name="ReferenceID"]').val(ReferenceID);
    $('#upload_solotionfile_window').window('open');
}

function uploadOrderSplitFile(TaskID, ReferenceID) {
    $('#upload_splitfile_form').find('input[name="TaskID"]').val(TaskID);
    $('#upload_splitfile_form').find('input[name="DesignID"]').val(ReferenceID);
    $('#upload_splitfile_window').window('open');
}

function unDoSolutionFile(TaskID, ReferenceID) {
    $.ajax({
        url: '/ashx/quotehandler.ashx?Method=GetCustomer&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (data) {
            if (data) {
                $('#undo_solotionfile_form').form('load', data);
            }
        }
    });
    $("#imgundosolution").attr('src', "/Content/images/solution_bg.png");
    $('#undo_solotionfile_form').find('input[name="TaskID"]').val(TaskID);
    $('#undo_solotionfile_form').find('input[name="ReferenceID"]').val(ReferenceID);
    $('#undo_solotionfile_window').window('open');
}

function initCustomer(ReferenceID) {
    $.ajax({
        url: '/ashx/quotehandler.ashx?Method=GetCustomer&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (data) {
            if (data) {
                $('#save_quote_form').form('load', data);
            }
        }
    });
}

function GetCustomer(ReferenceID) {
    $.ajax({
        url: '/ashx/quotehandler.ashx?Method=initCustomer&' + jsNC(),
        data: { ReferenceID: ReferenceID },
        datatype: "json",
        success: function (data) {
            if (data) {
                $('#save_solution_form').form('load', data);
            }
        }
    });
}


//部件  
function loadDetails(ReferenceID) {
    var TotalAmount = 0;
    $('#dgdetail').datagrid({
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
            param['ReferenceID'] = ReferenceID;
        },
        onLoadSuccess: function (data) {
            //统计板件金额
            $('#dgdetail').datagrid('reloadFooter', [{ 'Unit': '', 'QuotedPrice': '金额合计：', 'Amount': '<font color="red">￥' + TotalAmount.toFixed(2) + '</font>' }]);
        },
        //onClickCell: newquoteForm.events.onClickCell,//后期注释
        //onEndEdit: newquoteForm.events.onEndEdit//后期注释
    });
}
//五金
function loadHardwares(ReferenceID) {
    var TotalAmount = 0;
    $('#dghardware').datagrid({
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
        { field: 'HardwareCode', title: '五金编号', width: 150, sortable: false, align: 'center' },
        {
            field: 'HardwareName', title: '五金名称', width: 150, sortable: false, align: 'center',
            //editor: {
            //    type: 'combogrid',
            //    options: {
            //        panelWidth: 740,
            //        panelHeight: 350,
            //        idField: 'MaterialID',
            //        textField: 'MaterialName',
            //        fitColumns: true,
            //        sortName: 'MaterialID',
            //        toolbar: '#tbMaterial',
            //        url: '/ashx/materialhandler.ashx?Method=SearchMaterials',
            //        pagination: true,
            //        editable: false,
            //        nowrap: false,
            //        required: true,
            //        columns: [[
            //                { field: 'MaterialID', title: 'ID', hidden: true },
            //                { field: 'MaterialCode', title: '五金编号', width: 150, sortable: false, align: 'center' },
            //                { field: 'Category', title: '材料类型', width: 150, halign: 'center', align: 'center' },
            //                { field: 'MaterialName', title: '名称', width: 150, align: 'center' },
            //                { field: 'Style', title: '型号/款式', width: 150, sortable: false, align: 'center' },
            //                { field: 'Unit', title: '单位', width: 100, hidden: false, sortable: false, align: 'center' },
            //                { field: 'QuotedPrice', title: '价格', width: 150, sortable: false, align: 'center' },
            //        ]],
            //        onShowPanel: function () {
            //            comboMaterial = this;
            //        },
            //        onBeforeLoad: function (param) {
            //            param['Category'] = '五金';
            //            $('#search_form_material').find('input').each(function (index) {
            //                param[this.name] = $(this).val();
            //            });
            //        },
            //        onSelect: function (index, row) {
            //            HardwareName = row.MaterialName;
            //            ItemStyle = row.Style;
            //            Price = row.Price;
            //            Unit = row.Unit;
            //        }
            //    }
            //}
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
            //{ text: '增加', iconCls: 'icon-add' },//handler: newquoteForm.events.hardware_addRow },
            //{
            //    text: '取消', iconCls: 'icon-cancel', handler: function () {
            //        //newquoteForm.events.cancelall(newquoteForm.controls.dghardware);
            //    }
            //}
        ],
        onBeforeLoad: function (param) {
            param['ReferenceID'] = ReferenceID;
        },
        onLoadSuccess: function (data) {
            //统计板件金额
            $('#dghardware').datagrid('reloadFooter', [{ 'Unit': '', 'QuotedPrice': '金额合计：', 'Amount': '<font color="red">￥' + TotalAmount.toFixed(2) + '</font>' }]);
        },
        //onClickCell: newquoteForm.events.hardware_onClickCell,
        //onEndEdit: newquoteForm.events.hardware_onEndEdit
    });
}
//移门
function loadDoors() {
    $('#dgdoors').datagrid({
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
            { text: '增加', iconCls: 'icon-add', handler: function () { doors_addRow() } },
            {
                text: '取消', iconCls: 'icon-cancel', handler: function () {
                    cancelall($('#dgothers'));
                }
            }
        ]
        //onClickCell: newquoteForm.events.doors_onClickCell,
        //onEndEdit: newquoteForm.events.doors_onEndEdit
    });
}
//其他
function loadOthers() {
    $('#dgothers').datagrid({
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
            {
                text: '增加', iconCls: 'icon-add', handler: function () {
                    others_addRow();
                }
            },
            {
                text: '取消', iconCls: 'icon-cancel', handler: function () {
                    cancelall($('#dgothers'));
                }
            }
        ],
        //onClickCell: newquoteForm.events.others_onClickCell,
        //onEndEdit: newquoteForm.events.others__onEndEdit
    });
}

var doors_editIndex = undefined;
var others_editIndex = undefined;

//移门
function doors_isRepeartRow() {
    var rows = $('#dgdoors').datagrid("getRows");
    for (var i = 0; i < rows.length; i++) {
        for (var j = i + 1; j < rows.length ; j++) {
            if (rows[i].ItemName == rows[j].ItemName) {
                showError("产品名称【" + rows[j].ItemName + "】重复添加。");
                return true;
            }
        }
    }
    return false;
}
function doors_onClickCell(index, field) {
    if (doors_editIndex != index) {
        if (doors_endEditing()) {
            $('#dgdoors').datagrid("selectRow", index).datagrid("beginEdit", index);
            var ed = $('#dgdoors').datagrid('getEditor', { index: index, field: field });
            if (ed) {
                ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
            }
            doors_editIndex = index;
        } else {
            setTimeout(function () {
                $('#dgdoors').datagrid("selectRow", doors_editIndex);
            }, 0);
        }
    }
}
function doors_onEndEdit(index, row) {
    //row.Amount = (row.Price * row.Qty).toFixed(2);         
}
function doors_endEditing() {
    if (doors_editIndex == undefined) return true;
    if ($('#dgdoors').datagrid("validateRow", doors_editIndex)) {
        $('#dgdoors').datagrid("endEdit", doors_editIndex);
        if (!doors_isRepeartRow()) {
            doors_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}
function doors_addRow() {
    if (doors_endEditing()) {
        $('#dgdoors').datagrid("appendRow", {
            ItemName: "",
            ItemStyle: "",
            Unit: "条",
            Qty: "1.00",
            Price: "",
            Remark: ""
        });
        doors_editIndex = $('#dgdoors').datagrid('getRows').length - 1;
        $('#dgdoors').datagrid("selectRow", doors_editIndex).datagrid("beginEdit", doors_editIndex);
    }
}
function doors_cancelrow(index) {
    $('#dgdoors').datagrid("cancelEdit", index).datagrid('deleteRow', index);
}

//其他
function others_isRepeartRow() {
    var rows = $('#dgothers').datagrid("getRows");
    for (var i = 0; i < rows.length; i++) {
        for (var j = i + 1; j < rows.length ; j++) {
            if (rows[i].ItemName == rows[j].ItemName) {
                showError("产品名称【" + rows[j].ItemName + "】重复添加。");
                return true;
            }
        }
    }
    return false;
}
function others_endEditing() {
    if (others_editIndex == undefined) return true;
    if ($('#dgothers').datagrid("validateRow", others_editIndex)) {
        $('#dgothers').datagrid("endEdit", others_editIndex);
        if (!others_isRepeartRow()) {
            others_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}
function others_addRow() {
    if (others_endEditing()) {
        $('#dgothers').datagrid("appendRow", {
            ItemName: "",
            ItemStyle: "",
            Unit: "",
            Qty: "1.00",
            Price: "",
            Remark: ""
        });
        others_editIndex = $('#dgothers').datagrid('getRows').length - 1;
        $('#dgothers').datagrid("selectRow", doors_editIndex).datagrid("beginEdit", others_editIndex);
    }
}
function others_onClickCell(index, field) {
    if (others_editIndex != index) {
        if (others_endEditing()) {
            $('#dgothers').datagrid("selectRow", index).datagrid("beginEdit", index);
            var ed = $('#dgothers').datagrid('getEditor', { index: index, field: field });
            if (ed) {
                ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
            }
            others_editIndex = index;
        } else {
            setTimeout(function () {
                $('#dgothers').datagrid("selectRow", doors_editIndex);
            }, 0);
        }
    }
}
function others__onEndEdit(index, row) {
    //row.Amount = (row.Price * row.Qty).toFixed(2);
}
function orthers_cancelrow(index) {
    $('#dgothers').datagrid("cancelEdit", index).datagrid('deleteRow', index);
}

//取消所有行
function cancelall(selector) {
    selector.datagrid('rejectChanges');
}

//删除数据集合中的对象
function delArrayPathById(id) {
    for (var i = 0; i < ArrayPath.length; i++) {
        if (ArrayPath[i].id == id) {
            ArrayPath.splice(i, 1);
        }
    };
};

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}