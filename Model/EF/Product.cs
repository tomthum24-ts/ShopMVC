namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(500)]
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }
        [Display(Name="Đường dẫn")]

        [StringLength(250)]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả")]
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "hình ảnh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Display(Name = "Giá")]
        public decimal? Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }

        public bool? IncludedVAT { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Danh mục")]
        public long CategoryID { get; set; }

        //[Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Người tạo")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Người cập nhật")]
        [StringLength(50)]
        public string ModifiedBy { get; set; }
        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
        [Display(Name = "Hiển thị")]
        public bool Status { get; set; }
        [Display(Name = "Sản phẩm hot")]
        public bool TopHot { get; set; }

        public int? ViewCount { get; set; }
        [Display(Name = "Số sao")]
        public int? Star { get; set; }
        [Display(Name = "Số đánh giá")]
        public int? Vote { get; set; }
    }
}
