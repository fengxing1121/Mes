'use strict';
document.msCapsLockWarningOff = true;
var indexForm = {
    init: function () {
        indexForm.initControls();
        indexForm.events.tabClose();
        indexForm.events.tabCloseEven();
        indexForm.events.initMenu();
        //indexForm.events.initShortLink();
        indexForm.events.SetUserInfo();
        $('#editpass').click(function () {
            indexForm.controls.win_changepwd.window('open');
        });
        $('#btnCancel').click(function () {
            indexForm.controls.win_changepwd.window('close');
        })
        $('#loginOut').click(function () {
            $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/loginhandler.ashx?Method=LoginOut',
                        data: {},
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 1) {
                                    location.href = '/View/Account/login.aspx';
                                } else {
                                    showError(returnData.message);
                                }
                            }
                        }
                    });
                }
            });
        });
        $('#btnConfirm').click(function () {
            indexForm.events.changePwd();
        });

        indexForm.controls.FavoriteSetting.on('click', function () { indexForm.events.openFavoriteSetting(); });
        indexForm.controls.SaveFavorite.on('click', function () { indexForm.events.saveFavoriteSetting(); });
        indexForm.controls.CloseFavorite.on('click', function () { indexForm.events.closeFavoriteSetting(); });
        indexForm.controls.closePrivilege.on('click', function () { indexForm.events.closeprivilegeSetting(); });
       // indexForm.events.loadFavoriteGrid();
    },
    initControls: function () {
        indexForm.controls = {
            favorite_window: $('#favorite_window'),
            edit_form: $('#favorite_form'),
            win_changepwd: $('#win_changepwd'),
            win_changepwd_form: $('#win_changepwd_form'),
            OldPassword: $('#OldPassword'),
            NewPassword: $('#NewPassword'),
            _menus: null,
            SaveFavorite: $('#btnSaveFavorite'),
            CloseFavorite: $('#btnCloseFavorite'),
            FavoriteSetting: $('#btn_FavoriteSetting'),
            dgfavorite: $('#dgfavorite'),
            dgprivilege: $('#dgprivilege'),
            closePrivilege: $('#btnClosePrivilege'),
            privilege_window: $('#privilege_window'),
        }
    },
    events: {
        ////初始化菜单
        initMenu: function () {
            $.ajax({
                url: "/ashx/indexhandler.ashx?Method=InitMenus",
                dataType: 'text',
                success: function (returnData) {
                    indexForm.controls._menus = eval('(' + returnData + ')');
                    if (indexForm.controls._menus.isOk == 0) {
                        indexForm.msgShow("系统提示", _menus.message, 'error');
                        return;
                    }
                    indexForm.events.InitLeftMenu();
                }
            });
        },
        InitLeftMenu: function () {
            $("#nav").accordion({ animate: false });
            $.each(indexForm.controls._menus.menus, function (i, n) {
                var menulist = '';
                menulist += '<ul>';
                $.each(n.menus, function (j, o) {
                    var url = o.url;
                    if (url.indexOf('?') > 0)
                        url += '&' + jsNC();
                    else
                        url += '?' + jsNC();
                    //menulist += '<li><div><a ref="' + o.menuid + '" href="#" rel="' + url + '" ><span class="icon ' + o.icon + '" >&nbsp;</span><span class="nav">' + o.menuname + '</span></a></div></li> ';
                    menulist += '<li><div><a ref="' + o.menuid + '" href="#" rel="' + url + '" ><span class="nav">' + o.menuname + '</span></a></div></li> ';
                })
                menulist += '</ul>';
                $('#nav').accordion('add', {
                    title: n.menuname,
                    content: menulist,
                    iconCls: 'icon ' + n.icon
                });
            });
            $('.easyui-accordion li a').click(function () {
                var tabTitle = $(this).children('.nav').text();
                var url = $(this).attr("rel");//+ "?nocache=" + (new Date()).getTime();
                var menuid = $(this).attr("ref");
                var icon = indexForm.events.getIcon(menuid, icon);
                var tabs = $('#tabs').tabs().tabs('tabs');
                if (url.indexOf('?') > 0) {
                    url = url + '&pid=' + menuid;
                }
                else {
                    url = url + '?pid=' + menuid;
                }
                if (tabs.length < parseInt($('#tabmax').val())) {
                    indexForm.events.addTab(tabTitle, url, icon);
                }
                else {
                    showInfo("选项卡打开过多,请关闭部分窗口再操作！");
                }
                $('.easyui-accordion li div').removeClass("selected");
                $(this).parent().addClass("selected");
            }).hover(function () {
                $(this).parent().addClass("hover");
            }, function () {
                $(this).parent().removeClass("hover");
            });
            //选中第一个
            //var panels = $('#nav').accordion('panels');
            //if (panels.length > 0) {
            //    var t = panels[0].panel('options').title;
            //    $('#nav').accordion('select', t);
            //}
        },
        ///*修改密码*/
        changePwd: function () {
            if (indexForm.controls.win_changepwd_form.form('validate')) {
                if (indexForm.controls.win_changepwd_form.find("#OldPassword").val() == indexForm.controls.win_changepwd_form.find("#NewPassword").val()) {
                    showError('新密码与旧密码不能相同,请重新输入。');
                    return;
                }
                if (VerifyPwdStrength.toLowerCase() == 'true') {
                    if ((/^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/.test(indexForm.controls.win_changepwd_form.find("#NewPassword").val()))) {
                        showError('密码由字母和数字组成，长度至少6个字符。');
                        return;
                    }
                }
                $.ajax({
                    url: '/ashx/usershandle.ashx?Method=ModifiyPsw&OldPassword=' + indexForm.controls.win_changepwd_form.find("#OldPassword").val() + '&NewPassword=' + indexForm.controls.win_changepwd_form.find("#NewPassword").val(),
                    data: indexForm.controls.win_changepwd_form.serialize(),
                    success: function (returnData) {
                        if (returnData) {
                            if (returnData.isOk == 1) {
                                showInfo('恭喜，密码修改成功！<br>您的新密码为：' + indexForm.controls.win_changepwd_form.find("#NewPassword").val() + ',请保管好密码。');
                                indexForm.controls.win_changepwd_form.form('clear');
                                indexForm.controls.win_changepwd.window('close');
                            } else {
                                showError(returnData.message);
                            }
                        }
                    }
                });
            }
        },
        getIcon: function (menuid) {
            var icon = 'icon ';
            $.each(indexForm.controls._menus.menus, function (i, n) {
                $.each(n.menus, function (j, o) {
                    if (o.menuid == menuid) {
                        icon += o.icon;
                    }
                })
            })
            return icon;
        },
        tabCloseEven: function () {
            //刷新
            $('#mm-tabupdate').click(function () {
                var currTab = $('#tabs').tabs('getSelected');
                var url = $(currTab.panel('options').content).attr('src');
                self.parent.$('#tabs').tabs('update', {
                    tab: currTab,
                    options: {
                        //content: createFrame(url)
                        // href: url
                        content: indexForm.events.createFrame(url)
                    }
                });
            })
            //关闭当前
            $('#mm-tabclose').click(function () {
                var currtab_title = $('#mm').data("currtab");
                $('#tabs').tabs('close', currtab_title);
            })
            //全部关闭
            $('#mm-tabcloseall').click(function () {
                $('.tabs-inner span').each(function (i, n) {
                    var t = $(n).text();
                    if (t != "我的工作台")
                        $('#tabs').tabs('close', t);
                });
            });
            //关闭除当前之外的TAB
            $('#mm-tabcloseother').click(function () {
                $('#mm-tabcloseright').click();
                $('#mm-tabcloseleft').click();
            });
            //关闭当前右侧的TAB
            $('#mm-tabcloseright').click(function () {
                var nextall = $('.tabs-selected').nextAll();
                if (nextall.length == 0) {
                    //msgShow('系统提示','后边没有啦~~','error');
                    return false;
                }
                nextall.each(function (i, n) {
                    var t = $('a:eq(0) span', $(n)).text();
                    if (t != "我的工作台")
                        $('#tabs').tabs('close', t);
                });
                return false;
            });
            //关闭当前左侧的TAB
            $('#mm-tabcloseleft').click(function () {
                var prevall = $('.tabs-selected').prevAll();
                if (prevall.length == 0) {

                    return false;
                }
                prevall.each(function (i, n) {
                    var t = $('a:eq(0) span', $(n)).text();
                    if (t != "我的工作台")
                        $('#tabs').tabs('close', t);
                });
                return false;
            });

            //退出
            $("#mm-exit").click(function () {
                $('#mm').menu('hide');
            })
        },
        reloadTabGrid: function (title, flag) {
            if ($("#tabs").tabs('exists', title)) {
                $('#tabs').tabs('select', title);
                if (flag == 1)
                    window.top.reload_Abnormal_Monitor1.call();
                else if (flag == 2)
                    window.top.reload_Abnormal_Monitor2.call();
                else if (flag == 3)
                    window.top.reload_Abnormal_Monitor3.call();
            }
        },
        addTab: function (subtitle, url, icon) {
            if (icon == undefined || icon == null || icon == '') {
                icon = 'table';
            }
            if (!$('#tabs').tabs('exists', subtitle)) {
                $('#tabs').tabs('add', {
                    title: subtitle,
                    content: indexForm.events.createFrame(url),
                    closable: true,
                    icon: icon
                });
            } else {
                // setTimeout(function () {
                $('#tabs').tabs('select', subtitle);
                var currTab = $('#tabs').tabs('getSelected');
                $('#tabs').tabs('update', {
                    tab: currTab,
                    options: {
                        content: indexForm.events.createFrame(url)
                    }
                })
                $('#mm-tabupdate').click();
                //}, 0)//优化选项卡重复打开时会闪退到第一个选项卡问题
            }
            indexForm.events.tabClose();
        },
        tabClose: function () {
            /*双击关闭TAB选项卡*/
            $(".tabs-inner").dblclick(function () {
                var subtitle = $(this).children(".tabs-closable").text();
                $('#tabs').tabs('close', subtitle);
            })
            /*为选项卡绑定右键*/
            $(".tabs-inner").bind('contextmenu', function (e) {
                $('#mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
                var subtitle = $(this).children(".tabs-closable").text();
                $('#mm').data("currtab", subtitle);
                $('#tabs').tabs('select', subtitle);
                return false;
            });
        },
        updatetTab: function (subtitle) {
            if ($('#tabs').tabs('exists', subtitle)) {
                $('#tabs').tabs('select', subtitle);
                var currTab = $('#tabs').tabs('getSelected');
                var url = $(currTab.panel('options').content).attr('src');
                $('#tabs').tabs('update', {
                    tab: currTab,
                    options: {
                        content: createFrame(url)
                    }
                });
            }
        },
        closeTab: function (subtitle) {
            $('#tabs').tabs('close', subtitle);
        },
        createFrame: function (url) {//scrolling="no"
            var s = '<iframe scrolling="auto" frameborder="0" src="' + url + '" style="width:100%;height:99.7%;"></iframe>';
            return s;
        },
        openFavoriteSetting: function () {
            indexForm.controls.favorite_window.window('open');
        },
        closeFavoriteSetting: function () {
            indexForm.controls.favorite_window.window('close');
        },
        closeprivilegeSetting: function () {
            indexForm.controls.privilege_window.window('close');
        },
        saveFavoriteSetting: function () {
            //保存桌面快捷
            var selRows = indexForm.controls.dgprivilege.datagrid('getChecked');
            if (!selRows.length) {
                showError('请选择菜单。');
                return;
            }
            var privilegeids = [];
            $.each(selRows, function (index, item) {
                privilegeids.push(item.PrivilegeID);
            });
            $.messager.confirm('系统提示', '您确定要添加至桌面快捷方式吗?', function (flag) {
                if (flag) {
                    $.ajax({
                        url: '/ashx/privilegehandler.ashx?Method=SaveFavoritePrivilege',
                        data: { PrivilegeIDs: privilegeids.join(',') },
                        success: function (returnData) {
                            if (returnData) {
                                if (returnData.isOk == 0) {
                                    showError(returnData.message);
                                }
                                else {
                                    indexForm.controls.dgfavorite.datagrid('reload');
                                    indexForm.controls.privilege_window.window('close');
                                    indexForm.events.initShortLink();
                                }
                            }
                        }
                    });
                }
            });
        },
        loadFavoriteGrid: function () {
            indexForm.controls.dgfavorite.datagrid({
                sortName: 'PrivilegeID',
                idField: 'PrivilegeID',
                url: '/ashx/privilegehandler.ashx?Method=SearchFavoritePrivilege&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 20,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: true,
                columns: [[
                { field: 'CategoryName', title: '菜单组', width: 120, align: 'center' },
                { field: 'PrivilegeName', title: '菜单名称', width: 85, sortable: false, halign: 'center', align: 'center' },
                { field: 'FavoriteCategory', title: '快捷分组', width: 85, sortable: false, halign: 'center', align: 'center' },
                {
                    field: 'op', title: '移除', width: 80, sortable: false, halign: 'center', align: 'center', formatter: function (value, row, index) {
                        return '<a href="#" onclick="RemoveRow(\'' + row.PrivilegeID + '\')"><span class="icon delete">&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;删除</a>';
                    }
                }
                ]],
                toolbar: [
                      { text: '添加菜单', iconCls: 'report_add', handler: indexForm.events.appendPrivilege },
                ],
            });
        },
        loadPrivilegeGrid: function () {
            indexForm.controls.dgprivilege.datagrid({
                sortName: 'PrivilegeID',
                idField: 'PrivilegeID',
                url: '/ashx/privilegehandler.ashx?Method=SearchPrivilegeByCurrentUser&' + jsNC(),
                collapsible: false,
                fitColumns: true,
                pagination: true,
                striped: false,   //设置为true将交替显示行背景。
                pageSize: 50,
                loadMsg: '正在加载数据，请稍候....',
                singleSelect: false,
                columns: [[
                { field: 'cp', checkbox: true },
                { field: 'CategoryName', title: '菜单组', width: 120, align: 'center' },
                { field: 'PrivilegeName', title: '菜单名称', width: 85, sortable: false, halign: 'center', align: 'center' },
                { field: 'FavoriteCategory', title: '快捷分组', width: 85, sortable: false, halign: 'center', align: 'center' },
                ]]
            });
        },
        appendPrivilege: function () {
            indexForm.events.loadPrivilegeGrid();
            indexForm.controls.privilege_window.window('open');
        },
        closePrivilege: function () {
            indexForm.controls.privilege_window.window('close');
        },
        getTitleThumbnail: function (title) {
            switch (title) {
                case '订单管理':
                    return '/Content/images/desktop/lists_e.png';
                case '生产管理':
                    return '/Content/images/desktop/orders_e.png';
                case '报表管理':
                    return '/Content/images/desktop/report_e.png';
                case '系统管理':
                    return '/Content/images/desktop/syssetting_e.png';
                case '仓储管理':
                    return '/Content/images/desktop/stocks_e.png';
                case 'CRM管理':
                    return '/Content/images/desktop/schedule_e.png';
                default:
                    return '/Content/images/desktop/lists_e.png';
            }
        },
        initShortLink: function () {
            $.ajax({
                url: "/ashx/indexhandler.ashx?Method=InitShortLink",
                dataType: 'text',
                success: function (returnData) {
                    var shortlinks = eval('(' + returnData + ')');
                    if (shortlinks.isOk == 0) {
                        indexForm.msgShow("系统提示", shortlinks.message, 'error');
                        return;
                    }
                    //console.log(JSON.stringify(returnData));
                    var menulist = "";
                    $.each(shortlinks.menus, function (i, n) {
                        menulist += '<li class="item"><div class="item_body"><div class="item_title">'
                                + '<img src="' + indexForm.events.getTitleThumbnail(n.menuname) + '" />'
                                + '<div style="line-height: 72px; padding-top: 10px;"><span style="font-size: 20px; padding-left: 20px;">' + n.menuname + '</span></div></div>'
                                + '<div style="clear: both; height: 2px; border-bottom: 2px solid #eee;"></div><div class="desknav"><ul style="padding-left:0px;">';
                        $.each(n.menus, function (j, o) {
                            var url = o.url;
                            if (url == '')
                                url = '#'
                            else if (url.indexOf('?') > 0)
                                url += '&' + jsNC();
                            else
                                url += '?' + jsNC();
                            menulist += '<li style="line-height: 25px;"><a ref="' + o.menuid + '" href="#" rel="' + url + '"><span class="icon ' + o.icon + '">&nbsp;</span><span class="nav">' + o.menuname + '</span></a></li>';
                        })
                        menulist += '</ul></div></div></li>';
                        //console.log(menulist);
                    });
                    //console.log("menulist=" + menulist);

                    if (menulist == "") {
                        $(".huanyin").show();
                    }
                    else {
                        $(".huanyin").hide();
                    }
                    $('.deskmenu').empty().append(menulist);
                }
            });
            $('.deskmenu').delegate(".desknav li a", 'click', function () {
                var tabTitle = $(this).children('.nav').text();
                var url = $(this).attr("rel");
                if (url == '') {
                    url = '#';
                }
                var menuid = $(this).attr("ref");
                var icon = $(this)[0].firstChild.className;
                var tabs = $('#tabs').tabs().tabs('tabs');
                if (url.indexOf('?') > 0) {
                    url = url + '&pid=' + menuid;
                }
                else {
                    url = url + '?pid=' + menuid;
                }
                if (tabs.length < parseInt($('#tabmax').val())) {
                    indexForm.events.addTab(tabTitle, url, icon);
                }
                else {
                    showInfo("选项卡打开过多,请关闭部门窗口再操作！");
                }
                $('.easyui-accordion li div').removeClass("selected");
                $(this).parent().addClass("selected");
            }).hover(function () {
                $(this).parent().addClass("hover");
            }, function () {
                $(this).parent().removeClass("hover");
            });
        },
        SetUserInfo: function () {
            $.ajax({
                url: '/ashx/IndexHandler.ashx?Method=UserInfo',
                success: function (returnData) {
                    console.log(JSON.stringify(returnData));
                    $("#userinfo").text("欢迎【" + returnData.UserCode + "." + returnData.UserName + "】");
                }
            });
        }
    },
    msgShow: function (title, msgString, msgType) {
        $.messager.alert(title, msgString, msgType);
    },

}

$(function () {
    indexForm.init();
});

function RemoveRow(pID) {
    if (pID == '' || pID == undefined) return;
    //$.messager.confirm('系统提示', '您确定要移除此快捷方式吗?', function (flag) {
    //    if (flag) {
    $.ajax({
        url: '/ashx/privilegehandler.ashx?Method=DeleteFavoritePrivile',
        data: { PrivilegeID: pID },
        success: function (returnData) {
            if (returnData) {
                if (returnData.isOk == 0) {
                    showError(returnData.message);
                }
                else {
                    indexForm.controls.dgfavorite.datagrid('reload');
                    indexForm.events.initShortLink();
                }
            }
        }
    });
    //    }
    //});
}

function closeTab() {
    indexForm.events.closeTab(arguments[0]);
}

function addTab(subtitle, url, icon) {
    indexForm.events.addTab(subtitle, url, icon);
}

function RefreshTab(title, GridID) {
    if (GridID != null || GridID != undefined) {
        if ($('#tabs').tabs('exists', title)) {
            window.top[GridID].call();
        }
    }
}

//刷新父标检
function refreshTabs(partnertitle) {
    if ($('#tabs').tabs('exists', partnertitle)) {
        $('#tabs').tabs('select', partnertitle);
        var currTab = $('#tabs').tabs('getSelected');
        var url = $(currTab.panel('options').content).attr('src');
        self.parent.$('#tabs').tabs('update', {
            tab: currTab,
            options: {
                content: indexForm.events.createFrame(url)
            }
        });
    }
};

//关闭当前标签
function closeTabs() {
    var currTab = top.$(".tabs").find(".tabs-selected").text();
    top.closeTab(currTab);
};