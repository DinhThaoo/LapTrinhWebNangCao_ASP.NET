using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMypham.Areas.Admin.Model
{
    public class Banner
    {
        public int BannerID { get; set; }
        [Display(Name = "Hình ảnh")]
        public string hinhanh { get; set; }
    }
}