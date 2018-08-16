<%@ Page Title="新增销售订单" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addorder.aspx.cs" Inherits="Mes.Client.UI.View.PartnerOrder.addorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="/Script/stream-v1/stream-v1.css" rel="stylesheet" />
    <script src="/Script/stream-v1/stream-v1.js?ver=1.2"></script>
    <script src="/Script/forms/PartnerOrder/jquery.forms.addorder.js?ver=1.31"></script>
    <style type="text/css">
        .stream-cell-file .stream-cancel {
           display:none;
        }
        .datagrid-body .datagrid-editable {
            margin: 0 0px; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false" title="订单信息">
            <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="north" border="false">
                        <div>
                            <input type="hidden" id="OrderID" name="OrderID" />
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                            <input type="hidden" id="H_CustomerID" name="CustomerName" />
                            <input type="hidden" id="Cabinets" name="Cabinets" />
                        </div>
                        <table style="width: 100%; height: auto; padding: 5px;"  title="添加订单产品（单击行编辑）">
                            <tr>
                                <td class="lbl-caption" style="width: 120px;">订单编号:
                                </td>
                                <td>
                                    <input type="text" id="OrderNo" name="OrderNo" style="width: 300px;" placeholder="自动生成" readonly="true" />
                                </td>
                                <td class="lbl-caption" style="width: 120px;display:none;">来源单号:
                                </td>
                                <td style="display:none;">
                                    <input type="text" id="OutOrderNo" name="OutOrderNo" class="easyui-validatebox" style="width: 300px;" placeholder="非必填，没有可不填写"/>
                                </td>
                               <td class="lbl-caption"></td>
                                <td></td>                              
                            </tr>
                            <tr>
                                <td class="lbl-caption">订单类型:
                                </td>
                                <td>
                                    <select id="OrderType" name="OrderType" style="width: 306px;height:28px;" class="easyui-combobox"></select>
                                </td>    
                                <td class="lbl-caption">订货日期:
                                </td>
                                <td>
                                    <input type="text" id="BookingDate" name="BookingDate" class="easyui-datebox" style="width:306px;height:28px;" required="true"  />
                                </td>
                                 <td class="lbl-caption">交货日期:
                                </td>
                                <td>
                                    <input type="text" id="ShipDate" name="ShipDate" style="width: 306px;height:28px;" class="easyui-datebox" required="true" />
                                </td>
                            </tr>
                            <tr>
                               <td class="lbl-caption">客户名称:
                                </td>
                                <td >
                                    <input type="text" style="width: 306px;height:28px;" id="CustomerID" name="CustomerID" class="easyui-combogrid" editable="false" required="true" />
                                </td>
                                <td class="lbl-caption">客户地址:
                                </td>
                                <td >
                                    <input type="text"  id="Address" name="Address" style="width: 300px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td >
                                    <input type="text" id="Mobile" name="Mobile" style="width: 300px;" readonly="true" />
                                </td>
                            </tr>  
                            <tr>
                                <td class="lbl-caption">门店名称:
                                </td>
                                <td>
                                    <input type="text" id="PartnerName" name="PartnerName" style="width: 300px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">业务人员:
                                </td>
                                <td>
                                    <input type="text" id="SalesMan" name="SalesMan" style="width: 300px;" readonly="true" />
                                </td>
                                 <td class="lbl-caption">订单附件
                                </td>
                                <td>
                                    <input type="text" id="AttachmentFile" name="AttachmentFile" style="width:235px;" readonly="true" />
                                    <input type="button"  value="选择文件" onclick="$('#Upload_window').window('open')" />
                                </td>
                            </tr>                           
                            <tr>
                                <td class="lbl-caption">订单备注:
                                </td>
                                <td colspan="5">
                                    <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;">
                        <table id="dgCabinet" title="产品信息（单击行编辑）"></table>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                        <a id="btn_edit_save" icon="icon-ok"   class="easyui-linkbutton" href="javascript:void(0)">保存订单</a>
                        <a id="btn_edit_cancel" icon="icon-reload" class="easyui-linkbutton" href="javascript:void(0)">清空所有</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div id="tb" style="padding: 5px; height: auto">
        <form id="search_form_customer">
            <table>
                <tr>                    
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" id="CustomerNames" name="CustomerName" /></td>
                    <td class="lbl-caption">移动电话: </td>
                    <td style="text-align: left">
                        <input type="text" id="Mobile" name="Mobile" /></td>
                </tr>
                <tr>
                    <td class="lbl-caption">联系地址: </td>
                    <td style="text-align: left">
                        <input type="text" id="Address" name="Address" /></td>
                   <td class="lbl-caption"></td>
                    <td><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_customer">搜索</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>
    <div id="Upload_window" class="easyui-window" closed="true"  title="附件导入(.zip/.rar)" data-options="iconCls:'icon-save'"
        style="width: 650px; height: 600px; background: #fff;display:none;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;" title="附件导入(.zip/.rar)">
                        <div class="item">
                            	<div id="i_select_files"></div>
	                            <div id="i_stream_files_queue"></div>
	                            <div id="i_stream_message_container" class="stream-main-upload-box" style="overflow: auto;height:200px;display:none;"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script  type="text/javascript">

        var config = {
            browseFileId: "i_select_files", 
            browseFileBtn: "<div>请选择文件</div>",
            dragAndDropArea: "i_select_files",
            dragAndDropTips: "<span>把文件拖拽(点击)到这里</span>", 
            filesQueueId: "i_stream_files_queue",
            filesQueueHeight: 200,
            messagerId: "i_stream_message_container",
            multipleFiles: false, /** 多个文件一起上传, 默认: false */
            autoUploading: true, /** 选择文件后是否自动上传, 默认: true */
            autoRemoveCompleted: true, /** 是否自动删除容器中已上传完毕的文件, 默认: false */
            maxSize: 104857600,//, /** 单个文件的最大大小，默认:2G */
            tokenURL: "/ashx/StreamUploadHandler.ashx?Method=tk",
            uploadURL: "/ashx/StreamUploadHandler.ashx?Method=upload", 
            simLimit: 50, /** 单次最大上传文件个数 */
            extFilters: [".zip", ".rar"],
            onSelect: function (list) {
                //console.log(JSON.stringify(list));
            },
            onMaxSizeExceed: function (size, limited, name) { showError('文件大小超出限制！'); },
            onFileCountExceed: function (selected, limit) { showError('文件数量超出(' + limit + '个)限制！'); },
            onComplete: function (file) {
                //console.log(JSON.stringify(file));
                var obj = JSON.parse(file.msg);
                if (obj.success) {
                    $("#AttachmentFile").val(obj.filePath);
                    $('#Upload_window').window('close');
                }

            },
            onQueueComplete: function () {
                //单个文件上传完毕的响应事件
            }, 
            onUploadError: function (status, msg) {
                alert('onUploadError' + status + ":" + msg);
            }
        };

        var _t = new Stream(config);
    </script>
</asp:Content>

