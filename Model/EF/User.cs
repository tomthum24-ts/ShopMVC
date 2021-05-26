namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        //[Required(ErrorMessage = "Bạn chưa nhập user")]
        public string UserName { get; set; }
        [StringLength(32)]
        //[Required(ErrorMessage = "Bạn chưa nhập password")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Nhóm")]
        [StringLength(20)]
        public string GroupID { get; set; }
        [Display(Name = "Họ và tên")]
        [StringLength(50)]
        //[Required(ErrorMessage = "Bạn chưa nhập Tên")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(50)]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Display(Name = "Tỉnh/Thành phố")]
        public int? ProvinceID { get; set; }
        [Display(Name = "Quận/Huyện")]
        public int? DistrictID { get; set; }
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
        [Display(Name="Trạng thái ")]
        public bool Status { get; set; }
    }
}
