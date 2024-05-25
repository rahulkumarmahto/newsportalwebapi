namespace NewsPortal.Models
{
    public class NewsCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
    }
}
