using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var product = new ProductDao().ListAll();
            return View(product);
        }
        public ActionResult ProductCategory(long cateId)
        {
            var category = new CategoryDao().ViewDetail(cateId);
            return View(category);
        }
        //[OutputCache(Duration =int.MaxValue,VaryByParam ="id",Location =System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Detail(long id)
        {
            //get name productcategory wwith id
            var category = new ProductCategoryDao();
            //var nameCat = category.getCat(int.Parse(id));
            //Get detail
            var pro = new ProductDao();
            var Comment = new CommentDao();
            var product = new ProductDao().ViewDetail(id);
            long idcat = product.CategoryID;
            int? _star = product.Star;
            int? _vote = product.Vote;
            ViewBag.Title = product.Name;
            ViewBag.Description = product.MetaDescriptions;
            ViewBag.Keywords = product.MetaKeywords;
            ViewBag.Catid = pro.ListCat(5, idcat);
           var idComment = Convert.ToInt32(id);
            
            try
            {
                ViewBag.CommentById = Comment.ListCommentById(idComment);
            }
            catch (Exception)
            {

                
            }
            
            try
            {
                ViewBag.Star = pro.Star(_star);
                ViewBag.Vote = _vote;
            }
            catch (Exception)
            {

                return View(product);
            }

            //ViewBag.ListHot = ProductDao().
            return View(product);
        }
        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true

            },JsonRequestBehavior.AllowGet
                );
        }
        public ActionResult Category(long cateId, int page = 1, int pageSize = 1)
        {
            var category = new CategoryDao().ViewDetail(cateId);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateId, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        
    }
}