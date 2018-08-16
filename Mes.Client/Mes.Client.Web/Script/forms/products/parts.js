var me = {
    dgdetail: null,
    search_form: null,
    search_window: null,
    idFiled: 'ProductID',
    actionUrl: '/ashx/componentshandler.ashx'
};

$(function () {
    //初始化页面
    pageInit();
    //加载数据
    //loadGrid();    
});


//初始化页面
function pageInit() {
    me.search_form = $('#search_form');
    me.dgdetail = $('#dgdetail');
   

    $('#btn_search_ok').linkbutton();
    $('#btn_search_ok').click(function () {
        loadGrid(1);
    });
}

function loadGrid(pageNumber) {
    $.ajax({
        url: me.actionUrl + '?Method=SearchParts&page=' + pageNumber + '&' + jsNC(),
        collapsible: false,
        fitColumns: false,
        pagination: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        success: function (data) {
            if (data.isOk == 0) {
                return;
            }
            $('#pp').pagination({
                total: data.total,
                pageSize: 20,
                onSelectPage: function (pageNumber, pageSize) {
                    loadGrid(pageNumber);
                }
            });
            $('#list').html('');
            $.each(data.rows, function (index, row) {
                $('#list').append("<li style='width:200px;height:160px; float:left; border:1px solid #eee;padding:5px;text-align:center;'><a href='javascript:void(0);'><div><img src='../ashx/download_document.ashx?pid=" + row.ComponentID + "' style='height:140px auto; width:200px auto;' alt=''/><br/><span>" + row.ComponentName + "</span></div></a></li>");
            });
        }

    });
}

//查看详情        
function showdetail(args) {
    top.addTab("管理【" + args[1] + "】", "./PartsShow.aspx?ProductID=" + args[0] + "&" + jsNC());
}