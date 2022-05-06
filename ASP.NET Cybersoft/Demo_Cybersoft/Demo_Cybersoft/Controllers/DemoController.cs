using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Cybersoft.Models;

namespace Demo_Cybersoft.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        [HttpGet] //giao thức:
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]   
        //giao thức: Post là update khi ta ấn nút Submit để gửi gửi truyền dữ liệu đi cho nó upload rồi hiện ra , khi dùng cái này phải ghi rõ FormMethod.Post ... đã ghi kĩ bên Demo

        public ActionResult Index(FormCollection collection) 
        //FormCollection: là đối tượng để gửi các thẻ ở bên html qua, và truyền dữ liệu qua theo gaio thức post
        {
            return View();
        }

        [HttpGet] 
        //giao thức: get là kiểu update dữ liệu mới vào được khi chúng ta Reload trang (F5) 

        public ActionResult Demo()
        {
            //tạo 1 list TinhThanhPho
            List<TinhThanhPho> lstTTP = new List<TinhThanhPho>();
            TinhThanhPho ttp;
            ttp = new TinhThanhPho();
            ttp.MaThanhPho = 1;
            ttp.TenTinhThanhPho = "Hà Nội";
            lstTTP.Add(ttp);

            ttp = new TinhThanhPho();
            ttp.MaThanhPho = 2;
            ttp.TenTinhThanhPho = "Bắc Ninh ";
            lstTTP.Add(ttp);

            ViewBag.TinhThanhPho = new SelectList(lstTTP,"MaTinhThanhPho", "TenTinhThanhPho");

            return View();
        }

        [HttpPost]
        public ActionResult Demo(FormCollection collection) 
        {
            return View();
        }
    }
}