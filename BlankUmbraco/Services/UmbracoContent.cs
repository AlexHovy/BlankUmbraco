using BlankUmbraco.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace BlankUmbraco.Services
{
    public class UmbracoContent : IUmbracoContent
    {
        private IPublishedContentCache Content => _umbracoContextFactory.EnsureUmbracoContext().UmbracoContext.Content;

        private IUmbracoContextFactory _umbracoContextFactory { get; set; }

        public UmbracoContent(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public IPublishedContent GetById(int id)
        {
            return Content.GetById(id);
        }
    }
}
