using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMypham.Areas.Admin.Model
{
    public class Hoadon
    {
        public int HoadonID { get; set; }
        public int SanphamID { get; set; }
        [Display(Name = "Đơn giá")]
        public int Dongia { get; set; }
        [Display(Name = "Số lượng")]
        public int Soluong { get; set; }
        [Display(Name = "Thành tiền")]
        public int Thanhtien { get; set; }
        public virtual Sanpham Sanpham { get; set; }
    }
}