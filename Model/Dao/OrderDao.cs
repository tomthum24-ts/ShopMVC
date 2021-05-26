using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
   public class OrderDao
    {
        ShopDbContext db = null;
        public OrderDao()
        {
            db = new ShopDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public List<OrderAdm> Listall()
        {

            var model = from a in db.OrderDetails
                        join b in db.Orders
                        on a.OrderID equals b.ID
                        select new OrderAdm
                        {
                            id = b.ID,
                            Name = b.ShipName,
                            ShipMobile = b.ShipMobile,
                            ShipAddress = b.ShipAddress,
                            Status = b.Status,
                            Note = b.Note,
                            orderid = b.ID,
                            Quantity = a.Quantity,
                            price = a.Price,
                        };
            return model.ToList();
        }
        public List<Order> Listall2()
        {
            return db.Orders.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public IEnumerable<Order> ListAllPagingAd(int page, int pageSize)
        {
            //return db.Orders.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
            var list = db.Database.SqlQuery<Order>("List_all_order").OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
            return list ;
        }
        public List<OrderAdm> Detail(long id)
        {

            //var list = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            //    return list;
            var model = from a in db.OrderDetails
                        join b in db.Orders on a.OrderID equals b.ID
                        join c in db.Products on a.ProductID equals c.ID
                        where a.OrderID==id
                        select new OrderAdm
                        {
                            id = b.ID,
                            ShipName = b.ShipName,
                            Name= c.Name,
                            ShipMobile = b.ShipMobile,
                            ShipAddress = b.ShipAddress,
                            Status = b.Status,
                            Note = b.Note,
                            orderid = b.ID,
                            Quantity = a.Quantity,
                            price = a.Price,
                        };
            return model.ToList();
        }
    }

}
