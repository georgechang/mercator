using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Mercator.Attributes;
using Mercator.Helpers;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Pipelines.RenderField;

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
