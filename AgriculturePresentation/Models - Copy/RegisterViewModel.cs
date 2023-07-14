using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Models___Copy
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınız giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adınız giriniz!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi giriniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz!")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
        public string PasswordConfirm { get; set; }
    }
}
