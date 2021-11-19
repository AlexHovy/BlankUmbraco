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
            var items = content.Children.Where(q => q.ContentType.Alias == "newsItem").ToList();
            foreach (var item in items)
            {
                var imageProp = item.GetProperty("Image").GetValue() as MediaWithCrops;
                
                var newsItem = new NewsItem
                {
                    Name = item.Name,
                    Summary = item.GetProperty("summary").GetValue() as string,
                    Body = item.GetProperty("body").GetValue() as string,
                    ImageUrl = imageProp.LocalCrops.Src,
                    UpdatedOn = item.UpdateDate,
                    CreatedOn = item.CreateDate
                };
                NewsItems.Add(newsItem);
            }
        }

        // Custom properties here...
        public ICollection<NewsItem> NewsItems { get; set; } = new List<NewsItem>();
    }
}