using System.Web.Mvc;
using ControleFinanceiro.CORE.Helpers;

namespace ControleFinanceiro.CORE.Extensions
{
	public static class ViewDataDictionaryExtension
	{
		#region Public Static Methods

		public static void Merge(this ViewDataDictionary source, object model)
		{
			Merge(source, new ViewDataDictionary(model));
		}

		public static void Merge(this ViewDataDictionary source, ViewDataDictionary viewData)
		{
			if (source == null || viewData == null) { return; }

			ViewDataDictionaryHelper.Instance.Merge(source, viewData);
		}

		#endregion
	}
}