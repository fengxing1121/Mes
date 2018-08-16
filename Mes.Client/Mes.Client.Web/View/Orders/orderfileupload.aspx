<%@ Page Title="文件上传" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orderfileupload.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orderfileupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.orderfileupload.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="订单详情" region="center" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="text-align: left; height: auto; overflow: hidden;" id="search_window">
                <form id="upload_form" name="upload_form" method="post" enctype="multipart/form-data">
                    <div style="height: auto; padding: 5px;">
                        <table style="width: 100%; height: 50px;">
                            <tr>
                                <td style="width: 80px; text-align: right;">订单编号:
                                </td>
                                <td>
                                    <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" readonly="true" />
                                </td>
                                <td style="width: 100px; text-align: right;">订单类型：
                                </td>
                                <td>
                                    <input id="OrderType" type="text" name="OrderType" style="width: 100%;" readonly="true" />
                                </td>
                                <td style="width: 80px; text-align: right;">订货日期:
                                </td>
                                <td>
                                    <input type="text" id="BookingDate" name="BookingDate" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; text-align: right;">客户名称:
                                </td>
                                <td>
                                    <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" readonly="true" />
                                </td>
                                <td style="width: 100px; text-align: right;">联系电话:
                                </td>
                                <td>
                                    <input type="text" id="Mobile" name="Mobile" style="width: 100%;" readonly="true" />
                                </td>
                                <td style="width: 80px; text-align: right;">联系人:
                                </td>
                                <td>
                                    <input type="text" id="LinkMan" name="LinkMan" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; text-align: right;">客户地址:
                                </td>
                                <td colspan="5">
                                    <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; text-align: right;">交货日期:
                                </td>
                                <td>
                                    <input type="text" id="ShipDate" name="ShipDate" style="width: 100%;" readonly="true" />
                                </td>
                                <td style="width: 100px; text-align: right;">订单状态:
                                </td>
                                <td>
                                    <input type="text" id="Status" name="Status" style="width: 100%;" readonly="true" />
                                </td>
                                <td style="width: 80px; text-align: right;">开始生产:
                                </td>
                                <td>
                                    <input type="text" id="ManufactureDate" name="ManufactureDate" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div title="拆单文件上传" fit="true" border="false" style="padding: 10px;">
                                        <input type="hidden" id="OrderID" name="OrderID" />
                                        <div class="easyui-panel" title="BOM文件(请上传Excel格式文件,不同产品按产品名称拆分)" style="height: 80px; padding: 5px;" iconcls="icon-save">
                                            <input id="bomfile" name="bomfile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件',accept:'.xls,.xlsx'" required="true" />
                                        </div>
                                        <div class="easyui-panel" title="五金文件(请上传Excel格式文件,不同产品按产品名称拆分)" style="height: 80px; padding: 5px;" iconcls="icon-save">
                                            <input id="hardwarefile" name="hardwarefile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:false,buttonText:'选择文件',accept:'.xls,.xlsx'" required="true" />
                                        </div>
                                        <div class="easyui-panel" title="图纸文件" style="height: 80px; padding: 5px;" iconcls="icon-save">
                                            <input id="drawingfile" name="drawingfile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件',accept:'.dwg,.pdf'" required="true" />
                                        </div>
                                        <div class="easyui-panel" title="工艺文件" style="height: 80px; padding: 5px;" iconcls="icon-save">
                                            <input id="productfile" name="productfile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件(多选)'" required="true" />
                                        </div>
                                        <div class="easyui-panel" title="效果图" style="height: 80px; padding: 5px;" iconcls="icon-save">
                                            <input id="RenderingFile" name="RenderingFile" type="text" style="width: 60%;" class="easyui-filebox" data-options="multiple:true,buttonText:'选择文件(多选)',accept:'.jpg,.png,.bmp,.jpeg,.gif'" required="true" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div style="margin-bottom: 5px; height: 40px; text-align: center;">
                                        <a id="btn_fileupload" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)">上传文件</a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
