//'use strict';
document.msCapsLockWarningOff = true;
var editIndex = undefined;
var solutionForm = {
    init: function () {
        solutionForm.initControls();
        solutionForm.events.loadCabinet();//加载数据          
        solutionForm.events.loadCustomer();
        solutionForm.controls.savesolution.on('click', solutionForm.events.savesolution);//保存 
        solutionForm.controls.searchCustomer.on('click', solutionForm.events.searchCustomer);//查询客户
        solutionForm.events.createnewsolution();
        solutionForm.events.CabinetType();
        solutionForm.events.loadUploadFile();
    },
    initControls: function () {
        solutionForm.controls = {
            dgcabinet: $('#dgCabinet'),
            edit_form: $('#edit_form'),
            savesolution: $('#btn_edit_save'),
            searchCustomer: $('#btn_search_customer')//查询客户
        };
    },
    events: {
        //添加产品
        loadCabinet: function () {
            solutionForm.controls.dgcabinet.datagrid({
                idField: 'CabinetID',
                collapsible: false,
                singleSelect: true,
                pageSize: 20,
                fitColumns: true,
                pagination: false,
                columns: [[
                { field: 'CabinetID', title: '产品ID', hidden: true, width: 200, sortable: false, align: 'center' },
                //{ field: 'cp', checkbox: true },
                {
                    field: 'CabinetName', title: '产品名称', width: 150, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetCabinetName',
                            required: true
                        }
                    }
                },
                {
                    field: 'Size', title: '成品尺寸', width: 120, sortable: false, align: 'center', editor: {
                        type: 'textbox',
                        options: {
                            //required: true
                        }
                    }
                },

                {
                    field: 'Color', title: '材质颜色', width: 120, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetColorType'
                            //required: true
                        }
                    }
                },
                {
                    field: 'MaterialStyle', title: '材质风格', width: 120, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        required: true,
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetMaterialStyle',
                            required: true
                        }
                    }
                },
                {
                    field: 'MaterialCategory', title: '材质类型', width: 120, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        required: true,
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetMaterialCategory'
                            //required: true
                        }
                    }
                },
                {
                    field: 'Unit', title: '单位', width: 80, sortable: false, align: 'center', editor: {
                        type: 'combobox',
                        required: true,
                        options: {
                            valueField: 'CategoryName',
                            textField: 'CategoryName',
                            method: 'get',
                            url: '/ashx/categoryhandler.ashx?Method=GetUnitCategory'
                        }
                    }
                },
                {
                    field: 'Qty', title: '数量', width: 60, sortable: false, align: 'center', editor: {
                        type: 'numberbox',
                        options: {
                            required: true,
                            precision: 2
                        }
                    },
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

                        var str = '<a href="#" onclick="cancelrow(' + index + ')"><span class="icon delete">&nbsp;&nbsp;</span>&nbsp;移除</a>';
                        str += '<a href="#" onclick="copyrow(' + index + ')"><span class="icon add">&nbsp;&nbsp;</span>&nbsp;复制</a>';
                        return str;
                    }
                }
                ]],
                toolbar: [
                    { text: '增加', iconCls: 'icon-add', handler: solutionForm.events.addrow },
                    { text: '取消', iconCls: 'icon-cancel', handler: solutionForm.events.cancelall },
                ],
                onClickCell: solutionForm.events.onClickCell,
                onEndEdit: solutionForm.events.onEndEdit
            });
        },
        loadCustomer: function () {
            $('#CustomerID').combogrid({
                panelWidth: 640,
                panelHeight: 480,
                idField: 'CustomerID',
                textField: 'CustomerName',
                fitColumns: true,
                sortName: 'CustomerID',
                toolbar: '#tb',
                url: '/ashx/customerhandler.ashx?Method=SearchCustomers',
                pagination: true,
                editable: false,
                nowrap: false,
                columns: [[
                        { field: 'CustomerName', title: '客户名称', width: 100, align: 'center' },
                        {
                            field: 'p', title: '联系地址', width: 250, halign: 'center', align: 'left', formatter: function (value, row, index) {
                                return (row.Province) + (row.City) + row.Address;
                            }
                        },
                        { field: 'LinkMan', title: '联系人', width: 80, sortable: false, align: 'center' },
                        { field: 'Mobile', title: '移动电话', width: 80, sortable: false, align: 'center' }

                ]],
                onBeforeLoad: function (param) {
                    $('#search_form_customer').find('input').each(function (index) { param[this.name] = $(this).val(); });
                },
                onSelect: function (index, row) {
                    $('#H_CustomerID').val(row.CustomerName);
                    solutionForm.controls.edit_form.form('load', row);
                    $("#Address").val(row.Province + row.City + row.Address);
                }
            });
        },
        CabinetType: function () {
            $('#CabinetType').combobox({
                url: '/ashx/categoryhandler.ashx?Method=GetCabinetType',
                textField: 'CategoryName',
                valueField: 'CategoryName',
            });
        },
        loadUploadFile: function () {
            $("#solution_uploadify").uploadify({
                width: 307,
                height: 30,
                uploader: '/ashx/fileuploadhandler.ashx?Method=FileUpload',
                swf: '/Script/uploadify/uploadify.swf',
                queueSizeLimit: 6,
                checkExisting: '/ashx/solutionhandler.ashx?Method=CheckFileExists',
                buttonText: '点击上传文件',
                fileSizeLimit: '300MB',
                auto: true,
                fileTypeExts: '*.skp;*.xml;',
                //fileTypeExts:'*.jpg;',
                multi: true,
                fileDesc: '只能选择格式 (.skp)文件',
                queueID: 'Solution_queue',
                onQueueComplete: function (event, data) {
                    if (event.errorMsg != '' || event.errorMsg != undefined) return;
                    //$("#solution_uploadify").uploadify('disable', true);
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
                        //solutionForm.controls.dgcabinet.datagrid('reload');
                        $('#SolutionFileUrl').val(data.file_url);
                        $("#imgSolution").attr('src', "/Content/images/upload_success.png");
                    }
                },
                onUploadStart: function (file) {
                    $("#solution_uploadify").uploadify("settings", "formData", { ProductID: $("#SolutionID").val(), FileType: 'SolutionFile' });
                },
                onUploadError: function (event, queueId, fileObj, errorObj) {
                    //$("#solution_uploadify").attr('disable', false);
                    showInfo(errorObj.type + "：" + errorObj.info);
                }
            });
        },
        //保存
        savesolution: function () {
            //效果文件            
            if ($('#SolutionFileUrl').val() == '') {
                //$("#SolutionFileUrl").uploadify('disable', false);
                showError('请上传方案文件。');
                return;
            }

            solutionForm.controls.edit_form.form('submit', {
                url: '/ashx/solutionhandler.ashx?Method=SaveSolution&' + jsNC(),
                data: solutionForm.controls.edit_form.serialize(),
                datatype: 'json',
                onSubmit: function () {
                    var isValid = solutionForm.controls.edit_form.form('validate');
                    if (!isValid) {
                        return isValid;
                    }
                    else {
                        $('#btn_edit_save').linkbutton('disable');
                        return isValid;
                    }
                },
                success: function (returnData) {
                    $('#btn_edit_save').linkbutton('enable');
                    returnData = eval('(' + returnData + ')');
                    if (returnData.isOk == 0) {
                        showError(returnData.message);
                    }
                    else {
                        $.messager.alert('系统提示','方案提交成功。', 'info', function () {
                            top.RefreshTab('方案管理','Solution');
                            top.closeTab('新增方案');
                        });
                    }
                }
            });
        },
        createnewsolution: function () {
            //solutionForm.controls.edit_form.form('clear');
            $('#search_form_customer').form('clear');//清空客户列表查询项
            //solutionForm.controls.dgcabinet.datagrid('loadData', { total: 0, rows: [] });//清除详细列表缓存 
            $("#SolutionID").val(solutionForm.events.loadNewGuid());
            $('#CustomerID').combogrid("grid").datagrid("reload", {});
        },
        addrow: function () {
            if (solutionForm.events.endEditing()) {
                solutionForm.controls.dgcabinet.datagrid('appendRow',
                    {
                        CabinetName: '定制衣柜A',
                        Size: '1600*1200*600',
                        Color: '暖白',
                        MaterialStyle: '摩登时代',
                        MaterialCategory: '颗粒板',
                        Unit: '套',
                        CabinetID: solutionForm.events.loadNewGuid(),
                        Qty: 1,
                        Price: 0
                    });
                editIndex = solutionForm.controls.dgcabinet.datagrid('getRows').length - 1;
                solutionForm.controls.dgcabinet.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }
        },
        copyrow: function () {
            var row = $('#dgCabinet').datagrid('getChecked');
            if (row.length == 0) {
                showError('请选择一条记录。');
                return;
            }
            if (solutionForm.events.endEditing()) {
                $('#dgCabinet').datagrid('appendRow', {
                    CabinetID: solutionForm.events.loadNewGuid(),
                    CabinetName: row[0].CabinetName,
                    Size: row[0].Size,
                    Color: row[0].Color,
                    MaterialStyle: row[0].MaterialStyle,
                    MaterialCategory: row[0].MaterialCategory,
                    Unit: row[0].Unit,
                    Remark: row[0].Remark,
                    Qty: row[0].Qty,
                    Price: row[0].Price
                });
                editIndex = solutionForm.controls.dgcabinet.datagrid('getRows').length - 1;
                solutionForm.controls.dgcabinet.datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
            }

        },
        endEditing: function () {
            if (editIndex == undefined) { return true }
            if (solutionForm.controls.dgcabinet.datagrid('validateRow', editIndex)) {
                solutionForm.controls.dgcabinet.datagrid('endEdit', editIndex);
                if (!solutionForm.events.isRepeartRow()) {
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
            var rows = solutionForm.controls.dgcabinet.datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                for (var j = i + 1; j < rows.length; j++) {
                    if (rows[i].CabinetName == rows[j].CabinetName) {
                        showError("产品名称【" + rows[j].CabinetName + "】重复添加。");
                        return false;
                    }
                }
            }
            return false;
        },
        //取消所有行
        cancelall: function () {
            solutionForm.controls.dgcabinet.datagrid('rejectChanges');
        },
        onClickCell: function (index, field) {
            if (editIndex != index) {
                if (solutionForm.events.endEditing()) {
                    solutionForm.controls.dgcabinet.datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
                    var ed = solutionForm.controls.dgcabinet.datagrid('getEditor', { index: index, field: field });
                    if (ed) {
                        ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                    }
                    editIndex = index;
                } else {
                    setTimeout(function () {
                        solutionForm.controls.dgcabinet.datagrid('selectRow', editIndex);
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
        searchCustomer: function () {
            $('#CustomerID').combogrid("grid").datagrid("reload");
        }
    }
};

function cancelrow(index) {
    if (solutionForm.events.endEditing()) {
        if (index == undefined) { return }
        $('#dgCabinet').datagrid('deleteRow', index);
        var rows = $('#dgCabinet').datagrid("getRows");
        $('#dgCabinet').datagrid("loadData", rows);
        index = undefined;
    }
}

$(function () {
    solutionForm.init();    
});

//复制行
function copyrow(index) {
    solutionForm.controls.dgcabinet.datagrid('selectRow', index)
                         .datagrid('beginEdit', index);
    var row = $('#dgCabinet').datagrid('getSelected');
    if (solutionForm.events.endEditing()) {
        $('#dgCabinet').datagrid('appendRow', {
            CabinetID: solutionForm.events.loadNewGuid(),
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
