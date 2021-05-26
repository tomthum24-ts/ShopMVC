using System.Web;
using System.Web.Optimization;

namespace HocMVC
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

            bundles.Add(new StyleBundle("~/Public/Layout/styles").Include(
                      "~/Public/Layout/styles/bootstrap4/bootstrap.min.css",
                      "~/Public/Layout/plugins/fontawesome-free-5.0.1/css/fontawesome-all.css",
                      "~/Public/Layout/plugins/OwlCarousel2-2.2.1/owl.carousel.css",
                      "~/Public/Layout/plugins/OwlCarousel2-2.2.1/owl.theme.default.css",
                      "~/Public/Layout/plugins/OwlCarousel2-2.2.1/animate.css",
                      "~/Public/Layout/plugins/jquery-ui-1.12.1.custom/jquery-ui.css",
                      "~/Public/Layout/styles/shop_styles.css",
                      "~/Public/Layout/styles/shop_responsive.css",
                      "~/Public/Layout/styles/bootstrap4/jquery-ui.css",
                      "~/Public/Layout/styles/blog_styles.css",
                      "~/Public/Layout/styles/blog_responsive.css",
                      "~/Public/Layout/styles/product_styles.css",
                      "~/Public/Layout/styles/product_responsive.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
