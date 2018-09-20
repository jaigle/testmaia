using System.Web;
using System.Web.Optimization;

namespace DLMallas
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-1.10.2.min.js",
                         "~/Scripts/jquery.form.js",
                         "~/Scripts/jquery.json.js",
                         "~/Scripts/accounting.js",
                         "~/Scripts/plugins/jquery-ui/jquery-ui.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/combomultiselect").Include(
                "~/Scripts/plugins/multiselect/assets/prettify.js"//,
                //"~/Scripts/plugins/multiselect/jquery.multiselect.js",
                //"~/Scripts/plugins/multiselect/jquery.multiselect.filter.js"
                ));

            bundles.Add(new StyleBundle("~/Content/combocss").Include(
                //"~/Content/jquery.multiselect.css",
                //"~/Content/jquery.multiselect.filter.css",
                "~/Content/plugins/jquery-ui/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                "~/Scripts/highcharts/HighStock/highstock.js",
                "~/Scripts/highcharts/highcharts.js",
                "~/Scripts/highcharts/highcharts-3d.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js","~/Scripts/bootstrap-datepicker.js",
                       "~/Scripts/locales/bootstrap-datepicker.es.js"));
            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                    "~/Scripts/plugins/dataTables/DataTables-1.10.11/media/js/jquery.dataTables.js",
                    "~/Scripts/plugins/dataTables/DataTables-1.10.11/media/js/dataTables.bootstrap.js",
                    //"~/Scripts/plugins/dataTables/buttons.flash.min.js",
                    "~/Scripts/plugins/dataTables/buttons.html5.min.js",
                    "~/Scripts/plugins/dataTables/buttons.print.min.js",
                    "~/Scripts/plugins/dataTables/dataTables.buttons.min.js",
                    "~/Scripts/plugins/dataTables/jszip.min.js",
                    "~/Scripts/plugins/dataTables/pdfmake.min.js",
                    "~/Scripts/plugins/dataTables/vfs_fonts.js",
                    "~/Scripts/plugins/dataTables/pqselect.dev.js"
                      ));
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/bootstrap/dist/css/bootstrap.css",
            //    "~/Content/font-awesome/css/font-awesome.css",
            //    "~/Content/plugins/dataTables.bootstrap.css",
            //    "~/Content/plugins/jquery.dataTables.css",
            //    "~/Content/plugins/dataTables.responsive.css", 
            //    "~/Content/selectize.bootstrap3.css",
            //    "~/Content/bootstrap-datepicker3.css",
            //    "~/Content/jquery.multiselect.css",
            //    "~/Content/jquery.multiselect.filter.css",
            //    "~/Content/Content/plugins/jquery-ui/jquery-ui.css",
            //    "~/Content/Gridmvc.css",
            //    //,"~/Content/site.css",
            //    "~/Content/reset.css",
            //    "~/Content/base.css",
            //    //"~/Content/sb-admin-2.css",
            //    "~/Content/custom.css"
            //    ));
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/Utils.js",
                "~/Scripts/funciones-generales.js",
                "~/Scripts/plugins/waitingFor/bootstrap-waitingfor.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
                        "~/Scripts/modalform.js"));
            bundles.Add(new ScriptBundle("~/bundles/pqselectdev").Include(
                "~/Scripts/pqselectdev.js"
                ));
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862



            BundleTable.EnableOptimizations = false;
        }
    }
}
