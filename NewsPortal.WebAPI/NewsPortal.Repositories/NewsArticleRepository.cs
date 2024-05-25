using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;
using NewsPortal.Repositories.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewsPortal.Repositories
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly NewsPortalWebAPIContext context;

        public NewsArticleRepository(NewsPortalWebAPIContext context)
        {
            this.context = context;
        }

        public async Task<List<NewsArticleResponse>> GetAsync()
        {
            var entity = context.NewsArticle.Join(context.NewsCategory, a => a.NewsCategoryId, c => c.Id, (a, c) => new NewsArticleResponse()
            {
                CreatedBy = a.CreatedBy,
                CreatedDateTime = a.CreatedDateTime,
                Description = a.Description,
                Id = a.Id,
                ModifiedBy = a.ModifiedBy,
                Title = a.Title,
                ModifiedDateTime = a.ModifiedDateTime,
                NewsCategoryId = a.NewsCategoryId,
                NewsCategoryName = c.Name,
            });

            return await entity.ToListAsync();
        }

        public async Task<NewsArticleResponse> GetByIdAsync(int id)
        {
            var entity = await context.NewsArticle.Join(context.NewsCategory, a => a.NewsCategoryId, c => c.Id, (a, c) => new NewsArticleResponse()
            {
                CreatedBy = a.CreatedBy,
                CreatedDateTime = a.CreatedDateTime,
                Description = a.Description,
                Id = a.Id,
                ModifiedBy = a.ModifiedBy,
                Title = a.Title,
                ModifiedDateTime = a.ModifiedDateTime,
                NewsCategoryId = a.NewsCategoryId,
                NewsCategoryName = c.Name,
            }).FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
        public async Task AddAsync(NewsArticle request)
        {
            await context.NewsArticle.AddAsync(request).ConfigureAwait(false);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(NewsArticle request)
        {
            context.Entry(request).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await context.NewsArticle.FindAsync(id);

            if (entity == null)
                return;

            context.NewsArticle.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<PagedData<NewsArticleResponse>> GetByQueryParametersAsync(QueryParameters queryParameters)
        {
            var data = await context.NewsArticle.Join(context.NewsCategory, a => a.NewsCategoryId, c => c.Id, (a, c) => new NewsArticleResponse()
            {
                CreatedBy = a.CreatedBy,
                CreatedDateTime = a.CreatedDateTime,
                Description = a.Description,
                Id = a.Id,
                ModifiedBy = a.ModifiedBy,
                Title = a.Title,
                ModifiedDateTime = a.ModifiedDateTime,
                NewsCategoryId = a.NewsCategoryId,
                NewsCategoryName = c.Name,
            })
            .Where(x => string.IsNullOrEmpty(queryParameters.SearchText) 
                || x.Description.Contains(queryParameters.SearchText)
                || x.Title.Contains(queryParameters.SearchText)
                || x.NewsCategoryName.Contains(queryParameters.SearchText))
            .Skip(queryParameters.PageSize * (queryParameters.PageIndex - 1))
            .Take(queryParameters.PageSize)
            .OrderByDescending(x => x.CreatedDateTime)
            .ToListAsync();

            int totalRecordCount = await context.NewsArticle.CountAsync().ConfigureAwait(false);
            int matchingRecordCount = data.Count;

            PagedData<NewsArticleResponse> pagedData = new PagedData<NewsArticleResponse>()
            {
                CurrentPage = queryParameters.PageIndex,
                Items = data.ToList(),
                MatchingRecordCount = matchingRecordCount,
                PageSize = queryParameters.PageSize,
                TotalCount = totalRecordCount,
                TotalPages = string.IsNullOrEmpty(queryParameters.SearchText)
                   ? (int)Math.Ceiling(totalRecordCount / (double)queryParameters.PageSize)
                   : (int)Math.Ceiling(matchingRecordCount / (double)queryParameters.PageSize)
            };

            return pagedData;

        }
    }
}