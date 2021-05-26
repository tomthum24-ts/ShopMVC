using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(int page = 1, int pageSize = 1000)
        {
            var dao = new SlideDao();
            var model = dao.ListAllPagingAd(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Slide slide)
        {

            if (ModelState.IsValid)
            {
                var ngaynhap = DateTime.Now;
                slide.CreatedDate = ngaynhap;
                var dao = new SlideDao();
                long ID = dao.Insert(slide);
                if (slide.Status == false)
                {
                    slide.Status = true;
                }
                else
                {
                    slide.Status = false;
                }
                //var result = dao.Update(content);
                SetAlert("Thêm sản phẩm thành công", "success");
            }

            return RedirectToAction("Index", "Slide");
        }
    }
}