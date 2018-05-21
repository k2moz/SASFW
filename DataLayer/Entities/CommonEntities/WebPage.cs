using System;

namespace DataLayer.Entities.CommonEntities
{
    /// <summary>
    /// Web страница
    /// Базовый набор параметров любой web страницы
    /// </summary>
    public class WebPage
    {
        
        public string Author { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        
        public string PageName { get; set; }

        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        /// <summary>
        /// Seo Url
        /// </summary>
        public string SeoUrl { get; set; }

        public string PageStyles { get; set; }
        public string PageScripts { get; set; }
        public string PageHtml { get; set; }
    }
}
