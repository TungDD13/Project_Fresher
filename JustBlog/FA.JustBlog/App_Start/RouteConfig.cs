using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Posts",
                "Posts/{year}/{month}/{urlSluq}",
                new { controller = "Posts", action = "Detail" },
                new { year = @"\d{4}", month = @"\d{2}" },
                new[] { "IdentitySample.Controllers" }
            );

            routes.MapRoute(
                "PostsCategory",
                "Category/{category}",
                new { controller = "Posts", action = "getPostByCategory" },
                new[] { "IdentitySample.Controllers" }
            );

            routes.MapRoute(
                "PostsTag",
                "Tag/{tagName}",
                new { controller = "Posts", action = "getPostByTag" },
                new[] { "IdentitySample.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Posts", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "IdentitySample.Controllers" }
            );
        }
    }
}