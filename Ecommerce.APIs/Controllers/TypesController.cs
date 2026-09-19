using Ecommerce.Core.Entities;
using Ecommerce.Core.Services.Contruct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IProductTypeService _productype ;
        public TypesController(IProductTypeService productype)
        {
         _productype = productype;   
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _productype.GetAllProductTypeAsync();
            if(!types.Any()) return NotFound("No Brands Found");
            return Ok(types);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0 || id == null) return BadRequest("Invalid Type ");
            var type = await _productype.GetProductTypeById(id);
            if (type==null) return NotFound("there is no Brands");
            return Ok(type);
        }
    }
}
