using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class CommentController : BaseController
    {
        // GET: Admin/Comment
        public ActionResult Index()
        {
            var comment = new CommentDao().GetAllComment();
            return View(comment);

        }
        [HttpPost]
        public ActionResult ListAllComment(int id)
        {
            var product = new CommentDao().ListCommentById(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewbag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Comment comment)
        {

            if (ModelState.IsValid)
            {
                comment.CreatedDate = DateTime.Now;

                var dao = new CommentDao();
                long ID = dao.Insert(comment);

                //var result = dao.Update(content);
                SetAlert("Thêm sản phẩm thành công", "success");
            }

            return RedirectToAction("Index", "Comment");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new CommentDao();
            var comment = dao.GetbyID(id);
            SetViewbag(comment.Id);
            return View(comment);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Comment model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CommentDao();
                var result = dao.Update(model);
                SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật comment thành công", "success");
                    return RedirectToAction("Index", "Comment");
                }
                else
                {
                    SetAlert("Cập nhật comment thất bại", "alert-danger");
                    ModelState.AddModelError("", "cập nhật comment thất bại");
                }
            }

            return View();
        }
        [HttpPost]
        public void SetViewbag(long? selectedId = null)
        {
            var dao = new ProductDao();
            ViewBag.IdSanPham = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CommentDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}