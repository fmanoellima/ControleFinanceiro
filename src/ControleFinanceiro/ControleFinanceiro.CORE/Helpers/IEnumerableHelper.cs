using System.Collections;

namespace ControleFinanceiro.CORE.Helpers
{
	public sealed class IEnumerableHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static IEnumerableHelper _instance;
		public static IEnumerableHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new IEnumerableHelper();

					return _instance;
				}
			}
		}

		private IEnumerableHelper() { }

		#endregion

		#region Public Methods

		public bool IsNullOrEmpty(IEnumerable collection)
		{
			return (!(collection != null && collection.GetEnumerator().MoveNext()));
		}

		#endregion
	}
}