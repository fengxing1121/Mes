/**
 * 功能：判断一个字符串是否是键值对
 * 参数：
 *  @s，要判断的字符串
 * 返回值：如果是返回true,否则返回false。
 */
function isKeyValue(s) {
    var regKV = /\w+="((-)?\d+(.\d+)?)"/;
    return regKV.test(s);
};

/**
 * 功能：获取键值对的键
 * 参数：
 *  @s，键值对字符串
 * 返回值：键值对中的键。
 */
function getKey(s) {
    //分割
    var strArray = s.split("=");
    if (2 != strArray.length)
        return null;

    //键
    var key = s.match(/\w+/);
    if (null == key)
        return null;

    return key[0];
};

/**
 * 功能：获取键值对的值
 * 参数：
 *  @s，键值对字符串
 * 返回值：键值对中的值
 */
function getKeyValue(s) {
    //分割
    var strArray = s.split("=");
    if (2 != strArray.length)
        return null;

    var kv = new Object();

    //键
    var key = strArray[0].match(/\w+/);
    if (null == key)
        return null;

    //值
    var value = strArray[1].match(arguments[1] ? arguments[1] : /((-)?\d+(.\d+)?)/);
    if (null == value)
        return null;

    kv.key = key[0];
    kv.value = value[0];
    return kv;
};

/**
 * 功能：附加当前字符串并换行
 * 参数:
 *  @s，附加的字符串
 * 返回值：当前字符串和换行字符串组成的新字符串
 */
function appendLine(s) {
    return s + ("\r\n");
};

/**
 * 功能：是否以测试的字符串开始
 * 参数：
 *  @str，当前的字符串
 *  @strTest，待测试的字符串
 * 返回值：如果是则返回true，否则返回false。
 */
function isStartWith(s, strTest) {
    return (0 == s.indexOf(strTest));
};

/**
 * 功能：用于判断当前行是否是新的对象
 * 参数：
 *  @s，行字符串
 * 返回值：如果是返回true，否则返回false。
 */
function isNewEntity(s) {
    return (isStartWith(s, "[") || isStartWith(s, "<"));
};

/**
 * 功能：字符串生成面板对象
 * 参数：
 *  @text，mpr内容字符串
 * 返回值：面板对象
 */
function toPanel(text) {
    panel = new Panel();  //面板
    lines = text.split("\n");

    var bEntityLine = false;  //是否是实体行
    for (var i = 0; i < lines.length;) {
        var str = lines[i];

        //解析然后生成PDX
        if (isStartWith(str, "[001")) {
            //参数定义
            bEntityLine = true;

            while (++i < lines.length) {
                //如果是新的实体则跳出
                if (isNewEntity(lines[i])) break;

                //读取里面的参数的参数值
                var kv = getKeyValue(lines[i]);
                if (null != kv) {
                    var param = new Param();
                    param.key = kv.key;
                    param.value = kv.value;
                    param.describe = ('');  //忽略

                    //记录起来
                    panel.params.push(param);
                };
            };
        }
        else if (isStartWith(str, "<100")) {
            bEntityLine = true;
            while (++i < lines.length) {
                if (isNewEntity(lines[i])) break;

                var kv = getKeyValue(lines[i], /((-)?\d+(.\d+)?)|\w+/);
                if (null != kv) {
                    if ("LA" == kv.key) {
                        panel.strLength = kv.value;
                    }
                    else if ("BR" == kv.key) {
                        panel.strWidth = kv.value;
                    }
                    else if ("DI" == kv.key) {
                        panel.strThickness = kv.value;
                    };
                };
            };
        }
        else if (isStartWith(str, "<102")) {
            //垂直孔
            bEntityLine = true;
            var hole = new Hole();
            hole.dir = "z-";  //正面垂直孔

            while (++i < lines.length) {
                //如果是新的实体则跳出
                if (isNewEntity(lines[i])) break;

                //读取里面的参数的参数值
                var kv = getKeyValue(lines[i]);
                if (null != kv) {
                    //记录起来
                    if ("XA" == kv.key) {
                        hole.strX = kv.value;
                    }
                    else if ("YA" == kv.key) {
                        hole.strY = kv.value;
                    }
                    else if ("TI" == kv.key) {
                        hole.strDepth = kv.value;
                    }
                    else if ("DU" == kv.key) {
                        hole.strDiam = kv.value;
                    };
                };
            };
            panel.holes.push(hole);
        }
        else if (isStartWith(str, "<103")) {
            //水平孔
            bEntityLine = true;
            var hole = new Hole();

            while (++i < lines.length) {
                //如果是新的实体则跳出
                if (isNewEntity(lines[i])) break;

                //读取里面的参数的参数值
                var kv = getKeyValue(lines[i]);
                if (null != kv) {
                    //记录起来
                    if ("XA" == kv.key) {
                        hole.x = kv.value;
                    }
                    else if ("YA" == kv.key) {
                        hole.y = kv.value;
                    }
                    else if ("ZA" == kv.key) {
                        hole.z = kv.value;
                    };
                };
            };

            //添加到对象
            panel.holes.push(hole);
        }
        else if (isStartWith(str, "<105")) {
            //铣槽
            bEntityLine = true;

            while (++i < lines.length) {
                //如果是新的实体则跳出
                if (isNewEntity(lines[i])) break;
            }
        }
        else if (isStartWith(str, "<109")) {
            //锯槽
            bEntityLine = true;

            while (++i < lines.length) {
                //如果是新的实体则跳出
                if (isNewEntity(obj[i])) break;
            };
        }
        else {
            //忽略
            bEntityLine = false;
        }

        if (!bEntityLine)++i;  //如果不是实体行则读取下一行
        if (i >= lines.length) break;  //如果结束则跳出
    };
    return panel;
};