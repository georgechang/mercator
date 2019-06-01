using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercator.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SitecoreField : Attribute
    {
        public string Identifier { get; }

        public SitecoreField(string identifier)
        {
            Identifier = identifier;
        }
    }
}
