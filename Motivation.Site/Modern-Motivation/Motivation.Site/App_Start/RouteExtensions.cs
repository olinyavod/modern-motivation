using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Motivation.Site.App_Start
{
    public static class RouteExtensions
    {
        public static void Redirect(this RouteCollection routes, string url, string redirectUrl)
        {
            routes.Add(new Route(url, new RedirectRouteHandler(redirectUrl)));
        }
    }
}