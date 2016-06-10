
using System;
using System.Reflection;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.Framework
{
#pragma warning disable 1591
    /// <summary>
    /// Common reflection helper methods for Oanda data types.
    /// </summary>
	public class Common
	{
		public static object GetDefault(Type t)
		{
			return typeof(Common).GetTypeInfo().GetDeclaredMethod("GetDefaultGeneric").MakeGenericMethod(t).Invoke(null, null);
		}

		public static T GetDefaultGeneric<T>()
		{
			return default(T);
		}
	}
#pragma warning restore 1591
}
