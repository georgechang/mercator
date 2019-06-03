using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mercator.Attributes;
using Sitecore.Data.Fields;

namespace Mercator.Demo.ViewModels
{
    public class BannerViewModel
    {
        [SitecoreField("Title")]
        public TextField Title { get; set; }

        [SitecoreField("Description")]
        public TextField Description { get; set; }

        [SitecoreField("Image")]
        public ImageField Image { get; set; }

        [SitecoreField("Link")]
        public LinkField Link { get; set; }
    }
}