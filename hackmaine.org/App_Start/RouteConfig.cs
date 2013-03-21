using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hackmaine.org
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Root Controller Based on: ASP.NET MVC root url’s with generic routing Posted by William on Sep 19, 
            //  http://www.wduffy.co.uk/blog/aspnet-mvc-root-urls-with-generic-routing/
            routes.MapRoute(
                "Root",
                "{action}",
                new { controller = "Home", action = "Index" },
                new { IsRootAction = new IsRootActionConstraint() }  // Route Constraint
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

// Root Controller Based on: ASP.NET MVC root url’s with generic routing Posted by William on Sep 19, 
//  http://www.wduffy.co.uk/blog/aspnet-mvc-root-urls-with-generic-routing/

namespace System.Web.Mvc
{
    public class IsRootActionConstraint : IRouteConstraint
    {
        private Dictionary<string, Type> _controllers;

        public IsRootActionConstraint()
        {
            _controllers = Assembly
                                .GetCallingAssembly()
                                .GetTypes()
                                .Where(type => type.IsSubclassOf(typeof(Controller)))
                                .ToDictionary(key => key.Name.Replace("Controller", ""));
        }

        #region IRouteConstraint Members

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return !_controllers.Keys.Contains(values["action"] as string);
        }

        #endregion
    }
}