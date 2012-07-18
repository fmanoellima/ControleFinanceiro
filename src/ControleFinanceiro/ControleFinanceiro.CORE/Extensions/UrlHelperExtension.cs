using System;
using System.Web.Mvc;

namespace ControleFinanceiro.CORE.Extensions
{
	public static class UrlHelperExtension
	{
		#region Public Static Methods

		public static string AbsolutePath(this UrlHelper urlHelper, string relativeUrl)
		{
			Uri url = default(Uri);
			UriBuilder uriBuilder = null;

			url = urlHelper.RequestContext.HttpContext.Request.Url;
			uriBuilder = new UriBuilder(url.Scheme, url.Host, url.Port) { Path = relativeUrl };

			return uriBuilder.Uri.ToString();
		}

		public static string ApplicationPath(this UrlHelper urlHelper, string relativePath)
		{
			if (string.IsNullOrEmpty(relativePath))
				return string.Empty;

			return urlHelper.Content(relativePath.EnsureStartsWith("~"));
		}

		#region Routes Shortcuts

		public static string AccountSignIn(this UrlHelper urlHelper)
		{
			return urlHelper.RouteUrl(new { controller = "account", action = "signin" });
		}

		public static string AccountSignOut(this UrlHelper urlHelper)
		{
			return urlHelper.RouteUrl(new { controller = "account", action = "signout" });
		}

		public static string AccountChangePassword(this UrlHelper urlHelper)
		{
			return urlHelper.RouteUrl(new { controller = "account", action = "changepassword" });
		}

		public static string AccountForgotMyPassword(this UrlHelper urlHelper)
		{
			return urlHelper.RouteUrl(new { controller = "account", action = "forgotmypassword" });
		}

		public static string HomeIndex(this UrlHelper urlHelper)
		{
			return urlHelper.RouteUrl(new { controller = "Home", action = "index" });
		}

		#endregion

		#endregion
	}
}