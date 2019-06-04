using Mercator.Attributes;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System.Linq;
using System.Reflection;

namespace Mercator
{
    public static class ItemExtensions
    {
        public static T Map<T>(this Item item) where T : new()
        {
            return Map(item, new T());
        }

        public static T Map<T>(this Item item, T mappedObject) where T : new()
        {
            item.Fields.ReadAll();

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (!(property.GetCustomAttributes(typeof(SitecoreField)).FirstOrDefault() is SitecoreField attribute)) break;

                var constructor = property.PropertyType.GetConstructor(new[] { typeof(Field) });

                if (constructor == null) continue;

                var field = ID.TryParse(attribute.Identifier, out var itemId) ? item.Fields[itemId] : item.Fields[attribute.Identifier];
                var activator = LambdaHelper.GetActivator(constructor);
                property.SetValue(mappedObject, activator(field));
            }

            return mappedObject;
        }
    }
}
