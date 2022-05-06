
using MyASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MyASPMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //video 3 - làm việc với Database
        {
        }

        public ActionResult About( string id ) // video 1-2 dạng hiện thị ra thui
        {
            //B2 khi tạo mới thì phải using để nó tự sinh ra thì mới không lỗi 
            MyModel myobj = new MyModel();
            myobj.NAME = " ĐINH THỊ THẢO ";  // NAME, PHONE là 2 thông mới tạo bên MyModel
            myobj.PHONE = " 0973782719";

            ViewBag.Message = "Your application description page. + " + id;
            ViewBag.ThuocTinhA = 1;     // B2: khai báo ViewBag
            ViewBag.ThuocTinhB = "ABCXXX";

            ViewBag.OB = myobj; //gọi từ dạng model sang 

            return View( myobj ); // xong thì phải truyền dl vào đây
        }

        public ActionResult Contact(string hello)
            //khi truyền vào hello rồi thì ở ULR mình gõ chữ gì thay thế vào đấy n đều hiện ra ở chỗ +hello 
            //ví dụ localhost/ thư viện lập trình/Contact
        {

            ViewBag.Message = "Your contact page." +hello;
            ViewBag.Thu = " THỬ PHÁT BÊN NÀY XEM CÓ RA KHÔNG ";

            return View();
        }
    }
}

//khai báo myDB của Provider vào đây
