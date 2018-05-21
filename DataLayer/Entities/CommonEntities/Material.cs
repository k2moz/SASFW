using System.Collections.Generic;

namespace DataLayer.Entities.CommonEntities
{
    /// <summary>
    /// Страница в рамках сайта
    /// </summary>
    public class Material : SiteWebPage
    {
        public int DirectoryId { get; set; } // внешний ключ
        public Directory Directory { get; set; }  // навигационное свойство

        public string Category { get; set; }
        /// <summary>
        /// Список кастомных элементов страницы
        /// </summary>
        public List<CustumContent> ContentsList { get; set; }
    }
}
