using System;

namespace BlankUmbraco.Entities
{
    public class NewsItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
