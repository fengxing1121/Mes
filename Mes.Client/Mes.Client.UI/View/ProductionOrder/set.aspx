<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="set.aspx.cs" Inherits="Mes.Client.UI.View.ProductionOrder.set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/Content/css/calendar/calendarAll.css?ver=1.213" rel="stylesheet" type="text/css"/>
    <link href="/Content/css/calendar/skin.css?ver=1.2" rel="stylesheet" type="text/css"/>
    <link href="/Content/css/calendar/fontSize12.css?ver=1.22" rel="stylesheet" type="text/css"/>
    <link href="/Content/css/calendar/calendar.css" rel="stylesheet" type="text/css"/>

    <script src="/Script/easyui/jquery.min.js"></script>
    <script src="/Script/forms/ProductionOrder/jquery.forms.calendar.js?ver=1.187"></script>
</head>
<body>
<div class="main">
            <table class="biao" style="table-layout:fixed;width:80%;">
            <tbody>
            <tr>
                <td class="calTit" colSpan=7 style="height:30px;padding-top:3px;text-align:center;">
                    <a href="#" title="上一年" id="nianjian" class="ymNaviBtn lsArrow"></a>
                    <a href="#" title="上一月" id="yuejian" class="ymNaviBtn lArrow"></a>
                    <div style="width:250px; float:left; padding-left:40%;">
                        <span id="dateSelectionRili" class="dateSelectionRili" style="cursor:hand;color: white; border-bottom: 1px solid white;"  onclick="dateSelection.show()">
						<span id="nian" class="topDateFont"></span><span class="topDateFont">年</span><span id="yue"  class="topDateFont"></span><span  class="topDateFont">月</span>
						<span class="dateSelectionBtn cal_next"  onclick="dateSelection.show()">▼</span></span> &nbsp;&nbsp;<font id=GZ class="topDateFont"></font>
                    </div>
                    <div style="left: 45%; display: none;top:35px;" id="dateSelectionDiv">
                        <div id="dateSelectionHeader"></div>
                        <div id="dateSelectionBody">
                            <div id="yearList">
                                <div id="yearListPrev" onclick="dateSelection.prevYearPage()">&lt;</div>
                                <div id="yearListContent"></div>
                                <div id="yearListNext" onclick="dateSelection.nextYearPage()">&gt;</div>
                            </div>
                            <div id="dateSeparator"></div>
                            <div id="monthList">
                                <div id="monthListContent">
                                        <span id="SM0" class="month"  onclick="dateSelection.setMonth(0)">1</span>
                                        <span id="SM1" class="month" onclick="dateSelection.setMonth(1)">2</span>
                                        <span id="SM2" class="month" onclick="dateSelection.setMonth(2)">3</span>
                                        <span id="SM3" class="month" onclick="dateSelection.setMonth(3)">4</span>
                                        <span id="SM4" class="month" onclick="dateSelection.setMonth(4)">5</span>
                                        <span id="SM5" class="month" onclick="dateSelection.setMonth(5)">6</span>
                                        <span id="SM6" class="month" onclick="dateSelection.setMonth(6)">7</span>
                                        <span id="SM7" class="month" onclick="dateSelection.setMonth(7)">8</span>
                                        <span id="SM8" class="month" onclick="dateSelection.setMonth(8)">9</span>
                                        <span id="SM9" class="month" onclick="dateSelection.setMonth(9)">10</span>
                                        <span id="SM10" class="month" onclick="dateSelection.setMonth(10)">11</span>
                                        <span id="SM11" class="month" onclick="dateSelection.setMonth(11)">12</span>
                                </div>
                                <div style="clear: both;"></div>
                            </div>
                            <div id="dateSelectionBtn">
                                <div id="dateSelectionTodayBtn" onclick="dateSelection.goToday()">今天</div>
                                <div id="dateSelectionOkBtn" onclick="dateSelection.go()">确定</div>
                                <div id="dateSelectionCancelBtn" onclick="dateSelection.hide()">取消</div>
                            </div>
                        </div>
                        <div id="dateSelectionFooter"></div>
                    </div>
                    <a href="#" id="nianjia" title="下一年" class="ymNaviBtn rsArrow" style="float:right;"></a>
                    <a href="#" id="yuejia" title="下一月" class="ymNaviBtn rArrow" style="float:right;"></a>
                </td>
            </tr>
            <tr class="calWeekTit" style="font-size:12px; height:20px;text-align:center;">
                <td style="width:100px" class="red">星期日</td>
                <td style="width:100px">星期一</td>
                <td style="width:100px">星期二</td>
                <td style="width:100px">星期三</td>
                <td style="width:100px">星期四</td>
                <td style="width:100px">星期五</td>
                <td style="width:100px" class="red">星期六</td>
            </tr>
            <script type="text/javascript">
                var gNum;
                for (var i = 0; i < 6; i++) {
                    document.write('<tr style="table-layout:fixed" align=center height="50">');
                    for (var j = 0; j < 7; j++) {
                        gNum = i * 7 + j ;
                        document.write('<td  id="GD' + gNum + '" on="0" ><font id="SD' + gNum + '" style="font-size:22px;"  face="Arial"');
                        if (j == 0) {
                            document.write('color=red');
                        }
                        if (j == 6)
                        {
                            document.write('color=red');
                        }
                        document.write('></font><br><font  id="LD' + gNum + '"  size=2  style="white-space:nowrap;overflow:hidden;cursor:default;">  </font></td>');
                    }
                    document.write('</tr>');
                }
                </script>
            </tbody>
        </table>
        <table class="biao" width="80%" style="margin-top: 10px;">
        <tr>
            <td>
                <table width="100%" border="0">
                    <tr>
                    <td rowspan="2" style="border:0px;width:40%;">&nbsp;&nbsp;&nbsp;销售预测月总量设置（㎡）
                        <input  type="number" style="width:150px;" id="txttotalareal" placeholder="请填写总量"/>
                        <input  type="button" id="btnOk" value="计算"/>
                    </td>
                    <td style="border:0px;color:#B7B7B7;"  class="totalarealInfo">您的本月排班中总共有<span style="color:red;font-weight:bolder;">0周</span>，合计有<span style="color:red;font-weight:bolder;">0个工作日</span>，请合理填写月销售总量</td>
                    </tr>
                    <tr>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td colspan="2" style="border:0px;"><p class="setholiday"></p></td>
                    </tr>
                </table>
            </td>
        </tr>    
            <tr style="display:none;" class="trweek">
            <td>
                <table width="100%" border="0">
                    <tr>
                    <td rowspan="2" style="border:0px;width:40%;">第一周排产量比例设置（%）
<%--                            <input type="range" id="range1" value="0"  oninput="OnInput(event)" step="0.01"  style="width:150px;"/>
                        <span>0%</span>--%>
                        <input type="number" style="width:150px;" step="0.01"/>
                    </td>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td colspan="2" style="border:0px;"><p class="setholiday"></p></td>
                    </tr>
                </table>
            </td>
        </tr>       

        <tr style="display:none;" class="trweek">
            <td>
                <table width="100%" border="0">
                    <tr>
                    <td rowspan="2" style="border:0px;width:40%;">第二周排产量比例设置（%）
                        <input type="number" style="width:150px;" step="0.01"/>
                    </td>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td colspan="2" style="border:0px;"><p class="setholiday"></p></td>
                    </tr>
                </table>
            </td>
        </tr>
            <tr style="display:none;"  class="trweek">
                <td>
                    <table width="100%" border="0">
                    <tr>
                    <td rowspan="2" style="border:0px;width:40%;">第三周排产量比例设置（%）
                        <input type="number" style="width:150px;" step="0.01"/>
                    </td>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td colspan="2" style="border:0px;"><p class="setholiday"></p></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr style="display:none;"  class="trweek">
                <td>
                    <table width="100%" border="0">
                    <tr>
                    <td rowspan="2" style="border:0px;width:40%;">第四周排产量比例设置（%）
                        <input type="number" style="width:150px;" step="0.01"/>
                    </td>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td colspan="2" style="border:0px;"><p class="setholiday"></p></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr style="display:none;"  class="trweek">
                <td>
                    <table width="100%" border="0">
                    <tr>
                    <td rowspan="2" style="border:0px;width:40%;">第五周排产量比例设置（%）
                        <input type="number" style="width:150px;" step="0.01"/>
                    </td>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td colspan="2" style="border:0px;"><p class="setholiday"></p></td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr style="display:none;"  class="trweek">
                <td>
                    <table width="100%" border="0">
                    <tr>
                    <td rowspan="2" style="border:0px;width:40%;">第六周排产量比例设置（%）
                        <input type="number" style="width:150px;" step="0.01"/>
                    </td>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td style="border:0px;color:#B7B7B7;"></td>
                    </tr>
                    <tr>
                    <td colspan="2" style="border:0px;"><p class="setholiday"></p></td>
                    </tr>
                </table>
                </td>
            </tr>
        </table>
        <table  border="1"  cellpadding="5" cellspacing="5" style="margin-top: 10px;width: 80%;height: 30px">
            <tr align="center" style="margin-top: 5px;">
                <td width="80"><input type="button" value='提交' class="button6" id="btnsubmit"></td>
                <td width="80"><input type="button" value="重置" class="button6"  id="btnreset"></td>
                </tr>
        </table>
</div>
<script src="/Script/forms/ProductionOrder/jquery.forms.set.js?ver=1.23"></script>
</body>
</html>
