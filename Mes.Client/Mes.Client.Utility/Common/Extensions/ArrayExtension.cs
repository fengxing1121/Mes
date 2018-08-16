using System;
using System.Collections.Generic;
using System.Linq;
namespace Mes.Client.Utility.Extensions
{
	public static class ArrayExtension
	{
		public static bool In<T>(this T t, IEnumerable<T> enumerable)
		{
			return enumerable.Contains(t);
		}
		public static bool In(this string str, params string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				string text = args[i];
				if (text.Equals(str))
				{
					return true;
				}
			}
			return false;
		}
	}
}
