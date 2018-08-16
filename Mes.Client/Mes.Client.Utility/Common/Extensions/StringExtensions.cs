using System;
using System.Text.RegularExpressions;
namespace Mes.Client.Utility.Extensions
{
	public static class StringExtensions
	{
		private static readonly Regex NameExpression = new Regex("([A-Z]+(?=$|[A-Z][a-z])|[A-Z]?[a-z]+)", RegexOptions.Compiled);


        /// <summary>
        /// 判断字符串的值是否相同
        /// </summary>
        /// <param name="prve"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static bool StringEquals(string prve, string next)
        {
            bool flag = false;
            if (prve.Trim().ToLower() == next.Trim().ToLower())
            {
                flag = true;
            }
            return flag;
        }

        public static string FormatWith(this string instance, params object[] args)
		{
			return string.Format(instance, args);
		}
		public static bool HasValue(this string value)
		{
			return !string.IsNullOrEmpty(value);
		}
		public static bool IsNullOrEmpty(this string instance)
		{
			return string.IsNullOrEmpty(instance);
		}
		public static string[] Split(this string str, string splitString)
		{
			return str.Split(new string[]
			{
				splitString
			}, StringSplitOptions.None);
		}
		public static string Add(this string str, string addString)
		{
			if (!str.IsNullOrEmpty())
			{
				return str + addString;
			}
			return "";
		}
		public static bool EqualsTo(this string str, string to, bool ignoreCase)
		{
			return string.Compare(str, to, ignoreCase) == 0;
		}
		public static bool EqualsTo(this string str, string to)
		{
			return str.EqualsTo(to, false);
		}
		public static string ToTitleCase(this string value)
		{
			if (value.IsNullOrEmpty())
			{
				return value;
			}
			if (value.Length == 1)
			{
				return value.ToUpper();
			}
			return value.Substring(0, 1).ToUpper() + value.Substring(1);
		}
		public static string ToVariableCase(this string value)
		{
			if (value.IsNullOrEmpty())
			{
				return value;
			}
			if (value.Length == 1)
			{
				return value.ToLower();
			}
			return value.Substring(0, 1).ToLower() + value.Substring(1);
		}
	}
}
