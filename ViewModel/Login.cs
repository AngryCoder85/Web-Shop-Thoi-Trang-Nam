using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HLTClothes.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Tên người dùng không được bỏ trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password { get; set; }
    }
}