using NewsPortal.Models;
using NewsPortal.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
