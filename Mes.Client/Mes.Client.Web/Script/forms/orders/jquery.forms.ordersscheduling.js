
'use strict';
document.msCapsLockWarningOff = true;

var WorkFlowID = "";
var WorkFlowName = "";
var WorkFLowCode = "";
var editIndex = undefined;

var t = null;
var min = 0; //分
var sec = 0; //秒
var hour = 0; //小时

var ordersSchedulingForm = {
    init: function () {
        ordersSchedulingForm.initControls();
        $('#SpecialID').val(NewGuid());
        ordersSchedulingForm.controls.searchData.on('click', function () {
            ordersSchedulingForm.controls.orders_tree.tree('reload');
        });//加载数据
        ordersSchedulingForm.controls.search_material.on('click', ordersSchedulingForm.events.SearchMaterial);// 
        ordersSchedulingForm.controls.saveparts.on('click', ordersSchedulingForm.events.SaveSpecialParts);// 
        ordersSchedulingForm.controls.ScheduleSetting.on('click', ordersSchedulingForm.events.params_setting);
        ordersSchedulingForm.controls.create_scheduling.on('click', ordersSchedulingForm.events.create_scheduling);

        ordersSchedulingForm.controls.barcode_addOrderNo.on('click', ordersSchedulingForm.events.addOrderNo);//打印
        ordersSchedulingForm.controls.barcode_removeOrderNo.on('click', ordersSchedulingForm.events.removeOrderNo);//打印
        ordersSchedulingForm.controls.barcode_print.on('click', ordersSchedulingForm.events.print);//打印
        ordersSchedulingForm.controls.barcode_cancle.on('click', ordersSchedulingForm.events.cancel);//取消
 
        ordersSchedulingForm.events.loadorder();//loadData
        ordersSchedulingForm.controls.addparts.on('click', function () {
            ordersSchedulingForm.controls.edit_form.form('clear');
            $('#SpecialID').val(NewGuid());
            $('#dgSpecial').datagrid('reload');
        });
        ordersSchedulingForm.controls.edit_form.find('input[type=checkbox]').on('click', function () {
            if ($(this).is(':checked'))
                $(this).val("true");
            else
                $(this).val("false");
        });
        ordersSchedulingForm.controls.workinglineid.combobox({
            url: '/ashx/workinglinehandler.ashx?Method=GetWorkingLines&' + jsNC(),
            textField: 'WorkingLineName',
            valueField: 'WorkingLineID',
            editable: false
        });

        //ordersSchedulingForm.events.loadtotal();
        ordersSchedulingForm.events.loaddetails();
        //ordersSchedulingForm.events.loadmovedetails();
        //ordersSchedulingForm.events.loadsharpdetails();

        $('#MaterialType').combobox({
            onSelect: function (Value) {
                ordersSchedulingForm.controls.MID.value = Value.MaterialID;
                ordersSchedulingForm.events.loaddetails();
                //alert(Value.MaterialID);
            }
        });
        $('#ShipDate').datebox({
            onChange: function (date) {
                //alert(date.getFullYear() + ":" + (date.getMonth() + 1) + ":" + date.getDate());
                ordersSchedulingForm.controls.SD.value = date;
                ordersSchedulingForm.events.loaddetails();
                //debugger;
                //alert(ordersSchedulingForm.controls.ShipDate.datebox("getValue"));
            }
        });
    },
    initControls: function () {
        ordersSchedulingForm.controls = {
            searchData: $('#btn_search_ok'),//查询按钮
            dgtotal: $('#dgtotal'),//填充数据  
            dgdetail: $('#dgdetail'),//填充数据 
            dgremovedetails: $('#dgremovedetails'),//填充数据 
            dgsharp: $('#dgsharp'),//填充数据 
            dgSpecial: $('#dgSpecial'),
            edit_window: $('#edit_window'),
            edit_form: $('#edit_form'),
            search_material: $('#btn_search_material'),
            search_form: $('#search_form'),//查询表单
            workinglineid: $("#WorkingLineID"),
            MaterialType: $("#MaterialType"),
            MID: $("#MID"),
            SD: $("#SD"),
            addparts: $('#btn_add'),
            saveparts: $('#btn_save'),
            SpecialParts: $('#SpecialParts'),
            loading: $('#submit_window'),
            steps_window: $('#steps_window'),
            orders_tree: $('#orders_tree'),
            ScheduleSetting: $('#btnScheduleSetting'),
            create_scheduling: $('#btnCreate_Scheduling'),
            barcode_window: $("#barcode_window"),
            barcode_addOrderNo: $("#btn_barcode_addOrderNo"),
            barcode_removeOrderNo: $("#btn_barcode_remove"),
            barcode_print: $("#btn_barcode_print"),
            barcode_cancle: $("#btn_barcode_cancel"),
            orderNo: $("#OrderNo"),
            barcode_cancle: $("#btn_barcode_cancel"),
            settime_window: $('#settime_window'),
        }
        $('#btn_search_ok').linkbutton();
        $('#ShipDateTo').datebox({
            onSelect: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                var ShipDateTo = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                var ShipDateFrom = $("#ShipDateFrom").datebox("getValue");
                if (ShipDateFrom == "") {
                    alert("请选择开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }
                if (ShipDateFrom > ShipDateTo) {
                    alert("结束日期不能小于开始日期！");
                    $('#ShipDateTo').datebox("setValue", '');
                }

            }
        });
    },
    events: {
        loadorder: function () {
            ordersSchedulingForm.controls.orders_tree.tree({
                url: '/ashx/ordershandler.ashx?Method=GetOrderSchedulingTree',
                loadMsg: '正在加载数据，请稍候....',
                state: 'closed',
                checkbox: true,
                onBeforeLoad: function (node, param) {
                    ordersSchedulingForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersSchedulingForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                },
                onClick: function (node) {
                    //ordersSchedulingForm.events.loadGrid(1, node.id);
                },
                onCheck: function (node, checked) {
                    var ii = GetCabinetIDs();
                    //debugger;
                    //param["CabinetIDs"] = GetCabinetIDs();
                    ordersSchedulingForm.controls.MaterialType.combobox({
                        url: '/ashx/workinglinehandler.ashx?Method=GetMaterialType&' + jsNC(),
                        textField: 'MaterialID',
                        valueField: 'MaterialType',
                        editable: false,
                        queryParams: { CabinetIDs: ii }
                    });

                    ordersSchedulingForm.controls.MaterialType.combobox('setValue', ordersSchedulingForm.controls.MID.value);
                    ordersSchedulingForm.events.reload();
                },
                onLoadSuccess: function (node, param) {
                    var nd = ordersSchedulingForm.controls.orders_tree.tree('getRoot');
                    ordersSchedulingForm.controls.orders_tree.tree('expand', nd.target);
                }
            });
        },
        loadtotal: function () {
            ordersSchedulingForm.controls.dgtotal.datagrid({
                url: '/ashx/ordershandler.ashx?Method=SearchAPSTotal&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                pageSize: 20,
                columns: [[
                    { field: 'MaterialType', title: '使用材质', width: 100, sortable: false, align: 'center' },
                    {
                        field: 'Qty', title: '板件数量(片)', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
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
                        field: 'TotalAreal', title: '面积小计(M<sup>2</sup>)', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                            if (value == undefined) return "";
                            return value.toString().replace('.00', '');
                        }
                    },
                    { field: 'PlateQty', title: '预计用板数量(块)', width: 80, sortable: false, align: 'center' }
                ]],
                onBeforeLoad: function (param) {
                    ordersSchedulingForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersSchedulingForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                    param["CabinetIDs"] = GetCabinetIDs();
                }
            });
        },
        loaddetails: function () {
            ordersSchedulingForm.controls.dgdetail.datagrid({
                url: '/ashx/ordershandler.ashx?Method=SearchScheduleDetail&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 200,
                pageList: [50, 100, 200, 500, 1000, 2000],
                singleSelect: false,
                columns: [[
                     {
                         field: 'ItemID',
                         title: '多选',
                         width: 50,
                         checkbox: true
                     },
                { field: 'OrderNo', title: '所属订单', width: 120, align: 'center' },
                {
                    field: 'ShipDate', title: '交货日期', width: 80, align: 'center', formatter: function (value, rowData, rowIndex) {
                        return (new Date(value)).format("yyyy-MM-dd");
                    }
                },
                { field: 'ItemName', title: '部件名称', width: 120, align: 'center' },
                { field: 'MaterialType', title: '材质颜色', width: 100, sortable: false, align: 'center' },
                {
                    field: 'MadeWidth', title: '开料宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return value.toString().replace('.00', '');
                    }
                },

                  {
                      field: 'MadeLength', title: '开料长度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                          if (value == undefined) return "";
                          return value.toString().replace('.00', '');
                      }
                  },
                  {
                      field: 'EndWidth', title: '成品宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
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
                    { text: '补打条码', iconCls: 'icon-print', handler: ordersSchedulingForm.events.patch_barcode }
                ],
                onBeforeLoad: function (param) {
                    ordersSchedulingForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersSchedulingForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                    param["CabinetIDs"] = GetCabinetIDs();
                    param["MaterialType"] = ordersSchedulingForm.controls.MID.value;
                    param["ShipDate"] = ordersSchedulingForm.controls.SD.value;
                },
                onLoadSuccess: function (bbb) {
                    //alert($('#MaterialType').combobox('getValue'));
                }

            });
            $(".datagrid-toolbar:eq(1) tr").append('<td><div class="datagrid-btn-separator"></div></td><td><label><input type="checkbox" id="IsPrintBarcode" checked="checked" value="">是否打印条码</label>&nbsp;&nbsp;<input id="production_print_number" class="easyui-numberspinner" value="1" data-options="min:1,max:50,increment:1"  style="width:70px;" />份<label><input  id="checkview" type="checkbox"/>打印预览</label></td>');
        },
        loadmovedetails: function () {
            ordersSchedulingForm.controls.dgremovedetails.datagrid({
                idField: 'ItemID',
                url: '/ashx/ordershandler.ashx?Method=SearchRemoveDetails',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                pageSize: 20,
                columns: [[
                { field: 'ItemName', title: '部件名称', width: 120, align: 'center' },
                { field: 'MaterialType', title: '材质颜色', width: 100, sortable: false, align: 'center' },
                {
                    field: 'MadeWidth', title: '开料宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return value.toString().replace('.00', '');
                    }
                },

                  {
                      field: 'MadeLength', title: '开料长度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                          if (value == undefined) return "";
                          return value.toString().replace('.00', '');
                      }
                  },
                  {
                      field: 'EndWidth', title: '成品宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
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
                  }
                ]],
                onBeforeLoad: function (param) {
                    ordersSchedulingForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersSchedulingForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                    param["CabinetIDs"] = GetCabinetIDs();
                }
            });
        },
        loadsharpdetails: function () {
            ordersSchedulingForm.controls.dgsharp.datagrid({
                idField: 'ItemID',
                url: '/ashx/ordershandler.ashx?Method=SearchShapeDetails',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,
                pageSize: 20,
                columns: [[
                { field: 'ItemName', title: '部件名称', width: 120, align: 'center' },
                { field: 'MaterialType', title: '材质颜色', width: 100, sortable: false, align: 'center' },
                {
                    field: 'MadeWidth', title: '开料宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value == undefined) return "";
                        return value.toString().replace('.00', '');
                    }
                },

                  {
                      field: 'MadeLength', title: '开料长度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                          if (value == undefined) return "";
                          return value.toString().replace('.00', '');
                      }
                  },
                  {
                      field: 'EndWidth', title: '成品宽度', width: 80, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
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
                onBeforeLoad: function (param) {
                    ordersSchedulingForm.controls.search_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersSchedulingForm.controls.search_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                    param["CabinetIDs"] = GetCabinetIDs();
                }
            });
        },
        params_setting: function () {
            ordersSchedulingForm.events.loadSpecial();
            ordersSchedulingForm.events.loadSpecialWorkFlows();
            ordersSchedulingForm.controls.edit_window.window('open');
        },
        select_workingline: function () {
            $('#ul_WorkingLine')
            ordersSchedulingForm.controls.select_workingline.window('open');

        },
        patch_barcode: function () {
            ordersSchedulingForm.controls.barcode_window.window('open');
        },
        create_scheduling: function () {
            //var selRows = ordersSchedulingForm.controls.dgdetail.datagrid('getChecked');
            //var orderids = [];
            //$.each(selRows, function (index, item) {
            //    orderids.push(item.OrderID);
            //});
            var selRows = ordersSchedulingForm.controls.dgdetail.datagrid('getChecked');
            if (selRows.length == 0) {
                showError("请选择需要排产的板件。");
                return;
            }
            var paramStr="";
            for (var i = 0; i < selRows.length; i++) {
                paramStr += selRows[i].ItemID + ',';
            }
            paramStr = paramStr.substr(0, paramStr.length - 1);
            //var cabinetids = GetCabinetIDs();
            //if (cabinetids == "") {
            //    showError("请选择需要排产的订单。");
            //    return;
            //}
            var LineID = ordersSchedulingForm.controls.workinglineid.combobox('getValue');
            if (LineID == undefined || LineID == "") {
                showError("请选择需要排产生产线。");
                return;
            }
            //ordersSchedulingForm.controls.settime_window.window('open');
            var url = '/ashx/ordershandler.ashx?Method=CreateScheduling&' + jsNC();
            var data = { BJids: paramStr, WorkingLineID: LineID };
            t = null;
            hour = 0;
            min = 0;
            sec = 0;
            $('.runtime').html('');
            setInterval(function () { t = ordersSchedulingForm.events.timedCount(); }, 1000);
            ordersSchedulingForm.controls.loading.window('open');

            $.post(
                url,
                data,
                function (returnData) {
                    if (returnData) {
                        if (returnData.isOk == 1) {
                            showInfo(returnData.message);
                            ordersSchedulingForm.controls.orders_tree.tree('reload');
                            ordersSchedulingForm.events.reload();
                            if ($("#IsPrintBarcode").prop("checked")) {
                                //开始排产时打印条码
                                var production_printnumber = $("#production_print_number").numberspinner('getValue'); //打印份数
                                var checkview = $('#checkview').is(":checked");
                                setTimeout(function () {
                                    sendMessage(GetOrderIDs(), production_printnumber, checkview);
                                }, 1000);
                            }
                        } else {
                            showError(returnData.message);
                        }
                    }
                }, 'json')
                .done(function () {
                    ordersSchedulingForm.events.stopCount();
                    ordersSchedulingForm.controls.loading.window('close');
                })
                .error(function () {
                    ordersSchedulingForm.events.stopCount();
                    ordersSchedulingForm.controls.loading.window('close');
                });
        },
        saveOrderSchedulingBySkip: function () {
            $.messager.confirm('系统提示', '您确定要跳过排产时间设置？', function (flag) {
                if (flag) {
                    ordersSchedulingForm.events.saveOrderScheduling(true);
                }
            });
        },
        saveOrderScheduling: function (IsSkip) {
            if (!IsSkip) {
                if (!ordersSchedulingForm.controls.settime_form.form('validate')) {
                    showError("请设置排产时间。若无需设置请跳过该步骤");
                    return;
                }
            }
           
            var SchedulingTime = {
                MaterialMadeName: "开料",
                MaterialMadeStarted: setdefaulttime(($('#MaterialMadeStarted').datebox('getValue'))),
                MaterialMadeEnded: setdefaulttime(($('#MaterialMadeEnded').datebox('getValue'))),
                WoodMadeName: "封边",
                WoodMadeStarted: setdefaulttime(($('#WoodMadeStarted').datebox('getValue'))),
                WoodMadeEnded: setdefaulttime(($('#WoodMadeEnded').datebox('getValue'))),
                DetectMadeName: "铣型",
                DetectMadeStarted: setdefaulttime(($('#DetectMadeStarted').datebox('getValue'))),
                DetectMadeEnded: setdefaulttime(($('#DetectMadeEnded').datebox('getValue'))),
                PaintMadeName: "打孔",
                PaintMadeStarted: setdefaulttime(($('#PaintMadeStarted').datebox('getValue'))),
                PaintMadeEnded: setdefaulttime(($('#PaintMadeEnded').datebox('getValue'))),
                PrisonMadeName: "检验",
                PrisonMadeStarted: setdefaulttime(($('#PrisonMadeStarted').datebox('getValue'))),
                PrisonMadeEnded: setdefaulttime(($('#PrisonMadeEnded').datebox('getValue'))),
                PrisonMadeName: "美容",
                CosmetologyStarted: setdefaulttime(($('#CosmetologyStarted').datebox('getValue'))),
                CosmetologyEnded: setdefaulttime(($('#CosmetologyEnded').datebox('getValue'))),
                PackagMadeName: "包装",
                PackagMadeStarted: setdefaulttime(($('#PackagMadeStarted').datebox('getValue'))),
                PackagMadeEnded: setdefaulttime(($('#PackagMadeEnded').datebox('getValue'))),
                WarehousMadeName: "入库",
                WarehousMadeStarted: setdefaulttime(($('#WarehousMadeStarted').datebox('getValue'))),
                WarehousMadeEnded: setdefaulttime(($('#WarehousMadeEnded').datebox('getValue'))),
            };

            //var url = '/ashx/ordershandler.ashx?Method=CreateScheduling&' + jsNC();
            //var data = { BJids: paramStr, WorkingLineID: LineID, SchedulingTime: JSON.stringify(SchedulingTime) };
            //t = null;
            //hour = 0;
            //min = 0;
            //sec = 0;
            //$('.runtime').html('');
            //setInterval(function () { t = ordersSchedulingForm.events.timedCount(); }, 1000);
            //ordersSchedulingForm.controls.loading.window('open');

            //$.post(
            //    url,
            //    data,
            //    function (returnData) {
            //        if (returnData) {
            //            if (returnData.isOk == 1) {
            //                showInfo(returnData.message);
            //                ordersSchedulingForm.controls.orders_tree.tree('reload');
            //                ordersSchedulingForm.events.reload();
            //                if ($("#IsPrintBarcode").prop("checked")) {
            //                    //开始排产时打印条码
            //                    var production_printnumber = $("#production_print_number").numberspinner('getValue'); //打印份数
            //                    var checkview = $('#checkview').is(":checked");
            //                    setTimeout(function () {
            //                        sendMessage(GetOrderIDs(), production_printnumber, checkview);
            //                    }, 1000);
            //                }
            //            } else {
            //                showError(returnData.message);
            //            }
            //        }
            //    }, 'json')
            //    .done(function () {
            //        ordersSchedulingForm.events.stopCount();
            //        ordersSchedulingForm.controls.loading.window('close');
            //    })
            //    .error(function () {
            //        ordersSchedulingForm.events.stopCount();
            //        ordersSchedulingForm.controls.loading.window('close');
            //    });
        },
        loadSpecial: function () {
            ordersSchedulingForm.controls.SpecialParts.tree({
                url: '/ashx/ordershandler.ashx?Method=GetSpecialCompanents',
                checkbox: false,
                onClick: function (node) {
                    $('#SpecialID').val(node.id);
                    $('#ItemName').val(node.text);
                    $('#IsDisabled').attr('checked', node.attributes.IsDisabled.toLowerCase() === "true" ? true : false);
                    ordersSchedulingForm.controls.dgSpecial.datagrid('reload');
                }
            });

        },
        loadSpecialWorkFlows: function () {
            ordersSchedulingForm.controls.dgSpecial.datagrid({
                url: '/ashx/ordershandler.ashx?Method=SearchSpecialCompanent2WorkFlows',
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                singleSelect: true,
                pageList: [20, 40, 50, 80, 100],
                columns: [[
                { field: 'SpecialDetailID', title: '工序ID', hidden: true },
                { field: 'SpecialID', title: '部件ID', hidden: true },
                {
                    field: 'WorkFlowName', title: '工序名称', width: 200, sortable: false, align: 'center', editor: {
                        type: 'combogrid',
                        options: {
                            url: '/ashx/workflowhandler.ashx?Method=SearchWorkFlows',
                            idField: 'WorkFlowID',
                            textField: 'WorkFlowName',
                            panelWidth: 300,
                            panelHeight: 400,
                            fitColumns: true,
                            pagination: true,
                            required: true,
                            editable: false,
                            pageSize: 20,
                            singleSelect: true,
                            nowrap: true,
                            pageList: [20, 40, 50],
                            columns: [[
                                { field: 'WorkFlowID', title: 'ID', width: 100, hidden: true },
                                { field: 'WorkFlowCode', title: '工序编号', width: 120 },
                                { field: 'WorkFlowName', title: '工序名称', width: 150 }
                            ]],
                            onSelect: function (index, row) {
                                WorkFlowName = row.WorkFlowName;
                                WorkFlowID = row.WorkFlowID;
                                WorkFLowCode = row.WorkFLowCode;
                            }
                        }
                    }
                },
                {
                    field: 'op', title: '操作', width: 80, sortable: false, halign: 'center', align: 'left', formatter: function (value, row, index) {
                        return '<a href="#" onclick="cancelrow(' + index + ')"><span class="icon delete">&nbsp;</span>&nbsp;移除</a>';
                    }
                }
                ]],
                toolbar: [
                   { text: '添加工序', iconCls: 'ruby_add', handler: ordersSchedulingForm.events.workflow_addrow }
                ],
                onClickCell: function (index, field) {
                    if (editIndex != index) {
                        if (ordersSchedulingForm.events.endEditing()) {
                            ordersSchedulingForm.controls.dgSpecial.datagrid('selectRow', index)
                                    .datagrid('beginEdit', index);
                            var ed = ordersSchedulingForm.controls.dgSpecial.datagrid('getEditor', { index: index, field: field });
                            if (ed) {
                                ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                            }
                            editIndex = index;
                        } else {
                            setTimeout(function () {
                                ordersSchedulingForm.controls.dgSpecial.datagrid('selectRow', editIndex);
                            }, 0);
                        }
                    }
                },
                onEndEdit: function (index, row) {
                    if (WorkFlowID != "") {
                        row.WorkFlowID = WorkFlowID;
                    }
                    if (WorkFlowName != "") {
                        row.WorkFlowName = WorkFlowName;
                    }
                    $("#dgSpecial").datagrid('refreshRow', index);
                    WorkFlowID = "";
                    WorkFlowName = "";
                },
                onBeforeLoad: function (param) {
                    ordersSchedulingForm.controls.edit_form.find('select').each(function (index) {
                        param[this.name] = $(this).val();
                    });
                    ordersSchedulingForm.controls.edit_form.find('input').each(function (index) {
                        if (this.name != "")
                            param[this.name] = $(this).val();
                    });
                }
            });
        },
        workflow_addrow: function () {
            if (ordersSchedulingForm.events.endEditing()) {
                ordersSchedulingForm.controls.dgSpecial.datagrid('appendRow', { SpecialDetailID: NewGuid(), SpecialID: $('#SpecialID').val() });
                editIndex = ordersSchedulingForm.controls.dgSpecial.datagrid('getRows').length - 1;
                ordersSchedulingForm.controls.dgSpecial.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }
        },
        endEditing: function () {
            if (editIndex == undefined) { return true }
            if (ordersSchedulingForm.controls.dgSpecial.datagrid('validateRow', editIndex)) {
                ordersSchedulingForm.controls.dgSpecial.datagrid('endEdit', editIndex);
                if (!ordersSchedulingForm.events.isRepeartRow()) {
                    editIndex = undefined;
                    return true;
                }
                else {
                    return false;
                }
            } else {
                return false;
            }
        },
        isRepeartRow: function () {
            var rows = ordersSchedulingForm.controls.dgSpecial.datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                for (var j = i + 1; j < rows.length; j++) {
                    if (rows[i].WorkFlowName == rows[j].WorkFlowName) {
                        showError("工序名称【" + rows[j].WorkFlowName + "】已经存在，不能重复添加。");
                        return false;
                    }
                }
            }
            return false;
        },
        SaveSpecialParts: function () {
            var wfs = [];
            if (ordersSchedulingForm.events.endEditing()) {
                ordersSchedulingForm.controls.dgSpecial.datagrid('acceptChanges');
            }
            var rows = ordersSchedulingForm.controls.dgSpecial.datagrid('getRows');
            var kv = [];
            if (rows.length < 2) {
                showError("最少需要添加两个加工工序。");
                return;
            }
            for (var i = 0; i < rows.length; i++) {
                kv.push({ SpecialID: rows[i].SpecialID, SpecialDetailID: rows[i].SpecialDetailID, WorkFlowID: rows[i].WorkFlowID, Sequence: i + 1 });
            }

            //序列化对象为Json字符串
            var wfs = JSON.stringify(kv);
            $('#WorkFlows').val(wfs);

            ordersSchedulingForm.controls.edit_form.form('submit', {
                url: '/ashx/ordershandler.ashx?Method=SaveSpecialCompanent2WorkFlows&' + jsNC(),
                data: ordersSchedulingForm.controls.edit_form.serialize(),
                datatype: 'json',
                onSubmit: function () {
                    var isValid = ordersSchedulingForm.controls.edit_form.form('validate');
                    if (!isValid) {
                        return isValid;
                    }
                    else {
                        ordersSchedulingForm.controls.saveparts.linkbutton('disable');
                        return isValid;
                    }
                },
                success: function (returnData) {
                    ordersSchedulingForm.controls.saveparts.linkbutton('enable');
                    returnData = eval('(' + returnData + ')');
                    if (returnData.isOk == 0) {
                        showError(returnData.message);
                    }
                    else {
                        ordersSchedulingForm.controls.SpecialParts.tree('reload');
                    }
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
        reload: function () {
            ordersSchedulingForm.controls.dgtotal.datagrid('reload');
            ordersSchedulingForm.controls.dgdetail.datagrid('reload');
            ordersSchedulingForm.controls.dgremovedetails.datagrid('reload');
            ordersSchedulingForm.controls.dgsharp.datagrid('reload');
        },
        addOrderNo: function () {
            var orderNoVal = ordersSchedulingForm.controls.orderNo.val();
            if (orderNoVal == null || orderNoVal == "") {
                showError("请先输入要打印的订单编号。");
                return;
            }
            var url = "/ashx/ordershandler.ashx?Method=SearchIsExistOrder&" + jsNC,
                data = { OrderNo: orderNoVal };
            $.post(url, data, function (returnData) {
                if (returnData) {
                    if (returnData.OrderNo != "") {
                        var watiPrintOrder = $("#WaitPrintOrder").val();
                        var watiPrintOrderArray = watiPrintOrder.substring(0, watiPrintOrder.length - 1).split("|");
                        if ($.inArray(returnData.OrderNo, watiPrintOrderArray) > -1) {
                            showError("该订单编号已添加。");
                            return;
                        }
                        $("#WaitPrintOrder").val(returnData.OrderNo + "|" + watiPrintOrder);
                        $("#wait_order").prepend("<li style=\"padding: 5px 0 0 5px;font-weight: bold;\">" + returnData.OrderNo + "</li>");
                    } else {
                        showError("该订单编号不存在。");
                        return;
                    }
                }
            }, 'json').done(function () {
                ordersSchedulingForm.events.stopCount();
            }).error(function () {
                ordersSchedulingForm.events.stopCount();
            });
        },
        removeOrderNo: function () {
            $("#wait_order").empty();
            $("#WaitPrintOrder").val("");

        },
        print: function () {

            $("#PrintContext").html("");
            var watiPrintOrder = $("#WaitPrintOrder").val();
            if (watiPrintOrder == "") {
                showError("没有需要打印条码的订单。");
                return;
            }

            //补打条码
            $.ajax({
                url: "/ashx/ordershandler.ashx?Method=PrintOrderNoBarcode&" + jsNC,
                data: { WaitPrintBarcodeNo: watiPrintOrder.substring(0, watiPrintOrder.length - 1) },
                beforeSend: function () {
                    console.log(ordersSchedulingForm.controls.barcode_print.find('span.l-btn-text'));
                    ordersSchedulingForm.controls.barcode_print.find('span.l-btn-text').html('正在打印中');
                },
                success: function (returnData) {
                    if (returnData.total > 0) {
                        var printnumber = $("#print_number").numberspinner('getValue'); //打印份数
                        var checkview = $('#checkview1').is(":checked");
                        setTimeout(function () {
                            sendMessage(returnData.rows, printnumber, checkview);
                            //showInfo('打印成功');
                        }, 1000);
                    }
                },
                complete: function () {
                    ordersSchedulingForm.controls.barcode_print.find('span.l-btn-text').html('打印');
                    ordersSchedulingForm.controls.barcode_window.window('close');
                },
                error: function (e) {
                    alert(JSON.stringify(e));
                }
            });
        },
        cancel: function () {
            ordersSchedulingForm.controls.barcode_window.window('close');
        },
    }
};

function GetCabinetIDs() {
    var Cabinet_Nodes = ordersSchedulingForm.controls.orders_tree.tree('getChecked');
    var CabinetIDs = [];
    $.each(Cabinet_Nodes, function (index, node) {
        if (node.attributes.IsMenu == '3') {
            CabinetIDs.push(node.id);
        }
    });
    return CabinetIDs.join(',');
}
function GetOrderIDs() {
    var Order_Nodes = ordersSchedulingForm.controls.orders_tree.tree('getChecked');
    var OrderIDs = [];
    $.each(Order_Nodes, function (index, node) {
        if (node.attributes.IsMenu == '2') {
            OrderIDs.push({ OrderNo: node.text });
        }
    });
    return OrderIDs;
}
//订单条码二维码模版设置及打印
function sendMessage(dataset, printnumber, checkview) {
    printnumber = printnumber || 1; //打印次数
    var OrderNo = "";
    for (var i = 0; i < dataset.length; i++) {
        var row = dataset[i];
        OrderNo += row.OrderNo + ",";
    }
    var parameter = "?template=order&OrderNo=" + OrderNo + "&printnumber=" + printnumber + "&isview=" + checkview;
    InsertIframe(parameter);
}

function cast(obj) {
    if (obj.toString().length == 1)
        return '0' + obj.toString();
    else
        return obj.toString();
}

//移除行
function cancelrow() {
    if (editIndex == undefined) {
        return
    }
    $('#dgSpecial').datagrid('cancelEdit', editIndex)
            .datagrid('deleteRow', editIndex);
    editIndex = undefined;
}
//查看详情        
function showdetail(id, no) {
    top.addTab("查看【" + no + "】", "/View/orders/ordersdetail.aspx?orderid=" + id + "&" + jsNC());
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

$(function () {
    ordersSchedulingForm.init();
});
function setdefaulttime(Started) {
    return (!IsNullOrEmpty(Started) ? Started : "0000-01-01");
}