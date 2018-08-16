(function ($) {
    document.msCapsLockWarningOff = true;
    var PartnerUserTransDetail = {
        init: function () {
            PartnerUserTransDetail.initControls();        
            PartnerUserTransDetail.events.loadData();
            PartnerUserTransDetail.controls.btn_search_transdetail.on('click',PartnerUserTransDetail.events.search_transdetail);
            PartnerUserTransDetail.controls.btn_save.on('click', PartnerUserTransDetail.events.saveTransDetail);
            PartnerUserTransDetail.controls.btn_cancel.on('click', PartnerUserTransDetail.events.closewindow);
        },
        initControls: function () {
            PartnerUserTransDetail.controls = {
                pid: getUrlParam('pid'),
                btn_search_transdetail: $('#btn_search_transdetail'),
                search_form: $('#search_form'),
                save_form: $('#save_form'),
                save_window: $('#save_window'),
                btn_save: $('#btn_save'),
                btn_cancel: $('#btn_cancel'),
                dgdetail: $('#dgdetail')
            }
            $('#btn_search_ok').linkbutton();
        },
        events: {
            loadData: function () {
                PartnerUserTransDetail.controls.dgdetail.datagrid({
                    //idField: 'CustomerID',
                    url: '/ashx/PartnerUserTransDetailHandler.ashx?Method=SearchCustomerTransDetail&' + jsNC(),
                    collapsible: false,
                    fitColumns: true,
                    pagination: true,
                    striped: false,   //设置为true将交替显示行背景。
                    pageSize: 20,
                    columns: [[
                         {
                             field: 'action', title: '操作', width: 120, align: 'center', formatter: function (value, row, index) {
                                 var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="查看详细" onclick="openwindow(\'' + [row.QuoteID, row.CustomerID, row.CustomerName, row.TotalAmount, row.DiscountAmount, row.DiscountPercent,row.DebitAmount] + '\');"><span style="color:#0094ff;">' + "收款" + '</span></a>';
                                 return strReturn;
                             }
                         },
                        { field: 'QuoteID', hidden: true, width: 50, align: 'center' },
                        { field: 'CustomerID', hidden: true, width: 50, align: 'center' },
                        { field: 'CustomerName', title: '客户名称', width: 150, align: 'center' },
                        { field: 'LinkMan', title: '联系人', width: 150, align: 'center' },
                        { field: 'Mobile', title: '联系电话', width: 150, align: 'center' },
                        { field: 'QuoteNo', title: '报价单号', width: 170, align: 'center' },
                        { field: 'SolutionCode', title: '方案编号', width: 170, align: 'center' },
                        { field: 'SolutionName', title: '方案名称', width: 150, align: 'center' },                       
                        { field: 'TotalAmount', title: '总金额(元)', width: 120, align: 'center' },
                        {
                            field: 'DiscountPercent', title: '折扣率(%)', width: 150, align: 'center',
                            formatter: function (value,row,index) {                            
                                return (value*100);
                            }
                        },
                        { field: 'DiscountAmount', title: '折扣金额(元)', width: 150, align: 'center' },
                        { field: 'DebitAmount', title: '已收金额(元)', width: 150, align: 'center' },
                        { field: 'Created', title: '创建时间', width: 200, align: 'center' },
                        {
                            field: 'detail', title: '收款详情', width: 50, align: 'center',
                            formatter: function (value, row, index) {
                                var strReturn = '<a href="javascript:void(0)" class="l-btn-text" title="收款详情" onclick="detailwindow(\'' + row.QuoteID+ '\',\''+row.CustomerID +'\');"><span style="color:#0094ff;">' + "详情" + '</span></a>';
                                  return strReturn;
                            }
                        }
                    ]],
                    onBeforeLoad: function (param) {
                        PartnerUserTransDetail.controls.search_form.find('input').each(function (index) {
                            if (this.name != "")
                                param[this.name] = $(this).val();
                                param["Status"] = "I";
                        });
                    },
                    onSelect: function (rowIndex, rowData) {
                        
                    }
                });
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

            saveTransDetail:function(){                 
                if (PartnerUserTransDetail.controls.save_form.form('validate')) {
                    var NoPay = parseFloat($('#NoPay').val()).toFixed(2);//欠收
                    var Amount = parseFloat($('#Amount').val()).toFixed(2);//现收
                    if (NoPay ==="0.00") {
                        showError("款已收齐.");
                        $("#Amount").numberbox('setValue', '');
                        $('#VoucherNo').val('');
                        $('#TransDate').datebox('setValue','');
                        $('#Payee').val('');
                        return;
                    }
                    if (Amount === "0.00") {
                        showError("收款不能为零");
                        $("#Amount").numberbox('setValue', '');
                        $('#VoucherNo').val('');
                        $('#TransDate').datebox('setValue', '');
                        $('#Payee').val('');
                        return;
                    }
                    var a=Number(Amount);
                    var b = Number(NoPay);
                    var amount = parseFloat(a.toFixed(2));
                    var noPay = parseFloat(b.toFixed(2));

                    if (amount > noPay) {
                        showError("现收款数不能大于欠收款数.");
                        //$("#Amount").numberbox('setValue', '');
                        return;
                    }                   
                    $.ajax({
                        url: '/ashx/PartnerUserTransDetailHandler.ashx?Method=SaveCustomerTransDetail&' + jsNC(),
                        data: PartnerUserTransDetail.controls.save_form.serialize(),
                        success: function (data) {
                            if (data.isOk == 1) {
                                showInfo(data.message);
                                PartnerUserTransDetail.controls.save_form.form('clear');
                                $('#save_window').window('close');
                                PartnerUserTransDetail.controls.dgdetail.datagrid('reload');
                            } else {
                                showError(data.message);
                            }
                        }
                    });
                }
            },

            search_quotemain: function () {
                $('#QuoteMain').combogrid("grid").datagrid("reload");
            },

            search_transdetail: function () {
                $('#dgdetail').datagrid("reload");
            },

            closewindow:function(){
                PartnerUserTransDetail.controls.save_form.form('clear');
                PartnerUserTransDetail.controls.save_window.window('close');
            },
        },
        //用于判断是否有编辑权限
        options: {
            isModify: false
        }
    };

    $(function () {
        PartnerUserTransDetail.init();
    });

})(jQuery);

//获取权限
function verifyright() {
    $.ajax({
        url: '/ashx/verifyright.ashx?Method=GetRight&pid=' + getUrlParam('pid'),
        success: function (data) {
            if (data) {
                rightType($('#btn_save'), data);
            }
        }
    });
}

function rightType(eleAdd, data) {
    $(eleAdd).hide();
    $(data).each(function (i, obj) {
        switch (obj.PrivilegeItemCode) {
            case 'Add':
                $(eleAdd).show();
                break;
            default: break;
        }
    });
}

function openwindow(row) {
    verifyright();
    //[row.QuoteID, row.CustomerID, row.CustomerName, row.TotalAmount, row.DiscountAmount, row.DiscountPercent, row.DebitAmount]
    var arr = row.split(',');
    $('#QuoteID').val(arr[0]);
    $('#CustomerID').val(arr[1]);
    $('#CustomerName').val(arr[2]);
    $('#TotalAmount').val(parseFloat(arr[3]).toFixed(2));
    $('#DiscountAmount').val(parseFloat(arr[4]).toFixed(2));

    var TotalAmount = parseFloat(arr[3]).toFixed(2);
    var DiscountAmount = parseFloat(arr[4]).toFixed(2);
    var PayAmount = parseFloat(arr[6]).toFixed(2);

    $('#DiscountPercent').val((arr[5]*100));
    $('#PayAmount').val(parseFloat(arr[6]).toFixed(2)); 
    $('#totalAmount').val(parseFloat(TotalAmount - DiscountAmount).toFixed(2));
    var a = parseFloat(TotalAmount - DiscountAmount).toFixed(2);
    var b = parseFloat(a - PayAmount).toFixed(2);
    var NoPay = parseFloat(a - PayAmount).toFixed(2);
    if (NoPay === '0.00' || NoPay===0) {
        $('#NoPay').val("0.00"); //欠收款
    }else{
        $('#NoPay').val(NoPay); //欠收款
    }

    $('#save_window').window('open');
}

function detailwindow(qid, cid) {
    $('#detail').datagrid({
        //idField: 'CustomerID',
        url: '/ashx/PartnerUserTransDetailHandler.ashx?Method=SearchTransDetail&' + jsNC(),
        collapsible: false,
        queryParams:{QuoteID:qid,CustomerID:cid},
        fitColumns: true,
        pagination: true,
        striped: false,   //设置为true将交替显示行背景。
        pageSize: 20,
        columns: [[
            { field: 'QuoteID', hidden: true, width: 50, align: 'center' },
            { field: 'CustomerID', hidden: true, width: 50, align: 'center' },
            { field: 'Amount', title: '收款(元)', width: 150, align: 'center' },        
            { field: 'Payee', title: '收款人', width: 150, align: 'center' },
            { field: 'VoucherNo', title: '凭证号', width: 200, align: 'center' },
            { field: 'TransDate', title: '日期', width: 200, align: 'center' }
        ]]
    });
    $('#detail_window').window('open');
}
