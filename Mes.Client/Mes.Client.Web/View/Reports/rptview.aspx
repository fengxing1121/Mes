<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptview.aspx.cs" Inherits="Mes.Client.Web.View.Reports.rptview" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset='UTF-8'>
    <title>统计报表</title>
    <link href="/Script/easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="/Script/easyui/themes/icon.css" rel="stylesheet" />
    <link href="/Script/easyui/themes/color.css" rel="stylesheet" />
    <link href="/Script/easyui/themes/default.css" rel="stylesheet" />
    <link href="/Content/css/ext_icons.css" rel="stylesheet" />
    <script src="/Script/easyui/jquery.min.js"></script>
    <script src="/Script/easyui/jquery.easyui.min.js"></script>
    <script src="/Script/easyui/easyloader.js"></script>
    <script src='http://www.ichartjs.com/ichart.latest.min.js'></script>
    <script src="../../Script/easyui/jquery.easyui.common.js"></script>
    <script src="../../Script/common/jquery.forms.common.js"></script>
    <script type='text/javascript'>
        (function ($) {
            var reportView = {
                init: function () {
                    reportView.reports.rpt_customer();
                },
                reports: {
                    rpt_customer: function () {
                        var chart = iChart.create({
                            render: "ichart-render",
                            width: 800,
                            height: 400,
                            background_color: "#fdfdfd",
                            gradient: false,
                            color_factor: 0.2,
                            border: {
                                color: "#3e1c3e",
                                width: 1
                            },
                            align: "center",
                            offsetx: 0,
                            offsety: -10,
                            sub_option: {
                                border: {
                                    color: "#666791",
                                    width: 1
                                },
                                label: {
                                    fontweight: 600,
                                    fontsize: 11,
                                    color: "#4572a7",
                                    sign: "square",
                                    sign_size: 12,
                                    border: {
                                        color: "#BCBCBC",
                                        width: 1
                                    },
                                    background_color: "#fefefe"
                                }
                            },
                            shadow: true,
                            shadow_color: "#666666",
                            shadow_blur: 5,
                            showpercent: false,
                            column_width: "70%",
                            bar_height: "70%",
                            radius: "90%",
                            title: {
                                text: "2016年上半年客户发展统计",
                                color: "#3e576f",
                                fontsize: 26,
                                font: "微软雅黑",
                                textAlign: "center",
                                height: 30,
                                offsetx: 0,
                                offsety: 0
                            },
                            subtitle: {
                                text: "",
                                color: "#3e576f",
                                fontsize: 16,
                                font: "微软雅黑",
                                textAlign: "center",
                                height: 24,
                                offsetx: 0,
                                offsety: 0
                            },
                            //footnote: {
                            //    text: "模拟数据",
                            //    color: "#c0c0c0",
                            //    fontsize: 12,
                            //    font: "微软雅黑",
                            //    textAlign: "right",
                            //    height: 20,
                            //    offsetx: 0,
                            //    offsety: 0
                            //},
                            legend: {
                                enable: false,
                                background_color: "#fefefe",
                                color: "#333333",
                                fontsize: 12,
                                border: {
                                    color: "#BCBCBC",
                                    width: 1
                                },
                                column: 1,
                                align: "right",
                                valign: "center",
                                offsetx: 0,
                                offsety: 0
                            },
                            coordinate: {
                                width: "88%",
                                height: "80%",
                                background_color: "rgba(246,246,246,0.1)",
                                axis: {
                                    color: "#666791",
                                    width: ["", "", 2, ""]
                                },
                                grid_color: "#c0c0c0",
                                label: {
                                    fontweight: 500,
                                    color: "#666666",
                                    fontsize: 11
                                }
                            },
                            label: {
                                fontweight: 600,
                                color: "#666666",
                                fontsize: 11
                            },
                            type: "column2d",
                            data: [
                                  {
                                      name: "一月",
                                      value: 220,
                                      color: "rgba(130,127,191,0.80)"
                                  }, {
                                      name: "二月",
                                      value: 240,
                                      color: "rgba(228,190,77,0.80)"
                                  }, {
                                      name: "三月",
                                      value: 305,
                                      color: "rgba(145,170,81,0.80)"
                                  }, {
                                      name: "四月",
                                      value: 423,
                                      color: "rgba(161,69,69,0.80)"
                                  }, {
                                      name: "五月",
                                      value: 462,
                                      color: "rgba(151,69,39,0.80)"
                                  }, {
                                      name: "六月",
                                      value: 526,
                                      color: "rgba(193,169,101,0.80)"
                                  }
                            ]
                        });
                        chart.draw();
                    },
                    rpt_orders: function () {
                        $(function () {
                            var data = [
                                        { name: '广东', value: 40.0, color: '#4572a7' },
                                        { name: '北京', value: 37.1, color: '#aa4643' },
                                        { name: '上海', value: 13.8, color: '#89a54e' },
                                        { name: '深圳', value: 1.6, color: '#80699b' },
                                        { name: '湖南', value: 1.4, color: '#92a8cd' },
                                        { name: '四川', value: 1.2, color: '#db843d' },
                                        { name: '其他', value: 4.9, color: '#a47d7c' }
                            ];
                            new iChart.Pie2D({
                                render: 'ichart-render',
                                data: data,
                                title: '2016年10月份客户订单分布',
                                legend: {
                                    enable: true
                                },
                                sub_option: {
                                    label: {
                                        background_color: null,
                                        sign: false,//设置禁用label的小图标
                                        padding: '0 4',
                                        border: {
                                            enable: false,
                                            color: '#666666'
                                        },
                                        fontsize: 11,
                                        fontweight: 600,
                                        color: '#4572a7'
                                    },
                                    border: {
                                        width: 2,
                                        color: '#ffffff'
                                    }
                                },
                                animation: true,
                                showpercent: true,
                                decimalsnum: 2,
                                width: 500,
                                height: 300,
                                radius: 140
                            }).draw();
                        });
                    },                   
                    rpt_sales: function () {
                        var flow = [];
                        for (var i = 0; i < 31; i++) {
                            flow.push(Math.floor(Math.random() * 1000));
                        }

                        var data = [
                                    {
                                        name: 'Qty',
                                        value: flow,
                                        color: '#ec4646',
                                        line_width: 2
                                    }
                        ];

                        var labels = ["00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"];

                        var chart = new iChart.LineBasic2D({
                            render: 'ichart-render',
                            data: data,
                            align: 'center',
                            title: {
                                text: '2016年10月销售订单统计',
                                font: '微软雅黑',
                                fontsize: 24,
                                color: '#b4b4b4'
                            },
                            subtitle: {
                                text: '销售量达到最大',
                                font: '微软雅黑',
                                color: '#b4b4b4'
                            },
                            //footnote: {
                            //    text: '美屋智能科技(aimeiwu.com)',
                            //    font: '微软雅黑',
                            //    fontsize: 11,
                            //    fontweight: 600,
                            //    padding: '0 28',
                            //    color: '#b4b4b4'
                            //},
                            width: 500,
                            height: 300,
                            shadow: true,
                            shadow_color: '#202020',
                            shadow_blur: 8,
                            shadow_offsetx: 0,
                            shadow_offsety: 0,
                            background_color: '#2e2e2e',
                            tip: {
                                enable: true,
                                shadow: true,
                                listeners: {
                                    //tip:提示框对象、name:数据名称、value:数据值、text:当前文本、i:数据点的索引
                                    parseText: function (tip, name, value, text, i) {
                                        return "<span style='color:#005268;font-size:12px;'>2016年10月" + labels[i] + "日成交订单:<br/>" +
                                        "</span><span style='color:#005268;font-size:20px;'>" + value + "个</span>";
                                    }
                                }
                            },
                            crosshair: {
                                enable: true,
                                line_color: '#ec4646'
                            },
                            sub_option: {
                                smooth: true,
                                label: false,
                                hollow: false,
                                hollow_inside: false,
                                point_size: 8
                            },
                            coordinate: {
                                width: 640,
                                height: 260,
                                striped_factor: 0.18,
                                grid_color: '#4e4e4e',
                                axis: {
                                    color: '#252525',
                                    width: [0, 0, 4, 4]
                                },
                                scale: [{
                                    position: 'left',
                                    start_scale: 0,
                                    end_scale: 1000,
                                    scale_space: 100,
                                    scale_size: 2,
                                    scale_enable: false,
                                    label: { color: '#9d987a', font: '微软雅黑', fontsize: 11, fontweight: 600 },
                                    scale_color: '#9f9f9f'
                                }, {
                                    position: 'bottom',
                                    label: { color: '#9d987a', font: '微软雅黑', fontsize: 11, fontweight: 600 },
                                    scale_enable: false,
                                    labels: labels
                                }]
                            }
                        });
                        //利用自定义组件构造左侧说明文本
                        chart.plugin(new iChart.Custom({
                            drawFn: function () {
                                //计算位置
                                var coo = chart.getCoordinate(),
                                    x = coo.get('originx'),
                                    y = coo.get('originy'),
                                    w = coo.width,
                                    h = coo.height;
                                //在左上侧的位置，渲染一个单位的文字
                                chart.target.textAlign('start')
                                .textBaseline('bottom')
                                .textFont('600 11px 微软雅黑')
                                .fillText('订单量(个)', x - 40, y - 12, false, '#9d987a')
                                .textBaseline('top')
                                .fillText('(日期)', x + w + 12, y + h + 10, false, '#9d987a');

                            }
                        }));
                        //开始画图
                        chart.draw();
                    }
                }
            };

            $(function () {
                //reportView.init();
                var rptname = getUrlParam('Method');
                switch (rptname) {
                    case 'order':
                        reportView.reports.rpt_orders();
                        break;
                    case 'customer':
                        reportView.reports.rpt_customer();
                        break;
                    case 'madeprocess':
                        reportView.reports.rpt_madeprocess();
                        break;
                    case 'sales':
                        reportView.reports.rpt_sales();
                        break;
                    default:
                        reportView.init();
                        break;
                }

            });
        })(jQuery);
    </script>
</head>
<body style='background-color: #fff;'>
    <div id='ichart-render'></div>
</body>
</html>
