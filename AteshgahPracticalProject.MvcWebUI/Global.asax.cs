using AteshgahPracticalProject.Business.DependencyResolvers.Ninject;
using AteshgahPracticalProject.Core.Utilities.MVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AteshgahPracticalProject.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new ValidationModule(), new AutoMapperModule()));
        }
    }
}
