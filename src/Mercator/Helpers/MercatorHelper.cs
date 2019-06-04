using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Mercator.Helpers
{
    public class MercatorHelper<T>
    {
        private readonly HtmlHelper<T> _htmlHelper;

        public MercatorHelper(HtmlHelper<T> htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public IHtmlString Field(Expression<Func<T, CustomField>> fieldFunc)
        {
            return Field(_htmlHelper.ViewData.Model, fieldFunc);
        }

        public IHtmlString Field<TModel>(TModel model, Expression<Func<TModel, CustomField>> fieldFunc)
        {
            var property = fieldFunc.Compile()(model);

            var memberExpression = fieldFunc.Body as MemberExpression;
            var propertyInfo = memberExpression?.Member as PropertyInfo;
            if (propertyInfo == null) return null;

            if (Convert.ChangeType(property, propertyInfo.PropertyType) is CustomField propertyValue)
            {
                return propertyValue.InnerField.HasValue ? new HtmlString(FieldRenderer.Render(propertyValue.InnerField.Item, propertyValue.InnerField.Name)) : null;
            }

            return null;
        }
    }
}
