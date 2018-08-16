<%@ Page Title="生成订单" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="Mes.Client.Web.View.CRM.AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <script src="../../Script/easyui/datagrid/datagrid-scrollview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-bufferview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-defaultview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-detailview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.addorder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
            <form id="add_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="north" border="false">
                        <div>
                            <input type="hidden" id="OrderID" name="OrderID" />
                            <input type="hidden" id="TaskID" name="TaskID" />
                            <input type="hidden" id="SolutionID" name="SolutionID" />
                            <input type="hidden" id="QuoteID" name="QuoteID" />
                            <input type="hidden" id="DesignerID" name="DesignerID" />
                            <input type="hidden" id="CustomerID" name="CustomerID" />
                        </div>
                        <div style="width: 100%;">
                            <table style="width: 100%; height: auto; padding: 5px;">
                                <tr>
                                    <td class="lbl-caption">客户名称:</td>
                                    <td>
                                        <input type="text" style="width: 195px; height: 25px;" id="CustomerName" name="CustomerName" readonly="true" />
                                    </td>
                                    <td class="lbl-caption" style="width: 150px;">联系电话: </td>
                                    <td>
                                        <input type="text" id="Mobile" name="Mobile" style="width: 195px;" readonly="true" />
                                    </td>
                                    <td class="lbl-caption">联系人:</td>
                                    <td>
                                        <input type="text" id="LinkMan" name="LinkMan" style="width: 195px;" readonly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">客户地址:</td>
                                    <td colspan="7">
                                        <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td class="lbl-caption" style="width: 120px;">订单编号: </td>
                                    <td>
                                        <input type="text" id="OrderNo" name="OrderNo" style="width: 195px;" placeholder="自动生成" readonly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption" style="width: 120px;">订单号:</td>
                                    <td>
                                        <input type="text" id="OrderNo" name="OrderNo" class="easyui-validatebox" style="width: 195px; background: #f0f0f0;" readonly="true" />
                                    </td>
                                </tr>--%>


                                <tr style="display: none">
                                    <td class="lbl-caption" style="width: 120px;">经销商ID:</td>
                                    <td>
                                        <input type="text" id="PartnerID" name="PartnerID" class="easyui-validatebox" style="width: 195px; background: #f0f0f0;" readonly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption" style="width: 120px;">外部订单号:</td>
                                    <td>
                                        <input type="text" id="OutOrderNo" name="OutOrderNo" class="easyui-validatebox" style="width: 195px; background: #f0f0f0;" readonly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption" style="width: 120px;">采购单号:</td>
                                    <td>
                                        <input type="text" id="PurchaseNo" name="PurchaseNo" class="easyui-validatebox" style="width: 195px; background: #f0f0f0;" required="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">是否正标: </td>
                                    <td>
                                        <select style="width: 120px; height: 25px;" id="IsStandard" name="IsStandard" class="easyui-combobox" required="true">
                                            <option value="true">是</option>
                                            <option value="false">否</option>
                                        </select>
                                        <%--<input type="text" id="IsStandard" name="IsStandard" value="true" class="easyui-validatebox" style="width: 195px; background: #f0f0f0;" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">订单状态:</td>
                                    <td>
                                        <input type="text" id="Status" name="Status" style="width: 195px; background: #f0f0f0;" value="信息待确认" placeholder="信息待确认" readonly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">产品类型:</td>
                                    <td>
                                        <select style="width: 120px; height: 25px;" id="CabinetType" name="CabinetType" class="easyui-combobox" required="true">
                                            <option value="请选择">请选择</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">是否外购:</td>
                                    <td>
                                        <select id="IsOutsourcing" name="IsOutsourcing" style="width: 120px; height: 25px;" class="easyui-combobox" required="true">
                                            <option value="false">否</option>
                                            <option value="true">是</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">订单类型: </td>
                                    <td>
                                        <select id="OrderType" name="OrderType" style="width: 120px; height: 25px;" class="easyui-combobox" required="true">
                                            <option value="正常">正常</option>
                                            <option value="加急">加急</option>
                                            <option value="补货">补货</option>
                                            <option value="工程">工程</option>
                                            <option value="展会">展会</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">订货日期:</td>
                                    <td>
                                        <input type="text" id="BookingDate" name="BookingDate" style="width: 120px; height: 25px;" class="easyui-datebox" readonly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">交货日期:</td>
                                    <td>
                                        <input type="text" id="ShipDate" name="ShipDate" style="width: 120px; height: 25px;" class="easyui-datebox" required="true" />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td class="lbl-caption">外部单号:</td>
                                    <td>
                                        <input type="text" style="width: 195px; height: 25px;" id="OutOrderNo" name="OutOrderNo" class="easyui-validatebox" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="lbl-caption">客户预收款(元):</td>
                                    <td>
                                        <input type="text" style="width: 202px; height: 30px;" id="Amount" name="Amount" class="easyui-numberbox" data-options="precision:2" maxlength="50" />
                                    </td>
                                    <td class="lbl-caption">凭证号:</td>
                                    <td>
                                        <input type="text" style="width: 202px; height: 25px;" id="VoucherNo" maxlength="60" name="VoucherNo" class="easyui-validatebox" />
                                    </td>
                                    <td class="lbl-caption">收款人:</td>
                                    <td>
                                        <input type="text" style="width: 202px; height: 25px;" id="Payee" maxlength="50" name="Payee" class="easyui-validatebox" />
                                    </td>
                                    <td class="lbl-caption">收款日期:</td>
                                    <td>
                                        <input type="text" style="width: 202px; height: 25px;" id="TransDate" name="TransDate" class="easyui-datebox" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="lbl-caption">备注:</td>
                                    <td colspan="7">
                                        <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div region="south" border="south" style="margin-top: 5px; margin-right: 50px; float: right; text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                        <a id="btn_edit_save" icon="icon-save" style="width: 100px; height: 30px; background: #ff6a00; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">提交订单</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
