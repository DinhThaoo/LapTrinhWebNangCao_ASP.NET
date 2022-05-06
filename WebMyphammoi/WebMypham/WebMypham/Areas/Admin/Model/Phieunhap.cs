using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMypham.Areas.Admin.Model
{
    public class Phieunhap
    {
        public int PhieunhapID { get; set; }
        public int NhacungcapID { get; set; }
        [Display(Name = "Ngày nhập")]
        public DateTime Ngaynhap { get; set; }
        [Display(Name = "Đã xóa")]
        public bool Daxoa { get; set; }
        public virtual Nhacungcap Nhacungcap { get; set; }
    }
}