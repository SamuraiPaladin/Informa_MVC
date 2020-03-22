using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize/materialize.min.js",
                      "~/Scripts/menu.js",
                      "~/Scripts/site.js",
                      "~/Scripts/temperaturaAndLocale.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize/materialize.min.css",
                      "~/Content/paginas/home.css",
                      "~/Content/paginas/login.css",
                      "~/Content/paginas/perfilProfessor.css",
                      "~/Content/paginas/principal.css",
                      "~/Content/cadastro.css",
                      "~/Content/gerenciarPagamento.css",
                      "~/Content/public.css",
                      "~/Content/weather-icons-master/css/weather-icons.min.css",
                      "~/Content/Site.css"));
        }
    }
}
