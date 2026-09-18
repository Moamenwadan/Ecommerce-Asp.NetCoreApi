using Ecommerce.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface IProduct
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductById(int id);


    }
}
