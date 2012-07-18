using System;
using ControleFinanceiro.CORE.Helpers;

namespace ControleFinanceiro.CORE.Extensions
{
	public static class TypeExtension
	{
		#region Public Static Methods

		/// <summary>
		/// Verifica se o tipo pode conter valor nulo.
		/// </summary>
		/// <param name="type">Um dos tipos do sistema ou tipos do usuário.</param>
		/// <returns><c>true</c> se puder conter valor nulo, caso contrário, <c>false</c>.</returns>
		/// <exception cref="System.ArgumentNullException">Se <c>type</c> for nulo.</exception>
		public static bool IsNullable(this Type type)
		{
			return TypeHelper.Instance.IsNullable(type);
		}

		/// <summary>
		/// Verifica se um tipo passado é anônimo.
		/// </summary>
		/// <param name="type">Tipo a ser verificado.</param>
		/// <returns>Retorna <c>true</c> se for um anônimo, caso contrário, <c>false</c>.</returns>
		/// <exception cref="System.ArgumentNullException">Se <c>type</c> for nulo.</exception>
		public static bool IsAnonymous(this Type type)
		{
			return TypeHelper.Instance.IsAnonymous(type);
		}

		/// <summary>
		/// Verifica se o tipo passado é um tipo simples. (Tipos simples: 
		/// <see cref="System.String"/>, <see cref="System.DateTime"/>,
		/// <see cref="System.Enum"/>, <see cref="System.Decimal"/>,
		/// <see cref="System.Guid"/>).
		/// </summary>
		/// <param name="type">Tipo a ser verificado.</param>
		/// <returns>Retorna <c>true</c> se o tipo passado for simples; caso contrário, <c>false</c>.</returns>
		/// <exception cref="System.ArgumentNullException">Se <c>type</c> for nulo.</exception>
		public static bool IsSimple(this Type type)
		{
			return TypeHelper.Instance.IsSimple(type);
		}

		#endregion
	}
}