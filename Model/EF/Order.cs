namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }
        [Display(Name = "Ngày đặt hàng")]
        public DateTime? CreatedDate { get; set; }
        [Required(ErrorMessage = "Tên người nhận không được để trống")]
        public long? CustomerID { get; set; }
        [Display(Name = "Tên khách hàng")]
        [StringLength(2000)]
        public string ShipName { get; set; }
        [Display(Name = "Số điện thoại")]
        [StringLength(200)]
        public string ShipMobile { get; set; }
        [Display(Name = "Địa chỉ nhận hàng")]
        [StringLength(2000)]
        public string ShipAddress { get; set; }
        [Display(Name = "Email")]
        [StringLength(2000)]
        public string ShipEmail { get; set; }
        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }
        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        
    }
}
