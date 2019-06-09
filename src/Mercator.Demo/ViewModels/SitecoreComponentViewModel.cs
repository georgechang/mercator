using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Mercator.Demo.ViewModels
{
    public class SitecoreComponentViewModel
    {
        public string SomeOtherNonSitecoreContent { get; set; }

        public Item Item { get; set; }
    }
}