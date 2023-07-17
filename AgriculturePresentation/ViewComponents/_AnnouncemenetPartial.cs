using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _AnnouncemenetPartial: ViewComponent
    {
        private readonly IAnnouncemenetService _announcemenetService;

        public _AnnouncemenetPartial(IAnnouncemenetService announcemenetService)
        {
            _announcemenetService = announcemenetService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_announcemenetService.GetListAll());
        }
    }
}
