using BlankUmbraco.Entities;
using BlankUmbraco.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlankUmbraco.ViewModels
{
    public class NewsViewModel : PublishedContentWrapped
    {
        private readonly INewsService _newsService;

        // The PublishedContentWrapped accepts an IPublishedContent item as a constructor
        public NewsViewModel(IPublishedContent content,
            IPublishedValueFallback publishedValueFallback,
            INewsService newsService)
            : base(content, publishedValueFallback)
        {
            _newsService = newsService;
        }

        // Custom properties here...
        public ICollection<NewsItem> NewsItems
        {
            get
            {
                return _newsService.GetNewsItems();
            }
        }
    }
}