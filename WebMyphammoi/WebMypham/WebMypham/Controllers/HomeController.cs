using WebMypham.Areas.Admin.Context;
using WebMypham.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//OrderByDescending: sắp xếp theo thứ tự giảm dần
//OrderBy : tăng dần
namespace Myphamonline.Controllers
{
    public class HomeController : Controller
    {
        Mypham db = new Mypham();
        public ActionResult TatCaSanPham()
        {          
            ViewBag.SanPham = db.Sanphams.OrderByDescending(x => x.SanphamID).Take(10).ToList();
            ViewBag.DaDau = db.Sanphams.Where(x => x.LoaisanphamID == 3).Take(5).ToList();
            ViewBag.DaThuong = db.Sanphams.Where(x => x.LoaisanphamID == 4).Take(5).ToList();
            ViewBag.DaKho = db.Sanphams.Where(x => x.LoaisanphamID == 5).Take(5).ToList();
            return View();
        }

        public ActionResult ChiTietSanPham(string id)
        {
            // tìm sản phẩm có tên sản phầm = id 
            Sanpham sp = db.Sanphams.SingleOrDefault(x => x.TeSP.ToString() == id);
            //nếu không tìm thấy
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        public ActionResult SanPhamMoiNhat()
        {
            ViewBag.TrangSanPhamMoiNhat = db.Sanphams.OrderByDescending(x => x.Ngaycapnhat).Take(15).ToList();
            return View();
        }

        public ActionResult SanPhamBanChay()
        {
            ViewBag.TrangSanPhamBanChay = db.Sanphams.OrderByDescending(x => x.Soluongmua).Take(15).ToList();
            return View();
        }


        public ActionResult SuaRuaMat()  
        {
           
            ViewBag.SuaRuaMat = db.Sanphams.Where(x => x.LoaisanphamID == 1).Take(100).ToList();

            return View();
        }

        public ActionResult KemTriMun()
        {
            ViewBag.KemTriMun = db.Sanphams.Where(x => x.LoaisanphamID == 2).Take(100).ToList();

            return View();
        }
        public ActionResult SucKhoeVaSacDep()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult ChamSocKhachHang()
        {
            ViewBag.Message = "";

            return View();
        }

    }
}