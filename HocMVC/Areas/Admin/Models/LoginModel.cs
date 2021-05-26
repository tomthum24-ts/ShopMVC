using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HocMVC.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required( ErrorMessage ="Nhập user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập Password")]
        public string password { get; set; }
        public bool remember { get; set; }
    }
    
}