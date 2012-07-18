using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ControleFinanceiro.CORE.Helpers
{
	/// <summary>
	/// Classe auxiliar para tipos.
	/// </summary>
	public sealed class TypeHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static TypeHelper _instance;
		public static TypeHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new TypeHelper();

					return _instance;
				}
			}
		}

		private TypeHelper() { }

		#endregion

		#region Private Static Read-Only Fields

		/// <summary>
		/// Define os tipos simples que podem ser escritos, diretamente, em um XML.
		/// </summary>
		private static readonly Type[] _writeTypes = new[] {
			typeof(string),
			typeof(DateTime),
			typeof(Enum),
			typeof(decimal),
			typeof(Guid)
		};

		#endregion

		#region Public Static Methods

		/// <summary>
		/// Verifica se um tipo passado é anônimo.
		/// </summary>
		/// <param name="type">Tipo a ser verificado.</param>
		/// <returns>Retorna <c>true</c> se for um anônimo, caso contrário, <c>false</c>.</returns>
		/// <exception cref="System.ArgumentNullException">Se <c>type</c> for nulo.</exception>
		public bool IsAnonymous(Type type)
		{
			Check.Arguments.ThrowIfNull(type, "type");

			return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false) &&
					type.IsGenericType && type.Name.Contains("AnonymousType") &&
					(type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"));
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
		public bool IsSimple(Type type)
		{
			Check.Arguments.ThrowIfNull(type, "type");

			return (type.IsPrimitive || TypeHelper._writeTypes.Contains(type));
		}

		/// <summary>
		/// Verifica se o tipo pode conter valor nulo.
		/// </summary>
		/// <typeparam name="T">Um dos tipos do sistema ou tipos do usuário.</typeparam>
		/// <returns><c>true</c> se puder conter valor nulo, caso contrário, <c>false</c>.</returns>
		public bool IsNullable<T>()
		{
			return this.IsNullable(typeof(T));
		}

		/// <summary>
		/// Verifica se o tipo pode conter valor nulo.
		/// </summary>
		/// <param name="type">Um dos tipos do sistema ou tipos do usuário.</param>
		/// <returns><c>true</c> se puder conter valor nulo, caso contrário, <c>false</c>.</returns>
		/// <exception cref="System.ArgumentNullException">Se <c>type</c> for nulo.</exception>
		public bool IsNullable(Type type)
		{
			Check.Arguments.ThrowIfNull(type, "type");

			return (!type.IsValueType || type.FullName.StartsWith(typeof(Nullable).FullName));
		}

		#endregion
	}
}