using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlankUmbraco.Models
{
    public class HomeViewModel : PublishedContentWrapped
    {
        // The PublishedContentWrapped accepts an IPublishedContent item as a constructor
        public HomeViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        // Custom properties here...
        public string Test { get; set; }
    }
}