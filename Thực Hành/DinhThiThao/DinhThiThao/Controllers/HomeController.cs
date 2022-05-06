using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThiThao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Models.ProductsModel> product = new List<Models.ProductsModel>()
            {
                new Models.ProductsModel()
                {
                    name = "Điện thoại",
                    price ="10000000",
                    imgURL = "/Assets/Images/600x600-crop-iphone-12-mini-128gb-xtmobile-c32e1960-40fd-414b-8144-fb8517a9de97",
                    
                }
            };
            return View();
              
        }
    }
}