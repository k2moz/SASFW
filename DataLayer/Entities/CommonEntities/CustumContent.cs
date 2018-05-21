using DataLayer.Entities.CommonEntities;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    /// <summary>
    /// Кастомный контент на странице
    /// </summary>
    public class CustumContent
    {
        public int Id { get; set; }
        /// <summary>
        /// К какой странице еденица контента относится
        /// </summary>
        public int? MaterialId { get; set; } // внешний ключ

        public Material Material { get; set; } // навигационное свойство

        public string Title { get; set; }

        /// <summary>
        /// Краткое описание для снипета контента
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Html содержимое контента (как базовое доступное поле для еденицы контента)
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Кастомные поля для контента
        /// </summary>
        public List<CustumFieldValue> Fields { get; set; }

        /// <summary>
        /// Поле для сортировки
        /// </summary>
        public int? Order { get; set; }
    }
}
