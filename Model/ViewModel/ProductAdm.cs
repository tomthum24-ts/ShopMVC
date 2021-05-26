using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductAdm
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public string CategoryID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Status { get; set; }
        public bool TopHot { get; set; }
    }
}
