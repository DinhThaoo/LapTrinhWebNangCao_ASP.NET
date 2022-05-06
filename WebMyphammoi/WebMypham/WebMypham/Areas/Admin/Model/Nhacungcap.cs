using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMypham.Areas.Admin.Model
{
    public class Nhacungcap
    {
        public int NhacungcapID { get; set; }
        [Display(Name = "Tên nhà cung cấp")]
        public string TenNCC { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "SĐT")]
        public string SDT { get; set; }
        [Display(Name = "FAX")]
        public string Fax { get; set; }
        public virtual ICollection<Sanpham> Sanphams { get; set; }
        public virtual ICollection<Phieunhap> Phieunhaps { get; set; }
    }
}