using Mercator.Demo.ViewModels;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Mercator.Demo.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult MercatorComponent()
        {
            var componentViewModel = RenderingContext.Current.Rendering.Item.Map<MercatorComponentViewModel>();
            componentViewModel.SomeOtherNonSitecoreContent = "Hello nurse!";
            return View(componentViewModel);
        }

        public ActionResult SitecoreComponent()
        {
            var componentViewModel = new SitecoreComponentViewModel();
            componentViewModel.Item = RenderingContext.Current.Rendering.Item;
            componentViewModel.SomeOtherNonSitecoreContent = "Hello nurse!";
            return View(componentViewModel);
        }
    }
}