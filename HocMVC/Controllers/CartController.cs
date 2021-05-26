using HocMVC.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HocMVC.Controllers
{
    public class CartController : BaseHomeController
    {
        // GET: Cart
        private const string CartSession = "CartSesssion";
        //Load Giỏ hàng
        public ActionResult Index()
        {
            var cart = Session[CartSession];
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
            return View(list);
        }
        //Cập nhật số lượng  item
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            SetAlert("Cập nhật thành công", "success");
            return Json(new
            {
                status = true
            });
        }
        //Xóa item
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            SetAlert("Xóa thành công", "warning");
            return Json(new
            {
                status = true
            });
            
        }
        //Thêm vào giỏ hàng
        public ActionResult AddItem(long productId, int quantity)
        {
            //var url = Request.UrlReferrer.ToString();
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            //Kiểm tra giỏ hàng
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;

                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            SetAlert("Thêm vào giỏ thành công", "success");
            return Redirect(Request.UrlReferrer.ToString());
            
        }
        [HttpGet]
        //Lấy Danh sách thanh toán
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
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
            return View(list);

        }
        //Lưu lại danh sách thanh toán
        [HttpPost]
        public ActionResult Payment(string txtName, string txtPhone,string TxtDiachi,string txtGhichu)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipName = txtName;
            order.ShipMobile = txtPhone;
            order.ShipAddress = TxtDiachi;
            order.Note = txtGhichu;
            var ten = "";
            var soluong = "";
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new Model.Dao.OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);                    
                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                    ViewBag.Total = total;
                    ten = item.Product.Name;
                    soluong = item.Quantity.ToString();
                }
               
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Public/TemplateOder/neworder.html"));

                content = content.Replace("{{CustomerName}}", txtName);
                content = content.Replace("{{Phone}}", txtPhone);
                content = content.Replace("{{Note}}", txtGhichu);
                content = content.Replace("{{Address}}", TxtDiachi);
                content = content.Replace("{{NameProduct}}", ten);
                content = content.Replace("{{Quanlity}}", soluong);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = "transon.it24@gmail.com";

                new Mail().SendMail(toEmail, "Đơn hàng mới ", content);
                Session[CartSession] = null;
            }
            catch (Exception)
            {
                Session[CartSession] = null;
                return Redirect("/hoan-thanh");
            }
            return Redirect("/hoan-thanh");
        }
        //Chuyển tới trang thành công
        public ActionResult Success()
        {
            return View();
        }
    }
}