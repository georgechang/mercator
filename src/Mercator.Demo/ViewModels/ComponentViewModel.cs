using Mercator.Attributes;
using Sitecore.Data.Fields;

namespace Mercator.Demo.ViewModels
{
    public class ComponentViewModel
    {
        [SitecoreField("SingleLineText")]
        public TextField SingleLineText { get; set; }

        [SitecoreField("MultilineText")]
        public TextField MultilineText { get; set; }

        [SitecoreField("RichText")]
        public HtmlField RichText { get; set; }

        [SitecoreField("Image")]
        public ImageField Image { get; set; }

        [SitecoreField("GeneralLink")]
        public LinkField GeneralLink { get; set; }

        [SitecoreField("Date")]
        public DateField Date { get; set; }

        [SitecoreField("Checkbox")]
        public CheckboxField Checkbox { get; set; }

        [SitecoreField("File")]
        public FileField File { get; set; }

        [SitecoreField("Checklist")]
        public MultilistField Checklist { get; set; }

        [SitecoreField("Droplist")]
        public ValueLookupField Droplist { get; set; }

        [SitecoreField("GroupedDroplink")]
        public GroupedDroplinkField GroupedDroplinkField { get; set; }

        [SitecoreField("GroupedDroplist")]
        public GroupedDroplistField GroupedDroplistField { get; set; }

        [SitecoreField("Multilist")]
        public MultilistField Multilist { get; set; }

        [SitecoreField("NameValueList")]
        public NameValueListField NameValueList { get; set; }

        [SitecoreField("Treelist")]
        public MultilistField Treelist { get; set; }

        [SitecoreField("Droplink")]
        public LookupField Droplink { get; set; }

        [SitecoreField("Droptree")]
        public ReferenceField Droptree { get; set; }
        
        public string SomeOtherNonSitecoreContent { get; set; }
    }
}