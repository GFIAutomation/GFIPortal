using System.Web;
using System.Web.Optimization;

namespace gfi_test_landing
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
                bundles.Add(new ScriptBundle("~/Js").Include(
                          "~/content/plugins/jquery/jquery.min.js",
                          "~/content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                          "~/content/plugins/bootstrap/js/bootstrap.bundle.js",
                          "~/content/plugins/bootstrap/js/bootstrap.min.js",
                          "~/content/plugins/slimScroll/jquery.slimscroll.min.js",
                          "~/content/plugins/fastclick/fastclick.js",
                          "~/content/js/adminlte.js",
                          "~/content/js/adminlte.min.js",
                          "~/content/js/demo.js",
                          "~/content/js/chart.js",
                          "~/content/build/js/AdminLTE.js",
                          "~/content/build/js/ControlSidebar.js",
                          "~/content/build/js/Layout.js",
                          "~/content/build/js/PushMenu.js",
                          "~/content/build/js/SiteSearch.js",
                          "~/content/build/js/Treeview.js",
                          "~/content/build/js/Widget.js",
                          "~/content/build/npm/Plugins.js",
                          "~/content/build/npm/Publish.js",
                          "~/content/js/pages/dashboard.js",
                          "~/content/js/pages/dashboard2.js",
                          "~/content/js/pages/dashboard3.js"));

                bundles.Add(new StyleBundle("~/Css").Include(
                          "~/Content/css/adminlte.min.css",
                          "~/Content/css/adminlte.css",
                          "~/content/plugins/bootstrap/css/*.css"));


            bundles.Add(new StyleBundle("~/sCss").Include(
                          "~/content/build/scss/*.scss"
                         /* "~/content/build/scss/_alerts.scss",
                          "~/content/build/scss/_bootstrap-variable.scss",
                          "~/content/build/scss/_brand.scss",
                          "~/content/build/scss/_.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",
                          "~/content/build/scss/_404_500_erros.scss",*/));


            BundleTable.EnableOptimizations = true;
        }
    }
}
