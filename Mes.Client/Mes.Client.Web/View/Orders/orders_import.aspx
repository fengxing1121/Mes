<%@ Page Title="导入订单" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders_import.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orders_import" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Script/stream-v1/stream-v1.css" rel="stylesheet" />
    <script src="/Script/forms/orders/jquery.forms.orders_import.js?ver=1.61"></script> 
    <script src="../../Script/stream-v1/stream-v1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;" title="订单文件">
                        <div class="item">
                            	<div id="i_select_files"></div>
	                            <div id="i_stream_files_queue"></div>
	                            <div id="i_stream_message_container" class="stream-main-upload-box" style="overflow: auto;height:200px;display:none;"></div>
                        </div>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;display:none;">
                        <a id="btn_order_save" icon="icon-save" style="width:100px;height:30px; " class="easyui-linkbutton" href="javascript:void(0)">保存</a>   
                        <a id="btn_cancelorder" icon="icon-clear" style="width:100px;height:30px;"   class="easyui-linkbutton" href="javascript:window.location.reload();">取消</a>                   
                    </div>
                </div>
        </div>
    </div>
      <div id="Loding_window" class="easyui-window" closed="true" title="系统提示" data-options="iconCls:'cog'"
        style="width: 400px; height: 300px; background: #fff;display:none;" minimizable="false" maximizable="false" closable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td style="width: 33px;">
                            <img src="/Content/images/ui-loading-pink-32x32.gif" />
                        </td>
                        <td style="width: 100%;">
                            <span>正在导入数据，请稍候...</span>
                            <p>
                                <span class="runtime">已经运行：00:00:00</span>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script  type="text/javascript">
        var config = {
            browseFileId: "i_select_files", /** 选择文件的ID, 默认: i_select_files */
            browseFileBtn: "<div>请选择文件</div>", /** 显示选择文件的样式, 默认: `<div>请选择文件</div>` */
            dragAndDropArea: "i_select_files", /** 拖拽上传区域，Id（字符类型"i_select_files"）或者DOM对象, 默认: `i_select_files` */
            dragAndDropTips: "<span>把文件拖拽(点击)到这里</span>", /** 拖拽提示, 默认: `<span>把文件(文件夹)拖拽到这里</span>` */
            filesQueueId: "i_stream_files_queue", /** 文件上传容器的ID, 默认: i_stream_files_queue */
            filesQueueHeight: 200, /** 文件上传容器的高度（px）, 默认: 450 */
            messagerId: "i_stream_message_container", /** 消息显示容器的ID, 默认: i_stream_message_container */
            multipleFiles: true, /** 多个文件一起上传, 默认: false */
            autoUploading: true, /** 选择文件后是否自动上传, 默认: true */
            autoRemoveCompleted: false, /** 是否自动删除容器中已上传完毕的文件, 默认: false */
            maxSize: 104857600,//, /** 单个文件的最大大小，默认:2G */
            //		retryCount : 5, /** HTML5上传失败的重试次数 */
            //		postVarsPerFile : { /** 上传文件时传入的参数，默认: {} */
            //			param1: "val1",
            //			param2: "val2"
            //		},
            //swfURL : "swf/FlashUploader.swf", /** SWF文件的位置 */
            tokenURL: "/ashx/StreamUploadHandler.ashx?Method=tk", /** 根据文件名、大小等信息获取Token的URI（用于生成断点续传、跨域的令牌） */
            //frmUploadURL: "FileUpload.ashx?Method=fd;", /** Flash上传的URI */
            uploadURL: "/ashx/StreamUploadHandler.ashx?Method=upload", /** HTML5上传的URI */
            simLimit: 20, /** 单次最大上传文件个数 */
            //extFilters: [".zip", ".rar"], /** 允许的文件扩展名, 默认: [] */
            onSelect: function (list) {
                //console.log(JSON.stringify(list));
            }, /** 选择文件后的响应事件 */
            onMaxSizeExceed: function (size, limited, name) { showError('文件大小超出限制！'); }, /** 文件大小超出的响应事件 */
            onFileCountExceed: function (selected, limit) { showError('文件数量超出(' + limit + '个)限制！'); }, /** 文件数量超出的响应事件 */
            //onExtNameMismatch: function (name, filters) {alert(name + filters);}, /** 文件的扩展名不匹配的响应事件 */
            // onCancel: function (file) {alert('Canceled:  ' + file.name)}, /** 取消上传文件的响应事件 */
            onComplete: function (file) {
                //console.log(JSON.stringify(file));
                var obj = JSON.parse(file.msg);
                if (obj.success) {
                    console.log(decodeURIComponent(obj.filePath));
                    var model = {
                        id: file.id,
                        filePath: obj.filePath,
                    }
                    ArrayPath.push(model);
                }

            }, /** 单个文件上传完毕的响应事件 */
            onQueueComplete: function () {
                //console.log("ArrayPath=" + JSON.stringify(ArrayPath));
                //OrderImportForm.events.SaveOrder();
            }, /** 所以文件上传完毕的响应事件 */
            onUploadError: function (status, msg) {
                alert('onUploadError' + status + ":" + msg);
            } /** 文件上传出错的响应事件 */
        };
        var _t = new Stream(config);
    </script>
</asp:Content>
