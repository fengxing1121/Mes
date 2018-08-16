/*!
 @Name：calendar插件
 @Author：刘胜伟
 @Remark：删掉了一些非必要内容；根据业务需求对部分内容进行了优化；
 @Date：2018-07-05
 @License：MES  
 */
var lunarInfo = new Array(
		0x04bd8, 0x04ae0, 0x0a570, 0x054d5, 0x0d260, 0x0d950, 0x16554, 0x056a0, 0x09ad0, 0x055d2,
		0x04ae0, 0x0a5b6, 0x0a4d0, 0x0d250, 0x1d255, 0x0b540, 0x0d6a0, 0x0ada2, 0x095b0, 0x14977,
		0x04970, 0x0a4b0, 0x0b4b5, 0x06a50, 0x06d40, 0x1ab54, 0x02b60, 0x09570, 0x052f2, 0x04970,
		0x06566, 0x0d4a0, 0x0ea50, 0x06e95, 0x05ad0, 0x02b60, 0x186e3, 0x092e0, 0x1c8d7, 0x0c950,
		0x0d4a0, 0x1d8a6, 0x0b550, 0x056a0, 0x1a5b4, 0x025d0, 0x092d0, 0x0d2b2, 0x0a950, 0x0b557,
		0x06ca0, 0x0b550, 0x15355, 0x04da0, 0x0a5b0, 0x14573, 0x052b0, 0x0a9a8, 0x0e950, 0x06aa0,
		0x0aea6, 0x0ab50, 0x04b60, 0x0aae4, 0x0a570, 0x05260, 0x0f263, 0x0d950, 0x05b57, 0x056a0,
		0x096d0, 0x04dd5, 0x04ad0, 0x0a4d0, 0x0d4d4, 0x0d250, 0x0d558, 0x0b540, 0x0b6a0, 0x195a6,
		0x095b0, 0x049b0, 0x0a974, 0x0a4b0, 0x0b27a, 0x06a50, 0x06d40, 0x0af46, 0x0ab60, 0x09570,
		0x04af5, 0x04970, 0x064b0, 0x074a3, 0x0ea50, 0x06b58, 0x055c0, 0x0ab60, 0x096d5, 0x092e0,
		0x0c960, 0x0d954, 0x0d4a0, 0x0da50, 0x07552, 0x056a0, 0x0abb7, 0x025d0, 0x092d0, 0x0cab5,
		0x0a950, 0x0b4a0, 0x0baa4, 0x0ad50, 0x055d9, 0x04ba0, 0x0a5b0, 0x15176, 0x052b0, 0x0a930,
		0x07954, 0x06aa0, 0x0ad50, 0x05b52, 0x04b60, 0x0a6e6, 0x0a4e0, 0x0d260, 0x0ea65, 0x0d530,
		0x05aa0, 0x076a3, 0x096d0, 0x04bd7, 0x04ad0, 0x0a4d0, 0x1d0b6, 0x0d250, 0x0d520, 0x0dd45,
		0x0b5a0, 0x056d0, 0x055b2, 0x049b0, 0x0a577, 0x0a4b0, 0x0aa50, 0x1b255, 0x06d20, 0x0ada0,
		0x14b63);

var solarMonth = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
var Gan = new Array("甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸");
var Zhi = new Array("子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥");
var Animals = new Array("鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪");
var solarTerm = new Array("小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至")
var sTermInfo = new Array(0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758)
var nStr1 = new Array('日', '一', '二', '三', '四', '五', '六', '七', '八', '九', '十')
var nStr2 = new Array('初', '十', '廿', '卅', ' ')
var monthName = new Array("正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "冬月", "腊月")

//国历节日  *表示放假日
var sFtv = new Array(
        "0101*元旦",
        "0308  妇女节",
        "0501*劳动节",
        "0601  儿童节",
        "0701  建党节",
        "0801  建军节",
        "0910  教师节",
        "1001*国庆节",
        "1224  平安夜",
        "1225  圣诞节"
    )
//农历节日  *表示放假日
var lFtv = new Array(
        "0101*春节",
        "0115  元宵节",
        "0505*端午节",
        "0707  情人节",
        "0715  中元节",
        "0815*中秋节",
        "0909  重阳节",
        "1208  腊八节",
        "1223  小年",
        "0100*除夕");
//某月的第几个星期几; 5,6,7,8 表示到数第 1,2,3,4 个星期几
var wFtv = new Array(
        "0520  母亲节",
        "0630  父亲节"
    )

//====================================== 返回农历 y年的总天数
function lYearDays(y) {
    var i,
	sum = 348;
    for (i = 0x8000; i > 0x8; i >>= 1)
        sum += (lunarInfo[y - 1900] & i) ? 1 : 0;
    return (sum + leapDays(y));
}

//====================================== 返回农历 y年闰月的天数
function leapDays(y) {
    if (leapMonth(y))
        return ((lunarInfo[y - 1900] & 0x10000) ? 30 : 29);
    else
        return (0);
}

//====================================== 返回农历 y年闰哪个月 1-12 , 没闰返回 0
function leapMonth(y) {
    return (lunarInfo[y - 1900] & 0xf);
}

//====================================== 返回农历 y年m月的总天数
function monthDays(y, m) {
    return ((lunarInfo[y - 1900] & (0x10000 >> m)) ? 30 : 29);
}

//本月第几周的方法
var getMonthWeek = function (a, b, c) {
    /*  
    a = d = 当前日期  
    b = 6 - w = 当前周的还有几天过完(不算今天)  
    a + b 的和在除以7 就是当天是当前月份的第几周  
    */
    var date = new Date(a, parseInt(b) - 1, c),
        w = date.getDay(),
        d = date.getDate();
    return Math.ceil((d + 6 - w) / 7);
};

//====================================== 算出农历, 传入日期控件, 返回农历日期控件
//                                       该控件属性有 .year .month .day .isLeap
function Lunar(objDate) {

    var i,
	leap = 0,
	temp = 0;
    var offset = (Date.UTC(objDate.getFullYear(), objDate.getMonth(), objDate.getDate()) - Date.UTC(1900, 0, 31)) / 86400000;

    for (i = 1900; i < 2050 && offset > 0; i++) {
        temp = lYearDays(i);
        offset -= temp;
    }

    if (offset < 0) {
        offset += temp;
        i--;
    }

    this.year = i;

    leap = leapMonth(i); //闰哪个月
    this.isLeap = false;

    for (i = 1; i < 13 && offset > 0; i++) {
        //闰月
        if (leap > 0 && i == (leap + 1) && this.isLeap == false) {
            --i;
            this.isLeap = true;
            temp = leapDays(this.year);
        } else {
            temp = monthDays(this.year, i);
        }

        //解除闰月
        if (this.isLeap == true && i == (leap + 1))
            this.isLeap = false;

        offset -= temp;
    }

    if (offset == 0 && leap > 0 && i == leap + 1)
        if (this.isLeap) {
            this.isLeap = false;
        } else {
            this.isLeap = true;
            --i;
        }

    if (offset < 0) {
        offset += temp;
        --i;
    }

    this.month = i;
    this.day = offset + 1;
}

//==============================返回公历 y年某m+1月的天数
function solarDays(y, m) {
    if (m == 1)
        return (((y % 4 == 0) && (y % 100 != 0) || (y % 400 == 0)) ? 29 : 28);
    else
        return (solarMonth[m]);
}
//============================== 传入 offset 返回干支, 0=甲子
function cyclical(num) {
    return (Gan[num % 10] + Zhi[num % 12]);
}
//============================== 阴历属性
//============================== 阴历属性
function calElement(sYear, sMonth, sDay, week, lYear, lMonth, lDay, isLeap, cYear, cMonth, cDay) {

    this.isToday = false;
    //瓣句
    this.sYear = sYear; //公元年4位数字
    this.sMonth = sMonth; //公元月数字
    this.sDay = sDay; //公元日数字
    this.week = week; //星期, 1个中文
    //农历
    this.lYear = lYear; //公元年4位数字
    this.lMonth = lMonth; //农历月数字
    this.lDay = lDay; //农历日数字
    this.isLeap = isLeap; //是否为农历闰月?
    //八字
    this.cYear = cYear; //年柱, 2个中文
    this.cMonth = cMonth; //月柱, 2个中文
    this.cDay = cDay; //日柱, 2个中文

    this.color = '';

    this.lunarFestival = ''; //农历节日
    this.solarFestival = ''; //公历节日
    this.solarTerms = ''; //节气
}

//===== 某年的第n个节气为几日(从0小寒起算)
function sTerm(y, n) {
    if (y == 2009 && n == 2) {
        sTermInfo[n] = 43467
    }
    var offDate = new Date((31556925974.7 * (y - 1900) + sTermInfo[n] * 60000) + Date.UTC(1900, 0, 6, 2, 5));
    return (offDate.getUTCDate());
}

function calendar(y, m) {

    var sDObj,
	lDObj,
	lY,
	lM,
	lD = 1,
	lL,
	lX = 0,
	tmp1,
	tmp2,
	tmp3;
    var cY,
	cM,
	cD; //年柱,月柱,日柱
    var lDPOS = new Array(3);
    var n = 0;
    var firstLM = 0;

    sDObj = new Date(y, m, 1, 0, 0, 0, 0); //当月一日日期
    this.length = solarDays(y, m); //公历当月天数
    this.firstWeek = sDObj.getDay(); //公历当月1日星期几

    ////////年柱 1900年立春后为庚子年(60进制36)
    if (m < 2)
        cY = cyclical(y - 1900 + 36 - 1);
    else
        cY = cyclical(y - 1900 + 36);

    var term2 = sTerm(y, 2); //立春日期

    ////////月柱 1900年1月小寒以前为 丙子月(60进制12)
    var firstNode = sTerm(y, m * 2) //返回当月「节」为几日开始
    cM = cyclical((y - 1900) * 12 + m + 12);

    lM2 = (y - 1900) * 12 + m + 12;
    //当月一日与 1900/1/1 相差天数
    //1900/1/1与 1970/1/1 相差25567日, 1900/1/1 日柱为甲戌日(60进制10)
    var dayCyclical = Date.UTC(y, m, 1, 0, 0, 0, 0) / 86400000 + 25567 + 10;

    for (var i = 0; i < this.length; i++) {

        if (lD > lX) {
            sDObj = new Date(y, m, i + 1);    //当月一日日期
            lDObj = new Lunar(sDObj);     //农历
            lY = lDObj.year;           //农历年
            lM = lDObj.month;          //农历月
            lD = lDObj.day;            //农历日
            lL = lDObj.isLeap;         //农历是否闰月
            lX = lL ? leapDays(lY) : monthDays(lY, lM); //农历当月最后一天

            if (n == 0) firstLM = lM;
            lDPOS[n++] = i - lD + 1;
        }

        //依节气调整二月分的年柱, 以立春为界
        if (m == 1 && ((i + 1) == term2 || lD == 1))
            cY = cyclical(y - 1900 + 36);

        if (lD == 1) {
            cM = cyclical((y - 1900) * 12 + m + 13);
        }

        //日柱
        cD = cyclical(dayCyclical + i);
        lD2 = (dayCyclical + i);

        this[i] = new calElement(y, m + 1, i + 1, nStr1[(i + this.firstWeek) % 7],
                lY, lM, lD++, lL,
                cY, cM, cD);

    }

    //节气
    tmp1 = sTerm(y, m * 2) - 1;
    tmp2 = sTerm(y, m * 2 + 1) - 1;
    this[tmp1].solarTerms = solarTerm[m * 2];
    this[tmp2].solarTerms = solarTerm[m * 2 + 1];
    if (m == 3) this[tmp1].color = 'red'; //清明颜色

    //公历节日
    for (i in sFtv)
        if (sFtv[i].match(/^(\d{2})(\d{2})([\s\*])(.+)$/))
            if (Number(RegExp.$1) == (m + 1)) {
                this[Number(RegExp.$2) - 1].solarFestival += RegExp.$4 + ' ';
                if (RegExp.$3 == '*')
                    this[Number(RegExp.$2) - 1].color = 'red';
            }

    //月周节日
    for (i in wFtv)
        if (wFtv[i].match(/^(\d{2})(\d)(\d)([\s\*])(.+)$/))
            if (Number(RegExp.$1) == (m + 1)) {
                tmp1 = Number(RegExp.$2);
                tmp2 = Number(RegExp.$3);
                if (tmp1 < 5)
                    this[((this.firstWeek > tmp2) ? 7 : 0) + 7 * (tmp1 - 1) + tmp2 - this.firstWeek].solarFestival += RegExp.$5 + ' ';
                else {
                    tmp1 -= 5;
                    tmp3 = (this.firstWeek + this.length - 1) % 7; //当月最后一天星期?
                    this[this.length - tmp3 - 7 * tmp1 + tmp2 - (tmp2 > tmp3 ? 7 : 0) - 1].solarFestival += RegExp.$5 + ' ';
                }
            }
    //农历节日
    for (i in lFtv)
        if (lFtv[i].match(/^(\d{2})(.{2})([\s\*])(.+)$/)) {
            tmp1 = Number(RegExp.$1) - firstLM;
            if (tmp1 == -11)
                tmp1 = 1;
            if (tmp1 >= 0 && tmp1 < n) {
                tmp2 = lDPOS[tmp1] + Number(RegExp.$2) - 1;
                if (tmp2 >= 0 && tmp2 < this.length && this[tmp2].isLeap != true) {
                    this[tmp2].lunarFestival += RegExp.$4 + ' ';
                    if (RegExp.$3 == '*')
                        this[tmp2].color = 'red';
                }
            }
        }

    //今日
    if (y == tY && m == tM)
        this[tD - 1].isToday = true;
}

//====================== 中文日期
function cDay(d, m, dt) {
    var s;
    switch (d) {
        case 1:
            s = monthName[m - 1];
            if (dt) {
                s = '初一';
            }
            break;
        case 10:
            s = '初十';
            break;
        case 20:
            s = '二十';
            break;
        case 30:
            s = '三十';
            break;
        default:
            s = nStr2[Math.floor(d / 10)];
            s += nStr1[d % 10];
    }
    return (s);
}
var cld;

//存放选中的日期
var hDays = [];
function drawCld(SY, SM) {

    var i, sD, s, size;
    cld = new calendar(SY, SM);

    $("#GZ")[0].innerHTML = '  农历' + cyclical(SY - 1900 + 36) + '年&nbsp;【' + Animals[(SY - 4) % 12] + '年】';

    for (i = 0; i < 42; i++) {
        sObj = $("#SD" + i)[0];

        lObj = $("#LD" + i)[0];

        sObj.className = '';

        //在这里回显回来的数值，如果是工作日为淡粉红，假日为青色

        sD = i - cld.firstWeek;

        var type = $("#GD" + i).attr("class") //每次进来 都清除所有样式
        $("#GD" + i).removeClass(type);
        $("#GD" + i).attr("on", 0);
        if (sD > -1 && sD < cld.length) {  //日期内
            sObj.innerHTML = sD + 1;

            var nowDays = SY + '' + addZ((SM + 1)) + addZ((sD + 1));
            var hstr = hDays.join();
            if (hstr.indexOf(nowDays) > -1) {
                $("#GD" + i).addClass("selday");
            }
            sObj.style.color = cld[sD].color;  //国定假日颜色

            if (cld[sD].lDay == 1) {  //显示农历月
                lObj.innerHTML = (cld[sD].isLeap ? '闰' : '') + Lunarcalendar(cld[sD].lMonth) + '月';
            } else {  //显示农历日
                lObj.innerHTML = cDay(cld[sD].lDay);
            }

            s = cld[sD].lunarFestival;

            if (s.length > 0) {  //农历节日
                if (s.length > 8) s = s.substr(0, 7) + '...';
                s = s.fontcolor('red');

            } else {  //国历节日
                s = cld[sD].solarFestival;
                if (s.length > 0) {

                    s = s.fontcolor('#0066FF');
                }
                else {  //廿四节气
                    s = cld[sD].solarTerms;
                    if (s.length > 0) s = s.fontcolor('limegreen');
                }
            }
            if (cld[sD].solarTerms == '清明') s = '清明节'.fontcolor('red');
            if (cld[sD].solarTerms == '芒种') s = '芒种'.fontcolor('red');
            if (cld[sD].solarTerms == '夏至') s = '夏至'.fontcolor('red');
            if (cld[sD].solarTerms == '冬至') s = '冬至'.fontcolor('red');

            if (s.length > 0) { lObj.innerHTML = s; }
            // 注册点击事件
            $("#GD" + i).unbind('click').click(function (){
                mOck(this, sD + 1, i);
            });

            defalutcheck(i);
            
        }
        else {  //非日期
            $("#GD" + i).addClass("unover");
        }
    }
}


/*清除数据*/
function clear() {
    hDays = [];
    for (i = 0; i < 42; i++) {
        sObj = $("#SD" + i)[0];
        sObj.innerHTML = '';
        lObj = $("#LD" + i)[0];
        lObj.innerHTML = '';
        $("#GD" + i).removeClass("unover");
        $("#GD" + i).removeClass("jinri");
        $("#GD" + i).removeClass("selday");
        removeBan("GD" + i);
        //console.log(sObj);
    }
    clearWeekAverage();
}

function Lunarcalendar(Month) {
    var txt = "";
    switch (Month) {
        case 1: txt = "正"; break;
        case 2: txt = "二"; break;
        case 3: txt = "三"; break;
        case 4: txt = "四"; break;
        case 5: txt = "五"; break;
        case 6: txt = "六"; break;
        case 7: txt = "七"; break;
        case 8: txt = "八"; break;
        case 9: txt = "九"; break;
        case 10: txt = "十"; break;
        case 11: txt = "十一"; break;
        case 12: txt = "腊"; break;
    }
    return txt;
}

var Today = new Date();
var tY = Today.getFullYear();//2015
var tM = Today.getMonth();

var tD = Today.getDate();
 
var width = "130";
var offsetX = 2;
var offsetY = 18;

var x = 0;
var y = 0;
var snow = 0;
var sw = 0;
var cnt = 0;
var dStyle;


//日期点击函数
function mOck(thisObj, v, i) {
   
    var onoff = thisObj.attributes["on"].value; //判定当前是否已经选中了，0是表示之前没有被选 现在被选， 1是表示之前已经被选择了 现在取消
    var type = thisObj.getAttribute("class");  //判定类型 是否是特殊工作日和假日
    var dayContainer = thisObj.getElementsByTagName("font")[0]; //公历显示数据
    var nian = $('#nian').text();
    var yue = $('#yue').text();
    var dayJson = ""; //添加的数据
    var day = dayContainer.innerHTML;
    var ymd = nian + addZ(yue) + addZ(day);
    if (ymd.length != 8) {
        return false;
    }
    
    var dayContainer2 = thisObj.getElementsByTagName("font")[1];
    var name = dayContainer2.innerHTML;
    if (name.indexOf("font") > 0) { //获取农历的值
        var names = name.split(">");
        var namew = names[1].split("<");
        name = namew[0];
    }
    var ids = thisObj.attributes["id"].value
    var lx = '1';//是工作日

    var dayColor = dayContainer.attributes["color"];
    var dayF = nian + '/' + addZ(yue) + '/' + addZ(day);
    if (dayColor && dayColor.value == 'red' && getH(dayF)) {
        lx = '0';//周末
    }

    //自定义事件（刘胜伟）
    var weekno = getMonthWeek(nian, addZ(yue), addZ(day));
    var model = {
        weekno: parseInt(weekno),
        datetime: nian + '-' + addZ(yue) + '-' + addZ(day),
        lunarcalendar: name,
        isworkday: (lx == "1") ? true : false//表示工作日 周一到周5 
    }
    //console.log(onoff);
    if (onoff == "0") {
        thisObj.attributes["on"].value = '1';
        hDays.push(model);
        thisObj.setAttribute("class", "selday");
        addBan(thisObj.id)
    } else if (onoff == "1") {
        thisObj.attributes["on"].value = '0';
        thisObj.setAttribute("class", "");
        removeBan(thisObj.id)
        delArry(hDays, model);
    }
    var element = $(".trweek").eq(weekno - 1);
    var count = $('#' + ids).parent().find(".selday").length;
    if (count > 0) {
        if (element.is(":hidden")) {
            element.show();
        }
    }
    else {
        element.hide();
    }
    if (onoff == "0") {
        element.find("p").append("<span  class='date' id=" + ymd + ">" + ymd + "   " + "</span>");
    }
    if (onoff == "1") {
        $("#" + ymd).remove();
    }
    settotalarealHtml();
}

function defalutcheck(id) {
    
    var dayContainer = document.getElementById("GD" + id).getElementsByTagName("font")[0];
    var nian = $('#nian').text();
    var yue = $('#yue').text();
    var day = dayContainer.innerHTML;
    
    var lx = '1';//是工作日
    var dayColor = dayContainer.attributes["color"];
    var dayF = nian + '/' + addZ(yue) + '/' + addZ(day);
    if (dayColor && dayColor.value == 'red' && getH(dayF)) {
        lx = '0';//周末
    }
    else {
        $("#GD" + id).click();
    }
}

//删除数组指定元素
function delArry(arr, obj) {

    for (var i = 0; i < arr.length; i++) {
        if (JSON.stringify(arr[i]) == JSON.stringify(obj)) {
            arr.splice(i, 1);
        }
    };
}

function addZ(obj) {
    return obj < 10 ? '0' + obj : obj;
}
function getH(obj) {
    var d = new Date(Date.parse(obj));
    var c = d.getDay();
    if (c == 0 || c == 6) {
        return true;
    } else {
        return false;
    }
}

function addBan(id) {
    $("#" + id).prepend('<span class="op-calendar-new-table-holiday-sign">班</span>');
}
function removeBan(id) {
    $("#" + id).find(".op-calendar-new-table-holiday-sign").remove();
}

/*初始化日期*/

$(function () {
    initRiliIndex();
    clear();
    $("#nian").html(tY);
    $("#yue").html(tM + 1);

    /*年份递减*/
    $("#nianjian").click(function () {
        dateSelection.goPrevYear();

    });
    /*年份递加*/
    $("#nianjia").click(function () {
        dateSelection.goNextYear();

    });

    /*月份递减*/
    $("#yuejian").click(function () {
        dateSelection.goPrevMonth();
        $('.holiday').show();
    });



    /*月份递加*/
    $("#yuejia").click(function () {
        dateSelection.goNextMonth();

    });
    drawCld(tY, tM);

});


var global = {
    currYear: -1, // 当前年
    currMonth: -1, // 当前月，0-11
    currDate: null, // 当前点选的日期
    uid: null,
    username: null,
    email: null,
    single: false
    // 是否为独立页调用，如果是值为日历id，使用时请注意对0的判断，使用 single !== false 或者 single === false
};

var dateSelection = {
    currYear: -1,
    currMonth: -1,

    minYear: 1901,
    maxYear: 2200,

    beginYear: 0,
    endYear: 0,

    tmpYear: -1,
    tmpMonth: -1,

    init: function (year, month) {
        if (typeof year == 'undefined' || typeof month == 'undefined') {
            year = global.currYear;
            month = global.currMonth;
        }
        this.setYear(year);
        this.setMonth(month);
        this.showYearContent();
        this.showMonthContent();
    },
    show: function () {
        document.getElementById('dateSelectionDiv').style.display = 'block';
    },
    hide: function () {
        this.rollback();
        document.getElementById('dateSelectionDiv').style.display = 'none';
    },
    today: function () {
        var today = new Date();
        var year = today.getFullYear();
        var month = today.getMonth();

        if (this.currYear != year || this.currMonth != month) {
            if (this.tmpYear == year && this.tmpMonth == month) {
                this.rollback();
            } else {
                this.init(year, month);
                this.commit();
            }
        }
    },
    go: function () {
        if (this.currYear == this.tmpYear && this.currMonth == this.tmpMonth) {
            this.rollback();
        } else {
            this.commit();
        }
        this.hide();
    },
    goToday: function () {
        this.today();
        this.hide();
    },
    goPrevMonth: function () {
        this.prevMonth();
        this.commit();
    },
    goNextMonth: function () {
        this.nextMonth();
        this.commit();
    },
    goPrevYear: function () {
        this.prevYear();
        this.commit();
    },
    goNextYear: function () {
        this.nextYear();
        this.commit();
    },
    changeView: function () {
        global.currYear = this.currYear;
        global.currMonth = this.currMonth;
        clear();
        $("#nian").html(global.currYear);
        $("#yue").html(parseInt(global.currMonth) + 1);
        drawCld(global.currYear, global.currMonth);


    },
    commit: function () {
        if (this.tmpYear != -1 || this.tmpMonth != -1) {
            // 如果发生了变化
            if (this.currYear != this.tmpYear
                    || this.currMonth != this.tmpMonth) {
                // 执行某操作
                this.showYearContent();
                this.showMonthContent();
                this.changeView();


            }

            this.tmpYear = -1;
            this.tmpMonth = -1;
        }
    },
    rollback: function () {
        if (this.tmpYear != -1) {
            this.setYear(this.tmpYear);
        }
        if (this.tmpMonth != -1) {
            this.setMonth(this.tmpMonth);
        }
        this.tmpYear = -1;
        this.tmpMonth = -1;
        this.showYearContent();
        this.showMonthContent();
    },
    prevMonth: function () {
        var month = this.currMonth - 1;
        if (month == -1) {
            var year = this.currYear - 1;
            if (year >= this.minYear) {
                month = 11;
                this.setYear(year);
            } else {
                month = 0;
            }
        }
        this.setMonth(month);
    },
    nextMonth: function () {
        var month = this.currMonth + 1;
        if (month == 12) {
            var year = this.currYear + 1;
            if (year <= this.maxYear) {
                month = 0;
                this.setYear(year);
            } else {
                month = 11;
            }
        }
        this.setMonth(month);
    },
    prevYear: function () {
        var year = this.currYear - 1;
        if (year >= this.minYear) {
            this.setYear(year);
        }
    },
    nextYear: function () {
        var year = this.currYear + 1;
        if (year <= this.maxYear) {
            this.setYear(year);
        }
    },
    prevYearPage: function () {
        this.endYear = this.beginYear - 1;
        this.showYearContent(null, this.endYear);
    },
    nextYearPage: function () {
        this.beginYear = this.endYear + 1;
        this.showYearContent(this.beginYear, null);
    },
    selectYear: function () {//杨：select
        var selectY = $('select[@name="SY"] option[@selected]').text();
        this.setYear(selectY);
        this.commit();
    },
    selectMonth: function () {
        var selectM = $('select[@name="SM"] option[@selected]').text();
        this.setMonth(selectM - 1);
        this.commit();
    },
    setYear: function (value) {
        if (this.tmpYear == -1 && this.currYear != -1) {
            this.tmpYear = this.currYear;
        }
        $('#SY' + this.currYear).removeClass('curr');
        this.currYear = value;
        $('#SY' + this.currYear).addClass('curr');
    },
    setMonth: function (value) {
        if (this.tmpMonth == -1 && this.currMonth != -1) {
            this.tmpMonth = this.currMonth;
        }
        $('#SM' + this.currMonth).removeClass('curr');
        this.currMonth = value;
        $('#SM' + this.currMonth).addClass('curr');
    },
    showYearContent: function (beginYear, endYear) {
        if (!beginYear) {
            if (!endYear) {
                endYear = this.currYear + 1;
            }
            this.endYear = endYear;
            if (this.endYear > this.maxYear) {
                this.endYear = this.maxYear;
            }
            this.beginYear = this.endYear - 3;
            if (this.beginYear < this.minYear) {
                this.beginYear = this.minYear;
                this.endYear = this.beginYear + 3;
            }
        }
        if (!endYear) {
            if (!beginYear) {
                beginYear = this.currYear - 2;
            }
            this.beginYear = beginYear;
            if (this.beginYear < this.minYear) {
                this.beginYear = this.minYear;
            }
            this.endYear = this.beginYear + 3;
            if (this.endYear > this.maxYear) {
                this.endYear = this.maxYear;
                this.beginYear = this.endYear - 3;
            }
        }

        var s = '';
        for (var i = this.beginYear; i <= this.endYear; i++) {
            s += '<span id="SY' + i
                    + '" class="year" onclick="dateSelection.setYear(' + i
                    + ')">' + i + '</span>';
        }
        document.getElementById('yearListContent').innerHTML = s;
        $('#SY' + this.currYear).addClass('curr');
    },
    showMonthContent: function () {
        var s = '';
        for (var i = 0; i < 12; i++) {
            s += '<span id="SM' + i
                    + '" class="month" onclick="dateSelection.setMonth(' + i
                    + ')">' + (i + 1).toString() + '</span>';
        }
        document.getElementById('monthListContent').innerHTML = s;
        $('#SM' + this.currMonth).addClass('curr');
    },
    //根据节假日去相关的月份
    goHoliday: function (N) {
        this.setMonth(N);
        this.commit();
    }
};
function initRiliIndex() {
    var dateObj = new Date();
    global.currYear = dateObj.getFullYear();
    global.currMonth = dateObj.getMonth();

    dateSelection.init();

}