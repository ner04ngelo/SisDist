using System.Web.Optimization;

namespace Plantilla
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/css")
            .Include(
            "~/Content/css/light-bootstrap-dashboard.css",
            "~/Content/css/bootstrap.min.css"
           ));



            bundles.Add(new ScriptBundle("~/bundles/js").
            Include("~/Content/js/core/jquery.3.2.1.min.js",
            "~/Content/js/core/popper.min.js",
            "~/Content/js/core/bootstrap.min.js",
            "~/Content/js/plugins/bootstrap-switch.js",
            "~/Content/js/plugins/chartist.min.js",
            "~/Content/js/plugins/bootstrap-notify.js",
            "~/Content/js/light-bootstrap-dashboard.js?v=2.0.0",
            "~/Content/js/demo.js"
            ));
        }
    }
}