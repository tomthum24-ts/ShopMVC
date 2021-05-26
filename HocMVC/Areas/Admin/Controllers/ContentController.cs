using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HocMVC.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        Mystring mystr = new Mystring();
        public ActionResult Index(int page=1, int pageSize=1000)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging( page, pageSize);
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
        public ActionResult Edit(Contents model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                model.MetaTitle = mystr.ToVietAlias(model.MetaTitle);
                var result = dao.Update(model);
                SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật bài viết thành công", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    SetAlert("Thêm user thành công", "alert-danger");
                    ModelState.AddModelError("", "cập nhật không user thành công");
                }
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetbyID(id);
            SetViewbag(content.CategoryID);
            return View(content);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Contents content)
        {
            
            if (ModelState.IsValid)
            {
                var ngaynhap = DateTime.Now;
                content.CreatedDate = ngaynhap;
                content.MetaTitle = mystr.ToVietAlias(content.MetaTitle);
                var dao = new ContentDao();
                long ID = dao.Insert(content);
                if (content.Status == false)
                {
                    content.Status = true;
                }
                else
                {
                    content.Status = false;
                }
                var result = dao.Update(content);
                SetAlert("Thêm tin tức thành công", "success");
                SetViewbag();
            }

            return RedirectToAction("Index", "Content");
        }
        public void SetViewbag(long? selectedId=null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(),"ID","Name", selectedId);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ContentDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}