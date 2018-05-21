using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.CommonEntities
{
    /// <summary>
    /// Дерриктория страниц в рамках сайта
    /// </summary>
    public class Directory : SiteWebPage
    {
        /// <summary>
        /// Колличества запиисей на страницу
        /// </summary>
        public int? ItemsPerPage { get; set; }

        
        /// <summary>
        /// Redirect или Ajax открытие материалов
        /// </summary>
        public bool OpenDirectoryPagesWithAjax { get; set; }

        /// <summary>
        /// Список записей
        /// </summary>
        public List<Material> DirectoryPages { get; set; }
    }
}
