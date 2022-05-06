using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMypham.Models
{
    public class Nguoidung
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tài khoản ")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nhập tài khoản")]
        public string Taikhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Password ")]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [Display(Name = "Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên ")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nhập họ tên")]
        public string Hoten { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Display(Name = "Nhập Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đia chi")]
        [Display(Name = "Nhập địa chỉ")]
        public string Diachi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập SĐT")]
        [Display(Name = "Nhập SĐT")]
        public string SDT { get; set; }
    }
}