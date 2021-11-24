using BlankUmbraco.Entities;
using BlankUmbraco.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace BlankUmbraco.Services
{
    public class NewsService : INewsService
    {
        private IPublishedContent Content => _content.GetByAlias("news");

        private readonly IUmbracoContent _content;

        public NewsService(IUmbracoContent content)
        {
            _content = content;
        }

        public NewsItem GetNewsItemById(int id)
        {
            try
            {
                var item = _content.GetById(id);
                if (item != null)
                {
                    var imageUrl = (item.GetProperty("image")?.GetValue() as MediaWithCrops)?.LocalCrops.Src;

                    var newsItem = new NewsItem
                    {
                        Name = item.Name,
                        Url = item.Url(),
                        Summary = item.GetProperty("summary")?.GetValue().ToString(),
                        Body = item.GetProperty("body")?.GetValue().ToString(),
                        ImageUrl = imageUrl,
                        UpdatedOn = item.UpdateDate,
                        CreatedOn = item.CreateDate
                    };

                    return newsItem;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return new NewsItem();
        }

        public ICollection<NewsItem> GetNewsItems()
        {
            var newsItems = new List<NewsItem>();

            try
            {
                var items = Content.Children.Where(q => q.ContentType.Alias == "newsItem").ToList();
                foreach (var item in items)
                {
                    var imageUrl = (item.GetProperty("image")?.GetValue() as MediaWithCrops)?.LocalCrops.Src;

                    var newsItem = new NewsItem
                    {
                        Name = item.Name,
                        Url = item.Url(),
                        Summary = item.GetProperty("summary")?.GetValue().ToString(),
                        Body = item.GetProperty("body")?.GetValue().ToString(),
                        ImageUrl = imageUrl,
                        UpdatedOn = item.UpdateDate,
                        CreatedOn = item.CreateDate
                    };
                    newsItems.Add(newsItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return newsItems;
        }
    }
}
