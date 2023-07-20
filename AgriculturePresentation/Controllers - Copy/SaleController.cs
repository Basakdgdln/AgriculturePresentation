using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers___Copy
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        SaleValidator sv = new SaleValidator();
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public IActionResult Index()
        {
            return View(_saleService.GetListWithProduct());
        }

        [HttpGet]
        public IActionResult AddSale()
        {
            ProductManager pm = new ProductManager(new EfProductDal());
            List<SelectListItem> product = (from x in pm.GetListAll()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.ProductID.ToString()
                                            }).ToList();
            ViewBag.product = product;
            return View();
        }

        [HttpPost]
        public IActionResult AddSale(Sale sales)
        {
            ValidationResult result = sv.Validate(sales);
            if (result.IsValid)
            {
                sales.Date = DateTime.Now;
                _saleService.Insert(sales);
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
        public IActionResult EditSale(int id)
        {
            ProductManager pm = new ProductManager(new EfProductDal());
            List<SelectListItem> product = (from x in pm.GetListAll()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.ProductID.ToString()
                                            }).ToList();
            ViewBag.product = product;
            ViewBag.date = _saleService.GetListAll().Where(x => x.SaleID == id).Select(x => x.Date.ToShortDateString() + " " + x.Date.ToShortTimeString()).FirstOrDefault();
            ViewBag.amount = _saleService.GetListAll().Where(x => x.SaleID == id).Select(x => x.TotalAmount).FirstOrDefault();
            var value = _saleService.GetListAll().Where(x => x.SaleID == id).Select(x => x.ProductID).FirstOrDefault();
            ViewBag.price = pm.GetListAll().Where(x => x.ProductID == value).Select(x => x.Price).FirstOrDefault();
            var deger = _saleService.GetById(id);
            return View("EditSale", deger);
        }

        [HttpPost]
        public IActionResult EditSale(Sale sale)
        {
            ValidationResult result = sv.Validate(sale);
            if (result.IsValid)
            {

                _saleService.Update(sale);
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
