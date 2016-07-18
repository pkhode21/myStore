using System.Web.Optimization;

namespace idea_UX
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Home Bundle

            //home css bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/content/Css/bootstrap/css/bootstrap.min.css",
                     "~/Content/Css/libs/hover-min.css",
                     "~/content/css/fonts.css",
                     "~/content/css/form.css",
                     "~/Content/Css/home/registration.css",
                     "~/content/css/site.css",
                     "~/Content/Plugins/Sweetalert/sweet-alert.css"
                     ));

            //home js bundle
            bundles.Add(new ScriptBundle("~/Content/JavaScript").Include(
                    "~/Content/javascript/jQuery/jquery.min.js",
                    "~/Content/css/bootstrap/js/bootstrap.min.js",
                    "~/Content/JavaScript/angular/lib/angular.min.js",
                    "~/Content/JavaScript/angular/lib/angular-route.js",
                    "~/Content/JavaScript/angular/ng-routes.js",
                    "~/Content/Plugins/Sweetalert/sweet-alert.min.js",
                    "~/Content/Plugins/Sweetalert/sweetalert.js",
                    "~/Content/JavaScript/angular/home.js"
                    
                ));

            #endregion Home Bundle
        }
    }
}