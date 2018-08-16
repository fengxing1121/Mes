<%@ Page Title="方案报价" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewQuote.aspx.cs" Inherits="Mes.Client.Web.View.CRM.NewQuote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Script/uploadify/uploadify.css" rel="stylesheet" />
    <script src="../../Script/uploadify/jquery.uploadify.min.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-bufferview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-defaultview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-detailview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-scrollview.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.newquote.js"></script>
    <style>
        input[readonly] {
            border: none;
        }

        .item {
            width: 100%;
            height: 200px;
            margin-left: 0px;
            margin-top: 0px;
            border: none;
            float: left;
        }

        .img_wrap {
            border: solid 1px #eee;
            width: 320px;
            height: 160px;
            display: table-cell;
            text-align: center;
            vertical-align: middle;
        }

            .img_wrap img {
                max-width: 320px;
                max-height: 160px;
                height: 240px auto;
                width: 160px auto;
                vertical-align: middle;
                text-align: center;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" border="false">
        <form id="edit_form" method="post" style="width: 100%; height: 100%;">
            <div class="easyui-layout" fit="true">
                <div region="north" border="false" title="报价清单" style="height: 280px; overflow: hidden;">
                    <div style="text-align: right; padding-right: 50px; padding-top: 5px;">
                        <a id="btn_upload_splitfile" icon="icon-save" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">重新上传文件</a>
                        <a id="btn_quote" icon="icon-save" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">生成报价单</a>
                        <a id="btn_cancel" icon="icon-cancel" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">取消方案</a>
                    </div>
                    <div>
                        <input type="hidden" id="CustomerID" name="CustomerID" />
                        <input type="hidden" id="QuoteDetails" name="QuoteDetails" />
                        <input type="hidden" id="QuoteID" name="QuoteID" />
                        <input type="hidden" id="SolutionID" name="SolutionID" />
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
                                <td class="lbl-caption">报价单号：</td>
                                <td>
                                    <input type="text" id="QuoteNo" value="自动生成" style="width: 100%;" maxlength="50" class="easyui-validatebox" readonly="true" />
                                </td>
                                <td class="lbl-caption">失效日期：</td>
                                <td>
                                    <input type="text" id="ExpiryDate" name="ExpiryDate" style="width: 100%;" class="easyui-datebox" required="true" />
                                </td>
                                <td class="lbl-caption">折扣率：</td>
                                <td>
                                    <input type="text" id="DiscountPercent" name="DiscountPercent" class="easyui-numberbox" data-options="precision:2" style="width: 100%;" required="true" /></td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">备注:
                                </td>
                                <td colspan="5">
                                    <textarea id="Remark" name="Remark" maxlength="200" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div region="center" border="false">
                    <div class="easyui-tabs" fit="true" border="false" id="tt">
                        <div title="部件用料列表" fit="true" border="false">
                            <div class="easyui-layout" fit="true">
                                <%--<div region="north" border="false" style="height: auto;">
                                    <table>
                                        <tr>
                                            <td class="lbl-caption">用料选择：</td>
                                            <td>
                                                <input type="text" id="MaterialID" name="MaterialID" class="easyui-combogrid" style="width: 200px; height: 27px;" />
                                            </td>
                                            <td><a href="#" class="easyui-linkbutton" iconcls="icon-ok" plain="true" id="btn_setMaterial">确定</a></td>
                                        </tr>
                                    </table>
                                </div>--%>
                                <div region="center" border="false">
                                    <table id="dgdetail"></table>
                                </div>
                            </div>
                        </div>
                        <div title="五金用料明细" fit="true" border="false">
                            <table id="dghardware">
                            </table>
                        </div>
                        <div title="移门清单" fit="true" border="false">
                            <table id="dgdoors">
                            </table>
                        </div>
                        <div title="其他费用" fit="true" border="false">
                            <table id="dgohers">
                            </table>
                        </div>
                    </div>
                </div>
                <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                    <%--<a id="btn_edit_save" icon="icon-save" style="width: 150px; height: 40px; background: #0094ff; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">生成报价单</a>--%>
                </div>
            </div>
        </form>
    </div>

    <!--上传方案文件-->
    <div id="upload_window" class="easyui-window" closed="true" title="上传方案文件" data-options="iconCls:'icon-save'"
        style="width: 340px; height: 240px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden;">
                <form id="upload_form" method="post" style="overflow: hidden;" enctype="multipart/form-data">
                    <div class="item">
                        <input type="hidden" id="SolutionFileUrl" name="SolutionFileUrl" />
                        <input type="hidden" id="CabinetID" name="CabinetID" />
                        <div class="img_wrap">
                            <img id="imgSolution" src="/Content/images/solution_bg.png" />
                        </div>
                        <div id="Solution_queue" name="Solution_queue" style="position: absolute; top: 80px; width: 320px; z-index: 999; max-height: 160px;"></div>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                <input type="file" name="solution_uploadify" id="solution_uploadify" />
                <a id="btn_close" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>

    <!--材料名称下拉-->
    <div id="tbMaterial" style="padding: 5px; height: auto">
        <form id="search_form_material">
            <table>
                <tr>
                    <td class="lbl-caption">材料编号: </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="MaterialCode" name="MaterialCode" type="text" />
                    </td>
                    <td class="lbl-caption">材料名称</td>
                    <td style="width: 120px;">
                        <input type="text" style="width: 120px" id="MaterialName" name="MaterialName" />
                    </td>
                    <td><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_form_material">搜索</a></td>
                </tr>
                <%--<tr>
                    <td class="lbl-caption">材料类型:
                    </td>
                    <td>
                        <input style="width: 120px" id="SearchCategoryID" name="Category" class="easyui-combobox" value="" />
                    </td>
                    <td class="lbl-caption">子类型:
                    </td>
                    <td>
                        <input style="width: 120px" id="SearchSubCategoryID" name="SubCategory" class="easyui-combobox" value="" />
                    </td>
                    
                </tr>--%>
            </table>
        </form>
    </div>
</asp:Content>
