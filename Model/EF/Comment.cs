using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("Comments")]
    public partial class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Câu hỏi")]
        public string CauHoi { get; set; }
        [Display(Name = "Câu trả lời")]
        public string CauTraLoi { get; set; }
        [Display(Name = "Avata")]
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Display(Name = "Sản phẩm")]
        public int? IdSanPham { get; set; }
        public bool Isdelete { get; set; }
        [Display(Name = "Tên người hỏi")]
        public string TenNguoiHoi { get; set; }

    }
}
