using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncemenetService _announcemenetService;

        public AnnouncementController(IAnnouncemenetService announcemenetService)
        {
            _announcemenetService = announcemenetService;
        }

        public IActionResult Index()
        {
            return View(_announcemenetService.GetListAll());
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement a)
        {
            a.Date = DateTime.Now;
            a.Status = false;
            _announcemenetService.Insert(a);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            var value = _announcemenetService.GetById(id);
            return View("EditAnnouncement", value);
        }

        [HttpPost]
        public IActionResult EditAnnouncement(Announcement a)
        {
            _announcemenetService.Update(a);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            _announcemenetService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            _announcemenetService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
