using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderAdm
    {
        public long id { get; set; }
        public string ShipName { get; set; }
        public string Name { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public long orderid { get; set; }
        public int? Quantity { get;set; }
        public decimal? price { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
