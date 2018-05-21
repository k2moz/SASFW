namespace DataLayer.Entities.CommonEntities
{
    /// <summary>
    /// Данные кастомных полей
    /// </summary>
    public class CustumFieldValue
    {
        public int Id { get; set; }
        public int CustumFieldId { get; set; } // внешний ключ
        public CustumField CustumField { get; set; } // навигационное свойство

        public int CustumContentId { get; set; } // внешний ключ
        public CustumContent CustumContent { get; set; } // навигационное свойство

        public string Value { get; set; }

        public int? Order { get; set; }
        
    }
}
