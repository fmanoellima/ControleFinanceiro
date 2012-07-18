using System.Web.Mvc;

namespace ControleFinanceiro.CORE.Helpers
{
	public sealed class ViewDataDictionaryHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static ViewDataDictionaryHelper _instance;
		public static ViewDataDictionaryHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new ViewDataDictionaryHelper();

					return _instance;
				}
			}
		}

		private ViewDataDictionaryHelper() { }

		#endregion

		#region Public Methods

		public void Merge(ViewDataDictionary source, ViewDataDictionary destiny)
		{
			Check.Arguments.ThrowIfNull(source, "source");
			Check.Arguments.ThrowIfNull(destiny, "destiny");

			foreach (var entry in destiny)
				if (!source.ContainsKey(entry.Key))
					source.Add(entry.Key, entry.Value);

			if (destiny.Model != null)
				source.Model = destiny.Model;
		}

		#endregion
	}
}