//全局参数
var m_canvas = null;

var m_nHoleID = 0;  //孔位ID
var m_nLineID = 0;  //线ID
var m_nArcID = 0;  //弧ID
var m_nRectID = 0;  //矩形ID
var m_nBlockID = 0;  //块ID

//颜色
var RGB_BLACK = "black";
var RGB_WHITE = "white";
var RGB_RED = "red";
var RGB_NORMAL = ("black");  //正常颜色
var RGB_SELECT = ("green");  //选中颜色
var RGB_UNENABLE = ("red");  //禁用颜色

//镜像
var MIRROR_NONE = 0;  //无镜像
var MIRROR_X = 1;  //X镜像
var MIRROR_Y = 2;  //Y镜像
var MIRROR_XY = 3;  //XY镜像

//加载完毕
$(document).ready(function () {
    //初始化全局参数
    m_canvas = document.getElementById("panel_canvas");  //画板，DOM对象

    $("#BtnSearch").on("click", function () {
        //解析mpr数据
        var str = $("#txtContext").val();
        if (str != "") {
            var panel = toPanel(str);
            panel = calcautePanelEntity(panel);

            showPanel(panel);
        };
    });
});

/**
 * 功能：显示面板
 * 参数：
 *  @panel，面板对象
 */
function showPanel(panel) {
    //每次显示前将之前的画布清空
    var context = m_canvas.getContext("2d");

    //擦除之前的内容
    m_canvas.width = m_canvas.width;
    m_canvas.height = m_canvas.height;

    //计算比例
    var PANEL_OFFSET = 20;
    var XYZ_OFFSET = 10;
    var XYZ_LENGTH = 100;
    var XYZ_POINTER_OFFSET = 8;  //键头偏移
    var KNIFE_HEAD = 0.9;  //刀头

    var zoomX = panel.length / (m_canvas.width - 2 * PANEL_OFFSET);
    var zoomY = panel.width / (m_canvas.height - 2 * PANEL_OFFSET);
    var zoom = zoomX > zoomY ? zoomX : zoomY;  //取最大的显示比

    //开始绘制点
    var sX = (m_canvas.width - panel.length / zoom) / 2;
    var sY = (m_canvas.height - panel.width / zoom) / 2;

    context.stroke();
    //绘制原点
    //X
    line(10, m_canvas.height - 10, 100, m_canvas.height - 10, RGB_BLACK);
    line(90, m_canvas.height - 18, 100, m_canvas.height - 10, RGB_BLACK);
    line(90, m_canvas.height - 2, 100, m_canvas.height - 10, RGB_BLACK);
    context.font = "bold 15px Arial";
    context.fillText("x+", 110, m_canvas.height - 7);
    context.fillText(panel.length + "*" + panel.width, m_canvas.width / 2 - 20, m_canvas.height / 1 - 3);

    //Y
    line(10, m_canvas.height - 10, 10, m_canvas.height - 110, RGB_BLACK);
    line(2, m_canvas.height - 100, 10, m_canvas.height - 110, RGB_BLACK);
    line(18, m_canvas.height - 100, 10, m_canvas.height - 110, RGB_BLACK);
    context.fillText("+", 7, m_canvas.height - 130);
    context.fillText("y", 7, m_canvas.height - 120);

    //如果存在轮廓则绘制
    if (panel.outlines.length > 0) {
        drawVertexs(panel.outlines, RGB_NORMAL, true);
    }
    else {
        //绘制顶点
        //否则按长宽来绘制
        var Vertexs = [];
        Vertexs.push(new Vertex(0, 0));
        Vertexs.push(new Vertex(panel.length, 0));
        Vertexs.push(new Vertex(panel.length, panel.width));
        Vertexs.push(new Vertex(0, panel.width));
        Vertexs.push(new Vertex(0, 0));
        drawVertexs(Vertexs, RGB_NORMAL, true);
    };

    //如果存在孔位则绘制
    if (panel.holes) {
        var color = RGB_NORMAL;
        for (var i = 0; i < panel.holes.length; i++) {
            var h = panel.holes[i];
            color = h.sel ? RGB_SELECT : RGB_BLACK;
            if ("x+" == h.dir) {
                for (var n = 0; n < h.no; n++) {
                    //左侧
                    var Vertexs = [];
                    Vertexs[0] = new Vertex(h.x + n * h.xi, h.y + n * h.yi - h.diam / 2);
                    Vertexs[1] = new Vertex(h.x + n * h.xi + h.depth, h.y + n * h.yi - h.diam / 2);
                    Vertexs[2] = new Vertex(h.x + n * h.xi + h.depth, h.y + n * h.yi + h.diam / 2);
                    Vertexs[3] = new Vertex(h.x + n * h.xi, h.y + n * h.yi + h.diam / 2);
                    drawVertexs(Vertexs, color, false);
                };
            }
            else if ("x-" == h.dir) {
                //右侧
                for (var n = 0; n < h.no; n++) {
                    var Vertexs = [];
                    Vertexs[0] = new Vertex(h.x + n * h.xi, h.y + n * h.yi - h.diam / 2);
                    Vertexs[1] = new Vertex(h.x + n * h.xi - h.depth, h.y + n * h.yi - h.diam / 2);
                    Vertexs[2] = new Vertex(h.x + n * h.xi - h.depth, h.y + n * h.yi + h.diam / 2);
                    Vertexs[3] = new Vertex(h.x + n * h.xi, h.y + n * h.yi + h.diam / 2);
                    drawVertexs(Vertexs, color, false);
                };
            }
            else if ("y+" == h.dir) {
                //下侧
                for (var n = 0; n < h.no; n++) {
                    var Vertexs = [];
                    Vertexs[0] = new Vertex(h.x + n * h.xi - h.diam / 2, h.y + n * h.yi);
                    Vertexs[1] = new Vertex(h.x + n * h.xi - h.diam / 2, h.y + n * h.yi + h.depth);
                    Vertexs[2] = new Vertex(h.x + n * h.xi + h.diam / 2, h.y + n * h.yi + h.depth);
                    Vertexs[3] = new Vertex(h.x + n * h.xi + h.diam / 2, h.y + n * h.yi);
                    drawVertexs(Vertexs, color, false);
                };
            }
            else if ("y-" == h.dir) {
                //上侧
                for (var n = 0; n < h.no; n++) {
                    var Vertexs = [];
                    Vertexs[0] = new Vertex(h.x + n * h.xi - h.diam / 2, h.y + n * h.yi);
                    Vertexs[1] = new Vertex(h.x + n * h.xi - h.diam / 2, h.y + n * h.yi - h.depth);
                    Vertexs[2] = new Vertex(h.x + n * h.xi + h.diam / 2, h.y + n * h.yi - h.depth);
                    Vertexs[3] = new Vertex(h.x + n * h.xi + h.diam / 2, h.y + n * h.yi);
                    drawVertexs(Vertexs, color, false);
                };
            }
            else if ("z-" == h.dir) {
                //正面

                for (var n = 0; n < h.no; n++) {
                    drawCircle(h.x + n * h.xi, h.y + n * h.yi, h.diam / 2, color);
                };
            }
            else if ("z+" == h.dir) {
                //背面
                for (var n = 0; n < h.no; n++) {
                    drawCircle(h.x + n * h.xi, h.y + n * h.yi, h.diam / 2, color);
                };
            };
        };
    };

    //直槽
    if (panel.lines) {
        for (var i = 0; i < panel.lines.length; i++) {
            var line = panel.lines[i];
            var Vertexs = [];
            Vertexs[0] = new Vertex(line.startX, line.startY);
            Vertexs[1] = new Vertex(line.endX, line.endY);
            drawVertexs(Vertexs, line.sel ? RGB_SELECT : RGB_NORMAL, false, getLength(line.width));
        };
    };

    //弧
    if (panel.arcs) {
        for (var i = 0; i < panel.arcs.length; i++) {
            var arc = panel.arcs[i];

            var bClock = (AD_CW == arc.direct || AD_CW180 == arc.direct);
            var centerPoint = getArcCenterPoint(arc.startX, arc.startY, arc.endX, arc.endY, arc.radius, arc.direct);
            var angle = getArcAngle(centerPoint.x, centerPoint.y, arc.startX, arc.startY, arc.endX, arc.endY, arc.radius, bClock);
            var bulge = getBulge(angle.sweepAngle, bClock);

            var Vertexs = [];
            Vertexs[0] = new Vertex(arc.startX, arc.startY);
            Vertexs[0].bulge = bulge;
            Vertexs[1] = new Vertex(arc.endX, arc.endY);
            drawVertexs(Vertexs, arc.sel ? RGB_SELECT : RGB_NORMAL, false, getLength(arc.width));
        };
    };

    //圆
    if (panel.circles) {
        for (var i = 0; i < panel.circles.length; i++) {
            var circle = panel.circles[i];
            var Vertexes = [];
            Vertexes[0] = new Vertex(circle.centerX + circle.radius, circle.centerY, 0.0, getBulge(180, false));
            Vertexes[1] = new Vertex(circle.centerX - circle.radius, circle.centerY, 0.0, getBulge(180, false));
            drawVertexs(Vertexes, circle.sel ? RGB_SELECT : RGB_NORMAL, false, 1.0);
        };
    };

    //矩形
    if (panel.rects) {
        for (var i = 0; i < panel.rects.length; i++) {
            var rect = panel.rects[i];
            var Vertexes = [];
            if (rect.radius == 0) {
                Vertexes[0] = new Vertex(rect.x, rect.y);
                Vertexes[1] = new Vertex(rect.x + rect.length, rect.y);
                Vertexes[2] = new Vertex(rect.x + rect.length, rect.y + rect.width);
                Vertexes[3] = new Vertex(rect.x, rect.y + rect.width);
                Vertexes[4] = new Vertex(rect.x, rect.y);
            }
            else {
                var bulge = 0.414214;
                Vertexes[0] = new Vertex(rect.x + rect.radius, rect.y);
                Vertexes[1] = new Vertex(rect.x + rect.length - rect.radius, rect.y, 0, bulge);
                Vertexes[2] = new Vertex(rect.x + rect.length, rect.y + rect.radius);
                Vertexes[3] = new Vertex(rect.x + rect.length, rect.y + rect.width - rect.radius, 0, bulge);
                Vertexes[4] = new Vertex(rect.x + rect.length - rect.radius, rect.y + rect.width);
                Vertexes[5] = new Vertex(rect.x + rect.radius, rect.y + rect.width, 0, bulge);
                Vertexes[6] = new Vertex(rect.x, rect.y + rect.width - rect.radius);
                Vertexes[7] = new Vertex(rect.x, rect.y + rect.radius, 0, bulge);
                Vertexes[8] = new Vertex(rect.x + rect.radius, rect.y);
            };

            drawVertexs(Vertexes, rect.sel ? RGB_SELECT : RGB_NORMAL, false, 1.0);
        };
    };

    //块
    if (panel.blocks) {
        for (var i = 0; i < panel.blocks.length ; i++) {
            var block = panel.blocks[i];

            //线
            for (var j = 0; j < block.lines.length; j++) {
                var line = block.lines[j];
                var Vertexs = [];
                Vertexs[0] = new Vertex(line.startX, line.startY);
                Vertexs[1] = new Vertex(line.endX, line.endY);
                drawVertexs(Vertexs, block.sel ? RGB_SELECT : RGB_NORMAL, false, getLength(line.width));
            };

            //弧
            for (var j = 0; j < block.arcs.length; j++) {
                var arc = block.arcs[j];
                var bClock = (AD_CW == arc.direct || AD_CW180 == arc.direct);
                var centerPoint = getArcCenterPoint(arc.startX, arc.startY, arc.endX, arc.endY, arc.radius, arc.direct);
                var angle = getArcAngle(centerPoint.x, centerPoint.y, arc.startX, arc.startY, arc.endX, arc.endY, arc.radius, bClock);
                var bulge = getBulge(angle.sweepAngle, bClock);

                var Vertexs = [];
                Vertexs[0] = new Vertex(arc.startX, arc.startY);
                Vertexs[0].bulge = bulge;
                Vertexs[1] = new Vertex(arc.endX, arc.endY);
                drawVertexs(Vertexs, block.sel ? RGB_SELECT : RGB_NORMAL, false, getLength(arc.width));
            };

            //圆
            for (var j = 0; j < block.circles.length; j++) {
                var circle = block.circles[j];
                var Vertexs = [];
                Vertexs[0] = new Vertex(circle.centerX + circle.radius, circle.centerY, 0.0, getBulge(180, false));
                Vertexs[1] = new Vertex(circle.centerX - circle.radius, circle.centerY, 0.0, getBulge(180, false));
                Vertexs[2] = new Vertex(circle.centerX + circle.radius, circle.centerY);
                drawVertexs(Vertexs, block.sel ? RGB_SELECT : RGB_NORMAL, true, 1.0);
            };

            //多段线
            for (var j = 0; j < block.polylines.length; j++) {
                var Vertexes = block.polylines[j].vertexes;
                drawVertexs(Vertexes, block.sel ? RGB_SELECT : RGB_NORMAL, false, 1.0);
            };
        };
    };

    context.stroke();

    /* 下面是对其绘制的方法的封装 */
    //X方向上的实际值获取显示值
    function getX(x) {
        return (x / panel.length) * (panel.length / zoom);
    };

    //调整为左下角并实际值获取显示值
    function getY(y) {
        //调整为左下角
        return ((panel.width - y) / panel.width) * (panel.width / zoom);
    };

    //获取实际绘制的长度
    function getLength(l) {
        return (l / zoom);
    };

    /**
	 * 功能：画线，在整个画板中画
	 * 参数：
	 *  @sx，起点X坐标
	 *  @sy，起点Y坐标
	 *  @ex，终点X坐标
	 *  @ey，终点Y坐标
	 * 返回值：无
	 */
    function line(sx, sy, ex, ey, style) {
        context.strokeStyle = style;  //使用新样式
        context.moveTo(sx, sy);
        context.lineTo(ex, ey);
        context.stroke();
    };

    /**
	 * 功能：画线，相对于板件来画
	 * 参数：
	 *  @sx，起点X坐标
	 *  @sy，起点Y坐标
	 *  @ex，终点X坐标
	 *  @ey，终点Y坐标
	 * 返回值：无
	 */
    function drawLine(sx, sy, ex, ey) {
        context.moveTo(sX + getX(sx), sY + getY(sy));
        context.lineTo(sX + getX(ex), sY + getY(ey));
    };

    /**
	 * 功能：画圆
	 * 参数：
	 *  @x，圆心X坐标
	 *  @y，圆心Y价格
	 *  @r，半径
	 * 返回值：无
	 */
    function drawCircle(x, y, r, style) {
        context.strokeStyle = style;  //使用新样式
        context.beginPath();
        context.moveTo(sX + getX(x) + getLength(r), sY + getY(y));
        context.arc(sX + getX(x), sY + getY(y), getLength(r), 0, 2 * Math.PI);
        context.closePath();
        context.stroke();
    };

    //绘制顶点
    /**
	 * 功能：绘制顶点
	 * 参数：
	 *  @vertexs，顶点数组
	 * 返回值：无
	 */
    function drawVertexs(vertexs, style, close, width) {

        var width = IsNullOrEmpty(width) ? 1.0 : width;

        context.save();
        context.beginPath();
        context.lineWidth = width;
        context.strokeStyle = style;  //使用新样式
        for (var i = 0; i < vertexs.length - 1; i++) {
            var v1 = vertexs[i];
            var v2 = vertexs[(i + 1) % vertexs.length];

            if (0 == v1.bulge) {
                //直线
                context.moveTo(sX + getX(v1.x), sY + getY(v1.y));
                context.lineTo(sX + getX(v2.x), sY + getY(v2.y));
            } else {
                //弧
                var centerXY = getCenterXY(v1.x, v1.y, v2.x, v2.y, v1.bulge);

                //半径
                var dRadius = getRadius(v1.x, v1.y, v2.x, v2.y, v1.bulge);

                //角度
                var angle = getArcAngle(centerXY.x, centerXY.y, v1.x, v1.y, v2.x, v2.y, dRadius, v1.bulge < 0);
                var dStartRadian = 2 * Math.PI - AngleToRadian(angle.startAngle);
                var dEndRadian = 2 * Math.PI - AngleToRadian(angle.endAngle);

                context.arc(sX + getX(centerXY.x), sY + getY(centerXY.y), dRadius / zoom, dStartRadian, dEndRadian, v1.bulge > 0);
            };
        };
        //是否闭合
        //if (close)
        //context.closePath();

        context.stroke();
        context.restore();
    };
};