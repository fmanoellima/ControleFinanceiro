using System;
using System.Web.Mvc;
using SquishIt.Mvc;
using SquishIt.Framework;

namespace ControleFinanceiro.WEB.Controllers
{
    public partial class AssetsController : Controller
    {
        public virtual ActionResult Js(string id)
        {
            // Set max-age to a year from now
            Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
            return Content(Bundle.JavaScript().RenderCached(id), "text/javascript");
        }

        public virtual ActionResult Css(string id)
        {
            // Set max-age to a year from now
            Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
            return Content(Bundle.Css().RenderCached(id), "text/css");
        }
    }
}
