using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Api.Services;
using Datos.Datos.Pruebas;
using LogicaNegocio.Repositorios.Prueba;
using Unity.AspNet.WebApi;
using Unity;
using log4net.Config;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            var container = new UnityContainer();
            container.RegisterType<IDatosPrueba, DatosPrueba>();
            container.RegisterType<IRepositorioPrueba, RepositorioPrueba>();
            container.RegisterType<ServicioPrueba>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Registra el filtro de acción para eliminar el encabezado de versión de ASP.NET MVC
            GlobalFilters.Filters.Add(new RemoveMvcVersionHeaderFilter());
        }
    }

    public class RemoveMvcVersionHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Eliminar el encabezado de versión de ASP.NET MVC
            filterContext.HttpContext.Response.Headers.Remove("X-AspNetMvc-Version");
        }
    }
}
