using Umbraco.Cms.Core.Models.PublishedContent;

namespace BlankUmbraco.Services.Interfaces
{
    public interface IUmbracoContent
    {
        IPublishedContent GetById(int id);
    }
}
