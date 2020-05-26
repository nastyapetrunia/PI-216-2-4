using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using BLL.AutoMapper;
using Ninject;
using Ninject.Modules;

namespace WebSchedule
{
    public class WebApiApplication:HttpApplication
    {
        public static readonly string connection = "DbConnection";
        [Obsolete]
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<BLLProfile>();
                cfg.AddProfile<WebAPIProfile>();
            });
            Mapper.Configuration.AssertConfigurationIsValid();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var modules = new INinjectModule[]
            {
                new WebApiNinjectModule(),
                new BLL.Services.BllNinjectModule()
            };
            IKernel kernel = new StandardKernel(modules);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }
    }
}
