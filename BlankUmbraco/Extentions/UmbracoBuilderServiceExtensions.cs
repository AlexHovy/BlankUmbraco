using BlankUmbraco.Services;
using BlankUmbraco.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace BlankUmbraco.Extensions
{
    public static class UmbracoBuilderServiceExtensions
    {
        public static IUmbracoBuilder AddCustomServices(this IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IUmbracoContent, UmbracoContent>();
            builder.Services.AddScoped<INewsService, NewsService>();

            return builder;
        }
    }
}
