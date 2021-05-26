using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class ProductCategoryDao
    {
        ShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new ShopDbContext();
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.ToList();
        }
        public List<ProductCategory> getCat(int id)
        {
            return db.ProductCategories.Where(m => m.ID == id).ToList();
        }
        public bool ChangeStatus(long id)
        {
            var product = db.ProductCategories.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }
    }
}
