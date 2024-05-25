using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public interface INewsArticleRepository 
    {
        Task<List<NewsArticleResponse>> GetAsync();
        Task<NewsArticleResponse> GetByIdAsync(int id);
        Task AddAsync(NewsArticle request);
        Task UpdateAsync(NewsArticle request);
        Task DeleteByIdAsync(int id);
        Task<PagedData<NewsArticleResponse>> GetByQueryParametersAsync(QueryParameters queryParameters);
    }
}
