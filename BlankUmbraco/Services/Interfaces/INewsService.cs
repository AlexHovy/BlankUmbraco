using BlankUmbraco.Entities;
using System.Collections.Generic;

namespace BlankUmbraco.Services.Interfaces
{
    public interface INewsService
    {
        ICollection<NewsItem> GetNewsItems();
    }
}
