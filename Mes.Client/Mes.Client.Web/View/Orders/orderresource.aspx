<%@ Page Title="拆单上传" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orderresource.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orderresource" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <style type="text/css">
        .easyui-readonly
        {
            background: #efefef;
        }

        #unloadMask
        {
            background: #808080;
            opacity: 0.3;
        }
    </style>
    <script src="/Script/forms/orders/jquery.forms.ordersresource.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
            <table id="dgdetail">
            </table>
        </div>
        <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
            <div style="height: auto 50px;" class="datagrid-toolbar">
                <form id="search_form" method="post">
                    <div>
                        <input type="hidden" id="Status" name="Status" value="U" />
                    </div>
                    <table>
                        <tr>
                            <td class="lbl-caption">订单编号:</td>
                            <td style="width: 120px;">
                                <input type="text" style="width: 120px" id="Text1" name="OrderNo" />
                            </td>
                            <td class="lbl-caption">采购单号:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="PurchaseNo" name="PurchaseNo" type="text" />
                            </td>

                            <td class="lbl-caption">产品类型:
                            </td>
                            <td>
                                <select style="width: 120px" id="Select2" name="CabinetType" class="easyui-combobox" required="true">
                                   <option value="请选择">请选择</option>
                                </select>
                            </td>
                            <td class="lbl-caption">订单类型:
                            </td>
                            <td style="width: 120px;">
                                <select id="Select3" name="OrderType" style="width: 100%;" class="easyui-combobox" required="true">
                                    <option value="">全部</option>
                                    <option value="正常">正常</option>
                                    <option value="加急">加急</option>
                                    <option value="补货">补货</option>
                                    <option value="工程">工程</option>
                                    <option value="展会">展会</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>订货日期：</td>
                            <td>
                                <input type="text" id="BookingDateFrom" name="BookingDateFrom" class="easyui-datebox" style="width: 100%;" /></td>
                            <td>至：</td>
                            <td>
                                <input type="text" id="BookingDateTo" name="BookingDateTo" class="easyui-datebox" style="width: 100%;" /></td>
                            <td class="lbl-caption">客户名称:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Text4" name="CustomerName" type="text" />
                            </td>

                        </tr>
                        <tr>
                            <td class="lbl-caption">交货日期：</td>
                            <td>
                                <input type="text" id="ShipDateFrom" name="ShipDateFrom" class="easyui-datebox" style="width: 100%;" /></td>
                            <td>至：</td>
                            <td>
                                <input type="text" id="ShipDateTo" name="ShipDateTo" class="easyui-datebox" style="width: 100%;" /></td>
                            <td class="lbl-caption">联系电话:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Text5" name="Mobile" type="text" />
                            </td>
                            <td class="lbl-caption"></td>
                            <td colspan="2" style="text-align: left">
                                <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
        </div>
        <div id="edit_window" class="easyui-window" closed="true" title="上传文件" data-options="iconCls:'icon-save'"
            style="width: 900px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false">
                    <form id="edit_form" name="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                        <div class="easyui-layout" fit="true" border="false">
                            <div region="north" border="false">
                                <input type="hidden" id="OrderID" name="OrderID" />
                                <table style="width: 100%; height: 100%; padding: 15px;">
                                    <tr>
                                        <td class="lbl-caption">订单编号:
                                        </td>
                                        <td>
                                            <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">采购单号：
                                        </td>
                                        <td>
                                            <input id="Text3" type="text" name="PurchaseNo" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">订单类型：
                                        </td>
                                        <td>
                                            <input id="OrderType" type="text" name="OrderType" style="width: 100%;" readonly="true" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">订单状态:
                                        </td>
                                        <td>
                                            <input type="text" id="Statu" name="Status" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">产品类型:
                                        </td>
                                        <td>
                                            <input type="text" id="CabinetType" name="CabinetType" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">是否正标:
                                        </td>
                                        <td>
                                            <input type="text" id="IsStandard" name="IsStandard" style="width: 100%;" readonly="true" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">订货日期:
                                        </td>
                                        <td>
                                            <input type="text" id="BookingDate" name="BookingDate" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">交货日期:
                                        </td>
                                        <td>
                                            <input type="text" id="ShipDate" name="ShipDate" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">是否外购:
                                        </td>
                                        <td>
                                            <input type="text" id="IsOutsourcing" name="IsOutsourcing" style="width: 100%;" readonly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">客户名称:
                                        </td>
                                        <td>
                                            <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">联系电话:
                                        </td>
                                        <td>
                                            <input type="text" id="Mobile" name="Mobile" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">联系人:
                                        </td>
                                        <td>
                                            <input type="text" id="LinkMan" name="LinkMan" style="width: 100%;" readonly="true" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">客户地址:
                                        </td>
                                        <td colspan="5">
                                            <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" />
                                        </td>
                                    </tr>
                                    <tr>


                                        <td class="lbl-caption">开始生产:
                                        </td>
                                        <td>
                                            <input type="text" id="ManufactureDate" name="ManufactureDate" style="width: 100%;" readonly="true" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div region="center" style="padding: 0px; overflow: hidden;" title="待上传文件产品">
                                <table id="dgcabinet"></table>
                            </div>
                            <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                                <a id="btn_edit_return" icon="icon-cancel" style="width: 100px; height: 30px;" class="easyui-linkbutton" href="javascript:void(0)">退回订单</a>
                                <a id="btn_edit_finish" icon="icon-save" style="width: 100px; height: 30px;" class="easyui-linkbutton" href="javascript:void(0)">提交完成</a>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div id="upload_window" class="easyui-window" closed="true" title="上传文件" data-options="iconCls:'icon-save'"
            style="width: 800px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false">
                    <form id="upload_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                        <div>
                            <input type="hidden" id="OrderID" name="OrderID" />
                            <input type="hidden" id="CabinetID" name="CabinetID" />
                        </div>
                        <div class="easyui-panel" title="BOM文件(请上传Excel格式文件,不同产品按产品名称拆分)" style="height: 80px; padding: 5px;" iconcls="folder_table">
                            <input id="bomfile" name="bomfile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:false,buttonText:'选择文件',accept:'.xls,.xlsx'" required="true" />
                            <input type="checkbox" id="IsHandmade" name="IsHandmade" value="False" />手工料单
                        </div>
                        <div class="easyui-panel" title="五金文件(请上传Excel格式文件,不同产品按产品名称拆分)" style="height: 80px; padding: 5px;" iconcls="folder_table">
                            <input id="hardwarefile" name="hardwarefile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:false,buttonText:'选择文件',accept:'.xls,.xlsx'" required="true" />
                        </div>
                        <div class="easyui-panel" title="CNC文件" style="height: 80px; padding: 5px;" iconcls="folder_table">
                            <input id="cnc_productfile" name="cnc_productfile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件(多选)',accept:'.csv,.xml'" required="true" />
                        </div>
                        <div class="easyui-panel" title="DXF文件" style="height: 80px; padding: 5px;" iconcls="folder_table">
                            <input id="dxf_productfile" name="dxf_productfile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件(多选)',accept:'.dxf'" />
                        </div>
                        <div class="easyui-panel" title="图纸文件" style="height: 80px; padding: 5px;" iconcls="folder_table">
                            <input id="drawingfile" name="drawingfile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件',accept:'.dwg,.pdf,.dft'" />
                        </div>
                        <div class="easyui-panel" title="效果图" style="height: 80px; padding: 5px;" iconcls="folder_table">
                            <input id="RenderingFile" name="RenderingFile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件(多选)',accept:'.jpg,.png,.bmp,.jpeg,.gif'" />
                        </div>
                    </form>
                </div>
                <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                    <a id="btn_fileupload" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)">上传文件</a><a id="btn_cancel"
                        icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                </div>
            </div>
        </div>

        <div id="steps_window" class="easyui-window" closed="true" title="审核明细" data-options="iconCls:'icon-save'"
            style="width: 850px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false">
                    <table id="dgsteps"></table>
                </div>
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
