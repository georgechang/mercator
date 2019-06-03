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
        public HtmlField Description { get; set; }

        [SitecoreField("Image")]
        public ImageField Image { get; set; }

        [SitecoreField("Link")]
        public LinkField Link { get; set; }

        [SitecoreField("{ABDECD77-1C41-406C-82E1-3A9ED4050115}")]
        public CheckboxField Checkbox { get; set; }

        [SitecoreField("{0E5015AE-2D95-4500-A723-91CC723A5AE7}")]
        public LookupField Droplink { get; set; }

        public string SomeOtherNonSitecoreContent { get; set; }
    }
}