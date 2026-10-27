using Ecommerce.APIs.Response;
using Ecommerce.Core.Entities;
using Ecommerce.Repository.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        public BuggyController(EcommerceDbContext ecommerceDbContext)
        {
            _context = ecommerceDbContext;
        }

        [HttpGet("badrequest")]
        public async Task<IActionResult> GetBadRequstError()
        {
            return BadRequest(new ApiErrorResponse(400,"brand bad Request"));
        }
        [HttpGet("badrequest/{id}")]
        public async Task<IActionResult> GetBadRequstError(int id)
        {
            return BadRequest(new ApiErrorResponse(400));
        }


        [HttpGet("unauthorized")]
        public async Task<IActionResult> GetUnauthorizedError()
        {
            return Unauthorized(new ApiErrorResponse(401));
        }

        [HttpGet("notfound")]
        public async Task<IActionResult> GetNotFoundError()
        {
            var brand = await _context.Brands.FindAsync(100);
            if (brand is null)
            {
                return NotFound(new ApiErrorResponse(404)); 
               }else
            {
                return Ok(brand); 
            }
        }
        [HttpGet("servererror")]
        public async Task<IActionResult> GetServerError()
        {
            var brand = await _context.Brands.FindAsync(100);

            var brandToString = brand.ToString();
            return Ok(brand);
          
        }
    }
}
