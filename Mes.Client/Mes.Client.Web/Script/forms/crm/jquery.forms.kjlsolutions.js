'use strict';
document.msCapsLockWarningOff = true;
var productListForm = {
    init: function () {
        productListForm.initControls();
        productListForm.events.loadGrid(1, '');
        productListForm.controls.Search.on('click', function () {
            productListForm.events.loadGrid(1, '')
        });
    },
    initControls: function () {
        productListForm.controls = {
            pid: getUrlParam('pid'),
            actionUrl: '/ashx/kjl_solutions.ashx',
            Search: $('#btn_search_ok'),
        }
    },
    events: {
        loadGrid: function (pageNumber) {
            $.ajax({
                url: productListForm.controls.actionUrl + '?Method=GetSolutionTyUserID&page=' + pageNumber + '&' + jsNC(),
                collapsible: false,
                fitColumns: false,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                success: function (data) {
                    data.total = 50;
                    $('#pp').pagination({
                        total: data.total,
                        pageSize: 20,
                        onSelectPage: function (pageNumber, pageSize) {
                            loadGrid(pageNumber, '');
                        }
                    });
                    $('#list').html('');
                    $.each(data, function (index, row) {
                        var img = '';
                        if (row.obsPlan.smallPics == undefined || row.obsPlan.smallPics == '')
                            img = '<img src="/Content/images/products/sample.jpg"  />'
                        else
                            img = '<img src="' + row.obsPlan.smallPics + '" />'
                        var created = new Date(row.created).Formats("yyyy-MM-dd");
                        var modified = new Date(row.modifiedTime).Formats("yyyy-MM-dd"); //width: 320px auto; height: 280px; border: solid 1px #eee;
                        $('#list').append('<li>'
                            + '<div style="width:100%;">'
                                + '<div style="width: 95%; height: 30px; font-size: 16pt; line-height: 30px; padding-left: 10px; font-weight: bold; border-bottom: solid 1px #eee;">' + row.name + '</div>'
                                + '<div class="imgwrap">'
                                    + img
                                + '</div>'
                                + '<div class="product_item">'
                                    + '<table style="width: 100%;">'
                                        + '<tr>'
                                            + '<td class="caption">地址：</td>'
                                            + '<td>' + row.obsPlan.planCity + row.obsPlan.commName + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">户型：</td>'
                                            + '<td>' + row.obsPlan.specName + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">设计时间：</td>'
                                            + '<td>' + created + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">最后修改：</td>'
                                            + '<td>' + modified + '</td>'
                                        + '</tr>'
                                    + '</table>'
                                + '</div>'
                                + '<div style="clear: both; width: 320px; line-height: 30px; text-align: center; padding-top: 10px;">'
                                    + '<div class="kjl-button" onclick="jsDesigner(\'' + row.obsDesignId + '\');">去装修</div>'
                                    + '<div class="kjl-button" onclick="jsDownloadSolution(\'' + row.obsDesignId + '\')">导出拆单文件</div>'
                                + '</div>'
                            + '</div>'
                        + '</li>');
                    });
                }
            });
        }
    }
};
$(function () {
    productListForm.init();
});

function jsDownloadSolution(id) {
    window.open("/View/download/download_kjlsolution.aspx?obsDesignId=" + id);
}

function jsDesigner(id) {
    $.ajax({
        url: productListForm.controls.actionUrl + '?Method=OpenSolution&' + jsNC(),
        data: { 'designid': id },
        success: function (data) {
            if (data.errorCode == "0") {
                window.open(data.errorMsg);                
            }
            else {
                showError(data.errorMsg);
            }
        }
    });
}

function jsNewSolution() {
    $.ajax({
        url: productListForm.controls.actionUrl + '?Method=API_Login&' + jsNC(),
        success: function (data) {
            if (data.errorCode == "0") {
                window.open(data.errorMsg);
            }
            else {
                showError(data.errorMsg);
            }
        }
    });
}