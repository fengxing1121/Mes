(function ($) {
    document.msCapsLockWarningOff = true;
    var RoomDesignerShowForm = {
        init: function () {
            RoomDesignerShowForm.initControls();
            RoomDesignerShowForm.events.loadData();
            RoomDesignerShowForm.events.loadRoomDesignerFile();
        },
        initControls: function () {
            RoomDesignerShowForm.controls = {
                edit_form: $("#edit_form"),
                dgroomfile: $("#dgroomfile"),
                DesignerID: getUrlParam('DesignerID')
            };
        },
        events: {
            loadData: function () {               
                $.ajax({
                     url: '/ashx/RoomDesignerHandler.ashx?Method=UpdateRoomDesigner&DesignerID=' + RoomDesignerShowForm.controls.DesignerID,
                     success: function (data) {
                         RoomDesignerShowForm.controls.edit_form.form('load', data);
                         //$("#Designer").val('');
                         //获取客户信息
                         $.ajax({
                             url: '/ashx/customerhandler.ashx?Method=GetCustomer&CustomerID=' + data.CustomerID,
                             success: function (data) {
                                 $("#CustomerName").val(data.CustomerName);
                             }
                         });
                         //设计者信息
                         $.ajax({
                             url: '/ashx/UsersHandle.ashx?Method=GetUser&UserID=' + data.Designer,
                             success: function (data) {
                                 //$("#Designer").val(data.UserName);
                             }
                         });
                     }
                });
                RoomDesignerShowForm.controls.edit_form.find('input').each(function () {
                         $(this).attr('readonly', true);
                });
            },

            loadRoomDesignerFile: function () {
                RoomDesignerShowForm.controls.dgroomfile.datagrid({
                    idField: 'CustomerID',
                    url: '/ashx/RoomDesignerFileHandler.ashx?Method=GetRoomDesignerFile',
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                         { field: 'FileName', title: '文件名称', width: 100, align: 'center' },                
                         {
                             field: 'Created', 'title': '上传时间', width: 100, sortable: false, align: 'center',
                             formatter: function (value, rowData, rowIndex) {
                                 return ChangeDateFormat(value);
                             }
                         },
                         {
                             field: 'action', title: '操作', width: 90, sortable: false, align: 'center',
                             formatter: function (value, rowData, rowIndex) {
                             var str = '<img style="cursor:pointer;" onclick="downloadfile(\'' + rowData.FileID + '\')" src="/Content/images/exticons/page/page_white_put.png" alt="下载文件"/>&nbsp;&nbsp;';
                                 return str;
                             }
                         }
                    ]],
                    //toolbar: [
                    //   { text: '新增', iconCls: 'icon-add', handler: function () { roomdesignerForm.events.NewRoomDesigner(); } }
                    //],
                    onBeforeLoad: function (param) {
                        param["DesignerID"] = RoomDesignerShowForm.controls.DesignerID;
                    }
                });
            }
        }
    };

    $(function () {
        RoomDesignerShowForm.init();
    });
})(jQuery);

function downloadfile() {
    var FileID = arguments[0];
    $.messager.confirm('系统提示', '确定要下载文件吗？', function (flag) {
        if(flag)
        {
            var form = $("<form>");   //定义一个form表单
            form.attr('style', 'display:none');   //在form表单中添加查询参数
            form.attr('target', '');
            form.attr('method', 'post');
            form.attr('action', "/View/download/download_rooomDesigerFile.aspx");
            var down = $('<input>');
            down.attr('type', 'hidden');
            down.attr('name', 'FileID');
            down.attr('value', FileID);
            $('body').append(form);  //将表单放置在web中 
            form.append(down);   //将查询参数控件提交到表单上
            form.submit();       
        }
    });
}
