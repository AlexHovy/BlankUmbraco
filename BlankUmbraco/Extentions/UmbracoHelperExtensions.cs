using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Views;

namespace BlankUmbraco.Extentions
{
    public static class UmbracoHelperExtensions
    {
        public static string GetValue(this IPublishedContent content, string alias)
        {
            return content.GetProperty(alias).GetValue() as string;
        }

        public static string GetImageUrl(this IPublishedContent content, string alias)
        {
            var imageProp = content.GetProperty(alias).GetValue() as MediaWithCrops;
            return imageProp.LocalCrops.Src;
        }
    }
}
