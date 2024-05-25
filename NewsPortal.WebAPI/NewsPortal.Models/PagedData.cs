namespace NewsPortal.Models
{
    public class PagedData<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public int ItemsCount => Items.Count;
        public int MatchingRecordCount { get; set; }
        public List<T>? Items { get; set; }
    }
}
