using SportStore.Domain.Entities;
using SportStore.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Registering the CartModelBinder Class in the Global.asax.cs File
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
