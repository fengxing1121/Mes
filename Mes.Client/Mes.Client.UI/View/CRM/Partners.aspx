<%@ Page Title="门店管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Partners.aspx.cs" Inherits="Mes.Client.UI.View.CRM.Partners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.province.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.partners.js?ver=1.2"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto; border-bottom: solid 1px #93ccf6;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">门店名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px" id="PartnerName" name="PartnerName" type="text" />
                                </td>
                                <td class="lbl-caption">移动电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                                </td>
                                <td class="lbl-caption">业务员:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Tel" name="Tel" type="text" />
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
                                    <input style="width: 120px; height: 22px;" id="City" name="City" type="text" />
                                </td>

                                <td class="lbl-caption">地址：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Address" name="Address" type="text" />
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
    <div region="east" split="true" title="门店资料管理" style="width: 400px;" border="true">
        <div region="center" border="true" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新商户</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                        </div>
                        <table cellpadding="3" id="tbPartnerInfo">
                            <tr>
                                <td class="lbl-caption">门店编号:
                                </td>
                                <td style="width: 120px;">
                                    <input id="PartnerCode" name="PartnerCode" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">门店名称:<span style="color: red;">*</span>
                                </td>
                                <td style="width: 120px;">
                                    <input name="PartnerName" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">联系人:<span style="color: red;">*</span>
                                </td>
                                <td>
                                    <input id="LinkMan" name="LinkMan" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">移动电话:<span style="color: red;">*</span>
                                </td>
                                <td>
                                    <input id="Mobile" name="Mobile" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" validtype="mobile" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">业务员:<span style="color: red;">*</span>
                                </td>
                                <td>
                                    <input id="Tel" name="Tel" type="text" class="easyui-validatebox" required="true" placeholder=""
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
                            <tr>
                                <td class="lbl-caption">详细地址:
                                </td>
                                <td colspan="3">
                                    <input name="Address" type="text" class="easyui-validatebox"
                                        maxlength="200" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">备注说明:
                                </td>
                                <td colspan="3">
                                    <textarea id="Remark" name="Remark" cols="72" rows="3" style="width: 100%; height: 80px;" class="easyui-validatebox"  validtype="length[0,800]" maxlength="800"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
