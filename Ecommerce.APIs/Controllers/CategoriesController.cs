using Ecommerce.Core.Services.Contruct;
using Ecommerce.Service.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService=categoryService; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Category = await _categoryService.GetAllCategoryAsync();
            if (!Category.Any()) return NotFound("There Is No Products yet");
            return Ok(Category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0 || id == null) return BadRequest("Invalid Category");

            var Category = await _categoryService.GetCategoryById(id);

            if(Category == null)
            return NotFound("this Category doesn't exist");
            
            return Ok(Category);
        }

        [HttpGet("{id}/Types")]
        public async Task<IActionResult> GetTypesByCategory(int id)
        {
            if (id <= 0) return BadRequest("Invalid Category");

            var Types = await _categoryService.GetTypesByCategoryIdAsync(id);

            if (Types == null || !Types.Any())
                return NotFound("This Category has no Types yet");

            return Ok(Types);
        }
    }
}
