using Ecommerce.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface IProductType
    {
        Task<IEnumerable<ProductTypeDto>> GetAllProductTypeAsync();
        Task<ProductTypeDto> GetProductTypeById(int id);


    }
}
