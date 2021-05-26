using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class CategoryDao
    {
        ShopDbContext db = null;
        public CategoryDao()
        {
            db = new ShopDbContext();
        }
        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Category entity)
        {
            try
            {
                var cate = db.Categories.Find(entity.ID);
                

                cate.Name = entity.Name;
                cate.MetaTitle = entity.MetaTitle;
                cate.SeoTitle = entity.SeoTitle;
                cate.ModifiedBy = entity.ModifiedBy;
                cate.ModifiedDate = DateTime.Now;
                if (entity.Status == true)
                {
                    cate.Status = true;
                }
                else
                {
                    cate.Status = false;
                }

                db.SaveChanges();
                return true;



            }
            catch (Exception)
            {

                return false;
            }
        }
        public Category GetbyID(long id)
        {
            return db.Categories.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var cate = db.Categories.Find(id);
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }

            catch (Exception)
            {

                return false;
            }

        }
        public IEnumerable<Category> ListAllPaging(int page, int pageSize)
        {
            return db.Categories.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public bool ChangeStatus(long id)
        {
            var cate = db.Categories.Find(id);
            cate.Status = !cate.Status;
            db.SaveChanges();
            return cate.Status;
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
        public List<Product> ListCat(int top)
        {
            return db.Products.Where(x => x.Status==true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
    }
}
