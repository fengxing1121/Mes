<%@ Page Title="报价详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuoteShow.aspx.cs" Inherits="Mes.Client.Web.View.CRM.QuoteShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <script src="../../Script/easyui/datagrid/datagrid-bufferview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-defaultview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-detailview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-scrollview.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.quoteshow.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" border="false">
        <form id="search_form" style="width: 100%; height: 100%;">
            <div class="easyui-layout" fit="true">
                <div region="north" border="false" style="height: 50px; overflow: hidden;" collapsible="false">
                    <div style="text-align: right; float: right; height: 40px; padding-right: 50px; padding-top: 5px;">
                        <%-- <a id="btn_certain" icon="icon-save" style="display: none; float: left; width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">确认报价</a>--%>
                        <%-- <a id="btn_cancel" icon="icon-cancel" style="display: none; float: left; margin-left: 5px; width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">取消报价</a>--%>
                        <a id="btn_rptView" icon="icon-print" style="float: left; margin-left: 5px; width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">报表预览</a>
                    </div>
                </div>
                <div region="center" border="false">
                    <div class="easyui-layout" fit="true">
                        <div region="north" border="false" iconcls="table" title="报价清单详情" style="height: 280px; overflow: hidden;" collapsible="false">
                            <div>
                                <input type="hidden" id="SolutionID" name="SolutionID" />
                                <input type="hidden" id="QuoteID" name="QuoteID" />
                                <input type="hidden" id="QuoteNo" name="QuoteNo" />
                                <table>
                                    <tr>
                                        <td class="lbl-caption">客户名称：</td>
                                        <td>
                                            <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">联系人：</td>
                                        <td>
                                            <input type="text" id="LinkMan" name="LinkMan" style="width: 100%;" readonly="true" /></td>
                                        <td class="lbl-caption">联系电话：</td>
                                        <td>
                                            <input type="text" id="Mobile" name="Mobile" style="width: 100%;" readonly="true" /></td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">客户地址：</td>
                                        <td colspan="3">
                                            <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" /></td>
                                        <td class="lbl-caption">邮箱：</td>
                                        <td>
                                            <input type="text" id="Email" name="Email" style="width: 100%;" readonly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">状态：</td>
                                        <td>
                                            <input type="text" id="Status" name="Status" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">失效日期：</td>
                                        <td>
                                            <input type="text" id="ExpiryDate" name="ExpiryDate" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">折扣率(%)：</td>
                                        <td>
                                            <input type="text" id="DiscountPercent" name="DiscountPercent" style="width: 100%;" readonly="true" /></td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">总金额(元)：</td>
                                        <td>
                                            <input type="text" id="TotalAmount" name="TotalAmount" style="width: 100%;" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">折扣金额(元)：</td>
                                        <td>
                                            <input type="text" id="DiscountAmount" name="DiscountAmount" style="width: 100%;" readonly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">备注:</td>
                                        <td colspan="5">
                                            <textarea id="Remark" name="Remark" disabled="disabled" maxlength="200" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div region="center" border="false">
                            <div class="easyui-tabs" fit="true" border="false" id="tt">
                                <div title="产品列表" fit="true" border="false" iconcls="table">
                                    <table id="dgcabinet"></table>
                                </div>
                                <div title="用料列表" fit="true" border="false" iconcls="table">
                                    <table id="dgdetail"></table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>

</asp:Content>
