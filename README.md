# NEWSPortal API with ASP.NET Core 8

<a href="https://github.com/rahulkumarmahto/newsportalwebapi"></a>

This is the code repository for [Web API Development with ASP.NET Core 8](https://github.com/rahulkumarmahto/newsportalwebapi), published by Rahul Kumar Mahto.

**Learn techniques, patterns, and tools for building high-performance, robust, and scalable web APIs**

## What is this project about?
The api provides the feature of managing the news articles.
	
This API covers the following exciting features:
* Build a strong foundation in web API fundamentals
* Explore the ASP.NET Core 8 framework and other industry-standard libraries and tools for high-performance, scalable web APIs
* Apply essential software design patterns such as MVC, dependency injection, and the repository pattern
* Use Entity Framework Core for database operations and complex query creation

## Instructions and Navigations
All of the code is organized into folders. For example

The code will look like the following:

![image](https://github.com/rahulkumarmahto/newsportalwebapi/assets/48170575/54ffde27-04f5-4914-b8be-36c28e62f37e)

```
namespace NewsPortal.Models;
{
    public class NewsArticle
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int NewsCategoryId { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }

    public class NewsArticleResponse : NewsArticle
    {
        public string NewsCategoryName { get; set; }
    }

    public class NewsCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
    }
}

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


```

## Software and Hardware List

| Chapter  | Software required                        | OS required                   |
| -------- | -----------------------------------------| ------------------------------|
| 1-18     | Visual Studio 2022 Community Edition     | Windows, macOS, or Linux      |



