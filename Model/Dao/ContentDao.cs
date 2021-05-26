using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        ShopDbContext db = null;
        public ContentDao()
        {
            db = new ShopDbContext();
        }
        public Contents GetbyID(long id)
        {
            return db.Contents.Find(id);
        }
        public long Insert(Contents entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Contents entity)
        {
            try
            {
                var content = db.Contents.Find(entity.ID);
                content.Name = entity.Name;
                content.MetaTitle = entity.MetaTitle;
                content.Description = entity.Description;
                content.Image = entity.Image;
                content.CategoryID = entity.CategoryID;
                content.Detail = entity.Detail;
                content.MetaKeywords = entity.MetaKeywords;
                content.MetaDescriptions = entity.MetaDescriptions;
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
        public IEnumerable<Contents> ListAllPaging(int page, int pageSize)
        {
            return db.Contents.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.Contents.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<Contents> ListAll()
        {
            return db.Contents.Where(x => x.Status == true).ToList();
        }
        public Contents ViewDetail(long id)
        {
            return db.Contents.Find(id);
        }
    }
    
}
