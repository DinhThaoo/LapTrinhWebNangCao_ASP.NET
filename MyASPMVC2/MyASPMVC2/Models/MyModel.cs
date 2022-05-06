using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyASPMVC2.Models
{
    public class MyModel
    {
        // B1< tương tác giữa model và actio About> khai báo 2 thông tin -> Vào HomeController tạo object 
        public string NAME { get; set; }
        public string PHONE { get; set; }
    }
}