using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers___Copy
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View(_adminService.GetListAll());
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin a)
        {
            _adminService.Insert(a);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAdmin(int id)
        {
            var value = _adminService.GetById(id);
            _adminService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var value = _adminService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAdmin(Admin a)
        {
            _adminService.Update(a);
            return RedirectToAction("Index");
        }
    }
}
