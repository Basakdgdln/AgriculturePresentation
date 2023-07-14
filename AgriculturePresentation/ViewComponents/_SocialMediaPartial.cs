using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _SocialMediaPartial: ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public _SocialMediaPartial(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_socialMediaService.GetListAll());
        }
    }
}
