using Mercator.Helpers;
using System.Web.Mvc;

namespace Mercator
{
    public static class MvcExtensions
    {
        public static MercatorHelper<T> Mercator<T>(this HtmlHelper<T> htmlHelper)
        {
            return new MercatorHelper<T>(htmlHelper);
        }
    }
}
