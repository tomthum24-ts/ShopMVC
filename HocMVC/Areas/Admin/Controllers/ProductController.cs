using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        Mystring mystr = new Mystring();
        public ActionResult Index()
        {
            var dao = new ProductDao();
            var model = dao.ListAllPagingAd2();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewbag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                var ngaynhap = DateTime.Now;
                product.CreatedDate = ngaynhap;
                product.MetaTitle = mystr.ToVietAlias(product.MetaTitle);
                var dao = new ProductDao();
                long ID = dao.Insert(product);
                if (product.Status == false)
                {
                    product.Status = true;
                }
                else
                {
                    product.Status = false;
                }
                //var result = dao.Update(content);
                SetAlert("Thêm sản phẩm thành công", "success");
                SetViewbag();
            }

            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(model);
                SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "product");
                }
                else
                {
                    SetAlert("Cập nhật sản phẩm thất bại", "alert-danger");
                    ModelState.AddModelError("", "cập nhật sản phần thất bại");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductDao();
            var product = dao.GetbyID(id);
            SetViewbag(product.CategoryID);
            return View(product);
        }
        [HttpPost]     
        public void SetViewbag(long? selectedId = null)
        {
            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}