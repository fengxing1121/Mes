<%@ Page Title="客户资料" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Mes.Client.UI.View.CRM.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.province.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.customer.js?ver=1.23"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 60px; border-bottom: solid 1px #93ccf6;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px" id="CustomerName" name="CustomerName" type="text" />
                                </td>

                                <td class="lbl-caption">固定电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Tel" name="Tel" type="text" />
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
    <div region="east" split="true" title="客户资料管理" style="width: 400px;">
        <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新客户</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="CustomerID" name="CustomerID" />
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                        </div>
                        <table cellpadding="3" id="tbCustomerInfo">
                             <tr>
                                <td class="lbl-caption">门店:
                                </td>
                                <td>
                                    <input type="text" style="width: 125px;height:25px" id="PartnerName" name="PartnerName" class="easyui-combogrid" editable="false" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td style="width: 120px;">
                                    <input id="CustomerName" name="CustomerName" type="text" class="easyui-validatebox" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">移动电话:
                                </td>
                                <td>
                                    <input id="Text4" name="Mobile" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" validtype="mobile" />
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
                            <tr>
                                <td class="lbl-caption">详细地址:
                                </td>
                                <td colspan="3">
                                    <input id="Text2" name="Address" type="text" class="easyui-validatebox" 
                                        maxlength="200" style="width: 100%;" required="true"/>
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td class="lbl-caption">联系人:
                                </td>
                                <td>
                                    <input id="LinkMan" name="LinkMan" type="text" class="easyui-validatebox"  maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">职位:
                                </td>
                                <td>
                                    <input id="Position" name="Position" type="text" class="easyui-validatebox" 
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">固定电话:
                                </td>
                                <td>
                                    <input id="Text3" name="Tel" type="text" class="easyui-validatebox"
                                        maxlength="30" validtype="tel" />
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">传真:
                                </td>
                                <td>
                                    <input id="Fax" name="Fax" type="text" class="easyui-validatebox"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">邮箱:
                                </td>
                                <td>
                                    <input id="Email" name="Email" type="text" class="easyui-validatebox" validtype="email" />
                                </td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">网址:
                                </td>
                                <td>
                                    <input id="HomePage" name="HomePage" type="text" class="easyui-validatebox" />
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
    <div id="tb" style="padding: 5px; height: auto">
        <form id="search_form_partner">
            <table>
                <tr>
                    <td class="lbl-caption">编号:</td>
                    <td style="text-align: left">
                        <input type="text" id="PartnerCode" name="PartnerCode" /></td>
                    <td class="lbl-caption">名称: </td>
                    <td style="text-align: left">
                        <input type="text" id="PartnerName" name="PartnerName" /></td>
                    <td class="lbl-caption">联系人: </td>
                    <td style="text-align: left">
                        <input type="text" id="Text6" name="LinkMan" /></td>
                </tr>
                <tr>

                    <td class="lbl-caption">省份:
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="Text1" name="Province" type="text" />
                    </td>

                    <td class="lbl-caption">城市：
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="Text5" name="City" type="text" />
                    </td>

                    <td class="lbl-caption">地址：
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="Address" name="Address" type="text" />
                    </td>



                    <td colspan="2" style="text-align: left">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_partner" style="width: 80px;">搜索</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</asp:Content>
