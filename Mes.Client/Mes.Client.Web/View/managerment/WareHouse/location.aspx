<%@ Page Title="仓位列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="location.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.location" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.forms.location.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="仓位列表" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>

            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">所属仓库:
                                </td>
                                <td>
                                    <input style="width: 120px;height:27px;" id="SearchWarehouseID" name="Category" class="easyui-combobox" value="" />
                                </td>
                                <td class="lbl-caption">位置编号</td>
                                <td style="width: 120px;">
                                    <input type="text" style="width: 120px" id="SearchLocationCode" name="LocationCode" />
                                </td>

                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div id="edit_window" class="easyui-window" closed="true" title="新增仓位" data-options="iconCls:'icon-save'"
        style="width: 800px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="edit_form" method="post">
                    <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                        <table style="width: 100%; height: 100%; padding: 5px;">
                            <tr>
                                <td class="lbl-caption" style="width: 120px;">所属仓库:
                                </td>
                                <td>
                                    <input style="width: 100%" id="Category" name="Category" class="easyui-combobox" value="" />
                                </td>

                            </tr>
                            <tr>
                                <td class="lbl-caption">货架编号:
                                </td>
                                <td>
                                    <input type="text" id="CabinetNumCode" name="CabinetNumCode" class="easyui-validatebox" style="width: 80px;" required="true" placeholder="货架编码" value="C" />
                                    <input type="text" id="CabinetNumFrom" name="CabinetNumFrom" class="easyui-validatebox" style="width: 80px;" required="true" />
                                    <span style="width: 20px; text-align: right;">至：</span>
                                    <input type="text" id="CabinetNumTo" name="CabinetNumTo" class="easyui-validatebox" style="width: 80px;" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">层号:
                                </td>
                                <td>
                                    <input type="text" id="LayerNumCode" name="LayerNumCode" class="easyui-validatebox" style="width: 80px;" required="true" placeholder="层号编码" value="L" />
                                    <input type="text" style="width: 80px;" id="LayerNumFrom" name="LayerNumFrom" class="easyui-validatebox" required="true" />
                                    <span style="width: 20px; text-align: right;">至：</span>
                                    <input type="text" style="width: 80px;" id="LayerNumTo" name="LayerNumTo" class="easyui-validatebox" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">仓位数量:
                                </td>
                                <td>
                                    <input type="text" id="Qty" name="Qty" class="easyui-validatebox" style="width: 80px;" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">最大重量:
                                </td>
                                <td>
                                    <input type="text" id="MaxWeight" name="MaxWeight" style="width: 100%;" class="easyui-validatebox" required="true" value="0" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">最大包数:
                                </td>
                                <td>
                                    <input type="text" id="MaxPackage" name="MaxPackage" style="width: 100%;" class="easyui-validatebox" required="true" value="0" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a> <a id="btn_edit_cancel"
                    icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>


    <div region="east" split="true" title="仓位管理" style="width: 400px;" border="false">
        <form id="edit_form_manage" method="post">
            <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                <div style="margin-bottom: 5px;">
                    <a id="btn_edit_new" icon="icon-add" class="easyui-linkbutton" href="javascript:void(0)">新增</a>
                    <a id="btn_edit_submit" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                </div>
                <div>
                    <input type="hidden" id="LocationID" name="LocationID" />

                </div>
                <table style="width: 95%; height: 100%;">
                    <tr>
                        <td class="lbl-caption">所属仓库:
                        </td>
                        <td>
                            <input id="Warehouse" name="WarehouseID" class="easyui-combobox" style="width: 100%;" required="true" />
                        </td>
                    </tr>

                    <tr>
                        <td class="lbl-caption">货架号:
                        </td>
                        <td>
                            <input type="text" id="Text2" name="CabinetNum" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">层号:
                        </td>
                        <td>
                            <input type="text" id="LayerNum" name="LayerNum" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">位置编号:
                        </td>
                        <td>
                            <input id="Text1" name="LocationCode" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">最大重量(kg):
                        </td>
                        <td>
                            <input type="text" id="Text3" name="MaxWeight" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">最大包数:
                        </td>
                        <td>
                            <input type="text" id="Text4" name="MaxPackage" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">是否禁用:
                        </td>
                        <td>
                            <input type="checkbox" id="IsDisabled" name="IsDisabled" value="false" />
                        </td>
                    </tr>

                </table>
            </div>
        </form>
    </div>
</asp:Content>
