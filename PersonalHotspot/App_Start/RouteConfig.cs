using System.Web.Mvc;
using System.Web.Routing;

namespace PersonalHotspot
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute("Default", "{controller}/{action}/{id}", new
            {
                controller = "pages",
                action = "profile",
                id = UrlParameter.Optional
            });

            routes.MapRoute("Management", "management/{controller}/{action}/{id}", new
            {
                area = "Management",
                controller = "homecontents",
                action = "index",
                id = UrlParameter.Optional
            });
        }
    }
}