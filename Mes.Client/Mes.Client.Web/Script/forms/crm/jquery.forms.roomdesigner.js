
var ArrayPath = [];//上传文件路径

//删除数据集合中的对象
function delArrayPathById(id) {
    for (var i = 0; i < ArrayPath.length; i++) {
        if (ArrayPath[i].id == id) {
            ArrayPath.splice(i, 1);
        }
    };
};

(function ($) {
    'use strict';
    document.msCapsLockWarningOff = true;
    var roomdesignerForm = {
        init: function () {
            roomdesignerForm.initControls();
            roomdesignerForm.events.loadData();
            roomdesignerForm.controls.searchData.on('click', roomdesignerForm.events.loadData);//加载数据                
            roomdesignerForm.controls.SaveRoomDesigner.on('click', roomdesignerForm.events.SaveRoomDesigner);//保存
            roomdesignerForm.controls.edit_cancel.on('click', roomdesignerForm.events.Cancel);//取消
            roomdesignerForm.controls.SaveDesignUpload.on('click', roomdesignerForm.events.SaveDesignUpload);//保存
            roomdesignerForm.controls.designuploadedit_cancel.on('click', roomdesignerForm.events.CancelDesignUpload);//取消
            roomdesignerForm.controls.searchCustomer.on('click', roomdesignerForm.events.searchCustomer);//查询客户
            roomdesignerForm.controls.searchUser.on('click', roomdesignerForm.events.searchUser);//查询客户
            roomdesignerForm.controls.download_image.on('click', roomdesignerForm.events.downloadImage);//下载图片
            roomdesignerForm.controls.download_image.on('click', roomdesignerForm.events.downloadCAD);//下载CAD
            roomdesignerForm.events.loadCustomer();
            roomdesignerForm.events.loadUser();
            //roomdesignerForm.events.loadUploadify();
            roomdesignerForm.events.verifyright();
        },
        initControls: function () {
            roomdesignerForm.controls = {
                pid: getUrlParam('pid'),
                searchData: $('#btn_search_ok'),//查询按钮
                dgdetail: $('#dgdetail'),//填充数据
                search_form: $('#search_form'),//查询表单
                edit_form: $('#edit_form'),//编辑表单
                designuploadedit_form: $("#designuploadedit_form"),
                edit_cancel: $('#btn_edit_cancel'),
                designuploadedit_cancel: $('#btn_designuploadedit_cancel'),
                SaveRoomDesigner: $('#btn_edit_save'),//保存
                SaveDesignUpload: $('#btn_designuploadedit_save'),//保存
                edit_window: $('#edit_window'),
                designuploadedit_window: $('#designuploadedit_window'),
                searchCustomer: $('#btn_search_customer'),//查询客户
                searchUser: $('#search_form_username'),//查询设计者        
                download_image: $("download_image"),
                download_cad: $("#download_cad")
            };
            $('#btn_search_ok').linkbutton();
            $('#btn_search_customer').linkbutton();
            $('#search_form_username').linkbutton();
        },
        events: {
            loadData: function () {
                roomdesignerForm.controls.dgdetail.datagrid({
                    idField: 'DesignerID',
                    url: '/ashx/RoomDesignerHandler.ashx?Method=SearchRoomDesigners&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns:
                      [[
                        {
                            field: 'DesignerNo', title: '订单编号', width: 100, align: 'center', formatter: function (value, rowData, rowIndex) {
                                return rowData['DesignerNo'];
                            }
                        },
                        {
                            field: 'CustomerName', title: '客户名称', width: 120, align: 'center', formatter: function (value, row, index) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="showdetail(\'' + row['DesignerID'] + '\');"><span style="color:#0094ff;">' + value + '</span></a>';
                                return strReturn;
                            }
                        },
                        {
                            field: 'Building', title: '客户地址', width: 250, align: 'center', formatter: function (value, rowData, rowIndex) {
                                return rowData.VillageName + rowData['Building'] + '栋' + rowData['Unit'] + '单元' + rowData['RoomNo'] + '房';
                            }
                        },
                        {
                            field: 'Rooms', title: '房型', width: 120, align: 'center', formatter: function (value, rowData, rowIndex) {
                                return rowData['Rooms'] + '房' + rowData['SittingAndDiningRoom'] + '厅';
                            }
                        },
                        {
                            field: 'TotalAreal', title: '面积', width: 80, sortable: false, align: 'center', formatter: function (value, row, index) {
                                return value + '<span>M<Sup>2</Sup></span>';
                            }
                        },
	                    { field: 'UserName', title: '测量者', width: 120, align: 'center' },
	                    { field: 'FamilyMembers', title: '家庭人员', width: 70, sortable: false, align: 'center' },
                        { field: 'Budget', title: '预算(万元)', width: 80, sortable: false, align: 'center' },
                        { field: 'Color', title: '喜欢颜色', width: 80, sortable: false, align: 'center' },
	                    { field: 'Style', title: '装修风格', width: 80, sortable: false, align: 'center' },
	                    {
	                        field: 'Status', title: '状态', width: 80, sortable: false, align: 'center',
	                        formatter: function (value, rowData, rowIndex) {
	                            switch (value) {
	                                case 'N':
	                                    return '待酷家乐设计';
	                                    break;
	                                case 'C':
	                                    return '已酷家乐设计';
	                                    break;
	                                case 'P':
	                                    return '待导入拆单文件';
	                                    break;
	                                default:
	                                    return '';
	                            }
	                        }
	                    },
                        {
                            field: 'Created', title: '量尺时间', width: 120, sortable: false, align: 'center', formatter: function (value, rowData, rowIndex) {
                                if (value == undefined) return "";
                                return (new Date(value.replace(/-/g, "/"))).Formats("yyyy-MM-dd HH:mm:ss");
                            }
                        },
                        {
                            field: 'TODO', title: '操作', width: 100, sortable: false, align: 'center', formatter: function (value, row, index) {

                                //$('#SolutionID').val(row['']);
                                if (row['Status'] == 'N') {
                                    var _link = '<a href="javascript:void(0)" id="designUpload" class="l-btn-text" title="上传设计方案" onClick="load223(\'' + row['DesignerNo'] + '\',\'上传设计方案\',' + '\'' + row['CustomerID'] + '\',\'' + row['DesignerID'] + '\');"><span style="color:#0094ff;">上传设计方案</span></a>';
                                    return _link;
                                } else if (row['Status'] == 'C'||row['Status']=='P') {
                                    return '已上传设计方案';
                                } else {
                                    return '';
                                }
                            }
                        },
                        { field: 'Remark', title: '备注', width: 100, sortable: false, align: 'center' }
                      ]],
                    toolbar: ['-'
                     , { text: '新增', iconCls: 'icon-add', handler: function () { roomdesignerForm.events.NewRoomDesigner(); } }, '-'
                     //, { text: '编辑', iconCls: 'icon-edit', handler: function () { roomdesignerForm.events.UpdateRoomDesigner('update'); } }, '-'
                    //, { text: '详细', iconCls: 'icon-search', handler: function () { roomdesignerForm.events.UpdateRoomDesigner('view'); } }, '-'
                    ],
                    onBeforeLoad: function (param) {
                        roomdesignerForm.controls.search_form.find('select').each(function (index) {
                            param[this.name] = $(this).val();
                        });
                        roomdesignerForm.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                        });
                    }
                });
            },
            loadCustomer: function () {
                $('#CustomerID').combogrid({
                    panelWidth: 750,
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
                            { field: 'Tel', title: '固定电话', width: 80, sortable: false, align: 'center' },
                            { field: 'Mobile', title: '移动电话', width: 80, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_customer').find('input').each(function (index) { param[this.name] = $(this).val(); });
                    },
                    onSelect: function (index, row) {
                        roomdesignerForm.controls.edit_form.form('load', row);
                    }
                });
            },
            loadUser: function () {
                $('#Designer').combogrid({
                    panelWidth: 640,
                    panelHeight: 480,
                    idField: 'UserID',
                    textField: 'UserName',
                    fitColumns: true,
                    sortName: 'UserID',
                    toolbar: '#tb_user',
                    url: '/ashx/partnerUserHandler.ashx?Method=SearchPartnerUser',
                    pagination: true,
                    editable: false,
                    nowrap: false,
                    columns: [[
                            { field: 'UserCode', title: '用户编号', width: 100, align: 'center' },
                            { field: 'UserName', title: '姓名', width: 100, align: 'center' },
                            { field: 'Position', title: '职位', width: 80, sortable: false, align: 'center' }
                    ]],
                    onBeforeLoad: function (param) {
                        $('#search_form_username').find('input').each(function (index) {
                            param[this.name] = $(this).val();
                            param['IsSystem'] = false;
                        });
                    },
                    onSelect: function (index, row) {
                        roomdesignerForm.controls.edit_form.form('load', row);
                    }
                });
            },
            loadUploadify: function () {
                //上传文件
                $("#Image_Spk_file").uploadify({
                    width: 290,
                    height: 30,
                    uploader: '/ashx/RoomDesignerHandler.ashx?Method=FileUpload',
                    swf: '/Script/uploadify/uploadify.swf',
                    checkExisting: '/ashx/solutionhandler.ashx?Method=CheckFileExists',
                    queueSizeLimit: 1,
                    buttonText: '点击上传文件',
                    fileSizeLimit: '300MB',
                    auto: true,
                    multi: false,
                    //fileTypeExts: '*.zip',
                    fileDesc: '只能选择格式(.zip)压缩文件',
                    queueID: 'Solution_queue',
                    onQueueComplete: function (event, data) {
                        if (event.errorMsg != '' || event.errorMsg != undefined) return;
                    },
                    onUploadSuccess: function (file, data, response) {
                        if (data != "") {
                            data = $.parseJSON(data);
                        }
                        if (data.isOk == 0) {
                            showError(data.message);
                        } else {
                            $("#imgSolution").attr('src', "/Content/images/upload_success.png");
                            $("#RoomDesignerFiles").val(data.file_url);

                        }
                        // alert(data.file_url);
                        console.log(data.file_url);
                    },
                    onUploadStart: function (file) {
                        $("#Image_Spk_file").uploadify("settings", "formData", { DesignerID: $("#DesignerID").val(), FileType: 'RoomDesignerFile', Type: file.type });
                    },
                    onUploadError: function (event, queueId, fileObj, errorObj) {
                        showInfo(errorObj.type + "：" + errorObj.info);
                    }
                });
            },
            NewRoomDesigner: function () {
                roomdesignerForm.controls.edit_form.find('input').each(function () {
                    $(this).attr('readonly', false);
                });
                //roomdesignerForm.events.loadUploadify();
                roomdesignerForm.controls.edit_window.find('div[region="south"]').css('display', 'block');
                roomdesignerForm.controls.edit_window.window('open');
                $('#edit_form').form('clear');//添加之前先清空表单
                $("#imgSolution").attr('src', "/Content/images/solution_bg.png");
                $('#search_form_customer').form('clear');//清空客户列表查询项
                $('#search_form_username').form('clear');//清空设计者列表查询项
                $("#DesignerID").val(roomdesignerForm.events.loadNewGuid());
                $('#CustomerID').combogrid("grid").datagrid("reload", {});
            },
            UpdateRoomDesigner: function (action) {
                switch (action) {
                    case 'update':
                        var selectedRows = roomdesignerForm.controls.dgdetail.datagrid('getSelections');
                        if (selectedRows.length > 0) {
                            $.ajax({
                                url: '/ashx/RoomDesignerHandler.ashx?Method=UpdateRoomDesigner&DesignerID=' + selectedRows[0]['DesignerID'],
                                success: function (data) {
                                    roomdesignerForm.controls.edit_form.form('load', data);
                                    var d = new Date(data.Designed).Formats('yyyy-MM-dd');
                                    $('#Designed').datebox('setValue', d);
                                    $('#Status').val(getRoomDesigerStatusName(data.Status));
                                }
                            });
                            roomdesignerForm.controls.edit_form.find('input').each(function () {
                                $(this).attr('readonly', false);
                            });

                            roomdesignerForm.controls.edit_form.find('#image').remove();
                            roomdesignerForm.controls.edit_form.find('#file').remove();
                            roomdesignerForm.controls.edit_form.find('.status').remove();

                            var imageStr = '<tr id="image">' +
                                             '<td class="lbl-caption">' + '上传图片:' + '</td>' +
                                             '<td><input type="file" id="Image_file" name="Image_file"/></td>' +
                                             '<td><span id=imageInfo style="padding-left:30px;color:red;"></span></td></tr>';

                            var fileStr = '<tr id="file">' +
                                          '<td class="lbl-caption">' + '上传CAD文件:' + '</td>' +
                                          '<td><input type="file" id="Cad_file" name="Cad_file"/></td>' +
                                          '<td><span id="cadInfo" style="padding-left:30px;color:red;"></span></td></tr>';

                            var statusStr = '<td class="status" style="text-align:right;">状态:</td>' +
                                            '<td class="status"><input id="Status" name="Status" readonly="true" style="width:100%; height:30px;"/></td>';

                            roomdesignerForm.controls.edit_form.find('#tab').after(imageStr);
                            roomdesignerForm.controls.edit_form.find('#tab').append(statusStr);
                            roomdesignerForm.controls.edit_form.find('#image').after(fileStr);
                            //roomdesignerForm.events.loadUploadify();

                            roomdesignerForm.controls.edit_window.find('div[region="south"]').css('display', 'block');

                            $('#search_form_customer').form('clear');//清空客户列表查询项
                            $('#CustomerID').combogrid("grid").datagrid("reload");

                            $('#search_form_username').form('clear');//清空客户列表查询项
                            //$('#Designer').combogrid("grid").datagrid("reload");
                            roomdesignerForm.controls.edit_window.window('open');
                        } else {
                            showError('请选择一条记进行操作!');
                            return;
                        }
                        break;
                        //case 'view':
                        //    var selectedRows = roomdesignerForm.controls.dgdetail.datagrid('getSelections');
                        //    if (selectedRows.length > 0) {
                        //        $.ajax({
                        //            url: '/ashx/RoomDesignerHandler.ashx?Method=UpdateRoomDesigner&DesignerID=' + selectedRows[0]['DesignerID'],
                        //            success: function (data) {
                        //                roomdesignerForm.controls.edit_form.form('load', data);                         
                        //            }
                        //        });
                        //        roomdesignerForm.controls.edit_form.find('input').each(function () {
                        //              $(this).attr('readonly', true);
                        //        });
                        //        roomdesignerForm.controls.edit_form.find('#image').remove();
                        //        roomdesignerForm.controls.edit_form.find('#file').remove();

                        //        roomdesignerForm.controls.edit_window.window('open');
                        //        roomdesignerForm.controls.edit_window.find('div[region="south"]').css('display', 'none');
                        //    } else {
                        //        showError('请选择一条记进行操作!');
                        //        return;
                        //    }
                        //    break;
                }
            },
            SaveRoomDesigner: function () {
                if (ArrayPath.length < 1) {
                    showError("请先上传订单文件！");
                    return;
                }
                $("#RoomDesignerFiles").val(JSON.stringify(ArrayPath));
                if (roomdesignerForm.controls.edit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/RoomDesignerHandler.ashx?Method=SaveRoomDesigner',
                        data: roomdesignerForm.controls.edit_form.serialize(),
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    showInfo(returnData.message);
                                    roomdesignerForm.controls.edit_window.window('close');
                                    roomdesignerForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            SaveDesignUpload: function () {
                if (ArrayPath.length < 1) {
                    showError("请上传设计方案！");
                    return;
                }
                $("#RoomDesignerFiles").val(JSON.stringify(ArrayPath));

                if (roomdesignerForm.controls.designuploadedit_form.form('validate')) {
                    $.ajax({
                        url: '/ashx/solutionhandler.ashx?Method=SaveSolutionDLS',
                        //data: roomdesignerForm.controls.designuploadedit_form.serialize(),
                        data: {
                            ReferenceID: $("#ReferenceID").val(),
                            CustomerID: $("#CustomerID").val(),
                            RoomDesignerFiles: $("#RoomDesignerFiles").val(),
                            DesignerNo: $("#DesignerNo").val()
                        },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    showInfo(returnData.message);
                                    roomdesignerForm.controls.designuploadedit_window.window('close');
                                    roomdesignerForm.controls.dgdetail.datagrid('reload');
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            },
            Cancel: function () {
                roomdesignerForm.controls.edit_window.window('close');
            },
            CancelDesignUpload: function () {
                roomdesignerForm.controls.designuploadedit_window.window('close');
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
            },
            searchUser: function () {
                $('#Designer').combogrid("grid").datagrid("reload");
            },

            //获取权限
            verifyright: function () {
                $.ajax({
                    url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + roomdesignerForm.controls.pid,
                    success: function (data) {
                        if (data) {
                            rightType(data);
                        }
                    }
                });
            }
        }
    };

    function rightType(data) {
        $('div.datagrid-toolbar a').eq(0).hide()//toolbar第一按钮
        $('div.datagrid-toolbar div').eq(0).hide(); //隐藏第一条分隔线

        $('div.datagrid-toolbar a').eq(1).hide()//toolbar第二按钮
        $('div.datagrid-toolbar div').eq(1).hide(); //隐藏第二条分隔线


        $(data).each(function (i, obj) {
            switch (obj.PrivilegeItemCode) {
                case 'Add':
                    $('div.datagrid-toolbar a ').eq(0).show();
                    $('div.datagrid-toolbar div').eq(0).show();
                    break;
                case 'Modify':
                    $('div.datagrid-toolbar a ').eq(1).show();
                    $('div.datagrid-toolbar div').eq(1).show();
                    break;
                default: break;
            }
        });
    }

    $(function () {
        roomdesignerForm.init();
    });


})(jQuery);

function showdetail(DesignerID) {


    var source = getUrlParam('source');
    if (source == "null" || source == null) {//ems
        top.addTab("量尺详情", "/View/crm/roomdesignerShow.aspx?DesignerID=" + DesignerID + "&" + jsNC(), 'table');
    }
    else {
        window.location.href = "/View/crm/roomdesignerShow.aspx?DesignerID=" + DesignerID + "&" + jsNC();
    }

}

function load223(DesignerNo, StepName, CustomerID, ReferenceID) {
    var _self = $(this);
    switch ($.trim(StepName)) {
        case '上传设计方案':
            $('#designuploadedit_window').find('div[region="south"]').css('display', 'block');
            $('#designuploadedit_window').window('open');
            $('#designuploadedit_form').form('clear');//添加之前先清空表单
            $("#imgSolution").attr('src', "/Content/images/solution_bg.png");
            $('#search_form_customer').form('clear');//清空客户列表查询项
            $('#search_form_username').form('clear');//清空设计者列表查询项
            //$('#CustomerID').combogrid("grid").datagrid("reload", {});
            $("#CustomerID").val(CustomerID);
            $("#ReferenceID").val(ReferenceID);
            $("#DesignerNo").val(DesignerNo);
            //OpTab('导入订单', '/View/orders/orders_import.aspx');
            break;
        default:
            break;
    }
}
