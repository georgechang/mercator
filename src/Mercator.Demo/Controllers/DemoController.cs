using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mercator.Demo.ViewModels;
using Sitecore.Mvc.Presentation;

namespace Mercator.Demo.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Banner()
        {
            var bannerViewModel = RenderingContext.Current.Rendering.Item.Map<BannerViewModel>();
            return View(bannerViewModel);
        }
    }
}