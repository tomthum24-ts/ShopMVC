using System.Web;
using System.Web.Optimization;

namespace HocMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/java").Include(
                      "~/Public/Layout/plugins/Isotope/isotope.pkgd.min.js",
                      "~/Public/Layout/js/jquery-3.3.1.min.js",
                      "~/Public/Layout/styles/bootstrap4/bootstrap.min.js",
                      "~/Public/Layout/styles/bootstrap4/popper.js",
                      "~/Public/Layout/plugins/greensock/TweenMax.min.js",
                      "~/Public/Layout/plugins/greensock/TimelineMax.min.js",
                      "~/Public/Layout/plugins/scrollmagic/ScrollMagic.min.js",
                      "~/Public/Layout/plugins/greensock/animation.gsap.min.js",
                      "~/Public/Layout/plugins/greensock/ScrollToPlugin.min.js",
                      "~/Public/Layout/plugins/OwlCarousel2-2.2.1/owl.carousel.js",
                      "~/Public/Layout/plugins/easing/easing.js",
                      "~/Public/Layout/plugins/parallax-js-master/parallax.min.js",
                      "~/Public/Layout/js/shop_custom.js",
                      "~/Public/dist/js/demo.js"
                      ));

            bundles.Add(new StyleBundle("~/Layout/styles").Include(
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
                      "~/Public/dist/css/Layout.css",
                      "~/Public/Layout/styles/product_responsive.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
