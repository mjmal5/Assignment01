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
                    "~/Scripts/pizzaRatings.min.js"
            ));

            //Modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
            ));

            //Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"
            ));

            //Full Calendar
            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                    "~/Scripts/lib/moment.min.js",
                    "~/Scripts/fullcalendar.min.js"
            ));

            //Staff Calendar
            bundles.Add(new ScriptBundle("~/bundles/staffcalendar").Include(
                    "~/Scripts/staffCalendar.min.js"
            ));

            //Admin Calendar
            bundles.Add(new ScriptBundle("~/bundles/admincalendar").Include(
                    "~/Scripts/admincalendar.min.js"
            ));

            
            //Mapbox (Locations and Restaurant Finder Maps)
            bundles.Add(new ScriptBundle("~/bundles/mapbox").Include(
                    "~/Scripts/mapbox-gl-directions.min.js",
                    "~/Scripts/location.min.js"
            ));

            //DatePicker Constraints
            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/lib/moment.min.js",
                      "~/Scripts/datepicker-constraints.min.js"
            ));

            //JQuery DataTables
            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js"
            ));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.min.css",
                      "~/Content/jquery-ui.min.css",
                      "~/Content/style.min.css",
                      "~/Content/fullcalendar.min.css"
            ));

            bundles.Add(new StyleBundle("~/Content/mapbox-gl-directions").Include(
                      "~/Content/mapbox-gl-directions.min.css"
            ));



        }
    }
}
