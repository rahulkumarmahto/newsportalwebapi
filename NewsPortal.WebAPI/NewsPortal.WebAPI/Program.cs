using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.WebAPI.Data;
using NewsPortal.WebAPI.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NewsPortalWebAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewsPortalWebAPIContext") ?? throw new InvalidOperationException("Connection string 'NewsPortalWebAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapNewsArticleEndpoints();

app.Run();
