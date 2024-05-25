using NewsPortal.Models;
using NewsPortal.Repositories.Data;

namespace NewsPortal.Repositories
{
    public class NewsCategoryRepository : RepositoryBase<NewsCategory>, INewsCategoryRepository
    {
        private readonly NewsPortalWebAPIContext context;

        public NewsCategoryRepository(NewsPortalWebAPIContext context) : base(context)
        {
            this.context = context;
        }
    }
}
