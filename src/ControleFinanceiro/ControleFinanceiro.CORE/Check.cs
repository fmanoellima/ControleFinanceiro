using System;
using System.Collections;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE
{
    public static class Check
    {
        #region Public Static Inner Classes

        public static class Arguments
        {
            #region Public Static Methods

            /// <summary>
            /// Lança exceção se o argumento for nulo.
            /// </summary>
            /// <param name="arg">Argumento a ser testado.</param>
            /// <param name="argName">Nome do argumento.</param>
            /// <exception cref="ArgumentNullException">Se o argumento é nulo.</exception>
            public static void ThrowIfNull(object arg, string argName)
            {
                if (arg == null)
                    throw new ArgumentNullException(argName, string.Format(MessagesResource.CheckArgumentsThrowIfNull, argName));
            }
            /// <summary>
            /// Lança exceção se a coleção for nula ou vazia.
            /// </summary>
            /// <param name="arg">Coleção a ser testado.</param>
            /// <param name="argName">Nome da coleção.</param>
            /// <exception cref="ArgumentNullException">Se a coleção é nula.</exception>
            /// <exception cref="ArgumentException">Se a coleção é vazia.</exception>
            public static void ThrowIfEmptyCollection(IEnumerable arg, string argName)
            {
                Check.Arguments.ThrowIfNull(arg, argName);

                if (!arg.GetEnumerator().MoveNext())
                    throw new ArgumentException(string.Format(MessagesResource.CheckArgumentsThrowIfEmptyCollection, argName), argName);
            }
            /// <summary>
            /// Lança exceção se a cadeia de caracteres for nula, vazia ou apenas espaços em branco.
            /// </summary>
            /// <param name="arg">Cadeia de caracteres a ser testada.</param>
            /// <param name="argName">Nome da cadeia de caracteres.</param>
            /// <exception cref="ArgumentNullException">Se a cadeia de caracteres é nula.</exception>
            /// <exception cref="ArgumentException">Se a cadeia de caracteres é vazia ou apenas espaços em branco.</exception>
            public static void ThrowIfStringNotSafe(string arg, string argName)
            {
                Check.Arguments.ThrowIfNull(arg, argName);

                if (arg.Trim().Length == 0)
                    throw new ArgumentException(string.Format(MessagesResource.CheckArgumentsThrowIfStringNotSafe, argName), argName);
            }
            /// <summary>
            /// Lança exceção se o tipo não for um enumerador (<see cref="System.Enum"/>).
            /// </summary>
            /// <param name="arg">Tipo a ser testado.</param>
            /// <param name="argName">Nome do tipo.</param>
            /// <exception cref="ArgumentNullException">Se o tipo é nulo.</exception>
            /// <exception cref="ArgumentException">Se o tipo não for um enumerador.</exception>
            public static void ThrowIfNotEnumType(Type arg, string argName)
            {
                Check.Arguments.ThrowIfNull(arg, argName);

                if (!arg.IsEnum)
                    throw new ArgumentException(string.Format(MessagesResource.CheckArgumentsThrowIfNotEnumType, argName), argName);
            }
            /// <summary>
            /// Lança exceção se o tipo não for assinado por outro tipo especificado.
            /// </summary>
            /// <param name="argName">Nome do tipo.</param>
            /// <exception cref="ArgumentNullException">Se o tipo testado é nulo ou se o tipo assinalável é nulo.</exception>
            /// <exception cref="InvalidCastException">Se o tipo não for assinado.</exception>
            public static void ThrowIfNotAssignable<TAssignable, TArgument>(string argName)
            {
                Check.Arguments.ThrowIfNotAssignable(typeof(TArgument), typeof(TAssignable), argName);
            }
            /// <summary>
            /// Lança exceção se o tipo não for assinado por outro tipo especificado.
            /// </summary>
            /// <param name="arg">Tipo a ser testado.</param>
            /// <param name="assignable">Tipo o qual, o tipo testado, deve ter assinatura.</param>
            /// <param name="argName">Nome do tipo.</param>
            /// <exception cref="ArgumentNullException">Se o tipo é nulo ou se o tipo assinalável é nulo.</exception>
            /// <exception cref="InvalidCastException">Se o tipo não for assinado.</exception>
            public static void ThrowIfNotAssignable(Type arg, Type assignable, string argName)
            {
                Check.Arguments.ThrowIfNull(arg, argName);
                Check.Arguments.ThrowIfNull(assignable, "assignable");

                if (!assignable.IsAssignableFrom(arg))
                    throw new InvalidCastException(string.Format(MessagesResource.CheckArgumentsThrowIfNotAssignable, arg.FullName, assignable.FullName));
            }

            #endregion
        }

        #endregion
    }
}