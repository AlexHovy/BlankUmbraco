using BlankUmbraco.Entities;
using BlankUmbraco.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace BlankUmbraco.Services
{
    public class NewsService : INewsService
    {
        const int ContentId = 1060;
        private IPublishedContent Content => _content.GetById(ContentId);

        private IUmbracoContent _content { get; set; }

        public NewsService(IUmbracoContent content)
        {
            _content = content;
        }

        public List<NewsItem> GetNewsItems()
        {
            var newsItems = new List<NewsItem>();

            var items = Content.Children.Where(q => q.ContentType.Alias == "newsItem").ToList();
            foreach (var item in items)
            {
                var imageProp = item.GetProperty("image").GetValue() as MediaWithCrops;

                var newsItem = new NewsItem
                {
                    Name = item.Name,
                    Summary = item.GetProperty("summary").GetValue() as string,
                    Body = item.GetProperty("body").GetValue() as string,
                    ImageUrl = imageProp.LocalCrops.Src,
                    UpdatedOn = item.UpdateDate,
                    CreatedOn = item.CreateDate
                };
                newsItems.Add(newsItem);
            }

            return newsItems;
        }
    }
}
