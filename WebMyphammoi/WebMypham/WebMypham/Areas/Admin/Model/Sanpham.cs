using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMypham.Areas.Admin.Model
{
    public class Sanpham
    {
        public int SanphamID { get; set; }
        [Display (Name="Tên sản phẩm")]
        public string TeSP { get; set; }
        [Display(Name = "Giá cũ")]
        public int Giacu { get; set; }
        [Display(Name = "Giá mới")]
        public int Giamoi { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime Ngaycapnhat { get; set; }
        [Display(Name = "Thành phần")]
        public string Thanhphan { get; set; }
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Hinhanh { get; set; }
        [Display(Name = "Số lượng tồn")]
        public int Soluongton { get; set; }
        [Display(Name = "Số lượng xem")]
        public int Soluongxem { get; set; }
        [Display(Name = "Số lượng mua")]
        public int Soluongmua { get; set; }
        public int NhacungcapID { get; set; }
        public int LoaisanphamID { get; set; }
        public virtual Nhacungcap Nhacungcap { get; set; }
        public virtual Loaisanpham Loaisanpham { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }

    }
}