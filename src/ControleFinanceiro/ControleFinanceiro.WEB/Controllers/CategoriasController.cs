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
        private readonly ICategoriaService _service;
        private IValidatorRunner _validationRunner;

        public CategoriasController(ICategoriaService service, IValidatorRunner validationRunner)
         {
             _service = service;
            _validationRunner = validationRunner;
         }
        
        // GET: /Categorias/
        public ActionResult Index()
        {
            _feed = _service.ListarCategorias();
            ViewBag.Categorias = _feed.Status == Feedback.TypeFeedback.Success ? _feed.Output : null;

            return View();
        }

    }
}
