<%@ Page Title="量尺详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoomDesignerShow.aspx.cs" Inherits="Mes.Client.Web.View.CRM.RoomDesignerShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <script src="../../Script/forms/crm/jquery.forms.roomdesignershow.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="north" border="false">
        <div style="width: 100%;">
            <form id="edit_form" method="post" enctype="multipart/form-data">
                <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                    <div>
                        <input type="hidden" id="DesignerID" name="DesignerID" />
                    </div>
                    <table style="width: 100%; height: 100%; padding: 4px;">
                        <tr>
                            <td class="lbl-caption" style="width: 120px;">客户名称:</td>
                            <td>
                                <input type="text" style="width: 100%;" id="CustomerName" name="CustomerName" />
                            </td>
                            <%--<td class="lbl-caption">设计者:</td>
                                  <td>
                                      <input type="text" id="Designer" name="Designer" style="width: 100%;" />                                                               
                                  </td>--%>
                        </tr>
                        <tr>
                            <td class="lbl-caption">房间数:</td>
                            <td>
                                <input type="text" id="Rooms" name="Rooms" style="width: 100%;" />
                            </td>
                            <td class="lbl-caption">客厅和餐厅数:</td>
                            <td>
                                <input type="text" id="SittingAndDiningRoom" name="SittingAndDiningRoom" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">房屋面积:</td>
                            <td>
                                <input type="text" id="TotalAreal" name="TotalAreal" style="width: 100%;" />
                            </td>
                            <td class="lbl-caption">家庭人员: </td>
                            <td>
                                <input type="text" id="FamilyMembers" name="FamilyMembers" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">预算(万元):</td>
                            <td>
                                <input type="text" id="Budget" name="Budget" style="width: 100%;" />
                            </td>
                            <td class="lbl-caption">量尺日期:</td>
                            <td>
                                <input type="text" id="Created" name="Created" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">所住小区名称: </td>
                            <td colspan="5">
                                <input type="text" id="VillageName" name="VillageName" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">栋数（号数）:</td>
                            <td>
                                <input type="text" id="Building" name="Building" style="width: 100%;" />
                            </td>
                            <td class="lbl-caption">所在单元: </td>
                            <td>
                                <input type="text" id="Unit" name="Unit" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">房号:</td>
                            <td>
                                <input type="text" id="RoomNo" name="RoomNo" style="width: 100%;" />
                            </td>
                            <td class="lbl-caption">喜欢颜色:</td>
                            <td>
                                <input type="text" id="Color" name="Color" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">装修风格: </td>
                            <td>
                                <input type="text" id="Style" name="Style" style="width: 100%;" />
                            </td>
                            <td class="lbl-caption">状态:</td>
                            <td>
                                <input type="text" id="Status" name="Style" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">备注:</td>
                            <td colspan="5">
                                <textarea id="Remark" name="Remark" disabled="true" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea></td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
    <div region="center" border="false">
        <div class="easyui-tabs" fit="true" border="false">
            <div title="文件详情" fit="true" border="false">
                <table id="dgroomfile"></table>
            </div>
        </div>
    </div>
</asp:Content>
