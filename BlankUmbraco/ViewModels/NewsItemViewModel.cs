using BlankUmbraco.Entities;
using BlankUmbraco.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlankUmbraco.ViewModels
{
    public class NewsItemViewModel : PublishedContentWrapped
    {
        private int ContentId { get; set; }

        private readonly INewsService _newsService;

        // The PublishedContentWrapped accepts an IPublishedContent item as a constructor
        public NewsItemViewModel(IPublishedContent content,
            IPublishedValueFallback publishedValueFallback,
            INewsService newsService)
            : base(content, publishedValueFallback)
        {
            ContentId = content.Id;

            _newsService = newsService;
        }

        // Custom properties here...
        public NewsItem NewsItem
        {
            get
            {
                return _newsService.GetNewsItemById(ContentId);
            }
        }
    }
}