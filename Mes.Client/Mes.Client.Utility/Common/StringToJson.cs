using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Data.Common;
using Newtonsoft.Json;

namespace Mes.Client.Utility
{
    public static class StringToJson
    {
        public static string ToJsonAjax(object value)
        {
            StringBuilder builder = new StringBuilder();
            if ((value == null) || (value == DBNull.Value))
            {
                return "null";
            }
            if ((value is string) || (value is DateTime))
            {
                return string.Format("\"{0}\"", value.ToString().Replace(@"\", @"\\").Replace("\"", "\\\""));
            }
            if (value is bool)
            {
                if (!value.Equals(true))
                {
                    return "false";
                }
                return "true";
            }
            if (value is Guid)
            {
                return value.ToString();
            }
            //if (Regex.IsMatch(value.ToString(), @"^-?\d+(\.\d+)?$"))
            //{
            //    return value.ToString();
            //}
            if (value is IDictionary)
            {
                IDictionary dictionary = value as IDictionary;
                builder.Append('{');
                foreach (object obj2 in dictionary.Keys)
                {
                    builder.AppendFormat("\"{0}\":{1},", obj2.ToString().Replace(@"\", @"\\").Replace("\"", "\\\""), ToJson(dictionary[obj2]));
                }
                return (builder.ToString().Trim(new char[] { ',' }) + "}");
            }
            if (value is IList)
            {
                builder.Append('[');
                Array array = value as Array;
                if ((array != null) && (array.Rank >= 2))
                {
                    int dimension = 0;
                    int rank = array.Rank;
                    while (dimension < rank)
                    {
                        builder.Append("[");
                        int num3 = 0;
                        int length = array.GetLength(dimension);
                        while (num3 < length)
                        {
                            builder.AppendFormat("{0},", ToJson(array.GetValue(dimension, num3)));
                            num3++;
                        }
                        builder.Insert(builder.Length - 1, ']');
                        dimension++;
                    }
                }
                else
                {
                    foreach (object obj3 in value as IList)
                    {
                        builder.AppendFormat("{0},", ToJson(obj3));
                    }
                }
                return (builder.ToString().Trim(new char[] { ',' }) + "]");
            }
            if (value is DataTable)
            {
                builder.Append('[');
                foreach (DataRow row in (value as DataTable).Rows)
                {
                    builder.AppendFormat("{0},", ToJson(row));
                }
                return (builder.ToString().Trim(new char[] { ',' }) + "]");
            }
            if (value is DataSet)
            {
                builder.Append('[');
                foreach (DataTable table in (value as DataSet).Tables)
                {
                    builder.AppendFormat("{0},", ToJson(table));
                }
                return (builder.ToString().Trim(new char[] { ',' }) + "]");
            }
            if (value is DataRow)
            {
                builder.Append('{');
                DataRow row2 = value as DataRow;
                int num5 = 0;
                int count = row2.Table.Columns.Count;
                while (num5 < count)
                {
                    builder.AppendFormat("\"{0}\":{1},", row2.Table.Columns[num5], ToJson(row2[num5]));
                    num5++;
                }
                return (builder.ToString().Trim(new char[] { ',' }) + "}");
            }
            Type type = value.GetType();
            if (!type.IsClass && !type.IsValueType)
            {
                return ("\"" + value.ToString() + "\"");
            }
            builder.Append("{");
            PropertyInfo[] properties = type.GetProperties();
            object obj4 = null;
            foreach (PropertyInfo info in properties)
            {
                if (info.CanRead)
                {
                    try
                    {
                        obj4 = info.GetValue(value, null);
                    }
                    catch
                    {
                        obj4 = null;
                    }
                    if (obj4 != null)
                    {
                        builder.AppendFormat("\"{0}\":{1},", info.Name, ToJson(obj4));
                    }
                }
            }
            foreach (FieldInfo info2 in type.GetFields())
            {
                if (info2.IsPublic)
                {
                    try
                    {
                        obj4 = info2.GetValue(value);
                    }
                    catch
                    {
                        obj4 = null;
                    }
                }
                if (obj4 != null)
                {
                    builder.AppendFormat("\"{0}\":{1},", info2.Name, ToJson(obj4));
                }
            }
            return builder.Replace(',', '}', builder.Length - 1, 1).ToString();
        }


        public static string ToJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}