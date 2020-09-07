using System.Web;
using System.Web.Optimization;

namespace Autonoma.IOT.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.responsive.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/Utilidades.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/initial").Include(
                        "~/Scripts/initialLoad.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/MenuPrincipal.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/css/select2.min.css",
                      "~/Content/css/MenuPrincipal.css",
                      "~/Content/DataTables/css/jquery.dataTables.claro.min.css",
                      "~/Content/DataTables/css/responsive.dataTables.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/themes/base/jquery-ui.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/validacion").Include("~/Scripts/app/Views/ValidacionReferido/validacion.js"));
            bundles.Add(new ScriptBundle("~/bundles/Referidos").Include("~/Scripts/app/Views/ValidacionReferido/Referidos.js"));
        }
    }
}
