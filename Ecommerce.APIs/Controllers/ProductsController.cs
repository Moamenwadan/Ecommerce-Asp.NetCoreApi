using Ecommerce.Core.DTOS.ProductsDTOS;
using Ecommerce.Core.DTOS.ProductTypesDTOS;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Services.Contruct;
using Ecommerce.Service.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) {
            _productService= productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
     var products = await  _productService.GetAllProductAsync();
            if (products == null || !products.Any())
                return NotFound("No products found.");//404 NotFound
            return Ok(products);// 200 OK
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id <=0 || id == null)
             return BadRequest("Invalid product .");
            
            var product = await _productService.GetProductById(id);
            
            if (product == null)
            return NotFound("this Product doesn't exist");

            return Ok();// 200 OK
        }
    }
}
