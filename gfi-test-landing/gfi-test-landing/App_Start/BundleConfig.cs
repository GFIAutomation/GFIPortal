using System.Web;
using System.Web.Optimization;

namespace gfi_test_landing
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
                bundles.Add(new ScriptBundle("~/bundles/scripts/js")
                    .Include(
                          "~/content/plugins/jquery/jquery.min.js",
                          "~/content/dist/js/adminlte.js",
                          "~/Content/plugins/datatables/jquery.dataTables.js",
                          "~/Content/plugins/datatables/dataTables.bootstrap4.js")
                    .IncludeDirectory("~/Content/plugins",".js"));

                bundles.Add(new StyleBundle("~/bundles/custom/css").
                    Include(
                        "~/Content/dist/css/adminlte.css")
                   .IncludeDirectory("~/Content", ".css"));


            //bundles.Add(new StyleBundle("~/sCss").Include(
            //              "~/content/build/scss.scss"
            //             ));


            //BundleTable.EnableOptimizations = true;
        }
    }
}
