using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMypham.Areas.Admin.Model
{
    public class Loaisanpham
    {
        public int LoaisanphamID { get; set; }
        [Display(Name = "Tên loại sản phẩm")]
        public string Tenloaisp { get; set; }
        [Display(Name = "Thông tin")]
        public string Thongtin { get; set; }
        [Display(Name = "Logo")]
        public string logo { get; set; }
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}