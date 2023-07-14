using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _HeadPartial: ViewComponent
    {
       public IViewComponentResult Invoke()    // varsayılan olarak ınvoke adı kullanılır.
        {
            return View();
        }
    }
}
