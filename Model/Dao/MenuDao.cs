using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        ShopDbContext db = null;
        public MenuDao()
        {
            db = new ShopDbContext();
        }
        public List<Menu> ListByGroup(int group)
        {
            return db.Menus.Where(x => x.TypeID == group && x.Status==true).ToList();
        }
        public List<ProductCategory> ListByCate(bool group)
        {
            return db.ProductCategories.Where(x => x.Status == true).ToList();
        }
        public List<Scritp_Header> ListAll()
        {
            return db.Scritp_Header.Where(x=>x.Status==true).ToList();
        }
    }
}
