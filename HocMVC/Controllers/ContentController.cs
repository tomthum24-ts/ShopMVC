using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {

            var content = new ContentDao().ListAll();
            ViewBag.Title = "Sinh lý Nam nữ";
            ViewBag.Description = "Sinh lý Nam nữ";
            ViewBag.Keywords = "Sinh lý Nam nữ";
            return View(content);
        }
        public ActionResult Detail(long id)
        {
            var model = new ContentDao().ViewDetail(id);
            ViewBag.Title = model.Name;
            ViewBag.Description = model.MetaDescriptions;
            ViewBag.Keywords = model.MetaKeywords;
            return View(model);
        }
    }
}