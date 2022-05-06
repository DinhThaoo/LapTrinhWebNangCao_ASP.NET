using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMypham.Areas.Admin.Model
{
    public class Khachhang
    {
        public int KhachhangID { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string TenKH { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "SĐT")]
        public string SDT { get; set; }

    }
}