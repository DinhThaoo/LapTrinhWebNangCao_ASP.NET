using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMypham.Areas.Admin.Context;
using WebMypham.Models;
using WebMypham.Areas.Admin.Model;
namespace WebMypham.Controllers
{
    public class GioHangController : Controller
    {
        Mypham db = new Mypham();
       
        //lấy giỏ hàng 
        public List<ItemGioHang> LayGioHang()
        {
            //Gio hàng đã tồn tại, dùng session để lưu giỏ hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>; 
            if (lstGioHang == null)
            {
                //Nếu giỏ Secssion giỏ hàng chưa tồn tại thì khởi tạo giỏ hàng
                lstGioHang = new List<ItemGioHang>();
                Session["GioHang"] = lstGioHang;
                
            }
            return lstGioHang;
        }

        
        public ActionResult ThemGioHang ( int MaSP, string strURL )
        {
            //check sp CSDL
            Sanpham sp = db.Sanphams.SingleOrDefault(n=>n.SanphamID== MaSP);
            if (sp ==null )
            {
                
                Response.StatusCode = 404;
                return null;
            }

            List<ItemGioHang> lstGioHang = LayGioHang();
            //TH1: sp đã tồn tại trong giỏ hàng 
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.SanPhamID == MaSP);
            if (spCheck !=null)
            {
                if( sp.Soluongton < spCheck.SoLuong) //check sl
                {
                    return View("ThongBao");
                }    
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.Giamoi;
                return Redirect(strURL);
            }
           //th2: chưa tồn tại -> tạo 1 item giỏ hàng -> add n vào 1 list
            ItemGioHang itemGH = new ItemGioHang(MaSP);
            if (sp.Soluongton < itemGH.SoLuong) 
            {
                return View("ThongBao"); 
            }
            lstGioHang.Add(itemGH);             
            return Redirect(strURL);

        }

        public double TinhTongSoLuong()
        {
            //lấy giỏ hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.SoLuong);
        }

        //tính tổng tiền
        public decimal TinhTongTien()
        {
            //lấy giỏ hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ThanhTien);
        }

        public ActionResult GioHangPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }

        // GET: GioHang
        public ActionResult XemGioHang()
        {
            //lấy giỏ hàng   
            List<ItemGioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

       
         public ActionResult CapNhatGioHang(FormCollection form)
        {
            int idSanPham =int.Parse(form["ID_SP"]);
            int _soluong = int.Parse(form["soLuongSP"]);
            Sanpham spCheck = db.Sanphams.Single(n => n.SanphamID == idSanPham);
            if (_soluong < 0)
            {
                _soluong = 0;
            }
            if (spCheck.Soluongton < _soluong)
            {
                return View("ThongBao");
            }
            List<ItemGioHang> lstGH = LayGioHang();
            ItemGioHang itemGHUpdate = lstGH.Find(n => n.SanPhamID == idSanPham);
            itemGHUpdate.SoLuong = _soluong;
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.Giamoi;
            return RedirectToAction("XemGioHang");
        }

        public ActionResult XoaGioHang(int MaSP)
        {
            // check session giỏ hàng 
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("TatCaSanPham", "Home");
            }
            //check sp CSDL
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.SanphamID == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lấy list giỏ hàng từ session
            List<ItemGioHang> lstGioHang = LayGioHang();
            // check sp GH 
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.SanPhamID == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("TatCaSanPham", "Home");
            }

            //Xóa item trong giỏ hàng
            lstGioHang.Remove(spCheck);
            return RedirectToAction("XemGioHang");
        }
    }
}