using Ecommerce.Core.DTOS.ProductsDTOS;
using Ecommerce.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductById(int id);

        Task<PaginationResponse<ProductDto>> GetAllProductSpec(string? sort, int? brandId, int? typeId, int PageSize ,int PageIndex, string? search);
        Task<ProductDto> GetByIdSpec(int id);
    }
}
