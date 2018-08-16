<%@ Page Title="工作中心" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="workcenter.aspx.cs" Inherits="Mes.Client.Web.View.Workcenters.workcenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/workcenters/jquery.forms.workcenter.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div class="datagrid-toolbar" style="height: auto;">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">设备编号:
                                </td>
                                <td class="lbl-caption">
                                    <input style="width: 120px" id="WorkCenterCode" name="WorkCenterCode" type="text" />
                                </td>
                                <td class="lbl-caption">设备名称：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="WorkCenterName" name="WorkCenterName" type="text" />
                                </td>
                                <td style="width:100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div region="east" split="true" title="工作中心资料管理" style="width: 400px;" border="true">
        <div region="center" border="true" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新增</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="WorkCenterID" name="WorkCenterID" />
                        </div>
                        <table cellpadding="3" style="width:100%;">
                            <tr>
                                <td class="lbl-caption">设备编号:
                                </td>
                                <td>
                                    <input id="WorkCenterCode" name="WorkCenterCode" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">设备名称:
                                </td>
                                <td>
                                    <input id="WorkCenterName" name="WorkCenterName" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">规格:
                                </td>
                                <td>
                                    <input id="Style" name="Style" type="text" class="easyui-validatebox" 
                                        maxlength="30" />
                                </td>
                            </tr>
                              <tr>
                                <td class="lbl-caption">型号:
                                </td>
                                <td>
                                    <input id="Model" name="Model" type="text" class="easyui-validatebox"
                                        maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">车间名称:
                                </td>
                                <td>
                                    <input id="WorkShopID" name="WorkShopID" class="easyui-combobox" required="true" style="width: 120px;" />                                        
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">加工工序:
                                </td>
                                <td>
                                    <input id="WorkFlowID" name="WorkFlowID" class="easyui-combobox" required="true" style="width: 120px;" />                                        
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">最大产能(小时):
                                </td>
                                <td>
                                    <input id="MaxCapacity" name="MaxCapacity" type="text" class="easyui-validatebox" required="true" 
                                        maxlength="200" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">产能计算方式:
                                </td>
                                <td>
                                    <select id="CountCapacityType" name="CountCapacityType" class="easyui-combobox" required="true" style="width:120px;">
                                        <option value="请选择">请选择</option>
                                        <option value="A">面积</option>
                                        <option value="L">长度</option>
                                        <option value="Q">板件数量</option>
                                    </select>
                                </td>
                            </tr>  
                            <tr>
                                <td class="lbl-caption">排序:
                                </td>
                                <td  >
                                    <input id="Sequence" name="Sequence" type="text" class="easyui-validatebox" required="true"
                                        maxlength="30"   />
                                </td>
                            </tr>                            
                            <tr>
                                <td class="lbl-caption">备注说明:
                                </td>
                                <td>
                                    <textarea id="Remark" name="Remark" cols="72" rows="3" style="width:100%; height: 80px;" class="easyui-validatebox"
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
