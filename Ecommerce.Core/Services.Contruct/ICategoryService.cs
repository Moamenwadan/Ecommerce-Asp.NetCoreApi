using Ecommerce.Core.DTOS.CategoryDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface ICategoryService
    {
       Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();

        Task<CategoryDto> GetCategoryById(int id);

    }
}
