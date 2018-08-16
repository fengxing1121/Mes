using System;
namespace Mes.Client.Utility.Extensions
{
	public static class TryCatchExtensions
	{
		public static bool TryCatch<T>(this T source, Action<T> action, Action<Exception> failureAction, Action<T> successAction) where T : class
		{
			bool result;
			try
			{
				action(source);
				successAction(source);
				result = true;
			}
			catch (Exception obj)
			{
				failureAction(obj);
				result = false;
			}
			return result;
		}
		public static bool TryCatch<T>(this T source, Action<T> action, Action<Exception> failureAction) where T : class
		{
			return source.TryCatch(action, failureAction, delegate(T c)
			{
			});
		}
		public static U TryCatch<T, U>(this T source, Func<T, U> func, Action<Exception> failureAction, Action<T> successAction) where T : class
		{
			U result;
			try
			{
				U u = func(source);
				successAction(source);
				result = u;
			}
			catch (Exception obj)
			{
				failureAction(obj);
				result = default(U);
			}
			return result;
		}
		public static U TryCatch<T, U>(this T source, Func<T, U> func, Action<Exception> failureAction) where T : class
		{
			return source.TryCatch(func, failureAction);
		}
	}
}
