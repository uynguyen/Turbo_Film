using System.Web.Optimization;

namespace Turbo_Phim
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
<<<<<<< HEAD


            bundles.Add(new ScriptBundle("~/bundles/jquery").IncludeDirectory("~/Scripts/", "*.js"));
            //bundles.Add(new ScriptBundle("~/bundles/ckfinder").Include("~/ckfinder/ckfinder.js"));
            //bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include("~/ckeditor/ckeditor.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
=======
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js",
            //            "~/Scripts/jquery-ui.js",
            //            "~/Scripts/jquery-ui.min.js",
            //            "~/Scripts/jquery.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").IncludeDirectory("~/Scripts/", "*.js"));
>>>>>>> 14c573be6204f39af0baa542494024f789a525cf
            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content/", "*.css"));
        
        }
    }
}
