using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using NewsPortal.Services;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticlesController : ControllerBase
    {
        private readonly INewsArticleService newsArticleService;

        public NewsArticlesController(INewsArticleService newsArticleService)
        {
            this.newsArticleService = newsArticleService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAdync()
        {
            var newsArticle = await newsArticleService.GetAsync();

            if (newsArticle == null)
            {
                return NoContent();
            }

            return Ok(newsArticle);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var newsArticle = await newsArticleService.GetByIdAsync(id);

            if (newsArticle == null)
            {
                return NoContent();
            }

            return Ok(newsArticle);
        }

        [HttpPut]
        [Route("UpdateById/{id}")]

        public async Task<IActionResult> UpdateByIdAsync([FromRoute] int id, [FromBody] NewsArticle newsArticle)
        {
            if (id != newsArticle.Id)
            {
                return BadRequest();
            }

            await newsArticleService.UpdateAsync(newsArticle);

            return Ok();

        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync([FromBody] NewsArticle newsArticle)
        {
            await newsArticleService.AddAsync(newsArticle);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            await newsArticleService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetByQueryParameters")]
        public async Task<IActionResult> GetByQueryParametersAsync([FromQuery] QueryParameters queryParameters)
        {
            if (queryParameters is null)
                throw new ArgumentNullException(nameof(queryParameters));

            var result = await this.newsArticleService.GetByQueryParametersAsync(queryParameters);
            return Ok(result);
        }
    }
}
