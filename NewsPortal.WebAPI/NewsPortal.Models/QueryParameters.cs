namespace NewsPortal.Models
{
    public class QueryParameters
    {
        public string? SearchText { get; set; }
        public int PageIndex { get; set; } = 1;
        public string SortBy { get; set; } = "Id";
        public string SortDirection { get; set; } = "DESC";
        public int PageSize { get; set; } = 5;
    }
}
