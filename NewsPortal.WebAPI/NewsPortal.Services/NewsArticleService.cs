using NewsPortal.Models;
using NewsPortal.Repositories;

namespace NewsPortal.Services
{
    public interface INewsArticleService
    {
        Task<NewsArticle> GetByIdAsync(int id);
        Task AddAsync(NewsArticle request);
        Task UpdateAsync(NewsArticle request);
        Task DeleteByIdAsync(int id);
        Task<List<NewsArticle>> GetAsync();
    }

    public class NewsArticleService : INewsArticleService
    {
        private INewsArticleRepository newsArticleRepository;

        public NewsArticleService(INewsArticleRepository newsArticleRepository)
        {
            this.newsArticleRepository = newsArticleRepository;
        }

        public async Task AddAsync(NewsArticle request)
        {
            await this.newsArticleRepository.AddAsync(request).ConfigureAwait(false);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await this.newsArticleRepository.DeleteByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<List<NewsArticle>> GetAsync()
        {
           return await this.newsArticleRepository.GetAsync().ConfigureAwait(false);
        }

        public async Task<NewsArticle> GetByIdAsync(int id)
        {
            return await this.newsArticleRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task UpdateAsync(NewsArticle request)
        {
            await this.newsArticleRepository.UpdateAsync(request).ConfigureAwait(false);
        }
    }
}
