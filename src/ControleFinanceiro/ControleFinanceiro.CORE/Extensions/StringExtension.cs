using System;
using ControleFinanceiro.CORE.Helpers;

namespace ControleFinanceiro.CORE.Extensions
{
	public static class StringExtension
	{
		#region Public Static Methods

		public static bool IsSafe(this string source)
		{
			return StringHelper.Instance.IsSafe(source);
		}

		public static string EnsureStartsWith(this string source, string value)
		{
			return StringHelper.Instance.EnsureStartsWith(source, value);
		}

		public static string EnsureStartsWith(this string source, string value, StringComparison stringComparison)
		{
			return StringHelper.Instance.EnsureStartsWith(source, value, stringComparison);
		}

		#endregion
	}
}