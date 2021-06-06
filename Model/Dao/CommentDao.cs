using Model.EF;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Model.Dao
{
    public class CommentDao
    {
        ShopDbContext db = null;

        public CommentDao()
        {
            db = new ShopDbContext();
        }
        public List<Comment> ListCommentById(int id)
        {
            var Item= db.Comments.Where(x=>x.IdSanPham==id).ToList();
            //object[] request = new 
            //{
            //    new SqlParameter("@Product",id)
            //};
            //var item2 = db.Database.ExecuteSqlCommand("GetItemProduct", request);
            return Item;
        }
    }
}
