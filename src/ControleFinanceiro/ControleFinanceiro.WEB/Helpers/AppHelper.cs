using System;
using System.Web;

namespace ControleFinanceiro.Helpers
{
    public class AppHelper
    {

        #region Propriedades Privadas
        /// <summary>
        /// Propriedade privada que verifica se existe a barra final na url da aplicação, caso não exista, retorna a barra.
        /// </summary>
        private static string Slash
        {
            get { return (HttpContext.Current.Request.ApplicationPath != null && HttpContext.Current.Request.ApplicationPath.ToString().EndsWith("/") ? String.Empty : "/"); }
        }

        /// <summary>
        /// Propriedade privada que retorna a porta utilizada na aplicação, caso seja porta 80 (default), retorna em branco.
        /// </summary>
        private static string Port
        {
            get { return ((HttpContext.Current.Request.Url.Port.ToString() == "80") ? "" : (":" + HttpContext.Current.Request.Url.Port.ToString())); }
        }

        /// <summary>
        /// Propriedade privada que verifica o suporte a gzip.
        /// </summary>
        /// <returns>Retorna true para suportado e false para não suportado.</returns>
        private static bool IsGZipSupported()
        {
            string AcceptEncoding = HttpContext.Current.Request.Headers.Get("Accept-Encoding");

            if (!string.IsNullOrEmpty(AcceptEncoding) && (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate")))
            {
                return true;
            }

            return false;
        }
        #endregion
        /// <summary>
        /// Propriedade pública que retorna o domínio raiz da aplicação.
        /// </summary>
        public static string RootDomain
        {
            get { return String.Concat((HttpContext.Current.Request.Url.Scheme + "://"), HttpContext.Current.Request.Url.Host, Port, HttpContext.Current.Request.ApplicationPath, Slash); }
        }
        /// <summary>
        /// Propriedade pública que retorna a rota da pasta Assets.
        /// </summary>
        public static string AssetsPath
        {
            get { return String.Concat(RootDomain, "Assets/"); }
        }

    }
}