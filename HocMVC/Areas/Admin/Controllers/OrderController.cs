using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Oder
        public ActionResult Index()
        {
            var dao = new OrderDao();
            var model = dao.Listall2();
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var dao = new OrderDao();
            var model = dao.Detail(id);
            return View(model);
        }
    }
}