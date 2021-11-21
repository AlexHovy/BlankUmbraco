﻿using BlankUmbraco.Entities;
using BlankUmbraco.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

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

        public ICollection<NewsItem> GetNewsItems()
        {
            var newsItems = new List<NewsItem>();

            try
            {
                var items = Content.Children.Where(q => q.ContentType.Alias == "newsItem").ToList();
                foreach (var item in items)
                {
                    var imageProp = item.GetProperty("image")?.GetValue() as MediaWithCrops;

                    var newsItem = new NewsItem
                    {
                        Name = item.Name,
                        Url = string.Concat(item.Parent.UrlSegment, "/", item.UrlSegment),
                        Summary = item.GetProperty("summary")?.GetValue() as string,
                        Body = item.GetProperty("body")?.GetValue() as string,
                        ImageUrl = imageProp?.LocalCrops.Src,
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
