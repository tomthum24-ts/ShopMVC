namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Contents
    {
        public long ID { get; set; }
        
        [Display(Name = "Tên bài viết")]
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bài viết không được để trống")]
        public string Name { get; set; }
        [Display(Name = "Đường dẫn")]
        [StringLength(250)]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả")]
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "Hình ảnh")]
        [StringLength(250)]
        public string Image { get; set; }
        [Display(Name = "Danh mục")]
        public long? CategoryID { get; set; }
        [Display(Name = "Chi tiết")]
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Chi tiết không được để trống")]
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
        [Display(Name = "bài viết hot")]
        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }
        [Display(Name = "Ngôn ngữ")]
        [StringLength(2)]
        public string Language { get; set; }
    }
}
