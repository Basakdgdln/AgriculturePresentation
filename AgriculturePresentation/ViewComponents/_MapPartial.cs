using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _MapPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            AgricultureContext c = new AgricultureContext();
            ViewBag.v = c.Addresses.Select(x => x.MapInfo).FirstOrDefault();
            return View();
        }
    }
}
