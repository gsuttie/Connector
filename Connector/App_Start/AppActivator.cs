using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connector.App_Start
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class AppActivator
    {
        public static void PreStart()
        {
            StructuremapMvc.Start();
        }

        public static void PostStart()
        {
            // Clears all previously registered view engines (this reduces lookups for performance).
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public static void Stop()
        {
        }
    }
}