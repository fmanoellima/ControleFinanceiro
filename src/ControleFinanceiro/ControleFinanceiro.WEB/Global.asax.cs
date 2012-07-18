using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Castle.Components.Validator;
using ControleFinanceiro.CORE;
using ControleFinanceiro.CORE.Services;
using ControleFinanceiro.CORE.Services.Impl;

namespace ControleFinanceiro.WEB
{
    public class MvcApplication : HttpApplication
    {
        #region Protected Methods

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ConfigureAplication.Configure();

            ConfigureIOC();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               "Resources", // Route name
               "Assets/resources/{resxFileName}.js", // URL with parameters
               new { controller = "Resources", action = "GetResourcesJavaScript" } // Parameter defaults
           );

            routes.MapRoute(
               "Extends", // Route name
               "Assets/extends/{extFileName}.js", // URL with parameters
               new { controller = "Resources", action = "GetCustomExtends" } // Parameter defaults
           );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );



        }


        private void ConfigureIOC()
        {
            var builder = new ContainerBuilder();
            // Automatically register all controllers in the current assembly.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ValidatorRunner>().As<IValidatorRunner>().SingleInstance();
            builder.RegisterType<CachedValidationRegistry>().As<IValidatorRegistry>().SingleInstance();
            builder.Register<JsonResult>(j => new JsonResult()).InstancePerHttpRequest();

            builder.RegisterType<CategoriaService>().As<ICategoriaService>();
            
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion
    }
}
