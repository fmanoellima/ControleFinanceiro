using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ControleFinanceiro.CORE.Helpers
{
	public sealed class ParserHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static ParserHelper _instance;
		public static ParserHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new ParserHelper();

					return _instance;
				}
			}
		}

		private ParserHelper() { }

		#endregion

		#region Static Methods

		public bool GetBoolean(object value)
		{
			return this.GetBoolean(value, false);
		}

		public bool GetBoolean(object value, bool fallback)
		{
			if (value == null) return fallback;

			var result = false;

			return (bool.TryParse(value.ToString(), out result) ? result : fallback);
		}

		public byte GetByte(object value)
		{
			return this.GetByte(value, byte.MinValue, NumberStyles.None, null);
		}

		public byte GetByte(object value, byte fallback)
		{
			return this.GetByte(value, fallback, NumberStyles.None, null);
		}

		public byte GetByte(object value, byte fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = byte.MinValue;

			return (byte.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public char GetChar(object value)
		{
			return this.GetChar(value, char.MinValue);
		}

		public char GetChar(object value, char fallback)
		{
			if (value == null) return fallback;

			var result = char.MinValue;

			return (char.TryParse(value.ToString(), out result) ? result : fallback);
		}

		public DateTime GetDateTime(object value)
		{
			return this.GetDateTime(value, DateTime.MinValue, DateTimeStyles.None, null);
		}

		public DateTime GetDateTime(object value, DateTime fallback)
		{
			return this.GetDateTime(value, fallback, DateTimeStyles.None, null);
		}

		public DateTime GetDateTime(object value, DateTime fallback, DateTimeStyles styles, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = DateTime.MinValue;

			return (DateTime.TryParse(value.ToString(), provider, styles, out result) ? result : fallback);
		}

		public decimal GetDecimal(object value)
		{
			return this.GetDecimal(value, decimal.MinValue, NumberStyles.None, null);
		}

		public decimal GetDecimal(object value, decimal fallback)
		{
			return this.GetDecimal(value, fallback, NumberStyles.None, null);
		}

		public decimal GetDecimal(object value, decimal fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = decimal.MinValue;

			return (decimal.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public double GetDouble(object value)
		{
			return this.GetDouble(value, double.MinValue, NumberStyles.None, null);
		}

		public double GetDouble(object value, double fallback)
		{
			return this.GetDouble(value, fallback, NumberStyles.None, null);
		}

		public double GetDouble(object value, double fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = double.MinValue;

			return (double.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public short GetInt16(object value)
		{
			return this.GetInt16(value, short.MinValue, NumberStyles.None, null);
		}

		public short GetInt16(object value, short fallback)
		{
			return this.GetInt16(value, fallback, NumberStyles.None, null);
		}

		public short GetInt16(object value, short fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = short.MinValue;

			return (short.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public int GetInt32(object value)
		{
			return this.GetInt32(value, int.MinValue, NumberStyles.None, null);
		}

		public int GetInt32(object value, int fallback)
		{
			return this.GetInt32(value, fallback, NumberStyles.None, null);
		}

		public int GetInt32(object value, int fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = int.MinValue;

			return (int.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public long GetInt64(object value)
		{
			return this.GetInt64(value, long.MinValue, NumberStyles.None, null);
		}

		public long GetInt64(object value, long fallback)
		{
			return this.GetInt64(value, fallback, NumberStyles.None, null);
		}

		public long GetInt64(object value, long fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = long.MinValue;

			return (long.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public sbyte GetSByte(object value)
		{
			return this.GetSByte(value, sbyte.MinValue, NumberStyles.None, null);
		}

		public sbyte GetSByte(object value, sbyte fallback)
		{
			return this.GetSByte(value, fallback, NumberStyles.None, null);
		}

		public sbyte GetSByte(object value, sbyte fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = sbyte.MinValue;

			return (sbyte.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public float GetSingle(object value)
		{
			return this.GetSingle(value, float.MinValue, NumberStyles.None, null);
		}

		public float GetSingle(object value, float fallback)
		{
			return this.GetSingle(value, fallback, NumberStyles.None, null);
		}

		public float GetSingle(object value, float fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = float.MinValue;

			return (float.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public string GetString(object value)
		{
			return this.GetString(value, string.Empty, null);
		}

		public string GetString(object value, string fallback)
		{
			return this.GetString(value, fallback, null);
		}

		public string GetString(object value, string fallback, IFormatProvider provider)
		{
			return (value != null ? Convert.ToString(value.ToString(), provider) : fallback);
		}

		public ushort GetUInt16(object value)
		{
			return this.GetUInt16(value, ushort.MinValue, NumberStyles.None, null);
		}

		public ushort GetUInt16(object value, ushort fallback)
		{
			return this.GetUInt16(value, fallback, NumberStyles.None, null);
		}

		public ushort GetUInt16(object value, ushort fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = ushort.MinValue;

			return (ushort.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public uint GetUInt32(object value)
		{
			return this.GetUInt32(value, uint.MinValue, NumberStyles.None, null);
		}

		public uint GetUInt32(object value, uint fallback)
		{
			return this.GetUInt32(value, fallback, NumberStyles.None, null);
		}

		public uint GetUInt32(object value, uint fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = uint.MinValue;

			return (uint.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public ulong GetUInt64(object value)
		{
			return this.GetUInt64(value, ulong.MinValue, NumberStyles.None, null);
		}

		public ulong GetUInt64(object value, ulong fallback)
		{
			return this.GetUInt64(value, fallback, NumberStyles.None, null);
		}

		public ulong GetUInt64(object value, ulong fallback, NumberStyles style, IFormatProvider provider)
		{
			if (value == null) return fallback;

			var result = ulong.MinValue;

			return (ulong.TryParse(value.ToString(), style, provider, out result) ? result : fallback);
		}

		public Guid GetGuid(object value)
		{
			return this.GetGuid(value, Guid.Empty);
		}

		public Guid GetGuid(object value, Guid fallback)
		{
			if (value == null) return fallback;

			try { return new Guid(value.ToString()); }
			catch { return fallback; }
		}

		public T GetEnum<T>(object value)
		{
			return this.GetEnum<T>(value, default(T), false);
		}

		public T GetEnum<T>(object value, T fallback, bool ignoreCase)
		{
			Check.Arguments.ThrowIfNotEnumType(typeof(T), "T");

			if (value == null) return fallback;

			if (Enum.IsDefined(typeof(T), value))
				return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase);

			return fallback;
		}

		public T CastSilent<T>(object value)
		{
			return this.CastSilent<T>(value, default(T));
		}

		public T CastSilent<T>(object value, T fallback)
		{
			if (value == null) return fallback;
			if (value.GetType() != typeof(T)) return fallback;

			return (T)value;
		}

		public T[] GetArray<T>(IEnumerable values)
		{
			return this.GetArray<T>(values, new T[0]);
		}

		public T[] GetArray<T>(IEnumerable values, T[] fallback)
		{
			if (values == null) return fallback;

			if (typeof(T).IsEnum)
				return this.GetEnumArray<T>(values);

			if (typeof(T).IsAssignableFrom(typeof(Guid)))
				return this.GetGuidArray(values).OfType<T>().ToArray();

			return this.GetTypedArray<T>(values);
		}

		#endregion

		#region Private Methods

		private Guid[] GetGuidArray(IEnumerable values)
		{
			var result = new List<Guid>();
			var enumerator = values.GetEnumerator();

			while (enumerator.MoveNext())
				result.Add(this.GetGuid(enumerator.Current));

			return result.ToArray();
		}

		private T[] GetEnumArray<T>(IEnumerable values)
		{
			var result = new List<T>();
			var enumerator = values.GetEnumerator();

			while (enumerator.MoveNext())
				result.Add(this.GetEnum<T>(enumerator.Current));

			return result.ToArray();
		}

		private T[] GetTypedArray<T>(IEnumerable values)
		{
			var result = new List<object>();
			var enumerator = values.GetEnumerator();

			while (enumerator.MoveNext())
			{
				var value = enumerator.Current;

				switch (Type.GetTypeCode(typeof(T)))
				{
					case TypeCode.Boolean: result.Add(this.GetBoolean(value)); break;
					case TypeCode.Byte: result.Add(this.GetByte(value)); break;
					case TypeCode.Char: result.Add(this.GetChar(value)); break;
					case TypeCode.DateTime: result.Add(this.GetDateTime(value)); break;
					case TypeCode.Decimal: result.Add(this.GetDecimal(value)); break;
					case TypeCode.Double: result.Add(this.GetDouble(value)); break;
					case TypeCode.Int16: result.Add(this.GetInt16(value)); break;
					case TypeCode.Int32: result.Add(this.GetInt32(value)); break;
					case TypeCode.Int64: result.Add(this.GetInt64(value)); break;
					case TypeCode.Object: result.Add(value); break;
					case TypeCode.SByte: result.Add(this.GetSByte(value)); break;
					case TypeCode.Single: result.Add(this.GetSingle(value)); break;
					case TypeCode.String: result.Add(this.GetString(value)); break;
					case TypeCode.UInt16: result.Add(this.GetInt16(value)); break;
					case TypeCode.UInt32: result.Add(this.GetInt32(value)); break;
					case TypeCode.UInt64: result.Add(this.GetInt64(value)); break;
				}
			}

			return result.OfType<T>().ToArray();
		}

		#endregion
	}
}