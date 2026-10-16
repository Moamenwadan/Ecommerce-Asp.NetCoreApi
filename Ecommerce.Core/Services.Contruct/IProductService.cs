using Ecommerce.Core.DTOS.ProductsDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductById(int id);

        Task<IEnumerable<ProductDto>> GetAllProductSpec(string? sort, int? brandId, int? typeId, int PageSize ,int PageIndex);
        Task<ProductDto> GetByIdSpec(int id);
    }
}
