using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        ShopDbContext db = null;
        
        public ProductDao()
        {
            db = new ShopDbContext();
        }
        //lấy danh sách sản phẩm mới
        public List<Product> ListnewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Where(x=>x.Status==false&& x.TopHot == false).Take(top).ToList();
        }
        //Lấy danh sách sản phẩm hót
        public List<Product> ListHot(int top)
        {
            return db.Products.Where(x => x.TopHot == true&& x.Status==false).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListCat(int top, long id)
        {

            return db.Products.Where(x => x.Status==false&& x.CategoryID==id).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        //Xem chi tiết sản phẩm
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id); 
        }
        //Tìm kiếm sản phẩm
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        //Phân trang
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        //Get category product
        public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.CategoryID == categoryID
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        //Lấy ra danh sách product trang admin
        public IEnumerable<Product> ListAllPagingAd(int page, int pageSize)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<ProductAdm> ListAllPagingAd2()
        {
            var model1 = from a in db.ProductCategories
                        join b in db.Products
                        on a.ID equals b.CategoryID
                        select new ProductAdm
                        {
                            ID=b.ID,
                            Name = b.Name,
                            Image = b.Image,
                            Price = b.Price,
                            PromotionPrice = b.PromotionPrice,
                            CategoryID=a.Name,
                            CreatedDate=b.CreatedDate,
                            Status=b.Status,
                            TopHot=b.TopHot,

                        };
                return model1.ToList();
        }
        //Get product
        public List<Product> ListAll()
        {
            return db.Products.Where(x => x.Status == false).OrderByDescending(x=>x.CreatedDate).ToList();
        }
        //Insert product
        public long Insert(Product entity)
        {
            
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //Update product
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.MetaKeywords = entity.MetaKeywords;
                product.MetaDescriptions = entity.MetaDescriptions;
                product.CategoryID = entity.CategoryID;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                entity.ModifiedBy = entity.ModifiedBy;
                entity.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Get detail product
        public Product GetbyID(long id)
        {
            return db.Products.Find(id);
        }
        //Change status product
        public bool ChangeStatus(long id)
        {
            var product = db.Products.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }
        //Delete 
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        //Vote
        public string Star(object soluong)
        {
            if (soluong == null) soluong = 0;
            if (int.Parse(soluong.ToString()) == 1)
            {
                return "<span class='fa fa-star checked'></span><span class='fa fa-star'></span><span class='fa fa-star'></span><span class='fa fa-star'></span><span class='fa fa-star'></span>";
            }
            if (int.Parse(soluong.ToString()) == 2)
            {
                return "<span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star '></span><span class='fa fa-star '></span><span class='fa fa-star '></span>";
            }
            if (int.Parse(soluong.ToString()) == 3)
            {
                return "<span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star '></span><span class='fa fa-star '></span>";
            }
            if (int.Parse(soluong.ToString()) == 4)
            {
                return "<span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star '></span>";
            }
            else
            {
                return "<span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star checked'></span><span class='fa fa-star checked'></span>";
            }
        }
    }
}
