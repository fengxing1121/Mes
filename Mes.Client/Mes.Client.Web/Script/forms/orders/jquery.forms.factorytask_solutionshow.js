'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var solutionForm = {
    init: function () {
        solutionForm.initControls();
        solutionForm.controls.SolutionID = getUrlParam('SolutionID');  
        solutionForm.events.init();
        solutionForm.controls.btn_verify_ok.on('click', solutionForm.events.ComfirmSolution);//审核通过
        solutionForm.controls.btn_undo.on('click',solutionForm.events.UnDoSolution); //重新上传方案
    },
    initControls: function () {
        solutionForm.controls = {
            SolutionID: null,
            dgcabinet: $('#dgcabinet'),
            dgdetail: $('#dgdetail'),
            dgHardware: $('#dgHardware'),
            skpFile: $('#skpfile'),
            edit_form: $('#edit_form'),
            btn_verify_ok: $('#btn_verify_ok'),
            btn_undo: $('#btn_undo'),     
        }
    },
    events: {
        init: function () {
            //解决方案
            $.ajax({
                url: '/ashx/solutionhandler.ashx?Method=GetSolution',
                data: { SolutionID: solutionForm.controls.SolutionID },
                datatype: "json",
                success: function (data) {
                    if (data.isOk == 0) {
                        showError(data.message);
                        return;
                    }
                    solutionForm.controls.edit_form.form('load',data);
                    solutionForm.events.getCustomer(data.CustomerID);
                    //$("#Status").val(getSolutionStatusName(data.Status).replace('<font color="red">', '').replace('</font>', ''));
                    solutionForm.controls.edit_form.find('input').each(function (index) {
                          $(this).attr('readonly', true);
                    });
                    //if (data.Status == 'P') {
                    //    $('#btn_quote,#btn_fileupload').show();
                    //}
                    //else {
                    //    $('#btn_quote,#btn_fileupload').hide();
                    //}
                }
            });
            //产品明细
            solutionForm.controls.dgcabinet.datagrid({
                url: '/ashx/solutionhandler.ashx?Method=GetCabinets',
                idField: 'CabinetID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: true,
                columns: [[
                { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                { field: 'CabinetGroup', title: '产品名称', width: 150, sortable: false, align: 'center' },
                { field: 'CabinetName', title: '柜体名称', width: 150, sortable: false, align: 'center' },
                { field: 'Size', title: '柜体尺寸', width: 120, sortable: false, align: 'center' },
                { field: 'Color', title: '柜体颜色', width: 120, sortable: false, align: 'center' },
                { field: 'MaterialStyle', title: '材质风格', width: 120, sortable: false, align: 'center' },
                { field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center' },
                { field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center' },
                { field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center' },
                { field: 'Remark', title: '备注', width: 120, hidden: true, sortable: false, align: 'center' },
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
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                }
            });
            //板件明细
            solutionForm.controls.dgdetail.datagrid({
                idField: 'ItemID',
                url: '/ashx/solutionhandler.ashx?Method=GetSolutionDetails&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                pageSize: 20,
                striped: false,
                showFooter: false,
                columns: [[
                    { field: 'CabinetName', title: '产品名称', width: 180, align: 'center' },
                    { field: 'BarcodeNo', title: '板件条码', width: 180, align: 'center' },
                    { field: 'ItemName', title: '部件名称', width: 120, align: 'center' },
                    { field: 'MaterialName', title: '材质颜色', width: 100, sortable: false, align: 'center' },
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
                groupField: 'CabinetName',
                view: groupview,
                groupFormatter: function (value, rows) {
                    return value + ' - ' + rows.length + ' Item(s)';
                },
                onBeforeLoad: function (param) {
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                }
            });

            //五金明细
            solutionForm.controls.dgHardware.datagrid({
                idField: 'ItemID',
                url: '/ashx/solutionhandler.ashx?Method=GetSolutionHardwares&' + jsNC(),
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
                onBeforeLoad: function (param) {
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                }
            });

            //skpFile
            solutionForm.controls.skpFile.datagrid({
                //idField: 'DoorID',
                url: '/ashx/solutionhandler.ashx?Method=GetSoltionSpkFile',
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
                    param['SolutionID'] = solutionForm.controls.SolutionID;
                }
            });
        },
        getCustomer: function () {
            $.ajax({
                url: '/ashx/customerhandler.ashx',
                data: { Method: 'GetCustomer', CustomerID: arguments[0] },
                success: function (data) {
                    if (data.isOk == 0) {
                    }
                    else {
                        solutionForm.controls.edit_form.form('load', data);
                    }
                }
            });
        },
        ComfirmSolution: function () {
            $.messager.confirm('系统提示', '审核通过吗？', function (r) {
                if (r) {
                    var ReferenceID = getUrlParam('ReferenceID');
                    var TaskID = getUrlParam('TaskID');
                    $.ajax({
                        url: '/ashx/solutionhandler.ashx?Method=ComfirmSolution&' + jsNC(),
                        data: { ReferenceID: ReferenceID, TaskID: TaskID },
                        datatype: "json",
                        success: function (data) {
                            if (data.isOk == 0) {
                                showError(data.message);
                            } else {
                                $.messager.alert("提示", "审核成功", "info", function () {
                                    top.addTab("客户方案审核", "/View/orders/factorytask.aspx", 'table');
                                    window.parent.closeTab();
                                });
                            }
                        }
                    });
                }
            });
        },
        UnDoSolution: function () {
            $.messager.confirm('系统提示', '确定要重新上传方案吗？', function (r) {
                if (r) {
                    var ReferenceID = getUrlParam('ReferenceID');
                    var TaskID = getUrlParam('TaskID');
                    $.ajax({
                        url: '/ashx/solutionhandler.ashx?Method=UndoSolution&' + jsNC(),
                        data: { ReferenceID: ReferenceID, TaskID: TaskID },
                        datatype: "json",
                        success: function (data) {
                            if (data.isOk == 0) {
                                showError(data.message);
                            } else {
                                $.messager.alert("提示", data.message, "info", function () {
                                    top.addTab("客户方案审核", "/View/orders/factorytask.aspx", 'table');
                                    window.parent.closeTab();
                                });
                            }
                        }
                    });
                }
            });          
        }
    }
};

$(function () {
    solutionForm.init();
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