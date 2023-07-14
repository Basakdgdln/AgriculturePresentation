using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
        IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View(_serviceService.GetListAll());
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View(new ServiceAddViewModel());
        }

        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.GetById(id);
            _serviceService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceService.GetById(id);
            return View("EditService", values);
        }

        [HttpPost]
        public IActionResult EditService(Service s)
        {
            _serviceService.Update(s);
            return RedirectToAction("Index");
        }

    }
}
