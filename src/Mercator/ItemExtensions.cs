using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mercator.Attributes;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

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
                var attribute = property.GetCustomAttributes(typeof(SitecoreField)).FirstOrDefault() as SitecoreField;

                if (attribute == null) break;

                property.SetValue(mappedObject, ID.TryParse(attribute.Identifier, out var itemId) ? GetFieldValue(item, itemId) : attribute.Identifier);
            }

            return mappedObject;
        }

        private static object GetFieldValue(Item item, ID identifier)
        {
            switch (item.Fields[identifier].Type)
            {
                case "Image": return new ImageField(item.Fields[identifier]);
            }
        }

        private static object GetFieldValue(Item item, string identifier)
        {
        }
    }
}
