using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HLTClothes.ViewModel
{
    public class Register
    {
        [Required(ErrorMessage = "Tên người dùng không được bỏ trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Không để trống xác thực mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác thực mật khẩu không hợp lệ.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage ="Email không hợp lệ.")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}