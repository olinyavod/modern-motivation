using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.Services.Description;
using Motivation.Site.Models;

namespace Motivation.Site
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			var builder = new ODataConventionModelBuilder();
			builder.EntitySet<UserDto>("Users");
			builder.EntitySet<AchivmentAttempDto>("AchivmentAttemps");
	        var compition = builder.EntitySet<CompititionDto>("Compititions");
		        
	        

			config.MapODataServiceRoute(
				routeName: "ODataRoute",
				routePrefix: null,
				model: builder.GetEdmModel());
		}
    }
}
