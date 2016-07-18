using System.Web.Mvc;
using System.Web.Routing;

namespace idea_UX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Home
            routes.MapRoute(
                name: "HomePage",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
               name: "UserRegistrationPage",
               url: "user/register",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               );

            routes.MapRoute(
               name: "UserLoginPage",
               url: "user/login",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               );

            routes.MapRoute(
              name: "UserVerificationPage",
              url: "user/verification",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
              );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}