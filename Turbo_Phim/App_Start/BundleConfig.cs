using System.Web.Optimization;

namespace Turbo_Phim
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/jquery").IncludeDirectory("~/Scripts/", "*.js"));
            //bundles.Add(new ScriptBundle("~/bundles/ckfinder").Include("~/ckfinder/ckfinder.js"));
            //bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include("~/ckeditor/ckeditor.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content/", "*.css"));
        
        }
    }
}
