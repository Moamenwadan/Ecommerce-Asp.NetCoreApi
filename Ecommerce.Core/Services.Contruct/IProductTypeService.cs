using Ecommerce.Core.DTOS.ProductTypesDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductTypeDto>> GetAllProductTypeAsync();
        Task<ProductTypeDto> GetProductTypeById(int id);


    }
}
