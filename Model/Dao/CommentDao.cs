using Model.EF;
using System.Collections.Generic;
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
        public List<Comment> ListCommentById(int top)
        {
            var Item= db.Comments.Where(x=>x.IdSanPham==top).ToList();
            return Item;
        }
    }
}
