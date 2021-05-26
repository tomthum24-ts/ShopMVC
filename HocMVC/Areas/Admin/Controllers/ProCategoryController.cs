using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class ProCategoryController : Controller
    {
        // GET: Admin/ProCategory
    
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult loadData()
        {
            var dao = new ProductCategoryDao();
            var model = dao.ListAll();
            
            return Json(new
            {
                data = model,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductCategoryDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}