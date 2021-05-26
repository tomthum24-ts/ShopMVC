using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(int page=1, int pageSize=1000)
        {
            var dao = new CategoryDao();
            var content = dao.ListAllPaging(page, pageSize);
            return View(content);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CategoryDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                var ngaynhap = DateTime.Now;
                category.CreatedDate = ngaynhap;
                var dao = new CategoryDao();
                long ID = dao.Insert(category);
                //if (category.Status == false)
                //{
                //    category.Status = true;
                //}
                //else
                //{
                //    category.Status = false;
                //}
                category.Status = true;
                var result = dao.Update(category);
                SetAlert("Thêm loại tin thành công", "success");
            }

            return RedirectToAction("Index", "category");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(model);
                if (result)
                {
                    SetAlert("cập nhật danh mục thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetAlert("Cập nhật danh mục không thành công", "alert-danger");
                    ModelState.AddModelError("", "cập nhật danh mục không thành công");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new CategoryDao();
            var content = dao.GetbyID(id);
            return View(content);
        }

    }
}