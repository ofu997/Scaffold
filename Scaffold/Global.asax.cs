using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Scaffold
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

			// called from routeconfig.cs 
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
