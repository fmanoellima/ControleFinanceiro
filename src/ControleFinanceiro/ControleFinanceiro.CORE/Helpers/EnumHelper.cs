using System;
using System.ComponentModel;
using System.Linq;

namespace ControleFinanceiro.CORE.Helpers
{
	public sealed class EnumHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static EnumHelper _instance;
		public static EnumHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new EnumHelper();

					return _instance;
				}
			}
		}

		private EnumHelper() { }

		#endregion

		#region Public Methods

		public string GetDescription(Enum source)
		{
			var description = source
				.GetType()
				.GetField(source.ToString())
				.GetCustomAttributes(typeof(DescriptionAttribute), false)
				.OfType<DescriptionAttribute>()
				.FirstOrDefault();

			return (description != null ? description.Description : source.ToString());
		}

		public T[] GetValues<T>()
		{
			var result = default(T[]);

			if (typeof(T).IsEnum)
				result = Enum.GetValues(typeof(T)).OfType<T>().ToArray();

			return result;
		}

		#endregion
	}
}