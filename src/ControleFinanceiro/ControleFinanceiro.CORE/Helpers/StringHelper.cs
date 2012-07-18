using System;
namespace ControleFinanceiro.CORE.Helpers
{
	public sealed class StringHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static StringHelper _instance;
		public static StringHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new StringHelper();

					return _instance;
				}
			}
		}

		private StringHelper() { }

		#endregion

		#region Public Methods

		public bool IsSafe(string value)
		{
			return (value != null && value.Trim().Length > 0);
		}

		public string EnsureStartsWith(string value, string startsWith)
		{
			return this.EnsureStartsWith(value, startsWith, StringComparison.CurrentCulture);
		}

		public string EnsureStartsWith(string value, string startsWith, StringComparison stringComparison)
		{
			if (string.IsNullOrEmpty(value)) { return startsWith; }

			return (!value.StartsWith(startsWith, stringComparison) ? string.Concat(startsWith, value) : value);
		}

		#endregion
	}
}