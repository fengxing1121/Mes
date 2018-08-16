<%@ Page Title="我的任务" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnerTaskNew.aspx.cs" Inherits="Mes.Client.Web.View.CRM.PartnerTaskNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Script/uploadify/uploadify.css" rel="stylesheet" />
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <link href="../../Script/stream-v1/stream-v1.css" rel="stylesheet" />
    <script src="../../Script/uploadify/jquery.uploadify.min.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-bufferview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-defaultview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-detailview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="../../Script/easyui/datagrid/datagrid-scrollview.js"></script>
    <script src="../../Script/forms/crm/jquery.forms.partnertaskNew.js"></script>
    <script src="../../Script/stream-v1/stream-v1.js"></script>
    <style type="text/css">
        input[readonly] {
            border: none;
            background: #f0f0f0;
        }

        .item {
            width: 100%;
            height: 500px;
            margin-left: 0px;
            margin-top: 0px;
            border: none;
            float: left;
        }

        .img_wrap {
            border: solid 1px #eee;
            width: 320px;
            height: 130px;
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

    <!--任务管理-->
    <div title="任务管理" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="background: #fff; border: 0px solid #ccc;">
                <table id="datagrid"></table>
            </div>
            <div region="north" border="false" style="text-align: left; overflow: hidden;" id="search_window">
                <div style="padding: 5px;" class="datagrid-toolbar">
                    <form id="search_form">
                        <table>
                            <tr>
                                <td class="lbl-caption">任务编号:</td>
                                <td style="width: 120px">
                                    <input type="text" name="TaskNo" />
                                </td>
                                <td class="lbl-caption">任务类型:</td>
                                <td style="width: 120px">
                                    <input type="text" name="TaskType" style="width: 130px" />
                                </td>
                                <td style="width: 100px; text-align: right;">
                                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!--分派任务-->
    <div id="save_window" class="easyui-window" closed="true" title="客户量尺" data-options="iconCls:'icon-save'" style="width: 800px; height: 500px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="save_form" method="post">
                    <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                        <div>
                            <input type="hidden" id="TaskID" name="TaskID" />
                            <input type="hidden" id="ReferenceID" name="ReferenceID" />
                        </div>
                        <table style="width: 100%; height: 100%; padding: 4px;">
                            <tr>
                                <td class="lbl-caption">任务编号:</td>
                                <td>
                                    <input type="text" id="TaskNo" name="TaskNo" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                                <td class="lbl-caption">任务类型: </td>
                                <td>
                                    <input type="text" id="TaskType" name="TaskType" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">下一步:</td>
                                <td>
                                    <input type="text" id="StepName" name="StepName" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                                <td class="lbl-caption">方案设计师:</td>
                                <td>
                                    <input type="text" style="width: 100%;" id="UserCode" name="UserCode" class="easyui-combogrid" editable="false" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">客户名称：</td>
                                <td>
                                    <input type="text" name="CustomerName" style="width: 100%;" />
                                </td>
                                <td class="lbl-caption">联系人：</td>
                                <td>
                                    <input type="text" name="LinkMan" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">房间数:</td>
                                <td>
                                    <input type="text" id="Rooms" name="Rooms" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                                <td class="lbl-caption">客厅和餐厅数:</td>
                                <td>
                                    <input type="text" id="SittingAndDiningRoom" name="SittingAndDiningRoom" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">房屋面积(平方米):</td>
                                <td>
                                    <input type="text" id="TotalAreal" name="TotalAreal" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                                <td class="lbl-caption">家庭人员: </td>
                                <td>
                                    <input type="text" id="FamilyMembers" name="FamilyMembers" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">预算(万元):</td>
                                <td>
                                    <input type="text" id="Budget" name="Budget" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                                <td class="lbl-caption">量尺日期:</td>
                                <td>
                                    <input type="text" id="Designed" name="Designed" class="easyui-validatebox" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">所住小区名称: </td>
                                <td colspan="4">
                                    <input type="text" id="VillageName" name="VillageName" style="width: 100%;" class="easyui-validatebox" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">栋数（号数）:</td>
                                <td>
                                    <input type="text" id="Building" name="Building" style="width: 100%;" class="easyui-validatebox" />
                                </td>
                                <td class="lbl-caption">所在单元:</td>
                                <td>
                                    <input type="text" id="Unit" name="Unit" style="width: 100%;" class="easyui-validatebox" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">房号:</td>
                                <td>
                                    <input type="text" id="RoomNo" name="RoomNo" style="width: 100%;" class="easyui-validatebox" />
                                </td>
                                <td class="lbl-caption">喜欢颜色:</td>
                                <td>
                                    <input type="text" id="Color" name="Color" style="width: 100%;" class="easyui-validatebox" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">装修风格: </td>
                                <td>
                                    <input type="text" id="Style" name="Style" style="width: 100%;" class="easyui-validatebox" />
                                </td>
                                <td class="lbl-caption">状态:</td>
                                <td>
                                    <input type="text" id="Status" name="Status" style="width: 100%;" class="easyui-validatebox" />
                                </td>
                            </tr>

                            <tr>
                                <td class="lbl-caption">备注: </td>
                                <td colspan="5">
                                    <textarea name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">设计完成</a>
                <a id="btn_edit_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>

    <!--任务步骤明细--->
    <div id="taskstep_window" class="easyui-window" closed="true" title="任务明细" data-options="iconCls:'icon-save'"
        style="width: 850px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="taskdetail"></table>
            </div>
        </div>
    </div>

    <!--创建方案-->
    <div id="save_solution_window" class="easyui-window" closed="true" title="创建方案" data-options="iconCls:'icon-save'" fit="true" minimizable="false" maximizable="false">
        <form id="save_solution_form" method="post" enctype="multipart/form-data" style="height: 100%; width: 100%;">
            <div class="easyui-layout" border="false" fit="true">
                <div region="north" border="false">
                    <div style="text-align: right; padding-right: 50px; padding-top: 5px;">
                        <a id="btn_show_roomdesigner" icon="icon-save" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">查看量尺</a>
                    </div>
                    <div>
                        <input type="hidden" id="SolutionID" name="SolutionID" />
                        <input type="hidden" id="Cabinets" name="Cabinets" />
                        <input type="hidden" name="ReferenceID" />
                        <input type="hidden" name="CustomerID" />
                        <input type="hidden" name="TaskID" />
                        <input type="hidden" name="DesignerID" id="DesignerID" />
                    </div>
                    <table style="width: 100%; overflow: hidden;">
                        <tr>
                            <td class="lbl-caption">方案编号:</td>
                            <td>
                                <input type="text" name="SolutionCode" placeholder="自动编号" class="easyui-validatebox" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption" style="width: 100px;">方案名称:</td>
                            <td>
                                <select id="SolutionName" name="SolutionName" style="width: 200px; height: 25px;" class="easyui-combobox" required="true">
                                    <option>全屋设计</option>
                                    <option>衣柜</option>
                                    <option>厨柜</option>
                                    <option>鞋柜</option>
                                    <option>书柜</option>
                                    <option>酒柜</option>
                                    <option>榻榻米</option>
                                    <option>床</option>
                                    <option>其他</option>
                                </select>
                            </td>
                            <td class="lbl-caption" style="width: 100px;">设计师:</td>
                            <td>
                                <input type="text" name="Designer" style="width: 200px;" readonly="true" value="<%=CurrentUser.UserCode%>" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">订单编号:</td>
                            <td>
                                <input type="text" name="DesignerNo" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption">客户名称:</td>
                            <td colspan="2">
                                <input type="text" style="width: 200px; height: 25px;" name="CustomerName" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">联系电话:</td>
                            <td>
                                <input type="text" name="Mobile" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption">联系人:</td>
                            <td>
                                <input type="text" name="LinkMan" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption">方案状态:</td>
                            <td>
                                <input type="text" name="Status" style="width: 200px;" value="新增方案" placeholder="新增方案" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">客户地址:</td>
                            <td colspan="4">
                                <input type="text" name="Address" style="width: 100%;" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">方案备注:</td>
                            <td colspan="4">
                                <textarea name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
                <div region="center" border="false" style="padding: 0px; overflow: hidden;" title="方案文件">
                    <div class="item">
                        <div>
                            <input type="hidden" id="SolutionFileUrl" name="SolutionFileUrl" />
                            <input type="hidden" id="CabinetID" name="CabinetID" />
                            <div class="img_wrap">
                                <img id="imgSolution" src="/Content/images/solution_bg.png" />
                            </div>
                            <div id="Solution_queue" style="position: absolute; top: 80px; width: 320px; z-index: 999; max-height: 160px;"></div>
                        </div>
                        <div>
                            <input type="file" name="solution_uploadify" id="solution_uploadify" />
                        </div>
                    </div>
                </div>
                <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                    <a id="btn_save_solution" icon="icon-save" style="width: 120px; height: 40px; background: #0094ff; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">提交方案</a>
                    <a id="btn_save_cancel" icon="icon-cancel" style="width: 120px; height: 40px; background: #0094ff; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                </div>
            </div>
        </form>
    </div>

    <!--生成报价合同-->
    <div id="save_quote_window" class="easyui-window" closed="true" title="生成报价合同" data-options="iconCls:'icon-save'" fit="true" minimizable="false" maximizable="false">
        <form id="save_quote_form" method="post" style="width: 100%; height: 100%;">
            <div class="easyui-layout" fit="true">
                <div region="north" border="false" title="报价清单" style="height: 280px; overflow: hidden;">
                    <div style="text-align: right; padding-right: 50px; padding-top: 5px;">
                        <a id="btn_save_quote" icon="icon-save" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">生成报价合同</a>
                        <a id="btn_upload_splitfile" icon="icon-undo" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">重新拆单</a>
                        <%--<a id="btn_cancel_solution" icon="icon-cancel" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">取消方案</a>--%>
                        <a id="cancelQuoteWindow" icon="icon-cancel" style="width: 120px; height: 40px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">返 回</a>
                    </div>
                    <div>
                        <input type="hidden" name="QuoteDetails" />
                        <input type="hidden" name="QuoteID" />
                        <input type="hidden" name="ReferenceID" />
                        <input type="hidden" name="TaskID" />
                        <table>
                            <tr>
                                <td class="lbl-caption">客户名称：</td>
                                <td>
                                    <input type="text" id="Text6" name="CustomerName" style="width: 100%;" readonly="true" />
                                </td>
                                <td class="lbl-caption">联系人：</td>
                                <td>
                                    <input type="text" name="LinkMan" style="width: 100%;" readonly="true" />
                                </td>
                                <td class="lbl-caption">联系电话：</td>
                                <td>
                                    <input type="text" name="Mobile" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">客户地址：</td>
                                <td colspan="3">
                                    <input type="text" name="Address" style="width: 100%;" readonly="true" /></td>
                                <td class="lbl-caption">邮箱：</td>
                                <td>
                                    <input type="text" id="Email" name="Email" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">报价单号：</td>
                                <td>
                                    <input type="text" id="QuoteNo" placeholder="自动生成" style="width: 100%;" maxlength="50" readonly="true" />
                                </td>
                                <td class="lbl-caption">失效日期：</td>
                                <td>
                                    <input type="text" id="ExpiryDate" name="ExpiryDate" style="width: 100%;" class="easyui-datebox" required="true" />
                                </td>
                                <td class="lbl-caption">折扣率：</td>
                                <td>
                                    <input type="text" id="DiscountPercent" name="DiscountPercent" class="easyui-numberbox" data-options="precision:2,min:0.01,max:1.0" style="width: 100%;" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <%--<td class="lbl-caption">总金额：</td>
                                <td>
                                    <input type="text" id="TotalAmount" name="TotalAmount" style="width: 100%;" readonly="true" required="true"/>
                                </td>
                                <td class="lbl-caption">折扣金额：</td>
                                <td>
                                    <input type="text" id="DiscountAmount" name="DiscountAmount" style="width: 100%;" readonly="true" required="true"/>
                                </td>--%>
                            </tr>
                            <tr>
                                <td class="lbl-caption">备注:</td>
                                <td colspan="5">
                                    <textarea id="Textarea2" name="Remark" maxlength="200" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div region="center" border="false">
                    <div class="easyui-tabs" fit="true" border="false" id="tt">
                        <div title="部件用料列表" fit="true" border="false">
                            <table id="dgdetail"></table>
                        </div>
                        <div title="五金用料明细" fit="true" border="false">
                            <table id="dghardware"></table>
                        </div>
                        <div title="移门清单" fit="true" border="false">
                            <table id="dgdoors"></table>
                        </div>
                        <div title="其他费用" fit="true" border="false">
                            <table id="dgothers"></table>
                        </div>
                    </div>
                </div>
                <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                    <%--<a id="btn_edit_save" icon="icon-save" style="width: 150px; height: 40px; background: #0094ff; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">生成报价单</a>--%>
                </div>
            </div>
        </form>
    </div>

    <!--报价确认-->
    <div id="neworder_window" class="easyui-window" closed="true" title="报价确认" data-options="iconCls:'icon-save'" fit="true" minimizable="false" maximizable="false">
        <form id="neworder_form" method="post" enctype="multipart/form-data" style="height: 100%;">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false">
                    <div class="easyui-layout" fit="true" border="false">
                        <div region="north" border="false">
                            <div>
                                <input type="hidden" id="OrderID" name="OrderID" />
                                <input type="hidden" id="SolutionID" name="SolutionID" />
                                <input type="hidden" id="QuoteID" name="QuoteID" />
                                <input type="hidden" id="CustomerID" name="CustomerID" />
                            </div>
                            <div style="width: 100%;">
                                <table style="width: 100%; height: auto; padding: 5px;">
                                    <tr>
                                        <td class="lbl-caption" style="width: 120px;">订单编号: </td>
                                        <td>
                                            <input type="text" id="OrderNo" name="OrderNo" style="width: 195px;" placeholder="自动生成" readonly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption" style="width: 120px;">报价单号:</td>
                                        <td>
                                            <input type="text" id="PurchaseNo" name="PurchaseNo" class="easyui-validatebox" style="width: 195px; background: #f0f0f0;" readonly="true" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="lbl-caption">是否正标: </td>
                                        <td>
                                            <input type="text" id="IsStandard" name="IsStandard" value="true" class="easyui-validatebox" style="width: 195px; background: #f0f0f0;" readonly="true" />
                                        </td>
                                    </tr>--%>
                                    <%--<tr>
                                        <td class="lbl-caption">订单状态:</td>
                                        <td>
                                            <input type="text" id="Status" name="Status" style="width: 195px; background: #f0f0f0;" value="信息待确认" placeholder="信息待确认" readonly="true" />
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="lbl-caption">产品类型:</td>
                                        <td>
                                            <select style="width: 120px; height: 25px;" id="CabinetType" name="CabinetType" class="easyui-combobox" required="true">
                                                <option value="请选择">请选择</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="lbl-caption">是否外购:</td>
                                        <td>
                                            <select id="IsOutsourcing" name="IsOutsourcing" style="width: 120px; height: 25px;" class="easyui-combobox" required="true">
                                                <option value="true">是</option>
                                                <option value="false">否</option>
                                            </select>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="lbl-caption">订单类型: </td>
                                        <td>
                                            <select id="OrderType" name="OrderType" style="width: 120px; height: 25px;" class="easyui-combobox" required="true">
                                                <option value="">请选择</option>
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
                                    <tr>
                                        <td class="lbl-caption">外部单号:</td>
                                        <td>
                                            <input type="text" style="width: 195px; height: 25px;" id="OutOrderNo" name="OutOrderNo" class="easyui-validatebox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">客户预收款(元):</td>
                                        <td>
                                            <input type="text" style="width: 202px; height: 30px;" id="Amount" name="Amount" class="easyui-numberbox" data-options="precision:2" maxlength="50" required="true" />
                                        </td>
                                        <td class="lbl-caption">凭证号:</td>
                                        <td>
                                            <input type="text" style="width: 202px; height: 30px;" id="VoucherNo" maxlength="60" name="VoucherNo" class="easyui-validatebox" required="true" />
                                        </td>
                                        <td class="lbl-caption">收款人:</td>
                                        <td>
                                            <input type="text" style="width: 202px; height: 30px;" id="Payee" maxlength="50" name="Payee" class="easyui-validatebox" required="true" />
                                        </td>
                                        <td class="lbl-caption">收款日期:</td>
                                        <td>
                                            <input type="text" style="width: 202px; height: 30px;" id="TransDate" name="TransDate" class="easyui-datebox" required="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">客户名称:</td>
                                        <td colspan="3">
                                            <input type="text" style="width: 195px; height: 25px;" id="CustomerName" name="CustomerName" readonly="true" />
                                        </td>
                                        <td class="lbl-caption">联系电话: </td>
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
                            <a id="btn_quote_confirm" icon="icon-save" style="width: 100px; height: 30px; background: #ff6a00; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">确认提交</a>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>

    <!--重新上传skp-->
    <div id="upload_solotionfile_window" class="easyui-window" closed="true" fit="true" title="重新上传skp" data-options="iconCls:'icon-save'" minimizable="false" maximizable="false">
        <form id="upload_solotionfile_form" method="post" enctype="multipart/form-data" style="height: 100%; width: 100%;">
            <div class="easyui-layout" fit="true" border="false">
                <div region="north" border="false">
                    <table style="width: 100%; overflow: hidden;">
                        <tr>
                            <td class="lbl-caption">客户名称:</td>
                            <td colspan="3">
                                <input type="text" style="width: 200px; height: 25px;" name="CustomerName" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">联系电话:</td>
                            <td>
                                <input type="text" name="Mobile" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption">联系人:</td>
                            <td>
                                <input type="text" name="LinkMan" style="width: 200px" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">客户地址:</td>
                            <td colspan="4">
                                <input type="text" name="Address" style="width: 100%;" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">方案备注:</td>
                            <td colspan="4">
                                <textarea name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
                <div region="center" border="false" style="padding: 0px; overflow: hidden;" title="方案文件">
                    <input type="hidden" name="FileUrl" />
                    <input type="hidden" name="TaskID" />
                    <div class="item">
                        <div class="img_wrap">
                            <img id="imgsolution" src="/Content/images/solution_bg.png" />
                        </div>
                        <div style="position: absolute; top: 80px; width: 320px; z-index: 999; max-height: 160px;"></div>
                        <input type="file" name="solotionfile" id="solotionfile" />
                    </div>
                </div>
                <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                    <%-- <a id="btn_cancel_uploadfile" icon="icon-cancel" style="width: 120px; height: 40px; background: #0094ff; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">取消</a>--%>
                </div>
            </div>
        </form>
    </div>

    <!--设计师重新上传方案文件-->
    <div id="undo_solotionfile_window" class="easyui-window" closed="true" fit="true" minimizable="false" maximizable="false" title="重新上传方案文件" data-options="iconCls:'icon-save'">
        <form id="undo_solotionfile_form" method="post" enctype="multipart/form-data" style="height: 100%; width: 100%;">
            <div class="easyui-layout" fit="true" border="false">
                <div region="north" border="false">
                    <table style="width: 100%; overflow: hidden;">
                        <tr>
                            <td class="lbl-caption">客户名称:</td>
                            <td colspan="3">
                                <input type="text" style="width: 200px; height: 25px;" name="CustomerName" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">联系电话:</td>
                            <td>
                                <input type="text" name="Mobile" style="width: 200px;" readonly="true" />
                            </td>
                            <td class="lbl-caption">联系人:</td>
                            <td>
                                <input type="text" name="LinkMan" style="width: 200px" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">客户地址:</td>
                            <td colspan="4">
                                <input type="text" name="Address" style="width: 100%;" readonly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">方案备注:</td>
                            <td colspan="4">
                                <textarea name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
                <div region="center" border="false" style="padding: 0px; overflow: hidden;" title="方案文件">
                    <input type="hidden" name="FileUrl" />
                    <input type="hidden" name="TaskID" />
                    <input type="hidden" name="ReferenceID" />
                    <div class="item">
                        <div>
                            <div class="img_wrap">
                                <img id="imgundosolution" src="/Content/images/solution_bg.png" />
                            </div>
                            <div id="File_queue" style="position: absolute; top: 80px; width: 320px; z-index: 999; max-height: 160px;"></div>
                        </div>
                        <div>
                            <input type="file" name="undosolotionfile" id="undosolotionfile" />
                        </div>
                    </div>
                </div>
                <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                    <%-- <a id="btn_cancel_uploadfile" icon="icon-cancel" style="width: 120px; height: 40px; background: #0094ff; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">取消</a>--%>
                </div>
            </div>
        </form>
    </div>

    <!--上传拆单文件-->
    <div id="upload_splitfile_window" class="easyui-window" closed="true" title="上传拆单文件" data-options="iconCls:'icon-save'" fit="true" style="background: #fff;" minimizable="false" maximizable="false">
        <form id="upload_splitfile_form" method="post" enctype="multipart/form-data" style="height: 100%; width: 100%;">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;" title="订单文件">
                    <div class="item">
                        <div id="i_splitselect_files"></div>
                        <div id="i_splitstream_files_queue"></div>
                        <div id="i_splitstream_message_container" class="stream-main-upload-box" style="overflow: auto; height: 200px; display: none;"></div>
                    </div>
                    <input type="hidden" name="TaskID" />
                    <input type="hidden" name="DesignID" />
                </div>
                <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px; display: none;">
                    <a id="btn_order_save" icon="icon-save" style="width: 100px; height: 30px;" class="easyui-linkbutton" href="javascript:void(0)">保存订单</a>
                    <a id="btn_cancelorder" icon="icon-clear" style="width: 100px; height: 30px;" class="easyui-linkbutton" href="javascript:window.location.reload();">取消上传</a>
                </div>
            </div>
            <div id="Loding_window" class="easyui-window" closed="true" title="系统提示" data-options="iconCls:'cog'"
                style="width: 400px; height: 300px; background: #fff; display: none;" minimizable="false" maximizable="false" closable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 33px;">
                                    <img src="/Content/images/ui-loading-pink-32x32.gif" />
                                </td>
                                <td style="width: 100%;">
                                    <span>正在导入数据，请稍候...</span>
                                    <p>
                                        <span class="runtime">已经运行：00:00:00</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </form>
    </div>

    <!--任务被分配者-->
    <div id="tb" style="padding: 5px; height: auto">
        <form id="search_form_partneruser">
            <table>
                <tr>
                    <td class="lbl-caption">帐号:</td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" name="UserCode" type="text" />
                    </td>
                    <td class="lbl-caption">姓名: </td>
                    <td style="text-align: left">
                        <input type="text" name="UserName" />
                    </td>
                    <td colspan="2" style="text-align: left">
                        <a href="javascript:void(0)" id="btn_search_partneruser" class="easyui-linkbutton" icon="icon-search" style="width: 80px;">搜索</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>


    <!--上传拆单文件配置-->

    <script>
        var config = {
            browseFileId: "i_splitselect_files", /** 选择文件的ID, 默认: i_select_files */
            browseFileBtn: "<div>请选择文件</div>", /** 显示选择文件的样式, 默认: `<div>请选择文件</div>` */
            dragAndDropArea: "i_splitselect_files", /** 拖拽上传区域，Id（字符类型"i_select_files"）或者DOM对象, 默认: `i_select_files` */
            dragAndDropTips: "<span>把文件拖拽(点击)到这里</span>", /** 拖拽提示, 默认: `<span>把文件(文件夹)拖拽到这里</span>` */
            filesQueueId: "i_splitstream_files_queue", /** 文件上传容器的ID, 默认: i_stream_files_queue */
            filesQueueHeight: 200, /** 文件上传容器的高度（px）, 默认: 450 */
            messagerId: "i_splitstream_message_container", /** 消息显示容器的ID, 默认: i_stream_message_container */
            multipleFiles: true, /** 多个文件一起上传, 默认: false */
            autoUploading: true, /** 选择文件后是否自动上传, 默认: true */
            autoRemoveCompleted: false, /** 是否自动删除容器中已上传完毕的文件, 默认: false */
            maxSize: 104857600,//, /** 单个文件的最大大小，默认:2G */
            //		retryCount : 5, /** HTML5上传失败的重试次数 */
            //		postVarsPerFile : { /** 上传文件时传入的参数，默认: {} */
            //			param1: "val1",
            //			param2: "val2"
            //		},
            //swfURL : "swf/FlashUploader.swf", /** SWF文件的位置 */
            tokenURL: "/ashx/StreamUploadHandler.ashx?Method=tk", /** 根据文件名、大小等信息获取Token的URI（用于生成断点续传、跨域的令牌） */
            //frmUploadURL: "FileUpload.ashx?Method=fd;", /** Flash上传的URI */
            uploadURL: "/ashx/StreamUploadHandler.ashx?Method=upload", /** HTML5上传的URI */
            simLimit: 20, /** 单次最大上传文件个数 */
            //extFilters: [".zip", ".rar"], /** 允许的文件扩展名, 默认: [] */
            onSelect: function (list) {
                //console.log(JSON.stringify(list));
            }, /** 选择文件后的响应事件 */
            onMaxSizeExceed: function (size, limited, name) { showError('文件大小超出限制！'); }, /** 文件大小超出的响应事件 */
            onFileCountExceed: function (selected, limit) { showError('文件数量超出(' + limit + '个)限制！'); }, /** 文件数量超出的响应事件 */
            //onExtNameMismatch: function (name, filters) {alert(name + filters);}, /** 文件的扩展名不匹配的响应事件 */
            // onCancel: function (file) {alert('Canceled:  ' + file.name)}, /** 取消上传文件的响应事件 */
            onComplete: function (file) {
                //console.log(JSON.stringify(file));
                var obj = JSON.parse(file.msg);
                if (obj.success) {
                    console.log(decodeURIComponent(obj.filePath));
                    var model = {
                        id: file.id,
                        filePath: obj.filePath,
                    }
                    ArrayPath.push(model);
                }

            }, /** 单个文件上传完毕的响应事件 */
            onQueueComplete: function () {
                //console.log("ArrayPath=" + JSON.stringify(ArrayPath));
                //OrderImportForm.events.SaveOrder();
            }, /** 所以文件上传完毕的响应事件 */
            onUploadError: function (status, msg) {
                alert('onUploadError' + status + ":" + msg);
            } /** 文件上传出错的响应事件 */
        };
        var _t = new Stream(config);
    </script>
    <%--<script src="/Script/javascripts/forms/orders/jquery.forms.orders_import.js?ver=1.61"></script>--%>
</asp:Content>
