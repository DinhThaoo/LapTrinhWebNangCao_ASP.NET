using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMypham.Areas.Admin.Context;
using WebMypham.Areas.Admin.Model;

namespace WebMypham.Controllers
{
    public class TimKiemController : Controller
    {
        Mypham db = new Mypham();
        // GET: TimKiem
        public ActionResult KQTimKiem(string sTuKhoa)
        {           
            var lstSP = db.Sanphams.Where(n => n.TeSP.Contains(sTuKhoa));
            return View(lstSP.OrderBy(n => n.TeSP));

        }
    }
}