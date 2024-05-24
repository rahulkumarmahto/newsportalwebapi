using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;

namespace NewsPortal.WebAPI.Data
{
    public class NewsPortalWebAPIContext : DbContext
    {
        public NewsPortalWebAPIContext (DbContextOptions<NewsPortalWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<NewsPortal.Models.NewsArticle> NewsArticle { get; set; } = default!;
    }
}
