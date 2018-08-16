using System;
namespace Mes.Client.Utility.Extensions
{
	public static class NumberExtension
	{
		public static double ToDouble(this decimal value)
		{
			return Convert.ToDouble(value);
		}
		public static bool IsId(this int value)
		{
			return value > 0;
		}
		public static bool InRange<T>(this IComparable<T> t, T minT, T maxT)
		{
			return t.CompareTo(minT) >= 0 && t.CompareTo(maxT) <= 0;
		}
	}
}
