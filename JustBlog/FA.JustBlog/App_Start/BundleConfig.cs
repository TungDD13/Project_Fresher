using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/jusblogcss/css").Include(
                      "~/Content/jusblogcss/clean-blog.css",
                      "~/Content/jusblogcss/clean-blog.min.css"));

            bundles.Add(new StyleBundle("~/Content/vendor/bootstrap/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/fontawesome-free/css/all.min.css",
                      "~/Content/vendor/bootstrap/css/all.min.css"));

            bundles.Add(new ScriptBundle("~/Content/vendor/js").Include(
                      "~/Content/vendor/jquery/jquery.min.js",
                      "~/Content/bootstrap/js/bootstrap.bundle.min.js"));
            //bootstrap for admin
            bundles.Add(new StyleBundle("~/Content/bower_components/bootstrap/css").Include(
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                      "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                      "~/Content/bower_components/Ionicons/css/ionicons.min.css"));

            bundles.Add(new StyleBundle("~/Content/dist/css").Include(
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css",
                      "~/Content/dist/css/skins/skin-blue.min.css"));

            bundles.Add(new StyleBundle("~/Content/form/dist/css").Include(
                      "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                      "~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                      "~/Content/plugins/iCheck/all.css",
                      "~/Content/bower_components/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css",
                      "~/Content/plugins/timepicker/bootstrap-timepicker.min.css",
                      "~/Content/bower_components/select2/dist/css/select2.min.css",
                      "~/bower_components/bootstrap-daterangepicker/daterangepicker.css"));

            // js for admin
            bundles.Add(new ScriptBundle("~/Content/bower_components/jquery/js").Include(
                      "~/Content/bower_components/jquery/dist/jquery.min.js",
                      "~/Content/dist/js/demo.js",
                      "~/Content/dist/js/adminlte.min.js",
                      "~/Content/bower_components/fastclick/lib/fastclick.js",
                      "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                      "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Content/bower_components/form/js").Include(
                      "~/bower_components/select2/dist/js/select2.full.min.js",
                      "~/Content/plugins/input-mask/jquery.inputmask.js",
                      "~/Content/plugins/input-mask/jquery.inputmask.date.extensions.js",
                      "~/Content/plugins/plugins/input-mask/jquery.inputmask.extensions.js",
                      "~/Content/bower_components/moment/min/moment.min.js",
                      "~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                      "~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                      "~/Content/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                      "~/Content/plugins/timepicker/bootstrap-timepicker.min.js",
                      "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/Content/plugins/iCheck/icheck.min.js",
                      "~/Content/bower_components/fastclick/lib/fastclick.js",
                      "~/Content/dist/js/adminlte.min.js",
                      "~/Content/dist/js/demo.js",
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js"));
        }
    }
}
