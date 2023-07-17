using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers___Copy
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProductWithCategory());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(product);
            if (result.IsValid)
            {
                _productService.Insert(product);
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

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var deger = _productService.GetById(id);
            return View("EditProduct", deger);
        }

        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                _productService.Update(p);
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
