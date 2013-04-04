using System;
using System.Linq;
using System.Web.Mvc;

namespace ControleFinanceiro.WEB.Attributes
{
    public sealed class RequireAuthenticationFilterAttribute : AuthorizeAttribute
    {

        #region Private Read-Only Fields

        private readonly string[] _listaExcessoes = new string[] { "HomeController", "ResourcesController", "AssetsController", "AccountController" };

        #endregion

        #region Public Override Methods

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = _listaExcessoes.Contains(filterContext.Controller.GetType().Name, StringComparer.InvariantCultureIgnoreCase)
                || filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);


            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }

        }

        #endregion

    }
}