using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMypham.Areas.Admin.Context;
using WebMypham.Areas.Admin.Model;

namespace WebMypham.Models
{
    public class ItemGioHang
    {
        public string TeSP { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public decimal Giamoi { get; set; }
        public decimal ThanhTien { get; set; }
        public string HinhAnh { get; set; }
        public ItemGioHang (int iMaSP) //hàm khởi tạo giỏ hàng
        {
            using (Mypham db = new Mypham())
            {
                this.SanPhamID = iMaSP;
                Sanpham sp = db.Sanphams.Single(n => n.SanphamID == iMaSP);
                this.TeSP = sp.TeSP;
                this.HinhAnh = sp.Hinhanh;
                this.Giamoi = sp.Giamoi;
                this.SoLuong = 1;
                this.ThanhTien = Giamoi * SoLuong;
            }    
        }

        public ItemGioHang(int iMaSP, int SL) 
        {
            using (Mypham db = new Mypham())
            {
                this.SanPhamID = iMaSP;
                Sanpham sp = db.Sanphams.Single(n => n.SanphamID == iMaSP);
                this.TeSP = sp.TeSP;
                this.HinhAnh = sp.Hinhanh;
                this.Giamoi = sp.Giamoi;
                this.SoLuong = SL;
                this.ThanhTien = Giamoi * SoLuong;
            }
        }

    }
}

