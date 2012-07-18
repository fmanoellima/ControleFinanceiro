using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Autofac;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Components;
using ControleFinanceiro.CORE.Helpers;
using ControleFinanceiro.CORE.Models;
using ControleFinanceiro.CORE.Services.Impl;


namespace ControleFinanceiro.WEB.Controllers
{
    public class CategoriasController : Controller
    {
        private Feedback _feed;
        private JsonResult _jresult { get { return _context.Resolve<JsonResult>(); } }
        private readonly IComponentContext _context;
        private readonly ICategoriaService _service;
        private IValidatorRunner _validationRunner;

         public CategoriasController(IComponentContext context)
        {
            _context = context;
            _service = context.Resolve<ICategoriaService>();
             _validationRunner = context.Resolve<IValidatorRunner>();
        }
        
        // GET: /Categorias/
        public ActionResult Index()
        {
            _feed = _service.ListarCategorias();
            if(_feed.Status == Feedback.TypeFeedback.Success)
            {
                ViewBag.Categorias = _feed.Output;
            }
            else
            {
                ViewBag.Categorias = null;
            }

            return View();
        }

    }
}
