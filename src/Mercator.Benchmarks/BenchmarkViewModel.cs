using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercator.Attributes;
using Sitecore.Data.Fields;

namespace Mercator.Benchmarks
{
    public class BenchmarkViewModel
    {
        [SitecoreField("Title")]
        public TextField Title { get; set; }

        [SitecoreField("Description")]
        public HtmlField Description { get; set; }

        [SitecoreField("Link")]
        public LinkField Link { get; set; }
    }
}
