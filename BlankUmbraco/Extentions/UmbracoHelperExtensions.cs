using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;

namespace BlankUmbraco.Extentions
{
    public static class UmbracoHelperExtensions
    {
        public static string GetSiteLogo(this UmbracoHelper helper)
        {
            return helper.ContentSingleAtXPath("//home").GetProperty("siteLogo").GetValue() as string;
        }
    }
}
