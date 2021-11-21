using BlankUmbraco.Entities;
using BlankUmbraco.Services.Interfaces;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlankUmbraco.ViewModels
{
    public class HomeViewModel : PublishedContentWrapped
    {
        public readonly INewsService _newsService;

        // The PublishedContentWrapped accepts an IPublishedContent item as a constructor
        public HomeViewModel(IPublishedContent content,
            IPublishedValueFallback publishedValueFallback,
            INewsService newsService)
            : base(content, publishedValueFallback)
        {
            _newsService = newsService;
        }

        // Custom properties here...
        public ICollection<NewsItem> NewsItems {
            get
            {
                return _newsService.GetNewsItems();
            }
        }
    }
}