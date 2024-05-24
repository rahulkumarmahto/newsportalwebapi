using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using NewsPortal.Models;
using NewsPortal.WebAPI.Data;
namespace NewsPortal.WebAPI.Controllers;

public static class NewsArticleEndpoints
{
    public static void MapNewsArticleEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/NewsArticle").WithTags(nameof(NewsArticle));

        group.MapGet("/", async (NewsPortalWebAPIContext db) =>
        {
            return await db.NewsArticle.ToListAsync();
        })
        .WithName("GetAllNewsArticles")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<NewsArticle>, NotFound>> (int id, NewsPortalWebAPIContext db) =>
        {
            return await db.NewsArticle.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is NewsArticle model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetNewsArticleById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, NewsArticle newsArticle, NewsPortalWebAPIContext db) =>
        {
            var affected = await db.NewsArticle
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, newsArticle.Id)
                    .SetProperty(m => m.Title, newsArticle.Title)
                    .SetProperty(m => m.Description, newsArticle.Description)
                    .SetProperty(m => m.CategoryId, newsArticle.CategoryId)
                    .SetProperty(m => m.CreatedBy, newsArticle.CreatedBy)
                    .SetProperty(m => m.CreatedDatetime, newsArticle.CreatedDatetime)
                    .SetProperty(m => m.ModifiedBy, newsArticle.ModifiedBy)
                    .SetProperty(m => m.ModifiedDatetime, newsArticle.ModifiedDatetime)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateNewsArticle")
        .WithOpenApi();

        group.MapPost("/", async (NewsArticle newsArticle, NewsPortalWebAPIContext db) =>
        {
            db.NewsArticle.Add(newsArticle);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/NewsArticle/{newsArticle.Id}",newsArticle);
        })
        .WithName("CreateNewsArticle")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, NewsPortalWebAPIContext db) =>
        {
            var affected = await db.NewsArticle
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteNewsArticle")
        .WithOpenApi();
    }
}
