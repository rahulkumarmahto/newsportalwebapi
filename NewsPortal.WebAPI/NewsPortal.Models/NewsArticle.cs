namespace NewsPortal.Models
{
    public class NewsArticle
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int NewsCategoryId { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }

    }

    public class NewsArticleResponse : NewsArticle
    {
        public string NewsCategoryName { get; set; }
    }


}
