using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyASPMVC2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Viết mới vào đây

            routes.MapRoute(
                 name: "My Example",
                 url: "{hello}/xin-chao-cac-ban",
                 defaults: new { controller = "Home", action = "Contact" }
            );

            routes.MapRoute( // của form FrontEndLayout, phải khai báo vào thì nó mới có để chạy ra đc
                name: "Trang 1",
                url: "trang_1",
                defaults: new { controller = "TVLT", action = "Index" }
           );

            routes.MapRoute(  // của form FrontEndLayout,
             name: "Trang 2",
             url: "trang_2",
             defaults: new { controller = "TVLT", action = "Index2" }
           );


            routes.MapRoute( //luôn giữ nguyên và nằm cuối cùng để khi nào không tìm thấy yêu cầu của mình thì n dùng cái này như mặc định
                name: "Default", //tên đặt cho cấu hình, khai báo 
                url: "{controller}/{action}/{id}", //nhận dạng url, chỉ định url có dạng ntn
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // trong HomeController và Index trong VIEW- HOME
            );
        }
    }
}
