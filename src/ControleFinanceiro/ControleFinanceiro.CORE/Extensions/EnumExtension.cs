using System;
using ControleFinanceiro.CORE.Helpers;

namespace ControleFinanceiro.CORE.Extensions
{
	public static class NamelessEnumExtension
	{
		#region Public Static Methods

		public static string GetDescription(this Enum source)
		{
			return EnumHelper.Instance.GetDescription(source);
		}

		#endregion
	}
}