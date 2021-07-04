using Model.EF;
using Model.ViewModel;
using System;
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
        public List<CommentViewModel> GetAllComment()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@trangthai",null??(object)DBNull.Value)
            };
            var Item = db.Database.SqlQuery<CommentViewModel>("GetAllComment @trangthai", param).ToList();
            return Item;
        }
        public List<Comment> ListCommentById(int id)
        {
            var Item= db.Comments.Where(x=>x.IdSanPham==id).ToList();
            return Item;
        }
        public long Insert(Comment entity)
        {
            entity.TenNguoiHoi = entity.TenNguoiHoi.ToUpper();
            entity.CreatedDate = DateTime.Now;
            db.Comments.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public Comment GetbyID(long id)
        {
            return db.Comments.Find(id);
        }
        public bool Update(Comment entity)
        {
            try
            {
                var content = db.Comments.Find(entity.Id);
                content.TenNguoiHoi = entity.TenNguoiHoi;
                content.IdSanPham = entity.IdSanPham;
                content.Image = entity.Image;
                content.Image = entity.Image;
                content.CauHoi = entity.CauHoi;
                content.CauTraLoi = entity.CauTraLoi;
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
        public bool Delete(long id)
        {
            var content = db.Comments.Find(id);
            content.Isdelete = !content.Isdelete;
            db.SaveChanges();
            return content.Isdelete;
        }
    }
} 
