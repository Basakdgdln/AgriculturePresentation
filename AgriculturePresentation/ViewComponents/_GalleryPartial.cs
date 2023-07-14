using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _GalleryPartial: ViewComponent
    {
        private readonly IImageService _imageService;

        public _GalleryPartial(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_imageService.GetListAll());
        }
    }
}
