using Mercator.Attributes;
using Sitecore.Data;
using Sitecore.Data.Items;
using System.Linq;
using System.Reflection;

namespace Mercator
{
    public static class ItemExtensions
    {
        public static T Map<T>(this Item item) where T : new()
        {
            var mappedObject = new T();

            item.Fields.ReadAll();

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (!(property.GetCustomAttributes(typeof(SitecoreField)).FirstOrDefault() is SitecoreField attribute)) break;

                property.SetValue(mappedObject, ID.TryParse(attribute.Identifier, out var itemId) ? item.Fields[itemId] : item.Fields[attribute.Identifier]);
            }

            return mappedObject;
        }
    }
}
