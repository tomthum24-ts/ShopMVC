using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;



namespace Model.Dao
{
    
    public class UserDao
    {
        ShopDbContext db = null;
        public UserDao()
        {
            db = new ShopDbContext();
        }
        
       
        public long Insert (User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                    
                }

                user.Name = entity.Name;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                if (entity.Status == true)
                {
                    user.Status = true;
                }
                else
                {
                    user.Status = false;
                }
                
                db.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<User> ListAllPaging(int page,int pageSize)
        {
            return db.Users.OrderByDescending(x=>x.CreatedDate).ToPagedList(page,pageSize);
        }
        public User getbyid(string userName)
        {
            return db.Users.SingleOrDefault(x=>x.UserName==userName);
        }
        public User viewDetail(int id)
        {
            
            return db.Users.Find(id);
        }
        public int Login(string userName,string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName );
            if(result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                        return -2;
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
    }
}
