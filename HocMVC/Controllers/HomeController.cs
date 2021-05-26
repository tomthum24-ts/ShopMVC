using HocMVC.Common;
using HocMVC.Models;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var product = new ProductDao();
            ViewBag.Newproduct = product.ListnewProduct(1000);
            ViewBag.ListHot = product.ListHot(10);
            //ViewBag.Title = "Thuốc kích dục giá rẻ";
            //ViewBag.Description = "Thuốc kích dục giá rẻ ";
            //ViewBag.Keywords = "Thuốc kích dục giá rẻ";
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroup(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult CategoryMain()
        {
            var model = new MenuDao().ListByCate(true);
            return PartialView(model.ToList());
        }
        [ChildActionOnly]
        public ActionResult MainmenuMobile()
        {
            var model = new MenuDao().ListByGroup(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Slide()
        {
            var pro = new SlideDao();
            var model = new SlideDao().ListByGroup(1);
            ViewBag.Slide2 = pro.ListByGroup(2);
            ViewBag.Slide3 = pro.ListByGroup(3);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {

            var cart = Session[SessionKT.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                ViewBag.Total = total;
            }
            return PartialView(list);
        }
        public PartialViewResult Menubottom()
        {

            var cart = Session[SessionKT.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                ViewBag.Total = total;
            }
            return PartialView(list);
        }
        public ActionResult Script_Header()
        {
            var model = new MenuDao().ListAll();
            return PartialView(model);
        }
        public PartialViewResult AddItem()
        {

            var cart = Session[SessionKT.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                ViewBag.Total = total;
            }
            return PartialView(list);
        }
    }
}