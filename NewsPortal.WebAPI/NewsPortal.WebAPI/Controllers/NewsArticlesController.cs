using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;
using NewsPortal.Repositories.Data;
using NewsPortal.Services;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticlesController : ControllerBase
    {
        private readonly INewsArticleService _context;

        public NewsArticlesController(INewsArticleService context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetNewsArticle/{id}")]
        public async Task<ActionResult<NewsArticle>> GetNewsArticle(int id)
        {
            var newsArticle = await _context.GetByIdAsync(id);

            if (newsArticle == null)
            {
                return NotFound();
            }

            return newsArticle;
        }

        [HttpPut]
        [Route("UpdateNewsArticle/{id}")]

        public async Task<IActionResult> PutNewsArticle(int id, NewsArticle newsArticle)
        {
            if (id != newsArticle.Id)
            {
                return BadRequest();
            }

            await _context.UpdateAsync(newsArticle);

            return Ok();

        }

        [HttpPost]
        [Route("AddNewsArticle")]
        public async Task<ActionResult<NewsArticle>> PostNewsArticle(NewsArticle newsArticle)
        {
            await _context.AddAsync(newsArticle);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteNewsArticle/{id}")]
        public async Task<IActionResult> DeleteNewsArticle(int id)
        {
            await _context.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
