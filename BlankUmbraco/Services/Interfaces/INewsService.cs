using BlankUmbraco.Entities;
using System.Collections.Generic;

namespace BlankUmbraco.Services.Interfaces
{
    public interface INewsService
    {
        NewsItem GetNewsItemById(int id);
        ICollection<NewsItem> GetNewsItems();
    }
}
