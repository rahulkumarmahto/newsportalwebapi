namespace NewsPortal.Models
{
    public class NewsArticle
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int NewsCategoryId { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

    }

    public class NewsArticleResponse : NewsArticle
    {
        public string NewsCategoryName { get; set; }
    }


}
