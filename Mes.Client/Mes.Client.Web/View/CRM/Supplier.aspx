<%@ Page Title="供应商资料" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="Mes.Client.Web.View.CRM.Supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/common/region_select.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.supplier.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div id="show"></div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 60px; border-bottom: solid 1px #93ccf6;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">供应商名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px" id="SupplierName" name="SupplierName" type="text" />
                                </td>
                                <td class="lbl-caption">供应商编号：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Address" name="SupplierCode" type="text" />
                                </td>
                                <td class="lbl-caption">供应商类型:
                                </td>
                                <td>
                                    <input style="width: 120px" id="SearchCategoryID" name="Category" class="easyui-combobox" value="" />
                                </td>
                                <td class="lbl-caption">移动电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                                </td>


                            </tr>
                            <tr>
                                <td class="lbl-caption">省份:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="ProvinceText" name="Province" type="text" />
                                </td>

                                <td class="lbl-caption">城市：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="CityText" name="City" type="text" />
                                </td>

                                <td class="lbl-caption">地址：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="AddressText" name="Address" type="text" />
                                </td>
                                <td class="lbl-caption"></td>
                                <td colspan="3" style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>

                            </tr>

                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div region="east" split="false" title="供应商资料管理" style="width: 400px;">
        <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新供应商</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="SupplierID" name="SupplierID" />
                        </div>
                        <table cellpadding="3" id="tbsupplierInfo">

                            <tr>
                                <td class="lbl-caption">供应商名称:
                                </td>
                                <td style="width: 120px;">
                                    <input id="SupplierNames" name="SupplierName" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">供应商类型:
                                </td>
                                <td style="width: 120px;">
                                    <input id="CategoryID" name="Category" class="easyui-combobox" required="true" style="width: 125px" />

                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">供应商编号:
                                </td>
                                <td style="width: 120px;">
                                    <input id="SupplierCode" name="SupplierCode" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">所属省份:
                                </td>
                                <td>
                                    <select id="Province" name="Province" style="width: 125px;" class="easyui-combobox">
                                    </select>
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">所属城市:
                                </td>
                                <td>
                                    <select id="City" name="City" style="width: 125px;" class="easyui-combobox">
                                    </select>
                                </td>
                            </tr>
                            <%--区县预留 onchange="LoadCounty();--%>
                            <%--<tr>
                                <td class="lbl-caption">所属区/县:
                                </td>
                                <td>
                                    <select id="County" name="county" style="width: 100%;"  >
                                        <option id='chooseCounty' value='-1'>请选择区/县</option>
                                    </select>
                                   
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="lbl-caption">详细地址:
                                </td>
                                <td>
                                    <input id="Text1" name="Address" type="text" class="easyui-validatebox" required="true"
                                        maxlength="200" style="width: 250px;" />

                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">联系人:
                                </td>
                                <td>
                                    <input id="LinkMan" name="LinkMan" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td>
                                    <input id="Tel" name="Tel" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" validtype="tel" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">移动电话:
                                </td>
                                <td>
                                    <input id="Mobile" name="Mobile" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" validtype="mobile" />
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">邮箱:
                                </td>
                                <td>
                                    <input id="Email" name="Email" type="text" class="easyui-validatebox" validtype="email" required="true" />
                                </td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">备注说明:
                                </td>
                                <td colspan="3">
                                    <textarea id="Remark" name="Remark" cols="72" rows="3" style="width: 100%; height: 80px;" class="easyui-validatebox"
                                        validtype="length[0,800]" maxlength="800"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
