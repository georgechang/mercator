using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mercator.Demo.ViewModels;

namespace Mercator.Demo.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Banner()
        {
            return View(new BannerViewModel());
        }
    }
}