<%@ Page Title="新增产品" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newproduct.aspx.cs" Inherits="Mes.Client.Web.View.Product.newproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Script/uploadify/uploadify.css" rel="stylesheet" />
    <script src="../../Script/uploadify/jquery.uploadify.min.js"></script>
    <script src="/Script/forms/products/jquery.forms.newproduct.js" lang="zh-cn"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" border="false" fit="true">
        <div region="center" border="false">
            <form id="edit_form" method="post" style="width: 100%; height: 100%;">
                <div class="easyui-layout" border="false" fit="true">
                    <div region="north" border="false" iconcls="icon table_add" collapsible="true" title="新增产品资料" style="overflow: hidden; height: 350px;">
                        <div>
                            <table style="margin: 0px;">
                                <tr>
                                    <td style="width: 350px;">
                                        <div class="item">
                                            <input id="btnProductImg_Upload" type="file" />
                                            <input type="hidden" id="HeadImgUrl" name="HeadImgUrl" />
                                            <div class="img_wrap">
                                                <img id="imgMain" src="/Content/images/up_bg.png" />
                                            </div>
                                            <div id="HeadImg_queue" name="HeadImg_queue" style="position:absolute;top:80px;width:325px;z-index:999;max-height:240px;"></div>
                                        </div>
                                    </td>
                                    <td style="width: 100% auto; text-align: left;">
                                        <table style="width: 100%;" >
                                            <tr>
                                                <td colspan="2">
                                                    <input type="hidden" id="ProductID" name="ProductID" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">产品类型:
                                                </td>
                                                <td>
                                                    <input id="CategoryID" name="CategoryID" class="easyui-combobox" required="true" style="width: 200px; height: 25px;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">产品编号:
                                                </td>
                                                <td>
                                                    <input type="text" id="ProductCode" name="ProductCode" class="easyui-validatebox" style="width: 200px;" required="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">产品名称:
                                                </td>
                                                <td>
                                                    <input type="text" id="ProductName" name="ProductName" class="easyui-validatebox" style="width: 200px;" required="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">型号/款式:
                                                </td>
                                                <td>
                                                    <input type="text" id="MaterialStyle" name="MaterialStyle" class="easyui-validatebox" style="width: 200px;" required="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">材质:
                                                </td>
                                                <td>
                                                    <input type="text" id="MaterialCategory" name="MaterialCategory" class="easyui-validatebox" style="width: 200px;" required="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">颜色:
                                                </td>
                                                <td>
                                                    <input type="text" id="Color" name="Color" class="easyui-validatebox" style="width: 200px;" required="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">尺寸:
                                                </td>
                                                <td>
                                                    <input type="text" id="Size" name="Size" class="easyui-validatebox" style="width: 200px;" required="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">市场价:
                                                </td>
                                                <td>
                                                    <input type="text" id="Price" name="Price" class="easyui-validatebox" style="width: 200px;" required="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">设计师:
                                                </td>
                                                <td>
<%--                                                    <input type="text" id="Designer" name="Designer" class="easyui-validatebox" style="width: 200px;" readonly="true" value="<%=CurrentUser.UserCode+"."+CurrentUser.UserName %>" />--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div region="center" border="false" iconcls="icon table_add" collapsible="false" title="上传产品资料文件">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <div class="item">
                                        <input type="file" name="BOM_uploadify" id="BOM_uploadify" />
                                        <input type="hidden" id="BOMFileUrl" name="BOMFileUrl" />
                                        <div class="img_wrap">
                                            <img id="imgBOM" src="/Content/images/up_bombg.png" />
                                        </div>
                                        <div id="BOM_queue" name="BOM_queue" style="position:absolute;top:80px;width:325px;z-index:999;max-height:240px;"></div>
                                    </div>
                                    <div class="item">
                                        <input type="file" name="Hardware_uploadify" id="Hardware_uploadify" />
                                        <input type="hidden" id="HardwareFileUrl" name="HardwareFileUrl" />
                                        <div class="img_wrap">
                                            <img id="imgHardware" src="/Content/images/up_hardwarebg.png" />
                                        </div>
                                        <div id="Hardware_queue" name="Hardware_queue" style="position:absolute;top:80px;width:325px;z-index:999;max-height:240px;"></div>
                                    </div>
                                    <div class="item">
                                        <input type="file" name="Drawing_uploadify" id="Drawing_uploadify" />
                                        <input type="hidden" id="DrawingFileUrl" name="DrawingFileUrl" />
                                        <div class="img_wrap">
                                            <img id="imgDrawing" src="/Content/images/up_drawingbg.png" />
                                        </div>
                                        <div id="Drawing_queue" name="Drawing_queue" style="position:absolute;top:80px;width:325px;z-index:999;max-height:240px;"></div>
                                    </div>
                                    <div class="item">
                                        <input type="file" name="CNC_uploadify" id="CNC_uploadify" />
                                        <input type="hidden" id="CNCFileUrl" name="CNCFileUrl" />
                                        <div class="img_wrap">
                                            <img id="imgCNC" src="/Content/images/up_cncbg.png" />
                                        </div>
                                        <div id="cnc_queue" style="position:absolute;top:80px;width:325px;z-index:999;max-height:240px;"></div>
                                    </div>
                                    <div class="item">
                                        <input type="file" name="Rendering_uploadify" id="Rendering_uploadify" />                                        
                                        <input type="hidden" id="RenderingFileUrl" name="ProcessFileUrl" />
                                        <div class="img_wrap">
                                            <img id="imgRendering" src="/Content/images/up_imgbg.png" />
                                        </div>
                                        <div id="Rendering_queue" style="position:absolute;top:80px;width:325px;z-index:999;max-height:240px;"></div>
                                    </div>
                                    <div style="clear: both;"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div region="south" style="height: 60px; text-align: center;" collapsible="false">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <a href="javascript:void(0)" id="btn_submit" icon="icon-save" class="easyui-linkbutton" style="width: 120px; height: 35px;">确认提交</a>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
            </form>
        </div>
    </div>
    <div id="submit_window" class="easyui-window" closed="true" title="正在提交数据，请稍候..." data-options="iconCls:'application'"
        style="width: 300px; height: 200px; background: #fff;" minimizable="false" maximizable="false" closable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td style="width: 33px;">
                            <img src="/Content/images/ui-loading-pink-32x32.gif" />
                        </td>
                        <td style="width: 100%;">
                            <span>正在提交数据，请稍候...</span>
                            <p>
                                <span class="runtime">已经运行：</span>
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
</asp:Content>
