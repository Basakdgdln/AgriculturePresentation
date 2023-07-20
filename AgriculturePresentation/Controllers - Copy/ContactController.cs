﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var deger = _contactService.GetListAll();
            return View(deger);
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _contactService.GetById(id);
            _contactService.Delete(value);
            return RedirectToAction("Index");
        }

        public IActionResult MessageDetails(int id)
        {
            var value = _contactService.GetById(id);
            ViewBag.tarih = value.Date.ToShortDateString() + " " + value.Date.ToShortTimeString();
            return View(value);
        }
    }
}
