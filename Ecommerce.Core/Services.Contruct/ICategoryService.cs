using Ecommerce.Core.DTOS.CategoryDTOS;
using Ecommerce.Core.DTOS.ProductTypesDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface ICategoryService
    {
       Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();

        Task<CategoryDto> GetCategoryById(int id);

        Task<IEnumerable<ProductTypeDto>> GetTypesByCategoryIdAsync(int categoryId);

    }
}
