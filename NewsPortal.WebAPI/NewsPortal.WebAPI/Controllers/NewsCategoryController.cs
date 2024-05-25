using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using NewsPortal.Services;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCategoryController : ControllerBase
    {
        private readonly INewsCategoryService newsCategoryService;

        public NewsCategoryController(INewsCategoryService newsCategoryService)
        {
            this.newsCategoryService = newsCategoryService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAsync()
        {
            var newsArticle = await newsCategoryService.GetAsync();

            if (newsArticle == null)
            {
                return NoContent();
            }

            return Ok(newsArticle);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var newsArticle = await newsCategoryService.GetByIdAsync(id);

            if (newsArticle == null)
            {
                return NoContent();
            }

            return Ok(newsArticle);
        }

        [HttpPut]
        [Route("UpdateById/{id}")]

        public async Task<IActionResult> UpdateByIdAsync(int id, NewsCategory request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            await newsCategoryService.UpdateAsync(request);

            return Ok();

        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(NewsCategory request)
        {
            await newsCategoryService.AddAsync(request);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            await newsCategoryService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
