using Mercator.Attributes;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Mercator.Helpers
{
    public class MercatorHelper
    {
        private readonly HtmlHelper _htmlHelper;

        public MercatorHelper(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public IHtmlString Field<T>(T model, Expression<Func<T, object>> fieldFunc)
        {
            var memberExpression = fieldFunc.Body as MemberExpression;
            var propertyInfo = memberExpression?.Member as PropertyInfo;
            var sitecoreFieldAttributes = propertyInfo?.GetCustomAttributes(typeof(SitecoreField), false) as SitecoreField[];
            var sitecoreFieldAttribute = sitecoreFieldAttributes?.FirstOrDefault<SitecoreField>();

            return new HtmlString(FieldRenderer.Render(RenderingContext.Current.Rendering.Item, sitecoreFieldAttribute?.Identifier));
        }
    }
}
