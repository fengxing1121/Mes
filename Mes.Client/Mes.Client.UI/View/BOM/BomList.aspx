<%@ Page Title="BOM列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BomList.aspx.cs" Inherits="Mes.Client.UI.View.BOM.BomList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="/Script/stream-v1/stream-v1.css" rel="stylesheet" />
    <script src="/Script/stream-v1/stream-v1.js?ver=1.2"></script>
    <script src="/Script/forms/BOM/bomlist.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="BOM查询" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">BOM:</td>
                                <td>
                                    <input type="text" style="width: 120px" id="BOMID" name="BOMID" />
                                </td>
                                <td class="lbl-caption">产品编码:
                                </td>
                                <td>
                                    <input style="width: 120px; height: 22px;" id="ProductCode" name="ProductCode" type="text" />
                                </td>
                                <td class="lbl-caption">产品名称:
                                </td>
                                <td>
                                    <input style="width: 120px; height: 22px;" id="ProductName" name="ProductName" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">创建日期:</td>
                                <td>
                                    <input type="text" id="CreatedFrom" name="CreatedFrom" class="easyui-datebox" style="width: 125px; height: 25px;" /></td>
                                <td class="lbl-caption">至:</td>
                                <td>
                                    <input type="text" id="CreatedTo" name="CreatedTo" class="easyui-datebox" style="width: 125px; height: 25px;" /></td>
                                <td class="lbl-caption"></td>
                                <td colspan="2" style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <div id="Upload_window" class="easyui-window" closed="true" title="BOM文件导入(.xls, .xlsx)" data-options="iconCls:'icon-save'"
        style="width: 650px; height: 500px; background: #fff; display: none;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false">
                        <div class="item">
                            <div id="i_select_files"></div>
                            <div id="i_stream_files_queue"></div>
                            <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px; margin-top: 40px;">
                                <input type="hidden" id="hdnBOMID" />
                                <input type="hidden" id="hdnProductCode" />
                                <input type="hidden" id="hdnAttachmentFile" />
                                <a id="btn_save" icon="icon-ok" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                                <a id="btn_cancel" icon="icon-reload" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                            </div>
                            <div id="i_stream_message_container" class="stream-main-upload-box" style="overflow: auto; height: 200px; display: none;"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>