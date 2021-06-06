using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string CauHoi { get; set; }
        public string CauTraLoi { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? IdSanPham { get; set; }
        public bool Isdelete { get; set; }
        public string TenNguoiHoi { get; set; }

    }
}
