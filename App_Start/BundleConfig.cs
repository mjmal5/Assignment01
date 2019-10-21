using System.Web;
using System.Web.Optimization;

namespace FIT5032_Assignment
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js"
            ));

            //Jquery Validate
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
            ));

            //Jquery Canvas (Pizza Ratings Graph)
            bundles.Add(new ScriptBundle("~/bundles/canvas").Include(
                    "~/Scripts/jquery.canvasjs.min.js",
                    "~/Scripts/pizzaRatings.js"
            ));

            //Modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
            ));

            //Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
            ));

            //Custom
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/main.js"
            ));

            //Full Calendar
            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                    "~/Scripts/lib/moment.min.js",
                    "~/Scripts/fullcalendar.js"
            ));

            //Staff Calendar
            bundles.Add(new ScriptBundle("~/bundles/staffcalendar").Include(
                    "~/Scripts/staffcalendar.js"
            ));

            //Admin Calendar
            bundles.Add(new ScriptBundle("~/bundles/admincalendar").Include(
                    "~/Scripts/admincalendar.js"
            ));

            
            //Mapbox (Locations and Restaurant Finder Maps)
            bundles.Add(new ScriptBundle("~/bundles/mapbox").Include(
                    "~/Scripts/mapbox-gl-directions.js",
                    "~/Scripts/location.js"
            ));

            //DatePicker Constraints
            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/datepicker-constraints.js"
            ));

            //JQuery DataTables
            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js"
            ));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/style.css",
                      "~/Content/fullcalendar.min.css"
            ));

            bundles.Add(new StyleBundle("~/Content/mapbox-gl-directions").Include(
                      "~/Content/mapbox-gl-directions.css"
            ));



        }
    }
}
