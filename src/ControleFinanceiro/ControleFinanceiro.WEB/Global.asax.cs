using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Castle.Components.Validator;
using ControleFinanceiro.CORE;
using ControleFinanceiro.CORE.Components;
using ControleFinanceiro.CORE.Services;
using ControleFinanceiro.CORE.Services.Impl;
using ControleFinanceiro.WEB.Attributes;
using SquishIt.Framework;

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

            ConfigureSquishit();
            COREConfiguration.Configure();
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
            filters.Add(new RequireAuthenticationFilterAttribute());
            filters.Add(new CompressFilterAttribute());
            filters.Add(new CacheFilterAttribute());
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               "Resources", // Route name
               "Static/resources/{resxFileName}.js", // URL with parameters
               new { controller = "Resources", action = "GetResourcesJavaScript" } // Parameter defaults
           );

            routes.MapRoute(
               "Extends", // Route name
               "Static/extends/{extFileName}.js", // URL with parameters
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
            builder.Register<JsonResult>(j => new JsonResult());
            builder.Register(u => new Feedback()).InstancePerDependency();

            builder.RegisterType<CategoriaService>().As<ICategoriaService>();

            //builder.RegisterModule(new AutofacWebTypesModule());
            //builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void ConfigureSquishit()
        {

            Bundle.Css()
               .Add("~/Assets/frameworks/bootstrap/css/bootstrap.css")
               .Add("~/Assets/frameworks/bootstrap/css/bootstrap-responsive.css")
               .ForceRelease()
               .AsCached("CombinedCSS", "~/Assets/Css/CombinedCSS");


            Bundle.JavaScript()
                .AddMinified("~/Assets/frameworks/main/jquery-1.9.1.min.js")
                .AddMinified("~/Assets/frameworks/main/jquery-ui-1.10.2.min.js")
                .AddMinified("~/Assets/frameworks/main/jquery.validate.min.js")
                .Add("~/Assets/frameworks/main/modernizr-2.6.2.js")
                .Add("~/Assets/frameworks/bootstrap/js/bootstrap.min.js")
                .Add("~/Assets/frameworks/spin/spin.js")
                .Add("~/Assets/frameworks/offtmp/jquery.offtmp.js")
                .ForceRelease()
                .AsCached("CombinedJS", "~/Assets/Js/CombinedJS");
            
            Bundle.JavaScript()
                .AddRemote("~/Assets/customScripts", "/Static/extends/GlobalExtends.js")
                .AddRemote("~/Assets/customScripts", "/Static/resources/GlobalsResource.js")
                .AddRemote("~/Assets/customScripts", "/Static/resources/LabelsResource.js")
                .AddRemote("~/Assets/customScripts", "/Static/resources/MessagesResource.js")
                .Add("/Assets/customScripts/Global.js")
                .Add("/Assets/customScripts/Master.js")
                .Add("/Assets/customScripts/AccountSignIn.js")
                .ForceRelease()
                .WithDeferredLoad()
                .AsCached("CombinedJS2", "~/Assets/Js/CombinedJS2");
        }

        #endregion
    }
}
