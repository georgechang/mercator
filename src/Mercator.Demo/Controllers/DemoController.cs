using Mercator.Demo.ViewModels;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Mercator.Demo.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Component()
        {
            var componentViewModel = RenderingContext.Current.Rendering.Item.Map<ComponentViewModel>();
            componentViewModel.SomeOtherNonSitecoreContent = "Hello nurse!";
            return View(componentViewModel);
        }
    }
}