using BlankUmbraco.Entities;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlankUmbraco.ViewModels
{
    public class NewsViewModel : PublishedContentWrapped
    {
        // The PublishedContentWrapped accepts an IPublishedContent item as a constructor
        public NewsViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        // Custom properties here...
        public ICollection<NewsItem> NewsItems { get; set; } = new List<NewsItem>();
    }
}