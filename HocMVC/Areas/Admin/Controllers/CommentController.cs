using Model.Dao;
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
        public ActionResult ListAllComment(int id)
        {
            var product = new CommentDao().ListCommentById(id);
            return View(product);
        }
    }
}