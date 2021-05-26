using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocMVC.Areas.Admin.Models
{
    public class ProductViewCat
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public int CategoryID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public bool TopHot { get; set; }
    }
}