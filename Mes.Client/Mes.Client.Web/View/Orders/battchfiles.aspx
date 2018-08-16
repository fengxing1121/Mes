<%@ Page Title="批次开料文件管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="battchfiles.aspx.cs" Inherits="Mes.Client.Web.View.Orders.battchfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.battchfiles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
            <table id="dgdetail">
            </table>
        </div>
        <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
            <div class="datagrid-toolbar" style="height: auto;">
                <form id="search_form" method="post">                    
                    <table>
                        <tr>
                            <td style="width: 100px;">批次号:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="BattchNum" name="BattchNum" type="text" />
                            </td>
                            <td class="lbl-caption">所属设备:
                            </td>
                            <td>
                                <input style="width: 200px; height: 26px;" id="WorkCenterID" name="WorkCenterID" type="text" class="easyui-combobox" />
                            </td>
                            <td style="width:100px">
                                <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
        </div>
    </div>
    <div id="upload_window" class="easyui-window" closed="true" title="上传开料优化文件" data-options="iconCls:'page_white_get'"
        style="width: 640px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="upload_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                    <table>
                        <tr>
                            <td class="lbl-caption">批次号：
                            </td>
                            <td>
                                <input type="text" id="BattchNum" name="BattchNum" required="true" class="easyui-validatebox" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">所属生产线:
                            </td>
                            <td>
                                <input style="width: 200px; height: 26px;" id="WorkingLineID" name="WorkingLineID" type="text" class="easyui-combobox" required="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">CUT文件：
                            </td>
                            <td>
                                <input id="cutfile" name="cutfile" type="text" style="width: 98%;" class="easyui-filebox" data-options="multiple:false,buttonText:'选择文件',accept:'.cut'" required="true" />
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                <a id="btn_fileupload" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)">确认上传</a>
                <a id="btn_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>
    <div id="submit_window" class="easyui-window" closed="true" title="系统提示" data-options="iconCls:'cog'"
        style="width: 400px; height: 300px; background: #fff;" minimizable="false" maximizable="false" closable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td style="width: 33px;">
                            <img src="/Content/images/ui-loading-pink-32x32.gif" />
                        </td>
                        <td style="width: 100%;">
                            <span>正在提交数据，请稍候...</span>
                            <p>
                                <span class="runtime">已经运行：</span>
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
</asp:Content>
