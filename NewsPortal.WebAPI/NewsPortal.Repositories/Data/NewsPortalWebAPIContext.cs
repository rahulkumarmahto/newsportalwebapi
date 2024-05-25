using Microsoft.EntityFrameworkCore;

namespace NewsPortal.Repositories.Data
{
    public class NewsPortalWebAPIContext : DbContext
    {
        public NewsPortalWebAPIContext(DbContextOptions<NewsPortalWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<NewsPortal.Models.NewsArticle> NewsArticle { get; set; } = default!;
        public DbSet<NewsPortal.Models.NewsCategory> NewsCategory { get; set; } = default!;
    }
}
