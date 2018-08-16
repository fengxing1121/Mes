
var AD_CW = 1;  //顺时针
var AD_CCW = 2;  //逆时针
var AD_CW180 = 3;  //顺时针 > 180
var AD_CCW180 = 4;  //逆时针 > 180

/**
 * 功能：取得两个点的距离
 * 参数：
 *  @x1：第一个点X坐标
 *  @y1：第一个点Y坐标
 *  @x2：第二个点X坐标
 *  @y2：第二个点Y坐标
 */
function getTwoPointDistance(x1, y1, x2, y2) {
    return Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
};

//弧度转角度
function RadianToAngle(dRadian) {
    //弧度变角度 180/π×弧度
    return (180 / Math.PI * dRadian);
};

//角度转弧度
function AngleToRadian(dAngle) {
    //角度转弧度 π/180×角度
    return (Math.PI / 180 * dAngle);
};

/**
 * 功能：求两个凸点的半径
 * 参数：
 *  @x1：第一个点X坐标
 *  @y1：第一个点Y坐标
 *  @x2：第二个点X坐标
 *  @y2：第二个点Y坐标
 *  @bulge：凸度
 * 返回值：半径
 */
function getRadius(x1, y1, x2, y2, bulge) {
    //包角
    var centerAngle = 4 * Math.atan(Math.abs(bulge));

    //弦长
    var L = getTwoPointDistance(x1, y1, x2, y2);

    //返回半径
    return (L / Math.sin(centerAngle / 2.0)) / 2.0;
};

/**
 * 功能：获取圆弧凸度
 * 参数：
 *  @sweepAngle：圆弧扫过的角度
 *  @bClock：是否是顺时针
 * 返回值：圆弧凸度，包含正负
 */
function getBulge(sweepAngle, bClock) {
    var radian = AngleToRadian(sweepAngle);
    var bulge = Math.tan(radian / 4);
    return bClock ? -bulge : bulge;
};

/**
 * 功能：获取弧的开始角度，终止角度和扫过的角度
 * 参数：
 *  @dCenterX，中心X坐标
 *  @dCenterY，中心Y坐标
 *  @dBeginX，开始X坐标
 *  @dBeginY，开始Y坐标
 *  @dEndX，结束X坐标
 *  @dEndY，结束Y坐标
 *  @dRadius，半径
 *  @bClock，是否顺时针
 *  @[out]pStartAngle，开始角度，可以为NULL，表明不接收
 *  @[out]pEndAngle，结束角度，可以为NULL，表明不接收
 *  @[out]pSweepAngle，扫过的角度，可以为NULL，表明不接收
 * 返回值：如果成功，返回TRUE，否则返回FALSE
 */
function getArcAngle(dCenterX, dCenterY, dBeginX, dBeginY, dEndX, dEndY, dRadius, bClock) {
    var ret = new Object();

    //不能与圆心重合
    if (dBeginX == dEndX && dBeginY == dEndY) {
        //无法成圆
        ret.ok = false;
        return ret;
    };

    //半径不能小于等于零
    if (dRadius <= 0.0) {
        ret.ok = false;
        return ret;
    };

    //起始角度、终止角度
    var dStartValue = (dBeginX - dCenterX) / dRadius;

    //浮点型中的结果1可能是1.00000000000000001，避免这种情况出现。  
    if (dStartValue > 1) dStartValue = 1;
    if (dStartValue < -1) dStartValue = -1;
    var dBeginRadian = Math.acos(dStartValue);

    //如果在圆心的下方则是大于180
    if (dBeginY < dCenterY)
        dBeginRadian = 2 * Math.PI - dBeginRadian;
    var dBeginAngle = RadianToAngle(dBeginRadian);

    //终止角度、终止角度
    var dEndValue = (dEndX - dCenterX) / dRadius;
    //浮点型中的结果1可能是1.00000000000000001，避免这种情况出现。  
    if (dEndValue > 1) dEndValue = 1;
    if (dEndValue < -1) dEndValue = -1;
    var dEndRadian = Math.acos(dEndValue);

    //如果在圆心的下方则是大于180
    if (dEndY < dCenterY)
        dEndRadian = 2 * Math.PI - dEndRadian;
    var dEndAngle = RadianToAngle(dEndRadian);

    //扫过的角度
    var dSweepAngle = (dEndAngle - dBeginAngle);
    if (dSweepAngle < 0)
        dSweepAngle += 360.0;
    if (bClock)
        dSweepAngle = 360.0 - dSweepAngle;

    //赋值给参数作为返回
    ret.ok = true;
    ret.startAngle = dBeginAngle;
    ret.endAngle = dEndAngle;
    ret.sweepAngle = dSweepAngle;

    return ret;
};

//浮点数是否相等
function isDoubleEqual(a, b) {
    return (Math.abs(a - b) <= 0.001);
};

function getEquation(a, b, c) {
    //a != 0
    var ret = new Object();
    if (0 == a) {
        ret.ok = false;
        return ret;
    };

    //b^2 - 4ac 测试是否有解
    var d = b * b - 4 * a * c;
    if (isDoubleEqual(d, 0.0)) {
        //有一个解
        //-b / 2a
        ret.ok = true;
        ret.num = 1;
        ret.x1 = -b / (2 * a);
    }
    else if (d > 0.0) {
        //有两个解
        //(-b ± √(b^2 - 4ac))/2a
        var dRoot = Math.sqrt(d);
        ret.ok = true;
        ret.num = 2;
        ret.x1 = (-b + dRoot) / (2 * a);
        ret.x2 = (-b - dRoot) / (2 * a);
    }
    else {
        // < 0，无解
        ret.ok = false;
        return ret;
    };
    return ret;
};

//获取弧所对应的圆心坐标
function getArcCenterPoints(beginX, beginY, endX, endY, dR) {
    //两点不能相等
    var ret = new Object();
    if (isDoubleEqual(beginX, endX)
		&& isDoubleEqual(beginY, endY)) {
        ret.ok = false;
        return ret;
    };

    //半径不能小于等于零
    if (dR <= 0.0) {
        ret.ok = false;
        return ret;
    };

    //G = a*a - c*c + b*b - d*d;
    var dG = beginX * beginX + beginY * beginY - endX * endX - endY * endY;
    var dH = 2 * (beginY - endY);
    var dK = 2 * (beginX - endX);

    //被除数不能为零
    var a = 0.0;
    var b = 0.0;
    var c = 0.0;
    var nNum = 0;
    if (isDoubleEqual(dK, 0.0)) {
        var d = dR * dR - (beginY - endY) * (beginY - endY) / 4.0;
        if (d < 0) {
            ret.ok = false;
            return ret;
        };

        ret.ok = true;
        if (d == 0.0) {
            //存在一个解
            ret.num = 1;
            ret.x1 = beginX + Math.sqrt(d);
            ret.y1 = (beginY + endY) / 2;
            return ret;
        };

        //存在两个解
        ret.num = 2;
        ret.x1 = beginX + Math.sqrt(d);
        ret.y1 = (beginY + endY) / 2;
        ret.x2 = endX - Math.sqrt(d);
        ret.y2 = ret.y1;
        return ret;
    }
    else {
        //二元一次方程的一般公式
        a = 1 + Math.pow(dH, 2) / Math.pow(dK, 2);
        b = 2 * dH * beginX / dK - 2 * dG * dH / Math.pow(dK, 2) - 2 * beginY;
        c = Math.pow(beginX, 2) - 2 * dG * beginX / dK + Math.pow(dG, 2) / Math.pow(dK, 2) + Math.pow(beginY, 2) - Math.pow(dR, 2);

        //求解一元二次方程
        var e = getEquation(a, b, c);
        if (!e.ok) {
            ret.ok = false;
            return ret;
        };

        ret.num = e.num;
        if (1 == ret.num) {
            ret.x1 = (dG - dH * e.x1) / dK;
            ret.y1 = e.x1;
        }
        else if (2 == ret.num) {
            ret.x1 = (dG - dH * e.x1) / dK;
            ret.y1 = e.x1;
            ret.x2 = (dG - dH * e.x2) / dK;
            ret.y2 = e.x2;
        };
    };

    return ret;
};

//获取圆弧的中心（是否顺时针）
function getArcCenterPoint(dStartX, dStartY, dEndX, dEndY, dRadius, ad) {
    var ret = new Object();

    //半径不能小于弦长  
    var dLength = getTwoPointDistance(dStartX, dStartY, dEndX, dEndY);
    var dMinRadius = dLength / 2.0;
    if (dRadius < dMinRadius && !isDoubleEqual(dRadius, dMinRadius)) {
        //无法成圆
        ret.ok = false;
        return ret;
    };

    //先初步计算出两个圆心
    var dCenterX1 = 0;
    var dCenterX2 = 0;
    var dCenterY1 = 0;
    var dCenterY2 = 0;
    var e = getArcCenterPoints(dStartX, dStartY, dEndX, dEndY, dRadius);
    if (0 == e.num) {
        ret.ok = false;
        return ret;
    }
    else if (1 == e.num) {
        //只存在一个圆心
        dCenterX = e.x1;
        dCenterY = e.y1;
    }
    else if (2 == e.num) {
        //存在两个圆心，需要确定使用哪一个
        var bClockwise = (1 == ad || 3 == ad);
        var a = getArcAngle(e.x1, e.y1, dStartX, dStartY, dEndX, dEndY, dRadius, bClockwise);
        if (!a.ok) {
            ret.ok = false;
            return ret;
        };

        if (1 == ad || 2 == ad) {
            //劣弧
            if (a.sweepAngle <= 180.0) {
                dCenterX = e.x1;
                dCenterY = e.y1;
            }
            else {
                dCenterX = e.x2;
                dCenterY = e.y2;
            };
        }
        else {
            //优弧
            if (a.sweepAngle <= 180.0) {
                dCenterX = e.x2;
                dCenterY = e.y2;
            }
            else {
                dCenterX = e.x1;
                dCenterY = e.y1;
            };
        };
    }
    else {
        return false;
    };

    //赋值给结果
    ret.ok = true;
    ret.x = dCenterX;
    ret.y = dCenterY;
    return ret;
};

/**
 * 功用：获取圆心XY
 * 参数：
 * x1：第一个点X坐标
 * y1：第一个点Y坐标
 * x2：第二个点X坐标
 * y2：第二个点Y坐标
 * bulge：凸度
 * 返回值：返回一个对象，这个对象中ok如果为true表示成功，如果为false表示失败，当为true时，则存在x,y，此时的x,y为所求得的圆心x,y。
 */
function getCenterXY(x1, y1, x2, y2, bulge) {
    var ret = new Object();

    //半径
    var dR = getRadius(x1, y1, x2, y2, bulge)

    //弦长
    var dLength = getTwoPointDistance(x1, y1, x2, y2);
    if (2 * dR < dLength) {
        //无法成圆
        ret.ok = false;
        return ret;
    };

    var dCenterX1 = 0;
    var dCenterX2 = 0;
    var dCenterY1 = 0;
    var dCenterY2 = 0;
    var k = (y2 - y1) / (x2 - x1);  //请注意：在浮点数中是允许除数为零的，结果是无穷大
    if (0 == k) {
        dCenterX1 = (x1 + x2) / 2.0;
        dCenterX2 = (x1 + x2) / 2.0;
        dCenterY1 = y1 + Math.sqrt(dR * dR - (x1 - x2) * (x1 - x2) / 4.0);
        dCenterY2 = y2 - Math.sqrt(dR * dR - (x1 - x2) * (x1 - x2) / 4.0);
    }
    else {
        var k_verticle = -1.0 / k;
        var mid_x = (x1 + x2) / 2.0;
        var mid_y = (y1 + y2) / 2.0;
        var a = 1.0 + k_verticle * k_verticle;
        var b = -2 * mid_x - k_verticle * k_verticle * (x1 + x2);
        var c = mid_x * mid_x + k_verticle * k_verticle * (x1 + x2) * (x1 + x2) / 4.0 - (dR * dR - ((mid_x - x1) * (mid_x - x1) + (mid_y - y1) * (mid_y - y1)));

        dCenterX1 = (-1.0 * b + Math.sqrt(b * b - 4 * a * c)) / (2 * a);
        dCenterX2 = (-1.0 * b - Math.sqrt(b * b - 4 * a * c)) / (2 * a);
        dCenterY1 = k_verticle * dCenterX1 - k_verticle * mid_x + mid_y;
        dCenterY2 = k_verticle * dCenterX2 - k_verticle * mid_x + mid_y;
    };

    /* 确定圆心 */
    var angleChordX = Math.acos((1 * (x2 - x1) + 0 * (y2 - y1)) / dLength) * 180 / Math.PI;
    if (y2 < y1)
        angleChordX *= -1;

    //优劣弧
    var isMinorArc = (Math.abs(bulge) <= 1) ? true : false;

    //方向
    var dir = (bulge < 0) ? true : false;

    var dCenterX = 0;
    var dCenterY = 0;
    if ((angleChordX > 0 && angleChordX < 180) || angleChordX == 180) {
        if (dir) {
            //角度小于180度
            if (isMinorArc) {
                dCenterX = dCenterX1;
                dCenterY = dCenterY1;
            } else {
                dCenterX = dCenterX2;
                dCenterY = dCenterY2;
            };
        }
        else {	//逆圆
            if (isMinorArc) {
                dCenterX = dCenterX2;
                dCenterY = dCenterY2;
            } else {
                dCenterX = dCenterX1;
                dCenterY = dCenterY1;
            };
        };
    }
    else {
        //顺圆
        if (dir) {
            if (isMinorArc) {
                dCenterX = dCenterX2;
                dCenterY = dCenterY2;
            } else {
                dCenterX = dCenterX1;
                dCenterY = dCenterY1;
            };
        } else {
            //逆圆
            if (isMinorArc) {
                dCenterX = dCenterX1;
                dCenterY = dCenterY1;
            } else {
                dCenterX = dCenterX2;
                dCenterY = dCenterY2;
            };
        };
    };

    //成功，返回圆心坐标
    ret.ok = true;
    ret.x = dCenterX;
    ret.y = dCenterY;
    return ret;
};