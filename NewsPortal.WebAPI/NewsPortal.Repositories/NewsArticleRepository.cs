using NewsPortal.Models;
using NewsPortal.Repositories.Data;

namespace NewsPortal.Repositories
{
    public class NewsArticleRepository : RepositoryBase<NewsArticle>, 
        INewsArticleRepository
    {
        private readonly NewsPortalWebAPIContext context;

        protected NewsArticleRepository(NewsPortalWebAPIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
