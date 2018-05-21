namespace DataLayer.Entities.CommonEntities
{
    /// <summary>
    /// Страница в рамках системы
    /// С данными и привязками
    /// </summary>
    public class SiteWebPage : WebPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public PageStatusEnum Status { get; set; }
        public int? Order { get; set; }
    }
}
