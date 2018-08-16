using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Data.Common;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace Mes.Client.Utility
{
    public class JSONHelper
    {
        /// <summary>
        /// 类对像转换成json格式
        /// </summary> 
        /// <returns></returns>
        public static string ToJson(object t)
        {
            return StringToJson.ToJson(t);
        }

        /// <summary>
        /// List<T>转换成DataSet Json:{total:*,rows:[]}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string List2DataSetJson<T>(List<T> t)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            if (t == null)
            {
                jsonBuilder.Append("\"total\":0,");
                jsonBuilder.Append("\"rows\":[],");
                jsonBuilder.Append("\"footer\":[]");
            }
            else
            {
                jsonBuilder.Append("\"total\":" + t.Count + ",");
                string json = ToJson(t);
                jsonBuilder.Append("\"rows\":" + json);
                jsonBuilder.Append(",\"footer\":[{\"Total\":" + t.Count + "}]");
            }
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// 对象转换成DataSet Json {total:*,rows:[]}
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Object2DataSetJson(object t)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            if (t == null)
            {
                jsonBuilder.Append("\"total\":0,");
                jsonBuilder.Append("\"rows\":[]");
                jsonBuilder.Append(",\"footer\":[]");
            }
            else
            {
                string json = "";
                if (t is IList)
                {
                    jsonBuilder.Append("\"total\":" + (t as IList).Count + ",");
                    json = ToJson(t);
                }
                else if (t is DataTable)
                {
                    jsonBuilder.Append("\"total\":" + (t as DataTable).Rows.Count + ",");
                    json = DataTableToJSON(t as DataTable);
                }
                else
                {
                    jsonBuilder.Append("\"total\":0,");
                    json = ToJson(t);
                }

                jsonBuilder.Append("\"rows\":" + json + "");
                jsonBuilder.Append(",\"footer\":[{\"Total\":0}]");
            }

            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }


        /// <summary>
        /// json格式转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T FromJson<T>(string strJson) where T : class
        {
            return new JavaScriptSerializer().Deserialize<T>(strJson);
        }


        /// <summary> 
        /// 对象转JSON 
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string Object2JSON(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.ObjectToJSON(): " + ex.Message);
            }
        }
        /// <summary> 
        /// 数据表转键值对集合 
        /// 把DataTable转成 List集合, 存每一行 
        /// 集合中放的是键值对字典,存每一列 
        /// </summary> 
        /// <param name="dt">数据表</param> 
        /// <returns>哈希表数组</returns> 
        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list
            = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType == typeof(DateTime))
                        dic.Add(dc.ColumnName, dr[dc.ColumnName].ToString());
                    else
                        dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }
        /// <summary> 
        /// 数据集转键值对数组字典 
        /// </summary> 
        /// <param name="dataSet">数据集</param> 
        /// <returns>键值对数组字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> DataSetToDic(DataSet ds)
        {
            Dictionary<string, List<Dictionary<string, object>>> result = new Dictionary<string, List<Dictionary<string, object>>>();
            foreach (DataTable dt in ds.Tables)
                result.Add(dt.TableName, DataTableToList(dt));
            return result;
        }
        /// <summary> 
        /// 数据表转JSON 
        /// </summary> 
        /// <param name="dataTable">数据表</param> 
        /// <returns>JSON字符串</returns> 
        public static string DataTableToJSON(DataTable dt)
        {
            return ToJson(DataTableToList(dt));
        }
        /// <summary> 
        /// JSON文本转对象,泛型方法 
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        public static T JSONToObject<T>(string jsonText)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
            }
        }
        /// <summary> 
        /// 将JSON文本转换为数据表数据 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据表字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> TablesDataFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonText);
        }
        /// <summary> 
        /// 将JSON文本转换成数据行 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据行的字典</returns> 
        public static Dictionary<string, object> DataRowFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, object>>(jsonText);
        }

        /// <summary>
        /// DataTable到Json转换
        /// {jsonName:[{},{}]}
        /// </summary>
        /// <param name="jsonName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(string jsonName, DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + stringToJson(dt.Rows[i][j].ToString()) + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            jsonBuilder.Append(",");
                        }
                    }
                    jsonBuilder.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
            }
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// ComboxJson
        /// [{id:0,text:''},{id:0,text:'']
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="idF"></param>
        /// <param name="textF"></param>
        /// <returns></returns>
        public static string DataTable2ComboxJson(DataTable dt, string idF, string textF)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                jsonBuilder.Append("{");
                jsonBuilder.AppendFormat("\"value\":\"{0}\"", row[idF].ToString());
                jsonBuilder.Append(",");
                jsonBuilder.AppendFormat("\"text\":\"{0}\"", stringToJson(row[textF].ToString()));
                jsonBuilder.Append("}");
                if (i != dt.Rows.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]");

            return jsonBuilder.ToString();
        }


        /// <summary>
        /// 对象序列号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Object2Json(object obj)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            PropertyInfo[] pis = obj.GetType().GetProperties();
            jsonBuilder.Append("{");
            for (int i = 0; i < pis.Length; i++)
            {
                PropertyInfo pi = pis[i];
                object piValue = pi.GetValue(obj, null);
                if (pi.PropertyType.FullName.IndexOf("DateTime") >= 0)
                {
                    jsonBuilder.AppendFormat("\"{0}\":\"{1:yyyy-MM-dd hh:mm:ss}\"", pi.Name, stringToJson(piValue == null ? "" : piValue.ToString()));
                    //if (piValue != null)
                    //{
                    //    piValue = Convert.ToDateTime(piValue).ToString("yyyy-MM-dd hh:mm:ss");

                    //}
                    //jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", pi.Name, stringToJson(piValue == null ? "" : piValue.ToString()));
                }
                else if (pi.PropertyType.FullName.IndexOf("Decimal") >= 0)
                {
                    jsonBuilder.AppendFormat("\"{0}\":\"{1:0.00}\"", pi.Name, stringToJson(piValue == null ? "" : piValue.ToString()));
                }
                else
                {
                    jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", pi.Name, stringToJson(piValue == null ? "" : piValue.ToString()));
                }
                if (i < pis.Length - 1)
                {
                    jsonBuilder.AppendFormat(",");
                }
            }
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// 对象反序列号
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object Json2Object(string strJson, Type myType)
        {
            object result = Activator.CreateInstance(myType, null);
            Hashtable jsonHT = new Hashtable();
            string[] keyValuePairs = strJson.Trim('{').Trim('}').Split(',');
            for (int i = 0; i < keyValuePairs.Length; i++)
            {
                string[] keyValues = keyValuePairs[i].Split(new string[] { "\":\"" }, StringSplitOptions.None);
                jsonHT.Add(keyValues[0].Trim('"'), keyValues[1].Trim('"'));
            }
            foreach (PropertyInfo pi in myType.GetProperties())
            {
                try
                {
                    string s = jsonHT[pi.Name].ToString();
                    if (pi.PropertyType.FullName.IndexOf("Int32") >= 0)
                    {
                        pi.SetValue(result, Int32.Parse(s), null);
                    }
                    else if (pi.PropertyType.FullName.IndexOf("Decimal") >= 0)
                    {
                        pi.SetValue(result, Decimal.Parse(s), null);
                    }
                    else if (pi.PropertyType.FullName.IndexOf("DateTime") >= 0)
                    {
                        pi.SetValue(result, DateTime.Parse(s), null);
                    }
                    else
                    {
                        pi.SetValue(result, s, null);
                    }
                }
                catch { }
            }
            return result;
        }
        /// <summary>
        /// List转成json
        /// {name:[{},{}]}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonName"></param>
        /// <param name="IL"></param>
        /// <returns></returns>
        public static string ObjectToJson<T>(string jsonName, IList<T> IL)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"{0}\":[", jsonName);
            if (IL.Count > 0)
            {
                for (int i = 0; i < IL.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    Type type = obj.GetType();
                    PropertyInfo[] pis = type.GetProperties();
                    jsonBuilder.Append("{");
                    for (int j = 0; j < pis.Length; j++)
                    {
                        jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", pis[j].Name.ToString(), pis[j].GetValue(IL[i], null));
                        if (j < pis.Length - 1)
                        {
                            jsonBuilder.Append(",");
                        }
                    }
                    jsonBuilder.Append("}");
                    if (i < IL.Count - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
            }
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// DataTable转换为Json
        /// rows:[{列名1: 值1,列名2: 值2},{列名1: 值1,列名2: 值2}]
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static void DataTable2Json(DataTable dt, StringBuilder jsonBuilder)
        {
            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            jsonBuilder.Append("\"rows\":[");
            for (int i = 0; i < rowCount; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < colCount; j++)
                {
                    switch (dt.Columns[j].DataType.Name)
                    {
                        case "DateTime":
                            jsonBuilder.AppendFormat("\"{0}\":\"{1:yyyy-MM-dd HH:mm:ss}\"", dt.Columns[j].ColumnName, dt.Rows[i][j]);
                            break;
                        case "Decimal":
                            jsonBuilder.AppendFormat("\"{0}\":\"{1:0.00}\"", dt.Columns[j].ColumnName, dt.Rows[i][j]);
                            break;
                        default:
                            jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", dt.Columns[j].ColumnName, stringToJson(dt.Rows[i][j].ToString()));
                            break;
                    }
                    if (j < colCount - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
                jsonBuilder.Append("}");
                if (i < rowCount - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]");
        }

        /// <summary>
        /// 获取Menu数据Json
        /// {
        /// menus:[{
        ///     menuid:0,
        ///     menuname:'',
        ///     url:'',
        ///     icon:'',
        ///     menus:[{}]
        ///  }]
        ///  }
        /// </summary>
        /// <param name="idF"></param>
        /// <param name="textF"></param>
        /// <param name="parenidF"></param>
        /// <param name="parentID"></param>
        /// <param name="dt"></param>
        /// <param name="RootFlag">是否留根</param>
        /// <returns></returns>
        public static string DataTableMenuJson(string idF, string textF, string urlF, DataTable dt, int RootFlag)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            int colCount = dt.Columns.Count;
            jsonBuilder.Append("{\"menus\":[");
            if (RootFlag == 1)
            {

                int rowCount = dt.Rows.Count;

                for (int i = 0; i < rowCount; i++)
                {
                    jsonBuilder.Append("{");
                    DataRow row = dt.Rows[i];
                    jsonBuilder.AppendFormat("\"menuid\":{0},", row[idF]);
                    jsonBuilder.AppendFormat("\"menuname\":\"{0}\",", row[textF]);
                    jsonBuilder.AppendFormat("\"url\":\"{0}\",", row[urlF]);
                    jsonBuilder.AppendFormat("\"icon\":\"{0}\"", "icon-sys");
                    if (i != rowCount - 1)
                    {
                        jsonBuilder.Append("},");
                    }
                    else
                    {
                        jsonBuilder.Append("}");
                    }


                }
            }


            jsonBuilder.Append("]}");

            return jsonBuilder.ToString();
        }
        /// <summary>
        /// 获取Menu数据Json
        /// {
        /// menus:[{
        ///     menuid:0,
        ///     menuname:'',
        ///     url:'',
        ///     icon:'',
        ///     menus:[{}]
        ///  }]
        ///  }
        /// </summary>
        /// <param name="idF"></param>
        /// <param name="textF"></param>
        /// <param name="parenidF"></param>
        /// <param name="parentID"></param>
        /// <param name="dt"></param>
        /// <param name="RootFlag">是否留根</param>
        /// <returns></returns>
        public static string DataTable2MenuJson(string idF, string textF, string urlF, string parenidF, object parentID, DataTable dt, int RootFlag)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            int colCount = dt.Columns.Count;
            jsonBuilder.Append("{menus:");
            if (RootFlag == 1)
            {
                jsonBuilder.Append("[{");
                DataRow[] rows = dt.Select(string.Format(" {0}={1} ", parenidF, parentID));
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    jsonBuilder.AppendFormat("\"menuid\":{0},", row[idF]);
                    jsonBuilder.AppendFormat("\"menuname\":\"{0}\",", row[textF]);
                    jsonBuilder.AppendFormat("\"url\":\"{0}\",", row[urlF]);
                    if (row["ChildCount"].ToString() != "0")
                    {
                        jsonBuilder.AppendFormat("\"icon\":\"{0}\",", "icon-sys");
                        jsonBuilder.AppendFormat("\"menus\":");
                    }
                    else
                    {
                        jsonBuilder.AppendFormat("\"icon\":\"{0}\",", "icon-nav");
                    }
                }
                else
                {
                    jsonBuilder.AppendFormat("\"menuid\":0,\"menuname\":\"根\",\"menus\":");
                }
            }
            GetMenuChildNodes(idF, textF, urlF, parenidF, parentID, dt, jsonBuilder);
            if (RootFlag == 1)
            {
                jsonBuilder.Append("}]");
            }
            jsonBuilder.Append("}");

            return jsonBuilder.ToString();
        }
        public static void GetMenuChildNodes(string idF, string textF, string urlF, string parenidF, object parentID, DataTable dt, StringBuilder jsonBuilder)
        {
            DataRow[] rows = dt.Select(string.Format(" {0}={1} ", parenidF, parentID));
            int colCount = dt.Columns.Count;
            int rowCount = rows.Length;
            jsonBuilder.Append("[");
            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = rows[i];
                jsonBuilder.Append("{");
                jsonBuilder.AppendFormat("\"menuid\":{0},", row[idF]);
                jsonBuilder.AppendFormat("\"menuname\":\"{0}\",", row[textF]);
                jsonBuilder.AppendFormat("\"url\":\"{0}\",", row[urlF]);
                if (row["ChildCount"].ToString() != "0")
                {
                    jsonBuilder.AppendFormat("\"icon\":\"{0}\",", "icon-sys");
                    jsonBuilder.AppendFormat("\"menus\":");
                    GetMenuChildNodes(idF, textF, urlF, parenidF, Convert.ToInt32(row[idF]), dt, jsonBuilder);
                }
                else
                {
                    jsonBuilder.AppendFormat("\"icon\":\"{0}\"", "icon-nav");
                }
                jsonBuilder.Append("}");
                if (i != rowCount - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]");
        }

        /// <summary>
        /// 获取树数据Json
        /// [{
        /// id:0,
        /// text:'',
        /// iconCls:'',
        /// attributes:'',
        /// state:''
        /// children:[{}]
        /// }]
        /// </summary>
        /// <param name="idF"></param>
        /// <param name="textF"></param>
        /// <param name="dt"></param>
        /// <param name="RootFlag">是否留根</param>
        /// <returns></returns>
        public static string DataTable2TreeJson(string idF, string textF, DataTable dt, string Treename)
        {
            StringBuilder jsonBuilder = new StringBuilder();


            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            jsonBuilder.Append("[");
            for (int j = 0; j < rowCount; j++)
            {
                jsonBuilder.Append("{");
                DataRow row = dt.Rows[j];
                jsonBuilder.AppendFormat("\"id\":\"{0}\"", row[idF]);
                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", row[textF]);
                jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", false);
                jsonBuilder.Append(",\"attributes\":{");
                for (int i = 0; i < colCount; i++)
                {
                    DataColumn col = dt.Columns[i];
                    jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", col.ColumnName, stringToJson(row == null ? "" : row[col.ColumnName].ToString()));
                    if (i < colCount - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
                jsonBuilder.Append("}}");
                if (j < rowCount - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// 获取树数据Json
        /// [{
        /// id:0,
        /// text:'',
        /// iconCls:'',
        /// attributes:'',
        /// state:''
        /// children:[{}]
        /// }]
        /// </summary>
        /// <param name="idF"></param>
        /// <param name="textF"></param>
        /// <param name="parenidF"></param>
        /// <param name="parentID"></param>
        /// <param name="dt"></param>
        /// <param name="RootFlag">是否留根</param>
        /// <returns></returns>
        public static string DataTable2TreeJson(string idF, string textF, string parenidF, object parentID, DataTable dt, int RootFlag)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            if (RootFlag == 1)
            {
                int colCount = dt.Columns.Count;
                jsonBuilder.Append("[{");
                DataRow[] rows = dt.Select(string.Format(" {0}={1} ", idF, parentID));
                DataRow row = rows[0];
                jsonBuilder.AppendFormat("\"id\":\"{0}\"", row[idF]);
                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", row[textF]);
                jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", row["IsChecked"]);
                jsonBuilder.Append(",\"attributes\":{");
                for (int j = 0; j < colCount; j++)
                {
                    DataColumn col = dt.Columns[j];
                    jsonBuilder.AppendFormat("\"{0}\":\"{1}\",", col.ColumnName, stringToJson(row[j] == null ? "" : row[col.ColumnName].ToString()));
                    if (j < colCount - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
                jsonBuilder.Append("}");
                DataRow[] childRows = dt.Select(string.Format(" {0}='{1}' ", parenidF, row[idF]));
                if (childRows.Length > 0)
                {
                    jsonBuilder.AppendFormat(",\"children\":");
                }

                GetTreeChildNodes(idF, textF, parenidF, parentID, dt, jsonBuilder);

                jsonBuilder.Append("}]");
            }
            else
            {
                GetTreeChildNodes(idF, textF, parenidF, parentID, dt, jsonBuilder);
            }

            return jsonBuilder.ToString();
        }
        public static string DataTable2TreeJson(string idF, string textF, string checkedF, string parenidF, object parentID, DataTable dt, int RootFlag)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            if (RootFlag == 1)
            {
                int colCount = dt.Columns.Count;
                jsonBuilder.Append("[{");
                DataRow[] rows = dt.Select(string.Format(" {0}='{1}' ", idF, parentID));
                DataRow row = rows[0];
                jsonBuilder.AppendFormat("\"id\":\"{0}\"", row[idF]);
                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", row[textF]);
                jsonBuilder.AppendFormat(",\"checked\":{0}", row[checkedF]);
                jsonBuilder.Append(",\"attributes\":{");
                for (int j = 0; j < colCount; j++)
                {
                    DataColumn col = dt.Columns[j];
                    jsonBuilder.AppendFormat("\"{0}\":\"{1}\",", col.ColumnName, stringToJson(row[j] == null ? "" : row[col.ColumnName].ToString()));
                    if (j < colCount - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
                jsonBuilder.Append("}");
                DataRow[] childRows = dt.Select(string.Format(" {0}='{1}' ", parenidF, row[idF]));
                if (childRows.Length > 0)
                {
                    jsonBuilder.AppendFormat(",\"children\":");
                }

                GetTreeChildNodes(idF, textF, parenidF, parentID, dt, jsonBuilder);

                jsonBuilder.Append("}]");
            }
            else
            {
                GetTreeChildNodes(idF, textF, checkedF, parenidF, parentID, dt, jsonBuilder);
            }

            return jsonBuilder.ToString();
        }
        /// <summary>
        /// [{
        /// id:0,
        /// text:'',
        /// iconCls:'',
        /// attributes:'',
        /// state:''
        /// children:[{}]
        /// }]
        /// </summary>
        /// <param name="idF"></param>
        /// <param name="textF"></param>
        /// <param name="parenidF"></param>
        /// <param name="parentID"></param>
        /// <param name="dt"></param>
        /// <param name="jsonBuilder"></param>
        public static void GetTreeChildNodes(string idF, string textF, string parenidF, object parentID, DataTable dt, StringBuilder jsonBuilder)
        {
            DataRow[] rows = dt.Select(string.Format(" {0}='{1}' ", parenidF, parentID));
            int colCount = dt.Columns.Count;
            int rowCount = rows.Length;
            jsonBuilder.Append("[");
            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = rows[i];
                jsonBuilder.Append("{");
                jsonBuilder.AppendFormat("\"id\":\"{0}\"", row[idF]);
                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", row[textF]);
                jsonBuilder.Append(",\"attributes\":{");
                for (int j = 0; j < colCount; j++)
                {
                    DataColumn col = dt.Columns[j];
                    jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", col.ColumnName, stringToJson(row[j] == null ? "" : row[col.ColumnName].ToString()));
                    if (j < colCount - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
                jsonBuilder.Append("}");
                DataRow[] childRows = dt.Select(string.Format(" {0}='{1}' ", parenidF, row[idF]));
                if (childRows.Length > 0)
                {
                    jsonBuilder.AppendFormat(",\"children\":");
                    GetTreeChildNodes(idF, textF, parenidF, row[idF].ToString(), dt, jsonBuilder);
                }
                jsonBuilder.Append("}");
                if (i < rowCount - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]");
        }
        public static void GetTreeChildNodes(string idF, string textF, string checkedF, string parenidF, object parentID, DataTable dt, StringBuilder jsonBuilder)
        {
            DataRow[] rows = dt.Select(string.Format(" {0}='{1}' ", parenidF, parentID));
            int colCount = dt.Columns.Count;
            int rowCount = rows.Length;
            jsonBuilder.Append("[");
            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = rows[i];
                jsonBuilder.Append("{");
                jsonBuilder.AppendFormat("\"id\":\"{0}\"", row[idF]);
                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", row[textF]);
                jsonBuilder.AppendFormat(",\"checked\":{0}", row[checkedF]);
                jsonBuilder.Append(",\"attributes\":{");
                for (int j = 0; j < colCount; j++)
                {
                    DataColumn col = dt.Columns[j];
                    jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", col.ColumnName, stringToJson(row[j] == null ? "" : row[col.ColumnName].ToString()));
                    if (j < colCount - 1)
                    {
                        jsonBuilder.Append(",");
                    }
                }
                jsonBuilder.Append("}");
                DataRow[] childRows = dt.Select(string.Format(" {0}='{1}' ", parenidF, row[idF]));
                if (childRows.Length > 0)
                {
                    jsonBuilder.AppendFormat(",\"children\":");
                    GetTreeChildNodes(idF, textF, checkedF, parenidF, row[idF].ToString(), dt, jsonBuilder);
                }
                jsonBuilder.Append("}");
                if (i < rowCount - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]");
        }
        /// <summary>
        /// dataset到Jons字符串
        /// {total:0,rows:[{},{},{}]}
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string Dataset2Json(DataSet ds)
        {

            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            if (ds == null || ds.Tables.Count < 1)
            {
                jsonBuilder.Append("\"total\":0,");
                jsonBuilder.Append("\"rows\":[],");
                jsonBuilder.Append("\"footer\":[]");
            }
            else
            {
                jsonBuilder.AppendFormat("\"total\":{0},", ds.Tables[1].Rows[0][0]);
                DataTable2Json(ds.Tables[0], jsonBuilder);
                jsonBuilder.Append(",\"footer\":[{\"Total\":" + ds.Tables[1].Rows[0][0] + "}]");
            }
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        public static string Dataset2Json2(DataSet ds)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"total\":{0},", ds.Tables[0].Rows.Count);
            DataTable2Json(ds.Tables[0], jsonBuilder);
            jsonBuilder.Append(",\"footer\":[{\"Total\":" + ds.Tables[0].Rows.Count + "}]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        public static string DataTable2Json(DataTable dt, int count)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"total\":{0},", count);
            DataTable2Json(dt, jsonBuilder);
            jsonBuilder.Append(",\"footer\":[{\"Total\":" + count + "}]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// 总记录Json
        /// {total:0,row:[{},{}]}
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string TotalJson(int totalCount, DataSet ds)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            foreach (DataTable dt in ds.Tables)
            {
                jsonBuilder.Append("{");
                jsonBuilder.AppendFormat("\"total\":{0},", totalCount);
                DataTable2Json(ds.Tables[0], jsonBuilder);
                jsonBuilder.Append(",\"footer\":[{\"Total\":" + totalCount + "}]");
                jsonBuilder.Append("}");
            }
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// 转换成状态格式的JSON数据
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string ToResultJsonAndRow(int isOk, string message)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"isOk\":{0},\"message\":\"{1},\"", isOk, stringToJson(message));
            jsonBuilder.Append("\"total\":0,");
            jsonBuilder.Append("\"rows\":[]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// 转换成状态格式的JSON数据
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string ToResultJson(int isOk, string message)
        {
            message = message.Replace("\r", "");
            message = message.Replace("\n", "");
            message = message.Replace("'", "");
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"isOk\":{0},\"message\":\"{1}\"", isOk, stringToJson(message));
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String stringToJson(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {

                char c = s[i];
                switch (c)
                {
                    case '\\':
                        sb.Append("\\\\"); //盘符分隔符
                        break;
                    case '\'':
                        sb.Append("\\\'");
                        break;
                    case '"':
                        sb.Append("\\\"");
                        break;
                    case '\b':      //退格
                        sb.Append("\\b");
                        break;
                    case '\f':      //走纸换页
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n"); //换行    
                        break;
                    case '\r':      //回车
                        sb.Append("\\r");
                        break;
                    case '\t':      //横向跳格
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            sb.Replace("\r\n", "<br/>");
            return sb.ToString();
        }


        #region Newtonsoft.Json
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }
        #endregion
    }
}
