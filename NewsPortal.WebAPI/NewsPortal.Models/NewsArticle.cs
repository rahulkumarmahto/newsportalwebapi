namespace NewsPortal.Models
{
    public class NewsArticle
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int CategoryId { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDatetime { get; set; }

    }
}
