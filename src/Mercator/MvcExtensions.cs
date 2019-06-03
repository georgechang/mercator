using Mercator.Helpers;
using System.Web.Mvc;

namespace Mercator
{
    public static class MvcExtensions
    {
        public static MercatorHelper Mercator(this HtmlHelper htmlHelper)
        {
            return new MercatorHelper(htmlHelper);
        }
    }
}
