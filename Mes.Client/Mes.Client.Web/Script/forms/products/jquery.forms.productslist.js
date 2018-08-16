'use strict';
document.msCapsLockWarningOff = true;
var productListForm = {
    init: function () {
        productListForm.initControls();
        productListForm.events.loadCategory();//加载数据     
        productListForm.events.loadGrid(1, '');
        productListForm.controls.Search.on('click', function () {
            productListForm.events.loadGrid(1, '')
        });
    },
    initControls: function () {
        productListForm.controls = {
            pid: getUrlParam('pid'),
            category_tree: $('#category_tree'),
            actionUrl: '/ashx/producthandler.ashx',
            Search: $('#btn_search_ok'),
        }
    },
    events: {
        loadCategory: function () {
            productListForm.controls.category_tree.tree({
                url: '/ashx/categoryhandler.ashx?Method=GetCategoryTreeByCategoryCode&CategoryCode=ProductCategory&RootName=' + escape('产品分类'),
                loadMsg: '正在加载数据，请稍候....',
                state: 'closed',
                onClick: function (node) {
                    productListForm.events.loadGrid(1, node.id);
                },
                onLoadSuccess: function (node, param) {
                    var nd = productListForm.controls.category_tree.tree('getRoot');
                    productListForm.controls.category_tree.tree('expand', nd.target);
                }
            });
        },
        loadGrid: function (pageNumber, CategoryID) {
            $.ajax({
                url: productListForm.controls.actionUrl + '?Method=SearchProducts&CategoryID=' + CategoryID + '&page=' + pageNumber + '&' + jsNC(),
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
                            loadGrid(pageNumber, '');
                        }
                    });
                    $('#list').html('');
                    $.each(data.rows, function (index, row) {
                        var img = '';
                        if (row.ImageUrl == undefined || row.ImageUrl == '')
                            img = '<img src="/Content/images/products/sample.jpg"  />'
                        else
                            img = '<img src="/ashx/download_document.ashx?path=' + escape(row.ImageUrl) + '" />'

                        $('#list').append('<li>'
                            + '<div style="width: 320px auto; height: 210px; border: solid 1px #eee;">'
                                + '<div class="imgwrap">'
                                    + img
                                + '</div>'
                                + '<div class="product_item">'
                                    + '<table style="width: 100%;">'
                                        + '<tr>'
                                            + '<td class="title" colspan="2">' + row.ProductName + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">产品编号：</td>'
                                            + '<td>' + row.ProductCode + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">上市时间：</td>'
                                            + '<td>' + (new Date(row.Created.replace(/-/g, "/"))).Formats("yyyy-MM-dd") + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">型号/款式：</td>'
                                            + '<td>' + row.MaterialStyle + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">颜色：</td>'
                                            + '<td>' + row.Color + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">尺寸：</td>'
                                            + '<td>' + row.Size + '</td>'
                                        + '</tr>'
                                        + '<tr>'
                                            + '<td class="caption">价格：</td>'
                                            + '<td><span style="color: red">￥' + row.Price + '</span></td>'
                                        + '</tr>'
                                    + '</table>'
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

