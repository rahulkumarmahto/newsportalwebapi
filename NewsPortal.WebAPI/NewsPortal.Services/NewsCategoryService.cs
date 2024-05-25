using NewsPortal.Models;
using NewsPortal.Repositories;

namespace NewsPortal.Services
{
    public interface INewsCategoryService
    {
        Task<NewsCategory> GetByIdAsync(int id);
        Task AddAsync(NewsCategory request);
        Task UpdateAsync(NewsCategory request);
        Task DeleteByIdAsync(int id);
        Task<List<NewsCategory>> GetAsync();
    }
    public class NewsCategoryService : INewsCategoryService
    {
        private readonly INewsCategoryRepository newsCategoryRepository;

        public NewsCategoryService(INewsCategoryRepository newsCategoryRepository)
        {
            this.newsCategoryRepository = newsCategoryRepository;
        }

        public async Task AddAsync(NewsCategory request)
        {
            await this.newsCategoryRepository.AddAsync(request).ConfigureAwait(false);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await this.newsCategoryRepository.DeleteByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<List<NewsCategory>> GetAsync()
        {
            return await this.newsCategoryRepository.GetAsync();
        }

        public async Task<NewsCategory> GetByIdAsync(int id)
        {
           return await this.newsCategoryRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task UpdateAsync(NewsCategory request)
        {
            await this.newsCategoryRepository.UpdateAsync(request).ConfigureAwait(false);
        }
    }
}
