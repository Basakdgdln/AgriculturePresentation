﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IContactService _contactService;
        public DefaultController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.Insert(p);
            return RedirectToAction("Index", "Default");
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
