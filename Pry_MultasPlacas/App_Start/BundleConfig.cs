using System.Web;
using System.Web.Optimization;

namespace Pry_MultasPlacas
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/generalJS").Include(
             "~/Scripts/jquery-3.1.1.min.js",
             "~/Scripts/bootstrap.min.js",
             "~/Scripts/highchecktree.js",
             "~/Scripts/generalJS.js",
             "~/Scripts/loader.js",
             "~/Scripts/bluebird.min.js",
             "~/Scripts/sweetalert2.min.js"
));


            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.min.css",
                  "~/Content/index.css",
                  "~/Content/normalize.css",
                   "~/Content/sweetalert2.min.css",
                   "~/Content/easy-autocomplete.min.css",
                   "~/Content/custom.css"
                  ));

            bundles.Add(new ScriptBundle("~/bundles/BuscadorJS").Include(
                  "~/Scripts/jquery-ui.js",
                  "~/Scripts/BuscadorPlacasJS.js"
                  ));
        }
    }
}
