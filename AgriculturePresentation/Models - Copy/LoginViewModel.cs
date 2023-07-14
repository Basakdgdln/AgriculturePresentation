using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Models___Copy
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "lütfen kullanıcı adını giriniz...")]
        public string Username { get; set; }

        [Required(ErrorMessage = "lütfen şifreyi giriniz...")]
        public string Password { get; set; }
    }
}

