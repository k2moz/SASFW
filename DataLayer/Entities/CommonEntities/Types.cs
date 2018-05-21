namespace DataLayer.Entities.CommonEntities
{
    /// <summary>
    /// Типы данны в рамках системы
    /// </summary>
    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// К какому типу сущностей относится данный тип данных
        /// </summary>
        public EntitiesEnum EntityType { get; set; }
        public int? Order { get; set; }
    }
}
