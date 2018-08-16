
/* 实体类 */

//参数
function Param(key, value) {
    this.key = key;
    this.value = value;
};



//顶点
function Vertex(x, y, z, bulge, width) {

    var z = IsNullOrEmpty(z) ? 0.0 : z;
    var bulge = IsNullOrEmpty(bulge) ? 0.0 : bulge;
    var width = IsNullOrEmpty(width) ? 1.0 : width;

    this.strX = ("");
    this.strY = ("");
    this.strZ = ("");
    this.strBulge = ("");  //凸度
    this.strWidth = ("");  //到下一个点的宽度

    //数值
    this.x = x;
    this.y = y;
    this.z = z;
    this.bulge = bulge;
    this.width = width;
};

    //孔
function Hole() {
    //字符串
    this.id = 0;
    this.strX = ("0");
    this.strY = ("0");
    this.strZ = ("0");
    this.strDiam = ("0");
    this.strDepth = ("0");
    this.strNO = ("1");
    this.strXI = ("0");
    this.strYI = ("0");
    this.strZI = ("0");

    //数值
    this.x = ("");
    this.y = ("");
    this.z = ("");
    this.dir = ("");  //方向
    this.diam = ("");  //直径
    this.depth = ("");  //深度

    //扩展
    this.no = ("");  //数量
    this.xi = ("");  //X偏移
    this.yi = ("");  //Y偏移
    this.zi = ("");  //Z偏移
    this.enable = true;  //启用
    this.sel = false;  //选中
};

    //直槽
function Line() {
    this.id = 0;

    //描述字符串
    this.strStartX = ("");
    this.strStartY = ("");
    this.strEndX = ("");
    this.strEndY = ("");
    this.strWidth = ("");
    this.strDepth = ("");

    //直实数值
    this.startX = 0.0;
    this.startY = 0.0;
    this.endX = 0.0;
    this.endY = 0.0;
    this.width = 0.0;
    this.depth = 0.0;

    this.enable = true;  //启用
    this.sel = false;  //选中
};

    //弧
function Arc() {
    this.id = 0;

    //描述字符串
    this.strStartX = ("");
    this.strStartY = ("");
    this.strEndX = ("");
    this.strEndY = ("");
    this.strRadius = ("");
    this.strDirect = ("");
    this.strWidth = ("");
    this.strDepth = ("");

    //直实数值
    this.startX = 0.0;
    this.startY = 0.0;
    this.endX = 0.0;
    this.endY = 0.0;
    this.radius = 0.0;
    this.direct = 0;
    this.width = 0.0;
    this.depth = 0.0;

    this.enable = true;  //启用
    this.sel = false;  //选中
};

    //圆
function Circle() {
    this.id = 0;
    this.strCenterX = ("");
    this.strCenterY = ("");
    this.strRadius = ("");

    this.centerX = 0.0;
    this.centerY = 0.0;
    this.radius = 0.0;

    this.enable = true;  //启用
    this.sel = false;  //选中
};

    //矩形
function Rect() {
    this.id = 0;
    this.strX = ("0");
    this.strY = ("0");
    this.strLength = ("0");
    this.strWidth = ("0");
    this.strRadius = ("0");

    //直实数值
    this.y = 0.0;
    this.y = 0.0;
    this.length = 0.0;
    this.width = 0.0;
    this.radius = 0.0;

    this.enable = true;  //启用
    this.sel = false;  //选中
};

    //多段线
function PolyLine() {
    this.id = 0;
    this.close = false;  //是否闭合
    this.layer = ("");  //图层
    this.vertexes = [];
};

    //块
function Block() {
    this.id = 0;
    this.index = 0;
    this.strX = ("0");
    this.strY = ("0");
    this.args = [];  //变量

    this.x = 0.0;
    this.y = 0.0;
    this.length = 0.0;
    this.width = 0.0;
    this.angle = 0;
    this.mirror = MIRROR_NONE;
    this.layer = ("block");
    this.lines = [];
    this.arcs = [];
    this.circles = [];
    this.polylines = [];

    this.enable = true;  //启用
    this.sel = false;  //选中
};

    //面板
function Panel() {
    this.id = 0;
    this.strName = ("");  //名称
    this.outlineID = 0;  //轮廓ID

    //字符串
    this.strLength = ("");
    this.strWidth = ("");
    this.strThickness = ("");

    //长宽厚
    this.length = 0.0;
    this.width = 0.0;
    this.thickness = 0.0;

    this.params = [];  //参数
    this.outlines = [];  //轮廓
    this.holes = [];  //孔位
    this.lines = [];  //线条
    this.arcs = [];  //弧
    this.circles = [];  //圆
    this.rects = [];  //矩形
    this.polylines = [];  //多段线
    this.blocks = [];  //块

    //清空实体
    this.clearEntity = function () {

    };
};

    //相当于C++中的类
    //面板实体
function clearPanelEntity(p) {
    p.outlines = [];  //轮廓
    p.holes = [];  //也
    p.lines = [];  //线
    p.arcs = [];  //弧
    p.circles = [];  //圆
    p.rects = [];  //矩形
    p.polylines = [];  //多段线
};

    //管理器
function calcautePanelEntity(p) {
    //1.预定变量
    var strParamExpress = ("");
    for (var i = 0; i < p.params.length; i++) {
        var param = p.params[i];
        strParamExpress += "var " + param.key + (" = ") + param.value + (";");
    };

    //面板信息
    p.length = calc(p.strLength);
    p.width = calc(p.strWidth);
    p.thickness = calc(p.strThickness);

    //轮廓

    //孔位
    for (var i = 0; i < p.holes.length; i++) {
        var h = p.holes[i];

        //X
        h.x = calc(h.strX);
        h.y = calc(h.strY);
        h.z = calc(h.strZ);
        h.diam = calc(h.strDiam);
        h.depth = calc(h.strDepth);
        h.no = calc(h.strNO);
        h.xi = calc(h.strXI);
        h.yi = calc(h.strYI);
        h.zi = calc(h.strZI);
    };

    //直槽
    for (var i = 0; i < p.lines.length; i++) {
        var line = p.lines[i];

        //X
        line.startX = calc(line.strStartX);
        line.startY = calc(line.strStartY);
        line.endX = calc(line.strEndX);
        line.endY = calc(line.strEndY);
        line.width = calc(line.strWidth);
        line.depth = calc(line.strDepth);
    };

    //弧
    for (var i = 0; i < p.arcs.length; i++) {
        var arc = p.arcs[i];

        //X
        arc.startX = calc(arc.strStartX);
        arc.startY = calc(arc.strStartY);
        arc.endX = calc(arc.strEndX);
        arc.endY = calc(arc.strEndY);
        arc.radius = calc(arc.strRadius);
        arc.direct = calc(arc.strDirect);
        arc.width = calc(arc.strWidth);
        arc.depth = calc(arc.strDepth);
    };

    //圆
    for (var i = 0; i < p.circles.length; i++) {
        var circle = p.circles[i];

        //X
        circle.centerX = calc(circle.strCenterX);
        circle.centerY = calc(circle.strCenterY);
        circle.radius = calc(circle.strRadius);
    };

    //矩形
    for (var i = 0; i < p.rects.length ; i++) {
        var rect = p.rects[i];
        rect.x = calc(rect.strX);
        rect.y = calc(rect.strY);
        rect.length = calc(rect.strLength);
        rect.width = calc(rect.strWidth);
        rect.radius = calc(rect.strRadius);
    };

    //计算
    function calc(str) {
        //变量
        eval(strParamExpress);
        return eval(str);
    };

    //计算
    return p;
};