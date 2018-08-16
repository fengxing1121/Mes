using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Mes.Client.Utility
{
    public static class StaticFunction
    {
        public static string getNameLenth(string s, int i)
        {
            int intResult = 0;
            int j = 0;
            string s1 = s;
            if (GetStrLen(s) > i)
            {
                foreach (char Char in s)
                {
                    if (intResult < i)
                    {
                        j++;
                        if ((int)Char > 127)
                            intResult = intResult + 2;
                        else
                            intResult++;
                    }
                    else
                        break;
                }
                s1 = s.Substring(0, j);
            }
            else
            {
                return s1;
            }
            return s1 + "...";
        }
        public static int GetStrLen(string strData)
        {
            System.Text.Encoding encoder5 = System.Text.Encoding.GetEncoding("GB2312");
            return encoder5.GetByteCount(strData);
        }


        #region 得到IP地址
        /// <summary>
        /// 得到IP地址
        /// 创建者：小劉   时间：2011-1-19
        /// 修改者：         时间：
        /// </summary>
        /// <returns>IP地址</returns>
        public static string GetIP()
        {
            string reIp = "";
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null || System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().IndexOf("unknown") > -1)
            {
                reIp = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().IndexOf(",") > -1)
            {
                reIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") - 1);
            }
            else if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().IndexOf(";") > -1)
            {
                reIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(":") - 1);
            }
            else
            {
                reIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            if (reIp.Length > 30)
            {
                reIp = reIp.Trim().Substring(0, 29);
            }
            else
            {
                reIp = reIp.Trim();
            }
            return reIp;
        }
        #endregion

        #region IP地址轉换长整型
        /// <summary>
        /// 得到IP地址
        /// 创建者：小劉   时间：2011-1-19
        /// 修改者：         时间：
        /// </summary>
        /// <returns>IP地址</returns>
        public static long IPtoLong(string _strip)
        {
            long Ip = 0;
            string[] addressIP = _strip.Split('.');
            if (addressIP.Length == 4)
            {
                Ip = Convert.ToUInt32(addressIP[0]) * 256 * 256 * 256 + Convert.ToUInt32(addressIP[1]) * 256 * 256 + Convert.ToUInt32(addressIP[2]) * 256 + Convert.ToUInt32(addressIP[3]);
            }
            return Ip;
        }
        #endregion

        #region IP地址获取地理位置
        /// <summary>
        /// IP地址地理位置
        /// 创建者：劉   时间：2011-1-19
        /// 修改者：         时间：
        /// </summary>
        /// <param name="_strip">IP地址</param>
        /// <returns>地理位置</returns>
        //public static string getIPArea(string _strip)
        //{
        //    if ((_strip.Split('.')[0] == "192" && _strip.Split('.')[1] == "168") || _strip == "127.0.0.1")
        //        return "本地局域網";
        //    else
        //    {
        //        long Ip = IPtoLong(_strip);
        //        return getIPArea(Ip);
        //    }
        //}
        /// <summary>
        /// IP地址地理位置
        /// 创建者：袁纯林   时间：2011-1-19
        /// 修改者：         时间：
        /// </summary>
        /// <param name="_longip">IP地址长整型</param>
        /// <returns>地理位置</returns>
        /// 
        //public static string getIPArea(long _longip)
        //{
        //    string tempstr = "";
        //Database db = new Database("Info_sel_sp", "IPTOAREA", 0, 0, _longip, "", "");

        //SqlDataReader dr = db.ExecuteReader();
        //if (dr.Read())
        //{
        //    tempstr = dr["country"].ToString() + dr["city"].ToString();
        //}
        //DataTable dtData = StoreProcedureTongji.ExecuteDataTable("Info_sel_sp", "IPTOAREA", 0, 0, _longip, "", "");
        //if (dtData.Rows.Count > 0)
        //{
        //    tempstr = dtData.Rows[0]["country"].ToString() + dtData.Rows[0]["city"].ToString();
        //}
        //return tempstr;
        //}
        #endregion

        #region 将纯文本内容轉换成HTML格式内容

        /// <summary>
        /// 将纯文本内容轉换成HTML格式内容
        /// 创建者：小劉   时间：2011-3-4
        /// 修改者：         时间： 
        /// </summary>
        /// <param name="s">需要轉换的文本</param>
        /// <returns>轉换后的文本</returns>
        public static string TxtToHtml(string s)
        {
            if (s != null)
            {
                s = s.Replace("  ", "&nbsp;&nbsp;");
                s = s.Replace("\r\n", "<br>");
            }
            else
                s = "";
            return s;
        }

        #endregion


        #region 切割字符串

        /// <summary>
        /// 切割字符串
        /// 创建者：小劉   时间：2011-3-4
        /// 修改者：         时间： 
        /// </summary>
        /// <param name="s">需要切割的字符串</param>
        /// <param name="i">需要切割的字符串长度</param>
        /// <param name="smore">切割后字符串后面添加的字符串</param>
        /// <returns></returns>
        public static string SubStr(string s, int i, string smore)
        {
            int intResult = 0;
            int j = 0;
            string s1 = s;
            if (GetStrLen(s) > i)
            {
                foreach (char Char in s)
                {
                    if (intResult < i)
                    {
                        j++;
                        if ((int)Char > 127)
                            intResult = intResult + 2;
                        else
                            intResult++;
                    }
                    else
                        break;
                }
                s1 = s.Substring(0, j);
            }
            else
            {
                return s1;
            }
            return s1 + smore;
        }

        #endregion

        #region 判断是否是数字，放回BOOL
        /// <summary>
        /// 判断是否是数字，放回BOOL
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isnumeric(string str)
        {
            char[] ch = new char[str.Length];
            ch = str.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] < 48 || ch[i] > 57)
                    return false;
            }
            return true;
        }
        #endregion


        #region 判断字符串是否数字组成，不是则返回0
        public static int Cint(string str)
        {
            if (str == null || str == "")
                return 0;
            string sChar = "";
            string sNum = "0123456789";
            for (int i = 0; i < str.Length; i++)
            {
                sChar = str.Substring(i, 1);
                if (sNum.IndexOf(sChar) == -1)
                {
                    return 0;
                }
            }
            return Convert.ToInt32(str);
        }
        #endregion

        /// <summary>
        /// 验证Email格式
        /// 创建者：小劉   时间：2009-2-18
        /// </summary>
        /// <param name="source">要验证的邮件号码</param>
        /// <returns>bool值（true/fals）</returns>     

        #region  验证Email格式

        public static bool IsEmail(string source)
        {
            return Regex.IsMatch(source, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        }

        #endregion

        /// <summary>
        ///验证手机号
        /// 创建者：小劉   时间：2009-2-18
        /// </summary>
        /// <param name="source">要验证的手机号  </param>
        /// <returns>bool值（true/fals）</returns>   
        #region 验证手机号
        public static bool IsMobile(string source)
        {
            return Regex.IsMatch(source, @"^1[35]\d{9}$", RegexOptions.IgnoreCase);
        }

        #endregion



        #region 是不是中国电话，格式010-85849685
        /// <summary>
        ///  创建者：小劉   时间：2009-2-18
        /// 是不是中国电话，格式010-85849685
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsTel(string source)
        {
            return Regex.IsMatch(source, @"^\d{3,4}-?\d{6,8}$", RegexOptions.IgnoreCase);
        }
        #endregion


        #region 清除查询字符串的危险字符
        /// <summary>
        /// 清除查询字符串的危险字符
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string CheckSql(string sql)
        {
            string reSql = "";
            if (sql == null)
            {
                return reSql;
            }
            else
            {
                reSql = sql;
                reSql = reSql.ToLower().Replace("\"", "&quot;");
                reSql = reSql.ToLower().Replace("<", "&lt;");
                reSql = reSql.ToLower().Replace(">", "&gt;");
                reSql = reSql.Replace("script", "&#115;cript");
                reSql = reSql.Replace("SCRIPT", "&#083;CRIPT");
                reSql = reSql.Replace("Script", "&#083;cript");
                reSql = reSql.Replace("script", "&#083;cript");
                reSql = reSql.Replace("object", "&#111;bject");
                reSql = reSql.Replace("OBJECT", "&#079;BJECT");
                reSql = reSql.Replace("Object", "&#079;bject");
                reSql = reSql.Replace("object", "&#079;bject");
                reSql = reSql.Replace("applet", "&#097;pplet");
                reSql = reSql.Replace("APPLET", "&#065;PPLET");
                reSql = reSql.Replace("Applet", "&#065;pplet");
                reSql = reSql.Replace("applet", "&#065;pplet");
                reSql = reSql.ToLower().Replace("[", "&#091;");
                reSql = reSql.ToLower().Replace("]", "&#093;");
                reSql = reSql.ToLower().Replace("=", "&#061;");
                reSql = reSql.ToLower().Replace("'", "''");
                reSql = reSql.ToLower().Replace("select", "select");
                reSql = reSql.ToLower().Replace("execute", "&#101xecute");
                reSql = reSql.ToLower().Replace("exec", "&#101xec");
                reSql = reSql.ToLower().Replace("join", "join");
                reSql = reSql.ToLower().Replace("union", "union");
                reSql = reSql.ToLower().Replace("where", "where");
                reSql = reSql.ToLower().Replace("insert", "insert");
                reSql = reSql.ToLower().Replace("delete", "delete");
                reSql = reSql.ToLower().Replace("update", "update");
                reSql = reSql.ToLower().Replace("like", "like");
                reSql = reSql.ToLower().Replace("drop", "drop");
                reSql = reSql.ToLower().Replace("create", "create");
                reSql = reSql.ToLower().Replace("rename", "rename");
                reSql = reSql.ToLower().Replace("count", "co&#117;nt");
                reSql = reSql.ToLower().Replace("chr", "c&#104;r");
                reSql = reSql.ToLower().Replace("mid", "m&#105;d");
                reSql = reSql.ToLower().Replace("truncate", "trunc&#097;te");
                reSql = reSql.ToLower().Replace("nchar", "nch&#097;r");
                reSql = reSql.ToLower().Replace("char", "ch&#097;r");
                reSql = reSql.ToLower().Replace("alter", "alter");
                reSql = reSql.ToLower().Replace("cast", "cast");
                reSql = reSql.ToLower().Replace("exists", "e&#120;ists");
                reSql = reSql.ToLower().Replace("\n", "<br>");
                return reSql;
            }
        }
        #endregion

        #region 格式化标题
        public static string FormatTitle(string title, int len)
        {
            return SubStr(title, len, "");
        }
        #endregion

        //过滤html
        public static string NoHtml(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }
        //设置cookies
        public static bool SetCookies(string mainName, string mainValue, int days)
        {
            try
            {
                string Main = HttpUtility.UrlEncode(mainValue);
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[mainName];
                if (cookie == null)
                {
                    cookie = new HttpCookie(mainName, Main);
                }
                else
                {
                    cookie.Value = Main;
                }
                cookie.Expires = DateTime.Now.AddDays(days);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="mainName">主键</param>
        /// <returns></returns>
        public static string GetCookies(string mainName)
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[mainName];
            if (cookie != null)
            {
                return HttpUtility.UrlDecode(cookie.Value);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除Cookies
        /// </summary>
        /// <param name="mainName"></param>
        public static bool DelCookies(string mainName)
        {
            try
            {
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[mainName];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //16位MD5加密（取32位加密的9~25字符）
        public static string md5(string str, int code)
        {
            if (code == 16) //16位MD5加密（取32位加密的9~25字符）
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
            }
            else//32位加密
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }
        }

        /// <summary>
        /// 执行DataTable中的查询返回新的DataTable
        /// </summary>
        /// <param name="dt">源数据DataTable</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//返回的查询结果
        }



        internal static string getConn(int p)
        {
            throw new NotImplementedException();
        }

        public static DataTable ConvertDataReaderToDataTable(SqlDataReader reader)
        {
            try
            {
                DataTable objDataTable = new DataTable();
                int intFieldCount = reader.FieldCount;
                for (int intCounter = 0; intCounter < intFieldCount; ++intCounter)
                {
                    objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter));
                }

                objDataTable.BeginLoadData();

                object[] objValues = new object[intFieldCount];
                while (reader.Read())
                {
                    reader.GetValues(objValues);
                    objDataTable.LoadDataRow(objValues, true);
                }
                reader.Close();
                objDataTable.EndLoadData();

                return objDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception("转换出错!", ex);
            }

        }
    }
}
