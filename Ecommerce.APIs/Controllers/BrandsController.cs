using Ecommerce.Core.Services.Contruct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllBrandAsync();
            if (!brands.Any()) return NotFound("There Is No brands yet");
            return Ok(brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0 || id == null) return BadRequest("Invalid brand");

            var brand = await _brandService.GetBrandById(id);

            if (brand == null)
                return NotFound("this brand doesn't exist");

            return Ok(brand);
        }
    }
}
