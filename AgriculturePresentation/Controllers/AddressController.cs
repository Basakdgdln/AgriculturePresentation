using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers
{
    public class AddressController : Controller
    {
        IAddressService _addressService ;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            return View(_addressService.GetListAll());
        }
   
        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var value = _addressService.GetById(id);
            return View("EditAddress", value);
        }

        [HttpPost]
        public IActionResult EditAddress(Address address)
        {
            AddressValidator validationRules = new AddressValidator();
            ValidationResult result = validationRules.Validate(address);
            if (result.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
    }
}
