using System;
using System.Globalization;
using System.Web;
using ControleFinanceiro.CORE.Helpers;

namespace ControleFinanceiro.CORE.Extensions
{
	public static class HttpRequestBaseExtension
	{
		#region Public Static Methods

		public static bool GetBoolean(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetBoolean(source[key], false);
		}

		public static bool GetBoolean(this HttpRequestBase source, string key, bool fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetBoolean(source[key], fallback);
		}

		public static byte GetByte(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetByte(source[key], byte.MinValue, NumberStyles.None, null);
		}

		public static byte GetByte(this HttpRequestBase source, string key, byte fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetByte(source[key], fallback, NumberStyles.None, null);
		}

		public static byte GetByte(this HttpRequestBase source, string key, byte fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetByte(source[key], fallback, style, provider);
		}

		public static char GetChar(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetChar(source[key], char.MinValue);
		}

		public static char GetChar(this HttpRequestBase source, string key, char fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetChar(source[key], fallback);
		}

		public static DateTime GetDateTime(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDateTime(source[key], DateTime.MinValue, DateTimeStyles.None, null);
		}

		public static DateTime GetDateTime(this HttpRequestBase source, string key, DateTime fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDateTime(source[key], fallback, DateTimeStyles.None, null);
		}

		public static DateTime GetDateTime(this HttpRequestBase source, string key, DateTime fallback, DateTimeStyles styles, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDateTime(source[key], fallback, styles, provider);

		}

		public static decimal GetDecimal(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDecimal(source[key], decimal.MinValue, NumberStyles.None, null);
		}

		public static decimal GetDecimal(this HttpRequestBase source, string key, decimal fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDecimal(source[key], fallback, NumberStyles.None, null);
		}

		public static decimal GetDecimal(this HttpRequestBase source, string key, decimal fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDecimal(source[key], fallback, style, provider);
		}

		public static double GetDouble(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDouble(source[key], double.MinValue, NumberStyles.None, null);
		}

		public static double GetDouble(this HttpRequestBase source, string key, double fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDouble(source[key], fallback, NumberStyles.None, null);
		}

		public static double GetDouble(this HttpRequestBase source, string key, double fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetDouble(source[key], fallback, style, provider);
		}

		public static short GetInt16(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt16(source[key], short.MinValue, NumberStyles.None, null);
		}

		public static short GetInt16(this HttpRequestBase source, string key, short fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt16(source[key], fallback, NumberStyles.None, null);
		}

		public static short GetInt16(this HttpRequestBase source, string key, short fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt16(source[key], fallback, style, provider);
		}

		public static int GetInt32(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt32(source[key], int.MinValue, NumberStyles.None, null);
		}

		public static int GetInt32(this HttpRequestBase source, string key, int fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt32(source[key], fallback, NumberStyles.None, null);
		}

		public static int GetInt32(this HttpRequestBase source, string key, int fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt32(source[key], fallback, style, provider);
		}

		public static long GetInt64(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt64(source[key], long.MinValue, NumberStyles.None, null);
		}

		public static long GetInt64(this HttpRequestBase source, string key, long fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt64(source[key], fallback, NumberStyles.None, null);
		}

		public static long GetInt64(this HttpRequestBase source, string key, long fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetInt64(source[key], fallback, style, provider);
		}

		public static sbyte GetSByte(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetSByte(source[key], sbyte.MinValue, NumberStyles.None, null);
		}

		public static sbyte GetSByte(this HttpRequestBase source, string key, sbyte fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetSByte(source[key], fallback, NumberStyles.None, null);
		}

		public static sbyte GetSByte(this HttpRequestBase source, string key, sbyte fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetSByte(source[key], fallback, style, provider);
		}

		public static float GetSingle(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetSingle(source[key], float.MinValue, NumberStyles.None, null);
		}

		public static float GetSingle(this HttpRequestBase source, string key, float fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetSingle(source[key], fallback, NumberStyles.None, null);
		}

		public static float GetSingle(this HttpRequestBase source, string key, float fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetSingle(source[key], fallback, style, provider);
		}

		public static string GetString(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetString(source[key], string.Empty, null);
		}

		public static string GetString(this HttpRequestBase source, string key, string fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetString(source[key], fallback, null);
		}

		public static string GetString(this HttpRequestBase source, string key, string fallback, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetString(source[key], fallback, provider);
		}

		public static ushort GetUInt16(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt16(source[key], ushort.MinValue, NumberStyles.None, null);
		}

		public static ushort GetUInt16(this HttpRequestBase source, string key, ushort fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt16(source[key], fallback, NumberStyles.None, null);
		}

		public static ushort GetUInt16(this HttpRequestBase source, string key, ushort fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt16(source[key], fallback, style, provider);
		}

		public static uint GetUInt32(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt32(source[key], uint.MinValue, NumberStyles.None, null);
		}

		public static uint GetUInt32(this HttpRequestBase source, string key, uint fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt32(source[key], fallback, NumberStyles.None, null);
		}

		public static uint GetUInt32(this HttpRequestBase source, string key, uint fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt32(source[key], fallback, style, provider);
		}

		public static ulong GetUInt64(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt64(source[key], ulong.MinValue, NumberStyles.None, null);
		}

		public static ulong GetUInt64(this HttpRequestBase source, string key, ulong fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt64(source[key], fallback, NumberStyles.None, null);
		}

		public static ulong GetUInt64(this HttpRequestBase source, string key, ulong fallback, NumberStyles style, IFormatProvider provider)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetUInt64(source[key], fallback, style, provider);
		}

		public static Guid GetGuid(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetGuid(source[key], Guid.Empty);
		}

		public static Guid GetGuid(this HttpRequestBase source, string key, Guid fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetGuid(source[key], fallback);
		}

		public static T GetEnum<T>(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetEnum<T>(source[key], default(T), false);
		}

		public static T GetEnum<T>(this HttpRequestBase source, string key, T fallback, bool ignoreCase)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.GetEnum<T>(source[key], fallback, ignoreCase);
		}

		public static T CastSilent<T>(this HttpRequestBase source, string key)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.CastSilent<T>(source[key], default(T));
		}

		public static T CastSilent<T>(this HttpRequestBase source, string key, T fallback)
		{
			Check.Arguments.ThrowIfNull(source, "source");

			return ParserHelper.Instance.CastSilent<T>(source[key], fallback);
		}

		public static string GetRealIP(this HttpRequestBase source)
		{
			if (source == null) return string.Empty;

			var ip = source.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (ip.IsSafe() && !ip.Equals("unknown", StringComparison.InvariantCultureIgnoreCase))
				return ip;

			return source.ServerVariables["REMOTE_ADDR"];
		}

		#endregion
	}
}