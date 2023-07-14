using AgriculturePresentation.Models___Copy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers___Copy
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditWiewModel userEditWiewModel = new UserEditWiewModel();
            userEditWiewModel.Mail = value.Email;
            userEditWiewModel.Phone = value.PhoneNumber;
            return View(userEditWiewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditWiewModel p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Password == p.ConfirmPassword)
            {
                value.Email = p.Mail;
                value.PhoneNumber = p.Phone;
                value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, p.Password);
                var result = await _userManager.UpdateAsync(value);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
