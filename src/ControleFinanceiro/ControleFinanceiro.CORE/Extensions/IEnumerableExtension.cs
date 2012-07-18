using System.Collections;
using ControleFinanceiro.CORE.Helpers;

namespace ControleFinanceiro.CORE.Extensions
{
	public static class IEnumerableExtension
	{
		#region Public Static Methods

		public static bool IsNullOrEmpty(this IEnumerable source)
		{
			return IEnumerableHelper.Instance.IsNullOrEmpty(source);
		}

		#endregion
	}
}