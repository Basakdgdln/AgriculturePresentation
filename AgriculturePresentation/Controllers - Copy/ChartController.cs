using AgriculturePresentation.Models___Copy;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers___Copy
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {
            List<ProductClass> productClasses = new List<ProductClass>();
            productClasses.Add(new ProductClass
            {
                productname = "Buğday",
                productvalue = 850
            });
            productClasses.Add(new ProductClass
            {
                productname = "Mercimek",
                productvalue = 480
            });
            productClasses.Add(new ProductClass
            {
                productname = "Arpa",
                productvalue = 250
            });
            productClasses.Add(new ProductClass
            {
                productname = "Pirinç",
                productvalue = 120
            });
            productClasses.Add(new ProductClass
            {
                productname = "Domates",
                productvalue = 960
            });

            return Json(new { jsonlist = productClasses });
        }

        //public IActionResult Index2()
        //{
        //    return View();
        //}
        //public IActionResult Chart(int value, string name)
        //{
        //    List<Ürünler> ürünlist = new List<Ürünler>();
        //    ürünlist.Add(new Ürünler 
        //    {
        //        UrunName= 
        //    });
        //    return View();
        //}
    }
}
