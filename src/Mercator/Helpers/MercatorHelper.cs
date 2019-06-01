using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Mercator.Attributes;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Mercator.Helpers
{
    public class MercatorHelper
    {
        private readonly HtmlHelper _htmlHelper;

        public MercatorHelper(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public IHtmlString Field<T>(T model, Func<T, object> fieldFunc)
        {
            var property = fieldFunc(model);
            var sitecoreFieldAttributes = typeof(T).GetProperty(nameof(property))?.GetCustomAttributes(typeof(SitecoreField), false) as SitecoreField[];
            var sitecoreFieldAttribute = sitecoreFieldAttributes?.FirstOrDefault<SitecoreField>();

            return new HtmlString(FieldRenderer.Render(RenderingContext.Current.Rendering.Item, sitecoreFieldAttribute?.Identifier));
        }
    }
}
